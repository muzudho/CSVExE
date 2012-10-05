using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XmlToConf
{
    public class XmlToConfigurationtree_Collection
    {



        #region アクション
        //────────────────────────────────────────

        public static XmlToConfigurationtree_C15_Elm GetTranslatorByFncName(string sName_Fnc, Log_Reports log_Reports)
        {
            if (null == XmlToConfigurationtree_Collection.dictionary_FncVer)
            {
                Dictionary<string, XmlToConfigurationtree_C15_Elm> d = new Dictionary<string, XmlToConfigurationtree_C15_Elm>();

                {
                    //ａ－ｄｉｓｐｌａｙ
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_V_4ADisplayImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_TYPE.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesFnc.S_VLD_DISPLAY, xToS);
                }
                {
                    //ｓｅｌｅｃｔ－ｒｅｃｏｒｄ
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_V_4ASelectRecordImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_FIELD_KEY.Name_Attribute);
                    a.Add(PmNames.S_VALUE_KEY.Name_Attribute);
                    a.Add(PmNames.S_REQUIRED.Name_Attribute);
                    a.Add(PmNames.S_STORAGE.Name_Attribute);
                    a.Add(PmNames.S_FROM.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesFnc.S_VLD_SELECT_RECORD, xToS);
                }
                {
                    //ａｌｌ－ｆｉｅｌｄｓ－ｉｓ－ｅｍｐｔｙ
                    XmlToConfigurationtree_V_5FAllFieldsIsEmptyImpl_ xToS = new XmlToConfigurationtree_V_5FAllFieldsIsEmptyImpl_();
                    d.Add(NamesFnc.S_VLD_ALL_FIELDS_IS_EMPTY, xToS);
                }
                {
                    //ｆ－ａｌｌ－ｔｒｕｅ
                    XmlToConfigurationtree_V_5FAllTrueImpl_ xToS = new XmlToConfigurationtree_V_5FAllTrueImpl_();
                    d.Add(NamesFnc.S_ALL_TRUE, xToS);
                }
                {
                    //ａ－ｅｍｔｐｙ－ｆｉｅｌｄ
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_V_6AEmptyFieldImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_TYPE.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesFnc.S_VLD_EMPTY_FIELD, xToS);
                }

                XmlToConfigurationtree_Collection.dictionary_FncVer = d;
            }

            XmlToConfigurationtree_C15_Elm result;
            XmlToConfigurationtree_Collection.dictionary_FncVer.TryGetValue(sName_Fnc, out result);
            return result;
        }

        //────────────────────────────────────────

        public static XmlToConfigurationtree_C15_Elm GetTranslatorByNodeName(string sName_Node, Log_Reports log_Reports)
        {
            if (null == XmlToConfigurationtree_Collection.dictionary_NodeVer)
            {
                Dictionary<string, XmlToConfigurationtree_C15_Elm> d = new Dictionary<string, XmlToConfigurationtree_C15_Elm>();

                {
                    // ＜ｄａｔａ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C13_DataImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_MEMORY.Name_Attribute);
                    a.Add(PmNames.S_ACCESS.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    List<string> l3 = new List<string>();
                    l3.Add(PmNames.S_MEMORY.Name_Attribute);
                    l3.Add(PmNames.S_ACCESS.Name_Attribute);
                    xToS.List_SName_RequiredPm = l3;
                    d.Add(NamesNode.S_DATA, xToS);
                }
                {
                    // ＜ｅｖｅｎｔ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C13_EventImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_EVENT, xToS);
                }
                {
                    // ＜ｋｅｙ－ｅｖｅｎｔ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C13_KeyEventImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_MOTION.Name_Attribute);
                    a.Add(PmNames.S_KEY.Name_Attribute);
                    a.Add(PmNames.S_CTRL.Name_Attribute);
                    a.Add(PmNames.S_ALT.Name_Attribute);
                    a.Add(PmNames.S_SHIFT.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_KEY_EVENT, xToS);
                }
                {
                    // ＜ｔｏｇｅｔｈｅｒ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C13_TogetherImpl_();
                    d.Add(NamesNode.S_TOGETHER, xToS);
                }
                {
                    // ＜ｖｉｅｗ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C13_ViewImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_TARGET1.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_VIEW, xToS);
                }
                {
                    // ＜ｃｏｍｍｏｎ－ｆｕｎｃｔｉｏｎ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C15_DefFunctionImpl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_COMMON_FUNCTION, xToS);
                }
                {
                    // ＜ｆｎｃ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C15_FncImpl_();

                    // 追加【2012-07-27】
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.Name_Attribute);
                    a.Add(PmNames.S_VALUE.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;

                    d.Add(NamesNode.S_FNC, xToS);
                }
                {
                    // ＜ｆ－ｐａｒａｍ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C_Parser15Impl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_CALL.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_F_PARAM, xToS);
                }
                {
                    // ＜ｆ－ｓｔｒ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C_Parser15Impl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.Name_Attribute);
                    a.Add(PmNames.S_VALUE.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_F_STR, xToS);
                }
                {
                    // ＜ｆ－ｖａｒ＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C_Parser15Impl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.Name_Attribute);
                    a.Add(PmNames.S_VALUE.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_F_VAR, xToS);
                }
                {
                    // ＜ａｒｇ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C15b_ArgImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.Name_Attribute);
                    a.Add(PmNames.S_VALUE.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_ARG, xToS);
                }
                {
                    // ＜ｄｅｆ－ｐａｒａｍ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C_Parser15Impl();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_DEF_PARAM, xToS);
                }
                {
                    // ＜ｋｅｙ－ａｃｔｉｏｎ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_C_Parser15Impl();
                    List<PmNameItem> p1 = new List<PmNameItem>();
                    p1.Add(new PmNameItemImpl(PmNames.S_TYPE, true));
                    xToS.List_PmName = p1;
                    d.Add(NamesNode.S_KEY_ACTION, xToS);
                }
                {
                    // ＜ｆ－ｌｉｓｔｂｏｘ－ｖａｌｉｒａｔｉｏｎ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_V_3FListboxValidationImpl_();
                    d.Add(NamesNode.S_F_LISTBOX_VALIDATION, xToS);
                }
                {
                    // ＜ｖａｌｉｄａｔｏｒ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_V_3ValidatorImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.Name_Attribute);
                    a.Add(PmNames.S_DESCRIPTION.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_VALIDATOR, xToS);
                }
                {
                    // ＜ｃｏｎｔｒｏｌ　＞
                    XmlToConfigurationtree_C15_Elm xToS = new XmlToConfigurationtree_V52_ControlImpl_();
                    List<string> a = new List<string>();
                    a.Add(PmNames.S_NAME.Name_Attribute);
                    xToS.List_SName_Attribute = a;
                    d.Add(NamesNode.S_CONTROL1, xToS);
                }


                XmlToConfigurationtree_Collection.dictionary_NodeVer = d;
            }

            XmlToConfigurationtree_C15_Elm result;
            XmlToConfigurationtree_Collection.dictionary_NodeVer.TryGetValue(sName_Node, out result);
            return result;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ノード名
        /// </summary>
        private static Dictionary<string, XmlToConfigurationtree_C15_Elm> dictionary_NodeVer;

        /// <summary>
        /// 関数名
        /// </summary>
        private static Dictionary<string, XmlToConfigurationtree_C15_Elm> dictionary_FncVer;

        //────────────────────────────────────────
        #endregion



    }
}
