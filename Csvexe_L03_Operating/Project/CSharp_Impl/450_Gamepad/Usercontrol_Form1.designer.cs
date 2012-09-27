namespace Xenon.Operating
{
    partial class Usercontrol_Form1
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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pctmr1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucPage1 = new Xenon.Operating.Usercontrol_Page1();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucPage2 = new Xenon.Operating.Usercontrol_Page2();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucPage3 = new Xenon.Operating.Usercontrol_Page3();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctmr1
            // 
            this.pctmr1.Interval = 16;
            this.pctmr1.Tick += new System.EventHandler(this.pctmr1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(636, 448);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucPage1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(628, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "キーテスト";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucGmctrlAllTest
            // 
            this.ucPage1.Location = new System.Drawing.Point(0, 0);
            this.ucPage1.Name = "ucGmctrlAllTest";
            this.ucPage1.Size = new System.Drawing.Size(624, 420);
            this.ucPage1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucPage2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(628, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "キーコンフィグ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucGmctrlAllCnf
            // 
            this.ucPage2.Location = new System.Drawing.Point(0, 0);
            this.ucPage2.Name = "ucGmctrlAllCnf";
            this.ucPage2.Size = new System.Drawing.Size(624, 420);
            this.ucPage2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucPage3);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(628, 423);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "設定テキスト";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uc_Page31
            // 
            this.ucPage3.Location = new System.Drawing.Point(-4, -4);
            this.ucPage3.Name = "uc_Page31";
            this.ucPage3.Size = new System.Drawing.Size(622, 433);
            this.ucPage3.TabIndex = 0;
            // 
            // Uc_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.tabControl1);
            this.Name = "Uc_Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer pctmr1;
        private Xenon.Operating.Usercontrol_Page1 ucPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Xenon.Operating.Usercontrol_Page2 ucPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Xenon.Operating.Usercontrol_Page3 ucPage3;
    }
}

