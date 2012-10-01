using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol
using Xenon.Expr;


namespace Xenon.Functions
{
    public class Expression_Node_Function34Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:変数設定;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 変数の名前。未設定ならヌル？。
        /// </summary>
        public static readonly string S_PM_NAME_VAR = PmNames.S_NAME_VAR.Name_Pm;

        /// <summary>
        /// 変数の値。未設定ならヌル。
        /// </summary>
        public static readonly string S_PM_VALUE = PmNames.S_VALUE.Name_Pm;

        /// <summary>
        /// 空文字で無ければ、処理をスキップする。
        /// </summary>
        public static readonly string S_PM_FLOWSKIP = PmNames.S_FLOWSKIP.Name_Pm;

        //────────────────────────────────────────
        #endregion

        


        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function34Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function34Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.Dictionary_Expression_Attribute.Set(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);

            f0.Dictionary_Expression_Attribute.Set(Expression_Node_Function34Impl.S_PM_NAME_VAR, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.Dictionary_Expression_Attribute.Set(Expression_Node_Function34Impl.S_PM_VALUE, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.Dictionary_Expression_Attribute.Set(Expression_Node_Function34Impl.S_PM_FLOWSKIP, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Expression_ExecuteMain(Log_Reports log_Reports)// EventArgs e
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(
                    this.ExpressionfncPrmset.Sender,
                    log_Reports
                    );

            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                this.Perform2(
                    this.ExpressionfncPrmset.Sender,
                    log_Reports
                    );

                //
                //

                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.ExpressionfncPrmset.EventMonitor).BNowactionworking = false;
            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// 変数を設定します。
        /// </summary>
        protected void Perform2(
            object sender,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform2",log_Reports);


            string sFlowSkip;
            this.TrySelectAttribute( out sFlowSkip, Expression_Node_Function34Impl.S_PM_FLOWSKIP, false, Request_SelectingImpl.Unconstraint, log_Reports);
            if ("" != sFlowSkip.Trim())
            {
                // 処理をスキップします。
                goto gt_EndMethod;
            }


            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName0 + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (log_Reports.Successful)
            {
                // 正常時

                if (sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                    log_Reports.Comment_EventCreationMe += "／追加：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe += "／追加：[" + sFncName0 + "]アクションを実行。";
                }
            }
            else
            {
            }


            Expression_Node_String ec_ArgVarName;
            this.TrySelectAttribute(out ec_ArgVarName, Expression_Node_Function34Impl.S_PM_NAME_VAR, false, Request_SelectingImpl.Unconstraint, log_Reports);

            if (null == ec_ArgVarName)
            {
                goto gt_Error_NullArgVarName;
            }


            Expression_Node_String ec_ArgValue;
            this.TrySelectAttribute(out ec_ArgValue, Expression_Node_Function34Impl.S_PM_VALUE, false, Request_SelectingImpl.Unconstraint, log_Reports);

            if (null == ec_ArgValue)
            {
                goto gt_Error_NullArgValue;
            }

            if (log_Reports.Successful)
            {
                // 正常時

                this.Owner_MemoryApplication.MemoryVariables.SetVariable(
                    new XenonNameImpl(
                        ec_ArgVarName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports),
                        ec_ArgVarName.Cur_Givechapterandverse
                        ),
                    ec_ArgValue,
                    true,
                    log_Reports
                    );
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullArgVarName:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1203！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("name引数が指定されていません。");
                t.Newline();

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullArgValue:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1204！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("value引数が指定されていません。");
                t.Newline();

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
