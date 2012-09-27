using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{
    /// <summary>
    /// 検索でヒットして欲しい件数を区分にしたもの。
    /// </summary>
    public enum EnumHitcount
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// 特に決めない。
        /// </summary>
        Unconstraint,

        /// <summary>
        /// 必ず1つのみ。複数件ヒットはエラー。
        /// </summary>
        One,

        /// <summary>
        /// 最初の1つを選択。存在しない場合、エラー。複数件あっても2つ目以降は無視。
        /// </summary>
        First_Exist,

        /// <summary>
        /// 最初の1つを選択。存在しない場合、空っぽリスト。複数件あっても2つ目以降は無視。
        /// </summary>
        First_Exist_Or_Zero,

        /// <summary>
        /// 1つ以上、複数。
        /// </summary>
        Exists,

        /// <summary>
        /// 1件該当するか、または存在しないのどちらか。複数件ヒットはエラー。
        /// </summary>
        One_Or_Zero

        //────────────────────────────────────────
        #endregion



    }
}
