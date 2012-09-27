using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{



    public class EncodingItemImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public EncodingItemImpl()
        {
            this.sText_Display = "Default";
            this.encoding = Encoding.Default;
        }

        public EncodingItemImpl(string sText_Display, Encoding encoding)
        {
            this.sText_Display = sText_Display;
            this.encoding = encoding;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override string ToString()
        {
            return this.sText_Display;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected string sText_Display;

        /// <summary>
        /// 表示文字列。
        /// </summary>
        public string SText_Display
        {
            set
            {
                sText_Display = value;
            }
            get
            {
                return sText_Display;
            }
        }

        //────────────────────────────────────────

        protected Encoding encoding;

        /// <summary>
        /// エンコーディング。
        /// </summary>
        public Encoding Encoding
        {
            set
            {
                encoding = value;
            }
            get
            {
                return encoding;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
