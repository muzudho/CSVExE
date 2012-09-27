using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// ゲームパッドのキーの、bit値のユーティリティ。
    /// </summary>
    public class Utility_KeyconfigBit
    {



        #region アクション
        //────────────────────────────────────────

        static public string GetShortString(EnumGamepadkeyBit enumBit)
        {
            string s;

            switch(enumBit)
            {
                case EnumGamepadkeyBit.Up:
                    s = "↑";
                    break;

                case EnumGamepadkeyBit.Right:
                    s = "→";
                    break;

                case EnumGamepadkeyBit.Down:
                    s = "↓";
                    break;

                case EnumGamepadkeyBit.Left:
                    s = "←";
                    break;

                case EnumGamepadkeyBit.A:
                    s = "A";
                    break;

                case EnumGamepadkeyBit.B:
                    s = "B";
                    break;

                case EnumGamepadkeyBit.X:
                    s = "X";
                    break;

                case EnumGamepadkeyBit.Y:
                    s = "Y";
                    break;

                case EnumGamepadkeyBit.L:
                    s = "L";
                    break;

                case EnumGamepadkeyBit.R:
                    s = "R";
                    break;

                case EnumGamepadkeyBit.Select:
                    s = "Se";
                    break;

                case EnumGamepadkeyBit.Start:
                    s = "St";
                    break;

                default:
                    s = "";
                    break;
            }

            return s;
        }

        //────────────────────────────────────────

        static public string ToString_Display(EnumGamepadkeyBit enumBit)
        {
            string sResult;

            switch (enumBit)
            {
                case EnumGamepadkeyBit.Up:
                    sResult = "↑";
                    break;
                case EnumGamepadkeyBit.Right:
                    sResult = "→";
                    break;
                case EnumGamepadkeyBit.Down:
                    sResult = "↓";
                    break;
                case EnumGamepadkeyBit.Left:
                    sResult = "←";
                    break;
                case EnumGamepadkeyBit.A:
                    sResult = "A";
                    break;
                case EnumGamepadkeyBit.B:
                    sResult = "B";
                    break;
                case EnumGamepadkeyBit.X:
                    sResult = "X";
                    break;
                case EnumGamepadkeyBit.Y:
                    sResult = "Y";
                    break;
                case EnumGamepadkeyBit.L:
                    sResult = "L";
                    break;
                case EnumGamepadkeyBit.R:
                    sResult = "R";
                    break;
                case EnumGamepadkeyBit.Start:
                    sResult = "Start";
                    break;
                case EnumGamepadkeyBit.Select:
                    sResult = "Select";
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



    }
}
