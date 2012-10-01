using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XToGcav
{
    interface XToConfigurationtree_C12_Control_
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// X → S
        /// 
        /// event要素の読取と、処理の実行。
        /// </summary>
        /// <param select="xEvent"></param>
        /// <param select="fcUc"></param>
        void XToConfigurationtree(
            string sName_Control,
            Configurationtree_Node cf_FcConfig,
            XmlElement xControl,//＜ｃｏｎｔｒｏｌ＞要素。子要素の読取りに利用。
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
