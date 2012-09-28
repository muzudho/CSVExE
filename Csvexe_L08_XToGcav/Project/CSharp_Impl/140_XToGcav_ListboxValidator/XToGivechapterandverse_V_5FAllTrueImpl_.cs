using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{
    class XToGivechapterandverse_V_5FAllTrueImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected override Givechapterandverse_Node CreateMyself(
            XmlElement cur_X, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            Givechapterandverse_Node cur_Cf;
            cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_FNC, parent_Cf);

            return cur_Cf;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        protected override void Parse_SAttribute(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "Parse_SAttr",log_Reports);
            //
            //

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

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

            XmlElement err_XAEelem66 = null;

            // ＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞要素のリスト
            XmlNodeList child_XNl = cur_X.ChildNodes;

            foreach (XmlNode child_XNode in child_XNl)
            {
                if (XmlNodeType.Element == child_XNode.NodeType)
                {
                    XmlElement xChild = (XmlElement)child_XNode;
                    err_XAEelem66 = xChild;

                    string sName_Fnc = xChild.GetAttribute(PmNames.S_NAME.SName_Attr);

                    if (NamesFnc.S_VLD_EMPTY_FIELD == sName_Fnc)
                    {
                        //
                        // ＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞要素
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByFncName(sName_Fnc, log_Reports);
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
                        goto gt_Error_UndefinedChild13;
                    }

                }
            }
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedChild13:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー411！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("＜ｆ－ａｌｌ－ｔｒｕｅ＞要素に、＜a-emtpy-field＞要素以外の要素");
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(err_XAEelem66.Name);
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
        #endregion



    }
}
