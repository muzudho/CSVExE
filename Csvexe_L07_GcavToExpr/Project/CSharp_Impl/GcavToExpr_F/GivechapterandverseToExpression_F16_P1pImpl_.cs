using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    class GivechapterandverseToExpression_F16_P1pImpl_ : GivechapterandverseToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        public override void Translate(
            Givechapterandverse_Node cur_Cf,
            Expression_Node_String parent_Ec,
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            // throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#SToE: このメソッドは廃止方針です。");

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.SName_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(18)" + cur_Cf.SName);
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
            Expression_Node_String ec_Value;
            {
                ec_Value = new Expression_Node_StringImpl(parent_Ec, cur_Cf);
                ec_Value.AppendTextNode(
                    cur_Cf.SName,
                    cur_Cf,
                    log_Reports
                    );
            }



            //
            //
            //
            // 自
            //
            //
            //
            Expression_Node_StringImpl ec_Ap1p = new Expression_Node_StringImpl(parent_Ec, cur_Cf);

            ec_Ap1p.DicExpression_Attr.Set(
                PmNames.S_NAME.SName_Pm,
                ec_Value,
                log_Reports
                );

            StringBuilder sb = new StringBuilder();
            sb.Append("p");
            sb.Append(this.NP1p);
            sb.Append("p");



            //
            //
            //
            // 属性
            //
            //
            //
            parent_Ec.DicExpression_Attr.Set(
                sb.ToString(),
                ((Expression_Node_String)ec_Ap1p),
                log_Reports
                );


            //
            // 子要素
            //
            this.ParseChild_InGivechapterandverseToExpression(
                cur_Cf,
                ec_Ap1p,
                memoryApplication,
                pg_ParsingLog,
                log_Reports
                );

            goto gt_EndMethod;
        //
        //
        //
        //
        gt_EndMethod:
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Cf.SName);
            }
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// p1p、p2p、p3pといった数字の部分。
        /// </summary>
        private int nP1p;

        /// <summary>
        /// p1p、p2p、p3pといった数字の部分。
        /// </summary>
        public int NP1p
        {
            get
            {
                return nP1p;
            }
            set
            {
                nP1p = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
