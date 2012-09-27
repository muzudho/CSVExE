using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Middle
{

    /// <summary>
    /// テーブルの列名。
    /// </summary>
    public abstract class NamesFld
    {



        #region 用意
        //────────────────────────────────────────
        //
        // ファイル・テーブル系
        //

        public const string S_TYPE_DATA = "TYPE_DATA";

        public const string S_DATE_BACKUP = "DATE_BACKUP";

        public const string S_USE = "USE";

        public const string S_ROW_COL_REV = "ROW_COL_REV";

        public const string S_ALL_INT_FIELDS = "ALL_INT_FIELDS";

        public const string S_COMMA_ENDING = "COMMA_ENDING";

        //────────────────────────────────────────
        //
        // よく使う系
        //

        public const string S_NO = "NO";

        public const string S_ID = "ID";

        /// <summary>
        /// 前習慣から小文字が含まれる。
        /// </summary>
        public const string S_EXPL = "Expl";

        public const string S_END = "END";

        //────────────────────────────────────────
        //
        // 独自実装系
        //

        /// <summary>
        /// スタイルシート・レコード番号
        /// </summary>
        public const string S_EXPL_SS = "EXPL-SS";

        //────────────────────────────────────────
        //
        // レイアウト・テーブル系
        //

        public const string S_TREE = "TREE";

        public const string S_NAME_FORM = "NAME_FORM";

        public const string S_NAME = "NAME";

        public const string S_SET_VAR_PATH = "SET_VAR_PATH";

        /// <summary>
        /// コントロールの型。
        /// </summary>
        public const string S_TYPE = "TYPE";

        public const string S_TEXT = "TEXT";

        public const string S_FOLDER = "FOLDER";

        public const string S_FILE = "FILE";

        public const string S_ENABLED = "ENABLED";

        public const string S_VISIBLE = "VISIBLE";

        public const string S_READ_ONLY = "READ_ONLY";

        public const string S_WORD_WRAP = "WORD_WRAP";

        public const string S_NEW_LINE = "NEW_LINE";

        public const string S_SCROLL_BARS = "SCROLL_BARS";

        public const string S_CHK_VALUE_TYPE = "CHK_VALUE_TYPE";

        public const string S_FONT_SIZE_PT = "FONT_SIZE_PT";

        public const string S_PIC_ZOOM = "PIC_ZOOM";

        public const string S_X_LT = "X_LT";

        public const string S_Y_LT = "Y_LT";

        public const string S_WIDTH = "WIDTH";

        public const string S_HEIGHT = "HEIGHT";

        public const string S_TAB_INDEX = "TAB_INDEX";

        public const string S_BACK_COLOR = "BACK_COLOR";

        //────────────────────────────────────────
        //
        // レイアウト・テーブル系
        //

        public const string S_VALUE = "VALUE";

        //────────────────────────────────────────
        //
        // レイアウト・テーブル（リスト）系
        //

        public const string S_NAME_REF = "NAME_REF";

        public const string S_ITEM_HEIGHT_PX = "ITEM_HEIGHT_PX";

        public const string S_ITEM_DISPLAY_FORMAT = "ITEM_DISPLAY_FORMAT";

        public const string S_LIST_VALUE_FIELD = "LIST_VALUE_FIELD";

        //────────────────────────────────────────
        #endregion



    }
}
