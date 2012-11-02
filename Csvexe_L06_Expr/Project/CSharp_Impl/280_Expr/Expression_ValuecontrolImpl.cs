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
            Configurationtree_Node parent_Configurationtree_Node
            )
            : base(parent_Expression_Node, parent_Configurationtree_Node, owner_MemoryApplication)
        {
            this.expression_UsercontrolName = ec_FcName;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override string Execute5_Main(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute5_Main", log_Reports);
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.Expression_UsercontrolName.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//コントロールの値

                this.Owner_MemoryApplication.CreateErrorReport("Er:6041;", tmpl, log_Reports);
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
            sb.Append(this.Cur_Configuration.Parent);
            sb.Append(" [");
            sb.Append(this.Dictionary_Expression_Attribute.ToString());//？
            sb.Append("] 変数名");
            sb.Append(this.Expression_UsercontrolName.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod));
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
