using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

using System.Drawing;//Pens,Point
using Xenon.Operating;//BuilderPen

namespace Xenon.GridPanel
{

    // フォーム・デザイナーのツール・ボックスに追加できるようにシリアライズ可能の指定。
    [Serializable()]
    public class GridImpl : Grid
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public GridImpl()
        {
            this.sName = "";
            this.sName_ForegroundPen = "Black";

            this.ticklabel_X = new TicklabelImpl();
            this.ticklabel_Y = new TicklabelImpl();

            this.bVisibled_Horizontalline = true;
            this.bVisibled_Verticalline = true;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        // 説明はインターフェース参照。
        public void Paint(Graphics g, Point parentLocation)
        {
            int x2 = this.NLefttop_Table.X + this.NSize_Total.Width;
            int y2 = this.NLefttop_Table.Y + this.NSize_Total.Height;

            // 水平線
            if(this.BVisibled_Horizontalline)
            {
                for (int y = this.NLefttop_Table.Y; y <= y2; y += this.NSize_Cell.Height)
                {
                    g.DrawLine(
                        BuilderPen.Parse(this.SName_ForegroundPen),
                        this.NLefttop_Table.X + parentLocation.X,
                        y + parentLocation.Y,
                        this.NLefttop_Table.X + this.NSize_Total.Width + parentLocation.X,
                        y + parentLocation.Y);
                }
            }

            // 垂直線
            if(this.BVisibled_Verticalline)
            {
                for (int x = this.NLefttop_Table.X; x <= x2; x += this.NSize_Cell.Width)
                {
                    g.DrawLine(
                        BuilderPen.Parse(this.sName_ForegroundPen),
                        x + parentLocation.X,
                        this.NLefttop_Table.Y + parentLocation.Y,
                        x + parentLocation.X,
                        this.NLefttop_Table.Y + this.NSize_Total.Height + parentLocation.Y
                        );
                }
            }

            // 目盛り
            this.Ticklabel_X.Paint(g, parentLocation);
            this.Ticklabel_Y.Paint(g, parentLocation);
        }

        //────────────────────────────────────────

        // 説明はインターフェース参照。
        public bool Contains(Point location)
        {
            // 親コントロールの座標を足したい。
            //int ox;
            //int oy;

            int x1 = this.NLefttop_Table.X;
            int y1 = this.NLefttop_Table.Y;
            int x2 = this.NLefttop_Table.X + this.NSize_Total.Width;
            int y2 = this.NLefttop_Table.Y + this.NSize_Total.Height;

            bool bResult;

            if (x1 <= location.X && location.X <= x2 && y1 <= location.Y && location.Y <= y2)
            {
                bResult = true;
                //onsole.WriteLine(Info_GridPanel.LibraryName + ":" + this.GetType().Name + "#OnMouseMoved:　　["+this.SName+"]　　bResult=[" + bResult + "]　　x1=[" + x1 + "]＜＝location.X=[" + location.X + "]＜＝x2=[" + x2 + "]　　y1=[" + y1 + "]＜＝location.Y=[" + location.Y + "]＜＝y2=[" + y2 + "]　　this.NAbsXLt=[" + this.NXLt + "]　this.NAbsYLt=[" + this.NYLt + "]　this.NTotalWidth=[" + this.NTotalWidth + "]　this.NTotalHeight=[" + this.NTotalHeight + "]");
            }
            else
            {
                bResult = false;
            }

            return bResult;
        }

        //────────────────────────────────────────

        // 説明はインターフェース参照。
        public Point NearCrosspoint(Point location)
        {
            // グリッド領域内での位置に変換。
            int nXInArea = (location.X - this.NLefttop_Table.X);
            int nYInArea = (location.Y - this.NLefttop_Table.Y);
            //onsole.WriteLine(Info_GridPanel.LibraryName + ":" + this.GetType().Name + "#OnMouseMoved: xInArea=[" + nXInArea + "]　　yInArea=[" + nYInArea + "]");

            //
            // 十字交差点上を指したい。
            //

            //
            // 今いるセルの、左上の十字交差点を求める。
            //
            int column = (int)Math.Ceiling((double)nXInArea / (double)this.NSize_Cell.Width);
            int row = (int)Math.Ceiling((double)nYInArea / (double)this.NSize_Cell.Height);

            //
            // 端数を求める。
            //
            int hasuuX = nXInArea % this.NSize_Cell.Width;
            int hasuuY = nYInArea % this.NSize_Cell.Height;

            //
            // セルの中心を求める。
            //
            int halfX = (int)((double)this.NSize_Cell.Width / 2.0d);
            int halfY = (int)((double)this.NSize_Cell.Height / 2.0d);

            //
            // 端数がセルの半分より進んでいれば、１足す。
            //
            if(halfX<hasuuX)
            {
                column++;
            }

            if (halfY < hasuuY)
            {
                row++;
            }


            // セル位置
            //int column = (int)(((float)nXInArea + ) / (float)this.NCellSize.Width);
            //int row = (int)(((float)nYInArea + (float)this.NCellSize.Height / 2.0f) / (float)this.NCellSize.Height);

            //// セル内位置
            //int xInCell = xInArea % this.CellWidth;
            //int yInCell = yInArea % this.CellHeight;

            //// 半分以上進んでいれば、次のセル
            //if (this.CellWidth/2<xInCell)
            //{
            //    column++;
            //}
            //if (this.CellHeight / 2 < yInCell)
            //{
            //    row++;
            //}

            // とりあえず、どこかの角位置。
            int nearCrossX = column * this.NSize_Cell.Width; // todo:オフセット値があるかも。
            int nearCrossY = row * this.NSize_Cell.Height;

            // 絶対値にして返します。
            int nearCrossAbsX = nearCrossX + this.NLefttop_Table.X;
            int nearCrossAbsY = nearCrossY + this.NLefttop_Table.Y;

            return new Point(nearCrossAbsX, nearCrossAbsY);
        }

        //────────────────────────────────────────
        #endregion

        

        #region プロパティー
        //────────────────────────────────────────

        private string sName;

        /// <summary>
        /// このグリッドエリアの名前。
        /// </summary>
        public string SName
        {
            set
            {
                sName = value;
            }
            get
            {
                return sName;
            }
        }

        //────────────────────────────────────────

        private Point nLefttop_Table;

        /// <summary>
        /// 左上隅(Left Top)の絶対座標。
        /// </summary>
        public Point NLefttop_Table
        {
            set
            {
                nLefttop_Table = value;
            }
            get
            {
                return nLefttop_Table;
            }
        }

        //────────────────────────────────────────

        private Size nSize_Cell;

        /// <summary>
        /// 1セルの横幅・縦幅ピクセル。
        /// </summary>
        public Size NSize_Cell
        {
            set
            {
                nSize_Cell = value;
            }
            get
            {
                return nSize_Cell;
            }
        }

        //────────────────────────────────────────

        private Size nSize_Total;

        /// <summary>
        /// 全体の横幅・縦幅ピクセル。
        /// </summary>
        public Size NSize_Total
        {
            set
            {
                nSize_Total = value;
            }
            get
            {
                return nSize_Total;
            }
        }

        //────────────────────────────────────────

        private string sName_ForegroundPen;

        /// <summary>
        /// 描画色のペンの名前。C#のPensで定義されているペン変数と同名。既定値は "Black"。
        /// 
        /// Penクラスはシリアライズ化できなかったので止めた。
        /// </summary>
        public string SName_ForegroundPen
        {
            set
            {
                sName_ForegroundPen = value;
            }
            get
            {
                return sName_ForegroundPen;
            }
        }

        //────────────────────────────────────────

        private Ticklabel ticklabel_X;

        /// <summary>
        /// X軸の目盛りラベルの描画。
        /// </summary>
        public Ticklabel Ticklabel_X
        {
            set
            {
                ticklabel_X = value;
            }
            get
            {
                return ticklabel_X;
            }
        }

        //────────────────────────────────────────

        private Ticklabel ticklabel_Y;

        /// <summary>
        /// X軸の目盛りラベルの描画。
        /// </summary>
        public Ticklabel Ticklabel_Y
        {
            set
            {
                ticklabel_Y = value;
            }
            get
            {
                return ticklabel_Y;
            }
        }

        //────────────────────────────────────────

        private bool bVisibled_Horizontalline;

        /// <summary>
        /// 水平線の可視
        /// </summary>
        public bool BVisibled_Horizontalline
        {
            set
            {
                bVisibled_Horizontalline = value;
            }
            get
            {
                return bVisibled_Horizontalline;
            }
        }

        //────────────────────────────────────────

        private bool bVisibled_Verticalline;

        /// <summary>
        /// 垂直線の可視
        /// </summary>
        public bool BVisibled_Verticalline
        {
            set
            {
                bVisibled_Verticalline = value;
            }
            get
            {
                return bVisibled_Verticalline;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
