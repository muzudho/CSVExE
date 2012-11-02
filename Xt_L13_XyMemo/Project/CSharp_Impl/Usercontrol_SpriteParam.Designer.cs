namespace Xenon.XyMemo
{
    partial class Usercontrol_SpriteParam
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
            this.pclblSize = new System.Windows.Forms.Label();
            this.pctxtDstWidthForced = new System.Windows.Forms.TextBox();
            this.pctxtDstHeightForced = new System.Windows.Forms.TextBox();
            this.pclblLt = new System.Windows.Forms.Label();
            this.pctxtLtXForce = new System.Windows.Forms.TextBox();
            this.pctxtLtYForce = new System.Windows.Forms.TextBox();
            this.pclblCt = new System.Windows.Forms.Label();
            this.pctxtCtXForce = new System.Windows.Forms.TextBox();
            this.pctxtCtYForce = new System.Windows.Forms.TextBox();
            this.pclblDstWidthResult = new System.Windows.Forms.Label();
            this.pclblDstHeightResult = new System.Windows.Forms.Label();
            this.pclblLtXResult = new System.Windows.Forms.Label();
            this.pclblLtYResult = new System.Windows.Forms.Label();
            this.pclblCtXResult = new System.Windows.Forms.Label();
            this.pclblCtYResult = new System.Windows.Forms.Label();
            this.pclblBaseXy = new System.Windows.Forms.Label();
            this.pctxtBaseXForced = new System.Windows.Forms.TextBox();
            this.pctxtBaseYForced = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pclblSize
            // 
            this.pclblSize.AutoSize = true;
            this.pclblSize.Location = new System.Drawing.Point(0, 4);
            this.pclblSize.Name = "pclblSize";
            this.pclblSize.Size = new System.Drawing.Size(41, 12);
            this.pclblSize.TabIndex = 18;
            this.pclblSize.Text = "横縦幅";
            // 
            // pctxtDstWidthForced
            // 
            this.pctxtDstWidthForced.Location = new System.Drawing.Point(44, 0);
            this.pctxtDstWidthForced.Name = "pctxtDstWidthForced";
            this.pctxtDstWidthForced.Size = new System.Drawing.Size(36, 19);
            this.pctxtDstWidthForced.TabIndex = 19;
            this.pctxtDstWidthForced.TextChanged += new System.EventHandler(this.pctxtDstWidthForced_TextChanged);
            // 
            // pctxtDstHeightForced
            // 
            this.pctxtDstHeightForced.Location = new System.Drawing.Point(80, 0);
            this.pctxtDstHeightForced.Name = "pctxtDstHeightForced";
            this.pctxtDstHeightForced.Size = new System.Drawing.Size(36, 19);
            this.pctxtDstHeightForced.TabIndex = 21;
            this.pctxtDstHeightForced.TextChanged += new System.EventHandler(this.pctxtDstHeightForced_TextChanged);
            // 
            // pclblLt
            // 
            this.pclblLt.AutoSize = true;
            this.pclblLt.Location = new System.Drawing.Point(252, 4);
            this.pclblLt.Name = "pclblLt";
            this.pclblLt.Size = new System.Drawing.Size(43, 12);
            this.pclblLt.TabIndex = 22;
            this.pclblLt.Text = "左上XY";
            // 
            // pctxtLtXForce
            // 
            this.pctxtLtXForce.Location = new System.Drawing.Point(296, 0);
            this.pctxtLtXForce.Name = "pctxtLtXForce";
            this.pctxtLtXForce.Size = new System.Drawing.Size(36, 19);
            this.pctxtLtXForce.TabIndex = 26;
            this.pctxtLtXForce.TextChanged += new System.EventHandler(this.pctxtLtX_TextChanged);
            // 
            // pctxtLtYForce
            // 
            this.pctxtLtYForce.Location = new System.Drawing.Point(332, 0);
            this.pctxtLtYForce.Name = "pctxtLtYForce";
            this.pctxtLtYForce.Size = new System.Drawing.Size(36, 19);
            this.pctxtLtYForce.TabIndex = 28;
            this.pctxtLtYForce.TextChanged += new System.EventHandler(this.pctxtLtY_TextChanged);
            // 
            // pclblCt
            // 
            this.pclblCt.AutoSize = true;
            this.pclblCt.Location = new System.Drawing.Point(376, 4);
            this.pclblCt.Name = "pclblCt";
            this.pclblCt.Size = new System.Drawing.Size(43, 12);
            this.pclblCt.TabIndex = 29;
            this.pclblCt.Text = "中心XY";
            // 
            // pctxtCtXForce
            // 
            this.pctxtCtXForce.Location = new System.Drawing.Point(420, 0);
            this.pctxtCtXForce.Name = "pctxtCtXForce";
            this.pctxtCtXForce.Size = new System.Drawing.Size(36, 19);
            this.pctxtCtXForce.TabIndex = 30;
            this.pctxtCtXForce.TextChanged += new System.EventHandler(this.pctxtCtX_TextChanged);
            // 
            // pctxtCtYForce
            // 
            this.pctxtCtYForce.Location = new System.Drawing.Point(456, 0);
            this.pctxtCtYForce.Name = "pctxtCtYForce";
            this.pctxtCtYForce.Size = new System.Drawing.Size(36, 19);
            this.pctxtCtYForce.TabIndex = 32;
            this.pctxtCtYForce.TextChanged += new System.EventHandler(this.pctxtCtY_TextChanged);
            // 
            // pclblDstWidthResult
            // 
            this.pclblDstWidthResult.AutoSize = true;
            this.pclblDstWidthResult.Location = new System.Drawing.Point(60, 20);
            this.pclblDstWidthResult.Name = "pclblDstWidthResult";
            this.pclblDstWidthResult.Size = new System.Drawing.Size(11, 12);
            this.pclblDstWidthResult.TabIndex = 33;
            this.pclblDstWidthResult.Text = "-";
            // 
            // pclblDstHeightResult
            // 
            this.pclblDstHeightResult.AutoSize = true;
            this.pclblDstHeightResult.Location = new System.Drawing.Point(96, 20);
            this.pclblDstHeightResult.Name = "pclblDstHeightResult";
            this.pclblDstHeightResult.Size = new System.Drawing.Size(11, 12);
            this.pclblDstHeightResult.TabIndex = 34;
            this.pclblDstHeightResult.Text = "-";
            // 
            // pclblLtXResult
            // 
            this.pclblLtXResult.AutoSize = true;
            this.pclblLtXResult.Location = new System.Drawing.Point(312, 20);
            this.pclblLtXResult.Name = "pclblLtXResult";
            this.pclblLtXResult.Size = new System.Drawing.Size(11, 12);
            this.pclblLtXResult.TabIndex = 35;
            this.pclblLtXResult.Text = "-";
            // 
            // pclblLtYResult
            // 
            this.pclblLtYResult.AutoSize = true;
            this.pclblLtYResult.Location = new System.Drawing.Point(348, 20);
            this.pclblLtYResult.Name = "pclblLtYResult";
            this.pclblLtYResult.Size = new System.Drawing.Size(11, 12);
            this.pclblLtYResult.TabIndex = 36;
            this.pclblLtYResult.Text = "-";
            // 
            // pclblCtXResult
            // 
            this.pclblCtXResult.AutoSize = true;
            this.pclblCtXResult.Location = new System.Drawing.Point(436, 20);
            this.pclblCtXResult.Name = "pclblCtXResult";
            this.pclblCtXResult.Size = new System.Drawing.Size(11, 12);
            this.pclblCtXResult.TabIndex = 37;
            this.pclblCtXResult.Text = "-";
            // 
            // pclblCtYResult
            // 
            this.pclblCtYResult.AutoSize = true;
            this.pclblCtYResult.Location = new System.Drawing.Point(472, 20);
            this.pclblCtYResult.Name = "pclblCtYResult";
            this.pclblCtYResult.Size = new System.Drawing.Size(11, 12);
            this.pclblCtYResult.TabIndex = 38;
            this.pclblCtYResult.Text = "-";
            // 
            // pclblBaseXy
            // 
            this.pclblBaseXy.AutoSize = true;
            this.pclblBaseXy.Location = new System.Drawing.Point(124, 4);
            this.pclblBaseXy.Name = "pclblBaseXy";
            this.pclblBaseXy.Size = new System.Drawing.Size(48, 12);
            this.pclblBaseXy.TabIndex = 39;
            this.pclblBaseXy.Text = "ベースXY";
            // 
            // pctxtBaseX
            // 
            this.pctxtBaseXForced.Location = new System.Drawing.Point(172, 0);
            this.pctxtBaseXForced.Name = "pctxtBaseX";
            this.pctxtBaseXForced.Size = new System.Drawing.Size(36, 19);
            this.pctxtBaseXForced.TabIndex = 40;
            this.pctxtBaseXForced.TextChanged += new System.EventHandler(this.pctxtBaseXForced_TextChanged);
            // 
            // pctxtBaseY
            // 
            this.pctxtBaseYForced.Location = new System.Drawing.Point(208, 0);
            this.pctxtBaseYForced.Name = "pctxtBaseY";
            this.pctxtBaseYForced.Size = new System.Drawing.Size(36, 19);
            this.pctxtBaseYForced.TabIndex = 41;
            this.pctxtBaseYForced.TextChanged += new System.EventHandler(this.pctxtBaseYForced_TextChanged);
            // 
            // UcSpriteParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pctxtBaseYForced);
            this.Controls.Add(this.pctxtBaseXForced);
            this.Controls.Add(this.pclblBaseXy);
            this.Controls.Add(this.pclblCtYResult);
            this.Controls.Add(this.pclblCtXResult);
            this.Controls.Add(this.pclblLtYResult);
            this.Controls.Add(this.pclblLtXResult);
            this.Controls.Add(this.pclblDstHeightResult);
            this.Controls.Add(this.pclblDstWidthResult);
            this.Controls.Add(this.pctxtCtYForce);
            this.Controls.Add(this.pctxtCtXForce);
            this.Controls.Add(this.pclblCt);
            this.Controls.Add(this.pctxtLtYForce);
            this.Controls.Add(this.pctxtLtXForce);
            this.Controls.Add(this.pclblLt);
            this.Controls.Add(this.pctxtDstHeightForced);
            this.Controls.Add(this.pctxtDstWidthForced);
            this.Controls.Add(this.pclblSize);
            this.Name = "UcSpriteParam";
            this.Size = new System.Drawing.Size(495, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pclblSize;
        private System.Windows.Forms.TextBox pctxtDstWidthForced;
        private System.Windows.Forms.TextBox pctxtDstHeightForced;
        private System.Windows.Forms.Label pclblLt;
        private System.Windows.Forms.TextBox pctxtLtXForce;
        private System.Windows.Forms.TextBox pctxtLtYForce;
        private System.Windows.Forms.Label pclblCt;
        private System.Windows.Forms.TextBox pctxtCtXForce;
        private System.Windows.Forms.TextBox pctxtCtYForce;
        private System.Windows.Forms.Label pclblDstWidthResult;
        private System.Windows.Forms.Label pclblDstHeightResult;
        private System.Windows.Forms.Label pclblLtXResult;
        private System.Windows.Forms.Label pclblLtYResult;
        private System.Windows.Forms.Label pclblCtXResult;
        private System.Windows.Forms.Label pclblCtYResult;
        private System.Windows.Forms.Label pclblBaseXy;
        private System.Windows.Forms.TextBox pctxtBaseXForced;
        private System.Windows.Forms.TextBox pctxtBaseYForced;
    }
}
