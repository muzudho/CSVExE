namespace DragAndDrop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusEntersTxt = new System.Windows.Forms.TextBox();
            this.statusReceivesTxt = new System.Windows.Forms.TextBox();
            this.explainTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusResultsTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.formatsTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(23, 170);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(98, 76);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ドロップの許可(AllowDrop)をしたパネル";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "状況";
            // 
            // statusEntersTxt
            // 
            this.statusEntersTxt.Location = new System.Drawing.Point(56, 264);
            this.statusEntersTxt.Name = "statusEntersTxt";
            this.statusEntersTxt.ReadOnly = true;
            this.statusEntersTxt.Size = new System.Drawing.Size(542, 19);
            this.statusEntersTxt.TabIndex = 6;
            // 
            // statusReceivesTxt
            // 
            this.statusReceivesTxt.Location = new System.Drawing.Point(56, 289);
            this.statusReceivesTxt.Name = "statusReceivesTxt";
            this.statusReceivesTxt.ReadOnly = true;
            this.statusReceivesTxt.Size = new System.Drawing.Size(542, 19);
            this.statusReceivesTxt.TabIndex = 7;
            // 
            // explainTxt
            // 
            this.explainTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.explainTxt.Location = new System.Drawing.Point(445, 24);
            this.explainTxt.Multiline = true;
            this.explainTxt.Name = "explainTxt";
            this.explainTxt.ReadOnly = true;
            this.explainTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.explainTxt.Size = new System.Drawing.Size(175, 113);
            this.explainTxt.TabIndex = 8;
            this.explainTxt.Text = resources.GetString("explainTxt.Text");
            this.explainTxt.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(23, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 95);
            this.panel1.TabIndex = 9;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragLeave += new System.EventHandler(this.panel1_DragLeave);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "ここにテキストか画像か、";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(127, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 76);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // statusResultsTxt
            // 
            this.statusResultsTxt.Location = new System.Drawing.Point(56, 314);
            this.statusResultsTxt.Name = "statusResultsTxt";
            this.statusResultsTxt.ReadOnly = true;
            this.statusResultsTxt.Size = new System.Drawing.Size(542, 19);
            this.statusResultsTxt.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "何がパネルの上にドラッグされたか";
            // 
            // formatsTxt
            // 
            this.formatsTxt.Location = new System.Drawing.Point(445, 170);
            this.formatsTxt.Multiline = true;
            this.formatsTxt.Name = "formatsTxt";
            this.formatsTxt.ReadOnly = true;
            this.formatsTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.formatsTxt.Size = new System.Drawing.Size(175, 76);
            this.formatsTxt.TabIndex = 13;
            this.formatsTxt.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "テキスト形式";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "上のパネルにドロップした結果表示";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "画像表示";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(259, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(159, 220);
            this.listBox1.TabIndex = 17;
            this.listBox1.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.listBox1_QueryContinueDrag);
            this.listBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseUp);
            this.listBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            this.listBox1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.listBox1_GiveFeedback);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "文字列を取り出せるリストボックス";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "ファイルかフォルダーをドロップしてください。";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 366);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.formatsTxt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusResultsTxt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.explainTxt);
            this.Controls.Add(this.statusReceivesTxt);
            this.Controls.Add(this.statusEntersTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ファイルやフォルダーをドロップしてファイル・パスのようなものを取得できるようにしました。";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox statusEntersTxt;
        private System.Windows.Forms.TextBox statusReceivesTxt;
        private System.Windows.Forms.TextBox explainTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox statusResultsTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox formatsTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

