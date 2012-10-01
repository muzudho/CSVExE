//
// Cushion
//
// アプリケーションを作るうえで、よく使うことになるもの。
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{
    /// <summary>
    /// ファイル・パス。
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
    public interface Expression_Node_Filepath : Expression_Node_String
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 相対パスが設定されていた場合、その相対元となるディレクトリーへのパスです。
        /// そうでない場合は、System.Windows.Forms.StartupPath を入れてください。
        /// </summary>
        /// <param name="newDirectoryPath"></param>
        void SetDirectory_Base(
            string sFopath_New,
            Log_Reports log_Reports
            );

        /// <summary>
        /// 設定ファイルに記述されているままのファイル・パス表記。
        /// 
        /// 相対パス、絶対パスのどちらでも構わない。
        /// 
        /// 例："Data\\Monster.csv"
        /// </summary>
        /// <param name="sFpath_NewHumaninput"></param>
        void SetHumaninput(
            string sFpath_NewHumaninput,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 相対パスが設定されていた場合、その相対元となるディレクトリーへのパスです。
        /// そうでない場合は、System.Windows.Forms.StartupPath を入れてください。
        /// 
        /// ※「set」は外してある。プログラム中でセットしている場所を検索しやすいように別メソッドにしてある。
        /// </summary>
        string Directory_Base
        {
            get;
        }

        /// <summary>
        /// 設定ファイルに記述されているままのファイル・パス表記。
        /// 
        /// 相対パス、絶対パスのどちらでも構わない。
        /// 
        /// 例："Data\\Monster.csv"
        /// 
        /// ※「set」は外してある。プログラム中でセットしている場所を検索しやすいように別メソッドにしてある。
        /// </summary>
        /// <returns></returns>
        string Humaninput
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
