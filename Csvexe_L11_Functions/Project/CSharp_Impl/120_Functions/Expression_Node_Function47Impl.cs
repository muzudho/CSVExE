using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Forms;//Application
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol
using Xenon.Functions;

namespace Xenon.Functions
{


    /// <summary>
    /// [使い方]
    /// Form1など必ず最初に読み込まれるファイルで #RegisterFunctions を呼び出して関数登録をしてください。
    /// 
    /// フォルダーの中のファイル、フォルダーを一覧したCSVファイルを作成します。
    /// </summary>
    public class Expression_Node_Function47Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:CSV書出し_ファイルリスト;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 検索されるフォルダー。
        /// </summary>
        public const string S_PM_FOLDER_SOURCE = "Pm:folder-source;";

        /// <summary>
        /// 出力先ファイル。
        /// </summary>
        public const string S_PM_FILE_EXPORT = "Pm:file-export;";

        /// <summary>
        /// 「File」「Folder」「Both」のいずれか。無指定なら「Both」扱い。
        /// </summary>
        public const string S_PM_FILTER = "Pm:filter;";

        /// <summary>
        /// ポップアップの有無。「block」なら出ない。
        /// </summary>
        public const string S_PM_POPUP = "Pm:popup;";

        public const string S_FILE = "File";
        public const string S_FOLDER = "Folder";
        public const string S_BOTH = "Both";
        public const string S_BLOCK = "block";

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function47Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler, listS_ArgName, functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function47Impl(this.EnumEventhandler, this.List_NameArgument, this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.Dictionary_Expression_Attribute.Set(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);

            f0.Dictionary_Expression_Attribute.Set(Expression_Node_Function47Impl.S_PM_FOLDER_SOURCE, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

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
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain", log_Reports);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.Node_EventOrigin += "＜" + log_Method.Fullname + "＞";


                this.Perform2(
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
                ((EventMonitor)this.ExpressionfncPrmset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(
                    log_Reports
                    );
            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Perform2(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform2", log_Reports);

            string sName_Fnc;
            this.TrySelectAttribute(out sName_Fnc, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sName_Fnc + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }


            //ScriptVariableフォルダー
            string sFolder_Scriptvariable;
            {
                this.TrySelectAttribute(out sFolder_Scriptvariable, Expression_Node_Function47Impl.S_PM_FOLDER_SOURCE, false, Request_SelectingImpl.Unconstraint, log_Reports);
            }
            //書出し先ファイル
            Expression_Node_String expr_Variablefile_Export;
            {
                this.TrySelectAttribute(out expr_Variablefile_Export, Expression_Node_Function47Impl.S_PM_FILE_EXPORT, false, Request_SelectingImpl.Unconstraint, log_Reports);
            }
            //Expression_Node_Filepath file_Export;
            //{
            //    Expression_Node_String expr_Variablefile_Export;
            //    this.TrySelectAttribute(out expr_Variablefile_Export, Expression_Node_Function47Impl.S_PM_FILE_EXPORT, false, Request_SelectingImpl.Unconstraint, log_Reports);
            //    {
            //        file_Export = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(expr_Variablefile_Export, true, log_Reports);

            //        //Givechapterandverse_Filepath file_Export_Gcav = new Givechapterandverse_FilepathImpl(sVariablefile_Export, null);
            //        //file_Export = new Expression_Node_FilepathImpl(file_Export_Gcav);
            //        //file_Export.SetSDirectory_Base(sFolder_Export, log_Reports);
            //        //file_Export.SetSHumaninput("SrvList.csv", log_Reports);
            //    }
            //}
            //フィルター指定
            string sFilter;
            {
                this.TrySelectAttribute(out sFilter, Expression_Node_Function47Impl.S_PM_FILTER, false, Request_SelectingImpl.Unconstraint, log_Reports);
                sFilter = sFilter.Trim();
            }
            //ポップアップ指定
            string sPopup;
            {
                this.TrySelectAttribute(out sPopup, Expression_Node_Function47Impl.S_PM_POPUP, false, Request_SelectingImpl.Unconstraint, log_Reports);
                sPopup = sPopup.Trim();
            }

            {
                string[] array_Filesystementry;

                switch (sFilter)
                {
                    case S_FILE:
                        {
                            array_Filesystementry = Directory.GetFiles(sFolder_Scriptvariable);
                        }
                        break;
                    case S_FOLDER:
                        {
                            array_Filesystementry = Directory.GetDirectories(sFolder_Scriptvariable);
                        }
                        break;
                    default:
                        {
                            array_Filesystementry = Directory.GetFileSystemEntries(sFolder_Scriptvariable);
                        }
                        break;
                }


                // 検索結果をCSVテーブルの形にして出力。

                StringBuilder sb = new StringBuilder();
                sb.Append("NO,FILE,END");
                sb.Append(Environment.NewLine);
                sb.Append("int,string,END");
                sb.Append(Environment.NewLine);
                sb.Append("-1,ファイルパス,END");
                sb.Append(Environment.NewLine);
                int n = 0;
                foreach (string sFilesystementry in array_Filesystementry)
                {
                    //連番
                    sb.Append(n);
                    sb.Append(",");
                    sb.Append(sFilesystementry);
                    sb.Append(",END");
                    sb.Append(Environment.NewLine);
                    n++;
                }
                sb.Append("EOF,,");
                sb.Append(Environment.NewLine);

                System.Console.WriteLine(sb.ToString());


                try
                {
                    string sFile_Export2 = expr_Variablefile_Export.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                    System.IO.File.WriteAllText(
                        sFile_Export2,
                        sb.ToString(),
                        Encoding.Default
                        );

                    if (sPopup != S_BLOCK)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();

                        s.Append("ファイルに書き込みました。");
                        s.Newline();
                        s.Append("[");
                        s.Append(sFile_Export2);
                        s.Append("]");
                        s.Newline();
                        s.Newline();

                        s.Append("検索した場所：");
                        s.Newline();
                        s.Append("[");
                        s.Append(sFolder_Scriptvariable);
                        s.Append("]");
                        s.Newline();
                        s.Newline();

                        s.Append("検索オプション（Pm:filter;）：");
                        s.Newline();
                        s.Append("[");
                        s.Append(sFilter);
                        s.Append("]");
                        s.Newline();

                        MessageBox.Show(s.ToString(), "▲実行結果！（L02）");
                    }
                }
                catch (Exception ex)
                {
                    // 異常時は必ずポップアップが出る。
                    MessageBox.Show(
                        ex.Message,
                        "▲エラー201！(" + log_Method.Fullname + ")#Write"
                        );
                }
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
