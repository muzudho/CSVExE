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
    /// ラベル
    /// </summary>
    public class UsercontrolCreator2_LblImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolLabel uctLbl = new UsercontrolLabel();

            // 名前だけ初期設定 
            uctLbl.Expression_Name_Control = ec_FcName;
            uctLbl.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctLbl;
        }

        //────────────────────────────────────────
        #endregion



    }
}
