using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Lib;

namespace Xenon.PartsnumPut
{
    public partial class Form2Detail : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Form2Detail()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        private void SizeFit()
        {
            this.usercontrolDetailbrowser1.Width = this.ClientSize.Width;
            this.usercontrolDetailbrowser1.Height = this.ClientSize.Height;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form2Detail_SizeChanged(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        private void Form2Detail_Load(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public UsercontrolDetailbrowser UsercontrolDetailbrowser1
        {
            get
            {
                return this.usercontrolDetailbrowser1;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
