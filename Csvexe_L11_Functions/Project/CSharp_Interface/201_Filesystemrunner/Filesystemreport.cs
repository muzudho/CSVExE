using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Functions
{
    public interface Filesystemreport
    {



        #region アクション
        //────────────────────────────────────────

        void ForEach(DELEGATE_Filesystementries delegate_Records1, Log_Reports log_Reports);

        void Add(string filepath);

        void AddList(List<string> list_Filepath);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        DELEGATE_Filesystementries Delegate_Filesystementries
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion

    }
}
