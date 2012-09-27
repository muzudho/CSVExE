using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{

    /// <summary>
    /// 各種ビューでの、入力受取。
    /// </summary>
    public interface Gamepadmainloop_Receipt_View
    {



        #region アクション
        //────────────────────────────────────────
        
        void Perform(Gamepadmainloop mainloop);

        //────────────────────────────────────────
        #endregion



    }
}
