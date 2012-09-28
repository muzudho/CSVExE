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
    /// タブ ペーン
    /// </summary>
    public class UsercontrolCreator2_TbpImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolTabPane uctTbp = new UsercontrolTabPane();

            // 名前だけ初期設定
            uctTbp.Expression_Name_Control = ec_FcName;
            uctTbp.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctTbp;
        }

        //────────────────────────────────────────
        #endregion



    }
}
