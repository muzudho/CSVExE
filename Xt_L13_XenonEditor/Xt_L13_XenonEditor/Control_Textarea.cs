using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xt_L13_XenonEditor
{
    public partial class Control_Textarea : UserControl
    {
        public Control_Textarea()
        {
            InitializeComponent();
        }

        private void Control_Textarea_Load(object sender, EventArgs e)
        {
            this.textBox1.Location = new Point();
            this.textBox1.Size = this.Size;
        }

        private void Control_Textarea_Resize(object sender, EventArgs e)
        {
            this.textBox1.Location = new Point();
            this.textBox1.Size = this.Size;
        }
    }
}
