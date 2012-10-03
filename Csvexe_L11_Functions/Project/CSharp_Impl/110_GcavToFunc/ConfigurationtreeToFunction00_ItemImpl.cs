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


    public class ConfigurationtreeToFunction00_ItemImpl : ConfigurationtreeToFunction_Item
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public ConfigurationtreeToFunction00_ItemImpl()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public virtual void Translate_Step1(
            ConfigurationtreeToFunction_Item parentProcesser,
            Configurationtree_Node action_Gcav,
            Expression_Node_Function cur_Expr_Func,
            MemoryApplication owner_MemoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Translate_Step1",log_Reports);

            //
            // アクション型引数の引数
            //
            string err_sName_Attr;
            action_Gcav.List_Child.ForEach(delegate(Configurationtree_Node s_Arg, ref bool bBreak)
            {
                string sName_Attr;
                s_Arg.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Attr, true, log_Reports);

                if (cur_Expr_Func.List_NameArgument.Contains(sName_Attr))
                {
                    //
                    // 自解析
                    //
                    ConfigurationtreeToExpression_F14n16 to = new ConfigurationtreeToExpression_F14_FArgImpl();
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
                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, err_sName_Attr, log_Reports);//引数名

                    StringBuilder s1 = new StringBuilder();
                    foreach (string sLine in cur_Expr_Func.List_NameArgument)
                    {
                        s1.Append(sLine);
                        s1.Append(System.Environment.NewLine);
                    }
                    tmpl.SetParameter(2, s1.ToString(), log_Reports);//引数名リスト

                    owner_MemoryApplication.CreateErrorReport("Er:110001;", tmpl, log_Reports);
                }
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
            ConfigurationtreeToFunction_Item parentProcesser,
            Configurationtree_Node action_Gcav,
            Expression_Node_Function parent_Ec_Sf,//todo:何これ？
            MemoryApplication owner_MemoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
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
            Configurationtree_Node action_Gcav,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Translate",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment(action_Gcav.Name);
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
                pg_ParsingLog.Decrement(action_Gcav.Name);
            }

            log_Method.EndMethod(log_Reports);

            return expr_Func;
        }

        //────────────────────────────────────────
        #endregion



    }
}
