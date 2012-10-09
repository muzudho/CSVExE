using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;//Ｂｉｔｍａｐ

namespace Xenon.FrameMemo
{
    public class MemorySpriteImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemorySpriteImpl()
        {
            this.nCropForce = 0;//指定なし＝全体図
            this.nCropLast = 1;

            this.gridLt = new PointF();
            this.lt = new PointF();

            this.voFrameList = new List<ViewFrame>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 切り抜く位置。
        /// </summary>
        /// <returns></returns>
        public PointF GetCropXy()
        {
            float viWidth = (float)this.Bitmap.Width / this.NColCountResult;
            float viHeight = (float)this.Bitmap.Height / this.NRowCountResult;

            float srcX;
            if (0.0f == this.NColCountResult)
            {
                srcX = 0.0f;
            }
            else
            {
                srcX = (this.NCropForce - 1) % (int)this.NColCountResult * viWidth;
            }

            float srcY;
            if (0.0f == this.NRowCountResult)
            {
                srcY = 0.0f;
            }
            else
            {
                srcY = (this.NCropForce - 1) / (int)this.NColCountResult * viHeight;
            }

            return new PointF(srcX, srcY);
        }

        //────────────────────────────────────────

        public void RefreshViews()
        {
            foreach (ViewFrame voFrame in this.VoFrameList)
            {
                voFrame.Refresh();
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 再計算。
        /// </summary>
        private void CalSize()
        {
            //
            // 横幅と列数
            //
            if (0 < this.NCellSizeForce.Width && 0 < this.NColCntForce)
            {
                //
                // 強制横幅、強制列数　共に指定されているとき
                //
                this.NCellWidthResult = this.NCellSizeForce.Width;
                this.NColCountResult = this.NColCntForce;
                if (null == this.Bitmap)
                {
                    this.NImageSize = new SizeF(0.0f, this.NImageSize.Height);
                }
                else
                {
                    this.NImageSize = new SizeF(this.Bitmap.Width, this.NImageSize.Height);
                }
            }
            else if (0 < this.NCellSizeForce.Width)
            {
                //
                // 強制横幅が指定されているとき
                //
                this.NCellWidthResult = this.NCellSizeForce.Width;
                if (null == this.Bitmap)
                {
                    this.NColCountResult = 0.0f;
                    this.NImageSize = new SizeF(0.0f, this.NImageSize.Height);
                }
                else
                {
                    this.NColCountResult = (float)this.Bitmap.Width / this.NCellSizeForce.Width;
                    this.NImageSize = new SizeF(this.Bitmap.Width, this.NImageSize.Height);
                }
            }
            else if (0 < this.NColCntForce)
            {
                //
                // 強制列数が指定されているとき
                //
                this.NColCountResult = this.NColCntForce;
                if (null == this.Bitmap)
                {
                    this.NCellWidthResult = 0.0f;
                    this.NImageSize = new SizeF(0.0f, this.NImageSize.Height);
                }
                else
                {
                    this.NCellWidthResult = (float)this.Bitmap.Width / this.NColCntForce;
                    this.NImageSize = new SizeF(this.Bitmap.Width, this.NImageSize.Height);
                }
            }
            else
            {
                //
                // 強制されていないとき
                //
                this.NColCountResult = 1;
                if (null == this.Bitmap)
                {
                    this.NCellWidthResult = 0.0f;
                    this.NImageSize = new SizeF(0.0f, this.NImageSize.Height);
                }
                else
                {
                    this.NCellWidthResult = (float)this.Bitmap.Width;
                    this.NImageSize = new SizeF(this.Bitmap.Width, this.NImageSize.Height);
                }
            }


            //
            // 縦幅と行数
            //
            if (0 < this.NCellSizeForce.Height && 0 < this.NRowCountForce)
            {
                //
                // 強制縦幅、強制行数　共に指定されているとき
                //
                this.NCellHeightResult = this.NCellSizeForce.Height;
                this.NRowCountResult = this.NRowCountForce;
                if (null == this.Bitmap)
                {
                    this.NImageSize = new SizeF(this.NImageSize.Width, 0.0f);
                }
                else
                {
                    this.NImageSize = new SizeF(this.NImageSize.Width, this.Bitmap.Height);
                }
            }
            else if (0 < this.NCellSizeForce.Height)
            {
                //
                // 強制縦幅が指定されているとき
                //
                this.NCellHeightResult = this.NCellSizeForce.Height;
                if (null == this.Bitmap)
                {
                    this.NRowCountResult = 0.0f;
                    this.NImageSize = new SizeF(this.NImageSize.Width, 0.0f);
                }
                else
                {
                    this.NRowCountResult = (float)this.Bitmap.Height / this.NCellSizeForce.Height;
                    this.NImageSize = new SizeF(this.NImageSize.Width, this.Bitmap.Height);
                }
            }
            else if (0 < this.NRowCountForce)
            {
                //
                // 強制行数が指定されているとき
                //
                this.NRowCountResult = this.NRowCountForce;
                if (null == this.Bitmap)
                {
                    this.NCellHeightResult = 0.0f;
                    this.NImageSize = new SizeF(this.NImageSize.Width, 0.0f);
                }
                else
                {
                    this.NCellHeightResult = (float)this.Bitmap.Height / this.NRowCountForce;
                    this.NImageSize = new SizeF(this.NImageSize.Width, this.Bitmap.Height);
                }
            }
            else
            {
                //
                // 強制されていないとき
                //
                this.NRowCountResult = 1;
                if (null == this.Bitmap)
                {
                    this.NCellHeightResult = 0.0f;
                    this.NImageSize = new SizeF(this.NImageSize.Width, 0.0f);
                }
                else
                {
                    this.NCellHeightResult = (float)this.Bitmap.Height;
                    this.NImageSize = new SizeF(this.NImageSize.Width, this.Bitmap.Height);
                }
            }
        }

        //────────────────────────────────────────

        private void CalCrop()
        {
            //切抜き位置の最終番号を計算。
            this.NCropLast = (int)(this.NRowCountResult * this.NColCountResult);

            this.bCrop = 0 < this.NCropForce && this.NCropForce <= this.NCropLast;
        }

        //────────────────────────────────────────

        /// <summary>
        /// w,h（枠）
        /// </summary>
        /// <returns></returns>
        public SizeF GetFrameSize()
        {
            SizeF size;

            float col = this.NColCountResult;
            float row = this.NRowCountResult;
            if (col < 1)
            {
                col = 1;
            }

            if (row < 1)
            {
                row = 1;
            }

            float cw = this.NCellWidthResult;
            float ch = this.NCellHeightResult;

            size = new SizeF(
                col * cw,
                row * ch
            );

            return size;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected Bitmap bitmap;

        /// <summary>
        /// （１）画像
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                return bitmap;
            }
            set
            {
                bitmap = value;

                // 再計算
                this.CalSize();
            }
        }

        //────────────────────────────────────────

        protected PointF gridLt;

        /// <summary>
        /// 格子線の原点XY。
        /// 
        /// (left top)
        /// </summary>
        public PointF GridLt
        {
            get
            {
                return gridLt;
            }
            set
            {
                gridLt = value;
            }
        }

        //────────────────────────────────────────

        protected PointF lt;

        /// <summary>
        /// スプライトの原点XY。
        /// 
        /// (left top)
        /// </summary>
        public PointF Lt
        {
            get
            {
                return lt;
            }
            set
            {
                lt = value;
            }
        }

        //────────────────────────────────────────

        protected bool bAutoInputting;

        /// <summary>
        /// 自動入力中なら真。
        /// </summary>
        public bool BAutoInputting
        {
            get
            {
                return bAutoInputting;
            }
            set
            {
                bAutoInputting = value;
            }
        }

        //────────────────────────────────────────

        protected List<ViewFrame> voFrameList;

        public List<ViewFrame> VoFrameList
        {
            get
            {
                return voFrameList;
            }
        }

        //────────────────────────────────────────

        protected float nColCntForce;

        /// <summary>
        /// 指定された列数。未指定またはエラーなら 0。
        /// (Column Count)
        /// </summary>
        public float NColCntForce
        {
            get
            {
                return nColCntForce;
            }
            set
            {
                nColCntForce = value;

                // 再計算
                this.CalSize();
                this.CalCrop();
            }
        }

        //────────────────────────────────────────

        protected float nRowCountForce;

        /// <summary>
        /// 指定された行数。未指定またはエラーなら 0。
        /// </summary>
        public float NRowCountForce
        {
            get
            {
                return nRowCountForce;
            }
            set
            {
                nRowCountForce = value;

                // 再計算
                this.CalSize();
                this.CalCrop();

                // 再描画はここでは行わない。
            }
        }

        //────────────────────────────────────────

        protected float nColCntResult;

        /// <summary>
        /// 計算結果の列数。未指定またはエラーなら 0。
        /// (Column Count)
        /// </summary>
        public float NColCountResult
        {
            get
            {
                return nColCntResult;
            }
            set
            {
                nColCntResult = value;

                // 再計算
                this.CalCrop();

                foreach (ViewFrame voFrame in this.VoFrameList)
                {
                    voFrame.OnColumnCountResultChanged(nColCntResult);
                }
            }
        }

        //────────────────────────────────────────

        protected float nRowCountResult;

        /// <summary>
        /// 計算結果の行数。未指定またはエラーなら 0。
        /// </summary>
        public float NRowCountResult
        {
            get
            {
                return nRowCountResult;
            }
            set
            {
                nRowCountResult = value;

                // 再計算
                this.CalCrop();

                foreach (ViewFrame voFrame in this.VoFrameList)
                {
                    voFrame.OnRowCountResultChanged(nRowCountResult);
                }
            }
        }

        //────────────────────────────────────────

        protected SizeF nCellSizeForce;

        /// <summary>
        /// 利用者が指定したセルの横幅、縦幅。未指定またはエラーなら 0。
        /// </summary>
        public SizeF NCellSizeForce
        {
            get
            {
                return nCellSizeForce;
            }
            set
            {
                nCellSizeForce = value;

                // 再計算
                this.CalSize();
                this.CalCrop();

                // 再描画はここでは行わない。
            }
        }

        //────────────────────────────────────────

        protected float nCellWidthResult;

        /// <summary>
        /// 計算結果のセルの横幅。未指定またはエラーなら 0。
        /// </summary>
        public float NCellWidthResult
        {
            get
            {
                return nCellWidthResult;
            }
            set
            {
                nCellWidthResult = value;

                foreach (ViewFrame voFrame in this.VoFrameList)
                {
                    voFrame.OnCellWidthResultChanged(nCellWidthResult);
                }
            }
        }

        //────────────────────────────────────────

        protected float nCellHeightResult;

        /// <summary>
        /// 計算結果のセルの縦幅。未指定またはエラーなら 0。
        /// </summary>
        public float NCellHeightResult
        {
            get
            {
                return nCellHeightResult;
            }
            set
            {
                nCellHeightResult = value;

                foreach (ViewFrame voFrame in this.VoFrameList)
                {
                    voFrame.OnCellHeightResultChanged(nCellHeightResult);
                }
            }
        }

        //────────────────────────────────────────

        protected SizeF nImageSize;

        /// <summary>
        /// 画像の横幅、縦幅。等倍。
        /// </summary>
        public SizeF NImageSize
        {
            get
            {
                return nImageSize;
            }
            set
            {
                nImageSize = value;
            }
        }

        //────────────────────────────────────────

        protected int nCropForce;

        /// <summary>
        /// 指定した[切り抜くフレーム／１～]
        /// </summary>
        public int NCropForce
        {
            get
            {
                return nCropForce;
            }
            set
            {
                nCropForce = value;

                // 再計算
                this.CalCrop();

                foreach (ViewFrame voFrame in this.VoFrameList)
                {
                    voFrame.OnCropForceChanged(nCropForce);
                }
            }
        }

        //────────────────────────────────────────

        protected int nCropLast;

        /// <summary>
        /// 切り抜くフレーム終値／１～
        /// </summary>
        public int NCropLast
        {
            get
            {
                return nCropLast;
            }
            set
            {
                nCropLast = value;

                foreach (ViewFrame voFrame in this.VoFrameList)
                {
                    voFrame.OnCropLastResultChanged(nCropLast);
                }
            }
        }

        //────────────────────────────────────────

        protected bool bCrop;

        /// <summary>
        /// 切抜きなら真、全体図なら偽。
        /// </summary>
        public bool BCrop
        {
            get
            {
                return this.bCrop;
            }
        }

        //────────────────────────────────────────
        //────────────────────────────────────────
        //────────────────────────────────────────
        #endregion



    }
}
