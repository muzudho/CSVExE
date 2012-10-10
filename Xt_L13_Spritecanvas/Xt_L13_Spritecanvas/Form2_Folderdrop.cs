using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xt_L13_Spritecanvas
{
    public partial class Form2_Folderdrop : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Form2_Folderdrop()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void SizeFit()
        {

            this.usercontrolPanelFiledrop1.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);

        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form2_Folderdrop_Load(object sender, EventArgs e)
        {

            this.SizeFit();

        }

        //────────────────────────────────────────
        #endregion



    }
}
