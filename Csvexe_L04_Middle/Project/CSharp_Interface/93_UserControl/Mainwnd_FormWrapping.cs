using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;//Font
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;

namespace Xenon.Middle
{
    public interface Mainwnd_FormWrapping
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// レイアウト_レコードを元に、コントロールのスタイルを設定します。
        /// </summary>
        /// <param nFcName="fo_Record"></param>
        /// <param nFcName="log_Reports"></param>
        void SetupStyle(
            RecordUserformconfig fo_Record,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        Form Form
        {
            get;
        }

        bool UsercontrolVisible
        {
            get;
            set;
        }

        Font Font
        {
            get;
            set;
        }

        int UsercontrolWidth
        {
            get;
            set;
        }

        int UsercontrolHeight
        {
            get;
            set;
        }

        ControlCommon ControlCommon
        {
            get;
        }

        string UsercontrolText
        {
            set;
            get;
        }


        /// <summary>
        /// コントロールに、人間オペレーターが入力をできるか否か。
        /// </summary>
        [
        Category("追加"),
        Description("このコントロールを使用可能にするなら真です。")
        ]
        bool UsercontrolEnabled
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
