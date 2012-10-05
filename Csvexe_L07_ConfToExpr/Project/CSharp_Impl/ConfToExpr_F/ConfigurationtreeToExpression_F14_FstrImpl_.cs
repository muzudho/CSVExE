using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.ConfToExpr
{
    class ConfigurationtreeToExpression_F14_FstrImpl_ : ConfigurationtreeToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ＜ｆ－ｓｔｒ＞
        /// </summary>
        /// <param name="oFStrNode"></param>
        /// <param name="nFAelem"></param>
        /// <param name="moOpyopyo"></param>
        /// <param name="log_Reports"></param>
        public override void Translate(
            Configurationtree_Node cur_Cf,//＜ｆ－ｓｔｒ＞
            Expression_Node_String parent_Ec,//親＜●●＞。
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(30)" + cur_Cf.Name);
            }

            //
            //
            //
            //

            if (null == parent_Ec)
            {
                goto gt_Error_NullFAelem;
            }


            //
            //
            //
            // 自
            //
            //
            //
            Expression_Node_String ec_Cur = new Expression_Node_StringImpl(parent_Ec, cur_Cf);


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
                    ec_Cur,
                    false,//name属性は無い。
                    true,//ｖａｌｕｅ属性を、子＜ｆ－ｓｔｒ＞にする場合、真。
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
                this.ParseChild_InConfigurationtreeToExpression(
                    cur_Cf,
                    ec_Cur,
                    memoryApplication,
                    pg_ParsingLog,
                    log_Reports
                    );
            }


            //
            //
            //
            // 親へ連結　※子連結が基本
            //
            //
            //
            {
                parent_Ec.List_Expression_Child.Add(ec_Cur, log_Reports);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullFAelem:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(cur_Cf), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:7016;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
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



    }
}
