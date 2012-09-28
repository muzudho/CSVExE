﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XToGcav
{
    public class XToGivechapterandverse_Collection
    {



        #region アクション
        //────────────────────────────────────────

        public static XToGivechapterandverse_C15_Elm GetTranslatorByFncName(string sName_Fnc, Log_Reports log_Reports)
        {
            if (null == XToGivechapterandverse_Collection.dictionary_FncVer)
            {
                Dictionary<string, XToGivechapterandverse_C15_Elm> d = new Dictionary<string, XToGivechapterandverse_C15_Elm>();

                {
                    //ａ－ｄｉｓｐｌａｙ
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_V_4ADisplayImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_TYPE.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesFnc.S_VLD_DISPLAY, xToS);
                }
                {
                    //ｓｅｌｅｃｔ－ｒｅｃｏｒｄ
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_V_4ASelectRecordImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_FIELD_KEY.SName_Attr);
                    a.Add(PmNames.S_VALUE_KEY.SName_Attr);
                    a.Add(PmNames.S_REQUIRED.SName_Attr);
                    a.Add(PmNames.S_STORAGE.SName_Attr);
                    a.Add(PmNames.S_FROM.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesFnc.S_VLD_SELECT_RECORD, xToS);
                }
                {
                    //ａｌｌ－ｆｉｅｌｄｓ－ｉｓ－ｅｍｐｔｙ
                    XToGivechapterandverse_V_5FAllFieldsIsEmptyImpl_ xToS = new XToGivechapterandverse_V_5FAllFieldsIsEmptyImpl_();
                    d.Add(NamesFnc.S_VLD_ALL_FIELDS_IS_EMPTY, xToS);
                }
                {
                    //ｆ－ａｌｌ－ｔｒｕｅ
                    XToGivechapterandverse_V_5FAllTrueImpl_ xToS = new XToGivechapterandverse_V_5FAllTrueImpl_();
                    d.Add(NamesFnc.S_ALL_TRUE, xToS);
                }
                {
                    //ａ－ｅｍｔｐｙ－ｆｉｅｌｄ
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_V_6AEmptyFieldImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_TYPE.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesFnc.S_VLD_EMPTY_FIELD, xToS);
                }

                XToGivechapterandverse_Collection.dictionary_FncVer = d;
            }

            XToGivechapterandverse_C15_Elm result;
            XToGivechapterandverse_Collection.dictionary_FncVer.TryGetValue(sName_Fnc, out result);
            return result;
        }

        //────────────────────────────────────────

        public static XToGivechapterandverse_C15_Elm GetTranslatorByNodeName(string sName_Node, Log_Reports log_Reports)
        {
            if (null == XToGivechapterandverse_Collection.dictionary_NodeVer)
            {
                Dictionary<string, XToGivechapterandverse_C15_Elm> d = new Dictionary<string, XToGivechapterandverse_C15_Elm>();

                {
                    // ＜ｄａｔａ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C13_DataImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_MEMORY.SName_Attr);
                    a.Add(PmNames.S_ACCESS.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    List<string> l3 = new List<string>();
                    l3.Add(PmNames.S_MEMORY.SName_Attr);
                    l3.Add(PmNames.S_ACCESS.SName_Attr);
                    xToS.List_SName_RequiredPm = l3;
                    d.Add(NamesNode.S_DATA, xToS);
                }
                {
                    // ＜ｅｖｅｎｔ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C13_EventImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_EVENT, xToS);
                }
                {
                    // ＜ｋｅｙ－ｅｖｅｎｔ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C13_KeyEventImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_MOTION.SName_Attr);
                    a.Add(PmNames.S_KEY.SName_Attr);
                    a.Add(PmNames.S_CTRL.SName_Attr);
                    a.Add(PmNames.S_ALT.SName_Attr);
                    a.Add(PmNames.S_SHIFT.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_KEY_EVENT, xToS);
                }
                {
                    // ＜ｔｏｇｅｔｈｅｒ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C13_TogetherImpl_();
                    d.Add(NamesNode.S_TOGETHER, xToS);
                }
                {
                    // ＜ｖｉｅｗ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C13_ViewImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_TARGET1.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_VIEW, xToS);
                }
                {
                    // ＜ｃｏｍｍｏｎ－ｆｕｎｃｔｉｏｎ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C15_DefFunctionImpl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_COMMON_FUNCTION, xToS);
                }
                {
                    // ＜ｆｎｃ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C15_FncImpl_();

                    // 追加【2012-07-27】
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.SName_Attr);
                    a.Add(PmNames.S_VALUE.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;

                    d.Add(NamesNode.S_FNC, xToS);
                }
                {
                    // ＜ｆ－ｐａｒａｍ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C_Parser15Impl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_CALL.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_F_PARAM, xToS);
                }
                {
                    // ＜ｆ－ｓｔｒ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C_Parser15Impl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.SName_Attr);
                    a.Add(PmNames.S_VALUE.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_F_STR, xToS);
                }
                {
                    // ＜ｆ－ｖａｒ＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C_Parser15Impl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.SName_Attr);
                    a.Add(PmNames.S_VALUE.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_F_VAR, xToS);
                }
                {
                    // ＜ａｒｇ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C15b_ArgImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.SName_Attr);
                    a.Add(PmNames.S_VALUE.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_ARG, xToS);
                }
                {
                    // ＜ｄｅｆ－ｐａｒａｍ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C_Parser15Impl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_DEF_PARAM, xToS);
                }
                {
                    // ＜ｋｅｙ－ａｃｔｉｏｎ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_C_Parser15Impl();
                    List<PmNameItem> p1 = new List<PmNameItem>();
                    p1.Add(new PmNameItemImpl(PmNames.S_TYPE, true));
                    xToS.List_PmName = p1;
                    d.Add(NamesNode.S_KEY_ACTION, xToS);
                }
                {
                    // ＜ｆ－ｌｉｓｔｂｏｘ－ｖａｌｉｒａｔｉｏｎ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_V_3FListboxValidationImpl_();
                    d.Add(NamesNode.S_F_LISTBOX_VALIDATION, xToS);
                }
                {
                    // ＜ｖａｌｉｄａｔｏｒ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_V_3ValidatorImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.SName_Attr);
                    a.Add(PmNames.S_DESCRIPTION.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_VALIDATOR, xToS);
                }
                {
                    // ＜ｃｏｎｔｒｏｌ　＞
                    XToGivechapterandverse_C15_Elm xToS = new XToGivechapterandverse_V52_ControlImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.SName_Attr);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_CONTROL1, xToS);
                }


                XToGivechapterandverse_Collection.dictionary_NodeVer = d;
            }

            XToGivechapterandverse_C15_Elm result;
            XToGivechapterandverse_Collection.dictionary_NodeVer.TryGetValue(sName_Node, out result);
            return result;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ノード名
        /// </summary>
        private static Dictionary<string, XToGivechapterandverse_C15_Elm> dictionary_NodeVer;

        /// <summary>
        /// 関数名
        /// </summary>
        private static Dictionary<string, XToGivechapterandverse_C15_Elm> dictionary_FncVer;

        //────────────────────────────────────────
        #endregion



    }
}