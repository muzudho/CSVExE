using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;

namespace Xenon.Expr
{

    /// <summary>
    /// ケースの名前（case="1,2,3"等）は、ｃａｓｅＶａｌｕｅ 属性に入れること。
    /// </summary>
    public class Expression_SfcaseImpl : Expression_Node_StringImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        private Expression_SfcaseImpl(Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav)
            : base(parent_Expression, cur_Gcav)
        {
        }

        public static Expression_Node_String Create(Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav)
        {
            return new Expression_SfcaseImpl(parent_Expression, cur_Gcav);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 値を算出します。
        /// </summary>
        /// <returns></returns>
        public override string Expression_ExecuteMain(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //
            StringBuilder sb_Result = new StringBuilder();

            //
            //
            //
            // 子
            //
            //
            //
            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole(" ┌────┐ 子要素数＝[" + this.List_Expression_Child.Count + "]");
            }

            List<Expression_Node_String> ecList_Child = this.List_Expression_Child.SelectList(Request_SelectingImpl.Unconstraint,log_Reports);
            foreach (Expression_Node_String ec_Child in ecList_Child)
            {

                //
                // 子ノード名、子ファンク名
                //
                string sChildNodeName = ec_Child.Cur_Configurationtree.Name;

                string sChildFncName = "";
                {
                    bool bRequired2;
                    if (
                        NamesNode.S_ARG == sChildNodeName ||
                        NamesNode.S_FNC == sChildNodeName
                        )
                    {
                        // ＜ａｒｇ　＞の場合。
                        // ＜ｆｎｃ　＞の場合。
                        bRequired2 = true;
                    }
                    else
                    {
                        bRequired2 = false;
                    }
                    bool bHit = ec_Child.Dictionary_Expression_Attribute.TrySelect(out sChildFncName, PmNames.S_NAME.Name_Pm, bRequired2, Request_SelectingImpl.Unconstraint, log_Reports);
                }


                //
                //

                if (
                    // 子「S■ａｒｇ　ｎａｍｅ＝”ｃａｓｅ”」
                    NamesNode.S_ARG == sChildNodeName &&
                    PmNames.S_VALUE_CASE.Name_Pm == sChildFncName)
                {
                    // Ｓｆ：ｃａｓｅ；要素の子＜ａｒｇ＞は無視します。

                }
                else
                {
                    string sValue = ec_Child.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole(" ・子[" + sChildNodeName + "]　ｎａｍｅ＝”[" + sChildFncName + "]”　属性数＝[" + ec_Child.Dictionary_Expression_Attribute.Count + "]　値＝”[" + sValue + "]”");
                    }
                    sb_Result.Append(sValue);
                }

            }

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole( " └────┘");
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



    }
}
