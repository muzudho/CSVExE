using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{
    class XToGivechapterandverse_V_4ADisplayImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected override Givechapterandverse_Node CreateMyself(
            XmlElement cur_X,
            Givechapterandverse_Node parent_Cf,
            MemoryApplication memoryApplication, 
            Log_Reports log_Reports
            )
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
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "Parse_SAttr",log_Reports);
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
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "Parse_ChildNodes",log_Reports);
            //
            //

            XmlElement err_XFAllTrue = null;

            XmlNodeList child_XNl = cur_X.ChildNodes;

            foreach (XmlNode child_XNode in child_XNl)
            {
                // ＜ｆ－ａｌｌ－ｔｒｕｅ＞要素のリスト
                if (XmlNodeType.Element == child_XNode.NodeType)
                {
                    XmlElement child_X = (XmlElement)child_XNode;

                    string sName_Fnc = child_X.GetAttribute(PmNames.S_NAME.Name_Attribute);

                    if (NamesFnc.S_VLD_ALL_FIELDS_IS_EMPTY == sName_Fnc)
                    {
                        //
                        // ＜ｆ－ａｌｌ－ｆｉｅｌｄｓ－ｉｓ－ｅｍｐｔｙ＞要素
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByFncName(sName_Fnc, log_Reports);
                        to.XToGivechapterandverse(
                            child_X,
                            cur_Cf,
                            memoryApplication,
                            log_Reports
                            );

                    }
                    else if (NamesFnc.S_ALL_TRUE == sName_Fnc)
                    {
                        //
                        // ＜ｆ－ａｌｌ－ｔｒｕｅ＞要素
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByFncName(sName_Fnc, log_Reports);
                        to.XToGivechapterandverse(
                            child_X,
                            cur_Cf,
                            memoryApplication,
                            log_Reports
                            );


                    }
                    else
                    {
                        //
                        // エラー。
                        err_XFAllTrue = child_X;
                        goto gt_Error_UndefinedChild12;
                    }

                }
            }
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedChild12:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー400！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("＜ａ－ｄｉｓｐｌａｙ＞要素に、＜ｆ－ａｌｌ－ｔｒｕｅ＞要素以外の要素");
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(err_XFAllTrue.Name);
                t.Append("]が含まれていました。");
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

        protected override void LinkToParent(
            Givechapterandverse_Node cur_Cf, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf,log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
