namespace Xenon.SpeedCoder
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
            this.usercontrol_Canvas1 = new Xenon.SpeedCoder.Usercontrol_Canvas();
            this.SuspendLayout();
            // 
            // usercontrol_Canvas1
            // 
            this.usercontrol_Canvas1.Location = new System.Drawing.Point(0, 0);
            this.usercontrol_Canvas1.Name = "usercontrol_Canvas1";
            this.usercontrol_Canvas1.Size = new System.Drawing.Size(624, 440);
            this.usercontrol_Canvas1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.usercontrol_Canvas1);
            this.Name = "Form1";
            this.Text = "スピードコーダー";
            this.ResumeLayout(false);

        }

        #endregion

        private Usercontrol_Canvas usercontrol_Canvas1;
    }
}

