using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{


    /// <summary>
    /// S→E 変換。＜ｖｉｅｗ＞要素
    /// </summary>
    class GivechapterandverseToExpression_F12_ViewImpl_ : GivechapterandverseToExpression_AbstractImpl, GivechapterandverseToExpression_F12_
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 読取。
        /// </summary>
        /// <param name="s_View"></param>
        /// <param name="ef_View"></param>
        /// <param name="moOpyopyo"></param>
        /// <param name="log_Reports"></param>
        public void Translate(
            Givechapterandverse_Node cur_Cf,//＜ｖｉｅｗ＞
            Expression_Node_String parent_Ec,//「E■ｆｏｒｍ－ｃｏｍｐｏｎｅｎｔ」
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(3)"+cur_Cf.Name);
            }

            //
            //
            //
            //

            //
            //
            //
            // 自
            //
            //
            //

            Expression_Node_StringImpl cur_Ec = new Expression_Node_StringImpl(parent_Ec, cur_Cf);

            //
            //
            //
            // 子
            //
            //
            //
            {
                //＜●●＞要素を全検索。＜ｆ－ｌｉｓｔ－ｂｏｘ－ｌａｂｅｌｓ＞があることが期待されます。

                cur_Cf.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node cf_Child, ref bool bBreak)
                {
                    if (cf_Child is Givechapterandverse_Node)
                    {
                        Givechapterandverse_Node cf_Node = (Givechapterandverse_Node)cf_Child;

                        string sName_Node = cf_Node.Name;
                        string sName_Fnc = "";
                        {
                            bool bRequired;

                            if (NamesNode.S_FNC == sName_Node)
                            {
                                bRequired = true;
                            }
                            else
                            {
                                bRequired = false;
                            }

                            // todo; 子要素のnameも取りたい。
                            cf_Node.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Fnc, bRequired, log_Reports);
                        }

                        if (NamesNode.S_FNC == sName_Node && NamesFnc.S_LISTBOX_LABELS == sName_Fnc)
                        {
                            //　「S■ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｆ－ｌｉｓｔｂｏｘ－ｌａｂｅｌｓ；”」

                            GivechapterandverseToExpression_F91_FListboxLabelsImpl_ to = new GivechapterandverseToExpression_F91_FListboxLabelsImpl_();
                            to.Translate(
                                cf_Child,
                                cur_Ec,
                                memoryApplication,
                                pg_ParsingLog,
                                log_Reports
                                );
                        }
                        else
                        {
                            // エラー
                            if (log_Reports.CanCreateReport)
                            {
                                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                                r.SetTitle("▲エラー603！", log_Method);

                                StringBuilder t = new StringBuilder();
                                t.Append("＜view＞要素の中に、未対応の子要素名がありました。");
                                t.Append("未対応の要素＝＜[");
                                t.Append(sName_Node);
                                t.Append("]　ｎａｍｅ＝”[" + sName_Fnc + "]”＞");
                                r.Message = t.ToString();
                                log_Reports.EndCreateReport();
                            }

                            bBreak = true;
                        }
                    }
                });
            }


            //
            //
            //
            // 親へ連結
            //
            //
            //
            {
                parent_Ec.List_Expression_Child.Add(cur_Ec, log_Reports);
            }


            goto gt_EndMethod;
            //
            //

        gt_EndMethod:
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Cf.Name);
            }
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
