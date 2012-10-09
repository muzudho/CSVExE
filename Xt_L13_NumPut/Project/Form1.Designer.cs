namespace Xenon.NumPut
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
            //Xenon.NumPut.Mo02ProjectImpl mo02ProjectImpl2 = new Xenon.NumPut.Mo02ProjectImpl();
            Xenon.NumPut.Memory3ContentsImpl mo03ContentsImpl2 = new Xenon.NumPut.Memory3ContentsImpl();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_BgOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.説明書ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.説明書ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucGraphList1 = new Xenon.NumPut.UsercontrolGraphList();
            this.ucCanvas = new Xenon.NumPut.UsercontrolCanvas();
            this.編集モードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.番号配置モードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.番号レイヤー引越しモードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.説明書ToolStripMenuItem});
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
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // toolStripMenuItem_BgOpen
            // 
            this.toolStripMenuItem_BgOpen.Name = "toolStripMenuItem_BgOpen";
            this.toolStripMenuItem_BgOpen.Size = new System.Drawing.Size(280, 22);
            this.toolStripMenuItem_BgOpen.Text = "背景画像（.png）、表（.csv）のいずれかを開く";
            this.toolStripMenuItem_BgOpen.Click += new System.EventHandler(this.toolStripMenuItem_Open_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(277, 6);
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(280, 22);
            this.toolStripMenuItem_Save.Text = "PNG、CSV保存";
            this.toolStripMenuItem_Save.Click += new System.EventHandler(this.pNGCSV保存ToolStripMenuItem_Click);
            // 
            // 説明書ToolStripMenuItem
            // 
            this.説明書ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.説明書ToolStripMenuItem1});
            this.説明書ToolStripMenuItem.Name = "説明書ToolStripMenuItem";
            this.説明書ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.説明書ToolStripMenuItem.Text = "説明書";
            // 
            // 説明書ToolStripMenuItem1
            // 
            this.説明書ToolStripMenuItem1.Name = "説明書ToolStripMenuItem1";
            this.説明書ToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
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
            this.splitContainer1.Panel2.Controls.Add(this.ucCanvas);
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
            // ucCanvas
            // 
            this.ucCanvas.Location = new System.Drawing.Point(0, 0);
            mo03ContentsImpl2.BChangedContents = false;
            mo03ContentsImpl2.BCtrlKey = false;
            mo03ContentsImpl2.BDisplayExecute = false;
            mo03ContentsImpl2.BgLocationScaled = ((System.Drawing.PointF)(resources.GetObject("mo03ContentsImpl2.BgLocationScaled")));
            mo03ContentsImpl2.BgOpaque = 0.5F;
            mo03ContentsImpl2.Bitmap_Bg = null;
            mo03ContentsImpl2.BShiftKey = false;
            mo03ContentsImpl2.CreatesCount = 1;
            mo03ContentsImpl2.LayerDic = ((System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<Xenon.NumPut.MemoryNum>>)(resources.GetObject("mo03ContentsImpl2.LayerDic")));
            mo03ContentsImpl2.MouseDownLocation = ((System.Drawing.PointF)(resources.GetObject("mo03ContentsImpl2.MouseDownLocation")));
            mo03ContentsImpl2.MouseDragging = false;
            mo03ContentsImpl2.MouseDraggingNone = false;
            mo03ContentsImpl2.MouseTargetNum = null;
            mo03ContentsImpl2.NSelectedLayer = 0;
            mo03ContentsImpl2.PreDragLocation = ((System.Drawing.PointF)(resources.GetObject("mo03ContentsImpl2.PreDragLocation")));
            mo03ContentsImpl2.PreScale = 1F;
            mo03ContentsImpl2.ScaleImg = 1F;
            mo03ContentsImpl2.SelectedMoSprite = null;
            mo03ContentsImpl2.SFpath_BgPng = "";
            mo03ContentsImpl2.SFpath_Csv = "";
            //mo02ProjectImpl2.MoContents = mo03ContentsImpl2;
            //this.ucCanvas.MoProject = mo02ProjectImpl2;
            this.ucCanvas.Name = "ucCanvas";
            this.ucCanvas.PclstNums_autoInput = false;
            this.ucCanvas.PctxtEdits_autoInput = false;
            this.ucCanvas.Size = new System.Drawing.Size(256, 236);
            this.ucCanvas.TabIndex = 7;
            this.ucCanvas.Load += new System.EventHandler(this.ucCanvas_Load);
            // 
            // 編集モードToolStripMenuItem
            // 
            this.編集モードToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.番号配置モードToolStripMenuItem,
            this.番号レイヤー引越しモードToolStripMenuItem});
            this.編集モードToolStripMenuItem.Name = "編集モードToolStripMenuItem";
            this.編集モードToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.編集モードToolStripMenuItem.Text = "編集モード";
            // 
            // 番号配置モードToolStripMenuItem
            // 
            this.番号配置モードToolStripMenuItem.Name = "番号配置モードToolStripMenuItem";
            this.番号配置モードToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.番号配置モードToolStripMenuItem.Text = "基本モード";
            this.番号配置モードToolStripMenuItem.Click += new System.EventHandler(this.番号配置モードToolStripMenuItem_Click);
            // 
            // 番号レイヤー引越しモードToolStripMenuItem
            // 
            this.番号レイヤー引越しモードToolStripMenuItem.Name = "番号レイヤー引越しモードToolStripMenuItem";
            this.番号レイヤー引越しモードToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.番号レイヤー引越しモードToolStripMenuItem.Text = "番号レイヤー引越しモード";
            this.番号レイヤー引越しモードToolStripMenuItem.Click += new System.EventHandler(this.番号レイヤー引越しモードToolStripMenuItem_Click);
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
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UsercontrolCanvas ucCanvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_BgOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UsercontrolGraphList ucGraphList1;
        private System.Windows.Forms.ToolStripMenuItem 説明書ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 説明書ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 編集モードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 番号配置モードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 番号レイヤー引越しモードToolStripMenuItem;
    }
}

