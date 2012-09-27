using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.Operating
{

    /// <summary>
    /// ビュー・ページ2。
    /// </summary>
    public partial class Usercontrol_Page2 : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Usercontrol_Page2()
        {
            InitializeComponent();

            // コンポーネントを生成した後で。
            this.usercontrol_VwdKeycnfArray = new Usercontrol_VwdKeycnf[4 + 1];
            this.usercontrol_VwdKeycnfArray[1] = this.ucControllerCnf1;
            this.usercontrol_VwdKeycnfArray[2] = this.ucControllerCnf2;
            this.usercontrol_VwdKeycnfArray[3] = this.ucControllerCnf3;
            this.usercontrol_VwdKeycnfArray[4] = this.ucControllerCnf4;

            for (int i = 1; i < 5; i++)
            {
                this.Usercontrol_VwdKeycnfArray[i].PctxtUp.ForeColor = Color.White;
                this.Usercontrol_VwdKeycnfArray[i].PctxtUp.BackColor = Color.Blue;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Open(int nPlayer, KeyconfigPadImpl keycnfPad,out string sErrorMsg)
        {

            Usercontrol_VwdKeycnf ucGmctrlOneCnf = this.usercontrol_VwdKeycnfArray[nPlayer];

            // 1～12
            for (int nNum = 1; nNum < 13; nNum++ )
            {
                EnumGamepadkeyIx gaEnum = Utility_KeyconfigArray.IntTo(nNum);
                EnumGamepadkeyBit gpEnum = keycnfPad.KeyconfigArray[(int)gaEnum];

                switch (gpEnum)
                {
                    case EnumGamepadkeyBit.Up:
                        // [↑]
                        ucGmctrlOneCnf.PctxtUp.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.Right:
                        // [→]
                        ucGmctrlOneCnf.PctxtRight.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.Down:
                        // [↓]
                        ucGmctrlOneCnf.PctxtDown.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.Left:
                        // [←]
                        ucGmctrlOneCnf.PctxtLeft.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.A:
                        // [A]
                        ucGmctrlOneCnf.PctxtA.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.B:
                        // [B]
                        ucGmctrlOneCnf.PctxtB.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.X:
                        // [X]
                        ucGmctrlOneCnf.PctxtX.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.Y:
                        // [Y]
                        ucGmctrlOneCnf.PctxtY.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.L:
                        // [L]
                        ucGmctrlOneCnf.PctxtL.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.R:
                        // [R]
                        ucGmctrlOneCnf.PctxtR.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.Start:
                        // [Start]
                        ucGmctrlOneCnf.PctxtStart.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    case EnumGamepadkeyBit.Select:
                        // [Select]
                        ucGmctrlOneCnf.PctxtSelect.Text = Utility_KeyconfigArray.ToString_Display(gaEnum);
                        break;
                    default:
                        break;
                }
            }

            sErrorMsg = "";
            return;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Usercontrol_VwdKeycnf[] usercontrol_VwdKeycnfArray;

        public Usercontrol_VwdKeycnf[] Usercontrol_VwdKeycnfArray
        {
            get
            {
                return usercontrol_VwdKeycnfArray;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
