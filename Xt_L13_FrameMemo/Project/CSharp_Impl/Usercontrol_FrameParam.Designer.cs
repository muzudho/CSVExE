namespace Xenon.FrameMemo
{
    partial class Usercontrol_FrameParam
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
            this.pclblColumnRow = new System.Windows.Forms.Label();
            this.pctxtColumnForce = new System.Windows.Forms.TextBox();
            this.pctxtRowForce = new System.Windows.Forms.TextBox();
            this.pclblCellSize = new System.Windows.Forms.Label();
            this.pctxtCellWidthForce = new System.Windows.Forms.TextBox();
            this.pctxtCellHeightForce = new System.Windows.Forms.TextBox();
            this.pclblCrop = new System.Windows.Forms.Label();
            this.pclblCropLastResult = new System.Windows.Forms.Label();
            this.pctxtCropForce = new System.Windows.Forms.TextBox();
            this.pclblColResult = new System.Windows.Forms.Label();
            this.pclblRowResult = new System.Windows.Forms.Label();
            this.pclblCellWidthResult = new System.Windows.Forms.Label();
            this.pclblCellHeightResult = new System.Windows.Forms.Label();
            this.pclblCropResult = new System.Windows.Forms.Label();
            this.pclblGridXy = new System.Windows.Forms.Label();
            this.pctxtGridX = new System.Windows.Forms.TextBox();
            this.pctxtGridY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pclblColumnRow
            // 
            this.pclblColumnRow.AutoSize = true;
            this.pclblColumnRow.Enabled = false;
            this.pclblColumnRow.Location = new System.Drawing.Point(0, 4);
            this.pclblColumnRow.Name = "pclblColumnRow";
            this.pclblColumnRow.Size = new System.Drawing.Size(65, 12);
            this.pclblColumnRow.TabIndex = 20;
            this.pclblColumnRow.Text = "列数／行数";
            // 
            // pctxtColumnForce
            // 
            this.pctxtColumnForce.Enabled = false;
            this.pctxtColumnForce.Location = new System.Drawing.Point(68, 0);
            this.pctxtColumnForce.Name = "pctxtColumnForce";
            this.pctxtColumnForce.Size = new System.Drawing.Size(24, 19);
            this.pctxtColumnForce.TabIndex = 21;
            this.pctxtColumnForce.TextChanged += new System.EventHandler(this.pctxtColumn_TextChanged);
            // 
            // pctxtRowForce
            // 
            this.pctxtRowForce.Enabled = false;
            this.pctxtRowForce.Location = new System.Drawing.Point(92, 0);
            this.pctxtRowForce.Name = "pctxtRowForce";
            this.pctxtRowForce.Size = new System.Drawing.Size(24, 19);
            this.pctxtRowForce.TabIndex = 23;
            this.pctxtRowForce.TextChanged += new System.EventHandler(this.pctxtRow_TextChanged);
            // 
            // pclblCellSize
            // 
            this.pclblCellSize.AutoSize = true;
            this.pclblCellSize.Enabled = false;
            this.pclblCellSize.Location = new System.Drawing.Point(128, 4);
            this.pclblCellSize.Name = "pclblCellSize";
            this.pclblCellSize.Size = new System.Drawing.Size(82, 12);
            this.pclblCellSize.TabIndex = 24;
            this.pclblCellSize.Text = "１個幅ヨコ／タテ";
            // 
            // pctxtCellWidthForce
            // 
            this.pctxtCellWidthForce.Enabled = false;
            this.pctxtCellWidthForce.Location = new System.Drawing.Point(212, 0);
            this.pctxtCellWidthForce.Name = "pctxtCellWidthForce";
            this.pctxtCellWidthForce.Size = new System.Drawing.Size(28, 19);
            this.pctxtCellWidthForce.TabIndex = 25;
            this.pctxtCellWidthForce.TextChanged += new System.EventHandler(this.pctxtCellWidth_TextChanged);
            // 
            // pctxtCellHeightForce
            // 
            this.pctxtCellHeightForce.Enabled = false;
            this.pctxtCellHeightForce.Location = new System.Drawing.Point(240, 0);
            this.pctxtCellHeightForce.Name = "pctxtCellHeightForce";
            this.pctxtCellHeightForce.Size = new System.Drawing.Size(28, 19);
            this.pctxtCellHeightForce.TabIndex = 27;
            this.pctxtCellHeightForce.TextChanged += new System.EventHandler(this.pctxtCellHeight_TextChanged);
            // 
            // pclblCrop
            // 
            this.pclblCrop.AutoSize = true;
            this.pclblCrop.Enabled = false;
            this.pclblCrop.Location = new System.Drawing.Point(280, 4);
            this.pclblCrop.Name = "pclblCrop";
            this.pclblCrop.Size = new System.Drawing.Size(105, 12);
            this.pclblCrop.TabIndex = 28;
            this.pclblCrop.Text = "切抜きフレーム／1～";
            // 
            // pclblCropLastResult
            // 
            this.pclblCropLastResult.AutoSize = true;
            this.pclblCropLastResult.Enabled = false;
            this.pclblCropLastResult.Location = new System.Drawing.Point(388, 4);
            this.pclblCropLastResult.Name = "pclblCropLastResult";
            this.pclblCropLastResult.Size = new System.Drawing.Size(11, 12);
            this.pclblCropLastResult.TabIndex = 30;
            this.pclblCropLastResult.Text = "1";
            // 
            // pctxtCropForce
            // 
            this.pctxtCropForce.Enabled = false;
            this.pctxtCropForce.Location = new System.Drawing.Point(408, 0);
            this.pctxtCropForce.Name = "pctxtCropForce";
            this.pctxtCropForce.Size = new System.Drawing.Size(32, 19);
            this.pctxtCropForce.TabIndex = 31;
            this.pctxtCropForce.TextChanged += new System.EventHandler(this.pctxtCrop_TextChanged);
            // 
            // pclblColResult
            // 
            this.pclblColResult.AutoSize = true;
            this.pclblColResult.Location = new System.Drawing.Point(68, 20);
            this.pclblColResult.Name = "pclblColResult";
            this.pclblColResult.Size = new System.Drawing.Size(11, 12);
            this.pclblColResult.TabIndex = 32;
            this.pclblColResult.Text = "-";
            // 
            // pclblRowResult
            // 
            this.pclblRowResult.AutoSize = true;
            this.pclblRowResult.Location = new System.Drawing.Point(96, 20);
            this.pclblRowResult.Name = "pclblRowResult";
            this.pclblRowResult.Size = new System.Drawing.Size(11, 12);
            this.pclblRowResult.TabIndex = 33;
            this.pclblRowResult.Text = "-";
            // 
            // pclblCellWidthResult
            // 
            this.pclblCellWidthResult.AutoSize = true;
            this.pclblCellWidthResult.Location = new System.Drawing.Point(212, 20);
            this.pclblCellWidthResult.Name = "pclblCellWidthResult";
            this.pclblCellWidthResult.Size = new System.Drawing.Size(11, 12);
            this.pclblCellWidthResult.TabIndex = 34;
            this.pclblCellWidthResult.Text = "-";
            // 
            // pclblCellHeightResult
            // 
            this.pclblCellHeightResult.AutoSize = true;
            this.pclblCellHeightResult.Location = new System.Drawing.Point(240, 20);
            this.pclblCellHeightResult.Name = "pclblCellHeightResult";
            this.pclblCellHeightResult.Size = new System.Drawing.Size(11, 12);
            this.pclblCellHeightResult.TabIndex = 35;
            this.pclblCellHeightResult.Text = "-";
            // 
            // pclblCropResult
            // 
            this.pclblCropResult.AutoSize = true;
            this.pclblCropResult.Location = new System.Drawing.Point(408, 20);
            this.pclblCropResult.Name = "pclblCropResult";
            this.pclblCropResult.Size = new System.Drawing.Size(11, 12);
            this.pclblCropResult.TabIndex = 36;
            this.pclblCropResult.Text = "-";
            // 
            // pclblGridXy
            // 
            this.pclblGridXy.AutoSize = true;
            this.pclblGridXy.Enabled = false;
            this.pclblGridXy.Location = new System.Drawing.Point(448, 4);
            this.pclblGridXy.Name = "pclblGridXy";
            this.pclblGridXy.Size = new System.Drawing.Size(63, 12);
            this.pclblGridXy.TabIndex = 37;
            this.pclblGridXy.Text = "グリッドX／Y";
            // 
            // pctxtGridX
            // 
            this.pctxtGridX.Enabled = false;
            this.pctxtGridX.Location = new System.Drawing.Point(512, 0);
            this.pctxtGridX.Name = "pctxtGridX";
            this.pctxtGridX.Size = new System.Drawing.Size(28, 19);
            this.pctxtGridX.TabIndex = 38;
            this.pctxtGridX.TextChanged += new System.EventHandler(this.pctxtGridX_TextChanged);
            // 
            // pctxtGridY
            // 
            this.pctxtGridY.Enabled = false;
            this.pctxtGridY.Location = new System.Drawing.Point(540, 0);
            this.pctxtGridY.Name = "pctxtGridY";
            this.pctxtGridY.Size = new System.Drawing.Size(28, 19);
            this.pctxtGridY.TabIndex = 39;
            this.pctxtGridY.TextChanged += new System.EventHandler(this.pctxtGridY_TextChanged);
            // 
            // UcFrameParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pctxtGridY);
            this.Controls.Add(this.pctxtGridX);
            this.Controls.Add(this.pclblGridXy);
            this.Controls.Add(this.pclblCropResult);
            this.Controls.Add(this.pclblCellHeightResult);
            this.Controls.Add(this.pclblCellWidthResult);
            this.Controls.Add(this.pclblRowResult);
            this.Controls.Add(this.pclblColResult);
            this.Controls.Add(this.pctxtCropForce);
            this.Controls.Add(this.pclblCropLastResult);
            this.Controls.Add(this.pclblCrop);
            this.Controls.Add(this.pctxtCellHeightForce);
            this.Controls.Add(this.pctxtCellWidthForce);
            this.Controls.Add(this.pclblCellSize);
            this.Controls.Add(this.pctxtRowForce);
            this.Controls.Add(this.pctxtColumnForce);
            this.Controls.Add(this.pclblColumnRow);
            this.Name = "UcFrameParam";
            this.Size = new System.Drawing.Size(578, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pclblColumnRow;
        private System.Windows.Forms.TextBox pctxtColumnForce;
        private System.Windows.Forms.TextBox pctxtRowForce;
        private System.Windows.Forms.Label pclblCellSize;
        private System.Windows.Forms.TextBox pctxtCellWidthForce;
        private System.Windows.Forms.TextBox pctxtCellHeightForce;
        private System.Windows.Forms.Label pclblCrop;
        private System.Windows.Forms.Label pclblCropLastResult;
        private System.Windows.Forms.TextBox pctxtCropForce;
        private System.Windows.Forms.Label pclblColResult;
        private System.Windows.Forms.Label pclblRowResult;
        private System.Windows.Forms.Label pclblCellWidthResult;
        private System.Windows.Forms.Label pclblCellHeightResult;
        private System.Windows.Forms.Label pclblCropResult;
        private System.Windows.Forms.Label pclblGridXy;
        private System.Windows.Forms.TextBox pctxtGridX;
        private System.Windows.Forms.TextBox pctxtGridY;
    }
}
