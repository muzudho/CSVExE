using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Table;

namespace Xenon.Expr
{

    /// <summary>
    /// システム関数
    /// </summary>
    public class Expression_SfswitchImpl : Expression_Node_StringImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        private Expression_SfswitchImpl(
            Expression_Node_String parent_Expression, Givechapterandverse_Node parent_Givechapterandverse)
            : base(parent_Expression, parent_Givechapterandverse)
        {
            this.list_Expression_Sfcase = new List<Expression_SfcaseImpl>();
        }

        //────────────────────────────────────────

        public static Expression_Node_String Create(
            Expression_Node_String parent_Expression, Givechapterandverse_Node parent_Givechapterandverse)
        {
            return new Expression_SfswitchImpl(parent_Expression, parent_Givechapterandverse);
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
            log_Method.BeginMethod(Info_Expr.SName_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //

            StringBuilder sResult = new StringBuilder();

            //
            // ｓｗｉｔｃｈＶａｌｕｅ="" の有無を確認。
            string sSwitchValue;
            {
                // ＜ａｒｇ１　ｎａｍｅ＝”ｓｗｉｔｃｈＶａｌｕｅ”　＞
                log_Reports.Log_Callstack.Push(log_Method, "①");
                this.DicExpression_Attr.TrySelect(out sSwitchValue, PmNames.S_VALUE_SWITCH.SName_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports);
                log_Reports.Log_Callstack.Pop(log_Method, "①");
            }

            if ("" == sSwitchValue)
            {
                //
                //
                //
                // 子要素を計算して、 switch="" の値とします。
                //
                //
                //

                //sResult.Append("＜Ｓｆ：ｓｗｉｔｃｈ；の子要素全部＞");
                StringBuilder sb = new StringBuilder();

                List<Expression_Node_String> ecList = this.ListExpression_Child.SelectList(
                    Request_SelectingImpl.Unconstraint,
                    log_Reports
                    );

                foreach (Expression_Node_String ec_Child in ecList)
                {
                    sb.Append(ec_Child.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                }
                sSwitchValue = sb.ToString();
            }

            sSwitchValue = sSwitchValue.Trim();




            bool bHit = false;//case文に一致するものがあれば真、default文に行くならfalse。

            foreach (Expression_SfcaseImpl ec_SfCase in this.List_Expression_Sfcase)
            {
                //
                // ｃａｓｅＶａｌｕｅ="1,2,3" とか書いてある部分。
                //
                string sExpected;
                {
                    log_Reports.Log_Callstack.Push(log_Method, "②");
                    ec_SfCase.TrySelectAttr(out sExpected, PmNames.S_VALUE_CASE.SName_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports);
                    log_Reports.Log_Callstack.Pop(log_Method, "②");
                }

                CsvTo_ListImpl csvTo = new CsvTo_ListImpl();
                List<string> sList_Expected = csvTo.Read(sExpected);
                List<string> sList_ExpectedTrim = new List<string>();
                //
                // 要素数が 0 の場合、「空文字列」をヒットさせます。
                //
                if (0 == sList_Expected.Count)
                {
                    // 「空文字列要素」１個だけを持つリスト。
                    sList_ExpectedTrim.Add("");
                }
                else
                {
                    // デバッグ
                    foreach (string sExpectedTrim in sList_Expected)
                    {
                        string sTrim = sExpectedTrim.Trim();

                        // デバッグ
                        //onsole.Write("[" + sTrim + "]");

                        sList_ExpectedTrim.Add(sTrim);
                    }
                    // デバッグ
                    //onsole.WriteLine("");
                }


                if (sList_ExpectedTrim.Contains(sSwitchValue))
                {
                    log_Reports.Log_Callstack.Push(log_Method, "④");
                    string sHit = ec_SfCase.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                    log_Reports.Log_Callstack.Pop(log_Method, "④");


                    sResult.Append(sHit);
                    bHit = true;
                }
            }

            //
            // ＜a-default＞未実装
            //

            goto gt_EndMethod;
        //
        //
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sResult.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<Expression_SfcaseImpl> list_Expression_Sfcase;

        /// <summary>
        /// 「E■ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｃａｓｅ；”」要素のリスト。
        /// </summary>
        public List<Expression_SfcaseImpl> List_Expression_Sfcase
        {
            get
            {
                return list_Expression_Sfcase;
            }
            set
            {
                list_Expression_Sfcase = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
