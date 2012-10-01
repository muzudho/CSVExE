using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;//Font
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Operating;//BuilderColor,ColorResult

namespace Xenon.Controls
{
    /// <summary>
    /// メインウィンドウ_ラッパー。
    /// </summary>
    public class Mainwnd_FormWrappingImpl : Mainwnd_FormWrapping
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Mainwnd_FormWrappingImpl(Form form)
        {
            // ヌル・アクセス防止のため
            this.form = form;
            this.controlCommon__ = new ControlCommonImpl();

            //InitializeComponent();

            //
            // 暫定。
            // TODO: 「レイアウト設定ファイル」で指定したい。
            //
            this.UsercontrolWidth = 600;
            this.UsercontrolHeight = 800;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// レイアウト_レコードを元に、コントロールのスタイルを設定します。
        /// </summary>
        /// <param nFcName="fo_Record"></param>
        /// <param nFcName="log_Reports"></param>
        public void SetupStyle(
            RecordUserformconfig fo_Record,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "SetupStyle",log_Reports);
            //


            // 自動入力ここから
            this.ControlCommon.BAutomaticinputting = true;

            {
                string sText;
                fo_Record.TryGetString(out sText, NamesFld.S_TEXT, false, "", log_Reports);
                this.UsercontrolText = sText;

                bool bEnabled;
                fo_Record.TryGetBool(out bEnabled, NamesFld.S_ENABLED, log_Reports);
                this.UsercontrolEnabled = bEnabled;

                bool bVisible;
                fo_Record.TryGetBool(out bVisible, NamesFld.S_VISIBLE, log_Reports);
                this.UsercontrolVisible = bVisible;

                // フォントの設定
                {
                    // フォント・サイズの設定
                    float nFontSizePt = Utility_Usercontrol.ParseFontSize(fo_Record, log_Reports);
                    this.Font = new System.Drawing.Font("MS UI Gothic", nFontSizePt, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                }



                int nAbsXLt;
                fo_Record.TryGetInt(out nAbsXLt, NamesFld.S_X_LT, false, -1, log_Reports);

                int nAbsYLt;
                fo_Record.TryGetInt(out nAbsYLt, NamesFld.S_Y_LT, false, -1, log_Reports);

                // 【特殊】ユーザーコントロールではなく、持っているウィンドウに対して変更。
                this.form.Location = new System.Drawing.Point(nAbsXLt, nAbsYLt);



                int nWidth;
                fo_Record.TryGetInt(out nWidth, NamesFld.S_WIDTH, false, 1, log_Reports);

                int nHeight;
                fo_Record.TryGetInt(out nHeight, NamesFld.S_HEIGHT, false, 1, log_Reports);

                // 【特殊】ユーザーコントロールではなく、持っているウィンドウに対して変更。
                this.form.Size = new System.Drawing.Size(nWidth, nHeight);
            }

            // 背景色の設定
            string sBackColor;
            fo_Record.TryGetString(out sBackColor, NamesFld.S_BACK_COLOR, false, "", log_Reports);
            this.UsercontrolBackcolor = sBackColor;

            this.ControlCommon.BAutomaticinputting = false;
            // 自動入力ここまで


            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sUsercontrolBackcolor;
        public string UsercontrolBackcolor
        {
            get
            {
                return this.sUsercontrolBackcolor;
            }
            set
            {
                this.sUsercontrolBackcolor = value;

                ColorResult colorResult = BuilderColor.Parse(this.sUsercontrolBackcolor, SystemColors.Control, false);
                this.Form.BackColor = colorResult.Color;// 【特殊】ユーザーコントロールではなく、持っているウィンドウに対して変更。
            }
        }

        //────────────────────────────────────────

        private ControlCommon controlCommon__;

        /// <summary>
        /// コントロールの共通プロパティー、およびロジックが含まれているクラスです。
        /// 
        /// C#では多重継承ができないので、共通のプロパティー、ロジックがあれば、ここに含めます。
        /// </summary>
        public ControlCommon ControlCommon
        {
            get
            {
                return this.controlCommon__;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ラッピングされるフォーム。
        /// </summary>
        private Form form;

        public Form Form
        {
            get
            {
                return this.form;
            }
        }

        //────────────────────────────────────────

        public bool UsercontrolVisible
        {
            get
            {
                return this.Form.Visible;
            }
            set
            {
                this.Form.Visible = value;
            }
        }

        //────────────────────────────────────────

        public Font Font
        {
            get
            {
                return this.Form.Font;
            }
            set
            {
                this.Form.Font = value;
            }
        }

        //────────────────────────────────────────

        public int UsercontrolWidth
        {
            get
            {
                return this.Form.Width;
            }
            set
            {
                this.Form.Width = value;
            }
        }

        //────────────────────────────────────────

        public int UsercontrolHeight
        {
            get
            {
                return this.Form.Height;
            }
            set
            {
                this.Form.Height = value;
            }
        }

        //────────────────────────────────────────

        public string UsercontrolText
        {
            set
            {
                this.Form.Text = value;
            }
            get
            {
                return this.Form.Text;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロールに、人間オペレーターが入力をできるか否か。
        /// </summary>
        [
        Category("追加"),
        Description("このコントロールを使用可能にするなら真です。")
        ]
        public bool UsercontrolEnabled
        {
            set
            {
                this.Form.Enabled = value;
            }
            get
            {
                return this.Form.Enabled;
            }
        }

        //────────────────────────────────────────
        #endregion

        

    }
}
