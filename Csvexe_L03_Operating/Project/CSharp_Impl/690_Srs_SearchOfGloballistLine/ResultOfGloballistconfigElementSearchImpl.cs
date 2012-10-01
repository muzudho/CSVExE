using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// グローバルリストのレコードの検索結果
    /// </summary>
    public class ResultOfGloballistconfigElementSearchImpl : ResultOfGloballistconfigElementSearch
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public ResultOfGloballistconfigElementSearchImpl()
        {
            this.type = "";
            this.sNumberRange = "";
            this.priorityStr = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// リストボックス表示用文字列
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append(this.Name_Type);
            text.Append(" / ");
            text.Append(this.Text_NumberRange);
            text.Append(" / Priority=");
            text.Append(this.Priority);

            return text.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected string type;

        /// <summary>
        /// 変数の型
        /// </summary>
        public string Name_Type
        {
            set
            {
                type = value;
            }
            get
            {
                return type;
            }
        }

        //────────────────────────────────────────

        protected string sNumberRange;

        /// <summary>
        /// 変数番号の範囲
        /// </summary>
        public string Text_NumberRange
        {
            set
            {
                sNumberRange = value;
            }
            get
            {
                return sNumberRange;
            }
        }

        //────────────────────────────────────────

        protected string priorityStr;

        /// <summary>
        /// 優先度
        /// </summary>
        public string Priority
        {
            set
            {
                priorityStr = value;
            }
            get
            {
                return priorityStr;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
