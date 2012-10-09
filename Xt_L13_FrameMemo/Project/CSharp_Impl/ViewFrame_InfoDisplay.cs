using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Xenon.FrameMemo
{

    /// <summary>
    /// width,height,ファイル名等表示です。
    /// </summary>
    public class ViewFrame_InfoDisplay : ViewFrame
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public ViewFrame_InfoDisplay()
        {
            this.font = new Font("ＭＳ ゴシック", 12, FontStyle.Bold);

            int dy = 0;

            int nLastIndex = 7;
            this.locationAA = new Point[nLastIndex + 1][];

            for (int nIndex = 1; nIndex <= nLastIndex; nIndex++)
            {
                this.locationAA[nIndex] = new Point[nLastIndex + 1];
                this.locationAA[nIndex][1] = new Point(0, dy + 0);
                this.locationAA[nIndex][2] = new Point(4, dy + 4);
                this.locationAA[nIndex][3] = new Point(0, dy + 4);
                this.locationAA[nIndex][4] = new Point(4, dy + 0);
                this.locationAA[nIndex][5] = new Point(2, dy + 2);
                dy += 16;
            }

            this.sFilePath = "";
            this.textBackBrush = new SolidBrush(Color.FromArgb(0x99, 0xff, 0xff, 0xff));
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Refresh()
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// セルの横幅。等倍。
        /// </summary>
        public void OnCellWidthResultChanged(float nValue)
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// セルの縦幅。等倍。
        /// </summary>
        public void OnCellHeightResultChanged(float nValue)
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// 行数。
        /// </summary>
        public void OnRowCountResultChanged(float nValue)
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// 列数。
        /// </summary>
        public void OnColumnCountResultChanged(float nValue)
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// 切抜き位置／１～。0以下、または範囲外指定で全体図。
        /// </summary>
        public void OnCropForceChanged(int nValue)
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// 切抜き位置終値／１～。
        /// </summary>
        public void OnCropLastResultChanged(int nValue)
        {
        }

        //────────────────────────────────────────

        public string ToColumnRowString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("c");
            s.Append(this.MoSprite.NColCountResult);
            s.Append(" r");
            s.Append(this.MoSprite.NRowCountResult);
            s.Append("（列,行）");

            return s.ToString();
        }

        //────────────────────────────────────────

        public string ToCellSizeString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("w");
            s.Append(this.MoSprite.NCellWidthResult);
            s.Append(" h");
            s.Append(this.MoSprite.NCellHeightResult);
            s.Append(" (セル)");

            return s.ToString();
        }

        //────────────────────────────────────────

        public string ToFrameSizeString()
        {
            SizeF size = this.MoSprite.GetFrameSize();

            StringBuilder s = new StringBuilder();
            s.Append("w");
            s.Append(size.Width);
            s.Append(" h");
            s.Append(size.Height);
            s.Append(" (枠)");

            return s.ToString();
        }

        //────────────────────────────────────────

        public string ToFileNameString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("file=");
            s.Append(System.IO.Path.GetFileName(this.SFilePath));

            return s.ToString();
        }

        //────────────────────────────────────────

        public string ToCropString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("切抜き=");
            s.Append(this.MoSprite.NCropForce);
            s.Append("番目　x");

            PointF cropL = this.MoSprite.GetCropXy();
            s.Append(cropL.X);
            s.Append(" y");
            s.Append(cropL.Y);

            return s.ToString();
        }

        //────────────────────────────────────────

        public string ToGridXyString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("x");
            s.Append(this.MoSprite.GridLt.X);
            s.Append(" y");
            s.Append(this.MoSprite.GridLt.Y);
            s.Append("（グリッド）");

            return s.ToString();
        }

        //────────────────────────────────────────

        public string ToImageSizeString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("w");
            s.Append(this.MoSprite.NImageSize.Width);
            s.Append(" h");
            s.Append(this.MoSprite.NImageSize.Height);
            s.Append(" (画)");

            return s.ToString();
        }

        //────────────────────────────────────────

        public int TextWidth(Graphics g, out string[] textArray)
        {
            int maxTxtWidth = 1;
            int tmpTxtWidth;

            //
            // 文字列行数
            textArray = new string[this.InfoRows + 1];

            int nIndex = 1;

            if ((this.MoSprite.NRowCountResult != 1 || this.MoSprite.NColCountResult != 1) || this.MoSprite.BCrop)
            {
                // 1列、1行でなければ [c,r][w,h（個）][w,h（枠）]を表示するので +3 行。
                // または、切り抜いた時。

                // c,r
                textArray[nIndex] = this.ToColumnRowString();
                tmpTxtWidth = (int)g.MeasureString(textArray[nIndex], this.Font).Width;
                if (maxTxtWidth < tmpTxtWidth)
                {
                    maxTxtWidth = tmpTxtWidth;
                }
                nIndex++;

                // w,h（個）
                textArray[nIndex] = this.ToCellSizeString();
                tmpTxtWidth = (int)g.MeasureString(textArray[nIndex], this.Font).Width;
                if (maxTxtWidth < tmpTxtWidth)
                {
                    maxTxtWidth = tmpTxtWidth;
                }
                nIndex++;

                // w,h（枠）
                textArray[nIndex] = this.ToFrameSizeString();
                tmpTxtWidth = (int)g.MeasureString(textArray[nIndex], this.Font).Width;
                if (maxTxtWidth < tmpTxtWidth)
                {
                    maxTxtWidth = tmpTxtWidth;
                }
                nIndex++;
            }

            textArray[nIndex] = this.ToFileNameString();
            tmpTxtWidth = (int)g.MeasureString(textArray[nIndex], this.Font).Width;
            if (maxTxtWidth < tmpTxtWidth)
            {
                maxTxtWidth = tmpTxtWidth;
            }
            nIndex++;

            if (this.MoSprite.BCrop)
            {
                textArray[nIndex] = this.ToCropString();
                tmpTxtWidth = (int)g.MeasureString(textArray[nIndex], this.Font).Width;
                if (maxTxtWidth < tmpTxtWidth)
                {
                    maxTxtWidth = tmpTxtWidth;
                }
                nIndex++;
            }

            if (this.MoSprite.GridLt.X != 0 || this.MoSprite.GridLt.Y != 0)
            {
                textArray[nIndex] = this.ToGridXyString();
                tmpTxtWidth = (int)g.MeasureString(textArray[nIndex], this.Font).Width;
                if (maxTxtWidth < tmpTxtWidth)
                {
                    maxTxtWidth = tmpTxtWidth;
                }
                nIndex++;
            }

            // 画
            textArray[nIndex] = this.ToImageSizeString();
            tmpTxtWidth = (int)g.MeasureString(textArray[nIndex], this.Font).Width;
            if (maxTxtWidth < tmpTxtWidth)
            {
                maxTxtWidth = tmpTxtWidth;
            }
            nIndex++;

            return maxTxtWidth;
        }

        //────────────────────────────────────────

        public void Paint(Graphics g, bool bOnWindow, int dy, float scale2)
        {
            string[] textArray;
            int maxTxtWidth = this.TextWidth(g, out textArray);


            // 切抜きの有無。
            bool bCrop = this.MoSprite.BCrop;

            // 半透明の白色
            {
                int nRow = this.InfoRows;
                int nFontSize = 16;// +4;
                int nHeightMargin = 8 + 4;
                g.FillRectangle(this.textBackBrush,
                    0,
                    dy - 4,
                    maxTxtWidth + 8,
                    nRow * nFontSize + nHeightMargin//旧：5 * 16 + 8
                    );
            }

            int nIndex = 1;

            if ((this.MoSprite.NRowCountResult != 1 || this.MoSprite.NColCountResult != 1) || this.MoSprite.BCrop)
            {
                // 1列、1行でなければ [c,r][w,h（個）][w,h（枠）]を表示するので +3 行。
                // または、切り抜いた時。

                // c,r
                // w,h（個）
                // w,h（枠）
                for (int nJ = 0; nJ < 3; nJ++)
                {
                    string sValue = textArray[nIndex];

                    // 光
                    g.DrawString(
                        sValue,
                        this.font,
                        Brushes.White,
                        this.locationAA[nIndex][1].X,
                        this.locationAA[nIndex][1].Y + dy
                        );
                    // 影
                    g.DrawString(
                        sValue,
                        this.font,
                        Brushes.White,
                        this.locationAA[nIndex][2].X,
                        this.locationAA[nIndex][2].Y + dy
                        );
                    g.DrawString(
                        sValue,
                        this.font,
                        Brushes.White,
                        this.locationAA[nIndex][3].X,
                        this.locationAA[nIndex][3].Y + dy
                        );
                    g.DrawString(
                        sValue,
                        this.font,
                        Brushes.White,
                        this.locationAA[nIndex][4].X,
                        this.locationAA[nIndex][4].Y + dy
                        );
                    //文字
                    g.DrawString(
                        sValue,
                        this.font,
                        Brushes.Black,
                        this.locationAA[nIndex][5].X,
                        this.locationAA[nIndex][5].Y + dy
                        );

                    nIndex++;
                }
            }

            // ファイル名
            {
                string sValue = textArray[nIndex];

                // 光
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][1].X,
                    this.locationAA[nIndex][1].Y + dy
                    );
                // 影
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][2].X,
                    this.locationAA[nIndex][2].Y + dy
                    );
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][3].X,
                    this.locationAA[nIndex][3].Y + dy
                    );
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][4].X,
                    this.locationAA[nIndex][4].Y + dy
                    );
                //文字
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.Black,
                    this.locationAA[nIndex][5].X,
                    this.locationAA[nIndex][5].Y + dy
                    );

                nIndex++;
            }

            // 切抜き位置。
            if (bCrop)
            {
                string sValue = textArray[nIndex];

                // 光
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][1].X,
                    this.locationAA[nIndex][1].Y + dy
                    );
                // 影
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][2].X,
                    this.locationAA[nIndex][2].Y + dy
                    );
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][3].X,
                    this.locationAA[nIndex][3].Y + dy
                    );
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][4].X,
                    this.locationAA[nIndex][4].Y + dy
                    );
                //文字
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.Black,
                    this.locationAA[nIndex][5].X,
                    this.locationAA[nIndex][5].Y + dy
                    );

                nIndex++;
            }

            // グリッドXY
            if (this.MoSprite.GridLt.X != 0 || this.MoSprite.GridLt.Y != 0)
            {
                string sValue = textArray[nIndex];

                // 光
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][1].X,
                    this.locationAA[nIndex][1].Y + dy
                    );
                // 影
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][2].X,
                    this.locationAA[nIndex][2].Y + dy
                    );
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][3].X,
                    this.locationAA[nIndex][3].Y + dy
                    );
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][4].X,
                    this.locationAA[nIndex][4].Y + dy
                    );
                //文字
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.Black,
                    this.locationAA[nIndex][5].X,
                    this.locationAA[nIndex][5].Y + dy
                    );

                nIndex++;
            }

            // 画像w,h（画）
            {
                string sValue = textArray[nIndex];

                // 光
                // bug:切り抜いたとき
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][1].X,
                    this.locationAA[nIndex][1].Y + dy
                    );
                // 影
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][2].X,
                    this.locationAA[nIndex][2].Y + dy
                    );
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][3].X,
                    this.locationAA[nIndex][3].Y + dy
                    );
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.White,
                    this.locationAA[nIndex][4].X,
                    this.locationAA[nIndex][4].Y + dy
                    );
                //文字
                g.DrawString(
                    sValue,
                    this.font,
                    Brushes.Black,
                    this.locationAA[nIndex][5].X,
                    this.locationAA[nIndex][5].Y + dy
                    );

                nIndex++;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected MemorySpriteImpl moSprite;

        public MemorySpriteImpl MoSprite
        {
            get
            {
                return moSprite;
            }
            set
            {
                moSprite = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 座標フォント。
        /// </summary>
        protected Font font;

        public Font Font
        {
            get
            {
                return font;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 格子ペン。
        /// </summary>
        protected Pen gridPen;

        public Pen GridPen
        {
            get
            {
                return gridPen;
            }
            set
            {
                gridPen = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 2次元配列。
        /// [1]…(c r)列数行数　座標XY。 [光][影][影][影][字]
        /// [2]…(w h)セルサイズ（個）。 [光][影][影][影][字]
        /// [3]…(w h)セルサイズ（枠）。 [光][影][影][影][字]
        /// [4]…(file)ファイル名。 [光][影][影][影][字]
        /// [5]…(切抜き)切抜き位置。 [光][影][影][影][字]
        /// [6]…(グリッドxy)ベース位置。 [光][影][影][影][字]
        /// [3]…(w h)画像サイズ（画）。 [光][影][影][影][字]
        /// </summary>
        protected Point[][] locationAA;

        //────────────────────────────────────────

        protected string sFilePath;

        /// <summary>
        /// 画像の縦幅。等倍。
        /// </summary>
        public string SFilePath
        {
            get
            {
                return sFilePath;
            }
            set
            {
                sFilePath = value;
            }
        }

        //────────────────────────────────────────

        protected Brush textBackBrush;

        //────────────────────────────────────────

        public int InfoRows
        {
            get
            {
                //
                // 文字列行数
                int infoRows = 2;// [w,h（全）] [file name]

                if ((this.MoSprite.NRowCountResult != 1 || this.MoSprite.NColCountResult != 1) || this.MoSprite.BCrop)
                {
                    // 1列、1行でなければ [c,r][w,h（個）][w,h（枠）]を表示するので +2 行。
                    // または、切り抜いた時。
                    infoRows += 3;
                }

                if (this.MoSprite.BCrop)
                {
                    // 切抜き画像サイズ（切抜き1番目、等）を表示するなら +1 行。
                    infoRows++;
                }

                if (this.MoSprite.GridLt.X != 0 || this.MoSprite.GridLt.Y != 0)
                {
                    // グリッドベース座標を表示するなら +1 行。
                    infoRows++;
                }

                return infoRows;
            }
        }

        //────────────────────────────────────────
        #endregion



    }

}
