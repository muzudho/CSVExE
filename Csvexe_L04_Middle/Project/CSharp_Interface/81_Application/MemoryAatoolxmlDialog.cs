using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Xenon.Middle
{

    /// <summary>
    /// ツール設定ファイル・ダイアログ。
    /// </summary>
    public interface MemoryAatoolxmlDialog
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 選択しているエディター名
        /// </summary>
        string Name_SelectedEditor
        {
            get;
            set;
        }

        /// <summary>
        /// ツール設定ファイル モデル。
        /// </summary>
        MemoryAatoolxml MemoryAatoolxml
        {
            get;
            set;
        }

        /// <summary>
        /// エディター設定ファイルのリスト。
        /// </summary>
        Dictionary_Fsetvar_Configurationtree Dictionary_Editor
        {
            get;
            set;
        }

        /// <summary>
        /// このファイアログを開いているアプリケーションの名前
        /// </summary>
        string Name_Application
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
