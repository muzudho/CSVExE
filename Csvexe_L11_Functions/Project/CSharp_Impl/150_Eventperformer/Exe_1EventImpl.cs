﻿using System;
using System.Collections.Generic;
using System.Diagnostics;//Stopwatch
using System.Linq;
using System.Text;
using System.Windows.Forms;//DrawMode,Form

using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,OAction,NFcName,EventName
using Xenon.Controls;

namespace Xenon.Functions
{
    /// <summary>
    /// コントロールの ＜event＞要素の中を読み取って実行します。
    /// </summary>
    public class Exe_1EventImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// UsercontrolPerformerImpl#Perform_FcImpl で使用。
        /// UsercontrolPerformerImpl#Perform で使用。
        /// 
        /// cf_Eventは、ucFc.ControlCommon.Configurationtree_Control.SDic_Event から取っている。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cf_Event"></param>
        /// <param name="moWorkbench"></param>
        /// <param name="log_Reports"></param>
        public void Perform(
            object sender,
            Configurationtree_Node cf_Event,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform",log_Reports);

            Configurationtree_Node cf_ThisMethod = new Configurationtree_NodeImpl("＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform:＞", null);
            EventMonitorImpl eventMonitor = new EventMonitorImpl(cf_Event, cf_ThisMethod);

            if (log_Reports.CanStopwatch)
            {

                // コメント作成
                {
                    StringBuilder sb = new StringBuilder();

                    string sName_Control;
                    {
                        Configurationtree_Node owner_Configurationtree_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, log_Reports);
                        owner_Configurationtree_Control.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Control, false, log_Reports);
                    }

                    string sEventName;
                    {
                        cf_Event.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sEventName, false, log_Reports);
                    }

                    int nActionCount;
                    {
                        nActionCount = cf_Event.List_Child.Count;
                    }


                    sb.Append(Info_Functions.Name_Library);
                    sb.Append(":");
                    sb.Append(this.GetType().Name);
                    sb.Append("#ToString: イベント計測 ");
                    sb.Append("　FC[");
                    sb.Append(sName_Control);
                    sb.Append("].EV[");
                    sb.Append(sEventName);
                    sb.Append("]");

                    if (0 < nActionCount)
                    {
                        sb.Append("アクション数＝[");
                        sb.Append(nActionCount);
                        sb.Append("]");
                    }

                    log_Method.Log_Stopwatch.Message = sb.ToString();
                    log_Method.Log_Stopwatch.Begin();

                }

            }


            // ステータスバーに表示する文字列。
            {
                if (sender is Customcontrol)
                {
                    Customcontrol ccFc = (Customcontrol)sender;

                    if (null == ccFc.ControlCommon.Owner_MemoryApplication)
                    {
                        log_Method.WriteDebug_ToConsole("null==ccFc.ControlCommon.Owner_MemoryApplication がヌルでした。");
                    }
                    else
                    {
                        ccFc.ControlCommon.Owner_MemoryApplication.MemoryForms.AddStatus_ActionUsercontrolNameBegin(log_Reports);

                        string sName_Usercontrol = sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                        ccFc.ControlCommon.Owner_MemoryApplication.MemoryForms.AddStatus_ActionUsercontrolName(sName_Usercontrol, log_Reports);
                    }

                }
            }


            cf_Event.List_Child.ForEach(delegate(Configurationtree_Node s_Action, ref bool bBreak)
            {
                eventMonitor.BNowactionworking = true;

                Exe_2FunctionImpl actionPerformer = new Exe_2FunctionImpl();

                // イベントハンドラーの作成
                Expression_Node_Function expr_Func = actionPerformer.ConfigurationtreeToFunction(
                    s_Action,
                    owner_MemoryApplication,
                    log_Reports
                    );

                // システム定義関数の実行
                actionPerformer.PerformUsercontrol(
                    expr_Func,
                    sender,
                    eventMonitor,
                    owner_MemoryApplication,
                    log_Reports
                    );

                while (eventMonitor.BNowactionworking)
                {
                    // 他の待機スレッドに、実行順番を譲る。
                    System.Threading.Thread.Sleep(0);
                }

                if (Log_ReportsImpl.BDebugmode_Static)
                {
                    //.WriteLine(this.GetType().Name + "#Perform:\n│\n│\n│\n│");
                }
            });


            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
