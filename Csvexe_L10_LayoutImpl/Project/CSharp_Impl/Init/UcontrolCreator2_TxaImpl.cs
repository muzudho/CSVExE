using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;//ScrollBars
using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//Usercontrol

namespace Xenon.Layout
{
    /// <summary>
    /// テキストエリア
    /// </summary>
    public class UsercontrolCreator2_TxaImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolTextbox uctTxt = new UsercontrolTextbox();

            // 名前だけ初期設定 
            uctTxt.Expression_Name_Control = ec_FcName;
            uctTxt.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            //
            // 複数行入力のテキストボックスに設定することで、
            // テキストエリアになります。
            //
            uctTxt.Multiline = true;
            uctTxt.UsercontrolScrollbars = ScrollBars.Both;

            return uctTxt;
        }

        //────────────────────────────────────────
        #endregion



    }
}
