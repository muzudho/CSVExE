﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol

namespace Xenon.Functions
{
    public class Expression_Node_Function33Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:リスト項目選択;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// コントロール（リストボックス）の名前。
        /// </summary>
        public static readonly string S_PM_NAME_FC = PmNames.S_NAME_CONTROL.SName_Pm;

        /// <summary>
        /// キーフィールド名。
        /// </summary>
        public static readonly string S_PM_NAME_FIELD_KEY = PmNames.S_NAME_FIELD_KEY.SName_Pm;// "keyFieldName";

        /// <summary>
        /// 比較する値１。
        /// </summary>
        public static readonly string S_PM_VALUE_EXPECTED = PmNames.S_VALUE_EXPECTED.SName_Pm;

        /// <summary>
        /// 比較する値２。
        /// </summary>
        public static readonly string S_PM_VALUE_EXPECTED2 = PmNames.S_VALUE_EXPECTED2.SName_Pm;

        /// <summary>
        /// 空文字列だった場合の代替文字列。
        /// </summary>
        public static readonly string S_PM_VALUE_EMPTY = PmNames.S_VALUE_EMPTY.SName_Pm;// "emptyToAltValue";
        
        //────────────────────────────────────────
        #endregion


        
        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function33Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function33Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);

            f0.DicExpression_Attr.Set(Expression_Node_Function33Impl.S_PM_NAME_FC, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.DicExpression_Attr.Set(Expression_Node_Function33Impl.S_PM_NAME_FIELD_KEY, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.DicExpression_Attr.Set(Expression_Node_Function33Impl.S_PM_VALUE_EXPECTED, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.DicExpression_Attr.Set(Expression_Node_Function33Impl.S_PM_VALUE_EXPECTED2, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.DicExpression_Attr.Set(Expression_Node_Function33Impl.S_PM_VALUE_EMPTY, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

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
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",log_Reports);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";

                this.Perform2(
                    this.ExpressionfncPrmset.Sender,
                    log_Reports
                    );

                //
                //

                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.ExpressionfncPrmset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(
                    this.ExpressionfncPrmset.Sender,
                    log_Reports
                    );

            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Perform2(
            object sender,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform2",log_Reports);

            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName0 + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (log_Reports.BSuccessful)
            {
                // 正常時

                if (sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint,
                        log_Reports
                        );

                    log_Reports.SComment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    log_Reports.SComment_EventCreationMe += "／追記：[" + sFncName0 + "]アクションを実行。";
                }
            }
            else
            {
            }

            //
            //
            //
            // リストボックス
            //
            //
            //
            UsercontrolListbox uctLst;
            if (log_Reports.BSuccessful)
            {
                Expression_Node_String ec_ArgFcName;
                this.TrySelectAttr(out ec_ArgFcName, Expression_Node_Function33Impl.S_PM_NAME_FC, false, Request_SelectingImpl.Unconstraint, log_Reports);


                List<Usercontrol> list_FcUc = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                    ec_ArgFcName,
                    true,
                    log_Reports
                    );

                if (0 < list_FcUc.Count)
                {
                    Usercontrol uct = list_FcUc[0];

                    if (uct is UsercontrolListbox)
                    {
                        uctLst = (UsercontrolListbox)uct;
                    }
                    else
                    {
                        uctLst = null;
                    }
                }
                else
                {
                    uctLst = null;
                }
            }
            else
            {
                uctLst = null;
            }


            //
            //
            //
            // 項目選択の要求。
            //
            //
            //
            if (log_Reports.BSuccessful)
            {
                Expression_Node_String ec_ArgExpectedValue;
                this.TrySelectAttr(out ec_ArgExpectedValue, Expression_Node_Function33Impl.S_PM_VALUE_EXPECTED, false, Request_SelectingImpl.Unconstraint, log_Reports);

                Expression_Node_String ec_ArgKeyFieldName;
                this.TrySelectAttr(out ec_ArgKeyFieldName, Expression_Node_Function33Impl.S_PM_NAME_FIELD_KEY, false, Request_SelectingImpl.Unconstraint, log_Reports);

                Expression_Node_String ec_ArgEmptyToAltValue;
                this.TrySelectAttr(out ec_ArgEmptyToAltValue, Expression_Node_Function33Impl.S_PM_VALUE_EMPTY, false, Request_SelectingImpl.Unconstraint, log_Reports);

                if ("" == ec_ArgExpectedValue.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports))
                {
                    //
                    // 空文字列が指定されたときの代替値で検索。（初期値は空文字列）。
                    //

                    uctLst.SelectItem(
                        ec_ArgKeyFieldName,
                        ec_ArgEmptyToAltValue,
                        log_Reports
                        );
                }
                else
                {
                    uctLst.SelectItem(
                        ec_ArgKeyFieldName,
                        ec_ArgExpectedValue,
                        log_Reports
                        );
                }


                //
                // 一致項目がなければ、選択は解除されている。
                //
                if (-1 == uctLst.SelectedIndex)
                {
                    // #警告
                    log_Method.WriteWarning_ToConsole("選択されてない。。。");

                    Expression_Node_String ec_ArgExpectedValue2;
                    this.TrySelectAttr(out ec_ArgExpectedValue2, Expression_Node_Function33Impl.S_PM_VALUE_EXPECTED2, false, Request_SelectingImpl.Unconstraint, log_Reports);

                    //
                    // デフォルト値の設定があるかどうか。
                    //
                    if ("" != ec_ArgExpectedValue2.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports))
                    {
                        if ("" == ec_ArgExpectedValue2.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports))
                        {
                            //
                            // 空文字列が指定されたときの代替値で検索。（初期値は空文字列）。
                            //

                            uctLst.SelectItem(
                                ec_ArgKeyFieldName,
                                ec_ArgEmptyToAltValue,
                                log_Reports
                                );
                        }
                        else
                        {
                            uctLst.SelectItem(
                                ec_ArgKeyFieldName,
                                ec_ArgExpectedValue2,
                                log_Reports
                                );
                        }

                    }
                }
            }


            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}