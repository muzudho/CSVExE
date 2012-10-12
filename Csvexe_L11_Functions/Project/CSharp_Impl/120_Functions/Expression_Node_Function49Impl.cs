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
        /// このファイルの指定フィールドにあるファイルパスを、この関数は読み込みます。
        /// </summary>
        public static readonly string PM_FILE_IMPORT_LISTFILE = "Pm:file-import-listfile;";
        public static readonly string PM_FIELD_IMPORT_LISTFILE = "Pm:field-import-listfile;";
        public static readonly string PM_FILTER_EXTENSION_IMPORT = "Pm:filter-extension-import;";

        public static readonly string PM_FILE_EXPORT_LISTFILE = "Pm:file-export-listfile;";
        public static readonly string PM_FIELD_EXPORT_LISTFILE = "Pm:field-export-listfile;";
        public static readonly string PM_TYPEFIELD_EXPORT_LISTFILE = "Pm:typefield-export-listfile;";
        public static readonly string PM_COMMENTFIELD_EXPORT_LISTFILE = "Pm:commentfield-export-listfile;";

        public static readonly string PM_REGULAREXPRESSION_REPLACEBEFORE_NAMEFILEEXPORT = "Pm:regularexpression-replacebefore-namefileexport;";
        public static readonly string PM_REGULAREXPRESSION_REPLACEAFTER_NAMEFILEEXPORT = "Pm:regularexpression-replaceafter-namefileexport;";

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

            Expression_Node_Function f0 = new Expression_Node_Function49Impl(this.EnumEventhandler,this.List_NameArgumentInitializer,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expr;
            f0.Cur_Configurationtree = my_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, my_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function49Impl.PM_FILE_IMPORT_LISTFILE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function49Impl.PM_FIELD_IMPORT_LISTFILE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function49Impl.PM_FILTER_EXTENSION_IMPORT, new Expression_Node_StringImpl(this, my_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function49Impl.PM_FILE_EXPORT_LISTFILE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function49Impl.PM_FIELD_EXPORT_LISTFILE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function49Impl.PM_TYPEFIELD_EXPORT_LISTFILE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function49Impl.PM_COMMENTFIELD_EXPORT_LISTFILE, new Expression_Node_StringImpl(this, my_Conf), log_Reports);

            //f0.SetAttribute(Expression_Node_Function49Impl.PM_REGULAREXPRESSION_REPLACEBEFORE_NAMEFILEEXPORT, new Expression_Node_StringImpl(this, my_Conf), log_Reports);
            //f0.SetAttribute(Expression_Node_Function49Impl.PM_REGULAREXPRESSION_REPLACEAFTER_NAMEFILEEXPORT, new Expression_Node_StringImpl(this, my_Conf), log_Reports);

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


            Exception error_Exception;
            string error_Filepath_Export;


            Expression_Node_Filepath pm_FileImportListfile_Expr;
            this.TrySelectAttribute_ExpressionFilepath(out pm_FileImportListfile_Expr, Expression_Node_Function49Impl.PM_FILE_IMPORT_LISTFILE, EnumHitcount.One_Or_Zero, log_Reports);

            Expression_Node_String pm_FieldImportListfile_Expr;
            this.TrySelectAttribute(out pm_FieldImportListfile_Expr, Expression_Node_Function49Impl.PM_FIELD_IMPORT_LISTFILE, EnumHitcount.One, log_Reports);

            Expression_Node_String pm_FilterExtensionImport_Expr;
            this.TrySelectAttribute(out pm_FilterExtensionImport_Expr, Expression_Node_Function49Impl.PM_FILTER_EXTENSION_IMPORT, EnumHitcount.One, log_Reports);


            Expression_Node_Filepath pm_FileExportListfile_Expr;
            this.TrySelectAttribute_ExpressionFilepath(out pm_FileExportListfile_Expr, Expression_Node_Function49Impl.PM_FILE_EXPORT_LISTFILE, EnumHitcount.One_Or_Zero, log_Reports);

            Expression_Node_String pm_FieldExportListfile_Expr;
            this.TrySelectAttribute(out pm_FieldExportListfile_Expr, Expression_Node_Function49Impl.PM_FIELD_EXPORT_LISTFILE, EnumHitcount.One, log_Reports);

            Expression_Node_String pm_TypefieldExportListfile_Expr;
            this.TrySelectAttribute(out pm_TypefieldExportListfile_Expr, Expression_Node_Function49Impl.PM_TYPEFIELD_EXPORT_LISTFILE, EnumHitcount.One, log_Reports);

            Expression_Node_String pm_CommentfieldExportListfile_Expr;
            this.TrySelectAttribute(out pm_CommentfieldExportListfile_Expr, Expression_Node_Function49Impl.PM_COMMENTFIELD_EXPORT_LISTFILE, EnumHitcount.One, log_Reports);


            Expression_Node_String pm_RegularexpressionReplacebeforeNamefileexport_Expr;
            this.TrySelectAttribute(out pm_RegularexpressionReplacebeforeNamefileexport_Expr, Expression_Node_Function49Impl.PM_REGULAREXPRESSION_REPLACEBEFORE_NAMEFILEEXPORT, EnumHitcount.One_Or_Zero, log_Reports);

            Expression_Node_String pm_RegularexpressionReplaceafterNamefileexport_Expr;
            this.TrySelectAttribute(out pm_RegularexpressionReplaceafterNamefileexport_Expr, Expression_Node_Function49Impl.PM_REGULAREXPRESSION_REPLACEAFTER_NAMEFILEEXPORT, EnumHitcount.One_Or_Zero, log_Reports);

            
            Expression_Node_Filepath pm_FolderSource_Expr;
            this.TrySelectAttribute_ExpressionFilepath(out pm_FolderSource_Expr, Expression_Node_Function49Impl.PM_FOLDER_SOURCE, EnumHitcount.One_Or_Zero, log_Reports);

            Expression_Node_Filepath pm_FolderDestination_Expr;
            this.TrySelectAttribute_ExpressionFilepath(out pm_FolderDestination_Expr, Expression_Node_Function49Impl.PM_FOLDER_DESTINATION, EnumHitcount.One_Or_Zero, log_Reports);

            //ポップアップ指定
            string pm_Popup;
            this.TrySelectAttribute(out pm_Popup, Expression_Node_Function49Impl.PM_POPUP, EnumHitcount.One_Or_Zero, log_Reports);
            pm_Popup = pm_Popup.Trim();


            
            // メッセージボックスの表示。
            {
                Log_TextIndented str_Messagebox = new Log_TextIndentedImpl();
                str_Messagebox.Append(log_Method.Fullname);
                str_Messagebox.Append(":");
                str_Messagebox.Append(Environment.NewLine);

                this.Dictionary_Expression_Attribute.ToText_Debug(str_Messagebox, log_Reports);

                str_Messagebox.Append(
                    "file-import-listfile=[" + pm_FileImportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    "field-import-listfile=[" + pm_FieldImportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    "filter-extension-import=[" + pm_FilterExtensionImport_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +

                    "file-export-listfile=[" + pm_FileExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    "field-export-listfile=[" + pm_FieldExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    "typefield-export-listfile=[" + pm_TypefieldExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    "commentfield-export-listfile=[" + pm_CommentfieldExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +

                    "regularexpression-replacebefore-namefileexport=[" + pm_RegularexpressionReplacebeforeNamefileexport_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    "regularexpression-replaceafter-namefileexport=[" + pm_RegularexpressionReplaceafterNamefileexport_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +

                    "folder-source=[" + pm_FolderSource_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    "folder-destination=[" + pm_FolderDestination_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]\n\n" +
                    "pm_Popup=[" + pm_Popup + "]\n\n"
                    );

                MessageBox.Show(str_Messagebox.ToString(), "デバッグ表示");
            }

            //書出し先ファイルパス。
            string filepath_Export = "";
            try
            {
                filepath_Export = pm_FileExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                if ("" == filepath_Export)
                {
                    //エラー
                    error_Exception = null;
                    error_Filepath_Export = filepath_Export;
                    goto gt_Error_FilepathExport;
                }

            }
            catch (Exception ex)
            {
                //エラー
                error_Exception = ex;
                error_Filepath_Export = filepath_Export;
                goto gt_Error_FilepathExport;
            }


            // 「ファイル・リスト」CSVファイル読取り
            Table_Humaninput tableH;
            if (log_Reports.Successful)
            {
                CsvTo_Table_HumaninputImpl reader = new CsvTo_Table_HumaninputImpl();

                Request_ReadsTable request_Reads = new Request_ReadsTableImpl();
                Format_Table_Humaninput tblFormat_puts = new Format_Table_HumaninputImpl();
                request_Reads.Name_PutToTable = log_Method.Fullname;//暫定
                request_Reads.Expression_Filepath = pm_FileImportListfile_Expr;

                tableH = reader.Read(
                    request_Reads,
                    tblFormat_puts,
                    true,
                    log_Reports
                    );
            }
            else
            {
                tableH = null;
            }

            // CSVに列追加。
            string name_FieldNew;
            int index_FieldNew;
            if (log_Reports.Successful)
            {
                name_FieldNew = pm_FieldExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                string name_Typefield = pm_TypefieldExportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                Fielddefinition fielddefinition_New = new FielddefinitionImpl(name_FieldNew, FielddefinitionImpl.TypefieldFromString(name_Typefield, true, log_Reports));
                fielddefinition_New.Comment = pm_CommentfieldExportListfile_Expr.Execute4_OnExpressionString(Syntax.EnumHitcount.Unconstraint, log_Reports);
                tableH.AddField(fielddefinition_New, true, log_Reports);

                index_FieldNew = tableH.RecordFielddefinition.ColumnIndexOf_Trimupper(name_FieldNew);
            }
            else
            {
                index_FieldNew = -1;
            }


            string regularexpression_Replacebefore_Namefileexport = pm_RegularexpressionReplacebeforeNamefileexport_Expr.Execute4_OnExpressionString(Syntax.EnumHitcount.Unconstraint, log_Reports);
            string regularexpression_Replaceafter_Namefileexport = pm_RegularexpressionReplaceafterNamefileexport_Expr.Execute4_OnExpressionString(Syntax.EnumHitcount.Unconstraint, log_Reports);
            string name_FieldSource = pm_FieldImportListfile_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);// "FILE"
            if (log_Reports.Successful)
            {
                //
                // CSVソースファイル読取
                //

                int rowNumber = 1;
                tableH.ForEach_Datapart(delegate(Record_Humaninput recordH, ref bool isBreak2, Log_Reports log_Reports2)
                {
                    //記述されているファイルパス
                    string filepath_Source_Cur;
                    if (log_Reports.Successful)
                    {
                        String_HumaninputImpl.TryParse(
                            recordH.ValueAt(name_FieldSource),
                            out filepath_Source_Cur, "", "", log_Method, log_Reports);
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
                    }
                    else
                    {
                        filepathCur_Conf = null;
                    }

                    Expression_Node_Filepath filepathCur_Expr;
                    if (log_Reports.Successful)
                    {
                        filepathCur_Expr = new Expression_Node_FilepathImpl(filepathCur_Conf);
                    }
                    else
                    {
                        filepathCur_Expr = null;
                    }

                    //頭をカットする
                    Expression_Node_Filepath fileDestination_Expr;
                    if (log_Reports.Successful)
                    {
                        string filepath_Destination_New1;
                        filepathCur_Expr.TryCutFolderpath(out filepath_Destination_New1, pm_FolderSource_Expr, true, log_Reports);

                        //転送先パスの作成
                        Configurationtree_NodeFilepath fileDestination_Conf = new Configurationtree_NodeFilepathImpl(log_Method.Fullname, null);
                        fileDestination_Conf.InitPath(pm_FolderDestination_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), filepath_Destination_New1, log_Reports);

                        fileDestination_Expr = new Expression_Node_FilepathImpl(fileDestination_Conf);
                    }
                    else
                    {
                        fileDestination_Expr = null;
                    }

                    if (!log_Reports.Successful)
                    {
                        //エラー
                        isBreak2 = true;
                        goto gt_EndInnermethod;
                    }

                    //
                    //ソース側の拡張子を確認したい。
                    //
                    string extension;
                    string filterExtension = pm_FilterExtensionImport_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint,log_Reports);
                    List<string> list_FilterExtension = new CsvTo_ListImpl().Read(filterExtension);
                    fileDestination_Expr.TryGetExtension(out extension,log_Reports);
                    //log_Method.WriteDebug_ToConsole("拡張子=[" + extension + "](要素数=" + list_FilterExtension.Count + ") フィルター=[" + filterExtension + "] 含まれる？=[" + list_FilterExtension.Contains(extension) + "]");

                    if (list_FilterExtension.Contains(extension))
                    {
                        //フィルターに含まれる

                        //出力側のファイルパス
                        Value_Humaninput valueH_New = new String_HumaninputImpl(log_Method.Fullname);
                        valueH_New.Text = fileDestination_Expr.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                        //ファイル名を正規表現で置換をするか否か
                        if("" != regularexpression_Replacebefore_Namefileexport)
                        {
                            //ファイル名を正規表現で置換します。
                            //TextBox1内の郵便番号っぽい文字列の"-"を削除して、【】で囲む
                            valueH_New.Text = System.Text.RegularExpressions.Regex.Replace(
                                valueH_New.Text,
                                regularexpression_Replacebefore_Namefileexport,
                                regularexpression_Replaceafter_Namefileexport
                                );
                        }

                        //
                        // レコードの追加列に値セット。
                        //
                        recordH.SetValueAt(index_FieldNew, valueH_New, log_Reports);
                    }
                    else
                    {
                    }


                    //
                gt_EndInnermethod:
                    rowNumber++;
                }, log_Reports);
            }

            //自動連番を振ります。
            if (log_Reports.Successful)
            {
                tableH.RenumberingNoField();
            }

            //CSVファイルの書出し
            if (log_Reports.Successful)
            {
                string text_Csv = new ToCsv_Table_Humaninput_Impl().ToCsvText(tableH, log_Reports);

                try
                {

                    System.IO.File.WriteAllText(
                        filepath_Export,
                        text_Csv,
                        Global.ENCODING_CSV
                        );

                    if (pm_Popup != S_BLOCK)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();

                        s.Append("ファイルに書き込みました。");
                        s.Newline();
                        s.Append("[");
                        s.Append(filepath_Export);
                        s.Append("]");
                        s.Newline();
                        s.Newline();

                        MessageBox.Show(s.ToString(), "▲実行結果！（L02）");
                    }
                }
                catch (Exception ex)
                {
                    //エラー
                    error_Exception = ex;
                    error_Filepath_Export = filepath_Export;
                    goto gt_Error_Exception;
                }
            }


            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_FilepathExport:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Exception(error_Exception), log_Reports);//例外メッセージ
                tmpl.SetParameter(2, error_Filepath_Export, log_Reports);//出力先ファイルパス

                this.Owner_MemoryApplication.CreateErrorReport("Er:110031;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Exception(error_Exception), log_Reports);//例外メッセージ
                tmpl.SetParameter(2, error_Filepath_Export, log_Reports);//出力先ファイルパス

                this.Owner_MemoryApplication.CreateErrorReport("Er:110032;", tmpl, log_Reports);
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
