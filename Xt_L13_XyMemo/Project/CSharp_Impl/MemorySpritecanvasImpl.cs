using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.XyMemo
{
    public class MemorySpritecanvasImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemorySpritecanvasImpl()
        {
            this.scale = 1;
            this.preScale = 1;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected float scale;

        /// <summary>
        /// 拡大率。
        /// </summary>
        public float ScaleImg
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }

        //────────────────────────────────────────

        protected float preScale;

        /// <summary>
        /// 変更前の拡大率。
        /// </summary>
        public float PreScale
        {
            get
            {
                return preScale;
            }
            set
            {
                preScale = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
