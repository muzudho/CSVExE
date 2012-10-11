using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Xenon.Syntax;


namespace Xenon.Table
{
    public class Judge_FieldIntImpl
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
                object obj = row[sName_KeyField];

                if (obj is DBNull)
                {
                    bJudge = false;
                    goto gt_Error_DBNull;
                }

                Value_Humaninput o_CellValue = (Value_Humaninput)obj;

                // （５）キーが空欄で、検索ヒット必須でなければ、無視します。【int型フィールドの場合】
                if (Int_HumaninputImpl.IsSpaces(o_CellValue))
                {
                    bJudge = false;
                    goto gt_EndMethod;
                }


                // （６）この行の、キー_フィールドの値を取得。
                int nKeyValue;

                bool bParsedSuccessful = Int_HumaninputImpl.TryParse(
                    o_CellValue,
                    out nKeyValue,
                    EnumOperationIfErrorvalue.Error,
                    null,
                    log_Reports
                    );

                if (log_Reports.Successful)
                {
                    if (!bParsedSuccessful)
                    {
                        bJudge = false;
                        if (log_Reports.CanCreateReport)
                        {
                            Log_RecordReports d_Report = log_Reports.BeginCreateReport(EnumReport.Error);
                            d_Report.SetTitle("▲エラー698！", log_Method);
                            d_Report.Message = "int型パース失敗。";
                            log_Reports.EndCreateReport();
                        }
                        goto gt_EndMethod;
                    }
                }



                // （７）キー値をint型に変換します。
                int nExpectedValue;
                if (log_Reports.Successful)
                {
                    bool bParseSuccessful2 = int.TryParse(sValue_Expected, out nExpectedValue);
                    if (!bParseSuccessful2)
                    {
                        bJudge = false;
                        if (bRequired_ExpectedValue)
                        {
                            goto gt_Error_Parse;
                        }

                        goto gt_EndMethod;
                    }
                }
                else
                {
                    nExpectedValue = 0;
                }



                if (log_Reports.Successful)
                {
                    // （８）該当行をレコードセットに追加。
                    if (nKeyValue == nExpectedValue)
                    {
                        //
                        // 該当行なら。
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
        gt_Error_DBNull:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー244！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("検索キーに指定した[");
                s.Append(sName_KeyField);
                s.Append("]というフィールドは無いです。");
                s.Newline();

                // ヒント
                parent_Query.ToText_Locationbreadcrumbs(s);

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Parse:
            // 空値ではダメという設定の場合。
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー287！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.AppendI(0, "<Select_KeyIntImplクラス>");
                s.Newline();

                s.AppendI(1, "これはint型値のプログラムです。他の型のプログラムを使ってください。");
                s.Newline();

                s.AppendI(1, "・ヒント：変数が見つからなかった場合もここに来ます。例えば、変数名「$aaa」を書こうとして、「aaa」と書いていませんか？");
                s.Newline();

                s.AppendI(1, "・ヒント：数値が大きすぎた場合もここに来ます。");
                s.Newline();

                s.AppendI(1, "sExpectedValue=[");
                s.Append(sValue_Expected);
                s.Append("]");
                s.Newline();
                s.Newline();

                //
                // ヒント
                parent_Query.ToText_Locationbreadcrumbs(s);

                s.AppendI(0, "</Select_KeyIntImplクラス>");
                s.Newline();

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
