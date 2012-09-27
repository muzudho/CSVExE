using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    public interface GivechapterandverseToExpression_F14n16 : GivechapterandverseToExpression
    {



        #region アクション
        //────────────────────────────────────────

        void Translate(
            Givechapterandverse_Node cur_Cf,
            Expression_Node_String parent_Expr,
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
