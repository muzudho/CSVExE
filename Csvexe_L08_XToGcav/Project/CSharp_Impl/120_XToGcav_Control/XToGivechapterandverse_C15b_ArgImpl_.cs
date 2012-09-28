using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using Xenon.Syntax;//Log_TextIndented
using Xenon.Middle;


namespace Xenon.XToGcav
{

    /// <summary>
    /// ＜ａｒｇ＞
    /// ※＜ｆｎｃ＞専用の子要素。
    /// </summary>
    class XToGivechapterandverse_C15b_ArgImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region アクション
        //────────────────────────────────────────

        public override void XToGivechapterandverse(
            XmlElement cur_X,//＜ａｒｇ１＞
            Givechapterandverse_Node parent_Cf,//＜ｆｎｃ＞
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "XToS",log_Reports);
            //
            //


            //
            //
            //
            // 自
            //
            //
            //
            Givechapterandverse_Node cur_Cf = this.CreateMyself(cur_X, parent_Cf, memoryApplication, log_Reports);



            //
            //
            //
            // 属性
            //
            //
            //
            //string sFncName;
            //s_Parent.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.NAME.SName_Attr, out sFncName, false, log_Reports);
            if (NamesNode.S_VALIDATOR == parent_Cf.SName)
            {
                //
                // ＜ｖａｌｉｄａｔｏｒ＞の子＜ａｒｇ＞
                //

                //
                // ｎａｍｅ＝””
                {
                    XmlNode xNode = cur_X.Attributes.GetNamedItem(PmNames.S_NAME.SName_Attr);
                    if (null != xNode)
                    {
                        string sName = xNode.Value;

                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Set(PmNames.S_NAME.SName_Pm, sName, log_Reports);
                    }
                }

                //
                // ｖａｌｕｅ＝””
                string sValue;
                {
                    XmlNode xNode = cur_X.Attributes.GetNamedItem(PmNames.S_VALUE.SName_Attr);
                    if (null != xNode)
                    {
                        sValue = xNode.Value;
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(PmNames.S_VALUE.SName_Pm, sValue, cur_Cf, true, log_Reports);
                    }
                    else
                    {
                        sValue = "";
                    }
                }

                {
                    string sName;
                    cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName, false, log_Reports);

                    //O_Name o_Name = new O_NameImpl(sName, s_Cur);

                    parent_Cf.Dictionary_SAttribute_Givechapterandverse.Add( sName, sValue, parent_Cf, false, log_Reports);
                }

            }
            else
            {
                this.Parse_SAttribute(cur_X, cur_Cf, memoryApplication, log_Reports);
            }



            //
            //
            //
            // 子
            //
            //
            //
            this.Parse_ChildNodes(cur_X, cur_Cf, memoryApplication, log_Reports);



            //
            //
            //
            // 親へ連結
            //
            //
            //
            string err_Parent_SName;
            string parent_SName_Fnc;
            string parent_SAmemory;

            if(!log_Reports.BSuccessful)
            {
                // エラー
                goto gt_EndMethod;
            }
            else if (
                // 親＜ｄａｔａ　＞
                NamesNode.S_DATA == parent_Cf.SName
                )
            {
                bool bHit = parent_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out parent_SName_Fnc, false, log_Reports);

                bool bHit3 = parent_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_MEMORY, out parent_SAmemory, true, log_Reports);

                if (
                    ValuesAttr.S_RECORDS == parent_SAmemory ||
                    ValuesAttr.S_VARIABLE == parent_SAmemory
                    )
                {
                    //
                    // 親 ＜ｄａｔａ　ｍｅｍｏｒｙ＝”ｒｅｃｏｒｄｓ”＞
                    // 親 ＜ｄａｔａ　ｍｅｍｏｒｙ＝”ｖａｒｉａｂｌｅ”＞
                    //

                    //
                    // 属性としては追加する。
                    //
                    string sName_Fnc;
                    bool bHit2 = cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Fnc, false, log_Reports);
                    if (bHit2)
                    {
                        string sValue_Arg;
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue_Arg, false, log_Reports);

                        // 「S■ｄａｔａ－ｓｏｕｒｃｅ」の（＜ａｒｇ５　ｎａｍｅ属性＞としてｔａｒｇｅｔ値を追加。

                        // 属性とする。
                        if (log_Method.CanDebug(1))
                        {
                            log_Method.WriteDebug_ToConsole( "＜データ　ｔａｒｇｅｔ=[" + parent_SAmemory + "]＞に属性追加 [" + sName_Fnc + "]←[" + sValue_Arg + "]");
                        }
                        parent_Cf.Dictionary_SAttribute_Givechapterandverse.Add(sName_Fnc, sValue_Arg, parent_Cf, true, log_Reports);
                    }
                }
                else
                {
                    // エラー
                    err_Parent_SName = parent_Cf.SName;
                    goto gt_Error_Target;
                }
            }
            else
            {
                // 親が＜ｄａｔａ＞以外。
                bool bHit = parent_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out parent_SName_Fnc, true, log_Reports);//name属性が無い親もある？？

                if (!log_Reports.BSuccessful)
                {
                    log_Method.WriteWarning_ToConsole("s_Parent.SName_Node=[" + parent_Cf.SName + "]");
                }
                else
                {
                }

                if (
                    NamesNode.S_FNC != parent_Cf.SName &&
                    NamesNode.S_VALIDATOR != parent_Cf.SName &&
                    NamesNode.S_COMMON_FUNCTION != parent_Cf.SName &&
                    NamesFnc.S_SWITCH != parent_SName_Fnc //旧仕様に対応
                    )
                {
                    // 親要素が＜ｆｎｃ＞でも＜ｖａｌｉｄａｔｏｒ＞＜ｃｏｍｍｏｎ－ｆｕｎｃｔｉｏｎ＞＜ｆ－ｓｗｉｔｃｈ＞でもない。

                    // エラー
                    err_Parent_SName = parent_Cf.SName;
                    goto gt_Error_Parent;
                }
                else if (
                    // 親が＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｗｈｅｒｅ；”＞
                    NamesNode.S_FNC == parent_Cf.SName &&
                    NamesFnc.S_WHERE == parent_SName_Fnc)
                {
                    // この子ａｒｇ１要素は、
                    // 親要素「S■ｆ－ｃｅｌｌ」には追加しません。

                    // 【追加 2012-06-02】
                    // 現状では、「S■ａ－ｗｈｅｒｅ」に子「S■ａｒｇ１」要素が含まれていると、
                    // 「E■ｆ－ｃｅｌｌ」にａｒｇ１要素を追加してしまうので都合が悪い。

                    //
                    // 属性としては追加する。
                    //
                    string sArgAname;
                    bool bHit2 = cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sArgAname, true, log_Reports);
                    if (!log_Reports.BSuccessful)
                    {
                        goto gt_EndMethod;
                    }

                    string sValue;
                    cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, false, log_Reports);


                    // 「S■ｆｎｃ」のｌｏｇｉｃ属性として追加。

                    // 属性連結
                    parent_Cf.Dictionary_SAttribute_Givechapterandverse.Add(sArgAname, sValue, parent_Cf, true, log_Reports);
                }
                else
                {
                    // 属性にせず、子まま連結。

                    // 子連結
                    parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf, log_Reports);
                }
            }
            


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Parent:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー361！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("<");
                t.Append(cur_X.Name);
                t.Append(">要素の親は、＜ｆｎｃ＞でなければなりませんでしたが、別の要素＜");
                t.Append(err_Parent_SName);
                t.Append("＞でした。");
                t.NewLine();
                t.NewLine();

                // ヒント
                t.Append(r.Message_Givechapterandverse(parent_Cf));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Target:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー562！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("<");
                s.Append(cur_X.Name);
                s.Append(">要素のｔａｒｇｅｔ属性が予想外でした。＜[");
                s.Append(err_Parent_SName);
                s.Append("]　ｔａｒｇｅｔ＝”[");
                s.Append(parent_SAmemory);
                s.Append("]”＞");
                s.NewLine();
                s.NewLine();

                // ヒント
                s.Append(r.Message_Givechapterandverse(parent_Cf));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        protected override void Parse_SAttribute(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "Parse_SAttr",log_Reports);
            //
            //

            XmlAttribute err_XAttr = null;

            foreach (XmlAttribute xAttr in cur_X.Attributes)
            {
                //
                if (this.List_SName_Attribute.Contains(xAttr.Name))
                {
                    // 属性連結

                    // ⑦
                    PmName pmName = PmNames.FromSAttribute(xAttr.Name);
                    if (null != pmName)
                    {
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(pmName.SName_Pm, xAttr.Value, cur_Cf, true, log_Reports);
                    }
                    else
                    {
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(xAttr.Name, xAttr.Value, cur_Cf, true, log_Reports);
                    }

                }
                else
                {
                    err_XAttr = xAttr;
                    goto gt_Error_UndefinedAttr;
                }

                goto gt_attrEnd;

            gt_attrEnd:
                ;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedAttr:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー336！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("[");
                s.Append(cur_X.Name);
                s.Append("]要素を探索中に、未対応の属性が記述されていました。");
                s.NewLine();

                s.Append("xAttr.Name=[");
                s.Append(err_XAttr.Name);
                s.Append("]");
                s.NewLine();
                s.NewLine();

                // ヒント
                s.Append(r.Message_Givechapterandverse(cur_Cf));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
