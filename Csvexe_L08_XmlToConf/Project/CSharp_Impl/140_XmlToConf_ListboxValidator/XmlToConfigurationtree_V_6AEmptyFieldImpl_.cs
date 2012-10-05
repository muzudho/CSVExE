using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XmlToConf
{
    class XmlToConfigurationtree_V_6AEmptyFieldImpl_ : XmlToConfigurationtree_C_Parser15Impl
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



    }
}
