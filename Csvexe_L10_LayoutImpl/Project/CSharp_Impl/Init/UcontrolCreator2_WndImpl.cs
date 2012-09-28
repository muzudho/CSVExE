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
    /// ウィンドウ
    /// </summary>
    public class UsercontrolCreator2_WndImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolWindow uctWnd = new UsercontrolWindow();

            // 名前だけ初期設定
            uctWnd.Expression_Name_Control = ec_FcName;
            uctWnd.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;
            uctWnd.CustomcontrolWindow1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;//.CenterParent;

            return uctWnd;
        }

        //────────────────────────────────────────
        #endregion



    }
}
