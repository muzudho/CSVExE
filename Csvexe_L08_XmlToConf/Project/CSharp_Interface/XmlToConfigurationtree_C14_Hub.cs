using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XmlToConf
{
    public interface XmlToConfigurationtree_C14_Hub
    {



        #region アクション
        //────────────────────────────────────────

        void XmlToConfigurationtree(
            XmlElement cur_X,
            Configurationtree_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
