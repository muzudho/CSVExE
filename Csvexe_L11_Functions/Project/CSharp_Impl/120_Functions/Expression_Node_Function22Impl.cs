using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data;//DataRow
using Xenon.Syntax;
using Xenon.Middle;
using Xenon.MiddleImpl;
using Xenon.Table;//DefaultTable

namespace Xenon.Functions
{

    /// <summary>
    /// 「Aa_Files.csv」読取り。
    /// </summary>
    public class Expression_Node_Function22Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        /// <summary>
        /// 関数名。
        /// </summary>
        public static readonly string NAME_FUNCTION = "Sf:Action22;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        ///// <summary>
        ///// 「Aa_Files.csv」のファイルパスが入っている、変数名。
        ///// 
        ///// 元は名無し。
        ///// </summary>
        //public static readonly string S_PM_NAME_VAR_FILEPATH = PmNames.S_NAME_VAR_FILEPATH.Name_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        // ──────────────────────────────

        public Expression_Node_Function22Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
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

            Expression_Node_Function f0 = new Expression_Node_Function22Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion

       

        #region アクション
        //────────────────────────────────────────

        public string GetSNameTableAafilescsv()
        {
            return NamesVar.S_ST_FILES;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ファイルからテーブルを読み取り、モデルに内容を挿入します。
        /// </summary>
        /// <param name="moMre"></param>
        /// <param name="log_Reports"></param>
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);

            string sFncName;
            this.TrySelectAttribute(out sFncName, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {
                //
                //
                //
                //（）タスク・デスクリプション
                //
                //
                //
                if (this.Functionparameterset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.Functionparameterset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(
                        EnumHitcount.Unconstraint,
                        log_Reports
                        );

                    log_Reports.Comment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName + "]アクションを実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe += "／追記：[" + sFncName + "]アクションを実行。";
                }

                //
                //
                //
                //
                this.Functionparameterset.Node_EventOrigin += "＜" + log_Method.Fullname + ":＞";



                //
                // 「バックアップ対象のファイルのパス一覧」の変数準備。
                //
                this.List_Expression_Filepath_BackupRequest_Out = new List<Expression_Node_Filepath>();


                //
                //
                //
                //「Aa_Files.csv」
                //
                //
                //
                string name_Table = this.GetSNameTableAafilescsv();
                if ("" == name_Table)
                {
                    goto gt_Error_EmptynameTable;
                }


                //
                //
                //
                //（）テーブル読取り。
                //
                //
                //
                TableHumaninput xenonTable_Aafilescsv;
                if (log_Reports.Successful)
                {
                    xenonTable_Aafilescsv = this.Read_AaFilesCsv(log_Reports);
                }
                else
                {
                    xenonTable_Aafilescsv = null;
                }


                //
                //
                //
                // 「Aa_Files.csv」を、アプリケーションにそのまま追加。
                //
                //
                //
                if (log_Reports.Successful)
                {
                    this.Owner_MemoryApplication.MemoryTables.AddTableHumaninput(xenonTable_Aafilescsv, log_Reports);
                }


                //
                // 「Aa_Files.csvに書かれているテーブルと、スクリプトファイル」を読取り、登録。
                if (log_Reports.Successful)
                {
                    // 正常時

                    this.ReadAndRegisterFiles(xenonTable_Aafilescsv, log_Reports);
                }


                //
                // 日別バックアップ用の準備
                //
                if (log_Reports.Successful)
                {
                    // 正常時
                    this.RegisterDateBackup(log_Reports);
                }



                //
                // TODO:「フォーム一覧テーブル」を更に読取に行く。
                //
                if (this.Owner_MemoryApplication.MemoryTables.Dictionary_TableHumaninput.ContainsKey(NamesVar.S_ST_AA_FORMS))
                {
                    //
                    // 「フォーム一覧テーブル」
                    TableHumaninput o_Table_Aaformscsv = this.Owner_MemoryApplication.MemoryTables.Dictionary_TableHumaninput[NamesVar.S_ST_AA_FORMS];

                    //
                    // 「テーブルに書かれているテーブル」を読取り、登録。
                    if (log_Reports.Successful)
                    {
                        // 正常時

                        this.ReadAndRegisterFiles(o_Table_Aaformscsv, log_Reports);
                    }
                }



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

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_EmptynameTable:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, PmNames.S_NAME_TABLE.Name_Pm, log_Reports);//引数名
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:110008;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「Aa_Files.csv」を読み取る要求を作成します。
        /// 旧名：ReadIndexRequest
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        private Request_ReadsTable CreateReadRequest_AaFilesCsv(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "CreateReadRequest_AaFilesCsv",log_Reports);

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("「ファイルズ登録ファイル」を読取る要求を作成します。");
            }

            //
            // 「インデックス_テーブル」読取引数
            Request_ReadsTable forIndexTable_Request = new Request_ReadsTableImpl();

            string sTableName = this.GetSNameTableAafilescsv();

            //
            // 付けるテーブル名。
            forIndexTable_Request.Name_PutToTable = sTableName;

            //
            // 「レイアウト・テーブル」に設定。
            {
                forIndexTable_Request.Typedata = ValuesTypeData.S_TABLES_FILE;
            }

            // Aa_Files.csvテーブルのファイルパス。
            {
                // 変数名。
                Expression_Node_Filepath ec_Fpath_Aafilescsv;
                log_Reports.Log_Callstack.Push(log_Method, "⑦");
                ec_Fpath_Aafilescsv = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                    new Expression_Leaf_StringImpl(NamesVar.S_SP_FILES, null, new Configurationtree_NodeImpl(log_Method.Fullname, null)),
                    true,log_Reports);
                log_Reports.Log_Callstack.Pop(log_Method, "⑦");

                forIndexTable_Request.Expression_Filepath = ec_Fpath_Aafilescsv;

                //this.TrySelectAttribute(out ec_Atom, Ec_Sf22Impl.S_PM_NAME_VAR_FILEPATH, false, EnumHitcount.Unconstraint, log_Reports);
                //if (log_Reports.Successful)
                //{
                //    // ファイルパス。
                //    log_Reports.Log_Callstack.Push(log_Method, "②");
                //    forIndexTable_Request.Expression_Node_Filepath = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                //        ec_Fpath_Aafilescsv,
                //        true,
                //        log_Reports
                //        );
                //    log_Reports.Log_Callstack.Pop(log_Method, "②");
                //}
            }

            //
            // 日別バックアップ。
            forIndexTable_Request.IsDatebackupActivated = false;

            goto gt_EndMethod;
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return forIndexTable_Request;
        }

        //────────────────────────────────────────

        private Format_TableHumaninput ReadIndexFormat()
        {
            //
            // テーブル読取り引数。
            Format_TableHumaninput forIndexTable_format = new Format_TableHumaninputImpl();

            //
            // 「int型ばかりで型が省略されているテーブル」ではない。
            forIndexTable_format.IsAllintfieldsActivated = false;

            //
            // 行の末尾をカンマで終わらない。
            forIndexTable_format.IsCommaending = false;

            return forIndexTable_format;
        }

        //────────────────────────────────────────

        private TableHumaninput Read_AaFilesCsv(Log_Reports log_Reports)
        {
            //「Aa_Files.csv」を読み取る要求を作成します。
            Request_ReadsTable forAafilescsv_Request = this.CreateReadRequest_AaFilesCsv(log_Reports);
            Format_TableHumaninput forAafilescsv_Format = this.ReadIndexFormat();

            //
            // 「Aa_Files.csv」読取り
            CsvTo_TableHumaninputImpl reader = new CsvTo_TableHumaninputImpl();
            TableHumaninput xenonTable_Aafilescsv;
            if (log_Reports.Successful)
            {
                // 正常時

                xenonTable_Aafilescsv = reader.Read(
                        forAafilescsv_Request,
                        forAafilescsv_Format,
                        true,
                        log_Reports
                        );
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            else
            {
                xenonTable_Aafilescsv = null;
            }

            //
        //
        //
        //
        gt_EndMethod:
            return xenonTable_Aafilescsv;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「Aa_Files.csv」に書かれている「テーブル」と「スクリプト」を読取り、登録します。
        /// </summary>
        private void ReadAndRegisterFiles(
            TableHumaninput xenonTable_Aafilescsv,
            Log_Reports log_Reports
            )
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "ReadAndRegisterFiles",log_Reports);


            string err_STypedata;

            //
            //
            //
            // 「Aa_Files.csv」自身の絶対ファイルパス
            //
            //
            //
            string sFpatha_Aafilescsv;
            if (log_Reports.Successful)
            {
                sFpatha_Aafilescsv = xenonTable_Aafilescsv.Expression_Filepath_ConfigStack.Execute4_OnExpressionString(
                    EnumHitcount.Unconstraint, log_Reports);
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            else
            {
                sFpatha_Aafilescsv = null;
            }


            //
            //
            //
            //「TYPE_DATA」というフィールドは必須です。
            //
            //
            //
            bool isExists_FieldTypedata;
            if (log_Reports.Successful)
            {
                if (xenonTable_Aafilescsv.DataTable.Columns.Contains(NamesFld.S_TYPE_DATA))
                {
                    isExists_FieldTypedata = true;
                }
                else
                {
                    isExists_FieldTypedata = false;
                }
            }
            else
            {
                isExists_FieldTypedata = false;
            }


            int err_NRow=1;//行番号
            if (log_Reports.Successful)
            {

                //
                // テーブルを全て（読み込まないもの除く）読み取ります。
                //

                foreach (DataRow datarow in xenonTable_Aafilescsv.DataTable.Rows)
                {


                    Request_ReadsTable requestRead = this.CreateReadRequest(
                        datarow,
                        xenonTable_Aafilescsv,
                        log_Reports);

                    if (!log_Reports.Successful)
                    {
                        //既エラー時、ループ抜け。
                        break;
                    }

                    //
                    // テーブルを読み取るのか、XMLを読み取るのかの区別。
                    //
                    if (
                        ValuesTypeData.TestTable(requestRead.Typedata) ||
                        !isExists_FieldTypedata //TYPE_DATAフィールドそのものが無ければ、エラーとはせず、テーブルとして読み込みます。
                        )
                    {
                        //
                        // テーブルなら。
                        //

                        Format_TableHumaninput forTable_format = this.Read_RequestPart_Table(
                            datarow, sFpatha_Aafilescsv, log_Reports);

                        TableHumaninput oTable;
                        // テーブル読取の実行。（書き出し専用の場合は、登録だけする）
                        oTable = this.ReadTable(
                            requestRead,
                            forTable_format,
                            log_Reports
                            );

                        // テーブルは読み込まなくても、登録はする。
                        if (log_Reports.Successful)
                        {
                            // アプリケーション・モデルに、テーブルを登録
                            this.Owner_MemoryApplication.MemoryTables.AddTableHumaninput(
                                oTable,
                                log_Reports
                                );
                        }
                        //
                    }
                    else if(
                        ValuesTypeData.TestCode(requestRead.Typedata)
                        )
                    {
                        //
                        // XMLなら。
                        //

                        MemoryCodefileinfo moScriptfileInfo = this.Read_RequestPart_Script(
                            datarow,
                            sFpatha_Aafilescsv,
                            xenonTable_Aafilescsv,
                            log_Reports
                            );

                        // 登録
                        if (log_Reports.Successful)
                        {
                            this.Owner_MemoryApplication.MemoryCodefiles.Add(
                                moScriptfileInfo,
                                log_Reports
                                );
                        }

                        //requestRead.
                        log_Method.WriteDebug_ToConsole("sTypeData=[" + requestRead.Typedata + "]");
                    }
                    else
                    {
                        //エラー。
                        err_STypedata = requestRead.Typedata;
                        goto gt_Error_TypeData;
                    }


                    //エラー報告用の行カウンター。
                    err_NRow++;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_TypeData:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, NamesFld.S_TYPE_DATA, log_Reports);//フィールド名TYPE_DATA
                tmpl.SetParameter(2, err_STypedata, log_Reports);//TYPE_DATAフィールドの値
                tmpl.SetParameter(3, ValuesTypeData.Message_Allitems(), log_Reports);//TYPE_DATAフィールドに設定できる値のリスト

                Configurationtree_Node cf = new Configurationtree_NodeImpl("データ部" + err_NRow + "行", xenonTable_Aafilescsv.Parent);
                tmpl.SetParameter(4, Log_RecordReportsImpl.ToText_Configurationtree(cf), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:110011;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        private void ReadTablesFromIndex()
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// 一覧系のテーブルの行を読み取り、テーブルを読み取る要求を作成します。
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="o_IndexTable"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        private Request_ReadsTable CreateReadRequest(
            DataRow dataRow,
            TableHumaninput o_Table_Aafiles,
            Log_Reports log_Reports
            )
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(1);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "CreateReadRequest",log_Reports);


            //
            //

            Request_ReadsTable forTable_request = new Request_ReadsTableImpl();

            //
            // 「インデックス_テーブル」の絶対ファイルパス
            Expression_Node_Filepath ec_Fpath_Aafilescsv = o_Table_Aafiles.Expression_Filepath_ConfigStack;
            string sFpatha_Aafilescsv = ec_Fpath_Aafilescsv.Execute4_OnExpressionString(
                EnumHitcount.Unconstraint, log_Reports);
            //if (log_Method.CanDebug(1))
            //{
            //    log_Method.WriteDebug_ToConsole("「Aa_Files.csv」のファイルパス＝[" + sFpatha_Aafilescsv + "]");
            //}

            if (!log_Reports.Successful)
            {
                // 既エラー。
                goto gt_EndMethod;
            }


            //
            // テーブル名
            {
                string sName_Field = NamesFld.S_NAME;
                string sTableName;
                if (String_HumaninputImpl.TryParse(
                    dataRow[sName_Field],
                    out sTableName,
                    o_Table_Aafiles.Name,
                    sName_Field,
                    log_Method,
                    log_Reports))
                {

                }

                if (!log_Reports.Successful)
                {
                    // エラー
                    goto gt_EndMethod;
                }


                forTable_request.Name_PutToTable = sTableName;
            }

            //
            // フォーム名
            {
                string sName_Field = NamesFld.S_NAME_FORM;
                string sTableUnit;
                if (dataRow.Table.Columns.Contains(sName_Field))
                {
                    bool bBool = String_HumaninputImpl.TryParse(
                        dataRow[sName_Field],
                        out sTableUnit,
                        o_Table_Aafiles.Name,
                        sName_Field,
                        log_Method,
                        log_Reports);

                    if (bBool)
                    {

                    }

                    if (!log_Reports.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sTableUnit = "";
                }
                forTable_request.Tableunit = sTableUnit;
            }

            //
            // データ・タイプです。
            {
                string sName_Field = NamesFld.S_TYPE_DATA;
                string sValue;
                if (dataRow.Table.Columns.Contains(sName_Field))
                {
                    if (String_HumaninputImpl.TryParse(
                        dataRow[sName_Field],
                        out sValue,
                        o_Table_Aafiles.Name,
                        sName_Field,
                        log_Method,
                        log_Reports))
                    {

                    }

                    if (!log_Reports.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sValue = "";
                }
                forTable_request.Typedata = sValue;
            }

            //
            // テーブルのファイルパス
            //
            Expression_Node_Filepath ec_Fpath;
            {
                this.Read_Folder_File(
                    out ec_Fpath,
                    forTable_request.Name_PutToTable,
                    sFpatha_Aafilescsv,
                    dataRow,
                    o_Table_Aafiles,
                    log_Reports
                    );

                if (log_Reports.Successful)
                {
                    forTable_request.Expression_Filepath = ec_Fpath;
                }
            }

            //
            // ファイルパスを変数にセット
            //
            {
                string sName_Field = NamesFld.S_SET_VAR_PATH;
                string sNamevar;
                if (dataRow.Table.Columns.Contains(sName_Field))
                {
                    if (String_HumaninputImpl.TryParse(
                        dataRow[sName_Field],
                        out sNamevar,
                        o_Table_Aafiles.Name,
                        sName_Field,
                        log_Method,
                        log_Reports))
                    {

                    }

                    if (!log_Reports.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sNamevar = "";
                }

                if ("" != sNamevar && null != ec_Fpath)
                {
                    // 指定があれば、ファイルパスを変数にセット。
                    this.Owner_MemoryApplication.MemoryVariables.SetFilepathValue(
                        sNamevar, ec_Fpath, false, log_Reports);

                }
            }

            //
            // 「日別バックアップ」するなら真。
            //
            {
                string sName_Field = NamesFld.S_DATE_BACKUP;
                bool bDateBackup;
                if (dataRow.Table.Columns.Contains(sName_Field))
                {
                    bool bParsedSuccessful = Bool_HumaninputImpl.TryParse(
                        dataRow[sName_Field],
                        out bDateBackup,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                        false,
                        log_Reports
                        );

                    if (!log_Reports.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {

                    }
                }
                else
                {
                    bDateBackup = false;
                }

                forTable_request.IsDatebackupActivated = bDateBackup;
            }

            //
            // 用途。／「」指定なし。／「WriteOnly」データの読取を行わない。ログ出力先を登録しているだけなど。
            //
            {
                string sName_Field = NamesFld.S_USE;
                string sField;
                if (dataRow.Table.Columns.Contains(sName_Field))
                {
                    bool bParsedSuccessful = String_HumaninputImpl.TryParse(
                        dataRow[sName_Field],
                        out sField,
                        o_Table_Aafiles.Name,
                        sName_Field,
                        log_Method,
                        log_Reports
                        );

                    if (!log_Reports.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (bParsedSuccessful)
                    {

                    }
                }
                else
                {
                    sField = "";//指定なし。
                }

                forTable_request.Use = sField;
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return forTable_request;
        }

        //────────────────────────────────────────

        /// <summary>
        /// Aa_Files.xmlの「FOLDER」「FILE」列を読取ります。
        /// </summary>
        /// <param name="ec_Fpath"></param>
        /// <param name="sTableNameToPuts"></param>
        /// <param name="sFpatha_Aafiles"></param>
        /// <param name="dataRow"></param>
        /// <param name="o_IndexTable"></param>
        /// <param name="log_Reports"></param>
        private void Read_Folder_File(
            out Expression_Node_Filepath ec_Fpath,
            string sTableNameToPuts,
            string sFpatha_Aafiles,
            DataRow dataRow,
            TableHumaninput o_IndexTable,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Read_Folder_File",log_Reports);


            string sFpath;//バックアップ用に使い回す文字列。
            ec_Fpath = null;//セットパス用に使い回す。

            {
                //
                // フォルダー変数の指定の有無
                //
                string sNamevarFolder;
                {
                    string sFieldName2 = NamesFld.S_FOLDER;
                    if (String_HumaninputImpl.TryParse(
                        dataRow[sFieldName2],
                        out sNamevarFolder,
                        o_IndexTable.Name,
                        sFieldName2,
                        log_Method,
                        log_Reports))
                    {
                        // 正常、スルー。
                    }
                    else
                    {
                        sNamevarFolder = "";
                    }
                }


                // テーブルのファイルのパスを取得
                string sName_Field = NamesFld.S_FILE;
                if (String_HumaninputImpl.TryParse(
                    dataRow[sName_Field],
                    out sFpath,
                    o_IndexTable.Name,
                    sName_Field,
                    log_Method,
                    log_Reports))
                {

                    if ("" != sNamevarFolder.Trim())
                    {
                        // FOLDER列に、変数名が指定されているとき。

                        Expression_Node_String ec_Namevar_Folder = new Expression_Leaf_StringImpl(sNamevarFolder.Trim(), null, new Configurationtree_NodeImpl(o_IndexTable.Name, null));//todo:

                        log_Reports.Log_Callstack.Push(log_Method, "③");
                        Expression_Node_Filepath ec_Fopath = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                            ec_Namevar_Folder, true, log_Reports);
                        log_Reports.Log_Callstack.Pop(log_Method, "③");

                        if (null == ec_Fopath)
                        {
                            goto gt_Error_NullFolder;
                        }

                        //if (log_Method.CanDebug(1))
                        //{
                        //    log_Method.WriteDebug_ToConsole(".csvのFOLDER列に[" + sNamevarFolder + "]と指定されていました。");
                        //}

                        log_Reports.Log_Callstack.Push(log_Method, "⑧");
                        //bug:フォルダーパスだと Execute4_OnExpressionString は空白を返す？？
                        string sFopath2 = ec_Fopath.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                        if ("" == sFopath2)
                        {
                            //bug:フォルダーパスだと Execute4_OnExpressionString は空白を返すようなので、入力値をそのまま返すことにした。
                            sFopath2 = ec_Fopath.Humaninput.Trim();
                        }
                        log_Reports.Log_Callstack.Pop(log_Method, "⑧");

                        //if (log_Method.CanDebug(1))
                        //{
                        //    log_Method.WriteDebug_ToConsole("[" + sNamevarFolder + "]変数の内容は["+sFopath2+"]");
                        //    //this.Owner_MemoryApplication.MemoryVariables.WriteDebug_ToConsole();
                        //}


                        // 「フォルダー」　＋　「￥」　＋　「相対パス」
                        sFpath = sFopath2 + System.IO.Path.DirectorySeparatorChar + sFpath;
                    }
                }

                //
                // ファイルパス
                //
                Configurationtree_NodeFilepath cf_Fpath1;
                {
                    StringBuilder s = new StringBuilder();
                    s.Append("L11_1[");
                    s.Append(NamesFile.S_AA_FILES_CSV);
                    s.Append("ファイルの");
                    s.Append(sTableNameToPuts);
                    s.Append("指定=");
                    s.Append(sFpath);
                    s.Append("]");
                    cf_Fpath1 = new Configurationtree_NodeFilepathImpl(s.ToString(), null);
                    //cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L11_1", new Configurationtree_NodeImpl(s.ToString(), null));
                }

                cf_Fpath1.InitPath(sFpath, log_Reports);

                if (!log_Reports.Successful)
                {
                    // エラー
                    goto gt_EndMethod;
                }

                ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath1);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullFolder:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:110009;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datarow"></param>
        /// <param name="forIndexTable_csvAbsFilePath"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        private Format_TableHumaninput Read_RequestPart_Table(
            DataRow datarow,
            string filepath_ForAafilescsv,
            Log_Reports log_Reports
            )
        {
            //
            // 「各テーブル」の引数
            Format_TableHumaninput forTable_format = new Format_TableHumaninputImpl();


            //
            // 縦、横がひっくり返っているかどうか。
            //
            {
                bool isRowColRev;

                bool isSuccessful_Parsed = Bool_HumaninputImpl.TryParse(
                    datarow[NamesFld.S_ROW_COL_REV],
                    out isRowColRev,
                    EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                    false,
                    log_Reports
                    );
                if (!log_Reports.Successful)
                {
                    // エラー
                    goto gt_EndMethod;
                }

                if (isSuccessful_Parsed)
                {

                }
                forTable_format.IsRowcolumnreverse = isRowColRev;
            }

            //
            // 型定義のレコード（intやboolやstringが書いてあるところ）がなく、
            // 全フィールドがint型のテーブルかどうか。
            //
            {
                bool isAllIntFields;

                bool isSuccessful_Parsed = Bool_HumaninputImpl.TryParse(
                    datarow[NamesFld.S_ALL_INT_FIELDS],
                    out isAllIntFields,
                    EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                    false,
                    log_Reports
                    );
                if (!log_Reports.Successful)
                {
                    // エラー
                    goto gt_EndMethod;
                }

                if (isSuccessful_Parsed)
                {

                }
                forTable_format.IsAllintfieldsActivated = isAllIntFields;
            }

            //
            // 行の末尾を「,」で終える場合、真。
            //
            {
                string name_Field = NamesFld.S_COMMA_ENDING;
                bool isCommaEnding;
                if (datarow.Table.Columns.Contains(name_Field))
                {
                    bool isSuccessful_Parsed = Bool_HumaninputImpl.TryParse(
                        datarow[name_Field],
                        out isCommaEnding,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                        false,
                        log_Reports
                        );
                    if (!log_Reports.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    if (isSuccessful_Parsed)
                    {

                    }
                }
                else
                {
                    isCommaEnding = false;
                }

                forTable_format.IsCommaending = isCommaEnding;
            }

            //
        //
        //
        //
        gt_EndMethod:
            return forTable_format;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="forIndexTable_csvAbsFilePath"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        private MemoryCodefileinfo Read_RequestPart_Script(
            DataRow dataRow,
            string sFpatha_Aafilescsv,
            TableHumaninput o_Table_Aafiles,
            Log_Reports log_Reports
            )
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Read_RequestPart_Script",log_Reports);

            //
            // 「各テーブル」の引数
            MemoryCodefileinfo result = new MemoryCodefileinfoImpl();


            //
            // 呼出名。
            //
            {
                string sName;

                bool bParsedSuccessful = String_HumaninputImpl.TryParse(
                    dataRow[NamesFld.S_NAME],
                    out sName,
                    sFpatha_Aafilescsv,
                    NamesFld.S_NAME,
                    log_Method,
                    log_Reports
                    );

                if (bParsedSuccessful)
                {
                    result.Name = sName;
                }
            }


            //
            // タイプデータ。
            //
            {
                string sTypedata;

                bool bParsedSuccessful = String_HumaninputImpl.TryParse(
                    dataRow[NamesFld.S_TYPE_DATA],
                    out sTypedata,
                    sFpatha_Aafilescsv,
                    NamesFld.S_NAME,
                    log_Method,
                    log_Reports
                    );

                if (bParsedSuccessful)
                {
                    result.Typedata = sTypedata;
                }
            }


            //
            // フォルダーと、ファイルパス。
            //
            Expression_Node_Filepath ec_Fpath;
            {
                this.Read_Folder_File(
                    out ec_Fpath,
                    result.Name,
                    sFpatha_Aafilescsv,
                    dataRow,
                    o_Table_Aafiles,
                    log_Reports
                    );

                result.Expression_Filepath = ec_Fpath;
            }


            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// テーブル読取。
        /// </summary>
        /// <param name="forTable_request"></param>
        /// <param name="forTable_format"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        private TableHumaninput ReadTable(
            Request_ReadsTable forSubTable_Request_TblReads,
            Format_TableHumaninput o_TableFormat_ForSubTable_Puts,
            Log_Reports log_Reports
            )
        {
            TableHumaninput o_Tbl;
            if (log_Reports.Successful)
            {
                // 正常時

                //
                // テーブル読取り
                CsvTo_TableHumaninputImpl reader = new CsvTo_TableHumaninputImpl();

                // テーブル
                o_Tbl = reader.Read(
                        forSubTable_Request_TblReads,
                        o_TableFormat_ForSubTable_Puts,
                        true,
                        log_Reports
                        );
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                if (log_Reports.Successful)
                {
                    // 正常時

                    // NOフィールドの値を 0からの連番に振りなおします。
                    o_Tbl.RenumberingNoField();
                }
            }
            else
            {
                o_Tbl = null;
            }

            //
        //
        //
        //
        gt_EndMethod:
            return o_Tbl;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「日別バックアップ」するテーブルの登録。
        /// </summary>
        /// <param name="log_Reports"></param>
        private void RegisterDateBackup(
            Log_Reports log_Reports
            )
        {
            //
            // 全てのテーブルについて。
            //
            foreach (TableHumaninput oTable in this.Owner_MemoryApplication.MemoryTables.Dictionary_TableHumaninput.Values)
            {
                //
                // フラグ読取： 日初めのバックアップを取るかどうかどうか。
                //
                bool bDateBackupFlag;

                bool bParsedSuccessful = Bool_HumaninputImpl.TryParse(
                    oTable.IsDatebackupActivated,// dataRow["DATE_BACKUP"],
                    out bDateBackupFlag,
                    EnumOperationIfErrorvalue.Error,
                    null,
                    log_Reports
                    );
                if (!log_Reports.Successful)
                {
                    // エラー
                    goto gt_EndMethod;
                }

                if (bParsedSuccessful)
                {
                    if (bDateBackupFlag)
                    {
                        //
                        // バックアップを取るなら、
                        // ファイルパスをリストに入れる。
                        //

                        Log_TextIndented txt = new Log_TextIndentedImpl();
                        oTable.ToText_Locationbreadcrumbs(txt);

                        Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L11_2", oTable);//  txt.ToString() + "のDataBackup");
                        cf_Fpath.InitPath(
                            oTable.Expression_Filepath_ConfigStack.Humaninput,
                            log_Reports
                            );
                        if (!log_Reports.Successful)
                        {
                            // 既エラー。
                            goto gt_EndMethod;
                        }

                        Expression_Node_Filepath ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);
                        this.List_Expression_Filepath_BackupRequest_Out.Add(ec_Fpath);
                    }
                }
            }

            //
        //
        //
        //
        gt_EndMethod:
            return;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<Expression_Node_Filepath> list_Expression_Filepath_BackupRequest_Out;

        /// <summary>
        /// (out)呼び出し側で、返却を受け取ること。
        /// </summary>
        public List<Expression_Node_Filepath> List_Expression_Filepath_BackupRequest_Out
        {
            get
            {
                return list_Expression_Filepath_BackupRequest_Out;
            }
            set
            {
                list_Expression_Filepath_BackupRequest_Out = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
