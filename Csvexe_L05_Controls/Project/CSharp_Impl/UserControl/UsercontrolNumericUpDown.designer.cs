namespace Xenon.Controls
{
    partial class UsercontrolNumericUpDown
    {
        /// <summary> 
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param nFcName="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.SuspendLayout();
            // 
            // UcNumericUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UcNumericUpDown";
            this.Size = new System.Drawing.Size(120, 19);
            this.Load += new System.EventHandler(this.UsercontrolNumericUpDown_Load);
            this.MouseLeave += new System.EventHandler(this.UsercontrolNumericUpDown_MouseLeave);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UsercontrolNumericUpDown_Paint);
            this.Click += new System.EventHandler(this.UsercontrolNumericUpDown_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UsercontrolNumericUpDown_MouseMove);
            this.Leave += new System.EventHandler(this.UsercontrolNumericUpDown_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UsercontrolNumericUpDown_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UsercontrolNumericUpDown_MouseUp);
            this.SizeChanged += new System.EventHandler(this.UsercontrolNumericUpDown_SizeChanged);
            this.MouseEnter += new System.EventHandler(this.UsercontrolNumericUpDown_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
