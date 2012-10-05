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
    /// 引数呼出し箇所。
    /// </summary>
    class ConfigurationtreeToExpression_F14_FparamImpl_ : ConfigurationtreeToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ＜ｆ－ｐａｒａｍ＞
        /// </summary>
        /// <param name="oFStrNode"></param>
        /// <param name="nFAelem"></param>
        /// <param name="moOpyopyo"></param>
        /// <param name="log_Reports"></param>
        public override void Translate(
            Configurationtree_Node cur_Cf,//＜ｆ－ｐａｒａｍ＞
            Expression_Node_String parent_Ec,//親＜●●＞要素。汎用。
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(28)" + cur_Cf.Name);
            }

            //
            //
            //
            //


            //
            //
            //
            // 自
            //
            //
            //
            Expression_FparamImpl cur_Ec = new Expression_FparamImpl(parent_Ec, cur_Cf, memoryApplication);


            //
            //
            //
            // 属性
            //
            //
            //
            if (log_Reports.Successful)
            {
                // 非必須　ｃａｌｌ＝””　ｃａｌｌ属性がなくても正常です。子要素を見に行きます。
                this.ParseAttr_InConfigurationtreeToExpression(
                    cur_Cf,
                    cur_Ec,
                    false,//ｎａｍｅ属性は無い。
                    true,//ｖａｌｕｅは子ｆ－ｓｔｒに変換。
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
            {
                // 子＜●●＞ TODO:子call属性要素。
                this.ParseChild_InConfigurationtreeToExpression(
                    cur_Cf,
                    cur_Ec,
                    memoryApplication,
                    pg_ParsingLog,
                    log_Reports
                    );
            }
            //ystem.Console.WriteLine(this.GetType().Name + "#SToE: ──────────属性ここまで");


            //
            //
            //
            // 親へ連結
            //
            //
            //
            {
                parent_Ec.List_Expression_Child.Add(cur_Ec, log_Reports);
            }

            //
            //
            //
            //

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
