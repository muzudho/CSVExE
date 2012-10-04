using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{

    /// <summary>
    /// 使ってないかも？
    /// </summary>
    class ConfigurationtreeToExpression_V56_RecordSetLoadFromImpl_ : ConfigurationtreeToExpression_AbstractImpl, ConfigurationtreeToExpression_F14n16
    {



        #region アクション
        //────────────────────────────────────────

        public void Translate(
            Configurationtree_Node cur_Gcav,
            Expression_Node_String parent_Expr,
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(40)" + cur_Gcav.Name);
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
            Expression_Node_String ec_Value = new Expression_Node_StringImpl(parent_Expr, cur_Gcav);
            ec_Value.AppendTextNode(
                cur_Gcav.Name,
                cur_Gcav,
                log_Reports
                );


            //
            //
            //
            // 自
            //
            //
            //
            Expression_Node_StringImpl cur_Expr = new Expression_Node_StringImpl(parent_Expr, cur_Gcav);


            //
            //
            //
            // 属性
            //
            //
            //
            {
                cur_Expr.SetAttribute(
                    PmNames.S_NAME.Name_Pm,
                    ec_Value,
                    log_Reports
                    );

                parent_Expr.SetAttribute(
                    NamesNode.S_RECORD_SET_LOAD_FROM,
                    ((Expression_Node_String)cur_Expr),
                    log_Reports
                    );
            }


            //
            //
            //
            // 子要素
            //
            //
            //
            {
                this.ParseChild_InConfigurationtreeToExpression(
                    cur_Gcav,
                    cur_Expr,
                    memoryApplication,
                    pg_ParsingLog,
                    log_Reports
                    );
            }

            //
            //
            //
            //

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
