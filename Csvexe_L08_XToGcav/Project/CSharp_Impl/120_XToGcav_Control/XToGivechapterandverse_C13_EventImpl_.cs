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
    class XToGivechapterandverse_C13_EventImpl_ : XToGivechapterandverse_C_Parser15Impl
	{



        #region アクション
        //────────────────────────────────────────

        public override void XToGivechapterandverse(
            XmlElement cur_X,//＜event＞
            Givechapterandverse_Node parent_Cf,//＜ｃｏｎｔｒｏｌ＞
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "XToS",log_Reports);
            //
            //


            //
            //
            //
            // 自
            //
            //
            //
            Givechapterandverse_Node cur_Cf = this.CreateMyself(cur_X, parent_Cf, memoryApplication, log_Reports);


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
            if (log_Reports.BSuccessful)
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
                            XToGivechapterandverse_C15_Elm to = this.Dic_XToGivechapterandverse[xChild.Name];
                            to.XToGivechapterandverse(
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
            if (log_Reports.BSuccessful)
            {
                parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf, log_Reports);
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
                t.Append(r.Message_Givechapterandverse(cur_Cf));
                t.Append(r.Message_SException(err_Excp));

                r.SMessage = t.ToString();
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
                t.Append(r.Message_Givechapterandverse(cur_Cf));
                t.Append(r.Message_SException(err_Excp));

                r.SMessage = t.ToString();
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

        private static Dictionary<string, XToGivechapterandverse_C15_Elm> dic_XToGivechapterandverse;

        /// <summary>
        /// 名前付きパーサー一覧。
        /// </summary>
        private Dictionary<string, XToGivechapterandverse_C15_Elm> Dic_XToGivechapterandverse
        {
            get
            {
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports d_Logging_ThisMethod = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "XToS_F_4Map get",d_Logging_ThisMethod);
                //
                //

                if (null == dic_XToGivechapterandverse)
                {
                    dic_XToGivechapterandverse = new Dictionary<string, XToGivechapterandverse_C15_Elm>();

                    //
                    // TODO: 間違った入れ子関係も　読み取りしてしまうので、そこらへんのチェックも入れたい。
                    //

                    //
                    // 子要素＜fnc＞
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_FNC, d_Logging_ThisMethod);
                        dic_XToGivechapterandverse.Add(NamesNode.S_FNC, to);
                    }

                }

                //
                //
                log_Method.EndMethod(d_Logging_ThisMethod);
                d_Logging_ThisMethod.EndLogging(log_Method);

                return dic_XToGivechapterandverse;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
