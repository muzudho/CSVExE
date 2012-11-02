using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,OAction
using Xenon.ConfToExpr;
using Xenon.Expr;

namespace Xenon.Functions
{


    /// <summary>
    /// アプリケーション・モデルに渡す。
    /// 
    /// コントローラーの中で使っている。
    /// </summary>
    public class ConfigurationtreeToFunction_ListImpl : ConfigurationtreeToFunction
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="form"></param>
        public ConfigurationtreeToFunction_ListImpl(
            Expression_Node_String parent_Expression,
            Configuration_Node cur_Conf,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// Exe_2ActionImpl#SToFc で使用。
        /// </summary>
        /// <param name="s_Action"></param>
        /// <param name="bRequired"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public Expression_Node_Function Translate(
            Configurationtree_Node action_Conf,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Translate",log_Reports);
            //
            //

            string sName_Fnc;
            if (action_Conf.Dictionary_Attribute.ContainsKey(PmNames.S_NAME.Name_Pm))
            {
                action_Conf.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Fnc, true, log_Reports);
            }
            else
            {
                sName_Fnc = "＜エラー:" + log_Method.Fullname + "＞";
            }


            Expression_Node_Function expr_Func = Collection_Function.NewFunction2( sName_Fnc,
                null, action_Conf, this.Owner_MemoryApplication, log_Reports);



            if (log_Reports.Successful)
            {
                if (null != expr_Func)
                {
                    Log_TextIndented_ConfigurationtreeToExpressionImpl pg_ParsingLog = new Log_TextIndented_ConfigurationtreeToExpressionImpl();
                    pg_ParsingLog.BEnabled = false;
                    expr_Func = ((Expression_Node_FunctionAbstract)expr_Func).Functiontranslatoritem.Translate(
                        sName_Fnc,
                        action_Conf,//これは生成時に指定できない？
                        pg_ParsingLog,
                        this.Owner_MemoryApplication,
                        log_Reports
                        );
                    if (Log_ReportsImpl.BDebugmode_Static && pg_ParsingLog.BEnabled)
                    {
                        log_Method.WriteInfo_ToConsole(" pg_ParsingLog=" + Environment.NewLine + pg_ParsingLog.ToString());
                    }
                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return expr_Func;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// アプリケーション・モデル。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return owner_MemoryApplication;
            }
            set
            {
                owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
