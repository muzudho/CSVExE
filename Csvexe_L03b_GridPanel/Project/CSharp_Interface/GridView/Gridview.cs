using System;
using System.Collections.Generic;
using System.Drawing;//Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

namespace Xenon.GridPanel
{



    /// <summary>
    /// グリッドビュー。
    /// (grid view)
    /// </summary>
    public interface Gridview
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 空の状態に設定します。
        /// </summary>
        void Clear();

        /// <summary>
        /// グリッドの描画。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PaintGrid(object sender, Graphics g);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// グリッドパネルのモデル
        /// (grid areas)
        /// </summary>
        MemoryGrids Gridareas
        {
            get;
            set;
        }

        /// <summary>
        /// グリッド表示状態。
        /// 前面、背面、表示なし。
        /// (grid display mode)
        /// </summary>
        EnumGridDisplay EnumGridDisplay
        {
            get;
            set;
        }

        /// <summary>
        /// グリッド座標の起点となる、左上位置。
        /// </summary>
        Point Location
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
