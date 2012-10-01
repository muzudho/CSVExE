using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.GcavToExpr
{
    class ConfigurationtreeToExpression_F14_FvariableImpl_ : ConfigurationtreeToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 「S■ｆ－ｖａｒ」
        /// </summary>
        /// <param name="oFStrNode"></param>
        /// <param name="nFAelem"></param>
        /// <param name="moOpyopyo"></param>
        /// <param name="log_Reports"></param>
        public override void Translate(
            Configurationtree_Node cur_Cf,//「S■ｆ－ｖａｒ」
            Expression_Node_String parent_Ec,//親＜●●＞
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(33)" + cur_Cf.Name);
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
            Expression_FvarImpl cur_Ec = new Expression_FvarImpl(parent_Ec, cur_Cf, memoryApplication);


            //
            //
            //
            // 属性
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.ParseAttr_InConfigurationtreeToExpression(
                    cur_Cf,
                    cur_Ec,
                    false,//ｎａｍｅ属性は無い。
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
            {
                // 非必須　ｖａｌｕｅ＝””　ｖａｌｕｅ属性がなくても正常です。子要素を見に行きます。
                if (cur_Cf.Dictionary_Attribute.ContainsKey(PmNames.S_VALUE.Name_Pm))
                {
                    string sValue;
                    cur_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);
                    cur_Ec.AppendTextNode(
                        sValue,
                        cur_Cf,
                        log_Reports
                        );
                }
            }


            //
            //
            //
            // 子
            //
            //
            //
            {
                this.ParseChild_InConfigurationtreeToExpression(
                    cur_Cf,
                    cur_Ec,
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
            {
                parent_Ec.List_Expression_Child.Add(
                    cur_Ec,
                    log_Reports
                    );
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
