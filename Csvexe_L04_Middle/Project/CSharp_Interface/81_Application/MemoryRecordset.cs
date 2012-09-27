using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//Form

using Xenon.Syntax;//N_FilePath

namespace Xenon.Middle
{

    /// <summary>
    /// 
    /// </summary>
    public interface MemoryRecordset
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// レコードセットの一時記憶。
        /// </summary>
        RecordsetStorage RecordsetStorage
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }

}
