using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Controls;

namespace Xenon.ListboxWrap
{
    public class ListboxWrapperImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public ListboxWrapperImpl(ListBox listbox)
        {
            this.listbox = listbox;
        }

        public ListboxWrapperImpl(UsercontrolListbox uctLst)
        {
            this.usercontrolListbox1 = uctLst;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// リストボックス
        /// </summary>
        private ListBox listbox;

        //────────────────────────────────────────

        /// <summary>
        /// ＣＳＶＥｘＥ用リストボックス ユーザーコントロール
        /// </summary>
        private UsercontrolListbox usercontrolListbox1;

        //────────────────────────────────────────

        public ListBox.SelectedObjectCollection SelectedItems
        {
            get
            {
                if (null != this.usercontrolListbox1)
                {
                    return this.usercontrolListbox1.SelectedItems;
                }
                else
                {
                    return this.listbox.SelectedItems;
                }
            }
        }

        //────────────────────────────────────────

        public ListBox.ObjectCollection Items
        {
            get
            {
                if (null != this.usercontrolListbox1)
                {
                    return this.usercontrolListbox1.Items;
                }
                else
                {
                    return this.listbox.Items;
                }
            }
        }

        //────────────────────────────────────────

        public ListBox.SelectedIndexCollection SelectedIndices
        {
            get
            {
                if (null != this.usercontrolListbox1)
                {
                    return this.usercontrolListbox1.SelectedIndices;
                }
                else
                {
                    return this.listbox.SelectedIndices;
                }
            }
        }

        //────────────────────────────────────────

        public void ClearSelected()
        {
            if (null != this.usercontrolListbox1)
            {
                this.usercontrolListbox1.ClearSelected();
            }
            else
            {
                this.listbox.ClearSelected();
            }
        }

        //────────────────────────────────────────

        public bool BEnabled
        {
            set
            {
                if (null != this.usercontrolListbox1)
                {
                    this.usercontrolListbox1.Enabled = value;
                }
                else
                {
                    this.listbox.Enabled = value;
                }
            }
            get
            {
                if (null != this.usercontrolListbox1)
                {
                    return this.usercontrolListbox1.Enabled;
                }
                else
                {
                    return this.listbox.Enabled;
                }
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
