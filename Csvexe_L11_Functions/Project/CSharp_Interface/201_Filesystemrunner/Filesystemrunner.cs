using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Functions
{
    public interface Filesystemrunner
    {


        #region アクション
        //────────────────────────────────────────

        void Run(
            Filesystemreport filesystemreporter,
            string folderpathabsolute,
            string filter,
            string search_Subfolder,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
