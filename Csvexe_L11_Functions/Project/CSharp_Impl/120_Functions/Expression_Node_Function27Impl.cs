﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol
using Xenon.Table;


namespace Xenon.Functions
{
    public class Expression_Node_Function27Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:整合性を取る;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// トゥゲザー名。
        /// </summary>
        public static string S_PM_NAME_TOGETHER = PmNames.S_NAME_TOGETHER.SName_Pm;

        //────────────────────────────────────────
        #endregion


                
        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function27Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function27Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function27Impl.S_PM_NAME_TOGETHER, new Expression_Leaf_StringImpl("", null, cur_Gcav), pg_Logging);

            //
            pg_Method.EndMethod(pg_Logging);
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
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol ccFc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                    pg_Logging.SComment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールが、NAction27を実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe = "NAction27を実行。";
                }


                this.Perform2(pg_Logging);

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
                    Customcontrol ccFc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                    pg_Logging.SComment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールが、NAction27を実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe = "NAction27を実行。";
                }

                if (pg_Logging.BSuccessful)
                {
                    this.Perform2(
                        pg_Logging
                        );
                }
            }

            //
            //
            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// 指定の仕方で、トゥゲザーを読み取りに行く場所が変わる。
        /// 
        /// （１）トゥゲザー名で指定した場合
        /// 「トゥゲザー設定ファイル（Frfr）」の１箇所。
        /// 
        /// （２）トゥゲザー名で指定しなかった場合
        /// 「トゥゲザー設定ファイル（Frfr）」と、「コントロール設定ファイル（Fcnf）」の２箇所。
        /// </summary>
        /// <param name="pg_Logging"></param>
        protected void Perform2(
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform",pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = Utility_Textformat.Format_StopwatchComment(
                    this,
                    this.Cur_Givechapterandverse,
                    pg_Logging
                    );

                pg_Method.Log_Stopwatch.Begin();
            }


            Givechapterandverse_Node cf_TgTogether;
            if (pg_Logging.BSuccessful)
            {
                string sArg_Name_Together;
                this.TrySelectAttr(out sArg_Name_Together, Expression_Node_Function27Impl.S_PM_NAME_TOGETHER, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                if ("" != sArg_Name_Together.Trim())
                {
                    //
                    //
                    //
                    // トゥゲザー名を指定した場合
                    //
                    //
                    //
                    this.Perform_ByName(
                        out cf_TgTogether,
                        pg_Logging);
                }
                else
                {
                    //
                    //
                    //
                    // トゥゲザー名を指定していない場合
                    //
                    //
                    //
                    this.Perform_ByNoName(
                        out cf_TgTogether,
                        pg_Logging);
                }
            }
            else
            {
                cf_TgTogether = null;
            }


            //.WriteLine(this.GetType().Name + "#Perform_WrRhn: ◆　指定のコントロールを、リフレッシュした。");

            // ＜ｒｅｆｒｅｓｈｅｒ＞が無い場合もある。その場合は無視する。
            if (null == cf_TgTogether)
            {
                goto gt_EndMethod;
            }

            //
            //
            //
            // 妥当性判定を行います。
            //
            //
            //
            if (pg_Logging.BSuccessful)
            {

                //
                //
                // 21:妥当性判定
                // 所要時間目安[0]ミリ秒ほど
                //
                //

                //
                // 妥当性を判定したいコントロール名を一覧しているトゥゲザーの名前。
                //
                List<Givechapterandverse_Node> cfList_RfrTarget = cf_TgTogether.GetChildrenByNodename(NamesNode.S_TARGET,false,pg_Logging);


                //.WriteLine(this.GetType().Name + "#Perform_WrRhn: ◆　トゥゲザー名=[" + .Value + "] 対象Fc数=[" + oTargetList.Count + "]");

                foreach (Givechapterandverse_Node cf_RfrTarget in cfList_RfrTarget)
                {
                    string sName;
                    cf_RfrTarget.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName, true, pg_Logging);

                    Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(this, cf_RfrTarget);
                    ec_Str.AppendTextNode(
                        sName,
                        cf_RfrTarget,
                        pg_Logging
                        );


                    List<Usercontrol> list_FcUc2;
                    if (pg_Logging.BSuccessful)
                    {
                        list_FcUc2 = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                            ec_Str,
                            true,
                            pg_Logging
                            );
                    }
                    else
                    {
                        list_FcUc2 = new List<Usercontrol>();
                    }

                    if (pg_Logging.BSuccessful)
                    {
                        Usercontrol fcUc2 = list_FcUc2[0];

                        // 妥当性判定を行います。
                        fcUc2.JudgeValidity(
                            pg_Logging
                            );
                    }
                }


                //
                //
                //
                //
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// トゥゲザー名で指定した場合。
        /// </summary>
        /// <param name="pg_Logging"></param>
        private void Perform_ByName(
            out Givechapterandverse_Node cf_TgTogether,
            Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform_ByName",pg_Logging);

            // 指定のコントロールの内容を、データ・ソースから読取り直して最新表示します。

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = Utility_Textformat.Format_StopwatchComment(
                    this,
                    this.Cur_Givechapterandverse,
                    pg_Logging
                );

                pg_Method.Log_Stopwatch.Begin();
            }


            //
            //
            //
            // （０）トゥゲザーの取得
            //
            //
            //　トゥゲザーのname属性から取得。
            cf_TgTogether = null;
            {
                Expression_Node_String ec_Arg_Name_Together;
                this.TrySelectAttr(out ec_Arg_Name_Together, Expression_Node_Function27Impl.S_PM_NAME_TOGETHER, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                string sExpectedFncName = ec_Arg_Name_Together.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                List<Givechapterandverse_Node> listCf_Together = this.Owner_MemoryApplication.MemoryTogethers.Givechapterandverse_Togetherconfig.GetChildrenByNodename(NamesNode.S_TOGETHER, false, pg_Logging);
                foreach (Givechapterandverse_Node cf_Together in listCf_Together)
                {
                    string sFncName;
                    cf_Together.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sFncName, false, pg_Logging);

                    if(sExpectedFncName == sFncName)
                    {
                        cf_TgTogether = cf_Together;
                        break;
                    }
                }
            }


            if (pg_Logging.BSuccessful)
            {
                this.Owner_MemoryApplication.MemoryTogethers.RefreshDataByTogether(
                    cf_TgTogether,
                    this.Owner_MemoryApplication,
                    pg_Logging
                    );
            }

            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// トゥゲザー名で指定しなかった場合。
        /// 
        /// （１）「コントロール設定ファイル（Fcnf）」の＜ｒｅｆｒｅｓｈｅｒ＞を読みにいく。
        /// （２）なければ「トゥゲザー設定ファイル（Frfr）」の＜ｒｅｆｒｅｓｈｅｒ＞を読みにいく。
        /// </summary>
        /// <param name="pg_Logging"></param>
        private void Perform_ByNoName(
            out Givechapterandverse_Node cf_TgTogether,
            Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform_ByNoName",pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = Utility_Textformat.Format_StopwatchComment(
                    this,
                    this.Cur_Givechapterandverse,
                    pg_Logging
                );

                pg_Method.Log_Stopwatch.Begin();
            }
            //
            //

            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (null != this.Cur_Givechapterandverse)
            {
                Givechapterandverse_Node cf_Event = this.Cur_Givechapterandverse.GetParentByNodename(NamesNode.S_EVENT, false, pg_Logging);

                if (null != cf_Event)
                {
                    Givechapterandverse_Node owner_Givechapterandverse_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, pg_Logging);
                    if (null != owner_Givechapterandverse_Control)
                    {
                        //
                        //　（１）「コントロール設定ファイル（Fcnf）」の＜ｒｅｆｒｅｓｈｅｒ＞を読みにいく。
                        //
                        this.Perform_ByNoName_1Fcnf(
                            out cf_TgTogether,
                            owner_Givechapterandverse_Control,
                            cf_Event,
                            pg_Logging);

                        if (null == cf_TgTogether)
                        {

                            //
                            //　（２）「トゥゲザー設定ファイル（Frfr）」の＜ｒｅｆｒｅｓｈｅｒ＞を読みにいく。
                            //
                            this.Perform_ByNoName_2Frfr(
                                out cf_TgTogether,
                                owner_Givechapterandverse_Control,
                                cf_Event,
                                pg_Logging
                                );
                        }

                        //
                        //
                        // 13:トゥゲザーの実行
                        // 所要時間目安[1]～[4343]ミリ秒ほど
                        //
                        //

                        // 指定のコントロールの内容を、データ・ソースから読取り直して最新表示します。

                        if (pg_Logging.BSuccessful)
                        {
                            //
                            // トゥゲザー＜ｔｏｇｅｔｈｅｒ＞を使います。
                            //

                            this.Owner_MemoryApplication.MemoryTogethers.RefreshDataByTogether(
                                cf_TgTogether,
                                this.Owner_MemoryApplication,
                                pg_Logging
                                );
                        }

                    }
                    else
                    {
                        cf_TgTogether = null;
                        goto gt_Error_NullParentControl;
                    }
                }
                else
                {
                    cf_TgTogether = null;
                    goto gt_Error_NullParentEvent;
                }
            }
            else
            {
                cf_TgTogether = null;
                goto gt_Error_NullTogetherName;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullParentControl:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー110501！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("[");
                s.Append(sFncName0);
                s.Append("]アクションを実行しようとしましたが、");
                s.NewLine();

                s.Append("トゥゲザー名が指定されていなかったので、自動判定をしようとしたとき、");
                s.NewLine();

                s.Append("このアクションの親コントロールは　指定されていませんでした。");
                s.NewLine();

                s.Append("プログラムのミスかもしれません。");
                s.NewLine();

                // ヒント
                s.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.SMessage = s.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullParentEvent:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1101！", pg_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("[");
                t.Append(sFncName0);
                t.Append("]アクションを実行しようとしましたが、");
                t.NewLine();

                t.Append("トゥゲザー名が指定されていなかったので、自動判定をしようとしたとき、");
                t.NewLine();

                t.Append("このアクションの親イベントは　指定されていませんでした。");
                t.NewLine();

                t.Append("プログラムのミスかもしれません。");
                t.NewLine();

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.SMessage = t.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullTogetherName:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1102！", pg_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("[");
                t.Append(sFncName0);
                t.Append("]アクションを実行しようとしましたが、");
                t.NewLine();

                t.Append("トゥゲザー名が指定されていなかったので、自動判定をしようとしたとき、");
                t.NewLine();

                t.Append("このアクションのアクション設定は　指定されていませんでした。");
                t.NewLine();

                t.Append("プログラムのミスかもしれません。");
                t.NewLine();

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.SMessage = t.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// トゥゲザー名で指定しなかった場合の、
        /// （１）「コントロール設定ファイル（Fcnf）」の＜ｒｅｆｒｅｓｈｅｒ＞を読みにいく。
        /// 
        /// なければヌル。
        /// </summary>
        /// <param name="pg_Logging"></param>
        private void Perform_ByNoName_1Fcnf(
            out Givechapterandverse_Node cf_TgTogether,
            Givechapterandverse_Node cf_Fc,
            Givechapterandverse_Node cf_Event,
            Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform_ByNoName_1Fcnf",pg_Logging);

            //
            //
            // 11:トゥゲザー名の作成
            // 所要時間目安[0]ミリ秒ほど
            //
            //
            string sEventNameTrim;
            string sIn;
            {
                string sFcName3;
                cf_Fc.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sFcName3, true, pg_Logging);
                if (!pg_Logging.BSuccessful)
                {
                    cf_TgTogether = null;
                    goto gt_EndMethod;
                }

                // これはトゥゲザーが書いてあるコントロールの名前なので、
                // 末尾に「*」は無い。

                string sEventName;
                cf_Event.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sEventName, true, pg_Logging);
                if (!pg_Logging.BSuccessful)
                {
                    cf_TgTogether = null;
                    goto gt_EndMethod;
                }

                sEventNameTrim = sEventName.Trim();

                StringBuilder sbIn_ = new StringBuilder();
                sbIn_.Append(sFcName3);
                sbIn_.Append("/");
                sbIn_.Append(sEventNameTrim);
                sIn = sbIn_.ToString();
            }



            cf_TgTogether = null;
            List<Givechapterandverse_Node> listCf_Together = cf_Fc.GetChildrenByNodename(NamesNode.S_TOGETHER, false, pg_Logging);
            foreach (Givechapterandverse_Node cf_Together in listCf_Together)
            {
                string sOn2;
                cf_Together.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_ON, out sOn2, false, pg_Logging);

                if (sEventNameTrim==sOn2)
                {
                    cf_TgTogether = new Givechapterandverse_NodeImpl(
                        NamesNode.S_TOGETHER,
                        this.Owner_MemoryApplication.MemoryTogethers.Givechapterandverse_Togetherconfig
                        );

                    cf_TgTogether.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_IN.SName_Pm, sIn, pg_Logging);


                    //
                    //　＜ｒｅｆｒｅｓｈｅｒ＞→子＜ｔａｒｇｅｔ＞
                    //


                    // ＜ｒｅｆｒｅｓｈｅｒ＞が、ｔａｒｇｅｔ属性を持っていれば、それを子要素とする。
                    List<Givechapterandverse_Node> cfList = this.ConvertTarget2(cf_Together, pg_Logging);
                    foreach (Givechapterandverse_Node cf_Node in cfList)
                    {
                        cf_TgTogether.List_ChildGivechapterandverse.Add(cf_Node, pg_Logging);
                    }

                    // 1件のみ処理。
                    //break;
                }
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        private List<Givechapterandverse_Node> ConvertTarget2(Givechapterandverse_Node cf_Together, Log_Reports pg_Logging)
        {
            List<Givechapterandverse_Node> cfList_Result = new List<Givechapterandverse_Node>();

            string sTargetList;
            cf_Together.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_TARGET1, out sTargetList, false, pg_Logging);
            List<string> sList_Target = new CsvTo_ListImpl().Read(sTargetList);

            foreach (string sTarget in sList_Target)
            {
                Givechapterandverse_NodeImpl cf_RfrTarget = new Givechapterandverse_NodeImpl(NamesNode.S_TARGET, cf_Together);
                cf_RfrTarget.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_NAME.SName_Pm, sTarget, pg_Logging);
                cfList_Result.Add(cf_RfrTarget);
            }

            return cfList_Result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// トゥゲザー名で指定しなかった場合の、
        /// （２）なければ「トゥゲザー設定ファイル（Frfr）」の＜ｒｅｆｒｅｓｈｅｒ＞を読みにいく。
        /// </summary>
        /// <param name="pg_Logging"></param>
        private void Perform_ByNoName_2Frfr(
            out Givechapterandverse_Node cf_TgTogether,
            Givechapterandverse_Node s_Fc,
            Givechapterandverse_Node cf_Event,
            Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform_ByNoName_2Frfr",pg_Logging);

            //
            //
            // 11:トゥゲザー名の作成
            // 所要時間目安[0]ミリ秒ほど
            //
            //
            string sFcName3;
            s_Fc.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sFcName3, true, pg_Logging);

            string sEventName;
            cf_Event.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sEventName, true, pg_Logging);

            StringBuilder sIn = new StringBuilder();
            sIn.Append(sFcName3);
            sIn.Append("/");
            sIn.Append(sEventName);

            Givechapterandverse_Node sTg_TogetherIn = new Givechapterandverse_NodeImpl(NamesNode.S_TOGETHER_IN, this.Cur_Givechapterandverse);
            sTg_TogetherIn.Dictionary_SAttribute_Givechapterandverse.Add(PmNames.S_VALUE.SName_Pm, sIn.ToString(), this.Cur_Givechapterandverse, false, pg_Logging);


            //
            //
            // 12:トゥゲザーの取得
            // 所要時間目安[0]ミリ秒ほど
            //
            //

            //
            //
            //
            // （０）トゥゲザーの取得
            //
            //
            //
            cf_TgTogether = null;
            if (pg_Logging.BSuccessful)
            {
                string sExpectedValue;
                sTg_TogetherIn.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sExpectedValue, false, pg_Logging);

                if ("" != sExpectedValue)
                {
                    List<Givechapterandverse_Node> listCf_Together = this.Owner_MemoryApplication.MemoryTogethers.Givechapterandverse_Togetherconfig.GetChildrenByNodename(NamesNode.S_TOGETHER, false, pg_Logging);
                    foreach (Givechapterandverse_Node cf_Together in listCf_Together)
                    {
                        string sIn2;
                        cf_Together.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_IN, out sIn2, false, pg_Logging);

                        if (sExpectedValue == sIn2)
                        {
                            cf_TgTogether = cf_Together;
                        }
                    }
                }
            }

            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion



    }
}
