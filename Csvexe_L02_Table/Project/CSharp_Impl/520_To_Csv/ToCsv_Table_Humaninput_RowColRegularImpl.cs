using System;
using System.Collections.Generic;
using System.Data;//DataTable
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports


namespace Xenon.Table
{


    public class ToCsv_Table_Humaninput_RowColRegularImpl
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
        public ToCsv_Table_Humaninput_RowColRegularImpl()
        {
            this.exceptedFields = new ExceptedFields();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public string ToCsvText(
            Table_Humaninput hiTable,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.Name_Library, this, "ToCsvText",log_Reports);

            Log_TextIndented log_ReportsResult = new Log_TextIndentedImpl();

            RecordFielddefinition error_RecordFielddefinition;
            Exception err_E;
            int err_NColIndex;
            Fielddefinition err_FldDef;
            if (null == hiTable)
            {
                // エラー
                goto gt_Error_NullTable;
            }

            CsvEscapeImpl ce = new CsvEscapeImpl();

            // フィールド名をカンマ区切りで出力します。最後にENDを付加します。

            // フィールド定義部
            if (hiTable.RecordFielddefinition.Count < 1)
            {
                //エラー。
                error_RecordFielddefinition = hiTable.RecordFielddefinition;
                goto gt_Error_FieldZero;
            }


            // フィールド定義部：名前
            hiTable.RecordFielddefinition.ForEach(delegate(Fielddefinition fielddefinition, ref bool isBreak, Log_Reports log_Reports2)
            {
                if (this.ExceptedFields.TryExceptedField(fielddefinition.Name_Trimupper))
                {
                    // 出力しないフィールドの場合、無視します。
                }
                else
                {
                    log_ReportsResult.Append(ce.EscapeCell(fielddefinition.Name_Humaninput));
                    log_ReportsResult.Append(",");
                }
            }, log_Reports);
            log_ReportsResult.Append(ToCsv_Table_Humaninput_RowColRegularImpl.S_END);
            log_ReportsResult.Append(Environment.NewLine);//改行

            // フィールド定義部：型
            hiTable.RecordFielddefinition.ForEach(delegate(Fielddefinition fielddefinition, ref bool isBreak, Log_Reports log_Reports2)
            {
                if (this.ExceptedFields.TryExceptedField(fielddefinition.Name_Trimupper))
                {
                    // 出力しないフィールドの場合、無視します。
                }
                else
                {
                    Type type = fielddefinition.Type;

                    if (type == typeof(String_HumaninputImpl))
                    {
                        log_ReportsResult.Append(FielddefinitionImpl.S_STRING);
                    }
                    else if (type == typeof(Int_HumaninputImpl))
                    {
                        log_ReportsResult.Append(FielddefinitionImpl.S_INT);
                    }
                    else if (type == typeof(Bool_HumaninputImpl))
                    {
                        log_ReportsResult.Append(FielddefinitionImpl.S_BOOL);
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
            }, log_Reports);
            log_ReportsResult.Append(ToCsv_Table_Humaninput_RowColRegularImpl.S_END);
            log_ReportsResult.Append(Environment.NewLine);//改行

            // フィールド定義部：コメント
            hiTable.RecordFielddefinition.ForEach(delegate(Fielddefinition fielddefinition, ref bool isBreak, Log_Reports log_Reports2)
            {
                if (this.ExceptedFields.TryExceptedField(fielddefinition.Name_Trimupper))
                {
                    // 出力しないフィールドの場合、無視します。
                }
                else
                {
                    log_ReportsResult.Append(ce.EscapeCell(fielddefinition.Comment));
                    log_ReportsResult.Append(",");
                }
            }, log_Reports);
            log_ReportsResult.Append(ToCsv_Table_Humaninput_RowColRegularImpl.S_END);
            log_ReportsResult.Append(Environment.NewLine);//改行

            // 0行目から数えて3行目以降はデータ・テーブル部。

            // データ・テーブル部
            DataTable dataTable = hiTable.DataTable;

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
                    Fielddefinition fieldDefinition;
                    try
                    {
                        fieldDefinition = hiTable.RecordFielddefinition.ValueAt(nColIndex);
                    }
                    catch (Exception e)
                    {
                        // エラー。
                        err_E = e;
                        error_RecordFielddefinition = hiTable.RecordFielddefinition;
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
                        if (fieldDefinition.Type == typeof(String_HumaninputImpl))
                        {
                            sCellValue = String_HumaninputImpl.ParseString(recordFldArray[nColIndex]);
                        }
                        else if (fieldDefinition.Type == typeof(Int_HumaninputImpl))
                        {
                            sCellValue = Int_HumaninputImpl.ParseString(recordFldArray[nColIndex]);
                        }
                        else if (fieldDefinition.Type == typeof(Bool_HumaninputImpl))
                        {
                            sCellValue = Bool_HumaninputImpl.ParseString(recordFldArray[nColIndex]);
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
                log_ReportsResult.Append(ToCsv_Table_Humaninput_RowColRegularImpl.S_END);
                log_ReportsResult.Append(Environment.NewLine);//改行
            }
            log_ReportsResult.Append(ToCsv_Table_Humaninput_RowColRegularImpl.S_EOF);
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー854！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("（プログラム内部エラー）テーブルの列定義が０件です。 error_RecordFielddefinition.Count[");
                s.Append(error_RecordFielddefinition.Count);
                s.Append("] テーブル名＝[");
                s.Append(hiTable.Name);
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー853！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("（プログラム内部エラー）err_NColIndex=[");
                s.Append(err_NColIndex);
                s.Append("] error_RecordFielddefinition.Count[");
                s.Append(error_RecordFielddefinition.Count);
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
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
