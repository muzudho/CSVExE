using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Middle
{

    public abstract class NamesNode
    {



        #region 用意
        //────────────────────────────────────────
        //
        // スクリプトファイル系
        //

        /// <summary>
        /// ツール設定ファイル
        /// </summary>
        public const string S_CODEFILE_TOOL = "codefile-tool";

        /// <summary>
        /// エディター設定ファイル
        /// </summary>
        public const string S_CODEFILE_EDITOR = "codefile-editor";

        /// <summary>
        /// 関数登録ファイル
        /// </summary>
        public const string S_CODEFILE_FUNCTIONS = "codefile-functions";

        /// <summary>
        /// トゥゲザー登録ファイル
        /// </summary>
        public const string S_CODEFILE_TOGETHERS = "codefile-togethers";

        /// <summary>
        /// バリデーター登録ファイル
        /// </summary>
        public const string S_CODEFILE_VALIDATORS = "codefile-validators";

        /// <summary>
        /// コントロール設定ファイル
        /// </summary>
        public const string S_CODEFILE_CONTROLS = "codefile-controls";

        /// <summary>
        /// ＜ｆｏｒｍ－ｃｏｎｆｉｇ＞
        /// ？
        /// 
        /// ※親要素はない。
        /// ※架空の要素。
        /// </summary>
        public const string S_FORM_CONFIG = "form-config";

        /// <summary>
        /// ＜ｖａｒｉａｂｌｅ－ｃｏｎｆｉｇ＞
        /// 
        /// ※親要素はない。
        /// ※架空の要素。
        /// </summary>
        public const string S_VARIABLE_CONFIG = "variable-config";

        /// <summary>
        /// 変数設定。コンフィグ設定ファイルでよく記述します。
        /// </summary>
        public const string S_F_SET_VAR = "f-set-var";


        //────────────────────────────────────────
        //
        // ツール設定ファイル
        //

        public const string S_EDITOR = "editor";


        //────────────────────────────────────────
        //
        // フレームワーク系
        //

        /// <summary>
        /// これ使ってる？
        /// ＜ｃｏｎｔｒｏｌ＞
        /// 
        /// ※親要素は、＜ｆｃ－ｃｏｎｆｉｇ＞。
        /// ※バリデーター設定ファイルでも使われる。
        /// </summary>
        public const string S_CONTROL1 = "control";

        /// <summary>
        /// Xn_L05_Ec:Ec_ControlImpl 用
        /// </summary>
        public const string S_HARDCODING_CONTROL = "hardcoding-control";

        /// <summary>
        /// ＜ｄａｔａ　＞
        /// S_DataImpl
        /// </summary>
        public const string S_DATA = "data";

        /// <summary>
        /// ＜ｅｖｅｎｔ　＞
        /// S_EventImpl
        /// </summary>
        public const string S_EVENT = "event";

        /// <summary>
        /// ＜ｋｅｙ－ｅｖｅｎｔ　＞
        /// S_KeyEventImpl
        /// </summary>
        public const string S_KEY_EVENT = "key-event";
        public const string S_KEY_ACTION = "key-action";

        /// <summary>
        /// ＜ｔｏｇｅｔｈｅｒ　＞
        /// S_TogetherImpl
        /// STg_TogetherImpl
        /// </summary>
        public const string S_TOGETHER = "together";

        /// <summary>
        /// ＜ｖｉｅｗ　＞
        /// S_ViewImpl
        /// </summary>
        public const string S_VIEW = "view";

        /// <summary>
        /// ＜ｔｏｇｅｔｈｅｒ　ｉｎ＝”☆”＞
        /// STg_TogetherInImpl
        /// 
        /// todo:
        /// </summary>
        public const string S_TOGETHER_IN = "together-in";

        /// <summary>
        /// ＜ｖａｌｉｄａｔｏｒ　＞
        /// Sv_3ValidatorImpl
        /// </summary>
        public const string S_VALIDATOR = "validator";

        //────────────────────────────────────────
        //
        // 入れ子系
        //

        /// <summary>
        /// ＜ｆｎｃ＞
        /// </summary>
        public const string S_FNC = "fnc";

        /// <summary>
        /// ＜ｆ－ｐａｒａｍ　＞
        /// S_FParamImpl
        /// </summary>
        public const string S_F_PARAM = "f-param";

        /// <summary>
        /// ＜ｆ－ｓｔｒ　＞
        /// S_FStrImpl
        /// </summary>
        public const string S_F_STR = "f-str";

        /// <summary>
        /// ＜ｆ－ｖａｒ　＞
        /// S_FVarImpl
        /// </summary>
        public const string S_F_VAR = "f-var";

        /// <summary>
        /// ＜ｆ－ｔｅｘｔ－ｔｅｍｐｌａｔｅ　＞
        /// S_FtextTemplateImpl
        /// </summary>
        public const string S_F_TEXT_TEMPLATE = "f-text-template";

        /// <summary>
        /// ＜ａｒｇ　＞
        /// </summary>
        public const string S_ARG = "arg";

        //────────────────────────────────────────
        //
        // 関数定義文系
        //

        /// <summary>
        /// ＜ｄｅｆ－ｆｕｎｃｔｉｏｎ　＞
        /// 
        /// ※親要素はない。
        /// ※架空の要素。
        /// </summary>
        public const string S_COMMON_FUNCTION = "common-function";

        /// <summary>
        /// ＜ｄｅｆ－ｐａｒａｍ　＞
        /// S_ParamImpl
        /// 
        /// todo:"param"ではなく、"def-param"では？
        /// </summary>
        public const string S_DEF_PARAM = "def-param";

        /// <summary>
        /// トゥゲザーで利用
        /// </summary>
        public const string S_TARGET = "target";

        //────────────────────────────────────────
        //
        // 廃止方針
        //

        /// <summary>
        /// ＜ａ－ｒｅｃｏｒｄ－ｓｅｔ－ｓａｖｅ－ｔｏ＞　Ｓｆ：ｃｅｌｌ；用
        /// </summary>
        public const string S_A_RECORD_SET_SAVE_TO = "a-record-set-save-to";

        /// <summary>
        /// Sv_3FListboxValidationImpl
        /// 
        /// もしかすると "f-listbox-for-items"か？
        /// </summary>
        public const string S_F_LISTBOX_VALIDATION = "f-listbox-validation";

        /// <summary>
        /// ＜ｖａｒｉａｂｌｅ－ｒｅｃｏｒｄ＞
        /// 
        /// ※親要素は＜ｖａｒｉａｂｌｅ－ｃｏｎｆｉｇ＞。
        /// ※架空の要素。
        /// </summary>
        public const string S_VARIABLE_RECORD = "variable-record";

        /// <summary>
        /// ＜ｒｅｃｏｒｄ－ｓｅｔ－ｌｏａｄ－ｆｒｏｍ＞　Ｓｆ：ｃｅｌｌ；用
        /// </summary>
        public const string S_RECORD_SET_LOAD_FROM = "record-set-load-from";

        //────────────────────────────────────────
        #endregion



    }

}
