using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Xenon.NumPut
{
    public class Memory3Operationmode_AbstractImpl : Memory3Operationmode
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="moApplication"></param>
        public Memory3Operationmode_AbstractImpl(Memory2Project parentMoProject)
        {
            this.parentMoProject = parentMoProject;
        }

        //────────────────────────────────────────
        #endregion

        

        #region イベントハンドラー
        //────────────────────────────────────────

        public virtual void UcCanvas_MouseDown(object sender, MouseEventArgs e)
        {
        }

        //────────────────────────────────────────
        #endregion


        
        #region プロパティー
        //────────────────────────────────────────

        private Memory2Project parentMoProject;

        public Memory2Project ParentMoProject
        {
            get
            {
                return this.parentMoProject;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
