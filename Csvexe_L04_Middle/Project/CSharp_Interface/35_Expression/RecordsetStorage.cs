using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Middle
{
    public interface RecordsetStorage
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// レコードセットの追加。
        /// </summary>
        /// <param name="eName"></param>
        /// <param name="recordSet"></param>
        /// <param name="log_Reports"></param>
        void Add(Expression_Node_String ec_Name, RecordSet recordSet,
            MemoryApplication memoryApplication, 
            Log_Reports log_Reports);

        /// <summary>
        /// レコードセットの取得。
        /// </summary>
        /// <param name="eName"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        RecordSet Get(Expression_Node_String ec_Name,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports);

        /// <summary>
        /// レコードセットの削除。
        /// </summary>
        /// <param name="eName"></param>
        /// <param name="log_Reports"></param>
        void Remove(Expression_Node_String ec_Name,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 有無。
        /// </summary>
        /// <param name="nName"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        bool Contains(Expression_Node_String ec_Name, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



    }
}
