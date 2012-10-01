using System;
using System.Collections.Generic;
using System.Drawing;//Font
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

using System.Security.Permissions;//SecurityPermission
using System.Runtime.Serialization;//ISerializable

using Xenon.Operating;//TextAlign

namespace Xenon.GridPanel
{
    // フォーム・デザイナーのツール・ボックスに追加できるようにシリアライズ可能の指定。
    [Serializable()]
    public class TicklabelImpl : ISerializable, Ticklabel
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public TicklabelImpl()
        {
            this.bHorizontal = true;
            this.nSize_FontPt = 12.0F;
            this.sName_ForegroundBrush = "Black";
            this.nFirst_Label = 1;
            this.nOffset_Label = 1;
            this.Textalign = EnumTextalign.Left;
        }

        protected TicklabelImpl(SerializationInfo info, StreamingContext context)
        {
            //
            // (1)表示内容のプロパティー
            //

            // 目盛りラベルの１つ進むたびの増分。
            nOffset_Label = info.GetInt32("labelOffset");

            // 目盛りラベルの最初の数字。
            nFirst_Label = info.GetInt32("labelFirst");

            //
            // (2)表示位置と向きとサイズのプロパティー
            //

            // 端っこの座標。（xまたはy）
            nLocation_First = info.GetInt32("firstLocation");

            // 端っこの座標の反対軸。（xまたはy）
            nLocation_Fixed = info.GetInt32("fixedLocation");

            // 全体のピクセルの長さ。（widthまたはheight）
            nLength_Total = info.GetInt32("totalLength");

            // セルの間隔。ピクセルでの長さ。（widthまたはheight）
            nInterval_Cell = info.GetInt32("cellInterval");

            // ラベルの文字列幅。ピクセルでの長さ。
            // 垂直方向に並んだラベルでは cellInterval とは値が一致しないことがあることに対応した設定。
            nWidth_Label = info.GetInt32("labelWidth");

            // 水平なら真、垂直なら偽。
            bHorizontal = info.GetBoolean("horizontal");

            //
            // (3)スタイルのプロパティー
            //

            // 描画色のブラシの名前。C#のBrushesで定義されているブラシ変数と同名。既定値は "Black"。
            // 
            // Brushクラスはシリアライズ化できなかったので止めた。
            sName_ForegroundBrush = info.GetString("foregroundBrushName");

            // フォントのサイズ。単位はpoint(pt)。
            nSize_FontPt = info.GetSingle("fontSizePt"); // float型は Single （Visual Basic準拠）

            // ラベルの水平の位置揃え。
            textalign = (EnumTextalign)info.GetValue("textAlign", Textalign.GetType());

            // 表示するなら真。
            bVisibled = info.GetBoolean("visibled");
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// シリアライズ。
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //
            // (1)表示内容のプロパティー
            //

            // 目盛りラベルの１つ進むたびの増分。
            info.AddValue("labelOffset", nOffset_Label);

            // 目盛りラベルの最初の数字。
            info.AddValue("labelFirst", nFirst_Label);

            //
            // (2)表示位置と向きとサイズのプロパティー
            //

            // 端っこの座標。（xまたはy）
            info.AddValue("firstLocation", nLocation_First);

            // 端っこの座標の反対軸。（xまたはy）
            info.AddValue("fixedLocation", nLocation_Fixed);

            // 全体のピクセルの長さ。（widthまたはheight）
            info.AddValue("totalLength", nLength_Total);

            // セルの間隔。ピクセルでの長さ。（widthまたはheight）
            info.AddValue("cellInterval", nInterval_Cell);

            // ラベルの文字列幅。ピクセルでの長さ。
            // 垂直方向に並んだラベルでは cellInterval とは値が一致しないことがあることに対応した設定。
            info.AddValue("labelWidth", nWidth_Label);

            // 水平なら真、垂直なら偽。
            info.AddValue("horizontal", bHorizontal);

            //
            // (3)スタイルのプロパティー
            //

            // 描画色のブラシの名前。C#のBrushesで定義されているブラシ変数と同名。既定値は "Black"。
            // 
            // Brushクラスはシリアライズ化できなかったので止めた。
            info.AddValue("foregroundBrushName", sName_ForegroundBrush);

            // フォントのサイズ。単位はpoint(pt)。
            info.AddValue("fontSizePt", nSize_FontPt);

            // ラベルの水平の位置揃え。
            info.AddValue("textAlign", textalign);

            // 表示するなら真。
            info.AddValue("visibled", bVisibled);
        }


        /// <summary>
        /// 描画。
        /// </summary>
        /// <param name="e"></param>
        public void Paint(Graphics g, Point parentLocation)
        {
            Font font = new Font("Arial", this.Size_FontPt);

            if(this.IsVisibled)
            {
                StringFormat stringFormat = new StringFormat();

                if (this.IsHorizontal)
                {
                    //
                    // 水平に並ぶ目盛りなら
                    //
                    int labelCurrent = this.Number_LabelFirst;
                    int lastTick = this.Number_LocationFirst + this.Length_Total;

                    // 垂直線
                    for (int tick = this.Number_LocationFirst; tick < lastTick; tick += this.Interval_Cell)
                    {
                        string labelString = labelCurrent.ToString();
                        SizeF fontSize = g.MeasureString(labelString, font);

                        float offsetX;
                        switch (this.Textalign)
                        {
                            case EnumTextalign.Center:
                                offsetX = this.Width_Label / 2.0F - fontSize.Width / 2.0F;
                                break;
                            case EnumTextalign.Right:
                                offsetX = this.Width_Label - fontSize.Width;
                                break;
                            default:
                            //case TextAlign.Left:
                                offsetX = 0;
                                break;
                        }

                        g.DrawString(
                            labelString,
                            font,
                            BuilderBrush.Parse(this.Name_ForegroundBrush),
                            (float)tick + offsetX + parentLocation.X + this.OffsetPixel_FirstItem,
                            this.Number_LocationFixed + parentLocation.Y
                            );
                        labelCurrent += this.Offset_Label;
                    }
                }
                else
                {
                    //
                    // 垂直に並ぶ目盛りなら
                    //
                    int labelCurrent = this.Number_LabelFirst;
                    int lastTick = this.Number_LocationFirst + this.Length_Total;

                    // 水平線
                    for (int nTick = this.Number_LocationFirst; nTick < lastTick; nTick += this.Interval_Cell)
                    {
                        string sLabel = labelCurrent.ToString();
                        SizeF fontSize = g.MeasureString(sLabel, font);

                        float offsetX;
                        switch (this.Textalign)
                        {
                            case EnumTextalign.Center:
                                offsetX = this.Width_Label / 2.0F - fontSize.Width / 2.0F;
                                break;
                            case EnumTextalign.Right:
                                offsetX = this.Width_Label - fontSize.Width;
                                break;
                            default:
                                //case TextAlign.Left:
                                offsetX = 0;
                                break;
                        }

                        g.DrawString(
                            labelCurrent.ToString(),
                            font,
                            BuilderBrush.Parse(this.Name_ForegroundBrush),
                            this.Number_LocationFixed + offsetX + parentLocation.X,
                            nTick + parentLocation.Y + this.OffsetPixel_FirstItem
                            );
                        labelCurrent += this.Offset_Label;
                    }
                }
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー

        //────────────────────────────────────────
        //
        //（１）表示内容のプロパティー
        //

        private int nFirst_Label;

        /// <summary>
        /// 目盛りラベルの最初の数字。
        /// </summary>
        public int Number_LabelFirst
        {
            set
            {
                nFirst_Label = value;
            }
            get
            {
                return nFirst_Label;
            }
        }

        //────────────────────────────────────────

        private int nOffset_Label;

        /// <summary>
        /// 目盛りラベルの１つ進むたびの増分。
        /// </summary>
        public int Offset_Label
        {
            set
            {
                nOffset_Label = value;
            }
            get
            {
                return nOffset_Label;
            }
        }

        //────────────────────────────────────────
        //
        // (2)表示位置と向きとサイズのプロパティー
        //

        private int nLocation_First;

        /// <summary>
        /// 端っこの座標。（xまたはy）
        /// </summary>
        public int Number_LocationFirst
        {
            set
            {
                nLocation_First = value;
            }
            get
            {
                return nLocation_First;
            }
        }

        //────────────────────────────────────────

        private int nLocation_Fixed;

        /// <summary>
        /// 端っこの座標の反対軸。（xまたはy）
        /// </summary>
        public int Number_LocationFixed
        {
            set
            {
                nLocation_Fixed = value;
            }
            get
            {
                return nLocation_Fixed;
            }
        }

        //────────────────────────────────────────

        private int nLength_Total;

        /// <summary>
        /// 全体のピクセルの長さ。（widthまたはheight）
        /// </summary>
        public int Length_Total
        {
            set
            {
                nLength_Total = value;
            }
            get
            {
                return nLength_Total;
            }
        }

        //────────────────────────────────────────

        private int nInterval_Cell;

        /// <summary>
        /// セルの間隔。ピクセルでの長さ。（widthまたはheight）
        /// </summary>
        public int Interval_Cell
        {
            set
            {
                nInterval_Cell = value;
            }
            get
            {
                return nInterval_Cell;
            }
        }

        //────────────────────────────────────────

        private int nWidth_Label;

        /// <summary>
        /// ラベルの文字列幅。ピクセルでの長さ。
        /// 垂直方向に並んだラベルでは cellInterval とは値が一致しないことがあることに対応した設定。
        /// </summary>
        public int Width_Label
        {
            set
            {
                nWidth_Label = value;
            }
            get
            {
                return nWidth_Label;
            }
        }

        //────────────────────────────────────────

        private bool bHorizontal;

        /// <summary>
        /// 水平なら真、垂直なら偽。
        /// </summary>
        public bool IsHorizontal
        {
            set
            {
                bHorizontal = value;
            }
            get
            {
                return bHorizontal;
            }
        }

        //────────────────────────────────────────
        //
        //（３）スタイルのプロパティー
        //

        private bool bVisibled;

        /// <summary>
        /// 表示するなら真。
        /// </summary>
        public bool IsVisibled
        {
            set
            {
                bVisibled = value;
            }
            get
            {
                return bVisibled;
            }
        }

        //────────────────────────────────────────

        private string sName_ForegroundBrush;

        /// <summary>
        /// 描画色のブラシの名前。C#のBrushesで定義されているブラシ変数と同名。既定値は "Black"。
        /// 
        /// Brushクラスはシリアライズ化できなかったので止めた。
        /// </summary>
        public string Name_ForegroundBrush
        {
            set
            {
                sName_ForegroundBrush = value;
            }
            get
            {
                return sName_ForegroundBrush;
            }
        }

        //────────────────────────────────────────

        private float nSize_FontPt;

        /// <summary>
        /// フォントのサイズ。単位はpoint(pt)。
        /// </summary>
        public float Size_FontPt
        {
            set
            {
                nSize_FontPt = value;
            }
            get
            {
                return nSize_FontPt;
            }
        }

        //────────────────────────────────────────

        private EnumTextalign textalign;

        /// <summary>
        /// ラベルの水平の位置揃え。
        /// </summary>
        public EnumTextalign Textalign
        {
            set
            {
                textalign = value;
            }
            get
            {
                return textalign;
            }
        }

        //────────────────────────────────────────

        private int nOffsetPixel_FirstItem;

        /// <summary>
        /// 最初の項目を、ピクセル単位でずらして位置調整することができます。
        /// </summary>
        public int OffsetPixel_FirstItem
        {
            get
            {
                return nOffsetPixel_FirstItem;
            }
            set
            {
                nOffsetPixel_FirstItem = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }

}
