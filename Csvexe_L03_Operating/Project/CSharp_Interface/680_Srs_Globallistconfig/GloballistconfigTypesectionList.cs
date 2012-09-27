using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    public interface GloballistconfigTypesectionList
    {



        #region 判定
        //────────────────────────────────────────

        bool ContainsType(string sType);
        
        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 変数の型セクションのリスト。並び順を保持すること。
        /// </summary>
        List<GloballistconfigTypesection> List_Item
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
