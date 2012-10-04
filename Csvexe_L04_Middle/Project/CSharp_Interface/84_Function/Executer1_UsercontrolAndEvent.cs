using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// ユーザーコントロール名とイベント名を指定して、イベント内の関数を実行します。
    /// </summary>
    public interface Executer1_UsercontrolAndEvent
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
        void Execute1_Usercontrol(
            object sender,
            Expression_Node_String expr_NameControl,
            XenonName name_Event,
            MemoryApplication owner_MemoryApplication,
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
        void Execute1_UsercontrolNameStartsWith(
            object sender,
            string name_Control_NameStarts,
            XenonName name_Event,
            MemoryApplication owner_MemoryApplication,
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
        void Execute1_AllUsercontrols(
            List<string> list_Name_Usercontrol,
            object sender,
            XenonName name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            );

        ///// <summary>
        ///// 実行。
        ///// </summary>
        ///// <param name="nFcName"></param>
        ///// <param name="oEventName"></param>
        ///// <param name="log_Reports"></param>
        //void Execute2(
        //    object sender,
        //    string sName_Usercontrol,
        //    string sName_Event,
        //    MemoryApplication owner_MemoryApplication,
        //    string sConfigStack_EventOrigin,
        //    Log_Reports log_Reports
        //    );

        //────────────────────────────────────────
        #endregion



    }
}
