using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;//Graphics

namespace Xenon.XyMemo
{
    public class Spritememo_InfoDisplay : Spritememo
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Spritememo_InfoDisplay()
        {
            this.e_sSpBaseLocationOnBg = new StringBuilder();
            this.e_sSpLtOnBg = new StringBuilder();
            this.e_sSpCtOnBg = new StringBuilder();
            this.e_sWH = new StringBuilder();

            this.coordinateFont = new Font("ＭＳ ゴシック", 20);

            int x = 0;
            int y = 0;
            int row = 0;
            this.textLocationAA = new Point[5][];
            // 1行目
            row++;
            y += 0;
            this.textLocationAA[row] = new Point[3];
            this.textLocationAA[row][1] = new Point(x, y);
            this.textLocationAA[row][2] = new Point(x + 2, y + 2);
            // 2行目
            row++;
            y += 24;
            this.textLocationAA[row] = new Point[3];
            this.textLocationAA[row][1] = new Point(x, y);
            this.textLocationAA[row][2] = new Point(x + 2, y + 2);
            // 3行目
            row++;
            y += 24;
            this.textLocationAA[row] = new Point[3];
            this.textLocationAA[row][1] = new Point(x, y);
            this.textLocationAA[row][2] = new Point(x + 2, y + 2);
            // 4行目
            row++;
            y += 24;
            this.textLocationAA[row] = new Point[4];
            this.textLocationAA[row][1] = new Point(x, y);
            this.textLocationAA[row][2] = new Point(x + 2, y + 2);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void OnSpriteSizeChanged()
        {
            //
            // 文字列の作成。
            //
            StringBuilder s = this.e_sWH;
            s.Length = 0;

            if (this.MoSprite.BWidthForced)
            {
                s.Append("制W=");
                s.Append(this.MoSprite.DstSizeResult.Width);
            }
            else if (0 != this.MoSprite.SrcSize.Width)
            {
                s.Append("元W=");
                s.Append(this.MoSprite.SrcSize.Width);
            }

            if (
                (this.MoSprite.BWidthForced || 0 != this.MoSprite.SrcSize.Width) &&
                (this.MoSprite.BHeightForced || 0 != this.MoSprite.SrcSize.Height)
                )
            {
                s.Append(",");
            }

            if (this.MoSprite.BHeightForced)
            {
                s.Append("制H=");
                s.Append(this.MoSprite.DstSizeResult.Height);
            }
            else if (0 != this.MoSprite.SrcSize.Height)
            {
                s.Append("元H=");
                s.Append(this.MoSprite.SrcSize.Height);
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public void OnSpriteLocationChanged()
        {
            // スプライト画像の座標
            {
                // ドット絵の1ドットを最小単位にして動くよう調整。スケールは 1、または 2の倍数の整数。

                // ベース
                {
                    int x = (int)this.MoSprite.BaseLocationOnBgOsz.X;
                    int y = (int)this.MoSprite.BaseLocationOnBgOsz.Y;

                    StringBuilder s = this.e_sSpBaseLocationOnBg;
                    s.Length = 0;
                    s.Append("ベースx,y=");
                    s.Append(x);
                    s.Append(",");
                    s.Append(y);
                }

                // 左上
                {
                    int x = (int)this.MoSprite.MyLtOnBgOsz.X;
                    int y = (int)this.MoSprite.MyLtOnBgOsz.Y;

                    StringBuilder s = this.e_sSpLtOnBg;
                    s.Length = 0;
                    s.Append("左上x,y=");
                    s.Append(x);
                    s.Append(",");
                    s.Append(y);
                }

                // 中心
                {
                    int x = (int)this.MoSprite.MyCtOnBg.X;
                    int y = (int)this.MoSprite.MyCtOnBg.Y;

                    StringBuilder s = this.e_sSpCtOnBg;
                    s.Length = 0;
                    s.Append("中心x,y=");
                    s.Append(x);
                    s.Append(",");
                    s.Append(y);
                }
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected MemorySpritememoImpl moSprite;

        /// <summary>
        /// スプライト
        /// </summary>
        public MemorySpritememoImpl MoSprite
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
        /// 背景画像上（on the background image）でのスプライトの点XYを表す文字列。
        /// 画像の左上(Left Top)を指している。
        /// </summary>
        protected StringBuilder e_sSpLtOnBg;

        public StringBuilder E_sSpLtOnBg
        {
            get
            {
                return e_sSpLtOnBg;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 背景画像上（on the background image）でのスプライトの点XYを表す文字列。
        /// 画像の中心(CenTer)を指している。
        /// </summary>
        protected StringBuilder e_sSpCtOnBg;

        public StringBuilder E_sSpCtOnBg
        {
            get
            {
                return e_sSpCtOnBg;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ベースXY。
        /// </summary>
        protected StringBuilder e_sSpBaseLocationOnBg;

        public StringBuilder E_sSpBaseLocationOnBg
        {
            get
            {
                return e_sSpBaseLocationOnBg;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 表示する横幅、縦幅を指定していれば、それを表示。
        /// </summary>
        protected StringBuilder e_sWH;

        public StringBuilder E_sWH
        {
            get
            {
                return e_sWH;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 座標フォント。
        /// </summary>
        protected Font coordinateFont;

        public Font CoordinateFont
        {
            get
            {
                return coordinateFont;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// [1] …座標フォントXY。
        /// [2] …座標フォント影XY。
        /// </summary>
        protected Point[][] textLocationAA;

        public Point[][] TextLocationAA
        {
            get
            {
                return textLocationAA;
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
        #endregion



    }
}
