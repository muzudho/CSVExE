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
            Exception err_Excep;
            int error_IndexColumn;
            Fielddefinition error_Fielddefinition;
            object error_Item;

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
                    switch(fielddefinition.Type_Field)
                    {
                        case EnumTypeFielddefinition.String:
                            {
                                log_ReportsResult.Append(FielddefinitionImpl.S_STRING);
                            }
                            break;
                        case EnumTypeFielddefinition.Int:
                            {
                                log_ReportsResult.Append(FielddefinitionImpl.S_INT);
                            }
                            break;
                        case EnumTypeFielddefinition.Bool:
                            {
                                log_ReportsResult.Append(FielddefinitionImpl.S_BOOL);
                            }
                            break;
                        default:
                            {
                                // TODO エラー対応。

                                // 未定義の型があった場合、そのまま出力します。
                                // C#のメッセージになるかと思います。
                                log_ReportsResult.Append(fielddefinition.ToString_Type());
                            }
                            break;
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
                object[] itemArray = dataRow.ItemArray;// ItemArrayは1回の呼び出しが重い。
                for (int indexColumn = 0; indexColumn < itemArray.Length; indexColumn++)
                {

                    // TODO:範囲 リストサイズが0の時がある←プログラムミス？
                    Fielddefinition fielddefinition;
                    try
                    {
                        fielddefinition = hiTable.RecordFielddefinition.ValueAt(indexColumn);
                    }
                    catch (Exception e)
                    {
                        // エラー。
                        err_Excep = e;
                        error_RecordFielddefinition = hiTable.RecordFielddefinition;
                        error_IndexColumn = indexColumn;
                        goto gt_Error_OutOfIndex;
                    }

                    if (this.ExceptedFields.TryExceptedField(fielddefinition.Name_Trimupper))
                    {
                        // 出力しないフィールドの場合、無視します。
                    }
                    else
                    {
                        string value_Cell;
                        object item = itemArray[indexColumn];

                        if (item is Value_Humaninput)
                        {
                            value_Cell = ((Value_Humaninput)item).Text;
                        }
                        else if (item is string)
                        {
                            //フィールド定義部など。
                            value_Cell = (string)item;
                        }
                        else if (item is DBNull)
                        {
                            //空欄。
                            value_Cell = "";
                        }
                        else
                        {
                            // エラー
                            error_Item = item;
                            error_Fielddefinition = fielddefinition;
                            goto gt_Error_UndefinedFieldType;
                        }

                        log_ReportsResult.Append(ce.EscapeCell(value_Cell));
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
                s.Append(error_IndexColumn);
                s.Append("] error_RecordFielddefinition.Count[");
                s.Append(error_RecordFielddefinition.Count);
                s.Append("]");
                s.Newline();

                // ヒント
                s.Append(r.Message_SException(err_Excep));

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

                s.Append("（プログラム内部エラー）CSVを出力しようとしたとき、未定義のフィールド型=[");
                s.Append(error_Fielddefinition.ToString_Type());
                s.Append("]がありました。");
                s.Newline();

                s.Append("型名=[");
                s.Append(error_Item.GetType().Name);
                s.Append("]");
                s.Newline();

                s.Append("型は[");
                s.Append(typeof(String_HumaninputImpl));
                s.Append("],[");
                s.Append(typeof(Int_HumaninputImpl));
                s.Append("],[");
                s.Append(typeof(Bool_HumaninputImpl));
                s.Append("]が使えます。");
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
