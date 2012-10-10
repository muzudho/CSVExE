namespace Xt_L13_Spritecanvas
{
    partial class Form2_Folderdrop
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
            this.usercontrolPanelFiledrop1 = new Xt_L13_Spritecanvas.UsercontrolPanelFiledrop();
            this.SuspendLayout();
            // 
            // usercontrolPanelFiledrop1
            // 
            this.usercontrolPanelFiledrop1.Location = new System.Drawing.Point(0, 0);
            this.usercontrolPanelFiledrop1.Name = "usercontrolPanelFiledrop1";
            this.usercontrolPanelFiledrop1.Size = new System.Drawing.Size(303, 281);
            this.usercontrolPanelFiledrop1.TabIndex = 0;
            // 
            // Form2_Folderdrop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 349);
            this.Controls.Add(this.usercontrolPanelFiledrop1);
            this.Name = "Form2_Folderdrop";
            this.Text = "Form2_Folderdrop";
            this.Load += new System.EventHandler(this.Form2_Folderdrop_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UsercontrolPanelFiledrop usercontrolPanelFiledrop1;
    }
}