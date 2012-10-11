using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Xenon.Syntax;

namespace Xenon.Table
{
    public class Record_HumaninputImpl : Record_Humaninput
    {



        #region 用意
        //────────────────────────────────────────

        public Record_HumaninputImpl(DataRow dataRow)
        {
            this.dataRow = dataRow;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void ForEach(DELEGATE_Fields delegate_Fields, Log_Reports log_Reports)
        {
            bool isBreak = false;

            foreach (object valueField in this.DataRow.ItemArray)
            {
                delegate_Fields((Value_Humaninput)valueField, ref isBreak, log_Reports);

                if (isBreak)
                {
                    break;
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 配列の要素を取得します。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Value_Humaninput ValueAt(int index)
        {
            return (Value_Humaninput)this.DataRow[index];
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expected"></param>
        /// <returns>該当がなければ -1。</returns>
        public int ColumnIndexOf_Trimupper(string expected)
        {
            int result = -1;

            int cur_IndexColumn = 0;
            foreach(object obj in this.DataRow.ItemArray)
            {
                Value_Humaninput valueH = (Value_Humaninput)obj;

                if (expected == valueH.Text.Trim().ToUpper())
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

        /// <summary>
        /// デバッグ用に内容をダンプします。
        /// </summary>
        /// <returns></returns>
        public string ToString_DebugDump()
        {
            StringBuilder s = new StringBuilder();

            int cur_IndexColumn = 0;
            foreach (object obj in this.DataRow.ItemArray)
            {
                Value_Humaninput valueH = (Value_Humaninput)obj;

                s.Append("[");
                s.Append(cur_IndexColumn);
                s.Append("](");
                s.Append(valueH.Text);
                s.Append(")");

                cur_IndexColumn++;
            }

            return s.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private DataRow dataRow;

        public DataRow DataRow
        {
            get
            {
                return this.dataRow;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
