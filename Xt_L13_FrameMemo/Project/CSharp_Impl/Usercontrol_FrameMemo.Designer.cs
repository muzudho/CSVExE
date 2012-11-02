namespace Xenon.FrameMemo
{
    partial class Usercontrol_FrameMemo
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
            this.pclblImgBorder = new System.Windows.Forms.Label();
            this.pclblOpaque = new System.Windows.Forms.Label();
            this.pcddlOpaque = new System.Windows.Forms.ComboBox();
            this.pclstMouseDrag = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pclblInfo = new System.Windows.Forms.Label();
            this.pcchkInfo = new System.Windows.Forms.CheckBox();
            this.pcchkImgBorder = new System.Windows.Forms.CheckBox();
            this.pcddlGridcolor = new System.Windows.Forms.ComboBox();
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
            this.pclblMouseDrag.Location = new System.Drawing.Point(112, 16);
            this.pclblMouseDrag.Name = "pclblMouseDrag";
            this.pclblMouseDrag.Size = new System.Drawing.Size(65, 12);
            this.pclblMouseDrag.TabIndex = 4;
            this.pclblMouseDrag.Text = "マウスドラッグ";
            // 
            // pclblAlScale
            // 
            this.pclblAlScale.AutoSize = true;
            this.pclblAlScale.Enabled = false;
            this.pclblAlScale.Location = new System.Drawing.Point(256, 16);
            this.pclblAlScale.Name = "pclblAlScale";
            this.pclblAlScale.Size = new System.Drawing.Size(41, 12);
            this.pclblAlScale.TabIndex = 6;
            this.pclblAlScale.Text = "拡大率";
            // 
            // pcddlAlScale
            // 
            this.pcddlAlScale.Enabled = false;
            this.pcddlAlScale.FormattingEnabled = true;
            this.pcddlAlScale.Location = new System.Drawing.Point(304, 12);
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
            this.pclblBgclr.Location = new System.Drawing.Point(448, 8);
            this.pclblBgclr.Name = "pclblBgclr";
            this.pclblBgclr.Size = new System.Drawing.Size(41, 12);
            this.pclblBgclr.TabIndex = 8;
            this.pclblBgclr.Text = "背景色";
            // 
            // pcddlBgclr
            // 
            this.pcddlBgclr.Enabled = false;
            this.pcddlBgclr.FormattingEnabled = true;
            this.pcddlBgclr.Location = new System.Drawing.Point(540, 4);
            this.pcddlBgclr.Name = "pcddlBgclr";
            this.pcddlBgclr.Size = new System.Drawing.Size(56, 20);
            this.pcddlBgclr.TabIndex = 9;
            this.pcddlBgclr.SelectedIndexChanged += new System.EventHandler(this.pcddlOpaque_SelectedIndexChanged);
            // 
            // pclblImgBorder
            // 
            this.pclblImgBorder.AutoSize = true;
            this.pclblImgBorder.Enabled = false;
            this.pclblImgBorder.Location = new System.Drawing.Point(656, 8);
            this.pclblImgBorder.Name = "pclblImgBorder";
            this.pclblImgBorder.Size = new System.Drawing.Size(17, 12);
            this.pclblImgBorder.TabIndex = 10;
            this.pclblImgBorder.Text = "枠";
            // 
            // pclblOpaque
            // 
            this.pclblOpaque.AutoSize = true;
            this.pclblOpaque.Enabled = false;
            this.pclblOpaque.Location = new System.Drawing.Point(448, 28);
            this.pclblOpaque.Name = "pclblOpaque";
            this.pclblOpaque.Size = new System.Drawing.Size(87, 12);
            this.pclblOpaque.TabIndex = 13;
            this.pclblOpaque.Text = "画像の不透明度";
            // 
            // pcddlOpaque
            // 
            this.pcddlOpaque.Enabled = false;
            this.pcddlOpaque.FormattingEnabled = true;
            this.pcddlOpaque.Location = new System.Drawing.Point(540, 24);
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
            this.pclstMouseDrag.Location = new System.Drawing.Point(184, 4);
            this.pclstMouseDrag.Name = "pclstMouseDrag";
            this.pclstMouseDrag.Size = new System.Drawing.Size(60, 28);
            this.pclstMouseDrag.TabIndex = 15;
            this.pclstMouseDrag.SelectedIndexChanged += new System.EventHandler(this.pclstMouseDrag_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "キーボードのカーソルキー（↑→↓←）の利きがおかしくなった場合は、フォームの何も無いところをクリックしてください。";
            // 
            // pclblInfo
            // 
            this.pclblInfo.AutoSize = true;
            this.pclblInfo.Enabled = false;
            this.pclblInfo.Location = new System.Drawing.Point(608, 28);
            this.pclblInfo.Name = "pclblInfo";
            this.pclblInfo.Size = new System.Drawing.Size(65, 12);
            this.pclblInfo.TabIndex = 25;
            this.pclblInfo.Text = "情報表示中";
            // 
            // pcchkInfo
            // 
            this.pcchkInfo.AutoSize = true;
            this.pcchkInfo.Checked = true;
            this.pcchkInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pcchkInfo.Enabled = false;
            this.pcchkInfo.Location = new System.Drawing.Point(680, 28);
            this.pcchkInfo.Name = "pcchkInfo";
            this.pcchkInfo.Size = new System.Drawing.Size(15, 14);
            this.pcchkInfo.TabIndex = 26;
            this.pcchkInfo.UseVisualStyleBackColor = true;
            this.pcchkInfo.CheckedChanged += new System.EventHandler(this.pcchkInfo_CheckedChanged);
            // 
            // pcchkImgBorder
            // 
            this.pcchkImgBorder.AutoSize = true;
            this.pcchkImgBorder.Enabled = false;
            this.pcchkImgBorder.Location = new System.Drawing.Point(680, 8);
            this.pcchkImgBorder.Name = "pcchkImgBorder";
            this.pcchkImgBorder.Size = new System.Drawing.Size(15, 14);
            this.pcchkImgBorder.TabIndex = 31;
            this.pcchkImgBorder.UseVisualStyleBackColor = true;
            this.pcchkImgBorder.CheckedChanged += new System.EventHandler(this.pcchkImgBorder_CheckedChanged);
            // 
            // pcddlGridcolor
            // 
            this.pcddlGridcolor.FormattingEnabled = true;
            this.pcddlGridcolor.Location = new System.Drawing.Point(700, 4);
            this.pcddlGridcolor.Name = "pcddlGridcolor";
            this.pcddlGridcolor.Size = new System.Drawing.Size(56, 20);
            this.pcddlGridcolor.TabIndex = 32;
            this.pcddlGridcolor.SelectedIndexChanged += new System.EventHandler(this.pcddlGridcolor_SelectedIndexChanged);
            // 
            // pcbtnSaveImgFrames
            // 
            this.pcbtnSaveImgFrames.Enabled = false;
            this.pcbtnSaveImgFrames.Location = new System.Drawing.Point(652, 100);
            this.pcbtnSaveImgFrames.Name = "pcbtnSaveImgFrames";
            this.pcbtnSaveImgFrames.Size = new System.Drawing.Size(120, 24);
            this.pcbtnSaveImgFrames.TabIndex = 34;
            this.pcbtnSaveImgFrames.Text = "フレーム全画像を保存";
            this.pcbtnSaveImgFrames.UseVisualStyleBackColor = true;
            this.pcbtnSaveImgFrames.Click += new System.EventHandler(this.ccButtonEx1_Click);
            // 
            // ucFrameParam
            // 
            this.ucFrameParam.Location = new System.Drawing.Point(112, 44);
            this.ucFrameParam.MemorySprite = null;
            this.ucFrameParam.Name = "ucFrameParam";
            this.ucFrameParam.Size = new System.Drawing.Size(576, 36);
            this.ucFrameParam.TabIndex = 30;
            // 
            // pcbtnSaveImg
            // 
            this.pcbtnSaveImg.Enabled = false;
            this.pcbtnSaveImg.Location = new System.Drawing.Point(696, 76);
            this.pcbtnSaveImg.Name = "pcbtnSaveImg";
            this.pcbtnSaveImg.Size = new System.Drawing.Size(75, 23);
            this.pcbtnSaveImg.TabIndex = 12;
            this.pcbtnSaveImg.Text = "画像を保存";
            this.pcbtnSaveImg.UseVisualStyleBackColor = true;
            this.pcbtnSaveImg.Click += new System.EventHandler(this.pcbtnSaveImg_Click);
            // 
            // pcbtnOpen
            // 
            this.pcbtnOpen.Location = new System.Drawing.Point(16, 44);
            this.pcbtnOpen.Name = "pcbtnOpen";
            this.pcbtnOpen.Size = new System.Drawing.Size(96, 23);
            this.pcbtnOpen.TabIndex = 1;
            this.pcbtnOpen.Text = "画像開く";
            this.pcbtnOpen.UseVisualStyleBackColor = true;
            this.pcbtnOpen.Click += new System.EventHandler(this.pcbtnBg_Click);
            // 
            // Uc_FrameMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcbtnSaveImgFrames);
            this.Controls.Add(this.pcddlGridcolor);
            this.Controls.Add(this.pcchkImgBorder);
            this.Controls.Add(this.ucFrameParam);
            this.Controls.Add(this.pcchkInfo);
            this.Controls.Add(this.pclblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pclstMouseDrag);
            this.Controls.Add(this.pcddlOpaque);
            this.Controls.Add(this.pclblOpaque);
            this.Controls.Add(this.pcbtnSaveImg);
            this.Controls.Add(this.pclblImgBorder);
            this.Controls.Add(this.pcddlBgclr);
            this.Controls.Add(this.pclblBgclr);
            this.Controls.Add(this.pcddlAlScale);
            this.Controls.Add(this.pclblAlScale);
            this.Controls.Add(this.pclblMouseDrag);
            this.Controls.Add(this.pcbtnOpen);
            this.DoubleBuffered = true;
            this.Name = "Uc_FrameMemo";
            this.Size = new System.Drawing.Size(781, 509);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrameMemoUc_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrameMemoUc_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrameMemoUc_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrameMemoUc_MouseUp);
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
        private System.Windows.Forms.Label pclblImgBorder;
        private System.Windows.Forms.Label pclblOpaque;
        private System.Windows.Forms.ComboBox pcddlOpaque;
        private System.Windows.Forms.ListBox pclstMouseDrag;
        private CustomcontrolButtonEx pcbtnOpen;
        private CustomcontrolButtonEx pcbtnSaveImg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pclblInfo;
        private System.Windows.Forms.CheckBox pcchkInfo;
        private Usercontrol_FrameParam ucFrameParam;
        private System.Windows.Forms.CheckBox pcchkImgBorder;
        private System.Windows.Forms.ComboBox pcddlGridcolor;
        private CustomcontrolButtonEx pcbtnSaveImgFrames;
    }
}
