using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;//FormObjectProperties

namespace Xenon.Controls
{
    public abstract class Utility_Usercontrol
    {


        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// 未指定時のフォントサイズ。（pt）
        /// </summary>
        protected static readonly float N_DEFAULT_FONT_PT = 9.0F;

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// フォント・サイズを読み取ります。
        /// </summary>
        /// <param nFcName="fo_Record"></param>
        /// <param nFcName="log_Reports"></param>
        /// <returns></returns>
        public static float ParseFontSize(
            RecordUserformconfig fo_Record,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Controls.Name_Library, "Util_Fo", "ParseFontSize",log_Reports);

            float nFontSizePt;
            Exception err_Excp;
            {
                // 例："6.75" や ""（空文字列）。
                string sFontSizePt;
                fo_Record.TryGetString(out sFontSizePt, NamesFld.S_FONT_SIZE_PT, false, "",
                    memoryApplication,
                    log_Reports);
                sFontSizePt = sFontSizePt.Trim();

                if ("" == sFontSizePt)
                {
                    //
                    // 未指定時のフォントサイズ
                    //
                    nFontSizePt = N_DEFAULT_FONT_PT;
                }
                else
                {

                    try
                    {
                        nFontSizePt = float.Parse(sFontSizePt);
                    }
                    catch (Exception e2)
                    {
                        //
                        // 例外発生時のフォントサイズ
                        //
                        nFontSizePt = N_DEFAULT_FONT_PT;
                        err_Excp = e2;

                        goto gt_Error_Exception;
                    }
                }
            }
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲設定エラー4041！", pg_Method);
                r.Message = "コントロール設定ファイルの読取エラー：" + err_Excp.Message;
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return nFontSizePt;
        }

        //────────────────────────────────────────
        #endregion



    }
}
