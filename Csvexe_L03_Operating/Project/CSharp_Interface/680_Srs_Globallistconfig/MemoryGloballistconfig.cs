using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Operating
{
    /// <summary>
    /// グローバルリスト コンフィグ モデル
    /// 
    /// (Model Of Global List Config)
    /// </summary>
    public interface MemoryGloballistconfig
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 担当者名を全て返します。
        /// </summary>
        /// <returns></returns>
        List<string> GetNameHumans();

        /// <summary>
        /// 指定の番号の変数について、担当者が複数いたとき、どの担当者が優先されるかを調べます。
        /// </summary>
        /// <param name="sType">例：[I]</param>
        /// <param name="sNumber">例：970</param>
        /// <param name="sHumans">例：「太郎 | 二郎 | 三郎」</param>
        /// <param name="log_Reports">エラー処理オブジェクト</param>
        /// <returns>担当者名</returns>
        string SearchHuman(string sType, string sNumber, string sHumans, Log_Reports log_Reports);

        /// <summary>
        /// 変数の型セクションのリスト。
        /// </summary>
        GloballistconfigTypesectionList TypesectionList
        {
            get;
        }

        /// <summary>
        /// human要素のリスト。
        /// </summary>
        Dictionary<string, GloballistconfigHuman> Dictionary_Human
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
