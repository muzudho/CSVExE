using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using Xenon.Syntax;

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
            this.Clear();
            this.ForegroundBrush = Brushes.Red;// Brushes.Black;
            this.BackgroundBrush = Brushes.Yellow;// Brushes.White;
            this.BorderPen = Pens.Black;
            this.BackgroundMessage = "Unknown";
            this.ListMessageA = new List<string>();
            this.ListMessageB = new List<string>();
            this.Font = SystemFonts.DefaultFont;
        }

        public void Clear()
        {
            this.DroppedText = "";
            this.ListFilepath.Clear();
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        public bool HasText()
        {
            bool result = false;

            if (0 < this.ListFilepath.Count)
            {
                result = true;
            }
            else if(""!=this.DroppedText)
            {
                result = true;
            }

            return result;
        }

        public void Paint(Graphics g)
        {
            //Log_Method log_Method = new Log_MethodImpl();
            //Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            //log_Method.BeginMethod(Info_SpeedCoder.Name_Library, this, "Paint", log_Reports_ThisMethod);


            //log_Method.WriteDebug_ToConsole("ドロップエリアの描画。");


            if (this.IsDropped)
            {
                //入力があった場合の背景塗りつぶし。
                //log_Method.WriteDebug_ToConsole("入力があった場合の背景塗りつぶし。this.BackgroundBrush=[" + this.BackgroundBrush + "]");

                g.FillRectangle(this.BackgroundBrush, this.Bounds);
            }

            g.DrawRectangle(this.BorderPen, this.Bounds);

            g.DrawString( this.BackgroundMessage, new Font("メイリオ", 36.0f), Brushes.White, new PointF(this.Bounds.X+30, this.Bounds.Y+70));

            int y = this.Bounds.Y;
            if (this.HasText())
            {
                //入力があった場合の表示。

                y += 40;
                foreach(string messageA in this.ListMessageA)
                {
                    g.DrawString(messageA, this.Font, this.ForegroundBrush, new PointF(this.Bounds.X + 30, y));
                    y += 20;
                }
            }
            else
            {
                y += 40;
                foreach (string messageB in this.ListMessageB)
                {
                    g.DrawString(messageB, this.Font, this.ForegroundBrush, new PointF(this.Bounds.X + 30, y));
                    y += 20;
                }

                if (0 < this.ListFilepath.Count)
                {
                    string filename = this.ListFilepath[0];

                    // ファイル名が入力されていれば。
                    g.DrawString(filename, this.Font, this.ForegroundBrush, new PointF(this.Bounds.X + 30, y));
                    y += 20;
                    if (2 <= this.ListFilepath.Count)
                    {
                        g.DrawString("他 " + (this.ListFilepath.Count - 1) + " ファイル", this.Font, this.ForegroundBrush, new PointF(this.Bounds.X + 30, y));
                    }
                }
            }


            //log_Reports_ThisMethod.EndLogging(log_Method);
        }

        //────────────────────────────────────────
        #endregion




        #region プロパティー
        //────────────────────────────────────────

        private string droppedText;

        /// <summary>
        /// ドラッグ＆ドロップしたテキスト。
        /// </summary>
        public string DroppedText
        {
            get
            {
                return this.droppedText;
            }
            set
            {
                this.droppedText = value;
            }
        }

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
