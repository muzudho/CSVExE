using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;//WarningReports

namespace Xenon.Middle
{
    /// <summary>
    /// ＜ｆ－ｓｅｔ－ｖａｒ＞要素の連想配列。
    /// </summary>
    public interface Dictionary_Fsetvar_Givechapterandverse
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// input要素を、name属性を検索キーにして検索し、取得します。
        /// 該当がなければヌルを返します。
        /// </summary>
        /// <param name="inputName">name属性</param>
        /// <param name="bRequired">該当するデータがない場合、エラー</param>
        /// <returns></returns>
        Givechapterandverse_Node GetFsetvar(
            string sName_Var,
            bool bRequired,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// input要素の連想配列。
        /// </summary>
        ListGivechapterandverse_Node List_ChildGivechapterandverse
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }

}
