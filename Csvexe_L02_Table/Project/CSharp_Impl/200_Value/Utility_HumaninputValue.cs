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
            bool bRequired,
            string sConfigStack,
            out string sMessage_Error
            )
        {
            Value_Humaninput result;

            if(value is String_HumaninputImpl)
            {
                sMessage_Error = "";
                result = new String_HumaninputImpl(sConfigStack);
            }
            else if(value is Int_HumaninputImpl)
            {
                sMessage_Error = "";
                result = new Int_HumaninputImpl(sConfigStack);
            }
            else if(value is Bool_HumaninputImpl)
            {
                sMessage_Error = "";
                result = new Bool_HumaninputImpl(sConfigStack);
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
            out Value_Humaninput cellData,
            bool bRequired,
            out string sMessage_Error
            )
        {

            bool bResult;

            if(
                (value is String_HumaninputImpl)
                ||
                (value is Int_HumaninputImpl)
                ||
                (value is Bool_HumaninputImpl)
                )
            {
                cellData = (Value_Humaninput)value;

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
