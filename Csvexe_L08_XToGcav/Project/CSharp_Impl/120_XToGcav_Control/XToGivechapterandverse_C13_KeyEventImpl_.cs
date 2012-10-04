using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{
    /// <summary>
    /// (Sf) ＜ｋｅｙ－ｅｖｅｎｔ＞
    /// </summary>
    class XToConfigurationtree_C13_KeyEventImpl_ : XToConfigurationtree_C_Parser15Impl
    {



        #region アクション
        //────────────────────────────────────────

        public override void XToConfigurationtree(
            XmlElement cur_X,//＜key-event＞
            Configurationtree_Node parent_Cf,//＜control＞
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
            // コントロールの、key-eventリストに、S_KeyEventを追加。
            //
            if (log_Reports.Successful)
            {
                XToConfigurationtree_C15_Elm to = XToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_KEY_ACTION, log_Reports);

                //List<string> li = new List<string>();
                //li.Add(PmNames.TYPE.Name_Pm);
                //li.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                //xToS.List_AttrName = li;

                //
                //
                // fncノードを列挙
                //
                XmlNodeList child_XNl = cur_X.ChildNodes;
                foreach(XmlNode xChild in child_XNl)
                {

                    if (XmlNodeType.Element == xChild.NodeType)
                    {
                        if (NamesNode.S_FNC == xChild.Name)
                        {
                            XmlElement xFnc = (XmlElement)xChild;

                            to.XToConfigurationtree(
                                xFnc,
                                cur_Cf,
                                memoryApplication,
                                log_Reports
                                );
                        }
                        else
                        {
                            //#連続エラー
                            {
                                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                                tmpl.SetParameter(1, xChild.Name, log_Reports);//ノード名
                                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configurationtree(cur_Cf), log_Reports);//設定位置パンくずリスト

                                memoryApplication.CreateErrorReport("Er:8025;", tmpl, log_Reports);
                            }
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
                parent_Cf.List_Child.Add(cur_Cf,log_Reports);
            }



            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
