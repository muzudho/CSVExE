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
    /// 「wnd」。ウィンドウ。
    /// 
    /// 【特殊】ユーザーコントロールは無視されて、持っているウィンドウに対して操作されます。
    /// </summary>
    public partial class UsercontrolWindow : UserControl, Usercontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolWindow()
        {
            // ヌル・アクセス防止のため
            this.customcontrolWindow1 = new CustomcontrolWindow();

            InitializeComponent();

            //
            // 暫定。
            // TODO: 「レイアウト設定ファイル」で指定したい。
            //
            this.Width = 300;
            this.Height = 400;
        }

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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "CreateFunctionlist",log_Reports);
            //
            //
            Functionlist fw_Result = null;

            //.WriteLine(this.GetType().Name + "#CreateEventActionList: ＜構築＞【開始】　イベントに対応ついたアクションリストを追加します。　（ウィンドウ）");

            switch (sToE_Event.SName)
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
                r.SetTitle("▲エラー452！", pg_Method);

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
                t.Append(sToE_Event.SName);
                t.Append("]には対応できません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(sToE_Event.Givechapterandverse_Event));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return fw_Result;
        }

        //────────────────────────────────────────

        private void UsercontrolWindow_Load(object sender, EventArgs e)
        {
            this.customcontrolWindow1.Width = this.Width;
            this.customcontrolWindow1.Height = this.Height;


            this.Controls.Add(this.customcontrolWindow1);
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
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "SetupStyle",log_Reports);
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

                // 【特殊】ウィンドウは、X,Y設定を無視する。
                //this.ccWindow.Location = new System.Drawing.Point(sl_record.AbsXLt, sl_record.AbsYLt);


                int nWidth;
                fo_Record.TryGetInt(out nWidth, NamesFld.S_WIDTH, false, 1, log_Reports);

                int nHeight;
                fo_Record.TryGetInt(out nHeight, NamesFld.S_HEIGHT, false, 1, log_Reports);

                // 【特殊】ユーザーコントロールではなく、持っているウィンドウに対して変更。
                this.customcontrolWindow1.Size = new System.Drawing.Size(nWidth, nHeight);
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
        /// ウィンドウを閉じます。
        /// </summary>
        public void Close(
            Log_Reports log_Reports
            )
        {
            this.customcontrolWindow1.Close();
        }

        //────────────────────────────────────────

        public void Clear()
        {
            this.customcontrolWindow1.Clear();
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "Destruct(30)",log_Reports);
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
        /// ウィンドウに、ステータスバーを追加します。
        /// </summary>
        public void SetupStatusStrip()
        {
            this.CustomcontrolWindow1.SetupStatusStrip();
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
            if (log_Reports.BSuccessful)
            {

                // レイアウトを一時停止。
                this.customcontrolWindow1.SuspendLayout();

                //
                // カスタム コントロールに、
                // ユーザー コントロールを追加します。
                //
                this.customcontrolWindow1.Controls.Add((Control)uct);

                // レイアウトを再開。レイアウト実行の強制はしない。
                this.customcontrolWindow1.ResumeLayout(false);
            }
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "AddValidator",log_Reports);
            //
            //

            customcontrolWindow1.AddValidator(
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "RefreshData",log_Reports);
            //
            //

            customcontrolWindow1.RefreshData(
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
        /// コントロールの内容値で、データソースの値を更新します。
        /// </summary>
        public void UsercontrolToMemory(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "UpdateData",log_Reports);
            //
            //

            customcontrolWindow1.UsercontrolToMemory(
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



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 妥当性を判定します。
        /// </summary>
        public void JudgeValidity(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "JudgeValidity",log_Reports);
            //
            //

            customcontrolWindow1.JudgeValidity(
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

                // 【特殊】ユーザーコントロールではなく、持っているウィンドウに対して変更。
                this.CustomcontrolWindow1.BackColor = colorResult.Color;
                //this.BackColor = colorResult.Color;
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
                return this.CustomcontrolWindow1.Font.Size;
            }
        }

        [
        Category("追加"),
        Description("タブ インデックスです。")
        ]
        public int UsercontrolTabindex
        {
            set
            {
                this.CustomcontrolWindow1.TabIndex = value;
            }
            get
            {
                return this.CustomcontrolWindow1.TabIndex;
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

        private CustomcontrolWindow customcontrolWindow1;

        /// <summary>
        /// フォームを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        public CustomcontrolWindow CustomcontrolWindow1
        {
            get
            {
                return customcontrolWindow1;
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
                ccAll.Add(this.CustomcontrolWindow1);
                return ccAll;
            }
        }

        //────────────────────────────────────────

        public ControlCommon ControlCommon
        {
            get
            {
                return customcontrolWindow1.ControlCommon;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("ウィンドウのテキストです。"),
        Browsable(true)
            //EditorBrowsable(EditorBrowsableState.Always)
        ]
        public string UsercontrolText
        {
            set
            {
                customcontrolWindow1.Text = value;
            }
            get
            {
                return customcontrolWindow1.Text;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("テキストが変更されたときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerTextChanged
        {
            add
            {
                customcontrolWindow1.TextChanged += value;
            }
            remove
            {
                customcontrolWindow1.TextChanged -= value;
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
                customcontrolWindow1.Enter += value;
            }
            remove
            {
                customcontrolWindow1.Enter -= value;
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
                customcontrolWindow1.Leave += value;
            }
            remove
            {
                customcontrolWindow1.Leave -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("追加 ユーザーコントロールの中に配置されている主コントロールのコントロール名です。")
        ]
        public Expression_Node_String Expression_Name_Control
        {
            set
            {
                Log_Method pg_Method = new Log_MethodImpl(0);
                Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
                pg_Method.BeginMethod(Info_Controls.SName_Library, this, "Expression_Name_Control set",log_Reports_ThisMethod);
                //
                //

                if (null == value)
                {
                    // Visual Studio のビジュアルエディターで置いた時は、FcNameを設定できずにnullが設定されます。
                    Givechapterandverse_Node cf_Node = new Givechapterandverse_NodeImpl(Info_Controls.SName_Library + ":" + this.GetType().Name + "#<init>:" + this.Name, null);
                    customcontrolWindow1.ControlCommon.Expression_Name_Control = new Expression_Node_StringImpl(null, cf_Node);
                    customcontrolWindow1.Name = this.Name;
                }
                else
                {
                    customcontrolWindow1.ControlCommon.Expression_Name_Control = value;
                    string sName_Usercontrol = value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ThisMethod);
                    customcontrolWindow1.Name = sName_Usercontrol;
                }

                //
                //
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);
            }
            get
            {
                return customcontrolWindow1.ControlCommon.Expression_Name_Control;
            }
        }

        //────────────────────────────────────────

        [
        Category("動作"),
        Description("ドラッグ＆ドロップを許可するなら真にしてください。")
        ]
        public override bool AllowDrop
        {
            set
            {
                customcontrolWindow1.AllowDrop = value;
            }
            get
            {
                return customcontrolWindow1.AllowDrop;
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
                customcontrolWindow1.Enabled = value;
            }
            get
            {
                return customcontrolWindow1.Enabled;
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
                customcontrolWindow1.Visible = value;
            }
            get
            {
                return customcontrolWindow1.Visible;
            }
        }

        //────────────────────────────────────────

        [
        Category("表示"),
        Description("テキストボックスのテキストです。"),
        Browsable(true)
            //EditorBrowsable(EditorBrowsableState.Always)
        ]
        public override string Text
        {
            set
            {
                customcontrolWindow1.Text = value;
            }
            get
            {
                return customcontrolWindow1.Text;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("このコントロールにドラッグされたアイテムがドロップされたときのイベントハンドラです。")
        ]
        public event DragEventHandler UsercontroleventhandlerDragDrop
        {
            add
            {
                customcontrolWindow1.DragDrop += value;
            }
            remove
            {
                customcontrolWindow1.DragDrop -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("マウスカーソルがコントロール内に入ったときのイベントハンドラです。")
        ]
        public event DragEventHandler UsercontroleventhandlerDragEnter
        {
            add
            {
                customcontrolWindow1.DragEnter += value;
            }
            remove
            {
                customcontrolWindow1.DragEnter -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("マウスカーソルがコントロール外に出たときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerDragLeave
        {
            add
            {
                customcontrolWindow1.DragLeave += value;
            }
            remove
            {
                customcontrolWindow1.DragLeave -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("マウスカーソルがコントロール内で動いたときのイベントハンドラです。")
        ]
        public event DragEventHandler UsercontroleventhandlerDragOver
        {
            add
            {
                customcontrolWindow1.DragOver += value;
            }
            remove
            {
                customcontrolWindow1.DragOver -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("ドラッグ アンド ドロップのアイコンを変更するときなどに使います。")
        ]
        public event GiveFeedbackEventHandler UsercontroleventhandlerGiveFeedback
        {
            add
            {
                customcontrolWindow1.GiveFeedback += value;
            }
            remove
            {
                customcontrolWindow1.GiveFeedback -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("ドラッグ アンド ドロップのアイコンを変更するときなどに使います。")
        ]
        public event QueryContinueDragEventHandler UsercontroleventhandlerQueryContinueDrag
        {
            add
            {
                customcontrolWindow1.QueryContinueDrag += value;
            }
            remove
            {
                customcontrolWindow1.QueryContinueDrag -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("マウスボタンが押下されたときのイベントハンドラです。")
        ]
        public event MouseEventHandler UsercontroleventhandlerMouseDown
        {
            add
            {
                customcontrolWindow1.MouseDown += value;
            }
            remove
            {
                customcontrolWindow1.MouseDown -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("このコントロールにマウスカーソルが入ってきたときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerMouseEnter
        {
            add
            {
                customcontrolWindow1.MouseEnter += value;
            }
            remove
            {
                customcontrolWindow1.MouseEnter -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("このコントロールの中でマウスカーソルが移動したときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerMouseHover
        {
            add
            {
                customcontrolWindow1.MouseHover += value;
            }
            remove
            {
                customcontrolWindow1.MouseHover -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("このコントロールの中からマウスカーソルが出ていったときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerMouseLeave
        {
            add
            {
                customcontrolWindow1.MouseLeave += value;
            }
            remove
            {
                customcontrolWindow1.MouseLeave -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("このコントロールの中でマウスカーソルが移動したときのイベントハンドラです。")
        ]
        public event MouseEventHandler UsercontroleventhandlerMouseMove
        {
            add
            {
                customcontrolWindow1.MouseMove += value;
            }
            remove
            {
                customcontrolWindow1.MouseMove -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("このコントロールの中で押されているマウスボタンが放されたときのイベントハンドラです。")
        ]
        public event MouseEventHandler UsercontroleventhandlerMouseUp
        {
            add
            {
                customcontrolWindow1.MouseUp += value;
            }
            remove
            {
                customcontrolWindow1.MouseUp -= value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
