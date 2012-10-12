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

        public static readonly string NAME_FUNCTION = "Sf:変数設定;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 変数の名前。未設定ならヌル？。
        /// </summary>
        public static readonly string PM_NAME_VAR = PmNames.S_NAME_VAR.Name_Pm;

        /// <summary>
        /// 変数の値。未設定ならヌル。
        /// </summary>
        public static readonly string PM_VALUE = PmNames.S_VALUE.Name_Pm;

        /// <summary>
        /// 空文字で無ければ、処理をスキップする。
        /// </summary>
        public static readonly string PM_FLOWSKIP = PmNames.S_FLOWSKIP.Name_Pm;

        //────────────────────────────────────────
        #endregion

        


        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function34Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Conf,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function34Impl(this.EnumEventhandler,this.List_NameArgumentInitializer,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function34Impl.PM_NAME_VAR, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function34Impl.PM_VALUE, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function34Impl.PM_FLOWSKIP, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);

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
        public override string Execute5_Main(Log_Reports log_Reports)// EventArgs e
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Execute6_Sub(
                    this.Functionparameterset.Sender,
                    log_Reports
                    );

            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {
                this.Functionparameterset.Node_EventOrigin += "＜" + log_Method.Fullname+":＞";


                this.Execute6_Sub(
                    this.Functionparameterset.Sender,
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
                ((EventMonitor)this.Functionparameterset.EventMonitor).BNowactionworking = false;
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
        protected void Execute6_Sub(
            object sender,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute6_Sub", log_Reports);


            string sFlowSkip;
            this.TrySelectAttribute(out sFlowSkip, Expression_Node_Function34Impl.PM_FLOWSKIP, EnumHitcount.One_Or_Zero, log_Reports);
            if ("" != sFlowSkip.Trim())
            {
                // 処理をスキップします。
                goto gt_EndMethod;
            }


            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

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

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

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
            this.TrySelectAttribute(out ec_ArgVarName, Expression_Node_Function34Impl.PM_NAME_VAR, EnumHitcount.One_Or_Zero, log_Reports);

            if (null == ec_ArgVarName)
            {
                goto gt_Error_NullArgVarName;
            }


            Expression_Node_String ec_ArgValue;
            this.TrySelectAttribute(out ec_ArgValue, Expression_Node_Function34Impl.PM_VALUE, EnumHitcount.One_Or_Zero, log_Reports);

            if (null == ec_ArgValue)
            {
                goto gt_Error_NullArgValue;
            }

            if (log_Reports.Successful)
            {
                // 正常時

                this.Owner_MemoryApplication.MemoryVariables.SetVariable(
                    new XenonNameImpl(
                        ec_ArgVarName.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports),
                        ec_ArgVarName.Cur_Configurationtree
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:110017;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullArgValue:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:110018;", tmpl, log_Reports);
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
