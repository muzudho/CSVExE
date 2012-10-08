namespace Xenon.XyMemo
{
    partial class Usercontrol_XyMemo
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
            this.pcdlgOpenSpriteFile = new System.Windows.Forms.OpenFileDialog();
            this.pclblSpOpaque = new System.Windows.Forms.Label();
            this.pcddlSpOpaque = new System.Windows.Forms.ComboBox();
            this.pclblSpBorder = new System.Windows.Forms.Label();
            this.pclblBgOpaque = new System.Windows.Forms.Label();
            this.pcddlBgOpaque = new System.Windows.Forms.ComboBox();
            this.pclstMouseDrag = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbtnSpClr = new System.Windows.Forms.Button();
            this.pclblSpCross = new System.Windows.Forms.Label();
            this.pcchkSpCross = new System.Windows.Forms.CheckBox();
            this.pcchkSpBorder = new System.Windows.Forms.CheckBox();
            this.pcddlGridcolor = new System.Windows.Forms.ComboBox();
            this.ucSpriteParam = new Xenon.XyMemo.Usercontrol_SpriteParam();
            this.pcbtnSaveImg = new Xenon.XyMemo.CustomcontrolButtonEx();
            this.pcbtnSp = new Xenon.XyMemo.CustomcontrolButtonEx();
            this.pcbtnBg = new Xenon.XyMemo.CustomcontrolButtonEx();
            this.SuspendLayout();
            // 
            // pclblMouseDrag
            // 
            this.pclblMouseDrag.AutoSize = true;
            this.pclblMouseDrag.Enabled = false;
            this.pclblMouseDrag.Location = new System.Drawing.Point(136, 16);
            this.pclblMouseDrag.Name = "pclblMouseDrag";
            this.pclblMouseDrag.Size = new System.Drawing.Size(65, 12);
            this.pclblMouseDrag.TabIndex = 4;
            this.pclblMouseDrag.Text = "マウスドラッグ";
            // 
            // pclblAlScale
            // 
            this.pclblAlScale.AutoSize = true;
            this.pclblAlScale.Enabled = false;
            this.pclblAlScale.Location = new System.Drawing.Point(308, 28);
            this.pclblAlScale.Name = "pclblAlScale";
            this.pclblAlScale.Size = new System.Drawing.Size(41, 12);
            this.pclblAlScale.TabIndex = 6;
            this.pclblAlScale.Text = "拡大率";
            // 
            // pcddlAlScale
            // 
            this.pcddlAlScale.Enabled = false;
            this.pcddlAlScale.FormattingEnabled = true;
            this.pcddlAlScale.Location = new System.Drawing.Point(356, 24);
            this.pcddlAlScale.Name = "pcddlAlScale";
            this.pcddlAlScale.Size = new System.Drawing.Size(48, 20);
            this.pcddlAlScale.TabIndex = 7;
            this.pcddlAlScale.SelectedIndexChanged += new System.EventHandler(this.pcddlScale_SelectedIndexChanged);
            // 
            // pcdlgOpenBgFile
            // 
            this.pcdlgOpenBgFile.FileName = "openFileDialog1";
            // 
            // pcdlgOpenSpriteFile
            // 
            this.pcdlgOpenSpriteFile.FileName = "openFileDialog1";
            // 
            // pclblSpOpaque
            // 
            this.pclblSpOpaque.AutoSize = true;
            this.pclblSpOpaque.Enabled = false;
            this.pclblSpOpaque.Location = new System.Drawing.Point(468, 28);
            this.pclblSpOpaque.Name = "pclblSpOpaque";
            this.pclblSpOpaque.Size = new System.Drawing.Size(118, 12);
            this.pclblSpOpaque.TabIndex = 8;
            this.pclblSpOpaque.Text = "乗せる画像の不透明度";
            // 
            // pcddlSpOpaque
            // 
            this.pcddlSpOpaque.Enabled = false;
            this.pcddlSpOpaque.FormattingEnabled = true;
            this.pcddlSpOpaque.Location = new System.Drawing.Point(592, 24);
            this.pcddlSpOpaque.Name = "pcddlSpOpaque";
            this.pcddlSpOpaque.Size = new System.Drawing.Size(68, 20);
            this.pcddlSpOpaque.TabIndex = 9;
            this.pcddlSpOpaque.SelectedIndexChanged += new System.EventHandler(this.pcddlOpaque_SelectedIndexChanged);
            // 
            // pclblSpBorder
            // 
            this.pclblSpBorder.AutoSize = true;
            this.pclblSpBorder.Enabled = false;
            this.pclblSpBorder.Location = new System.Drawing.Point(668, 28);
            this.pclblSpBorder.Name = "pclblSpBorder";
            this.pclblSpBorder.Size = new System.Drawing.Size(17, 12);
            this.pclblSpBorder.TabIndex = 10;
            this.pclblSpBorder.Text = "枠";
            // 
            // pclblBgOpaque
            // 
            this.pclblBgOpaque.AutoSize = true;
            this.pclblBgOpaque.Enabled = false;
            this.pclblBgOpaque.Location = new System.Drawing.Point(468, 8);
            this.pclblBgOpaque.Name = "pclblBgOpaque";
            this.pclblBgOpaque.Size = new System.Drawing.Size(111, 12);
            this.pclblBgOpaque.TabIndex = 13;
            this.pclblBgOpaque.Text = "背景画像の不透明度";
            // 
            // pcddlBgOpaque
            // 
            this.pcddlBgOpaque.Enabled = false;
            this.pcddlBgOpaque.FormattingEnabled = true;
            this.pcddlBgOpaque.Location = new System.Drawing.Point(592, 4);
            this.pcddlBgOpaque.Name = "pcddlBgOpaque";
            this.pcddlBgOpaque.Size = new System.Drawing.Size(68, 20);
            this.pcddlBgOpaque.TabIndex = 14;
            this.pcddlBgOpaque.SelectedIndexChanged += new System.EventHandler(this.pcddlOpaqueBg_SelectedIndexChanged);
            // 
            // pclstMouseDrag
            // 
            this.pclstMouseDrag.Enabled = false;
            this.pclstMouseDrag.FormattingEnabled = true;
            this.pclstMouseDrag.ItemHeight = 12;
            this.pclstMouseDrag.Location = new System.Drawing.Point(208, 4);
            this.pclstMouseDrag.Name = "pclstMouseDrag";
            this.pclstMouseDrag.Size = new System.Drawing.Size(88, 40);
            this.pclstMouseDrag.TabIndex = 15;
            this.pclstMouseDrag.SelectedIndexChanged += new System.EventHandler(this.pclstMouseDrag_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "キーボードのカーソルキー（↑→↓←）の利きがおかしくなった場合は、フォームの何も無いところをクリックしてください。";
            // 
            // pcbtnSpClr
            // 
            this.pcbtnSpClr.Enabled = false;
            this.pcbtnSpClr.Location = new System.Drawing.Point(92, 52);
            this.pcbtnSpClr.Name = "pcbtnSpClr";
            this.pcbtnSpClr.Size = new System.Drawing.Size(40, 23);
            this.pcbtnSpClr.TabIndex = 29;
            this.pcbtnSpClr.Text = "クリア";
            this.pcbtnSpClr.UseVisualStyleBackColor = true;
            this.pcbtnSpClr.Click += new System.EventHandler(this.pcbtnSpClr_Click);
            // 
            // pclblSpCross
            // 
            this.pclblSpCross.AutoSize = true;
            this.pclblSpCross.Enabled = false;
            this.pclblSpCross.Location = new System.Drawing.Point(668, 8);
            this.pclblSpCross.Name = "pclblSpCross";
            this.pclblSpCross.Size = new System.Drawing.Size(29, 12);
            this.pclblSpCross.TabIndex = 30;
            this.pclblSpCross.Text = "十字";
            // 
            // pcchkSpCross
            // 
            this.pcchkSpCross.AutoSize = true;
            this.pcchkSpCross.Enabled = false;
            this.pcchkSpCross.Location = new System.Drawing.Point(700, 8);
            this.pcchkSpCross.Name = "pcchkSpCross";
            this.pcchkSpCross.Size = new System.Drawing.Size(15, 14);
            this.pcchkSpCross.TabIndex = 31;
            this.pcchkSpCross.UseVisualStyleBackColor = true;
            this.pcchkSpCross.CheckedChanged += new System.EventHandler(this.pcchkCross_CheckedChanged);
            // 
            // pcchkSpBorder
            // 
            this.pcchkSpBorder.AutoSize = true;
            this.pcchkSpBorder.Enabled = false;
            this.pcchkSpBorder.Location = new System.Drawing.Point(700, 28);
            this.pcchkSpBorder.Name = "pcchkSpBorder";
            this.pcchkSpBorder.Size = new System.Drawing.Size(15, 14);
            this.pcchkSpBorder.TabIndex = 32;
            this.pcchkSpBorder.UseVisualStyleBackColor = true;
            this.pcchkSpBorder.CheckedChanged += new System.EventHandler(this.pcchkSpBorder_CheckedChanged);
            // 
            // pcddlGridcolor
            // 
            this.pcddlGridcolor.FormattingEnabled = true;
            this.pcddlGridcolor.Location = new System.Drawing.Point(720, 4);
            this.pcddlGridcolor.Name = "pcddlGridcolor";
            this.pcddlGridcolor.Size = new System.Drawing.Size(56, 20);
            this.pcddlGridcolor.TabIndex = 34;
            this.pcddlGridcolor.SelectedIndexChanged += new System.EventHandler(this.pcddlBordercolor_SelectedIndexChanged);
            // 
            // ucSpriteParam
            // 
            this.ucSpriteParam.Location = new System.Drawing.Point(136, 52);
            this.ucSpriteParam.MoSprite = null;
            this.ucSpriteParam.MoSpriteCanvas = null;
            this.ucSpriteParam.Name = "ucSpriteParam";
            this.ucSpriteParam.Size = new System.Drawing.Size(496, 34);
            this.ucSpriteParam.TabIndex = 33;
            // 
            // pcbtnSaveImg
            // 
            this.pcbtnSaveImg.Enabled = false;
            this.pcbtnSaveImg.Location = new System.Drawing.Point(696, 52);
            this.pcbtnSaveImg.Name = "pcbtnSaveImg";
            this.pcbtnSaveImg.Size = new System.Drawing.Size(75, 23);
            this.pcbtnSaveImg.TabIndex = 12;
            this.pcbtnSaveImg.Text = "画像を保存";
            this.pcbtnSaveImg.UseVisualStyleBackColor = true;
            this.pcbtnSaveImg.Click += new System.EventHandler(this.pcbtnSaveImg_Click);
            // 
            // pcbtnSp
            // 
            this.pcbtnSp.Enabled = false;
            this.pcbtnSp.Location = new System.Drawing.Point(4, 52);
            this.pcbtnSp.Name = "pcbtnSp";
            this.pcbtnSp.Size = new System.Drawing.Size(88, 23);
            this.pcbtnSp.TabIndex = 2;
            this.pcbtnSp.Text = "乗せる画像開く";
            this.pcbtnSp.UseVisualStyleBackColor = true;
            this.pcbtnSp.Click += new System.EventHandler(this.pcbtnSp_Click);
            // 
            // pcbtnBg
            // 
            this.pcbtnBg.Location = new System.Drawing.Point(4, 24);
            this.pcbtnBg.Name = "pcbtnBg";
            this.pcbtnBg.Size = new System.Drawing.Size(88, 23);
            this.pcbtnBg.TabIndex = 1;
            this.pcbtnBg.Text = "背景画像開く";
            this.pcbtnBg.UseVisualStyleBackColor = true;
            this.pcbtnBg.Click += new System.EventHandler(this.pcbtnBg_Click);
            // 
            // Uc_XyMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcddlGridcolor);
            this.Controls.Add(this.ucSpriteParam);
            this.Controls.Add(this.pcchkSpBorder);
            this.Controls.Add(this.pcchkSpCross);
            this.Controls.Add(this.pclblSpCross);
            this.Controls.Add(this.pcbtnSpClr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pclstMouseDrag);
            this.Controls.Add(this.pcddlBgOpaque);
            this.Controls.Add(this.pclblBgOpaque);
            this.Controls.Add(this.pcbtnSaveImg);
            this.Controls.Add(this.pclblSpBorder);
            this.Controls.Add(this.pcddlSpOpaque);
            this.Controls.Add(this.pclblSpOpaque);
            this.Controls.Add(this.pcddlAlScale);
            this.Controls.Add(this.pclblAlScale);
            this.Controls.Add(this.pclblMouseDrag);
            this.Controls.Add(this.pcbtnSp);
            this.Controls.Add(this.pcbtnBg);
            this.DoubleBuffered = true;
            this.Name = "Uc_XyMemo";
            this.Size = new System.Drawing.Size(781, 509);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.XyMemoUc_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.XyMemoUc_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XyMemoUc_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XyMemoUc_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pclblMouseDrag;
        private System.Windows.Forms.Label pclblAlScale;
        private System.Windows.Forms.ComboBox pcddlAlScale;
        private System.Windows.Forms.OpenFileDialog pcdlgOpenBgFile;
        private System.Windows.Forms.OpenFileDialog pcdlgOpenSpriteFile;
        private System.Windows.Forms.Label pclblSpOpaque;
        private System.Windows.Forms.ComboBox pcddlSpOpaque;
        private System.Windows.Forms.Label pclblSpBorder;
        private System.Windows.Forms.Label pclblBgOpaque;
        private System.Windows.Forms.ComboBox pcddlBgOpaque;
        private System.Windows.Forms.ListBox pclstMouseDrag;
        private CustomcontrolButtonEx pcbtnBg;
        private CustomcontrolButtonEx pcbtnSp;
        private CustomcontrolButtonEx pcbtnSaveImg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pcbtnSpClr;
        private System.Windows.Forms.Label pclblSpCross;
        private System.Windows.Forms.CheckBox pcchkSpCross;
        private System.Windows.Forms.CheckBox pcchkSpBorder;
        private Usercontrol_SpriteParam ucSpriteParam;
        private System.Windows.Forms.ComboBox pcddlGridcolor;
    }
}
