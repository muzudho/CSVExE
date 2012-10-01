using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// 引数の名前。
    /// </summary>
    public abstract class PmNames
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 頭文字、終端文字
        //

        public const string S_PM = "Pm:";

        public const string S_SEMICOLON = ";";

        //────────────────────────────────────────
        //
        // Attr専用／必須組
        //          ※「Pm:☆;」への置き換えをさせない。
        //

        /// <summary>
        /// ｎａｍｅ＝””
        /// </summary>
        public static readonly PmName S_NAME = new PmNameImpl_("Pm:name;");

        /// <summary>
        /// ｃａｌｌ＝””【廃止方針】
        /// </summary>
        public static readonly PmName S_CALL = new PmNameImpl_("Pm:call;");

        /// <summary>
        /// ｖａｌｕｅ＝””
        /// </summary>
        public static readonly PmName S_VALUE = new PmNameImpl_("Pm:value;");

        /// <summary>
        /// ｄｅｓｃｒｉｐｔｉｏｎ＝””
        /// </summary>
        public static readonly PmName S_DESCRIPTION = new PmNameImpl_("Pm:description;");


        //────────────────────────────────────────
        //
        // Attr専用／よく使う組
        //          ※「Pm:☆;」への置き換えをさせない。
        //

        /// <summary>
        /// Aa_Tool.xml用。
        /// </summary>
        public static readonly PmName S_DEFAULT_EDITOR = new PmNameImpl_("Pm:default-editor;");

        /// <summary>
        /// ＜ｃｏｄｅｆｉｌｅ－☆　＞用。
        /// </summary>
        public static readonly PmName S_CODEFILE_VERSION = new PmNameImpl_("Pm:codefile-version;");

        /// <summary>
        /// ＜ｄａｔａ＞用。
        /// </summary>
        public static readonly PmName S_ACCESS = new PmNameImpl_("Pm:access;");

        /// <summary>
        /// 汎用。
        /// </summary>
        public static readonly PmName S_TARGET1 = new PmNameImpl_("Pm:target;");

        /// <summary>
        /// ＜ｄａｔａ＞用。
        /// </summary>
        public static readonly PmName S_MEMORY = new PmNameImpl_("Pm:memory;");

        /// <summary>
        /// トゥゲザー用。
        /// </summary>
        public static readonly PmName S_IN = new PmNameImpl_("Pm:in;");

        /// <summary>
        /// トゥゲザー用。
        /// </summary>
        public static readonly PmName S_ON = new PmNameImpl_("Pm:on;");

        //────────────────────────────────────────
        //
        // Attr専用／その他組
        //          ※イベントは＜arg＞を持たないので「Pm:☆;」への置き換えができない。
        //

        /// <summary>
        /// キーアクション用。
        /// </summary>
        public static readonly PmName S_MOTION = new PmNameImpl_("Pm:motion;");

        /// <summary>
        /// キーアクション用。
        /// </summary>
        public static readonly PmName S_KEY = new PmNameImpl_("Pm:key;");

        /// <summary>
        /// キーアクション用。
        /// </summary>
        public static readonly PmName S_CTRL = new PmNameImpl_("Pm:ctrl;");

        /// <summary>
        /// キーアクション用。
        /// </summary>
        public static readonly PmName S_ALT = new PmNameImpl_("Pm:alt;");

        /// <summary>
        /// キーアクション用。
        /// </summary>
        public static readonly PmName S_SHIFT = new PmNameImpl_("Pm:shift;");

        //────────────────────────────────────────
        //
        // 名前系
        //

        /// <summary>
        /// テーブル
        /// </summary>
        public static readonly PmName S_NAME_TABLE = new PmNameImpl_("Pm:name-table;");

        /// <summary>
        /// テーブル
        /// </summary>
        public static readonly PmName S_NAME_TABLE_SRC = new PmNameImpl_("Pm:name-table-src;");

        /// <summary>
        /// テーブル
        /// </summary>
        public static readonly PmName S_NAME_TABLE_DST = new PmNameImpl_("Pm:name-table-dst;");

        /// <summary>
        /// スタイルシートテーブル　※使ってない？
        /// </summary>
        public static readonly PmName S_NAME_TABLE_STYLESHEET = new PmNameImpl_("Pm:name-table-stylesheet;");

        //

        /// <summary>
        /// 変数
        /// 
        /// 合併：Pm:item-value-to-variable; S_ITEM_VALUE_TO_VARIABLE ＜ｄａｔａ＞要素の子＜ａｒｇ５＞用。
        /// </summary>
        public static readonly PmName S_NAME_VAR = new PmNameImpl_("Pm:name-var;");

        /// <summary>
        /// デスティネーション変数
        /// </summary>
        public static readonly PmName S_NAME_VAR_DESTINATION = new PmNameImpl_("Pm:name-var-destination;");

        /// <summary>
        /// ファイルパス変数　※使ってない？
        /// </summary>
        //public static readonly PmName S_NAME_VAR_FILEPATH = new PmNameImpl_("Pm:name-var-filepath;");

        //

        /// <summary>
        /// コントロール
        /// </summary>
        public static readonly PmName S_NAME_CONTROL = new PmNameImpl_("Pm:name-control;");

        /// <summary>
        /// デスティネーション・コントロール
        /// </summary>
        public static readonly PmName S_NAME_CONTROL_DESTINATION = new PmNameImpl_("Pm:name-control-destination;");

        /// <summary>
        /// リストボックス・コントロール
        /// </summary>
        public static readonly PmName S_NAME_CONTROL_LST = new PmNameImpl_("Pm:name-control-lst;");

        //

        /// <summary>
        /// フィールド。
        /// </summary>
        public static readonly PmName S_NAME_FIELD = new PmNameImpl_("Pm:name-field;");

        /// <summary>
        /// キー・フィールド。
        /// Xn_L11_NorenImpl:SToE_Arg33Impl#SToE_Arg 用。
        /// </summary>
        public static readonly PmName S_NAME_FIELD_KEY = new PmNameImpl_("Pm:name-field-key;");

        /// <summary>
        /// トゥゲザー。
        /// </summary>
        public static readonly PmName S_NAME_TOGETHER = new PmNameImpl_("Pm:name-together;");

        //────────────────────────────────────────
        //
        // ファイルパス系
        //

        public static readonly PmName S_FILEPATH = new PmNameImpl_("Pm:filepath;");

        public static readonly PmName S_FILEPATH_EXPORTS = new PmNameImpl_("Pm:filepath-exports;");

        public static readonly PmName S_FILEPATH_EXTERNALAPPLICATION = new PmNameImpl_("Pm:filepath-externalapplication;");

        /// <summary>
        /// ＜ｆ－ｓｅｔ－ｖａｒ＞要素の属性。ｆｏｌｄｅｒ＝””の形でだけ使用。
        /// </summary>
        public static readonly PmName S_FOLDER = new PmNameImpl_("Pm:folder;");

        //────────────────────────────────────────
        //
        // 値系
        //

        public static readonly PmName S_VALUE_ENABLED = new PmNameImpl_("Pm:value-enabled;");

        public static readonly PmName S_VALUE_VISIBLED = new PmNameImpl_("Pm:value-visibled;");

        /// <summary>
        /// 引数　ｎａｍｅ＝”ｃａｓｅＶａｌｕｅ”
        /// </summary>
        public static readonly PmName S_VALUE_CASE = new PmNameImpl_("Pm:value-case;");


        /// <summary>
        /// ｓｗｉｔｃｈＶａｌｕｅ＝””
        /// </summary>
        public static readonly PmName S_VALUE_SWITCH = new PmNameImpl_("Pm:value-switch;");

        /// <summary>
        /// バリデーター用。
        /// </summary>
        public static readonly PmName S_VALUE_RESULT = new PmNameImpl_("Pm:value-result;");


        /// <summary>
        /// Xn_L11_NorenImpl:SToE_Arg33Impl#SToE_Arg 用。
        /// 旧：Pm:empty-to-alt-value;
        /// </summary>
        public static readonly PmName S_VALUE_EMPTY = new PmNameImpl_("Pm:value-empty;");

        /// <summary>
        /// Xn_L11_NorenImpl:SToE_Arg33Impl#SToE_Arg 用。
        /// </summary>
        public static readonly PmName S_VALUE_EXPECTED = new PmNameImpl_("Pm:value-expected;");

        /// <summary>
        /// Xn_L11_NorenImpl:SToE_Arg33Impl#SToE_Arg 用。
        /// </summary>
        public static readonly PmName S_VALUE_EXPECTED2 = new PmNameImpl_("Pm:value-expected2;");

        /// <summary>
        /// XToS_V_4ASelectRecordImpl_ 
        /// 未使用？ @Deprecated
        /// </summary>
        public static readonly PmName S_VALUE_KEY = new PmNameImpl_("Pm:value-key;");

        //────────────────────────────────────────
        //
        // ID系
        //

        /// <summary>
        /// ＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｔｅｘｔ－ｔｅｍｐｌａｔｅ；”＞
        /// 　　　　＜ａｒｇ１　ｎａｍｅ＝”ｌｏｏｋｕｐ－ｉｄ”＞
        /// </summary>
        public static readonly PmName S_LOOKUP_ID = new PmNameImpl_("Pm:lookup-id;");

        //────────────────────────────────────────
        //
        // フィールド系
        //

        public static readonly PmName S_FIELD = new PmNameImpl_("Pm:field;");

        /// <summary>
        /// XToS_V_4ASelectRecordImpl_ 使ってない？
        /// </summary>
        public static readonly PmName S_FIELD_KEY = new PmNameImpl_("Pm:field-key;");

        //────────────────────────────────────────
        //
        // その他系
        //

        public static readonly PmName S_POPUP = new PmNameImpl_("Pm:popup;");

        public static readonly PmName S_FLOWSKIP = new PmNameImpl_("Pm:flowskip;");

        public static readonly PmName S_MESSAGE = new PmNameImpl_("Pm:message;");

        public static readonly PmName S_NAME_FORM = new PmNameImpl_("Pm:name-form;");

        public static readonly PmName S_FROM = new PmNameImpl_("Pm:from;");

        public static readonly PmName S_TO = new PmNameImpl_("Pm:to;");

        public static readonly PmName S_EXECUTE = new PmNameImpl_("Pm:execute;");

        /// <summary>
        /// Ｓｆ：ｃｅｌｌ；用。
        /// </summary>
        public static readonly PmName S_SELECT = new PmNameImpl_("Pm:select;");

        /// <summary>
        /// ＜ｆ－ｔｅｘｔ－ｔｅｍｐｌａｔｅ＞用。
        /// </summary>
        public static readonly PmName S_TABLE = new PmNameImpl_("Pm:table;");

        /// <summary>
        /// 「E■　ｗｈｅｒｅ＝””」　使ってない？
        /// </summary>
        public static readonly PmName S_WHERE = new PmNameImpl_("Pm:where;");


        /// <summary>
        /// ｔｙｐｅ＝””　使ってない？
        /// </summary>
        public static readonly PmName S_TYPE = new PmNameImpl_("Pm:type;");

        /// <summary>
        /// バリデーターなど。
        /// </summary>
        public static readonly PmName S_EXPECTED = new PmNameImpl_("Pm:expected;");




        /// <summary>
        /// バリデーター用。
        /// </summary>
        public static readonly PmName S_BEGIN = new PmNameImpl_("Pm:begin;");

        /// <summary>
        /// バリデーター用。
        /// </summary>
        public static readonly PmName S_END = new PmNameImpl_("Pm:end;");

        /// <summary>
        /// ヒット必須。ｆ－ｃｅｌｌ。値はｔｒｕｅ／ｆａｌｓｅ。
        /// </summary>
        public static readonly PmName S_REQUIRED = new PmNameImpl_("Pm:required;");

        /// <summary>
        /// 前ゼロの無視。ｆ－ｃｅｌｌ。値はｔｒｕｅ／ｆａｌｓｅ。
        /// </summary>
        public static readonly PmName S_IGNORED_ZERO_SUPPLY = new PmNameImpl_("Pm:ignored-zero-supply;");

        /// <summary>
        /// XToS_V_4ASelectRecordImpl_
        /// </summary>
        public static readonly PmName S_STORAGE = new PmNameImpl_("Pm:storage;");

        /// <summary>
        /// 全置換済み
        /// </summary>
        public static readonly PmName S_OPE = new PmNameImpl_("Pm:ope;");

        /// <summary>
        /// 全置換済み
        /// </summary>
        public static readonly PmName S_LOGIC = new PmNameImpl_("Pm:logic;");

        public static readonly PmName S_DEFINITION_PARAMETERS = new PmNameImpl_("Pm:definition-parameters;");

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public static PmName FromSAttribute(string sName_Attr)
        {
            if (PmNames.Dictionary_Attribute_.ContainsKey(sName_Attr))
            {
                return PmNames.Dictionary_Attribute_[sName_Attr];
            }

            return null;
        }

        //────────────────────────────────────────

        private static void RegisterAttributeDictionary_(Dictionary<string, PmName> d, PmName pmName)
        {
            d.Add(pmName.Name_Attribute, pmName);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private static Dictionary<string, PmName> dictionary_Attribute_;
        private static Dictionary<string, PmName> Dictionary_Attribute_
        {
            get
            {
                if (null == dictionary_Attribute_)
                {
                    Dictionary<string, PmName> d = new Dictionary<string, PmName>();

                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_ACCESS);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_ALT);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_BEGIN);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_CALL);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE_CASE);
                    //PmNames.RegisterAttributeDictionary_(d, PmNames.S_FILEPATH_CSV);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_CTRL);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_DEFINITION_PARAMETERS);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_DESCRIPTION);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE_EMPTY);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE_ENABLED);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_END);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_EXECUTE);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_EXPECTED);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE_EXPECTED);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE_EXPECTED2);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_FILEPATH_EXPORTS);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_FILEPATH_EXTERNALAPPLICATION);

                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_CONTROL);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_CONTROL_DESTINATION);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_CONTROL_LST);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_FIELD);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_FORM);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_TABLE);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_TABLE_SRC);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_TABLE_DST);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_TABLE_STYLESHEET);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_VAR);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_VAR_DESTINATION);
                    //PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_VAR_FILEPATH);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_FIELD_KEY);

                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_FIELD);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_FILEPATH);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_FLOWSKIP);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_FROM);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_IGNORED_ZERO_SUPPLY);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_IN);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_KEY);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_FIELD_KEY);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE_KEY);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_LOGIC);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_LOOKUP_ID);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_MESSAGE);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_MOTION);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_ON);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_OPE);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_POPUP);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME_TOGETHER);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_REQUIRED);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE_RESULT);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_SELECT);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_SHIFT);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_STORAGE);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE_SWITCH);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_TABLE);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_TARGET1);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_MEMORY);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_TO);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_TYPE);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_VALUE_VISIBLED);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_WHERE);
                    PmNames.RegisterAttributeDictionary_(d, PmNames.S_NAME);

                    PmNames.dictionary_Attribute_ = d;
                }

                return PmNames.dictionary_Attribute_;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
