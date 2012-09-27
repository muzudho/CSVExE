using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    public interface GivechapterandverseToExpression_V51_Config : GivechapterandverseToExpression
    {


        
        #region アクション
        //────────────────────────────────────────

        void Translate(
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
