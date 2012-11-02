using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;

namespace Xenon.Middle
{
    public abstract class ValuesAttr
    {



        #region 用意
        //────────────────────────────────────────
        //
        // バージョン。
        //

        /// <summary>
        /// 現状の、ＣＳＶＥｘＥのバージョン
        /// </summary>
        public const string S_VERSION_CSVEXE = "R4-003";

        /// <summary>
        /// 現状の、コードファイル・バージョン値
        /// </summary>
        public const string S_VERSION_CODEFILE = "2.0";

        //────────────────────────────────────────
        //
        // ツール設定ファイルへの相対ファイルパス（特別）
        //

        /// <summary>
        /// ツール設定ファイルへの相対ファイルパス。
        /// </summary>
        public const string S_FPATHR_AATOOLXML = "config-csveditor/Aa_Tool.xml";

        //────────────────────────────────────────
        //
        // 属性値
        //

        /// <summary>
        /// ＜ｄａｔａ　ａｃｃｅｓｓ＝”☆”＞用。
        /// Ｓｆ：ｃｅｌｌ；でも使う。
        /// </summary>
        public const string S_FROM = "from";

        /// <summary>
        /// ＜ｄａｔａ　ａｃｃｅｓｓ＝”☆”＞用。
        /// </summary>
        public const string S_TO = "to";

        /// <summary>
        /// Ｓｆ：ｃｅｌｌ；用
        /// </summary>
        public const string S_SELECT = "select";

        /// <summary>
        /// ＜ｄａｔａ　ｍｅｍｏｒｙ＝”☆”＞用。
        /// </summary>
        public const string S_NONE = "none";

        /// <summary>
        /// ＜ｄａｔａ　ｍｅｍｏｒｙ＝”☆”＞用。
        /// </summary>
        public const string S_CELL = "cell";

        /// <summary>
        /// ＜ｄａｔａ　ｍｅｍｏｒｙ＝”☆”＞用。
        /// </summary>
        public const string S_RECORDS = "records";

        /// <summary>
        /// ＜ｄａｔａ　ｍｅｍｏｒｙ＝”☆”＞用。
        /// </summary>
        public const string S_VARIABLE = "variable";

        //────────────────────────────────────────
        //
        // 三値ブール
        //      旧型：On,Off,""
        //      新型：Yes,No,Ignore

        public const string S_ON = "On";

        public const string S_OFF = "Off";

        public const string S_YES = "Yes";

        public const string S_NO = "No";

        public const string S_IGNORE = "Ignore";

        //────────────────────────────────────────
        //
        // チェックボックスの値の型
        //

        public const string S_ZERO_ONE = "ZERO_ONE";

        public const string S_BOOL = "BOOL";

        //────────────────────────────────────────
        //
        // スクロールバー
        //

        public const string S_BOTH = "BOTH";

        public const string S_HORIZONTAL = "HORIZONTAL";

        public const string S_VERTICAL = "VERTICAL";

        // "NONE";

        //────────────────────────────────────────
        //
        // 汎用。
        //

        /// <summary>
        /// 空文字列。
        /// </summary>
        public const string S_EMPTY = "";

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// (code file verseion)
        /// </summary>
        /// <param name="sCodefileVersion"></param>
        /// <param name="pg_Loggin"></param>
        /// <param name="gcav_Codefile"></param>
        /// <param name="info_Name_Node"></param>
        public static void Test_Codefileversion(
            string sCodefileVersion,
            Log_Reports pg_Loggin,
            Configurationtree_Node gcav_Codefile,
            string info_Name_Node
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Middle.Name_Library, "ValuesAttr", "Test_CodefileVersion",pg_Loggin);


            double nNow;
            bool bSuccessful = double.TryParse(ValuesAttr.S_VERSION_CODEFILE, out nNow);

            double nFile = 0.0;
            if (bSuccessful)
            {
                bSuccessful = double.TryParse(sCodefileVersion, out nFile);
            }
            else
            {
                goto gt_Error_Parse;
            }

            if (!bSuccessful)
            {
                //エラー
                goto gt_Error_Parse;
            }


            if (bSuccessful)
            {
                if (nNow < nFile)
                {
                    // 未来のバージョンの場合。
                    goto gt_Error_FutureVersion;
                }

                if(1.0 <= (Math.Floor(nNow) - Math.Floor(nFile)))
                {
                    // メジャーバージョンが１以上古かった場合。
                    goto gt_Error_OldMajor;
                }

            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_OldMajor:
            if (pg_Loggin.CanCreateReport)
            {
                Log_RecordReports r = pg_Loggin.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー41！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定のスクリプトファイルは、メジャーバージョンが古くて読めないバージョンでした。");
                s.Newline();
                s.Append("　　スクリプトファイルのバージョン=[");
                s.Append(sCodefileVersion);
                s.Append("]");
                s.Newline();
                s.Append("　　このアプリケーションのバージョン=[");
                s.Append(ValuesAttr.S_VERSION_CODEFILE);
                s.Append("]");
                s.Newline();
                s.Newline();

                //ヒント
                s.Append(r.Message_Configuration(gcav_Codefile));

                r.Message = s.ToString();
                pg_Loggin.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_FutureVersion:
            if (pg_Loggin.CanCreateReport)
            {
                Log_RecordReports r = pg_Loggin.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー41！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定のスクリプトファイルは、このアプリケーションより新しくて読めないバージョンでした。");
                s.Newline();
                s.Append("　　スクリプトファイルのバージョン=[");
                s.Append(sCodefileVersion);
                s.Append("]");
                s.Newline();
                s.Append("　　このアプリケーションのバージョン=[");
                s.Append(ValuesAttr.S_VERSION_CODEFILE);
                s.Append("]");
                s.Newline();
                s.Newline();

                //ヒント
                s.Append(r.Message_Configuration(gcav_Codefile));

                r.Message = s.ToString();
                pg_Loggin.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Parse:
            if (pg_Loggin.CanCreateReport)
            {
                Log_RecordReports r = pg_Loggin.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー41！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定のスクリプトファイルの、バージョンを読み取れませんでした。");
                s.Newline();
                s.Newline();
                s.Append("　　スクリプトファイルに書かれていたバージョン表記=[");
                s.Append(sCodefileVersion);
                s.Append("]");
                s.Newline();
                s.Append("　　期待する書き方の例： <");
                s.Append(info_Name_Node);
                s.Append(" ");
                s.Append(PmNames.S_CODEFILE_VERSION.Name_Attribute);
                s.Append("=\"");
                s.Append(ValuesAttr.S_VERSION_CODEFILE);
                s.Append("\">");
                s.Newline();
                s.Newline();

                //ヒント
                s.Append(r.Message_Configuration(gcav_Codefile));

                r.Message = s.ToString();
                pg_Loggin.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Loggin);
        }

        //────────────────────────────────────────
        #endregion



    }
}
