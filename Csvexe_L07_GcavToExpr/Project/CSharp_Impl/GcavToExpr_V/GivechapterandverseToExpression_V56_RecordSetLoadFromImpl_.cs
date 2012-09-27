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
    class GivechapterandverseToExpression_V56_RecordSetLoadFromImpl_ : GivechapterandverseToExpression_AbstractImpl, GivechapterandverseToExpression_F14n16
    {



        #region アクション
        //────────────────────────────────────────

        public void Translate(
            Givechapterandverse_Node cur_Gcav,
            Expression_Node_String parent_Expr,
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.SName_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(40)" + cur_Gcav.SName);
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
                cur_Gcav.SName,
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
                cur_Expr.DicExpression_Attr.Set(
                    PmNames.S_NAME.SName_Pm,
                    ec_Value,
                    log_Reports
                    );

                parent_Expr.DicExpression_Attr.Set(
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
                this.ParseChild_InGivechapterandverseToExpression(
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
                pg_ParsingLog.Decrement(cur_Gcav.SName);
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
