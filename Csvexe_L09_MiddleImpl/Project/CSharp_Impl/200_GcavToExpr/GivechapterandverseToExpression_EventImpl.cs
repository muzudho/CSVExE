using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.MiddleImpl
{
    public class ConfigurationtreeToExpression_EventImpl : ConfigurationtreeToExpression_Event
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public ConfigurationtreeToExpression_EventImpl()
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
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "CfToEc",log_Reports);
            //
            //

            this.Configurationtree_Event.List_Child.ForEach(delegate(Configurationtree_Node systemFunction_Gcav, ref bool bBreak)
            {
                Expression_Node_Function expr_Func;
                if (log_Reports.Successful)
                {
                    expr_Func = moApplication.MemoryForms.ConfigurationtreeToFunction.Translate(
                        systemFunction_Gcav,
                        true,
                        log_Reports
                        );
                }
                else
                {
                    expr_Func = null;
                }

                if (log_Reports.Successful)
                {
                    this.Owner_Functionlist.List_Item.Add(expr_Func);
                }
            });

            if (log_Reports.Successful)
            {
                this.IsTranslated_ConfigurationtreeToExpression = true;
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
        private Configurationtree_Node givechapterandverse_Event;

        /// <summary>
        /// このアクションの一覧が記述されている、対応するイベント。
        /// </summary>
        public Configurationtree_Node Configurationtree_Event
        {
            get
            {
                return givechapterandverse_Event;
            }
            set
            {
                this.IsTranslated_ConfigurationtreeToExpression = false;

                givechapterandverse_Event = value;
            }
        }

        //────────────────────────────────────────

        private bool isTranslated_ConfigurationtreeToExpression;

        public bool IsTranslated_ConfigurationtreeToExpression
        {
            get
            {
                return isTranslated_ConfigurationtreeToExpression;
            }
            set
            {
                isTranslated_ConfigurationtreeToExpression = value;
            }
        }

        //────────────────────────────────────────

        public string Name
        {
            get
            {
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports d_Logging_Dammy = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Name", d_Logging_Dammy);
                //
                //

                string sResult;
                this.Configurationtree_Event.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sResult, false, d_Logging_Dammy);

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
                log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Name", d_Logging_Dammy);
                //
                //

                this.Configurationtree_Event.Dictionary_Attribute.Add(PmNames.S_NAME.Name_Pm, value, this.Configurationtree_Event, true, d_Logging_Dammy);

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
