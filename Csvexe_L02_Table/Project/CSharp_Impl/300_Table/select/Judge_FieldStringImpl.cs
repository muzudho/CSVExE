using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Xenon.Syntax;


namespace Xenon.Table
{
    public class Judge_FieldStringImpl
    {



        #region 判定
        //────────────────────────────────────────

        public void Judge(
            out bool bJudge,
            string sName_KeyField,
            string sValue_Expected,
            bool bRequired_ExpectedValue,//使ってない。
            DataRow row,
            Givechapterandverse_Node parent_Query,
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
                // 無い列名を指定した場合。
                if (!row.Table.Columns.Contains(sName_KeyField))
                {
                    // エラー
                    bJudge = false;
                    goto gt_Error_NothingKeyField;
                }

                XenonValue o_CellValue = (XenonValue)row[sName_KeyField];


                //
                // （５）キーが空欄なら、無視します。【文字列型フィールドのみ】
                //
                if (XenonValue_StringImpl.IsSpaces(o_CellValue))
                {
                    bJudge = false;
                    goto gt_EndMethod;
                }


                //
                // （６）この行の、キー_フィールドの値を取得。
                //
                string sKeyValue;
                bool bParsedSuccessful = XenonValue_StringImpl.TryParse(
                    o_CellValue,
                    out sKeyValue,
                    parent_Query.ToString(),//TODO:本当はテーブル名がいい。 xenonTable.SName,
                    sName_KeyField,
                    log_Method,
                    log_Reports);
                if (!log_Reports.Successful)
                {
                    // 既エラー
                    bJudge = false;
                    goto gt_EndMethod;
                }

                if (!bParsedSuccessful)
                {
                    // エラー
                    bJudge = false;
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport d_Report = log_Reports.BeginCreateReport(EnumReport.Error);
                        d_Report.SetTitle("▲エラー697！", log_Method);
                        d_Report.Message = "string型パース失敗。";
                        log_Reports.EndCreateReport();
                    }
                    goto gt_EndMethod;
                }



                // （８）該当行をレコードセットに追加。
                if (sKeyValue == sValue_Expected)
                {
                    bJudge = true;
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
        gt_Error_NothingKeyField:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー611！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("無い列名が指定されました。 sKeyFieldName=[" + sName_KeyField + "]");
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
