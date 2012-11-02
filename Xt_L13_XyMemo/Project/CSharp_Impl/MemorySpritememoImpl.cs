using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;//Graphics

namespace Xenon.XyMemo
{
    public class MemorySpritememoImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemorySpritememoImpl()
        {
            this.primaryLtCtForce = EnumLefttopCenter.Lt;
            this.srcSize = new Size();

            this.voSpriteList = new List<Spritememo>();
            this.baseLocationOnBgOsz = new PointF();
            this.myLtOnBgOsz = new Point();
            this.myCtOnBg = new Point();

            // 画像が無かった時に表示する四角を塗りつぶすブラシの再計算。
            this.CalAltBrush();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        private void CalAltBrush()
        {
            // 緑
            this.altBrush = new SolidBrush(Color.FromArgb((int)(255.0F * this.NOpaque), 51, 153, 102));
        }

        //────────────────────────────────────────

        /// <summary>
        /// 原寸大左上xを指定。
        /// </summary>
        /// <param name="ltX"></param>
        public void ForceToLtXOriginsize(float ltXNoscaled)
        {
            // 表示先等倍画像の横幅の半分。（左端と中心の距離）
            float nHalfW = (float)this.DstSizeResult.Width / 2.0f;

            // 背景画像上のスプライト位置
            this.MyLtOnBgOsz = new PointF(
                ltXNoscaled,
                this.MyLtOnBgOsz.Y
                );
            this.MyCtOnBg = new PointF(
                ltXNoscaled + nHalfW,
                this.MyCtOnBg.Y
                );

            foreach (Spritememo voSp in this.VoSpriteList)
            {
                voSp.OnSpriteLocationChanged();
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 原寸大左上yを指定。
        /// </summary>
        /// <param name="ltYNoscaled"></param>
        public void ForceToLtYOriginsize(float ltYNoscaled)
        {
            // 表示先等倍画像の縦幅の半分。（上端と中心の距離）
            float nHalfH = (float)this.DstSizeResult.Height / 2.0f;

            // 背景画像上のスプライト位置
            this.MyLtOnBgOsz = new PointF(
                this.MyLtOnBgOsz.X,
                ltYNoscaled
                );
            this.MyCtOnBg = new PointF(
                this.MyCtOnBg.X,
                ltYNoscaled + nHalfH
                );

            foreach (Spritememo voSp in this.VoSpriteList)
            {
                voSp.OnSpriteLocationChanged();
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 原寸大ベースxを指定。
        /// </summary>
        /// <param name="ctXNoscaled"></param>
        /// <param name="scale"></param>
        public void ForceToBaseXOriginsize(float baseXNoscaled, float scale)
        {
            // 変更前のベース座標
            PointF preBaseOnBg = this.BaseLocationOnBgOsz;

            // ベース座標
            this.BaseLocationOnBgOsz = new PointF(
                (baseXNoscaled / scale),
                this.BaseLocationOnBgOsz.Y
                );

            // 左上座標
            this.MyLtOnBgOsz = new PointF(
                preBaseOnBg.X + this.MyLtOnBgOsz.X - baseXNoscaled,
                this.MyLtOnBgOsz.Y
                );

            // 中心座標
            this.MyCtOnBg = new PointF(
                preBaseOnBg.X + this.MyCtOnBg.X - baseXNoscaled,
                this.MyCtOnBg.Y
                );

            foreach (Spritememo voSp in this.VoSpriteList)
            {
                voSp.OnSpriteLocationChanged();
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 原寸大ベースyを指定。
        /// </summary>
        /// <param name="ctXNoscaled"></param>
        /// <param name="scale"></param>
        public void ForceToBaseYOriginsize(float baseYNoscaled, float scale)
        {
            // 変更前のベース座標
            PointF preBaseOnBg = this.BaseLocationOnBgOsz;

            // ベース座標
            this.BaseLocationOnBgOsz = new PointF(
                this.BaseLocationOnBgOsz.X,
                (baseYNoscaled / scale)
                );

            // 左上座標
            this.MyLtOnBgOsz = new PointF(
                //                preBaseOnBg.X + this.MyLtOnBg.X,
                this.MyLtOnBgOsz.X,
                preBaseOnBg.Y + this.MyLtOnBgOsz.Y - baseYNoscaled
                );

            // 中心座標
            this.MyCtOnBg = new PointF(
                //preBaseOnBg.X + this.MyCtOnBg.X,
                this.MyCtOnBg.X,
                preBaseOnBg.Y + this.MyCtOnBg.Y - baseYNoscaled
                );

            foreach (Spritememo voSp in this.VoSpriteList)
            {
                voSp.OnSpriteLocationChanged();
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 原寸大中心xを指定。
        /// </summary>
        /// <param name="ctXNoscaled"></param>
        /// <param name="scale"></param>
        public void ForceToCtXOriginsize(float ctXNoscaled)
        {
            // 表示先等倍画像の横幅の半分。（左端と中心の距離）
            float nHalfW = (float)this.DstSizeResult.Width / 2.0f;

            // 中央座標
            this.MyCtOnBg = new PointF(
                ctXNoscaled,
                this.MyCtOnBg.Y
                );

            // 左上座標
            this.MyLtOnBgOsz = new PointF(
                ctXNoscaled - nHalfW,
                this.MyLtOnBgOsz.Y
                );

            foreach (Spritememo voSp in this.VoSpriteList)
            {
                voSp.OnSpriteLocationChanged();
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 原寸大中心yを指定。
        /// </summary>
        /// <param name="ctYNoscaled"></param>
        /// <param name="scale"></param>
        public void ForceToCtYOriginsize(float ctYNoscaled)
        {
            // 表示先等倍画像の縦幅の半分。（上端と中心の距離）
            float nHalfH = (float)this.DstSizeResult.Height / 2.0f;

            // 中央座標
            this.MyCtOnBg = new PointF(
                this.MyCtOnBg.X,
                ctYNoscaled
                );

            // 左上座標
            this.MyLtOnBgOsz = new PointF(
                this.MyLtOnBgOsz.X,
                ctYNoscaled - nHalfH
                );

            foreach (Spritememo voSp in this.VoSpriteList)
            {
                voSp.OnSpriteLocationChanged();
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected EnumLefttopCenter primaryLtCtForce;

        /// <summary>
        /// 左上座標を優先するか、右上座標を優先するか。
        /// </summary>
        public EnumLefttopCenter PrimaryLtCtForce
        {
            get
            {
                return primaryLtCtForce;
            }
            set
            {
                primaryLtCtForce = value;
            }
        }

        //────────────────────────────────────────

        protected bool bWidthForced;

        /// <summary>
        /// 横幅が指定されているなら真。
        /// </summary>
        public bool BWidthForced
        {
            get
            {
                return bWidthForced;
            }
            set
            {
                bWidthForced = value;
            }
        }

        //────────────────────────────────────────

        protected bool bHeightForced;

        /// <summary>
        /// 縦幅が指定されているなら真。
        /// </summary>
        public bool BHeightForced
        {
            get
            {
                return bHeightForced;
            }
            set
            {
                bHeightForced = value;
            }
        }

        //────────────────────────────────────────

        protected List<Spritememo> voSpriteList;

        public List<Spritememo> VoSpriteList
        {
            get
            {
                return voSpriteList;
            }
            set
            {
                voSpriteList = value;
            }
        }

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
            }
        }

        //────────────────────────────────────────

        protected Size srcSize;

        /// <summary>
        /// スプライトの元画像の横幅・縦幅ピクセルの指定。未指定なら0。
        /// </summary>
        public Size SrcSize
        {
            get
            {
                return srcSize;
            }
            set
            {
                srcSize = value;

                // 再計算
                foreach (Spritememo voSp in this.VoSpriteList)
                {
                    voSp.OnSpriteSizeChanged();
                }
            }
        }

        //────────────────────────────────────────

        protected Size dstSizeResult;

        /// <summary>
        /// 表示する横幅・縦幅ピクセルの指定。
        /// </summary>
        public Size DstSizeResult
        {
            get
            {
                return dstSizeResult;
            }
            set
            {
                Size oldSize = dstSizeResult;

                dstSizeResult = value;

                //
                // todo: 左上座標を優先するか、中心座標を優先するか。
                //

                switch (this.PrimaryLtCtForce)
                {
                    case EnumLefttopCenter.Ct:
                        {
                            //
                            // 中心座標優先
                            //

                            // 左上位置は変わっていないので、
                            // 左上位置＋「以前のサイズの半分サイズ」で中心座標を求める。
                            this.MyCtOnBg = new PointF(
                                this.LtXOnBgOsz + (float)oldSize.Width / 2.0f,
                                this.LtYOnBgOsz + (float)oldSize.Height / 2.0f
                                );

                            // 中心座標から、「現在のサイズの半分サイズ」を引いて左上座標を求める。
                            this.MyLtOnBgOsz = new PointF(
                                this.CtXOnBg - (float)dstSizeResult.Width / 2.0f,
                                this.CtYOnBg - (float)dstSizeResult.Height / 2.0f
                                );
                        }
                        break;

                    default:
                        {
                            //
                            // 左上座標優先
                            //

                            // 左上位置は変わっていないので、そのまま。

                            // 中心座標は、左上座標に「現在のサイズの半分サイズ」を足します。
                            this.MyCtOnBg = new PointF(
                                this.LtXOnBgOsz + (float)dstSizeResult.Width / 2.0f,
                                this.LtYOnBgOsz + (float)dstSizeResult.Height / 2.0f
                                );
                        }
                        break;
                }

                // 再計算
                foreach (Spritememo voSp in this.VoSpriteList)
                {
                    voSp.OnSpriteSizeChanged();
                }
            }
        }

        //────────────────────────────────────────

        protected bool bBorder;

        /// <summary>
        /// 枠線の有無。
        /// </summary>
        public bool BBorder
        {
            get
            {
                return bBorder;
            }
            set
            {
                bBorder = value;
            }
        }

        //────────────────────────────────────────

        protected bool bCross;

        /// <summary>
        /// 十字線の有無。
        /// </summary>
        public bool BCross
        {
            get
            {
                return bCross;
            }
            set
            {
                bCross = value;
            }
        }

        //────────────────────────────────────────

        protected float nOpaque;

        /// <summary>
        /// 乗せる画像の不透明度。0.0F～1.0F。
        /// </summary>
        public float NOpaque
        {
            get
            {
                return nOpaque;
            }
            set
            {
                nOpaque = value;
                // 画像が無かった時に表示する四角を塗りつぶすブラシの再計算。
                this.CalAltBrush();
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 画像が無かった時に表示する四角を塗りつぶすブラシ
        /// </summary>
        protected Brush altBrush;

        public Brush AltBrush
        {
            get
            {
                return altBrush;
            }
        }

        //────────────────────────────────────────

        protected PointF baseLocationOnBgOsz;

        /// <summary>
        /// base location on background original size.
        /// 
        /// スプライト画像の座標のオフセット。
        /// 倍角表示された画面上の座標ではなく、x1 倍でのサイズ。
        /// </summary>
        public PointF BaseLocationOnBgOsz
        {
            get
            {
                return baseLocationOnBgOsz;
            }
            set
            {
                baseLocationOnBgOsz = value;
            }
        }

        //────────────────────────────────────────

        protected PointF myLtOnBgOsz;

        /// <summary>
        /// my left top on background original size.
        /// 
        /// 背景画像上（on the background image）でのスプライトの点XY。
        /// 画像の左上(Left Top)を指している。
        /// 倍角表示された画面上の座標ではなく、x1 倍でのサイズ。
        /// </summary>
        public PointF MyLtOnBgOsz
        {
            get
            {
                return myLtOnBgOsz;
            }
            set
            {
                myLtOnBgOsz = value;
            }
        }

        //────────────────────────────────────────

        public float LtXOnBgOsz
        {
            get
            {
                return this.BaseLocationOnBgOsz.X + this.MyLtOnBgOsz.X;
            }
        }

        //────────────────────────────────────────

        public float LtYOnBgOsz
        {
            get
            {
                return this.BaseLocationOnBgOsz.Y + this.MyLtOnBgOsz.Y;
            }
        }

        //────────────────────────────────────────

        protected PointF myCtOnBg;

        /// <summary>
        /// 背景画像上（on the background image）でのスプライトの点XY。
        /// 画像の中心(CenTer)を指している。
        /// </summary>
        public PointF MyCtOnBg
        {
            get
            {
                return myCtOnBg;
            }
            set
            {
                myCtOnBg = value;

                // 再計算
                foreach (Spritememo voSp in this.VoSpriteList)
                {
                    voSp.OnSpriteLocationChanged();
                }
            }
        }

        public float CtXOnBg
        {
            get
            {
                return this.BaseLocationOnBgOsz.X + this.MyCtOnBg.X;
            }
        }

        public float CtYOnBg
        {
            get
            {
                return this.BaseLocationOnBgOsz.Y + this.MyCtOnBg.Y;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
