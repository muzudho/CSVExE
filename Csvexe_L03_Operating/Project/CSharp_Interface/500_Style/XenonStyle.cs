using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// スタイル・モデル。
    /// </summary>
    public interface XenonStyle
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 前景色。設定されていなければヌル。
        /// 
        /// 旧名：MoColor
        /// </summary>
        /// <returns></returns>
        XenonColor ForeColor
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
