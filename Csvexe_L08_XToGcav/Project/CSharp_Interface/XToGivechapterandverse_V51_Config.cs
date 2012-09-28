using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XToGcav
{
    public interface XToGivechapterandverse_V51_Config
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// X → S。
        /// </summary>
        /// <param name="sFpatha">絶対ファイルパス</param>
        /// <param name="memoryApplication"></param>
        /// <param name="log_Reports"></param>
        void XToGivechapterandverse(
            string sFpatha,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
