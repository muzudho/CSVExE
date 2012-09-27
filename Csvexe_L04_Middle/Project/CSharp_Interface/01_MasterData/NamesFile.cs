using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Middle
{



    /// <summary>
    /// ファイル名。またはフォルダー名。
    /// </summary>
    public abstract class NamesFile
    {



        #region 用意
        //────────────────────────────────────────
        //
        // Aa　（名前順で先頭に来る）
        //

        /// <summary>
        /// エディター設定ファイル
        /// </summary>
        public const string S_AA_EDITOR_XML = "Aa_Editor.xml";

        /// <summary>
        /// 共有素材フォルダー
        /// </summary>
        public const string S_AA_CONTENTS = "Aa_Contents";

        /// <summary>
        /// ファイルパス設定ファイル
        /// </summary>
        public const string S_AA_FILES_CSV = "Aa_Files.csv";

        //────────────────────────────────────────

        public const string S_ENGINE = "Engine";

        public const string S_FORMS = "Forms";

        public const string S_LOGS = "Logs";

        //────────────────────────────────────────
        //
        // ログ・ファイル名
        //

        public const string S_LOG_VARIABLES = "Log_Variables.csv";

        public const string S_SAVE_VARIABLES = "Save_Variables.csv";

        /// <summary>
        /// TODO:レイアウト・テーブルは複数個あるが？
        /// </summary>
        public const string S_LOG_FORM = "Log_Form.csv";

        /// <summary>
        /// TODO:レイアウト・テーブルは複数個あるが？
        /// </summary>
        public const string S_SAVE_FORM = "Save_Form.csv";

        //────────────────────────────────────────
        #endregion



    }
}
