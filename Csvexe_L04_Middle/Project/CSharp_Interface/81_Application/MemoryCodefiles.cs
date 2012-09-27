using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{
    public interface MemoryCodefiles
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

        void Add(
            MemoryCodefileinfo moCodefileInfo,
            Log_Reports log_Reports
            );

        /// <summary>
        /// コード・ファイル情報を返します。TYPE_DATA値を指定してください。
        /// </summary>
        /// <param select="nTableName"></param>
        /// <param select="bRequired">該当しなかった場合にエラー扱いなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        List<MemoryCodefileinfo> GetCodefileinfoByTypedata(
            Expression_Node_String ec_Typedata,
            bool bRequired,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// コードファイルの行データの連想配列。
        /// </summary>
        Dictionary<string, MemoryCodefileinfo> Dictionary_Table
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
