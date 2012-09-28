using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//Log_Reports
using Xenon.Controls;
using Xenon.Middle;//Usercontrol

namespace Xenon.Layout
{
    /// <summary>
    /// チェックボックス
    /// </summary>
    public class UsercontrolCreator2_ChkImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolCheckbox uctChk = new UsercontrolCheckbox();

            // 名前だけ初期設定 
            uctChk.ControlCommon.Expression_Name_Control = ec_FcName;
            uctChk.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctChk;
        }

        //────────────────────────────────────────
        #endregion



    }
}
