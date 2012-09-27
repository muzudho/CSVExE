using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//WarningReports, HumanInputFilePath



namespace Xenon.Table
{
    public class CsvTo_XenonTableReverseAllIntsImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// TODO:「,」「"」に対応したい。
        /// 
        /// 
        /// 縦、横がひっくり返っていて、
        /// 型定義レコードがないCSVテーブルの読取。
        /// </summary>
        /// <param name="csvText"></param>
        /// <returns>列名情報も含むテーブル。</returns>
        public XenonTable Read(
            string sText_Csv,
            Request_ReadsTable forTable_Request,
            XenonTableformat forTable_Format,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.SName_Library, this, "Read",log_Reports);

            //
            //
            //
            //
            CsvEscapeImpl ce = new CsvEscapeImpl();

            XenonTable xenonTable = new XenonTableImpl(forTable_Request.SName_PutToTable, forTable_Request.Expression_Filepath);
            xenonTable.STableunit = forTable_Request.STableunit;
            xenonTable.STypedata = forTable_Request.STypedata;
            xenonTable.BDatebackup = forTable_Request.BDatebackup;
            xenonTable.XenonTableformat = forTable_Format;


            //
            // 一旦、テーブルを全て読み込みます。
            //
            List<List<string>> lines = new List<List<string>>();

            {
                // CSVテキストを読み込み、型とデータのバッファーを作成します。
                System.IO.StringReader reader = new System.IO.StringReader(sText_Csv);


                string[] sFields;
                while (-1 < reader.Peek())
                {
                    string sLine = reader.ReadLine();
                    List<string> tokens = new List<string>();

                    sFields = ce.UnescapeRecordToFieldList(sLine, ',').ToArray();
//                    sFields = line.Split(',');

                    int nColumnIndex = 0;
                    foreach (string sToken in sFields)
                    {
                        if (nColumnIndex == 0 && ToCsv_OTableImpl.S_END == sToken.Trim().ToUpper())
                        {
                            // 1列目にENDがある場合、その手前までの列が有効データです。
                            // END以降の行は無視します。
                            goto row_end;
                        }


                        tokens.Add(sToken);

                        nColumnIndex++;
                    }
                    lines.Add(tokens);
                }
            row_end:

                // ストリームを閉じます。
                reader.Close();
            }





            //
            // 型定義部
            //
            // （※NO,ID,EXPL,NAME など、フィールドの定義を持つテーブル）
            //
            List<XenonFielddefinition> list_FldDef = new List<XenonFielddefinition>();

            //
            // データ・テーブル部
            //
            List<List<string>> rows = new List<List<string>>();

            //
            // まず、0列目、1列目のデータを読み取ります。
            //
            int nRowIndex=0;
            foreach (List<string> tokens in lines)
            {
                XenonFielddefinition fieldDefinition = null;



                int nColumnIndex = 0;
                foreach(string sToken in tokens)
                {

                    if(0==nColumnIndex)
                    {
                        //
                        // 0列目は、フィールド名です。
                        //
                        string sFieldName = sToken;//.Trim().ToUpper();

                        // テーブルのフィールドを追加します。型の既定値は文字列型とします。
                        fieldDefinition = new XenonFielddefinitionImpl(sFieldName, typeof(XenonValue_StringImpl));
                        list_FldDef.Add(fieldDefinition);

                        //
                        // フィールドの型は、intに固定です。
                        //
                        fieldDefinition.Type = typeof(XenonValue_IntImpl);
                    }
                    else if(1==nColumnIndex)
                    {
                        //
                        // 1列目は、フィールドのコメントとします。
                        //
                        nColumnIndex = 1;
                        {
                            fieldDefinition.SComment = sToken;
                        }

                    }
                    else
                    {
                        //
                        // 2列目から右側は、データ・テーブル部。
                        //

                        if(0==nRowIndex)
                        {
                            //
                            // 先頭行
                            //

                            //
                            // 「EOF」というトークンが出てくるまで。
                            //
                            if(ToCsv_OTableImpl.S_EOF==sToken.Trim().ToUpper())
                            {
                                goto column_end;
                            }

                            List<string> record = new List<string>();

                            // 1番目のフィールド_データを追加。
                            record.Add( sToken);

                            rows.Add(record);
                        }
                        else
                        {
                            //
                            // 2番目以降のフィールド_データを追加。
                            //

                            //
                            // 先頭の2つのレコード分、切り詰めます。
                            //
                            int nDataIndex = nColumnIndex - 2;
                            if (nDataIndex < rows.Count)
                            {
                                List<string> record = rows[nDataIndex];

                                record.Add(sToken);
                            }
                            else
                            {
                                // 無視
                            }
                        }
                    }


                    nColumnIndex ++;
                }//c
            column_end:


                nRowIndex++;
            }





            //essageBox.Show("CSV読取終わり1 rows.Count=[" + rows.Count + "]", "TableCsvLibデバッグ");

            // テーブル作成。テーブルのフィールド型定義と、データ本体をセットします。
            xenonTable.CreateTable(list_FldDef,log_Reports);
            if( log_Reports.BSuccessful)
            {
                xenonTable.AddRecordList(rows, list_FldDef, log_Reports);
                //essageBox.Show("CSV読取後のテーブル作成終わり", "TableCsvLibデバッグ");
            }

            goto gt_EndMethod;
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
