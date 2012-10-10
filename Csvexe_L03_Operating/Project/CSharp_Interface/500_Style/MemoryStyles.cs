using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Operating
{

    /// <summary>
    /// スタイル一覧。
    /// </summary>
    public interface MemoryStyles
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        /// <param name="log_Reports"></param>
        void Clear(Log_Reports log_Reports);

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        /// <param name="o_Table_StyleSheet"></param>
        /// <param name="log_Reports"></param>
        void Clear(TableHumaninput xenonTable_Stylesheet, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// スタイル属性のリスト。
        /// 
        /// キー：IDフィールド値
        /// 値：STYLEフィールド値
        /// </summary>
        Dictionary<string, RecordXenonStyle> Dictionary_RecordStyle
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
