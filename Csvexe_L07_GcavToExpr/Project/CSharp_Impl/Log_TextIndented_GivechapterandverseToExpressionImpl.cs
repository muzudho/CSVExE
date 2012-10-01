using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{


    public class Log_TextIndented_GivechapterandverseToExpressionImpl : Log_TextIndentedImpl, Log_TextIndented_GivechapterandverseToExpression
    {



        #region アクション
        //────────────────────────────────────────

        public void Increment(string sNodeNameComment)
        {
            if (this.bEnabled)
            {
                base.Increment();
                this.AppendI(0, "＜");
                this.Append(sNodeNameComment);
                this.Append("＞");
                this.Newline();
            }
        }

        public void Increment(string sNodeNameComment, Dictionary<string, string> sDic)
        {
            if (this.bEnabled)
            {
                base.Increment();
                this.AppendI(0, "＜");
                this.Append(sNodeNameComment);

                foreach (KeyValuePair<string, string> kvp in sDic)
                {
                    this.Append("　");
                    this.Append(kvp.Key);
                    this.Append("＝”");
                    this.Append(kvp.Value);
                }

                this.Append("”＞");
                this.Newline();
            }
        }

        public void Decrement(string sNodeNameComment)
        {
            if (this.bEnabled)
            {
                this.AppendI(0, "＜／");
                this.Append(sNodeNameComment);
                this.Append("＞");
                this.Newline();
                base.Decrement();
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private bool bEnabled;

        /// <summary>
        /// 採ログの有無。
        /// </summary>
        public bool BEnabled
        {
            get
            {
                return this.bEnabled;
            }
            set
            {
                this.bEnabled = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
