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
    class ConfigurationtreeToExpression_F12_ViewImpl_ : ConfigurationtreeToExpression_AbstractImpl, ConfigurationtreeToExpression_F12_
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
            Configurationtree_Node cur_Cf,//＜ｖｉｅｗ＞
            Expression_Node_String parent_Ec,//「E■ｆｏｒｍ－ｃｏｍｐｏｎｅｎｔ」
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

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

                cur_Cf.List_Child.ForEach(delegate(Configurationtree_Node cf_Child, ref bool bBreak)
                {
                    if (cf_Child is Configurationtree_Node)
                    {
                        Configurationtree_Node cf_Node = (Configurationtree_Node)cf_Child;

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
                            cf_Node.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Fnc, bRequired, log_Reports);
                        }

                        if (NamesNode.S_FNC == sName_Node && NamesFnc.S_LISTBOX_LABELS == sName_Fnc)
                        {
                            //　「S■ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｆ－ｌｉｓｔｂｏｘ－ｌａｂｅｌｓ；”」

                            ConfigurationtreeToExpression_F91_FListboxLabelsImpl_ to = new ConfigurationtreeToExpression_F91_FListboxLabelsImpl_();
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
                            {
                                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                                tmpl.SetParameter(1, sName_Node, log_Reports);//設定ノード名
                                tmpl.SetParameter(2, sName_Fnc, log_Reports);//関数名

                                memoryApplication.CreateErrorReport("Er:7003;", tmpl, log_Reports);
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
