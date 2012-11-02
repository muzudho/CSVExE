using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.XyMemo
{
    public partial class Usercontrol_SpriteParam : UserControl, Spritememo
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// 自動入力でコントロールの値を変えた場合は、真。真で、コントロールの変更イベントをスルーさせます。
        /// </summary>
        protected bool bAutoInputting_pclblDstWidthResult;
        protected bool bAutoInputting_pclblDstHeightResult;
        protected bool bAutoInputting_pctxtBaseX;
        protected bool bAutoInputting_pctxtBaseY;
        protected bool bAutoInputting_pctxtLtX;
        protected bool bAutoInputting_pctxtLtY;
        protected bool bAutoInputting_pctxtCtX;
        protected bool bAutoInputting_pctxtCtY;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Usercontrol_SpriteParam()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public Label PclblDstWidthResult
        {
            get
            {
                return this.pclblDstWidthResult;
            }
        }

        //────────────────────────────────────────

        public TextBox PctxtDstWidthForced
        {
            get
            {
                return this.pctxtDstWidthForced;
            }
        }

        //────────────────────────────────────────

        public Label PclblDstHeightResult
        {
            get
            {
                return this.pclblDstHeightResult;
            }
        }

        //────────────────────────────────────────

        public TextBox PctxtDstHeightForced
        {
            get
            {
                return this.pctxtDstHeightForced;
            }
        }

        //────────────────────────────────────────

        public Label PclblLtXResult
        {
            get
            {
                return this.pclblLtXResult;
            }
        }

        //────────────────────────────────────────

        public TextBox PctxtLtXForce
        {
            get
            {
                return this.pctxtLtXForce;
            }
        }

        //────────────────────────────────────────

        public Label PclblLtYResult
        {
            get
            {
                return this.pclblLtYResult;
            }
        }

        //────────────────────────────────────────

        public TextBox PctxtLtYForce
        {
            get
            {
                return this.pctxtLtYForce;
            }
        }

        //────────────────────────────────────────

        public Label PclblCtXResult
        {
            get
            {
                return this.pclblCtXResult;
            }
        }

        //────────────────────────────────────────

        public TextBox PctxtCtXForce
        {
            get
            {
                return this.pctxtCtXForce;
            }
        }

        //────────────────────────────────────────

        public Label PclblCtYResult
        {
            get
            {
                return this.pclblCtYResult;
            }
        }

        //────────────────────────────────────────

        public TextBox PctxtCtYForce
        {
            get
            {
                return this.pctxtCtYForce;
            }
        }

        //────────────────────────────────────────

        protected MemorySpritecanvasImpl moSpriteCanvas;

        public MemorySpritecanvasImpl MoSpriteCanvas
        {
            get
            {
                return moSpriteCanvas;
            }
            set
            {
                moSpriteCanvas = value;
            }
        }

        //────────────────────────────────────────

        protected MemorySpritememoImpl moSprite;

        /// <summary>
        /// スプライト
        /// </summary>
        public MemorySpritememoImpl MoSprite
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

        public void RefreshSpriteSizeDisplay()
        {
            this.bAutoInputting_pclblDstWidthResult = true;//自動入力開始
            this.bAutoInputting_pclblDstHeightResult = true;//自動入力開始

            this.pclblDstWidthResult.Text = ((int)this.MoSprite.DstSizeResult.Width).ToString();
            this.pclblDstHeightResult.Text = ((int)this.MoSprite.DstSizeResult.Height).ToString();

            this.bAutoInputting_pclblDstWidthResult = false;//自動入力終了
            this.bAutoInputting_pclblDstHeightResult = false;//自動入力終了
        }

        //────────────────────────────────────────

        public void OnSpriteSizeChanged()
        {
            this.RefreshSpriteSizeDisplay();
        }

        //────────────────────────────────────────

        /// <summary>
        /// スプライトの位置が変わったとき。
        /// </summary>
        public void OnSpriteLocationChanged()
        {
            this.bAutoInputting_pctxtLtX = true;//自動入力開始
            this.bAutoInputting_pctxtLtY = true;//自動入力開始
            this.bAutoInputting_pctxtCtX = true;//自動入力開始
            this.bAutoInputting_pctxtCtY = true;//自動入力開始

            this.pclblLtXResult.Text = ((int)this.MoSprite.MyLtOnBgOsz.X).ToString();
            this.pclblLtYResult.Text = ((int)this.MoSprite.MyLtOnBgOsz.Y).ToString();
            this.pclblCtXResult.Text = ((int)this.MoSprite.MyCtOnBg.X).ToString();
            this.pclblCtYResult.Text = ((int)this.MoSprite.MyCtOnBg.Y).ToString();

            this.bAutoInputting_pctxtLtX = false;//自動入力終了
            this.bAutoInputting_pctxtLtY = false;//自動入力終了
            this.bAutoInputting_pctxtCtX = false;//自動入力終了
            this.bAutoInputting_pctxtCtY = false;//自動入力終了
        }

        //────────────────────────────────────────

        private void pctxtDstWidthForced_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            //
            // 横幅の強制の有無
            //
            if ("" == pctxt.Text)
            {
                this.MoSprite.BWidthForced = false;
            }
            else
            {
                this.MoSprite.BWidthForced = true;
            }

            int nValue;
            if (!int.TryParse(pctxt.Text, out nValue))
            {
                // パース失敗時
                nValue = this.MoSprite.SrcSize.Width;//ソースサイズ。
                this.MoSprite.BWidthForced = false;
            }

            this.MoSprite.DstSizeResult = new Size(
                nValue,
                this.MoSprite.DstSizeResult.Height
                );
        }

        //────────────────────────────────────────

        private void pctxtDstHeightForced_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            //
            // 縦幅の強制の有無
            //
            if ("" == pctxt.Text)
            {
                this.MoSprite.BHeightForced = false;
            }
            else
            {
                this.MoSprite.BHeightForced = true;
            }

            int nValue;
            if (!int.TryParse(pctxt.Text, out nValue))
            {
                // パース失敗時
                nValue = this.MoSprite.SrcSize.Height;//ソースサイズ。
                this.MoSprite.BHeightForced = false;
            }

            this.MoSprite.DstSizeResult = new Size(
                this.MoSprite.DstSizeResult.Width,
                nValue
                );
        }

        //────────────────────────────────────────

        /// <summary>
        /// 左上座標X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtLtX_TextChanged(object sender, EventArgs e)
        {
            if (!this.bAutoInputting_pctxtLtX)
            {
                //
                // 手動入力の場合
                //
                int nLtXNoscaled;//原寸
                if (int.TryParse(this.pctxtLtXForce.Text, out nLtXNoscaled))
                {
                    // 左上座標の強制力を優先。
                    this.MoSprite.PrimaryLtCtForce = EnumLefttopCenter.Lt;

                    // 左上座標欄を有効にするために、中央座標欄を　空欄にします。
                    this.pctxtCtXForce.Text = "";
                    this.pctxtCtYForce.Text = "";

                    this.MoSprite.ForceToLtXOriginsize(nLtXNoscaled);
                }
            }

        }

        //────────────────────────────────────────

        /// <summary>
        /// 左上座標Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtLtY_TextChanged(object sender, EventArgs e)
        {
            if (!this.bAutoInputting_pctxtLtY)
            {
                //
                // 手動入力の場合
                //
                int nLtYNoscaled;//原寸
                if (int.TryParse(this.pctxtLtYForce.Text, out nLtYNoscaled))
                {
                    // 左上座標の強制力を優先。
                    this.MoSprite.PrimaryLtCtForce = EnumLefttopCenter.Lt;

                    // 左上座標欄を有効にするために、中央座標欄を　空欄にします。
                    this.pctxtCtXForce.Text = "";
                    this.pctxtCtYForce.Text = "";

                    this.MoSprite.ForceToLtYOriginsize(nLtYNoscaled);
                }
            }

        }

        //────────────────────────────────────────

        /// <summary>
        /// 中央座標X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtCtX_TextChanged(object sender, EventArgs e)
        {
            if (!this.bAutoInputting_pctxtCtX)
            {
                //
                // 手動入力の場合
                //
                int nCtXNoscaled;//原寸
                if (int.TryParse(this.pctxtCtXForce.Text, out nCtXNoscaled))
                {
                    // 中央座標の強制力を優先。
                    this.MoSprite.PrimaryLtCtForce = EnumLefttopCenter.Ct;

                    // 中央座標欄を有効にするために、左上座標欄を　空欄にします。
                    this.pctxtLtXForce.Text = "";
                    this.pctxtLtYForce.Text = "";

                    this.MoSprite.ForceToCtXOriginsize(nCtXNoscaled);
                }
            }

        }

        //────────────────────────────────────────

        /// <summary>
        /// 中央座標Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtCtY_TextChanged(object sender, EventArgs e)
        {
            if (!this.bAutoInputting_pctxtCtY)
            {
                //
                // 手動入力の場合
                //
                int nCtYNoscaled;//原寸
                if (int.TryParse(this.pctxtCtYForce.Text, out nCtYNoscaled))
                {
                    // 中央座標の強制力を優先。
                    this.MoSprite.PrimaryLtCtForce = EnumLefttopCenter.Ct;

                    // 中央座標欄を有効にするために、左上座標欄を　空欄にします。
                    this.pctxtLtXForce.Text = "";
                    this.pctxtLtYForce.Text = "";

                    this.MoSprite.ForceToCtYOriginsize(nCtYNoscaled);
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ベースX。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtBaseXForced_TextChanged(object sender, EventArgs e)
        {
            if (!this.bAutoInputting_pctxtBaseX)
            {
                //
                // 手動入力の場合
                //

                string sText = this.pctxtBaseXForced.Text;

                int nValue;
                if ("" == sText)
                {
                    nValue = 0;
                }
                else if (!int.TryParse(sText, out nValue))
                {
                    goto gt_ProcessEnd;
                }

                // 強制力を解除。
                this.pctxtLtXForce.Text = "";
                this.pctxtLtYForce.Text = "";
                this.pctxtCtXForce.Text = "";
                this.pctxtCtYForce.Text = "";

                this.MoSprite.ForceToBaseXOriginsize(nValue, this.MoSpriteCanvas.ScaleImg);
            }

            //
        //
        //
        //
        gt_ProcessEnd:
            return;
        }

        //────────────────────────────────────────

        private void pctxtBaseYForced_TextChanged(object sender, EventArgs e)
        {
            if (!this.bAutoInputting_pctxtBaseY)
            {
                //
                // 手動入力の場合
                //
                string sText = this.pctxtBaseYForced.Text;

                int nValue;
                if ("" == sText)
                {
                    nValue = 0;
                }
                else if (!int.TryParse(sText, out nValue))
                {
                    goto gt_ProcessEnd;
                }

                // 強制力を解除。
                this.pctxtLtXForce.Text = "";
                this.pctxtLtYForce.Text = "";
                this.pctxtCtXForce.Text = "";
                this.pctxtCtYForce.Text = "";

                this.MoSprite.ForceToBaseYOriginsize(nValue, this.MoSpriteCanvas.ScaleImg);
            }

            //
        //
        //
        //
        gt_ProcessEnd:
            return;
        }

        //────────────────────────────────────────
        #endregion



    }



}
