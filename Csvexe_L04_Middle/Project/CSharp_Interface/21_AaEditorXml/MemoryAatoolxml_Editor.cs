using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{



    /// <summary>
    /// ツール設定ファイルのエディター要素、または　エディター設定ファイルの、codefile-editor要素。
    /// </summary>
    public interface MemoryAatoolxml_Editor : MemorySetvarContainer
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// エディター名。
        /// 
        /// ツール設定ファイルでは name属性、エディター設定ファイルでは name-editor属性。
        /// </summary>
        string SName
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
