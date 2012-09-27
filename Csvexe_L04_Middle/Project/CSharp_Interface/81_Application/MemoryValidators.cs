using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{
    public interface MemoryValidators
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// クリアーします。
        /// </summary>
        void Clear();

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 妥当性判定のグローバル設定ファイルの読取り。
        /// </summary>
        /// <param name="sFpatha">絶対ファイルパス</param>
        /// <param name="log_Reports"></param>
        void LoadFile(
            string sFpatha,
            MemoryApplication owner_MoApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// バリデーション設定ファイル。
        /// </summary>
        Givechapterandverse_Node Givechapterandverse_Validatorsconfig
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
