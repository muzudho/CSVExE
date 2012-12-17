using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xt_L13_XenonEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.control_Workbench1.Sizefit(this);
            this.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.control_Workbench1.Sizefit(this);
        }
    }
}
