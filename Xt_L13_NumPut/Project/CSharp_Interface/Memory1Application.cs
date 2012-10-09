using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.NumPut
{
    public interface Memory1Application
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 番号スプライトのリスト。
        /// </summary>
        Memory2ProjectImpl MoProject
        {
            get;
            set;
        }

        Form1 Form1
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
