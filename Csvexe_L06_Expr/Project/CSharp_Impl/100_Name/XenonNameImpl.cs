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
        public XenonNameImpl(Givechapterandverse_Node owner_Givechapterandverse)
        {
            this.sValue = "";
            this.cur_Givechapterandverse = owner_Givechapterandverse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param select="nValue"></param>
        /// <param select="s_OwnerNode"></param>
        public XenonNameImpl(string sValue, Givechapterandverse_Node owner_Givechapterandverse)
        {
            this.sValue = sValue;
            this.cur_Givechapterandverse = owner_Givechapterandverse;
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

        private Givechapterandverse_Node cur_Givechapterandverse;

        /// <summary>
        /// 
        /// </summary>
        public Givechapterandverse_Node Cur_Givechapterandverse
        {
            get
            {
                return cur_Givechapterandverse;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
