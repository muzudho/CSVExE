using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//Log_TextIndented
using Xenon.Table;//NFldNameImpl
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.GcavToExpr
{

    /// <summary>
    /// Ｓｆ：ｃａｓｅ；要素
    /// 
    /// その内容は、Ｓｆ：ｓｗｉｔｃｈ；　の属性に連結。
    /// </summary>
    class ConfigurationtreeToExpression_F16_CaseImpl_ : ConfigurationtreeToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s_cur"></param>
        /// <param name="e_parent"></param>
        /// <param name="moOpyopyo"></param>
        /// <param name="log_Reports"></param>
        public override void Translate(
            Configurationtree_Node cur_Cf,//Ｓｆ：ｃａｓｅ；
            Expression_Node_String parent_Expr,//Ｓｆ：ｓｗｉｔｃｈ；
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            //throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#SToE: このメソッドは廃止方針です。");

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(8)"+cur_Cf.Name);
            }

            //
            //
            //
            //

            string parent_SName_Fnc;
            parent_Expr.TrySelectAttribute(out parent_SName_Fnc, PmNames.S_NAME.Name_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports);


            if (NamesFnc.S_SWITCH != parent_SName_Fnc)
            {
                goto gt_Error_Parent;
            }




            //
            // 親
            //
            Expression_SfswitchImpl parent_Expression_Fswitch = (Expression_SfswitchImpl)parent_Expr;

            //
            // 自
            //
            Expression_SfcaseImpl cur_Ec = (Expression_SfcaseImpl)Expression_SfcaseImpl.Create(parent_Expression_Fswitch, cur_Cf);

            //
            // 属性
            //
            {
                this.ParseAttr_InConfigurationtreeToExpression(
                    cur_Cf,
                    cur_Ec,
                    true,//ｎａｍｅ属性は必須。
                    false,//ｖａｌｕｅ属性は無い。
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
            Configurationtree_Node err_Child_Cf;
            {
                //
                // ＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｃａｓｅ；”＞
                // 　　＜ａｒｇ１　ｎａｍｅ＝”ｃａｓｅＶａｌｕｅ”　ｖａｌｕｅ＝”★”＞要素の ｖａｌｕｅ値を、nFallTrue に セット。
                //

                cur_Cf.List_Child.ForEach(delegate(Configurationtree_Node child_Cf_Arg1, ref bool bBreak)
                {
                    if (
                        // ＜ａｒｇ　＞
                        NamesNode.S_ARG == child_Cf_Arg1.Name
                        )
                    {
                        string sName_Child_Fnc;
                        child_Cf_Arg1.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Child_Fnc, true, log_Reports);

                        if (log_Method.CanDebug(1))
                        {
                            log_Method.WriteDebug_ToConsole( "　・" + child_Cf_Arg1.Name + "　ｎａｍｅ＝”[" + sName_Child_Fnc + "]”");
                        }

                        if (
                            //s_ChildArg1.Dictionary_Attribute.ContainsKey(PmNames.NAME.SAttrName) &&
                            // ｎａｍｅ＝”ｃａｓｅＶａｌｕｅ”
                            PmNames.S_VALUE_CASE.Name_Pm == sName_Child_Fnc
                            )
                        {

                            //
                            // ｃａｓｅＶａｌｕｅは、直接 value=""属性で指定されたものだけが有効です。子要素は指定できません。
                            //
                            if (child_Cf_Arg1.Dictionary_Attribute.ContainsKey(PmNames.S_VALUE.Name_Pm))
                            {
                                log_Reports.Log_Callstack.Push(log_Method, "SToE②s_Cur→e_Cur");
                                this.ParseChild_InConfigurationtreeToExpression(
                                    cur_Cf, //Ｓｆ：ｃａｓｅ；
                                    cur_Ec,// e_Cur, e_Parent, //Ｓｆ：ｃａｓｅ；
                                    memoryApplication,
                                    pg_ParsingLog,
                                    log_Reports
                                    );
                                log_Reports.Log_Callstack.Pop(log_Method, "SToE②s_Cur→e_Cur");


                                //
                                // 最初のｃａｓｅＶａｌｕｅのみ有効。
                                //
                                bBreak = true;
                            }
                            else
                            {
                                // エラー
                                err_Child_Cf = child_Cf_Arg1;
                                bBreak = true;
                                goto gt_Error_NotConstCaseValue;
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        if (log_Method.CanDebug(1))
                        {
                            log_Method.WriteDebug_ToConsole("　・" + child_Cf_Arg1.Name);
                        }
                    }

                    goto gt_End2;
                //
                //
                gt_Error_NotConstCaseValue:
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー415！", log_Method);

                        Log_TextIndented s = new Log_TextIndentedImpl();

                        s.Append("[");
                        s.Append(PmNames.S_VALUE_CASE.Name_Pm);
                        s.Append("]属性は、直接 value=””属性で指定されたものだけが有効です。子要素は指定できません。");
                        s.Newline();

                        // ヒント
                        s.Append(r.Message_Configurationtree(err_Child_Cf));

                        r.Message = s.ToString();
                        log_Reports.EndCreateReport();
                    }
                    goto gt_End2;
                    //
                    //
                gt_End2:
                    ;
                });
            }


            //
            //
            //
            // 親
            //
            //
            //
            parent_Expression_Fswitch.List_Expression_Sfcase.Add(cur_Ec);


            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole( "　┌────┐ 子要素数＝[" + cur_Cf.List_Child.Count + "]");
                cur_Cf.List_Child.ForEach(delegate(Configurationtree_Node s_Child, ref bool bBreak)
                {
                    if (NamesNode.S_ARG == s_Child.Name)
                    {
                        string sName;
                        s_Child.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName, true, log_Reports);
                        log_Method.WriteDebug_ToConsole( "　・" + s_Child.Name + "　ｎａｍｅ＝”[" + sName + "]”");
                    }
                    else
                    {
                        log_Method.WriteDebug_ToConsole( "　・" + s_Child.Name);
                    }
                });
                log_Method.WriteDebug_ToConsole( "　└────┘");


                log_Method.WriteDebug_ToConsole("　┌────┐ string属性数＝[" + cur_Cf.Dictionary_Attribute.Count + "]");
                cur_Cf.Dictionary_Attribute.ForEach(delegate(string sKey, string sValue, ref bool bBreak)
                {
                    log_Method.WriteDebug_ToConsole( "　s属　[" + sKey + "]＝[" + sValue + "]");
                });
                log_Method.WriteDebug_ToConsole( "　└────┘");

            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Parent:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー805！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("Ｓｆ：ｃａｓｅ；要素はＳｆ：ｓｗｉｔｃｈ；要素の子であるべきですが、＜");
                s.Append(parent_Expr.Cur_Configurationtree.Name);
                s.Append(":");
                s.Append(parent_SName_Fnc);
                s.Append("＞要素の子として検出されました。");
                s.Newline();

                s.Append("　プログラムにミスがあるかもしれません。");
                s.Newline();
                s.Newline();

                // ヒント
                s.Append(r.Message_Configurationtree(cur_Cf));

                r.Message = s.ToString();
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

        //────────────────────────────────────────
        #endregion



    }
}
