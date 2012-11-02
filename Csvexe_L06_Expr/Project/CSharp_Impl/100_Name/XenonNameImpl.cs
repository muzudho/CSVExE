using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;

namespace Xenon.Expr
{

    /// <summary>
    /// 名前。 GetElementByName(s_name)のような引数として使う。
    /// </summary>
    public class XenonNameImpl : XenonName
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public XenonNameImpl(Configuration_Node owner_Configuration)
        {
            this.sValue = "";
            this.cur_Configuration = owner_Configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param select="nValue"></param>
        /// <param select="s_OwnerNode"></param>
        public XenonNameImpl(string sValue, Configuration_Node owner_Configuration)
        {
            this.sValue = sValue;
            this.cur_Configuration = owner_Configuration;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sValue;

        /// <summary>
        /// 名前の文字列。
        /// </summary>
        public string SValue
        {
            get
            {
                return sValue;
            }
        }

        //────────────────────────────────────────

        private Configuration_Node cur_Configuration;

        /// <summary>
        /// 
        /// </summary>
        public Configuration_Node Cur_Configuration
        {
            get
            {
                return cur_Configuration;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
