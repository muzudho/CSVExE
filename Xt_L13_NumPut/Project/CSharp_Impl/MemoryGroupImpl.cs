using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.NumPut
{



    public class MemoryGroupImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryGroupImpl()
        {
            this.mNameDefine = new MemoryNumImpl();
            this.mNumList = new List<MemoryNum>();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryNum mNameDefine;

        /// <summary>
        /// グループ名。「a=100」や「b=a+0」といったもの。
        /// </summary>
        public MemoryNum MNameDefine
        {
            get
            {
                return this.mNameDefine;
            }
            set
            {
                this.mNameDefine = value;
            }
        }

        //────────────────────────────────────────

        private List<MemoryNum> mNumList;

        /// <summary>
        /// ナム・リスト。「b+0」「b+1」といったもの。
        /// </summary>
        public List<MemoryNum> MNumList
        {
            get
            {
                return this.mNumList;
            }
        }

        //────────────────────────────────────────
        #endregion



    }



}
