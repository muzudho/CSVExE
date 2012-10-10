using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table;//DefaultTable

namespace Xenon.Middle
{

    /// <summary>
    /// T → M。
    /// </summary>
    public interface ToMemory_Cell
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// </summary>
        /// <param name="outputValueStr"></param>
        /// <param name="nFcell"></param>
        /// <param name="row"></param>
        /// <param name="selectedFldDefinition">選択フィールド</param>
        /// <param name="log_Reports"></param>
        void ToMemory_ToSelectedField(
            string sValue_Output,
            Expression_Node_String expression_Fcell,
            DataRow row,
            Fielddefinition selectedFldDefinition,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
