using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using Xenon.Syntax;
using Xenon.Table;
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
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod( Info_PartsnumPut.Name_Library, this, "Perform", log_Reports_ThisMethod);


            this.out_Errormessage = "";
            this.out_Table_Humaninput = new Table_HumaninputImpl("名無し", null, new Configurationtree_NodeImpl(log_Method.Fullname, null));


            // CSV読取
            string text_Csv;
            try
            {
                text_Csv = System.IO.File.ReadAllText(this.In_Filepathabsolute, Encoding.Default);
            }
            catch (Exception e)
            {
                // エラー
                this.out_Errormessage = e.Message;
                goto gt_EndMethod;
            }

            Request_ReadsTable request = new Request_ReadsTableImpl();
            Format_Table_Humaninput format = new Format_Table_HumaninputImpl();

            CsvTo_Table_HumaninputImpl trans = new CsvTo_Table_HumaninputImpl();
            this.out_Table_Humaninput = trans.Read(
                text_Csv,
                request,
                format,
                log_Reports_ThisMethod
                );
                
            goto gt_EndMethod;
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports_ThisMethod);
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

        protected Table_Humaninput out_Table_Humaninput;

        public Table_Humaninput Out_Table_Humaninput
        {
            get
            {
                return this.out_Table_Humaninput;
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
