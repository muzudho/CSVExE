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
            Log_Method pg_Method,
            MemoryApplication owner_MemoryApplication,
            Log_Reports pg_Logging
            )
        {
            // エラーログ出力。
            owner_MemoryApplication.MemoryLogwriter.WriteErrorLog(
                owner_MemoryApplication,
                pg_Logging,
                pg_Method.SHead);
                //Info_Functions.SName_Library + ":" + sClassName + sMethodNameWithSharp);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        static public String SName_Library
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
