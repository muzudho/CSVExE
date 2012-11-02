using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Xenon.Syntax;
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.XmlToConf
{
    public class Utility_XmlToConfigurationtree_NodeImpl
    {



        #region アクション
        //────────────────────────────────────────

        public static Usercontrol GetUsercontrol(
            Configurationtree_Node cf_CurTree,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XmlToConf.Name_Library, "Util_XmlToConfigurationtree_NodeImpl", "GetUsercontrol",log_Reports);

            Usercontrol fcUc = null;
            string sFcName;
            string err_FcName;

            //
            // 対応するコントロール。
            List<Usercontrol> list_Usercontrol;
            {
                // コントロール名。
                Expression_Node_StringImpl ec_String = new Expression_Node_StringImpl(null, memoryApplication.MemoryValidators.Configurationtree_Validatorsconfig);
                {
                    PmName pmName = PmNames.S_NAME;
                    if (cf_CurTree.Dictionary_Attribute.ContainsKey(pmName.Name_Pm))
                    {
                        cf_CurTree.Dictionary_Attribute.TryGetValue(pmName, out sFcName, true, log_Reports);

                        ec_String.AppendTextNode(
                            sFcName,
                            memoryApplication.MemoryValidators.Configurationtree_Validatorsconfig,
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_FcName, log_Reports);//関数名
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(memoryApplication.MemoryValidators.Configurationtree_Validatorsconfig), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:8001;", tmpl, log_Reports);
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
        public static List<Configurationtree_Node> SelectItemsBySAttrAsCsv(
            List<Configurationtree_Node> items,
            PmName pmName/*string sName_Attr*/,
            string sValue_Expected,
            bool bRemove,
            EnumHitcount hits,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XmlToConf.Name_Library, "Util_XmlToConfigurationtree_NodeImpl", "SelectItemsBySAttrAsCsv",log_Reports);

            List<Configurationtree_Node> cfList_Result = new List<Configurationtree_Node>();

            for (int nI = 0; nI < items.Count; nI++ )
            {
                Configurationtree_Node cf_Item = items[nI];

                if (log_Reports.Successful)
                {
                    string sValue_Attr;
                    bool bHit = cf_Item.Dictionary_Attribute.TryGetValue(pmName, out sValue_Attr, false, log_Reports);
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


                            if (EnumHitcount.First_Exist == hits ||
                                EnumHitcount.First_Exist_Or_Zero == hits)
                            {
                                // 最初の１件で削除は終了。複数件ヒットするかどうかは判定しない。
                                break;
                            }
                        }
                    }
                }
            }


            //ystem.Console.WriteLine(Info_Forms.LibraryName + ":EUtil_NodeImpl.GetItemsByAttrAsCsv: 直後 list_Result.Count=[" + list_Result.Count + "]");


            if (EnumHitcount.One == hits)
            {
                // 必ず１件だけヒットする想定。

                if (cfList_Result.Count != 1)
                {
                    goto gt_errorNotOne;
                }
            }
            else if (EnumHitcount.First_Exist == hits)
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
            else if (EnumHitcount.First_Exist_Or_Zero == hits)
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, cfList_Result.Count.ToString(), log_Reports);//検索ヒット数

                memoryApplication.CreateErrorReport("Er:8002;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_errorNotOne:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, cfList_Result.Count.ToString(), log_Reports);//検索ヒット数

                memoryApplication.CreateErrorReport("Er:8003;", tmpl, log_Reports);
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
