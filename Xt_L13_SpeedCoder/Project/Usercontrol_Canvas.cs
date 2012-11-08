using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Xenon.Syntax;

namespace Xenon.SpeedCoder
{
    public partial class Usercontrol_Canvas : UserControl
    {



        #region 用意
        //────────────────────────────────────────

        private const string BREAK = "&br;";

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Usercontrol_Canvas()
        {
            InitializeComponent();
            this.Textdroparea1 = new TextdropareaImpl();
            this.Textdroparea1.Bounds = new Rectangle(10, 10, 280, 140);
            this.Textdroparea1.ForegroundBrush = Brushes.Blue;
            this.Textdroparea1.BackgroundBrush = Brushes.SkyBlue;
            this.Textdroparea1.BorderPen = Pens.Blue;
            this.Textdroparea1.BackgroundMessage = "Template";
            this.Textdroparea1.ListMessageA.Add("ここにテンプレートを書いたテキストファイル(.txt)を");
            this.Textdroparea1.ListMessageA.Add("ドラッグ＆ドロップしてください。");
            this.Textdroparea1.ListMessageA.Add("（エンコーディングは UTF-8 にしてください）");
            this.Textdroparea1.ListMessageB.Add("テンプレートを書いたテキストファイル");
            this.Textdroparea1.Font = this.Font;


            this.Textdroparea2 = new TextdropareaImpl();
            this.Textdroparea2.Bounds = new Rectangle(300, 10, 280, 140);
            this.Textdroparea2.ForegroundBrush = Brushes.Green;
            this.Textdroparea2.BackgroundBrush = Brushes.GreenYellow;
            this.Textdroparea2.BorderPen = Pens.Green;
            this.Textdroparea2.BackgroundMessage = "Argument";
            this.Textdroparea2.ListMessageA.Add("ここに入力引数を書いたテキストファイル(.txt)を");
            this.Textdroparea2.ListMessageA.Add("ドラッグ＆ドロップしてください。");
            this.Textdroparea2.ListMessageA.Add("（エンコーディングは UTF-8 にしてください）");
            this.Textdroparea2.ListMessageB.Add("入力引数を書いたテキストファイル");
            this.Textdroparea2.Font = this.Font;
        }

        //────────────────────────────────────────
        #endregion





        #region イベントハンドラー
        //────────────────────────────────────────

        private void Usercontrol_Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            this.Textdroparea1.Paint(g);
            this.Textdroparea2.Paint(g);
        }

        //────────────────────────────────────────

        private void Usercontrol_Canvas_DragDrop(object sender, DragEventArgs e)
        {
            Log_Method log_Method = new Log_MethodImpl();
            Log_Reports log_Reports = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_SpeedCoder.Name_Library, this, "Usercontrol_Canvas_DragDrop", log_Reports);

            Point locationMouse = this.PointToClient(new Point(e.X, e.Y));

            bool isDropped=false;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ファイルドロップ
                TextdropareaImpl droppedArea = null;
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (this.Textdroparea1.Bounds.Contains(locationMouse.X, locationMouse.Y))
                {
                    droppedArea = this.Textdroparea1;
                }

                if (this.Textdroparea2.Bounds.Contains(locationMouse.X, locationMouse.Y))
                {
                    droppedArea = this.Textdroparea2;
                }

                if (null!=droppedArea)
                {
                    droppedArea.IsDropped = true;
                    droppedArea.Clear();
                    //log_Method.WriteDebug_ToConsole("ファイルをドロップした。 fileNames.length=[" + fileNames.Length + "]");
                    foreach (string fileName in fileNames)
                    {
                        droppedArea.ListFilepath.Add(fileName);
                        //log_Method.WriteDebug_ToConsole("fileName=[" + fileName + "]");
                    }

                    isDropped = true;
                }
                else
                {
                    //log_Method.WriteDebug_ToConsole("ファイルをドロップしたが、枠には入っていない。 fileNames.length=[" + fileNames.Length + "]");
                }
            }
            // 文字列
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                // 文字列として読み取れる形式のデータがドロップされた場合、
                // テキストボックスに、その文字列データを表示します。
                string droppedText = (string)e.Data.GetData(typeof(string));

                
                TextdropareaImpl droppedArea = null;
                if (this.Textdroparea1.Bounds.Contains(locationMouse.X, locationMouse.Y))
                {
                    droppedArea = this.Textdroparea1;
                }

                if (this.Textdroparea2.Bounds.Contains(locationMouse.X, locationMouse.Y))
                {
                    droppedArea = this.Textdroparea2;
                }

                if (null != droppedArea)
                {
                    droppedArea.IsDropped = true;
                    droppedArea.Clear();

                    droppedArea.DroppedText = droppedText;

                    isDropped = true;
                }
            }
            else
            {
                //log_Method.WriteDebug_ToConsole("ファイル以外のものをドロップした。");
            }

            if (isDropped)
            {
                SpeedCodingImpl speedCoding = new SpeedCodingImpl();
                bool isError;
                string result = speedCoding.Perform(out isError, this.Textdroparea1, this.Textdroparea2, log_Reports);
                this.textBox1.Text = result;
                if (isError)
                {
                    this.textBox1.ForeColor = Color.Red;
                }
                else
                {
                    this.textBox1.ForeColor = SystemColors.ControlText;
                }

                this.Refresh();
            }

            //log_Method.WriteDebug_ToConsole("locationMouse.X=[" + locationMouse.X + "] .Y=[" + locationMouse.Y + "]");
            //log_Method.WriteDebug_ToConsole("this.Textdroparea1.Bounds=[" + this.Textdroparea1.Bounds.X + "][" + this.Textdroparea1.Bounds.Y + "][" + this.Textdroparea1.Bounds.Width + "][" + this.Textdroparea1.Bounds.Height + "]");
            //log_Method.WriteDebug_ToConsole("this.Textdroparea2.Bounds=[" + this.Textdroparea2.Bounds.X + "][" + this.Textdroparea2.Bounds.Y + "][" + this.Textdroparea2.Bounds.Width + "][" + this.Textdroparea2.Bounds.Height + "]");

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        private void Usercontrol_Canvas_DragEnter(object sender, DragEventArgs e)
        {
            Log_Method log_Method = new Log_MethodImpl();
            Log_Reports log_Reports = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_SpeedCoder.Name_Library, this, "Usercontrol_Canvas_DragEnter", log_Reports);

            // ファイルドロップ
            if (
                e.Data.GetDataPresent(DataFormats.FileDrop)//ファイルパス
                ||
                e.Data.GetDataPresent(DataFormats.StringFormat)//文字列
                )
            {
                // ドロップした時の効果を Copy として見えるようにします。
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「クリップボードへコピー」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClipboardcopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.textBox1.Text);
        }

        /// <summary>
        /// 「&br;折る」誤判定をすることもある。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrBreak_Click(object sender, EventArgs e)
        {
            Log_Method log_Method = new Log_MethodImpl();
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_SpeedCoder.Name_Library, this, "buttonBrBreak_Click", log_Reports_ThisMethod);

            string left = this.textBox1.Text;//残りの文字列。

            StringBuilder s = new StringBuilder();

            int index;
            index = left.IndexOf(Usercontrol_Canvas.BREAK);
            while (0 <= index)
            {
                string a = left.Substring(0, index);
                string b = left.Substring(Usercontrol_Canvas.BREAK.Length + index);
                //System.Console.WriteLine("left=[" + left + "] index=["+index+"] a=["+a+"] b=["+b+"]");

                s.Append(a);
                s.Append(Usercontrol_Canvas.BREAK);

                if (b.StartsWith(Environment.NewLine))
                {
                    //既に改行が付いているのなら、付けない。
                }
                else
                {
                    s.Append(Environment.NewLine);
                }
                left = b;

                index = left.IndexOf(Usercontrol_Canvas.BREAK);

                //log_Method.WriteDebug_ToConsole("left.Length=[" + left.Length + "]");
            }

            s.Append(left);

            this.textBox1.Text = s.ToString();
            log_Method.EndMethod(log_Reports_ThisMethod);
        }

        /// <summary>
        /// 「&br;結ぶ」誤判定をすることもある。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrCombine_Click(object sender, EventArgs e)
        {
            string old = this.textBox1.Text;

            StringBuilder s = new StringBuilder();

            string[] lines = old.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                s.Append(line);
                if (line.EndsWith(Usercontrol_Canvas.BREAK))
                {
                    //行末が「&br;」で終わっている場合、改行を追加しません。
                }
                else
                {
                    s.Append(Environment.NewLine);
                }
            }

            this.textBox1.Text = s.ToString();
        }

        /// <summary>
        /// 「クリアー」ボタン。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private TextdropareaImpl textdroparea1;

        public TextdropareaImpl Textdroparea1
        {
            get
            {
                return this.textdroparea1;
            }
            set
            {
                this.textdroparea1 = value;
            }
        }

        //────────────────────────────────────────

        private TextdropareaImpl textdroparea2;

        public TextdropareaImpl Textdroparea2
        {
            get
            {
                return this.textdroparea2;
            }
            set
            {
                this.textdroparea2 = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
