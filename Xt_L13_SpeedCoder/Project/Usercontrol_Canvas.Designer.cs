namespace Xenon.SpeedCoder
{
    partial class Usercontrol_Canvas
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonBrBreak = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrCombine = new System.Windows.Forms.Button();
            this.buttonClipboardcopy = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 156);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(614, 254);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            // 
            // buttonBrBreak
            // 
            this.buttonBrBreak.Location = new System.Drawing.Point(33, 417);
            this.buttonBrBreak.Name = "buttonBrBreak";
            this.buttonBrBreak.Size = new System.Drawing.Size(40, 23);
            this.buttonBrBreak.TabIndex = 1;
            this.buttonBrBreak.Text = "折る";
            this.buttonBrBreak.UseVisualStyleBackColor = true;
            this.buttonBrBreak.Click += new System.EventHandler(this.buttonBrBreak_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "&&br;";
            // 
            // buttonBrCombine
            // 
            this.buttonBrCombine.Location = new System.Drawing.Point(79, 417);
            this.buttonBrCombine.Name = "buttonBrCombine";
            this.buttonBrCombine.Size = new System.Drawing.Size(41, 23);
            this.buttonBrCombine.TabIndex = 3;
            this.buttonBrCombine.Text = "結ぶ";
            this.buttonBrCombine.UseVisualStyleBackColor = true;
            this.buttonBrCombine.Click += new System.EventHandler(this.buttonBrCombine_Click);
            // 
            // buttonClipboardcopy
            // 
            this.buttonClipboardcopy.Location = new System.Drawing.Point(240, 416);
            this.buttonClipboardcopy.Name = "buttonClipboardcopy";
            this.buttonClipboardcopy.Size = new System.Drawing.Size(115, 23);
            this.buttonClipboardcopy.TabIndex = 4;
            this.buttonClipboardcopy.Text = "クリップボードにコピー";
            this.buttonClipboardcopy.UseVisualStyleBackColor = true;
            this.buttonClipboardcopy.Click += new System.EventHandler(this.buttonClipboardcopy_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(458, 417);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(54, 23);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "クリアー";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Usercontrol_Canvas
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonClipboardcopy);
            this.Controls.Add(this.buttonBrCombine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBrBreak);
            this.Controls.Add(this.textBox1);
            this.Name = "Usercontrol_Canvas";
            this.Size = new System.Drawing.Size(620, 440);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Usercontrol_Canvas_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Usercontrol_Canvas_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Usercontrol_Canvas_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonBrBreak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrCombine;
        private System.Windows.Forms.Button buttonClipboardcopy;
        private System.Windows.Forms.Button buttonClear;
    }
}
