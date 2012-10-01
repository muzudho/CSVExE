using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

using Xenon.Operating;//TextAlign


namespace Xenon.GridPanel
{

    /// <summary>
    /// グリッド・パネル。
    /// 
    /// 注意。Panelの拡張ではなく、UserControlの拡張です。
    /// </summary>
    public partial class UsercontrolXenonGridPanel : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolXenonGridPanel()
        {
            InitializeComponent();



            // 画面のちらつきをなくすために、ダブル・バッファーを真にします。
            this.DoubleBuffered = true;

            // 初期設定
            this.bPrepainted_Grid = true;

            this.gridView = new GridviewImpl();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 初期設定のサンプルをクリアーし、空の状態に設定します。
        /// </summary>
        public void Clear()
        {
            this.GridView.Clear();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// デフォルト値を追加します。
        /// </summary>
        public void PutDefault()
        {
            // (20,20)から、縦横10セルずつのテーブル。
            // 1セルのサイズは 縦横16px。

            Grid gridArea1 = new GridImpl();
            this.GridView.Gridareas.Dictionary_Item.Add("グリッド領域1", gridArea1);
            gridArea1.Lefttop_Table = new Point(32, 32);
            gridArea1.Size_Cell = new Size(16, 16);
            gridArea1.Size_Total = new Size(160, 160);

            // X軸の目盛り
            {
                Ticklabel tickLabel = gridArea1.Ticklabel_X;
                tickLabel.IsHorizontal = true;
                tickLabel.Number_LocationFirst = 32;
                tickLabel.Number_LocationFixed = 16;
                tickLabel.Length_Total = 160;
                tickLabel.Interval_Cell = 16;
                tickLabel.Width_Label = 16;
                tickLabel.Size_FontPt = 8.0F;
                tickLabel.Number_LabelFirst = 1;
                tickLabel.Offset_Label = 1;
                tickLabel.Textalign = EnumTextalign.Right;
                tickLabel.IsVisibled = true;
            }

            // Y軸の目盛り
            {
                Ticklabel tickLabel = gridArea1.Ticklabel_Y;
                tickLabel.IsHorizontal = false;
                tickLabel.Number_LocationFirst = 32;
                tickLabel.Number_LocationFixed = 16;
                tickLabel.Length_Total = 160;
                tickLabel.Interval_Cell = 16;
                tickLabel.Width_Label = 10;
                tickLabel.Size_FontPt = 8.0F;
                tickLabel.Number_LabelFirst = 1;
                tickLabel.Offset_Label = 1;
                tickLabel.Textalign = EnumTextalign.Right;
                tickLabel.IsVisibled = true;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            if (this.BPrepainted_Grid)
            {
                // グリッドを自動で描画するなら。

                // グリッドの描画。
                this.GridView.PaintGrid(sender, e.Graphics);
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected bool bPrepainted_Grid;

        /// <summary>
        /// パネルに自動的にグリッドを描画するなら真。
        /// 
        /// グリッドの描画をプログラムで指示するなら偽にしてください。
        /// グリッドを自動的には描画しません。
        /// </summary>
        public bool BPrepainted_Grid
        {
            set
            {
                bPrepainted_Grid = value;
            }
            get
            {
                return bPrepainted_Grid;
            }
        }

        //────────────────────────────────────────

        protected Gridview gridView;

        /// <summary>
        /// グリッド ペインター
        /// </summary>
        public Gridview GridView
        {
            get
            {
                return gridView;
            }
            set
            {
                gridView = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }

}
