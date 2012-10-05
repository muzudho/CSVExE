using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Middle
{
    /// <summary>
    /// 関数３０「ウィンドウを開くアクション」の内部処理。
    /// </summary>
    public interface Subroutine_Function30_2
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        ///
        /// </summary>
        void Perform(
            List<XenonTable> oList_Table_Form,
            Expression_Node_Filepath ec_Fopath_Forms,
            Configurationtree_Node thisAction_Conf,
            Form form,
            object sender,
            EventMonitor eventMonitor,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
