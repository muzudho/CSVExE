using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode
using System.Windows.Forms;

using Xenon.Syntax;//Log_TextIndented
using Xenon.Controls;
using Xenon.Middle;

namespace Xenon.XToGcav
{

    /// <summary>
    /// （Sf）＜control＞
    /// </summary>
    class XToConfigurationtree_C12_ControlImpl_ : XToConfigurationtree_C12_Control_
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public XToConfigurationtree_C12_ControlImpl_()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// X → S
        /// 
        /// event要素の読取と、処理の実行。
        /// </summary>
        /// <param select="xEvent"></param>
        /// <param select="fcUc"></param>
        public void XToConfigurationtree(
            string sName_Control,
            Configurationtree_Node cf_ControlConfig,
            XmlElement xControl,//＜ｃｏｎｔｒｏｌ＞要素。子要素の読取りに利用。
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToCf",log_Reports);
            //
            //

            Expression_Node_String ec_Name_Control;
            XmlElement err_11elm;
            Exception err_Excp;
            Configurationtree_Node cur_Cf;
            if (log_Reports.Successful)
            {

                // コントロール名。
                ec_Name_Control = new Expression_Node_StringImpl(null, cf_ControlConfig);
                ec_Name_Control.AppendTextNode(
                    sName_Control,
                    cf_ControlConfig,
                    log_Reports
                    );

                List<Usercontrol> list_Usercontrol = owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                    ec_Name_Control,
                    true,
                    log_Reports
                    );

                Usercontrol uct;
                if (list_Usercontrol.Count < 1)
                {
                    //
                    // エラー。
                    goto gt_Error_NotFoundFc;
                }
                else
                {
                    uct = list_Usercontrol[0];
                }

                //if (null == uct.ControlCommon.Configurationtree_Control)
                //{
                //    uct.ControlCommon.Configurationtree_Control = new Configurationtree_NodeImpl(NamesNode.S_CONTROL+"(ヌル時の代替)", cf_ControlConfig);
                //}


                //
                //
                //
                // 自
                //
                //
                //
                cur_Cf = new Configurationtree_NodeImpl(NamesNode.S_CONTROL1, cf_ControlConfig);
                //上書きします。
                uct.ControlCommon.Configurationtree_Control = cur_Cf;
                //
                // コントロール名。
                uct.ControlCommon.Configurationtree_Control.Dictionary_Attribute.Add(PmNames.S_NAME.Name_Pm, sName_Control, uct.ControlCommon.Configurationtree_Control, true, log_Reports);

                //
                //
                //
                // 子
                //
                //
                //
                {
                    // ＜data＞、＜event＞、＜view＞要素を列挙
                    XmlNodeList child_XNl = xControl.ChildNodes;

                    foreach (XmlNode child_XNode in child_XNl)
                    {
                        if (XmlNodeType.Element == child_XNode.NodeType)
                        {
                            XmlElement child_XElm = (XmlElement)child_XNode;

                            try
                            {
                                XToConfigurationtree_C15_Elm to = this.Dictionary_XToConfigurationtree_Elm[child_XElm.Name];
                                to.XToConfigurationtree(
                                    child_XElm,
                                    cur_Cf,
                                    owner_MemoryApplication,
                                    log_Reports
                                    );
                            }
                            catch (ArgumentException e)
                            {
                                //
                                // エラー。
                                err_11elm = child_XElm;
                                err_Excp = e;
                                goto gt_Error_UndefinedChild;
                            }
                            catch (Exception e)
                            {
                                //
                                // エラー。
                                err_11elm = child_XElm;
                                err_Excp = e;
                                goto gt_Error_Exception03;
                            }


                        }

                    }
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundFc:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();

                string sFcName = ec_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                tmpl.SetParameter(1, sFcName, log_Reports);//コントロール名

                tmpl.SetParameter(2, Log_Report01Impl.ToMessage_Configurationtree(cf_ControlConfig), log_Reports);//設定位置パンくずリスト

                owner_MemoryApplication.CreateErrorReport("Er:8017;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedChild:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();

                string sFcName = ec_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                tmpl.SetParameter(1, NamesNode.S_CONTROL1, log_Reports);//期待するノード名
                tmpl.SetParameter(2, err_11elm.Name, log_Reports);//実際のノード名
                tmpl.SetParameter(3, Log_Report01Impl.ToMessage_Configurationtree(cur_Cf), log_Reports);//設定位置パンくずリスト
                tmpl.SetParameter(4, Log_Report01Impl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                owner_MemoryApplication.CreateErrorReport("Er:8018;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception03:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_11elm.Name, log_Reports);//ノード名
                tmpl.SetParameter(2, Log_Report01Impl.ToMessage_Configurationtree(cur_Cf), log_Reports);//設定位置パンくずリスト
                tmpl.SetParameter(3, Log_Report01Impl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                owner_MemoryApplication.CreateErrorReport("Er:8019;", tmpl, log_Reports);
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



        #region プロパティー
        //────────────────────────────────────────

        private static Dictionary<string, XToConfigurationtree_C15_Elm> dictionary_XToConfigurationtree_Elm;

        /// <summary>
        /// 名前付きパーサー一覧。
        /// </summary>
        private Dictionary<string, XToConfigurationtree_C15_Elm> Dictionary_XToConfigurationtree_Elm
        {
            get
            {
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports d_Logging_ThisMethod = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToS_ElmMap get",d_Logging_ThisMethod);
                //
                //

                if (null == dictionary_XToConfigurationtree_Elm)
                {
                    dictionary_XToConfigurationtree_Elm = new Dictionary<string, XToConfigurationtree_C15_Elm>();

                    //
                    // TODO: 間違った入れ子関係も　読み取りしてしまうので、そこらへんのチェックも入れたい。
                    //

                    //
                    // 子要素＜ｄａｔａ＞
                    //
                    {
                        XToConfigurationtree_C15_Elm to = XToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_DATA, d_Logging_ThisMethod);
                        dictionary_XToConfigurationtree_Elm.Add(NamesNode.S_DATA, to);
                    }


                    //
                    // 子要素＜event＞
                    //
                    {
                        XToConfigurationtree_C15_Elm to = XToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_EVENT, d_Logging_ThisMethod);
                        dictionary_XToConfigurationtree_Elm.Add(NamesNode.S_EVENT, to);
                    }

                    //
                    // 子要素＜key-event＞
                    //
                    {
                        XToConfigurationtree_C15_Elm to = XToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_KEY_EVENT, d_Logging_ThisMethod);
                        dictionary_XToConfigurationtree_Elm.Add(NamesNode.S_KEY_EVENT, to);
                    }

                    //
                    // 子要素＜ｖｉｅｗ＞
                    //
                    {
                        XToConfigurationtree_C15_Elm to = XToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_VIEW, d_Logging_ThisMethod);
                        dictionary_XToConfigurationtree_Elm.Add(NamesNode.S_VIEW, to);
                    }

                    //
                    // 子要素＜ｔｏｇｅｔｈｅｒ＞ 2012-01-18 追加
                    //
                    {
                        XToConfigurationtree_C15_Elm to = XToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_TOGETHER, d_Logging_ThisMethod);
                        dictionary_XToConfigurationtree_Elm.Add(NamesNode.S_TOGETHER, to);
                    }

                }

                //
                //
                log_Method.EndMethod(d_Logging_ThisMethod);
                d_Logging_ThisMethod.EndLogging(log_Method);

                return dictionary_XToConfigurationtree_Elm;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
