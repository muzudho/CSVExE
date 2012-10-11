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
    /// フォルダー構造を、別のフォルダー下に複製します。
    /// 
    /// フォルダー構造をそのままコピーするのではなく、
    /// 「ファイルパス一覧CSV」をもとに複製します。
    /// </summary>
    public class Expression_Node_Function48Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:フォルダー構造の複製;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 表示文章。
        /// </summary>
        public static readonly string PM_FILE_IMPORT_LISTFILE = "Pm:file-import-listfile;";
        //public static readonly string PM_FOLDER_SOURCE = "Pm:folder-source;";
        //public static readonly string PM_FOLDER_DESTINATION = "Pm:folder-destination;";

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function48Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
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

            Expression_Node_Function f0 = new Expression_Node_Function48Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function48Impl.PM_FILE_IMPORT_LISTFILE, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);
            //f0.SetAttribute(Expression_Node_Function48Impl.PM_FOLDER_DESTINATION, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);
            //f0.SetAttribute(Expression_Node_Function48Impl.PM_FOLDER_SOURCE, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);

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
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute6_Sub", log_Reports);

            string error_Filepath_Source;
            int error_RowNumber;
            Table_Humaninput error_Table_Humaninput;

            string sName_Fnc;
            this.TrySelectAttribute(out sName_Fnc, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sName_Fnc + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }

            //
            // メッセージボックスの表示。
            StringBuilder sb = new StringBuilder();
            sb.Append(log_Method.Fullname);
            sb.Append(":");
            sb.Append(Environment.NewLine);

            string sPmFileListfile;
            this.TrySelectAttribute(out sPmFileListfile, Expression_Node_Function48Impl.PM_FILE_IMPORT_LISTFILE, EnumHitcount.One_Or_Zero, log_Reports);
            //string sPmFolderSource;
            //this.TrySelectAttribute(out sPmFolderSource, Expression_Node_Function48Impl.PM_FOLDER_SOURCE, EnumHitcount.One_Or_Zero, log_Reports);
            //string sPmFolderDestination;
            //this.TrySelectAttribute(out sPmFolderDestination, Expression_Node_Function48Impl.PM_FOLDER_DESTINATION, EnumHitcount.One_Or_Zero, log_Reports);

            Configurationtree_NodeFilepath fileListfile_Conf = new Configurationtree_NodeFilepathImpl(log_Method.Fullname, null);
            fileListfile_Conf.InitPath(sPmFileListfile, log_Reports);
            //Configurationtree_NodeFilepath folderSource_Conf = new Configurationtree_NodeFilepathImpl(log_Method.Fullname, null);
            //folderSource_Conf.InitPath(sPmFolderSource,log_Reports);
            //Configurationtree_NodeFilepath folderDestination_Conf = new Configurationtree_NodeFilepathImpl(log_Method.Fullname, null);
            //folderDestination_Conf.InitPath(sPmFolderDestination, log_Reports);

            Expression_Node_Filepath fileListfile_Expr = new Expression_Node_FilepathImpl(fileListfile_Conf);
            //Expression_Node_Filepath folderSource_Expr = new Expression_Node_FilepathImpl(folderSource_Conf);//頭をカットするのに使う。
            //Expression_Node_Filepath folderDestination_Expr = new Expression_Node_FilepathImpl(folderDestination_Conf);

            sb.Append(
                "\n" +
                "file-listfile = " + fileListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint,log_Reports) + "\n\n"
                //"folder-source = " + folderSource_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "\n\n" +
                //"folder-destination = " + folderDestination_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "\n\n"
                );

            MessageBox.Show(sb.ToString(), "デバッグ表示");


            // CSVファイル読取り
            if (log_Reports.Successful)
            {
                //
                // CSVソースファイル読取
                //
                CsvTo_Table_HumaninputImpl reader = new CsvTo_Table_HumaninputImpl();

                Request_ReadsTable request_tblReads = new Request_ReadsTableImpl();
                Format_Table_Humaninput tblFormat_puts = new Format_Table_HumaninputImpl();
                request_tblReads.Name_PutToTable = log_Method.Fullname;//暫定
                request_tblReads.Expression_Filepath = fileListfile_Expr;

                Table_Humaninput xenonTable = reader.Read(
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
                    string filepath_Destination_Cur;
                    if (log_Reports.Successful)
                    {
                        String_HumaninputImpl.TryParse(row["FILE"], out filepath_Source_Cur, "", "", log_Method, log_Reports);
                        String_HumaninputImpl.TryParse(row["FILE2"], out filepath_Destination_Cur, "", "", log_Method, log_Reports);
                        //if (log_Method.CanDebug(9))
                        //{
                        log_Method.WriteDebug_ToConsole("コピーしたいfilepath：①[" + filepath_Source_Cur + "]→②[" + filepath_Destination_Cur + "]");
                        //}
                    }
                    else
                    {
                        filepath_Source_Cur = "";
                        filepath_Destination_Cur = "";
                    }

                    //
                    // ファイルのコピー（上書き）
                    //
                    {
                        //フォルダーのコピー方法は別。
                        if (System.IO.Directory.Exists(filepath_Source_Cur))
                        {
                            //フォルダー

                            //コピー先のディレクトリがないときは作る
                            if (!System.IO.Directory.Exists(filepath_Destination_Cur))
                            {
                                System.IO.Directory.CreateDirectory(filepath_Destination_Cur);
                                //属性もコピー
                                System.IO.File.SetAttributes(filepath_Destination_Cur,
                                    System.IO.File.GetAttributes(filepath_Source_Cur));
                            }

                        }
                        else if (System.IO.File.Exists(filepath_Source_Cur))
                        {
                            //ファイル

                            //第一引数で示されたファイルを、第二引数で示されたファイル位置にコピー。
                            //第3項にtrueを指定することにより、上書きを許可
                            System.IO.File.Copy(filepath_Source_Cur, filepath_Destination_Cur, true);
                        }
                        else
                        {
                            //エラー
                            //
                            error_Filepath_Source = filepath_Source_Cur;
                            error_RowNumber = rowNumber;
                            error_Table_Humaninput = xenonTable;
                            goto gt_Error_NoFilesystementry;
                        }
                    }

                    if (!log_Reports.Successful)
                    {
                        //エラー
                        break;
                    }

                    rowNumber++;
                }
            }



            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NoFilesystementry:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, error_Filepath_Source, log_Reports);//ファイルパス
                tmpl.SetParameter(2, error_RowNumber.ToString(), log_Reports);//エラーのあった行
                tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Configurationtree(error_Table_Humaninput), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:110030;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
