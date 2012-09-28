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
        /// <param name="pg_Logging"></param>
        /// <returns></returns>
        public Expression_Node_Function GivechapterandverseToFunction(
            Givechapterandverse_Node action_Gcav,
            MemoryApplication owner_MemoryApplication,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "GivechapterandverseToFunction",pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Begin();
            }
            //


            Expression_Node_Function expr_Func;
            if (pg_Logging.BSuccessful)
            {
                expr_Func = owner_MemoryApplication.MemoryForms.GivechapterandverseToFunction.Translate(
                    action_Gcav,
                    true,
                    pg_Logging
                    );
            }
            else
            {
                expr_Func = null;
            }


            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
            return expr_Func;
        }

        //────────────────────────────────────────

        /// <summary>
        /// システム定義関数の実行。
        /// </summary>
        /// <param name="fc_EventHandler"></param>
        /// <param name="sender"></param>
        /// <param name="eventMonitor"></param>
        /// <param name="pg_Logging"></param>
        public void PerformUsercontrol(
            Expression_Node_Function expr_Func,
            object sender,
            EventMonitorImpl eventMonitor,
            Log_Reports pg_Logging
        )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "PerformUsercontrol",pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Begin();
            }
            //
            //
            //
            //
            string sConfigStack_EventOrigin = "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform:＞";

            string sFncName;
            expr_Func.TrySelectAttr(out sFncName, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            //
            // アクションの実行
            //
            //ystem.Console.WriteLine(this.GetType().Name + "#PerformAllFcs: 【開始】E_Action実行します。");
            if (pg_Logging.BSuccessful)
            {
                if (null != expr_Func)
                {
                    if (pg_Method.CanWarning())
                    {
                        pg_Method.WriteWarning_ToConsole(" 【実行】イベント=[" + expr_Func.EnumEventhandler + "] システム関数=[" + sFncName + "] ");
                    }

                    switch (expr_Func.EnumEventhandler)
                    {
                        case EnumEventhandler.Wr_Rhn:
                            {
                                expr_Func.Execute_OnWrRhn(
                                    sender,
                                    eventMonitor,
                                    sConfigStack_EventOrigin,
                                    pg_Logging
                                    );
                            }
                            break;

                        case EnumEventhandler.O_Ea:
                            {
                                // 変換 OEa → WrRhn。
                                expr_Func.Execute_OnWrRhn(
                                    sender,
                                    eventMonitor,
                                    sConfigStack_EventOrigin,
                                    pg_Logging
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
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSupportedEnum:
            // アクションしていない、アクションは終了したという判断。
            eventMonitor.BNowactionworking = false;
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー202！", pg_Method);

                string sActionName = "（エラー処理未実装 " + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform）";

                StringBuilder t = new StringBuilder();
                t.Append("指定のアクション[" + sActionName + "]を実行しようとしましたが、");
                t.Append(Environment.NewLine);
                t.Append("　enum=[");
                t.Append(expr_Func.EnumEventhandler);
                t.Append("]に対応するメソッドを呼び出すプログラムが書かれていません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("　" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Performに、プログラムを実装してください。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("　・または、そのイベントに追加できないアクションを記述しているのかもしれません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                //todo: t.Append(r.Message_Givechapterandverse(e_Uic.Cur_Givechapterandverse));

                r.SMessage = t.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion



    }

}
