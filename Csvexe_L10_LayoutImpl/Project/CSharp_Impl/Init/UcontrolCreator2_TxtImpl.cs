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
    /// テキストボックス
    /// </summary>
    public class UsercontrolCreator2_TxtImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {

            //
            // 既に起動されているウィンドウに、パネルを埋め込む指定です。
            //

            UsercontrolTextbox uctTxt = new UsercontrolTextbox();

            // 名前だけ初期設定 
            uctTxt.Expression_Name_Control = ec_FcName;
            uctTxt.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctTxt;
        }

        //────────────────────────────────────────
        #endregion



    }
}
