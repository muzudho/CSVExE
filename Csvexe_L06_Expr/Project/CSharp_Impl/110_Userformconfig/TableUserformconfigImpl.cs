using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;//OSourceImpl

namespace Xenon.Expr
{

    /// <summary>
    /// 『レイアウト設定ファイル』の内容。
    /// </summary>
    public class TableUserformconfigImpl : TableUserformconfig
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public TableUserformconfigImpl(string sName_Table, Givechapterandverse_Node cur_Gcav)
        {
            this.sName_Table = sName_Table;
            this.cur_Givechapterandverse = cur_Gcav;

            this.list_RecordUserformconfig = new List<RecordUserformconfig>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// テーブル名を出したい。
        /// </summary>
        /// <param name="txt"></param>
        public void ToDescription(Log_TextIndented txt)
        {
            txt.Increment();

            txt.AppendI(0, "<OLcnf_ConfigImpl");

            txt.AppendI(1, "テーブル名=[");
            txt.Append(this.sName_Table);
            txt.Append("]");

            txt.AppendI(0, ">");

            txt.Decrement();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Givechapterandverse_Node cur_Givechapterandverse;

        public Givechapterandverse_Node Cur_Givechapterandverse
        {
            get
            {
                return this.cur_Givechapterandverse;
            }
        }

        //────────────────────────────────────────

        private string sName_Table;

        public string SName_Table
        {
            get
            {
                return this.sName_Table;
            }
            set
            {
                this.sName_Table = value;
            }
        }

        //────────────────────────────────────────

        private List<RecordUserformconfig> list_RecordUserformconfig;

        public List<RecordUserformconfig> List_RecordUserformconfig
        {
            get
            {
                return this.list_RecordUserformconfig;
            }
            set
            {
                this.list_RecordUserformconfig = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
