using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports

namespace Xenon.Middle
{
    /// <summary>
    /// エディター設定ファイル。
    /// (Aa_Editor.xml)
    /// </summary>
    public interface MemoryAaeditorxml
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        void Clear(MemoryApplication owner_MemoryApplication);

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────
        
        /// <summary>
        /// システム変数を、自動類推して、自動登録します。
        /// </summary>
        /// <param name="ec_Fopath_Editor"></param>
        /// <param name="log_Reports"></param>
        void Load_AutoSystemVariable(
            Expression_Node_Filepath ec_Fopath_Editor,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ファイル読み込み。
        /// </summary>
        /// <param name="ec_Fopath_Editor"></param>
        /// <param name="log_Reports"></param>
        void LoadFile(
            Expression_Node_Filepath ec_Fopath_Editor,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 利用者に、修正箇所を伝える情報。
        /// </summary>
        Configurationtree_Node Cur_Configurationtree
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 使ってる？
        /// エディター要素。
        /// </summary>
        MemoryAaeditorxml_Editor MemoryAaeditorxml_Editor
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
