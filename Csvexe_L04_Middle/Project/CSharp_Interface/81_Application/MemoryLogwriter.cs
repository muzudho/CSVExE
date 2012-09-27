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
    public interface MemoryLogwriter
    {

        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// エラーログを出力します。（エラーが発生したときに呼び出してください）
        /// </summary>
        /// <param name="memoryApplication"></param>
        /// <param name="log_Reports_Output"></param>
        /// <param name="sLogStack">このメソッドが呼び出された場所が分かるようなヒント。</param>
        void WriteErrorLog(
            MemoryApplication memoryApplication,
            Log_Reports log_Reports_Output,
            string sLogStack
                );

        //────────────────────────────────────────
        #endregion

    }



}
