using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//Usercontrol

namespace Xenon.Layout
{
    /// <summary>
    /// エリアベース
    /// </summary>
    public class UsercontrolCreator2_AraImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolArea uctAra = new UsercontrolArea();

            // 名前だけ初期設定 
            uctAra.Expression_Name_Control = ec_FcName;
            uctAra.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctAra;
        }

        //────────────────────────────────────────
        #endregion



    }
}
