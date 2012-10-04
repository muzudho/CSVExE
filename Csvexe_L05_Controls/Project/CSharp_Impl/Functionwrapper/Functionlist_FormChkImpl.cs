using System;
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
    /// 実行可能な＜event＞要素。チェックボックス用。
    /// </summary>
    public class Functionlist_FormChkImpl : Functionlist_FormImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param nFcName="nActionPerformEnum"></param>
        /// <param nFcName="oWrittenPlace"></param>
        public Functionlist_FormChkImpl(ConfigurationtreeToExpression_Event sToE_Event, MemoryApplication owner_MemoryApplication)
            : base(sToE_Event, owner_MemoryApplication)
        {
            this.Configurationtree_Event = sToE_Event.Configurationtree_Event;
            this.sType = "!ハードコーディング_" + this.GetType().Name + "#<init>";
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
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute_OnOEa",log_Reports_ThisMethod);
            //
            //

            Customcontrol cct = null;

            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);

                log_Reports_ThisMethod.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールでOEaアクションが実行されました。";
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports_ThisMethod.Comment_EventCreationMe = "OEaアクションが実行されました。";
            }

            if (log_Reports_ThisMethod.CanStopwatch)
            {
                string sEventName;
                this.Configurationtree_Event.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sEventName, true, log_Reports_ThisMethod);

                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    sEventName
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            //
            //
            //
            //ystem.Console.WriteLine(Info_Forms.LibraryName + ":" + this.GetType().Name + "#Perform_OEa: 何回呼び出される？(A)");

            //EnumEventhandler err_Eh;
            //
            // 「登録アクション設定」を元に、「アクション」を作成し、実行順に実行。
            //
            Configurationtree_Event.List_Child.ForEach(delegate(Configurationtree_Node systemFunction_Gcav, ref bool bBreak)
            {
                Expression_Node_Function expr_Func = cct.ControlCommon.Owner_MemoryApplication.MemoryForms.ConfigurationtreeToFunction.Translate(
                    systemFunction_Gcav, true, log_Reports_ThisMethod);

                if (log_Reports_ThisMethod.Successful)
                {
                    expr_Func.Execute_OnOEa(sender, e);
                }

                goto gt_EndMethod2;
            //
            gt_EndMethod2:
                ;
            });

            goto gt_EndMethod;
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
        /// このアクションの一覧が記述されている、対応するイベント。
        /// </summary>
        private Configurationtree_Node Configurationtree_Event;

        //────────────────────────────────────────
        #endregion



    }
}
