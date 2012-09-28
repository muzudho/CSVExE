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
    /// ドロップ・ダウン・リスト・ボックス
    /// </summary>
    public class UsercontrolCreator2_DdlImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolCombobox uctDdl = new UsercontrolCombobox();

            // 名前だけ初期設定 
            uctDdl.Expression_Name_Control = ec_FcName;
            uctDdl.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctDdl;
        }

        //────────────────────────────────────────
        #endregion



    }
}
