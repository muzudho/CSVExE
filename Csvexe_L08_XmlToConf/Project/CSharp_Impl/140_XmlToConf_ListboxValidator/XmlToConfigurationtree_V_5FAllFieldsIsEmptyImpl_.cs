using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XmlToConf
{
    class XmlToConfigurationtree_V_5FAllFieldsIsEmptyImpl_ : XmlToConfigurationtree_C_Parser15Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected override Configurationtree_Node CreateMyself(
            XmlElement cur_X, Configurationtree_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            Configurationtree_Node cur_Cf;
            cur_Cf = new Configurationtree_NodeImpl(NamesNode.S_FNC, parent_Cf);

            return cur_Cf;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        protected override void Parse_SAttribute(
            XmlElement cur_X,
            Configurationtree_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XmlToConf.Name_Library, this, "Parse_SAttr",log_Reports);
            //
            //

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        protected override void LinkToParent(
            Configurationtree_Node cur_Cf, Configurationtree_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
        }

        //────────────────────────────────────────
        #endregion



    }
}
