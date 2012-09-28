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
    /// 
    /// </summary>
    class XToGivechapterandverse_V_3FListboxValidationImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected override Givechapterandverse_Node CreateMyself(
            XmlElement cur_X, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            Givechapterandverse_Node cur_Cf;
            cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_F_LISTBOX_VALIDATION, parent_Cf);

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

            //string sIvtv = x_Cur.Attributes.GetNamedItem(AttrNames.S_ITEM_VALUE_TO_VARIABLE).Value;
            //string sIvtvTrim = "";
            //if (null == sIvtv)
            //{
            //    sIvtvTrim = "";
            //}
            //else
            //{
            //    sIvtvTrim = sIvtv.Trim();
            //}
            cur_Cf.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_NAME_VAR.SName_Pm, "", log_Reports);// PmNames.Z_ITEM_VALUE_TO_VARIABLE sIvtv;

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
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "Parse_ChildNodes",log_Reports);
            //
            //

            XmlElement err_XADisplay = null;

            Usercontrol uct = null;
            if (log_Reports.BSuccessful)
            {
                Givechapterandverse_Node cf_Control= cur_Cf.GetParentByNodename(NamesNode.S_CONTROL1,true,log_Reports);
                uct = Utility_XToGivechapterandverse_NodeImpl.GetUsercontrol(cf_Control, memoryApplication, log_Reports);
            }

            if (log_Reports.BSuccessful)
            {
                if (uct is UsercontrolListbox)
                {
                    //
                    // リストボックスなら。
                    UsercontrolListbox uctLst = (UsercontrolListbox)uct;

                    //
                    // ＜a-select-record＞、＜ａ－ｄｉｓｐｌａｙ＞要素
                    //
                    XmlNodeList child_XNl = cur_X.ChildNodes;

                    foreach (XmlNode x_childNode in child_XNl)
                    {
                        if (XmlNodeType.Element == x_childNode.NodeType)
                        {
                            XmlElement xChild = (XmlElement)x_childNode;
                            err_XADisplay = xChild;

                            string child_SName_Fnc = xChild.GetAttribute(PmNames.S_NAME.SName_Attr);

                            //
                            //
                            if (NamesFnc.S_VLD_DISPLAY == child_SName_Fnc)//【変更 2012-07-19】
                            {

                                XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByFncName(child_SName_Fnc, log_Reports);
                                to.XToGivechapterandverse(
                                    xChild,
                                    cur_Cf,
                                    memoryApplication,
                                    log_Reports
                                    );

                            }
                            else if (NamesFnc.S_VLD_SELECT_RECORD == child_SName_Fnc)
                            {
                                // Sf:Vld-SelectRecord;

                                XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByFncName(child_SName_Fnc, log_Reports);
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
                                goto gt_Error_UndefinedChild11;
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
        gt_Error_UndefinedChild11:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー385！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("＜ｆ－ｌｉｓｔ－ｂｏｘ－ｖａｌｉｄａｔｉｏｎ＞要素に、＜ａ－ｄｉｓｐｌａｙ＞＜a-select-record＞要素以外の要素");
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(err_XADisplay.Name);
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
            Usercontrol uct = null;
            if (log_Reports.BSuccessful)
            {
                Givechapterandverse_Node cf_Control = cur_Cf.GetParentByNodename(NamesNode.S_CONTROL1, true, log_Reports);
                uct = Utility_XToGivechapterandverse_NodeImpl.GetUsercontrol(cf_Control, memoryApplication, log_Reports);
            }

            uct.ControlCommon.Givechapterandverse_Control.List_ChildGivechapterandverse.Add(cur_Cf, log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
