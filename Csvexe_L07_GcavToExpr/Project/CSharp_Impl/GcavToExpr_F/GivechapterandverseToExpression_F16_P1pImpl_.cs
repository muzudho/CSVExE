using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    class ConfigurationtreeToExpression_F16_P1pImpl_ : ConfigurationtreeToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        public override void Translate(
            Configurationtree_Node cur_Cf,
            Expression_Node_String parent_Ec,
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            // throw new Exception(Info_SToE.LibraryName + ":" + this.GetType().Name + "#SToE: このメソッドは廃止方針です。");

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(18)" + cur_Cf.Name);
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
                    cur_Cf.Name,
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

            ec_Ap1p.SetAttribute(
                PmNames.S_NAME.Name_Pm,
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
            parent_Ec.SetAttribute(
                sb.ToString(),
                ((Expression_Node_String)ec_Ap1p),
                log_Reports
                );


            //
            // 子要素
            //
            this.ParseChild_InConfigurationtreeToExpression(
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
                pg_ParsingLog.Decrement(cur_Cf.Name);
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
