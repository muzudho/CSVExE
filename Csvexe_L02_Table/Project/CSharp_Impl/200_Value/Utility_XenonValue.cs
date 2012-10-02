using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports

namespace Xenon.Table
{
    public class Utility_XenonValue
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public static XenonValue NewInstance(
            object value,
            bool bRequired,
            string sConfigStack,
            out string sMessage_Error
            )
        {
            XenonValue result;

            if(value is XenonValue_StringImpl)
            {
                sMessage_Error = "";
                result = new XenonValue_StringImpl(sConfigStack);
            }
            else if(value is XenonValue_IntImpl)
            {
                sMessage_Error = "";
                result = new XenonValue_IntImpl(sConfigStack);
            }
            else if(value is XenonValue_BoolImpl)
            {
                sMessage_Error = "";
                result = new XenonValue_BoolImpl(sConfigStack);
            }
            else
            {
                if (bRequired)
                {
                    Log_TextIndented t = new Log_TextIndentedImpl();
                    t.Append("▲エラー292！（" + Info_Table.Name_Library + "）");
                    t.Newline();
                    t.Append("string,int,boolセルデータクラス以外のオブジェクトが指定されました。");
                    t.Newline();

                    t.Append("指定された値のクラス=[");
                    t.Append(value.GetType().Name);
                    t.Append("]");

                    sMessage_Error = t.ToString();
                }
                else
                {
                    sMessage_Error = "";
                }

                result = null;
                goto gt_EndMethod;
            }

            goto gt_EndMethod;

            //
            //
            //
            //
        gt_EndMethod:
            return result;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public static bool TryParse(
            object value,
            out XenonValue cellData,
            bool bRequired,
            out string sMessage_Error
            )
        {

            bool bResult;

            if(
                (value is XenonValue_StringImpl)
                ||
                (value is XenonValue_IntImpl)
                ||
                (value is XenonValue_BoolImpl)
                )
            {
                cellData = (XenonValue)value;

                bResult = true;
            }
            else
            {
                cellData = null;
                bResult = false;

                if (bRequired)
                {
                    goto gt_Error_AnotherType;
                }
                else
                {
                    sMessage_Error = "";
                }

                goto gt_EndMethod;
            }

            sMessage_Error = "";
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_AnotherType:
            {
                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("▲エラー201！（" + Info_Table.Name_Library + "）");
                t.Newline();
                t.Append("string,int,boolセルデータクラス以外のオブジェクトが指定されました。");
                t.Newline();

                t.Append("指定された値のクラス=[");
                t.Append(value.GetType().Name);
                t.Append("]");

                sMessage_Error = t.ToString();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            return bResult;
        }
        //────────────────────────────────────────
        #endregion



    }
}
