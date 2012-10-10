using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Table;//IntCellData

namespace Xenon.Operating
{
    /// <summary>
    /// human/varialbe/number要素
    /// </summary>
    public interface GloballistconfigNumber
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 番号の範囲指定。
        /// </summary>
        string Text_Range
        {
            set;
            get;
        }

        /// <summary>
        /// 優先度。
        /// </summary>
        Int_HumaninputImpl Priority
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion

    
    
    }
}
