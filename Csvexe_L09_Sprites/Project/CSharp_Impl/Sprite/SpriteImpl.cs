using System;
using System.Collections.Generic;
using System.Drawing;//Bitmap
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

using Xenon.Syntax;

///
/// スプライトを画面上で動かすクラスが入る名前空間。
///
namespace Xenon.Sprites
{
    /// <summary>
    /// 画面上に配置される画像データ。
    /// </summary>
    public class SpriteImpl : Sprite
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// スプライトの配置位置が妥当か不妥当かを判定するメソッドのデリゲーター。
        /// </summary>
        private DLGT_CheckLocationValid dlgt_CheckLocationValid;

        //────────────────────────────────────────

        private static readonly Font WARNING_MESSAGE_FONT = new Font("Arial", 12);

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public SpriteImpl(string sLogStack)
        {
            // 1回設定するだけでＯＫなデリゲーター
            this.dlgt_CheckLocationValid = null;

            this.sLogStack = sLogStack;

            this.boundsLefttopOriginal = new Rectangle();
            this.boundsLefttopScaled = new Rectangle();
            this.nScale = 1.0F;
            this.font = new Font("Arial", 12);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 赤い枠と×印を描画します。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="parentLocation"></param>
        /// <param name="sMsg">「画像が見つかりません」「配置場所が不妥当です」など</param>
        /// <param name="modelOfSprDic"></param>
        private void PaintRedCross(
            Graphics g,
            Point parentLocation,
            string sMsg,
            MemorySpriteDictionary moSpriteMouse
            )
        {
            // 等倍表示も、倍角表示も　描画処理は同じ。
            // 矩形（4px桃色）
            g.DrawRectangle(
                moSpriteMouse.BorderPen4OnInvalid,//ペン
                this.BoundsLefttopScaled.X + parentLocation.X,
                this.BoundsLefttopScaled.Y + parentLocation.Y,
                this.BoundsLefttopScaled.Width,
                this.BoundsLefttopScaled.Height
                );
            // ×印の斜線（4px桃色）
            g.DrawLine(
                moSpriteMouse.BorderPen4OnInvalid,//ペン
                this.BoundsLefttopScaled.X + parentLocation.X,
                this.BoundsLefttopScaled.Y + parentLocation.Y,
                this.BoundsLefttopScaled.X + this.BoundsLefttopScaled.Width + parentLocation.X,
                this.BoundsLefttopScaled.Y + this.BoundsLefttopScaled.Height + parentLocation.Y
                );
            // ×印の斜線（4px桃色）
            g.DrawLine(
                moSpriteMouse.BorderPen4OnInvalid,//ペン
                this.BoundsLefttopScaled.X + parentLocation.X,
                this.BoundsLefttopScaled.Y + this.BoundsLefttopScaled.Height + parentLocation.Y,
                this.BoundsLefttopScaled.X + this.BoundsLefttopScaled.Width + parentLocation.X,
                this.BoundsLefttopScaled.Y + parentLocation.Y
                );


            // 等倍表示も、倍角表示も　描画処理は同じ。
            // 矩形（2px赤色）
            g.DrawRectangle(
                moSpriteMouse.BorderPen2OnInvalid,//ペン
                this.BoundsLefttopScaled.X + parentLocation.X,
                this.BoundsLefttopScaled.Y + parentLocation.Y,
                this.BoundsLefttopScaled.Width,
                this.BoundsLefttopScaled.Height
                );
            // ×印の斜線（2px赤色）
            g.DrawLine(
                moSpriteMouse.BorderPen2OnInvalid,//ペン
                this.BoundsLefttopScaled.X + parentLocation.X,
                this.BoundsLefttopScaled.Y + parentLocation.Y,
                this.BoundsLefttopScaled.X + this.BoundsLefttopScaled.Width + parentLocation.X,
                this.BoundsLefttopScaled.Y + this.BoundsLefttopScaled.Height + parentLocation.Y
                );
            // ×印の斜線（2px赤色）
            g.DrawLine(
                moSpriteMouse.BorderPen2OnInvalid,//ペン
                this.BoundsLefttopScaled.X + parentLocation.X,
                this.BoundsLefttopScaled.Y + this.BoundsLefttopScaled.Height + parentLocation.Y,
                this.BoundsLefttopScaled.X + this.BoundsLefttopScaled.Width + parentLocation.X,
                this.BoundsLefttopScaled.Y + parentLocation.Y
                );

            g.DrawString(
                sMsg,
                WARNING_MESSAGE_FONT,
                moSpriteMouse.BorderBrushOnInvalid,
                this.BoundsLefttopScaled.X + parentLocation.X,
                this.BoundsLefttopScaled.Y + this.BoundsLefttopScaled.Height + parentLocation.Y
                );
        }

        //────────────────────────────────────────

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        /// <param name="modelOfSprDic"></param>
        /// <param name="pg_Logging"></param>
        public void Paint(
            Graphics g,
            Point parentLocation,
            MemorySpriteDictionary moSprDic,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Sprite.SName_Library, this, "Paint",pg_Logging);

            Exception err_Excp;
            try
            {
                if (null == this.Bmp)
                {
                    // 画像の読取りに失敗している場合は、

                    // 白い影を持った赤い線の四角を表示します。中には×を描きます。

                    this.PaintRedCross(
                        g,
                        parentLocation,
                        "画像が見つかりません",
                        moSprDic
                        );
                }
                else
                {
                    // 画像の読取に成功している場合のみ

                    // 等倍表示も、倍角表示も　描画処理は同じ。
                    g.DrawImage(
                        this.Bmp,
                        this.BoundsLefttopScaled.X + parentLocation.X,
                        this.BoundsLefttopScaled.Y + parentLocation.Y,
                        this.BoundsLefttopScaled.Width,
                        this.BoundsLefttopScaled.Height
                        );
                }

                // 選択時：2x2ブロックに枠を表示。
                if (this.BSelected)
                {
                    // 等倍表示も、倍角表示も　描画処理は同じ。
                    g.DrawRectangle(
                        moSprDic.BorderPen4OnSelected,
                        this.BoundsLefttopScaled.X + parentLocation.X,
                        this.BoundsLefttopScaled.Y + parentLocation.Y,
                        this.BoundsLefttopScaled.Width,
                        this.BoundsLefttopScaled.Height
                        );
                    g.FillRectangle(
                        moSprDic.BorderBrushOnSelected,
                        this.BoundsLefttopScaled.X + parentLocation.X,
                        this.BoundsLefttopScaled.Y + parentLocation.Y,
                        this.BoundsLefttopScaled.Width,
                        this.BoundsLefttopScaled.Height
                        );
                }

                //
                // 不妥当配置の警告表示
                //
                // 
                //
                if (null != this.dlgt_CheckLocationValid)
                {
                    string sMsg = "";//不妥当だった場合、原因。
                    bool locationValid = this.dlgt_CheckLocationValid(this, parentLocation, ref sMsg);

                    if (!locationValid)
                    {
                        // 不妥当な位置にスプライトが配置されていれば、
                        // 警告を表示します。

                        // 白い影を持った赤い線の四角を表示します。中には×を描きます。

                        this.PaintRedCross(
                            g,
                            parentLocation,
                            sMsg,
                            moSprDic
                            );
                    }
                }

                // マウスが指しているスプライトの時：2x2ブロックに枠を表示。
                if (this.BMouseTarget)
                {
                    // 等倍表示も、倍角表示も　描画処理は同じ。
                    g.DrawRectangle(
                        moSprDic.BorderPen4OnOver,//ペン
                        this.BoundsLefttopScaled.X + parentLocation.X,
                        this.BoundsLefttopScaled.Y + parentLocation.Y,
                        this.BoundsLefttopScaled.Width,
                        this.BoundsLefttopScaled.Height
                        );
                    g.DrawRectangle(
                        moSprDic.BorderPen2OnOver,//ペン
                        this.BoundsLefttopScaled.X + parentLocation.X,
                        this.BoundsLefttopScaled.Y + parentLocation.Y,
                        this.BoundsLefttopScaled.Width,
                        this.BoundsLefttopScaled.Height
                        );

                    // 十字を表示します。（中心位置の縦軸、横軸が分かりやすいように）
                    {
                        int lineWidth = this.BoundsLefttopScaled.Width;
                        int lineHeight = this.BoundsLefttopScaled.Height;

                        // 縦線
                        g.DrawLine(
                            moSprDic.BorderPen2OnOver,//ペン
                            this.BoundsLefttopScaled.X + parentLocation.X + this.BoundsLefttopScaled.Width / 2,
                            this.BoundsLefttopScaled.Y + parentLocation.Y,
                            this.BoundsLefttopScaled.X + parentLocation.X + this.BoundsLefttopScaled.Width / 2,
                            this.BoundsLefttopScaled.Y + parentLocation.Y + this.BoundsLefttopScaled.Height
                            );
                        // 横線
                        g.DrawLine(
                            moSprDic.BorderPen2OnOver,//ペン
                            this.BoundsLefttopScaled.X + parentLocation.X,
                            this.BoundsLefttopScaled.Y + parentLocation.Y + this.BoundsLefttopScaled.Height / 2,
                            this.BoundsLefttopScaled.X + parentLocation.X + this.BoundsLefttopScaled.Width,
                            this.BoundsLefttopScaled.Y + parentLocation.Y + this.BoundsLefttopScaled.Height / 2
                            );
                    }
                }


                //// デバッグ用
                //{
                //    // スプライト名を表示します。
                //    e.Graphics.DrawString(this.Index.ToString(), this.font, modelOfSprDic.BorderBrushOnSelected, this.BoundsLtScaled.Location);
                //    System.Console.WriteLine(Info_Sprite.LibraryName + ":" + this.GetType().Name + "#Paint: スプライト番号＝[" + this.Index.ToString() + "]");
                //}

                //// エラーメッセージが登録されていれば、それを表示します。
                //if ("" != this.errorMessage)
                //{
                //    e.Graphics.DrawString(this.errorMessage, this.font, modelOfSprDic.BorderBrushOnSelected, this.BoundsLtScaled.Location);
                //}
            }
            catch (Exception e1)
            {
                err_Excp = e1;
                goto gt_Error_Exception;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Exception:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー451！", pg_Method);
                r.SMessage = "予期しないエラー：" + err_Excp.Message;
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 左上隅座標
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetLefttopLocation(int nX, int nY)
        {
            // boundsScaledの更新
            // TODO 倍角表示：現状は、左上角を固定して、辺を伸ばしています。
            this.boundsLefttopOriginal.X = nX;
            this.boundsLefttopOriginal.Y = nY;
            this.boundsLefttopScaled.X = nX;
            this.boundsLefttopScaled.Y = nY;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 左上隅座標に加算
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void OffsetLefttopLocation(int nDx, int nDy)
        {
            // boundsScaledの更新
            // TODO 倍角表示：現状は、左上角を固定して、辺を伸ばしています。
            this.boundsLefttopOriginal.X += nDx;
            this.boundsLefttopOriginal.Y += nDy;
            this.boundsLefttopScaled.X += nDx;
            this.boundsLefttopScaled.Y += nDy;
        }

        //────────────────────────────────────────

        /// <summary>
        /// サイズ
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize(int nWidth, int nHeight)
        {
            // boundsScaledの更新
            // TODO 倍角表示：現状は、左上角を固定して、辺を伸ばしています。
            this.boundsLefttopOriginal.Width += nWidth;
            this.boundsLefttopOriginal.Height += nHeight;
            this.boundsLefttopScaled.Width += (int)((float)nWidth * this.nScale);
            this.boundsLefttopScaled.Height += (int)((float)nHeight * this.nScale);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private int nIndex;

        /// <summary>
        /// スプライト・インデックス。
        /// スプライトを、配列やコレクション・クラスで管理するときに使うための、0から始まる数値です。
        /// </summary>
        public int NIndex
        {
            get
            {
                return nIndex;
            }
            set
            {
                nIndex = value;
            }
        }

        //────────────────────────────────────────

        private int nIndexForRenumbering;

        /// <summary>
        /// 番号の振りなおしを行うときに、一時的に新しいスプライト・インデックスを入れておくためのものです。
        /// </summary>
        public int NIndexForRenumbering
        {
            get
            {
                return nIndexForRenumbering;
            }
            set
            {
                nIndexForRenumbering = value;
            }
        }

        //────────────────────────────────────────

        private Bitmap bmp;

        /// <summary>
        /// 画像
        /// </summary>
        public Bitmap Bmp
        {
            get
            {
                return bmp;
            }
            set
            {
                bmp = value;
            }
        }

        //────────────────────────────────────────

        private Rectangle boundsLefttopOriginal;

        /// <summary>
        /// スプライト画像の位置とサイズです。倍角を掛け算する前の値です。
        /// 
        /// スプライトは、画像の左上隅位置(Left top)を、パネル上の座標（ピクセル）を持っています。
        /// </summary>
        public Rectangle BoundsLefttopOriginal
        {
            get
            {
                return boundsLefttopOriginal;
            }
            set
            {
                boundsLefttopOriginal = value;

                // boundsScaledの更新
                // TODO 倍角表示：現状は、左上角を固定して、辺を伸ばしています。
                boundsLefttopScaled.X = boundsLefttopOriginal.X;
                boundsLefttopScaled.Y = boundsLefttopOriginal.Y;
                boundsLefttopScaled.Width = (int)((float)boundsLefttopOriginal.Width * nScale);
                boundsLefttopScaled.Height = (int)((float)boundsLefttopOriginal.Height * nScale);
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// サイズ
        /// </summary>
        public Size SizeOriginal
        {
            get
            {
                return boundsLefttopOriginal.Size;
            }
            set
            {
                boundsLefttopOriginal.Size = value;

                // boundsScaledの更新
                // TODO 倍角表示：現状は、左上角を固定して、辺を伸ばしています。
                boundsLefttopScaled.Size = new Size((int)((float)value.Width * this.nScale), (int)((float)value.Height * this.nScale));
            }
        }

        //────────────────────────────────────────

        private Rectangle boundsLefttopScaled;

        /// <summary>
        /// スプライト画像の位置とサイズです。倍角を掛け算した後の値です。
        /// 
        /// スプライトは、画像の左上隅位置(Left top)を、パネル上の座標（ピクセル）を持っています。
        /// </summary>
        public Rectangle BoundsLefttopScaled
        {
            get
            {
                return boundsLefttopScaled;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// サイズ
        /// </summary>
        public Size SizeScaled
        {
            get
            {
                return boundsLefttopScaled.Size;
            }
        }

        //────────────────────────────────────────

        private bool bMouseOvered;

        /// <summary>
        /// スプライト画像の上にマウスカーソルが合わさっていれば真。
        /// </summary>
        public bool BMouseOvered
        {
            get
            {
                return bMouseOvered;
            }
            set
            {
                bMouseOvered = value;
            }
        }

        //────────────────────────────────────────

        private float nScale;

        /// <summary>
        /// 拡大率。1で等倍。2で1辺の長さが2倍。既定値：1.0F
        /// </summary>
        public float NScale
        {
            set
            {
                nScale = value;

                // boundsScaledの更新
                // TODO 倍角表示：現状は、左上角を固定して、辺を伸ばしています。
                boundsLefttopScaled.X = boundsLefttopOriginal.X;
                boundsLefttopScaled.Y = boundsLefttopOriginal.Y;
                boundsLefttopScaled.Width = (int)((float)boundsLefttopOriginal.Width * nScale);
                boundsLefttopScaled.Height = (int)((float)boundsLefttopOriginal.Height * nScale);
            }
            get
            {
                return nScale;
            }
        }

        //────────────────────────────────────────

        private int nZOrder;

        /// <summary>
        /// Zインデックス
        /// Z-Orderです。数字の一番小さい方が最背面、大きい方が最前面に表示されます。
        /// 同じ数字の場合は　挙動は未定です。
        /// </summary>
        public int NZOrder
        {
            get
            {
                return nZOrder;
            }
            set
            {
                nZOrder = value;
            }
        }

        //────────────────────────────────────────

        private bool bMouseTarget;

        /// <summary>
        /// (選択状態)
        /// マウスカーソルが指していれば真。他のスプライトとは排他的に常に１つ。
        /// </summary>
        public bool BMouseTarget
        {
            get
            {
                return bMouseTarget;
            }
            set
            {
                bMouseTarget = value;
            }
        }

        //────────────────────────────────────────

        private bool bDragging;

        /// <summary>
        /// (選択状態)
        /// スプライト画像をドラッギングしていれば真です。
        /// </summary>
        public bool BDragging
        {
            get
            {
                return bDragging;
            }
            set
            {
                bDragging = value;
            }
        }

        //────────────────────────────────────────

        private bool bSelected;

        /// <summary>
        /// (選択状態)
        /// スプライト画像を選択していれば真です。
        /// </summary>
        public bool BSelected
        {
            get
            {
                return bSelected;
            }
            set
            {
                bSelected = value;
            }
        }

        //────────────────────────────────────────

        private bool bSelectToggled;

        /// <summary>
        /// (選択状態)
        /// スプライト画像の選択を切り替えようとすれば真です。
        /// </summary>
        public bool BSelectToggled
        {
            get
            {
                return bSelectToggled;
            }
            set
            {
                bSelectToggled = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// (選択状態)
        /// デバッグ用フォント
        /// </summary>
        private Font font;

        //────────────────────────────────────────

        private string sLogStack;

        /// <summary>
        /// デバッグ用情報。このスプライトが作られたソースを人間が修正するために使われます。
        /// </summary>
        public string SLogStack
        {
            get
            {
                return sLogStack;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウスの操作対象が変更されたとき。
        /// </summary>
        public DLGT_CheckLocationValid Dlgt_CheckLocationValid
        {
            set
            {
                dlgt_CheckLocationValid = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
