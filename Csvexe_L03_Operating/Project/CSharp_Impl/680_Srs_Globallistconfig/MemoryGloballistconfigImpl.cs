using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//O_IntegerRanges
using Xenon.Table;//XenonValue_IntImpl

namespace Xenon.Operating
{
    /// <summary>
    /// グローバルリスト設定。
    /// 
    /// （Model Of Global List Config Implementation）
    /// </summary>
    public class MemoryGloballistconfigImpl : MemoryGloballistconfig
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryGloballistconfigImpl()
        {
            this.typeSectionList = new GloballistconfigTypesectionListImpl();
            this.humanDictionary = new Dictionary<string, GloballistconfigHuman>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 担当者名を全て返します。
        /// </summary>
        /// <returns></returns>
        public List<string> GetSHumans()
        {
            List<string> humanNames = new List<string>();

            foreach (string humanName in this.humanDictionary.Keys)
            {
                humanNames.Add(humanName);
            }

            return humanNames;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 指定の番号の変数について、担当者が複数いたとき、どの担当者が優先されるかを調べます。
        /// </summary>
        /// <param name="typeName">例：[I]</param>
        /// <param name="numberStr">例：970</param>
        /// <param name="humanNames">例：「太郎 | 二郎 | 三郎」</param>
        /// <param name="log_Reports">エラー処理オブジェクト</param>
        /// <returns>担当者名</returns>
        public string SearchHuman(
            string typeName, string sNumber, string humanNames, Log_Reports log_Reports)
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Operating.SName_Library, this, "SearchHuman", log_Reports);

            //
            //
            //
            //

            // 現在、最も大きな値の「優先番号」。
            int highPriority = int.MinValue;
            // 現在、最も優先されている担当者の名前。
            string highHumanName = "";

            int nVariable;
            if (!int.TryParse(sNumber, out nVariable))
            {
                // エラー
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー1008！", pg_Method);
                    r.SMessage = "入力数値[" + sNumber + "]を、int型整数に変換できませんでした。";
                    log_Reports.EndCreateReport();
                }

                return "";
            }

            // 指定の担当者名をリスト化します。
            List<string> humanNameList = new List<string>();
            {
                string[] humanNameArray = humanNames.Split('|');
                foreach (string humanName in humanNameArray)
                {
                    humanNameList.Add(humanName.Trim());
                }
            }

            // 各担当者について
            foreach (GloballistconfigHuman human in this.humanDictionary.Values)
            {
                // 指定された担当者名か否か。
                if (humanNameList.Contains(human.SName))
                {
                    // 指定された担当者名なら


                    // 各変数の型について
                    foreach (GloballistconfigVariable variable in human.Dictionary_Variable.Values)
                    {
                        // 指定の変数の型と一致するかどうか。

                        if (variable.SType == typeName)
                        {
                            // 指定の変数の型と一致した場合


                            // 番号別優先順位設定について
                            CfToO_IntegerRanges sToO = new CfToO_IntegerRanges();
                            foreach (GloballistconfigNumber numberObj in variable.Dictionary_Number.Values)
                            {
                                O_IntegerRanges o_Ranges2;
                                StringBuilder sInfoMsg = new StringBuilder();
                                string sErrorMsg;
                                if (sToO.CfToO(numberObj.SRange, out o_Ranges2, ref sInfoMsg, out sErrorMsg))
                                {
                                    // 正常時

                                    // 各番号について
                                    List<int> numbers = new List<int>();
                                    o_Ranges2.ToNumbers(ref numbers);

                                    foreach (int number in numbers)
                                    {
                                        if (nVariable == number)
                                        {
                                            // 条件に含む番号なら

                                            // 優先順位を比較します。
                                            int numberRef;

                                            XenonValue_IntImpl.TryParse(
                                                numberObj.Priority,
                                                out numberRef,
                                                EnumOperationIfErrorvalue.Error,
                                                null,
                                                log_Reports
                                                );
                                            if (!log_Reports.BSuccessful)
                                            {
                                                // エラー
                                                goto gt_EndMethod;
                                            }

                                            if (log_Reports.BSuccessful)
                                            {
                                                // 正常時

                                                if (highPriority < numberRef)
                                                {
                                                    // 優先順位が高ければ

                                                    highPriority = numberRef;
                                                    highHumanName = human.SName;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // 条件に含まない番号なら
                                        }
                                    }
                                }

                                if (0 < sInfoMsg.Length)
                                {
                                    // 情報・警告
                                    if (log_Reports.CanCreateReport)
                                    {
                                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Warning);
                                        r.SMessage = sInfoMsg.ToString();
                                        sInfoMsg.Length = 0;
                                        log_Reports.EndCreateReport();
                                    }
                                }

                                if ("" != sErrorMsg)
                                {
                                    // エラー
                                    if (log_Reports.CanCreateReport)
                                    {
                                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                                        r.SMessage = sErrorMsg;
                                        log_Reports.EndCreateReport();
                                    }
                                    goto gt_EndMethod;
                                }

                            }
                        }
                        else
                        {
                            // 指定とは異なる変数の型の場合

                        }


                    }//foreach 各変数の型について
                }

            }

            //
        //
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return highHumanName;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected GloballistconfigTypesectionList typeSectionList;

        /// <summary>
        /// 変数の型セクションのリスト。
        /// </summary>
        public GloballistconfigTypesectionList TypesectionList
        {
            get
            {
                return typeSectionList;
            }
        }

        //────────────────────────────────────────

        protected Dictionary<string, GloballistconfigHuman> humanDictionary;

        /// <summary>
        /// human要素の連想配列。
        /// </summary>
        public Dictionary<string, GloballistconfigHuman> Dictionary_Human
        {
            get
            {
                return humanDictionary;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
