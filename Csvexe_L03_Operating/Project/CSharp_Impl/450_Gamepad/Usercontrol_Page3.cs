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
    /// 設定ファイルの中身をテキスト表示。
    /// </summary>
    public partial class Usercontrol_Page3 : UserControl
    {


        #region 生成と破棄
        //────────────────────────────────────────

        public Usercontrol_Page3()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────

        public void Init()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Open(int nPlayer, KeyconfigPadImpl keycnfPad, out string sErrorMsg)
        {
            TextBox pctxt;
            switch(nPlayer)
            {
                case 2:
                    pctxt = this.textBox2;
                    break;
                case 3:
                    pctxt = this.textBox3;
                    break;
                case 4:
                    pctxt = this.textBox4;
                    break;
                default:
                    pctxt = this.textBox1;
                    break;
            }

            // 1～12
            for (int nNum = 1; nNum < 13; nNum++)
            {
                EnumGamepadkeyIx enumGa = Utility_KeyconfigArray.IntTo(nNum);
                EnumGamepadkeyBit enumGp = keycnfPad.KeyconfigArray[(int)enumGa];

                switch (enumGp)
                {
                    case EnumGamepadkeyBit.Up:
                        // [↑]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.Right:
                        // [→]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.Down:
                        // [↓]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.Left:
                        // [←]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.A:
                        // [A]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.B:
                        // [B]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.X:
                        // [X]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.Y:
                        // [Y]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.L:
                        // [L]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.R:
                        // [R]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.Start:
                        // [Start]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
                        break;
                    case EnumGamepadkeyBit.Select:
                        // [Select]
                        pctxt.Text += Utility_KeyconfigArray.ToString_Display(enumGa);
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



    }
}
