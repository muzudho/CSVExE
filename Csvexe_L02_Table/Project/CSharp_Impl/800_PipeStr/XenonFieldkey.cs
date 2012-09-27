using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Table
{

    /// <summary>
    /// テーブルのフィールドを指定するものです。
    /// </summary>
    public class XenonFieldkey
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public XenonFieldkey()
        {
            this.sName = "";
            this.sType = "";
            this.sDescription = "";
        }

        //────────────────────────────────────────

        public XenonFieldkey(string sName, string sType, string sDescription)
        {
            this.sName = sName;
            this.sType = sType;
            this.sDescription = sDescription;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sName;

        /// <summary>
        /// フィールド名。「NAME」など。
        /// </summary>
        public string SName
        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
            }
        }

        //────────────────────────────────────────

        private string sType;

        /// <summary>
        /// フィールド値の型。「int」など。
        /// </summary>
        public string SType
        {
            get
            {
                return sType;
            }
            set
            {
                sType = value;
            }
        }

        //────────────────────────────────────────

        private string sDescription;

        /// <summary>
        /// フィールドの説明。
        /// </summary>
        public string SDescription
        {
            get
            {
                return sDescription;
            }
            set
            {
                sDescription = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
