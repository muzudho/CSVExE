using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;//DrawMode
using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//Usercontrol

namespace Xenon.Layout
{
    /// <summary>
    /// リストボックス02
    /// </summary>
    public class UsercontrolCreator2_Lst03Impl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication moApplication
            )
        {
            UsercontrolListbox uctLst = new UsercontrolListbox();

            // 名前だけ初期設定 
            uctLst.Expression_Name_Control = ec_FcName;
            uctLst.ControlCommon.Owner_MemoryApplication = moApplication;

            //
            // 項目に色を付けるなどの機能に、変更。
            //
            {
                uctLst.ListboxItemDrawer = new ListboxItemDrawer_03Impl(moApplication);
                // リストボックスの表示を自作します。項目の高さが固定の場合。
                uctLst.DrawMode = DrawMode.OwnerDrawFixed;
            }

            return uctLst;
        }

        //────────────────────────────────────────
        #endregion



    }
}
