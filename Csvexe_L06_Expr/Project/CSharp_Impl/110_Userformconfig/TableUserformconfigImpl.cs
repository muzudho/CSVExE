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

        public TableUserformconfigImpl(string sName_Table, Configurationtree_Node cur_Conf)
        {
            this.name_Table = sName_Table;
            this.cur_Configurationtree = cur_Conf;

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
            txt.Append(this.name_Table);
            txt.Append("]");

            txt.AppendI(0, ">");

            txt.Decrement();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Configurationtree_Node cur_Configurationtree;

        public Configurationtree_Node Cur_Configurationtree
        {
            get
            {
                return this.cur_Configurationtree;
            }
        }

        //────────────────────────────────────────

        private string name_Table;

        public string Name_Table
        {
            get
            {
                return this.name_Table;
            }
            set
            {
                this.name_Table = value;
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
