using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    public interface GivechapterandverseToExpression_F10_ControlList : GivechapterandverseToExpression
    {



        #region アクション
        //────────────────────────────────────────

        void Translate(
            List<string> sList_Name_Control,
            Givechapterandverse_Node cf_FcConfig,
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
