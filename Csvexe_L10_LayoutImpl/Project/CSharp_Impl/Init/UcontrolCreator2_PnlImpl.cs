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
    /// パネル
    /// </summary>
    public class UsercontrolCreator2_PnlImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolPanel uctPnl = new UsercontrolPanel();

            // 名前だけ初期設定 
            uctPnl.Expression_Name_Control = ec_FcName;
            uctPnl.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctPnl;
        }

        //────────────────────────────────────────
        #endregion



    }
}
