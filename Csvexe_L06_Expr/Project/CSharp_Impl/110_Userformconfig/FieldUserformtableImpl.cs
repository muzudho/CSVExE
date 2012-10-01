using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;

namespace Xenon.Expr
{


    /// <summary>
    /// フィールド。
    /// </summary>
    public class FieldUserformtableImpl : FieldUserformtable
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public FieldUserformtableImpl()
        {
            this.name = "";
            this.enumTypedb = EnumTypedb.Another;
        }

        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public FieldUserformtableImpl(string sName, EnumTypedb enum_Typedb, object data)
        {
            this.name = sName;
            this.enumTypedb = enum_Typedb;
            this.data = data;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        //────────────────────────────────────────

        private EnumTypedb enumTypedb;

        public EnumTypedb EnumTypedb
        {
            get
            {
                return this.enumTypedb;
            }
            set
            {
                this.enumTypedb = value;
            }
        }

        //────────────────────────────────────────

        private object data;

        public object Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
