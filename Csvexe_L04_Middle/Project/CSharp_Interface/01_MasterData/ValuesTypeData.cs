using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Middle
{
    public abstract class ValuesTypeData
    {



        #region 用意
        //────────────────────────────────────────
        //
        // テーブルのテーブル系
        //

        /// <summary>
        /// Aa_Files.csv です。
        /// プログラムの中で自動的に付けられます。手動で設定することはありません。
        /// </summary>
        public const string S_TABLES_FILE = "T:TablesFile;";

        /// <summary>
        /// レイアウト・テーブルの一覧です。
        /// </summary>
        public const string S_TABLES_FORM = "T:TablesForm;";

        //────────────────────────────────────────
        //
        // テーブル系
        //

        /// <summary>
        /// スタイルシートです。
        /// </summary>
        public const string S_TABLE_STYLESHEET = "T:TableStylesheet;";

        /// <summary>
        /// エラーメッセージ表です。
        /// </summary>
        public const string S_TABLE_ERRORMESSAGES = "T:TableErrermessages;";

        /// <summary>
        /// データ・テーブルです。
        /// </summary>
        public const string S_TABLE_DATA = "T:TableData;";

        /// <summary>
        /// レイアウト・テーブルです。
        /// </summary>
        public const string S_TABLE_FORM = "T:TableForm;";

        /// <summary>
        /// レイアウト・テーブルです。C:Lst;型コントロールの設定が書かれています。
        /// </summary>
        public const string S_TABLE_FORM_LST = "T:TableFormLst;";

        //────────────────────────────────────────
        //
        // コード系
        //

        /// <summary>
        /// バリデーターXMLです。
        /// </summary>
        public const string S_CODE_VALIDATORS = "T:CodeValidators;";

        /// <summary>
        /// 関数XMLです。
        /// </summary>
        public const string S_CODE_FUNCTIONS = "T:CodeFunctions;";

        /// <summary>
        /// トゥゲザーXMLです。
        /// </summary>
        public const string S_CODE_TOGETHERS = "T:CodeTogethers;";

        //────────────────────────────────────────
        #endregion
        


        #region 生成と破棄
        //────────────────────────────────────────

        static ValuesTypeData()
        {
            {
                List<string> l = new List<string>();
                l.Add(ValuesTypeData.S_TABLES_FILE);
                l.Add(ValuesTypeData.S_TABLE_DATA);
                l.Add(ValuesTypeData.S_TABLE_FORM);
                l.Add(ValuesTypeData.S_TABLE_FORM_LST);
                l.Add(ValuesTypeData.S_TABLE_STYLESHEET);
                l.Add(ValuesTypeData.S_TABLE_ERRORMESSAGES);
                l.Add(ValuesTypeData.S_TABLES_FORM);
                ValuesTypeData.LISTS_TABLES = l;
            }

            {
                List<string> l = new List<string>();
                l.Add(ValuesTypeData.S_CODE_VALIDATORS);
                l.Add(ValuesTypeData.S_CODE_FUNCTIONS);
                l.Add(ValuesTypeData.S_CODE_TOGETHERS);
                ValuesTypeData.LISTS_CODES = l;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// エラーメッセージ用に、全部の要素を表示します。
        /// (string message all items)
        /// </summary>
        /// <returns></returns>
        public static string Message_Allitems()
        {
            StringBuilder sb = new StringBuilder();

            int n = 0;

            foreach (string s in ValuesTypeData.LISTS_TABLES)
            {
                sb.Append(s);
                sb.Append(" ");

                n++;
                if (1 < n && n % 5 == 0)
                {
                    sb.Append(Environment.NewLine);
                }
            }

            foreach (string s in ValuesTypeData.LISTS_CODES)
            {
                sb.Append(s);
                sb.Append(" ");

                n++;
                if (1 < n && n % 5 == 0)
                {
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────
        //
        // XML or CSV
        //

        public static bool TestTable(string sTypeData)
        {
            return ValuesTypeData.LISTS_TABLES.Contains(sTypeData);
        }

        public static bool TestCode(string sTypeData)
        {
            return ValuesTypeData.LISTS_CODES.Contains(sTypeData);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// テーブル種類名一覧。
        /// </summary>
        private static readonly List<string> LISTS_TABLES;

        /// <summary>
        /// コード種類名一覧。
        /// </summary>
        private static readonly List<string> LISTS_CODES;

        //────────────────────────────────────────
        #endregion



    }
}
