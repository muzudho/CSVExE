using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.Controls
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

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = SystemColors.ControlText;
            label.BackColor = SystemColors.Control;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = Color.Green;
            label.BackColor = Color.YellowGreen;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = Color.Green;
            label.BackColor = Color.DarkSeaGreen;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = Color.Green;
            label.BackColor = Color.YellowGreen;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // ↑キーを押したとき

                //
                //
                // テキストボックスの内容が数値なら、+1 します。
                // 空白なら 0 を入れます。
                // それ以外なら無視します。
                //
                if (this.textBox1.Text == "")
                {
                    this.textBox1.Text = "0";
                }
                else
                {
                    int nNumber;
                    if (!int.TryParse(this.textBox1.Text,out nNumber))
                    {
                        // エラー
                        // 操作を無視します。
                    }
                    else
                    {
                        nNumber++;
                        this.textBox1.Text = nNumber.ToString();
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                // ↓キーを押したとき

                //
                //
                // テキストボックスの内容が数値なら、-1 します。
                // 空白なら 0 を入れます。
                // それ以外なら無視します。
                //
                if (this.textBox1.Text == "")
                {
                    this.textBox1.Text = "0";
                }
                else
                {
                    int nNumber;
                    if(!int.TryParse(this.textBox1.Text,out nNumber))
                    {
                        //エラー
                        // 操作を無視します。
                    }
                    else
                    {
                        nNumber--;
                        this.textBox1.Text = nNumber.ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //────────────────────────────────────────
        #endregion



    }
}
