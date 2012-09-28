using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,OAction
using Xenon.GcavToExpr;
using Xenon.Expr;

namespace Xenon.Functions
{


    /// <summary>
    /// アプリケーション・モデルに渡す。
    /// 
    /// コントローラーの中で使っている。
    /// </summary>
    public class GivechapterandverseToFunction_ListImpl : GivechapterandverseToFunction
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="form"></param>
        public GivechapterandverseToFunction_ListImpl(
            Expression_Node_String parent_Expression,
            Givechapterandverse_Node cur_Gcav,
            MemoryApplication owner_MemoryApplication,
            Log_Reports pg_Logging
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
        /// <param name="pg_Logging"></param>
        /// <returns></returns>
        public Expression_Node_Function Translate(
            Givechapterandverse_Node action_Gcav,
            bool bRequired,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Translate",pg_Logging);
            //
            //

            string sName_Fnc;
            if (action_Gcav.Dictionary_SAttribute_Givechapterandverse.ContainsKey(PmNames.S_NAME.SName_Pm))
            {
                action_Gcav.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Fnc, true, pg_Logging);
            }
            else
            {
                sName_Fnc = "＜エラー:" + pg_Method.SHead + "＞";
            }


            Expression_Node_Function expr_Func = Collection_Function.NewFunction2( sName_Fnc,
                null, action_Gcav, this.Owner_MemoryApplication, pg_Logging);



            if (pg_Logging.BSuccessful)
            {
                if (null != expr_Func)
                {
                    Log_TextIndented_GivechapterandverseToExpressionImpl pg_ParsingLog = new Log_TextIndented_GivechapterandverseToExpressionImpl();
                    pg_ParsingLog.BEnabled = false;
                    expr_Func = ((Expression_Node_FunctionAbstract)expr_Func).Functiontranslatoritem.Translate(
                        sName_Fnc,
                        action_Gcav,//これは生成時に指定できない？
                        pg_ParsingLog,
                        this.Owner_MemoryApplication,
                        pg_Logging
                        );
                    if (Log_ReportsImpl.BDebugmode_Static && pg_ParsingLog.BEnabled)
                    {
                        pg_Method.WriteInfo_ToConsole(" pg_ParsingLog=" + Environment.NewLine + pg_ParsingLog.ToString());
                    }
                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
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
