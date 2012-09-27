using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// validation設定ファイルの、＜f-listbox-validation＞。
    /// </summary>
    public interface Expressionv_3FListboxValidation : Expressionv_Elem99
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ＜a-select-record＞要素のリスト。
        /// </summary>
        List<Expressionv_4ASelectRecord> List_Expressionv_ASelectRecord
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ＜a-display＞要素のリスト。
        /// </summary>
        List<Expressionv_4ADisplay> List_Expressionv_ADisplay
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
