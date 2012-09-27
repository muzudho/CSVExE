using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// GlobalList.txtの1行分のモデル。
    /// 
    /// (Model Of Global List Line)
    /// </summary>
    public interface MemoryGloballistLine
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 変数の型の名前。例：[I]
        /// </summary>
        string SType
        {
            get;
        }

        /// <summary>
        /// 変数の番号。
        /// </summary>
        int NNumber
        {
            get;
        }

        /// <summary>
        /// テキスト。
        /// </summary>
        string SText
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
