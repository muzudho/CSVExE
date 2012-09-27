using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// human/variable要素
    /// </summary>
    public interface GloballistconfigVariable
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 型。
        /// </summary>
        string SType
        {
            set;
            get;
        }

        /// <summary>
        /// number要素のリスト。
        /// </summary>
        Dictionary<string, GloballistconfigNumber> Dictionary_Number
        {
            get;
        }

        //────────────────────────────────────────
        #endregion

    
    
    }
}
