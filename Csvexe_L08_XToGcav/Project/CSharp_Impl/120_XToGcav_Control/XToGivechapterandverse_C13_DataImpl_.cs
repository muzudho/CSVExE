using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.XToGcav
{


    /// <summary>
    /// ＜ｄａｔａ＞　→　「S■ｄａｔａ」
    /// </summary>
    class XToConfigurationtree_C13_DataImpl_ : XToConfigurationtree_C_Parser15Impl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 変換。
        /// </summary>
        /// <param select="x_cur"></param>
        /// <param select="s_Parent"></param>
        /// <param select="log_Reports"></param>
        public override void XToConfigurationtree(
            XmlElement cur_X,//＜ｄａｔａ＞
            Configurationtree_Node parent_Cf,//「Cf■ｃｏｎｔｒｏｌ」
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToCf",log_Reports);
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
                this.Test_Attributes(cur_X, cur_Cf, log_Reports);
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
                XToConfigurationtree_C14_HubImpl to = new XToConfigurationtree_C14_HubImpl();
                to.XToConfigurationtree(
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
        protected override void Test_Attributes(XmlElement cur_X, Configurationtree_Node cur_Cf, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "Test_Attributes",log_Reports);

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
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー810！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                //ａｃｃｅｓｓ属性に「ｔｏ」が指定されていない時に、ｔａｒｇｅｔ属性に「ｎｏｎｅ」「ｃｅｌｌ」「ｌｉｓｔｂｏｘ」以外のものが設定されていました。これはエラーです。
                //
                //ａｃｃｅｓｓ属性に「ｔｏ」が指定されていない場合は、ｔａｒｇｅｔ属性は「ｎｏｎｅ」「ｃｅｌｌ」「ｌｉｓｔｂｏｘ」のいずれかにしなければなりません。
                s.Append(PmNames.S_ACCESS.Name_Attribute);
                s.Append("属性に「");
                s.Append(ValuesAttr.S_TO);
                s.Append("」が指定されていない時に、");
                s.Append(PmNames.S_MEMORY.Name_Attribute);
                s.Append("属性に「");
                s.Append(ValuesAttr.S_NONE);
                s.Append("」「");
                s.Append(ValuesAttr.S_CELL);
                s.Append("」「");
                s.Append(ValuesAttr.S_RECORDS);
                s.Append("」以外のものが設定されていました。これはエラーです。");
                s.Newline();
                s.Newline();

                s.Append(PmNames.S_ACCESS.Name_Attribute);
                s.Append("属性に「");
                s.Append(ValuesAttr.S_TO);
                s.Append("」が指定されていない場合は、");
                s.Append(PmNames.S_MEMORY.Name_Attribute);
                s.Append("属性は「");
                s.Append(ValuesAttr.S_NONE);
                s.Append("」「");
                s.Append(ValuesAttr.S_CELL);
                s.Append("」「");
                s.Append(ValuesAttr.S_RECORDS);
                s.Append("」のいずれかにしなければなりません。");
                s.Newline();
                s.Newline();

                // ヒント
                s.Append(r.Message_Configurationtree(cur_Cf));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_AttrType:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー809！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append(PmNames.S_MEMORY.Name_Attribute+"属性値[" + sMemory + "]はエラーです。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("「" + ValuesAttr.S_CELL + "」「" + ValuesAttr.S_RECORDS + "」「" + ValuesAttr.S_VARIABLE + "」、のいずれかを指定してください。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configurationtree(cur_Cf));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_AttrAccess:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー809！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append(PmNames.S_ACCESS.Name_Attribute+"属性値[" + err_sAccess + "]はエラーです。指定全文=[" + sAccess_Src + "]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("「" + ValuesAttr.S_FROM + "」、「" + ValuesAttr.S_TO + "」、指定なし、のいずれかを指定してください。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configurationtree(cur_Cf));

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
