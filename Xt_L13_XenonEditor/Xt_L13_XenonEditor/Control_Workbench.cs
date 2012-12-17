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
    public partial class Control_Workbench : UserControl
    {
        public Control_Workbench()
        {
            InitializeComponent();
        }

        public void Sizefit(Control parent)
        {

            if (parent is Form)
            {
                Form form = (Form)parent;

                this.Location = new Point();
                this.Size = form.ClientSize;
                //System.Console.WriteLine("親コントロール名＝[" + parent.GetType().Name + "]");


                // left=20% top=0%
                this.control_Textarea1.Bounds = new Rectangle(
                    this.Size.Width * 20 / 100,
                    0,
                    this.Size.Width * 80 / 100,
                    this.Size.Height
                    );

            }
        }

        private void Control_Workbench_Load(object sender, EventArgs e)
        {
            //Control control = this.Parent;
            //System.Console.WriteLine("親コントロール名＝[" + this.Parent.GetType().Name + "]");

            //if (control is Form)
            //{
            //    Form form = (Form)control;

            //    this.Size = form.ClientSize;
            //}
        }
    }
}
