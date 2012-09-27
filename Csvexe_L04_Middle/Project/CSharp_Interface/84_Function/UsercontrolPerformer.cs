using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// アクションを実行します。
    /// </summary>
    public interface UsercontrolPerformer
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 実行。
        /// 
        /// 指定のコントロールの、指定のイベントを実行します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nFcName">コントロール名。</param>
        /// <param name="oEventName"></param>
        /// <param name="log_Reports"></param>
        void Perform_Usercontrol(
            object sender,
            Expression_Node_String ec_FcName,
            XenonName o_Name_Event,
            MemoryApplication owner_MoApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 実行。
        /// 
        /// コントロールの名前数文字を指定して、一致するコントロールのイベントを実行します。
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="eventName"></param>
        /// <param name="log_Reports"></param>
        void Perform_UsercontrolNameStartsWith(
            object sender,
            string sFcNameStarts,
            XenonName o_Name_Event,
            MemoryApplication owner_MoApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 実行。
        /// 
        /// 全てのコントロールの、指定のイベントを実行します。
        /// 
        /// アプリケーション起動時に、"OnLoad"を全て実行するなど。
        /// </summary>
        /// <param name="nFcName"></param>
        /// <param name="oEventName"></param>
        /// <param name="log_Reports"></param>
        void Perform_AllUsercontrols(
            List<string> sList_Name_Ucontrol,
            object sender,
            XenonName o_Name_Event,
            MemoryApplication owner_MoApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 実行。
        /// </summary>
        /// <param name="nFcName"></param>
        /// <param name="oEventName"></param>
        /// <param name="log_Reports"></param>
        void Perform(
            object sender,
            string sName_Ucontrol,
            string sName_Event,
            MemoryApplication owner_MoApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
