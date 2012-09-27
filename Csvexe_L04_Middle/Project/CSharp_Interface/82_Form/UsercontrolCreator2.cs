using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// 1と2がある。
    /// 旧名：FcCreator
    /// </summary>
    public interface UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        Usercontrol Perform(
            Expression_Node_StringImpl expr_Name_Ucontrol,
            MemoryApplication memoryApplication
            );

        //────────────────────────────────────────
        #endregion



    }
}
