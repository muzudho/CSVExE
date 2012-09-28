﻿using System;
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
        public static readonly string S_ACTION_NAME = "Sf:Action22;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        ///// <summary>
        ///// 「Aa_Files.csv」のファイルパスが入っている、変数名。
        ///// 
        ///// 元は名無し。
        ///// </summary>
        //public static readonly string S_PM_NAME_VAR_FILEPATH = PmNames.S_NAME_VAR_FILEPATH.SName_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        // ──────────────────────────────

        public Expression_Node_Function22Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function22Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);

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
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",log_Reports);

            string sFncName;
            this.TrySelectAttr(out sFncName, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                //
                //
                //
                //（）タスク・デスクリプション
                //
                //
                //
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint,
                        log_Reports
                        );

                    log_Reports.SComment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName + "]アクションを実行。";
                }
                else
                {
                    log_Reports.SComment_EventCreationMe += "／追記：[" + sFncName + "]アクションを実行。";
                }

                //
                //
                //
                //
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";



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
                string sTableName = this.GetSNameTableAafilescsv();
                if ("" == sTableName)
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
                XenonTable o_Table_Aafiles;
                if (log_Reports.BSuccessful)
                {
                    o_Table_Aafiles = this.Read_AaFilesCsv(log_Reports);
                }
                else
                {
                    o_Table_Aafiles = null;
                }


                //
                //
                //
                // 「Aa_Files.csv」を、アプリケーションにそのまま追加。
                //
                //
                //
                if (log_Reports.BSuccessful)
                {
                    this.Owner_MemoryApplication.MemoryTables.AddXenonTable(o_Table_Aafiles, log_Reports);
                }


                //
                // 「Aa_Files.csvに書かれているテーブルと、スクリプトファイル」を読取り、登録。
                if (log_Reports.BSuccessful)
                {
                    // 正常時

                    this.ReadAndRegisterFiles(o_Table_Aafiles, log_Reports);
                }


                //
                // 日別バックアップ用の準備
                //
                if (log_Reports.BSuccessful)
                {
                    // 正常時
                    this.RegisterDateBackup(log_Reports);
                }



                //
                // TODO:「フォーム一覧テーブル」を更に読取に行く。
                //
                if (this.Owner_MemoryApplication.MemoryTables.Dictionary_XenonTable.ContainsKey(NamesVar.S_ST_AA_FORMS))
                {
                    //
                    // 「フォーム一覧テーブル」
                    XenonTable o_Table_Aaformscsv = this.Owner_MemoryApplication.MemoryTables.Dictionary_XenonTable[NamesVar.S_ST_AA_FORMS];

                    //
                    // 「テーブルに書かれているテーブル」を読取り、登録。
                    if (log_Reports.BSuccessful)
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
                ((EventMonitor)this.ExpressionfncPrmset.EventMonitor).BNowactionworking = false;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_EmptynameTable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー529！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("引数 [" + PmNames.S_NAME_TABLE.SName_Pm + "] を指定してください。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
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
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "CreateReadRequest_AaFilesCsv",log_Reports);

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
            forIndexTable_Request.SName_PutToTable = sTableName;

            //
            // 「レイアウト・テーブル」に設定。
            {
                forIndexTable_Request.STypedata = ValuesTypeData.S_TABLES_FILE;
            }

            // Aa_Files.csvテーブルのファイルパス。
            {
                // 変数名。
                Expression_Node_Filepath ec_Fpath_Aafilescsv;
                log_Reports.Log_Callstack.Push(log_Method, "⑦");
                ec_Fpath_Aafilescsv = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                    new Expression_Leaf_StringImpl(NamesVar.S_SP_FILES, null, new Givechapterandverse_NodeImpl(log_Method.SHead, null)),
                    true,log_Reports);
                log_Reports.Log_Callstack.Pop(log_Method, "⑦");

                forIndexTable_Request.Expression_Filepath = ec_Fpath_Aafilescsv;

                //this.TrySelectAttr(out ec_Atom, Ec_Sf22Impl.S_PM_NAME_VAR_FILEPATH, false, Request_SelectingImpl.Unconstraint, log_Reports);
                //if (log_Reports.BSuccessful)
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
            forIndexTable_Request.BDatebackup = false;

            goto gt_EndMethod;
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return forIndexTable_Request;
        }

        //────────────────────────────────────────

        private XenonTableformat ReadIndexFormat()
        {
            //
            // テーブル読取り引数。
            XenonTableformat forIndexTable_format = new XenonTableformatImpl();

            //
            // 「int型ばかりで型が省略されているテーブル」ではない。
            forIndexTable_format.BAllintfields = false;

            //
            // 行の末尾をカンマで終わらない。
            forIndexTable_format.BCommaending = false;

            return forIndexTable_format;
        }

        //────────────────────────────────────────

        private XenonTable Read_AaFilesCsv(Log_Reports log_Reports)
        {
            //「Aa_Files.csv」を読み取る要求を作成します。
            Request_ReadsTable forAafilescsv_Request = this.CreateReadRequest_AaFilesCsv(log_Reports);
            XenonTableformat forAafilescsv_Format = this.ReadIndexFormat();

            //
            // 「Aa_Files.csv」読取り
            CsvTo_XenonTableImpl reader = new CsvTo_XenonTableImpl();
            XenonTable o_AaFilesTable;
            if (log_Reports.BSuccessful)
            {
                // 正常時

                o_AaFilesTable = reader.Read(
                        forAafilescsv_Request,
                        forAafilescsv_Format,
                        true,
                        log_Reports
                        );
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            else
            {
                o_AaFilesTable = null;
            }

            //
        //
        //
        //
        gt_EndMethod:
            return o_AaFilesTable;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「Aa_Files.csv」に書かれている「テーブル」と「スクリプト」を読取り、登録します。
        /// </summary>
        private void ReadAndRegisterFiles(
            XenonTable o_Table_Aafiles,
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
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "ReadAndRegisterFiles",log_Reports);


            string err_STypedata;

            //
            //
            //
            // 「Aa_Files.csv」自身の絶対ファイルパス
            //
            //
            //
            string sFpatha_Aafilescsv;
            if (log_Reports.BSuccessful)
            {
                sFpatha_Aafilescsv = o_Table_Aafiles.Expression_Filepath_ConfigStack.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint, log_Reports);
                if (!log_Reports.BSuccessful)
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
            bool bExistsField_TypeData;
            if (log_Reports.BSuccessful)
            {
                if (o_Table_Aafiles.DataTable.Columns.Contains(NamesFld.S_TYPE_DATA))
                {
                    bExistsField_TypeData = true;
                }
                else
                {
                    bExistsField_TypeData = false;
                }
            }
            else
            {
                bExistsField_TypeData = false;
            }


            int err_NRow=1;//行番号
            if (log_Reports.BSuccessful)
            {

                //
                // テーブルを全て（読み込まないもの除く）読み取ります。
                //

                foreach (DataRow dataRow in o_Table_Aafiles.DataTable.Rows)
                {


                    Request_ReadsTable requestRead = this.CreateReadRequest(
                        dataRow,
                        o_Table_Aafiles,
                        log_Reports);

                    if (!log_Reports.BSuccessful)
                    {
                        //既エラー時、ループ抜け。
                        break;
                    }

                    //
                    // テーブルを読み取るのか、XMLを読み取るのかの区別。
                    //
                    if (
                        ValuesTypeData.TestTable(requestRead.STypedata) ||
                        !bExistsField_TypeData //TYPE_DATAフィールドそのものが無ければ、エラーとはせず、テーブルとして読み込みます。
                        )
                    {
                        //
                        // テーブルなら。
                        //

                        XenonTableformat forTable_format = this.Read_RequestPart_Table(
                            dataRow, sFpatha_Aafilescsv, log_Reports);

                        XenonTable oTable;
                        // テーブル読取の実行。（書き出し専用の場合は、登録だけする）
                        oTable = this.ReadTable(
                            requestRead,
                            forTable_format,
                            log_Reports
                            );

                        // テーブルは読み込まなくても、登録はする。
                        if (log_Reports.BSuccessful)
                        {
                            // アプリケーション・モデルに、テーブルを登録
                            this.Owner_MemoryApplication.MemoryTables.AddXenonTable(
                                oTable,
                                log_Reports
                                );
                        }
                        //
                    }
                    else if(
                        ValuesTypeData.TestCode(requestRead.STypedata)
                        )
                    {
                        //
                        // XMLなら。
                        //

                        MemoryCodefileinfo moScriptfileInfo = this.Read_RequestPart_Script(
                            dataRow,
                            sFpatha_Aafilescsv,
                            o_Table_Aafiles,
                            log_Reports
                            );

                        // 登録
                        if (log_Reports.BSuccessful)
                        {
                            this.Owner_MemoryApplication.MemoryCodefiles.Add(
                                moScriptfileInfo,
                                log_Reports
                                );
                        }

                        //requestRead.
                        log_Method.WriteDebug_ToConsole("sTypeData=[" + requestRead.STypedata + "]");
                    }
                    else
                    {
                        //エラー。
                        err_STypedata = requestRead.STypedata;
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
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー301！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("未定義のデータ・タイプです。");
                s.NewLine();

                s.Append(NamesFld.S_TYPE_DATA);
                s.Append("=[");
                s.Append(err_STypedata);
                s.Append("]。");
                s.NewLine();
                s.NewLine();

                s.Append("次の値から選ばなければいけません。");
                s.NewLine();
                s.Append(ValuesTypeData.SMessage_Allitems());
                s.NewLine();
                s.NewLine();

                // ヒント
                {
                    Givechapterandverse_Node cf = new Givechapterandverse_NodeImpl("データ部"+err_NRow+"行",o_Table_Aafiles.Parent_Givechapterandverse);
                    //s.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));
                    s.Append(r.Message_Givechapterandverse(cf));//o_Table_Aafiles.Parent_Givechapterandverse
                }

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
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
            XenonTable o_Table_Aafiles,
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
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "CreateReadRequest",log_Reports);


            //
            //

            Request_ReadsTable forTable_request = new Request_ReadsTableImpl();

            //
            // 「インデックス_テーブル」の絶対ファイルパス
            Expression_Node_Filepath ec_Fpath_Aafilescsv = o_Table_Aafiles.Expression_Filepath_ConfigStack;
            string sFpatha_Aafilescsv = ec_Fpath_Aafilescsv.Execute_OnExpressionString(
                Request_SelectingImpl.Unconstraint, log_Reports);
            //if (log_Method.CanDebug(1))
            //{
            //    log_Method.WriteDebug_ToConsole("「Aa_Files.csv」のファイルパス＝[" + sFpatha_Aafilescsv + "]");
            //}

            if (!log_Reports.BSuccessful)
            {
                // 既エラー。
                goto gt_EndMethod;
            }


            //
            // テーブル名
            {
                string sName_Field = NamesFld.S_NAME;
                string sTableName;
                if (XenonValue_StringImpl.TryParse(
                    dataRow[sName_Field],
                    out sTableName,
                    o_Table_Aafiles.SName,
                    sName_Field,
                    log_Method,
                    log_Reports))
                {

                }

                if (!log_Reports.BSuccessful)
                {
                    // エラー
                    goto gt_EndMethod;
                }


                forTable_request.SName_PutToTable = sTableName;
            }

            //
            // フォーム名
            {
                string sName_Field = NamesFld.S_NAME_FORM;
                string sTableUnit;
                if (dataRow.Table.Columns.Contains(sName_Field))
                {
                    bool bBool = XenonValue_StringImpl.TryParse(
                        dataRow[sName_Field],
                        out sTableUnit,
                        o_Table_Aafiles.SName,
                        sName_Field,
                        log_Method,
                        log_Reports);

                    if (bBool)
                    {

                    }

                    if (!log_Reports.BSuccessful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sTableUnit = "";
                }
                forTable_request.STableunit = sTableUnit;
            }

            //
            // データ・タイプです。
            {
                string sName_Field = NamesFld.S_TYPE_DATA;
                string sValue;
                if (dataRow.Table.Columns.Contains(sName_Field))
                {
                    if (XenonValue_StringImpl.TryParse(
                        dataRow[sName_Field],
                        out sValue,
                        o_Table_Aafiles.SName,
                        sName_Field,
                        log_Method,
                        log_Reports))
                    {

                    }

                    if (!log_Reports.BSuccessful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sValue = "";
                }
                forTable_request.STypedata = sValue;
            }

            //
            // テーブルのファイルパス
            //
            Expression_Node_Filepath ec_Fpath;
            {
                this.Read_Folder_File(
                    out ec_Fpath,
                    forTable_request.SName_PutToTable,
                    sFpatha_Aafilescsv,
                    dataRow,
                    o_Table_Aafiles,
                    log_Reports
                    );

                if (log_Reports.BSuccessful)
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
                    if (XenonValue_StringImpl.TryParse(
                        dataRow[sName_Field],
                        out sNamevar,
                        o_Table_Aafiles.SName,
                        sName_Field,
                        log_Method,
                        log_Reports))
                    {

                    }

                    if (!log_Reports.BSuccessful)
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
                    bool bParsedSuccessful = XenonValue_BoolImpl.TryParse(
                        dataRow[sName_Field],
                        out bDateBackup,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                        false,
                        log_Reports
                        );

                    if (!log_Reports.BSuccessful)
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

                forTable_request.BDatebackup = bDateBackup;
            }

            //
            // 用途。／「」指定なし。／「WriteOnly」データの読取を行わない。ログ出力先を登録しているだけなど。
            //
            {
                string sName_Field = NamesFld.S_USE;
                string sField;
                if (dataRow.Table.Columns.Contains(sName_Field))
                {
                    bool bParsedSuccessful = XenonValue_StringImpl.TryParse(
                        dataRow[sName_Field],
                        out sField,
                        o_Table_Aafiles.SName,
                        sName_Field,
                        log_Method,
                        log_Reports
                        );

                    if (!log_Reports.BSuccessful)
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

                forTable_request.SUse = sField;
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
            XenonTable o_IndexTable,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Read_Folder_File",log_Reports);


            string sFpath;//バックアップ用に使い回す文字列。
            ec_Fpath = null;//セットパス用に使い回す。

            {
                //
                // フォルダー変数の指定の有無
                //
                string sNamevarFolder;
                {
                    string sFieldName2 = NamesFld.S_FOLDER;
                    if (XenonValue_StringImpl.TryParse(
                        dataRow[sFieldName2],
                        out sNamevarFolder,
                        o_IndexTable.SName,
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
                if (XenonValue_StringImpl.TryParse(
                    dataRow[sName_Field],
                    out sFpath,
                    o_IndexTable.SName,
                    sName_Field,
                    log_Method,
                    log_Reports))
                {

                    if ("" != sNamevarFolder.Trim())
                    {
                        // FOLDER列に、変数名が指定されているとき。

                        Expression_Node_String ec_Namevar_Folder = new Expression_Leaf_StringImpl(sNamevarFolder.Trim(), null, new Givechapterandverse_NodeImpl(o_IndexTable.SName, null));//todo:

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
                        //bug:フォルダーパスだと Execute_OnExpressionString は空白を返す？？
                        string sFopath2 = ec_Fopath.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                        if ("" == sFopath2)
                        {
                            //bug:フォルダーパスだと Execute_OnExpressionString は空白を返すようなので、入力値をそのまま返すことにした。
                            sFopath2 = ec_Fopath.SHumaninput.Trim();
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
                Givechapterandverse_Filepath cf_Fpath1;
                {
                    StringBuilder s = new StringBuilder();
                    s.Append("L11_1[");
                    s.Append(NamesFile.S_AA_FILES_CSV);
                    s.Append("ファイルの");
                    s.Append(sTableNameToPuts);
                    s.Append("指定=");
                    s.Append(sFpath);
                    s.Append("]");
                    cf_Fpath1 = new Givechapterandverse_FilepathImpl(s.ToString(), null);
                    //cf_Fpath = new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L11_1", new Givechapterandverse_NodeImpl(s.ToString(), null));
                }

                cf_Fpath1.InitPath(sFpath, log_Reports);

                if (!log_Reports.BSuccessful)
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
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー502！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("フォルダーパスの取得に失敗しました。");
                s.NewLine();

                // ヒント
                s.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
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
        /// <param name="dataRow"></param>
        /// <param name="forIndexTable_csvAbsFilePath"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        private XenonTableformat Read_RequestPart_Table(
            DataRow dataRow,
            string sForIndexTable_csvFpatha,
            Log_Reports log_Reports
            )
        {
            //
            // 「各テーブル」の引数
            XenonTableformat forTable_format = new XenonTableformatImpl();


            //
            // 縦、横がひっくり返っているかどうか。
            //
            {
                bool bRowColRev;

                bool bParsedSuccessful = XenonValue_BoolImpl.TryParse(
                    dataRow[NamesFld.S_ROW_COL_REV],
                    out bRowColRev,
                    EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                    false,
                    log_Reports
                    );
                if (!log_Reports.BSuccessful)
                {
                    // エラー
                    goto gt_EndMethod;
                }

                if (bParsedSuccessful)
                {

                }
                forTable_format.BRowcolumnreverse = bRowColRev;
            }

            //
            // 型定義のレコード（intやboolやstringが書いてあるところ）がなく、
            // 全フィールドがint型のテーブルかどうか。
            //
            {
                bool bAllIntFields;

                bool bParsedSuccessful = XenonValue_BoolImpl.TryParse(
                    dataRow[NamesFld.S_ALL_INT_FIELDS],
                    out bAllIntFields,
                    EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                    false,
                    log_Reports
                    );
                if (!log_Reports.BSuccessful)
                {
                    // エラー
                    goto gt_EndMethod;
                }

                if (bParsedSuccessful)
                {

                }
                forTable_format.BAllintfields = bAllIntFields;
            }

            //
            // 行の末尾を「,」で終える場合、真。
            //
            {
                string sName_Field = NamesFld.S_COMMA_ENDING;
                bool bCommaEnding;
                if (dataRow.Table.Columns.Contains(sName_Field))
                {
                    bool bParsedSuccessful = XenonValue_BoolImpl.TryParse(
                        dataRow[sName_Field],
                        out bCommaEnding,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                        false,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
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
                    bCommaEnding = false;
                }

                forTable_format.BCommaending = bCommaEnding;
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
            XenonTable o_Table_Aafiles,
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
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Read_RequestPart_Script",log_Reports);

            //
            // 「各テーブル」の引数
            MemoryCodefileinfo result = new MemoryCodefileinfoImpl();


            //
            // 呼出名。
            //
            {
                string sName;

                bool bParsedSuccessful = XenonValue_StringImpl.TryParse(
                    dataRow[NamesFld.S_NAME],
                    out sName,
                    sFpatha_Aafilescsv,
                    NamesFld.S_NAME,
                    log_Method,
                    log_Reports
                    );

                if (bParsedSuccessful)
                {
                    result.SName = sName;
                }
            }


            //
            // タイプデータ。
            //
            {
                string sTypedata;

                bool bParsedSuccessful = XenonValue_StringImpl.TryParse(
                    dataRow[NamesFld.S_TYPE_DATA],
                    out sTypedata,
                    sFpatha_Aafilescsv,
                    NamesFld.S_NAME,
                    log_Method,
                    log_Reports
                    );

                if (bParsedSuccessful)
                {
                    result.STypedata = sTypedata;
                }
            }


            //
            // フォルダーと、ファイルパス。
            //
            Expression_Node_Filepath ec_Fpath;
            {
                this.Read_Folder_File(
                    out ec_Fpath,
                    result.SName,
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
        private XenonTable ReadTable(
            Request_ReadsTable forSubTable_Request_TblReads,
            XenonTableformat o_TableFormat_ForSubTable_Puts,
            Log_Reports log_Reports
            )
        {
            XenonTable o_Tbl;
            if (log_Reports.BSuccessful)
            {
                // 正常時

                //
                // テーブル読取り
                CsvTo_XenonTableImpl reader = new CsvTo_XenonTableImpl();

                // テーブル
                o_Tbl = reader.Read(
                        forSubTable_Request_TblReads,
                        o_TableFormat_ForSubTable_Puts,
                        true,
                        log_Reports
                        );
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                if (log_Reports.BSuccessful)
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
            foreach (XenonTable oTable in this.Owner_MemoryApplication.MemoryTables.Dictionary_XenonTable.Values)
            {
                //
                // フラグ読取： 日初めのバックアップを取るかどうかどうか。
                //
                bool bDateBackupFlag;

                bool bParsedSuccessful = XenonValue_BoolImpl.TryParse(
                    oTable.BDatebackup,// dataRow["DATE_BACKUP"],
                    out bDateBackupFlag,
                    EnumOperationIfErrorvalue.Error,
                    null,
                    log_Reports
                    );
                if (!log_Reports.BSuccessful)
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
                        oTable.ToText_Path(txt);

                        Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L11_2", oTable);//  txt.ToString() + "のDataBackup");
                        cf_Fpath.InitPath(
                            oTable.Expression_Filepath_ConfigStack.SHumaninput,
                            log_Reports
                            );
                        if (!log_Reports.BSuccessful)
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