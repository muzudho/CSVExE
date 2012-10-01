using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{

    /// <summary>
    /// (Sf) ＜ｅｖｅｎｔ＞
    /// </summary>
    class XToConfigurationtree_C13_EventImpl_ : XToConfigurationtree_C_Parser15Impl
	{



        #region アクション
        //────────────────────────────────────────

        public override void XToConfigurationtree(
            XmlElement cur_X,//＜event＞
            Configurationtree_Node parent_Cf,//＜ｃｏｎｔｒｏｌ＞
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToS",log_Reports);
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
                            XToConfigurationtree_C15_Elm to = this.Dic_XToConfigurationtree[xChild.Name];
                            to.XToConfigurationtree(
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
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー389！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("　<event>要素には、[" + err_XAction.Name + "]子要素は未対応です。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configurationtree(cur_Cf));
                t.Append(r.Message_SException(err_Excp));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Excp:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー390！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("　予想だにしないエラー。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configurationtree(cur_Cf));
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

        private static Dictionary<string, XToConfigurationtree_C15_Elm> dic_XToConfigurationtree;

        /// <summary>
        /// 名前付きパーサー一覧。
        /// </summary>
        private Dictionary<string, XToConfigurationtree_C15_Elm> Dic_XToConfigurationtree
        {
            get
            {
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports d_Logging_ThisMethod = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToS_F_4Map get",d_Logging_ThisMethod);
                //
                //

                if (null == dic_XToConfigurationtree)
                {
                    dic_XToConfigurationtree = new Dictionary<string, XToConfigurationtree_C15_Elm>();

                    //
                    // TODO: 間違った入れ子関係も　読み取りしてしまうので、そこらへんのチェックも入れたい。
                    //

                    //
                    // 子要素＜fnc＞
                    {
                        XToConfigurationtree_C15_Elm to = XToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_FNC, d_Logging_ThisMethod);
                        dic_XToConfigurationtree.Add(NamesNode.S_FNC, to);
                    }

                }

                //
                //
                log_Method.EndMethod(d_Logging_ThisMethod);
                d_Logging_ThisMethod.EndLogging(log_Method);

                return dic_XToConfigurationtree;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
