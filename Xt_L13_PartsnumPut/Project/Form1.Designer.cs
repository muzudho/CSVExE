namespace Xenon.PartsnumPut
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_BgOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.編集モードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.番号配置モードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.番号レイヤー引越しモードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.説明書ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.説明書ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucGraphList1 = new Xenon.PartsnumPut.UsercontrolListfile();
            this.usercontrolCanvas1 = new Xenon.PartsnumPut.UsercontrolCanvas();
            this.表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.詳細ウィンドウToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集モードToolStripMenuItem,
            this.説明書ToolStripMenuItem,
            this.表示ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_BgOpen,
            this.toolStripSeparator,
            this.toolStripMenuItem_Save});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // toolStripMenuItem_BgOpen
            // 
            this.toolStripMenuItem_BgOpen.Name = "toolStripMenuItem_BgOpen";
            this.toolStripMenuItem_BgOpen.Size = new System.Drawing.Size(316, 22);
            this.toolStripMenuItem_BgOpen.Text = "背景画像（.png）、表（.csv）のいずれかを開く";
            this.toolStripMenuItem_BgOpen.Click += new System.EventHandler(this.toolStripMenuItem_Open_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(313, 6);
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(316, 22);
            this.toolStripMenuItem_Save.Text = "PNG、CSV保存";
            this.toolStripMenuItem_Save.Click += new System.EventHandler(this.pNGCSV保存ToolStripMenuItem_Click);
            // 
            // 編集モードToolStripMenuItem
            // 
            this.編集モードToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.番号配置モードToolStripMenuItem,
            this.番号レイヤー引越しモードToolStripMenuItem});
            this.編集モードToolStripMenuItem.Name = "編集モードToolStripMenuItem";
            this.編集モードToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.編集モードToolStripMenuItem.Text = "編集モード";
            // 
            // 番号配置モードToolStripMenuItem
            // 
            this.番号配置モードToolStripMenuItem.Name = "番号配置モードToolStripMenuItem";
            this.番号配置モードToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.番号配置モードToolStripMenuItem.Text = "基本モード";
            this.番号配置モードToolStripMenuItem.Click += new System.EventHandler(this.番号配置モードToolStripMenuItem_Click);
            // 
            // 番号レイヤー引越しモードToolStripMenuItem
            // 
            this.番号レイヤー引越しモードToolStripMenuItem.Name = "番号レイヤー引越しモードToolStripMenuItem";
            this.番号レイヤー引越しモードToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.番号レイヤー引越しモードToolStripMenuItem.Text = "番号レイヤー引越しモード";
            this.番号レイヤー引越しモードToolStripMenuItem.Click += new System.EventHandler(this.番号レイヤー引越しモードToolStripMenuItem_Click);
            // 
            // 説明書ToolStripMenuItem
            // 
            this.説明書ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.説明書ToolStripMenuItem1});
            this.説明書ToolStripMenuItem.Name = "説明書ToolStripMenuItem";
            this.説明書ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.説明書ToolStripMenuItem.Text = "説明書";
            // 
            // 説明書ToolStripMenuItem1
            // 
            this.説明書ToolStripMenuItem1.Name = "説明書ToolStripMenuItem1";
            this.説明書ToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.説明書ToolStripMenuItem1.Text = "説明書";
            this.説明書ToolStripMenuItem1.Click += new System.EventHandler(this.説明書ToolStripMenuItem1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucGraphList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usercontrolCanvas1);
            this.splitContainer1.Size = new System.Drawing.Size(692, 504);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 9;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // ucGraphList1
            // 
            this.ucGraphList1.Location = new System.Drawing.Point(0, 0);
            this.ucGraphList1.Name = "ucGraphList1";
            this.ucGraphList1.Size = new System.Drawing.Size(184, 224);
            this.ucGraphList1.TabIndex = 0;
            // 
            // usercontrolCanvas1
            // 
            this.usercontrolCanvas1.Location = new System.Drawing.Point(0, 0);
            this.usercontrolCanvas1.Name = "usercontrolCanvas1";
            this.usercontrolCanvas1.Owner_MemoryApplication = null;
            this.usercontrolCanvas1.PclstNums_autoInput = false;
            this.usercontrolCanvas1.PctxtEdits_autoInput = false;
            this.usercontrolCanvas1.Size = new System.Drawing.Size(256, 236);
            this.usercontrolCanvas1.TabIndex = 7;
            this.usercontrolCanvas1.Load += new System.EventHandler(this.ucCanvas_Load);
            // 
            // 表示ToolStripMenuItem
            // 
            this.表示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.詳細ウィンドウToolStripMenuItem});
            this.表示ToolStripMenuItem.Name = "表示ToolStripMenuItem";
            this.表示ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.表示ToolStripMenuItem.Text = "表示";
            // 
            // 詳細ウィンドウToolStripMenuItem
            // 
            this.詳細ウィンドウToolStripMenuItem.Name = "詳細ウィンドウToolStripMenuItem";
            this.詳細ウィンドウToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.詳細ウィンドウToolStripMenuItem.Text = "詳細ウィンドウ";
            this.詳細ウィンドウToolStripMenuItem.Click += new System.EventHandler(this.詳細ウィンドウToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 556);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UsercontrolCanvas usercontrolCanvas1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_BgOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UsercontrolListfile ucGraphList1;
        private System.Windows.Forms.ToolStripMenuItem 説明書ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 説明書ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 編集モードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 番号配置モードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 番号レイヤー引越しモードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 詳細ウィンドウToolStripMenuItem;
    }
}

