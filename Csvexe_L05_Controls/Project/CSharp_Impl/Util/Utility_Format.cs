using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Controls
{
    public abstract class Utility_Format
    {



        #region アクション
        //────────────────────────────────────────

        public static string Format(
            string sName_Control,
            string sName_Event
            )
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Info_Controls.Name_Library);
            sb.Append(":");
            sb.Append("#ToString: 計測");

            {
                sb.Append("　FC[");
                sb.Append(sName_Control);
                sb.Append("].EV[");
                sb.Append(sName_Event);
                sb.Append("]");
            }

            return sb.ToString();
        }

        //────────────────────────────────────────
        #endregion



    }
}
