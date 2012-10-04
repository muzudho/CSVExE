using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol


namespace Xenon.Functions
{
    public class Expression_Node_Function42Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:arg実行;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 実行したい＜fnc＞要素が記述されたもの。
        /// </summary>
        public static readonly string PM_EXECUTE = PmNames.S_EXECUTE.Name_Pm;

        /// <summary>
        /// 空文字で無ければ、処理をスキップする。
        /// </summary>
        public static readonly string PM_FLOWSKIP = PmNames.S_FLOWSKIP.Name_Pm;

        //────────────────────────────────────────
        #endregion


        
        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function42Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            : base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function42Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Gcav), log_Reports);

            f0.SetAttribute(Expression_Node_Function42Impl.PM_EXECUTE, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.SetAttribute(Expression_Node_Function42Impl.PM_FLOWSKIP, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション部
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

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "「E■[" + sFncName0 + "]アクション」実行(A)";
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.Functionparameterset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";

                this.Perform2(log_Reports);

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
                this.Perform2(log_Reports);
            }

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        private void Perform2(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform2",log_Reports);

            string sFlowSkip;
            this.TrySelectAttribute(out sFlowSkip, Expression_Node_Function42Impl.PM_FLOWSKIP, EnumHitcount.One, log_Reports);
            if ("" != sFlowSkip.Trim())
            {
                // 処理をスキップします。
                goto gt_EndMethod;
            }

            //
            //
            //
            //

            Expression_Node_String ec_ArgExecute;
            this.TrySelectAttribute(out ec_ArgExecute, Expression_Node_Function42Impl.PM_EXECUTE, EnumHitcount.One, log_Reports);
            // 実行するだけでよい。返り値は使わない。
            ec_ArgExecute.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

            goto gt_EndMethod;

            //
        //
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
