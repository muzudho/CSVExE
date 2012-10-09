using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.NumPut
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
        /// コンテンツ編集後。
        /// </summary>
        public void OnContentsChanged()
        {
            this.RefreshTitle();

            if (this.UcCanvas.MoApplication.MoProject.MoContents.BChangedContents)
            {
                this.ucGraphList1.Enabled = false;
            }
            else
            {
                this.ucGraphList1.Enabled = true;
            }
        }

        /// <summary>
        /// タイトル。
        /// </summary>
        private void RefreshTitle()
        {
            StringBuilder s = new StringBuilder();

            s.Append("NumPut v");
            s.Append(Application.ProductVersion);
            s.Append(" - Xenon Tools");

            if (this.UcCanvas.MoApplication.MoProject.MoContents.BChangedContents)
            {
                s.Append(" *");
            }

            this.Text = s.ToString();
        }

        private void SizeFit()
        {
            this.splitContainer1.Size = this.ClientSize;

            this.ucGraphList1.Size = this.splitContainer1.Panel1.ClientSize;
            this.ucCanvas.Size = this.splitContainer1.Panel2.ClientSize;
        }

        public void Save()
        {
            //
            //
            this.UcCanvas.MoApplication.MoProject.MoContents.Save(this);

            //
            //
            this.OnContentsChanged();
        }

        public void OnOpened()
        {
            // グルーピング、フォーム再描画、HTMLリロード。
            ucCanvas.MoApplication.MoProject.MoContents.Grouping();
            ucCanvas.Refresh();
            this.UcDetailWindow.UcDetailOut.ReloadHtml(ucCanvas.MoApplication.MoProject.MoContents);
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.ucCanvas.Size = this.ClientSize;
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.RefreshTitle();

            this.ucCanvas.Focus();

            this.SizeFit();

            // グルーピング
            this.ucCanvas.MoApplication.MoProject.MoContents.Grouping();

            // 詳細ウィンドウ
            this.ucDetailWindow = new UsercontrolDetailWindow();
            this.ucDetailWindow.UcDetailOut.ReloadHtml(this.ucCanvas.MoApplication.MoProject.MoContents);
            this.ucDetailWindow.Show();
            this.ucDetailWindow.TopMost = true;
        }

        //────────────────────────────────────────

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            // bug:リストボックスで　カーソルを動かしているときも、利いてしまう。

            if (e.Control)
            {
                this.ucCanvas.MoApplication.MoProject.MoContents.BCtrlKey = true;

                switch (e.KeyCode)
                {
                    case Keys.S:
                        {
                            // [Ctrl]+[S]
                            this.Save();
                        }
                        break;
                }
            }
            else if (e.Shift)
            {
                this.ucCanvas.MoApplication.MoProject.MoContents.BShiftKey = true;
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
                            x = (int)(0 * this.ucCanvas.MoApplication.MoProject.MoContents.ScaleImg);
                            y = (int)(-1 * this.ucCanvas.MoApplication.MoProject.MoContents.ScaleImg);

                            this.ucCanvas.MoveActiveSprite(x, y);
                        }
                        break;
                    case Keys.Right:
                        {
                            // [→]
                            x = (int)(1 * this.ucCanvas.MoApplication.MoProject.MoContents.ScaleImg);
                            y = (int)(0 * this.ucCanvas.MoApplication.MoProject.MoContents.ScaleImg);

                            this.ucCanvas.MoveActiveSprite(x, y);
                        }
                        break;
                    case Keys.Down:
                        {
                            // [↓]
                            x = (int)(0 * this.ucCanvas.MoApplication.MoProject.MoContents.ScaleImg);
                            y = (int)(1 * this.ucCanvas.MoApplication.MoProject.MoContents.ScaleImg);

                            this.ucCanvas.MoveActiveSprite(x, y);
                        }
                        break;
                    case Keys.Left:
                        {
                            // [←]
                            x = (int)(-1 * this.ucCanvas.MoApplication.MoProject.MoContents.ScaleImg);
                            y = (int)(0 * this.ucCanvas.MoApplication.MoProject.MoContents.ScaleImg);

                            this.ucCanvas.MoveActiveSprite(x, y);
                        }
                        break;

                    case Keys.X:
                        {
                            // [X]ズームダウン
                            this.ucCanvas.ZoomDown();
                        }
                        break;

                    case Keys.Z:
                        {
                            // [Z]ズームアップ
                            this.ucCanvas.ZoomUp();
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
                this.ucCanvas.MoApplication.MoProject.MoContents.BCtrlKey = false;
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                this.ucCanvas.MoApplication.MoProject.MoContents.BShiftKey = false;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pNGCSV保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void toolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            UsercontrolCanvas ucCanvas = this.UcCanvas;

            ucCanvas.PcdlgOpenBg.InitialDirectory = Application.StartupPath;
            DialogResult result = ucCanvas.PcdlgOpenBg.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                // 絶対ファイルパス
                string sFpatha = ucCanvas.PcdlgOpenBg.FileName;

                //ystem.Console.WriteLine("System.IO.Path.GetExtension(sFpatha)=" + System.IO.Path.GetExtension(sFpatha));
                string sExtension = System.IO.Path.GetExtension(sFpatha);
                if (".png" == sExtension)
                {
                    this.UcCanvas.MoApplication.MoProject.MoContents.SFpath_BgPng = sFpatha;
                    this.UcCanvas.OpenBg();

                    // CSVファイルも予想。
                    StringBuilder s = new StringBuilder();
                    s.Append(System.IO.Path.GetDirectoryName(sFpatha));
                    s.Append(System.IO.Path.DirectorySeparatorChar);
                    s.Append(System.IO.Path.GetFileNameWithoutExtension(sFpatha));
                    s.Append(".csv");
                    this.UcCanvas.MoApplication.MoProject.MoContents.SFpath_Csv = s.ToString();
                    //ystem.Console.WriteLine("CSVファイル=" + sFpathCsv);

                    this.UcCanvas.OpenCsv();

                    // ディレクトリー読込み
                    this.ucGraphList1.LoadDirectory(System.IO.Path.GetDirectoryName(sFpatha));
                    this.OnOpened();
                }
                else if (".csv" == sExtension)
                {
                    this.UcCanvas.MoApplication.MoProject.MoContents.SFpath_Csv = sFpatha;
                    this.UcCanvas.OpenCsv();

                    // PNGファイルも予想。
                    StringBuilder s = new StringBuilder();
                    s.Append(System.IO.Path.GetDirectoryName(sFpatha));
                    s.Append(System.IO.Path.DirectorySeparatorChar);
                    s.Append(System.IO.Path.GetFileNameWithoutExtension(sFpatha));
                    s.Append(".png");
                    this.UcCanvas.MoApplication.MoProject.MoContents.SFpath_BgPng = s.ToString();
                    //ystem.Console.WriteLine("PNGファイル=" + sFpathPng);

                    this.UcCanvas.OpenBg();

                    // ディレクトリー読込み
                    this.ucGraphList1.LoadDirectory(System.IO.Path.GetDirectoryName(sFpatha));
                    this.OnOpened();
                }
            }
            else if (result == DialogResult.Cancel)
            {
                //変更なし
            }
            else
            {
                this.toolStripMenuItem_BgOpen.Enabled = false;
            }

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
            UsercontrolExplainWindow window = new UsercontrolExplainWindow();
            window.TopMost = true;
            window.ShowDialog(this);
        }

        private void 番号配置モードToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 番号レイヤー引越しモードToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //────────────────────────────────────────
        #endregion

        

        #region プロパティー
        //────────────────────────────────────────

        private UsercontrolDetailWindow ucDetailWindow;

        /// <summary>
        /// 詳細ウィンドウ。
        /// </summary>
        public UsercontrolDetailWindow UcDetailWindow
        {
            get
            {
                return this.ucDetailWindow;
            }
        }

        //────────────────────────────────────────

        public UsercontrolCanvas UcCanvas
        {
            get
            {
                return this.ucCanvas;
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
        #endregion



    }
}
