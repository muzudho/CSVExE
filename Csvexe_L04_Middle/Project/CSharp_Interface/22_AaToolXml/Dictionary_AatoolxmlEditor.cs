using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports

namespace Xenon.Middle
{
    /// <summary>
    /// ツール設定ファイルの、エディター要素の集まり。
    /// </summary>
    public interface Dictionary_AatoolxmlEditor
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// エディター要素を返します。該当がなければヌルを返します。
        /// </summary>
        /// <param name="inputName"></param>
        /// <param name="bRequired">該当がない場合にエラー扱いにするなら真</param>
        /// <returns></returns>
        MemoryAatoolxml_Editor GetEditorByName(
            string sProjectName,
            bool bRequired,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────

        /// <summary>
        /// 内容をデバッグ出力します。
        /// </summary>
        void CreateMessage_Debug(Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// input要素の連想配列。
        /// </summary>
        Dictionary<string, MemoryAatoolxml_Editor> Dictionary_Item
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 親要素。ツール設定ファイル・モデル。
        /// </summary>
        MemoryAatoolxml MemoryAatoolxml
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
