using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{
    public interface MemoryBackup
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        void Clear(object/*MemoryApplication*/ owner_MemoryApplication);//, Log_Reports log_Reports

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────
        //
        // バックアップ関連
        //

        /// <summary>
        /// バックアップ・フォルダーのサブ名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
        /// </summary>
        string Name_SubFolder
        {
            set;
            get;
        }

        /// <summary>
        /// 取り置きするバックアップ・フォルダーの数。1日1回バックアップを取っているのなら、10 に設定すれば、10日分のバックアップが取り置きされることになります。
        /// </summary>
        int BackupKeptbackups
        {
            set;
            get;
        }

        /// <summary>
        /// バックアップ・フォルダーのサブ名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
        /// </summary>
        Configurationtree_Node Configurationtree_Name_SubFolder
        {
            set;
            get;
        }

        /// <summary>
        /// 取り置きするバックアップ・フォルダーの数。1日1回バックアップを取っているのなら、10 に設定すれば、10日分のバックアップが取り置きされることになります。
        /// </summary>
        Configurationtree_Node Configurationtree_BackupKeptbackups
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
