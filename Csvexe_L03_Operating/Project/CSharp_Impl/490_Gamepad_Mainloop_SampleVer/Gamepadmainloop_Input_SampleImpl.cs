using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;
using System.Data;//DataTable
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Table;//XenonTable,XenonValue_IntImpl

namespace Xenon.Operating
{
    /// <summary>
    /// メインループの中の、入力担当。
    /// </summary>
    public class Gamepadmainloop_Input_SampleImpl : Gamepadmainloop_Input
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Gamepadmainloop_Input_SampleImpl()
        {
            this.dictionary_GameController = new Dictionary<int, Memory_GameController>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ゲームコントローラーの接続を監視。
        /// </summary>
        public void ListenController(Gamepadmainloop mainloopPrm)
        {
            if (!(mainloopPrm is Gamepadmainloop_SampleImpl))
            {
                throw new Exception("未対応のクラスが引数に渡されました。");
            }

            Gamepadmainloop_SampleImpl mainloop = (Gamepadmainloop_SampleImpl)mainloopPrm;

            //ゲームコントローラーの接続を監視。毎フレーム監視していては重いと思うので、たまに。
            if (this.ListenFrame < 1)
            {
                goto gt_play;
            }
            if (62 <= this.ListenFrame)
            {
                this.ListenFrame = -1;
            }
            this.ListenFrame++;

            return;

            //
            //
            //
            //

            gt_play:

            //
            // 接続されている「ゲーム用コントローラー」のリストを取得します。
            DeviceList dl = Manager.GetDevices(
                    DeviceClass.GameControl,
                    EnumDevicesFlags.AttachedOnly
                    );

            List<DeviceInstance> deviceInstanceList = new List<DeviceInstance>();
            foreach (DeviceInstance di in dl)
            {
                deviceInstanceList.Add(di);
            }

            if (this.Dictionary_GameController.Count != deviceInstanceList.Count)
            {
                //
                // 設定し直し。
                // TODO: 抜けてないプレイヤーの接続は、そのまま保持しておきたい。
                //
                this.Dictionary_GameController.Clear();

                int playerNumber = 1;
                foreach (DeviceInstance di in deviceInstanceList)
                {

                    Device gameControl = new Device(di.InstanceGuid);
                    Memory_GameController gc = new Memory_GameController();
                    gc.GameController = gameControl;
                    this.Dictionary_GameController.Add(playerNumber, gc);

                    this.ReadKeyconfig(mainloop, playerNumber, gc);

                    // 十字キーまたはレバーのX,Yの倒れ具合を、-5000,0,5000 で表現するように設定。
                    foreach (DeviceObjectInstance doi in gameControl.Objects)
                    {
                        if ((doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
                        {
                            gameControl.Properties.SetRange(
                                ParameterHow.ById,
                                doi.ObjectId,
                                new InputRange(-5000, 5000)
                                );
                        }
                    }

                    // 倒れ方を相対的ではなく、絶対的に判定。
                    gameControl.Properties.AxisModeAbsolute = true;

                    // 「協調レベル」を設定。キーボードやゲームパッドの取り合い、ウィンドウが前景のとき背景のとき等をここで設定。
                    gameControl.SetCooperativeLevel(
                        mainloop.Form1,
                        CooperativeLevelFlags.NonExclusive |
                        CooperativeLevelFlags.Background
                        );

                    // キャプチャー（入力の補足）を獲得する。
                    gameControl.Acquire();

                    playerNumber++;
                }
            }

        }

        //────────────────────────────────────────

        private void ReadKeyconfig(Gamepadmainloop mainloop, int nPlayerPrm, Memory_GameController gc)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Operating.Name_Library, this, "ReadKeyConfig",log_Reports_ThisMethod);

            // テーブルを、上から下に読んでいく。
            // 列の並び順は NO	ID	Expl	PLAYER	BEFORE	AFTER

            if (null != this.XenonTable_Keyconfig)//テーブルの読取が成功していること。
            {
                DataTable dataTable = this.XenonTable_Keyconfig.DataTable;

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int nPlayer;
                    XenonValue_IntImpl.TryParse(
                        dataRow.ItemArray[3],
                        out nPlayer,
                        EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                        0,
                        log_Reports_ThisMethod
                        );

                    if (nPlayerPrm == nPlayer)
                    {
                        string sBefore;
                        string sAfter;

                        XenonValue_StringImpl.TryParse(
                            dataRow.ItemArray[4],
                            out sBefore,
                            "",
                            "",
                            pg_Method,
                            log_Reports_ThisMethod
                            );

                        XenonValue_StringImpl.TryParse(
                            dataRow.ItemArray[5],
                            out sAfter,
                            "",
                            "",
                            pg_Method,
                            log_Reports_ThisMethod
                            );

                        EnumGamepadkeyIx o_Before;
                        EnumGamepadkeyBit o_After;

                        switch (sBefore)
                        {
                            case "Up":
                                o_Before = EnumGamepadkeyIx.Up;
                                break;
                            case "Right":
                                o_Before = EnumGamepadkeyIx.Right;
                                break;
                            case "Down":
                                o_Before = EnumGamepadkeyIx.Down;
                                break;
                            case "Left":
                                o_Before = EnumGamepadkeyIx.Left;
                                break;
                            case "1":
                                o_Before = EnumGamepadkeyIx.B0;
                                break;
                            case "2":
                                o_Before = EnumGamepadkeyIx.B1;
                                break;
                            case "3":
                                o_Before = EnumGamepadkeyIx.B2;
                                break;
                            case "4":
                                o_Before = EnumGamepadkeyIx.B3;
                                break;
                            case "5":
                                o_Before = EnumGamepadkeyIx.B4;
                                break;
                            case "6":
                                o_Before = EnumGamepadkeyIx.B5;
                                break;
                            case "7":
                                o_Before = EnumGamepadkeyIx.B6;
                                break;
                            case "8":
                                o_Before = EnumGamepadkeyIx.B7;
                                break;
                            default:
                                o_Before = EnumGamepadkeyIx.Up;
                                break;
                        }

                        switch (sAfter)
                        {
                            case "Up":
                                o_After = EnumGamepadkeyBit.Up;
                                break;
                            case "Right":
                                o_After = EnumGamepadkeyBit.Right;
                                break;
                            case "Down":
                                o_After = EnumGamepadkeyBit.Down;
                                break;
                            case "Left":
                                o_After = EnumGamepadkeyBit.Left;
                                break;
                            case "A":
                                o_After = EnumGamepadkeyBit.A;
                                break;
                            case "B":
                                o_After = EnumGamepadkeyBit.B;
                                break;
                            case "X":
                                o_After = EnumGamepadkeyBit.X;
                                break;
                            case "Y":
                                o_After = EnumGamepadkeyBit.Y;
                                break;
                            case "L":
                                o_After = EnumGamepadkeyBit.L;
                                break;
                            case "R":
                                o_After = EnumGamepadkeyBit.R;
                                break;
                            case "Select":
                                o_After = EnumGamepadkeyBit.Select;
                                break;
                            case "Start":
                                o_After = EnumGamepadkeyBit.Start;
                                break;
                            default:
                                o_After = EnumGamepadkeyBit.Up;
                                break;
                        }

                        gc.KeyCnf.KeyconfigArray[(int)o_Before] = o_After;
                    }
                }
            }

            //
            //
            pg_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(pg_Method);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<int, Memory_GameController> dictionary_GameController;

        /// <summary>
        /// 接続されているゲームコントローラーの状態のリスト。
        /// </summary>
        public Dictionary<int, Memory_GameController> Dictionary_GameController
        {
            get
            {
                return dictionary_GameController;
            }
            set
            {
                dictionary_GameController = value;
            }
        }

        //────────────────────────────────────────

        private XenonTable xenonTable_Keyconfig;

        /// <summary>
        /// キー設定を記憶します。
        /// </summary>
        public XenonTable XenonTable_Keyconfig
        {
            get
            {
                return xenonTable_Keyconfig;
            }
            set
            {
                xenonTable_Keyconfig = value;
            }
        }

        //────────────────────────────────────────

        private int listenFrame;

        /// <summary>
        /// ゲームコントローラーの接続を監視してから何フレーム経ったか。
        /// </summary>
        public int ListenFrame
        {
            get
            {
                return listenFrame;
            }
            set
            {
                listenFrame = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
