using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{


    public interface EventMonitor
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// アクションがまだ始まっていないときは false、
        /// アクションが始まって、完了していない間は true です。
        /// (now action working)
        /// </summary>
        bool BNowactionworking
        {
            get;
            set;
        }


        /// <summary>
        /// 問題箇所となる＜ｅｖｅｎｔ＞要素。
        /// </summary>
        Configurationtree_Node Configurationtree_Event
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }


}
