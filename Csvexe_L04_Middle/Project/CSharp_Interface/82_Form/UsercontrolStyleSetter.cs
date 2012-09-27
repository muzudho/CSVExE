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
    public interface UsercontrolStyleSetter
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// コントロールに、スタイルを設定。
        /// </summary>
        void SetupStyle(
            TableUserformconfig fo_Config,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
