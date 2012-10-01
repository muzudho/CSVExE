using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    interface ConfigurationtreeToExpression_F12_ : ConfigurationtreeToExpression
    {



        #region アクション
        //────────────────────────────────────────

        void Translate(
            Configurationtree_Node cur_Gcav,//＜ｄａｔａ＞要素
            Expression_Node_String cur_Expr,//＜ｄａｔａ＞Expression_Node_StringImpl
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
