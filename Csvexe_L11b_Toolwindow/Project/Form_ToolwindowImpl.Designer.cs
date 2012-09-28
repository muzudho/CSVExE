namespace Xenon.Toolwindow
{
    partial class Form_ToolwindowImpl
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
            this.label1 = new System.Windows.Forms.Label();
            this.pctxtInformation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pclbl5 = new System.Windows.Forms.Label();
            this.pctxtFpathProjectcnf = new Xenon.Controls.UsercontrolTextbox();
            this.pcbtnChanging = new Xenon.Controls.UsercontrolButton();
            this.uclstNameProject = new Xenon.Controls.UsercontrolListbox();
            this.uctButton1 = new Xenon.Controls.UsercontrolButton();
            this.uctButton2 = new Xenon.Controls.UsercontrolButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "エディター名を選んでください。";
            // 
            // pctxtInformation
            // 
            this.pctxtInformation.Location = new System.Drawing.Point(320, 72);
            this.pctxtInformation.Multiline = true;
            this.pctxtInformation.Name = "pctxtInformation";
            this.pctxtInformation.ReadOnly = true;
            this.pctxtInformation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.pctxtInformation.Size = new System.Drawing.Size(336, 216);
            this.pctxtInformation.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "エディター設定ファイルへのパス";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "情報";
            // 
            // pclbl5
            // 
            this.pclbl5.AutoSize = true;
            this.pclbl5.Location = new System.Drawing.Point(80, 304);
            this.pclbl5.Name = "pclbl5";
            this.pclbl5.Size = new System.Drawing.Size(171, 12);
            this.pclbl5.TabIndex = 9;
            this.pclbl5.Text = "保存していない内容は失われます。";
            // 
            // pctxtFpathProjectcnf
            // 
            this.pctxtFpathProjectcnf.UsercontrolEnabled = true;
            this.pctxtFpathProjectcnf.UsercontrolTabindex = 0;
            this.pctxtFpathProjectcnf.UsercontrolText = "";
            this.pctxtFpathProjectcnf.UsercontrolVisible = true;
            this.pctxtFpathProjectcnf.Location = new System.Drawing.Point(8, 24);
            this.pctxtFpathProjectcnf.Margin = new System.Windows.Forms.Padding(0);
            this.pctxtFpathProjectcnf.Multiline = false;
            this.pctxtFpathProjectcnf.Name = "pctxtFpathProjectcnf";
            this.pctxtFpathProjectcnf.UsercontrolNewline = "";
            this.pctxtFpathProjectcnf.UsercontrolReadonly = true;
            this.pctxtFpathProjectcnf.UsercontrolScrollbars = System.Windows.Forms.ScrollBars.None;
            this.pctxtFpathProjectcnf.SelectionStart = 0;
            this.pctxtFpathProjectcnf.Size = new System.Drawing.Size(380, 19);
            this.pctxtFpathProjectcnf.TabIndex = 4;
            this.pctxtFpathProjectcnf.UsercontrolWordwrap = true;
            // 
            // pcbtnChanging
            // 
            this.pcbtnChanging.BackColor = System.Drawing.Color.Red;
            this.pcbtnChanging.UsercontrolEnabled = true;
            this.pcbtnChanging.UsercontrolTabindex = 0;
            this.pcbtnChanging.UsercontrolText = "切替";
            this.pcbtnChanging.UsercontrolVisible = true;
            this.pcbtnChanging.Location = new System.Drawing.Point(16, 296);
            this.pcbtnChanging.Margin = new System.Windows.Forms.Padding(0);
            this.pcbtnChanging.Name = "pcbtnChanging";
            this.pcbtnChanging.Size = new System.Drawing.Size(44, 24);
            this.pcbtnChanging.TabIndex = 2;
            this.pcbtnChanging.Load += new System.EventHandler(this.pcbtnChanging_Load);
            this.pcbtnChanging.UsercontroleventhandlerClick += new System.EventHandler(this.On_ChangingBtn_FoClick);
            // 
            // uclstNameProject
            // 
            this.uclstNameProject.UsercontrolEnabled = true;
            this.uclstNameProject.UsercontrolTabindex = 0;
            this.uclstNameProject.UsercontrolText = "＜正常：データはない＞";
            this.uclstNameProject.UsercontrolVisible = true;
            this.uclstNameProject.DataSource = null;
            this.uclstNameProject.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.uclstNameProject.HorizontalExtent = 0;
            this.uclstNameProject.HorizontalScrollbar = false;
            this.uclstNameProject.ItemHeight = 12;
            this.uclstNameProject.Location = new System.Drawing.Point(24, 72);
            this.uclstNameProject.Name = "uclstNameProject";
            this.uclstNameProject.NIndex_PreselectedItem = -1;
            this.uclstNameProject.SelectedIndex = -1;
            this.uclstNameProject.SelectedItem = null;
            this.uclstNameProject.SelectedValue = null;
            this.uclstNameProject.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.uclstNameProject.Size = new System.Drawing.Size(280, 220);
            this.uclstNameProject.TabIndex = 10;
            // 
            // uctButton1
            // 
            this.uctButton1.BackColor = System.Drawing.Color.Red;
            this.uctButton1.UsercontrolEnabled = true;
            this.uctButton1.UsercontrolTabindex = 0;
            this.uctButton1.UsercontrolText = "変数ログ書出";
            this.uctButton1.UsercontrolVisible = true;
            this.uctButton1.Location = new System.Drawing.Point(300, 408);
            this.uctButton1.Margin = new System.Windows.Forms.Padding(0);
            this.uctButton1.Name = "uctButton1";
            this.uctButton1.Size = new System.Drawing.Size(100, 19);
            this.uctButton1.TabIndex = 11;
            // 
            // uctButton2
            // 
            this.uctButton2.BackColor = System.Drawing.Color.Red;
            this.uctButton2.UsercontrolEnabled = true;
            this.uctButton2.UsercontrolTabindex = 0;
            this.uctButton2.UsercontrolText = "フォームCSV書出";
            this.uctButton2.UsercontrolVisible = true;
            this.uctButton2.Location = new System.Drawing.Point(416, 408);
            this.uctButton2.Margin = new System.Windows.Forms.Padding(0);
            this.uctButton2.Name = "uctButton2";
            this.uctButton2.Size = new System.Drawing.Size(100, 19);
            this.uctButton2.TabIndex = 12;
            // 
            // Form_ToolwindowImpl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 483);
            this.Controls.Add(this.uctButton2);
            this.Controls.Add(this.uctButton1);
            this.Controls.Add(this.uclstNameProject);
            this.Controls.Add(this.pclbl5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pctxtInformation);
            this.Controls.Add(this.pctxtFpathProjectcnf);
            this.Controls.Add(this.pcbtnChanging);
            this.Controls.Add(this.label1);
            this.Name = "Form_ToolwindowImpl";
            this.Text = "ツール・ウィンドウ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Xenon.Controls.UsercontrolButton pcbtnChanging;
        private Xenon.Controls.UsercontrolTextbox pctxtFpathProjectcnf;
        private System.Windows.Forms.TextBox pctxtInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label pclbl5;
        private Xenon.Controls.UsercontrolListbox uclstNameProject;
        private Xenon.Controls.UsercontrolButton uctButton1;
        private Xenon.Controls.UsercontrolButton uctButton2;
    }
}

