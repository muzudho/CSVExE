using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    public abstract class GivechapterandverseToExpression_F14n16_AbstractImpl_ : GivechapterandverseToExpression_AbstractImpl, GivechapterandverseToExpression_F14n16
    {



        #region アクション
        //────────────────────────────────────────

        public abstract void Translate(
            Givechapterandverse_Node cur_Cf,
            Expression_Node_String parent_Ec,
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────

        /// <summary>
        /// 【追加 2012-07-05】
        /// </summary>
        /// <param name="s_Cur"></param>
        /// <param name="e_Cur"></param>
        /// <param name="bRequired_NameAttr"></param>
        /// <param name="bRequired_ValueAttrIsChild"></param>
        /// <param name="log_Reports"></param>
        public static void ParseAttr_InAnotherLibrary(
            Givechapterandverse_Node cur_Cf,
            Expression_Node_String cur_Ec,
            bool bRequired_NameAttr,//name属性が必須な場合、真。
            bool bRequired_ValueAttrIsChild,//ｖａｌｕｅ属性を、子＜ｆ－ｓｔｒ＞にする場合、真。
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, "SToE_F14n16_AbstractImpl_", "ParseAttr_InAnotherLibrary",log_Reports);

            if (log_Method.CanDebug(1))
            {
                //d_ParsingLog.Increment("(5.FElem汎用)"+s_Cur.Name_Node);
            }


            GivechapterandverseToExpression_F14_FncImpl_ dammy = new GivechapterandverseToExpression_F14_FncImpl_();//メソッドが使いたいだけなので、何でもいい。
            dammy.ParseAttr_InGivechapterandverseToExpression(
                cur_Cf,
                cur_Ec,
                bRequired_NameAttr,
                bRequired_ValueAttrIsChild,
                log_Reports
                );

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:

            if (Log_ReportsImpl.BDebugmode_Static)
            {
                //d_ParsingLog.Decrement(s_Cur.Name_Node);
            }
            log_Method.EndMethod(log_Reports);
        }


        public void ParseAttr_InGivechapterandverseToExpression(
            Givechapterandverse_Node cur_Cf,
            Expression_Node_String cur_Ec,
            bool bRequired_NameAttr,//name属性が必須な場合、真。
            bool bRequired_ValueAttrIsChild,//ｖａｌｕｅ属性を、子＜ｆ－ｓｔｒ＞にする場合、真。
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, this, "ParseAttr",log_Reports);
            //
            //


            if (log_Reports.Successful)
            {
                //
                // s属性 はなんでも受け入れるとする。
                //
                cur_Cf.Dictionary_Attribute_Givechapterandverse.ForEach(delegate(string sPmName, string sAttrValue, ref bool bBreak)
                {
                    Expression_Node_String ec_AttrValue;
                    if (log_Reports.Successful)
                    {

                        ec_AttrValue = new Expression_Node_StringImpl(cur_Ec, cur_Cf);
                        ec_AttrValue.AppendTextNode(sAttrValue, cur_Cf, log_Reports);//ここでエラー？
                    }
                    else
                    {
                        bBreak = true;
                        goto gt_EndMethod1;
                    }

                    if (log_Reports.Successful)
                    {
                        if (bRequired_ValueAttrIsChild && PmNames.S_VALUE.Name_Pm == sPmName)
                        {
                            // ｖａｌｕｅ属性は、子＜ｆ－ｓｔｒ＞にする。

                            //d_InMethod.WriteDebug_ToConsole(2," 　　　　["+sAttrName+"]属性を子要素として追加。");
                            cur_Ec.List_Expression_Child.Add(ec_AttrValue, log_Reports);
                        }
                        else
                        {
                            // 属性にする。
                            cur_Ec.Dictionary_Expression_Attribute.Set(sPmName, ec_AttrValue, log_Reports);
                        }
                    }
                    else
                    {
                        bBreak = true;
                        goto gt_EndMethod1;
                    }

                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole( "　├属性[" + sPmName + "]＝”[" + sAttrValue + "]”");
                    }

                    //　追加したe_Attr=[" + e_AttrValue.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports) + "]　e属性数=[" + e_Cur.Dictionary_Expression_Attribute.Count + "]　子要素数＝[" + e_Cur.List_ChildGivechapterandverse.Count + "]

                    goto gt_EndMethod1;
                //
                //
                //
                //
                gt_EndMethod1:
                    ;
                });

                //
                // 【開発中 2012-06-04】
                // S_Elmの、Ｓ＿ＡｔｔｒＤｉｃ は廃止したい。
                //




                if (bRequired_NameAttr)
                {
                    //
                    // name属性は必須。
                    //
                    string sFncName2;
                    log_Reports.Log_Callstack.Push(log_Method, "①name必須指定");
                    cur_Ec.TrySelectAttribute(out sFncName2, PmNames.S_NAME.Name_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports);
                    log_Reports.Log_Callstack.Pop(log_Method, "①name必須指定");

                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole( "sFncName2=[" + sFncName2 + "]");
                    }
                    //bool bHit = s_Cur.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.NAME.SAttrName, out sFncName2, true, log_Reports);

                    if (!log_Reports.Successful)
                    {
                        goto gt_EndMethod;
                    }

                }
            }
            else
            {
                goto gt_EndMethod;
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
