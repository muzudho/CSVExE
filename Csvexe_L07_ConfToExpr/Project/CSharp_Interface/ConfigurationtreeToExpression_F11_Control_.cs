using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.ConfToExpr
{


    /// <summary>
    /// 
    /// </summary>
    interface ConfigurationtreeToExpression_F11_Control_ : ConfigurationtreeToExpression
    {



        #region アクション
        //────────────────────────────────────────

        void Translate(
            Configurationtree_Node cur_Conf,
            Expression_Node_String cur_Expr,
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
