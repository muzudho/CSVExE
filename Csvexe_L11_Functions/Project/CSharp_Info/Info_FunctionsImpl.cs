using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Functions
{
    class Info_Functions
    {



        #region アクション
        //────────────────────────────────────────

        static public void WriteErrorLog(
            Log_Method log_Method,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            // エラーログ出力。
            owner_MemoryApplication.MemoryLogwriter.WriteErrorLog(
                owner_MemoryApplication,
                log_Reports,
                log_Method.Fullname);
                //Info_Functions.Name_Library + ":" + sClassName + sMethodNameWithSharp);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        static public String Name_Library
        {
            get
            {
                return "Csvexe_L11_Functions";
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
