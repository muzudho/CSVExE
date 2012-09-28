using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;//DataRow
using System.Windows.Forms;//Application
using Xenon.Syntax;
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.Functions
{


    /// <summary>
    /// 変数モデルを、CSVに書出します。
    /// </summary>
    public class Expression_Node_Function45Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:CSV書出し_変数;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 表示文章。
        /// </summary>
        public static string S_PM_MESSAGE = PmNames.S_MESSAGE.SName_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function45Impl(
            EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem
            )
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

            Expression_Node_Function f0 = new Expression_Node_Function45Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;            
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function45Impl.S_PM_MESSAGE, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                this.Perform2(
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
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(
                    pg_Logging
                    );
            }

            //
            //
            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────

        protected void Perform2(
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform2",pg_Logging);

            string sName_Fnc;
            this.TrySelectAttr(out sName_Fnc, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = "Nアクション[" + sName_Fnc + "]実行";
                pg_Method.Log_Stopwatch.Begin();
            }


            //
            // 変数は、登録されている名前の変数は存在し、登録されていない名前の変数は（自動作成されたもの以外は）存在しない。
            //
            // 元となるテーブルを見ながら、変数オブジェクトの内容を調べていく。
            //
            //


            Givechapterandverse_Node cur_Cf = new Givechapterandverse_NodeImpl(pg_Method.SHead, null);


            // 変数ログを吐く。
            {
                StringBuilder sb = new StringBuilder();

                //１行目
                sb.Append(NamesFld.S_NO);
                sb.Append(",");
                sb.Append(NamesFld.S_ID);
                sb.Append(",");
                sb.Append(NamesFld.S_EXPL);
                sb.Append(",");
                sb.Append(NamesFld.S_NAME);
                sb.Append(",");
                sb.Append(NamesFld.S_FOLDER);
                sb.Append(",");
                sb.Append(NamesFld.S_VALUE);
                sb.Append(",");
                sb.Append(NamesFld.S_END);
                sb.Append(Environment.NewLine);

                //２行目
                sb.Append(NamesTypedb.S_INT);//NO
                sb.Append(",");
                sb.Append(NamesTypedb.S_INT);//ID
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//Expl
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//NAME
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//FOLDER
                sb.Append(",");
                sb.Append(NamesTypedb.S_STRING);//VALUE
                sb.Append(",");
                sb.Append(NamesFld.S_END);//END
                sb.Append(Environment.NewLine);

                //３行目
                sb.Append("-1,");//NO
                sb.Append("使わない,");//ID
                sb.Append("解説,");//Expl
                sb.Append("変数名,");//NAME
                sb.Append("（ファイルパス変数のみ指定有効）フォルダーパス,");//FOLDER
                sb.Append("初期値,");//VALUE
                sb.Append(NamesFld.S_END);//END
                sb.Append(Environment.NewLine);

                int nAuto = 0;
                this.Owner_MemoryApplication.MemoryVariables.EachVariable(delegate(string sKey, Expression_Node_String ec_String, ref bool bBreak)
                {
                    if (pg_Method.CanDebug(1))
                    {
                        pg_Method.WriteDebug_ToConsole("[" + sKey + "]=[" + ec_String.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging) + "]");
                    }

                    sb.Append(nAuto);//NO
                    sb.Append(",");
                    //ID 使わない
                    sb.Append(",");
                    //Expl 消えてしまう
                    sb.Append(",");
                    sb.Append(sKey);//NAME
                    sb.Append(",");
                    //FOLDER TODO:逆算が必要
                    sb.Append(",");
                    sb.Append(ec_String.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging));//VALUE
                    sb.Append(",");
                    sb.Append(NamesFld.S_END);//END
                    sb.Append(Environment.NewLine);

                    nAuto++;
                });


                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole(sb.ToString());
                }

                //ログ出力
                {
                    Expression_Node_Filepath ec_Fpath_Logs = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(NamesVar.S_SP_LOGS, null, cur_Cf), true, pg_Logging);

                    string sFpatha_LogVariables = ec_Fpath_Logs.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging) + System.IO.Path.DirectorySeparatorChar + NamesFile.S_LOG_VARIABLES;

                    if (pg_Logging.BSuccessful)
                    {
                        CsvWriterImpl writer = new CsvWriterImpl();
                        writer.Write(
                            sb.ToString(),
                            sFpatha_LogVariables,
                            true
                            );
                    }
                }
            }



            //変数CSVを吐き出したい。（登録されている順序を保って）
            {
                // 変数ファイルの読取り
                XenonTable o_Table_Variables;
                this.Owner_MemoryApplication.MemoryVariables.TryGetTable_Variables(
                    out o_Table_Variables,
                    Application.StartupPath,
                    this.Owner_MemoryApplication,
                    pg_Logging
                    );

                if (null != o_Table_Variables)
                {
                    StringBuilder sb = new StringBuilder();

                    //１行目
                    sb.Append(NamesFld.S_NO);
                    sb.Append(",");
                    sb.Append(NamesFld.S_ID);
                    sb.Append(",");
                    sb.Append(NamesFld.S_EXPL);
                    sb.Append(",");
                    sb.Append(NamesFld.S_NAME);
                    sb.Append(",");
                    sb.Append(NamesFld.S_FOLDER);
                    sb.Append(",");
                    sb.Append(NamesFld.S_VALUE);
                    sb.Append(",");
                    sb.Append(NamesFld.S_END);
                    sb.Append(Environment.NewLine);

                    //２行目
                    sb.Append(NamesTypedb.S_INT);//NO
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_INT);//ID
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_STRING);//Expl
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_STRING);//NAME
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_STRING);//FOLDER
                    sb.Append(",");
                    sb.Append(NamesTypedb.S_STRING);//VALUE
                    sb.Append(",");
                    sb.Append(NamesFld.S_END);//END
                    sb.Append(Environment.NewLine);

                    //３行目
                    sb.Append("-1,");//NO
                    sb.Append("使わない,");//ID
                    sb.Append("解説,");//Expl
                    sb.Append("変数名,");//NAME
                    sb.Append("（ファイルパス変数のみ指定有効）フォルダーパス,");//FOLDER
                    sb.Append("初期値,");//VALUE
                    sb.Append(NamesFld.S_END);//END
                    sb.Append(Environment.NewLine);


                    int nAuto = 0;
                    foreach (DataRow row in o_Table_Variables.DataTable.Rows)
                    {

                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_NO))
                        {
                            int nValue;
                            XenonValue_IntImpl.TryParse(row[NamesFld.S_NO], out nValue, EnumOperationIfErrorvalue.Spaces_To_Alt_Value, 0, pg_Logging);
                            sb.Append(nValue);
                            sb.Append(",");
                        }

                        // IDは空欄が正しいが、int型なので空欄にできないので 0 を入れる。
                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_ID))
                        {
                            int nValue;
                            XenonValue_IntImpl.TryParse(row[NamesFld.S_ID], out nValue, EnumOperationIfErrorvalue.Spaces_To_Alt_Value, 0, pg_Logging);
                            sb.Append(nValue);
                            sb.Append(",");
                        }

                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_EXPL))
                        {
                            string sValue;
                            XenonValue_StringImpl.TryParse(row[NamesFld.S_EXPL], out sValue, "", "", pg_Method, pg_Logging);
                            sb.Append(sValue);
                            sb.Append(",");
                        }

                        string sName_Var = "";
                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_NAME))
                        {
                            string sValue;
                            XenonValue_StringImpl.TryParse(row[NamesFld.S_NAME], out sValue, "", "", pg_Method, pg_Logging);
                            sb.Append(sValue);
                            sb.Append(",");

                            sName_Var = sValue;
                        }

                        // 現在の変数の内容
                        string sValue_Var = this.Owner_MemoryApplication.MemoryVariables.GetStringByVariablename(new Expression_Leaf_StringImpl(sName_Var, null, cur_Cf), true, pg_Logging);

                        //現在の変数の内容を検索
                        if (NamesVar.Test_Filepath(sName_Var))
                        {
                            Expression_Node_Filepath ec_Fpath = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(sName_Var, null, cur_Cf), true, pg_Logging);
                            // 絶対パスとは限らない。フォルダーを指していることもある。
                            string sFpath = ec_Fpath.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                            //フォルダー列値を取得。
                            string sNamevar_Folder_Src;
                            if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_FOLDER))
                            {
                                XenonValue_StringImpl.TryParse(row[NamesFld.S_FOLDER], out sNamevar_Folder_Src, "", "", pg_Method, pg_Logging);

                                //フォルダーパス
                                Expression_Node_Filepath ec_Folder = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(sNamevar_Folder_Src,null,cur_Cf), false, pg_Logging);
                                if (null != ec_Folder)
                                {
                                    // FOLDER列に入力があれば。

                                    string sFpath_Folder = ec_Folder.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);
                                    if (sValue_Var.StartsWith(sFpath_Folder))
                                    {
                                        // FOLDER列値をそのままキープ。
                                        sb.Append(sNamevar_Folder_Src);

                                        // 値のフォルダー部分を削る。
                                        sValue_Var = sValue_Var.Substring(sFpath_Folder.Length);

                                        // 先頭が　ディレクトリー区切り文字なら削る。
                                        if (sValue_Var.StartsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                                        {
                                            sValue_Var = sValue_Var.Substring(System.IO.Path.DirectorySeparatorChar.ToString().Length);
                                        }
                                    }
                                    else
                                    {
                                        // FOLDER列値はそのまま使えない。
                                    }
                                }

                                sb.Append(",");
                            }

                            if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_VALUE))
                            {
                                //string sValue;
                                //XenonValue_StringImpl.TryParse(row[NamesFld.S_VALUE], out sValue, "", "", pg_Method, pg_Logging);
                                //sb.Append(sValue);
                                //sb.Append(",");

                                // 現在の変数の値（の削った残り）を入れる。
                                sb.Append(sValue_Var);
                                sb.Append(",");
                            }
                        }
                        else// if (NamesVar.Test_String(sName_Var))
                        {

                            // FOLDER列値は無し。
                            sb.Append(",");

                            if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_VALUE))
                            {
                                // 現在の変数の値を入れる。
                                sb.Append(sValue_Var);
                                sb.Append(",");
                            }
                        }

                        sb.Append(NamesFld.S_END);
                        sb.Append(Environment.NewLine);

                        nAuto++;
                    }

                    //ファイル書出し
                    {
                        Expression_Node_Filepath ec_Fpath_Logs = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(NamesVar.S_SP_LOGS, null, cur_Cf), true, pg_Logging);

                        string sFpatha_LogVariables = ec_Fpath_Logs.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging) + System.IO.Path.DirectorySeparatorChar + NamesFile.S_SAVE_VARIABLES;

                        if (pg_Logging.BSuccessful)
                        {
                            CsvWriterImpl writer = new CsvWriterImpl();
                            writer.Write(
                                sb.ToString(),
                                sFpatha_LogVariables,
                                true
                                );
                        }
                    }
                }
            }



            //
            // メッセージボックスの表示。
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(this.GetType().Name);
                sb.Append("#Perform:");
                sb.Append(Environment.NewLine);
                string sArgMessage;
                this.TrySelectAttr(out sArgMessage, Expression_Node_Function45Impl.S_PM_MESSAGE, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                sb.Append(sArgMessage);

                MessageBox.Show(sb.ToString(), "変数をCSVファイルに書き出したい。");
            }

            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion



    }
}
