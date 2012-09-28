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
        public static readonly string S_PM_NAME_TABLE_SRC = PmNames.S_NAME_TABLE_SRC.SName_Pm;

        /// <summary>
        /// 書き出し先となるテーブル名。//カンマ区切りで複数指定できる。
        /// </summary>
        public static readonly string S_PM_NAME_TABLE_DST = PmNames.S_NAME_TABLE_DST.SName_Pm;

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
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_Node_Function05Impl",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function05Impl(this.EnumEventhandler, this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function05Impl.S_PM_NAME_TABLE_SRC, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function05Impl.S_PM_NAME_TABLE_DST, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

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
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
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

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string fcNameStr = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                    pg_Logging.SComment_EventCreationMe += "／追記：[" + fcNameStr + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe += "／追記：[" + sFncName0 + "]アクションを実行。";
                }



                // テーブル
                XenonTable o_Table_Src;
                {
                    Expression_Node_String ec_ArgTableName;
                    this.TrySelectAttr(out ec_ArgTableName, Expression_Node_Function05Impl.S_PM_NAME_TABLE_SRC, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                    o_Table_Src = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_ArgTableName,
                        true,
                        pg_Logging
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
                    bool bOldRowColRev = o_Table_Src.XenonTableformat.BRowcolumnreverse;
                    o_Table_Src.XenonTableformat.BRowcolumnreverse = false;//行と列を、ひっくり返さずに書きだす。

                    sCsvText = toCsv.ToCsvText(o_Table_Src, pg_Logging);
                    if (!pg_Logging.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    //
                    // 元に戻す。
                    //
                    o_Table_Src.XenonTableformat.BRowcolumnreverse = bOldRowColRev;
                }

                //
                // 書き出し先のテーブル
                //
                XenonTable o_Table_Dst;
                if (pg_Logging.BSuccessful)
                {
                    Expression_Node_String ec_ArgTableName;
                    this.TrySelectAttr(out ec_ArgTableName, Expression_Node_Function05Impl.S_PM_NAME_TABLE_DST, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                    o_Table_Dst = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_ArgTableName,
                        true,
                        pg_Logging
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
                if (pg_Logging.BSuccessful)
                {
                    sFpatha_Dst = o_Table_Dst.Expression_Filepath_ConfigStack.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);
                }
                else
                {
                    sFpatha_Dst = null;
                }


                //
                // ファイルの書き出し
                //
                if (pg_Logging.BSuccessful)
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
            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
