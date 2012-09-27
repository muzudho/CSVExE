using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;
using System.Drawing;//Color
using System.Windows.Forms;//Label
using Xenon.Syntax;

using Xenon.Table;//XenonTable

namespace Xenon.Operating
{
    public partial class Usercontrol_Form1 : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Usercontrol_Form1()
        {
            InitializeComponent();

            this.mainloop = new Gamepadmainloop_SampleImpl(this);
            this.mainloop.Init();
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Mainloop.Load();
        }

        /// <summary>
        /// 16ミリ秒置きに。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctmr1_Tick(object sender, EventArgs e)
        {
            this.Mainloop.Step();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Gamepadmainloop mainloop;

        /// <summary>
        /// メインループ。
        /// </summary>
        public Gamepadmainloop Mainloop
        {
            get
            {
                return mainloop;
            }
            set
            {
                mainloop = value;
            }
        }

        //────────────────────────────────────────

        public TabControl TabControl1
        {
            get
            {
                return this.tabControl1;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// キーコンフィグを試すページ。
        /// </summary>
        public Usercontrol_Page1 UsercontrolPage1
        {
            get
            {
                return this.ucPage1;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// キーコンフィグを設定するページ。
        /// </summary>
        public Usercontrol_Page2 UsercontrolPage2
        {
            get
            {
                return this.ucPage2;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// キーコンフィグのテキストを確認するページ。
        /// </summary>
        public Usercontrol_Page3 UsercontrolPage3
        {
            get
            {
                return this.ucPage3;
            }
        }

        //────────────────────────────────────────

        public Timer Pctmr1
        {
            get
            {
                return pctmr1;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
