using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XmlToConf
{
    class PmNameItemImpl : PmNameItem
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public PmNameItemImpl(PmName pmName, bool bRequired)
        {
            this.pmName = pmName;
            this.bRequired = bRequired;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private PmName pmName;

        public PmName PmName
        {
            get
            {
                return this.pmName;
            }
        }

        //────────────────────────────────────────

        private bool bRequired;

        public bool BRequired
        {
            get
            {
                return this.bRequired;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
