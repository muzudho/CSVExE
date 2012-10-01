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
            Log_Reports log_Reports
            )
        {

            string sControl = "";
            {
                Givechapterandverse_Node cf_Event = cf_ThisAction.GetParentByNodename(NamesNode.S_EVENT, true, log_Reports);
                if (log_Reports.Successful)
                {
                    Givechapterandverse_Node owner_Givechapterandverse_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, log_Reports);
                    owner_Givechapterandverse_Control.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sControl, false, log_Reports);
                }
            }

            string sEventName = "";
            {
                Givechapterandverse_Node cf_Event = cf_ThisAction.GetParentByNodename(NamesNode.S_EVENT, true, log_Reports);

                if (log_Reports.Successful)
                {
                    cf_Event.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sEventName, false, log_Reports);
                }
            }

            string sActionType = "";
            {
                string sFncName0;
                ec_Sa.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);
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
