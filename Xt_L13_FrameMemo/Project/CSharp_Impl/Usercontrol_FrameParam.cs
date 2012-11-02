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
    public partial class Usercontrol_FrameParam : UserControl, Usercontrolview
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

        public void OnChanged_CountcolumnResult(float nValue)
        {
            this.pclblColResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnChanged_CountrowResult(float nValue)
        {
            this.pclblRowResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnChanged_WidthcellResult(float nValue)
        {
            this.pclblCellWidthResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnChanged_HeightcellResult(float nValue)
        {
            this.pclblCellHeightResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnChanged_CropForce(int nValue)
        {
            this.pclblCropResult.Text = nValue.ToString();
        }

        //────────────────────────────────────────

        public void OnChanged_CropLastResult(int nValue)
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

            this.MemorySprite.IsAutoinputting = true;//自動入力開始
            this.MemorySprite.CountcolumnForce = nValue;
            this.MemorySprite.RefreshViews();// 対応ビューの再描画
            this.MemorySprite.IsAutoinputting = false;//自動入力終了
        }

        private void pctxtRow_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MemorySprite.IsAutoinputting = true;//自動入力開始
            this.MemorySprite.CountrowForce = value;
            this.MemorySprite.RefreshViews();// 対応ビューの再描画
            this.MemorySprite.IsAutoinputting = false;//自動入力終了
        }

        private void pctxtCellWidth_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MemorySprite.IsAutoinputting = true;//自動入力開始

            this.MemorySprite.SizecellForce = new SizeF(value, this.MemorySprite.SizecellForce.Height);

            this.MemorySprite.RefreshViews();// 対応ビューの再描画
            this.MemorySprite.IsAutoinputting = false;//自動入力終了
        }

        private void pctxtCellHeight_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MemorySprite.IsAutoinputting = true;//自動入力開始

            this.MemorySprite.SizecellForce = new SizeF(this.MemorySprite.SizecellForce.Width, value);

            this.MemorySprite.RefreshViews();// 対応ビューの再描画
            this.MemorySprite.IsAutoinputting = false;//自動入力終了
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

            this.MemorySprite.IsAutoinputting = true;//自動入力開始
            this.MemorySprite.FrameCropForce = nCropForce;
            this.MemorySprite.RefreshViews();// 対応ビューの再描画
            this.MemorySprite.IsAutoinputting = false;//自動入力終了
        }

        private void pctxtGridX_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MemorySprite.IsAutoinputting = true;//自動入力開始
            this.MemorySprite.GridLefttop = new PointF(
                value,
                this.MemorySprite.GridLefttop.Y
                );
            this.MemorySprite.RefreshViews();// 対応ビューの再描画
            this.MemorySprite.IsAutoinputting = false;//自動入力終了
        }

        private void pctxtGridY_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int value = 0;
            int.TryParse(pctxt.Text, out value);

            this.MemorySprite.IsAutoinputting = true;//自動入力開始
            this.MemorySprite.GridLefttop = new PointF(
                this.MemorySprite.GridLefttop.X,
                value
                );
            this.MemorySprite.RefreshViews();// 対応ビューの再描画
            this.MemorySprite.IsAutoinputting = false;//自動入力終了
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected MemorySpriteImpl memorySprite;

        public MemorySpriteImpl MemorySprite
        {
            get
            {
                return memorySprite;
            }
            set
            {
                memorySprite = value;
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
