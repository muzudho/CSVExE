using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.FrameMemo
{
    public partial class Usercontrol_FrameParam : UserControl, ViewFrame
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Usercontrol_FrameParam()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void OnColumnCountResultChanged(float nValue)
        {
            this.pclblColResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnRowCountResultChanged(float nValue)
        {
            this.pclblRowResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnCellWidthResultChanged(float nValue)
        {
            this.pclblCellWidthResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnCellHeightResultChanged(float nValue)
        {
            this.pclblCellHeightResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnCropForceChanged(int nValue)
        {
            this.pclblCropResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnCropLastResultChanged(int nValue)
        {
            this.pclblCropLastResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// スプライト画像ファイルが開かれたとき。
        /// </summary>
        public void OnImageOpened()
        {
            // 列数／行数
            this.pclblColumnRow.Enabled = true;
            this.pctxtColumnForce.Enabled = true;
            this.pctxtRowForce.Enabled = true;

            // 1個幅ヨコ／タテ
            this.pclblCellSize.Enabled = true;
            this.pctxtCellWidthForce.Enabled = true;
            this.pctxtCellHeightForce.Enabled = true;

            // 切抜きフレーム
            this.pclblCrop.Enabled = true;
            this.pclblCropLastResult.Enabled = true;
            this.pctxtCropForce.Enabled = true;

            // ベースX／Y
            this.pclblGridXy.Enabled = true;
            this.pctxtGridX.Enabled = true;
            this.pctxtGridY.Enabled = true;
        }

        //────────────────────────────────────────

        /// <summary>
        /// スプライト画像ファイルが無くなったとき。
        /// </summary>
        public void OnImageClosed()
        {
            // 列数／行数
            this.pclblColumnRow.Enabled = false;
            this.pctxtColumnForce.Enabled = false;
            this.pctxtRowForce.Enabled = false;

            // 1個幅ヨコ／タテ
            this.pclblCellSize.Enabled = false;
            this.pctxtCellWidthForce.Enabled = false;
            this.pctxtCellHeightForce.Enabled = false;

            // 切抜きフレーム
            this.pclblCrop.Enabled = false;
            this.pclblCropLastResult.Enabled = false;
            this.pctxtCropForce.Enabled = false;

            // ベースX／Y
            this.pclblGridXy.Enabled = false;
            this.pctxtGridX.Enabled = false;
            this.pctxtGridY.Enabled = false;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// [列数]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtColumn_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int nValue;
            int.TryParse(pctxt.Text, out nValue);

            this.MoSprite.BAutoInputting = true;//自動入力開始
            this.MoSprite.NColCntForce = nValue;
            this.MoSprite.RefreshViews();// 対応ビューの再描画
            this.MoSprite.BAutoInputting = false;//自動入力終了
        }

        private void pctxtRow_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MoSprite.BAutoInputting = true;//自動入力開始
            this.MoSprite.NRowCountForce = value;
            this.MoSprite.RefreshViews();// 対応ビューの再描画
            this.MoSprite.BAutoInputting = false;//自動入力終了
        }

        private void pctxtCellWidth_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MoSprite.BAutoInputting = true;//自動入力開始

            this.MoSprite.NCellSizeForce = new SizeF(value, this.MoSprite.NCellSizeForce.Height);

            this.MoSprite.RefreshViews();// 対応ビューの再描画
            this.MoSprite.BAutoInputting = false;//自動入力終了
        }

        private void pctxtCellHeight_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MoSprite.BAutoInputting = true;//自動入力開始

            this.MoSprite.NCellSizeForce = new SizeF(this.MoSprite.NCellSizeForce.Width, value);

            this.MoSprite.RefreshViews();// 対応ビューの再描画
            this.MoSprite.BAutoInputting = false;//自動入力終了
        }

        /// <summary>
        /// [切抜きフレーム]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtCrop_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            string sCropForce = pctxt.Text.Trim();
            int nCropForce;
            if (!int.TryParse(sCropForce, out nCropForce))
            {
                nCropForce = 0;
            }

            this.MoSprite.BAutoInputting = true;//自動入力開始
            this.MoSprite.NCropForce = nCropForce;
            this.MoSprite.RefreshViews();// 対応ビューの再描画
            this.MoSprite.BAutoInputting = false;//自動入力終了
        }

        private void pctxtGridX_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MoSprite.BAutoInputting = true;//自動入力開始
            this.MoSprite.GridLt = new PointF(
                value,
                this.MoSprite.GridLt.Y
                );
            this.MoSprite.RefreshViews();// 対応ビューの再描画
            this.MoSprite.BAutoInputting = false;//自動入力終了
        }

        private void pctxtGridY_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MoSprite.BAutoInputting = true;//自動入力開始
            this.MoSprite.GridLt = new PointF(
                this.MoSprite.GridLt.X,
                value
                );
            this.MoSprite.RefreshViews();// 対応ビューの再描画
            this.MoSprite.BAutoInputting = false;//自動入力終了
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected MemorySpriteImpl moSprite;

        public MemorySpriteImpl MoSprite
        {
            get
            {
                return moSprite;
            }
            set
            {
                moSprite = value;
            }
        }

        //────────────────────────────────────────

        public Label PclblCropLastResult
        {
            get
            {
                return this.pclblCropLastResult;
            }
        }

        //────────────────────────────────────────

        public TextBox PctxtCropForce
        {
            get
            {
                return this.pctxtCropForce;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
