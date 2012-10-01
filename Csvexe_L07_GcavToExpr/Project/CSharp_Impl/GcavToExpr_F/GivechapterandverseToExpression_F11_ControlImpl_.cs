using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    class ConfigurationtreeToExpression_F11_ControlImpl_ : ConfigurationtreeToExpression_AbstractImpl, ConfigurationtreeToExpression_F11_Control_
    {



        #region アクション
        //────────────────────────────────────────

        public void Translate(
            Configurationtree_Node cur_Cf,//コントロール
            Expression_Node_String ec_Cur,//「E■ｆｏｒｍ－ｃｏｍｐｏｎｅｎｔ」
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            List<Configurationtree_Node> cfList_Data = cur_Cf.GetChildrenByNodename(NamesNode.S_DATA, false, log_Reports);
            foreach (Configurationtree_Node cf_Data in cfList_Data)
            {
                string sAccess;
                cf_Data.Dictionary_Attribute.TryGetValue(PmNames.S_ACCESS, out sAccess, false, log_Reports);

                List<string> sList_Access = new CsvTo_ListImpl().Read(sAccess);

                if (sList_Access.Contains(ValuesAttr.S_FROM))
                {
                    // ＜ｄａｔａ＞要素（ａｃｃｅｓｓ="ｆｒｏｍ"）を S→E。

                    ConfigurationtreeToExpression_F12_ to = new ConfigurationtreeToExpression_F12_DataImpl_();
                    to.Translate(
                        cf_Data,
                        ec_Cur,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }

                // ｆｒｏｍとtoは、両方持つこともある。

                if (sList_Access.Contains(ValuesAttr.S_TO))
                {
                    // ＜ｄａｔａ＞(ａｃｃｅｓｓ="ｔｏ")要素要素を S→E。

                    ConfigurationtreeToExpression_F12_ to = new ConfigurationtreeToExpression_F12_DataImpl_();
                    to.Translate(
                        cf_Data,
                        ec_Cur,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }
            }



            //
            // ＜view＞要素を S→E。
            List<Configurationtree_Node> sList_View = cur_Cf.GetChildrenByNodename(NamesNode.S_VIEW, false, log_Reports);
            if(1<sList_View.Count)
            {
                // ＜view＞要素は１個だけあるという前提。
                throw new Exception("＜[" + NamesNode.S_VIEW + "]＞要素が２個以上あるのはエラー。");
            }
            else if (0 < sList_View.Count)
            {
                Configurationtree_Node cf_View = sList_View[0];

                ConfigurationtreeToExpression_F12_ViewImpl_ to = new ConfigurationtreeToExpression_F12_ViewImpl_();
                to.Translate(
                    cf_View,
                    ec_Cur,//.E_View,
                    memoryApplication,
                    pg_ParsingLog,
                    log_Reports
                    );
            }
            else
            {
            }

        }

        //────────────────────────────────────────
        #endregion



    }
}
