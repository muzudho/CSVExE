using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//DrawItemEventArgs

using System.Drawing;

using Xenon.Syntax;
using Xenon.Middle;//ModelOfOpyopyo


namespace Xenon.Controls
{
    public interface ListboxItemDrawer
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        void Perform(
            object sender,
            DrawItemEventArgs e,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 項目の文字列。
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="ccLst"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        string P1_GetItemString(
            int nCurrentIndex,
            CustomcontrolListbox ccLst,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curIx"></param>
        /// <param name="ccLst"></param>
        /// <param name="log_Reports"></param>
        /// <returns>指定しない場合はヌル。</returns>
        Brush P2_GetForeBrush(//virtual
            int nCurIx,
            CustomcontrolListbox ccLst,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// アプリケーション・モデル。
        /// </summary>
        MemoryApplication Owner_MemoryApplication
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
