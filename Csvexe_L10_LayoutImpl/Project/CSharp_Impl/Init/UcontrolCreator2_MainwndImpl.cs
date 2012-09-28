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
    /// メイン・ウィンドウ
    /// </summary>
    public class UsercontrolCreator2_MainwndImpl : UsercontrolCreator2
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

            // パネルとして作成します。
            UsercontrolPanel uctPnl = new UsercontrolPanel();
            //ucPanel.BackColor = Color.Transparent;

            // 名前だけ初期設定 
            uctPnl.Expression_Name_Control = ec_FcName;
            uctPnl.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctPnl;
        }

        //────────────────────────────────────────
        #endregion



    }
}
