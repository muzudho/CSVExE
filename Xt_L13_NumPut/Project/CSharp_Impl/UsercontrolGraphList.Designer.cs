namespace Xenon.NumPut
{
    partial class UsercontrolGraphList
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
            this.pclst1 = new System.Windows.Forms.ListBox();
            this.pcpicThumbnail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcpicThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // pclst1
            // 
            this.pclst1.FormattingEnabled = true;
            this.pclst1.ItemHeight = 12;
            this.pclst1.Location = new System.Drawing.Point(0, 0);
            this.pclst1.Name = "pclst1";
            this.pclst1.Size = new System.Drawing.Size(120, 88);
            this.pclst1.TabIndex = 0;
            this.pclst1.SelectedIndexChanged += new System.EventHandler(this.pclst1_SelectedIndexChanged);
            // 
            // pcpicThumbnail
            // 
            this.pcpicThumbnail.Location = new System.Drawing.Point(0, 100);
            this.pcpicThumbnail.Name = "pcpicThumbnail";
            this.pcpicThumbnail.Size = new System.Drawing.Size(100, 50);
            this.pcpicThumbnail.TabIndex = 2;
            this.pcpicThumbnail.TabStop = false;
            // 
            // UcGraphList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcpicThumbnail);
            this.Controls.Add(this.pclst1);
            this.Name = "UcGraphList";
            this.Size = new System.Drawing.Size(269, 303);
            this.SizeChanged += new System.EventHandler(this.UcGraphList_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pcpicThumbnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox pclst1;
        private System.Windows.Forms.PictureBox pcpicThumbnail;
    }
}
