using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{

    /// <summary>
    /// ゲームパッド１つ分のキーコンフィグ。
    /// </summary>
    public class KeyconfigPadImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public KeyconfigPadImpl()
        {
            // [A],[B],[X],[Y],[L],[R],[Select],[Start] の８ボタンを想定。念のためボタン数32に。
            this.nCount_MaxButton = 32;


            this.keyconfigArray = new EnumGamepadkeyBit[4 + this.NCount_MaxButton + 1];
            this.keyconfigArray[(int)EnumGamepadkeyIx.Up] = EnumGamepadkeyBit.Up;
            this.keyconfigArray[(int)EnumGamepadkeyIx.Right] = EnumGamepadkeyBit.Right;
            this.keyconfigArray[(int)EnumGamepadkeyIx.Down] = EnumGamepadkeyBit.Down;
            this.keyconfigArray[(int)EnumGamepadkeyIx.Left] = EnumGamepadkeyBit.Left;
            this.keyconfigArray[(int)EnumGamepadkeyIx.B0] = EnumGamepadkeyBit.A;
            this.keyconfigArray[(int)EnumGamepadkeyIx.B1] = EnumGamepadkeyBit.B;
            this.keyconfigArray[(int)EnumGamepadkeyIx.B2] = EnumGamepadkeyBit.X;
            this.keyconfigArray[(int)EnumGamepadkeyIx.B3] = EnumGamepadkeyBit.Y;
            this.keyconfigArray[(int)EnumGamepadkeyIx.B4] = EnumGamepadkeyBit.L;
            this.keyconfigArray[(int)EnumGamepadkeyIx.B5] = EnumGamepadkeyBit.R;
            this.keyconfigArray[(int)EnumGamepadkeyIx.B6] = EnumGamepadkeyBit.Select;
            this.keyconfigArray[(int)EnumGamepadkeyIx.B7] = EnumGamepadkeyBit.Start;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private int nCount_MaxButton;

        /// <summary>
        /// ボタンの数。
        /// </summary>
        public int NCount_MaxButton
        {
            get
            {
                return nCount_MaxButton;
            }
            set
            {
                nCount_MaxButton = value;
            }
        }

        //────────────────────────────────────────

        private EnumGamepadkeyBit[] keyconfigArray;

        /// <summary>
        /// キーコンフィグ配列。[1]～[4]が上、右、下、左。[5]～[12]が、ボタン。配列長は「4+最大ボタン数+1」を確保しておく。
        /// </summary>
        public EnumGamepadkeyBit[] KeyconfigArray
        {
            get
            {
                return this.keyconfigArray;
            }
            set
            {
                this.keyconfigArray = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
