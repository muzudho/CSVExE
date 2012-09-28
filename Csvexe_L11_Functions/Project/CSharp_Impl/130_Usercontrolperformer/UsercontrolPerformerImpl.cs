using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//DrawMode,Form

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,OAction,NFcName,EventName,OEvent

namespace Xenon.Functions
{
    /// <summary>
    /// コントロールの &lt;event&gt;要素の中を読み取って実行します。
    /// </summary>
    public class UsercontrolPerformerImpl : UsercontrolPerformer
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="form"></param>
        public UsercontrolPerformerImpl()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 実行。
        /// 
        /// 指定のコントロールの、指定のイベントを実行します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nFcName">コントロール名。</param>
        /// <param name="oEventName"></param>
        /// <param name="pg_Logging"></param>
        public void Perform_Usercontrol(
            object sender,
            Expression_Node_String ec_FcName,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports pg_Logging
            )
        {
            //.WriteLine(this.GetType().Name + "#PerformFc: 【アクション_パフォーマー開始】");

            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform_Fc",pg_Logging);
            //
            //
            sConfigStack_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_Fc:" + o_Name_Event.SValue + "＞";



            Usercontrol ucFc = null;

            string sFcName1 = ec_FcName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

            owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol ucFc2, ref bool bRemove, ref bool bBreak)
            {
                string sFcName2 = ucFc2.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                if (sFcName2 == sFcName1)
                {
                    ucFc = ucFc2;
                }
            });

            if (null != ucFc)
            {
                // 一致したfcUcがあれば、一致した最後のfcUcを。
                this.Perform_UsercontrolImpl(
                    sender,
                    ucFc,
                    o_Name_Event,
                    owner_MemoryApplication,
                    sConfigStack_EventOrigin,
                    pg_Logging
                    );
            }
            else
            {
                //
                //
                //
                //.WriteLine(this.GetType().Name + "#PerformFc: ■[" + sFcName_prm + "]という名前のコントロールはありませんでした。");
            }


            //
            //
            pg_Method.EndMethod(pg_Logging);

            //.WriteLine(this.GetType().Name + "#PerformFc: 【アクション_パフォーマー終了】");
        }

        //────────────────────────────────────────

        /// <summary>
        /// 実行。
        /// 
        /// コントロールの名前数文字を指定して、一致するコントロールのイベントを実行します。
        /// </summary>
        /// <param name="oEventName"></param>
        /// <param name="oEventName"></param>
        /// <param name="pg_Logging"></param>
        public void Perform_UsercontrolNameStartsWith(
            object sender,
            string sFcNameStarts,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports pg_Logging
            )
        {
            //.WriteLine(this.GetType().Name + "#Perform_FcNameStartsWith: 【アクション_パフォーマー開始】");

            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform_FcNameStartsWith",pg_Logging);
            //
            //
            sConfigStack_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_FcNameStartsWith:" + o_Name_Event.SValue + "＞";

            Dictionary<string, Usercontrol> dic = owner_MemoryApplication.MemoryForms.ItemsStartsWith(
                sFcNameStarts,
                pg_Logging
                );

            foreach (Usercontrol ucFc in dic.Values)
            {
                if (null != ucFc)
                {
                    this.Perform_UsercontrolImpl(
                        sender,
                        ucFc,
                        o_Name_Event,
                        owner_MemoryApplication,
                        sConfigStack_EventOrigin,
                        pg_Logging
                        );
                }
                else
                {
                    //
                    //
                    //
                    //string sFcName3 = ucFc.ControlCommon.Expression_Name_Control.E_Execute(pg_Logging);
                    //.WriteLine(this.GetType().Name + "#Perform_FcNameStartsWith: ■[" + sFcName_prm + "]という名前のコントロールはありませんでした。");
                }
            }

            //
            //
            pg_Method.EndMethod(pg_Logging);

            //.WriteLine(this.GetType().Name + "#Perform_FcNameStartsWith: 【アクション_パフォーマー終了】");
        }

        //────────────────────────────────────────

        /// <summary>
        /// 実行。
        /// 
        /// 全てのコントロールの、指定のイベントを実行します。
        /// 
        /// アプリケーション起動時に、"OnLoad"を全て実行するなど。
        /// </summary>
        /// <param name="oEventName"></param>
        /// <param name="oEventName"></param>
        /// <param name="pg_Logging"></param>
        public void Perform_AllUsercontrols(
            List<string> sFcNameList,
            object sender,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform_AllFcs",pg_Logging);
            //
            //
            string sConfigStack = "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_AllFcs:" + o_Name_Event.SValue + "＞";
            sConfigStack_EventOrigin += sConfigStack;
            Givechapterandverse_Node cf_ThisMethod = new Givechapterandverse_NodeImpl(sConfigStack, null);


            foreach (string sName_Usercontrol in sFcNameList)
            {
                if ("" == sName_Usercontrol)
                {
                    // 空行。飛ばす。
                    goto end_row;
                }

                Expression_Leaf_StringImpl ec_FcName = new Expression_Leaf_StringImpl(null, cf_ThisMethod);
                ec_FcName.SetString( sName_Usercontrol, pg_Logging);


                List<Usercontrol> list_UcFc = owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(ec_FcName, true, pg_Logging);
                if (list_UcFc.Count < 1)
                {
                    // 正常。
                    // 特に設定をすることのないコントロールは、XMLファイルが用意されていない。
                    // 無視する。
                }
                else
                {
                    Usercontrol ucFc = list_UcFc[0];

                    this.Perform_UsercontrolImpl(
                        sender,
                        ucFc,
                        o_Name_Event,
                        owner_MemoryApplication,
                        sConfigStack_EventOrigin,
                        pg_Logging
                        );
                }

            end_row:
                ;
            }

            //
            //
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 実行。
        /// 
        /// 指定のコントロールの、指定のイベントを実行します。
        /// 
        /// アプリケーション起動時に、"OnLoad"を全て実行するなど。
        /// </summary>
        /// <param name="oEventName"></param>
        /// <param name="oEventName"></param>
        /// <param name="pg_Logging"></param>
        protected void Perform_UsercontrolImpl(
            object sender,
            Usercontrol ucFc,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform_FcImpl",pg_Logging);
            //
            //
            string sFcName2 = ucFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);
            sConfigStack_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_FcImpl:" + o_Name_Event.SValue + "＞";


            if (null == ucFc.ControlCommon.Givechapterandverse_Control)
            {
                //
                // 「コントロール設定ファイル」が無いコントロールの場合は、無視します。
                //
                goto gt_EndMethod;
            }




            //if (0 < fcUc.ControlCommon.OCnf_Control.OEvents.Count)
            //{
            //    //.WriteLine(this.GetType().Name + "#PerformAllFcs: ■■コントロール=[" + fcNameStr2 + "] イベント数=[" + fcUc.ControlCommon.OFcnfControl.OEvents.Count + "]");
            //}


            List<Givechapterandverse_Node> cfList_Event = ucFc.ControlCommon.Givechapterandverse_Control.GetChildrenByNodename(NamesNode.S_EVENT, false, pg_Logging);
            foreach (Givechapterandverse_Node cf_Event in cfList_Event)
            {

                string sEventName;
                cf_Event.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sEventName, true, pg_Logging);
                if (!pg_Logging.BSuccessful)
                {
                    goto gt_EndMethod;
                }

                if (o_Name_Event.SValue == sEventName)
                {
                    Exe_1EventImpl exe1 = new Exe_1EventImpl();
                    exe1.Perform(
                        sender,
                        cf_Event,
                        owner_MemoryApplication,
                        pg_Logging
                        );

                }//oEventName

            }//foreach


            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 実行。
        /// 
        /// 指定のコントロールの、指定のイベントを実行します。
        /// </summary>
        /// <param name="oEventName"></param>
        /// <param name="oEventName"></param>
        /// <param name="pg_Logging"></param>
        public void Perform(
            object sender,
            string sName_Usercontrol,
            string sEventName,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform",pg_Logging);
            //
            //
            sConfigStack_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform:" + sEventName + "＞";


            //.WriteLine(this.GetType().Name + "#Perform:◆◆◆◆◆◆ 【アクション_パフォーマー開始】");

            Usercontrol foundUcFc = null;

            owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol ucFc, ref bool bRemove, ref bool bBreak)
            {
                string sFcName2 = ucFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint,
                    pg_Logging
                    );


                //.WriteLine(this.GetType().Name + "#Perform_PrjSelected: ■■コントロール=[" + fcUc.ControlCommon.Name.Value + "] イベント数=[" + fcUc.ControlCommon.OEvents.Items.Count + "]");

                if (sName_Usercontrol == sFcName2)
                {
                    foundUcFc = ucFc;


                    //.WriteLine(this.GetType().Name + "#Perform_PrjSelected: ■■コントロール=[" + fcNameStr2 + "] イベント数=[" + fcUc.ControlCommon.OFcnfControl.OEvents.Count + "]");

                    Givechapterandverse_Node cf_HitEvent = null;
                    List<Givechapterandverse_Node> cfList_Event = ucFc.ControlCommon.Givechapterandverse_Control.GetChildrenByNodename(NamesNode.S_EVENT, false, pg_Logging);
                    foreach (Givechapterandverse_Node cf_Event in cfList_Event)
                    {
                        string sFncName;
                        cf_Event.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sFncName, false, pg_Logging);

                        if (sFncName == sEventName)
                        {
                            cf_HitEvent = cf_Event;
                        }
                    }

                    if (null != cf_HitEvent)
                    {
                        //
                        // 最初の<event>要素
                        //
                        Exe_1EventImpl exe1 = new Exe_1EventImpl();
                        exe1.Perform(
                            sender,
                            cf_HitEvent,
                            owner_MemoryApplication,
                            pg_Logging
                            );
                    }
                    else
                    {
                        string sFcName3 = ucFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                            Request_SelectingImpl.Unconstraint,
                            pg_Logging
                            );

                        if (pg_Logging.CanCreateReport)
                        {
                            Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                            r.SetTitle("▲エラー1108！", pg_Method);

                            StringBuilder t = new StringBuilder();
                            t.Append("[");
                            t.Append(sFcName3);
                            t.Append("]という名前のコントロールには、");
                            t.Append(Environment.NewLine);

                            t.Append("[");
                            t.Append(sEventName);
                            t.Append("]という名前のイベントは　存在しませんでした。");
                            t.Append(Environment.NewLine);
                            t.Append(Environment.NewLine);

                            // ヒント

                            r.SMessage = t.ToString();
                            pg_Logging.EndCreateReport();
                        }
                    }


                }//nFcName_prm
            });

            //loop_end:
            //.WriteLine(this.GetType().Name + "#Perform_PrjSelected: 【アクション_パフォーマー終了】");

            if (null == foundUcFc)
            {
                goto gt_Error_NotFoundUsercontrol;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundUsercontrol:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1107！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("[");
                t.Append(sName_Usercontrol);
                t.Append("]という名前のコントロールは存在しませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

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
        #endregion



    }
}
