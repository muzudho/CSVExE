using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Table;//XenonValue_IntImpl

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
            this.priority = new XenonValue_IntImpl("!ハードコーディング_MoGlConfigImpl");
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

        protected XenonValue_IntImpl priority;

        /// <summary>
        /// 優先度。
        /// </summary>
        public XenonValue_IntImpl Priority
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
