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
            Givechapterandverse_Node parent_Givechapterandverse_Node,
            MemoryApplication owner_MemoryApplication
            )
            : base(parent_Expression_Node, parent_Givechapterandverse_Node, owner_MemoryApplication)
        {
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
            log_Method.BeginMethod(Info_Expr.SName_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //
            string sResult;


            // call属性（必須）
            string sCall;
            {
                if (this.DicExpression_Attr.TrySelect(out sCall, PmNames.S_CALL.SName_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports))
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
                sResult = "＜Xn_L05_E:E_FParamImpl#Expression_ExecuteMain ｆ－ｐａｒａｍ開発中 call=\"" + sCall + "\" 親e_CommonFunctionなし＞";
            }
            else
            {
                // 親「E■ｆｕｎｃｔｉｏｎ」取得。
                string sParam;
                if (ec_CommonFunction.DicExpression_Param.TrySelect(out sParam, sCall, true, Request_SelectingImpl.Unconstraint, log_Reports))
                {
                    //sResult = "＜Xn_L05_E:E_FParamImpl#Expression_ExecuteMain ｆ－ｐａｒａｍ開発中 call=\"" + sCall + "\"　値＝”" + e_Param.E_Execute(Request_SelectingImpl.Unconstraint,log_Reports) + "”＞";
                    sResult = sParam;
                }
                else
                {
                    // エラー。
                    Log_TextIndented s1 = new Log_TextIndentedImpl();
                    ec_CommonFunction.DicExpression_Param.ToText_Debug(s1, log_Reports);

                    sResult = "＜Xn_L05_E:E_FParamImpl#Expression_ExecuteMain ｆ－ｐａｒａｍ開発中 call=\"" + sCall + "\" e_Functionノード名＝”" + ec_CommonFunction.Cur_Givechapterandverse.SName + "” 引数不該当＞s1=" + s1.ToString();
                }

            }



            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_CallAttr:
            sResult = "エラー。";
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー301！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("・もしかして？　＜ｆ－ｐａｒａｍ＞要素にｃａｌｌ属性が無かった？");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                //this.E_AttrDictionary.D

                // ヒント

                r.SMessage = s.ToString();
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
        #endregion



    }
}
