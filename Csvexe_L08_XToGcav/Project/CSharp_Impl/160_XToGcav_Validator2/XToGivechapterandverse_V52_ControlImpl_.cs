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
    class XToGivechapterandverse_V52_ControlImpl_ : XToGivechapterandverse_C_Parser15Impl
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

            XmlNode err_Chidl_XNode = null;

            //
            // validator要素のリスト
            //
            XmlNodeList child_XNl = cur_X.ChildNodes;

            foreach (XmlNode child_XNode in child_XNl)
            {
                err_Chidl_XNode = child_XNode;

                if (XmlNodeType.Element == child_XNode.NodeType)
                {
                    XmlElement xChild = (XmlElement)child_XNode;

                    if (NamesNode.S_VALIDATOR == xChild.Name)
                    {
                        //
                        // ＜validator＞要素。
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_VALIDATOR, log_Reports);
                        to.XToGivechapterandverse(
                            xChild,
                            cur_Cf,
                            memoryApplication,
                            log_Reports
                            );

                    }
                    else if (NamesNode.S_F_LISTBOX_VALIDATION == xChild.Name)
                    {
                        //
                        // ＜ｆ－ｌｉｓｔｂｏｘ－ｖａｌｉｄａｔｉｏｎ＞要素。
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_F_LISTBOX_VALIDATION, log_Reports);
                        to.XToGivechapterandverse(
                            xChild,
                            cur_Cf,
                            memoryApplication,
                            log_Reports
                            );

                    }
                    else
                    {
                        //
                        // エラー。
                        goto gt_Error_UndefinedChild03;
                    }
                }
            }
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedChild03:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー410！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("<" + NamesNode.S_CONTROL1 + ">要素に、<validator>、＜ｆ－ｌｉｓｔ－ｂｏｘ－ｖａｌｉｄａｔｉｏｎ＞要素以外の要素[");
                t.Append(err_Chidl_XNode.Name);
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

        protected override void LinkToParent(Givechapterandverse_Node cur_Cf, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            Usercontrol uct = null;
            if (log_Reports.BSuccessful)
            {
                uct = Utility_XToGivechapterandverse_NodeImpl.GetUsercontrol(cur_Cf, memoryApplication, log_Reports);
            }

            uct.ControlCommon.Givechapterandverse_Control.List_ChildGivechapterandverse.Add(cur_Cf, log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
