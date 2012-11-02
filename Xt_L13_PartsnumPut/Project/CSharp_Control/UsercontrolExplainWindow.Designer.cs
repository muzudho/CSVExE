namespace Xenon.PartsnumPut
{
    partial class UsercontrolExplainWindow
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
            this.ucExplainPanel1 = new Xenon.PartsnumPut.UsercontrolExplainPanel();
            this.SuspendLayout();
            // 
            // ucExplainPanel1
            // 
            this.ucExplainPanel1.Location = new System.Drawing.Point(0, 0);
            this.ucExplainPanel1.Name = "ucExplainPanel1";
            this.ucExplainPanel1.Size = new System.Drawing.Size(150, 150);
            this.ucExplainPanel1.TabIndex = 0;
            // 
            // UcExplainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 366);
            this.Controls.Add(this.ucExplainPanel1);
            this.Name = "UcExplainWindow";
            this.Text = "説明書";
            this.Load += new System.EventHandler(this.UcExplainWindow_Load);
            this.SizeChanged += new System.EventHandler(this.UcExplainWindow_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private UsercontrolExplainPanel ucExplainPanel1;
    }
}