using System;
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
    public class Executer2_EventImpl
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
        /// <param name="event_Conf"></param>
        /// <param name="moWorkbench"></param>
        /// <param name="log_Reports"></param>
        public void Execute2_Event(
            object sender,
            Configurationtree_Node event_Conf,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute2_Event", log_Reports);

            Configurationtree_Node cf_ThisMethod = new Configurationtree_NodeImpl("＜" + log_Method.Fullname + ":＞", null);

            if (log_Reports.CanStopwatch)
            {

                // コメント作成
                {
                    StringBuilder sb = new StringBuilder();

                    string sName_Control;
                    {
                        Configuration_Node owner_Configurationtree_Control = event_Conf.GetParentByNodename(
                            NamesNode.S_CONTROL1, EnumConfiguration.Tree, true, log_Reports);
                        ((Configurationtree_Node)owner_Configurationtree_Control).Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Control, false, log_Reports);
                    }

                    string sEventName;
                    {
                        event_Conf.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sEventName, false, log_Reports);
                    }

                    int nActionCount;
                    {
                        nActionCount = event_Conf.List_Child.Count;
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

                        string sName_Usercontrol = sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                        ccFc.ControlCommon.Owner_MemoryApplication.MemoryForms.AddStatus_ActionUsercontrolName(sName_Usercontrol, log_Reports);
                    }

                }
            }


            event_Conf.List_Child.ForEach(delegate(Configurationtree_Node s_Action, ref bool bBreak)
            {
                Executer3_FunctionImpl exe2 = new Executer3_FunctionImpl();

                // イベントハンドラーの作成
                Expression_Node_Function expr_Func = exe2.ConfigurationtreeToFunction(
                    s_Action,
                    owner_MemoryApplication,
                    log_Reports
                    );

                // システム定義関数の実行
                exe2.Execute3_Function(
                    expr_Func,
                    sender,
                    owner_MemoryApplication,
                    log_Reports
                    );

                // 他の待機スレッドに、実行順番を譲る。
                //TODO: System.Threading.Thread.Sleep(0);

                //if (Log_ReportsImpl.BDebugmode_Static)
                //{
                //    //.WriteLine(this.GetType().Name + "#:\n│\n│\n│\n│");
                //}
            });


            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
