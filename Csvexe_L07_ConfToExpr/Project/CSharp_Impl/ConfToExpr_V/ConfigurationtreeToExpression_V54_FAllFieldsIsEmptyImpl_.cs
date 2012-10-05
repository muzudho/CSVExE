using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.ConfToExpr
{

    class ConfigurationtreeToExpression_V54_FAllFieldsIsEmptyImpl_ : ConfigurationtreeToExpression_AbstractImpl
    {



        #region アクション
        //────────────────────────────────────────

        public void Translate(
            Configurationtree_Node cur_Conf,
            Expressionv_4ADisplayImpl parent_Exprv,
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(37)" + cur_Conf.Name);
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
            Expressionv_5FAllFieldsIsEmptyImpl cur_Exprv = new Expressionv_5FAllFieldsIsEmptyImpl(parent_Exprv, cur_Conf, memoryApplication);


            //
            //
            //
            // 子
            //
            //
            //
            {
                this.ParseChild_InConfigurationtreeToExpression(
                    cur_Conf,
                    cur_Exprv,
                    memoryApplication,
                    pg_ParsingLog,
                    log_Reports
                    );
            }


            //
            //
            //
            // 親へ連結
            //
            //
            //
            parent_Exprv.List_Expression_Child.Add(
                cur_Exprv,
                log_Reports
                );


            // #デバッグ中
            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole(" ★★ ＜ｆ－ａｌｌ－ｆｉｅｌｄｓ－ｉｓ－ｅｍｐｔｙ＞ 子要素数＝[" + cur_Exprv.List_Expression_Child.Count + "] 属性数＝[" + cur_Exprv.Dictionary_Expression_Attribute.Count + "]");
            }

            goto gt_EndMethod;
        //
        //
        //
        //
        gt_EndMethod:

            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Conf.Name);
            }
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
