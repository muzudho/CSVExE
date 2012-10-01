using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{
    class XToConfigurationtree_V_4ASelectRecordImpl_ : XToConfigurationtree_C_Parser15Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected override Configurationtree_Node CreateMyself(
            XmlElement cur_X,
            Configurationtree_Node parent_Cf,
            MemoryApplication memoryApplication, 
            Log_Reports log_Reports
            )
        {
            Configurationtree_Node cf_Cur;
            cf_Cur = new Configurationtree_NodeImpl(NamesNode.S_FNC, parent_Cf);

            return cf_Cur;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        protected override void Parse_ChildNodes(
            XmlElement cur_X,
            Configurationtree_Node cf_Cur,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────

        protected override void LinkToParent(
            Configurationtree_Node cur_Cf, Configurationtree_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            parent_Cf.List_Child.Add(cur_Cf,log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
