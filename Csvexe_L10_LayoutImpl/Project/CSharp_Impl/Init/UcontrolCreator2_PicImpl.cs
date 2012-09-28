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
    /// 画像
    /// </summary>
    public class UsercontrolCreator2_PicImpl : UsercontrolCreator2
    {



        #region アクション
        //────────────────────────────────────────

        public Usercontrol Perform(
            Expression_Node_StringImpl ec_FcName,
            MemoryApplication owner_MemoryApplication
            )
        {
            UsercontrolImage uctPic = new UsercontrolImage();

            // 名前だけ初期設定 
            uctPic.Expression_Name_Control = ec_FcName;
            uctPic.ControlCommon.Owner_MemoryApplication = owner_MemoryApplication;

            return uctPic;
        }

        //────────────────────────────────────────
        #endregion



    }
}
