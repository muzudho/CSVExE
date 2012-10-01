using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Xenon.Syntax
{

    /// <summary>
    /// ステートレス設計です。一度生成したら、その値を変えることはできません。
    /// </summary>
    public class Request_SelectingImpl : Request_Selecting
    {



        #region 用意
        //────────────────────────────────────────

        public static readonly Request_Selecting Unconstraint = new Request_SelectingImpl(EnumHitcount.Unconstraint);

        public static readonly Request_Selecting First_Exist = new Request_SelectingImpl(EnumHitcount.First_Exist);

        public static readonly Request_Selecting First_Exist_Or_Zero = new Request_SelectingImpl(EnumHitcount.First_Exist_Or_Zero);

        public static readonly Request_Selecting One = new Request_SelectingImpl(EnumHitcount.One);

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        Request_SelectingImpl()
        {
            this.enumHitcount = EnumHitcount.Unconstraint;
        }

        public Request_SelectingImpl(EnumHitcount enumVolumeConstraint)
        {
            this.enumHitcount = enumVolumeConstraint;
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
        }

        //────────────────────────────────────────
        #endregion
        


    }
}
