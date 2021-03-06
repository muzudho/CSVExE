﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol

namespace Xenon.Functions
{
    public class Expression_Node_Function39Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:活性化;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// コントロール名。
        /// </summary>
        public static readonly string PM_NAME_CONTROL = PmNames.S_NAME_CONTROL.Name_Pm;

        /// <summary>
        /// 活性。コントロールの使用可能／不可能を切り替えます。true または false を指定してください。
        /// </summary>
        public static readonly string PM_VALUE_ENABLED = PmNames.S_VALUE_ENABLED.Name_Pm;

        //────────────────────────────────────────
        #endregion


        
        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function39Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configuration_Node cur_Conf,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function39Impl(this.EnumEventhandler,this.List_NameArgumentInitializer,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configuration = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function39Impl.PM_NAME_CONTROL, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function39Impl.PM_VALUE_ENABLED, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {
                this.Execute6_Sub(
                    log_Reports
                    );
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Execute6_Sub(
                    log_Reports
                    );

            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Execute6_Sub(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute6_Sub", log_Reports);

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName0 + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }


            {
                Expression_Node_String ec_ArgFcName;
                this.TrySelectAttribute(out ec_ArgFcName, Expression_Node_Function39Impl.PM_NAME_CONTROL, EnumHitcount.One_Or_Zero, log_Reports);

                List<Usercontrol> list_FcUc = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                    ec_ArgFcName, true, log_Reports);

                if (log_Reports.Successful)
                {
                    Usercontrol fcUc = list_FcUc[0];

                    string sValue;
                    this.TrySelectAttribute(out sValue, Expression_Node_Function39Impl.PM_VALUE_ENABLED, EnumHitcount.One_Or_Zero, log_Reports);

                    bool bValue;
                    if (Boolean.TryParse(sValue, out bValue))
                    {
                        fcUc.ControlCommon.BAutomaticinputting = true;//自動入力開始。
                        fcUc.UsercontrolEnabled = bValue;
                        fcUc.ControlCommon.BAutomaticinputting = false;//自動入力終了。

                        // なぜか、Enabledを変更しても、背景色が　更新されない。
                        // 値は変更されてないからか。
                        // 背景色を更新するために、JudgeValidity を呼んでやる。
                        //
                        // トゥゲザーでやるべきか？
                        //fcUc.JudgeValidity(log_Reports);

                    }
                }
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
