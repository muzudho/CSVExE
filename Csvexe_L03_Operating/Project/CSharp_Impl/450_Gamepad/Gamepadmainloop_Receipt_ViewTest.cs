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
    /// テスト・ビューでの、入力受取。
    /// </summary>
    public class Gamepadmainloop_Receipt_ViewTest : Gamepadmainloop_Receipt_View
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Gamepadmainloop_Receipt_ViewTest()
        {
            keyListener_MainImpl = new Gamepadmainloop_Receipt_SubImpl();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ゲームコントローラーのキー入力を監視。
        /// </summary>
        public void Perform(Gamepadmainloop mainloop)
        {
            // 接続ゲームコントローラー数。
            this.Uc_Form1.UsercontrolPage1.PctxtConnectedDevices.Text = mainloop.Input.Dictionary_GameController.Count.ToString();

            // 抜けたコントローラーのプレイヤー番号のリスト。
            List<int> listN_Lost = new List<int>();

            foreach (KeyValuePair<int, Memory_GameController> pair in mainloop.Input.Dictionary_GameController)
            {
                int nPlayer = pair.Key;
                Memory_GameController gc = pair.Value;
                Device gameController = gc.GameController;

                // ゲームコントローラーの、ボタンの押されている状況を取得します。
                // その他に、マウス、キーボードも取得できるかも。
                try
                {

                    // キー読取
                    this.keyListener_MainImpl.Perform(gc);

                    JoystickState state = gameController.CurrentJoystickState;

                    StringBuilder sb = new StringBuilder();
                    int nX = state.X;
                    int nY = state.Y;

                    // 1スタートで+1、カーソルキーが4つで+4。
                    int nMax1 = 4+gc.KeyCnf.NCount_MaxButton+1;
                    for (int nBtnIndex = 4+1; nBtnIndex < nMax1; nBtnIndex++)
                    {
                        if (gc.ButtonsFrame[nBtnIndex] == 1)
                        {
                            sb.Append("[");
                            sb.Append(nBtnIndex-4-1);
                            sb.Append("]");
                        }
                    }

                    if (5000 == nX)
                    {
                        //
                        // [→]
                        //
                        if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.Right] == 1)
                        {
                            sb.Append("[→]");
                        }
                    }
                    else if (-5000 == nX)
                    {
                        //
                        // [←]
                        //
                        if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.Left] == 1)
                        {
                            sb.Append("[←]");
                        }
                    }

                    if (5000 == nY)
                    {
                        //
                        // [↓]
                        //

                        if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.Down] == 1)
                        {
                            sb.Append("[↓]");
                        }
                    }
                    else if (-5000 == nY)
                    {
                        //
                        // [↑]
                        //

                        if (gc.ButtonsFrame[(int)EnumGamepadkeyIx.Up] == 1)
                        {
                            sb.Append("[↑]");
                        }
                    }




                    //
                    // 表示
                    //

                    string sTxt = sb.ToString();
                    int nMaxItems = 23;//リストボックスに表示できるアイテム数。
                    if (nPlayer < this.Uc_Form1.UsercontrolPage1.Usercontrol_VwdTestArray.Length)
                    {
                        Usercontrol_VwdTest ucController = this.Uc_Form1.UsercontrolPage1.Usercontrol_VwdTestArray[nPlayer];

                        if (null != ucController)
                        {
                            // フォーム配置完了時

                            //
                            // [↑]
                            //
                            {
                                int nKeyHard = (int)EnumGamepadkeyIx.Up;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    // todo:変更されているときだけ更新したい。
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = "↑";
                                }
                            }

                            //
                            // [→]
                            //
                            {
                                int nKeyHard = (int)EnumGamepadkeyIx.Right;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = "→";
                                }
                            }

                            // [↓]
                            {
                                int nKeyHard = (int)EnumGamepadkeyIx.Down;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = "↓";
                                }
                            }

                            // [←]
                            {
                                int nKeyHard = (int)EnumGamepadkeyIx.Left;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = "←";
                                }
                            }

                            // [0]
                            {
                                int nBtn = 0;
                                int nKeyHard = (int)EnumGamepadkeyIx.B0;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = nBtn.ToString();
                                }
                            }

                            // [1]
                            {
                                int nBtn = 1;
                                int nKeyHard = (int)EnumGamepadkeyIx.B1;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = nBtn.ToString();
                                }
                            }

                            // [2]
                            {
                                int nBtn = 2;
                                int nKeyHard = (int)EnumGamepadkeyIx.B2;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = nBtn.ToString();
                                }
                            }

                            // [3]
                            {
                                int nBtn = 3;
                                int nKeyHard = (int)EnumGamepadkeyIx.B3;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = nBtn.ToString();
                                }
                            }

                            // [4]
                            {
                                int nBtn = 4;
                                int nKeyHard = (int)EnumGamepadkeyIx.B4;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = nBtn.ToString();
                                }
                            }

                            // [5]
                            {
                                int nBtn = 5;
                                int nKeyHard = (int)EnumGamepadkeyIx.B5;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = nBtn.ToString();
                                }
                            }

                            // [6]
                            {
                                int nBtn = 6;
                                int nKeyHard = (int)EnumGamepadkeyIx.B6;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = nBtn.ToString();
                                }
                            }

                            // [7]
                            {
                                int nBtn = 7;
                                int nKeyHard = (int)EnumGamepadkeyIx.B7;
                                Label pclblB = ucController.PclblArray[nKeyHard];
                                if (0 < gc.ButtonsPressingFrame[nKeyHard])
                                {
                                    pclblB.ForeColor = Color.Blue;
                                    pclblB.Text = Utility_KeyconfigBit.GetShortString(gc.KeyCnf.KeyconfigArray[nKeyHard]);
                                }
                                else
                                {
                                    pclblB.ForeColor = Color.LightGray;
                                    pclblB.Text = nBtn.ToString();
                                }
                            }


                            if ("" != sTxt)
                            {
                                ucController.Pclst.Items.Add(sTxt);
                                if (nMaxItems < ucController.Pclst.Items.Count)
                                {
                                    ucController.Pclst.Items.RemoveAt(0);
                                }
                            }
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
                    listN_Lost.Add(nPlayer);
                }

                nPlayer++;
            }


            foreach (int nPlayer in listN_Lost)
            {
                // 削除
                mainloop.Input.Dictionary_GameController.Remove(nPlayer);
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
