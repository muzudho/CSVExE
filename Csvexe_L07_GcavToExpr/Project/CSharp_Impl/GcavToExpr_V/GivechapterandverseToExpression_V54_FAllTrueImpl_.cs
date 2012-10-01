using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;


namespace Xenon.GcavToExpr
{

    class ConfigurationtreeToExpression_V54_FAllTrueImpl_ : ConfigurationtreeToExpression_AbstractImpl
    {



        #region アクション
        //────────────────────────────────────────

        public void Translate(
            Configurationtree_Node cur_Gcav,
            Expressionv_4ADisplayImpl exprv_ADisplay,
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(38)" + cur_Gcav.Name);
            }

            //
            //

            //
            //
            //
            // 自
            //
            //
            //
            Expressionv_5FAllTrueImpl cur_Exprv = new Expressionv_5FAllTrueImpl(exprv_ADisplay, cur_Gcav, memoryApplication);


            //
            //
            //
            // 子
            //
            //
            //
            if(log_Reports.Successful)
            {
                exprv_ADisplay.List_Expression_Child.Add(
                    cur_Exprv,
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
            List<Configurationtree_Node> cfList_Fnc = cur_Gcav.GetChildrenByNodename(NamesNode.S_FNC, false, log_Reports);
            foreach (Configurationtree_Node cf_Child in cfList_Fnc)
            {
                string child_SName_Fnc;
                cf_Child.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out child_SName_Fnc, true, log_Reports);

                if (NamesFnc.S_VLD_EMPTY_FIELD == child_SName_Fnc)
                {
                    // ＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞要素
                    ConfigurationtreeToExpression_V55_AEmptyFieldImpl_ to = new ConfigurationtreeToExpression_V55_AEmptyFieldImpl_();
                    to.Translate(
                        cf_Child,
                        cur_Exprv,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }
                else
                {
                    if (log_Method.CanDebug(0))
                    {
                        log_Method.WriteError_ToConsole("未実装です。");
                    }

                    throw new Exception("未実装です。");
                }
            }

            goto gt_EndMethod;
        //
        //
        //
        //
        gt_EndMethod:

            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Gcav.Name);
            }
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
