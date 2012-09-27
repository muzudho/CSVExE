using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// ゲームパッドのキーの、配列番号のユーティリティ。
    /// </summary>
    public class Utility_KeyconfigArray
    {



        #region アクション
        //────────────────────────────────────────

        static public EnumGamepadkeyIx IntTo(int nNum)
        {
            EnumGamepadkeyIx result;

            result = GAMEPADKEY_ARRAY_ENUM_ARRAY[nNum];

            return result;
        }

        //────────────────────────────────────────

        static public string ToString_Display(EnumGamepadkeyIx enumGa)
        {
            string sResult;

            switch (enumGa)
            {
                case EnumGamepadkeyIx.Up:
                    sResult = "↑";
                    break;
                case EnumGamepadkeyIx.Right:
                    sResult = "→";
                    break;
                case EnumGamepadkeyIx.Down:
                    sResult = "↓";
                    break;
                case EnumGamepadkeyIx.Left:
                    sResult = "←";
                    break;
                case EnumGamepadkeyIx.B0:
                    sResult = "0";
                    break;
                case EnumGamepadkeyIx.B1:
                    sResult = "1";
                    break;
                case EnumGamepadkeyIx.B2:
                    sResult = "2";
                    break;
                case EnumGamepadkeyIx.B3:
                    sResult = "3";
                    break;
                case EnumGamepadkeyIx.B4:
                    sResult = "4";
                    break;
                case EnumGamepadkeyIx.B5:
                    sResult = "5";
                    break;
                case EnumGamepadkeyIx.B6:
                    sResult = "6";
                    break;
                case EnumGamepadkeyIx.B7:
                    sResult = "7";
                    break;
                default:
                    // エラー
                    sResult = "＜エラー＞";
                    break;
            }

            return sResult;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        static private EnumGamepadkeyIx[] GAMEPADKEY_ARRAY_ENUM_ARRAY = new EnumGamepadkeyIx[]{
            EnumGamepadkeyIx.None,//[0]エラー
            EnumGamepadkeyIx.Up,//[1]
            EnumGamepadkeyIx.Right,
            EnumGamepadkeyIx.Down,
            EnumGamepadkeyIx.Left,
            EnumGamepadkeyIx.B0,
            EnumGamepadkeyIx.B1,
            EnumGamepadkeyIx.B2,
            EnumGamepadkeyIx.B3,
            EnumGamepadkeyIx.B4,
            EnumGamepadkeyIx.B5,
            EnumGamepadkeyIx.B6,
            EnumGamepadkeyIx.B7,//[12]
        };

        //────────────────────────────────────────
        #endregion



    }
}
