using System;
using System.Collections.Generic;
using System.Data;//DataTable
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports


namespace Xenon.Table
{


    public class ToCsv_OTableImpl
    {



        #region 用意
        //────────────────────────────────────────

        public const string S_EOF = "EOF";

        public const string S_END = "END";

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public ToCsv_OTableImpl()
        {
            this.exceptedFields = new ExceptedFields();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public string ToCsvText(
            XenonTable xenonTable,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.Name_Library, this, "ToCsvText",log_Reports);

            Log_TextIndented log_ReportsResult = new Log_TextIndentedImpl();

            List<XenonFielddefinition> err_OList_FldDef;
            Exception err_E;
            int err_NColIndex;
            XenonFielddefinition err_FldDef;
            if (null == xenonTable)
            {
                // エラー
                goto gt_Error_NullTable;
            }

            CsvEscapeImpl ce = new CsvEscapeImpl();

            // フィールド名をカンマ区切りで出力します。最後にENDを付加します。

            // フィールド定義部
            List<XenonFielddefinition> oList_FldDef = xenonTable.List_Fielddefinition;
            if (oList_FldDef.Count < 1)
            {
                //エラー。
                err_OList_FldDef = oList_FldDef;
                goto gt_Error_FieldZero;
            }


            // フィールド定義部：名前
            foreach (XenonFielddefinition o_FldDef in oList_FldDef)
            {
                if (this.ExceptedFields.TryExceptedField(o_FldDef.Name_Trimupper))
                {
                    // 出力しないフィールドの場合、無視します。
                }
                else
                {
                    log_ReportsResult.Append(ce.EscapeCell(o_FldDef.Name_Humaninput));
                    log_ReportsResult.Append(",");
                }
            }
            log_ReportsResult.Append(ToCsv_OTableImpl.S_END);
            log_ReportsResult.Append(Environment.NewLine);//改行

            // フィールド定義部：型
            foreach (XenonFielddefinitionImpl o_FldDef in oList_FldDef)
            {
                if (this.ExceptedFields.TryExceptedField(o_FldDef.Name_Trimupper))
                {
                    // 出力しないフィールドの場合、無視します。
                }
                else
                {
                    Type type = o_FldDef.Type;

                    if (type == typeof(XenonValue_StringImpl))
                    {
                        log_ReportsResult.Append(XenonFielddefinitionImpl.S_STRING);
                    }
                    else if (type == typeof(XenonValue_IntImpl))
                    {
                        log_ReportsResult.Append(XenonFielddefinitionImpl.S_INT);
                    }
                    else if (type == typeof(XenonValue_BoolImpl))
                    {
                        log_ReportsResult.Append(XenonFielddefinitionImpl.S_BOOL);
                    }
                    else
                    {
                        // TODO エラー対応。

                        // 未定義の型があった場合、そのまま出力します。
                        // C#のメッセージになるかと思います。
                        log_ReportsResult.Append(type.ToString());
                    }
                    log_ReportsResult.Append(",");
                }
            }
            log_ReportsResult.Append(ToCsv_OTableImpl.S_END);
            log_ReportsResult.Append(Environment.NewLine);//改行

            // フィールド定義部：コメント
            foreach (XenonFielddefinitionImpl o_FldDef in oList_FldDef)
            {
                if (this.ExceptedFields.TryExceptedField(o_FldDef.Name_Trimupper))
                {
                    // 出力しないフィールドの場合、無視します。
                }
                else
                {
                    log_ReportsResult.Append(ce.EscapeCell(o_FldDef.Comment));
                    log_ReportsResult.Append(",");
                }
            }
            log_ReportsResult.Append(ToCsv_OTableImpl.S_END);
            log_ReportsResult.Append(Environment.NewLine);//改行

            // 0行目から数えて3行目以降はデータ・テーブル部。

            // データ・テーブル部
            DataTable dataTable = xenonTable.DataTable;

            // 各行について
            for (int nRowIndex = 0; nRowIndex < dataTable.Rows.Count; nRowIndex++)
            {
                DataRow dataRow = dataTable.Rows[nRowIndex];

                //
                // 各フィールドについて
                //
                object[] recordFldArray = dataRow.ItemArray;// ItemArrayは1回の呼び出しが重い。
                for (int nColIndex = 0; nColIndex < recordFldArray.Length; nColIndex++)
                {

                    // TODO:範囲 リストサイズが0の時がある←プログラムミス？
                    XenonFielddefinition fieldDefinition;
                    try
                    {
                        fieldDefinition = oList_FldDef[nColIndex];
                    }
                    catch (Exception e)
                    {
                        // エラー。
                        err_E = e;
                        err_OList_FldDef = oList_FldDef;
                        err_NColIndex = nColIndex;
                        goto gt_Error_OutOfIndex;
                    }

                    if (this.ExceptedFields.TryExceptedField(fieldDefinition.Name_Trimupper))
                    {
                        // 出力しないフィールドの場合、無視します。
                    }
                    else
                    {
                        string sCellValue;
                        if (fieldDefinition.Type == typeof(XenonValue_StringImpl))
                        {
                            sCellValue = XenonValue_StringImpl.ParseString(recordFldArray[nColIndex]);
                        }
                        else if (fieldDefinition.Type == typeof(XenonValue_IntImpl))
                        {
                            sCellValue = XenonValue_IntImpl.ParseString(recordFldArray[nColIndex]);
                        }
                        else if (fieldDefinition.Type == typeof(XenonValue_BoolImpl))
                        {
                            sCellValue = XenonValue_BoolImpl.ParseString(recordFldArray[nColIndex]);
                        }
                        else
                        {
                            // エラー
                            err_FldDef = fieldDefinition;
                            goto gt_Error_UndefinedFieldType;
                        }


                        log_ReportsResult.Append(ce.EscapeCell(sCellValue));
                        log_ReportsResult.Append(',');
                    }
                }
                log_ReportsResult.Append(ToCsv_OTableImpl.S_END);
                log_ReportsResult.Append(Environment.NewLine);//改行
            }
            log_ReportsResult.Append(ToCsv_OTableImpl.S_EOF);
            // 最後に一応、改行を付けておきます。
            log_ReportsResult.Append(Environment.NewLine);//改行

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_FieldZero:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー854！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("（プログラム内部エラー）テーブルの列定義が０件です。 o_FldDefList.Count[");
                s.Append(err_OList_FldDef.Count);
                s.Append("] テーブル名＝[");
                s.Append(xenonTable.Name);
                s.Append("]");
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_OutOfIndex:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー853！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("（プログラム内部エラー）err_NColIndex=[");
                s.Append(err_NColIndex);
                s.Append("] o_FldDefList.Count[");
                s.Append(err_OList_FldDef.Count);
                s.Append("]");
                s.Newline();

                // ヒント
                s.Append(r.Message_SException(err_E));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedFieldType:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー855！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("（プログラム内部エラー）未定義のフィールド型=[");
                s.Append(err_FldDef.Type.ToString());
                s.Append("]");
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullTable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー852！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("（プログラム内部エラー）tableがヌルでした。");
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return log_ReportsResult.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private ExceptedFields exceptedFields;

        /// <summary>
        /// 出力しないフィールド名のリスト。
        /// </summary>
        public ExceptedFields ExceptedFields
        {
            get
            {
                return exceptedFields;
            }
            set
            {
                exceptedFields = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }


}
