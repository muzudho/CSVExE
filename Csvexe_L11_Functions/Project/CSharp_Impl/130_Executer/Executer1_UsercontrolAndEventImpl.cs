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
    public class Executer1_UsercontrolAndEventImpl : Executer1_UsercontrolAndEvent
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="form"></param>
        public Executer1_UsercontrolAndEventImpl()
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
        /// 
        /// todo:どこで利用されている？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nFcName">コントロール名。</param>
        /// <param name="oEventName"></param>
        /// <param name="log_Reports"></param>
        public void Execute1_Usercontrol(
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
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute1_Usercontrol", log_Reports);
            //
            //
            sConfigStack_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#:" + o_Name_Event.SValue + "＞";



            Usercontrol ucFc = null;

            string sFcName1 = ec_FcName.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

            owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol ucFc2, ref bool bRemove, ref bool bBreak)
            {
                string sFcName2 = ucFc2.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                if (sFcName2 == sFcName1)
                {
                    ucFc = ucFc2;
                }
            });

            if (null != ucFc)
            {
                // 一致したfcUcがあれば、一致した最後のfcUcを。
                this.Execute1_UsercontrolImpl(
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
        /// 
        /// todo:どこから呼び出されている？
        /// </summary>
        /// <param name="oEventName"></param>
        /// <param name="oEventName"></param>
        /// <param name="log_Reports"></param>
        public void Execute1_UsercontrolNameStartsWith(
            object sender,
            string sFcNameStarts,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute1_UsercontrolNameStartsWith", log_Reports);
            //
            //
            sConfigStack_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#:" + o_Name_Event.SValue + "＞";

            Dictionary<string, Usercontrol> dic = owner_MemoryApplication.MemoryForms.ItemsStartsWith(
                sFcNameStarts,
                log_Reports
                );

            foreach (Usercontrol ucFc in dic.Values)
            {
                if (null != ucFc)
                {
                    this.Execute1_UsercontrolImpl(
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
        /// 
        /// 別の関数から呼び出されます。
        /// </summary>
        /// <param name="oEventName"></param>
        /// <param name="oEventName"></param>
        /// <param name="log_Reports"></param>
        public void Execute1_AllUsercontrols(
            List<string> sFcNameList,
            object sender,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute1_AllUsercontrols", log_Reports);
            //
            //
            string sConfigStack = "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#:" + o_Name_Event.SValue + "＞";
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

                    this.Execute1_UsercontrolImpl(
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
        protected void Execute1_UsercontrolImpl(
            object sender,
            Usercontrol ucFc,
            XenonName o_Name_Event,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute1_UsercontrolImpl", log_Reports);
            //
            //
            string sFcName2 = ucFc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
            sConfigStack_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#:" + o_Name_Event.SValue + "＞";


            if (null == ucFc.ControlCommon.Configurationtree_Control)
            {
                //
                // 「コントロール設定ファイル」が無いコントロールの場合は、無視します。
                //
                goto gt_EndMethod;
            }




            //if (0 < fcUc.ControlCommon.OCnf_Control.OEvents.Count)
            //{
            //    //.WriteLine(this.GetType().Name + "#: ■■コントロール=[" + fcNameStr2 + "] イベント数=[" + fcUc.ControlCommon.OFcnfControl.OEvents.Count + "]");
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
                    Executer2_EventImpl exe1 = new Executer2_EventImpl();
                    exe1.Execute2_Event(
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
        private void Execute1b(
            object sender,
            string name_ExpectedUsercontrol,
            string sEventName,
            MemoryApplication owner_MemoryApplication,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute2", log_Reports);
            //
            //
            sConfigStack_EventOrigin += "＜" + log_Method.Fullname + ":" + sEventName + "＞";


            Usercontrol foundUsercontrol = null;

            owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol curUsercontrol, ref bool bRemove, ref bool bBreak)
            {
                string name_CurUsercontrol = curUsercontrol.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(
                    EnumHitcount.Unconstraint,
                    log_Reports
                    );


                //.WriteLine(this.GetType().Name + "#: ■■コントロール=[" + fcUc.ControlCommon.Name.Value + "] イベント数=[" + fcUc.ControlCommon.OEvents.Items.Count + "]");

                if (name_ExpectedUsercontrol == name_CurUsercontrol)
                {
                    foundUsercontrol = curUsercontrol;


                    //.WriteLine(this.GetType().Name + "#: ■■コントロール=[" + fcNameStr2 + "] イベント数=[" + fcUc.ControlCommon.OFcnfControl.OEvents.Count + "]");

                    Configurationtree_Node hitEvent_Cnf = null;
                    List<Configurationtree_Node> list_EventCnf = curUsercontrol.ControlCommon.Configurationtree_Control.GetChildrenByNodename(NamesNode.S_EVENT, false, log_Reports);
                    foreach (Configurationtree_Node event_Cnf in list_EventCnf)
                    {
                        string name_Fnc;
                        event_Cnf.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out name_Fnc, false, log_Reports);

                        if (name_Fnc == sEventName)
                        {
                            hitEvent_Cnf = event_Cnf;
                        }
                    }

                    if (null != hitEvent_Cnf)
                    {
                        //
                        // 最初の<event>要素
                        //
                        Executer2_EventImpl exe1 = new Executer2_EventImpl();
                        exe1.Execute2_Event(
                            sender,
                            hitEvent_Cnf,
                            owner_MemoryApplication,
                            log_Reports
                            );
                    }
                    else
                    {
                        string sFcName3 = curUsercontrol.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(
                            EnumHitcount.Unconstraint,
                            log_Reports
                            );

                        {
                            Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                            tmpl.SetParameter(1, sFcName3, log_Reports);//コントロール名
                            tmpl.SetParameter(2, sEventName, log_Reports);//イベント名

                            owner_MemoryApplication.CreateErrorReport("Er:110027;", tmpl, log_Reports);
                        }
                    }


                }//nFcName_prm
            });

            //loop_end:
            //.WriteLine(this.GetType().Name + "#: 【アクション_パフォーマー終了】");

            if (null == foundUsercontrol)
            {
                goto gt_Error_NotFoundUsercontrol;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundUsercontrol:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, name_ExpectedUsercontrol, log_Reports);//コントロール名

                owner_MemoryApplication.CreateErrorReport("Er:110028;", tmpl, log_Reports);
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
