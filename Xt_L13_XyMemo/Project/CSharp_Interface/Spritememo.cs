using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.XyMemo
{


    /// <summary>
    /// スプライト。同名の型名とは違いを付けてある。
    /// </summary>
    public interface Spritememo
    {



        #region アクション
        //────────────────────────────────────────

        void OnSpriteSizeChanged();

        void OnSpriteLocationChanged();

        //────────────────────────────────────────
        #endregion



    }
}
