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
            this.sName_SubFolder = "";
            this.nBackupKeptbackups = 0;

            Givechapterandverse_Node s_ParentNode_Null = null;
            this.givechapterandverse_SName_SubFolder = new Givechapterandverse_NodeImpl(NamesNode.S_F_SET_VAR, s_ParentNode_Null);
            this.givechapterandverse_BackupKeptbackups = new Givechapterandverse_NodeImpl(NamesNode.S_F_SET_VAR, s_ParentNode_Null);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sName_SubFolder;

        /// <summary>
        /// バックアップ・フォルダーのサブ名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
        /// </summary>
        public string SName_SubFolder
        {
            set
            {
                sName_SubFolder = value;
            }
            get
            {
                return sName_SubFolder;
            }
        }

        //────────────────────────────────────────

        private int nBackupKeptbackups;

        /// <summary>
        /// 取り置きするバックアップ・フォルダーの数。1日1回バックアップを取っているのなら、10 に設定すれば、10日分のバックアップが取り置きされることになります。
        /// </summary>
        public int NBackupKeptbackups
        {
            set
            {
                nBackupKeptbackups = value;
            }
            get
            {
                return nBackupKeptbackups;
            }
        }

        //────────────────────────────────────────

        private Givechapterandverse_Node givechapterandverse_SName_SubFolder;

        /// <summary>
        /// バックアップ・フォルダーのサブ名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
        /// </summary>
        public Givechapterandverse_Node Givechapterandverse_SName_SubFolder
        {
            set
            {
                givechapterandverse_SName_SubFolder = value;
            }
            get
            {
                return givechapterandverse_SName_SubFolder;
            }
        }

        //────────────────────────────────────────

        private Givechapterandverse_Node givechapterandverse_BackupKeptbackups;

        /// <summary>
        /// 取り置きするバックアップ・フォルダーの数。1日1回バックアップを取っているのなら、10 に設定すれば、10日分のバックアップが取り置きされることになります。
        /// </summary>
        public Givechapterandverse_Node Givechapterandverse_BackupKeptbackups
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
