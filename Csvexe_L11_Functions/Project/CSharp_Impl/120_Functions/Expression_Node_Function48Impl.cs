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
        public static readonly string PM_FIELDSOURCE_IMPORTLISTFILE = "Pm:fieldsource-importlistfile;";
        public static readonly string PM_FIELDDESTINATION_IMPORTLISTFILE = "Pm:fielddestination-exportlistfile;";
        public static readonly string PM_ENCODING_FILEIMPORT = "Pm:encoding-fileimport;";
        public static readonly string PM_ENCODING_FILEEXPORT = "Pm:encoding-fileexport;";

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function48Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configuration_Node my_Conf,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function48Impl(this.EnumEventhandler,this.List_NameArgumentInitializer,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configuration = my_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, my_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function48Impl.PM_FILE_IMPORT_LISTFILE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function48Impl.PM_ENCODING_FILEIMPORT, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function48Impl.PM_ENCODING_FILEEXPORT, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            //↓TODO:未記入判定にひっかからなくなるので、初期値は書かない。
            //f0.SetAttribute(Expression_Node_Function48Impl.PM_FIELDSOURCE_IMPORTLISTFILE, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);
            //f0.SetAttribute(Expression_Node_Function48Impl.PM_FIELDDESTINATION_IMPORTLISTFILE, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);

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
                this.Execute6_Sub(
                    log_Reports
                    );
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


            Expression_Node_Filepath pm_FileImportListfile_Expr;
            this.TrySelectAttribute_ExpressionFilepath(out pm_FileImportListfile_Expr, Expression_Node_Function48Impl.PM_FILE_IMPORT_LISTFILE, EnumHitcount.One, log_Reports);

            Expression_Node_String pm_FieldsourceImportlistfile_Expr;
            this.TrySelectAttribute(out pm_FieldsourceImportlistfile_Expr, Expression_Node_Function48Impl.PM_FIELDSOURCE_IMPORTLISTFILE, EnumHitcount.One, log_Reports);

            Expression_Node_String pm_FielddestinationImportlistfile_Expr;
            this.TrySelectAttribute(out pm_FielddestinationImportlistfile_Expr, Expression_Node_Function48Impl.PM_FIELDDESTINATION_IMPORTLISTFILE, EnumHitcount.One, log_Reports);

            Expression_Node_String pm_EncodingFileimport_Expr;
            this.TrySelectAttribute(out pm_EncodingFileimport_Expr, Expression_Node_Function48Impl.PM_ENCODING_FILEIMPORT, EnumHitcount.One, log_Reports);

            Expression_Node_String pm_EncodingFileexport_Expr;
            this.TrySelectAttribute(out pm_EncodingFileexport_Expr, Expression_Node_Function48Impl.PM_ENCODING_FILEEXPORT, EnumHitcount.One, log_Reports);


            //
            // メッセージボックスの表示。
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(log_Method.Fullname);
                sb.Append(":");
                sb.Append(Environment.NewLine);

                sb.Append(
                    "\n" +
                    "file-listfile = " + pm_FileImportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "\n\n" +
                    "fieldsource-importlistfile = " + pm_FieldsourceImportlistfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "\n\n" +
                    "fielddestination-importlistfile = " + pm_FielddestinationImportlistfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "\n\n" +
                    "encoding-fileimport=[" + pm_EncodingFileimport_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    "encoding-fileexport=[" + pm_EncodingFileexport_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    ""
                    );

                MessageBox.Show(sb.ToString(), "デバッグ表示");
            }


            // CSVファイル読取り
            Table_Humaninput tableH;
            if (log_Reports.Successful)
            {
                //
                // CSVソースファイル読取
                //
                CsvTo_Table_HumaninputImpl reader = new CsvTo_Table_HumaninputImpl();

                Request_ReadsTable request_tblReads = new Request_ReadsTableImpl();
                Format_Table_Humaninput tblFormat_puts = new Format_Table_HumaninputImpl();
                request_tblReads.Name_PutToTable = log_Method.Fullname;//暫定
                request_tblReads.Expression_Filepath = pm_FileImportListfile_Expr;

                tableH = reader.Read(
                    request_tblReads,
                    tblFormat_puts,
                    true,
                    log_Reports
                    );
            }
            else
            {
                tableH = null;
            }

            if (log_Reports.Successful)
            {

                int rowNumber = 1;
                foreach (DataRow row in tableH.DataTable.Rows)
                {

                    //記述されているファイルパス
                    string filepath_Source_Cur;
                    string filepath_Destination_Cur;
                    if (log_Reports.Successful)
                    {
                        //"FILE"
                        string field1 = pm_FieldsourceImportlistfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint,log_Reports);
                        //"FILE2"
                        string field2 = pm_FielddestinationImportlistfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                        String_HumaninputImpl.TryParse(row[field1], out filepath_Source_Cur, "", "", log_Method, log_Reports);
                        String_HumaninputImpl.TryParse(row[field2], out filepath_Destination_Cur, "", "", log_Method, log_Reports);
                        //if (log_Method.CanDebug(9))
                        //{
                        //log_Method.WriteDebug_ToConsole("コピーしたいfilepath：①[" + filepath_Source_Cur + "]→②[" + filepath_Destination_Cur + "]");
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
                    if ("" != filepath_Source_Cur && "" != filepath_Destination_Cur)
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


                            //コピー先フォルダが存在しない場合、フォルダを作成
                            string nameFolderDestination = System.IO.Path.GetDirectoryName(filepath_Destination_Cur);
                            if (!System.IO.Directory.Exists(nameFolderDestination))
                            {
                                // フォルダ作成
                                System.IO.Directory.CreateDirectory(nameFolderDestination);

                                //TODO:作成したフォルダに、フォルダの属性を複写
                                //System.IO.File.SetAttributes(nameFolderDestination, System.IO.File.GetAttributes(Source_Folder_Name));
                            }


                            //第一引数で示されたファイルを、第二引数で示されたファイル位置にコピー。
                            //第3項にtrueを指定することにより、上書きを許可
                            System.IO.File.Copy(filepath_Source_Cur, filepath_Destination_Cur, true);



                            //エンコーディングを変換する
                            {
                                Encoding encodingSrc;
                                {
                                    string nameEncodingSrc = pm_EncodingFileimport_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                                    if ("" != nameEncodingSrc)
                                    {
                                        encodingSrc = Encoding.GetEncoding(nameEncodingSrc);
                                    }
                                    else
                                    {
                                        encodingSrc = null;
                                    }
                                }

                                Encoding encodingDst;
                                {
                                    string nameEncodingDst = pm_EncodingFileexport_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                                    if ("" != nameEncodingDst)
                                    {
                                        encodingDst = Encoding.GetEncoding(nameEncodingDst);
                                    }
                                    else
                                    {
                                        encodingDst = Global.ENCODING_CSV;
                                    }
                                }

                                if (null != encodingSrc && (encodingSrc != encodingDst))
                                {
                                    //エンコーディング変換を行う。
                                    log_Method.WriteDebug_ToConsole("エンコーディング変換[" + encodingSrc.EncodingName + "]→[" + encodingDst.EncodingName + "]");

                                    string textAll = System.IO.File.ReadAllText(filepath_Source_Cur);

                                    byte[] temp1 = encodingSrc.GetBytes(textAll);
                                    byte[] temp2 = System.Text.Encoding.Convert(encodingSrc, encodingDst, temp1);
                                    textAll = encodingDst.GetString(temp2);

                                    System.IO.File.WriteAllText(filepath_Destination_Cur, textAll);
                                }
                            }


                        }
                        else
                        {
                            //エラー
                            //
                            error_Filepath_Source = filepath_Source_Cur;
                            error_RowNumber = rowNumber;
                            error_Table_Humaninput = tableH;
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
                tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Configuration(error_Table_Humaninput), log_Reports);//設定位置パンくずリスト

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
