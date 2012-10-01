﻿using System;
using System.Collections.Generic;
using System.IO;  //Path,Directory
using System.Linq;
using System.Text;

using System.Windows.Forms;//Application

namespace Xenon.Syntax
{

    /// <summary>
    /// ファイルパス。
    /// </summary>
    public class Configurationtree_NodeFilepathImpl : Configurationtree_NodeImpl, Configurationtree_NodeFilepath
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="sName_Node"></param>
        public Configurationtree_NodeFilepathImpl(string sName_Node, Configurationtree_Node parent_Gcav)
            : base(sName_Node, parent_Gcav)
        {
            this.humaninput = "";
            this.directory_Base = "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// パスを設定します。相対パス、絶対パスの違いを吸収するためのものです。
        /// </summary>
        /// <param name="sFopath_New">フォルダーパス。指定するものがない場合は、System.Windows.Forms.StartupPath を入れてください。</param>
        /// <param name="sFpath_Newhumaninput">ファイルパス。</param>
        public void InitPath(
            string sFopath_New,
            string sFpath_Newhumaninput,
            Log_Reports log_Reports
            )
        {
            // ダミー・フラグ。使いません。
            bool bDammyFlagCheckPathTooLong = false;

            if (log_Reports.Successful)
            {
                // チェック。絶対パスにすることができればOK。
                Utility_Configurationtree_Filepath.GetAbsolutefilepathimpl(
                    sFopath_New,
                    sFpath_Newhumaninput,
                    ref bDammyFlagCheckPathTooLong,
                    false,//ファイル名の長さが上限超過ならエラー
                    log_Reports,//out out_sErrorMsg,
                    this
                    );
            }

            if (log_Reports.Successful)
            {
                this.SetDirectory_Base(sFopath_New);
            }

            if (log_Reports.Successful)
            {
                this.SetHumaninput(
                    sFpath_Newhumaninput,
                    log_Reports
                    );
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            return;
        }

        //────────────────────────────────────────

        /// <summary>
        /// パスを設定します。相対パス、絶対パスの違いを吸収するためのものです。
        /// </summary>
        /// <param name="newDirectoryPath">指定するものがない場合は、System.Windows.Forms.StartupPath を入れてください。</param>
        /// <param name="newHumanInputFilePath"></param>
        public void InitPath(
            string sFpath_Newhumaninput,
            Log_Reports log_Reports
            )
        {
            this.InitPath(
                "",
                sFpath_Newhumaninput,
                log_Reports
                );
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override void ToText_Content(Log_TextIndented s)
        {
            s.Increment();


            s.AppendI(0, "<");
            s.Append(this.GetType().Name);
            s.Append("クラス>");
            s.Newline();

            //
            // 子要素なし。
            //

            //
            // メンバ変数
            //
            s.Append("ノード名=[");
            s.Append(this.Name);
            s.Append("]");
            s.Newline();

            s.Append("sBaseDirectory=[");
            s.Append(this.directory_Base);
            s.Append("]");
            s.Newline();

            s.Append("sHumanInput=[");
            s.Append(this.humaninput);
            s.Append("]");
            s.Newline();


            s.AppendI(0, "</");
            s.Append(this.GetType().Name);
            s.Append("クラス>");
            s.Newline();


            s.Decrement();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 人間が入力したままの、トリム等が行われていないテキスト。
        /// </summary>
        private string humaninput;

        /// <summary>
        /// 設定ファイルに記述されているままのファイル・パス表記。
        /// 
        /// 相対パス、絶対パスのどちらでも構わない。
        /// 
        /// 例："Data\\Monster.csv"
        /// </summary>
        /// <returns></returns>
        public string GetHumaninput()
        {
            return humaninput;
        }

        public void SetHumaninput(
            string sFpath_Newhumaninput,
            Log_Reports log_Reports
            )
        {
            // ダミー・フラグ。使いません。
            bool bDammyFlagCheckPathTooLong = false;

            if (log_Reports.Successful)
            {
                // チェック。絶対パスにすることができればOK。
                Utility_Configurationtree_Filepath.GetAbsolutefilepathimpl(
                    this.directory_Base,
                    sFpath_Newhumaninput,
                    ref bDammyFlagCheckPathTooLong,
                    false,//ファイル名の長さが上限超過ならエラー
                    log_Reports,//out out_sErrorMsg,
                    this.Parent
                );
            }

            if (log_Reports.Successful)
            {
                this.humaninput = sFpath_Newhumaninput;
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            return;
        }

        //────────────────────────────────────────

        private string directory_Base;

        /// <summary>
        /// 相対パスが設定されていた場合、その相対元となるディレクトリーへのパスです。
        /// そうでない場合は、System.Windows.Forms.StartupPath を入れてください。
        /// </summary>
        public string Directory_Base
        {
            get
            {
                return directory_Base;
            }
        }

        /// <summary>
        /// 初期化用。
        /// </summary>
        /// <param name="baseDirectory"></param>
        public void SetDirectory_Base(string sDirectory_Base)
        {
            this.directory_Base = sDirectory_Base;
        }

        //────────────────────────────────────────
        #endregion



    }
}