using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Table;

namespace Xenon.Controls
{
    public abstract class Utility_Expression_NodeImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 指定の属性を持っていれば、無条件一致
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="sExpectedValue"></param>
        /// <param name="request_Items"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public static List<Expression_Node_String> SelectItemsByPmAsCsv_Unconditional(
            List<Expression_Node_String> ecList_Item, string sPmName, bool bRemove,
            Request_Selecting request, Log_Reports log_Reports)
        {
            return Utility_Expression_NodeImpl.SelectItemsByPmAsCsv_Full_(
                ecList_Item,
                sPmName,
                true,
                "",
                bRemove,
                request,
                log_Reports
                );
        }

        //────────────────────────────────────────

        /// <summary>
        /// 例えば　（"ａｃｃｅｓｓ",”ｆｒｏｍ”）と指定すれば、
        /// 指定リストの要素の中で　＜～　ａｃｃｅｓｓ＝”ｆｒｏｍ,to”＞ といった属性を持つものはヒットする。
        /// 
        /// 選択アイテムをリストから除外するなら bRemove=true にします。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="sExpectedValue"></param>
        /// <param name="request_Items"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public static List<Expression_Node_String> SelectItemsByPmAsCsv(
            List<Expression_Node_String> ecList_Item, string sPmName, string sExpectedValue,
            bool bRemove, Request_Selecting request, Log_Reports log_Reports)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Controls.Name_Library, "Util_E_NodeImpl", "SelectItemsByAttrAsCsv",log_Reports);
            //
            //
            //Util_E_NodeImpl dammy_This = new Util_E_NodeImpl();

            List<Expression_Node_String> ecList_Result;
            ecList_Result =  Utility_Expression_NodeImpl.SelectItemsByPmAsCsv_Full_(
                ecList_Item,
                sPmName,
                false,
                sExpectedValue,
                bRemove,
                request,
                log_Reports
                );

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);

            // 正常終了
            return ecList_Result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 例えば　（"ａｃｃｅｓｓ",”ｆｒｏｍ”）と指定すれば、
        /// 指定リストの要素の中で　＜～　ａｃｃｅｓｓ＝”ｆｒｏｍ,to”＞ といった属性を持つものはヒットする。
        /// 
        /// 選択アイテムをリストから除外するなら bRemove=true にします。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="sExpectedValue"></param>
        /// <param name="request_Items"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        private static List<Expression_Node_String> SelectItemsByPmAsCsv_Full_(
            List<Expression_Node_String> ecList_Item,
            string sPmName,
            bool bUnconditional,//無条件一致なら真
            string sExpectedValue,
            bool bRemove,
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Controls.Name_Library, "Util_E_NodeImpl", "SelectItemsByAttrAsCsv_Full_",log_Reports);
            //
            //
            //Util_E_NodeImpl dammy_This = new Util_E_NodeImpl();

            List<Expression_Node_String> ecList_Result = new List<Expression_Node_String>();

            for (int nI = 0; nI < ecList_Item.Count; nI++ )
            {
                Expression_Node_String ec_Item = ecList_Item[nI];

                if (log_Reports.Successful)
                {
                    Expression_Node_String ec_AttrValue;
                    bool bHit = ec_Item.Dictionary_Expression_Attribute.TrySelect(out ec_AttrValue, sPmName, false, Request_SelectingImpl.Unconstraint, log_Reports);
                    if (bHit)
                    {
                        string sAttrValue = ec_AttrValue.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                        CsvTo_ListImpl to = new CsvTo_ListImpl();
                        List<string> sList_Value = to.Read(sAttrValue);

                        bool bHit10 = false;

                        if(bUnconditional)
                        {
                            //if(""!=sAttrValue)
                            //{
                                bHit = true;
                            //}
                        }
                        else if(sList_Value.Contains(sExpectedValue))
                        {
                            bHit10 = true;
                        }

                        if (bHit10)
                        {
                            ecList_Result.Add(ec_Item);

                            if (bRemove)
                            {
                                // 削除
                                ecList_Item.RemoveAt(nI);
                                nI--;
                            }


                            if (EnumHitcount.First_Exist == request.EnumHitcount ||
                                EnumHitcount.First_Exist_Or_Zero == request.EnumHitcount)
                            {
                                // 最初の１件で削除は終了。複数件ヒットするかどうかは判定しない。
                                break;
                            }
                        }
                    }
                }
            }


            //ystem.Console.WriteLine(Info_Forms.LibraryName + ":Util_E_NodeImpl.GetItemsByAttrAsCsv: 直後 list_E_Result.Count=[" + list_E_Result.Count + "]");


            if (EnumHitcount.One == request.EnumHitcount)
            {
                // 必ず１件だけヒットする想定。

                if (ecList_Result.Count != 1)
                {
                    goto gt_Error_NotOne;
                }
            }
            else if (EnumHitcount.First_Exist == request.EnumHitcount)
            {
                // 必ずヒットする。複数件あれば、最初の１件だけ取得。

                if (0 == ecList_Result.Count)
                {
                    goto gt_Error_NoHit;
                }
                else if (1 < ecList_Result.Count)
                {
                    ecList_Result.RemoveRange(1, ecList_Result.Count - 1);
                }
            }
            else if (EnumHitcount.First_Exist_Or_Zero == request.EnumHitcount)
            {
                // ヒットすれば最初の１件だけ、ヒットしなければ０件の想定。

                if (1 < ecList_Result.Count)
                {
                    ecList_Result.RemoveRange(1, ecList_Result.Count - 1);
                }
            }
            else
            {
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NoHit:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー102！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("必ず、１件以上ヒットする指定でしたが、[");
                s.Append(ecList_Result.Count);
                s.Append("]件ヒットしました。");
                s.Newline();
                s.Newline();

                s.AppendI(1, "ヒット件数=[");
                s.Append(ecList_Result.Count);
                s.Append("]");
                s.Newline();

                s.AppendI(1, "items.Count=[");
                s.Append(ecList_Item.Count);
                s.Append("]");
                s.Newline();

                s.AppendI(1, "sPmName=[");
                s.Append(sPmName);
                s.Append("]");
                s.Newline();

                s.AppendI(1, "無条件一致か？=[");
                s.Append(bUnconditional);
                s.Append("]");
                s.Newline();

                s.AppendI(1, "sExpectedValue=[");
                s.Append(sExpectedValue);
                s.Append("]");
                s.Newline();

                s.AppendI(1, "bRemove=[");
                s.Append(bRemove);
                s.Append("]");
                s.Newline();


                s.AppendI(1, "request_Items.EnumHitcount=[");
                s.Append(request.EnumHitcount);
                s.Append("]");
                s.Newline();

                

                s.Append("┌────────┐処理後に残った内容　要素数＝[");
                s.Append(ecList_Item.Count);
                s.Append("]");
                s.Newline();
                foreach (Expression_Node_String e_Item2 in ecList_Item)
                {
                    string sAttrNameValue;
                    bool bHit = e_Item2.Dictionary_Expression_Attribute.TrySelect(out sAttrNameValue, sPmName, false, Request_SelectingImpl.Unconstraint, log_Reports);

                    s.AppendI(1, "・「E■[");
                    s.Append(e_Item2.Cur_Configurationtree.Name);
                    s.Append("]　ｎａｍｅ＝”[");
                    s.Append(sAttrNameValue);
                    s.Append("]　値＝”[");
                    s.Append(e_Item2.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                    s.Append("]”」");
                    s.Newline();

                    e_Item2.ToText_Snapshot(s);

                }
                s.Append("└────────┘");
                s.Newline();

                // ヒント
                if(1<ecList_Item.Count)
                {
                    Expression_Node_String parent_Expr = ecList_Item[0].Parent_Expression;
                    if (null != parent_Expr)
                    {
                        s.Append("┌────────┐先頭要素の親");
                        s.Newline();
                        parent_Expr.ToText_Snapshot(s);
                        s.Append("└────────┘");
                        s.Newline();
                    }
                }

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotOne:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("必ず、１件のみ取得する指定でしたが、[");
                s.Append(ecList_Result.Count);
                s.Append("]件取得しました。");
                s.Newline();
                s.Newline();

                s.AppendI(1, "sPmName=[");
                s.Append(sPmName);
                s.Append("]");
                s.Newline();

                s.AppendI(1, "無条件一致か？=[");
                s.Append(bUnconditional);
                s.Append("]");
                s.Newline();

                s.AppendI(1, "sExpectedValue=[");
                s.Append(sExpectedValue);
                s.Append("]");
                s.Newline();

                s.AppendI(1, "bRemove=[");
                s.Append(bRemove);
                s.Append("]");
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return ecList_Result;
        }

        //────────────────────────────────────────
        #endregion



    }
}
