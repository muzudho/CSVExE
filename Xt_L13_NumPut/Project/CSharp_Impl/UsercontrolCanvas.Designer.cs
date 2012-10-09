namespace Xenon.NumPut
{
    partial class UsercontrolCanvas
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pclblAlScale = new System.Windows.Forms.Label();
            this.pcddlAlScale = new System.Windows.Forms.ComboBox();
            this.pcdlgOpenBg = new System.Windows.Forms.OpenFileDialog();
            this.pclblBgOpaque = new System.Windows.Forms.Label();
            this.pcddlBgOpaque = new System.Windows.Forms.ComboBox();
            this.pclstNums = new System.Windows.Forms.ListBox();
            this.ccbtnRemoves = new System.Windows.Forms.Button();
            this.pctxtEdits = new System.Windows.Forms.TextBox();
            this.pcrdiFontSmall = new System.Windows.Forms.RadioButton();
            this.pcrdiFontMiddle = new System.Windows.Forms.RadioButton();
            this.pclblFontSmall = new System.Windows.Forms.Label();
            this.pclblFontMiddle = new System.Windows.Forms.Label();
            this.pcrdiBgcolorBlue = new System.Windows.Forms.RadioButton();
            this.pclblBgcolorBlue = new System.Windows.Forms.Label();
            this.pcrdiBgcolorGreen = new System.Windows.Forms.RadioButton();
            this.pclblBgcolorGreen = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pclblFontLarge = new System.Windows.Forms.Label();
            this.pcrdiFontLarge = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcrdiDisplay1 = new System.Windows.Forms.RadioButton();
            this.pcrdiDisplay2 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pcbtnLayerAdd = new System.Windows.Forms.Button();
            this.pclstLayer = new System.Windows.Forms.ListBox();
            this.ccbtnAdds = new Xenon.NumPut.CustomcontrolButtonEx();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pclblAlScale
            // 
            this.pclblAlScale.AutoSize = true;
            this.pclblAlScale.Enabled = false;
            this.pclblAlScale.Location = new System.Drawing.Point(148, 24);
            this.pclblAlScale.Name = "pclblAlScale";
            this.pclblAlScale.Size = new System.Drawing.Size(41, 12);
            this.pclblAlScale.TabIndex = 6;
            this.pclblAlScale.Text = "拡大率";
            // 
            // pcddlAlScale
            // 
            this.pcddlAlScale.Enabled = false;
            this.pcddlAlScale.FormattingEnabled = true;
            this.pcddlAlScale.Location = new System.Drawing.Point(196, 20);
            this.pcddlAlScale.Name = "pcddlAlScale";
            this.pcddlAlScale.Size = new System.Drawing.Size(48, 20);
            this.pcddlAlScale.TabIndex = 7;
            this.pcddlAlScale.SelectedIndexChanged += new System.EventHandler(this.pcddlScale_SelectedIndexChanged);
            // 
            // pclblBgOpaque
            // 
            this.pclblBgOpaque.AutoSize = true;
            this.pclblBgOpaque.Enabled = false;
            this.pclblBgOpaque.Location = new System.Drawing.Point(268, 24);
            this.pclblBgOpaque.Name = "pclblBgOpaque";
            this.pclblBgOpaque.Size = new System.Drawing.Size(111, 12);
            this.pclblBgOpaque.TabIndex = 13;
            this.pclblBgOpaque.Text = "背景画像の不透明度";
            // 
            // pcddlBgOpaque
            // 
            this.pcddlBgOpaque.Enabled = false;
            this.pcddlBgOpaque.FormattingEnabled = true;
            this.pcddlBgOpaque.Location = new System.Drawing.Point(384, 20);
            this.pcddlBgOpaque.Name = "pcddlBgOpaque";
            this.pcddlBgOpaque.Size = new System.Drawing.Size(68, 20);
            this.pcddlBgOpaque.TabIndex = 14;
            this.pcddlBgOpaque.SelectedIndexChanged += new System.EventHandler(this.pcddlOpaqueBg_SelectedIndexChanged);
            // 
            // pclstNums
            // 
            this.pclstNums.FormattingEnabled = true;
            this.pclstNums.ItemHeight = 12;
            this.pclstNums.Location = new System.Drawing.Point(12, 216);
            this.pclstNums.Name = "pclstNums";
            this.pclstNums.Size = new System.Drawing.Size(96, 244);
            this.pclstNums.TabIndex = 17;
            this.pclstNums.SelectedIndexChanged += new System.EventHandler(this.pclstNums_SelectedIndexChanged);
            // 
            // ccbtnRemoves
            // 
            this.ccbtnRemoves.Enabled = false;
            this.ccbtnRemoves.Location = new System.Drawing.Point(12, 500);
            this.ccbtnRemoves.Name = "ccbtnRemoves";
            this.ccbtnRemoves.Size = new System.Drawing.Size(96, 23);
            this.ccbtnRemoves.TabIndex = 19;
            this.ccbtnRemoves.Text = "選択項目削除";
            this.ccbtnRemoves.UseVisualStyleBackColor = true;
            this.ccbtnRemoves.Click += new System.EventHandler(this.ccbtnRemoves_Click);
            // 
            // pctxtEdits
            // 
            this.pctxtEdits.Enabled = false;
            this.pctxtEdits.Location = new System.Drawing.Point(12, 196);
            this.pctxtEdits.Name = "pctxtEdits";
            this.pctxtEdits.Size = new System.Drawing.Size(96, 19);
            this.pctxtEdits.TabIndex = 20;
            this.pctxtEdits.TextChanged += new System.EventHandler(this.pctxtEdits_TextChanged);
            this.pctxtEdits.Leave += new System.EventHandler(this.pctxtEdits_Leave);
            // 
            // pcrdiFontSmall
            // 
            this.pcrdiFontSmall.AutoSize = true;
            this.pcrdiFontSmall.Enabled = false;
            this.pcrdiFontSmall.Location = new System.Drawing.Point(8, 16);
            this.pcrdiFontSmall.Name = "pcrdiFontSmall";
            this.pcrdiFontSmall.Size = new System.Drawing.Size(14, 13);
            this.pcrdiFontSmall.TabIndex = 22;
            this.pcrdiFontSmall.TabStop = true;
            this.pcrdiFontSmall.UseVisualStyleBackColor = true;
            this.pcrdiFontSmall.CheckedChanged += new System.EventHandler(this.pcrdiFontSmall_CheckedChanged);
            // 
            // pcrdiFontMiddle
            // 
            this.pcrdiFontMiddle.AutoSize = true;
            this.pcrdiFontMiddle.Enabled = false;
            this.pcrdiFontMiddle.Location = new System.Drawing.Point(24, 16);
            this.pcrdiFontMiddle.Name = "pcrdiFontMiddle";
            this.pcrdiFontMiddle.Size = new System.Drawing.Size(14, 13);
            this.pcrdiFontMiddle.TabIndex = 23;
            this.pcrdiFontMiddle.TabStop = true;
            this.pcrdiFontMiddle.UseVisualStyleBackColor = true;
            this.pcrdiFontMiddle.CheckedChanged += new System.EventHandler(this.pcrdiFontMiddle_CheckedChanged);
            // 
            // pclblFontSmall
            // 
            this.pclblFontSmall.AutoSize = true;
            this.pclblFontSmall.Enabled = false;
            this.pclblFontSmall.Location = new System.Drawing.Point(8, 4);
            this.pclblFontSmall.Name = "pclblFontSmall";
            this.pclblFontSmall.Size = new System.Drawing.Size(17, 12);
            this.pclblFontSmall.TabIndex = 24;
            this.pclblFontSmall.Text = "小";
            // 
            // pclblFontMiddle
            // 
            this.pclblFontMiddle.AutoSize = true;
            this.pclblFontMiddle.Enabled = false;
            this.pclblFontMiddle.Location = new System.Drawing.Point(24, 4);
            this.pclblFontMiddle.Name = "pclblFontMiddle";
            this.pclblFontMiddle.Size = new System.Drawing.Size(17, 12);
            this.pclblFontMiddle.TabIndex = 25;
            this.pclblFontMiddle.Text = "中";
            // 
            // pcrdiBgcolorBlue
            // 
            this.pcrdiBgcolorBlue.AutoSize = true;
            this.pcrdiBgcolorBlue.Enabled = false;
            this.pcrdiBgcolorBlue.Location = new System.Drawing.Point(8, 16);
            this.pcrdiBgcolorBlue.Name = "pcrdiBgcolorBlue";
            this.pcrdiBgcolorBlue.Size = new System.Drawing.Size(14, 13);
            this.pcrdiBgcolorBlue.TabIndex = 26;
            this.pcrdiBgcolorBlue.TabStop = true;
            this.pcrdiBgcolorBlue.UseVisualStyleBackColor = true;
            this.pcrdiBgcolorBlue.CheckedChanged += new System.EventHandler(this.pcrdiBgcolorBlue_CheckedChanged);
            // 
            // pclblBgcolorBlue
            // 
            this.pclblBgcolorBlue.AutoSize = true;
            this.pclblBgcolorBlue.Enabled = false;
            this.pclblBgcolorBlue.Location = new System.Drawing.Point(8, 4);
            this.pclblBgcolorBlue.Name = "pclblBgcolorBlue";
            this.pclblBgcolorBlue.Size = new System.Drawing.Size(17, 12);
            this.pclblBgcolorBlue.TabIndex = 27;
            this.pclblBgcolorBlue.Text = "青";
            // 
            // pcrdiBgcolorGreen
            // 
            this.pcrdiBgcolorGreen.AutoSize = true;
            this.pcrdiBgcolorGreen.Enabled = false;
            this.pcrdiBgcolorGreen.Location = new System.Drawing.Point(24, 16);
            this.pcrdiBgcolorGreen.Name = "pcrdiBgcolorGreen";
            this.pcrdiBgcolorGreen.Size = new System.Drawing.Size(14, 13);
            this.pcrdiBgcolorGreen.TabIndex = 28;
            this.pcrdiBgcolorGreen.TabStop = true;
            this.pcrdiBgcolorGreen.UseVisualStyleBackColor = true;
            this.pcrdiBgcolorGreen.CheckedChanged += new System.EventHandler(this.pcrdiBgcolorGreen_CheckedChanged);
            // 
            // pclblBgcolorGreen
            // 
            this.pclblBgcolorGreen.AutoSize = true;
            this.pclblBgcolorGreen.Enabled = false;
            this.pclblBgcolorGreen.Location = new System.Drawing.Point(24, 4);
            this.pclblBgcolorGreen.Name = "pclblBgcolorGreen";
            this.pclblBgcolorGreen.Size = new System.Drawing.Size(17, 12);
            this.pclblBgcolorGreen.TabIndex = 29;
            this.pclblBgcolorGreen.Text = "緑";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pclblFontLarge);
            this.panel1.Controls.Add(this.pcrdiFontLarge);
            this.panel1.Controls.Add(this.pclblFontSmall);
            this.panel1.Controls.Add(this.pcrdiFontSmall);
            this.panel1.Controls.Add(this.pclblFontMiddle);
            this.panel1.Controls.Add(this.pcrdiFontMiddle);
            this.panel1.Location = new System.Drawing.Point(0, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 32);
            this.panel1.TabIndex = 30;
            // 
            // pclblFontLarge
            // 
            this.pclblFontLarge.AutoSize = true;
            this.pclblFontLarge.Enabled = false;
            this.pclblFontLarge.Location = new System.Drawing.Point(40, 4);
            this.pclblFontLarge.Name = "pclblFontLarge";
            this.pclblFontLarge.Size = new System.Drawing.Size(17, 12);
            this.pclblFontLarge.TabIndex = 27;
            this.pclblFontLarge.Text = "大";
            // 
            // pcrdiFontLarge
            // 
            this.pcrdiFontLarge.AutoSize = true;
            this.pcrdiFontLarge.Enabled = false;
            this.pcrdiFontLarge.Location = new System.Drawing.Point(40, 16);
            this.pcrdiFontLarge.Name = "pcrdiFontLarge";
            this.pcrdiFontLarge.Size = new System.Drawing.Size(14, 13);
            this.pcrdiFontLarge.TabIndex = 26;
            this.pcrdiFontLarge.TabStop = true;
            this.pcrdiFontLarge.UseVisualStyleBackColor = true;
            this.pcrdiFontLarge.CheckedChanged += new System.EventHandler(this.pcrdiFontLarge_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pclblBgcolorBlue);
            this.panel2.Controls.Add(this.pcrdiBgcolorBlue);
            this.panel2.Controls.Add(this.pcrdiBgcolorGreen);
            this.panel2.Controls.Add(this.pclblBgcolorGreen);
            this.panel2.Location = new System.Drawing.Point(76, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(48, 32);
            this.panel2.TabIndex = 31;
            // 
            // pcrdiDisplay1
            // 
            this.pcrdiDisplay1.AutoSize = true;
            this.pcrdiDisplay1.Checked = true;
            this.pcrdiDisplay1.Location = new System.Drawing.Point(4, 4);
            this.pcrdiDisplay1.Name = "pcrdiDisplay1";
            this.pcrdiDisplay1.Size = new System.Drawing.Size(84, 16);
            this.pcrdiDisplay1.TabIndex = 32;
            this.pcrdiDisplay1.TabStop = true;
            this.pcrdiDisplay1.Text = "そのまま表示";
            this.pcrdiDisplay1.UseVisualStyleBackColor = true;
            this.pcrdiDisplay1.CheckedChanged += new System.EventHandler(this.pcrdiDisplay1_CheckedChanged);
            // 
            // pcrdiDisplay2
            // 
            this.pcrdiDisplay2.AutoSize = true;
            this.pcrdiDisplay2.Location = new System.Drawing.Point(4, 20);
            this.pcrdiDisplay2.Name = "pcrdiDisplay2";
            this.pcrdiDisplay2.Size = new System.Drawing.Size(71, 16);
            this.pcrdiDisplay2.TabIndex = 33;
            this.pcrdiDisplay2.Text = "加算表示";
            this.pcrdiDisplay2.UseVisualStyleBackColor = true;
            this.pcrdiDisplay2.CheckedChanged += new System.EventHandler(this.pcrdiDisplay2_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pcrdiDisplay1);
            this.panel3.Controls.Add(this.pcrdiDisplay2);
            this.panel3.Location = new System.Drawing.Point(12, 460);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(92, 40);
            this.panel3.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "キーボードのカーソルキー（↑→↓←）の利きがおかしくなった場合は、フォームの何も無いところをクリックしてください。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "レイヤー";
            // 
            // pcbtnLayerAdd
            // 
            this.pcbtnLayerAdd.Location = new System.Drawing.Point(68, 20);
            this.pcbtnLayerAdd.Name = "pcbtnLayerAdd";
            this.pcbtnLayerAdd.Size = new System.Drawing.Size(40, 23);
            this.pcbtnLayerAdd.TabIndex = 38;
            this.pcbtnLayerAdd.Text = "追加";
            this.pcbtnLayerAdd.UseVisualStyleBackColor = true;
            this.pcbtnLayerAdd.Click += new System.EventHandler(this.pcbtnLayerAdd_Click);
            // 
            // pclstLayer
            // 
            this.pclstLayer.FormattingEnabled = true;
            this.pclstLayer.ItemHeight = 12;
            this.pclstLayer.Location = new System.Drawing.Point(4, 44);
            this.pclstLayer.Name = "pclstLayer";
            this.pclstLayer.Size = new System.Drawing.Size(104, 88);
            this.pclstLayer.TabIndex = 39;
            this.pclstLayer.SelectedIndexChanged += new System.EventHandler(this.pclstLayer_SelectedIndexChanged);
            // 
            // ccbtnAdds
            // 
            this.ccbtnAdds.Location = new System.Drawing.Point(12, 172);
            this.ccbtnAdds.Name = "ccbtnAdds";
            this.ccbtnAdds.Size = new System.Drawing.Size(96, 23);
            this.ccbtnAdds.TabIndex = 18;
            this.ccbtnAdds.Text = "新規追加";
            this.ccbtnAdds.UseVisualStyleBackColor = true;
            this.ccbtnAdds.Click += new System.EventHandler(this.ccbtnAdds_Click);
            // 
            // UcCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pclstLayer);
            this.Controls.Add(this.pcbtnLayerAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pctxtEdits);
            this.Controls.Add(this.ccbtnRemoves);
            this.Controls.Add(this.ccbtnAdds);
            this.Controls.Add(this.pclstNums);
            this.Controls.Add(this.pcddlBgOpaque);
            this.Controls.Add(this.pclblBgOpaque);
            this.Controls.Add(this.pcddlAlScale);
            this.Controls.Add(this.pclblAlScale);
            this.DoubleBuffered = true;
            this.Name = "UcCanvas";
            this.Size = new System.Drawing.Size(796, 530);
            this.Load += new System.EventHandler(this.UcCanvas_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UcCanvas_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UcCanvas_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UcCanvas_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UcCanvas_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pclblAlScale;
        private System.Windows.Forms.ComboBox pcddlAlScale;
        private System.Windows.Forms.OpenFileDialog pcdlgOpenBg;
        private System.Windows.Forms.Label pclblBgOpaque;
        private System.Windows.Forms.ComboBox pcddlBgOpaque;
        private System.Windows.Forms.ListBox pclstNums;
        private CustomcontrolButtonEx ccbtnAdds;
        private System.Windows.Forms.Button ccbtnRemoves;
        private System.Windows.Forms.TextBox pctxtEdits;
        private System.Windows.Forms.RadioButton pcrdiFontSmall;
        private System.Windows.Forms.RadioButton pcrdiFontMiddle;
        private System.Windows.Forms.Label pclblFontSmall;
        private System.Windows.Forms.Label pclblFontMiddle;
        private System.Windows.Forms.RadioButton pcrdiBgcolorBlue;
        private System.Windows.Forms.Label pclblBgcolorBlue;
        private System.Windows.Forms.RadioButton pcrdiBgcolorGreen;
        private System.Windows.Forms.Label pclblBgcolorGreen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label pclblFontLarge;
        private System.Windows.Forms.RadioButton pcrdiFontLarge;
        private System.Windows.Forms.RadioButton pcrdiDisplay1;
        private System.Windows.Forms.RadioButton pcrdiDisplay2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button pcbtnLayerAdd;
        private System.Windows.Forms.ListBox pclstLayer;
    }
}
