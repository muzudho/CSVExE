using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.NumPut
{
    public class MemoryFilesetImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター
        /// </summary>
        public MemoryFilesetImpl()
        {
            this.SName = "";
            this.SFpathCsv = "";
            this.SFpathPng = "";
            this.SFpathPngGraph = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(this.sName);
            if ("" == this.SFpathPng)
            {
                s.Append(" 絵☓");
            }

            if ("" == this.SFpathCsv)
            {
                s.Append(" 表☓");
            }

            if ("" == this.SFpathPngGraph)
            {
                s.Append(" 見☓");
            }

            return s.ToString();
        }

        //────────────────────────────────────────
        #endregion

        

        #region プロパティー
        //────────────────────────────────────────

        private string sName;

        public string SName
        {
            get
            {
                return this.sName;
            }
            set
            {
                this.sName = value;
            }
        }

        //────────────────────────────────────────

        private string sFpathCsv;

        public string SFpathCsv
        {
            get
            {
                return this.sFpathCsv;
            }
            set
            {
                this.sFpathCsv = value;
            }
        }

        //────────────────────────────────────────

        private string sFpathPng;

        public string SFpathPng
        {
            get
            {
                return this.sFpathPng;
            }
            set
            {
                this.sFpathPng = value;
            }
        }

        //────────────────────────────────────────

        private string sFpathPngGraph;

        public string SFpathPngGraph
        {
            get
            {
                return this.sFpathPngGraph;
            }
            set
            {
                this.sFpathPngGraph = value;
            }
        }

        //────────────────────────────────────────
        #endregion
        


    }
}
