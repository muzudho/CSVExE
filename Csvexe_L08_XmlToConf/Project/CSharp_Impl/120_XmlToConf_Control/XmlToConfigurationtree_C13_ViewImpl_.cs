using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using Xenon.Syntax;//Log_TextIndented
using Xenon.Controls;
using Xenon.Middle;

namespace Xenon.XmlToConf
{


    /// <summary>
    /// (Sf) ＜ｖｉｅｗ＞
    /// </summary>
    class XmlToConfigurationtree_C13_ViewImpl_ : XmlToConfigurationtree_C_Parser15Impl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ＜ｖｉｅｗ＞要素を読取り、s_Dataを作成。
        /// </summary>
        /// <param name="x_View"></param>
        /// <param name="s_Parent"></param>
        /// <param name="log_Reports"></param>
        public override void XmlToConfigurationtree(
            XmlElement cur_X,
            Configurationtree_Node parent_Cf,//＜ｃｏｎｔｒｏｌ＞
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XmlToConf.Name_Library, this, "XmlToConfigurationtree", log_Reports);
            //
            //



            //
            //
            //
            // 自
            //
            //
            //
            Configurationtree_Node cur_Sf = this.CreateMyself(cur_X, parent_Cf, memoryApplication, log_Reports);



            //
            //
            //
            // 属性
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Parse_SAttribute(cur_X, cur_Sf, memoryApplication, log_Reports);
            }



            //
            //
            //
            // 子
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Parse_ChildNodes(cur_X, cur_Sf, memoryApplication, log_Reports);
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
                parent_Cf.List_Child.Add(cur_Sf, log_Reports);
            }



            //
            //
            //
            //

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return;
        }

        //────────────────────────────────────────

        protected override void Parse_ChildNodes(
            XmlElement cur_X,
            Configurationtree_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            XmlToConfigurationtree_C14_Hub to = new XmlToConfigurationtree_C14_HubImpl();
            to.XmlToConfigurationtree(
                cur_X,
                cur_Cf,
                memoryApplication,
                log_Reports
                );
        }

        //────────────────────────────────────────
        #endregion



    }
}
