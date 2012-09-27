using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{


    /// <summary>
    /// (memory code file info)
    /// </summary>
    public interface MemoryCodefileinfo
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// コードファイル呼出名。
        /// </summary>
        string SName
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// タイプデータ。
        /// </summary>
        string STypedata
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ファイルパス。
        /// </summary>
        Expression_Node_Filepath Expression_Filepath
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
