using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.GridPanel
{

    /// <summary>
    /// グリッド エリアのコレクション。
    /// 
    /// (Model Of Grid Areas)
    /// </summary>
    public interface MemoryGrids
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 空の状態に設定します。
        /// </summary>
        void Clear();

        /// <summary>
        /// グリッド領域を追加します。（エラー対応処理付き）
        /// </summary>
        /// <param name="sName_GridArea"></param>
        /// <param name="gridArea"></param>
        /// <param name="log_Reports"></param>
        void Add(
            string sName_GridArea,
            Grid gridArea,
            Log_Reports log_Reports,
            string sLogStack
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// グリッド領域。
        /// </summary>
        Dictionary<string, Grid> Dictionary_Item
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
