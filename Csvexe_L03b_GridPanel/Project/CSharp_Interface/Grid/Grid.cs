using System;
using System.Collections.Generic;
using System.Drawing;//Pens,Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

namespace Xenon.GridPanel
{



    /// <summary>
    /// 
    /// </summary>
    public interface Grid
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 描画。
        /// </summary>
        void Paint(Graphics g, Point parentLocation);

        /// <summary>
        /// 指定の座標から最も近くにある、グリッドの交点を返します。
        /// (cross point)
        /// </summary>
        /// <returns></returns>
        Point NearCrosspoint(Point location);

        /// <summary>
        /// 指定の座標が、このグリッドに含まれるなら真。
        /// </summary>
        /// <returns></returns>
        bool Contains(Point location);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// このグリッドエリアの名前。
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// コントロールの中での、左上隅(Left Top)の座標。
        /// （Table LT）
        /// </summary>
        Point Lefttop_Table
        {
            get;
            set;
        }

        /// <summary>
        /// 1セルの横幅・縦幅ピクセル。
        /// </summary>
        Size Size_Cell
        {
            get;
            set;
        }

        /// <summary>
        /// 全体の横幅・縦幅ピクセル。
        /// </summary>
        Size Size_Total
        {
            get;
            set;
        }

        /// <summary>
        /// 描画色のペンの名前。C#のPensで定義されているペン変数と同名。既定値は "Black"。
        /// </summary>
        string Name_ForegroundPen
        {
            get;
            set;
        }

        /// <summary>
        /// X軸の目盛りラベルの描画。
        /// </summary>
        Ticklabel Ticklabel_X
        {
            get;
            set;
        }

        /// <summary>
        /// X軸の目盛りラベルの描画。
        /// </summary>
        Ticklabel Ticklabel_Y
        {
            get;
            set;
        }

        /// <summary>
        /// 水平線の可視
        /// (horizontal line)
        /// </summary>
        bool IsVisibled_Horizontalline
        {
            set;
            get;
        }

        /// <summary>
        /// 垂直線の可視
        /// (vertical line)
        /// </summary>
        bool IsVisibled_Verticalline
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
