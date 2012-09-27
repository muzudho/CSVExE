using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//WarningReports, HumanInputFilePath

using Xenon.Table;//OTableImpl


namespace Xenon.Table
{
    /// <summary>
    /// XenonTableを作成します。
    /// 
    /// 他の Readメソッドの説明文参照。
    /// </summary>
    public class CsvTo_XenonTableImpl
    {



        #region 用意
        //────────────────────────────────────────

        public const string S_WRITE_ONLY = "WriteOnly";

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// パーサーのハブ。
        /// 
        /// </summary>
        /// <param name="request_ReadsTable">テーブルに付けたい名前や、ファイルパスの要求。</param>
        /// <param name="xenonTableFormat_puts">テーブルの行列が逆になっているなどの、設定。</param>
        /// <param name="bRequired">テーブルが無かった場合、エラーとするなら真。</param>
        /// <param name="out_sErrorMsg"></param>
        /// <returns></returns>
        public XenonTable Read(
            Request_ReadsTable request_ReadsTable,
            XenonTableformat xenonTableFormat_puts,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.SName_Library, this, "Read",log_Reports);



            XenonTable xenonTable_Result;

            string sFpatha_Csv = request_ReadsTable.Expression_Filepath.Execute_OnExpressionString(
                Request_SelectingImpl.Unconstraint, log_Reports);
            if (!log_Reports.BSuccessful)
            {
                // 既エラー。
                xenonTable_Result = null;
                goto gt_EndMethod;
            }

            string sCsv;

            // CSVテキスト
            Exception err_Excp;
            if (CsvTo_XenonTableImpl.S_WRITE_ONLY!=request_ReadsTable.SUse)
            {
                // 書き出し専用でなければ。
                // ファイル読取を実行します。

                try
                {
                    if (!System.IO.File.Exists(sFpatha_Csv))
                    {
                        // ファイルが存在しない場合。
                        xenonTable_Result = null;
                        goto gt_Error_NotExistsFile;
                    }

                    // TODO:IOException 別スレッドで開いているときなど。
                    sCsv = System.IO.File.ReadAllText(sFpatha_Csv, Encoding.Default);
                }
                catch (System.IO.IOException e)
                {
                    // エラー処理。
                    xenonTable_Result = null;
                    sCsv = "";
                    err_Excp = e;
                    goto gt_Error_FileOpen;
                }
                catch (Exception e)
                {
                    // エラー処理。
                    xenonTable_Result = null;
                    sCsv = "";
                    err_Excp = e;
                    goto gt_Error_Exception;
                }
            }
            else
            {
                sCsv = "";
            }

            xenonTable_Result = this.Read(
                sCsv,
                request_ReadsTable,
                xenonTableFormat_puts,
                log_Reports
                );
            if (!log_Reports.BSuccessful)
            {
                // 既エラー。
                goto gt_EndMethod;
            }

            // NOフィールドの値を 0からの連番に振りなおします。
            xenonTable_Result.RenumberingNoField();

            if (bRequired && null == xenonTable_Result)
            {
                goto gt_Error_NullTable;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_FileOpen:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("Er:201;", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("ファイルの読取りに失敗しました。");
                s.NewLine();
                s.NewLine();

                s.Append("　ファイル=[");
                s.Append(sFpatha_Csv);
                s.Append("]");
                s.NewLine();
                s.NewLine();

                s.Append("もしかして？");
                s.NewLine();

                s.Append("　・ファイルの有無、ファイル名、ファイル パスを確認してください。");
                s.NewLine();
                s.Append("　・別アプリケーションで　ファイルを開いていれば、閉じてください。");
                s.NewLine();
                s.NewLine();

                //
                // ヒント
                request_ReadsTable.Expression_Filepath.Cur_Givechapterandverse.ToText_Path(s);
                s.Append(err_Excp.Message);

                r.SMessage = s.ToString();

                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotExistsFile:
            if(log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー234！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定されたファイルはありませんでした。CSVファイルを読み込もうとしたとき。");
                s.NewLine();
                s.NewLine();

                s.AppendI(1,"指定されたファイルパス=[");
                s.Append(sFpatha_Csv);
                s.Append("]");
                s.NewLine();

                if ("" == request_ReadsTable.Expression_Filepath.SDirectory_Base)
                {
                    s.AppendI(1, "ベース・ディレクトリは指定されていません。");
                    s.NewLine();
                    s.AppendI(2,"もし相対パスが指定されていた場合、実行した.exeファイルからの相対パスとします。");
                    s.NewLine();
                    s.NewLine();
                }
                else
                {
                    s.AppendI(1, "指定されたベース・ディレクトリ=[");
                    s.Append(request_ReadsTable.Expression_Filepath.SDirectory_Base);
                    s.Append("]");
                    s.NewLine();
                    s.NewLine();
                }
                

                s.Append("　ヒント：ファイルの有無、ファイル名、ファイル パスを確認してください。");
                s.NewLine();

                // ヒント
                s.Append(r.Message_Givechapterandverse(request_ReadsTable.Expression_Filepath.Cur_Givechapterandverse));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー104！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("▲エラー4030！(" + Info_Table.SName_Library + ")");
                s.NewLine();
                s.Append("CSV読み取り中にエラーが発生しました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("指定CSVファイル=[");
                s.Append(sFpatha_Csv);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                //
                // ヒント
                request_ReadsTable.Expression_Filepath.Cur_Givechapterandverse.ToText_Path(s);


                s.Append("エラーの種類：");
                s.Append(err_Excp.GetType().Name);
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("エラーメッセージ：");
                s.Append(err_Excp.Message);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullTable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー105！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("▲エラー131！");
                s.NewLine();
                s.Append("[");
                s.Append(request_ReadsTable.SName_PutToTable);
                s.Append("]テーブルがありませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

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
            return xenonTable_Result;
        }

        //────────────────────────────────────────
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sText_Csv"></param>
        /// <param name="request_ReadsTable"></param>
        /// <param name="xenonTableFormat_puts"></param>
        /// <param name="out_SErrorMsg"></param>
        /// <returns></returns>
        public XenonTable Read(
            string sText_Csv,
            Request_ReadsTable request_ReadsTable,
            XenonTableformat xenonTableFormat_puts,
            Log_Reports log_Reports
            )
        {

            XenonTable o_Result;

            if (xenonTableFormat_puts.BRowcolumnreverse)
            {
                //
                // 縦、横がひっくりかえっているCSVテーブルを読み込みます。
                //

                if (xenonTableFormat_puts.BAllintfields)
                {
                    //
                    // 型定義のレコードがなく、全てのフィールドがint型のCSVテーブルを読み込みます。
                    //

                    CsvTo_XenonTableReverseAllIntsImpl csvTo = new CsvTo_XenonTableReverseAllIntsImpl();

                    XenonTable xenonTable = csvTo.Read(
                        sText_Csv,
                        request_ReadsTable,
                        xenonTableFormat_puts,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        o_Result = null;
                        goto gt_EndMethod;
                    }

                    o_Result = xenonTable;
                }
                else
                {
                    CsvTo_XenonTableReverseImpl csvTo = new CsvTo_XenonTableReverseImpl();

                    XenonTable xenonTable = csvTo.Read(
                        sText_Csv,
                        request_ReadsTable,
                        xenonTableFormat_puts,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        o_Result = null;

                        goto gt_EndMethod;
                    }

                    o_Result = xenonTable;
                }
            }
            else
            {
                //
                // 縦、横そのままのCSVテーブルを読み込みます。
                //
                CsvTo_XenonTableNormalImpl csvTo = new CsvTo_XenonTableNormalImpl();

                XenonTable xenonTable = csvTo.Read(
                    sText_Csv,
                    request_ReadsTable,
                    xenonTableFormat_puts,
                    log_Reports
                    );
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    o_Result = null;

                    goto gt_EndMethod;
                }

                o_Result = xenonTable;
            }

            goto gt_EndMethod;

            //
            //
            //
            //
        gt_EndMethod:
            return o_Result;
        }

        //────────────────────────────────────────
        #endregion



    }
}
