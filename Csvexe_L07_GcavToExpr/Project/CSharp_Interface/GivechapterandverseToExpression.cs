using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{


    /// <summary>
    /// 
    /// </summary>
    public interface GivechapterandverseToExpression
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s_Cur"></param>
        /// <param name="e_Parent"></param>
        /// <param name="memoryApplication"></param>
        /// <param name="d_ParsingLog"></param>
        /// <param name="log_Reports"></param>
        void ParseChild_InGivechapterandverseToExpression(
            Givechapterandverse_Node cur_Gcav,
            Expression_Node_String parent_Expr,//nAcase,nFelemの両方の場合がある。Expression_Node_StringImpl
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
