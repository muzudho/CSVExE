using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.XyMemo
{



    /// <summary>
    /// マウス・ドラッグ・モード。
    /// </summary>
    public enum EnumMousedragmode
    {



        #region 用意
        //────────────────────────────────────────

        NONE,

        /// <summary>
        /// 乗せる画像移動
        /// </summary>
        SPRITE_MOVE,

        /// <summary>
        /// 背景画像移動
        /// </summary>
        BG_MOVE

        //────────────────────────────────────────
        #endregion



    }
}
