using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XToGcav
{
    public interface XToGivechapterandverse_C11_Config
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// X→S。
        /// 
        /// コントロール名と、設定ファイルパスが指定されるので、
        /// 検索して、設定。
        /// </summary>
        /// <param name="sFcName"></param>
        /// <param name="sFpathH_F">絶対ファイルパス（F）手入力</param>
        /// <param name="sFpatha_F">絶対ファイルパス（F）</param>
        /// <param name="s_FcConfig"></param>
        /// <param name="oFormsFolderPath"></param>
        /// <param name="owner_MemoryApplication"></param>
        /// <param name="log_Reports"></param>
        void XToGivechapterandverse(
            string sName_Control,
            string sFpathH_F,
            string sFpatha_F,
            Givechapterandverse_Node cf_FcConfig,
            Expression_Node_Filepath ec_Fopath_Forms,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
