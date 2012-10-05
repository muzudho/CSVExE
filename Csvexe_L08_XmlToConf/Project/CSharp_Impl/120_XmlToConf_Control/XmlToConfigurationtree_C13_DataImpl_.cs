using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.XmlToConf
{


    /// <summary>
    /// ＜ｄａｔａ＞　→　「S■ｄａｔａ」
    /// </summary>
    class XmlToConfigurationtree_C13_DataImpl_ : XmlToConfigurationtree_C_Parser15Impl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 変換。
        /// </summary>
        /// <param select="x_cur"></param>
        /// <param select="s_Parent"></param>
        /// <param select="log_Reports"></param>
        public override void XmlToConfigurationtree(
            XmlElement cur_X,//＜ｄａｔａ＞
            Configurationtree_Node parent_Cf,//「Cf■ｃｏｎｔｒｏｌ」
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XmlToConf.Name_Library, this, "XToCf",log_Reports);
            //
            //



            //
            //
            //
            // 自
            //
            //
            //
            Configurationtree_Node cur_Cf = this.CreateMyself(cur_X, parent_Cf, memoryApplication, log_Reports);



            //
            //
            //
            // 属性
            //
            //
            //
            this.Parse_SAttribute(cur_X, cur_Cf, memoryApplication, log_Reports);



            //
            //
            //
            // 属性テスト
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Test_Attributes(cur_X, cur_Cf, memoryApplication, log_Reports);
            }




            //
            //
            //
            // 子
            //
            //
            //
            if (log_Reports.Successful)
            {
                XmlToConfigurationtree_C14_HubImpl to = new XmlToConfigurationtree_C14_HubImpl();
                to.XmlToConfigurationtree(
                    cur_X,
                    cur_Cf,
                    memoryApplication,
                    log_Reports
                    );
            }



            //
            //
            //
            // 親へ連結
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.LinkToParent(cur_Cf, parent_Cf, memoryApplication, log_Reports);
            }





            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 属性テスト
        /// </summary>
        /// <param name="x_Cur"></param>
        /// <param name="s_Cur"></param>
        /// <param name="log_Reports"></param>
        protected override void Test_Attributes(XmlElement cur_X, Configurationtree_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XmlToConf.Name_Library, this, "Test_Attributes",log_Reports);

            string sMemory;
            cur_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_MEMORY, out sMemory, false, log_Reports);

            string sAccess_Src;
            cur_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_ACCESS, out sAccess_Src, false, log_Reports);

            //
            // ａｃｃｅｓｓ
            //
            bool bExists_To=false;
            string err_sAccess;
            {
                CsvTo_ListImpl to = new CsvTo_ListImpl();
                List<string> listS = to.Read(sAccess_Src);
                foreach (string sAccess1 in listS)
                {
                    if (ValuesAttr.S_FROM == sAccess1)
                    {
                        // ・読取り。（読取り専用とは限らない。writeは別＜ｄａｔａ＞で書く可能性もある）。
                    }
                    else if (ValuesAttr.S_TO == sAccess1)
                    {
                        // ・書出し。（書出し専用とは限らない。readは別＜ｄａｔａ＞で書く可能性もある）。
                        bExists_To = true;
                    }
                    //else if (ValuesAttr.S_FROM + "," + ValuesAttr.S_TO == sAccess)//"from,to"
                    //{
                    //    // ・読み書き両用。
                    //}
                    else
                    {
                        // ｆｒｏｍでも、ｔｏでもないものが指定されていれば、エラー。
                        err_sAccess = sAccess1;
                        goto gt_Error_AttrAccess;
                    }
                }

            }

            //
            //ｍｅｍｏｒｙ
            //
            if (!(
                ValuesAttr.S_NONE == sMemory ||
                ValuesAttr.S_CELL == sMemory ||
                ValuesAttr.S_RECORDS == sMemory ||
                ValuesAttr.S_VARIABLE == sMemory
                ))
            {
                // 無いものを指定したらエラー
                goto gt_Error_AttrType;
            }

            //
            //ａｃｃｅｓｓ属性に「ｔｏ」が指定されていない時に、ｍｅｍｏｒｙ属性に「ｎｏｎｅ」「ｃｅｌｌ」「ｒｅｃｏｒｄｓ」以外のものが設定されていれば、エラー。
            //
            if (!bExists_To && (ValuesAttr.S_NONE != sMemory && ValuesAttr.S_CELL != sMemory && ValuesAttr.S_RECORDS != sMemory))
            {
                goto gt_Error_GhostTarget;
            }


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_GhostTarget:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, PmNames.S_ACCESS.Name_Attribute, log_Reports);//属性名access
                tmpl.SetParameter(2, ValuesAttr.S_TO, log_Reports);//属性値to
                tmpl.SetParameter(3, PmNames.S_MEMORY.Name_Attribute, log_Reports);//属性名memory

                StringBuilder s1 = new StringBuilder();
                s1.Append("「");
                s1.Append(ValuesAttr.S_NONE);
                s1.Append("」「");
                s1.Append(ValuesAttr.S_CELL);
                s1.Append("」「");
                s1.Append(ValuesAttr.S_RECORDS);
                s1.Append("」");
                tmpl.SetParameter(4, s1.ToString(), log_Reports);//属性値

                tmpl.SetParameter(5, Log_RecordReportsImpl.ToText_Configurationtree(cur_Cf), log_Reports);//設定位置パンくずリスト

                //ａｃｃｅｓｓ属性に「ｔｏ」が指定されていない時に、ｔａｒｇｅｔ属性に「ｎｏｎｅ」「ｃｅｌｌ」「ｌｉｓｔｂｏｘ」以外のものが設定されていました。これはエラーです。
                //
                //ａｃｃｅｓｓ属性に「ｔｏ」が指定されていない場合は、ｔａｒｇｅｔ属性は「ｎｏｎｅ」「ｃｅｌｌ」「ｌｉｓｔｂｏｘ」のいずれかにしなければなりません。

                memoryApplication.CreateErrorReport("Er:8020;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_AttrType:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, PmNames.S_MEMORY.Name_Attribute, log_Reports);//属性名memory
                tmpl.SetParameter(2, sMemory, log_Reports);//属性名memoryの値

                StringBuilder s1 = new StringBuilder();
                s1.Append("「");
                s1.Append(ValuesAttr.S_CELL);
                s1.Append("」「");
                s1.Append(ValuesAttr.S_RECORDS);
                s1.Append("」「");
                s1.Append(ValuesAttr.S_VARIABLE);
                s1.Append("」");
                tmpl.SetParameter(3, s1.ToString(), log_Reports);//属性値

                tmpl.SetParameter(4, Log_RecordReportsImpl.ToText_Configurationtree(cur_Cf), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:8021;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_AttrAccess:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, PmNames.S_ACCESS.Name_Attribute, log_Reports);//属性名access
                tmpl.SetParameter(2, err_sAccess, log_Reports);//access属性の値
                tmpl.SetParameter(3, sAccess_Src, log_Reports);//access指定値全文

                StringBuilder s1 = new StringBuilder();
                s1.Append("「");
                s1.Append(ValuesAttr.S_FROM);
                s1.Append("」「");
                s1.Append(ValuesAttr.S_TO);
                s1.Append("」指定なし");
                tmpl.SetParameter(4, s1.ToString(), log_Reports);//属性値

                tmpl.SetParameter(5, Log_RecordReportsImpl.ToText_Configurationtree(cur_Cf), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:8022;", tmpl, log_Reports);
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
        protected override void LinkToParent(Configurationtree_Node cur_Cf, Configurationtree_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            string sAccess;
            cur_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_ACCESS, out sAccess, false, log_Reports);

            bool bHit = false;

            List<string> sList_Access = new CsvTo_ListImpl().Read(sAccess);
            foreach (string sAccess2 in sList_Access)
            {
                if (ValuesAttr.S_FROM == sAccess2)
                {
                    // データソース用。
                    bHit = true;
                }
                else if (ValuesAttr.S_TO == sAccess2)
                {
                    // データターゲット用。
                    bHit = true;
                }
                else
                {
                    // ａｃｃｅｓｓ属性の有無は既にチェック済みのはず。
                    throw new Exception("未定義のａｃｃｅｓｓ属性の値[" + sAccess2 + "]");
                }
            }


            if (bHit)
            {
                parent_Cf.List_Child.Add(cur_Cf, log_Reports);
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
