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
        public XenonNameImpl(Configurationtree_Node owner_Configurationtree)
        {
            this.sValue = "";
            this.cur_Configurationtree = owner_Configurationtree;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param select="nValue"></param>
        /// <param select="s_OwnerNode"></param>
        public XenonNameImpl(string sValue, Configurationtree_Node owner_Configurationtree)
        {
            this.sValue = sValue;
            this.cur_Configurationtree = owner_Configurationtree;
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

        private Configurationtree_Node cur_Configurationtree;

        /// <summary>
        /// 
        /// </summary>
        public Configurationtree_Node Cur_Configurationtree
        {
            get
            {
                return cur_Configurationtree;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
