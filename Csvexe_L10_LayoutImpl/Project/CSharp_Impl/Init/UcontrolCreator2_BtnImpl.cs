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
    /// ボタン
    /// </summary>
    public class UsercontrolCreator2_BtnImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolButton uctBtn = new UsercontrolButton();

            // 名前だけ初期設定 
            uctBtn.Expression_Name_Control = ec_FcName;
            uctBtn.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctBtn;
        }

        //────────────────────────────────────────
        #endregion



    }
}
