using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XmlToConf
{
    public interface PmNameItem
    {



        #region プロパティー
        //────────────────────────────────────────

        PmName PmName
        {
            get;
        }

        //────────────────────────────────────────

        bool BRequired
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
