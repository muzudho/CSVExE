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
        /// <param name="hits"></param>
        /// <param name="log_Reports"></param>
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

            //
            // 子要素を実行し、文字列連結。
            string sFormValue;
            {
                StringBuilder sb = new StringBuilder();
                List<Expression_Node_String> ecList_Child = this.List_Expression_Child.SelectList(//Nv_Elem
                    EnumHitcount.Unconstraint,
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
                    sb.Append(ec_11.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                }
                sFormValue = sb.ToString();
            }


            string sResult;

            if (log_Reports.Successful)//無限ループ防止
            {

                string sType;
                {
                    bool bHit = this.TrySelectAttribute(out sType, PmNames.S_TYPE.Name_Pm, EnumHitcount.One, log_Reports);
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
            sResult = "false";
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sFormValue, log_Reports);//コントロールの値
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(this.Cur_Configuration), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6035;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_ParseFailure02:
            sResult = "false";
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sFormValue, log_Reports);//コントロールの値
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(this.Cur_Configuration), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6036;", tmpl, log_Reports);
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
