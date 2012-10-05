using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//WarningReports, HumanInputFilePath


namespace Xenon.Table
{
    public class CsvTo_XenonTableNormalImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// CSVを読取り、テーブルにして返します。
        /// 
        /// 
        /// SRS仕様の実装状況
        /// ここでは、先頭行を[0]行目と数えるものとします。
        /// (1)CSVの[0]行目は列名です。
        /// (2)CSVの[1]行目は型名です。
        /// (3)CSVの[2]行目はコメントです。
        /// 
        /// (4)データ・テーブル部で、0列目に「EOF」と入っていれば終了。大文字・小文字は区別せず。
        ///    それ以降に、コメントのようなデータが入力されていることがあるが、フィールドの型に一致しないことがあるので無視。
        ///    TODO: EOF以降の行も、コメントとして残したい。
        /// 
        /// (5)列名に ”ＥＮＤ”（半角） がある場合、その手前までの列が有効データです。
        ///    ”ＥＮＤ”以降の列は無視します。
        ///    TODO: ”ＥＮＤ”以降の行も、コメントとして残したい。
        /// 
        /// (6)int型として指定されているフィールドのデータ・テーブル部に空欄があった場合、DBNull（データベース用のヌル）とします。
        /// </summary>
        /// <param name="csvText"></param>
        /// <returns>列名情報も含むテーブル。列の型は文字列型とします。</returns>
        public XenonTable Read(
            string string_Csv,
            Request_ReadsTable forTable_request,
            XenonTableformat forTable_puts,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.Name_Library, this, "Read(1)",log_Reports);

            XenonTable xenonTable = new XenonTableImpl(forTable_request.Name_PutToTable,forTable_request.Expression_Filepath);
            xenonTable.Tableunit = forTable_request.Tableunit;
            xenonTable.Typedata = forTable_request.Typedata;
            xenonTable.IsDatebackupActivated = forTable_request.IsDatebackupActivated;
            xenonTable.XenonTableformat = forTable_puts;


            Exception err_Excp;
            int error_Count_Index;
            string[] error_Fields_Cur;


            //
            // 型定義部
            //
            // （※NO,ID,EXPL,NAME など、フィールドの定義を持つテーブル）
            //
            List<XenonFielddefinition> list_FldDef = new List<XenonFielddefinition>();

            //
            // データ・テーブル部
            //
            List<List<string>> dataTableRows = new List<List<string>>();

            // CSVテキストを読み込み、型とデータのバッファーを作成します。
            System.IO.StringReader reader = new System.IO.StringReader(string_Csv);
            CsvEscapeImpl ce = new CsvEscapeImpl();

            // CSVを解析して、テーブル形式で格納。
            {
                // データとして認識する列の総数です。
                int nDataColumnsCount = 0;

                int nRowIndex = 0;
                string[] fields_Cur;
                while (-1 < reader.Peek())
                {
                    string sLine = reader.ReadLine();

                    fields_Cur = ce.UnescapeRecordToFieldList(sLine,',').ToArray();
                    //sFields = sLine.Split(',');


                    if (0 == nRowIndex)
                    {
                        // 0行目
                        
                        // 列名の行とします。

                        for (int nColumnIx = 0; nColumnIx < fields_Cur.Length; nColumnIx++)
                        {
                            string sColumnName = fields_Cur[nColumnIx];

                            // 列名を読み込みました。

                            // トリム＆大文字
                            string sCellValueTU = sColumnName.Trim().ToUpper();
                            if (ToCsv_OTableImpl.S_END == sCellValueTU)
                            {
                                // 列名に ”ＥＮＤ” がある場合、その手前までの列が有効データです。
                                // ”ＥＮＤ” 以降の列は無視します。
                                goto field_name_reading_end;
                            }

                            // テーブルのフィールドを追加します。型の既定値は文字列型とします。
                            XenonFielddefinitionImpl fieldDef = new XenonFielddefinitionImpl(sColumnName, typeof(XenonValue_StringImpl));
                            list_FldDef.Add(fieldDef);
                            nDataColumnsCount++;
                        }


                        // 0行目は、テーブルのデータとしては持ちません。
                    }
                    else if (1 == nRowIndex)
                    {
                        // 1行目
                        
                        // フィールド型名の行。

                        for (int nColumnIx = 0; nColumnIx < nDataColumnsCount; nColumnIx++)
                        {
                            string sFieldTypeNameLower;
                            try
                            {
                                sFieldTypeNameLower = fields_Cur[nColumnIx].ToLower();
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                err_Excp = e;
                                goto gt_Error_FdIndexOutOfRangeException;
                            }

                            // 列の型名を読み込みました。

                            // テーブルのフィールドを追加します。型の既定値は文字列型とします。
                            // TODO int型とboolean型にも対応したい。
                            if (XenonFielddefinitionImpl.S_STRING.Equals(sFieldTypeNameLower))
                            {
                                list_FldDef[nColumnIx].Type = typeof(XenonValue_StringImpl);
                            }
                            else if (XenonFielddefinitionImpl.S_INT.Equals(sFieldTypeNameLower))
                            {
                                list_FldDef[nColumnIx].Type = typeof(XenonValue_IntImpl);
                            }
                            else if (XenonFielddefinitionImpl.S_BOOL.Equals(sFieldTypeNameLower))
                            {
                                // 2009-11-11修正：SRS仕様では「bool」が正しい。「boolean」は間違い。
                                list_FldDef[nColumnIx].Type = typeof(XenonValue_BoolImpl);
                            }
                            else
                            {
                                // 型が未定義の列は、文字列型として読み取ります。

                                // TODO:警告を出すか？

                                list_FldDef[nColumnIx].Type = typeof(XenonValue_StringImpl);
                            }
                        }

                        // 1行目は、テーブルのデータとしては持ちません。
                    }
                    else if (2 == nRowIndex)
                    {
                        // 2行目
                        
                        // フィールドのコメントの行。
                        // TODO: フィールドのコメントの行は省略されることがある。

                        for (int column = 0; column < nDataColumnsCount; column++)
                        {
                            if (fields_Cur.Length<=column)
                            {
                                error_Fields_Cur = fields_Cur;
                                //error_Count_Columns = fields_Cur.Length;
                                error_Count_Index = column;
                                goto gt_Error_CommentFieldCount;
                            }

                            string comment_Field = fields_Cur[column];//todo:bug:境界線エラーをキャッチしてない。

                            list_FldDef[column].Comment = comment_Field;
                        }

                        // 2行目は、テーブルのデータとしては持ちません。
                    }
                    else
                    {
                        // 3行目以降のループ。
                        List<string> sList_Column = new List<string>();

                        // データ・テーブル部で、0列目に「EOF」と入っていれば終了。大文字・小文字は区別せず。

                        if (fields_Cur.Length < 1)
                        {
                            // 空行は無視。
                            goto end_recordAdd;
                        }
                        //ystem.Console.WriteLine(InfxenonTable.LibraryName + ":" + this.GetType().Name + "#UnescapeToList: sFields[0]=[" + sFields[0] + "] sLine=[" + sLine + "]");

                        string sCellValueTrimUpper = fields_Cur[0].Trim().ToUpper();
                        if (ToCsv_OTableImpl.S_EOF == sCellValueTrimUpper)
                        {
                            goto reading_end;
                        }

                        int nColumnCount;
                        if (fields_Cur.Length < nDataColumnsCount)
                        {
                            // 「実際にデータとして存在する列数」
                            nColumnCount = fields_Cur.Length;
                        }
                        else
                        {
                            // 「データとして存在する筈の列数」（これ以降の列は無視）
                            nColumnCount = nDataColumnsCount;
                        }


                        for (int nColumnIx = 0; nColumnIx < nColumnCount; nColumnIx++)
                        {
                            string sValue;

                            sValue = fields_Cur[nColumnIx];

                            if (list_FldDef.Count <= nColumnIx)
                            {
                                // 0行目で数えた列数より多い場合。

                                // テーブルのフィールドを追加します。型は文字列型とします。名前は空文字列です。
                                list_FldDef.Add(new XenonFielddefinitionImpl("", typeof(XenonValue_StringImpl)));
                            }

                            sList_Column.Add(sValue);
                        }

                        dataTableRows.Add(sList_Column);
                    end_recordAdd:
                        ;
                    }
                field_name_reading_end:

                    //essageBox.Show("ttbwIndex=[" + ttbwIndex + "]行目ループ終わり", "TableCsvLibデバッグ");
                    nRowIndex++;
                }
            }
        reading_end:

            // ストリームを閉じます。
            reader.Close();

            //essageBox.Show("CSV読取終わり1 rows.Count=[" + rows.Count + "]", "TableCsvLibデバッグ");


            // テーブルのフィールド定義。
            xenonTable.CreateTable(list_FldDef,log_Reports);
            if(log_Reports.Successful)
            {
                // データ本体のセット。
                xenonTable.AddRecordList(dataTableRows, list_FldDef, log_Reports);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_CommentFieldCount:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1356！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("「フィールド・コメント」行のフィールド数が合いませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("index＝[");
                s.Append(error_Count_Index);
                s.Append("]");
                s.Append(Environment.NewLine);

                s.Append("列数＝[");
                s.Append(error_Fields_Cur.Length);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("──────────fields ここから");
                s.Append(Environment.NewLine);
                foreach (string field in error_Fields_Cur)
                {
                    s.Append("field=[");
                    s.Append(field);
                    s.Append("]");
                    s.Append(Environment.NewLine);
                }
                s.Append("──────────fields ここまで");
                s.Append(Environment.NewLine);

                //
                // ヒント
                s.Append(Log_RecordReportsImpl.ToText_Configurationtree(xenonTable));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_FdIndexOutOfRangeException:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー132！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Newline();
                
                s.Append("フィールド定義の数が合いませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                string sFpatha = forTable_request.Expression_Filepath.Execute4_OnExpressionString(
                    EnumHitcount.Unconstraint, log_Reports);
                s.Append("ファイルパス＝[");
                s.Append(sFpatha);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                //
                // ヒント
                s.Append(err_Excp.Message);

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
            return xenonTable;
        }

        //────────────────────────────────────────
        #endregion



    }
}
