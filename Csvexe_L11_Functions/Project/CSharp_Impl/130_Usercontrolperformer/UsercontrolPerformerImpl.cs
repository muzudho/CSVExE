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
        /// <param name="log_Reports"></param>
        public void Perform_Usercontrol(
            object sender,
            Expression_Node_String ec_FcName,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
            //.WriteLine(this.GetType().Name + "#PerformFc: 【アクション_パフォーマー開始】");

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform_Fc",log_Reports);
            //
            //
            sConfigStack_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_Fc:" + o_Name_Event.SValue + "＞";



            Usercontrol ucFc = null;

            string sFcName1 = ec_FcName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

            owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol ucFc2, ref bool bRemove, ref bool bBreak)
            {
                string sFcName2 = ucFc2.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

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
                    log_Reports
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
            log_Method.EndMethod(log_Reports);

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
        /// <param name="log_Reports"></param>
        public void Perform_UsercontrolNameStartsWith(
            object sender,
            string sFcNameStarts,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
            //.WriteLine(this.GetType().Name + "#Perform_FcNameStartsWith: 【アクション_パフォーマー開始】");

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform_FcNameStartsWith",log_Reports);
            //
            //
            sConfigStack_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_FcNameStartsWith:" + o_Name_Event.SValue + "＞";

            Dictionary<string, Usercontrol> dic = owner_MemoryApplication.MemoryForms.ItemsStartsWith(
                sFcNameStarts,
                log_Reports
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
                        log_Reports
                        );
                }
                else
                {
                    //
                    //
                    //
                    //string sFcName3 = ucFc.ControlCommon.Expression_Name_Control.E_Execute(log_Reports);
                    //.WriteLine(this.GetType().Name + "#Perform_FcNameStartsWith: ■[" + sFcName_prm + "]という名前のコントロールはありませんでした。");
                }
            }

            //
            //
            log_Method.EndMethod(log_Reports);

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
        /// <param name="log_Reports"></param>
        public void Perform_AllUsercontrols(
            List<string> sFcNameList,
            object sender,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform_AllFcs",log_Reports);
            //
            //
            string sConfigStack = "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_AllFcs:" + o_Name_Event.SValue + "＞";
            sConfigStack_EventOrigin += sConfigStack;
            Configurationtree_Node cf_ThisMethod = new Configurationtree_NodeImpl(sConfigStack, null);


            foreach (string sName_Usercontrol in sFcNameList)
            {
                if ("" == sName_Usercontrol)
                {
                    // 空行。飛ばす。
                    goto end_row;
                }

                Expression_Leaf_StringImpl ec_FcName = new Expression_Leaf_StringImpl(null, cf_ThisMethod);
                ec_FcName.SetString( sName_Usercontrol, log_Reports);


                List<Usercontrol> list_UcFc = owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(ec_FcName, true, log_Reports);
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
                        log_Reports
                        );
                }

            end_row:
                ;
            }

            //
            //
            log_Method.EndMethod(log_Reports);
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
        /// <param name="log_Reports"></param>
        protected void Perform_UsercontrolImpl(
            object sender,
            Usercontrol ucFc,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform_FcImpl",log_Reports);
            //
            //
            string sFcName2 = ucFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
            sConfigStack_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_FcImpl:" + o_Name_Event.SValue + "＞";


            if (null == ucFc.ControlCommon.Configurationtree_Control)
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


            List<Configurationtree_Node> cfList_Event = ucFc.ControlCommon.Configurationtree_Control.GetChildrenByNodename(NamesNode.S_EVENT, false, log_Reports);
            foreach (Configurationtree_Node cf_Event in cfList_Event)
            {

                string sEventName;
                cf_Event.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sEventName, true, log_Reports);
                if (!log_Reports.Successful)
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
                        log_Reports
                        );

                }//oEventName

            }//foreach


            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 実行。
        /// 
        /// 指定のコントロールの、指定のイベントを実行します。
        /// </summary>
        /// <param name="oEventName"></param>
        /// <param name="oEventName"></param>
        /// <param name="log_Reports"></param>
        public void Perform(
            object sender,
            string sName_Usercontrol,
            string sEventName,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform",log_Reports);
            //
            //
            sConfigStack_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform:" + sEventName + "＞";


            //.WriteLine(this.GetType().Name + "#Perform:◆◆◆◆◆◆ 【アクション_パフォーマー開始】");

            Usercontrol foundUcFc = null;

            owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol ucFc, ref bool bRemove, ref bool bBreak)
            {
                string sFcName2 = ucFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint,
                    log_Reports
                    );


                //.WriteLine(this.GetType().Name + "#Perform_PrjSelected: ■■コントロール=[" + fcUc.ControlCommon.Name.Value + "] イベント数=[" + fcUc.ControlCommon.OEvents.Items.Count + "]");

                if (sName_Usercontrol == sFcName2)
                {
                    foundUcFc = ucFc;


                    //.WriteLine(this.GetType().Name + "#Perform_PrjSelected: ■■コントロール=[" + fcNameStr2 + "] イベント数=[" + fcUc.ControlCommon.OFcnfControl.OEvents.Count + "]");

                    Configurationtree_Node cf_HitEvent = null;
                    List<Configurationtree_Node> cfList_Event = ucFc.ControlCommon.Configurationtree_Control.GetChildrenByNodename(NamesNode.S_EVENT, false, log_Reports);
                    foreach (Configurationtree_Node cf_Event in cfList_Event)
                    {
                        string sFncName;
                        cf_Event.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sFncName, false, log_Reports);

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
                            log_Reports
                            );
                    }
                    else
                    {
                        string sFcName3 = ucFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                            Request_SelectingImpl.Unconstraint,
                            log_Reports
                            );

                        if (log_Reports.CanCreateReport)
                        {
                            Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                            r.SetTitle("▲エラー1108！", log_Method);

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

                            r.Message = t.ToString();
                            log_Reports.EndCreateReport();
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
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1107！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("[");
                t.Append(sName_Usercontrol);
                t.Append("]という名前のコントロールは存在しませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
