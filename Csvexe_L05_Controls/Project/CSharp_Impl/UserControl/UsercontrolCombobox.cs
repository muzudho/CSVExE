using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;//SystemColors
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
    /// 「ddl」。ドロップダウン_リストボックス。
    /// </summary>
    public partial class UsercontrolCombobox : UserControl, Usercontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolCombobox()
        {
            // ヌル・アクセス防止のため
            this.customcontrolCombobox1 = new CustomcontrolCombobox();

            InitializeComponent();
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアー
        /// 
        /// コンボボックスの内容データを、空っぽにします。
        /// </summary>
        public void Clear()
        {
            this.Items.Clear();
            this.Text = "";
        }

        /// <summary>
        /// イベントハンドラーを全て除去します。
        /// </summary>
        public void ClearAllEventhandlers(Log_Reports log_Reports)
        {
            Remover_AllEventhandlers remover = new Remover_AllEventhandlersImpl(
                this,
                this.ControlCommon.Owner_MemoryApplication,
                log_Reports
                );

            remover.Suppress(
                this.ControlCommon.Owner_MemoryApplication,
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

        /// <summary>
        /// ユーザーコントロールのサイズが変更されたとき。
        /// 
        /// ユーザーコントロール内部のサイズも調整します。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        private void UcCombobox_SizeChanged(object sender, EventArgs e)
        {
            UsercontrolCombobox uctCmb = (UsercontrolCombobox)sender;

            this.customcontrolCombobox1.Width = uctCmb.Width;
            this.customcontrolCombobox1.Height = uctCmb.Height;

            // サイズを変更しても、
            // ラベルの設定によってはサイズが変わらないことがあります。
            //
            // ラベルのサイズをフィードバックします。
            uctCmb.Width = this.customcontrolCombobox1.Width;
            uctCmb.Height = this.customcontrolCombobox1.Height;
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
            Functionlist fw_Result = null;

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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.GetType().Name, log_Reports);//クラス名
                tmpl.SetParameter(2, sToE_Event.Name, log_Reports);//イベント名
                tmpl.SetParameter(3, Log_Report01Impl.ToMessage_Configurationtree(sToE_Event.Configurationtree_Event), log_Reports);//設定位置パンくずリスト

                this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:526;", tmpl, log_Reports);
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

        /// <summary>
        /// 子コントロールを追加します。
        /// </summary>
        /// <param nFcName="uct"></param>
        public void AppendChild(
            Usercontrol uct,
            Log_Reports log_Reports
            )
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
                r.SetTitle("▲エラー372！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("コンボボックスに、子コントロールを追加しようとしないでください。");
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

            // リストボックスの Text プロパティーは無視。

            bool bEnabled;
            fo_Record.TryGetBool(out bEnabled, NamesFld.S_ENABLED, this.ControlCommon.Owner_MemoryApplication, log_Reports);
            this.UsercontrolEnabled = bEnabled;

            bool bVisible;
            fo_Record.TryGetBool(out bVisible, NamesFld.S_VISIBLE, this.ControlCommon.Owner_MemoryApplication, log_Reports);
            this.UsercontrolVisible = bVisible;

            // フォントの設定
            {
                // フォント・サイズの設定
                float nFontSizePt = Utility_Usercontrol.ParseFontSize(fo_Record, this.ControlCommon.Owner_MemoryApplication, log_Reports);
                this.Font = new System.Drawing.Font("MS UI Gothic", nFontSizePt, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            }

            // タブ・インデックス
            int nTabIndex;
            fo_Record.TryGetInt(out nTabIndex, NamesFld.S_TAB_INDEX, false, -1, this.ControlCommon.Owner_MemoryApplication, log_Reports);
            if (nTabIndex < 0)
            {
                // 未指定の場合は変更しません。
            }
            else
            {
                this.UsercontrolTabindex = nTabIndex;
            }

            int nAbsXLt;
            fo_Record.TryGetInt(out nAbsXLt, NamesFld.S_X_LT, false, -1, this.ControlCommon.Owner_MemoryApplication, log_Reports);

            int nAbsYLt;
            fo_Record.TryGetInt(out nAbsYLt, NamesFld.S_Y_LT, false, -1, this.ControlCommon.Owner_MemoryApplication, log_Reports);

            this.Location = new System.Drawing.Point(nAbsXLt, nAbsYLt);


            int nWidth;
            fo_Record.TryGetInt(out nWidth, NamesFld.S_WIDTH, false, 1, this.ControlCommon.Owner_MemoryApplication, log_Reports);

            int nHeight;
            fo_Record.TryGetInt(out nHeight, NamesFld.S_HEIGHT, false, 1, this.ControlCommon.Owner_MemoryApplication, log_Reports);

            this.Size = new System.Drawing.Size(nWidth, nHeight);

            // 背景色の設定
            string sBackColor;
            fo_Record.TryGetString(out sBackColor, NamesFld.S_BACK_COLOR, false, "", this.ControlCommon.Owner_MemoryApplication, log_Reports);
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
        /// 再描画のタイミングで、データの再読込をさせる指定をします。
        /// </summary>
        /// <param name="log_Reports"></param>
        public void Dirty(
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────

        public void RefreshData(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "RefreshData",log_Reports);
            //
            //

            customcontrolCombobox1.RefreshData(
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
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "RefreshData",log_Reports);
            //
            //

            customcontrolCombobox1.UsercontrolToMemory(
                log_Reports
                );

            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void AddValidator(
            Expressionv_Validator_Old ecv_Validator,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "RefreshData",log_Reports);
            //
            //

            customcontrolCombobox1.AddValidator(
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

        /// <summary>
        /// ユーザーコントロールが、フォーム等のコントロール上に配置されたとき。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        private void UsercontrolCombobox_Load(object sender, EventArgs e)
        {
            // コンボボックスの幅を、ユーザーコントロールの幅に合わせます。
            this.customcontrolCombobox1.Width = this.Width;

            // ユーザーコントロールの縦幅を、コンボボックスの縦幅に合わせます。
            this.Height = this.customcontrolCombobox1.Height;


            this.Controls.Add(this.customcontrolCombobox1);
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

            customcontrolCombobox1.JudgeValidity(
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
                return this.CustomcontrolCombobox1.Font.Size;
            }
        }

        public int UsercontrolTabindex
        {
            set
            {
                this.CustomcontrolCombobox1.TabIndex = value;
            }
            get
            {
                return this.CustomcontrolCombobox1.TabIndex;
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
                customcontrolCombobox1.Enter += value;
            }
            remove
            {
                customcontrolCombobox1.Enter -= value;
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
                customcontrolCombobox1.Leave += value;
            }
            remove
            {
                customcontrolCombobox1.Leave -= value;
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
                customcontrolCombobox1.TextChanged += value;
            }
            remove
            {
                customcontrolCombobox1.TextChanged -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragDrop
        {
            add
            {
                customcontrolCombobox1.DragDrop += value;
            }
            remove
            {
                customcontrolCombobox1.DragDrop -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragEnter
        {
            add
            {
                customcontrolCombobox1.DragEnter += value;
            }
            remove
            {
                customcontrolCombobox1.DragEnter -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerDragLeave
        {
            add
            {
                customcontrolCombobox1.DragLeave += value;
            }
            remove
            {
                customcontrolCombobox1.DragLeave -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragOver
        {
            add
            {
                customcontrolCombobox1.DragOver += value;
            }
            remove
            {
                customcontrolCombobox1.DragOver -= value;
            }
        }

        //────────────────────────────────────────

        public event GiveFeedbackEventHandler UsercontroleventhandlerGiveFeedback
        {
            add
            {
                customcontrolCombobox1.GiveFeedback += value;
            }
            remove
            {
                customcontrolCombobox1.GiveFeedback -= value;
            }
        }

        //────────────────────────────────────────

        public event QueryContinueDragEventHandler UsercontroleventhandlerQueryContinueDrag
        {
            add
            {
                customcontrolCombobox1.QueryContinueDrag += value;
            }
            remove
            {
                customcontrolCombobox1.QueryContinueDrag -= value;
            }
        }

        //────────────────────────────────────────

        public event MouseEventHandler UsercontroleventhandlerMouseDown
        {
            add
            {
                customcontrolCombobox1.MouseDown += value;
            }
            remove
            {
                customcontrolCombobox1.MouseDown -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerMouseEnter
        {
            add
            {
                customcontrolCombobox1.MouseEnter += value;
            }
            remove
            {
                customcontrolCombobox1.MouseEnter -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerMouseHover
        {
            add
            {
                customcontrolCombobox1.MouseHover += value;
            }
            remove
            {
                customcontrolCombobox1.MouseHover -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerMouseLeave
        {
            add
            {
                customcontrolCombobox1.MouseLeave += value;
            }
            remove
            {
                customcontrolCombobox1.MouseLeave -= value;
            }
        }

        //────────────────────────────────────────

        public event MouseEventHandler UsercontroleventhandlerMouseMove
        {
            add
            {
                customcontrolCombobox1.MouseMove += value;
            }
            remove
            {
                customcontrolCombobox1.MouseMove -= value;
            }
        }

        //────────────────────────────────────────

        public event MouseEventHandler UsercontroleventhandlerMouseUp
        {
            add
            {
                customcontrolCombobox1.MouseUp += value;
            }
            remove
            {
                customcontrolCombobox1.MouseUp -= value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// コンボボックスを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        private CustomcontrolCombobox customcontrolCombobox1;

        /// <summary>
        /// コンボボックスを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        public CustomcontrolCombobox CustomcontrolCombobox1
        {
            get
            {
                return customcontrolCombobox1;
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
                ccAll.Add(this.CustomcontrolCombobox1);
                return ccAll;
            }
        }

        //────────────────────────────────────────

        public ControlCommon ControlCommon
        {
            get
            {
                return customcontrolCombobox1.ControlCommon;
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
                customcontrolCombobox1.Text = value;
            }
            get
            {
                return customcontrolCombobox1.Text;
            }
        }

        //────────────────────────────────────────

        public int PreselectedItemIndex
        {
            set
            {
                customcontrolCombobox1.NIndex_PreselectedItem = value;
            }
            get
            {
                return customcontrolCombobox1.NIndex_PreselectedItem;
            }
        }

        //────────────────────────────────────────

        public object DataSource
        {
            set
            {
                customcontrolCombobox1.DataSource = value;
            }
            get
            {
                return customcontrolCombobox1.DataSource;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 要素のコレクション。読み取り専用。
        /// </summary>
        public ComboBox.ObjectCollection Items
        {
            get
            {
                return customcontrolCombobox1.Items;
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
                    customcontrolCombobox1.ControlCommon.Expression_Name_Control = new Expression_Node_StringImpl(null, cf_Node);
                    customcontrolCombobox1.Name = this.Name;
                }
                else
                {
                    customcontrolCombobox1.ControlCommon.Expression_Name_Control = value;
                    string sName_Usercontrol = value.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);
                    customcontrolCombobox1.Name = sName_Usercontrol;
                }

                //
                //
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);
            }
            get
            {
                return customcontrolCombobox1.ControlCommon.Expression_Name_Control;
            }
        }

        //────────────────────────────────────────

        public override bool AllowDrop
        {
            set
            {
                customcontrolCombobox1.AllowDrop = value;
            }
            get
            {
                return customcontrolCombobox1.AllowDrop;
            }
        }

        //────────────────────────────────────────

        // イベントハンドラ
        public event DrawItemEventHandler DrawItem
        {
            add
            {
                customcontrolCombobox1.DrawItem += value;
            }
            remove
            {
                customcontrolCombobox1.DrawItem -= value;
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
                customcontrolCombobox1.Enabled = value;
            }
            get
            {
                return customcontrolCombobox1.Enabled;
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

        // イベントハンドラ
        public event EventHandler SelectedIndexChanged
        {
            add
            {
                customcontrolCombobox1.SelectedIndexChanged += value;
            }
            remove
            {
                customcontrolCombobox1.SelectedIndexChanged -= value;
            }
        }

        //────────────────────────────────────────

        public override string Text
        {
            set
            {
                customcontrolCombobox1.Text = value;
            }
            get
            {
                return customcontrolCombobox1.Text;
            }
        }

        //────────────────────────────────────────

        public int SelectedIndex
        {
            set
            {
                customcontrolCombobox1.SelectedIndex = value;
            }
            get
            {
                return customcontrolCombobox1.SelectedIndex;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 選択されている要素。
        /// </summary>
        public object SelectedItem
        {
            set
            {
                customcontrolCombobox1.SelectedItem = value;
            }
            get
            {
                return customcontrolCombobox1.SelectedItem;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
