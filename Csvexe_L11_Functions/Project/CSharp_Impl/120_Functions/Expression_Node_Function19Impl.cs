using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol
using Xenon.Operating;//StyleSheetTableParser
using Xenon.Table;//DefaultTable


namespace Xenon.Functions
{
    public class Expression_Node_Function19Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        /// <summary>
        /// 関数名。
        /// </summary>
        public static readonly string S_ACTION_NAME = "Sf:Action19;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 「スタイル設定テーブル・ファイル」のテーブル名が入っている変数の名前。
        /// 
        /// 元は名無し。
        /// </summary>
        public static readonly string S_PM_NAME_TABLE_STYLE_SHEET = PmNames.S_NAME_TABLE_STYLESHEET.SName_Pm;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function19Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
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

            Expression_Node_Function f0 = new Expression_Node_Function19Impl(this.EnumEventhandler, this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function19Impl.S_PM_NAME_TABLE_STYLE_SHEET, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

            //
            pg_Method.EndMethod(pg_Logging);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// スタイルシート設定ファイルを読み込んでおきます。
        /// </summary>
        /// <param name="moMre"></param>
        /// <param name="pg_Logging"></param>
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);

            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName0 + "]実行";
                pg_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                    pg_Logging.SComment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe += "／追記：[" + sFncName0 + "]アクションを実行。";
                }

                //
                //
                //
                //
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";



                string sStartupPath = Application.StartupPath;

                if (pg_Logging.BSuccessful)
                {
                    // 正常時

                    Expression_Node_String ec_ArgTableNameStylesheet;
                    this.TrySelectAttr(out ec_ArgTableNameStylesheet, Expression_Node_Function19Impl.S_PM_NAME_TABLE_STYLE_SHEET, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                    // スタイルシート・テーブル
                    XenonTable o_Table_Stylesheet = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_ArgTableNameStylesheet,
                        true,
                        pg_Logging
                        );

                    this.Owner_MemoryApplication.MemoryStyles.Clear( o_Table_Stylesheet, pg_Logging);
                }
                else
                {
                    // 異常時

                    this.Owner_MemoryApplication.MemoryStyles.Clear(pg_Logging);
                }

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
        #endregion



    }
}
