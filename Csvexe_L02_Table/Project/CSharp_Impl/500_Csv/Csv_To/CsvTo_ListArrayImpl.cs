using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;//DataTable

namespace Xenon.Table
{
    ///
    /// CSVテキストの各セル値を、「リストのリスト」に格納します。
    ///
    /// 備考：CSVの先頭データが「ID」の場合、ExcelだとSYLKファイルと認識されて開けません。
    ///
    public class CsvTo_ListArrayImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public CsvTo_ListArrayImpl()
        {
            this.chSeparator = ',';
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// Listを作成します。
        /// 
        /// セルのデータ型は全て string です。
        /// </summary>
        /// <param name="csvText"></param>
        /// <returns></returns>
        public List<string[]> Read(
            string sText_Csv
            )
        {
            //
            // テーブルを作成します。
            //
            List<string[]> list_SArray = new List<string[]>();

            System.IO.StringReader reader = new System.IO.StringReader(sText_Csv);
            CsvEscapeImpl ce = new CsvEscapeImpl();

            // CSVを解析して、テーブル形式で格納。
            {
                int nRowIndex = 0;
                while (-1 < reader.Peek())
                {
                    string sLine = reader.ReadLine();

                    //
                    // 配列の返却値を、ダイレクトに渡します。
                    //
                    string[] sFields = ce.UnescapeRecordToFieldList(sLine, this.ChSeparator).ToArray();
                    list_SArray.Add(sFields);
                    //listArray.Add(line.Split(this.SeparatorChar));//','

                    nRowIndex++;
                }
            }

            // ストリームを閉じます。
            reader.Close();

            return list_SArray;
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
