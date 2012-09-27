namespace Xenon.Operating
{
    partial class Usercontrol_Page1
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
            this.pclblTimer = new System.Windows.Forms.Label();
            this.pctxtTimer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pctxtConnectedDevices = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucController4 = new Xenon.Operating.Usercontrol_VwdTest();
            this.ucController3 = new Xenon.Operating.Usercontrol_VwdTest();
            this.ucController2 = new Xenon.Operating.Usercontrol_VwdTest();
            this.ucController1 = new Xenon.Operating.Usercontrol_VwdTest();
            this.SuspendLayout();
            // 
            // pclblTimer
            // 
            this.pclblTimer.AutoSize = true;
            this.pclblTimer.Location = new System.Drawing.Point(28, 16);
            this.pclblTimer.Name = "pclblTimer";
            this.pclblTimer.Size = new System.Drawing.Size(41, 12);
            this.pclblTimer.TabIndex = 6;
            this.pclblTimer.Text = "タイマー";
            // 
            // pctxtTimer
            // 
            this.pctxtTimer.Location = new System.Drawing.Point(72, 12);
            this.pctxtTimer.Name = "pctxtTimer";
            this.pctxtTimer.ReadOnly = true;
            this.pctxtTimer.Size = new System.Drawing.Size(100, 19);
            this.pctxtTimer.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "接続コントローラー数";
            // 
            // pctxtConnectedDevices
            // 
            this.pctxtConnectedDevices.Location = new System.Drawing.Point(312, 12);
            this.pctxtConnectedDevices.Name = "pctxtConnectedDevices";
            this.pctxtConnectedDevices.ReadOnly = true;
            this.pctxtConnectedDevices.Size = new System.Drawing.Size(100, 19);
            this.pctxtConnectedDevices.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "1";
            // 
            // ucController4
            // 
            this.ucController4.Location = new System.Drawing.Point(448, 44);
            this.ucController4.Name = "ucController4";
            this.ucController4.Size = new System.Drawing.Size(148, 380);
            this.ucController4.TabIndex = 13;
            // 
            // ucController3
            // 
            this.ucController3.Location = new System.Drawing.Point(300, 44);
            this.ucController3.Name = "ucController3";
            this.ucController3.Size = new System.Drawing.Size(148, 380);
            this.ucController3.TabIndex = 12;
            // 
            // ucController2
            // 
            this.ucController2.Location = new System.Drawing.Point(152, 44);
            this.ucController2.Name = "ucController2";
            this.ucController2.Size = new System.Drawing.Size(148, 380);
            this.ucController2.TabIndex = 11;
            // 
            // ucController1
            // 
            this.ucController1.Location = new System.Drawing.Point(4, 44);
            this.ucController1.Name = "ucController1";
            this.ucController1.Size = new System.Drawing.Size(148, 380);
            this.ucController1.TabIndex = 10;
            // 
            // UcGmctrlAllTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucController4);
            this.Controls.Add(this.ucController3);
            this.Controls.Add(this.ucController2);
            this.Controls.Add(this.ucController1);
            this.Controls.Add(this.pctxtConnectedDevices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pctxtTimer);
            this.Controls.Add(this.pclblTimer);
            this.Name = "UcGmctrlAllTest";
            this.Size = new System.Drawing.Size(622, 433);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pclblTimer;
        private System.Windows.Forms.TextBox pctxtTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pctxtConnectedDevices;
        private Usercontrol_VwdTest ucController1;
        private Usercontrol_VwdTest ucController2;
        private Usercontrol_VwdTest ucController3;
        private Usercontrol_VwdTest ucController4;
        private System.Windows.Forms.Label label2;
    }
}
