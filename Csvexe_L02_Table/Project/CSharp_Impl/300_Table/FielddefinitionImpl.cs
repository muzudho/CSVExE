using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Table
{



    /// <summary>
    /// フィールド定義。
    /// </summary>
    class FielddefinitionImpl : Fielddefinition
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
        public FielddefinitionImpl(string name_Humaninput, Type type)
        {
            this.Name_Humaninput = name_Humaninput;
            this.Type = type;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 入力したままのフィールド名。
        /// </summary>
        private string name_Humaninput;

        /// <summary>
        /// トリムして大文字化したフィールド名。
        /// </summary>
        private string name_Trimupper;

        /// <summary>
        /// フィールドの名前。入力したままの文字列。
        /// </summary>
        public string Name_Humaninput
        {
            set
            {
                name_Humaninput = value;
                this.name_Trimupper = name_Humaninput.Trim().ToUpper();
            }
            get
            {
                return name_Humaninput;
            }
        }

        /// <summary>
        /// フィールドの名前。トリムして英字大文字に加工した文字列。読み取り専用。
        /// </summary>
        public string Name_Trimupper
        {
            get
            {
                return this.name_Trimupper;
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
                return FielddefinitionImpl.S_STRING;
            }
            else if (this.Type == typeof(int))
            {
                return FielddefinitionImpl.S_INT;
            }
            else if (this.Type == typeof(bool))
            {
                return FielddefinitionImpl.S_BOOL;
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

        private string comment;

        /// <summary>
        /// フィールドについてのコメント。
        /// </summary>
        public string Comment
        {
            set
            {
                comment = value;
            }
            get
            {
                return comment;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
