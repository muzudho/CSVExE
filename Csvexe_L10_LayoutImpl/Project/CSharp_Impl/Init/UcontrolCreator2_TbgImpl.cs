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
    /// タブ ページ
    /// </summary>
    public class UsercontrolCreator2_TbgImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolTabPage uctTpg = new UsercontrolTabPage();

            // 名前だけ初期設定
            uctTpg.Expression_Name_Control = ec_FcName;
            uctTpg.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctTpg;
        }

        //────────────────────────────────────────
        #endregion



    }
}
