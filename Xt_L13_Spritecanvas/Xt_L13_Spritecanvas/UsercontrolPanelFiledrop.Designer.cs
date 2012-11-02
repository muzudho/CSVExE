namespace Xt_L13_Spritecanvas
{
    partial class UsercontrolPanelFiledrop
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
            this.SuspendLayout();
            // 
            // UsercontrolPanelFiledrop
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UsercontrolPanelFiledrop";
            this.Size = new System.Drawing.Size(303, 281);
            this.Load += new System.EventHandler(this.UsercontrolPanelFiledrop_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UsercontrolPanelFiledrop_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UsercontrolPanelFiledrop_DragEnter);
            this.DragLeave += new System.EventHandler(this.UsercontrolPanelFiledrop_DragLeave);
            this.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.UsercontrolPanelFiledrop_GiveFeedback);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UsercontrolPanelFiledrop_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
