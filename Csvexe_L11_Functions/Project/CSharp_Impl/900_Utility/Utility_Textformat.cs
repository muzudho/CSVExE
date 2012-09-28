using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Functions
{



    /// <summary>
    /// (text format)
    /// </summary>
    public abstract class Utility_Textformat
    {



        #region アクション
        //────────────────────────────────────────

        public static string Format_StopwatchComment(
            Expression_Node_FunctionAbstract ec_Sa,
            Givechapterandverse_Node cf_ThisAction,
            Log_Reports pg_Logging
            )
        {

            string sControl = "";
            {
                Givechapterandverse_Node cf_Event = cf_ThisAction.GetParentByNodename(NamesNode.S_EVENT, true, pg_Logging);
                if (pg_Logging.BSuccessful)
                {
                    Givechapterandverse_Node owner_Givechapterandverse_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, pg_Logging);
                    owner_Givechapterandverse_Control.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sControl, false, pg_Logging);
                }
            }

            string sEventName = "";
            {
                Givechapterandverse_Node cf_Event = cf_ThisAction.GetParentByNodename(NamesNode.S_EVENT, true, pg_Logging);

                if (pg_Logging.BSuccessful)
                {
                    cf_Event.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sEventName, false, pg_Logging);
                }
            }

            string sActionType = "";
            {
                string sFncName0;
                ec_Sa.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);
                sActionType = sFncName0;
            }



            StringBuilder sb = new StringBuilder();

            {
                if ("" != sActionType)
                {
                    sb.Append("　Nアクション＝[");
                    sb.Append(sActionType);
                    sb.Append("]");
                }

                sb.Append("　FC[");
                sb.Append(sControl);
                sb.Append("].EV[");
                sb.Append(sEventName);
                sb.Append("]");
            }


            return sb.ToString();
        }

        //────────────────────────────────────────
        #endregion



    }
}
