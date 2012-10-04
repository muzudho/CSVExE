//
// Cushion
//
// アプリケーションを作るうえで、よく使うことになるもの。
//
using System;
using System.Collections.Generic;
using System.IO;  //Directory
using System.Linq;
using System.Text;
using System.Windows.Forms;//Application

namespace Xenon.Syntax
{
    /// <summary>
    /// ファイル・パス。
    /// 
    /// 人間オペレーターが設定ファイルなどに入力したファイルパスの記述そのままに保持。
    /// 
    /// 相対パス、絶対パスのどちらでも構いません。
    /// 
    /// 
    /// 備考1：
    /// ファイルパスに無効な値が含まれていることを事前にチェックするのは難しい。
    /// Windowsで作れないファイル名
    /// 「CON」「PRN」「AUX」「NUL」「COM0」～「COM9」「LPT0」～「LPT9」など。DOSのコマンド。
    /// これらを事前チェックで弾くのもローカル依存なので、例外でキャッチすること。
    /// 
    /// ファイル名として使えない文字は、
    /// 「filePath.IndexOfAny(Path.GetInvalidFileNameChars()) &lt; 0;」
    /// で確認可能。
    ///
    /// 備考2：
    ///
    /// パスは、文字列連結や変換の過程で「/」と「\」が混在することがあり、
    /// == を使った文字列比較では　一致を判定できない。
    ///
    /// </summary>
    public class Expression_Node_FilepathImpl : Expression_Leaf_StringImpl, Expression_Node_Filepath
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="s_Fpath"></param>
        public Expression_Node_FilepathImpl(Configurationtree_NodeFilepath fpath_Gcav)
            :base(null,fpath_Gcav)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 設定ファイルに記述されているままのファイル・パス表記。
        /// 
        /// 相対パス、絶対パスのどちらでも構わない。
        /// 
        /// 例："Data\\Monster.csv"
        /// </summary>
        /// <param name="newHumanInputFilePath"></param>
        public void SetHumaninput(
            string sFpath_Humaninput_New,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "SetSHumaninput",log_Reports);

            if (this.Cur_Configurationtree is Configurationtree_NodeFilepath)
            {
                ((Configurationtree_NodeFilepath)this.Cur_Configurationtree).SetHumaninput(
                sFpath_Humaninput_New,
                log_Reports
                );
            }
            else
            {
                // エラー。
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー902！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();
                    s.Append(Environment.NewLine);
                    s.Append("#SetSHumanInput:型が違います。[" + this.Cur_Configurationtree.GetType().Name + "]");

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 絶対パスを取得します。
        /// 
        /// 未設定の場合は、空文字列を返します。
        /// 
        /// ・ファイルパスとして利用できない文字や、予約語が含まれていると例外を投げます。
        /// ・絶対パスの文字列の長さが、ファイルシステムで使える制限を越えると例外を投げます。
        /// 
        /// 設定されたパスが相対パスだった場合に、ベース・パスが設定されていなければ、
        /// 起動「.exe」のあったパスが頭に付く。
        /// </summary>
        /// <returns></returns>
        public override string Execute_OnExpressionString(
            EnumHitcount request,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "Execute_OnEString",log_Reports);
            //
            //

            // 絶対パスにして返します。

            string sFpath;
            if (this.Cur_Configurationtree is Configurationtree_NodeFilepath)
            {
                Configurationtree_NodeFilepath cf_Fpath = (Configurationtree_NodeFilepath)this.Cur_Configurationtree;

                bool bCheckPathTooLong = false;

                if (log_Reports.Successful)
                {
                    sFpath = Utility_Configurationtree_Filepath.GetAbsolutefilepathimpl(
                        this.Directory_Base,
                        cf_Fpath.GetHumaninput(),//this.SHumanInput相当
                        ref bCheckPathTooLong, //ファイル名の長さチェックは、もう済んでいるものとして、行いません。
                        false,//ファイル名の長さが上限超過ならエラー
                        log_Reports,//out sErrorMsg,
                        this.Cur_Configurationtree
                        );
                }
                else
                {
                    sFpath = "";
                }
            }
            else
            {
                // エラー。
                sFpath = "";
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー901！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();
                    s.Append(Environment.NewLine);
                    s.Append("#GetSAbsoluteFilePath:型が違います。[" + this.Cur_Configurationtree.GetType().Name + "]");

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sFpath;
        }

        //────────────────────────────────────────

        /// <summary>
        /// このデータは、ファイルパス型だ、と想定して、ファイルパスを取得します。
        /// </summary>
        /// <returns></returns>
        public override Expression_Node_Filepath Execute_OnExpressionString_AsFilepath(
            EnumHitcount request,
            Log_Reports log_Reports
            )
        {
            return this;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 相対パスが設定されていた場合、その相対元となるディレクトリーへのパスです。
        /// そうでない場合は、System.Windows.Forms.StartupPath を入れてください。
        /// </summary>
        /// <param name="newDirectoryPath"></param>
        public void SetDirectory_Base(
            string sFolderpath_New,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "SetSDirectory_Base",log_Reports);

            // ダミー・フラグ。使いません。
            bool bDammyFlagCheckPathTooLong = false;

            if (this.Cur_Configurationtree is Configurationtree_NodeFilepath)
            {
                Configurationtree_NodeFilepath cf_Fpath = ((Configurationtree_NodeFilepath)this.Cur_Configurationtree);

                // チェック。絶対パスにすることができればOK。
                Utility_Configurationtree_Filepath.GetAbsolutefilepathimpl(
                    sFolderpath_New,
                    cf_Fpath.GetHumaninput(),
                    ref bDammyFlagCheckPathTooLong,
                    false,//ファイル名の長さが上限超過ならエラー
                    log_Reports,//out sErrorMsg,
                    this.Cur_Configurationtree
                    );
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                cf_Fpath.SetDirectory_Base(sFolderpath_New);
            }
            else
            {
                // エラー
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー903！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();
                    s.Append(Environment.NewLine);
                    s.Append("#GetSAbsoluteFilePath:型が違います。[" + this.Cur_Configurationtree.GetType().Name + "]");

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
            }

            //
        //
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 相対パスが設定されていた場合、その相対元となるディレクトリーへのパスです。
        /// そうでない場合は、System.Windows.Forms.StartupPath を入れてください。
        /// </summary>
        public string Directory_Base
        {
            get
            {
                string sResult;

                if (this.Cur_Configurationtree is Configurationtree_NodeFilepath)
                {
                    sResult = ((Configurationtree_NodeFilepath)this.Cur_Configurationtree).Directory_Base;
                }
                else
                {
                    // エラー。
                    sResult = "＜" + Info_Syntax.Name_Library + ":" + this.GetType().Name + "#SBaseDirectory:型が違います。[" + this.Cur_Configurationtree.GetType().Name+ "]＞";
                }

                return sResult;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 設定ファイルに記述されているままのファイル・パス表記。
        /// 
        /// 相対パス、絶対パスのどちらでも構わない。
        /// 
        /// 例："Data\\Monster.csv"
        /// </summary>
        /// <returns></returns>
        public string Humaninput
        {
            get
            {
                string sResult;

                if (this.Cur_Configurationtree is Configurationtree_NodeFilepath)
                {
                    sResult = ((Configurationtree_NodeFilepath)this.Cur_Configurationtree).GetHumaninput();
                }
                else
                {
                    // エラー。
                    sResult = "＜" + Info_Syntax.Name_Library + ":" + this.GetType().Name + "#GetString:型が違います。[" + this.Cur_Configurationtree.GetType().Name + "]＞";
                }

                return sResult;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
