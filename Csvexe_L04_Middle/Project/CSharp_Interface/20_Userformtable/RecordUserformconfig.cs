using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//HumanInputFilePath

namespace Xenon.Middle
{
    /// <summary>
    /// 『ユーザーフォーム設定ファイル』の１レコードに相当。
    /// 
    /// コントロール１個分のレイアウト用データ。
    /// </summary>
    public interface RecordUserformconfig
    {



        #region アクション
        //────────────────────────────────────────

        void Set(string sName, EnumTypedb enum_Typedb, object value, Log_Reports log_Reports);

        void TryGetInt(out int out_NValue, string sName, bool bRequired, int nAlt, Log_Reports log_Reports);

        void TryGetString(out string out_SValue, string sName, bool bRequired, string nAlt, Log_Reports log_Reports);

        void TryGetBool(out bool out_BValue, string sName, Log_Reports log_Reports);

        void TryGetFilepath_Configurationtree(out Configurationtree_NodeFilepath out_BValue, string sName, bool bRequired, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        Dictionary<string, FieldUserformtable> Dictionary_Field
        {
            get;
        }

        /// <summary>
        /// 親要素。
        /// </summary>
        TableUserformconfig Parent_TableUserformconfig
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
