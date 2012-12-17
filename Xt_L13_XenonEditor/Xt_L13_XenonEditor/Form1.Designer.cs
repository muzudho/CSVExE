namespace Xt_L13_XenonEditor
{
    partial class Form1
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.control_Workbench1 = new Xt_L13_XenonEditor.Control_Workbench();
            this.SuspendLayout();
            // 
            // control_Workbench1
            // 
            this.control_Workbench1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.control_Workbench1.Location = new System.Drawing.Point(59, 45);
            this.control_Workbench1.Name = "control_Workbench1";
            this.control_Workbench1.Size = new System.Drawing.Size(284, 261);
            this.control_Workbench1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.control_Workbench1);
            this.Name = "Form1";
            this.Text = "ゼノンエディター";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Workbench control_Workbench1;
    }
}

