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
    /// ＜ｆｎｃ＞
    /// </summary>
    class XToGivechapterandverse_C15_FncImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected override Givechapterandverse_Node CreateMyself(
            XmlElement cur_X,
            Givechapterandverse_Node parent_Cf,
            MemoryApplication memoryApplication, 
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "CreateMyself",log_Reports);

            if (log_Method.CanDebug(1))
            {
            }

            //
            //

            Givechapterandverse_Node cur_Cf = null;

            //
            // name属性は必須。
            //
            string sName_Fnc = cur_X.GetAttribute(PmNames.S_NAME.SName_Attr);
            if ("" == sName_Fnc)
            {
                goto gt_Error_UndefinedFncNameAttr;
            }

            //
            //

            if (
                NamesFnc.S_CELL == sName_Fnc || //Ｓｆ：ｃｅｌｌ；
                NamesFnc.S_WHERE == sName_Fnc || //Ｓｆ：ｗｈｅｒｅ；
                NamesFnc.S_REC_COND == sName_Fnc || //Ｓｆ：ｒｅｃ－ｃｏｎｄ；
                NamesFnc.S_VALUE_CONTROL == sName_Fnc ||
                NamesFnc.S_CASE == sName_Fnc || //Ｓｆ：ｃａｓｅ；”
                NamesFnc.S_LISTBOX_LABELS == sName_Fnc || //Ｓｆ：ｌｉｓｔ－ｂｏｘ－ｌａｂｅｌｓ；
                NamesFnc.S_SWITCH == sName_Fnc || //Ｓｆ：ｓｗｉｔｃｈ；
                NamesFnc.S_ITEM_LABEL2 == sName_Fnc || //Ｓｆ：ｉｔｅｍ－ｌａｂｅｌ；
                NamesFnc.S_ITEM_VALUE == sName_Fnc || //Ｓｆ：ｉｔｅｍ－ｖａｌｕｅ；
                NamesFnc.S_ITEM_GRAY_OUT == sName_Fnc || //Ｓｆ：ｉｔｅｍ－ｇｒａｙ－ｏｕｔ；
                NamesFnc.S_TEXT_TEMPLATE == sName_Fnc || //Ｓｆ：ｔｅｘｔ－ｔｅｍｐｌａｔｅ；
                NamesFnc.S_EMPTY_FIELD == sName_Fnc ||
                NamesFnc.S_ALL_TRUE == sName_Fnc
                )
            {
                cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_FNC, parent_Cf);
            }
            else if (NamesNode.S_DATA == cur_X.Name)
            {
                // 【追加】
                cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_DATA, parent_Cf);
            }
            else if (NamesFnc.S_RECORD_SET_SAVE_TO2 == sName_Fnc)
            {
                // ノード名は　ｆｎｃ　では。
                cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_A_RECORD_SET_SAVE_TO, parent_Cf);
            }
            else
            {
                // ＜ｆｎｃ　ｎａｍｅ＝”Sa:入力値の確定;”＞
                // などがここにくる。
                cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_FNC, parent_Cf);
            }


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedFncNameAttr:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー412！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("＜ｆｎｃ＞要素に、ｎａｍｅ属性が指定されていませんでした。");
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
            return cur_Cf;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        protected override void Parse_SAttribute(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "Parse_SAttr",log_Reports);
            //
            //



            //
            // name属性は必須。
            //
            string sName_Fnc = cur_X.GetAttribute(PmNames.S_NAME.SName_Attr);
            if ("" == sName_Fnc)
            {
                goto gt_Error_UndefinedFncNameAttr;
            }


            XmlAttribute err_XAttr = null;
            if (NamesFnc.S_CELL == sName_Fnc)
            {
                foreach (XmlAttribute xAttr in cur_X.Attributes)
                {
                    // ②
                    // ｎａｍｅ，ｄｅｓｃｒｉｐｔｉｏｎ
                    PmName pmName = PmNames.FromSAttribute(xAttr.Name);
                    if (null != pmName)
                    {
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(pmName.SName_Pm, xAttr.Value, cur_Cf, true, log_Reports);
                    }
                    else
                    {
                        err_XAttr = xAttr;
                        goto gt_Error_UndefinedAttr;
                    }
                }
            }
            else if (NamesFnc.S_SWITCH == sName_Fnc)
            {
                foreach (XmlAttribute xAttr in cur_X.Attributes)
                {
                    // ③
                    // ｎａｍｅ，ｄｅｓｃｒｉｐｔｉｏｎ
                    PmName pmName = PmNames.FromSAttribute(xAttr.Name);
                    if (null != pmName)
                    {
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(pmName.SName_Pm, xAttr.Value, cur_Cf, true, log_Reports);
                    }
                    else
                    {
                        err_XAttr = xAttr;
                        goto gt_Error_UndefinedAttr;
                    }
                }
            }
            else if (NamesFnc.S_CASE == sName_Fnc)
            {
                foreach (XmlAttribute xAttr in cur_X.Attributes)
                {
                    // ④
                    // ｎａｍｅ，ｄｅｓｃｒｉｐｔｉｏｎ
                    PmName pmName = PmNames.FromSAttribute(xAttr.Name);
                    if (null != pmName)
                    {
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(pmName.SName_Pm, xAttr.Value, cur_Cf, true, log_Reports);
                    }
                    else
                    {
                        err_XAttr = xAttr;
                        goto gt_Error_UndefinedAttr;
                    }
                }
            }
            else if (NamesFnc.S_VALUE_CONTROL == sName_Fnc)
            {
                foreach (XmlAttribute xAttr in cur_X.Attributes)
                {
                    // ⑤
                    // ｎａｍｅ，ｄｅｓｃｒｉｐｔｉｏｎ
                    PmName pmName = PmNames.FromSAttribute(xAttr.Name);
                    if (null != pmName)
                    {
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(pmName.SName_Pm, xAttr.Value, cur_Cf, true, log_Reports);
                    }
                    else
                    {
                        err_XAttr = xAttr;
                        goto gt_Error_UndefinedAttr;
                    }
                }

                // value属性の指定がなければ、このコントロールの名前を入れておく。
                if (!cur_Cf.Dictionary_SAttribute_Givechapterandverse.ContainsKey(PmNames.S_VALUE.SName_Pm))
                {
                    Givechapterandverse_Node parent_Cf = cur_Cf.Parent_Givechapterandverse;

                    //ystem.Console.WriteLine(Info_XToS.LibraryName + ":★" + this.GetType().Name + "#XToS:");
                    Givechapterandverse_Node owner_Givechapterandverse_Control;
                    if (NamesNode.S_CONTROL1 == parent_Cf.SName)
                    {
                        owner_Givechapterandverse_Control = parent_Cf;
                    }
                    else
                    {
                        owner_Givechapterandverse_Control = parent_Cf.GetParentByNodename(NamesNode.S_CONTROL1, true, log_Reports);
                    }

                    if (null != owner_Givechapterandverse_Control)
                    {
                        if (owner_Givechapterandverse_Control.Dictionary_SAttribute_Givechapterandverse.ContainsKey(PmNames.S_NAME.SName_Pm))
                        {
                            string sFcName;
                            owner_Givechapterandverse_Control.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sFcName, true, log_Reports);
                            cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(PmNames.S_VALUE.SName_Pm, sFcName, cur_Cf, true, log_Reports);
                        }
                    }
                }
            }
            else if (NamesFnc.S_RECORD_SET_SAVE_TO2 == sName_Fnc)
            {
                foreach (XmlAttribute xAttr in cur_X.Attributes)
                {
                    string xName_AttrTrim = xAttr.Name.Trim();

                    if (
                        PmNames.S_REQUIRED.SName_Attr == xAttr.Name // 特にS→Eにパースは無い
                        || PmNames.S_FROM.SName_Attr == xAttr.Name // Xn_L07_SToE:SToE_F_5FElem／Xn_L07_SToE:SToE_F_A6FromImpl
                        || PmNames.S_STORAGE.SName_Attr == xAttr.Name // 特にS→Eにパースは無い
                        || PmNames.S_FIELD.SName_Attr == xAttr.Name // 特にS→Eにパースは無い
                        )
                    {
                        //
                        // 属性＝””
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(xAttr.Name, xAttr.Value, cur_Cf, true, log_Reports);
                    }
                    else
                    {
                        //
                        // エラー。
                        err_XAttr = xAttr;
                        goto gt_Error_UndefinedAttr;
                    }
                }//foreach
            }
            else
            {
                foreach (XmlNode xAttr in cur_X.Attributes)
                {
                    // とりあえず、どんな属性名でも受け入れる。

                    if(log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole( "＜ｆｎｃ　ｎａｍｅ＝”[" + sName_Fnc + "]”＞の属性　" + xAttr.Name + "＝”" + xAttr.Value + "”");
                    }

                    //
                    // value=""
                    //

                    // ⑥
                    PmName pmName = PmNames.FromSAttribute(xAttr.Name);
                    if (null != pmName)
                    {
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(pmName.SName_Pm, xAttr.Value, cur_Cf, true, log_Reports);
                    }
                    else
                    {
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.Add(xAttr.Name, xAttr.Value, cur_Cf, true, log_Reports);
                    }

                    //
                    // 子＜ａｒｇ１＞は、ここでは処理しない。
                    //
                }
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
        gt_Error_UndefinedFncNameAttr:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー413！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("＜ｆｎｃ＞要素に、ｎａｍｅ属性が指定されていませんでした。");
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

        protected override void Test_ChildNodes(
            XmlElement cur_X, Givechapterandverse_Node cur_Cf, Log_Reports log_Reports)
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "Test_ChildNodes",log_Reports);

            //
            // name属性は必須。
            //
            string sName_Fnc = cur_X.GetAttribute(PmNames.S_NAME.SName_Attr);
            if ("" == sName_Fnc)
            {
                goto gt_Error_UndefinedFncNameAttr;
            }


            //
            //
            //
            // 「Ｓｆ：ｃｅｌｌ；」では、子要素＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｗｈｅｒｅ；”＞が必須。
            //
            //
            //
            int nAwhrCount = 0;//ｗｈｅｒｅ要素の数。
            {
                if (NamesFnc.S_CELL == sName_Fnc)
                {
                    cur_Cf.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node s_Child, ref bool bBreak)
                    {
                        string sName_Attr;
                        bool bHit = s_Child.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Attr, false, log_Reports);
                        if (bHit)
                        {
                            if (NamesFnc.S_WHERE == sName_Attr)
                            {
                                nAwhrCount++;
                            }
                        }

                    });

                    if (0 == nAwhrCount)
                    {
                        goto gt_Error_ZeroAwhr;
                    }
                    else if (1 < nAwhrCount)
                    {
                        goto gt_Error_SomeAwhr;
                    }
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedFncNameAttr:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー411！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("＜ｆｎｃ＞要素に、ｎａｍｅ属性が指定されていませんでした。");
                s.NewLine();
                s.NewLine();

                // ヒント
                s.Append(r.Message_Givechapterandverse(cur_Cf));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_ZeroAwhr:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー377！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("func系要素の下に、＜ａ－ｗｈｅｒｅ＞要素がありませんでした。");

                // ヒント
                s.Append(r.Message_Givechapterandverse(cur_Cf));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_SomeAwhr:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー319！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("＜ａ－ｗｈｅｒｅ＞要素が[");
                s.Append(nAwhrCount);
                s.Append("]つありました。＜ａ－ｗｈｅｒｅ＞要素は、<f-cell>要素の中に1つまでしか書いてはいけません。");

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

        /// <summary>
        /// 親要素に、この要素を追加。
        /// </summary>
        protected override void LinkToParent(
            Givechapterandverse_Node cur_Cf, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "LinkToParent",log_Reports);


            //
            // name属性は必須。
            //
            string sName_Fnc;
            cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Fnc, true, log_Reports);
            if (!log_Reports.BSuccessful)
            {
                goto gt_EndMethod;
                //goto gt_Error_UndefinedFncNameAttr;
            }

            string parent_SName_Fnc;
            {
                //
                // ※注意　＜ｄａｔａ　＞も、＜ｆｎｃ　＞扱い。ｎａｍｅ属性を持っていない。
                //
                bool bRequired = false;
                parent_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out parent_SName_Fnc, bRequired, log_Reports);

                if (!log_Reports.BSuccessful)
                {
                    goto gt_EndMethod;
                    //goto gt_Error_UndefinedFncNameAttr;
                }
            }



            if (NamesFnc.S_WHERE == sName_Fnc)
            {
                //
                //
                //
                // 親へ連結。
                //
                //
                //
                parent_Cf.List_ChildGivechapterandverse.Add(
                    cur_Cf,
                    log_Reports
                    );

                // デバッグ出力
                if (log_Method.CanDebug(1))
                {
                    Log_TextIndented s = new Log_TextIndentedImpl();
                    parent_Cf.ToText_Path(s);
                    //log_Method.WriteDebug_ToConsole( "＜ｆｎｃ　ｎａｍｅ＝”[" + sFncName + "]”＞要素　親要素「S■[" + s_Parent.SName_Node + "]」の子リストに、自分を追加。　子要素の数は[" + s_Cur.CountChildNodes + "]でした。");
                    log_Method.WriteDebug_ToConsole("＜ｆｎｃ　ｎａｍｅ＝”[" + sName_Fnc + "]”＞要素　親要素「S■[" + parent_Cf.SName + "]」の『属性[" + cur_Cf.SName + "]』に、自分「S■[" + cur_Cf.SName + "]」を追加。　子要素の数は[" + cur_Cf.List_ChildGivechapterandverse.NCount + "]でした。　Place＝[" + s.ToString() + "]");
                }


            }
            else if (NamesFnc.S_CASE == sName_Fnc)
            {
                //
                // 親要素は　Ｓｆ：ｓｗｉｔｃｈ；　である必要があります。
                //
                if (NamesFnc.S_SWITCH != parent_SName_Fnc)
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー308！", log_Method);

                        Log_TextIndented s = new Log_TextIndentedImpl();

                        s.Append("Ｓｆ：ｃａｓｅ；系要素の親は ｆ－ｓｗｉｔｃｈ を期待します。");
                        s.NewLine();
                        s.NewLine();

                        s.Append("親ノード名=[");
                        s.Append(parent_Cf.SName);
                        s.Append("]");
                        s.NewLine();
                        s.NewLine();

                        // ヒント
                        s.Append(r.Message_Givechapterandverse(parent_Cf));

                        r.SMessage = s.ToString();
                        log_Reports.EndCreateReport();
                    }

                    goto gt_EndMethod;
                }

                // 要素の（OAelemListではなく）OAcaseListに、この　Ｓｆ：ｃａｓｅ；　要素を追加。

                //
                //
                //
                // 親へ連結。
                //
                //
                //
                parent_Cf.List_ChildGivechapterandverse.Add(
                    cur_Cf,
                    log_Reports
                    );

            }
            else if (
                NamesFnc.S_ITEM_LABEL2 == sName_Fnc
                )
            {
                //
                //
                //
                // 親へ連結。
                //
                //
                //
                parent_Cf.List_ChildGivechapterandverse.Add(
                    cur_Cf,
                    log_Reports
                    );
            }
            else if (
                NamesFnc.S_ITEM_VALUE == sName_Fnc
                )
            {
                //
                //
                //
                // 親へ連結。
                //
                //
                //
                parent_Cf.List_ChildGivechapterandverse.Add(
                    cur_Cf,
                    log_Reports
                    );
            }
            else if (
                NamesFnc.S_ITEM_GRAY_OUT == sName_Fnc
                )
            {
                //
                //
                //
                // 親へ連結。
                //
                //
                //
                parent_Cf.List_ChildGivechapterandverse.Add(
                    cur_Cf,
                    log_Reports
                    );
            }
            else if (
                NamesFnc.S_RECORD_SET_SAVE_TO2 == sName_Fnc
                )
            {
                //
                // 暫定で、親要素は＜ｆ－ａｌｌ－ｔｒｕｅ＞である必要があります。
                //
                if (NamesFnc.S_ALL_TRUE != parent_SName_Fnc)
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー404！", log_Method);

                        Log_TextIndented s = new Log_TextIndentedImpl();

                        s.Append("＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞系要素の親は ＜ｆ－ａｌｌ－ｔｒｕｅ＞ であることを期待します。");
                        s.NewLine();
                        s.NewLine();

                        s.Append("oFnode.NodeName=[");
                        s.Append(parent_Cf.SName);
                        s.Append("]");
                        s.NewLine();
                        s.NewLine();

                        // ヒント
                        s.Append(r.Message_Givechapterandverse(parent_Cf));

                        r.SMessage = s.ToString();
                        log_Reports.EndCreateReport();
                    }

                    goto gt_EndMethod;
                }

                if (!(NamesFnc.S_ALL_TRUE == parent_SName_Fnc))
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー403！", log_Method);

                        Log_TextIndented s = new Log_TextIndentedImpl();

                        s.Append("内部プログラムのミス。");
                        s.NewLine();
                        s.Append("＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞系要素の親が、OFAllTrueImplクラスでありませんでした。");
                        s.NewLine();
                        s.NewLine();

                        s.Append("oFnode.NodeName=[");
                        s.Append(parent_Cf.SName);
                        s.Append("]");
                        s.NewLine();
                        s.NewLine();

                        s.Append("oFnode.GetType().Name=[");
                        s.Append(parent_Cf.GetType().Name);
                        s.Append("]");
                        s.NewLine();
                        s.NewLine();

                        // ヒント
                        s.Append(r.Message_Givechapterandverse(parent_Cf));

                        r.SMessage = s.ToString();
                        log_Reports.EndCreateReport();
                    }

                    goto gt_EndMethod;
                }

                // 親要素の（OAelemListではなく）OArecordSetSaveToListに、この＜ｆｎｃ　ｎａｍｅ＝”Sf:ａ－ｒｅｃｏｒｄ－ｓｅｔ－ｓａｖｅ－ｔｏ；”＞要素を追加。

                //
                //
                //
                // 親へ連結。
                //
                //
                //
                parent_Cf.List_ChildGivechapterandverse.Add(
                    cur_Cf,
                    log_Reports
                    );

            }
            else if (
                NamesFnc.S_EMPTY_FIELD == sName_Fnc
                )
            {
                //
                // 親要素は＜ｆ－ａｌｌ－ｔｒｕｅ＞である必要があります。
                //
                if (NamesFnc.S_ALL_TRUE != parent_SName_Fnc)
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー405！", log_Method);

                        Log_TextIndented s = new Log_TextIndentedImpl();

                        s.Append("＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞系要素の親は ＜ｆ－ａｌｌ－ｔｒｕｅ＞ であることを期待します。");
                        s.NewLine();
                        s.NewLine();

                        s.Append("oFnode.NodeName=[");
                        s.Append(parent_Cf.SName);
                        s.Append("]");
                        s.NewLine();
                        s.NewLine();

                        // ヒント
                        s.Append(r.Message_Givechapterandverse(parent_Cf));

                        r.SMessage = s.ToString();
                        log_Reports.EndCreateReport();
                    }

                    goto gt_EndMethod;
                }

                if (!(NamesFnc.S_ALL_TRUE == parent_SName_Fnc))
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー406！", log_Method);

                        Log_TextIndented s = new Log_TextIndentedImpl();

                        s.Append("内部プログラムのミス。");
                        s.NewLine();
                        s.Append("＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞系要素の親が、OFAllTrueImplクラスでありませんでした。");
                        s.NewLine();
                        s.NewLine();

                        s.Append("oFnode.NodeName=[");
                        s.Append(parent_Cf.SName);
                        s.Append("]");
                        s.NewLine();
                        s.NewLine();

                        s.Append("oFnode.GetType().Name=[");
                        s.Append(parent_Cf.GetType().Name);
                        s.Append("]");
                        s.NewLine();
                        s.NewLine();

                        // ヒント
                        s.Append(r.Message_Givechapterandverse(parent_Cf));

                        r.SMessage = s.ToString();
                        log_Reports.EndCreateReport();
                    }

                    goto gt_EndMethod;
                }

                //
                // ＜ｆ－ａｌｌ－ｔｒｕｅ＞

                //
                // 親要素の（OAelemListではなく）OAemptyFldListに、この<ａ－ｅｍｐｔｙ－ｆｉｅｌｄ>要素を追加。

                //
                //
                //
                // 親へ連結。
                //
                //
                //
                parent_Cf.List_ChildGivechapterandverse.Add(
                    cur_Cf,
                    log_Reports
                    );

            }
            else
            {
                // 親要素「S■？？」に、この「S■ｆｎｃ」要素を追加。
                // 同名要素が複数個並ぶので、属性ではなく子要素として追加する。

                //
                //
                //
                // 親へ連結。
                //
                //
                //
                parent_Cf.List_ChildGivechapterandverse.Add(
                    cur_Cf,
                    log_Reports
                    );

                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("＜ｆｎｃ　ｎａｍｅ＝”[" + sName_Fnc + "]”＞要素　親要素「S■[" + parent_Cf.SName + "]」の子リストに、自分を追加。　子要素の数は[" + cur_Cf.List_ChildGivechapterandverse.NCount + "]でした。");
                }
            }


            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
