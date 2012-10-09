using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Xenon.NumPut
{
    public class Memory3OperationMode_NormalImpl : Memory3Operationmode_AbstractImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="moApplication"></param>
        public Memory3OperationMode_NormalImpl(Memory2Project moProject)
            : base(moProject)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        public override void UcCanvas_MouseDown(object sender, MouseEventArgs e)
        {
        }

        //────────────────────────────────────────
        #endregion



    }
}
