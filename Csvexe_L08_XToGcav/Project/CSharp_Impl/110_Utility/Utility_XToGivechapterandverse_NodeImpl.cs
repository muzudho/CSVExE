using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Xenon.Syntax;
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.XToGcav
{
    public class Utility_XToGivechapterandverse_NodeImpl
    {



        #region アクション
        //────────────────────────────────────────

        public static Usercontrol GetUsercontrol(
            Givechapterandverse_Node cf_Cur,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, "Util_XToGivechapterandverse_NodeImpl", "GetUsercontrol",log_Reports);

            Usercontrol fcUc = null;
            string sFcName;
            string err_FcName;

            //
            // 対応するコントロール。
            List<Usercontrol> list_Usercontrol;
            {
                // コントロール名。
                Expression_Node_StringImpl ec_String = new Expression_Node_StringImpl(null, memoryApplication.MemoryValidators.Givechapterandverse_Validatorsconfig);
                {
                    PmName pmName = PmNames.S_NAME;
                    if (cf_Cur.Dictionary_Attribute_Givechapterandverse.ContainsKey(pmName.Name_Pm))
                    {
                        cf_Cur.Dictionary_Attribute_Givechapterandverse.TryGetValue(pmName, out sFcName, true, log_Reports);

                        ec_String.AppendTextNode(
                            sFcName,
                            memoryApplication.MemoryValidators.Givechapterandverse_Validatorsconfig,
                            log_Reports
                            );
                    }
                    else
                    {
                        //
                        // エラー。
                        err_FcName = "＜コントロール名無し＞";
                        goto gt_Error_NotFoundFc02;
                    }

                }


                list_Usercontrol = memoryApplication.MemoryForms.GetUsercontrolsByName(
                    ec_String,
                    true,
                    log_Reports
                    );
            }

            if (list_Usercontrol.Count < 1)
            {
                //
                // エラー。
                err_FcName = sFcName;
                goto gt_Error_NotFoundFc02;
            }
            else
            {
                fcUc = list_Usercontrol[0];
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundFc02:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー396！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("[" + err_FcName + "]という名前のコントロールは、存在しません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("バリデーション設定ファイル読取時。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(memoryApplication.MemoryValidators.Givechapterandverse_Validatorsconfig));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return fcUc;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 例えば　（"ａｃｃｅｓｓ","ｆｒｏｍ"）と指定すれば、
        /// 指定リストの要素の中で　「～　ａｃｃｅｓｓ＝”ｆｒｏｍ,to”」 といった属性を持つものはヒットする。
        /// 
        /// 選択アイテムをリストから除外するなら bRemove=true にします。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="sExpectedValue"></param>
        /// <param name="request_Items"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public static List<Givechapterandverse_Node> SelectItemsBySAttrAsCsv(
            List<Givechapterandverse_Node> items, PmName pmName/*string sName_Attr*/, string sValue_Expected, bool bRemove, Request_Selecting request, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, "Util_XToGivechapterandverse_NodeImpl", "SelectItemsBySAttrAsCsv",log_Reports);

            List<Givechapterandverse_Node> cfList_Result = new List<Givechapterandverse_Node>();

            for (int nI = 0; nI < items.Count; nI++ )
            {
                Givechapterandverse_Node cf_Item = items[nI];

                if (log_Reports.Successful)
                {
                    string sValue_Attr;
                    bool bHit = cf_Item.Dictionary_Attribute_Givechapterandverse.TryGetValue(pmName, out sValue_Attr, false, log_Reports);
                    if (bHit)
                    {
                        CsvTo_ListImpl to = new CsvTo_ListImpl();
                        List<string> sList_Value = to.Read(sValue_Attr);

                        if (sList_Value.Contains(sValue_Expected))
                        {
                            cfList_Result.Add(cf_Item);

                            if (bRemove)
                            {
                                // 削除
                                items.RemoveAt(nI);
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


            //ystem.Console.WriteLine(Info_Forms.LibraryName + ":EUtil_NodeImpl.GetItemsByAttrAsCsv: 直後 list_Result.Count=[" + list_Result.Count + "]");


            if (EnumHitcount.One == request.EnumHitcount)
            {
                // 必ず１件だけヒットする想定。

                if (cfList_Result.Count != 1)
                {
                    goto gt_errorNotOne;
                }
            }
            else if (EnumHitcount.First_Exist == request.EnumHitcount)
            {
                // 必ずヒットする。複数件あれば、最初の１件だけ取得。

                if (0 == cfList_Result.Count)
                {
                    goto gt_errorNoHit;
                }
                else if (1 < cfList_Result.Count)
                {
                    cfList_Result.RemoveRange(1, cfList_Result.Count - 1);
                }
            }
            else if (EnumHitcount.First_Exist_Or_Zero == request.EnumHitcount)
            {
                // ヒットすれば最初の１件だけ、ヒットしなければ０件の想定。

                if (1 < cfList_Result.Count)
                {
                    cfList_Result.RemoveRange(1, cfList_Result.Count - 1);
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
        gt_errorNoHit:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー102！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("必ず、１件以上ヒットする指定でしたが、[");
                s.Append(cfList_Result.Count);
                s.Append("]件ヒットしました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_errorNotOne:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("必ず、１件のみ取得する指定でしたが、[");
                s.Append(cfList_Result.Count);
                s.Append("]件取得しました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        gt_EndMethod:
            return cfList_Result;
        }

        //────────────────────────────────────────
        #endregion



    }
}
