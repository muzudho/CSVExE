using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table;//RequestOfTableRead


namespace Xenon.Middle
{

    /// <summary>
    /// X→M。
    /// </summary>
    public interface XToMemory_Form
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『ユーザーフォーム設定ファイル』を読取ります。
        /// </summary>
        void LoadUserformconfigFile(
            TableUserformconfig ufoConfig,
            Table_Humaninput xenonTable_Form,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
