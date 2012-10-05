using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.ConfToExpr
{
    public interface ConfigurationtreeToExpression_F14n16 : ConfigurationtreeToExpression
    {



        #region アクション
        //────────────────────────────────────────

        void Translate(
            Configurationtree_Node cur_Cf,
            Expression_Node_String parent_Expr,
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
