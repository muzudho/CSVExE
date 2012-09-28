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
        public static readonly string S_PM_NAME_VAR = PmNames.S_NAME_VAR.SName_Pm;

        /// <summary>
        /// 変数の値。未設定ならヌル。
        /// </summary>
        public static readonly string S_PM_VALUE = PmNames.S_VALUE.SName_Pm;

        /// <summary>
        /// 空文字で無ければ、処理をスキップする。
        /// </summary>
        public static readonly string S_PM_FLOWSKIP = PmNames.S_FLOWSKIP.SName_Pm;

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
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function34Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function34Impl.S_PM_NAME_VAR, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function34Impl.S_PM_VALUE, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function34Impl.S_PM_FLOWSKIP, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

            //
            pg_Method.EndMethod(pg_Logging);
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
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)// EventArgs e
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(
                    this.ExpressionfncPrmset.Sender,
                    pg_Logging
                    );

            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                this.Perform2(
                    this.ExpressionfncPrmset.Sender,
                    pg_Logging
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
            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// 変数を設定します。
        /// </summary>
        protected void Perform2(
            object sender,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform2",pg_Logging);


            string sFlowSkip;
            this.TrySelectAttr( out sFlowSkip, Expression_Node_Function34Impl.S_PM_FLOWSKIP, false, Request_SelectingImpl.Unconstraint, pg_Logging);
            if ("" != sFlowSkip.Trim())
            {
                // 処理をスキップします。
                goto gt_EndMethod;
            }


            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName0 + "]実行";
                pg_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (pg_Logging.BSuccessful)
            {
                // 正常時

                if (sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                    pg_Logging.SComment_EventCreationMe += "／追加：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe += "／追加：[" + sFncName0 + "]アクションを実行。";
                }
            }
            else
            {
            }


            Expression_Node_String ec_ArgVarName;
            this.TrySelectAttr(out ec_ArgVarName, Expression_Node_Function34Impl.S_PM_NAME_VAR, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (null == ec_ArgVarName)
            {
                goto gt_Error_NullArgVarName;
            }


            Expression_Node_String ec_ArgValue;
            this.TrySelectAttr(out ec_ArgValue, Expression_Node_Function34Impl.S_PM_VALUE, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (null == ec_ArgValue)
            {
                goto gt_Error_NullArgValue;
            }

            if (pg_Logging.BSuccessful)
            {
                // 正常時

                this.Owner_MemoryApplication.MemoryVariables.SetVariable(
                    new XenonNameImpl(
                        ec_ArgVarName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging),
                        ec_ArgVarName.Cur_Givechapterandverse
                        ),
                    ec_ArgValue,
                    true,
                    pg_Logging
                    );
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullArgVarName:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1203！", pg_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("name引数が指定されていません。");
                t.NewLine();

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.SMessage = t.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullArgValue:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1204！", pg_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("value引数が指定されていません。");
                t.NewLine();

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

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
