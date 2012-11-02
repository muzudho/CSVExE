using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Lib;

namespace Xenon.PartsnumPut
{
    public partial class Form1 : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// タイトル。
        /// </summary>
        private void RefreshTitle()
        {
            StringBuilder s = new StringBuilder();

            s.Append("PartsnumPut v");
            s.Append(Application.ProductVersion);
            s.Append(" - Xenon Tools");

            if (this.UsercontrolCanvas.Owner_MemoryApplication.IsChangedContents)
            {
                s.Append(" *");
            }

            this.Text = s.ToString();
        }

        private void SizeFit()
        {
            this.splitContainer1.Size = this.ClientSize;

            this.ucGraphList1.Size = this.splitContainer1.Panel1.ClientSize;
            this.usercontrolCanvas1.Size = this.splitContainer1.Panel2.ClientSize;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.usercontrolCanvas1.Size = this.ClientSize;
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.memory1Application_Partsnumput = new Memory1Application_PartsnumputImpl();
            this.memory1Application_Partsnumput.Form = this;
            this.memory1Application_Partsnumput.Delegate_OnSave = Form1_OnSave;
            this.memory1Application_Partsnumput.Delegate_OnPopupExplain = Form1_OnPopupExplain;

            this.usercontrolCanvas1.InitializeBeforeuse(this.memory1Application_Partsnumput);
            this.Memory1Application_Partsnumput.Delegate_OnRequestPaintBackground = this.usercontrolCanvas1.PaintBackground;
            this.Memory1Application_Partsnumput.Delegate_OnRequestPaintListsprite = this.Memory1Application_Partsnumput.PaintListsprite;
            this.Memory1Application_Partsnumput.Delegate_OnRequestWriteCsv = this.usercontrolCanvas1.WriteCsv;
            this.Memory1Application_Partsnumput.Delegate_OnChanged_SomeContents = this.Form1_OnChanged_SomeContents;
            this.Memory1Application_Partsnumput.Delegate_OnOpened_SomeFiles = this.Form1_OnOpened_SomeFiles;

            // リストボックスの一番上の項目を選ぶ。（再セット）
            this.usercontrolCanvas1.PcddlAlScale.SelectedIndex = 0;
            this.usercontrolCanvas1.PcddlBgOpaque.SelectedIndex = 0;



            //タイトル再描画
            this.RefreshTitle();

            //キャンバスにフォーカスを合わせる
            this.usercontrolCanvas1.Focus();

            //サイズを整える
            this.SizeFit();

            //グルーピング
            this.Memory1Application_Partsnumput.Grouping(this.Memory1Application_Partsnumput);
        }

        //────────────────────────────────────────

        private void Form1_OnSave()
        {
            if (this.ToolStripMenuItem_Save.Enabled)
            {
                this.Memory1Application_Partsnumput.Save();
            }

            this.Memory1Application_Partsnumput.Delegate_OnChanged_SomeContents();
        }

        private void Form1_OnPopupExplain()
        {
            UsercontrolExplainWindow window = new UsercontrolExplainWindow();
            window.TopMost = true;
            window.ShowDialog(this);
        }

        //────────────────────────────────────────

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            // bug:リストボックスで　カーソルを動かしているときも、利いてしまう。

            if (e.Control)
            {
                this.Memory1Application_Partsnumput.IsControlkey = true;

                switch (e.KeyCode)
                {
                    case Keys.S:
                        {
                            // [Ctrl]+[S]
                            this.Memory1Application_Partsnumput.Delegate_OnSave();
                        }
                        break;
                }
            }
            else if (e.Shift)
            {
                this.Memory1Application_Partsnumput.IsShiftkey = true;
            }
            else
            {
                int x;
                int y;
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            // [↑]
                            x = (int)(0 * this.Memory1Application_Partsnumput.ScaleImg);
                            y = (int)(-1 * this.Memory1Application_Partsnumput.ScaleImg);

                            this.usercontrolCanvas1.MoveActiveSprite(x, y);
                        }
                        break;
                    case Keys.Right:
                        {
                            // [→]
                            x = (int)(1 * this.Memory1Application_Partsnumput.ScaleImg);
                            y = (int)(0 * this.Memory1Application_Partsnumput.ScaleImg);

                            this.usercontrolCanvas1.MoveActiveSprite(x, y);
                        }
                        break;
                    case Keys.Down:
                        {
                            // [↓]
                            x = (int)(0 * this.Memory1Application_Partsnumput.ScaleImg);
                            y = (int)(1 * this.Memory1Application_Partsnumput.ScaleImg);

                            this.usercontrolCanvas1.MoveActiveSprite(x, y);
                        }
                        break;
                    case Keys.Left:
                        {
                            // [←]
                            x = (int)(-1 * this.Memory1Application_Partsnumput.ScaleImg);
                            y = (int)(0 * this.Memory1Application_Partsnumput.ScaleImg);

                            this.usercontrolCanvas1.MoveActiveSprite(x, y);
                        }
                        break;

                    case Keys.X:
                        {
                            // [X]ズームダウン
                            this.usercontrolCanvas1.ZoomDown();
                        }
                        break;

                    case Keys.Z:
                        {
                            // [Z]ズームアップ
                            this.usercontrolCanvas1.ZoomUp();
                        }
                        break;
                }
            }

        }

        //────────────────────────────────────────

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.Memory1Application_Partsnumput.IsControlkey = false;
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                this.Memory1Application_Partsnumput.IsShiftkey = false;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// 「PNG、CSV保存」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pNGCSV保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Memory1Application_Partsnumput.Delegate_OnSave();
        }

        /// <summary>
        /// 「背景画像（.png）、表（.csv）のいずれかを開く」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            this.Memory1Application_Partsnumput.ChooseFile_PngCsv(this);
        }

        private void ucCanvas_Load(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.SizeFit();
        }

        private void 説明書ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void 番号配置モードToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 番号レイヤー引越しモードToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //────────────────────────────────────────

        /// <summary>
        /// コンテンツ編集後。
        /// </summary>
        private void Form1_OnChanged_SomeContents()
        {
            this.RefreshTitle();

            if (this.Memory1Application_Partsnumput.IsChangedContents)
            {
                this.ucGraphList1.Enabled = false;
            }
            else
            {
                this.ucGraphList1.Enabled = true;
            }
        }

        //────────────────────────────────────────

        private void Form1_OnOpened_SomeFiles()
        {
            //グルーピング
            this.Memory1Application_Partsnumput.Grouping(this.Memory1Application_Partsnumput);

            //フォーム再描画
            usercontrolCanvas1.Refresh();

            if (null != this.UcDetailWindow)
            {
                //HTMLリロード
                this.UcDetailWindow.UsercontrolDetailbrowser1.ReloadHtml(this.Memory1Application_Partsnumput);
            }
        }

        //────────────────────────────────────────

        private void 詳細ウィンドウToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //詳細ウィンドウを出す
            this.ucDetailWindow = new Form2Detail();
            this.ucDetailWindow.UsercontrolDetailbrowser1.ReloadHtml(this.Memory1Application_Partsnumput);
            this.ucDetailWindow.Show();
            this.ucDetailWindow.TopMost = true;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Memory1Application_Partsnumput memory1Application_Partsnumput;

        public Memory1Application_Partsnumput Memory1Application_Partsnumput
        {
            get
            {
                return this.memory1Application_Partsnumput;
            }
            set
            {
                this.memory1Application_Partsnumput = value;
            }
        }

        //────────────────────────────────────────

        private Form2Detail ucDetailWindow;

        /// <summary>
        /// 詳細ウィンドウ。
        /// </summary>
        public Form2Detail UcDetailWindow
        {
            get
            {
                return this.ucDetailWindow;
            }
        }

        //────────────────────────────────────────

        public UsercontrolCanvas UsercontrolCanvas
        {
            get
            {
                return this.usercontrolCanvas1;
            }
        }

        //────────────────────────────────────────

        public ToolStripMenuItem ToolStripMenuItem_BgOpen
        {
            get
            {
                return this.toolStripMenuItem_BgOpen;
            }
        }

        public ToolStripMenuItem ToolStripMenuItem_Save
        {
            get
            {
                return this.toolStripMenuItem_Save;
            }
        }

        //────────────────────────────────────────

        public UsercontrolListfile UcGraphList1
        {
            get
            {
                return this.ucGraphList1;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
