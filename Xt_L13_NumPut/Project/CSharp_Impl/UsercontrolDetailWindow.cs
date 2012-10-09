using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.NumPut
{
    public partial class UsercontrolDetailWindow : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolDetailWindow()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        private void SizeFit()
        {
            this.ucDetailOut1.Width = this.ClientSize.Width;
            this.ucDetailOut1.Height = this.ClientSize.Height;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void UcDetailWindow_SizeChanged(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        private void UcDetailWindow_Load(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public UsercontrolDetailOut UcDetailOut
        {
            get
            {
                return this.ucDetailOut1;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
