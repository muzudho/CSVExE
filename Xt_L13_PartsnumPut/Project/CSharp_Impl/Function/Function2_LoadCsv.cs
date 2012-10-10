using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using Xenon.Lib;

namespace Xenon.PartsnumPut
{
    /// <summary>
    /// CSVファイルの読取
    /// </summary>
    public class Function2_LoadCsv
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Function2_LoadCsv()
        {
            this.in_Filepathabsolute = "";

            this.out_Errormessage = "";
        }

        //────────────────────────────────────────
        #endregion

        

        #region アクション
        //────────────────────────────────────────

        public void Perfrom()
        {
            this.out_Errormessage = "";
            this.out_ListArraystring_Table = new List<string[]>();

            // CSV読取
            string sCsv;
            try
            {
                sCsv = System.IO.File.ReadAllText(this.In_Filepathabsolute, Encoding.Default);
            }
            catch (Exception e)
            {
                // エラー
                this.out_Errormessage = e.Message;
                goto gt_EndMethod;
            }


            //
            // テーブル作成
            //

            System.IO.StringReader reader = new System.IO.StringReader(sCsv);

            // CSVを解析して、テーブル形式で格納。
            {
                int rowIndex = 0;
                while (-1 < reader.Peek())
                {
                    string line = reader.ReadLine();

                    //
                    // 配列の返却値を、ダイレクトに渡します。
                    //
                    this.Out_ListArraystring_Table.Add(line.Split(','));

                    rowIndex++;
                }
            }

            // ストリームを閉じます。
            reader.Close();

            goto gt_EndMethod;
        //
        gt_EndMethod:
            return;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected string in_Filepathabsolute;

        /// <summary>
        /// 絶対ファイルパス
        /// </summary>
        public string In_Filepathabsolute
        {
            get
            {
                return in_Filepathabsolute;
            }
            set
            {
                in_Filepathabsolute = value;
            }
        }

        //────────────────────────────────────────

        protected List<string[]> out_ListArraystring_Table;

        public List<string[]> Out_ListArraystring_Table
        {
            get
            {
                return out_ListArraystring_Table;
            }
        }

        //────────────────────────────────────────

        protected string out_Errormessage;

        /// <summary>
        /// エラーメッセージ。無ければ空文字列。
        /// </summary>
        public string Out_Errormessage
        {
            get
            {
                return out_Errormessage;
            }
        }

        //────────────────────────────────────────
        #endregion



    }



}
