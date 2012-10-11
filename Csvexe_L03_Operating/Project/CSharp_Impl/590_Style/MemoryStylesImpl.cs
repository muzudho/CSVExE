using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Operating
{
    /// <summary>
    /// CSVで記述したスタイルシートから内容を読み取った結果です。
    /// </summary>
    public class MemoryStylesImpl : MemoryStyles
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryStylesImpl()
        {
            this.Dictionary_RecordStyle = new Dictionary<string, RecordXenonStyle>();
        }

        //────────────────────────────────────────

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        /// <param name="log_Reports"></param>
        public void Clear( Log_Reports log_Reports)
        {
            this.Dictionary_RecordStyle.Clear();
        }

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        /// <param name="o_Table_StyleSheet"></param>
        /// <param name="log_Reports"></param>
        public void Clear(Table_Humaninput xenonTable_Stylesheet, Log_Reports log_Reports)
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Operating.Name_Library, this, "Clear",log_Reports);

            //
            //

            this.Dictionary_RecordStyle.Clear();

            MemoryToMemory_Stylesheet mToO = new MemoryToMemory_Stylesheet();
            MemoryStyles moStyles = mToO.Translate(xenonTable_Stylesheet, log_Reports);

            foreach (KeyValuePair<string, RecordXenonStyle> kvp in moStyles.Dictionary_RecordStyle)
            {
                this.Dictionary_RecordStyle.Add(kvp.Key, kvp.Value);
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, RecordXenonStyle> dictionary_RecordStyle;

        /// <summary>
        /// スタイル属性のリスト。
        /// </summary>
        public Dictionary<string, RecordXenonStyle> Dictionary_RecordStyle
        {
            set
            {
                dictionary_RecordStyle = value;
            }
            get
            {
                return dictionary_RecordStyle;
            }
        }

        //────────────────────────────────────────
        #endregion



    }

}
