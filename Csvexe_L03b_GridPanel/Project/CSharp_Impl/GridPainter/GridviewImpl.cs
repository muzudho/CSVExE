using System;
using System.Collections.Generic;
using System.Drawing;//Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

namespace Xenon.GridPanel
{
    public class GridviewImpl : Gridview
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public GridviewImpl()
        {
            this.gridareas = new MemoryGridsImpl();

            // グリッドは背面表示設定（このプロパティーをどう使うか、または使わないかは任意）
            this.enumGridDisplay = EnumGridDisplay.Background;

            this.location = new Point();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 空の状態に設定します。
        /// </summary>
        public void Clear()
        {
            this.Gridareas.Clear();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// グリッドの描画。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PaintGrid(object sender, Graphics g)
        {
            foreach (Grid gridArea in this.Gridareas.Dictionary_Item.Values)
            {
                gridArea.Paint(g, this.Location);
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryGrids gridareas;

        /// <summary>
        /// グリッドパネルのモデル
        /// </summary>
        public MemoryGrids Gridareas
        {
            get
            {
                return gridareas;
            }
            set
            {
                gridareas = value;
            }
        }

        //──────────────────────────────

        private EnumGridDisplay enumGridDisplay;

        /// <summary>
        /// グリッド表示状態。
        /// 
        /// 前面、背面、表示なし。
        /// このプロパティーをどう使うか、または使わないかは任意。
        /// </summary>
        public EnumGridDisplay EnumGridDisplay
        {
            get
            {
                return enumGridDisplay;
            }
            set
            {
                enumGridDisplay = value;
            }
        }

        //──────────────────────────────

        private Point location;

        /// <summary>
        /// グリッド座標の起点となる、左上位置。
        /// </summary>
        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
