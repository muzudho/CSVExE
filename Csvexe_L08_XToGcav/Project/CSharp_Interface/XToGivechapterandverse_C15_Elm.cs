using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{
    public interface XToGivechapterandverse_C15_Elm
    {



        #region アクション
        //────────────────────────────────────────

        void XToGivechapterandverse(
            XmlElement cur_X,
            Givechapterandverse_Node parent_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        List<string> List_SName_Attribute
        {
            get;
            set;
        }

        List<string> List_SName_RequiredPm
        {
            get;
            set;
        }

        List<PmNameItem> List_PmName
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
