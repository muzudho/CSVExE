using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using Xenon.Syntax;


namespace Xenon.Table
{
    public class Judge_FieldBoolImpl
    {



        #region 判定
        //────────────────────────────────────────

        public void Judge(
            out bool bJudge,
            string sName_KeyField,
            string sValue_Expected,
            bool bRequired_ExpectedValue,
            DataRow row,
            Givechapterandverse_Node parent_Query,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.SName_Library, this, "Judge",log_Reports);

            //
            //
            //
            //

            try
            {
                XenonValue o_CellValue = (XenonValue)row[sName_KeyField];

                // （５）キーが空欄で、検索ヒット必須でなければ、無視します。【bool型フィールドの場合】
                if (XenonValue_BoolImpl.IsSpaces(o_CellValue))
                {
                    bJudge = false;
                    goto gt_EndMethod;
                }



                //
                // （６）この行の、キー_フィールドの値を取得。
                //
                bool bKeyValue;

                bool bParsedSuccessful = XenonValue_BoolImpl.TryParse(
                    o_CellValue,
                    out bKeyValue,
                    EnumOperationIfErrorvalue.Error,
                    null,
                    log_Reports
                    );
                if (log_Reports.BSuccessful)
                {
                    if (!bParsedSuccessful)
                    {
                        // エラー。
                        bJudge = false;
                        if (log_Reports.CanCreateReport)
                        {
                            Log_RecordReport d_Report = log_Reports.BeginCreateReport(EnumReport.Error);
                            d_Report.SetTitle("▲エラー699！", log_Method);
                            d_Report.SMessage = "bool型パース失敗。";
                            log_Reports.EndCreateReport();
                        }
                        goto gt_EndMethod;
                    }
                }


                bool bExpectedValue;
                if (log_Reports.BSuccessful)
                {
                    // （８）キー値をbool型に変換します。
                    bool bParseSuccessful2 = bool.TryParse(sValue_Expected, out bExpectedValue);
                    if (!bParseSuccessful2)
                    {
                        bJudge = false;
                        if (bRequired_ExpectedValue)
                        {
                            // 空値ではダメという設定の場合。
                            goto gt_Error_Parse;
                        }
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    bExpectedValue = false;
                }




                // （８）該当行をレコードセットに追加。
                if (log_Reports.BSuccessful)
                {
                    if (bKeyValue == bExpectedValue)
                    {
                        bJudge = true;
                    }
                    else
                    {
                        bJudge = false;
                    }
                }
                else
                {
                    bJudge = false;
                }
            }
            catch (RowNotInTableException)
            {
                // （９）指定行がなかった場合は、スルー。
                bJudge = false;

                //
                // 指定の行は、テーブルの中にありませんでした。
                // 再描画と、行の削除が被ったのかもしれません。
                // いわゆる「処理中」です。
                //

                //.WriteLine(this.GetType().Name+"#GetValueStringList: ["+refTable.Name+"]テーブルには、["+ttbwIndex+"]行が存在しませんでした。もしかすると、削除されたのかもしれません。エラー："+e.Message);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Parse:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー286！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.AppendI(0, "<Select_KeyBoolImplクラス>");
                s.Append(Environment.NewLine);

                s.AppendI(1, "これはbool型値のプログラムです。他の型のプログラムを使ってください。");
                s.Append(Environment.NewLine);

                s.AppendI(1, "sExpectedValue=[");
                s.Append(sValue_Expected);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                parent_Query.ToText_Path(s);

                s.AppendI(0, "</Select_KeyBoolImplクラス>");

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
