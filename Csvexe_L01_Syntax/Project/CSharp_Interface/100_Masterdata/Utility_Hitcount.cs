using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{
    public class Utility_Hitcount
    {

        public static bool IsRequired(EnumHitcount hits, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.Name_Library, "Utility_Hitcount", "IsRequired", log_Reports);

            bool result;

            switch(hits)
            {
                case EnumHitcount.Exists:
                    result = true;
                    break;
                case EnumHitcount.First_Exist:
                    result = true;
                    break;
                case EnumHitcount.First_Exist_Or_Zero:
                    result = false;
                    break;
                case EnumHitcount.One:
                    result = true;//複数件あっても、構わず通す。
                    break;
                case EnumHitcount.One_Or_Zero:
                    result = false;//複数件あっても、構わず通す。
                    break;
                case EnumHitcount.Unconstraint:
                    result = false;
                    break;
                default:
                    //エラー
                    goto gt_Error_Default;
            }

            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Default:
            {
                result = false;
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー031！", log_Method);

                    Log_TextIndented t = new Log_TextIndentedImpl();
                    t.Append("Enum型の対応していない値[");
                    t.Append(hits.ToString());
                    t.Append("]");
                    t.Newline();

                    r.Message = t.ToString();
                    log_Reports.EndCreateReport();
                }
            }
            goto gt_EndMethod;
            //────────────────────────────────────────
            #endregion
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

    }
}
