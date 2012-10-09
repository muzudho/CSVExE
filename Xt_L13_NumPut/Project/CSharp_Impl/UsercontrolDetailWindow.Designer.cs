namespace Xenon.NumPut
{
    partial class UsercontrolDetailWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucDetailOut1 = new Xenon.NumPut.UsercontrolDetailOut();
            this.SuspendLayout();
            // 
            // ucDetailOut1
            // 
            this.ucDetailOut1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ucDetailOut1.Location = new System.Drawing.Point(0, 0);
            this.ucDetailOut1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.ucDetailOut1.Name = "ucDetailOut1";
            this.ucDetailOut1.Size = new System.Drawing.Size(690, 470);
            this.ucDetailOut1.TabIndex = 0;
            // 
            // UcDetailWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 166);
            this.Controls.Add(this.ucDetailOut1);
            this.Name = "UcDetailWindow";
            this.Text = "詳細";
            this.Load += new System.EventHandler(this.UcDetailWindow_Load);
            this.SizeChanged += new System.EventHandler(this.UcDetailWindow_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private UsercontrolDetailOut ucDetailOut1;
    }
}