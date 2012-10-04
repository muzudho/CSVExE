using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// 
    /// </summary>
    class PmNameImpl_ : PmName
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="sName_Pm"></param>
        /// <param name="log_Reports"></param>
        public PmNameImpl_(string sName_Pm)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Middle.Name_Library, this, "PmNameImpl_",log_Reports_ThisMethod);


            if (sName_Pm.StartsWith(PmNames.S_PM) && sName_Pm.EndsWith(PmNames.S_SEMICOLON))
            {
                // "Pm:"で始まり、";"で終わる。

                this.name_Pm = sName_Pm;
                this.name_Attribute = sName_Pm.Substring(3, sName_Pm.Length - 4);

                if(""==this.name_Attribute)
                {
                    // エラー。
                    goto gt_Error_Format;
                }
            }
            else
            {
                // エラー。
                goto gt_Error_Format;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Format:
            if (log_Reports_ThisMethod.CanCreateReport)
            {
                Log_RecordReports r = log_Reports_ThisMethod.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー36！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("pm引数フォーマットエラー　入力=[");
                s.Append(sName_Pm);
                s.Append("]　Attr部=[");
                s.Append(this.Name_Attribute);
                s.Append("]　pm部=[");
                s.Append(this.Name_Pm);
                s.Append("]");
                s.Newline();
                s.Append("["+PmNames.S_PM+"]で始まり、「;」で終わらなければなりません。また、名前は空文字列であってはいけません。");
                s.Newline();
                s.Newline();

                r.Message = s.ToString();
                log_Reports_ThisMethod.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(pg_Method);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string name_Pm;

        /// <summary>
        /// 属性名。書式「pm_☆;」。
        /// </summary>
        public string Name_Pm
        {
            get
            {
                return this.name_Pm;
            }
        }

        //────────────────────────────────────────

        private string name_Attribute;

        /// <summary>
        /// 属性名。
        /// </summary>
        public string Name_Attribute
        {
            get
            {
                return this.name_Attribute;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
