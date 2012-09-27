using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    public class GloballistconfigTypesectionImpl : GloballistconfigTypesection
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public GloballistconfigTypesectionImpl()
        {
            this.sType = "";
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected string sType;

        /// <summary>
        /// 型名。
        /// </summary>
        public string SType
        {
            get
            {
                return sType;
            }
            set
            {
                sType = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
