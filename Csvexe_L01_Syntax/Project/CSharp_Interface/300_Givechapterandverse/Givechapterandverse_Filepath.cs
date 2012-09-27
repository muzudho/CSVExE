﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{


    /// <summary>
    /// ファイルパス。相対パス、絶対パスの違いを吸収するためのものです。
    /// </summary>
    public interface Givechapterandverse_Filepath : Givechapterandverse_Node
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// パスを設定します。
        /// </summary>
        /// <param name="newHumanInputFilePath"></param>
        void InitPath(
            string sFpath_Newhumaninput,
            Log_Reports log_Reports
            );

        /// <summary>
        /// パスを設定します。
        /// </summary>
        /// <param name="newDirectoryPath">フォルダーのパス。</param>
        /// <param name="newHumanInputFilePath"></param>
        void InitPath(
            string sFopath_New,
            string sFpath_Newhumaninput,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 初期化用。
        /// </summary>
        /// <param name="sDirectory_Base"></param>
        void SetSDirectory_Base(string sDirectory_Base);

        /// <summary>
        /// 設定ファイルに記述されているままのファイル・パス表記。
        /// 
        /// 相対パス、絶対パスのどちらでも構わない。
        /// 
        /// 例："Data\\Monster.csv"
        /// </summary>
        /// <returns></returns>
        string GetSHumaninput();

        /// <summary>
        /// 設定ファイルに記述されているままのファイル・パス表記。
        /// 
        /// 相対パス、絶対パスのどちらでも構わない。
        /// 
        /// 例："Data\\Monster.csv"
        /// </summary>
        /// <param name="newHumanInputFilePath"></param>
        void SetSHumaninput(
            string sFpath_Newhumaninput,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 相対パスが設定されていた場合、その相対元となるディレクトリーへのパスです。
        /// そうでない場合は、System.Windows.Forms.StartupPath を入れてください。
        /// </summary>
        string SDirectory_Base
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
