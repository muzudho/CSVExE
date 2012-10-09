using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.NumPut
{
    public class Memory1ApplicationImpl : Memory1Application
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Memory1ApplicationImpl()
        {
            this.MoProject = new Memory2ProjectImpl(this);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        private Memory2ProjectImpl moProject;

        /// <summary>
        /// 番号スプライトのリスト。
        /// </summary>
        public Memory2ProjectImpl MoProject
        {
            get
            {
                return moProject;
            }
            set
            {
                moProject = value;
            }
        }

        //────────────────────────────────────────

        private Form1 form1;

        public Form1 Form1
        {
            get
            {
                return this.form1;
            }
            set
            {
                this.form1 = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
