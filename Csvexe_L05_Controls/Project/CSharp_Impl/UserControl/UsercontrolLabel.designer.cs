namespace Xenon.Controls
{
    partial class UsercontrolLabel
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
            // UcLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcLabel";
            this.Size = new System.Drawing.Size(100, 19);
            this.Load += new System.EventHandler(this.UsercontrolLabel_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UsercontrolLabel_Paint);
            this.SizeChanged += new System.EventHandler(this.UsercontrolLabel_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
