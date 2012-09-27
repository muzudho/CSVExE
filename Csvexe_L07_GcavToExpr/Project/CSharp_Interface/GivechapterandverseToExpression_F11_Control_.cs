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
    interface GivechapterandverseToExpression_F11_Control_ : GivechapterandverseToExpression
    {



        #region アクション
        //────────────────────────────────────────

        void Translate(
            Givechapterandverse_Node cur_Gcav,
            Expression_Node_String cur_Expr,
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
