using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xt_L13_Spritecanvas
{
    public partial class UsercontrolPanelFiledrop : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolPanelFiledrop()
        {
            this.Text = "ここにファイルをドロップしてください";
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion





        #region イベントハンドラー
        //────────────────────────────────────────

        private void UsercontrolPanelFiledrop_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SizeF sizeText = g.MeasureString(this.Text, this.Font);

            e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, new PointF(this.ClientSize.Width / 2 - sizeText.Width / 2, this.ClientSize.Height / 2 - sizeText.Height / 2));

        }

        //────────────────────────────────────────

        private void UsercontrolPanelFiledrop_Load(object sender, EventArgs e)
        {

            // カーソルのアイコン画像。.icoや、.cur。
            this.cursor_DraggingMove = new Cursor("img/ImageDragMove.ico");
            this.cursor_DraggingCopy = new Cursor("img/ImageDragCopy.ico");
            this.cursor_DraggingLink = new Cursor("img/ImageDragLink.ico");
            this.cursor_DraggingDisable = new Cursor("img/ImageDragNone.ico");

        }

        //────────────────────────────────────────

        /// <summary>
        /// ドラッグ＆ドロップ開始時に発生します。
        /// マウス・カーソルを指定するのに使います。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsercontrolPanelFiledrop_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            /// マウス・カーソルは、リストボックスと対象パネルの間に
            /// フォームの上を通りますので、その間のカーソルも変更するために
            /// フォームの AllowDropプロパティーを True に設定しておいてください。

            // マウス・カーソルのアイコン画像を変更します。

            // 既定のカーソルを使わないようにします。
            e.UseDefaultCursors = false;

            // ドロップの効果に合わせて、カーソルを指定します。
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // 移動
                Cursor.Current = this.cursor_DraggingMove;
            }
            else if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                // コピー
                Cursor.Current = this.cursor_DraggingCopy;
            }
            else if ((e.Effect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // ショートカット
                Cursor.Current = this.cursor_DraggingLink;
            }
            else
            {
                // 禁止
                Cursor.Current = this.cursor_DraggingDisable;
            }
        }

        //────────────────────────────────────────
        //
        //ドラッグ＆ドロップ
        //

        /// <summary>
        /// データが、パネルの上にドロップされたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsercontrolPanelFiledrop_DragDrop(object sender, DragEventArgs e)
        {
            string text_Dropped = "";
            string text_Format_Dropped;
            string text_StatusResults;
            Image image_Dropped = null;

            // ドロップされたデータの形式を一覧します。
            StringBuilder text = new StringBuilder();
            text.Append("ドロップされたデータの形式の個数=[");
            text.Append(e.Data.GetFormats().Length);
            text.Append("]\r\n");
            foreach (string format in e.Data.GetFormats())
            {
                text.Append(format);
                text.Append("\r\n");
            }
            text_Format_Dropped = text.ToString();

            //ドロップされたデータの形式を調べます。

            // ファイルドロップ
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ファイルであれば。
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                // ドロップされたファイル名を一覧します。
                StringBuilder fileNamesText = new StringBuilder();
                fileNamesText.Append("ドロップされたファイル名の個数=[");
                fileNamesText.Append(fileNames.Length);
                fileNamesText.Append("]\r\n");

                foreach (string fileName in fileNames)
                {
                    Bitmap droppedBitmap = null;
                    try
                    {
                        // ファイル名が画像を指していれば画像に、
                        // そうでなければ例外を返します。
                        droppedBitmap = new Bitmap(fileName);

                        image_Dropped = droppedBitmap;
                    }
                    catch (Exception)
                    {
                        // 画像ではなかった場合。

                        // 無視します。
                    }

                    // ファイル名を取得していきます。
                    fileNamesText.Append(fileName);
                    fileNamesText.Append("\r\n");
                }
                text_Dropped = fileNamesText.ToString();

                text_StatusResults = "ファイル名のようなものがパネルの上に落とされました。";
            }
            // URL
            else if (
                e.Data.GetDataPresent("UniformResourceLocator") ||
                e.Data.GetDataPresent("UniformResourceLocatorW")
                )
            {
                // 現在、プログラムの処理は　このコードまで到達しません。

                MessageBox.Show(e.Data.GetData("UniformResourceLocator").ToString(), "URI");

                // URLとして読み取れる形式のデータがドロップされた場合、
                // テキストボックスに、そのURLを表示します。
                string droppedUri = e.Data.GetData("UniformResourceLocator").ToString();
                if ("" == droppedUri)
                {
                    droppedUri = e.Data.GetData("UniformResourceLocatorW").ToString();
                }

                text_Dropped = droppedUri;

                text_StatusResults = "URLがパネルの上に落とされました。";
            }
            // 文字列
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                // 文字列として読み取れる形式のデータがドロップされた場合、
                // テキストボックスに、その文字列データを表示します。
                string droppedText = (string)e.Data.GetData(typeof(string));

                text_Dropped = droppedText;

                text_StatusResults = "文字列がパネルの上に落とされました。";
            }
            else
            {
                text_StatusResults = "何かパネルの上に落とされましたが、文字列としても画像としても読み取れませんでした。";
            }
            // 文字列または画像のどちらにも読み取れないデータは無視します。


            //デバッグ出力
            {
                System.Console.WriteLine("text_Dropped=[" + text_Dropped + "]");
                System.Console.WriteLine("text_Format_Dropped=[" + text_Format_Dropped + "]");
                System.Console.WriteLine("text_StatusResults=[" + text_StatusResults + "]");
                System.Console.WriteLine("image_Dropped=[" + image_Dropped + "]");
            }
        }

        private void UsercontrolPanelFiledrop_DragEnter(object sender, DragEventArgs e)
        {
            string text_StatusEnters = "";
            string text_StatusReceives = "";
            string text_StatusResults = "";
            string text_Format_Dropped;

            // ドラッグされてきたデータの形式を一覧します。
            StringBuilder text = new StringBuilder();
            text.Append("ドラッグされてきたデータの形式の個数=[");
            text.Append(e.Data.GetFormats().Length);
            text.Append("]\r\n");
            foreach (string format in e.Data.GetFormats())
            {
                text.Append(format);
                text.Append("\r\n");
            }
            text_Format_Dropped = text.ToString();


            // ドラッグされてきたデータの形式を調べます。

            // ファイルドロップ
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                text_StatusEnters = "ファイル名のようなものがパネルの上にドラッグされてきました。";

                // ドロップした時の効果を Copy として見えるようにします。
                e.Effect = DragDropEffects.Copy;
                text_StatusReceives = "コピーの受け入れ態勢をとります。ファイルの名前のようなものとして読み取れます。";
            }
            // URL
            else if (
                e.Data.GetDataPresent("UniformResourceLocator") ||
                e.Data.GetDataPresent("UniformResourceLocatorW")
                )
            {
                text_StatusEnters = "URLのようなものがパネルの上にドラッグされてきました。";

                // URLであれば、ドロップした時の効果を Copy として見えるようにします。
                e.Effect = DragDropEffects.Copy;
                text_StatusReceives = "コピーの受け入れ態勢をとります。URLとして読み取れます。（HTMLへのリンクは何故かドロップできないようです。）";
            }
            // 文字列
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                text_StatusEnters = "文字列のようなものがパネルの上にドラッグされてきました。";

                // 文字列であれば、ドロップした時の効果を Copy として見えるようにします。
                e.Effect = DragDropEffects.Copy;
                text_StatusReceives = "コピーの受け入れ態勢をとります。文字列として読み取れます。";
            }
            else
            {
                text_StatusEnters = "何かパネルの上にドラッグされてきました。";

                // 文字列でも画像でもなければ、ドロップできないように見えるようにします。
                e.Effect = DragDropEffects.None;
                text_StatusReceives = "受け入れない態勢をとります。文字列としても画像としても読み取れません。";
            }

            //デバッグ出力
            {
                System.Console.WriteLine("text_StatusEnters=[" + text_StatusEnters + "]");
                System.Console.WriteLine("text_StatusReceives=[" + text_StatusReceives + "]");
                System.Console.WriteLine("text_StatusResults=[" + text_StatusResults + "]");
                System.Console.WriteLine("text_Format_Dropped=[" + text_Format_Dropped + "]");
            }
        }

        private void UsercontrolPanelFiledrop_DragLeave(object sender, EventArgs e)
        {
            string text_StatusEnters = "パネルの上でドラッグの意思のあったマウスカーソルは、どこかへ消えました。";
            string text_StatusReceives = "";

            //デバッグ出力
            {
                System.Console.WriteLine("text_StatusEnters=[" + text_StatusEnters + "]");
                System.Console.WriteLine("text_StatusReceives=[" + text_StatusReceives + "]");
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string text;

        /// <summary>
        /// 表示テキスト
        /// </summary>
        [
        Category("プロパティー"),
        Description("ユーザーコントロールの中央に表示される文字列です。"),
        Browsable(true)
        ]
        public new string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }

        //────────────────────────────────────────

        // ドラッグ時のカーソルの画像。移動時。
        private Cursor cursor_DraggingMove;

        // ドラッグ時のカーソルの画像。コピー時。
        private Cursor cursor_DraggingCopy;

        // ドラッグ時のカーソルの画像。ショートカット作成時。
        private Cursor cursor_DraggingLink;

        // ドラッグ時のカーソルの画像。禁止時。
        private Cursor cursor_DraggingDisable;

        //────────────────────────────────────────
        #endregion



    }
}
