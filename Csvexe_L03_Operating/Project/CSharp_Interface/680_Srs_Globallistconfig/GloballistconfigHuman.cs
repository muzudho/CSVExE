using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// human要素
    /// </summary>
    public interface GloballistconfigHuman
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 名前。
        /// </summary>
        string SName
        {
            set;
            get;
        }

        /// <summary>
        /// variable要素のリスト。
        /// </summary>
        Dictionary<string, GloballistconfigVariable> Dictionary_Variable
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
