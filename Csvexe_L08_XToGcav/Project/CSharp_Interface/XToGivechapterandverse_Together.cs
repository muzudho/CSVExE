using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XToGcav
{

    /// <summary>
    /// X→S　トゥゲザー登録ファイル
    /// </summary>
    public interface XToConfigurationtree_Together
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ファイルから内容を読み込んでモデルに挿入
        /// </summary>
        /// <param name="sFpatha">絶対ファイルパス</param>
        /// <param name="log_Reports"></param>
        /// <returns>トゥゲザー設定。</returns>
        Configurationtree_Node XToConfigurationtree(
            string sFpatha,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
