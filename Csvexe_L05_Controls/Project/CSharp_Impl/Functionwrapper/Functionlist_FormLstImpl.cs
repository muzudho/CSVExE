﻿using System;
using System.Collections.Generic;
using System.Diagnostics;//Stopwatch
using System.Drawing;//SystemColors,Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//GiveFeedbackEventArgs

using Xenon.Syntax;//Log_TextIndented
using Xenon.Middle;//FormObjectProperties,CustomLabel

namespace Xenon.Controls
{

    /// <summary>
    /// 実行可能な＜event＞要素。リストボックス用。
    /// </summary>
    public class Functionlist_FormLstImpl : Functionlist_FormImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param nFcName="nActionPerformEnum"></param>
        /// <param nFcName="oWrittenPlace"></param>
        public Functionlist_FormLstImpl(GivechapterandverseToExpression_Event sToE_Event, MemoryApplication owner_MemoryApplication)
            : base(sToE_Event, owner_MemoryApplication)
        {
            this.givechapterandverse_Event = sToE_Event.Givechapterandverse_Event;
            this.sType = "!ハードコーディング_" + this.GetType().Name + "#<init>";
        }

        //────────────────────────────────────────

        /// <summary>
        /// このオブジェクトのインスタンスを作成したときに、セットしてください。
        /// </summary>
        public override void InitializeBeforeUse()
        {
            base.InitializeBeforeUse();
            this.nIndex_PreSelected = -1;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override void Execute_OnOEa(
            object sender, EventArgs e
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "Execute_OnOEa",log_Reports_ThisMethod);
            //
            //

            Customcontrol cct = null;

            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ThisMethod);

                log_Reports_ThisMethod.SComment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールでOEaアクションが実行されました。";
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports_ThisMethod.SComment_EventCreationMe = "OEaアクションが実行されました。";
            }


            if (log_Reports_ThisMethod.CanStopwatch)
            {
                string sEventName;
                this.givechapterandverse_Event.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sEventName, true, log_Reports_ThisMethod);

                pg_Method.Log_Stopwatch.SMessage = Utility_Format.Format(
                    sName_Usercontrol,
                    sEventName
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            //
            //
            //


            // ★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            // ★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            // ★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            {
                CustomcontrolListbox ccLst = (CustomcontrolListbox)sender;

                //true || 
                if (this.nIndex_PreSelected != ccLst.SelectedIndex)
                {
                    //essageBox.Show(Info_Forms.LibraryName + ":" + this.GetType().Name + "#Perform_OEa: FC[" + fcNameStr + "]で、イベント（リストボックスの項目選択等）が起こりました。 .SelectedIndex=[" + .SelectedIndex + "] preSelectedIndex=["+this.preSelectedIndex+"]");
                }
                else
                {
                    //
                    // リストボックスの selectedIndex が変わっていないとき。
                    //
                    // ※ dataSourceのテーブルの行が変わったりすると、ここに来ます。
                    //
                    return;

                    //essageBox.Show(Info_Forms.LibraryName + ":" + this.GetType().Name + "#Perform_OEa: FC[" + fcNameStr + "]で、イベント（リストボックスの項目選択等）が起こっていません。選択項目インデックスが同じです。 .SelectedIndex=[" + .SelectedIndex + "] preSelectedIndex=[" + this.preSelectedIndex + "]");
                }

                this.nIndex_PreSelected = ccLst.SelectedIndex;
            }


            //if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            //{
                //
                // 「登録アクション設定」を元に、「アクション」を作成し、実行順に実行。
                //

                givechapterandverse_Event.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node systemFunction_Gcav, ref bool bBreak)
                {
                    Expression_Node_Function expr_Func = cct.ControlCommon.Owner_MemoryApplication.MemoryForms.GivechapterandverseToFunction.Translate(
                        systemFunction_Gcav,
                        true,
                        log_Reports_ThisMethod
                        );

                    if (log_Reports_ThisMethod.BSuccessful)
                    {
                        //ystem.Console.WriteLine(Info_Forms.LibraryName + ":" + this.GetType().Name + "#Perform_OEa: 何回呼び出される？(B)");
                        expr_Func.Execute_OnOEa(sender, e);
                    }
                });
            //}
            //else
            //{
            //    // エラー
            //    goto gt_Error_AnotherEvent;
            //}


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        //gt_Error_AnotherEvent:
        //    if (log_Reports_ThisMethod.CanCreateReport)
        //    {
        //        Log_RecordReport r = log_Reports_ThisMethod.BeginCreateReport(EnumReport.Error);
        //        r.SetTitle("▲エラー397！", pg_Method);

        //        StringBuilder t = new StringBuilder();
        //        t.Append("[");
        //        t.Append(this.EnumEventhandler);
        //        t.Append("]形式のアクションリストが、Perform_OEaを実行しようとしました。");
        //        t.Append(Environment.NewLine);
        //        t.Append("これはプログラムの間違いです。");
        //        r.SMessage = t.ToString();
        //        log_Reports_ThisMethod.EndCreateReport();
        //    }
        //    goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(pg_Method);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 前回「項目を選択するイベント」が起こったときの、
        /// リストボックスの selectedIndex 値。
        /// 初期値は -1 。
        /// </summary>
        private int nIndex_PreSelected;

        //────────────────────────────────────────

        /// <summary>
        /// このアクションの一覧が記述されている、対応するイベント。
        /// </summary>
        private Givechapterandverse_Node givechapterandverse_Event;
        
        //────────────────────────────────────────
        #endregion



    }
}