using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Controls;

namespace Xenon.ListboxWrap
{
    public class TextboxWrapperImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public TextboxWrapperImpl(TextBox textbox)
        {
            this.textbox1 = textbox;
        }

        public TextboxWrapperImpl(UsercontrolTextbox uctTxt)
        {
            this.usercontrolTextbox2 = uctTxt;
        }

        public void Clear()
        {
            if (null != this.usercontrolTextbox2)
            {
                this.usercontrolTextbox2.Clear();
            }
            else
            {
                this.textbox1.Clear();
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// テキストボックス
        /// </summary>
        private TextBox textbox1;

        //────────────────────────────────────────

        /// <summary>
        /// ＣＳＶＥｘＥ用テキストボックス ユーザーコントロール
        /// </summary>
        private UsercontrolTextbox usercontrolTextbox2;

        //────────────────────────────────────────

        public string SText
        {
            set
            {
                if (null != this.usercontrolTextbox2)
                {
                    this.usercontrolTextbox2.Text = value;
                }
                else
                {
                    this.textbox1.Text = value;
                }
            }
            get
            {
                if (null != this.usercontrolTextbox2)
                {
                    return this.usercontrolTextbox2.Text;
                }
                else
                {
                    return this.textbox1.Text;
                }
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
