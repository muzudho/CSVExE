using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XToGcav
{
    public interface XToGivechapterandverse_C14_Hub
    {



        #region アクション
        //────────────────────────────────────────

        void XToGivechapterandverse(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
