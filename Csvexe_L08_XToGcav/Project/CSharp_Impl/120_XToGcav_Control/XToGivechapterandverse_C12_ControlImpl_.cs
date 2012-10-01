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
    class XToGivechapterandverse_C12_ControlImpl_ : XToGivechapterandverse_C12_Control_
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public XToGivechapterandverse_C12_ControlImpl_()
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
        public void XToGivechapterandverse(
            string sName_Control,
            Givechapterandverse_Node cf_ControlConfig,
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
            Givechapterandverse_Node cur_Cf;
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

                //if (null == uct.ControlCommon.Givechapterandverse_Control)
                //{
                //    uct.ControlCommon.Givechapterandverse_Control = new Givechapterandverse_NodeImpl(NamesNode.S_CONTROL+"(ヌル時の代替)", cf_ControlConfig);
                //}


                //
                //
                //
                // 自
                //
                //
                //
                cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_CONTROL1, cf_ControlConfig);
                //上書きします。
                uct.ControlCommon.Givechapterandverse_Control = cur_Cf;
                //
                // コントロール名。
                uct.ControlCommon.Givechapterandverse_Control.Dictionary_Attribute_Givechapterandverse.Add(PmNames.S_NAME.Name_Pm, sName_Control, uct.ControlCommon.Givechapterandverse_Control, true, log_Reports);

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
                                XToGivechapterandverse_C15_Elm to = this.Dictionary_XToGivechapterandverse_Elm[child_XElm.Name];
                                to.XToGivechapterandverse(
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
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("△情報35！", log_Method);

                string sFcName = ec_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("「コンポーネント設定ファイル」で指定されている、");
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(sFcName);
                t.Append("]という名前のコントロールは、登録されていませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(cf_ControlConfig));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedChild:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー401！", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("＜" + NamesNode.S_CONTROL1 + "＞要素の直下に、未対応の要素が書かれていました。");
                sb.Append(Environment.NewLine);
                sb.Append("xChild.Name=[");
                sb.Append(err_11elm.Name);
                sb.Append("]");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // ヒント
                sb.Append(r.Message_Givechapterandverse(cur_Cf));
                sb.Append(r.Message_SException(err_Excp));

                r.Message = sb.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception03:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー402！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("予想外の例外。");
                t.Append("xChild.Name=[");
                t.Append(err_11elm.Name);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(cur_Cf));
                t.Append(r.Message_SException(err_Excp));

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



        #region プロパティー
        //────────────────────────────────────────

        private static Dictionary<string, XToGivechapterandverse_C15_Elm> dictionary_XToGivechapterandverse_Elm;

        /// <summary>
        /// 名前付きパーサー一覧。
        /// </summary>
        private Dictionary<string, XToGivechapterandverse_C15_Elm> Dictionary_XToGivechapterandverse_Elm
        {
            get
            {
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports d_Logging_ThisMethod = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToS_ElmMap get",d_Logging_ThisMethod);
                //
                //

                if (null == dictionary_XToGivechapterandverse_Elm)
                {
                    dictionary_XToGivechapterandverse_Elm = new Dictionary<string, XToGivechapterandverse_C15_Elm>();

                    //
                    // TODO: 間違った入れ子関係も　読み取りしてしまうので、そこらへんのチェックも入れたい。
                    //

                    //
                    // 子要素＜ｄａｔａ＞
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_DATA, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_Elm.Add(NamesNode.S_DATA, to);
                    }


                    //
                    // 子要素＜event＞
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_EVENT, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_Elm.Add(NamesNode.S_EVENT, to);
                    }

                    //
                    // 子要素＜key-event＞
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_KEY_EVENT, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_Elm.Add(NamesNode.S_KEY_EVENT, to);
                    }

                    //
                    // 子要素＜ｖｉｅｗ＞
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_VIEW, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_Elm.Add(NamesNode.S_VIEW, to);
                    }

                    //
                    // 子要素＜ｔｏｇｅｔｈｅｒ＞ 2012-01-18 追加
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_TOGETHER, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_Elm.Add(NamesNode.S_TOGETHER, to);
                    }

                }

                //
                //
                log_Method.EndMethod(d_Logging_ThisMethod);
                d_Logging_ThisMethod.EndLogging(log_Method);

                return dictionary_XToGivechapterandverse_Elm;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
