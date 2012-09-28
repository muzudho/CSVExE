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
        public EventMonitorImpl(Givechapterandverse_Node cur_Event, Givechapterandverse_Node parent_Givechapterandverse)
        {
            this.parent_Givechapterandverse = parent_Givechapterandverse;

            if (null == cur_Event)
            {
                cur_Event = new Givechapterandverse_NodeImpl(NamesNode.S_EVENT, new Givechapterandverse_NodeImpl(NamesNode.S_CONTROL1, null));//, new Givechapterandverse_NodeImpl("EventMonitorImpl<init>", null)
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

        private Givechapterandverse_Node givechapterandverse_Event;

        /// <summary>
        /// 問題箇所となる＜ｅｖｅｎｔ＞要素。
        /// </summary>
        public Givechapterandverse_Node Givechapterandverse_Event
        {
            get
            {
                return givechapterandverse_Event;
            }
        }

        //────────────────────────────────────────

        private Givechapterandverse_Node parent_Givechapterandverse;

        /// <summary>
        /// 問題箇所ヒント。
        /// </summary>
        public Givechapterandverse_Node Parent_Givechapterandverse
        {
            get
            {
                return parent_Givechapterandverse;
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
