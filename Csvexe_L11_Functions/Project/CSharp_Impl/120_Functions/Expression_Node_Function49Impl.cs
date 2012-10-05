using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.Functions
{

    /// <summary>
    /// （関数47で作られるような）ファイルパス（Ａ）が一覧されたCSVを読み取り、
    /// そのようなファイルパス（Ａ）を、別のフォルダーにコピーするよう、「Ａ→Ｂ」の一覧になっているCSVファイルを書き出します。
    /// 
    /// 連携：関数47→関数49
    /// </summary>
    public class Expression_Node_Function49Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:CSV書出し_ファイルリスト_フォルダー構造の複製;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 表示文章。
        /// </summary>
        public static readonly string PM_FILE_IMPORT_LISTFILE = "Pm:file-import-listfile;";
        public static readonly string PM_FILE_EXPORT_LISTFILE = "Pm:file-export-listfile;";
        public static readonly string PM_FOLDER_SOURCE = "Pm:folder-source;";
        public static readonly string PM_FOLDER_DESTINATION = "Pm:folder-destination;";
        public static readonly string PM_POPUP = "Pm:popup;";

        /// <summary>
        /// ポップアップの有無。「block」なら出ない。
        /// </summary>
        public const string S_BLOCK = "block";

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function49Impl(EnumEventhandler enumEventhandler, List<string> list_NameArg, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,list_NameArg,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expr, Configurationtree_Node my_Conf,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function49Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expr;
            f0.Cur_Configurationtree = my_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, my_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function49Impl.PM_FILE_IMPORT_LISTFILE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function49Impl.PM_FILE_EXPORT_LISTFILE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function49Impl.PM_FOLDER_DESTINATION, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function49Impl.PM_FOLDER_SOURCE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function49Impl.PM_POPUP, new Expression_Node_StringImpl(this, my_Conf), log_Reports);

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
                this.Functionparameterset.Node_EventOrigin += "＜" + log_Method.Fullname + "＞";


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
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute6_Sub", log_Reports);

            string sName_Fnc;
            this.TrySelectAttribute(out sName_Fnc, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sName_Fnc + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }

            //
            // メッセージボックスの表示。
            Log_TextIndented str_Messagebox = new Log_TextIndentedImpl();
            str_Messagebox.Append(log_Method.Fullname);
            str_Messagebox.Append(":");
            str_Messagebox.Append(Environment.NewLine);


            Expression_Node_Filepath pm_FileImportListfile_Expr;
            this.TrySelectAttribute_ExpressionFilepath(out pm_FileImportListfile_Expr, Expression_Node_Function49Impl.PM_FILE_IMPORT_LISTFILE, EnumHitcount.One_Or_Zero, log_Reports);

            Expression_Node_Filepath pm_FileExportListfile_Expr;
            this.TrySelectAttribute_ExpressionFilepath(out pm_FileExportListfile_Expr, Expression_Node_Function49Impl.PM_FILE_EXPORT_LISTFILE, EnumHitcount.One_Or_Zero, log_Reports);

            Expression_Node_Filepath pm_FolderSource_Expr;
            this.TrySelectAttribute_ExpressionFilepath(out pm_FolderSource_Expr, Expression_Node_Function49Impl.PM_FOLDER_SOURCE, EnumHitcount.One_Or_Zero, log_Reports);

            Expression_Node_Filepath pm_FolderDestination_Expr;
            this.TrySelectAttribute_ExpressionFilepath(out pm_FolderDestination_Expr, Expression_Node_Function49Impl.PM_FOLDER_DESTINATION, EnumHitcount.One_Or_Zero, log_Reports);

            //ポップアップ指定
            string pm_Popup;
            this.TrySelectAttribute(out pm_Popup, Expression_Node_Function49Impl.PM_POPUP, EnumHitcount.One_Or_Zero, log_Reports);
            pm_Popup = pm_Popup.Trim();

            this.Dictionary_Expression_Attribute.ToText_Debug(str_Messagebox, log_Reports);

            str_Messagebox.Append(
                "file-import-listfile=[" + pm_FileImportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint,log_Reports) + "]\n\n" +
                "file-export-listfile=[" + pm_FileExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                "folder-source=[" + pm_FolderSource_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                "folder-destination=[" + pm_FolderDestination_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                "pm_Popup=[" + pm_Popup + "]\n\n"
                );

            MessageBox.Show(str_Messagebox.ToString(), "デバッグ表示");


            // CSVファイル読取り
            List<string[]> list_StringArray = new List<string[]>();
            if (log_Reports.Successful)
            {
                //
                // CSVソースファイル読取
                //
                CsvTo_XenonTableImpl reader = new CsvTo_XenonTableImpl();

                Request_ReadsTable request_tblReads = new Request_ReadsTableImpl();
                XenonTableformat tblFormat_puts = new XenonTableformatImpl();
                request_tblReads.Name_PutToTable = log_Method.Fullname;//暫定
                request_tblReads.Expression_Filepath = pm_FileImportListfile_Expr;

                XenonTable xenonTable = reader.Read(
                    request_tblReads,
                    tblFormat_puts,
                    true,
                    log_Reports
                    );

                int rowNumber = 1;
                foreach (DataRow row in xenonTable.DataTable.Rows)
                {

                    //記述されているファイルパス
                    string filepath_Source_Cur;
                    if (log_Reports.Successful)
                    {
                        XenonValue_StringImpl.TryParse(row["FILE"], out filepath_Source_Cur, "", "", log_Method, log_Reports);
                        //if (log_Method.CanDebug(9))
                        //{
                        //    log_Method.WriteDebug_ToConsole("①filepathCur=[" + filepathCur + "]");
                        //}
                    }
                    else
                    {
                        filepath_Source_Cur = "";
                    }

                    Configurationtree_NodeFilepath filepathCur_Conf;
                    if (log_Reports.Successful)
                    {
                        filepathCur_Conf = new Configurationtree_NodeFilepathImpl(log_Method.Fullname, null);
                        filepathCur_Conf.InitPath(filepath_Source_Cur, log_Reports);
                        //if (log_Method.CanDebug(9))
                        //{
                        //    Log_TextIndented s = new Log_TextIndentedImpl();
                        //    filepathCur_Conf.ToText_Content(s);
                        //    log_Method.WriteDebug_ToConsole("②filepathCur_Conf=[" + s.ToString() + "]");
                        //}
                    }
                    else
                    {
                        filepathCur_Conf = null;
                    }

                    Expression_Node_Filepath filepathCur_Expr;
                    if (log_Reports.Successful)
                    {
                        filepathCur_Expr = new Expression_Node_FilepathImpl(filepathCur_Conf);
                        //if (log_Method.CanDebug(9))
                        //{
                        //    log_Method.WriteDebug_ToConsole("③filepathCur_Expr=[" + filepathCur_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]");
                        //}
                    }
                    else
                    {
                        filepathCur_Expr = null;
                    }

                    //頭をカットする
                    string filepath_Destination_New;
                    //Expression_Node_Filepath filepathCrop;
                    if (log_Reports.Successful)
                    {
                        filepathCur_Expr.TryCutFolderpath(out filepath_Destination_New, pm_FolderSource_Expr, true, log_Reports);
                        //if (log_Method.CanDebug(9))
                        //{
                        //    log_Method.WriteDebug_ToConsole("④filepathCrop.Humaninput =[" + filepathCrop.Humaninput + "]");
                        //    log_Method.WriteDebug_ToConsole("④filepathCrop.Execute4_～=[" + filepathCrop.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]");
                        //}

                        //if (log_Method.CanDebug(9))
                        //{
                        //    log_Method.WriteDebug_ToConsole("filepathCrop=[" + filepathCrop + "]");
                        //}

                        //転送先パスの作成
                        Configurationtree_NodeFilepath fileDestination_Conf = new Configurationtree_NodeFilepathImpl(log_Method.Fullname, null);
                        fileDestination_Conf.InitPath(pm_FolderDestination_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint,log_Reports), filepath_Destination_New, log_Reports);

                        Expression_Node_Filepath fileDestination_Expr = new Expression_Node_FilepathImpl(fileDestination_Conf);
                        filepath_Destination_New = fileDestination_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                    }
                    else
                    {
                        filepath_Destination_New = "";
                    }

                    //if (log_Method.CanDebug(1))
                    //{
                    //    log_Method.WriteDebug_ToConsole("コピーしたい：　filepath_Source_Cur=[" + filepath_Source_Cur + "] → filepath_New=[" + filepath_Destination_New + "]");
                    //}

                    if (!log_Reports.Successful)
                    {
                        //エラー
                        break;
                    }

                    list_StringArray.Add(new string[] { filepath_Source_Cur, filepath_Destination_New });

                    rowNumber++;
                }
            }

            //CSVファイルの書出し
            if (log_Reports.Successful)
            {
                StringBuilder s2 = new StringBuilder();
                s2.Append("NO,FILE,FILE2,END");
                s2.Append(Environment.NewLine);
                s2.Append("int,string,string,END");
                s2.Append(Environment.NewLine);
                s2.Append("-1,ファイルパス,ファイルパス2,END");
                s2.Append(Environment.NewLine);
                int n = 0;
                foreach (string[] row in list_StringArray)
                {
                    //連番
                    s2.Append(n);
                    s2.Append(",");
                    s2.Append(row[0]);
                    s2.Append(",");
                    s2.Append(row[1]);
                    s2.Append(",END");
                    s2.Append(Environment.NewLine);
                    n++;
                }
                s2.Append("EOF,,,");
                s2.Append(Environment.NewLine);

                //System.Console.WriteLine(s2.ToString());

                try
                {
                    System.IO.File.WriteAllText(
                        pm_FileExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint,log_Reports),
                        s2.ToString(),
                        Global.ENCODING_CSV
                        );

                    if (pm_Popup != S_BLOCK)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();

                        s.Append("ファイルに書き込みました。");
                        s.Newline();
                        s.Append("[");
                        s.Append(pm_FileExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                        s.Append("]");
                        s.Newline();
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


            goto gt_EndMethod;
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
