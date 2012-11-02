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
    /// ＜ｆ－ｐａｒａｍ＞要素。
    /// </summary>
    public class Expression_FparamImpl : Expression_NodeImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="e_ParentNode"></param>
        /// <param name="s_ParentNode"></param>
        /// <param name="moOpyopyo"></param>
        public Expression_FparamImpl(
            Expression_Node_String parent_Expression_Node,
            Configurationtree_Node parent_Configurationtree_Node,
            MemoryApplication owner_MemoryApplication
            )
            : base(parent_Expression_Node, parent_Configurationtree_Node, owner_MemoryApplication)
        {
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


            // call属性（必須）
            string sCall;
            {
                if (this.TrySelectAttribute(out sCall, PmNames.S_CALL.Name_Pm, EnumHitcount.One, log_Reports))
                {
                }
                else
                {
                    sCall = "＜エラーcall属性取得失敗＞";
                    // エラー
                    goto gt_Error_CallAttr;
                }
            }

            Expression_Node_Function ec_CommonFunction = (Expression_Node_Function)this.GetParentExpressionOrNull(NamesNode.S_COMMON_FUNCTION);
            if (null == ec_CommonFunction)
            {
                // エラー
                sResult = "＜Xn_L05_E:E_FParamImpl#Execute5_Main ｆ－ｐａｒａｍ開発中 call=\"" + sCall + "\" 親e_CommonFunctionなし＞";
            }
            else
            {
                // 親「E■ｆｕｎｃｔｉｏｎ」取得。
                string sParam;
                if (ec_CommonFunction.Dictionary_Expression_Parameter.TrySelect(out sParam, sCall, EnumHitcount.One, log_Reports))
                {
                    //sResult = "＜Xn_L05_E:E_FParamImpl#Execute5_Main ｆ－ｐａｒａｍ開発中 call=\"" + sCall + "\"　値＝”" + e_Param.E_Execute(EnumHitcount.Unconstraint,log_Reports) + "”＞";
                    sResult = sParam;
                }
                else
                {
                    // エラー。
                    Log_TextIndented s1 = new Log_TextIndentedImpl();
                    ec_CommonFunction.Dictionary_Expression_Parameter.ToText_Debug(s1, log_Reports);

                    sResult = "＜Xn_L05_E:E_FParamImpl#Execute5_Main ｆ－ｐａｒａｍ開発中 call=\"" + sCall + "\" e_Functionノード名＝”" + ec_CommonFunction.Cur_Configuration.Name + "” 引数不該当＞s1=" + s1.ToString();
                }

            }



            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_CallAttr:
            sResult = "エラー。";
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                this.Owner_MemoryApplication.CreateErrorReport("Er:6040;", tmpl, log_Reports);
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
        #endregion



    }
}
