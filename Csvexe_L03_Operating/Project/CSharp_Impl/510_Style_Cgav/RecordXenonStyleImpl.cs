using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{

    /// <summary>
    /// スタイル属性1件分の記述と、テーブル上のID。
    /// </summary>
    public class RecordXenonStyleImpl : RecordXenonStyle
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public RecordXenonStyleImpl()
        {
            this.sId = "";
            this.sStyle = "";
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sId;

        /// <summary>
        /// テーブル上のID。
        /// </summary>
        public string Id
        {
            set
            {
                sId = value;
            }
            get
            {
                return sId;
            }
        }

        //────────────────────────────────────────

        private string sStyle;

        /// <summary>
        /// スタイル属性1件分の記述。
        /// </summary>
        public string Style
        {
            set
            {
                sStyle = value;
            }
            get
            {
                return sStyle;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
