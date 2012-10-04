using System;
using System.Collections.Generic;
using System.Diagnostics;//Stopwatch
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Functions
{

    /// <summary>
    /// 単一の関数を実行する。
    /// 
    /// Exe_1EventImpl#Perform で使用。
    /// </summary>
    public class Exe_2FunctionImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// イベントハンドラーの作成。
        /// </summary>
        /// <param name="s_Action"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public Expression_Node_Function ConfigurationtreeToFunction(
            Configurationtree_Node action_Gcav,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "ConfigurationtreeToFunction",log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Begin();
            }
            //


            Expression_Node_Function expr_Func;
            if (log_Reports.Successful)
            {
                expr_Func = owner_MemoryApplication.MemoryForms.ConfigurationtreeToFunction.Translate(
                    action_Gcav,
                    true,
                    log_Reports
                    );
            }
            else
            {
                expr_Func = null;
            }


            goto gt_EndMethod;
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return expr_Func;
        }

        //────────────────────────────────────────

        /// <summary>
        /// システム定義関数の実行。
        /// </summary>
        /// <param name="fc_EventHandler"></param>
        /// <param name="sender"></param>
        /// <param name="eventMonitor"></param>
        /// <param name="log_Reports"></param>
        public void PerformUsercontrol(
            Expression_Node_Function expr_Func,
            object sender,
            EventMonitorImpl eventMonitor,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
        )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "PerformUsercontrol",log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //
            //
            //
            string sConfigStack_EventOrigin = "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform:＞";

            string sFncName;
            expr_Func.TrySelectAttribute(out sFncName, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            //
            // アクションの実行
            //
            //ystem.Console.WriteLine(this.GetType().Name + "#PerformAllFcs: 【開始】E_Action実行します。");
            if (log_Reports.Successful)
            {
                if (null != expr_Func)
                {
                    if (log_Method.CanWarning())
                    {
                        log_Method.WriteWarning_ToConsole(" 【実行】イベント=[" + expr_Func.EnumEventhandler + "] システム関数=[" + sFncName + "] ");
                    }

                    switch (expr_Func.EnumEventhandler)
                    {
                        case EnumEventhandler.O_Lr:
                            {
                                expr_Func.Execute_OnLr(
                                    sender,
                                    eventMonitor,
                                    sConfigStack_EventOrigin,
                                    log_Reports
                                    );
                            }
                            break;

                        case EnumEventhandler.O_Ea:
                            {
                                // 変換 OEa → WrRhn。
                                expr_Func.Execute_OnLr(
                                    sender,
                                    eventMonitor,
                                    sConfigStack_EventOrigin,
                                    log_Reports
                                    );
                            }
                            break;

                        //case NActionPerformEnum.O_DEA_P_S_B_WR:
                        //    break;

                        default:
                            //エラー
                            goto gt_Error_NotSupportedEnum;
                    }
                }
            }
            else
            {
                //
                // アクションしていない、アクションは終了したという判断。
                //
                eventMonitor.BNowactionworking = false;
            }



            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSupportedEnum:
            // アクションしていない、アクションは終了したという判断。
            eventMonitor.BNowactionworking = false;
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sFncName, log_Reports);//関数名
                tmpl.SetParameter(2, expr_Func.EnumEventhandler.ToString(), log_Reports);//イベントハンドラー名
                tmpl.SetParameter(3, log_Method.Fullname, log_Reports);//問題のあったメソッド

                memoryApplication.CreateErrorReport("Er:110029;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }

}
