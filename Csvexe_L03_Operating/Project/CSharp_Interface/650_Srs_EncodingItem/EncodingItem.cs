using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    public interface EncodingItem
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 表示文字列。
        /// </summary>
        string SDisplay
        {
            set;
            get;
        }

        /// <summary>
        /// エンコーディング。
        /// </summary>
        Encoding Encoding
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion

    
    
    }
}
