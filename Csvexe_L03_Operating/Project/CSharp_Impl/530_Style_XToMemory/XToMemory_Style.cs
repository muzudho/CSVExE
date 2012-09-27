using System;
using System.Collections.Generic;
using System.Drawing;//Color
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Operating
{

    /// <summary>
    /// </summary>
    public class XToMemory_Style
    {



        #region アクション
        //────────────────────────────────────────

        public XenonStyle Parse(string sText, Log_Reports log_Reports)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Operating.SName_Library, this, "Parse",log_Reports);

            XenonStyle o_Style = new XenonStyleImpl();

            string[] properties = sText.Split(';');

            foreach (string sProperty in properties)
            {
                string[] keyValue = sProperty.Split(':');

                if (2 <= keyValue.Length)
                {
                    if ("color" == keyValue[0].Trim().ToLower())
                    {
                        string sValue = keyValue[1].Trim().ToLower();

                        ColorResult colorResult = BuilderColor.Parse(keyValue[1].Trim().ToLower(), Color.Black, true);
                        if (colorResult.BNotFound)
                        {
                            // 該当がなければ

                            // #連続エラー処理
                            if (log_Reports.CanCreateReport)
                            {
                                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                                r.SetTitle("▲エラー4301！", pg_Method);
                                r.SMessage = "color属性に["+sValue+"]が指定されましたが、対応していない値です。";
                                log_Reports.EndCreateReport();
                            }
                        }
                        else
                        {
                            o_Style.ForeColor = new XenonColorImpl();
                            o_Style.ForeColor.Color = colorResult.Color;
                            o_Style.ForeColor.SName_Color = sValue;
                        }
                    }
                    else
                    {
                        // 無視
                    }
                }
                else
                {
                    // エラー処理
                }
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return o_Style;
        }

        //────────────────────────────────────────
        #endregion



    }
}
