using System;
using System.Collections.Generic;
using System.IO;  //Directory, Path
using System.Linq;
using System.Text;
using System.Windows.Forms;//Application

namespace Xenon.Syntax
{
    public abstract class Utility_Configurationtree_Filepath
    {



        #region アクション
        //────────────────────────────────────────

        public static string GetAbsoluteFilePathImpl(
            string sHumaninput,
            ref bool bFlagCheckPathTooLong,
            bool bOkPathTooLong,
            Log_Reports log_Reports,
            Configurationtree_Node cur_Gcav
            )
        {
            string sResult;

            if (log_Reports.Successful)
            {
                sResult = Utility_Configurationtree_Filepath.GetAbsolutefilepathimpl(
                    "",
                    sHumaninput,
                    ref bFlagCheckPathTooLong,
                    bOkPathTooLong,
                    log_Reports,//out sErrorMsg,
                    cur_Gcav
                    );
            }
            else
            {
                sResult = "";
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            return sResult;
        }

        //────────────────────────────────────────

        public static string GetAbsolutefilepathimpl(
            Configurationtree_NodeFilepath fpath_Gcav,
            ref bool bFlagCheckPathTooLong,
            bool bOkPathTooLong,
            Log_Reports log_Reports
            )
        {
            string sResult;

            if (log_Reports.Successful)
            {
                sResult = Utility_Configurationtree_Filepath.GetAbsolutefilepathimpl(
                    "",
                    fpath_Gcav.GetHumaninput(),
                    ref bFlagCheckPathTooLong,
                    bOkPathTooLong,
                    log_Reports,//out sErrorMsg,
                    fpath_Gcav
                    );
            }
            else
            {
                sResult = "";
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            return sResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 絶対パスを取得します。
        /// 
        /// 未設定の場合は、空文字列を返します。
        /// ※bug:フォルダーパスの場合も空文字列になる？？
        /// 
        /// ・ファイルパスとして利用できない文字や、予約語が含まれていると例外を投げます。
        /// ・絶対パスの文字列の長さが、ファイルシステムで使える制限を越えると例外を投げます。
        /// 
        /// もし、設定されたパスが相対パスだった場合に、ベース・パスが設定されていなければ、
        /// 起動「.exe」のあったパスが頭に付く。
        /// </summary>
        /// <param name="baseDirectory"></param>
        /// <param name="humanInputText"></param>
        /// <param name="flagCheckPathTooLong">絶対パスの文字列の長さが、ファイルシステムで使える上限を超えていた場合に真、そうでない場合　偽にセットされます。</param>
        /// <param name="okPathTooLong">絶対パスの文字列の長さが、ファイルシステムで使える上限を超えていた場合に、「正常扱いにするなら」真、「エラー扱いにするなら」偽。</param>
        /// <param name="cur_Gcav">デバッグ用情報。人間オペレーターが修正するべき箇所などの情報。</param>
        /// <returns></returns>
        public static string GetAbsolutefilepathimpl(
            string sBaseDirectory,
            string sHumanInput,
            ref bool bFlagCheckPathTooLong,
            bool bOkPathTooLong,
            Log_Reports log_Reports,
            Configurationtree_Node cur_Gcav
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.Name_Library, "Utility_Configurationtree_Filepath", "GetAbsolutefilepathimpl", log_Reports);
            //
            //

            //
            // 修正履歴(2009-12-02)
            //
            // ・カレント・ディレクトリの移動を使ったコードを書いてはいけない。
            //   MS-DOSの名残り？
            //
            // ・起動「.exe」のディレクトリは Application.StartupPath で取得できる。
            //
            // ・備考：
            // System.IO.Directory.GetCurrentDirectory()は、
            // 「プロセスが開始されたディレクトリ」を返すので、
            // openFileDialogで開いたディレクトリを返すこともある。
            //
            // System.IO.Path.GetFullPath(path)も同じ。

            Exception err_Excp;

            string sResult_FilePath;//ファイルパス

            // フラグのクリアー。
            bFlagCheckPathTooLong = false;

            //
            // 人間がCSVファイルに記述しているファイル・パス。
            //
            // 「絶対パス」「相対パス」のどちらでも指定されます。
            //
            string sFpath_Src = sHumanInput.Trim();

            if ("" == sFpath_Src)
            {
                // 未設定の場合。
                sResult_FilePath = "";//ファイルパスとしては使えない文字列。
                goto gt_EndMethod;
            }

            // 「絶対パス」か、「相対パス」かを判断します。
            bool bPathRooted = Utility_Configurationtree_Filepath.IsRooted_Path(
                sFpath_Src,
                log_Reports
                );

            if (!log_Reports.Successful)
            {
                // 既エラー。
                sResult_FilePath = "";//ファイルパスとしては使えない文字列。
                goto gt_EndMethod;
            }

            if (!bPathRooted)
            {
                // 相対パスの場合

                // 「相対パス」に「ベース・ディレクトリー文字列」を連結して、「絶対パス」に変換します。

                if ("" != sBaseDirectory)
                {
                    // 相対パスの相対元となるディレクトリーが設定されていれば。

                    if (!sBaseDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    {
                        sFpath_Src = sBaseDirectory + Path.DirectorySeparatorChar + sFpath_Src;
                    }
                    else
                    {
                        sFpath_Src = sBaseDirectory + sFpath_Src;
                    }
                }
                else
                {
                    // 起動「.exe」のあったパスを、相対の元となるディレクトリーとします。

                    if (!sBaseDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    {
                        sFpath_Src = Application.StartupPath + Path.DirectorySeparatorChar + sFpath_Src;
                    }
                    else
                    {
                        sFpath_Src = Application.StartupPath + sFpath_Src;
                    }
                }
            }

            // ここで、パスは　絶対パスに変換されています。

            try
            {
                // カレントディレクトリは使わない。

                // 絶対パスの場合、GetFullPathを通す必要はないが、
                // ファイルパスに使えない文字列を判定するために、
                // 例外を返すメソッドを使っています。
                sResult_FilePath = System.IO.Path.GetFullPath(sFpath_Src);
            }
            catch (ArgumentException e)
            {
                // 指定のファイルパスに「*」など、ファイルパスとして使えない文字列が含まれていた場合など。

                sResult_FilePath = "";//ファイルパスとしては使えない文字列。

                err_Excp = e;
                goto gt_Error_ArgumentException;
            }
            catch (PathTooLongException e)
            {
                // ディレクトリーの文字数が、制限数を超えた場合などのエラー。

                sResult_FilePath = "";//ファイルパスとしては使えない文字列。

                if (bOkPathTooLong)
                {
                    // 正常処理扱いとします。

                }
                else
                {
                    // 異常扱いとします。

                    err_Excp = e;
                    goto gt_Error_PathTooLongException;
                }


                bFlagCheckPathTooLong = true;
            }
            catch (NotSupportedException e)
            {
                //パスのフォーマットが間違っているなどのエラー。
                sResult_FilePath = "";//ファイルパスとしては使えない文字列。
                err_Excp = e;
                goto gt_Error_NotSupportedException;
            }
            catch (Exception e)
            {
                // それ以外のエラー。
                sResult_FilePath = "";//ファイルパスとしては使えない文字列。
                err_Excp = e;
                goto gt_Error_Exception;
            }

            goto gt_EndMethod;
            //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_ArgumentException:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー107！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append(Environment.NewLine);
                s.Append("使えないファイルパスです。[");
                s.Append(sFpath_Src);
                s.Append("]　：");

                s.Append(err_Excp.Message);
                cur_Gcav.ToText_Locationbreadcrumbs(s);

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_PathTooLongException:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー108！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append(Environment.NewLine);
                s.Append("エラー 入力パス=[" + sFpath_Src + "]：(" + err_Excp.GetType().Name + ") ");

                s.Append(err_Excp.Message);
                cur_Gcav.ToText_Locationbreadcrumbs(s);

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotSupportedException:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー109！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append(Environment.NewLine);
                s.Append("ファイルパスが間違っているかもしれません。");
                s.Newline();
                s.AppendI(1,"入力パス=[" + sFpath_Src + "]");
                s.Newline();

                // ヒント
                s.Append(r.Message_SException(err_Excp));
                cur_Gcav.ToText_Locationbreadcrumbs(s);

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー109！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append(Environment.NewLine);
                s.Append("エラー 入力パス=[" + sFpath_Src + "]");
                s.Newline();

                // ヒント
                s.Append(r.Message_SException(err_Excp));
                cur_Gcav.ToText_Locationbreadcrumbs(s);

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
            return sResult_FilePath;
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// パスはルートかどうか。
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsRooted_Path(
            string sFilepath,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.Name_Library, "Utility_Configurationtree_Filepath", "IsRooted_Path", log_Reports);
            //
            //
            bool bPathRooted;

            Exception err_Excp;
            try
            {
                // 「絶対パス」か、「相対パス」かを判断します。
                bPathRooted = System.IO.Path.IsPathRooted(sFilepath);
            }
            catch (ArgumentException e)
            {
                // エラー
                err_Excp = e;
                goto gt_Error_MissInput;
            }

            goto gt_EndMethod;
            //
            //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_MissInput:
            bPathRooted = false;
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー211！", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("エラー 入力パス=[" + sFilepath + "]：(" + err_Excp.GetType().Name + ") ");
                sb.Append(err_Excp.Message);

                r.Message = sb.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return bPathRooted;
        }

        //────────────────────────────────────────

        public static bool IsPathTooLong(
            string sNewhumaninputfilepath,
            Log_Reports log_Reports,
            Configurationtree_Node cur_Gcav
            )
        {
            return Utility_Configurationtree_Filepath.IsPathTooLong(
                "",
                sNewhumaninputfilepath,
                log_Reports,// out sErrorMsg,
                cur_Gcav
                );
        }

        //────────────────────────────────────────

        /// <summary>
        /// 絶対パスが、ファイルシステムで使えるファイルパスの文字列の長さの制限を越えていれば真。
        /// </summary>
        /// <param name="newDirectoryPath">指定するものがない場合は、System.Windows.Forms.StartupPath を入れてください。</param>
        /// <param name="newHumanInputFilePath"></param>
        /// <param name="cur_Gcav"></param>
        public static bool IsPathTooLong(
            string sNewDirectoryPath,
            string sNewHumanInputFilepath,
            Log_Reports log_Reports,
            Configurationtree_Node cur_Gcav
            )
        {
            // フラグ。
            bool bFlagCheckPathTooLong = false;

            if (log_Reports.Successful)
            {
                // チェック。絶対パスにすることができればOK。
                Utility_Configurationtree_Filepath.GetAbsolutefilepathimpl(
                    sNewDirectoryPath,
                    sNewHumanInputFilepath,
                    ref bFlagCheckPathTooLong,
                    true,//ファイル名の長さが上限超過でも、正常処理扱いとします。
                    log_Reports,// out sErrorMsg,
                    cur_Gcav
                    );
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            return bFlagCheckPathTooLong;
        }

        //────────────────────────────────────────
        #endregion



    }
}
