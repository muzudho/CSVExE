using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// (Model Of Global List)
    /// </summary>
    public interface MemoryGloballist
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// クリアーします。
        /// </summary>
        void Clear();

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// GlobalList.txtの一行分のデータを追加します。
        /// </summary>
        /// <param name="glLine"></param>
        void AddLine(MemoryGloballistLine glLine);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 変数の型毎に区切られた、変数のリスト。(type section)
        /// 
        /// [変数の型名,[変数の番号,GlLine]]
        /// </summary>
        Dictionary<string, Dictionary<int, MemoryGloballistLine>> Dictionary_Typesection
        {
            set;
            get;
        }
        
        //────────────────────────────────────────
        #endregion



    }

}
