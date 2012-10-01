using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{

    /// <summary>
    /// 
    /// </summary>
    public class Log_TextIndentedImpl : Log_TextIndented
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Log_TextIndentedImpl()
        {
            this.nCount_IndentBase = 0;
            this.sb_Value = new StringBuilder();
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="indentCountBase"></param>
        public Log_TextIndentedImpl(int nCount_IndentBase)
        {
            this.nCount_IndentBase = nCount_IndentBase;
            this.sb_Value = new StringBuilder();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 改行を追加します。
        /// </summary>
        public void Newline()
        {
            this.Append(Environment.NewLine);
        }

        protected void AppendIndent(int nCount_Indent)
        {
            for (int nIndex = 0; nIndex < nCount_IndentBase + nCount_Indent; nIndex++)
            {
                this.Append("    ");//空白
            }
        }

        public void AppendI(int nCount_Indent, object obj)
        {
            this.AppendIndent(nCount_Indent);
            this.Append(obj.ToString());
        }

        public void AppendI(int nCount_Indent, string sValue)
        {
            this.AppendIndent(nCount_Indent);
            this.Append(sValue);
        }

        public void AppendI(int nCount_Indent, int nValue)
        {
            this.AppendIndent(nCount_Indent);
            this.Append(nValue);
        }

        public void AppendI(int nCount_Indent, bool bValue)
        {
            this.AppendIndent(nCount_Indent);
            this.Append(bValue);
        }

        public void AppendI(int nCount_Indent, char value)
        {
            this.AppendIndent(nCount_Indent);
            this.Append(value);
        }

        public void Append(object obj)
        {
            this.Append(obj.ToString());
        }

        public void Append(string sValue)
        {
            this.sb_Value.Append(sValue);
        }

        public void Append(int nValue)
        {
            this.Append(nValue.ToString());
        }

        public void Append(bool bValue)
        {
            this.Append(bValue.ToString());
        }

        public void Append(char value)
        {
            this.Append(value.ToString());
        }

        public override string ToString()
        {
            return this.sb_Value.ToString();
        }

        public void Increment()
        {
            this.nCount_IndentBase++;
        }

        public void Decrement()
        {
            this.nCount_IndentBase--;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 文字列。
        /// </summary>
        private StringBuilder sb_Value;

        //────────────────────────────────────────

        /// <summary>
        /// 底上げインデント数。
        /// </summary>
        private int nCount_IndentBase;

        //────────────────────────────────────────
        #endregion



    }
}
