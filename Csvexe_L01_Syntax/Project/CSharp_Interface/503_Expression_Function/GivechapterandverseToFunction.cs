using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{

    /// <summary>
    /// 
    /// </summary>
    public interface GivechapterandverseToFunction
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s_Action"></param>
        /// <param name="bRequired"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        Expression_Node_Function Translate(
            Givechapterandverse_Node systemFunction_Gcav,
            bool bRequired,
            Log_Reports log_Reports
        );

        //────────────────────────────────────────
        #endregion



    }
}
