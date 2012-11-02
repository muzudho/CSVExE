using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.ConfToExpr
{
    /// <summary>
    /// 「S■ｆｎｃ」要素。
    /// </summary>
    class ConfigurationtreeToExpression_F14_FncImpl_ : ConfigurationtreeToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        public override void Translate(
            Configurationtree_Node cur_Cf,//「S■ｆｎｃ」
            Expression_Node_String parent_Ec,//「S■ｆｎｃ」、や「S■ｅｖｅｎｔ」か？
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

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
                bool bHit9 = parent_Ec.TrySelectAttribute(out parent_SName_Fnc, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);


                if (!log_Reports.Successful)
                {
                    goto gt_EndMethod;
                }
                else if (NamesNode.S_FNC == parent_Ec.Cur_Configuration.Name && "" == parent_SName_Fnc)
                {
                    //
                    // エラー。親要素が、ｎａｍｅ属性を持たない「E■ｆｎｃ」だった。
                    //
                    goto gt_Error_NoNameParent1;
                }
            }

            // 　　「E■ｆｎｃ」には、ｎａｍｅ＝”★”属性が必須。
            bool bHit = cur_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_MyFnc, true, log_Reports);

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
                    cur_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sFcName, true, log_Reports);
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
                this.ParseAttr_InConfigurationtreeToExpression(
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
                    ConfigurationtreeToExpression_V55_AEmptyFieldImpl_ to = new ConfigurationtreeToExpression_V55_AEmptyFieldImpl_();
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
                    || (NamesNode.S_FNC == parent_Ec.Cur_Configuration.Name)
                    || (NamesFnc.S_CELL == sName_MyFnc || NamesFnc.S_TEXT_TEMPLATE == sName_MyFnc)
                    || (sName_MyFnc == NamesFnc.S_REC_COND && NamesNode.S_FNC == parent_Ec.Cur_Configuration.Name && NamesFnc.S_WHERE == parent_SName_Fnc)//親が＜ｒｅｃ－ｃｏｎｄ＞で、自＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：Ｗｈｅｒｅ；”＞要素
                    )
                {                    
                    parent_Ec.List_Expression_Child.Add(cur_Ec, log_Reports);
                }
                else
                {
                    // エラー

                    goto gt_Error_CanNotAddParent;
                    // todo:
                    //throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#SToE:（１８）★★親要素へ連結不能　　　　・親「E■[" + e_Parent.Cur_Configurationtree.Name + "]　ｎａｍｅ＝”[" + sParentFncName + "]”」　←　自「S■[" + s_AFnc.Name_Node + "]　ｎａｍｅ＝”[" + sFncName + "]”」中止。　／エラー。親要素に追加しようとしましたが、予想しない親要素でした。");
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
                            log_Method.WriteDebug_ToConsole("「S■" + e_Child.Cur_Configuration.Name + "」");
                        });

                    log_Method.WriteDebug_ToConsole( "（２２） └────┘");

                    log_Method.WriteDebug_ToConsole( "（２３）└────────────────┘ 「S■[" + cur_Cf.Name + "]　ｎａｍｅ＝”[" + sName_MyFnc + "]”」（ｆｎｃ）要素解析終了。");


                    //
                    // ｎａｍｅ属性の指定は必須です。
                    //
                    string sName8;
                    bool bHit8 = cur_Ec.TrySelectAttribute(out sName8, PmNames.S_NAME.Name_Pm, EnumHitcount.One, log_Reports);
                    if (!bHit8)
                    {
                        // todo:
                        throw new Exception(Info_ConfigurationtreeToExpression.Name_Library + ":" + this.GetType().Name + "#SToE:（２４）ｆｎｃ要素にｎａｍｅ属性が指定されていないのはエラーです①。");
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, cur_Cf.Name, log_Reports);//設定ノード名
                tmpl.SetParameter(2, sName_MyFnc, log_Reports);//関数名

                if (null != cur_Ec)
                {
                    tmpl.SetParameter(3, cur_Ec.Dictionary_Expression_Attribute.Count.ToString(), log_Reports);//属性の数

                    //属性リスト
                    StringBuilder s1 = new StringBuilder();
                    cur_Ec.Dictionary_Expression_Attribute.ForEach(
                        delegate(string sName2, Expression_Node_String e_Attr2, ref bool bBreak)
                        {
                            s1.Append("属" + sName2 + "＝”" + e_Attr2.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "”\n");
                        });
                    tmpl.SetParameter(4, s1.ToString(), log_Reports);

                    tmpl.SetParameter(5, cur_Ec.List_Expression_Child.Count.ToString(), log_Reports);//子要素の数

                    //子要素リスト
                    StringBuilder s2 = new StringBuilder();
                    cur_Ec.List_Expression_Child.ForEach(
                        delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                        {
                            s2.Append("子「S■" + e_Child.Cur_Configuration.Name + "」\n");
                        });
                    tmpl.SetParameter(6, s2.ToString(), log_Reports);

                    tmpl.SetParameter(7, NamesNode.S_ARG, log_Reports);//期待の親設定ノード名
                    tmpl.SetParameter(8, PmNames.S_WHERE.Name_Pm, log_Reports);//期待の親設定関数名
                }
                else
                {
                    tmpl.SetParameter(3, "ヌル", log_Reports);//設定属性の数
                    tmpl.SetParameter(4, "ヌル", log_Reports);//設定属性リスト
                    tmpl.SetParameter(5, "ヌル", log_Reports);//設定子要素の数
                    tmpl.SetParameter(6, "ヌル", log_Reports);//設定子要素リスト
                    tmpl.SetParameter(7, "ヌル", log_Reports);//期待の親設定ノード名
                    tmpl.SetParameter(8, "ヌル", log_Reports);//期待の親設定関数名
                }

                if (null != parent_Ec)
                {
                    tmpl.SetParameter(9, parent_Ec.Cur_Configuration.Name, log_Reports);//実際の親Expression要素ノード名
                    tmpl.SetParameter(10, parent_SName_Fnc, log_Reports);//実際の親Expression要素関数名
                    tmpl.SetParameter(11, parent_Ec.Dictionary_Expression_Attribute.Count.ToString(), log_Reports);//Expression属性の数

                    StringBuilder s3 = new StringBuilder();
                    parent_Ec.Dictionary_Expression_Attribute.ForEach(
                        delegate(string sName2, Expression_Node_String e_Attr2, ref bool bBreak)
                        {
                            s3.Append("属" + sName2 + "＝”" + e_Attr2.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "”\n");
                        });
                    tmpl.SetParameter(12, s3.ToString(), log_Reports);//子Expression属性リスト

                    tmpl.SetParameter(13, parent_Ec.List_Expression_Child.Count.ToString(), log_Reports);//子Expression要素数

                    StringBuilder s4 = new StringBuilder();
                    parent_Ec.List_Expression_Child.ForEach(
                        delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                        {
                            s4.Append("子「S■" + e_Child.Cur_Configuration.Name + "」\n");
                        });
                    tmpl.SetParameter(14, s4.ToString(), log_Reports);//子Expression要素リスト

                }
                else
                {
                    tmpl.SetParameter(9, "ヌル", log_Reports);//実際の親Expression要素ノード名
                    tmpl.SetParameter(10, "ヌル", log_Reports);//実際の親Expression要素関数名
                    tmpl.SetParameter(11, "ヌル", log_Reports);//Expression属性の数
                    tmpl.SetParameter(12, "ヌル", log_Reports);//子Expression属性リスト
                    tmpl.SetParameter(13, "ヌル", log_Reports);//子Expression要素数
                    tmpl.SetParameter(14, "ヌル", log_Reports);//子Expression要素リスト
                }

                tmpl.SetParameter(15, Log_RecordReportsImpl.ToText_Configuration(parent_Ec.Cur_Configuration), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:7021;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NoNameParent2:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, cur_Cf.Name, log_Reports);//設定ノード名
                tmpl.SetParameter(2, sName_MyFnc, log_Reports);//関数名

                if (null != cur_Ec)
                {
                    tmpl.SetParameter(3, cur_Ec.Dictionary_Expression_Attribute.Count.ToString(), log_Reports);//属性の数

                    //属性リスト
                    StringBuilder s1 = new StringBuilder();
                    cur_Ec.Dictionary_Expression_Attribute.ForEach(
                        delegate(string sName2, Expression_Node_String e_Attr2, ref bool bBreak)
                        {
                            s1.Append("属" + sName2 + "＝”" + e_Attr2.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "”\n");
                        });
                    tmpl.SetParameter(4, s1.ToString(), log_Reports);

                    tmpl.SetParameter(5, cur_Ec.List_Expression_Child.Count.ToString(), log_Reports);//子要素の数

                    //子要素リスト
                    StringBuilder s2 = new StringBuilder();
                    cur_Ec.List_Expression_Child.ForEach(
                        delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                        {
                            s2.Append("子「S■" + e_Child.Cur_Configuration.Name + "」\n");
                        });
                    tmpl.SetParameter(6, s2.ToString(), log_Reports);

                    tmpl.SetParameter(7, NamesNode.S_ARG, log_Reports);//期待の親設定ノード名
                    tmpl.SetParameter(8, PmNames.S_WHERE.Name_Pm, log_Reports);//期待の親設定関数名
                }
                else
                {
                    tmpl.SetParameter(3, "ヌル", log_Reports);//設定属性の数
                    tmpl.SetParameter(4, "ヌル", log_Reports);//設定属性リスト
                    tmpl.SetParameter(5, "ヌル", log_Reports);//設定子要素の数
                    tmpl.SetParameter(6, "ヌル", log_Reports);//設定子要素リスト
                    tmpl.SetParameter(7, "ヌル", log_Reports);//期待の親設定ノード名
                    tmpl.SetParameter(8, "ヌル", log_Reports);//期待の親設定関数名
                }

                if (null != parent_Ec)
                {
                    tmpl.SetParameter(9, parent_Ec.Cur_Configuration.Name, log_Reports);//実際の親Expression要素ノード名
                    tmpl.SetParameter(10, parent_SName_Fnc, log_Reports);//実際の親Expression要素関数名
                    tmpl.SetParameter(11, parent_Ec.Dictionary_Expression_Attribute.Count.ToString(), log_Reports);//Expression属性の数

                    StringBuilder s3 = new StringBuilder();
                    parent_Ec.Dictionary_Expression_Attribute.ForEach(
                        delegate(string sName2, Expression_Node_String e_Attr2, ref bool bBreak)
                        {
                            s3.Append("属" + sName2 + "＝”" + e_Attr2.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "”\n");
                        });
                    tmpl.SetParameter(12, s3.ToString(), log_Reports);//子Expression属性リスト

                    tmpl.SetParameter(13, parent_Ec.List_Expression_Child.Count.ToString(), log_Reports);//子Expression要素数

                    StringBuilder s4 = new StringBuilder();
                    parent_Ec.List_Expression_Child.ForEach(
                        delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                        {
                            s4.Append("子「S■" + e_Child.Cur_Configuration.Name + "」\n");
                        });
                    tmpl.SetParameter(14, s4.ToString(), log_Reports);//子Expression要素リスト

                }
                else
                {
                    tmpl.SetParameter(9, "ヌル", log_Reports);//実際の親Expression要素ノード名
                    tmpl.SetParameter(10, "ヌル", log_Reports);//実際の親Expression要素関数名
                    tmpl.SetParameter(11, "ヌル", log_Reports);//Expression属性の数
                    tmpl.SetParameter(12, "ヌル", log_Reports);//子Expression属性リスト
                    tmpl.SetParameter(13, "ヌル", log_Reports);//子Expression要素数
                    tmpl.SetParameter(14, "ヌル", log_Reports);//子Expression要素リスト
                }

                tmpl.SetParameter(15, Log_RecordReportsImpl.ToText_Configuration(parent_Ec.Cur_Configuration), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:7022;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NoNameParent1:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, cur_Cf.Name, log_Reports);//設定ノード名
                tmpl.SetParameter(2, sName_MyFnc, log_Reports);//関数名

                if (null != cur_Ec)
                {
                    tmpl.SetParameter(3, cur_Ec.Dictionary_Expression_Attribute.Count.ToString(), log_Reports);//属性の数

                    //属性リスト
                    StringBuilder s1 = new StringBuilder();
                    cur_Ec.Dictionary_Expression_Attribute.ForEach(
                        delegate(string sName2, Expression_Node_String e_Attr2, ref bool bBreak)
                        {
                            s1.Append("属" + sName2 + "＝”" + e_Attr2.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "”\n");
                        });
                    tmpl.SetParameter(4, s1.ToString(), log_Reports);

                    tmpl.SetParameter(5, cur_Ec.List_Expression_Child.Count.ToString(), log_Reports);//子要素の数

                    //子要素リスト
                    StringBuilder s2 = new StringBuilder();
                    cur_Ec.List_Expression_Child.ForEach(
                        delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                        {
                            s2.Append("子「S■" + e_Child.Cur_Configuration.Name + "」\n");
                        });
                    tmpl.SetParameter(6, s2.ToString(), log_Reports);

                    tmpl.SetParameter(7, NamesNode.S_ARG, log_Reports);//期待の親設定ノード名
                    tmpl.SetParameter(8, PmNames.S_WHERE.Name_Pm, log_Reports);//期待の親設定関数名
                }
                else
                {
                    tmpl.SetParameter(3, "ヌル", log_Reports);//設定属性の数
                    tmpl.SetParameter(4, "ヌル", log_Reports);//設定属性リスト
                    tmpl.SetParameter(5, "ヌル", log_Reports);//設定子要素の数
                    tmpl.SetParameter(6, "ヌル", log_Reports);//設定子要素リスト
                    tmpl.SetParameter(7, "ヌル", log_Reports);//期待の親設定ノード名
                    tmpl.SetParameter(8, "ヌル", log_Reports);//期待の親設定関数名
                }

                if (null != parent_Ec)
                {
                    tmpl.SetParameter(9, parent_Ec.Cur_Configuration.Name, log_Reports);//実際の親Expression要素ノード名
                    tmpl.SetParameter(10, parent_SName_Fnc, log_Reports);//実際の親Expression要素関数名
                    tmpl.SetParameter(11, parent_Ec.Dictionary_Expression_Attribute.Count.ToString(), log_Reports);//Expression属性の数

                    StringBuilder s3 = new StringBuilder();
                    parent_Ec.Dictionary_Expression_Attribute.ForEach(
                        delegate(string sName2, Expression_Node_String e_Attr2, ref bool bBreak)
                        {
                            s3.Append("属" + sName2 + "＝”" + e_Attr2.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "”\n");
                        });
                    tmpl.SetParameter(12, s3.ToString(), log_Reports);//子Expression属性リスト

                    tmpl.SetParameter(13, parent_Ec.List_Expression_Child.Count.ToString(), log_Reports);//子Expression要素数

                    StringBuilder s4 = new StringBuilder();
                    parent_Ec.List_Expression_Child.ForEach(
                        delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                        {
                            s4.Append("子「S■" + e_Child.Cur_Configuration.Name + "」\n");
                        });
                    tmpl.SetParameter(14, s4.ToString(), log_Reports);//子Expression要素リスト

                }
                else
                {
                    tmpl.SetParameter(9, "ヌル", log_Reports);//実際の親Expression要素ノード名
                    tmpl.SetParameter(10, "ヌル", log_Reports);//実際の親Expression要素関数名
                    tmpl.SetParameter(11, "ヌル", log_Reports);//Expression属性の数
                    tmpl.SetParameter(12, "ヌル", log_Reports);//子Expression属性リスト
                    tmpl.SetParameter(13, "ヌル", log_Reports);//子Expression要素数
                    tmpl.SetParameter(14, "ヌル", log_Reports);//子Expression要素リスト
                }

                tmpl.SetParameter(15, Log_RecordReportsImpl.ToText_Configuration(parent_Ec.Cur_Configuration), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:7023;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullParent:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configuration(cur_Cf), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:7004;", tmpl, log_Reports);
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



        private void ParseChild_SpecialFnc_(
            Configurationtree_Node cur_Cf,
            Expression_Node_String cur_Ec,//「S■ｆｎｃ」、や「S■ｅｖｅｎｔ」か？
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "ParseChild_Special_",log_Reports);
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
            cur_Cf.List_Child.ForEach(delegate(Configurationtree_Node s_Child, ref bool bBreak)
            {
                if (log_Reports.Successful)
                {
                    if (NamesNode.S_ARG == s_Child.Name)
                    {
                        //━━━━━
                        // ａｒｇ
                        //━━━━━

                        string sName_MyFnc;
                        cur_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_MyFnc, false, log_Reports);

                        string sName_ChildFnc;
                        s_Child.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_ChildFnc, false, log_Reports);


                        //
                        bool bNormalize = false;
                        if(
                            // 親が「E■ｆｎｃ」
                            NamesNode.S_FNC == cur_Ec.Cur_Configuration.Name &&
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
                            ConfigurationtreeToExpression_F14n16 to = new ConfigurationtreeToExpression_F14_FArgImpl();
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
                            s_Child.Dictionary_Attribute.ForEach(delegate(string sPmName2, string sAttrValue2, ref bool bBreak2)
                            {
                                if (PmNames.S_VALUE.Name_Pm == sPmName2)
                                {
                                    // value属性が指定されていた場合。
                                    s_Child.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                                    // 「E■ａｒｇ１」は作らずに、親要素の属性として追加。
                                    Expression_Node_String e_Value = new Expression_Leaf_StringImpl(sValue, cur_Ec, cur_Ec.Cur_Configuration);
                                    cur_Ec.SetAttribute(sName_ChildFnc, e_Value, log_Reports);
                                }
                            });


                            //
                            // 子要素の有無。
                            //
                            if (0 < s_Child.List_Child.Count)
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

                                    ConfigurationtreeToExpression_F14_FncImpl_ to2 = new ConfigurationtreeToExpression_F14_FncImpl_();
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
                                    cur_Ec.SetAttribute(sName_ChildFnc, ec_Value, log_Reports);
                                }
                            }
                            else
                            {
                                if ("" == sValue)
                                {
                                    // todo:
                                    throw new Exception(Info_ConfigurationtreeToExpression.Name_Library + ":" + this.GetType().Name + "#ParseChild:（３） 「S■[" + cur_Cf.Name + "]」の子要素「S■[" + s_Child.Name + "]」に、value属性がありませんでした。子要素もありませんでした。");
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
                        ConfigurationtreeToExpression_F14_FvariableImpl_ to = new ConfigurationtreeToExpression_F14_FvariableImpl_();
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
                        ConfigurationtreeToExpression_F14_FstrImpl_ to = new ConfigurationtreeToExpression_F14_FstrImpl_();
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
                        ConfigurationtreeToExpression_F14n16 to = new ConfigurationtreeToExpression_F14_FncImpl_();
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
                        ConfigurationtreeToExpression_F14_FparamImpl_ to4 = new ConfigurationtreeToExpression_F14_FparamImpl_();
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
                        throw new Exception(Info_ConfigurationtreeToExpression.Name_Library + ":" + this.GetType().Name + "#ParseChild:（１６） 「S■[" + cur_Cf.Name + "]」に、未定義の子要素「S■[" + s_Child.Name + "]」がありました。");
                    }
                }

                goto gt_EndMethod2;

                //
            gt_Error_UndefinedChlid:
                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, cur_Cf.Name, log_Reports);//設定ノード名
                    tmpl.SetParameter(2, s_Child.Name, log_Reports);//子要素名
                    tmpl.SetParameter(3, cur_Cf.Dictionary_Attribute.Count.ToString(), log_Reports);//string属性の数

                    //string属性のリスト
                    StringBuilder s1 = new StringBuilder();
                    cur_Cf.Dictionary_Attribute.ForEach(delegate(string sKey2, string sValue2, ref bool bBreak2)
                    {
                        s1.Append("s属　[" + sKey2 + "]＝[" + sValue2 + "]\n");
                    });
                    tmpl.SetParameter(4, s1.ToString(), log_Reports);

                    tmpl.SetParameter(5, cur_Cf.List_Child.Count.ToString(), log_Reports);//子要素の数

                    //子要素のリスト
                    StringBuilder s2 = new StringBuilder();
                    cur_Cf.List_Child.ForEach(
                        delegate(Configurationtree_Node cf_Child2, ref bool bBreak5)
                        {
                            s2.Append("子「S■" + cf_Child2.Name + "」\n");
                        });
                    tmpl.SetParameter(6, s2.ToString(), log_Reports);

                    tmpl.SetParameter(7, Log_RecordReportsImpl.ToText_Configuration(cur_Cf), log_Reports);//設定位置パンくずリスト

                    memoryApplication.CreateErrorReport("Er:7005;", tmpl, log_Reports);
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
            Configurationtree_Node cur_Cf,//「S■ｆｎｃ」
            Expression_Node_String owner_Ec,// 「E■ｆｎｃ」
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            // a-●●要素や、switch要素など。

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "ParseChild_SpecialSwitch_",log_Reports);

            //
            //
            //
            //

            //
            // データ_ソース、データ_ターゲット、＜ｆｎｃ　＞の子要素。


            string sName_OwnerNode = owner_Ec.Cur_Configuration.Name;
            string sName_OwnerFnc = "";
            {
                EnumHitcount enumHitcount;
                if (NamesNode.S_FNC == sName_OwnerNode
                    //||
                    //NamesNode.S_F_TEXT_TEMPLATE2 == sOwnerNodeName
                    )
                {
                    enumHitcount = EnumHitcount.One;
                }
                else
                {
                    enumHitcount = EnumHitcount.One_Or_Zero;
                }
                bool bHit = owner_Ec.TrySelectAttribute(out sName_OwnerFnc, PmNames.S_NAME.Name_Pm, enumHitcount, log_Reports);
            }


            string sName_MyFnc;
            cur_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_MyFnc, true, log_Reports);

            //
            // ＜ｆ－ｓｗｉｔｃｈ＞要素であれば、子Ｓｆ：ｃａｓｅ；要素が何個もある。
            //
            if (log_Reports.Successful)
            {
                if (NamesFnc.S_SWITCH == sName_MyFnc)
                {
                    cur_Cf.List_Child.ForEach(delegate(Configurationtree_Node s_Child, ref bool bBreak)
                    {
                        Configurationtree_Node err_CfAttr;
                        if (log_Reports.Successful)
                        {
                            string sName;
                            s_Child.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName, true, log_Reports);

                            if (
                                NamesNode.S_FNC == s_Child.Name
                                && NamesFnc.S_CASE == sName
                                )
                            {
                                ConfigurationtreeToExpression_F14n16_AbstractImpl_ to = new ConfigurationtreeToExpression_F16_CaseImpl_();
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
                                ConfigurationtreeToExpression_F14n16 to = new ConfigurationtreeToExpression_F14_FArgImpl();
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
                    gt_Error_NotACase:
                        {
                            Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                            tmpl.SetParameter(1, err_CfAttr.Name, log_Reports);//設定ノード名
                            tmpl.SetParameter(2, err_CfAttr.GetType().Name, log_Reports);//ノードのクラス名
                            tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Configuration(err_CfAttr), log_Reports);//設定位置パンくずリスト

                            memoryApplication.CreateErrorReport("Er:7006;", tmpl, log_Reports);
                        }
                        goto gt_EndMethod2;
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
            Configurationtree_Node cur_Cf,
            Expression_Node_String owner_Ec,
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "ParseChild_Special_",log_Reports);

            //
            //
            //
            //

            //
            // データ_ソース、データ_ターゲット、＜ｆｎｃ　＞の子要素。


            string sName_OwnerNode = owner_Ec.Cur_Configuration.Name;
            string sName_OwnerFnc = "";
            {
                EnumHitcount enumHitcount;
                if (NamesNode.S_FNC == sName_OwnerNode
                    //||
                    //NamesNode.S_F_TEXT_TEMPLATE2 == sOwnerNodeName
                    )
                {
                    enumHitcount = EnumHitcount.One;
                }
                else
                {
                    enumHitcount = EnumHitcount.One_Or_Zero;
                }
                bool bHit = owner_Ec.TrySelectAttribute(out sName_OwnerFnc, PmNames.S_NAME.Name_Pm, enumHitcount, log_Reports);
            }



            //
            //
            //
            // 子
            //
            //
            //
            string err_SAtFncName;
            Configurationtree_Node err_Cf_AtElm;
            Exception err_E;

            cur_Cf.List_Child.ForEach(delegate(Configurationtree_Node cf_Child, ref bool bBreak)
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

                            cf_Child.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_AtFnc, bRequired, log_Reports);
                        }


                        if (NamesNode.S_ARG == sName_AtNode)
                        {
                            // 「S■ａｒｇ」

                            int nP1p;
                            bool bP1pNameSuccessful = Utility_TexttemplateP1p.TryParseName(sName_AtFnc, out nP1p);

                            if (bP1pNameSuccessful)
                            {
                                //
                                // 例：　＜ａｔｔｒｉｂｕｔｅ　ｎａｍｅ＝”ｐ１ｐ”＞
                                ConfigurationtreeToExpression_F16_P1pImpl_ to = new ConfigurationtreeToExpression_F16_P1pImpl_();

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
                                    log_Method.WriteDebug_ToConsole("テキストテンプレートのテーブル属性。親要素「S■[" + sName_OwnerNode + "]　ｎａｍｅ＝”[" + sName_OwnerFnc + "]”」　自要素「[" + sName_AtNode + "]　ｎａｍｅ＝”[" + sName_AtFnc + "]”」 子要素数=[" + cf_Child.List_Child.Count + "]　string属性数＝[" + cf_Child.Dictionary_Attribute.Count + "]　S_Elm属性数＝[" + cf_Child.Dictionary_Attribute.Count + "]");
                                }

                                //
                                //
                                // 自
                                //
                                //
                                string sValue;
                                cf_Child.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                                Expression_Node_String ec_Tbl = new Expression_Node_StringImpl(owner_Ec, cf_Child);
                                ec_Tbl.AppendTextNode(
                                    sValue,
                                    cf_Child,
                                    log_Reports
                                    );

                                owner_Ec.SetAttribute(
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
                                ConfigurationtreeToExpression_F14n16 to = this.Dic_B[sName_AtFnc];
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

                            ConfigurationtreeToExpression_F14n16 to;
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
                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, cur_Cf.Name, log_Reports);//設定ノード名
                    tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(cf_Child), log_Reports);//設定位置パンくずリスト

                    memoryApplication.CreateErrorReport("Er:7007;", tmpl, log_Reports);
                }
                goto gt_nextAttr;

            gt_Error_KeyNotFound_Arg3:
                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, err_Cf_AtElm.Name, log_Reports);//設定ノード名
                    tmpl.SetParameter(2, err_SAtFncName, log_Reports);//関数名
                    tmpl.SetParameter(3, err_Cf_AtElm.GetType().Name, log_Reports);//関数のクラス名
                    tmpl.SetParameter(4, sName_OwnerNode, log_Reports);//親設定ノード名
                    tmpl.SetParameter(5, sName_OwnerFnc, log_Reports);//親設定関数名
                    tmpl.SetParameter(6, Log_RecordReportsImpl.ToText_Configuration(err_Cf_AtElm), log_Reports);//設定位置パンくずリスト
                    tmpl.SetParameter(7, Log_RecordReportsImpl.ToText_Exception(err_E), log_Reports);//例外メッセージ

                    memoryApplication.CreateErrorReport("Er:7008;", tmpl, log_Reports);
                }
                goto gt_nextAttr;

            gt_Error_KeyNotFound1:
                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, err_Cf_AtElm.Name, log_Reports);//設定ノード名
                    tmpl.SetParameter(2, err_Cf_AtElm.GetType().Name, log_Reports);//設定ノードのクラス名
                    tmpl.SetParameter(3, sName_OwnerNode, log_Reports);//親設定ノード名
                    tmpl.SetParameter(4, sName_OwnerFnc, log_Reports);//親設定関数名
                    tmpl.SetParameter(5, Log_RecordReportsImpl.ToText_Configuration(err_Cf_AtElm), log_Reports);//設定位置パンくずリスト
                    tmpl.SetParameter(6, Log_RecordReportsImpl.ToText_Exception(err_E), log_Reports);//例外メッセージ

                    memoryApplication.CreateErrorReport("Er:7009;", tmpl, log_Reports);
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

        private Dictionary<string, ConfigurationtreeToExpression_F14n16> dic_B;

        /// <summary>
        /// Ｓｆ：ｔｅｘｔ－ｔｅｍｐｌａｔｅ；用
        /// </summary>
        private Dictionary<string, ConfigurationtreeToExpression_F14n16> Dic_B
        {
            get
            {
                if (null == dic_B)
                {
                    dic_B = new Dictionary<string, ConfigurationtreeToExpression_F14n16>();

                    //
                    // TODO: 間違った入れ子関係も　読み取りしてしまうので、そこらへんのチェックも入れたい。
                    //

                    // ｌｏｏｋｕｐ－ｉｄ属性。 //Ｓｆ：ｔｅｘｔ－ｔｅｍｐｌａｔｅ；用。
                    dic_B.Add(PmNames.S_LOOKUP_ID.Name_Pm, new ConfigurationtreeToExpression_F16_LookupIdImpl_());


                    // "ｃａｓｅ" 、”ａｒｇ１”は？→別の場所。

                }

                return dic_B;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
