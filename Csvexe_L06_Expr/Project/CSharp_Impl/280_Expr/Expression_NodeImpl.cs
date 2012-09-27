using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Expr
{

    /// <summary>
    /// 【追加 2012-06-19】
    /// </summary>
    public class Expression_NodeImpl : Expression_Node_StringImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param oVariableName="moOpyopyo"></param>
        public Expression_NodeImpl(Expression_Node_String e_ParentNode, Givechapterandverse_Node s_ParentNode, MemoryApplication owner_MemoryApplication)
            : base(e_ParentNode, s_ParentNode)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// アプリケーション・モデル。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return owner_MemoryApplication;
            }
            set
            {
                owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
