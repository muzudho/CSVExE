using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Table
{



    /// <summary>
    /// フィールド定義。
    /// </summary>
    class XenonFielddefinitionImpl : XenonFielddefinition
    {



        #region 用意
        //────────────────────────────────────────

        public const string S_STRING = "string";

        public const string S_INT = "int";

        public const string S_BOOL = "bool";

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="name_humanInput"></param>
        /// <param name="type">string,int,boolに対応。</param>
        public XenonFielddefinitionImpl(string sName_Humaninput, Type type)
        {
            this.SName_Humaninput = sName_Humaninput;
            this.Type = type;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sName_Humaninput;

        private string sName_Trimupper;

        /// <summary>
        /// フィールドの名前。入力したままの文字列。
        /// </summary>
        public string SName_Humaninput
        {
            set
            {
                sName_Humaninput = value;
                this.sName_Trimupper = sName_Humaninput.Trim().ToUpper();
            }
            get
            {
                return sName_Humaninput;
            }
        }

        /// <summary>
        /// フィールドの名前。トリムして英字大文字に加工した文字列。読み取り専用。
        /// </summary>
        public string SName_Trimupper
        {
            get
            {
                return this.sName_Trimupper;
            }
        }

        //────────────────────────────────────────

        private Type type;

        /// <summary>
        /// フィールドの型。
        /// </summary>
        public Type Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <summary>
        /// string,int,boolを返します。未該当の時は空文字列を返します。
        /// </summary>
        /// <returns></returns>
        public string GetTypeString()
        {
            if (this.Type == typeof(string))
            {
                return XenonFielddefinitionImpl.S_STRING;
            }
            else if (this.Type == typeof(int))
            {
                return XenonFielddefinitionImpl.S_INT;
            }
            else if (this.Type == typeof(bool))
            {
                return XenonFielddefinitionImpl.S_BOOL;
            }
            else
            {
                //
                // 未該当
                //
                return "";
            }
        }

        //────────────────────────────────────────

        private string sComment;

        /// <summary>
        /// フィールドについてのコメント。
        /// </summary>
        public string SComment
        {
            set
            {
                sComment = value;
            }
            get
            {
                return sComment;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
