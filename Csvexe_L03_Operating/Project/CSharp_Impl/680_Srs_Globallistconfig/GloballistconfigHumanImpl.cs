using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// human要素
    /// </summary>
    public class GloballistconfigHumanImpl : GloballistconfigHuman
    {

        

        #region 生成と破棄
        //────────────────────────────────────────

        public GloballistconfigHumanImpl()
        {
            this.variableDictionary = new Dictionary<string, GloballistconfigVariable>();
        }

        //────────────────────────────────────────
        #endregion


        
        #region プロパティー
        //────────────────────────────────────────

        protected string name;

        /// <summary>
        /// 名前。
        /// </summary>
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        //────────────────────────────────────────

        protected Dictionary<string, GloballistconfigVariable> variableDictionary;

        /// <summary>
        /// variable要素のリスト。
        /// </summary>
        public Dictionary<string, GloballistconfigVariable> Dictionary_Variable
        {
            get
            {
                return variableDictionary;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
