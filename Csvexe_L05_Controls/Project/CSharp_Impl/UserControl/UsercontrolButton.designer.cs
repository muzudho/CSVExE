namespace Xenon.Controls
{
    partial class UsercontrolButton
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
            // UcButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UcButton";
            this.Size = new System.Drawing.Size(100, 19);
            this.Load += new System.EventHandler(this.UctTextbox_Load);
            this.MouseLeave += new System.EventHandler(this.UsercontrolButton_MouseLeave);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UsercontrolButton_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UsercontrolButton_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UsercontrolButton_MouseDown);
            this.SizeChanged += new System.EventHandler(this.UsercontrolButton_SizeChanged);
            this.MouseEnter += new System.EventHandler(this.UsercontrolButton_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
