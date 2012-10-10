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
            Configurationtree_Node parent_Query,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.Name_Library, this, "Judge",log_Reports);

            //
            //
            //
            //

            try
            {
                ValueHumaninput o_CellValue = (ValueHumaninput)row[sName_KeyField];

                // （５）キーが空欄で、検索ヒット必須でなければ、無視します。【bool型フィールドの場合】
                if (Bool_HumaninputImpl.IsSpaces(o_CellValue))
                {
                    bJudge = false;
                    goto gt_EndMethod;
                }



                //
                // （６）この行の、キー_フィールドの値を取得。
                //
                bool bKeyValue;

                bool bParsedSuccessful = Bool_HumaninputImpl.TryParse(
                    o_CellValue,
                    out bKeyValue,
                    EnumOperationIfErrorvalue.Error,
                    null,
                    log_Reports
                    );
                if (log_Reports.Successful)
                {
                    if (!bParsedSuccessful)
                    {
                        // エラー。
                        bJudge = false;
                        if (log_Reports.CanCreateReport)
                        {
                            Log_RecordReports d_Report = log_Reports.BeginCreateReport(EnumReport.Error);
                            d_Report.SetTitle("▲エラー699！", log_Method);
                            d_Report.Message = "bool型パース失敗。";
                            log_Reports.EndCreateReport();
                        }
                        goto gt_EndMethod;
                    }
                }


                bool bExpectedValue;
                if (log_Reports.Successful)
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
                if (log_Reports.Successful)
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
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
                parent_Query.ToText_Locationbreadcrumbs(s);

                s.AppendI(0, "</Select_KeyBoolImplクラス>");

                r.Message = s.ToString();
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
