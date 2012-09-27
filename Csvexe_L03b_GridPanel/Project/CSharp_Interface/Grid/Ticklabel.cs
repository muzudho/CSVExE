using System;
using System.Collections.Generic;
using System.Drawing;//Pens,Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

using System.Security.Permissions;//SecurityPermission
using System.Runtime.Serialization;//ISerializable

using Xenon.Operating;//TextAlign

namespace Xenon.GridPanel
{



    /// <summary>
    /// 刻み目盛り。
    /// (tick label)
    /// </summary>
    public interface Ticklabel
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// シリアライズ。
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        void GetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// 描画。
        /// </summary>
        /// <param name="e"></param>
        void Paint(Graphics g, Point parentLocation);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 表示するなら真。
        /// </summary>
        bool BVisibled
        {
            get;
            set;
        }

        /// <summary>
        /// 端っこの座標。（xまたはy）
        /// </summary>
        int NLocation_First
        {
            get;
            set;
        }

        /// <summary>
        /// 端っこの座標の反対軸。（xまたはy）
        /// </summary>
        int NLocation_Fixed
        {
            get;
            set;
        }

        /// <summary>
        /// 全体のピクセルの長さ。（widthまたはheight）
        /// </summary>
        int NLength_Total
        {
            get;
            set;
        }

        /// <summary>
        /// セルの間隔。ピクセルでの長さ。（widthまたはheight）
        /// </summary>
        int NInterval_Cell
        {
            get;
            set;
        }

        /// <summary>
        /// ラベルの文字列幅。ピクセルでの長さ。
        /// 垂直方向に並んだラベルでは cellInterval とは値が一致しないことがあることに対応した設定。
        /// </summary>
        int NWidth_Label
        {
            get;
            set;
        }

        /// <summary>
        /// 水平なら真、垂直なら偽。
        /// </summary>
        bool BHorizontal
        {
            get;
            set;
        }

        /// <summary>
        /// フォントのサイズ。単位はpoint(pt)。
        /// </summary>
        float NSize_FontPt
        {
            get;
            set;
        }

        /// <summary>
        /// 描画色のブラシの名前。C#のBrushesで定義されているブラシ変数と同名。既定値は "Black"。
        /// 
        /// Brushクラスはシリアライズ化できなかったので止めた。
        /// </summary>
        string SName_ForegroundBrush
        {
            get;
            set;
        }

        /// <summary>
        /// 目盛りラベルの最初の数字。
        /// </summary>
        int NFirst_Label
        {
            get;
            set;
        }

        /// <summary>
        /// 目盛りラベルの１つ進むたびの増分。
        /// </summary>
        int NOffset_Label
        {
            get;
            set;
        }

        /// <summary>
        /// ラベルの水平の位置揃え。
        /// (text align)
        /// </summary>
        EnumTextalign Textalign
        {
            get;
            set;
        }

        /// <summary>
        /// 最初の項目を、ピクセル単位でずらして位置調整することができます。
        /// </summary>
        int NOffsetPixel_FirstItem
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
