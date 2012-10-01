using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//N_FilePath

namespace Xenon.Operating
{
    /// <summary>
    /// GlobalList.txtを読み取ります。
    /// </summary>
    public class GloballistAction00001
    {
        public MemoryGloballist Perform(
            Expression_Node_Filepath expr_Fpath_GloballistText,
            Encoding encoding,
            Log_Reports log_Reports,
            string sRunningHintName
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Operating.Name_Library, this, "Perform",log_Reports);

            MemoryGloballist moGl = new MemoryGloballistImpl();

            string sFpatha = expr_Fpath_GloballistText.Execute_OnExpressionString(
                Request_SelectingImpl.Unconstraint, log_Reports);//絶対ファイルパス
            if (!log_Reports.Successful)
            {
                // 既エラー。
                goto gt_EndMethod;
            }

            if ("" == sFpatha)
            {
                // グローバルリスト ファイルへのパスが空文字列だった場合
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー080011！", pg_Method);
                    r.Message = "グローバルリスト ファイルへのパスを指定してください。";
                    log_Reports.EndCreateReport();
                }
            }

            string sText1;
            if (log_Reports.Successful)
            {
                // 正常時

                // テキスト読取り
                try
                {
                    sText1 = System.IO.File.ReadAllText(sFpatha, encoding);
                }
                catch(Exception ex)
                {
                    sText1 = null;
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー0800023！", pg_Method);

                        StringBuilder t = new StringBuilder();
                        t.Append("ファイルの読み取りに失敗しました。");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("ファイルパス=[");
                        t.Append(sFpatha);
                        t.Append("]");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("エンコーディング=[");
                        t.Append(encoding.ToString());
                        t.Append("]");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("例外：[");
                        t.Append(ex.GetType().Name);
                        t.Append("]：");
                        t.Append(ex.Message);

                        r.Message = t.ToString();

                        log_Reports.EndCreateReport();
                    }
                }
            }
            else
            {
                // エラー時
                sText1 = null;
            }

            if (log_Reports.Successful)
            {
                // 正常時

                // テキストをストリーム化します。
                System.IO.StringReader reader = new System.IO.StringReader(sText1);

                while (-1 < reader.Peek())
                {
                    string sLine = reader.ReadLine();

                    string parent_SNode = sFpatha;
                    MemoryGloballistLine modelOfGlLine = this.Sub_ParseLine(sLine, log_Reports, parent_SNode);

                    if (log_Reports.Successful)
                    {
                        // 正常時

                        moGl.AddLine(modelOfGlLine);
                    }
                }
                // ストリームを閉じます。
                reader.Close();
            }

            //
            //
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return moGl;
        } 

        /// <summary>
        /// グローバルリストの1行相当のデータの内容を解析します。
        /// </summary>
        /// <param name="line"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public MemoryGloballistLine Sub_ParseLine(string sLine, Log_Reports log_Reports, string parent_SNode)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Operating.Name_Library, this, "Sub_ParseLine",log_Reports);

            MemoryGloballistLineImpl moGlLine = new MemoryGloballistLineImpl();

            // 最初の「:」の位置
            int nColonIndex = sLine.IndexOf(':');

            if (nColonIndex<0)
            {
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー0800871！", pg_Method);

                    StringBuilder t = new StringBuilder();
                    t.Append("「:」が含まれていませんでした。");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);
                    t.Append("行内容=[");
                    t.Append(sLine);
                    t.Append("]");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);
                    t.Append("もしかすると：");
                    t.Append(Environment.NewLine);
                    t.Append("　　・単に「:」が含まれていない？");
                    t.Append(Environment.NewLine);
                    t.Append("　　・ファイルの文字エンコーディングの指定が間違っていて文字化けしており、正しく読めていない？");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);
                    t.Append("推定問題箇所=[");
                    t.Append(parent_SNode);
                    t.Append("]");
                    r.Message = t.ToString();
                    log_Reports.EndCreateReport();
                }
            }

            string sToken1;
            int nCommaIndex;
            if (log_Reports.Successful)
            {
                // 正常時

                // 第二引数は length
                sToken1 = sLine.Substring(0, nColonIndex);
                int nSecondIndex = nColonIndex + 1;
                moGlLine.Text = sLine.Substring(nSecondIndex, sLine.Length - nSecondIndex);

                // 「[I],1」といった書式の「,」の位置。
                nCommaIndex = sToken1.IndexOf(',');

                if (nCommaIndex < 0)
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー872！", pg_Method);
                        r.Message = "行内容[" + sLine + "]の[" + sToken1 + "]部分に、「,」が含まれていませんでした。";
                        log_Reports.EndCreateReport();
                    }
                }
            }
            else
            {
                // エラー処理。

                sToken1 = "";
                nCommaIndex = -1;
            }

            if (log_Reports.Successful)
            {
                // 正常時

                moGlLine.Name_Type = sToken1.Substring(0, nCommaIndex);

                int nSecondIndex = nCommaIndex + 1;
                string sNumber = sToken1.Substring(nSecondIndex, sToken1.Length - nSecondIndex);

                int nGlLine;
                if (!int.TryParse(sNumber, out nGlLine))
                {
                    // エラー
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー878！", pg_Method);
                        r.Message = "変数番号[" + sNumber + "]を、int型の数値に変換できませんでした。";
                        log_Reports.EndCreateReport();
                    }
                }
                else
                {
                    moGlLine.Number = nGlLine;
                }
            }

            goto gt_EndMethod;

        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return moGlLine;
        }

    }
}
