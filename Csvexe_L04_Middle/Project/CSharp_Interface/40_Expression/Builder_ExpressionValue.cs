using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    ///
    /// </summary>
    public interface Builder_ExpressionValue
    {



        #region アクション
        //────────────────────────────────────────

        Expression_Node_String build(
            string sValue,
            Givechapterandverse_Node parent_Gcav,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
