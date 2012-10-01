using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.GcavToExpr
{
    /// <summary>
    /// 「S■ｆｎｃ」要素。
    /// </summary>
    class GivechapterandverseToExpression_F14_FncImpl_ : GivechapterandverseToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        public override void Translate(
            Givechapterandverse_Node cur_Cf,//「S■ｆｎｃ」
            Expression_Node_String parent_Ec,//「S■ｆｎｃ」、や「S■ｅｖｅｎｔ」か？
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(29)" + cur_Cf.Name);
            }

            //
            //
            //
            //

            if (!log_Reports.Successful)
            {
                goto gt_EndMethod;
            }

            if (null == parent_Ec)
            {
                goto gt_Error_NullParent;
            }


            //
            //
            //
            // 自
            //
            //
            //
            Expression_Node_String cur_Ec = null;  //「E■ｆｎｃ」



            //
            // 親ファンク名
            // 自ファンク名
            //
            string parent_SName_Fnc = "";
            string sName_MyFnc = "";
            {
                bool bHit9 = parent_Ec.Dictionary_Expression_Attribute.TrySelect(out parent_SName_Fnc, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);


                if (!log_Reports.Successful)
                {
                    goto gt_EndMethod;
                }
                else if (NamesNode.S_FNC == parent_Ec.Cur_Givechapterandverse.Name && "" == parent_SName_Fnc)
                {
                    //
                    // エラー。親要素が、ｎａｍｅ属性を持たない「E■ｆｎｃ」だった。
                    //
                    goto gt_Error_NoNameParent1;
                }
            }

            // 　　「E■ｆｎｃ」には、ｎａｍｅ＝”★”属性が必須。
            bool bHit = cur_Cf.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_MyFnc, true, log_Reports);

            if (!log_Reports.Successful)
            {
                goto gt_EndMethod;
            }






            //
            //
            //
            // 自
            //
            //
            //
            if (log_Reports.Successful)
            {
                // 「E■ｆｎｃ」要素を作成。

                if (NamesFnc.S_ALL_TRUE == sName_MyFnc)
                {
                    cur_Ec = Expressionv_5FAllTrueImpl.Create(parent_Ec, cur_Cf, memoryApplication);
                }
                else if (NamesFnc.S_TEXT_TEMPLATE == sName_MyFnc)
                {
                    cur_Ec = Expression_SftextTemplate.Create(parent_Ec, cur_Cf, memoryApplication);
                }
                else if (NamesFnc.S_CELL == sName_MyFnc)
                {
                    if (log_Method.CanDebug(10))
                    {
                        log_Method.WriteDebug_ToConsole( "（２） 「S■ｆｎｃ　ｎａｍｅ＝”[" + sName_MyFnc + "]”」要素　属性解析開始。");
                    }
                    cur_Ec = Expression_SfcellImpl.Create(parent_Ec, cur_Cf, memoryApplication);
                }
                else if (NamesFnc.S_VALUE_CONTROL == sName_MyFnc)
                {
                    // コントロール名を取得し、コントロールの値を返すように設定。

                    string sFcName;
                    cur_Cf.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sFcName, true, log_Reports);
                    if (!log_Reports.Successful)
                    {
                        goto gt_EndMethod;
                    }

                    Expression_Node_String ec_FcName = new Expression_Leaf_StringImpl(sFcName, parent_Ec, cur_Cf);
                    cur_Ec = new Expression_ValuecontrolImpl(ec_FcName, memoryApplication, parent_Ec, cur_Cf);
                }
                else if (NamesFnc.S_SWITCH == sName_MyFnc)
                {
                    if(log_Method.CanDebug(1))
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        parent_Ec.ToText_Snapshot(s);
                        log_Method.WriteDebug_ToConsole( "E■ｓｗｉｔｃｈ生成。s=" + s.ToString());
                    }
                    cur_Ec = Expression_SfswitchImpl.Create(parent_Ec, cur_Cf);
                }
                else
                {

                    if(sName_MyFnc.StartsWith(NamesFnc.S_UF))
                    {
                        // ユーザー定義関数
                        cur_Ec = new Expression_FfncImpl(parent_Ec, cur_Cf, memoryApplication);
                    }
                    else
                    {
                        // システム定義関数
                        cur_Ec = new Expression_Node_StringImpl(parent_Ec, cur_Cf);
                    }

                }
            }
            else
            {
                goto gt_EndMethod;
            }



            //
            //
            //
            // 属性
            //
            //
            //
            if (log_Reports.Successful)
            {
                // 元からあった。
                this.ParseAttr_InGivechapterandverseToExpression(
                    cur_Cf,
                    cur_Ec,
                    true,//ｎａｍｅ属性は必須。
                    false,//ｖａｌｕｅ属性は、子＜ｆ－ｓｔｒ＞にしない。
                    log_Reports
                    );
            }



            //
            //
            //
            // 子
            //
            //
            //
            if (log_Reports.Successful)
            {
                if(NamesFnc.S_TEXT_TEMPLATE == sName_MyFnc)
                {
                    this.ParseChild_SpecialTextTemplate_(
                        cur_Cf,
                        cur_Ec,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }
                else if (NamesFnc.S_SWITCH == sName_MyFnc)
                {
                    this.ParseChild_SpecialSwitch_(
                        cur_Cf,//「S■ｆｎｃ」
                        cur_Ec,//「E■ｆｎｃ」
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                            );
                }
                else if (NamesFnc.S_VLD_EMPTY_FIELD == sName_MyFnc)
                {
                    // ＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞要素
                    GivechapterandverseToExpression_V55_AEmptyFieldImpl_ to = new GivechapterandverseToExpression_V55_AEmptyFieldImpl_();
                    to.Translate(
                        cur_Cf,
                        cur_Ec,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }
                else
                {
                    // この「S□ｆｎｃ」の子を解析。
                    // 「Ｓｆ：ｃｅｌｌ；」
                    // 「Ｓｆ：ｗｈｅｒｅ；」
                    // 「Ｓｆ：ｒｅｃ－ｃｏｎｄ；」

                    // 【追加 2012-06-02】
                    this.ParseChild_SpecialFnc_(
                        cur_Cf,
                        cur_Ec,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }
            }
            else
            {
                goto gt_EndMethod;
            }




            //
            //
            //
            // 親へ連結
            //
            //
            //
            if (log_Reports.Successful)
            {

                //
                // "hardcoding-control" に追加する子要素としては、ｆ－ｃｅｌｌなどがある。
                //

                if (
                    sName_MyFnc.StartsWith(NamesFnc.S_UF)//ユーザー定義関数
                    || NamesFnc.S_TEXT_TEMPLATE == sName_MyFnc//テンプレート
                    || NamesFnc.S_SWITCH == sName_MyFnc//スイッチ文
                    || (NamesNode.S_FNC == cur_Cf.Name && NamesFnc.S_VALUE_CONTROL == sName_MyFnc)//todo:
                    || (NamesNode.S_FNC == parent_Ec.Cur_Givechapterandverse.Name)
                    || (NamesFnc.S_CELL == sName_MyFnc || NamesFnc.S_TEXT_TEMPLATE == sName_MyFnc)
                    || ( sName_MyFnc == NamesFnc.S_REC_COND && NamesNode.S_FNC == parent_Ec.Cur_Givechapterandverse.Name && NamesFnc.S_WHERE == parent_SName_Fnc)//親が＜ｒｅｃ－ｃｏｎｄ＞で、自＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：Ｗｈｅｒｅ；”＞要素
                    )
                {                    
                    parent_Ec.List_Expression_Child.Add(cur_Ec, log_Reports);
                }
                else
                {
                    // エラー

                    goto gt_Error_CanNotAddParent;
                    // todo:
                    //throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#SToE:（１８）★★親要素へ連結不能　　　　・親「E■[" + e_Parent.Cur_Givechapterandverse.Name + "]　ｎａｍｅ＝”[" + sParentFncName + "]”」　←　自「S■[" + s_AFnc.Name_Node + "]　ｎａｍｅ＝”[" + sFncName + "]”」中止。　／エラー。親要素に追加しようとしましたが、予想しない親要素でした。");
                }

            }



            //
            //
            // 終わり際に、デバッグ
            //
            //
            if (log_Method.CanDebug(10) && log_Reports.Successful)
            {
                if (null != cur_Ec)//既にエラーが出ている場合。
                {
                    log_Method.WriteDebug_ToConsole("（１９） 自要素の属性の数=[" + cur_Ec.Dictionary_Expression_Attribute.Count + "]");

                    log_Method.WriteDebug_ToConsole("（２１） ┌────┐自要素。その子要素の数=[" + cur_Ec.List_Expression_Child.Count + "]");

                    cur_Ec.List_Expression_Child.ForEach(
                        delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                        {
                            log_Method.WriteDebug_ToConsole( "「S■" + e_Child.Cur_Givechapterandverse.Name + "」");
                        });

                    log_Method.WriteDebug_ToConsole( "（２２） └────┘");

                    log_Method.WriteDebug_ToConsole( "（２３）└────────────────┘ 「S■[" + cur_Cf.Name + "]　ｎａｍｅ＝”[" + sName_MyFnc + "]”」（ｆｎｃ）要素解析終了。");


                    //
                    // ｎａｍｅ属性の指定は必須です。
                    //
                    string sName8;
                    bool bHit8 = cur_Ec.Dictionary_Expression_Attribute.TrySelect(out sName8, PmNames.S_NAME.Name_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports);
                    if (!bHit8)
                    {
                        // todo:
                        throw new Exception(Info_GivechapterandverseToExpression.Name_Library + ":" + this.GetType().Name + "#SToE:（２４）ｆｎｃ要素にｎａｍｅ属性が指定されていないのはエラーです①。");
                    }
                    else if ("" == sName8)
                    {
                        // todo:
                        //throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#SToE:（２４）ｆｎｃ要素に空文字列のｎａｍｅ属性が指定されているのはエラーです。");
                        goto gt_Error_NoNameParent2;
                    }
                }
            }


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_CanNotAddParent:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー880！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("親要素に連結不能でした。");
                s.Append(Environment.NewLine);

                this.WriteError_(
                    "gt_Error_CanNotAddParent",
                    s,
                    cur_Cf,
                    cur_Ec,
                    parent_Ec,
                    sName_MyFnc,
                    parent_SName_Fnc,
                    log_Reports
                    );

                // ヒント
                s.Append(r.Message_Givechapterandverse(parent_Ec.Cur_Givechapterandverse));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NoNameParent2:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー881！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("自要素が、ｎａｍｅ属性を持たない「E■ｆｎｃ」だった。。");
                s.Append(Environment.NewLine);

                this.WriteError_(
                    "gt_Error_NoNameParent2",
                    s,
                    cur_Cf,
                    cur_Ec,
                    parent_Ec,
                    sName_MyFnc,
                    parent_SName_Fnc,
                    log_Reports
                    );

                // ヒント
                s.Append(r.Message_Givechapterandverse(parent_Ec.Cur_Givechapterandverse));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NoNameParent1:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー882！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("親要素が、ｎａｍｅ属性を持たない「E■ｆｎｃ」だった。。");
                s.Append(Environment.NewLine);

                this.WriteError_(
                    "gt_Error_NoNameParent1",
                    s,
                    cur_Cf,
                    cur_Ec,
                    parent_Ec,
                    sName_MyFnc,
                    parent_SName_Fnc,
                    log_Reports
                    );

                // ヒント
                s.Append(r.Message_Givechapterandverse(parent_Ec.Cur_Givechapterandverse));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullParent:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー888！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("親要素の指定が空っぽ（ヌル）でした。プログラムミスの可能性。");
                t.Append(Environment.NewLine);
                // nFAelem はヌルなので、確認できない。

                // ヒント
                t.Append(r.Message_Givechapterandverse(cur_Cf));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Cf.Name);
            }
            log_Method.EndMethod(log_Reports);
        }

        private void WriteError_(
            string sComment,
            Log_TextIndented s,
            Givechapterandverse_Node cur_Cf,
            Expression_Node_String cur_Ec,
            Expression_Node_String parent_Ec,
            string sName_MyFnc,
            string parent_SName_Fnc,
            Log_Reports log_Reports
            )
        {
            s.Append("コメント「[" + sComment + "]」");
            s.Newline();

            //
            // 自
            //
            s.Append("期待の自「S■[" + cur_Cf.Name + "]　ｎａｍｅ＝”[" + sName_MyFnc + "]”」");
            s.Newline();

            if (null != cur_Ec)
            {
                //
                // 属
                //
                s.Append("┌────┐属性の数=[" + cur_Ec.Dictionary_Expression_Attribute.Count + "]");
                s.Newline();
                cur_Ec.Dictionary_Expression_Attribute.ForEach(
                    delegate(string sName2, Expression_Node_String e_Attr2, ref bool bBreak)
                    {
                        s.Append("属" + sName2 + "＝”" + e_Attr2.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports) + "”");
                        s.Newline();
                    });
                s.Append("└────┘");
                s.Newline();

                //
                // 子
                //
                s.Append("┌────┐子要素の数=[" + cur_Ec.List_Expression_Child.Count + "]");
                s.Newline();
                cur_Ec.List_Expression_Child.ForEach(
                    delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                    {
                        s.Append("子「S■" + e_Child.Cur_Givechapterandverse.Name + "」");
                        s.Newline();
                    });
                s.Append("└────┘");
                s.Newline();
                s.Newline();
            }
            else
            {
                s.Append("実際の自「ヌル」");
                s.Newline();
                s.Newline();
            }


            s.Append("期待の親「E■[" + NamesNode.S_ARG + "]　ｎａｍｅ＝”[" + PmNames.S_WHERE.Name_Pm + "]”」");
            s.Newline();
            if (null != parent_Ec)
            {
                //
                // 親
                //
                s.Append("実際の親「E■[" + parent_Ec.Cur_Givechapterandverse.Name + "]　ｎａｍｅ＝”[" + parent_SName_Fnc + "]”」");
                s.Newline();

                //
                // 属
                //
                s.Append("┌────┐属性の数=[" + parent_Ec.Dictionary_Expression_Attribute.Count + "]");
                s.Newline();
                parent_Ec.Dictionary_Expression_Attribute.ForEach(
                    delegate(string sName2, Expression_Node_String e_Attr2, ref bool bBreak)
                    {
                        s.Append("属" + sName2 + "＝”" + e_Attr2.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports) + "”");
                        s.Newline();
                    });
                s.Append("└────┘");
                s.Newline();

                //
                // 子
                //
                s.Append("┌────┐子要素の数=[" + parent_Ec.List_Expression_Child.Count + "]");
                s.Newline();
                parent_Ec.List_Expression_Child.ForEach(
                    delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                    {
                        s.Append("子「S■" + e_Child.Cur_Givechapterandverse.Name + "」");
                        s.Newline();
                    });
                s.Append("└────┘");
                s.Newline();
            }
            else
            {
                s.Append("親「ヌル」");
                s.Newline();
                s.Newline();
            }
        }




        private void ParseChild_SpecialFnc_(
            Givechapterandverse_Node cur_Cf,
            Expression_Node_String cur_Ec,//「S■ｆｎｃ」、や「S■ｅｖｅｎｔ」か？
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, this, "ParseChild_Special_",log_Reports);
            //
            //
            if (!log_Reports.Successful)
            {
                goto gt_EndMethod;
            }

            //
            //
            //
            // 子
            //
            //
            //
            cur_Cf.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node s_Child, ref bool bBreak)
            {
                if (log_Reports.Successful)
                {
                    if (NamesNode.S_ARG == s_Child.Name)
                    {
                        //━━━━━
                        // ａｒｇ
                        //━━━━━

                        string sName_MyFnc;
                        cur_Cf.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_MyFnc, false, log_Reports);

                        string sName_ChildFnc;
                        s_Child.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_ChildFnc, false, log_Reports);


                        //
                        bool bNormalize = false;
                        if(
                            // 親が「E■ｆｎｃ」
                            NamesNode.S_FNC==cur_Ec.Cur_Givechapterandverse.Name &&
                            NamesFnc.S_CELL == sName_MyFnc
                            )
                        {
                            if (
                                // 子が「ｎａｍｅ＝”ｓｅｌｅｃｔ”」
                                PmNames.S_SELECT.Name_Pm == sName_ChildFnc
                                )
                            {
                                bNormalize = true;
                            }
                        }

                        if (bNormalize)
                        {
                            GivechapterandverseToExpression_F14n16 to = new GivechapterandverseToExpression_F14_FArgImpl();
                            to.Translate(
                                s_Child,
                                cur_Ec,//「E■ｆｎｃ」とか
                                memoryApplication,
                                pg_ParsingLog,
                                log_Reports
                                );
                        }
                        else
                        {
                            string sValue = "";

                            //
                            // ｖａｌｕｅ＝”” 属性が指定されていれば、その値をそのまま取得。
                            //
                            s_Child.Dictionary_Attribute_Givechapterandverse.ForEach(delegate(string sPmName2, string sAttrValue2, ref bool bBreak2)
                            {
                                if (PmNames.S_VALUE.Name_Pm == sPmName2)
                                {
                                    // value属性が指定されていた場合。
                                    s_Child.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                                    // 「E■ａｒｇ１」は作らずに、親要素の属性として追加。
                                    Expression_Node_String e_Value = new Expression_Leaf_StringImpl(sValue, cur_Ec, cur_Ec.Cur_Givechapterandverse);
                                    cur_Ec.Dictionary_Expression_Attribute.Set(sName_ChildFnc, e_Value, log_Reports);
                                }
                            });


                            //
                            // 子要素の有無。
                            //
                            if (0 < s_Child.List_ChildGivechapterandverse.Count)
                            {
                                // 子要素が指定されている場合。

                                if ("" != sValue)
                                {
                                    // value属性が指定されているのに、子要素も指定されているのは、エラーです。

                                    if (log_Method.CanError())
                                    {
                                        log_Method.WriteError_ToConsole( "　value属性が指定されているのに、子要素も指定されているのは、エラーです。");
                                    }
                                }
                                else
                                {
                                    Expression_Node_StringImpl ec_Value = new Expression_Node_StringImpl(cur_Ec, s_Child);

                                    GivechapterandverseToExpression_F14_FncImpl_ to2 = new GivechapterandverseToExpression_F14_FncImpl_();
                                    to2.ParseChild_SpecialFnc_(
                                        s_Child,
                                        ec_Value,
                                        memoryApplication,
                                        pg_ParsingLog,
                                        log_Reports
                                        );

                                    //
                                    // 「E■ａｒｇ１」は作らずに、親要素の属性として追加。
                                    //
                                    cur_Ec.Dictionary_Expression_Attribute.Set(sName_ChildFnc, ec_Value, log_Reports);
                                }
                            }
                            else
                            {
                                if ("" == sValue)
                                {
                                    // todo:
                                    throw new Exception(Info_GivechapterandverseToExpression.Name_Library + ":" + this.GetType().Name + "#ParseChild:（３） 「S■[" + cur_Cf.Name + "]」の子要素「S■[" + s_Child.Name + "]」に、value属性がありませんでした。子要素もありませんでした。");
                                }
                            }
                        }


                    }
                    else if (NamesNode.S_F_VAR == s_Child.Name)
                    {
                        //━━━━━
                        // ｆ－ｖａｒ
                        //━━━━━
                        //throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#ParseChild:（ｂ）ｆ－ｖａｒ　使っていなければ廃止したい。");

                        // 親要素「S■ｆｎｃ」の子要素として追加します。
                        GivechapterandverseToExpression_F14_FvariableImpl_ to = new GivechapterandverseToExpression_F14_FvariableImpl_();
                        to.Translate(
                            s_Child,
                            cur_Ec,//「E■ｆｎｃ」とか
                            memoryApplication,
                            pg_ParsingLog,
                            log_Reports
                            );
                    }
                    else if (NamesNode.S_F_STR == s_Child.Name)
                    {
                        //━━━━━
                        // ｆ－ｓｔｒ
                        //━━━━━
                        //throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#ParseChild:（ｃ）ｆ－ｓｔｒ　使っていなければ廃止したい。");


                        // 親要素「S■ｆｎｃ」の子要素として追加します。
                        GivechapterandverseToExpression_F14_FstrImpl_ to = new GivechapterandverseToExpression_F14_FstrImpl_();
                        to.Translate(
                            s_Child,
                            cur_Ec,//「E■ｆｎｃ」とか
                            memoryApplication,
                            pg_ParsingLog,
                            log_Reports
                            );
                    }
                    else if (NamesNode.S_FNC == s_Child.Name)
                    {
                        //━━━━━
                        // ｆｎｃ
                        //━━━━━
                        //throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#ParseChild:（ｅ）ｆｎｃ　使っていなければ廃止したい。");

                        //
                        // S_FVarImpl （「S■ｆ－ｖａｒ」）など。
                        // 【追加 2012-05-31】
                        //


                        // 親要素「S■ｆｎｃ」の子要素として追加します。
                        pg_ParsingLog.Increment("（ＳＴｏＥ＿Ｆ＿４ＦＦｎｃＩｍｐｌ②）");
                        GivechapterandverseToExpression_F14n16 to = new GivechapterandverseToExpression_F14_FncImpl_();
                        to.Translate(
                            s_Child,// s_Fnc,//※s_Node（「S■ｆ－ｖａｒ」とか）を入れるのではなく、その親を入れます。
                            cur_Ec,//「E■ｆｎｃ」とかか？
                            memoryApplication,
                            pg_ParsingLog,
                            log_Reports
                            );
                        pg_ParsingLog.Decrement();

                    }
                    else if (NamesNode.S_F_PARAM == s_Child.Name)
                    {
                        //━━━━━
                        // ｆ－ｐａｒａｍ
                        //━━━━━
                        //throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#ParseChild:（ｆ）ｆ－ｐａｒａｍ　使っていなければ廃止したい。");

                        // 【追加 2012-06-05】
                        GivechapterandverseToExpression_F14_FparamImpl_ to4 = new GivechapterandverseToExpression_F14_FparamImpl_();
                        to4.Translate(
                            s_Child,
                            cur_Ec,
                            memoryApplication,
                            pg_ParsingLog,
                            log_Reports
                            );

                    }
                    else
                    {
                        // todo:2
                        goto gt_Error_UndefinedChlid;
                        throw new Exception(Info_GivechapterandverseToExpression.Name_Library + ":" + this.GetType().Name + "#ParseChild:（１６） 「S■[" + cur_Cf.Name + "]」に、未定義の子要素「S■[" + s_Child.Name + "]」がありました。");
                    }
                }

                goto gt_EndMethod2;

                //
            gt_Error_UndefinedChlid:
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー829！", log_Method);

                    StringBuilder s = new StringBuilder();
                    s.Append("「S■[");
                    s.Append(cur_Cf.Name);
                    s.Append("]」に、未定義の子要素「S■[");
                    s.Append(s_Child.Name);
                    s.Append("]」がありました。");
                    s.Append(Environment.NewLine);

                    //
                    // s属
                    //
                    s.Append(Info_GivechapterandverseToExpression.Name_Library + ":" + this.GetType().Name + "#SToE: ┌────┐string属性の数=[" + cur_Cf.Dictionary_Attribute_Givechapterandverse.Count + "]");
                    s.Append(Environment.NewLine);
                    cur_Cf.Dictionary_Attribute_Givechapterandverse.ForEach(delegate(string sKey2, string sValue2, ref bool bBreak2)
                    {
                        s.Append(Info_GivechapterandverseToExpression.Name_Library + ":" + this.GetType().Name + "#SToE: s属　[" + sKey2 + "]＝[" + sValue2 + "]");
                        s.Append(Environment.NewLine);
                    });
                    s.Append(Info_GivechapterandverseToExpression.Name_Library + ":" + this.GetType().Name + "#SToE: └────┘");
                    s.Append(Environment.NewLine);


                    //
                    // 子
                    //
                    s.Append(Info_GivechapterandverseToExpression.Name_Library + ":" + this.GetType().Name + "#SToE: ┌────┐子要素の数=[" + cur_Cf.List_ChildGivechapterandverse.Count + "]");
                    s.Append(Environment.NewLine);
                    cur_Cf.List_ChildGivechapterandverse.ForEach(
                        delegate(Givechapterandverse_Node cf_Child2, ref bool bBreak5)
                        {
                            s.Append(Info_GivechapterandverseToExpression.Name_Library + ":" + this.GetType().Name + "#SToE: 子「S■" + cf_Child2.Name + "」");
                            s.Append(Environment.NewLine);
                        });
                    s.Append(Info_GivechapterandverseToExpression.Name_Library + ":" + this.GetType().Name + "#SToE: └────┘");
                    s.Append(Environment.NewLine);


                    // ヒント
                    s.Append(r.Message_Givechapterandverse(cur_Cf));

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
                goto gt_EndMethod2;


            gt_EndMethod2:
                ;
            });

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }



        private void ParseChild_SpecialSwitch_(
            Givechapterandverse_Node cur_Cf,//「S■ｆｎｃ」
            Expression_Node_String owner_Ec,// 「E■ｆｎｃ」
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            // a-●●要素や、switch要素など。

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, this, "ParseChild_SpecialSwitch_",log_Reports);

            //
            //
            //
            //

            //
            // データ_ソース、データ_ターゲット、＜ｆｎｃ　＞の子要素。


            string sName_OwnerNode = owner_Ec.Cur_Givechapterandverse.Name;
            string sName_OwnerFnc = "";
            {
                bool bRequired;
                if (NamesNode.S_FNC == sName_OwnerNode
                    //||
                    //NamesNode.S_F_TEXT_TEMPLATE2 == sOwnerNodeName
                    )
                {
                    bRequired = true;
                }
                else
                {
                    bRequired = false;
                }
                bool bHit = owner_Ec.Dictionary_Expression_Attribute.TrySelect(out sName_OwnerFnc, PmNames.S_NAME.Name_Pm, bRequired, Request_SelectingImpl.Unconstraint, log_Reports);
            }


            string sName_MyFnc;
            cur_Cf.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_MyFnc, true, log_Reports);

            //
            // ＜ｆ－ｓｗｉｔｃｈ＞要素であれば、子Ｓｆ：ｃａｓｅ；要素が何個もある。
            //
            if (log_Reports.Successful)
            {
                if (NamesFnc.S_SWITCH == sName_MyFnc)
                {
                    cur_Cf.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node s_Child, ref bool bBreak)
                    {
                        Givechapterandverse_Node err_CfAttr;
                        if (log_Reports.Successful)
                        {
                            string sName;
                            s_Child.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName, true, log_Reports);

                            if (
                                NamesNode.S_FNC == s_Child.Name
                                && NamesFnc.S_CASE == sName
                                )
                            {
                                GivechapterandverseToExpression_F14n16_AbstractImpl_ to = new GivechapterandverseToExpression_F16_CaseImpl_();
                                to.Translate(
                                    s_Child,//Ｓｆ：ｃａｓｅ；
                                    owner_Ec,//Ｓｆ：ｓｗｉｔｃｈ；
                                    memoryApplication,
                                    pg_ParsingLog,
                                    log_Reports
                                    );
                            }
                            else if (NamesNode.S_ARG == s_Child.Name)
                            {
                                // todo:＜ａｒｇ＞。恐らくｓｗｉｔｃｈＶａｌｕｅなど。
                                GivechapterandverseToExpression_F14n16 to = new GivechapterandverseToExpression_F14_FArgImpl();
                                to.Translate(
                                    s_Child,
                                    owner_Ec,//＜ｆ－ｓｗｉｔｃｈ　＞
                                    memoryApplication,
                                    pg_ParsingLog,
                                    log_Reports
                                    );
                            }
                            else
                            {
                                err_CfAttr = s_Child;
                                bBreak = true;
                                goto gt_Error_NotACase;
                            }
                        }

                        goto gt_EndMethod2;
                    //
                    //
                    //
                    gt_Error_NotACase:
                        if (log_Reports.CanCreateReport)
                        {
                            Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                            r.SetTitle("▲エラー313！", log_Method);

                            Log_TextIndented t = new Log_TextIndentedImpl();

                            t.Append("「ａ－ｃａｓｅ」という名前の要素を期待しましたが、[");
                            t.Append(err_CfAttr.Name);
                            t.Append("]でした。[");
                            t.Append(err_CfAttr.GetType().Name);
                            t.Append("]クラスでした。");
                            t.Newline();

                            t.Append("　プログラムにミスがあるかもしれません。");
                            t.Newline();
                            t.Newline();

                            // ヒント
                            t.Append(r.Message_Givechapterandverse(err_CfAttr));

                            r.Message = t.ToString();
                            log_Reports.EndCreateReport();
                        }
                        goto gt_EndMethod2;
                    //
                    //
                    //
                    //
                    gt_EndMethod2:
                        ;
                    });
                }
            }

            goto gt_EndMethod;



        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }



        private void ParseChild_SpecialTextTemplate_(
            Givechapterandverse_Node cur_Cf,
            Expression_Node_String owner_Ec,
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, this, "ParseChild_Special_",log_Reports);

            //
            //
            //
            //

            //
            // データ_ソース、データ_ターゲット、＜ｆｎｃ　＞の子要素。


            string sName_OwnerNode = owner_Ec.Cur_Givechapterandverse.Name;
            string sName_OwnerFnc = "";
            {
                bool bRequired;
                if (NamesNode.S_FNC == sName_OwnerNode
                    //||
                    //NamesNode.S_F_TEXT_TEMPLATE2 == sOwnerNodeName
                    )
                {
                    bRequired = true;
                }
                else
                {
                    bRequired = false;
                }
                bool bHit = owner_Ec.Dictionary_Expression_Attribute.TrySelect(out sName_OwnerFnc, PmNames.S_NAME.Name_Pm, bRequired, Request_SelectingImpl.Unconstraint, log_Reports);
            }



            //
            //
            //
            // 子
            //
            //
            //
            string err_SAtFncName;
            Givechapterandverse_Node err_Cf_AtElm;
            Exception err_E;

            cur_Cf.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node cf_Child, ref bool bBreak)
            {

                if (log_Reports.Successful)
                {
                    if (null == cf_Child)
                    {
                        bBreak = true;
                        goto gt_errorNullValue;
                    }
                    else
                    {
                        string sName_AtNode = cf_Child.Name;
                        string sName_AtFnc = "";
                        {
                            bool bRequired;

                            if (
                                NamesNode.S_FNC == sName_AtNode ||
                                NamesNode.S_ARG == sName_AtNode
                                )
                            {
                                // 「S■ｆｎｃ」
                                // 「S■ａｒｇ」
                                bRequired = true;
                            }
                            else
                            {
                                bRequired = false;
                            }

                            cf_Child.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_AtFnc, bRequired, log_Reports);
                        }


                        if (NamesNode.S_ARG == sName_AtNode)
                        {
                            // 「S■ａｒｇ」

                            int nP1p;
                            bool bP1pNameSuccessful = Util_P1p.TryParseName(sName_AtFnc, out nP1p);

                            if (bP1pNameSuccessful)
                            {
                                //
                                // 例：　＜ａｔｔｒｉｂｕｔｅ　ｎａｍｅ＝”ｐ１ｐ”＞
                                GivechapterandverseToExpression_F16_P1pImpl_ to = new GivechapterandverseToExpression_F16_P1pImpl_();

                                // Ｓｆ：ｃａｓｅ；文はここには来ない。

                                to.NP1p = nP1p;
                                to.Translate(
                                    cf_Child,
                                    owner_Ec,
                                    memoryApplication,
                                    pg_ParsingLog,
                                    log_Reports
                                    );
                            }
                            else if (
                                NamesFnc.S_TEXT_TEMPLATE == sName_OwnerFnc &&
                                //NamesNode.S_F_TEXT_TEMPLATE2 == sOwnerNodeName &&
                                PmNames.S_TABLE.Name_Pm == sName_AtFnc
                                )
                            {
                                // 【追加 2012-06-05】
                                //　＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｔｅｘｔ－ｔｅｍｐｌａｔｅ；”＞
                                //      ＜ａｒｇ　ｎａｍｅ＝”ｔａｂｌｅ”　ｖａｌｕｅ＝”～”＞

                                // 旧仕様？
                                //　「S■ｆ－ｔｅｘｔ－ｔｅｍｐｌａｔｅ　ｎａｍｅ＝””」
                                //　　　　　「S■ｔａｂｌｅ　ｎａｍｅ＝””」

                                if (log_Method.CanDebug(2))
                                {
                                    log_Method.WriteDebug_ToConsole("テキストテンプレートのテーブル属性。親要素「S■[" + sName_OwnerNode + "]　ｎａｍｅ＝”[" + sName_OwnerFnc + "]”」　自要素「[" + sName_AtNode + "]　ｎａｍｅ＝”[" + sName_AtFnc + "]”」 子要素数=[" + cf_Child.List_ChildGivechapterandverse.Count + "]　string属性数＝[" + cf_Child.Dictionary_Attribute_Givechapterandverse.Count + "]　S_Elm属性数＝[" + cf_Child.Dictionary_Attribute_Givechapterandverse.Count + "]");
                                }

                                //
                                //
                                // 自
                                //
                                //
                                string sValue;
                                cf_Child.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                                Expression_Node_String ec_Tbl = new Expression_Node_StringImpl(owner_Ec, cf_Child);
                                ec_Tbl.AppendTextNode(
                                    sValue,
                                    cf_Child,
                                    log_Reports
                                    );

                                owner_Ec.Dictionary_Expression_Attribute.Set(
                                    PmNames.S_TABLE.Name_Pm,
                                    ec_Tbl,
                                    log_Reports
                                    );

                                // 無視します。
                                goto gt_nextAttr;
                            }
                            else if (this.Dic_B.ContainsKey(sName_AtFnc))
                            {
                                // キー有り。
                                GivechapterandverseToExpression_F14n16 to = this.Dic_B[sName_AtFnc];
                                to.Translate(
                                    cf_Child,
                                    owner_Ec,
                                    memoryApplication,
                                    pg_ParsingLog,
                                    log_Reports
                                    );
                            }
                            else
                            {
                                // キー無し。
                                err_Cf_AtElm = cf_Child;
                                err_SAtFncName = sName_AtFnc;
                                err_E = null;
                                goto gt_Error_KeyNotFound_Arg3;
                            }

                        }
                        else
                        {

                            GivechapterandverseToExpression_F14n16 to;
                            if (this.Dic_B.ContainsKey(sName_AtNode))//todo:ノード名と比べるのはおかしい？
                            {
                                // キー有り。
                                to = this.Dic_B[sName_AtNode];
                            }
                            else
                            {
                                // キー無し。
                                err_Cf_AtElm = cf_Child;
                                err_E = null;
                                goto gt_Error_KeyNotFound1;
                            }


                            to.Translate(
                                cf_Child,
                                owner_Ec,
                                memoryApplication,
                                pg_ParsingLog,
                                log_Reports
                                );
                        }
                        // <ａ－ｃａｓｅ>要素は、次のループで。

                    }

                }

                goto gt_nextAttr;
            //
            //
            //
            //

            gt_errorNullValue:
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー804！", log_Method);

                    Log_TextIndented t = new Log_TextIndentedImpl();

                    t.Append("　<" + cur_Cf.Name + ">要素に、ヌルのattr要素が入っていました。");
                    t.Newline();

                    t.Append("　プログラムのミスかも知れません。");
                    t.Newline();
                    t.Newline();

                    t.Append("　　・(Fcnf) ＜" + cur_Cf.Name + "＞ 要素に、＜ａ－ｗｈｅｒｅ＞要素がないものには未対応です。");
                    t.Newline();
                    t.Newline();

                    // ヒント
                    t.Append(r.Message_Givechapterandverse(cf_Child));

                    r.Message = t.ToString();
                    log_Reports.EndCreateReport();
                }
                goto gt_nextAttr;

            gt_Error_KeyNotFound_Arg3:
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー315！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();

                    s.Append("「S■ａｒｇ３」のname属性で、「p1p」、「p2p」などのattr要素の名前を期待しましたが、「S■[");
                    s.Append(err_Cf_AtElm.Name);
                    s.Append("]　name=”[" + err_SAtFncName + "]”」でした。");
                    s.Newline();
                    s.Append("[");
                    s.Append(err_Cf_AtElm.GetType().Name);
                    s.Append("]クラスでした。");
                    s.Newline();
                    s.Newline();

                    s.Append("親「S■[" + sName_OwnerNode + "]　ｎａｍｅ＝”[" + sName_OwnerFnc + "]”」");
                    s.Newline();
                    s.Newline();

                    s.Append("　プログラムにミスがあるかもしれません。");
                    s.Newline();
                    s.Newline();

                    // ヒント
                    s.Append(r.Message_Givechapterandverse(err_Cf_AtElm));
                    s.Append(r.Message_SException(err_E));

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
                goto gt_nextAttr;

            gt_Error_KeyNotFound1:
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー314！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();

                    s.Append("（タイプ１）「select」、「ｆｒｏｍ」など、attr要素の名前を期待しましたが、[");
                    s.Append(err_Cf_AtElm.Name);
                    s.Append("]でした。[");
                    s.Append(err_Cf_AtElm.GetType().Name);
                    s.Append("]クラスでした。");
                    s.Newline();
                    s.Newline();

                    s.Append("親「S■[" + sName_OwnerNode + "]　ｎａｍｅ＝”[" + sName_OwnerFnc + "]”」");
                    s.Newline();
                    s.Newline();

                    s.Append("　プログラムにミスがあるかもしれません。");
                    s.Newline();
                    s.Newline();

                    // ヒント
                    s.Append(r.Message_Givechapterandverse(err_Cf_AtElm));
                    s.Append(r.Message_SException(err_E));

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
                goto gt_nextAttr;

            gt_nextAttr:
                ;
            });

            goto gt_EndMethod;



        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, GivechapterandverseToExpression_F14n16> dic_B;

        /// <summary>
        /// Ｓｆ：ｔｅｘｔ－ｔｅｍｐｌａｔｅ；用
        /// </summary>
        private Dictionary<string, GivechapterandverseToExpression_F14n16> Dic_B
        {
            get
            {
                if (null == dic_B)
                {
                    dic_B = new Dictionary<string, GivechapterandverseToExpression_F14n16>();

                    //
                    // TODO: 間違った入れ子関係も　読み取りしてしまうので、そこらへんのチェックも入れたい。
                    //

                    // ｌｏｏｋｕｐ－ｉｄ属性。 //Ｓｆ：ｔｅｘｔ－ｔｅｍｐｌａｔｅ；用。
                    dic_B.Add(PmNames.S_LOOKUP_ID.Name_Pm, new GivechapterandverseToExpression_F16_LookupIdImpl_());


                    // "ｃａｓｅ" 、”ａｒｇ１”は？→別の場所。

                }

                return dic_B;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
