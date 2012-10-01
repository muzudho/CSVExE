using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Middle;
using Xenon.Syntax;

namespace Xenon.Expr
{

    /// <summary>
    /// ”Ｓｆ：Ｖａｌｕｅ－Ｃｏｎｔｒｏｌ”
    /// コントロールを指定する。そのコントロールの値を返す。
    /// </summary>
    public class Expression_ValuecontrolImpl : Expression_NodeImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="moOpyopyo"></param>
        /// <param name="s_ParentNode"></param>
        public Expression_ValuecontrolImpl(
            Expression_Node_String ec_FcName,
            MemoryApplication owner_MemoryApplication,
            Expression_Node_String parent_Expression_Node,
            Givechapterandverse_Node parent_Givechapterandverse_Node
            )
            : base(parent_Expression_Node, parent_Givechapterandverse_Node, owner_MemoryApplication)
        {
            this.expression_UsercontrolName = ec_FcName;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override string Expression_ExecuteMain(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //
            string sResult;

            //
            List<Usercontrol> ucList_Fc = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(this.Expression_UsercontrolName, true, log_Reports);
            if (log_Reports.Successful)
            {
                if (1 != ucList_Fc.Count)
                {
                    // TODO:エラー
                    sResult = "";
                    goto gt_Error_No1Hit;
                }

                Usercontrol ucFc = ucList_Fc[0];
                sResult = ucFc.UsercontrolText;
            }
            else
            {
                // エラー
                sResult = "";
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_No1Hit:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー542！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定の名前のコントロールはありませんでした。");
                s.Append(Environment.NewLine);
                s.Append("[");
                s.Append(this.Expression_UsercontrolName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                s.Append("]");
                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sResult;
        }

        //────────────────────────────────────────

        public override string ToString()
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "ToString",log_Reports_ThisMethod);

            log_Reports_ThisMethod.BeginCreateReport(EnumReport.Dammy);

            StringBuilder sb = new StringBuilder();

            sb.Append(this.GetType().Name);
            sb.Append(" ");
            sb.Append(this.Cur_Givechapterandverse.Parent_Givechapterandverse);
            sb.Append(" [");
            sb.Append(this.Dictionary_Expression_Attribute.ToString());
            sb.Append("] 変数名");
            sb.Append(this.Expression_UsercontrolName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ThisMethod));
            sb.Append("");

            log_Reports_ThisMethod.EndCreateReport();

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports_ThisMethod);
            return sb.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Expression_Node_String expression_UsercontrolName;

        /// <summary>
        /// コントロール名。
        /// </summary>
        public Expression_Node_String Expression_UsercontrolName
        {
            set
            {
                expression_UsercontrolName = value;
            }
            get
            {
                return expression_UsercontrolName;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
