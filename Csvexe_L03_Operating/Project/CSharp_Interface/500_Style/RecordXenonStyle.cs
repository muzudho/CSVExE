using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// スタイル属性1件分の記述と、テーブル上のID。
    /// </summary>
    public interface RecordXenonStyle
    {

        
        
        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// テーブル上のID。
        /// </summary>
        string Id
        {
            set;
            get;
        }

        /// <summary>
        /// スタイル属性1件分の記述。
        /// </summary>
        string Style
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
