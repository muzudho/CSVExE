using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.RepoNum
{
    public class TagElmImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public TagElmImpl()
        {
            this.sValue = "";
            this.sDisplay = "";
            this.sDescription = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override string ToString()
        {
            return this.SDisplay;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected string sValue;

        public string SValue
        {
            get
            {
                return sValue;
            }
            set
            {
                sValue = value;
            }
        }

        //────────────────────────────────────────

        protected string sDisplay;

        public string SDisplay
        {
            get
            {
                return sDisplay;
            }
            set
            {
                sDisplay = value;
            }
        }

        //────────────────────────────────────────

        protected string sDescription;

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
