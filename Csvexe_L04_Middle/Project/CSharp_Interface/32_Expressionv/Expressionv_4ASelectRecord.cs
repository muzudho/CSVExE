using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table;//NFieldName

namespace Xenon.Middle
{
    public interface Expressionv_4ASelectRecord : Expression_Node_String
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// レコードセットを、名前を付けて一時記憶します。
        /// </summary>
        void Execute_SaveRecordset(Log_Reports log_Reports);

        /// <summary>
        /// レコードセットの一時記憶を、削除します。
        /// </summary>
        void RemoveRecordset(Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// field="" 属性。
        /// </summary>
        Expression_Node_String Expression_Field
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ｌｏｏｋｕｐ－ｖａｌｕｅ="" 属性。
        /// </summary>
        Expression_Node_String Expression_LookupVal
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// required="" 属性。
        /// </summary>
        Expression_Node_String Expression_Required
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ｆｒｏｍ="" 属性。
        /// </summary>
        Expression_Node_String Expression_From
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// storage="" 属性。
        /// </summary>
        Expression_Node_String Expression_Storage
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 属性。
        /// </summary>
        Expression_Node_String Expression_Description
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
