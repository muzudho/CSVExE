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

        public static readonly string S_ACTION_NAME = "Sf:arg実行;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 実行したい＜fnc＞要素が記述されたもの。
        /// </summary>
        public static readonly string S_PM_EXECUTE = PmNames.S_EXECUTE.SName_Pm;

        /// <summary>
        /// 空文字で無ければ、処理をスキップする。
        /// </summary>
        public static readonly string S_PM_FLOWSKIP = PmNames.S_FLOWSKIP.SName_Pm;

        //────────────────────────────────────────
        #endregion


        
        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function42Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            : base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function42Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function42Impl.S_PM_EXECUTE, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function42Impl.S_PM_FLOWSKIP, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

            //
            pg_Method.EndMethod(pg_Logging);
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
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);

            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = "「E■[" + sFncName0 + "]アクション」実行(A)";
                pg_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";

                this.Perform2(pg_Logging);

                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.ExpressionfncPrmset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(pg_Logging);
            }

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────

        private void Perform2(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform2",pg_Logging);

            string sFlowSkip;
            this.TrySelectAttr(out sFlowSkip, Expression_Node_Function42Impl.S_PM_FLOWSKIP, true, Request_SelectingImpl.Unconstraint, pg_Logging);
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
            this.TrySelectAttr(out ec_ArgExecute, Expression_Node_Function42Impl.S_PM_EXECUTE, true, Request_SelectingImpl.Unconstraint, pg_Logging);
            // 実行するだけでよい。返り値は使わない。
            ec_ArgExecute.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

            goto gt_EndMethod;

            //
        //
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion



    }
}
