using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    class ConfigurationtreeToExpression_F91_FListboxLabelsImpl_ : ConfigurationtreeToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        public override void Translate(
            Configurationtree_Node cur_Cf,//「S■ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｆ－ｌｉｓｔ－ｂｏｘ－ｌａｂｅｌｓ；”」
            Expression_Node_String parent_Expr,//「E■ｖｉｅｗ」
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {

            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE", log_Reports);

            if (log_Method.CanDebug(1))
            {
            }

            //
            //
            //
            // 自
            //
            //
            //
            Expression_Node_String cur_Expr = new Expression_Node_StringImpl(parent_Expr, cur_Cf);


            //
            //
            //
            // 属性
            //
            //
            //
            this.ParseAttr_InConfigurationtreeToExpression(
                cur_Cf,
                cur_Expr,
                true,
                true,
                log_Reports
                );


            //
            //
            //
            // 子
            //
            //
            //
            cur_Cf.List_Child.ForEach(delegate( Configurationtree_Node child_Cf, ref bool bBreak2)
            {
                string sName_Fnc;
                child_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Fnc, false, log_Reports);

                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole( " 子解析。　＜～　ｎａｍｅ＝”[" + sName_Fnc + "]”＞");
                }



                // todo: Sf:item-value;
                if(NamesFnc.S_ITEM_VALUE == sName_Fnc)
                {
                    //
                    // 自
                    //
                    Expression_Node_String child_Expr = new Expression_Node_StringImpl(cur_Expr, child_Cf);

                    //
                    // 属性
                    //
                    this.ParseAttr_InConfigurationtreeToExpression(
                        child_Cf,
                        child_Expr,
                        true,
                        true,
                        log_Reports
                        );

                    //
                    // 子
                    //
                    this.ParseChild_InConfigurationtreeToExpression(
                        child_Cf,
                        child_Expr,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );

                    //
                    // 親
                    //
                    cur_Expr.List_Expression_Child.Add(child_Expr, log_Reports);
                }
                else if (NamesFnc.S_ITEM_LABEL2 == sName_Fnc)
                {
                    //
                    // 自
                    //
                    Expression_Node_String child_Expr = new Expression_Node_StringImpl(cur_Expr, child_Cf);

                    //
                    // 属性
                    //
                    this.ParseAttr_InConfigurationtreeToExpression(
                        child_Cf,
                        child_Expr,
                        true,
                        true,
                        log_Reports
                        );

                    //
                    // 子
                    //
                    this.ParseChild_InConfigurationtreeToExpression(
                        child_Cf,
                        child_Expr,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );

                    //
                    // 親
                    //
                    cur_Expr.List_Expression_Child.Add(child_Expr, log_Reports);
                }
                else if (NamesFnc.S_ITEM_GRAY_OUT == sName_Fnc)
                {
                    //
                    // 自
                    //
                    Expression_Node_String child_Expr = new Expression_Node_StringImpl(cur_Expr, child_Cf);

                    //
                    // 属性
                    //
                    this.ParseAttr_InConfigurationtreeToExpression(
                        child_Cf,
                        child_Expr,
                        true,
                        true,
                        log_Reports
                        );

                    //
                    // 子
                    //
                    this.ParseChild_InConfigurationtreeToExpression(
                        child_Cf,
                        child_Expr,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );

                    //
                    // 親
                    //
                    cur_Expr.List_Expression_Child.Add(child_Expr, log_Reports);
                }
                else
                {
                    // エラー
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー803！", log_Method);

                        StringBuilder t = new StringBuilder();
                        t.Append("＜f-listbox-for-items＞要素の中に、未対応の属性名がありました。");
                        t.Append("未対応の属性＝＜");
                        t.Append(child_Cf.Name);
                        t.Append("＞");
                        r.Message = t.ToString();
                        log_Reports.EndCreateReport();
                    }

                    bBreak2 = true;
                    goto gt_gt_EndMethod2;
                }
                goto gt_gt_EndMethod2;

                //
            //
            //
            //
            gt_gt_EndMethod2:
                ;
            });


            //
            //
            //
            // 親へ連結
            //
            //
            //
            parent_Expr.List_Expression_Child.Add(cur_Expr, log_Reports);
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
