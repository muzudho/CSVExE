using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Operating
{

    /// <summary>
    /// (date backup)
    /// </summary>
    public interface Datebackup
    {


        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// バックアップしたいファイルのパス一覧。
        /// (list expression file path request)
        /// </summary>
        List<Expression_Node_Filepath> List_Expression_Filepath_Request
        {
            get;
            set;
        }

        /// <summary>
        /// バックアップ・ホーム・フォルダー。
        /// (expression filepath backup home)
        /// </summary>
        Expression_Node_Filepath Expression_Filepath_Backuphome
        {
            get;
            set;
        }

        /// <summary>
        /// 保管する日付バックアップ・フォルダー数。
        /// (kept backups)
        /// </summary>
        int Keptbackups
        {
            set;
            get;
        }

        /// <summary>
        /// サブネーム。
        /// 例えば「20091203_yamada」の「yamada」に当たる文字列。アンダースコアは含まない。
        /// </summary>
        string Name_Sub
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
