using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XmlToConf
{
    public interface XmlToConfigurationtree_V51_Config
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// X → S。
        /// </summary>
        /// <param name="sFpatha">絶対ファイルパス</param>
        /// <param name="memoryApplication"></param>
        /// <param name="log_Reports"></param>
        void XmlToConfigurationtree(
            string sFpatha,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
