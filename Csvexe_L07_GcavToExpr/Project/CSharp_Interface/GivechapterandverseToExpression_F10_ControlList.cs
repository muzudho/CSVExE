using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    public interface ConfigurationtreeToExpression_F10_ControlList : ConfigurationtreeToExpression
    {



        #region アクション
        //────────────────────────────────────────

        void Translate(
            List<string> sList_Name_Control,
            Configurationtree_Node cf_FcConfig,
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
