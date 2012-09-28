using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;

namespace Xenon.XToGcav
{

    /// <summary>
    /// ＜validator＞要素。
    /// </summary>
    class XToGivechapterandverse_V_3ValidatorImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region アクション
        //────────────────────────────────────────

        protected override void Parse_ChildNodes(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "Parse_ChildNodes",log_Reports);
            //
            //

            XmlNode err_Child_XNode;

            // ＜ａｒｇ＞要素のリスト
            XmlNodeList child_XNl = cur_X.ChildNodes;

            foreach (XmlNode child_XNode in child_XNl)
            {
                if (XmlNodeType.Element == child_XNode.NodeType)
                {
                    XmlElement xChild = (XmlElement)child_XNode;

                    if (NamesNode.S_ARG == xChild.Name)
                    {
                        //
                        // ＜ａｒｇ＞要素
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(xChild.Name, log_Reports);
                        to.XToGivechapterandverse(xChild, cur_Cf, memoryApplication, log_Reports);
                    }
                    else
                    {
                        // エラー。
                        err_Child_XNode = xChild;
                        goto gt_Error_UndefinedChild01;
                    }

                }
            }
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedChild01:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー386！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("<validator>要素に、<arg>要素以外の要素[");
                t.Append(err_Child_XNode.Name);
                t.Append("]が含まれていました。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

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

        protected override void LinkToParent(
            Givechapterandverse_Node cur_Cf, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf,log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
