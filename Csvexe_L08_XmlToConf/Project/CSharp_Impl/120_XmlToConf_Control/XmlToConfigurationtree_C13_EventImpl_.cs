using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XmlToConf
{

    /// <summary>
    /// (Sf) ＜ｅｖｅｎｔ＞
    /// </summary>
    class XmlToConfigurationtree_C13_EventImpl_ : XmlToConfigurationtree_C_Parser15Impl
	{



        #region アクション
        //────────────────────────────────────────

        public override void XmlToConfigurationtree(
            XmlElement cur_X,//＜event＞
            Configurationtree_Node parent_Cf,//＜ｃｏｎｔｒｏｌ＞
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XmlToConf.Name_Library, this, "XmlToConfigurationtree", log_Reports);
            //
            //


            //
            //
            //
            // 自
            //
            //
            //
            Configurationtree_Node cur_Cf = this.CreateMyself(cur_X, parent_Cf, memoryApplication, log_Reports);


            //
            //
            //
            // 属性
            //
            //
            //
            this.Parse_SAttribute(cur_X, cur_Cf, memoryApplication, log_Reports);



            //
            //
            //
            // 子
            //
            //
            //
            XmlElement err_XAction;
            Exception err_Excp;
            if (log_Reports.Successful)
            {

                //
                //
                // actionノードを列挙
                //
                XmlNodeList child_XNl = cur_X.ChildNodes;
                foreach(XmlNode xChild in child_XNl)
                {

                    if (XmlNodeType.Element == xChild.NodeType)
                    {
                        XmlElement xAction = (XmlElement)xChild;

                        try
                        {
                            XmlToConfigurationtree_C15_Elm to = this.Dic_XmlToConfigurationtree[xChild.Name];
                            to.XmlToConfigurationtree(
                                xAction,
                                cur_Cf,
                                memoryApplication,
                                log_Reports
                                );
                        }
                        catch(KeyNotFoundException e)
                        {
                            err_XAction = xAction;
                            err_Excp = e;
                            goto gt_Error_NotFound;
                        }
                        catch (Exception e)
                        {
                            err_Excp = e;
                            goto gt_Error_Excp;
                        }
                    }


                }

            }



            //
            //
            //
            // 親へ連結
            //
            //
            //
            if (log_Reports.Successful)
            {
                parent_Cf.List_Child.Add(cur_Cf, log_Reports);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFound:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_XAction.Name, log_Reports);//ノード名
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configurationtree(cur_Cf), log_Reports);//設定位置パンくずリスト
                tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Exception(err_Excp), log_Reports);//例外メッセージ

                memoryApplication.CreateErrorReport("Er:8023;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Excp:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(cur_Cf), log_Reports);//設定位置パンくずリスト
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Exception(err_Excp), log_Reports);//例外メッセージ

                memoryApplication.CreateErrorReport("Er:8024;", tmpl, log_Reports);
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

        private static Dictionary<string, XmlToConfigurationtree_C15_Elm> dic_XmlToConfigurationtree;

        /// <summary>
        /// 名前付きパーサー一覧。
        /// </summary>
        private Dictionary<string, XmlToConfigurationtree_C15_Elm> Dic_XmlToConfigurationtree
        {
            get
            {
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports d_Logging_ThisMethod = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_XmlToConf.Name_Library, this, "Dic_XmlToConfigurationtree get", d_Logging_ThisMethod);
                //
                //

                if (null == dic_XmlToConfigurationtree)
                {
                    dic_XmlToConfigurationtree = new Dictionary<string, XmlToConfigurationtree_C15_Elm>();

                    //
                    // TODO: 間違った入れ子関係も　読み取りしてしまうので、そこらへんのチェックも入れたい。
                    //

                    //
                    // 子要素＜fnc＞
                    {
                        XmlToConfigurationtree_C15_Elm to = XmlToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_FNC, d_Logging_ThisMethod);
                        dic_XmlToConfigurationtree.Add(NamesNode.S_FNC, to);
                    }

                }

                //
                //
                log_Method.EndMethod(d_Logging_ThisMethod);
                d_Logging_ThisMethod.EndLogging(log_Method);

                return dic_XmlToConfigurationtree;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
