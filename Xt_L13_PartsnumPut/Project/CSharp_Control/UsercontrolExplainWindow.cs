using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.PartsnumPut
{
    public partial class UsercontrolExplainWindow : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolExplainWindow()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        private void SizeFit()
        {
            this.ucExplainPanel1.Size = this.ClientSize;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void UcExplainWindow_Load(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        private void UcExplainWindow_SizeChanged(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        //────────────────────────────────────────
        #endregion



    }
}
