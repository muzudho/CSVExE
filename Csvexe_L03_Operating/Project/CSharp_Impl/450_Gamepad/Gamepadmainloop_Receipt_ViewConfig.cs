using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;
using System.Drawing;//Color
using System.Windows.Forms;//Label

namespace Xenon.Operating
{

    /// <summary>
    /// コンフィグ・ビューでの、入力受取。
    /// </summary>
    public class Gamepadmainloop_Receipt_ViewConfig : Gamepadmainloop_Receipt_View
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Gamepadmainloop_Receipt_ViewConfig()
        {
            keyListener_MainImpl = new Gamepadmainloop_Receipt_SubImpl();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Perform(Gamepadmainloop mainloop)
        {
            // 接続ゲームコントローラー数。
            this.Uc_Form1.UsercontrolPage1.PctxtConnectedDevices.Text = mainloop.Input.Dictionary_GameController.Count.ToString();

            // 抜けたコントローラーのプレイヤー番号のリスト。
            List<int> nList_Lost = new List<int>();

            // プレイヤー毎に。
            foreach (KeyValuePair<int, Memory_GameController> pair in mainloop.Input.Dictionary_GameController)
            {
                int nPlayer = pair.Key;
                Memory_GameController gc = pair.Value;
                Device gameController = gc.GameController;
                Usercontrol_VwdKeycnf ucCtrlCnf = this.Uc_Form1.UsercontrolPage2.Usercontrol_VwdKeycnfArray[nPlayer];

                // ゲームコントローラーの、ボタンの押されている状況を取得します。
                // その他に、マウス、キーボードも取得できるかも。


                // ボタンが押されたかどうか。
                bool bBtnPushed = false;

                try
                {

                    // キー読取
                    this.keyListener_MainImpl.Perform(gc);

                    JoystickState state = gameController.CurrentJoystickState;
                    int nX = state.X;
                    int nY = state.Y;

                    // 押されたキー
                    EnumGamepadkeyIx enumPushedKey = EnumGamepadkeyIx.None;//ダミー初期値。

                    //
                    // [1]
                    //
                    if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.B0] == 1)
                    {
                        bBtnPushed = true;
                        enumPushedKey = EnumGamepadkeyIx.B0;
                        goto gt_buttonEnd;//1個だけ判定。
                    }

                    //
                    // [2]
                    //
                    if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.B1] == 1)
                    {
                        bBtnPushed = true;
                        enumPushedKey = EnumGamepadkeyIx.B1;
                        goto gt_buttonEnd;//1個だけ判定。
                    }

                    //
                    // [3]
                    //
                    if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.B2] == 1)
                    {
                        bBtnPushed = true;
                        enumPushedKey = EnumGamepadkeyIx.B2;
                        goto gt_buttonEnd;//1個だけ判定。
                    }

                    //
                    // [4]
                    //
                    if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.B3] == 1)
                    {
                        bBtnPushed = true;
                        enumPushedKey = EnumGamepadkeyIx.B3;
                        goto gt_buttonEnd;//1個だけ判定。
                    }

                    //
                    // [5]
                    //
                    if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.B4] == 1)
                    {
                        bBtnPushed = true;
                        enumPushedKey = EnumGamepadkeyIx.B4;
                        goto gt_buttonEnd;//1個だけ判定。
                    }

                    //
                    // [6]
                    //
                    if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.B5] == 1)
                    {
                        bBtnPushed = true;
                        enumPushedKey = EnumGamepadkeyIx.B5;
                        goto gt_buttonEnd;//1個だけ判定。
                    }

                    //
                    // [7]
                    //
                    if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.B6] == 1)
                    {
                        bBtnPushed = true;
                        enumPushedKey = EnumGamepadkeyIx.B6;
                        goto gt_buttonEnd;//1個だけ判定。
                    }

                    //
                    // [8]
                    //
                    if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.B7] == 1)
                    {
                        bBtnPushed = true;
                        enumPushedKey = EnumGamepadkeyIx.B7;
                        goto gt_buttonEnd;//1個だけ判定。
                    }

                    if (5000 == nX)
                    {
                        //
                        // [→]
                        //
                        if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.Right] == 1)
                        {
                            bBtnPushed = true;
                            enumPushedKey = EnumGamepadkeyIx.Right;
                            goto gt_buttonEnd;//1個だけ判定。
                        }
                    }
                    else if (-5000 == nX)
                    {
                        //
                        // [←]
                        //
                        if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.Left] == 1)
                        {
                            bBtnPushed = true;
                            enumPushedKey = EnumGamepadkeyIx.Left;
                            goto gt_buttonEnd;//1個だけ判定。
                        }
                    }

                    if (5000 == nY)
                    {
                        //
                        // [↓]
                        //

                        if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.Down] == 1)
                        {
                            bBtnPushed = true;
                            enumPushedKey = EnumGamepadkeyIx.Down;
                            goto gt_buttonEnd;//1個だけ判定。
                        }
                    }
                    else if (-5000 == nY)
                    {
                        //
                        // [↑]
                        //

                        if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.Up] == 1)
                        {
                            bBtnPushed = true;
                            enumPushedKey = EnumGamepadkeyIx.Up;
                            goto gt_buttonEnd;//1個だけ判定。
                        }
                    }

                    //
                    //
                    //
                    //
                    gt_buttonEnd:

                    //
                    // 押されたキーの文字列化
                    //
                    string sPushedKey;
                    switch (enumPushedKey)
                    {
                        case EnumGamepadkeyIx.None:
                            goto gt_playerEnd;
                        case EnumGamepadkeyIx.Up:
                            sPushedKey = "↑";
                            break;
                        case EnumGamepadkeyIx.Right:
                            sPushedKey = "→";
                            break;
                        case EnumGamepadkeyIx.Down:
                            sPushedKey = "↓";
                            break;
                        case EnumGamepadkeyIx.Left:
                            sPushedKey = "←";
                            break;
                        case EnumGamepadkeyIx.B0:
                            sPushedKey = "1";
                            break;
                        case EnumGamepadkeyIx.B1:
                            sPushedKey = "2";
                            break;
                        case EnumGamepadkeyIx.B2:
                            sPushedKey = "3";
                            break;
                        case EnumGamepadkeyIx.B3:
                            sPushedKey = "4";
                            break;
                        case EnumGamepadkeyIx.B4:
                            sPushedKey = "5";
                            break;
                        case EnumGamepadkeyIx.B5:
                            sPushedKey = "6";
                            break;
                        case EnumGamepadkeyIx.B6:
                            sPushedKey = "7";
                            break;
                        case EnumGamepadkeyIx.B7:
                            sPushedKey = "8";
                            break;
                        default:
                            sPushedKey = "エラー";
                            break;
                    }

                    //
                    // 設定
                    //
                    gc.KeyCnf.KeyconfigArray[(int)enumPushedKey] = gc.EnumCurKeyForCnf;

                    //
                    // 表示する場所。
                    if( bBtnPushed)
                    {
                        TextBox pctxtCur;
                        TextBox pctxtNext;
                        switch (gc.EnumCurKeyForCnf)
                        {
                            case EnumGamepadkeyBit.Up:
                                // [↑]
                                pctxtCur = ucCtrlCnf.PctxtUp;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtRight;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.Right;
                                break;

                            case EnumGamepadkeyBit.Right:
                                // [→]
                                pctxtCur = ucCtrlCnf.PctxtRight;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtDown;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.Down;
                                break;

                            case EnumGamepadkeyBit.Down:
                                // [↓]
                                pctxtCur = ucCtrlCnf.PctxtDown;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtLeft;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.Left;
                                break;

                            case EnumGamepadkeyBit.Left:
                                // [←]
                                pctxtCur = ucCtrlCnf.PctxtLeft;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtA;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.A;
                                break;

                            case EnumGamepadkeyBit.A:
                                // [A]
                                pctxtCur = ucCtrlCnf.PctxtA;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtB;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.B;
                                break;

                            case EnumGamepadkeyBit.B:
                                // [B]
                                pctxtCur = ucCtrlCnf.PctxtB;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtX;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.X;
                                break;

                            case EnumGamepadkeyBit.X:
                                // [X]
                                pctxtCur = ucCtrlCnf.PctxtX;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtY;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.Y;
                                break;

                            case EnumGamepadkeyBit.Y:
                                // [Y]
                                pctxtCur = ucCtrlCnf.PctxtY;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtL;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.L;
                                break;

                            case EnumGamepadkeyBit.L:
                                // [L]
                                pctxtCur = ucCtrlCnf.PctxtL;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtR;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.R;
                                break;

                            case EnumGamepadkeyBit.R:
                                // [R]
                                pctxtCur = ucCtrlCnf.PctxtR;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtSelect;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.Select;
                                break;

                            case EnumGamepadkeyBit.Select:
                                // [Select]
                                pctxtCur = ucCtrlCnf.PctxtSelect;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtStart;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.Start;
                                break;

                            case EnumGamepadkeyBit.Start:
                                // [Start]
                                pctxtCur = ucCtrlCnf.PctxtStart;
                                pctxtCur.Text = sPushedKey;
                                pctxtCur.ForeColor = Color.Black;
                                pctxtCur.BackColor = SystemColors.Control;
                                pctxtNext = ucCtrlCnf.PctxtUp;
                                pctxtNext.ForeColor = Color.White;
                                pctxtNext.BackColor = Color.Blue;
                                gc.EnumCurKeyForCnf = EnumGamepadkeyBit.Up;
                                break;
                        }
                    }

                }
                catch (NotAcquiredException)
                {
                    // ゲームコントローラーを獲得していない。
                }
                catch (InputLostException)
                {
                    // ゲームコントローラーが抜けたとき。

                    // 抜けたコントローラーのプレイヤー番号を記憶
                    nList_Lost.Add(nPlayer);
                }

                // プレイヤー１人分終了
            gt_playerEnd:

                nPlayer++;
            }


            foreach (int playerNumber in nList_Lost)
            {
                // 削除
                mainloop.Input.Dictionary_GameController.Remove(playerNumber);
            }

            this.Uc_Form1.UsercontrolPage1.PctxtTimer.Text = this.Uc_Form1.Mainloop.NTimer.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Gamepadmainloop_Receipt_SubImpl keyListener_MainImpl;

        //────────────────────────────────────────

        private Usercontrol_Form1 uc_Form1;

        /// <summary>
        /// フォーム1。
        /// </summary>
        public Usercontrol_Form1 Uc_Form1
        {
            get
            {
                return uc_Form1;
            }
            set
            {
                uc_Form1 = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
