namespace Xenon.RepoNum
{
    partial class Form1
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
            this.pctbp1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pctxtStatusDescription = new System.Windows.Forms.TextBox();
            this.pclstStatus = new System.Windows.Forms.ListBox();
            this.pclblStatus = new System.Windows.Forms.Label();
            this.pcbtnPngCopy = new System.Windows.Forms.Button();
            this.pctxtPng = new System.Windows.Forms.TextBox();
            this.pclblPng = new System.Windows.Forms.Label();
            this.pclstTarget = new System.Windows.Forms.ListBox();
            this.pclblTarget = new System.Windows.Forms.Label();
            this.pcbtnStampCopy = new System.Windows.Forms.Button();
            this.pcbtnNext = new System.Windows.Forms.Button();
            this.pctxtStamp = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pctxtSaveStatus = new System.Windows.Forms.TextBox();
            this.pcbtnLoad = new System.Windows.Forms.Button();
            this.pcbtnSave = new System.Windows.Forms.Button();
            this.pctxtEngineCnf = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pctxtUserCnf = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pctxtNum = new System.Windows.Forms.TextBox();
            this.pclblNum = new System.Windows.Forms.Label();
            this.pctxtVer = new System.Windows.Forms.TextBox();
            this.pclblVer = new System.Windows.Forms.Label();
            this.pctxtUser = new System.Windows.Forms.TextBox();
            this.pclblUser = new System.Windows.Forms.Label();
            this.pctbp1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctbp1
            // 
            this.pctbp1.Controls.Add(this.tabPage1);
            this.pctbp1.Controls.Add(this.tabPage2);
            this.pctbp1.Location = new System.Drawing.Point(0, 0);
            this.pctbp1.Name = "pctbp1";
            this.pctbp1.SelectedIndex = 0;
            this.pctbp1.Size = new System.Drawing.Size(392, 268);
            this.pctbp1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pctxtStatusDescription);
            this.tabPage1.Controls.Add(this.pclstStatus);
            this.tabPage1.Controls.Add(this.pclblStatus);
            this.tabPage1.Controls.Add(this.pcbtnPngCopy);
            this.tabPage1.Controls.Add(this.pctxtPng);
            this.tabPage1.Controls.Add(this.pclblPng);
            this.tabPage1.Controls.Add(this.pclstTarget);
            this.tabPage1.Controls.Add(this.pclblTarget);
            this.tabPage1.Controls.Add(this.pcbtnStampCopy);
            this.tabPage1.Controls.Add(this.pcbtnNext);
            this.tabPage1.Controls.Add(this.pctxtStamp);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(384, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "スタンプ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pctxtStatusDescription
            // 
            this.pctxtStatusDescription.Location = new System.Drawing.Point(32, 216);
            this.pctxtStatusDescription.Name = "pctxtStatusDescription";
            this.pctxtStatusDescription.ReadOnly = true;
            this.pctxtStatusDescription.Size = new System.Drawing.Size(304, 19);
            this.pctxtStatusDescription.TabIndex = 10;
            // 
            // pclstStatus
            // 
            this.pclstStatus.FormattingEnabled = true;
            this.pclstStatus.ItemHeight = 12;
            this.pclstStatus.Location = new System.Drawing.Point(184, 148);
            this.pclstStatus.Name = "pclstStatus";
            this.pclstStatus.Size = new System.Drawing.Size(152, 64);
            this.pclstStatus.TabIndex = 9;
            this.pclstStatus.SelectedIndexChanged += new System.EventHandler(this.pclstStatus_SelectedIndexChanged);
            // 
            // pclblStatus
            // 
            this.pclblStatus.AutoSize = true;
            this.pclblStatus.Location = new System.Drawing.Point(184, 132);
            this.pclblStatus.Name = "pclblStatus";
            this.pclblStatus.Size = new System.Drawing.Size(107, 12);
            this.pclblStatus.TabIndex = 8;
            this.pclblStatus.Text = "ステータスタグを付ける";
            // 
            // pcbtnPngCopy
            // 
            this.pcbtnPngCopy.Location = new System.Drawing.Point(252, 96);
            this.pcbtnPngCopy.Name = "pcbtnPngCopy";
            this.pcbtnPngCopy.Size = new System.Drawing.Size(123, 23);
            this.pcbtnPngCopy.TabIndex = 7;
            this.pcbtnPngCopy.Text = "クリップボードにコピー";
            this.pcbtnPngCopy.UseVisualStyleBackColor = true;
            this.pcbtnPngCopy.Click += new System.EventHandler(this.pcbtnPngCopy_Click);
            // 
            // pctxtPng
            // 
            this.pctxtPng.Location = new System.Drawing.Point(172, 76);
            this.pctxtPng.Name = "pctxtPng";
            this.pctxtPng.Size = new System.Drawing.Size(204, 19);
            this.pctxtPng.TabIndex = 6;
            // 
            // pclblPng
            // 
            this.pclblPng.AutoSize = true;
            this.pclblPng.Location = new System.Drawing.Point(172, 64);
            this.pclblPng.Name = "pclblPng";
            this.pclblPng.Size = new System.Drawing.Size(204, 12);
            this.pclblPng.TabIndex = 5;
            this.pclblPng.Text = "添付PNG画像ファイル名の適当なサンプル";
            // 
            // pclstTarget
            // 
            this.pclstTarget.FormattingEnabled = true;
            this.pclstTarget.HorizontalScrollbar = true;
            this.pclstTarget.ItemHeight = 12;
            this.pclstTarget.Location = new System.Drawing.Point(8, 148);
            this.pclstTarget.Name = "pclstTarget";
            this.pclstTarget.Size = new System.Drawing.Size(152, 64);
            this.pclstTarget.TabIndex = 4;
            this.pclstTarget.SelectedIndexChanged += new System.EventHandler(this.pclstTag_SelectedIndexChanged);
            // 
            // pclblTarget
            // 
            this.pclblTarget.AutoSize = true;
            this.pclblTarget.Location = new System.Drawing.Point(8, 132);
            this.pclblTarget.Name = "pclblTarget";
            this.pclblTarget.Size = new System.Drawing.Size(86, 12);
            this.pclblTarget.TabIndex = 3;
            this.pclblTarget.Text = "宛先タグを付ける";
            // 
            // pcbtnStampCopy
            // 
            this.pcbtnStampCopy.Location = new System.Drawing.Point(256, 24);
            this.pcbtnStampCopy.Name = "pcbtnStampCopy";
            this.pcbtnStampCopy.Size = new System.Drawing.Size(120, 23);
            this.pcbtnStampCopy.TabIndex = 2;
            this.pcbtnStampCopy.Text = "クリップボードにコピー";
            this.pcbtnStampCopy.UseVisualStyleBackColor = true;
            this.pcbtnStampCopy.Click += new System.EventHandler(this.pcbtnStampCopy_Click);
            // 
            // pcbtnNext
            // 
            this.pcbtnNext.Location = new System.Drawing.Point(8, 24);
            this.pcbtnNext.Name = "pcbtnNext";
            this.pcbtnNext.Size = new System.Drawing.Size(248, 23);
            this.pcbtnNext.TabIndex = 1;
            this.pcbtnNext.Text = "次の番号のスタンプを作る";
            this.pcbtnNext.UseVisualStyleBackColor = true;
            this.pcbtnNext.Click += new System.EventHandler(this.pcbtnNext_Click);
            // 
            // pctxtStamp
            // 
            this.pctxtStamp.Location = new System.Drawing.Point(8, 8);
            this.pctxtStamp.Multiline = true;
            this.pctxtStamp.Name = "pctxtStamp";
            this.pctxtStamp.Size = new System.Drawing.Size(368, 16);
            this.pctxtStamp.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pctxtSaveStatus);
            this.tabPage2.Controls.Add(this.pcbtnLoad);
            this.tabPage2.Controls.Add(this.pcbtnSave);
            this.tabPage2.Controls.Add(this.pctxtEngineCnf);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.pctxtUserCnf);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.pctxtNum);
            this.tabPage2.Controls.Add(this.pclblNum);
            this.tabPage2.Controls.Add(this.pctxtVer);
            this.tabPage2.Controls.Add(this.pclblVer);
            this.tabPage2.Controls.Add(this.pctxtUser);
            this.tabPage2.Controls.Add(this.pclblUser);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(384, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "設定";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pctxtSaveStatus
            // 
            this.pctxtSaveStatus.Location = new System.Drawing.Point(16, 96);
            this.pctxtSaveStatus.Name = "pctxtSaveStatus";
            this.pctxtSaveStatus.ReadOnly = true;
            this.pctxtSaveStatus.Size = new System.Drawing.Size(100, 19);
            this.pctxtSaveStatus.TabIndex = 12;
            // 
            // pcbtnLoad
            // 
            this.pcbtnLoad.Location = new System.Drawing.Point(204, 96);
            this.pcbtnLoad.Name = "pcbtnLoad";
            this.pcbtnLoad.Size = new System.Drawing.Size(75, 23);
            this.pcbtnLoad.TabIndex = 11;
            this.pcbtnLoad.Text = "最新表示";
            this.pcbtnLoad.UseVisualStyleBackColor = true;
            this.pcbtnLoad.Click += new System.EventHandler(this.pcbtnLoad_Click);
            // 
            // pcbtnSave
            // 
            this.pcbtnSave.Location = new System.Drawing.Point(116, 96);
            this.pcbtnSave.Name = "pcbtnSave";
            this.pcbtnSave.Size = new System.Drawing.Size(75, 23);
            this.pcbtnSave.TabIndex = 10;
            this.pcbtnSave.Text = "設定保存";
            this.pcbtnSave.UseVisualStyleBackColor = true;
            this.pcbtnSave.Click += new System.EventHandler(this.pcbtnSave_Click);
            // 
            // pctxtEngineCnf
            // 
            this.pctxtEngineCnf.Location = new System.Drawing.Point(20, 216);
            this.pctxtEngineCnf.Name = "pctxtEngineCnf";
            this.pctxtEngineCnf.ReadOnly = true;
            this.pctxtEngineCnf.Size = new System.Drawing.Size(356, 19);
            this.pctxtEngineCnf.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "エンジン設定ファイルの場所";
            // 
            // pctxtUserCnf
            // 
            this.pctxtUserCnf.Location = new System.Drawing.Point(20, 164);
            this.pctxtUserCnf.Name = "pctxtUserCnf";
            this.pctxtUserCnf.ReadOnly = true;
            this.pctxtUserCnf.Size = new System.Drawing.Size(356, 19);
            this.pctxtUserCnf.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "ユーザー設定ファイルの場所";
            // 
            // pctxtNum
            // 
            this.pctxtNum.Location = new System.Drawing.Point(140, 68);
            this.pctxtNum.Name = "pctxtNum";
            this.pctxtNum.Size = new System.Drawing.Size(100, 19);
            this.pctxtNum.TabIndex = 5;
            this.pctxtNum.TextChanged += new System.EventHandler(this.pctxtNum_TextChanged);
            // 
            // pclblNum
            // 
            this.pclblNum.AutoSize = true;
            this.pclblNum.Location = new System.Drawing.Point(16, 72);
            this.pclblNum.Name = "pclblNum";
            this.pclblNum.Size = new System.Drawing.Size(75, 12);
            this.pclblNum.TabIndex = 4;
            this.pclblNum.Text = "前の報告番号";
            // 
            // pctxtVer
            // 
            this.pctxtVer.Location = new System.Drawing.Point(140, 40);
            this.pctxtVer.Name = "pctxtVer";
            this.pctxtVer.Size = new System.Drawing.Size(100, 19);
            this.pctxtVer.TabIndex = 3;
            this.pctxtVer.TextChanged += new System.EventHandler(this.pctxtVer_TextChanged);
            // 
            // pclblVer
            // 
            this.pclblVer.AutoSize = true;
            this.pclblVer.Location = new System.Drawing.Point(16, 44);
            this.pclblVer.Name = "pclblVer";
            this.pclblVer.Size = new System.Drawing.Size(120, 12);
            this.pclblVer.TabIndex = 2;
            this.pclblVer.Text = "制作物のバージョン番号";
            // 
            // pctxtUser
            // 
            this.pctxtUser.Location = new System.Drawing.Point(140, 12);
            this.pctxtUser.Name = "pctxtUser";
            this.pctxtUser.Size = new System.Drawing.Size(100, 19);
            this.pctxtUser.TabIndex = 1;
            this.pctxtUser.TextChanged += new System.EventHandler(this.pctxtUser_TextChanged);
            // 
            // pclblUser
            // 
            this.pclblUser.AutoSize = true;
            this.pclblUser.Location = new System.Drawing.Point(16, 16);
            this.pclblUser.Name = "pclblUser";
            this.pclblUser.Size = new System.Drawing.Size(53, 12);
            this.pclblUser.TabIndex = 0;
            this.pclblUser.Text = "報告者名";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 266);
            this.Controls.Add(this.pctbp1);
            this.Name = "Form1";
            this.Text = "RepoNum v1.00 - Xenon Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pctbp1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl pctbp1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox pctxtUser;
        private System.Windows.Forms.Label pclblUser;
        private System.Windows.Forms.Label pclblVer;
        private System.Windows.Forms.TextBox pctxtVer;
        private System.Windows.Forms.TextBox pctxtNum;
        private System.Windows.Forms.Label pclblNum;
        private System.Windows.Forms.Button pcbtnStampCopy;
        private System.Windows.Forms.Button pcbtnNext;
        private System.Windows.Forms.TextBox pctxtStamp;
        private System.Windows.Forms.ListBox pclstTarget;
        private System.Windows.Forms.Label pclblTarget;
        private System.Windows.Forms.Label pclblPng;
        private System.Windows.Forms.Button pcbtnPngCopy;
        private System.Windows.Forms.TextBox pctxtPng;
        private System.Windows.Forms.TextBox pctxtEngineCnf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pctxtUserCnf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button pcbtnLoad;
        private System.Windows.Forms.Button pcbtnSave;
        private System.Windows.Forms.TextBox pctxtSaveStatus;
        private System.Windows.Forms.ListBox pclstStatus;
        private System.Windows.Forms.Label pclblStatus;
        private System.Windows.Forms.TextBox pctxtStatusDescription;
    }
}

