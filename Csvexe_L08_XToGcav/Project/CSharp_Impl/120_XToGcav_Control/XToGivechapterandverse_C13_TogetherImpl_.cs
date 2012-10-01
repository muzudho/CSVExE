using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;//XmlNode
using Xenon.Syntax;//Log_TextIndented
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.XToGcav
{

    /// <summary>
    /// (Stg) ＜ｔｏｇｅｔｈｅｒ＞
    /// 
    /// TODO:　フォーム設定ファイルの中に＜ｔｏｇｅｔｈｅｒ＞要素を書く形にしたい。
    /// </summary>
    class XToGivechapterandverse_C13_TogetherImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected override Givechapterandverse_Node CreateMyself(
            XmlElement cur_X, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            //D_InMethod d_InMethod = new D_InMethodImpl(0, Info_XToS.LibraryName, this, "CreateMyself");

            Givechapterandverse_Node cur_Cf;

            if (NamesNode.S_CODEFILE_TOGETHERS == parent_Cf.Name)
            {
                cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_TOGETHER, parent_Cf);
                cur_Cf.Dictionary_Attribute_Givechapterandverse.Set(PmNames.S_IN.Name_Pm, "", log_Reports);
            }
            else
            {
                cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_TOGETHER, parent_Cf);
            }

            return cur_Cf;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override void XToGivechapterandverse(//override
            XmlElement cur_X,
            Givechapterandverse_Node parent_Cf,//トゥゲザー設定ファイル
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(1);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToS",log_Reports);
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
            //「トゥゲザー登録ファイル」に書かれているのか、
            //「コントロール設定ファイル」に書かれているのかで、処理を変えます。
            //
            //
            //
            bool bGlobalRfr;
            if (NamesNode.S_CODEFILE_TOGETHERS == parent_Cf.Name)
            {
                bGlobalRfr = true;

                //if (log_Method.CanDebug(1))
                //{
                //    log_Method.WriteDebug_ToConsole("親要素がトゥゲザーコンフィグってことは、グローバル・トゥゲザー？");
                //}
            }
            else
            {
                bGlobalRfr = false;

                //if (log_Method.CanDebug(1))
                //{
                //    log_Method.WriteDebug_ToConsole("トゥゲザーコンフィグじゃないって何？");
                //}
            }



            //
            //
            //
            // 属性
            //
            //
            //

            //ｎａｍｅ（未設定可）
            if (log_Reports.Successful)
            {
                XmlNode xNd = cur_X.Attributes.GetNamedItem(PmNames.S_NAME.Name_Attribute);
                if (null != xNd)
                {
                    cur_Cf.Dictionary_Attribute_Givechapterandverse.Add(PmNames.S_NAME.Name_Pm, xNd.Value, cur_Cf, false, log_Reports);
                }
            }

            //ｉｎ（未設定可。コントロール設定ファイルには無い）
            if (log_Reports.Successful)
            {
                if (bGlobalRfr)
                {
                    XmlNode xNd = cur_X.Attributes.GetNamedItem(PmNames.S_IN.Name_Pm);
                    if (null != xNd)
                    {
                        cur_Cf.Dictionary_Attribute_Givechapterandverse.Set(PmNames.S_IN.Name_Pm, xNd.Value, log_Reports);
                    }
                }
            }

            //ｏｎ（コントロール設定ファイルでは必須、グローバル・トゥゲザー登録ファイルには無い）
            if (log_Reports.Successful)
            {
                if (!bGlobalRfr)
                {
                    XmlNode xNd = cur_X.Attributes.GetNamedItem(PmNames.S_ON.Name_Attribute);
                    if (null != xNd)
                    {
                        cur_Cf.Dictionary_Attribute_Givechapterandverse.Add(PmNames.S_ON.Name_Pm, xNd.Value, cur_Cf, false, log_Reports);
                    }
                    else
                    {
                        // エラー
                        goto gt_Error_NoOn;
                    }
                }
            }

            // ｔａｒｇｅｔ（コントロール設定ファイルでは必須、グローバル・トゥゲザー登録ファイルには無い）
            if (log_Reports.Successful)
            {
                if (!bGlobalRfr)
                {
                    XmlNode xNd = cur_X.Attributes.GetNamedItem(PmNames.S_TARGET1.Name_Attribute);
                    if (null != xNd)
                    {
                        cur_Cf.Dictionary_Attribute_Givechapterandverse.Add(PmNames.S_TARGET1.Name_Pm, xNd.Value, cur_Cf, false, log_Reports);
                    }
                    else
                    {
                        // エラー
                        goto gt_Error_NoTarget;
                    }
                }


            }

            //ｄｅｓｃｒｉｐｔｉｏｎ（未設定可）
            if (log_Reports.Successful)
            {
                XmlNode xNd = cur_X.Attributes.GetNamedItem(PmNames.S_DESCRIPTION.Name_Attribute);
                if (null != xNd)
                {
                    cur_Cf.Dictionary_Attribute_Givechapterandverse.Add(PmNames.S_DESCRIPTION.Name_Pm, xNd.Value, cur_Cf, true, log_Reports);
                }
            }



            //
            //
            //
            // 子
            //
            //
            //
            XmlElement err_Child_X;
            if (log_Reports.Successful)
            {
                if (bGlobalRfr)
                {
                    if (log_Reports.Successful)
                    {
                        //
                        // ｔａｒｇｅｔ要素
                        //
                        XmlNodeList child_XNl = cur_X.ChildNodes;

                        foreach (XmlNode child_XNode in child_XNl)
                        {
                            if (XmlNodeType.Element == child_XNode.NodeType)
                            {
                                XmlElement xChild = (XmlElement)child_XNode;

                                if (NamesNode.S_TARGET == xChild.Name)
                                {
                                    //
                                    // ｔａｒｇｅｔ要素
                                    //
                                    string sName_Target = xChild.Attributes.GetNamedItem(PmNames.S_NAME.Name_Attribute).Value;

                                    Givechapterandverse_Node cfRfr_Target = new Givechapterandverse_NodeImpl(NamesNode.S_TARGET, cur_Cf);
                                    cfRfr_Target.Dictionary_Attribute_Givechapterandverse.Set(PmNames.S_NAME.Name_Pm, sName_Target, log_Reports);

                                    cur_Cf.List_ChildGivechapterandverse.Add(cfRfr_Target, log_Reports);
                                }
                                else
                                {
                                    // エラー
                                    err_Child_X = xChild;
                                    goto gt_Error_Child;
                                }
                            }

                        }
                    }
                }
            }


            //
            //
            //
            // 親
            //
            //
            //
            string err_SIn;
            if (bGlobalRfr)
            {
                string sIn;
                if (log_Reports.Successful)
                {
                    // 重複チェック用。
                    List<string> sList_In = new List<string>();
                    List<string> sList_Name = new List<string>();


                    //
                    //
                    //
                    // （１）in属性が付いていれば　そちらへ、
                    // （２）nameが付いていれば　そちらへ。
                    // 重複名があれば発見したい。
                    //
                    //
                    //
                    cur_Cf.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_IN, out sIn,
                        false,//空文字列でも構わない。
                        log_Reports);

                    string sName_Rfr;
                    cur_Cf.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Rfr, false, log_Reports);


                    if ("" != sIn)
                    {
                        // トゥゲザー登録ファイルに、in指定での＜ｔｏｇｅｔｈｅｒ＞要素を追加。

                        // 重複チェック。
                        if (!sList_In.Contains(sIn))
                        {
                            sList_In.Add(sIn);
                            parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf, log_Reports);
                        }
                        else
                        {
                            // エラー。
                            err_SIn = sIn;
                            goto gtj_Error_DuplicationIn;
                        }
                    }
                    else if ("" != sName_Rfr)
                    {
                        // トゥゲザー設定ファイルに、name指定での＜ｔｏｇｅｔｈｅｒ＞要素を追加。

                        // 重複チェック。
                        if (!sList_Name.Contains(sName_Rfr))
                        {
                            sList_Name.Add(sName_Rfr);
                            parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf, log_Reports);
                        }
                        else
                        {
                            // エラー
                            goto gt_Error_DuplicationTogether;
                        }
                    }
                    else
                    {
                        // エラー
                        goto gt_Error_Attr;
                    }
                }



                goto gt_EndMethod;
            }
            else
            {

                //
                //
                //
                // 親
                //
                //
                //
                if (log_Reports.Successful)
                {
                    string sOn;
                    cur_Cf.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_ON, out sOn, false, log_Reports);

                    List<Givechapterandverse_Node> listCf_Together = parent_Cf.GetChildrenByNodename(NamesNode.S_TOGETHER, false, log_Reports);
                    foreach (Givechapterandverse_Node cf_Together in listCf_Together)
                    {
                        string sOn2;
                        cf_Together.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_ON, out sOn2, false, log_Reports);

                        if (sOn == sOn2)
                        {
                            // エラー
                            goto gt_Error_DuplicationOn;
                        }
                    }

                    parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf, log_Reports);
                }
            }

            goto gt_EndMethod;
            //
        //
            #region 異常系
        //────────────────────────────────────────
        gtj_Error_DuplicationIn:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー381！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("同じin属性値を持つ<"+NamesNode.S_TOGETHER+">要素がありました。in属性値は重複してはいけません。");
                t.Newline();

                //t.Append("トゥゲザー登録ファイル（絶対パス）=[" + sFpatha + "]");
                //t.Newline();

                t.Append("トゥゲザーのin属性=[" + err_SIn + "]");
                t.Newline();

                // ヒント
                t.Append(r.Message_Givechapterandverse(cur_Cf));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_DuplicationTogether:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー382！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("同名の<" + NamesNode.S_TOGETHER + ">要素がありました。名前は重複してはいけません。");
                t.Newline();

                //t.Append("トゥゲザー登録ファイル（絶対パス）=[" + sFpatha + "]");
                //t.Newline();

                string sName_Tg;
                cur_Cf.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Tg, false, log_Reports);
                t.Append("トゥゲザー名=[" + sName_Tg + "]");
                t.Newline();

                // ヒント
                t.Append(r.Message_Givechapterandverse(cur_Cf));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_DuplicationOn:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー384！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("同名の[" + PmNames.S_ON.Name_Attribute + "]属性を持つ＜" + NamesNode.S_TOGETHER + "＞要素がありました。on属性は重複してはいけません。");
                t.Newline();

                // ヒント
                t.Append(r.Message_Givechapterandverse(parent_Cf));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Attr:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー383！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("<" + NamesNode.S_TOGETHER + ">要素に、in属性、name属性のどちらもありませんでした。どちらかが必要です。");
                t.Newline();

                //t.Append("トゥゲザー登録ファイル（絶対パス）=[" + sFpatha + "]");
                //t.Newline();

                // ヒント
                t.Append(r.Message_Givechapterandverse(cur_Cf));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Child:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー313！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("<" + NamesNode.S_TOGETHER + ">要素に、<ｔａｒｇｅｔ>要素以外の要素[");
                s.Append(err_Child_X.Name);
                s.Append("]が含まれていました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Givechapterandverse(cur_Cf));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NoTarget:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー312！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("<" + NamesNode.S_TOGETHER + ">要素に[" + PmNames.S_TARGET1.Name_Attribute + "]属性がありませんでした。");
                s.Newline();

                s.Append("コントロール設定ファイルの中に書く<" + NamesNode.S_TOGETHER + ">要素では必要です。");
                s.Newline();

                // ヒント
                s.Append(r.Message_Givechapterandverse(parent_Cf));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NoOn:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー311！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("<" + NamesNode.S_TOGETHER + ">要素に[" + PmNames.S_ON.Name_Attribute + "]属性がありませんでした。");
                s.Newline();

                s.Append("コントロール設定ファイルの中に書く<" + NamesNode.S_TOGETHER + ">要素では必要です。");
                s.Newline();

                // ヒント
                s.Append(r.Message_Givechapterandverse(parent_Cf));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return;
        }

        //────────────────────────────────────────

        protected override void Parse_SAttribute(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────
        #endregion



    }
}
