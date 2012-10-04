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
        public static readonly string NAME_FUNCTION = "Sf:Action19;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 「スタイル設定テーブル・ファイル」のテーブル名が入っている変数の名前。
        /// 
        /// 元は名無し。
        /// </summary>
        public static readonly string PM_NAME_TABLE_STYLESHEET = PmNames.S_NAME_TABLE_STYLESHEET.Name_Pm;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function19Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function19Impl(this.EnumEventhandler, this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Gcav), log_Reports);

            f0.SetAttribute(Expression_Node_Function19Impl.PM_NAME_TABLE_STYLESHEET, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
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
        /// <param name="log_Reports"></param>
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain",log_Reports);

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName0 + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                if (this.Functionparameterset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.Functionparameterset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                    log_Reports.Comment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe += "／追記：[" + sFncName0 + "]アクションを実行。";
                }

                //
                //
                //
                //
                this.Functionparameterset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";



                string sStartupPath = Application.StartupPath;

                if (log_Reports.Successful)
                {
                    // 正常時

                    Expression_Node_String ec_ArgTableNameStylesheet;
                    this.TrySelectAttribute(out ec_ArgTableNameStylesheet, Expression_Node_Function19Impl.PM_NAME_TABLE_STYLESHEET, EnumHitcount.One_Or_Zero, log_Reports);

                    // スタイルシート・テーブル
                    XenonTable o_Table_Stylesheet = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_ArgTableNameStylesheet,
                        true,
                        log_Reports
                        );

                    this.Owner_MemoryApplication.MemoryStyles.Clear( o_Table_Stylesheet, log_Reports);
                }
                else
                {
                    // 異常時

                    this.Owner_MemoryApplication.MemoryStyles.Clear(log_Reports);
                }

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
        #endregion



    }
}
