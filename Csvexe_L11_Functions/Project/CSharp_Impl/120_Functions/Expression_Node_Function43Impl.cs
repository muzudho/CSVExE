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

        public static readonly string NAME_FUNCTION = "Sf:変数設定_コントロール値;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 値格納先変数名。
        /// </summary>
        public static readonly string PM_NAME_VAR = PmNames.S_NAME_VAR.Name_Pm;

        /// <summary>
        /// コントロール名。
        /// </summary>
        public static readonly string PM_NAME_CONTROL = PmNames.S_NAME_CONTROL.Name_Pm;

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
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Conf,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Expression_Node_Function f0 = new Expression_Node_Function43Impl(this.EnumEventhandler,this.List_NameArgumentInitializer,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

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
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {
                this.Functionparameterset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#:＞";

                this.Execute6_Sub(this.Functionparameterset.Sender, log_Reports);


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
                this.Execute6_Sub(this.Functionparameterset.Sender, log_Reports);

            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Execute6_Sub(
            object sender,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute6_Sub", log_Reports);

            if (log_Reports.CanStopwatch)
            {
                string sFncName;
                this.TrySelectAttribute(out sFncName, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }

            string err_SFcName;
            string err_SFcTypeName;
            if (log_Reports.Successful)
            {
                // 変数名が入っているはず。
                Expression_Node_String ec_ArgNameVariable;
                this.TrySelectAttribute(out ec_ArgNameVariable, Expression_Node_Function43Impl.PM_NAME_VAR, EnumHitcount.One_Or_Zero, log_Reports);
                string sVariableName = ec_ArgNameVariable.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                Expression_Node_String ec_ArgFcName;
                this.TrySelectAttribute(out ec_ArgFcName, Expression_Node_Function43Impl.PM_NAME_CONTROL, EnumHitcount.One_Or_Zero, log_Reports);
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
                        err_SFcName = uct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_SFcName, log_Reports);//コントロール名
                tmpl.SetParameter(2, err_SFcTypeName, log_Reports);//コントロールの型名

                this.Owner_MemoryApplication.CreateErrorReport("Er:110026;", tmpl, log_Reports);
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
