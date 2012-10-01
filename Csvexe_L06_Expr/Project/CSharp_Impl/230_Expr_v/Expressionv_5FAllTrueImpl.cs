using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;

namespace Xenon.Expr
{
    public class Expressionv_5FAllTrueImpl : Expressionv_Elem99Impl, Expressionv_5FAllTrue
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="s_ParentNode"></param>
        /// <param name="moOpyopyo"></param>
        public Expressionv_5FAllTrueImpl(Expression_Node_String parent_Expression_Node, Givechapterandverse_Node parent_Givechapterandverse_Node, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression_Node, parent_Givechapterandverse_Node, owner_MemoryApplication)//"f-all-true",
        {
            this.list_Expressionv_AEmptyField = new List<Expressionv_Elem99>();
        }

        public static Expression_Node_String Create(Expression_Node_String parent_Expression_Node, Givechapterandverse_Node parent_Givechapterandverse_Node, MemoryApplication owner_MemoryApplication)
        {
            return new Expressionv_5FAllTrueImpl(parent_Expression_Node, parent_Givechapterandverse_Node, owner_MemoryApplication);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ユーザー定義プログラムの実行。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public override string Execute_OnExpressionString(
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnExpressionString",log_Reports);
            //
            //

            //
            // 子＜a-●●＞要素の実行。

            //
            // 全部真なら真、１つでも偽なら偽。
            bool bResult = true;
            {
                List<Expression_Node_String> ecList_Child = this.List_Expression_Child.SelectList(//Nv_Elem
                    Request_SelectingImpl.Unconstraint,
                    log_Reports
                    );

                // ★★★★★★★★★ここが遅い？ 42項目あると、42個全部調べることになります。
                //ystem.Console.WriteLine(this.GetType().Name + "#GetString: 全部真か？ childNList.Count＝[" + childNList.Count + "]");

                foreach (Expression_Node_String ec_11 in ecList_Child)
                {
                    Expressionv_Elem99 ecv_Elem = (Expressionv_Elem99)ec_11;
                    ecv_Elem.SetDataRow(this.DataRow);
                    string str = ecv_Elem.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                    // ★★★★★★★★★ここが遅い？ 42項目あると、42個全部調べることになります。
                    //ystem.Console.WriteLine(this.GetType().Name + "#GetString: str＝[" + str + "]");

                    bool bChild;
                    if (Boolean.TryParse(str, out bChild))
                    {
                        if (!bChild)
                        {
                            bResult = false;
                            goto loop_end;
                        }

                    }
                }
            loop_end:
                ;//空文
            }

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
            return bResult.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞要素のリスト。
        /// </summary>
        protected List<Expressionv_Elem99> list_Expressionv_AEmptyField;

        public List<Expressionv_Elem99> List_Expressionv_AEmptyField
        {
            get
            {
                return list_Expressionv_AEmptyField;
            }
            set
            {
                list_Expressionv_AEmptyField = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
