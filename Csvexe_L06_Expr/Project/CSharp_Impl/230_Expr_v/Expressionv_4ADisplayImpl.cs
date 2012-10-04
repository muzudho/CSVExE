using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;

namespace Xenon.Expr
{
    public class Expressionv_4ADisplayImpl : Expressionv_Elem99Impl, Expressionv_4ADisplay
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Expressionv_4ADisplayImpl(Expression_Node_String parent_Expression_Node, Configurationtree_Node parent_Configurationtree_Node, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression_Node, parent_Configurationtree_Node, owner_MemoryApplication)
        {
            this.dictionary_SAttribute = new Dictionary<string, string>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 子要素の文字列を単純に連結。属性は無視。
        /// </summary>
        /// <returns></returns>
        public override string Execute4_OnExpressionString(
            EnumHitcount hits,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnExpressionString",log_Reports);
            //
            //
            StringBuilder sb_Result = new StringBuilder();

            // 属性は無視。

            //
            // 子要素全部。

            List<Expression_Node_String> ecList_Child = this.List_Expression_Child.SelectList(//Nv_Elem
                EnumHitcount.Unconstraint,
                log_Reports
                );

            foreach (Expression_Node_String ec_11 in ecList_Child)
            {
                Expressionv_Elem99 ecv_Elem = (Expressionv_Elem99)ec_11;
                ecv_Elem.SetDataRow(this.DataRow);
                sb_Result.Append(
                    ecv_Elem.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports)
                    );
            }

            //
            //
            //
            //

            log_Method.EndMethod(log_Reports);
            return sb_Result.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, string> dictionary_SAttribute;

        /// <summary>
        /// 属性＝””
        /// 
        /// ｔｙｐｅ、ｄｅｓｃｒｉｐｔｉｏｎ
        /// </summary>
        public Dictionary<string, string> Dictionary_SAttribute
        {
            get
            {
                return dictionary_SAttribute;
            }
            set
            {
                dictionary_SAttribute = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
