using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragAndDrop
{
    public partial class Form1 : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Form1()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// マウス・カーソルのアイコン画像を変更します。
        /// </summary>
        /// <param name="e"></param>
        private void changeCursorIcon(GiveFeedbackEventArgs e)
        {
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
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// データが、パネルの上にドロップされたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            this.textBox1.Text = "";
            this.pictureBox1.Image = null;

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
            this.formatsTxt.Text = text.ToString();

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

                        this.pictureBox1.Image = droppedBitmap;
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
                this.textBox1.Text = fileNamesText.ToString();

                this.statusResultsTxt.Text = "ファイル名のようなものがパネルの上に落とされました。";
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

                this.textBox1.Text = droppedUri;

                this.statusResultsTxt.Text = "URLがパネルの上に落とされました。";
            }
            // 文字列
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                // 文字列として読み取れる形式のデータがドロップされた場合、
                // テキストボックスに、その文字列データを表示します。
                string droppedText = (string)e.Data.GetData(typeof(string));

                this.textBox1.Text = droppedText;

                this.statusResultsTxt.Text = "文字列がパネルの上に落とされました。";
            }
            else
            {
                this.statusResultsTxt.Text = "何かパネルの上に落とされましたが、文字列としても画像としても読み取れませんでした。";
            }
            // 文字列または画像のどちらにも読み取れないデータは無視します。
        }

        /// <summary>
        /// データが、パネルの上にエンターされたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            this.statusEntersTxt.Text = "";
            this.statusReceivesTxt.Text = "";
            this.statusResultsTxt.Text = "";

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
            this.formatsTxt.Text = text.ToString();


            // ドラッグされてきたデータの形式を調べます。

            // ファイルドロップ
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                this.statusEntersTxt.Text = "ファイル名のようなものがパネルの上にドラッグされてきました。";

                // ドロップした時の効果を Copy として見えるようにします。
                e.Effect = DragDropEffects.Copy;
                this.statusReceivesTxt.Text = "コピーの受け入れ態勢をとります。ファイルの名前のようなものとして読み取れます。";
            }
            // URL
            else if (
                e.Data.GetDataPresent("UniformResourceLocator") ||
                e.Data.GetDataPresent("UniformResourceLocatorW")
                )
            {
                this.statusEntersTxt.Text = "URLのようなものがパネルの上にドラッグされてきました。";

                // URLであれば、ドロップした時の効果を Copy として見えるようにします。
                e.Effect = DragDropEffects.Copy;
                this.statusReceivesTxt.Text = "コピーの受け入れ態勢をとります。URLとして読み取れます。（HTMLへのリンクは何故かドロップできないようです。）";
            }
            // 文字列
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                this.statusEntersTxt.Text = "文字列のようなものがパネルの上にドラッグされてきました。";

                // 文字列であれば、ドロップした時の効果を Copy として見えるようにします。
                e.Effect = DragDropEffects.Copy;
                this.statusReceivesTxt.Text = "コピーの受け入れ態勢をとります。文字列として読み取れます。";
            }
            else
            {
                this.statusEntersTxt.Text = "何かパネルの上にドラッグされてきました。";

                // 文字列でも画像でもなければ、ドロップできないように見えるようにします。
                e.Effect = DragDropEffects.None;
                this.statusReceivesTxt.Text = "受け入れない態勢をとります。文字列としても画像としても読み取れません。";
            }
        }

        /// <summary>
        /// ドラッグのマウスカーソルがパネルの上から消えたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_DragLeave(object sender, EventArgs e)
        {
            this.statusEntersTxt.Text = "パネルの上でドラッグの意思のあったマウスカーソルは、どこかへ消えました。";
            this.statusReceivesTxt.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // カーソルのアイコン画像。.icoや、.cur。
            this.cursor_DraggingMove = new Cursor("img/ImageDragMove.ico");
            this.cursor_DraggingCopy = new Cursor("img/ImageDragCopy.ico");
            this.cursor_DraggingLink = new Cursor("img/ImageDragLink.ico");
            this.cursor_DraggingDisable = new Cursor("img/ImageDragNone.ico");

            // リストボックスの内容
            this.listBox1.Items.Add("みかん");
            this.listBox1.Items.Add("ゆず");
            this.listBox1.Items.Add("グレープ");
            this.listBox1.Items.Add("かぼす");
        }

        /// <summary>
        /// リストボックスの上で、マウス・ボタンが押下されたとき。
        /// 
        /// マウス・カーソルの座標位置を記憶します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // マウスの左ボタンが押下されている時、ドラッグを実行中にします。

            // マウスの左ボタンが押されている時。
            if (e.Button == MouseButtons.Left)
            {
                // このリストボックス
                ListBox listBox = (ListBox)sender;
                // ドラッグするアイテムのインデックスを取得します。
                int itemIndex = listBox.IndexFromPoint(e.X, e.Y);
                if (0 <= itemIndex)
                {
                    // 選択時。
                    this.location_Mousedown = new Point(e.X, e.Y);

                    // ここでは　ドラッグ＆ドロップしません。
                }
                else
                {
                    // 未選択時。
                    return;
                }
            }
            // マウスの左ボタン以外が押されたとき。
            else
            {
                this.location_Mousedown = Point.Empty;
            }
        }

        /// <summary>
        /// リストボックスの上で、マウス・ボタンが放されたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.location_Mousedown = Point.Empty;
        }

        /// <summary>
        /// リストボックスの上で、マウス・カーソルが移動したとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // マウス・カーソルの座標位置が記憶されている場合。
            if (this.location_Mousedown != Point.Empty)
            {
                // ドラッグと判定しないマウス・カーソルの移動範囲を取得する
                Rectangle noDragBounds = new Rectangle(
                    this.location_Mousedown.X - SystemInformation.DragSize.Width / 2,
                    this.location_Mousedown.Y - SystemInformation.DragSize.Height / 2,
                    SystemInformation.DragSize.Width,
                    SystemInformation.DragSize.Height);

                // ドラッグと判定しない移動範囲を超えたかどうか判定します。
                if (!noDragBounds.Contains(e.X, e.Y))
                {
                    // このリスト・ボックス
                    ListBox listBox = (ListBox)sender;

                    // ドラッグするアイテムのインデックスを取得します。
                    int itemIndex = listBox.IndexFromPoint(this.location_Mousedown);
                    if (itemIndex < 0)
                    {
                        return;
                    }

                    // ドラッグするアイテムの内容を取得します。
                    string itemText = (string)listBox.Items[itemIndex];

                    // ドラッグ＆ドロップの実行中になります。
                    DragDropEffects effects =
                        listBox.DoDragDrop(itemText,
                            DragDropEffects.All | DragDropEffects.Link);

                    // ドロップしたときの効果がMoveになる場合は、もとのアイテムを削除します。
                    if (effects == DragDropEffects.Move)
                    {
                        listBox.Items.RemoveAt(itemIndex);
                    }

                    this.location_Mousedown = Point.Empty;
                }
            }

        }

        /// <summary>
        /// ドラッグ＆ドロップ開始時に発生します。
        /// マウス・カーソルを指定するのに使います。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            /// マウス・カーソルは、リストボックスと対象パネルの間に
            /// フォームの上を通りますので、その間のカーソルも変更するために
            /// フォームの AllowDropプロパティーを True に設定しておいてください。

            // マウス・カーソルのアイコン画像を変更します。
            this.changeCursorIcon(e);
        }

        /// <summary>
        /// ドラッグ＆ドロップ中に発生します。
        /// ドラッグをキャンセルするのに使います。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            // ドラッグ中にマウスの右ボタンが押されていれば、ドラッグをキャンセルします。

            // "2"は、マウスの右ボタンを表します。何故か定数はないようです。
            if ((e.KeyState & 2) == 2)
            {
                e.Action = DragAction.Cancel;
            }
        }

        //────────────────────────────────────────
        #endregion


        #region プロパティー
        //────────────────────────────────────────

        // マウス・ボタンが押された時の座標位置
        private Point location_Mousedown = Point.Empty;

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
