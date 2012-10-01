using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;

namespace Xenon.Expr
{
    public class Expressionv_6AEmptyFieldImpl : Expressionv_Elem99Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="s_ParentNode"></param>
        public Expressionv_6AEmptyFieldImpl(Expression_Node_String parent_Expression_Node, Configurationtree_Node parent_Configurationtree_Node, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression_Node, parent_Configurationtree_Node, owner_MemoryApplication)
        {
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
            // 子要素を実行し、文字列連結。
            string sFormValue;
            {
                StringBuilder sb = new StringBuilder();
                List<Expression_Node_String> ecList_Child = this.List_Expression_Child.SelectList(//Nv_Elem
                    Request_SelectingImpl.Unconstraint,
                    log_Reports
                    );

                //// debug:
                //if (true)
                //{
                //    ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#E_Execute: childNList.Count＝[" + childNList.Count + "]");
                //}

                foreach (Expression_Node_String ec_11 in ecList_Child)
                {
                    //
                    // ＜f-cell＞要素を想定。
                    sb.Append(ec_11.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                }
                sFormValue = sb.ToString();
            }


            string sResult;

            if (log_Reports.Successful)//無限ループ防止
            {

                string sType;
                {
                    bool bHit = this.Dictionary_Expression_Attribute.TrySelect(out sType, PmNames.S_TYPE.Name_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports);
                }

                if ("chk" == sType.Trim())
                {
                    //
                    // true/false型のチェックボックスの場合

                    bool bValue;
                    if ("" == sFormValue)
                    {
                        //
                        // 空文字列なら、真。
                        sResult = "true";
                    }
                    else if (Boolean.TryParse(sFormValue, out bValue))
                    {
                        if (bValue)
                        {
                            //
                            // "true" が入っていたら、偽。
                            sResult = "false";
                        }
                        else
                        {
                            //
                            // "false" が入っていたら、真。
                            sResult = "true";
                        }
                    }
                    else
                    {
                        //
                        // 判定不能なら。
                        goto gt_Error_ParseFailure01;
                    }
                }
                else if ("chk01" == sType.Trim())
                {
                    //
                    // 0/1型のチェックボックスの場合

                    int nValue;
                    if ("" == sFormValue)
                    {
                        //
                        // 空文字列なら、真。
                        sResult = "true";
                    }
                    else if (int.TryParse(sFormValue, out nValue))
                    {
                        if (0 == nValue)
                        {
                            //
                            // 0 が入っていたら、真。
                            sResult = "true";
                        }
                        else
                        {
                            //
                            // それ以外は、偽。
                            sResult = "false";
                        }
                    }
                    else
                    {
                        //
                        // 判定不能なら。
                        goto gt_Error_ParseFailure02;
                    }
                }
                else
                {
                    if ("" == sFormValue)
                    {
                        sResult = "true";
                    }
                    else
                    {
                        sResult = "false";
                    }
                }
            }
            else
            {
                sResult = "false";
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_ParseFailure01:
            {
                sResult = "false";

                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー127！", log_Method);

                    Log_TextIndented t = new Log_TextIndentedImpl();

                    t.Append("　チェックボックスの値が、true/false ではありませんでした。");
                    t.Newline();

                    t.Append("　sFormValue＝[");
                    t.Append(sFormValue);
                    t.Append("]");
                    t.Newline();

                    //
                    // ヒント
                    t.Append(r.Message_Configurationtree(this.Cur_Configurationtree));

                    t.Append(r.Message_SSeparator());
                    t.Append("　　ヒント：");
                    t.Newline();
                    t.Append("　　　例えば、変数名「$aaa」を書こうとして、「aaa」と文字列を入れていませんか？");

                    r.Message = t.ToString();
                    log_Reports.EndCreateReport();
                }
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_ParseFailure02:
            {
                sResult = "false";

                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー128！", log_Method);

                    Log_TextIndented t = new Log_TextIndentedImpl();

                    t.Append("　チェックボックスの値が、(真)0以外の数字/(偽)0 ではありませんでした。");
                    t.Newline();

                    t.Append("　sFormValue＝[");
                    t.Append(sFormValue);
                    t.Append("]");
                    t.Newline();

                    // ヒント：this
                    t.Append(r.Message_Configurationtree(this.Cur_Configurationtree));

                    t.Append(r.Message_SSeparator());
                    t.Append("　　ヒント：");
                    t.Newline();
                    t.Append("　　　例えば、変数名「$aaa」を書こうとして、「aaa」と文字列を入れていませんか？");

                    r.Message = t.ToString();
                    log_Reports.EndCreateReport();
                }
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sResult;
        }

        //────────────────────────────────────────
        #endregion



    }
}
