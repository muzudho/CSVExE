using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    class GivechapterandverseToExpression_F91_FListboxLabelsImpl_ : GivechapterandverseToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        public override void Translate(
            Givechapterandverse_Node cur_Cf,//「S■ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｆ－ｌｉｓｔ－ｂｏｘ－ｌａｂｅｌｓ；”」
            Expression_Node_String parent_Expr,//「E■ｖｉｅｗ」
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {

            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.SName_Library, this, "SToE", log_Reports);

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
            this.ParseAttr_InGivechapterandverseToExpression(
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
            cur_Cf.List_ChildGivechapterandverse.ForEach(delegate( Givechapterandverse_Node child_Cf, ref bool bBreak2)
            {
                string sName_Fnc;
                child_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Fnc, false, log_Reports);

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
                    this.ParseAttr_InGivechapterandverseToExpression(
                        child_Cf,
                        child_Expr,
                        true,
                        true,
                        log_Reports
                        );

                    //
                    // 子
                    //
                    this.ParseChild_InGivechapterandverseToExpression(
                        child_Cf,
                        child_Expr,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );

                    //
                    // 親
                    //
                    cur_Expr.ListExpression_Child.Add(child_Expr, log_Reports);
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
                    this.ParseAttr_InGivechapterandverseToExpression(
                        child_Cf,
                        child_Expr,
                        true,
                        true,
                        log_Reports
                        );

                    //
                    // 子
                    //
                    this.ParseChild_InGivechapterandverseToExpression(
                        child_Cf,
                        child_Expr,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );

                    //
                    // 親
                    //
                    cur_Expr.ListExpression_Child.Add(child_Expr, log_Reports);
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
                    this.ParseAttr_InGivechapterandverseToExpression(
                        child_Cf,
                        child_Expr,
                        true,
                        true,
                        log_Reports
                        );

                    //
                    // 子
                    //
                    this.ParseChild_InGivechapterandverseToExpression(
                        child_Cf,
                        child_Expr,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );

                    //
                    // 親
                    //
                    cur_Expr.ListExpression_Child.Add(child_Expr, log_Reports);
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
                        t.Append(child_Cf.SName);
                        t.Append("＞");
                        r.SMessage = t.ToString();
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
            parent_Expr.ListExpression_Child.Add(cur_Expr, log_Reports);
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
