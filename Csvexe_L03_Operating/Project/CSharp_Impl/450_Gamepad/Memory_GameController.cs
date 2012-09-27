using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;

namespace Xenon.Operating
{

    /// <summary>
    /// ゲームコントローラーの入力状態。
    /// (Game Controller)
    /// </summary>
    public class Memory_GameController
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Memory_GameController()
        {
            this.keyCnf = new KeyconfigPadImpl();

            this.buttonsFrame = new int[4 + this.KeyCnf.NCount_MaxButton + 1];
            this.buttonsPressingFrame = new int[4 + this.KeyCnf.NCount_MaxButton + 1];

            this.nKeyRepeatFrames = int.MaxValue; // 3;

            this.enumCurKeyForCnf = EnumGamepadkeyBit.Up;

        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private KeyconfigPadImpl keyCnf;

        /// <summary>
        /// キー設定。
        /// </summary>
        public KeyconfigPadImpl KeyCnf
        {
            get
            {
                return keyCnf;
            }
            set
            {
                keyCnf = value;
            }
        }

        //────────────────────────────────────────

        private int nKeyRepeatFrames;

        /// <summary>
        /// このフレーム数だけ、キーを押しっぱなしにしても反応しないようにします。
        /// </summary>
        public int NKeyRepeatFrames
        {
            get
            {
                return nKeyRepeatFrames;
            }
            set
            {
                nKeyRepeatFrames = value;
            }
        }

        //────────────────────────────────────────

        private int[] buttonsFrame;

        /// <summary>
        /// 押されたボタンが連続して押されているフレーム数。
        /// 指定フレーム経過で 0 に戻る。
        /// </summary>
        public int[] ButtonsFrame
        {
            get
            {
                return buttonsFrame;
            }
            set
            {
                buttonsFrame = value;
            }
        }

        //────────────────────────────────────────

        private int[] buttonsPressingFrame;

        /// <summary>
        /// 押されたボタンが連続して押されているフレーム数。
        /// キーが離された時に 0 に戻る。
        /// </summary>
        public int[] ButtonsPressingFrame
        {
            get
            {
                return buttonsPressingFrame;
            }
            set
            {
                buttonsPressingFrame = value;
            }
        }

        //────────────────────────────────────────

        private Device gameController;

        /// <summary>
        /// 接続されているゲームコントローラー。
        /// </summary>
        public Device GameController
        {
            get
            {
                return gameController;
            }
            set
            {
                gameController = value;
            }
        }

        //────────────────────────────────────────

        private EnumGamepadkeyBit enumCurKeyForCnf;

        /// <summary>
        /// キーコンフィグ用。
        /// </summary>
        public EnumGamepadkeyBit EnumCurKeyForCnf
        {
            get
            {
                return this.enumCurKeyForCnf;
            }
            set
            {
                this.enumCurKeyForCnf = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
