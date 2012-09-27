using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{


    /// <summary>
    /// 指定値を、テーブルに書き込みます。
    /// </summary>
    public interface ToMemory_Performer
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// このデータ_ソース（データ_ターゲット）に指定されている場所へ、値をセットします。
        /// </summary>
        /// <returns>成功すれば真。</returns>
        void ToMemory(
            string sOutputValue,
            Expression_Node_String ec_Control,//「E■ｆｏｒｍ－ｃｏｍｐｏｎｅｎｔ」相当。
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        void ToMemory_ParentFcells(
            string sOutputValue,
            Expression_Node_String parent_Expr_Fcells,//「E■ｆ－ｃｅｌｌ」要素のリストを持った親要素。
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        void ToMemory_DataTargetFcell(
            string sOutputValue,
            Expression_Node_String ec_DataTargetFcell,//「E■ｆ－ｃｅｌｌ」相当。
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
