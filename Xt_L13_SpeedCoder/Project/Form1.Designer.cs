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
            Xenon.SpeedCoder.TextdropareaImpl textdropareaImpl1 = new Xenon.SpeedCoder.TextdropareaImpl();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Xenon.SpeedCoder.TextdropareaImpl textdropareaImpl2 = new Xenon.SpeedCoder.TextdropareaImpl();
            this.usercontrol_Canvas1 = new Xenon.SpeedCoder.Usercontrol_Canvas();
            this.SuspendLayout();
            // 
            // usercontrol_Canvas1
            // 
            this.usercontrol_Canvas1.AllowDrop = true;
            this.usercontrol_Canvas1.Location = new System.Drawing.Point(0, 0);
            this.usercontrol_Canvas1.Name = "usercontrol_Canvas1";
            this.usercontrol_Canvas1.Size = new System.Drawing.Size(624, 440);
            this.usercontrol_Canvas1.TabIndex = 0;
            textdropareaImpl1.BackgroundMessage = "Template";
            textdropareaImpl1.Bounds = new System.Drawing.Rectangle(10, 10, 280, 140);
            textdropareaImpl1.DroppedText = "";
            textdropareaImpl1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            textdropareaImpl1.IsDropped = false;
            textdropareaImpl1.ListFilepath = ((System.Collections.Generic.List<string>)(resources.GetObject("textdropareaImpl1.ListFilepath")));
            textdropareaImpl1.ListMessageA = ((System.Collections.Generic.List<string>)(resources.GetObject("textdropareaImpl1.ListMessageA")));
            textdropareaImpl1.ListMessageB = ((System.Collections.Generic.List<string>)(resources.GetObject("textdropareaImpl1.ListMessageB")));
            this.usercontrol_Canvas1.Textdroparea1 = textdropareaImpl1;
            textdropareaImpl2.BackgroundMessage = "Argument";
            textdropareaImpl2.Bounds = new System.Drawing.Rectangle(300, 10, 280, 140);
            textdropareaImpl2.DroppedText = "";
            textdropareaImpl2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            textdropareaImpl2.IsDropped = false;
            textdropareaImpl2.ListFilepath = ((System.Collections.Generic.List<string>)(resources.GetObject("textdropareaImpl2.ListFilepath")));
            textdropareaImpl2.ListMessageA = ((System.Collections.Generic.List<string>)(resources.GetObject("textdropareaImpl2.ListMessageA")));
            textdropareaImpl2.ListMessageB = ((System.Collections.Generic.List<string>)(resources.GetObject("textdropareaImpl2.ListMessageB")));
            this.usercontrol_Canvas1.Textdroparea2 = textdropareaImpl2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.usercontrol_Canvas1);
            this.Name = "Form1";
            this.Text = "スピードコーダー 1.2";
            this.ResumeLayout(false);

        }

        #endregion

        private Usercontrol_Canvas usercontrol_Canvas1;
    }
}

