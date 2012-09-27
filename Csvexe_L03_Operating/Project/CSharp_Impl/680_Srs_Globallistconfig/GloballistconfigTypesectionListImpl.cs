using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    public class GloballistconfigTypesectionListImpl : GloballistconfigTypesectionList
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public GloballistconfigTypesectionListImpl()
        {
            this.list_Items = new List<GloballistconfigTypesection>();
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        public bool ContainsType(string sType)
        {
            bool bResult = false;

            foreach (GloballistconfigTypesection typeSection in this.list_Items)
            {
                if (typeSection.SType == sType)
                {
                    bResult = true;
                    break;
                }
            }

            return bResult;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected List<GloballistconfigTypesection> list_Items;

        /// <summary>
        /// 変数の型セクションのリスト。
        /// </summary>
        public List<GloballistconfigTypesection> List_Item
        {
            get
            {
                return list_Items;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
