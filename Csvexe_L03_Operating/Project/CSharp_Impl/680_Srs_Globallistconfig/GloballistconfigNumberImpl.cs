using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Table;//Int_HumaninputImpl

namespace Xenon.Operating
{
    /// <summary>
    /// human/variable/number 要素
    /// </summary>
    public class GloballistconfigNumberImpl : GloballistconfigNumber
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public GloballistconfigNumberImpl()
        {
            this.sRange = "";
            this.priority = new Int_HumaninputImpl("!ハードコーディング_MoGlConfigImpl");
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected string sRange;

        /// <summary>
        /// 番号の範囲指定。
        /// </summary>
        public string Text_Range
        {
            set
            {
                sRange = value;
            }
            get
            {
                return sRange;
            }
        }

        //────────────────────────────────────────

        protected Int_HumaninputImpl priority;

        /// <summary>
        /// 優先度。
        /// </summary>
        public Int_HumaninputImpl Priority
        {
            set
            {
                priority = value;
            }
            get
            {
                return priority;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
