using System;
using System.Collections.Generic;
using System.Drawing;//Brush
using System.Linq;
using System.Text;

using Xenon.Operating;//NStyle

namespace Xenon.Middle
{
    public interface MemoryBrushes
    {



        #region アクション
        //────────────────────────────────────────
        
        /// <summary>
        /// 使わなくなったら呼び出してください。
        /// </summary>
        void Dispose();

        /// <summary>
        /// ブラシの再利用。
        /// </summary>
        /// <param name="xenonStyle"></param>
        /// <returns></returns>
        Brush GetByStyle(XenonStyle xenonStyle);

        /// <summary>
        /// ブラシの再利用。
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        Brush GetByName(string sName);

        //────────────────────────────────────────
        #endregion



    }
}
