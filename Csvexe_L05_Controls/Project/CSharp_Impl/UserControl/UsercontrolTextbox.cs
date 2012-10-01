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
    /// 「txt」「txa」。テキストボックス、またはテキストエリア。
    /// </summary>
    public partial class UsercontrolTextbox : UserControl, Usercontrol
    {



        #region 生成と初期化
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolTextbox()
        {
            // ヌル・アクセス防止のため
            this.customcontrolTextbox1 = new CustomcontrolTextbox();

            InitializeComponent();
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
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "CreateFunctionlist",log_Reports);
            //
            //
            Functionlist result_Felist = null;

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

                case NamesSe.S_VALUE_CHANGED:
                    {
                        //
                        // テキストボックスの内容変更時。
                        //

                        if (null == this.functionlist_Event_ValueChanged)
                        {
                            result_Felist = new Functionlist_FormImpl(
                                //EnumEventhandler.O_Ea,
                                sToE_Event,
                                owner_MemoryApplication
                                );
                            this.functionlist_Event_ValueChanged = result_Felist;
                            ((Functionlist_FormImpl)this.functionlist_Event_ValueChanged).InitializeBeforeUse();


                            this.customcontrolTextbox1.TextChanged += new System.EventHandler(this.functionlist_Event_ValueChanged.Execute_OnOEa);

                        }
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
                r.SetTitle("▲エラー373！", pg_Method);

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
            return result_Felist;
        }

        //────────────────────────────────────────

        private void UsercontrolTextbox_Load(object sender, EventArgs e)
        {
            this.customcontrolTextbox1.Width = this.Width;
            this.customcontrolTextbox1.Height = this.Height;


            this.Controls.Add(this.customcontrolTextbox1);
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

                // 【特殊】
                bool bReadonly;
                fo_Record.TryGetBool(out bReadonly, NamesFld.S_READ_ONLY, log_Reports);
                this.UsercontrolReadonly = bReadonly;

                // 【特殊】
                bool bWordwrap;
                fo_Record.TryGetBool(out bWordwrap, NamesFld.S_WORD_WRAP, log_Reports);
                this.UsercontrolWordwrap = bWordwrap;

                // 【特殊】
                string sNewline;
                fo_Record.TryGetString(out sNewline, NamesFld.S_NEW_LINE, false, "", log_Reports);
                this.UsercontrolNewline = sNewline;

                // 【特殊】
                string sScrollbars;
                fo_Record.TryGetString(out sScrollbars, NamesFld.S_SCROLL_BARS, false, "", log_Reports);
                switch (sScrollbars.ToUpper())
                {
                    case ValuesAttr.S_BOTH:
                        this.UsercontrolScrollbars = ScrollBars.Both;
                        break;
                    case ValuesAttr.S_HORIZONTAL:
                        this.UsercontrolScrollbars = ScrollBars.Horizontal;
                        break;
                    case ValuesAttr.S_VERTICAL:
                        this.UsercontrolScrollbars = ScrollBars.Vertical;
                        break;
                    default: //case "NONE":
                        this.UsercontrolScrollbars = ScrollBars.None;
                        break;
                }

                // フォントの設定
                {
                    //
                    // フォント・サイズの設定
                    //
                    float nFontSizePt = Utility_Usercontrol.ParseFontSize(fo_Record, log_Reports);

                    //
                    //
                    //
                    this.Font = new System.Drawing.Font("MS UI Gothic", nFontSizePt, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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

            // 背景色の設定
            string sBackColor;
            fo_Record.TryGetString(out sBackColor, NamesFld.S_BACK_COLOR, false, "", log_Reports);
            this.UsercontrolBackcolor = sBackColor;

            // コントロールは不可視にする。
            this.CustomcontrolTextbox1.Visible = false;

            this.ControlCommon.BAutomaticinputting = false;
            // 自動入力ここまで


            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void Clear()
        {
            this.customcontrolTextbox1.Clear();
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
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "GetString",log_Reports);
            //
            //

            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー374！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("テキストボックスに、子コントロールを追加しようとしないでください。");
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

            customcontrolTextbox1.AddValidator(
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
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "RefreshData",log_Reports);
            //
            //

            customcontrolTextbox1.RefreshData(log_Reports);
            if (!customcontrolTextbox1.Visible)
            {
                // テキストボックスが表示されていない時。
                // 描画に任せる。コントロールを絵で描いていることがある。
                this.Refresh();
            }

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
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UpdateData",log_Reports);
            //
            //

            customcontrolTextbox1.UsercontrolToMemory(
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

        private void UsercontrolTextbox_SizeChanged(object sender, EventArgs e)
        {
            UsercontrolTextbox uctTxt = (UsercontrolTextbox)sender;

            this.customcontrolTextbox1.Width = uctTxt.Width;
            this.customcontrolTextbox1.Height = uctTxt.Height;

            //
            // 縦幅を固定して、サイズ変更時も大きさを伸ばさないようにしたい場合は
            // この記述を有効にしてください。
            //
            // ucWindow.Height = this.ccWindow.Height;
        }

        //────────────────────────────────────────

        /// <summary>
        /// テキストボックスの絵を描画。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsercontrolTextbox_Paint(object sender, PaintEventArgs e)
        {
            UsercontrolTextbox uctTxt = (UsercontrolTextbox)sender;
            if (!uctTxt.customcontrolTextbox1.Visible)
            {
                // 不可視のときに描画。

                // 自分の内側に線を引ければよい。
                Rectangle rect = new Rectangle(
                    0,
                    0,
                    uctTxt.Width - 1,
                    uctTxt.Height - 1
                    );
                if (uctTxt.customcontrolTextbox1.ReadOnly)
                {
                    // 編集不可能。
                    e.Graphics.FillRectangle(Brushes.LightGray, rect);
                }
                else
                {
                    // 編集可能。
                    e.Graphics.FillRectangle(Brushes.White, rect);
                }

                // 枠線
                e.Graphics.DrawRectangle(
                    Pens.Black, rect
                    );

                // テキスト表示領域は、四角の線から1ドット離すように小さくします。
                rect.Inflate(-2, -2);
                rect.Offset(-1, +1);
                e.Graphics.DrawString(this.customcontrolTextbox1.Text, this.customcontrolTextbox1.Font, Brushes.Black, rect);
            }
        }

        //────────────────────────────────────────

        private void UsercontrolTextbox_MouseEnter(object sender, EventArgs e)
        {
            // マウスが領域に入ってきたら、
            // テキストボックスを可視化。
            UsercontrolTextbox uctTxt = (UsercontrolTextbox)sender;
            if (!uctTxt.customcontrolTextbox1.ReadOnly)
            {
                // 読取専門でなければ可視化。
                uctTxt.customcontrolTextbox1.Visible = true;
            }

            //// テキストボックス左上の画面位置
            //Point p0 = new Point(0, 0);
            //Point p1 = uctTxt.PointToScreen(p0);//プラス値が返ってくる。
            //Point p2 = this.ControlCommon.MoControlMediator.Form.PointToClient(p0);//マイナス値が返ってくる。
            //// p1+p2で、クライアント領域上での位置になる。
            ////ystem.Console.WriteLine("p1=[" + p1.X + "," + p1.Y + "]　p2=[" + p2.X + "," + p2.Y + "]");
            //mrTextbox.Bounds = new Rectangle(
            //    p1.X+p2.X,
            //    p1.Y+p2.Y,
            //    uctTxt.CcTextbox.Bounds.Width,
            //    uctTxt.CcTextbox.Bounds.Height
            //    );
        }

        //────────────────────────────────────────

        private void UsercontrolTextbox_Leave(object sender, EventArgs e)
        {
            // テキストボックスがフォーカスを失ったら、
            // テキストボックスを不可視化。
            UsercontrolTextbox ucTxt = (UsercontrolTextbox)sender;
            ucTxt.customcontrolTextbox1.Visible = false;
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

            customcontrolTextbox1.JudgeValidity(
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

        [
        Category("動作"),
        Description("エディット コントロールの中の文字列を変更できるかどうかを設定します。")
        ]
        public bool UsercontrolReadonly
        {
            set
            {
                this.CustomcontrolTextbox1.ReadOnly = value;
            }
            get
            {
                return this.CustomcontrolTextbox1.ReadOnly;
            }
        }

        [
        Category("動作"),
        Description("複数行エディット コントロールで、行が自動的に折り返されるかどうかを示します。")
        ]
        public bool UsercontrolWordwrap
        {
            set
            {
                this.CustomcontrolTextbox1.WordWrap = value;
            }
            get
            {
                return this.CustomcontrolTextbox1.WordWrap;
            }
        }

        [
        Category("動作"),
        Description("複数行エディット コントロールで、改行を表す文字列を示します。")
        ]
        public string UsercontrolNewline
        {
            set
            {
                this.CustomcontrolTextbox1.SNewline = value;
            }
            get
            {
                return this.CustomcontrolTextbox1.SNewline;
            }
        }

        //────────────────────────────────────────

        public float UsercontrolFontsizept
        {
            get
            {
                return this.CustomcontrolTextbox1.Font.Size;
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
                this.CustomcontrolTextbox1.TabIndex = value;
            }
            get
            {
                return this.CustomcontrolTextbox1.TabIndex;
            }
        }

        [
        Category("表示"),
        Description("スクロールバー。")
        ]
        public ScrollBars UsercontrolScrollbars
        {
            set
            {
                this.CustomcontrolTextbox1.ScrollBars = value;
            }
            get
            {
                return this.CustomcontrolTextbox1.ScrollBars;
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
        /// イベントに対応づくアクションの実行順リスト。無ければヌル。
        /// </summary>
        private Functionlist functionlist_Event_ValueChanged;

        //────────────────────────────────────────

        private CustomcontrolTextbox customcontrolTextbox1;

        /// <summary>
        /// テキストボックスを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        public CustomcontrolTextbox CustomcontrolTextbox1
        {
            get
            {
                return customcontrolTextbox1;
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
                ccAll.Add(this.CustomcontrolTextbox1);
                return ccAll;
            }
        }

        //────────────────────────────────────────

        public ControlCommon ControlCommon
        {
            get
            {
                return customcontrolTextbox1.ControlCommon;
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
                string sOld = customcontrolTextbox1.Text;
                customcontrolTextbox1.Text = value;

                if (sOld != customcontrolTextbox1.Text)
                {
                    // 変更されたとき。

                    if (!customcontrolTextbox1.Visible)
                    {
                        // テキストボックスが表示されていない時。

                        // 描画に任せる。コントロールを絵で描いていることがある。
                        this.Refresh();
                    }
                }

            }
            get
            {
                return customcontrolTextbox1.Text;
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
                customcontrolTextbox1.TextChanged += value;
            }
            remove
            {
                customcontrolTextbox1.TextChanged -= value;
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
                customcontrolTextbox1.Enter += value;
            }
            remove
            {
                customcontrolTextbox1.Enter -= value;
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
                customcontrolTextbox1.Leave += value;
            }
            remove
            {
                customcontrolTextbox1.Leave -= value;
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
                    Givechapterandverse_Node cf_Node = new Givechapterandverse_NodeImpl(Info_Controls.Name_Library + ":" + this.GetType().Name + "#<init>" + this.Name, null);
                    customcontrolTextbox1.ControlCommon.Expression_Name_Control = new Expression_Node_StringImpl(null, cf_Node);
                    customcontrolTextbox1.Name = this.Name;
                }
                else
                {
                    customcontrolTextbox1.ControlCommon.Expression_Name_Control = value;
                    string sName_Usercontrol = value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ThisMethod);
                    customcontrolTextbox1.Name = sName_Usercontrol;
                }

                //
                //
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);
            }
            get
            {
                return customcontrolTextbox1.ControlCommon.Expression_Name_Control;
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
                customcontrolTextbox1.AllowDrop = value;
            }
            get
            {
                return customcontrolTextbox1.AllowDrop;
            }
        }

        //────────────────────────────────────────

        [
        Category("動作"),
        Description("エディット コントロールのテキストが複数行にわたることができるかどうかを設定します。")
        ]
        public bool Multiline
        {
            set
            {
                customcontrolTextbox1.Multiline = value;
            }
            get
            {
                return customcontrolTextbox1.Multiline;
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
                customcontrolTextbox1.Enabled = value;
            }
            get
            {
                return customcontrolTextbox1.Enabled;
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
        Category("表示"),
        Description("テキストボックスのテキストです。"),
        Browsable(true)
            //EditorBrowsable(EditorBrowsableState.Always)
        ]
        public override string Text
        {
            set
            {
                this.UsercontrolText = value;
            }
            get
            {
                return this.UsercontrolText;
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
                customcontrolTextbox1.DragDrop += value;
            }
            remove
            {
                customcontrolTextbox1.DragDrop -= value;
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
                customcontrolTextbox1.DragEnter += value;
            }
            remove
            {
                customcontrolTextbox1.DragEnter -= value;
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
                customcontrolTextbox1.DragLeave += value;
            }
            remove
            {
                customcontrolTextbox1.DragLeave -= value;
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
                customcontrolTextbox1.DragOver += value;
            }
            remove
            {
                customcontrolTextbox1.DragOver -= value;
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
                customcontrolTextbox1.GiveFeedback += value;
            }
            remove
            {
                customcontrolTextbox1.GiveFeedback -= value;
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
                customcontrolTextbox1.QueryContinueDrag += value;
            }
            remove
            {
                customcontrolTextbox1.QueryContinueDrag -= value;
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
                customcontrolTextbox1.MouseDown += value;
            }
            remove
            {
                customcontrolTextbox1.MouseDown -= value;
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
                customcontrolTextbox1.MouseEnter += value;
            }
            remove
            {
                customcontrolTextbox1.MouseEnter -= value;
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
                customcontrolTextbox1.MouseHover += value;
            }
            remove
            {
                customcontrolTextbox1.MouseHover -= value;
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
                customcontrolTextbox1.MouseLeave += value;
            }
            remove
            {
                customcontrolTextbox1.MouseLeave -= value;
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
                customcontrolTextbox1.MouseMove += value;
            }
            remove
            {
                customcontrolTextbox1.MouseMove -= value;
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
                customcontrolTextbox1.MouseUp += value;
            }
            remove
            {
                customcontrolTextbox1.MouseUp -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("文字列選択の開始位置です。")
        ]
        public int SelectionStart
        {
            set
            {
                customcontrolTextbox1.SelectionStart = value;
            }
            get
            {
                return customcontrolTextbox1.SelectionStart;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
