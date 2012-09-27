using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;

namespace Xenon.Operating
{
    /// <summary>
    /// 入力受取。
    /// </summary>
    public class Gamepadmainloop_Receipt_SubImpl
    {



        #region アクション
        //────────────────────────────────────────

        public void Perform(
            Memory_GameController gc
            )
        {
            Device gameController = gc.GameController;
            JoystickState state = gameController.CurrentJoystickState;
            int nX = state.X;
            int nY = state.Y;

            // 128個のボタンが取得できる。
            byte[] buttons = state.GetButtons();

            //
            // X,Y,A,B,L,R 等のボタン。
            {
                // 各ボタンのbyte
                {

                    int nMax = gc.KeyCnf.NCount_MaxButton;
                    for (int nBtnIndex = 0; nBtnIndex < nMax; nBtnIndex++)
                    {
                        byte buttonByte = buttons[nBtnIndex];

                        // カーソル4つで+4、 1スタートで+1
                        int nKeyNum = 4 + nBtnIndex + 1;

                        if (0 != buttonByte)
                        {
                            //押されたら 0 以外が入っているようだ。

                            //
                            // [何かのボタン]
                            //
                            if (gc.NKeyRepeatFrames < gc.ButtonsFrame[nKeyNum])
                            {
                                // 指定フレーム以上押しっぱなしにしていれば、押し直したことにする。
                                gc.ButtonsFrame[nKeyNum] = 0;
                            }

                            gc.ButtonsFrame[nKeyNum]++;
                            gc.ButtonsPressingFrame[nKeyNum]++;
                        }
                        else
                        {
                            // 押していない場合。
                            gc.ButtonsFrame[nKeyNum] = 0;
                            gc.ButtonsPressingFrame[nKeyNum] = 0;
                        }

                    }
                }
            }

            //
            // 十字キーのボタン
            {
                if (5000 == nX)
                {
                    //
                    // [→]
                    //
                    int nKey = (int)EnumGamepadkeyIx.Right;
                    if (gc.NKeyRepeatFrames < gc.ButtonsFrame[nKey])
                    {
                        // 指定フレーム以上押しっぱなしにしていれば、押し直したことにする。
                        gc.ButtonsFrame[nKey] = 0;
                    }

                    gc.ButtonsFrame[nKey]++;
                    gc.ButtonsPressingFrame[nKey]++;

                    int nReverseKey = (int)EnumGamepadkeyIx.Left;
                    gc.ButtonsFrame[nReverseKey] = 0;
                    gc.ButtonsPressingFrame[nReverseKey] = 0;
                }
                else if (-5000 == nX)
                {
                    //
                    // [←]
                    //
                    int nKey = (int)EnumGamepadkeyIx.Left;
                    if (gc.NKeyRepeatFrames < gc.ButtonsFrame[nKey])
                    {
                        // 指定フレーム以上押しっぱなしにしていれば、押し直したことにする。
                        gc.ButtonsFrame[nKey] = 0;
                    }

                    gc.ButtonsFrame[nKey]++;
                    gc.ButtonsPressingFrame[nKey]++;

                    int nReverseKey = (int)EnumGamepadkeyIx.Right;
                    gc.ButtonsFrame[nReverseKey] = 0;
                    gc.ButtonsPressingFrame[nReverseKey] = 0;
                }
                else
                {
                    gc.ButtonsFrame[(int)EnumGamepadkeyIx.Left] = 0;
                    gc.ButtonsPressingFrame[(int)EnumGamepadkeyIx.Left] = 0;

                    gc.ButtonsFrame[(int)EnumGamepadkeyIx.Right] = 0;
                    gc.ButtonsPressingFrame[(int)EnumGamepadkeyIx.Right] = 0;
                }


                if (5000 == nY)
                {
                    //
                    // [↓]
                    //
                    int nKey = (int)EnumGamepadkeyIx.Down;
                    if (gc.NKeyRepeatFrames < gc.ButtonsFrame[nKey])
                    {
                        // 指定フレーム以上押しっぱなしにしていれば、押し直したことにする。
                        gc.ButtonsFrame[nKey] = 0;
                    }

                    gc.ButtonsFrame[nKey]++;
                    gc.ButtonsPressingFrame[nKey]++;

                    int nReverseKey = (int)EnumGamepadkeyIx.Up;
                    gc.ButtonsFrame[nReverseKey] = 0;
                    gc.ButtonsPressingFrame[nReverseKey] = 0;
                }
                else if (-5000 == nY)
                {
                    //
                    // [↑]
                    //
                    int nKey = (int)EnumGamepadkeyIx.Up;
                    if (gc.NKeyRepeatFrames < gc.ButtonsFrame[nKey])
                    {
                        // 指定フレーム以上押しっぱなしにしていれば、押し直したことにする。
                        gc.ButtonsFrame[nKey] = 0;
                    }

                    gc.ButtonsFrame[nKey]++;
                    gc.ButtonsPressingFrame[nKey]++;

                    int nReverseKey = (int)EnumGamepadkeyIx.Down;
                    gc.ButtonsFrame[nReverseKey] = 0;
                    gc.ButtonsPressingFrame[nReverseKey] = 0;
                }
                else
                {
                    gc.ButtonsFrame[(int)EnumGamepadkeyIx.Down] = 0;
                    gc.ButtonsPressingFrame[(int)EnumGamepadkeyIx.Down] = 0;

                    gc.ButtonsFrame[(int)EnumGamepadkeyIx.Up] = 0;
                    gc.ButtonsPressingFrame[(int)EnumGamepadkeyIx.Up] = 0;
                }
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
