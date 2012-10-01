using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;//SystemColors
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//Log_TextIndentedImpl
using Xenon.Middle;//FormObjectProperties,CustomLabel
using Xenon.Operating;//BuilderColor

namespace Xenon.Controls
{

    /// <summary>
    /// 「lbl」。ラベル。
    /// </summary>
    public partial class UsercontrolLabel : UserControl, Usercontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolLabel()
        {
            // ヌル・アクセス防止のため
            this.customcontrolLabel1 = new CustomcontrolLabel();

            InitializeComponent();
        }

        //────────────────────────────────────────

        private void UsercontrolLabel_Load(object sender, EventArgs e)
        {
            this.customcontrolLabel1.Width = this.Width;
            this.customcontrolLabel1.Height = this.Height;


            this.Controls.Add(this.customcontrolLabel1);
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

                //
                // 「MS UI Gothic」フォントで決め打ち。
                //
                //
                this.Font = new System.Drawing.Font("MS UI Gothic", nFontSizePt, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

            }

            // タブ・インデックス
            int nTabIndex;
            fo_Record.TryGetInt(out nTabIndex, NamesFld.S_TAB_INDEX, false, -1, log_Reports);
            if (nTabIndex < 0)
            {
                // 未指定の場合は変更しません。
            }
            else
            {
                this.UsercontrolTabindex = nTabIndex;
            }


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


            // 背景色の設定
            string sBackColor;
            fo_Record.TryGetString(out sBackColor, NamesFld.S_BACK_COLOR, false, "", log_Reports);
            this.UsercontrolBackcolor = sBackColor;

            // コントロールは不可視にする。
            this.customcontrolLabel1.Visible = false;

            this.ControlCommon.BAutomaticinputting = false;
            // 自動入力ここまで


            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロール用共通メソッド。
        /// </summary>
        public void Clear()
        {
            this.UsercontrolText = "";
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

        private void UsercontrolLabel_SizeChanged(object sender, EventArgs e)
        {
            UsercontrolLabel ucLabel = (UsercontrolLabel)sender;

            this.customcontrolLabel1.Width = ucLabel.Width;
            this.customcontrolLabel1.Height = ucLabel.Height;

            // サイズを変更しても、
            // ラベルの設定によってはサイズが変わらないことがあります。
            //
            // ラベルのサイズをフィードバックします。
            ucLabel.Width = this.customcontrolLabel1.Width;
            ucLabel.Height = this.customcontrolLabel1.Height;
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
            ConfigurationtreeToExpression_Event sToE_Event,
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

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSupportedEvent:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー352！", pg_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("「コントロール設定ファイル」の記述エラーか、プログラムの未実装です。");
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(this.GetType().Name);
                t.Append("]クラスは、");
                t.Append(Environment.NewLine);
                t.Append("指定されたイベントの名前");
                t.Append(Environment.NewLine);
                t.Append("oEvent.Name=[");
                t.Append(sToE_Event.Name);
                t.Append("]には対応できません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configurationtree(sToE_Event.Configurationtree_Event));

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
            Log_Reports log_Reports)
        {
            //
            // エラー。

            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "AppendChild",log_Reports);
            //
            //

            //#このルートはエラー
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー353！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("ラベルに、子コントロールを追加しようとしないでください。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("[");
                t.Append(this.ControlCommon.Expression_Name_Control);
                t.Append("]に、[");
                t.Append(uct.ControlCommon.Expression_Name_Control);
                t.Append("]を　追加しようとしました。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }

            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);
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

        /// <summary>
        /// データソースから値を取得し、コントロールに取り込みます。
        /// </summary>
        public void RefreshData(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "RefreshData",log_Reports);
            //
            //

            customcontrolLabel1.RefreshData(
                log_Reports
                );

            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void UsercontrolToMemory(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UpdateData",log_Reports);
            //
            //

            customcontrolLabel1.UsercontrolToMemory(
                log_Reports
                );

            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);
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
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "AddValidator",log_Reports);
            //
            //

            customcontrolLabel1.AddValidator(
                ecv_Validator,
                log_Reports
                );

            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void UsercontrolLabel_Paint(object sender, PaintEventArgs e)
        {
            UsercontrolLabel ucLbl = (UsercontrolLabel)sender;

            // 自分の内側に線を引ければよい。
            Rectangle rect = new Rectangle(
                0,
                0,
                ucLbl.Width - 1,
                ucLbl.Height - 1
                );

            // 背景色はない。

            // 枠もない。
            if (Log_ReportsImpl.BDebugmode_Form)
            {
                // 画面レイアウト・デバッグ用
                e.Graphics.DrawRectangle(Pens.Red, rect);
            }

            // テキスト表示領域は、四角の線から1ドット離すように小さくします。
            rect.Inflate(-2, -2);
            e.Graphics.DrawString(this.customcontrolLabel1.Text, this.customcontrolLabel1.Font, new SolidBrush(this.customcontrolLabel1.ForeColor), rect);
            //            e.Graphics.DrawString(this.ccLabel.Text, this.ccLabel.Font, Brushes.Black, rect);


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
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "JudgeValidity",log_Reports);
            //
            //

            customcontrolLabel1.JudgeValidity(
                log_Reports
                );

            //
            //
            pg_Method.EndMethod(log_Reports);
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
                return this.CustomcontrolLabel1.Font.Size;
            }
        }

        public int UsercontrolTabindex
        {
            set
            {
                this.CustomcontrolLabel1.TabIndex = value;
            }
            get
            {
                return this.CustomcontrolLabel1.TabIndex;
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
                customcontrolLabel1.Enter += value;
            }
            remove
            {
                customcontrolLabel1.Enter -= value;
            }
        }

        //────────────────────────────────────────

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
                customcontrolLabel1.Leave += value;
            }
            remove
            {
                customcontrolLabel1.Leave -= value;
            }
        }

        //────────────────────────────────────────

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
                customcontrolLabel1.TextChanged += value;
            }
            remove
            {
                customcontrolLabel1.TextChanged -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragDrop
        {
            add
            {
                customcontrolLabel1.DragDrop += value;
            }
            remove
            {
                customcontrolLabel1.DragDrop -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragEnter
        {
            add
            {
                customcontrolLabel1.DragEnter += value;
            }
            remove
            {
                customcontrolLabel1.DragEnter -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerDragLeave
        {
            add
            {
                customcontrolLabel1.DragLeave += value;
            }
            remove
            {
                customcontrolLabel1.DragLeave -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragOver
        {
            add
            {
                customcontrolLabel1.DragOver += value;
            }
            remove
            {
                customcontrolLabel1.DragOver -= value;
            }
        }

        //────────────────────────────────────────

        public event GiveFeedbackEventHandler UsercontroleventhandlerGiveFeedback
        {
            add
            {
                customcontrolLabel1.GiveFeedback += value;
            }
            remove
            {
                customcontrolLabel1.GiveFeedback -= value;
            }
        }

        //────────────────────────────────────────

        public event QueryContinueDragEventHandler UsercontroleventhandlerQueryContinueDrag
        {
            add
            {
                customcontrolLabel1.QueryContinueDrag += value;
            }
            remove
            {
                customcontrolLabel1.QueryContinueDrag -= value;
            }
        }

        //────────────────────────────────────────

        private CustomcontrolLabel customcontrolLabel1;

        /// <summary>
        /// ラベルを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        public CustomcontrolLabel CustomcontrolLabel1
        {
            get
            {
                return customcontrolLabel1;
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
                ccAll.Add(this.CustomcontrolLabel1);
                return ccAll;
            }
        }

        //────────────────────────────────────────

        public ControlCommon ControlCommon
        {
            get
            {
                return customcontrolLabel1.ControlCommon;
            }
        }

        //────────────────────────────────────────

        [Browsable(true), Description("ラベルの表示文字列です。")]
        public string UsercontrolText
        {
            set
            {
                customcontrolLabel1.Text = value;
            }
            get
            {
                return customcontrolLabel1.Text;
            }
        }

        //────────────────────────────────────────

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
                    Configurationtree_Node cf_Node = new Configurationtree_NodeImpl(Info_Controls.Name_Library + ":" + this.GetType().Name + "#<init>" + this.Name, null);
                    customcontrolLabel1.ControlCommon.Expression_Name_Control = new Expression_Node_StringImpl(null, cf_Node);
                    customcontrolLabel1.Name = this.Name;
                }
                else
                {
                    customcontrolLabel1.ControlCommon.Expression_Name_Control = value;
                    string sName_Usercontrol = value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ThisMethod);
                    customcontrolLabel1.Name = sName_Usercontrol;
                }

                //
                //
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);
            }
            get
            {
                return customcontrolLabel1.ControlCommon.Expression_Name_Control;
            }
        }

        //────────────────────────────────────────

        public override bool AllowDrop
        {
            set
            {
                customcontrolLabel1.AllowDrop = value;
            }
            get
            {
                return customcontrolLabel1.AllowDrop;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロールに、人間オペレーターが入力をできるか否か。
        /// </summary>
        public bool UsercontrolEnabled
        {
            set
            {
                customcontrolLabel1.Enabled = value;
            }
            get
            {
                return customcontrolLabel1.Enabled;
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
        #endregion



    }
}
