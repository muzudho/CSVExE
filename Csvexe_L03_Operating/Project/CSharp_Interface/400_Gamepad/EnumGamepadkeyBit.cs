using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// ゲームパッドのキーの、bit値。
    /// </summary>
    public enum EnumGamepadkeyBit
    {



        #region 用意
        //────────────────────────────────────────

        Up = 1,
        Right = 2,
        Down = 4,
        Left = 8,
        A = 16,
        B = 32,
        X = 64,
        Y = 128,
        L = 256,
        R = 512,
        Select = 1024,
        Start = 2048

        //────────────────────────────────────────
        #endregion



    }
}
