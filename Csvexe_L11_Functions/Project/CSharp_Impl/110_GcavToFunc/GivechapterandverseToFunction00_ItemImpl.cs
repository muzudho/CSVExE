using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;
using Xenon.GcavToExpr;

namespace Xenon.Functions
{


    public class GivechapterandverseToFunction00_ItemImpl : GivechapterandverseToFunction_Item
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public GivechapterandverseToFunction00_ItemImpl()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public virtual void Translate_Step1(
            GivechapterandverseToFunction_Item parentProcesser,
            Givechapterandverse_Node action_Gcav,
            Expression_Node_Function cur_Expr_Func,
            MemoryApplication owner_MemoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Translate_Step1",log_Reports);

            //
            // アクション型引数の引数
            //
            string err_sName_Attr;
            action_Gcav.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node s_Arg, ref bool bBreak)
            {
                string sName_Attr;
                s_Arg.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Attr, true, log_Reports);

                if (cur_Expr_Func.ListS_ArgName.Contains(sName_Attr))
                {
                    //
                    // 自解析
                    //
                    GivechapterandverseToExpression_F14n16 to = new GivechapterandverseToExpression_F14_FArgImpl();
                    to.Translate(
                        s_Arg,
                        cur_Expr_Func,
                        owner_MemoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }
                else
                {
                    // エラー
                    err_sName_Attr = sName_Attr;
                    goto gt_Error_UndefinedArgName;
                }

                goto gt_EndMethod2;
            //
            //
            gt_Error_UndefinedArgName:
                bBreak = true;
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー702！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();
                    s.Append("未対応の引数名です。[");
                    s.Append(err_sName_Attr);
                    s.Append("]");
                    s.NewLine();

                    s.Append("┌────────┐対応している引数名の一覧。");
                    s.NewLine();
                    foreach (string sLine in cur_Expr_Func.ListS_ArgName)
                    {
                        s.Append(sLine);
                        s.NewLine();
                    }
                    s.Append("└────────┘");
                    s.NewLine();

                    r.SMessage = s.ToString();
                    log_Reports.EndCreateReport();
                }
            //
            //
            gt_EndMethod2:
                ;
            });

            goto gt_EndMethod;

        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public virtual void Translate_Step2(
            GivechapterandverseToFunction_Item parentProcesser,
            Givechapterandverse_Node action_Gcav,
            Expression_Node_Function parent_Ec_Sf,//todo:何これ？
            MemoryApplication owner_MemoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// 2010年11月22日追加。
        /// </summary>
        /// <returns></returns>
        public virtual Expression_Node_Function Translate(
            string sName_Action,
            Givechapterandverse_Node action_Gcav,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Translate",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment(action_Gcav.SName);
            }

            //

            //
            //
            //
            // 自
            //
            //
            //
            Expression_Node_Function expr_Func;
            {
                Expression_Node_String parent_Expression_Null = null;

                expr_Func = Collection_Function.NewFunction2(
                    sName_Action,
                    parent_Expression_Null,
                    action_Gcav,
                    owner_MemoryApplication,
                    log_Reports
                    );
            }

            this.Translate_Step1(
                this,
                action_Gcav,
                expr_Func,
                owner_MemoryApplication,
                pg_ParsingLog,
                log_Reports
                );

            this.Translate_Step2(
                this,
                action_Gcav,
                expr_Func,
                owner_MemoryApplication,
                pg_ParsingLog,
                log_Reports
                );


            //
            //
            //
            //

            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(action_Gcav.SName);
            }

            log_Method.EndMethod(log_Reports);

            return expr_Func;
        }

        //────────────────────────────────────────
        #endregion



    }
}
