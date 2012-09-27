using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// human/variable要素
    /// </summary>
    public class GloballistconfigVariableImpl : GloballistconfigVariable
    {


        
        #region 生成と破棄
        //────────────────────────────────────────

        public GloballistconfigVariableImpl()
        {
            this.type = "";
            this.dictionary_Number = new Dictionary<string, GloballistconfigNumber>();
        }

        //────────────────────────────────────────
        #endregion




        #region プロパティー
        //────────────────────────────────────────

        protected string type;

        /// <summary>
        /// 型。
        /// </summary>
        public string SType
        {
            set
            {
                type = value;
            }
            get
            {
                return type;
            }
        }

        //────────────────────────────────────────

        protected Dictionary<string, GloballistconfigNumber> dictionary_Number;

        /// <summary>
        /// number要素のリスト。
        /// </summary>
        public Dictionary<string, GloballistconfigNumber> Dictionary_Number
        {
            get
            {
                return dictionary_Number;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
