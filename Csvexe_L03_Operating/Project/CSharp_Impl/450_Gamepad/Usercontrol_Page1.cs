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
    /// ビュー・ページ1。
    /// </summary>
    public partial class Usercontrol_Page1 : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Usercontrol_Page1()
        {
            InitializeComponent();

            // コンポーネントを生成した後で。
            this.usercontrol_VwdTestArray = new Usercontrol_VwdTest[4 + 1];
            this.usercontrol_VwdTestArray[1] = this.ucController1;
            this.usercontrol_VwdTestArray[2] = this.ucController2;
            this.usercontrol_VwdTestArray[3] = this.ucController3;
            this.usercontrol_VwdTestArray[4] = this.ucController4;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────
        
        private Usercontrol_VwdTest[] usercontrol_VwdTestArray;

        public Usercontrol_VwdTest[] Usercontrol_VwdTestArray
        {
            get
            {
                return usercontrol_VwdTestArray;
            }
        }

        //────────────────────────────────────────

        public TextBox PctxtConnectedDevices
        {
            get
            {
                return this.pctxtConnectedDevices;
            }
        }

        //────────────────────────────────────────

        public TextBox PctxtTimer
        {
            get
            {
                return this.pctxtTimer;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
