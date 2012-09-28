using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.MiddleImpl
{
    public class GivechapterandverseToExpression_EventImpl : GivechapterandverseToExpression_Event
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public GivechapterandverseToExpression_EventImpl()
        {
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        public void Translate(
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "CfToEc",log_Reports);
            //
            //

            this.Givechapterandverse_Event.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node systemFunction_Gcav, ref bool bBreak)
            {
                Expression_Node_Function expr_Func;
                if (log_Reports.BSuccessful)
                {
                    expr_Func = moApplication.MemoryForms.GivechapterandverseToFunction.Translate(
                        systemFunction_Gcav,
                        true,
                        log_Reports
                        );
                }
                else
                {
                    expr_Func = null;
                }

                if (log_Reports.BSuccessful)
                {
                    this.Owner_Functionlist.List_Item.Add(expr_Func);
                }
            });

            if (log_Reports.BSuccessful)
            {
                this.BTranslatedGivechapterandverseToExpression = true;
            }

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Functionlist owner_Functionlist;

        public Functionlist Owner_Functionlist
        {
            get
            {
                return owner_Functionlist;
            }
            set
            {
                owner_Functionlist = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// このアクションの一覧が記述されている、対応するイベント。
        /// </summary>
        private Givechapterandverse_Node givechapterandverse_Event;

        /// <summary>
        /// このアクションの一覧が記述されている、対応するイベント。
        /// </summary>
        public Givechapterandverse_Node Givechapterandverse_Event
        {
            get
            {
                return givechapterandverse_Event;
            }
            set
            {
                this.BTranslatedGivechapterandverseToExpression = false;

                givechapterandverse_Event = value;
            }
        }

        //────────────────────────────────────────

        private bool bTranslatedGivechapterandverseToExpression;

        public bool BTranslatedGivechapterandverseToExpression
        {
            get
            {
                return bTranslatedGivechapterandverseToExpression;
            }
            set
            {
                bTranslatedGivechapterandverseToExpression = value;
            }
        }

        //────────────────────────────────────────

        public string SName
        {
            get
            {
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports d_Logging_Dammy = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "SName",d_Logging_Dammy);
                //
                //

                string sResult;
                this.Givechapterandverse_Event.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sResult, false, d_Logging_Dammy);

                //
                //
                log_Method.EndMethod(d_Logging_Dammy);
                d_Logging_Dammy.EndLogging(log_Method);

                return sResult;
            }
            set
            {
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports d_Logging_Dammy = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "SName",d_Logging_Dammy);
                //
                //

                this.Givechapterandverse_Event.Dictionary_SAttribute_Givechapterandverse.Add(PmNames.S_NAME.SName_Pm, value, this.Givechapterandverse_Event, true, d_Logging_Dammy);

                //
                //
                log_Method.EndMethod(d_Logging_Dammy);
                d_Logging_Dammy.EndLogging(log_Method);
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
