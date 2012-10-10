using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Table
{

    /// <summary>
    /// テーブルの内容保存方法などの設定。
    /// </summary>
    public class Format_TableHumaninputImpl : Format_TableHumaninput
    {



        #region プロパティー
        //────────────────────────────────────────

        private bool bRowColRev;

        /// <summary>
        /// 行と列がひっくり返っている（左から右へレコードが並んでいる）なら真。
        /// 
        /// 通常（上から下へレコードが並んでいる）なら偽。
        /// </summary>
        public bool IsRowcolumnreverse
        {
            get
            {
                return bRowColRev;
            }
            set
            {
                bRowColRev = value;
            }
        }

        //────────────────────────────────────────

        private bool bAllIntFields;

        /// <summary>
        /// 型定義のレコード（intやboolやstringが書いてあるところ）がなく、全フィールドがint型のテーブルの場合、真。
        /// </summary>
        public bool IsAllintfieldsActivated
        {
            get
            {
                return bAllIntFields;
            }
            set
            {
                bAllIntFields = value;
            }
        }

        //────────────────────────────────────────

        private bool bCommaEnding;

        /// <summary>
        /// 行の末尾を「,」で終える場合、真。
        /// </summary>
        public bool IsCommaending
        {
            get
            {
                return bCommaEnding;
            }
            set
            {
                bCommaEnding = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
