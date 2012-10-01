using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Table;


namespace Xenon.Functions
{
    public class Expression_Node_Function05Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:CSV書出;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 元となるテーブル名。//カンマ区切りで複数指定できる。
        /// </summary>
        public static readonly string S_PM_NAME_TABLE_SRC = PmNames.S_NAME_TABLE_SRC.Name_Pm;

        /// <summary>
        /// 書き出し先となるテーブル名。//カンマ区切りで複数指定できる。
        /// </summary>
        public static readonly string S_PM_NAME_TABLE_DST = PmNames.S_NAME_TABLE_DST.Name_Pm;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function05Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            : base(enumEventhandler, listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_Node_Function05Impl",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function05Impl(this.EnumEventhandler, this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.Dictionary_Expression_Attribute.Set(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);

            f0.Dictionary_Expression_Attribute.Set(Expression_Node_Function05Impl.S_PM_NAME_TABLE_SRC, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.Dictionary_Expression_Attribute.Set(Expression_Node_Function05Impl.S_PM_NAME_TABLE_DST, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

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
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain",log_Reports);

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName0 + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string fcNameStr = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                    log_Reports.Comment_EventCreationMe += "／追記：[" + fcNameStr + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe += "／追記：[" + sFncName0 + "]アクションを実行。";
                }



                // テーブル
                XenonTable o_Table_Src;
                {
                    Expression_Node_String ec_ArgTableName;
                    this.TrySelectAttribute(out ec_ArgTableName, Expression_Node_Function05Impl.S_PM_NAME_TABLE_SRC, false, Request_SelectingImpl.Unconstraint, log_Reports);

                    o_Table_Src = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_ArgTableName,
                        true,
                        log_Reports
                        );
                }

                //
                // 書き出すテキスト
                //
                string sCsvText;
                {
                    ToCsv_TableCsvImpl toCsv = new ToCsv_TableCsvImpl();

                    //
                    // 出力しないフィールド名（英字は、大文字にして入れること）
                    //
                    toCsv.ExceptedFields.List_SExceptedFields_Starts_Upper.Add("Expl".ToUpper());

                    //
                    // 一時的にプロパティー変更
                    //
                    bool bOldRowColRev = o_Table_Src.XenonTableformat.IsRowcolumnreverse;
                    o_Table_Src.XenonTableformat.IsRowcolumnreverse = false;//行と列を、ひっくり返さずに書きだす。

                    sCsvText = toCsv.ToCsvText(o_Table_Src, log_Reports);
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    //
                    // 元に戻す。
                    //
                    o_Table_Src.XenonTableformat.IsRowcolumnreverse = bOldRowColRev;
                }

                //
                // 書き出し先のテーブル
                //
                XenonTable o_Table_Dst;
                if (log_Reports.Successful)
                {
                    Expression_Node_String ec_ArgTableName;
                    this.TrySelectAttribute(out ec_ArgTableName, Expression_Node_Function05Impl.S_PM_NAME_TABLE_DST, false, Request_SelectingImpl.Unconstraint, log_Reports);

                    o_Table_Dst = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_ArgTableName,
                        true,
                        log_Reports
                        );
                }
                else
                {
                    o_Table_Dst = null;
                }

                //
                // 書き出し先ファイルへのパス
                //
                string sFpatha_Dst;//絶対ファイルパス
                if (log_Reports.Successful)
                {
                    sFpatha_Dst = o_Table_Dst.Expression_Filepath_ConfigStack.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                }
                else
                {
                    sFpatha_Dst = null;
                }


                //
                // ファイルの書き出し
                //
                if (log_Reports.Successful)
                {
                    // 正常時

                    CsvWriterImpl writer = new CsvWriterImpl();
                    writer.Write(sCsvText, sFpatha_Dst, true);
                }
            }


            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
