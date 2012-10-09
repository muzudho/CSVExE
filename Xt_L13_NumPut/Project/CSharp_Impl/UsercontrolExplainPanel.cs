using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.NumPut
{
    public partial class UsercontrolExplainPanel : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolExplainPanel()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        private void SizeFit()
        {
            this.textBox1.Size = this.ClientSize;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void UcExplainPanel_SizeChanged(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        private void UcExplainPanel_Load(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        //────────────────────────────────────────
        #endregion



    }
}
