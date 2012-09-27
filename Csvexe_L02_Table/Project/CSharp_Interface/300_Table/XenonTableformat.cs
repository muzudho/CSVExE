﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Table
{

    /// <summary>
    /// テーブルの行列が逆になっているなどの、設定。
    /// (table format)
    /// </summary>
    public interface XenonTableformat
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 行と列がひっくり返っている（左から右へレコードが並んでいる）なら真。
        /// 
        /// 通常（上から下へレコードが並んでいる）なら偽。
        /// (フィールド名：ROW_COL_REV)
        /// </summary>
        bool BRowcolumnreverse
        {
            get;
            set;
        }

        /// <summary>
        /// 型定義のレコード（intやboolやstringが書いてあるところ）がなく、全フィールドがint型のテーブルの場合、真。
        /// （フィールド名：ALL_INT_FIELDS）
        /// </summary>
        bool BAllintfields
        {
            get;
            set;
        }

        /// <summary>
        /// 行の末尾を「,」で終える場合、真。
        /// （フィールド名：COMMA_ENDING）
        /// </summary>
        bool BCommaending
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
