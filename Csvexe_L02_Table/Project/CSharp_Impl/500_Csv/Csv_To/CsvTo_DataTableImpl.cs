﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;//DataTable


namespace Xenon.Table
{
    ///
    /// CSVファイル関係ライブラリ。
    ///
    /// 備考：CSVの先頭データが「ID」の場合、ExcelだとSYLKファイルと認識されて開けません。
    ///
    public class CsvTo_DataTableImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public CsvTo_DataTableImpl()
        {
            this.chSeparator = ',';
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// DataTableを作成します。
        /// 
        /// セルのデータ型は全て string です。
        /// </summary>
        /// <param name="csvText"></param>
        /// <returns></returns>
        public DataTable Read(
            string sText_Csv
            )
        {
            // テーブルを作成します。
            DataTable dataTable = new DataTable();

            System.IO.StringReader reader = new System.IO.StringReader(sText_Csv);

            //
            // CSVを解析して、テーブル形式で格納。
            //

            int nRowIndex = 0;
            string[] sFieldArray;
            DataRow dataRow;
            CsvEscapeImpl ce = new CsvEscapeImpl();

            if (-1 < reader.Peek())
            {
                // 1行ずつ読み取ります。

                //
                // 0 行目の読取。　列名データが入っている行です。
                //

                // 読み取った返却値を、変数に入れ直さずにスプリット。
                sFieldArray = ce.UnescapeRecordToFieldList(reader.ReadLine(), this.ChSeparator).ToArray();
                //                sFieldArray = reader.ReadLine().Split(this.SeparatorChar);//','

                // 行を作成します。
                dataRow = dataTable.NewRow();

                int nColumnIndex1 = 0;
                while (nColumnIndex1 < sFieldArray.Length)
                {
                    // 列情報を追加します。 型は文字列型とします。
                    dataTable.Columns.Add(sFieldArray[nColumnIndex1], typeof(string));

                    // データとしても早速格納します。
                    dataRow[nColumnIndex1] = sFieldArray[nColumnIndex1];

                    nColumnIndex1++;
                }

                dataTable.Rows.Add(dataRow);
                nRowIndex++;



                //
                // 1行目以降の読取。
                //
                while (-1 < reader.Peek())
                {
                    // 1行ずつ読み取ります。

                    // 読み取った返却値を、変数に入れ直さずにスプリット。
                    sFieldArray = reader.ReadLine().Split(this.ChSeparator);//','

                    // 行を作成します。
                    dataRow = dataTable.NewRow();

                    //
                    // 追加する列数
                    //
                    object[] o_RecordFieldArray = dataRow.ItemArray;//ItemArrayは1回の呼び出しが重い。
                    int nAddsColumns = sFieldArray.Length - o_RecordFieldArray.Length;
                    for (int nCount = 0; nCount < nAddsColumns; nCount++)
                    {
                        // 0行目で数えた列数より多い場合。

                        // 列を追加します。
                        // 列定義を追加しています。型は文字列型、名前は空文字列です。
                        dataTable.Columns.Add("", typeof(string));
                    }

                    int nColumnIndex3 = 0;
                    while (nColumnIndex3 < sFieldArray.Length)
                    {
                        dataRow[nColumnIndex3] = sFieldArray[nColumnIndex3];
                        nColumnIndex3++;
                    }

                    dataTable.Rows.Add(dataRow);
                    nRowIndex++;
                }
            }



            // ストリームを閉じます。
            reader.Close();

            return dataTable;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private char chSeparator;

        /// <summary>
        /// 区切り文字。初期値は「,」
        /// </summary>
        public char ChSeparator
        {
            get
            {
                return chSeparator;
            }
            set
            {
                chSeparator = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
