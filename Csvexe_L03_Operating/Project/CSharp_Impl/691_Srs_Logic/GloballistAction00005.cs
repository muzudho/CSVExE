using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Operating
{
    /// <summary>
    /// グローバル・リスト・ライン検索
    /// 
    /// 旧名：SearcherOfGlConfigElement#Search
    /// </summary>
    public class GloballistAction00005
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sHuman">担当者名</param>
        /// <param name="moGlcnf"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public List<ResultOfGloballistconfigElementSearch> Perform(
            string sHuman,
            MemoryGloballistconfig moGlcnf,
            Log_Reports log_Reports
            )
        {
            List<ResultOfGloballistconfigElementSearch> resultList = new List<ResultOfGloballistconfigElementSearch>();

            if (null == sHuman)
            {
                // 担当者名が未指定の場合

                // 空リストになります。
            }
            else
            {
                // 担当者
                GloballistconfigHuman human = moGlcnf.Dictionary_Human[sHuman];

                // 各変数の型について
                foreach (GloballistconfigTypesection typeSection in moGlcnf.TypesectionList.List_Item)
                {
                    if (human.Dictionary_Variable.ContainsKey(typeSection.Name_Type))
                    {
                        // この型について
                        GloballistconfigVariable variable = human.Dictionary_Variable[typeSection.Name_Type];

                        // その変数番号要素をリストにします。

                        // 番号別優先順位設定について
                        foreach (GloballistconfigNumber numberObj in variable.Dictionary_Number.Values)
                        {
                            ResultOfGloballistconfigElementSearchImpl resultItem = new ResultOfGloballistconfigElementSearchImpl();
                            resultItem.Name_Type = variable.Name_Type;
                            resultItem.Text_NumberRange = numberObj.Text_Range;
                            resultItem.Priority = numberObj.Priority.Text;

                            resultList.Add(resultItem);
                        }
                    }
                }
            }

            return resultList;
        }

        //────────────────────────────────────────
        #endregion



    }
}
