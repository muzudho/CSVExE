using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.NumPut
{
    public interface Memory2Project
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 操作モード。
        /// </summary>
        Memory3Operationmode MoOperationMode
        {
            get;
            set;
        }

        //────────────────────────────────────────

        Memory3Contents MoContents
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
