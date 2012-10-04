using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;//EventMonitor

namespace Xenon.Functions
{
    public class EventMonitorImpl : EventMonitor
	{



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cur_Event">設定ファイル以外で作る時は代わりが無いのでnullを指定する。</param>
        public EventMonitorImpl(Configurationtree_Node cur_Event, Configurationtree_Node parent_Configurationtree)
        {
            this.parent_Configurationtree = parent_Configurationtree;

            if (null == cur_Event)
            {
                cur_Event = new Configurationtree_NodeImpl(NamesNode.S_EVENT, new Configurationtree_NodeImpl(NamesNode.S_CONTROL1, null));//, new Configurationtree_NodeImpl("EventMonitorImpl<init>", null)
            }
            this.givechapterandverse_Event = cur_Event;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private bool bNowactionworking;

        /// <summary>
        /// アクションがまだ始まっていないときは false、
        /// アクションが始まって、完了していない間は true です。
        /// (now action working)
        /// </summary>
        public bool BNowactionworking
        {
            get
            {
                return bNowactionworking;
            }
            set
            {
                bNowactionworking = value;
            }
        }

        //────────────────────────────────────────

        private Configurationtree_Node givechapterandverse_Event;

        /// <summary>
        /// 問題箇所となる＜ｅｖｅｎｔ＞要素。
        /// </summary>
        public Configurationtree_Node Configurationtree_Event
        {
            get
            {
                return givechapterandverse_Event;
            }
        }

        //────────────────────────────────────────

        private Configurationtree_Node parent_Configurationtree;

        /// <summary>
        /// 問題箇所ヒント。
        /// </summary>
        public Configurationtree_Node Parent
        {
            get
            {
                return parent_Configurationtree;
            }
            //set
            //{
            //    s_WrittenPlace = value;
            //}
        }

        //────────────────────────────────────────
        #endregion



	}
}
