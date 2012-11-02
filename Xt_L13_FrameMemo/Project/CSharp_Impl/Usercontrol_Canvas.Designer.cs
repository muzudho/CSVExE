namespace Xenon.FrameMemo
{
    partial class Usercontrol_Canvas
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
            this.pclblMouseDrag = new System.Windows.Forms.Label();
            this.pclblAlScale = new System.Windows.Forms.Label();
            this.pcddlAlScale = new System.Windows.Forms.ComboBox();
            this.pcdlgOpenBgFile = new System.Windows.Forms.OpenFileDialog();
            this.pclblBgclr = new System.Windows.Forms.Label();
            this.pcddlBgclr = new System.Windows.Forms.ComboBox();
            this.pclblGrid1 = new System.Windows.Forms.Label();
            this.pclblOpaque = new System.Windows.Forms.Label();
            this.pcddlOpaque = new System.Windows.Forms.ComboBox();
            this.pclstMouseDrag = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pclblInfo1 = new System.Windows.Forms.Label();
            this.pcchkInfoVisibled = new System.Windows.Forms.CheckBox();
            this.pcchkGridVisibled = new System.Windows.Forms.CheckBox();
            this.pcddlGridColor = new System.Windows.Forms.ComboBox();
            this.pclblPartnumber1 = new System.Windows.Forms.Label();
            this.pcddlPartnumberOpaque = new System.Windows.Forms.ComboBox();
            this.pclblPartnumber2 = new System.Windows.Forms.Label();
            this.pcchkPartnumberVisible = new System.Windows.Forms.CheckBox();
            this.pcddlPartnumberColor = new System.Windows.Forms.ComboBox();
            this.pclblPartnumber3 = new System.Windows.Forms.Label();
            this.pctxtPartnumberFirst = new System.Windows.Forms.TextBox();
            this.pcbtnSaveImgFrames = new Xenon.FrameMemo.CustomcontrolButtonEx();
            this.ucFrameParam = new Xenon.FrameMemo.Usercontrol_FrameParam();
            this.pcbtnSaveImg = new Xenon.FrameMemo.CustomcontrolButtonEx();
            this.pcbtnOpen = new Xenon.FrameMemo.CustomcontrolButtonEx();
            this.SuspendLayout();
            // 
            // pclblMouseDrag
            // 
            this.pclblMouseDrag.AutoSize = true;
            this.pclblMouseDrag.Enabled = false;
            this.pclblMouseDrag.Location = new System.Drawing.Point(65, 16);
            this.pclblMouseDrag.Name = "pclblMouseDrag";
            this.pclblMouseDrag.Size = new System.Drawing.Size(65, 12);
            this.pclblMouseDrag.TabIndex = 4;
            this.pclblMouseDrag.Text = "マウスドラッグ";
            // 
            // pclblAlScale
            // 
            this.pclblAlScale.AutoSize = true;
            this.pclblAlScale.Enabled = false;
            this.pclblAlScale.Location = new System.Drawing.Point(221, 16);
            this.pclblAlScale.Name = "pclblAlScale";
            this.pclblAlScale.Size = new System.Drawing.Size(41, 12);
            this.pclblAlScale.TabIndex = 6;
            this.pclblAlScale.Text = "拡大率";
            // 
            // pcddlAlScale
            // 
            this.pcddlAlScale.Enabled = false;
            this.pcddlAlScale.FormattingEnabled = true;
            this.pcddlAlScale.Location = new System.Drawing.Point(268, 13);
            this.pcddlAlScale.Name = "pcddlAlScale";
            this.pcddlAlScale.Size = new System.Drawing.Size(48, 20);
            this.pcddlAlScale.TabIndex = 7;
            this.pcddlAlScale.SelectedIndexChanged += new System.EventHandler(this.pcddlScale_SelectedIndexChanged);
            // 
            // pcdlgOpenBgFile
            // 
            this.pcdlgOpenBgFile.FileName = "openFileDialog1";
            // 
            // pclblBgclr
            // 
            this.pclblBgclr.AutoSize = true;
            this.pclblBgclr.Enabled = false;
            this.pclblBgclr.Location = new System.Drawing.Point(343, 6);
            this.pclblBgclr.Name = "pclblBgclr";
            this.pclblBgclr.Size = new System.Drawing.Size(41, 12);
            this.pclblBgclr.TabIndex = 8;
            this.pclblBgclr.Text = "背景色";
            // 
            // pcddlBgclr
            // 
            this.pcddlBgclr.Enabled = false;
            this.pcddlBgclr.FormattingEnabled = true;
            this.pcddlBgclr.Location = new System.Drawing.Point(460, 3);
            this.pcddlBgclr.Name = "pcddlBgclr";
            this.pcddlBgclr.Size = new System.Drawing.Size(56, 20);
            this.pcddlBgclr.TabIndex = 9;
            this.pcddlBgclr.SelectedIndexChanged += new System.EventHandler(this.pcddlOpaque_SelectedIndexChanged);
            // 
            // pclblGrid1
            // 
            this.pclblGrid1.AutoSize = true;
            this.pclblGrid1.Enabled = false;
            this.pclblGrid1.Location = new System.Drawing.Point(570, 8);
            this.pclblGrid1.Name = "pclblGrid1";
            this.pclblGrid1.Size = new System.Drawing.Size(17, 12);
            this.pclblGrid1.TabIndex = 10;
            this.pclblGrid1.Text = "枠";
            // 
            // pclblOpaque
            // 
            this.pclblOpaque.AutoSize = true;
            this.pclblOpaque.Enabled = false;
            this.pclblOpaque.Location = new System.Drawing.Point(343, 25);
            this.pclblOpaque.Name = "pclblOpaque";
            this.pclblOpaque.Size = new System.Drawing.Size(87, 12);
            this.pclblOpaque.TabIndex = 13;
            this.pclblOpaque.Text = "画像の不透明度";
            // 
            // pcddlOpaque
            // 
            this.pcddlOpaque.Enabled = false;
            this.pcddlOpaque.FormattingEnabled = true;
            this.pcddlOpaque.Location = new System.Drawing.Point(460, 22);
            this.pcddlOpaque.Name = "pcddlOpaque";
            this.pcddlOpaque.Size = new System.Drawing.Size(56, 20);
            this.pcddlOpaque.TabIndex = 14;
            this.pcddlOpaque.SelectedIndexChanged += new System.EventHandler(this.pcddlOpaqueBg_SelectedIndexChanged);
            // 
            // pclstMouseDrag
            // 
            this.pclstMouseDrag.Enabled = false;
            this.pclstMouseDrag.FormattingEnabled = true;
            this.pclstMouseDrag.ItemHeight = 12;
            this.pclstMouseDrag.Location = new System.Drawing.Point(136, 8);
            this.pclstMouseDrag.Name = "pclstMouseDrag";
            this.pclstMouseDrag.Size = new System.Drawing.Size(60, 28);
            this.pclstMouseDrag.TabIndex = 15;
            this.pclstMouseDrag.SelectedIndexChanged += new System.EventHandler(this.pclstMouseDrag_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "キーボードのカーソルキー（↑→↓←）の利きがおかしくなった場合は、フォームの何も無いところをクリックしてください。";
            // 
            // pclblInfo1
            // 
            this.pclblInfo1.AutoSize = true;
            this.pclblInfo1.Enabled = false;
            this.pclblInfo1.Location = new System.Drawing.Point(522, 28);
            this.pclblInfo1.Name = "pclblInfo1";
            this.pclblInfo1.Size = new System.Drawing.Size(65, 12);
            this.pclblInfo1.TabIndex = 25;
            this.pclblInfo1.Text = "情報表示中";
            // 
            // pcchkInfoVisibled
            // 
            this.pcchkInfoVisibled.AutoSize = true;
            this.pcchkInfoVisibled.Checked = true;
            this.pcchkInfoVisibled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pcchkInfoVisibled.Enabled = false;
            this.pcchkInfoVisibled.Location = new System.Drawing.Point(593, 28);
            this.pcchkInfoVisibled.Name = "pcchkInfoVisibled";
            this.pcchkInfoVisibled.Size = new System.Drawing.Size(15, 14);
            this.pcchkInfoVisibled.TabIndex = 26;
            this.pcchkInfoVisibled.UseVisualStyleBackColor = true;
            this.pcchkInfoVisibled.CheckedChanged += new System.EventHandler(this.pcchkInfo_CheckedChanged);
            // 
            // pcchkGridVisibled
            // 
            this.pcchkGridVisibled.AutoSize = true;
            this.pcchkGridVisibled.Enabled = false;
            this.pcchkGridVisibled.Location = new System.Drawing.Point(593, 7);
            this.pcchkGridVisibled.Name = "pcchkGridVisibled";
            this.pcchkGridVisibled.Size = new System.Drawing.Size(15, 14);
            this.pcchkGridVisibled.TabIndex = 31;
            this.pcchkGridVisibled.UseVisualStyleBackColor = true;
            this.pcchkGridVisibled.CheckedChanged += new System.EventHandler(this.pcchkImgBorder_CheckedChanged);
            // 
            // pcddlGridColor
            // 
            this.pcddlGridColor.Enabled = false;
            this.pcddlGridColor.FormattingEnabled = true;
            this.pcddlGridColor.Location = new System.Drawing.Point(614, 4);
            this.pcddlGridColor.Name = "pcddlGridColor";
            this.pcddlGridColor.Size = new System.Drawing.Size(56, 20);
            this.pcddlGridColor.TabIndex = 32;
            this.pcddlGridColor.SelectedIndexChanged += new System.EventHandler(this.pcddlGridcolor_SelectedIndexChanged);
            // 
            // pclblPartnumber1
            // 
            this.pclblPartnumber1.AutoSize = true;
            this.pclblPartnumber1.Enabled = false;
            this.pclblPartnumber1.Location = new System.Drawing.Point(343, 45);
            this.pclblPartnumber1.Name = "pclblPartnumber1";
            this.pclblPartnumber1.Size = new System.Drawing.Size(111, 12);
            this.pclblPartnumber1.TabIndex = 35;
            this.pclblPartnumber1.Text = "部品番号の不透明度";
            // 
            // pcddlPartnumberOpaque
            // 
            this.pcddlPartnumberOpaque.Enabled = false;
            this.pcddlPartnumberOpaque.FormattingEnabled = true;
            this.pcddlPartnumberOpaque.Location = new System.Drawing.Point(460, 42);
            this.pcddlPartnumberOpaque.Name = "pcddlPartnumberOpaque";
            this.pcddlPartnumberOpaque.Size = new System.Drawing.Size(56, 20);
            this.pcddlPartnumberOpaque.TabIndex = 36;
            this.pcddlPartnumberOpaque.SelectedIndexChanged += new System.EventHandler(this.pcddlPartnumberOpaque_SelectedIndexChanged);
            // 
            // pclblPartnumber2
            // 
            this.pclblPartnumber2.AutoSize = true;
            this.pclblPartnumber2.Enabled = false;
            this.pclblPartnumber2.Location = new System.Drawing.Point(546, 46);
            this.pclblPartnumber2.Name = "pclblPartnumber2";
            this.pclblPartnumber2.Size = new System.Drawing.Size(41, 12);
            this.pclblPartnumber2.TabIndex = 37;
            this.pclblPartnumber2.Text = "表示中";
            // 
            // pcchkPartnumberVisible
            // 
            this.pcchkPartnumberVisible.AutoSize = true;
            this.pcchkPartnumberVisible.Checked = true;
            this.pcchkPartnumberVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pcchkPartnumberVisible.Enabled = false;
            this.pcchkPartnumberVisible.Location = new System.Drawing.Point(593, 45);
            this.pcchkPartnumberVisible.Name = "pcchkPartnumberVisible";
            this.pcchkPartnumberVisible.Size = new System.Drawing.Size(15, 14);
            this.pcchkPartnumberVisible.TabIndex = 38;
            this.pcchkPartnumberVisible.UseVisualStyleBackColor = true;
            this.pcchkPartnumberVisible.CheckedChanged += new System.EventHandler(this.pcchkPartnumberVisible_CheckedChanged);
            // 
            // pcddlPartnumberColor
            // 
            this.pcddlPartnumberColor.Enabled = false;
            this.pcddlPartnumberColor.FormattingEnabled = true;
            this.pcddlPartnumberColor.Location = new System.Drawing.Point(614, 42);
            this.pcddlPartnumberColor.Name = "pcddlPartnumberColor";
            this.pcddlPartnumberColor.Size = new System.Drawing.Size(55, 20);
            this.pcddlPartnumberColor.TabIndex = 39;
            this.pcddlPartnumberColor.SelectedIndexChanged += new System.EventHandler(this.pcddlPartnumberColor_SelectedIndexChanged);
            // 
            // pclblPartnumber3
            // 
            this.pclblPartnumber3.AutoSize = true;
            this.pclblPartnumber3.Enabled = false;
            this.pclblPartnumber3.Location = new System.Drawing.Point(675, 46);
            this.pclblPartnumber3.Name = "pclblPartnumber3";
            this.pclblPartnumber3.Size = new System.Drawing.Size(53, 12);
            this.pclblPartnumber3.TabIndex = 40;
            this.pclblPartnumber3.Text = "開始番号";
            // 
            // pctxtPartnumberFirst
            // 
            this.pctxtPartnumberFirst.Enabled = false;
            this.pctxtPartnumberFirst.Location = new System.Drawing.Point(734, 43);
            this.pctxtPartnumberFirst.Name = "pctxtPartnumberFirst";
            this.pctxtPartnumberFirst.Size = new System.Drawing.Size(37, 19);
            this.pctxtPartnumberFirst.TabIndex = 41;
            this.pctxtPartnumberFirst.TextChanged += new System.EventHandler(this.pctxtPartnumberFirst_TextChanged);
            // 
            // pcbtnSaveImgFrames
            // 
            this.pcbtnSaveImgFrames.Enabled = false;
            this.pcbtnSaveImgFrames.Location = new System.Drawing.Point(651, 120);
            this.pcbtnSaveImgFrames.Name = "pcbtnSaveImgFrames";
            this.pcbtnSaveImgFrames.Size = new System.Drawing.Size(120, 24);
            this.pcbtnSaveImgFrames.TabIndex = 34;
            this.pcbtnSaveImgFrames.Text = "フレーム全画像を保存";
            this.pcbtnSaveImgFrames.UseVisualStyleBackColor = true;
            this.pcbtnSaveImgFrames.Click += new System.EventHandler(this.ccButtonEx1_Click);
            // 
            // ucFrameParam
            // 
            this.ucFrameParam.Location = new System.Drawing.Point(112, 65);
            this.ucFrameParam.MemorySprite = null;
            this.ucFrameParam.Name = "ucFrameParam";
            this.ucFrameParam.Size = new System.Drawing.Size(576, 36);
            this.ucFrameParam.TabIndex = 30;
            // 
            // pcbtnSaveImg
            // 
            this.pcbtnSaveImg.Enabled = false;
            this.pcbtnSaveImg.Location = new System.Drawing.Point(696, 100);
            this.pcbtnSaveImg.Name = "pcbtnSaveImg";
            this.pcbtnSaveImg.Size = new System.Drawing.Size(75, 23);
            this.pcbtnSaveImg.TabIndex = 12;
            this.pcbtnSaveImg.Text = "画像を保存";
            this.pcbtnSaveImg.UseVisualStyleBackColor = true;
            this.pcbtnSaveImg.Click += new System.EventHandler(this.pcbtnSaveImg_Click);
            // 
            // pcbtnOpen
            // 
            this.pcbtnOpen.Location = new System.Drawing.Point(10, 74);
            this.pcbtnOpen.Name = "pcbtnOpen";
            this.pcbtnOpen.Size = new System.Drawing.Size(96, 23);
            this.pcbtnOpen.TabIndex = 1;
            this.pcbtnOpen.Text = "画像開く";
            this.pcbtnOpen.UseVisualStyleBackColor = true;
            this.pcbtnOpen.Click += new System.EventHandler(this.pcbtnBg_Click);
            // 
            // Usercontrol_Canvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pctxtPartnumberFirst);
            this.Controls.Add(this.pclblPartnumber3);
            this.Controls.Add(this.pcddlPartnumberColor);
            this.Controls.Add(this.pcchkPartnumberVisible);
            this.Controls.Add(this.pclblPartnumber2);
            this.Controls.Add(this.pcddlPartnumberOpaque);
            this.Controls.Add(this.pclblPartnumber1);
            this.Controls.Add(this.pcbtnSaveImgFrames);
            this.Controls.Add(this.pcddlGridColor);
            this.Controls.Add(this.pcchkGridVisibled);
            this.Controls.Add(this.ucFrameParam);
            this.Controls.Add(this.pcchkInfoVisibled);
            this.Controls.Add(this.pclblInfo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pclstMouseDrag);
            this.Controls.Add(this.pcddlOpaque);
            this.Controls.Add(this.pclblOpaque);
            this.Controls.Add(this.pcbtnSaveImg);
            this.Controls.Add(this.pclblGrid1);
            this.Controls.Add(this.pcddlBgclr);
            this.Controls.Add(this.pclblBgclr);
            this.Controls.Add(this.pcddlAlScale);
            this.Controls.Add(this.pclblAlScale);
            this.Controls.Add(this.pclblMouseDrag);
            this.Controls.Add(this.pcbtnOpen);
            this.DoubleBuffered = true;
            this.Name = "Usercontrol_Canvas";
            this.Size = new System.Drawing.Size(781, 509);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pclblMouseDrag;
        private System.Windows.Forms.Label pclblAlScale;
        private System.Windows.Forms.ComboBox pcddlAlScale;
        private System.Windows.Forms.OpenFileDialog pcdlgOpenBgFile;
        private System.Windows.Forms.Label pclblBgclr;
        private System.Windows.Forms.ComboBox pcddlBgclr;
        private System.Windows.Forms.Label pclblGrid1;
        private System.Windows.Forms.Label pclblOpaque;
        private System.Windows.Forms.ComboBox pcddlOpaque;
        private System.Windows.Forms.ListBox pclstMouseDrag;
        private CustomcontrolButtonEx pcbtnOpen;
        private CustomcontrolButtonEx pcbtnSaveImg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pclblInfo1;
        private System.Windows.Forms.CheckBox pcchkInfoVisibled;
        private Usercontrol_FrameParam ucFrameParam;
        private System.Windows.Forms.CheckBox pcchkGridVisibled;
        private System.Windows.Forms.ComboBox pcddlGridColor;
        private CustomcontrolButtonEx pcbtnSaveImgFrames;
        private System.Windows.Forms.Label pclblPartnumber1;
        private System.Windows.Forms.ComboBox pcddlPartnumberOpaque;
        private System.Windows.Forms.Label pclblPartnumber2;
        private System.Windows.Forms.CheckBox pcchkPartnumberVisible;
        private System.Windows.Forms.ComboBox pcddlPartnumberColor;
        private System.Windows.Forms.Label pclblPartnumber3;
        private System.Windows.Forms.TextBox pctxtPartnumberFirst;
    }
}
