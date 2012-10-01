using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{
    /// <summary>
    /// 『ユーザーフォーム・テーブル設定ファイル』の内容。
    /// </summary>
    public interface TableUserformconfig
    {



        #region プロパティー
        //────────────────────────────────────────

        string Name_Table
        {
            get;
            set;
        }

        List<RecordUserformconfig> List_RecordUserformconfig
        {
            get;
            set;
        }

        /// <summary>
        /// 親要素。
        /// </summary>
        Configurationtree_Node Cur_Configurationtree
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
