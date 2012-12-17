namespace Xt_L13_XenonEditor
{
    partial class Control_Workbench
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
            this.control_Textarea1 = new Xt_L13_XenonEditor.Control_Textarea();
            this.SuspendLayout();
            // 
            // control_Textarea1
            // 
            this.control_Textarea1.Location = new System.Drawing.Point(36, 45);
            this.control_Textarea1.Name = "control_Textarea1";
            this.control_Textarea1.Size = new System.Drawing.Size(150, 150);
            this.control_Textarea1.TabIndex = 0;
            // 
            // Control_Workbench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.Controls.Add(this.control_Textarea1);
            this.Name = "Control_Workbench";
            this.Size = new System.Drawing.Size(423, 336);
            this.Load += new System.EventHandler(this.Control_Workbench_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Textarea control_Textarea1;
    }
}
