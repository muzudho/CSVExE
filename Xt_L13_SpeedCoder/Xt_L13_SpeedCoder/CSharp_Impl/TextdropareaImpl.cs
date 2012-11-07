using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Xenon.SpeedCoder
{


    /// <summary>
    /// テキスト・ドロップ・エリア。
    /// </summary>
    public class TextdropareaImpl
    {


        #region 生成と破棄
        //────────────────────────────────────────

        public TextdropareaImpl()
        {
            this.Bounds = new Rectangle();
            this.ListFilepath = new List<string>();
            this.ForegroundBrush = Brushes.Black;
            this.BackgroundBrush = Brushes.White;
            this.BorderPen = Pens.Black;
            this.BackgroundMessage = "Unknown";
            this.ListMessageA = new List<string>();
            this.ListMessageB = new List<string>();
            this.Font = SystemFonts.DefaultFont;
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        public void Paint(Graphics g)
        {

            if (this.IsDropped)
            {
                g.FillRectangle(this.BackgroundBrush, this.Bounds);
            }

            g.DrawRectangle(this.BorderPen, this.Bounds);

            g.DrawString( this.BackgroundMessage, new Font("メイリオ", 36.0f), Brushes.White, new PointF(this.Bounds.X+30, this.Bounds.Y+70));

            int y = this.Bounds.Y;
            if (0 == this.ListFilepath.Count)
            {
                y += 40;
                foreach(string messageA in this.ListMessageA)
                {
                    g.DrawString(messageA, this.Font, this.ForegroundBrush, new PointF(this.Bounds.X + 30, y));
                    y += 20;
                }
            }
            else
            {
                string filename = System.IO.Path.GetFileName(this.ListFilepath[0]);
                y += 40;
                foreach (string messageB in this.ListMessageB)
                {
                    g.DrawString(messageB, this.Font, this.ForegroundBrush, new PointF(this.Bounds.X + 30, y));
                    y += 20;
                }

                g.DrawString(filename, this.Font, this.ForegroundBrush, new PointF(this.Bounds.X + 30, y));
                y += 20;
                if (2 <= this.ListFilepath.Count)
                {
                    g.DrawString("他 " + (this.ListFilepath.Count - 1) + " ファイル", this.Font, Brushes.Blue, new PointF(this.Bounds.X + 30, y));
                }
            }

        }

        //────────────────────────────────────────
        #endregion




        #region プロパティー
        //────────────────────────────────────────

        private List<string> listFilepath;

        public List<string> ListFilepath
        {
            get
            {
                return this.listFilepath;
            }
            set
            {
                this.listFilepath = value;
            }
        }

        //────────────────────────────────────────

        private bool isDropped;

        public bool IsDropped
        {
            get
            {
                return this.isDropped;
            }
            set
            {
                this.isDropped = value;
            }
        }

        //────────────────────────────────────────

        private Rectangle bounds;

        public Rectangle Bounds
        {
            get
            {
                return this.bounds;
            }
            set
            {
                this.bounds = value;
            }
        }

        //────────────────────────────────────────

        private Brush foregroundBrush;

        public Brush ForegroundBrush
        {
            get
            {
                return this.foregroundBrush;
            }
            set
            {
                this.foregroundBrush = value;
            }
        }

        //────────────────────────────────────────

        private Brush backgroundBrush;

        public Brush BackgroundBrush
        {
            get
            {
                return this.backgroundBrush;
            }
            set
            {
                this.backgroundBrush = value;
            }
        }

        //────────────────────────────────────────

        private Pen borderPen;

        public Pen BorderPen
        {
            get
            {
                return this.borderPen;
            }
            set
            {
                this.borderPen = value;
            }
        }

        //────────────────────────────────────────

        private string backgroundMessage;

        public string BackgroundMessage
        {
            get
            {
                return this.backgroundMessage;
            }
            set
            {
                this.backgroundMessage = value;
            }
        }

        //────────────────────────────────────────

        private List<string> listMessageA;

        public List<string> ListMessageA
        {
            get
            {
                return this.listMessageA;
            }
            set
            {
                this.listMessageA = value;
            }
        }

        //────────────────────────────────────────

        private List<string> listMessageB;

        public List<string> ListMessageB
        {
            get
            {
                return this.listMessageB;
            }
            set
            {
                this.listMessageB = value;
            }
        }

        //────────────────────────────────────────

        private Font font;

        public Font Font
        {
            get
            {
                return this.font;
            }
            set
            {
                this.font = value;
            }
        }

        //────────────────────────────────────────
        #endregion




    }



}
