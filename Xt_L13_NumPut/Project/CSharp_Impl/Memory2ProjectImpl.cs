using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.NumPut
{
    public class Memory2ProjectImpl : Memory2Project
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Memory2ProjectImpl(Memory1Application parentMoApplication)
        {
            this.parentMoApplication = parentMoApplication;

            this.MoOperationMode = new Memory3OperationMode_NormalImpl(this);
            this.MoContents = new Memory3ContentsImpl();
        }

        //────────────────────────────────────────
        #endregion

        

        #region プロパティー
        //────────────────────────────────────────

        private Memory1Application parentMoApplication;

        public Memory1Application ParentMoApplication
        {
            get
            {
                return this.parentMoApplication;
            }
        }

        //────────────────────────────────────────

        private Memory3Operationmode moOperationMode;

        /// <summary>
        /// 操作モード。
        /// </summary>
        public Memory3Operationmode MoOperationMode
        {
            get
            {
                return this.moOperationMode;
            }
            set
            {
                this.moOperationMode = value;
            }
        }

        //────────────────────────────────────────

        private Memory3Contents moContents;

        public Memory3Contents MoContents
        {
            get
            {
                return this.moContents;
            }
            set
            {
                this.moContents = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
