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
    /// リストボックス
    /// </summary>
    public class UsercontrolCreator2_LstImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_Name_Control,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolListbox uctLst = new UsercontrolListbox();

            // 名前だけ初期設定 
            uctLst.Expression_Name_Control = ec_Name_Control;
            uctLst.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            // E_Action08、E_Action26 の内容をここに移動。
            {
                // 動作
                uctLst.ListboxItemDrawer = new ListboxItemDrawer_01Impl(owner_MemoryApplication);

                // リストボックスの表示を自作します。項目の高さが固定の場合。
                uctLst.DrawMode = DrawMode.OwnerDrawFixed;
            }

            return uctLst;
        }

        //────────────────────────────────────────
        #endregion



    }
}
