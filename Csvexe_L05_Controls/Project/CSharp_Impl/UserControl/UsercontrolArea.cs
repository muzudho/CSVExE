using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//Log_TextIndentedImpl
using Xenon.Middle;
using Xenon.Operating;//BuilderColor,ColorResult

namespace Xenon.Controls
{

    /// <summary>
    /// 「ara」。矩形領域。
    /// 
    /// 注意。カスタム コントロールとして パネルを持っていますが、
    /// ControlCommonを使うためだけで、GUIとしては利用していません。
    /// </summary>
    public partial class UsercontrolArea : UserControl, Usercontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolArea()
        {
            // ヌル・アクセス防止のため
            this.customcontrolPanel1 = new CustomcontrolPanel();

            InitializeComponent();

            // 画面のちらつきをなくすために、ダブル・バッファーを真にします。
            this.DoubleBuffered = true;

            this.Clear();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 空の状態に設定します。
        /// </summary>
        public void Clear()
        {
        }

        /// <summary>
        /// イベントハンドラーを全て除去します。
        /// </summary>
        public void ClearAllEventhandlers(Log_Reports log_Reports)
        {
            Remover_AllEventhandlers remover = new Remover_AllEventhandlersImpl(
                this,
                log_Reports
                );

            remover.Suppress(
                log_Reports
                );

            //            remover.Resume(log_Reports);

            foreach (Customcontrol cct in this.List_Customcontrol)
            {
                cct.ClearAllEventhandlers(log_Reports);
            }
        }

        /// <summary>
        /// 構成カスタム・コントロールを全て破棄します。
        /// </summary>
        public void DestractAllCustomcontrols(Log_Reports log_Reports)
        {
            foreach (Customcontrol cct in this.List_Customcontrol)
            {
                cct.Destruct(
                    log_Reports
                    );
            }
        }

        //────────────────────────────────────────

        public void Destruct(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Destruct(10)",log_Reports);
            //
            //

            this.ClearAllEventhandlers(log_Reports);

            this.DestractAllCustomcontrols(log_Reports);

            this.Clear();

            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// イベント アクション リストを作成します。
        /// </summary>
        /// <param nFcName="eventName"></param>
        /// <param nFcName="nActionSuper"></param>
        /// <param nFcName="log_Reports"></param>
        public Functionlist CreateFunctionlist(
            GivechapterandverseToExpression_Event sToE_Event,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "CreateFunctionlist",log_Reports);
            //
            //
            Functionlist fc_Result = null;

            switch (sToE_Event.Name)
            {
                case NamesSe.S_LOAD:
                    {
                        //
                        // このコントロールの「アプリケーション起動時」。
                        //
                        //  （NActionPerformEnum.O_EA）
                        //

                        //
                        // 無視します。
                        //
                    }
                    break;

                default:
                    goto gt_Error_NotSupportedEvent;
            }

            //.WriteLine(this.GetType().NFcName + "#CreateEventActionList: ■■■■■■■■■■未実装です。無視されます。rEvent.NFcName=[" + rEvent.NFcName + "]■■■■■■■■■■");

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSupportedEvent:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー321！", pg_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("「コントロール設定ファイル」の記述エラーか、プログラムの未実装です。");
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(this.GetType().Name);
                t.Append("]クラスは、");
                t.Append(Environment.NewLine);
                t.Append("指定されたイベントの名前");
                t.Append(Environment.NewLine);
                t.Append("rEvent.Name=[");
                t.Append(sToE_Event.Name);
                t.Append("]には対応できません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(sToE_Event.Givechapterandverse_Event));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return fc_Result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 子コントロールを追加します。
        /// </summary>
        /// <param nFcName="uct"></param>
        public void AppendChild(
            Usercontrol uct,
            Log_Reports log_Reports
            )
        {
            if (log_Reports.Successful)
            {
                ////
                //// ユーザーコントロールに、
                //// ユーザーコントロールを追加します。
                ////
                this.Controls.Add((Control)uct);

                //
                // パネルなのは カスタム コントロールなので、
                // カスタム コントロールに、
                // ユーザーコントロールを追加します。
                //
                //this.CcPanel.Controls.Add((Control)uct);
            }
        }

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


                int nAbsXLt;
                fo_Record.TryGetInt(out nAbsXLt, NamesFld.S_X_LT, false, -1, log_Reports);

                int nAbsYLt;
                fo_Record.TryGetInt(out nAbsYLt, NamesFld.S_Y_LT, false, -1, log_Reports);

                this.Location = new System.Drawing.Point(nAbsXLt, nAbsYLt);


                int nWidth;
                fo_Record.TryGetInt(out nWidth, NamesFld.S_WIDTH, false, 1, log_Reports);

                int nHeight;
                fo_Record.TryGetInt(out nHeight, NamesFld.S_HEIGHT, false, 1, log_Reports);

                this.Size = new System.Drawing.Size(nWidth, nHeight);
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

        /// <summary>
        /// データソースから値を取得し、コントロールに取り込みます。
        /// </summary>
        public void RefreshData(
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロールの内容値で、データソースの値を更新します。
        /// </summary>
        public void UsercontrolToMemory(
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// 妥当性判定ロジックを追加します。
        /// </summary>
        /// <param nFcName="nValidator"></param>
        public void AddValidator(
            Expressionv_Validator_Old ecv_Validator,
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// 再描画のタイミングで、データの再読込をさせる指定をします。
        /// </summary>
        /// <param name="log_Reports"></param>
        public void Dirty(
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void UsercontrolArea_SizeChanged(object sender, EventArgs e)
        {
            UsercontrolArea ucArea = (UsercontrolArea)sender;

            this.customcontrolPanel1.Width = ucArea.Width;
            this.customcontrolPanel1.Height = ucArea.Height;
            //.WriteLine(this.GetType().NFcName + "#UcTabPage_SizeChanged: UcAreaの横縦幅（" + this.ccPanel.Width + "," + this.ccPanel.Height + "）");
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 妥当性を判定します。
        /// </summary>
        public void JudgeValidity(
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public string UsercontrolChkvaluetype
        {
            get
            {
                //該当なし
                return "";
            }
        }

        public int UsercontrolPiczoom
        {
            get
            {
                //該当なし
                return -1;
            }
        }

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
                this.BackColor = colorResult.Color;
            }
        }

        public int UsercontrolItemheightpx
        {
            get
            {
                //該当なし
                return -1;
            }
        }

        public string UsercontrolItemdisplayformat
        {
            get
            {
                //該当なし
                return "";
            }
        }

        public string UsercontrolListvaluefield
        {
            get
            {
                //該当なし
                return "";
            }
        }

        //────────────────────────────────────────

        public bool UsercontrolReadonly
        {
            get
            {
                //該当なし
                return false;
            }
        }

        public bool UsercontrolWordwrap
        {
            get
            {
                //該当なし
                return false;
            }
        }

        public string UsercontrolNewline
        {
            get
            {
                //該当なし
                return "";
            }
        }

        //────────────────────────────────────────

        public float UsercontrolFontsizept
        {
            get
            {
                return this.CustomcontrolPanel1.Font.Size;
            }
        }

        public int UsercontrolTabindex
        {
            get
            {
                return this.CustomcontrolPanel1.TabIndex;
            }
        }

        public ScrollBars UsercontrolScrollbars
        {
            get
            {
                //該当なし
                return ScrollBars.None;
            }
            set
            {
                //該当なし
            }
        }

        //────────────────────────────────────────

        public int UsercontrolXlt
        {
            get
            {
                return this.Location.X;
            }
        }

        public int UsercontrolYlt
        {
            get
            {
                return this.Location.Y;
            }
        }

        public int UsercontrolWidth
        {
            get
            {
                return this.Width;
            }
        }

        public int UsercontrolHeight
        {
            get
            {
                return this.Height;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// フォーカスを持ったとき。
        /// </summary>
        [
        Category("追加 イベントハンドラ"),
        Description("フォーカスを持ったときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerFocusEnter
        {
            add
            {
                customcontrolPanel1.Enter += value;
            }
            remove
            {
                customcontrolPanel1.Enter -= value;
            }
        }

        /// <summary>
        /// フォーカスが外れたとき。
        /// </summary>
        [
        Category("追加 イベントハンドラ"),
        Description("フォーカスが外れたときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerFocusLeave
        {
            add
            {
                customcontrolPanel1.Leave += value;
            }
            remove
            {
                customcontrolPanel1.Leave -= value;
            }
        }

        /// <summary>
        /// テキストが変更されたとき。
        /// </summary>
        [
        Category("追加 イベントハンドラ"),
        Description("テキストが変更されたときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerTextChanged
        {
            add
            {
                customcontrolPanel1.TextChanged += value;
            }
            remove
            {
                customcontrolPanel1.TextChanged -= value;
            }
        }

        //────────────────────────────────────────

        protected CustomcontrolPanel customcontrolPanel1;

        /// <summary>
        /// パネルを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// 
        /// 更にこの中に、パネル（Panel）が乗っている。
        /// </summary>
        public CustomcontrolPanel CustomcontrolPanel1
        {
            get
            {
                return customcontrolPanel1;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// カスタム コンポーネントを返します。
        /// </summary>
        /// <returns></returns>
        public List<Customcontrol> List_Customcontrol
        {
            get
            {
                List<Customcontrol> ccAll = new List<Customcontrol>();
                ccAll.Add(this.CustomcontrolPanel1);
                return ccAll;
            }
        }

        //────────────────────────────────────────

        public ControlCommon ControlCommon
        {
            get
            {
                return customcontrolPanel1.ControlCommon;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("追加 ユーザーコントロールの中に配置されている主コントロールの名前です。")
        ]
        public Expression_Node_String Expression_Name_Control
        {
            set
            {
                Log_Method pg_Method = new Log_MethodImpl(0);
                Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
                pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Expression_Name_Control set",log_Reports_ThisMethod);
                //
                //

                if (null == value)
                {
                    // Visual Studio のビジュアルエディターで置いた時は、FcNameを設定できずにnullが設定されます。
                    Givechapterandverse_Node cf_Node = new Givechapterandverse_NodeImpl(Info_Controls.Name_Library + ":" + this.GetType().Name + "#<init>:" + this.Name, null);
                    customcontrolPanel1.ControlCommon.Expression_Name_Control = new Expression_Node_StringImpl(null, cf_Node);
                    customcontrolPanel1.Name = this.Name;
                }
                else
                {
                    customcontrolPanel1.ControlCommon.Expression_Name_Control = value;
                    string sName_Usercontrol = value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ThisMethod);
                    customcontrolPanel1.Name = sName_Usercontrol;
                }

                //
                //
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);
            }
            get
            {
                return customcontrolPanel1.ControlCommon.Expression_Name_Control;
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
                this.Enabled = value;
            }
            get
            {
                return this.Enabled;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロールが、表示されているか否か。
        /// </summary>
        [
        Category("追加"),
        Description("このコントロールを表示するなら真です。")
        ]
        public bool UsercontrolVisible
        {
            set
            {
                this.Visible = value;
            }
            get
            {
                return this.Visible;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("ボタンのテキストです。"),
        Browsable(true)
            //EditorBrowsable(EditorBrowsableState.Always)
        ]
        public string UsercontrolText
        {
            set
            {
                customcontrolPanel1.Text = value;
            }
            get
            {
                return customcontrolPanel1.Text;
            }
        }

        //────────────────────────────────────────
        #endregion




    }

}
