using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.MiddleImpl
{
    public class MemoryBackupImpl : MemoryBackup
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryBackupImpl()
        {
            this.Clear();
        }

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear()
        {
            this.name_SubFolder = "";
            this.backupKeptbackups = 0;

            Configurationtree_Node s_ParentNode_Null = null;
            this.givechapterandverse_Name_SubFolder = new Configurationtree_NodeImpl(NamesNode.S_F_SET_VAR, s_ParentNode_Null);
            this.givechapterandverse_BackupKeptbackups = new Configurationtree_NodeImpl(NamesNode.S_F_SET_VAR, s_ParentNode_Null);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string name_SubFolder;

        /// <summary>
        /// バックアップ・フォルダーのサブ名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
        /// </summary>
        public string Name_SubFolder
        {
            set
            {
                name_SubFolder = value;
            }
            get
            {
                return name_SubFolder;
            }
        }

        //────────────────────────────────────────

        private int backupKeptbackups;

        /// <summary>
        /// 取り置きするバックアップ・フォルダーの数。1日1回バックアップを取っているのなら、10 に設定すれば、10日分のバックアップが取り置きされることになります。
        /// </summary>
        public int BackupKeptbackups
        {
            set
            {
                backupKeptbackups = value;
            }
            get
            {
                return backupKeptbackups;
            }
        }

        //────────────────────────────────────────

        private Configurationtree_Node givechapterandverse_Name_SubFolder;

        /// <summary>
        /// バックアップ・フォルダーのサブ名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
        /// </summary>
        public Configurationtree_Node Configurationtree_Name_SubFolder
        {
            set
            {
                givechapterandverse_Name_SubFolder = value;
            }
            get
            {
                return givechapterandverse_Name_SubFolder;
            }
        }

        //────────────────────────────────────────

        private Configurationtree_Node givechapterandverse_BackupKeptbackups;

        /// <summary>
        /// 取り置きするバックアップ・フォルダーの数。1日1回バックアップを取っているのなら、10 に設定すれば、10日分のバックアップが取り置きされることになります。
        /// </summary>
        public Configurationtree_Node Configurationtree_BackupKeptbackups
        {
            set
            {
                givechapterandverse_BackupKeptbackups = value;
            }
            get
            {
                return givechapterandverse_BackupKeptbackups;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
