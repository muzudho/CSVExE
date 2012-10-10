using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table; //DefaultTable

namespace Xenon.Middle
{
    public interface MemoryTables
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        void Clear(MemoryApplication owner_MemoryApplication);

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// テーブルを、コレクションに追加します。
        /// </summary>
        /// <param name="oTable"></param>
        void AddTableHumaninput(
            TableHumaninput xenonTable,
            Log_Reports log_Reports
            );

        /// <summary>
        /// テーブルを返します。
        /// </summary>
        /// <param name="nTableName"></param>
        /// <param name="bRequired">該当しなかった場合に警告表示を行うなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        TableHumaninput GetTableHumaninputByName(
            Expression_Node_String ec_NameTable,
            bool bRequired,
            Log_Reports log_Reports
            );

        /// <summary>
        /// テーブルを返します。NAME_FORM列値を指定してください。
        /// </summary>
        /// <param select="nTableName"></param>
        /// <param select="bRequired">該当しなかった場合にエラー扱いなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        List<TableHumaninput> GetTableHumaninputByFormgroup(
            Expression_Node_String ec_Formgroup,
            bool bRequired,
            Log_Reports log_Reports
            );

        /// <summary>
        /// テーブルを返します。レイアウト_グループ名を指定してください。
        /// </summary>
        /// <param select="nTableName"></param>
        /// <param select="bRequired">該当しなかった場合にエラー扱いなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        List<TableHumaninput> GetTableHumaninputByTypedata(
            Expression_Node_String expr_KeyExpected,
            bool bRequired,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// テーブルの、名前付き一覧。
        /// </summary>
        Dictionary<string, TableHumaninput> Dictionary_TableHumaninput
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
