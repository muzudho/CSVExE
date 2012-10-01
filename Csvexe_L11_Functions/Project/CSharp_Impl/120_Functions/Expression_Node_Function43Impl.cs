using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol
using Xenon.Expr;

namespace Xenon.Functions
{

    /// <summary>
    /// @Deprecated
    /// 使うか？使ってない。
    /// </summary>
    public class Expression_Node_Function43Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:変数設定_コントロール値;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 値格納先変数名。
        /// </summary>
        public static readonly string S_PM_NAME_VAR = PmNames.S_NAME_VAR.Name_Pm;

        /// <summary>
        /// コントロール名。
        /// </summary>
        public static readonly string S_PM_NAME_FC = PmNames.S_NAME_CONTROL.Name_Pm;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function43Impl(
            EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem
            )
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Expression_Node_Function f0 = new Expression_Node_Function43Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.Dictionary_Expression_Attribute.Set(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);

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
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain",log_Reports);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.Functionparameterset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";

                this.Perform2(this.Functionparameterset.Sender, log_Reports);


                //
                //

                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.Functionparameterset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(this.Functionparameterset.Sender, log_Reports);

            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Perform2(
            object sender,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform2",log_Reports);

            if (log_Reports.CanStopwatch)
            {
                string sFncName;
                this.TrySelectAttribute(out sFncName, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }

            string err_SFcName;
            string err_SFcTypeName;
            if (log_Reports.Successful)
            {
                // 変数名が入っているはず。
                Expression_Node_String ec_ArgNameVariable;
                this.TrySelectAttribute(out ec_ArgNameVariable, Expression_Node_Function43Impl.S_PM_NAME_VAR, false, Request_SelectingImpl.Unconstraint, log_Reports);
                string sVariableName = ec_ArgNameVariable.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                Expression_Node_String ec_ArgFcName;
                this.TrySelectAttribute(out ec_ArgFcName, Expression_Node_Function43Impl.S_PM_NAME_FC, false, Request_SelectingImpl.Unconstraint, log_Reports);
                List<Usercontrol> list_UcFc = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(ec_ArgFcName, true, log_Reports);
                foreach (Usercontrol uct in list_UcFc)
                {
                    if (uct is UsercontrolCheckbox)
                    {
                        // チェックボックスの場合。
                        CustomcontrolCheckbox ccChk = ((UsercontrolCheckbox)uct).CustomcontrolCheckbox1;
                        string sBool = ccChk.Checked.ToString();//TRUE or FALSE

                        XenonName o_VariableName = new XenonNameImpl(sVariableName, this.Cur_Configurationtree);

                        // 変数を上書き。
                        this.Owner_MemoryApplication.MemoryVariables.SetStringValue(
                            o_VariableName,
                            sBool,
                            true,
                            log_Reports
                            );
                    }
                    else
                    {
                        // エラー
                        err_SFcName = uct.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                        err_SFcTypeName = uct.GetType().Name;
                        goto gt_Error_UndefinedUc;
                    }

                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedUc:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー542！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("このアクションでは、指定のコントロールの種類に対して、プログラムが未実装です。");
                t.Append(Environment.NewLine);

                t.Append("Fc名[");
                t.Append(err_SFcName);
                t.Append("] Fc型[");
                t.Append(err_SFcTypeName);
                t.Append("]");
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
