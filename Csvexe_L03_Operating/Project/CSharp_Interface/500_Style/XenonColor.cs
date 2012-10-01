using System;
using System.Collections.Generic;
using System.Drawing;//Color
using System.Linq;
using System.Text;

namespace Xenon.Operating
{

    /// <summary>
    /// カラー。
    /// </summary>
    public interface XenonColor
    {



        #region プロパティー
        //────────────────────────────────────────

        Color Color
        {
            set;
            get;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 前景色の名前。
        /// </summary>
        string Name_Color
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }

}
