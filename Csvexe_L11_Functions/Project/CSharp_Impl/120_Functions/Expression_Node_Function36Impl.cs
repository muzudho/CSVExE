﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol
using Xenon.Table;//DefaultTable

namespace Xenon.Functions
{
    public class Expression_Node_Function36Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:入力値の消去;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// コントロールの名前。
        /// </summary>
        public static readonly string S_PM_FC_NAME = PmNames.S_NAME_CONTROL.Name_Pm;

        //────────────────────────────────────────
        #endregion



        
        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function36Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function36Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.Dictionary_Expression_Attribute.Set(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);

            f0.Dictionary_Expression_Attribute.Set(Expression_Node_Function36Impl.S_PM_FC_NAME, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

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
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint,
                        log_Reports
                        );

                    log_Reports.Comment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + this.GetType().Name + "]を実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe += "／追記：[" + this.GetType().Name + "]を実行。";
                }

                //
                //
                //
                //
                this.ExpressionfncPrmset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                this.Perform2(
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
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint,
                        log_Reports
                        );

                    log_Reports.Comment_EventCreationMe += "／追記：[" + sName_Usercontrol + "]コントロールが、[" + this.GetType().Name + "]を実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe += "／追記：[" + this.GetType().Name + "]を実行。";
                }

                this.Perform2(
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
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform2",log_Reports);

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName0 + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //

            //
            // 指定された引数から、または、
            // この＜action＞要素を含んでいる ｃｏｎｔｒｏｌ要素から、コントロールの名前を取得。
            List<Usercontrol> list_FcUc = new List<Usercontrol>();
            if (log_Reports.Successful)
            {
                // 正常時

                Expression_Node_String ec_FcName_Prm;
                this.TrySelectAttribute(out ec_FcName_Prm, Expression_Node_Function36Impl.S_PM_FC_NAME, false, Request_SelectingImpl.Unconstraint, log_Reports);

                string sFcName_Prm = ec_FcName_Prm.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint,log_Reports);


                List<Expression_Node_String> ecList_FcName = new List<Expression_Node_String>();
                if ("" == sFcName_Prm)
                {
                    //
                    // fcName未設定時は、この＜action＞要素を含んでいるｃｏｎｔｒｏｌ要素から
                    // コントロールの名前を取得。
                    //

                    Givechapterandverse_Node cf_Event = this.Cur_Givechapterandverse.GetParentByNodename(NamesNode.S_EVENT, false, log_Reports);

                    if (null != cf_Event)
                    {
                        Givechapterandverse_Node owner_Givechapterandverse_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, log_Reports);

                        if (null != owner_Givechapterandverse_Control)
                        {
                            string sName;
                            bool bHit = owner_Givechapterandverse_Control.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName, false, log_Reports);

                            if (bHit)
                            {
                                Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(this, this.Cur_Givechapterandverse);
                                ec_Str.AppendTextNode(
                                    sName,
                                    this.Cur_Givechapterandverse,
                                    log_Reports
                                    );

                                // 上書き
                                ec_FcName_Prm = ec_Str;
                                ecList_FcName.Add(ec_FcName_Prm);
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            //nFcName_prm = null;
                        }

                    }
                    else
                    {
                        //nFcName_prm = null;
                    }
                }
                else
                {
                    //
                    // fcName 指定時。

                    // カンマ区切りか確認。
                    CsvTo_ListImpl csvTo = new CsvTo_ListImpl();
                    List<string> sList_FcName_Prm = csvTo.Read(sFcName_Prm);

                    foreach (string sFcName2 in sList_FcName_Prm)
                    {
                        // コントロール名。
                        Expression_Node_StringImpl ec_FcName4 = new Expression_Node_StringImpl(this, this.Cur_Givechapterandverse);
                        ec_FcName4.AppendTextNode(
                            sFcName2,
                            this.Cur_Givechapterandverse,
                            log_Reports
                            );

                        ecList_FcName.Add(ec_FcName4);
                    }

                }

                foreach (Expression_Node_String ec_FcName5 in ecList_FcName)
                {
                    //
                    // 指定のコントロール
                    //
                    List<Usercontrol> list_FcUc2 = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                        ec_FcName5,
                        true,
                        log_Reports
                        );

                    if (0 < list_FcUc2.Count)
                    {
                        Usercontrol fcUc = list_FcUc2[0];
                        list_FcUc.Add(fcUc);
                    }
                }
            }
            else
            {
            }



            foreach (Usercontrol fcUc in list_FcUc)
            {
                if (log_Reports.Successful)
                {
                    ////
                    //// 妥当性判定を行います。
                    ////
                    //if (log_Reports.Successful)
                    //{
                    //    fcUc.JudgeValidity(
                    //        log_Reports
                    //        );

                    //    //.WriteLine(this.GetType().Name + "#Perform_WrRhn: ◆　妥当性判定を行った。");
                    //}


                    if (fcUc.ControlCommon.BAutomaticinputting)
                    {
                        // コンピューターにより自動入力されたとき。
                    }
                    else
                    {
                        // 手入力による更新。

                        {
                            ToMemory_Performer toM = new ExpressionDataTargetUpdaterImpl();
                            toM.ToMemory(
                                "",// 空文字列
                                fcUc.ControlCommon.Expression_Control,
                                fcUc.ControlCommon.Owner_MemoryApplication,
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
