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

        public static readonly string NAME_FUNCTION = "Sf:CSV書出し_変数;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 表示文章。
        /// </summary>
        public static string PM_MESSAGE = PmNames.S_MESSAGE.Name_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function45Impl(
            EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem
            )
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

            Expression_Node_Function f0 = new Expression_Node_Function45Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Conf;            
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function45Impl.PM_MESSAGE, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);

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
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {
                this.Functionparameterset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#:＞";


                this.Execute6_Sub(
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
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Execute6_Sub(
                    log_Reports
                    );
            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Execute6_Sub(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute6_Sub", log_Reports);

            string sName_Fnc;
            this.TrySelectAttribute(out sName_Fnc, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sName_Fnc + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }


            //
            // 変数は、登録されている名前の変数は存在し、登録されていない名前の変数は（自動作成されたもの以外は）存在しない。
            //
            // 元となるテーブルを見ながら、変数オブジェクトの内容を調べていく。
            //
            //


            Configurationtree_Node cur_Cf = new Configurationtree_NodeImpl(log_Method.Fullname, null);


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
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole("[" + sKey + "]=[" + ec_String.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]");
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
                    sb.Append(ec_String.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));//VALUE
                    sb.Append(",");
                    sb.Append(NamesFld.S_END);//END
                    sb.Append(Environment.NewLine);

                    nAuto++;
                });


                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole(sb.ToString());
                }

                //ログ出力
                {
                    Expression_Node_Filepath ec_Fpath_Logs = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(NamesVar.S_SP_LOGS, null, cur_Cf), true, log_Reports);

                    string sFpatha_LogVariables = ec_Fpath_Logs.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + System.IO.Path.DirectorySeparatorChar + NamesFile.S_LOG_VARIABLES;

                    if (log_Reports.Successful)
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
                TableHumaninput o_Table_Variables;
                this.Owner_MemoryApplication.MemoryVariables.TryGetTable_Variables(
                    out o_Table_Variables,
                    Application.StartupPath,
                    log_Reports
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
                            Int_HumaninputImpl.TryParse(row[NamesFld.S_NO], out nValue, EnumOperationIfErrorvalue.Spaces_To_Alt_Value, 0, log_Reports);
                            sb.Append(nValue);
                            sb.Append(",");
                        }

                        // IDは空欄が正しいが、int型なので空欄にできないので 0 を入れる。
                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_ID))
                        {
                            int nValue;
                            Int_HumaninputImpl.TryParse(row[NamesFld.S_ID], out nValue, EnumOperationIfErrorvalue.Spaces_To_Alt_Value, 0, log_Reports);
                            sb.Append(nValue);
                            sb.Append(",");
                        }

                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_EXPL))
                        {
                            string sValue;
                            String_HumaninputImpl.TryParse(row[NamesFld.S_EXPL], out sValue, "", "", log_Method, log_Reports);
                            sb.Append(sValue);
                            sb.Append(",");
                        }

                        string sName_Var = "";
                        if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_NAME))
                        {
                            string sValue;
                            String_HumaninputImpl.TryParse(row[NamesFld.S_NAME], out sValue, "", "", log_Method, log_Reports);
                            sb.Append(sValue);
                            sb.Append(",");

                            sName_Var = sValue;
                        }

                        // 現在の変数の内容
                        string sValue_Var = this.Owner_MemoryApplication.MemoryVariables.GetStringByVariablename(new Expression_Leaf_StringImpl(sName_Var, null, cur_Cf), true, log_Reports);

                        //現在の変数の内容を検索
                        if (NamesVar.Test_Filepath(sName_Var))
                        {
                            Expression_Node_Filepath ec_Fpath = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(sName_Var, null, cur_Cf), true, log_Reports);
                            // 絶対パスとは限らない。フォルダーを指していることもある。
                            string sFpath = ec_Fpath.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                            //フォルダー列値を取得。
                            string sNamevar_Folder_Src;
                            if (o_Table_Variables.DataTable.Columns.Contains(NamesFld.S_FOLDER))
                            {
                                String_HumaninputImpl.TryParse(row[NamesFld.S_FOLDER], out sNamevar_Folder_Src, "", "", log_Method, log_Reports);

                                //フォルダーパス
                                Expression_Node_Filepath ec_Folder = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(sNamevar_Folder_Src,null,cur_Cf), false, log_Reports);
                                if (null != ec_Folder)
                                {
                                    // FOLDER列に入力があれば。

                                    string sFpath_Folder = ec_Folder.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
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
                                //String_HumaninputImpl.TryParse(row[NamesFld.S_VALUE], out sValue, "", "", log_Method, log_Reports);
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
                        Expression_Node_Filepath ec_Fpath_Logs = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(new Expression_Leaf_StringImpl(NamesVar.S_SP_LOGS, null, cur_Cf), true, log_Reports);

                        string sFpatha_LogVariables = ec_Fpath_Logs.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + System.IO.Path.DirectorySeparatorChar + NamesFile.S_SAVE_VARIABLES;

                        if (log_Reports.Successful)
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
                sb.Append("#Execute6_Sub:");
                sb.Append(Environment.NewLine);
                string sArgMessage;
                this.TrySelectAttribute(out sArgMessage, Expression_Node_Function45Impl.PM_MESSAGE, EnumHitcount.One_Or_Zero, log_Reports);

                sb.Append(sArgMessage);

                MessageBox.Show(sb.ToString(), "変数をCSVファイルに書き出したい。");
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
