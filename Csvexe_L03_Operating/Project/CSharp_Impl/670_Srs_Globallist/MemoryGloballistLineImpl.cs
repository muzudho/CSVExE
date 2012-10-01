using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// GlobalList.txtの1行分のモデル。
    /// 
    /// (Model Of Global List Line Implementation)
    /// </summary>
    public class MemoryGloballistLineImpl : MemoryGloballistLine
    {




        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryGloballistLineImpl()
        {
            this.sType = "";
            this.sText = "";
        }

        /// <summary>
        /// クローンを作成します。
        /// </summary>
        public MemoryGloballistLineImpl(MemoryGloballistLine source)
        {
            this.sType = source.Name_Type;
            this.nNumber = source.Number;
            this.sText = source.Text;
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(this.sType);
            text.Append(',');
            text.Append(this.nNumber.ToString());
            text.Append(':');
            text.Append(this.sText);
            return text.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected string sType;

        /// <summary>
        /// 変数の型の名前。例：[I]
        /// </summary>
        public string Name_Type
        {
            set
            {
                sType = value;
            }
            get
            {
                return sType;
            }
        }

        //────────────────────────────────────────

        protected int nNumber;

        /// <summary>
        /// 変数の番号。
        /// </summary>
        public int Number
        {
            set
            {
                nNumber = value;
            }
            get
            {
                return nNumber;
            }
        }

        //────────────────────────────────────────

        protected string sText;

        /// <summary>
        /// テキスト。
        /// </summary>
        public string Text
        {
            set
            {
                sText = value;
            }
            get
            {
                return sText;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
