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
    public partial class Form1 : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Form1()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            //詳細ウィンドウを出す
            this.form2_Folderdrop = new Form2_Folderdrop();
            this.form2_Folderdrop.Show();
            this.form2_Folderdrop.TopMost = true;

        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Form2_Folderdrop form2_Folderdrop;

        public Form2_Folderdrop Form2_Folderdrop
        {
            get
            {
                return this.form2_Folderdrop;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
