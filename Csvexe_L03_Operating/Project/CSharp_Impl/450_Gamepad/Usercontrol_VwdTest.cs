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
    /// View Dimension。
    /// </summary>
    public partial class Usercontrol_VwdTest : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Usercontrol_VwdTest()
        {
            InitializeComponent();

            // コンポーネント生成後に。
            this.pclblArray = new Label[32];
            this.pclblArray[(int)EnumGamepadkeyIx.Up] = this.pclblUp;
            this.pclblArray[(int)EnumGamepadkeyIx.Right] = this.pclblRight;
            this.pclblArray[(int)EnumGamepadkeyIx.Down] = this.pclblDown;
            this.pclblArray[(int)EnumGamepadkeyIx.Left] = this.pclblLeft;
            this.pclblArray[(int)EnumGamepadkeyIx.B0] = this.pclblB0;
            this.pclblArray[(int)EnumGamepadkeyIx.B1] = this.pclblB1;
            this.pclblArray[(int)EnumGamepadkeyIx.B2] = this.pclblB2;
            this.pclblArray[(int)EnumGamepadkeyIx.B3] = this.pclblB3;
            this.pclblArray[(int)EnumGamepadkeyIx.B4] = this.pclblB4;
            this.pclblArray[(int)EnumGamepadkeyIx.B5] = this.pclblB5;
            this.pclblArray[(int)EnumGamepadkeyIx.B6] = this.pclblB6;
            this.pclblArray[(int)EnumGamepadkeyIx.B7] = this.pclblB7;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public ListBox Pclst
        {
            get
            {
                return this.pclst;
            }
        }

        //────────────────────────────────────────

        private Label[] pclblArray;

        public Label[] PclblArray
        {
            get
            {
                return pclblArray;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
