using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{
    public interface Remover_AllEventhandlers
    {



        #region アクション
        //────────────────────────────────────────

        void Resume(
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 全てのイベントハンドラーを削除します。
        /// </summary>
        void Suppress(
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
