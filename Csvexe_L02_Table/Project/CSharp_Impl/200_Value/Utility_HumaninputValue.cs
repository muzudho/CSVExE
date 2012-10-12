using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports

namespace Xenon.Table
{
    public class Utility_HumaninputValue
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public static Value_Humaninput NewInstance(
            object value,
            bool isRequired,
            string nodeConfigtree,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.Name_Library, "Utility_HumaninputValue", "NewInstance", log_Reports);

            Value_Humaninput result;

            if(value is String_HumaninputImpl)
            {
                result = new String_HumaninputImpl(nodeConfigtree);
            }
            else if(value is Int_HumaninputImpl)
            {
                result = new Int_HumaninputImpl(nodeConfigtree);
            }
            else if(value is Bool_HumaninputImpl)
            {
                result = new Bool_HumaninputImpl(nodeConfigtree);
            }
            else
            {
                result = null;

                if (isRequired)
                {
                    //エラー
                    goto gt_Error_AnotherType;
                }
            }

            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_AnotherType:
            if(log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー292！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("▲エラー201！（" + Info_Table.Name_Library + "）");
                s.Newline();
                s.Append("string,int,boolセルデータクラス以外のオブジェクトが指定されました。");
                s.Newline();

                s.Append("指定された値のクラス=[");
                s.Append(value.GetType().Name);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public static bool TryParse(
            object value,
            out Value_Humaninput out_ValueH,
            bool isRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.Name_Library, "Utility_HumaninputValue", "TryParse", log_Reports);

            bool bResult;

            if (value is Value_Humaninput)
            {
                out_ValueH = (Value_Humaninput)value;

                bResult = true;
            }
            else
            {
                out_ValueH = null;
                bResult = false;

                if (isRequired)
                {
                    goto gt_Error_AnotherType;
                }

                goto gt_EndMethod;
            }

            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_AnotherType:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー201！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("string,int,boolセルデータクラス以外のオブジェクトが指定されました。");
                s.Newline();

                s.Append("指定された値のクラス=[");
                s.Append(value.GetType().Name);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return bResult;
        }
        //────────────────────────────────────────
        #endregion



    }
}
