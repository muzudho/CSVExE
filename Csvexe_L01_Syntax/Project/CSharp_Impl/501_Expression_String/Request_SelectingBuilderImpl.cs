using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Xenon.Syntax
{
    public class Request_SelectingBuilderImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Request_SelectingBuilderImpl()
        {
            this.enumHitcount = EnumHitcount.Unconstraint;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public Request_Selecting ToObject(Log_Reports log_Reports)
        {
            return new Request_SelectingImpl(this.EnumHitcount);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private EnumHitcount enumHitcount;

        /// <summary>
        /// 期待する検索ヒット数の区分。
        /// </summary>
        public virtual EnumHitcount EnumHitcount
        {
            get
            {
                return this.enumHitcount;
            }
            set
            {
                this.enumHitcount = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
