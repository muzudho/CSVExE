using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Middle
{
    public abstract class NamesFnc
    {



        #region 用意
        //────────────────────────────────────────
        //
        // ユーザー定義関数
        //


        /// <summary>
        /// ｎａｍｅ＝”Ｕｆ：☆；”
        /// 
        /// ユーザー定義関数名の開始文字。
        /// </summary>
        public const string S_UF = "Uf:";

        //────────────────────────────────────────
        //
        // 基本
        //

        public const string S_VALUE_CONTROL = "Sf:Value-Control;";

        public const string S_TEXT_TEMPLATE = "Sf:TextTemplate;";

        //────────────────────────────────────────
        //
        // 制御
        //

        public const string S_SWITCH = "Sf:Switch;";

        public const string S_CASE = "Sf:Case;";

        //────────────────────────────────────────
        //
        // データベース
        //

        public const string S_CELL = "Sf:Cell;";

        public const string S_WHERE = "Sf:Where;";

        public const string S_REC_COND = "Sf:RecCond;";

        //────────────────────────────────────────
        //
        // バリデーター基本
        //

        /// <summary>
        /// バリデーター用。
        /// </summary>
        public const string S_VLD_SPACES = "Sf:Vld-Spaces;";

        /// <summary>
        /// バリデーター用。
        /// </summary>
        public const string S_VLD_INT_RANGE = "Sf:Vld-IntRange;";

        /// <summary>
        /// バリデーター用。
        /// </summary>
        public const string S_VLD_ALL = "Sf:Vld-All;";

        /// <summary>
        /// バリデーター用。
        /// </summary>
        public const string S_VLD_MATCH = "Sf:Vld-Match;";

        /// <summary>
        /// バリデーター用。　未使用？
        /// </summary>
        public const string S_VLD_DISPLAY = "Sf:Vld-Display;";

        //────────────────────────────────────────
        //
        // バリデーター　リストボックス用
        //

        /// <summary>
        /// リストボックス・バリデーター用。
        /// </summary>
        public const string S_VLD_ALL_FIELDS_IS_EMPTY = "Sf:Vld-AllFieldsIsEmpty;";

        /// <summary>
        /// リストボックス・バリデーター用。
        /// </summary>
        public const string S_VLD_SELECT_RECORD = "Sf:Vld-SelectRecord;";

        /// <summary>
        /// リストボックス・バリデーター用。
        /// </summary>
        public const string S_VLD_EMPTY_FIELD = "Sf:Vld-EmptyField;";

        //────────────────────────────────────────
        //
        // その他
        //

        public const string S_LISTBOX_LABELS = "Sf:ListboxLabels;";
        
        /// <summary>
        /// 未使用？
        /// </summary>
        public const string S_ALL_TRUE = "Sf:AllTrue;";





        /// <summary>
        /// </summary>
        public const string S_ITEM_LABEL2 = "Sf:ItemLabel;";

        /// <summary>
        /// 未使用？
        /// </summary>
        public const string S_ITEM_VALUE = "Sf:ItemValue;";

        /// <summary>
        /// 未使用？
        /// </summary>
        public const string S_ITEM_GRAY_OUT = "Sf:ItemGrayOut;";

        /// <summary>
        /// 未使用？
        /// </summary>
        public const string S_EMPTY_FIELD = "Sf:EmptyField;";

        /// <summary>
        /// 未使用？
        /// </summary>
        public const string S_RECORD_SET_SAVE_TO2 = "Sf:RecordSetSaveTo;";

        //────────────────────────────────────────
        #endregion



    }
}
