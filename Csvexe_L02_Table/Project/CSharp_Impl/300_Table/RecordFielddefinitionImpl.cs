using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Table
{
    public class RecordFielddefinitionImpl : RecordFielddefinition
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public RecordFielddefinitionImpl()
        {
            this.list_Fielddefinition = new List<Fielddefinition>();
        }

        public RecordFielddefinitionImpl(List<Fielddefinition> list_Fielddefinition)
        {
            this.list_Fielddefinition = list_Fielddefinition;
        }

        //────────────────────────────────────────
        #endregion

        

        #region アクション
        //────────────────────────────────────────

        public void Add(Fielddefinition fielddefinition)
        {
            this.List_Fielddefinition.Add(fielddefinition);
        }

        public void Insert(int indexColumn, Fielddefinition fielddefinition)
        {
            this.List_Fielddefinition.Insert(indexColumn, fielddefinition);
        }

        public void ForEach(DELEGATE_Fielddefinitions delegate_Fielddefinitions, Log_Reports log_Reports)
        {
            bool isBreak = false;

            foreach (Fielddefinition fielddefinition in this.List_Fielddefinition)
            {
                delegate_Fielddefinitions(fielddefinition, ref isBreak, log_Reports);

                if (isBreak)
                {
                    break;
                }
            }
        }

        //────────────────────────────────────────

        public Fielddefinition ValueAt(int index)
        {
            return this.List_Fielddefinition[index];
        }

        //────────────────────────────────────────

        /// <summary>
        /// デバッグ用に内容をダンプします。
        /// </summary>
        /// <returns></returns>
        public string ToString_DebugDump()
        {
            StringBuilder s = new StringBuilder();

            int cur_IndexColumn = 0;
            foreach (Fielddefinition fielddefinition in this.List_Fielddefinition)
            {
                s.Append("[");
                s.Append(cur_IndexColumn);
                s.Append("](");
                s.Append(fielddefinition.Name_Humaninput);
                s.Append(":");
                s.Append(fielddefinition.ToString_Type());
                s.Append(")");

                cur_IndexColumn++;
            }

            return s.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 主に、データベースのフィールド名のindexを調べるのに利用されます。
        /// </summary>
        /// <param name="expected"></param>
        /// <returns>該当がなければ -1。</returns>
        public int ColumnIndexOf_Trimupper(string expected)
        {
            int result = -1;

            int cur_IndexColumn = 0;
            foreach (Fielddefinition fielddefinition in this.List_Fielddefinition)
            {
                if (expected == fielddefinition.Name_Trimupper)
                {
                    result = cur_IndexColumn;
                    break;
                }
                else
                {
                }

                cur_IndexColumn++;
            }

            return result;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public int Count
        {
            get
            {
                return this.List_Fielddefinition.Count;
            }
        }

        //────────────────────────────────────────

        private List<Fielddefinition> list_Fielddefinition;

        /// <summary>
        /// フィールドの型定義。
        /// </summary>
        private List<Fielddefinition> List_Fielddefinition
        {
            get
            {
                return list_Fielddefinition;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
