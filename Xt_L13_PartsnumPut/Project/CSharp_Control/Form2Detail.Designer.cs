namespace Xenon.PartsnumPut
{
    partial class Form2Detail
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
            this.usercontrolDetailbrowser1 = new Xenon.PartsnumPut.UsercontrolDetailbrowser();
            this.SuspendLayout();
            // 
            // usercontrolDetailbrowser1
            // 
            this.usercontrolDetailbrowser1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.usercontrolDetailbrowser1.Location = new System.Drawing.Point(0, 0);
            this.usercontrolDetailbrowser1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.usercontrolDetailbrowser1.Name = "usercontrolDetailbrowser1";
            this.usercontrolDetailbrowser1.Size = new System.Drawing.Size(690, 470);
            this.usercontrolDetailbrowser1.TabIndex = 0;
            // 
            // Form2Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 166);
            this.Controls.Add(this.usercontrolDetailbrowser1);
            this.Name = "Form2Detail";
            this.Text = "詳細";
            this.Load += new System.EventHandler(this.Form2Detail_Load);
            this.SizeChanged += new System.EventHandler(this.Form2Detail_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private UsercontrolDetailbrowser usercontrolDetailbrowser1;
    }
}