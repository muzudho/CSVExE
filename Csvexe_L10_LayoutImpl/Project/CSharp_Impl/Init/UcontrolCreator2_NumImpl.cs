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
    /// 数上下ボックス
    /// </summary>
    public class UsercontrolCreator2_NumImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolNumericUpDown uctNum = new UsercontrolNumericUpDown();

            // 名前だけ初期設定 
            uctNum.Expression_Name_Control = ec_FcName;
            uctNum.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctNum;
        }

        //────────────────────────────────────────
        #endregion



    }
}
