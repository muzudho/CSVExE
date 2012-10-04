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
    /// 「btn」。ボタン。
    /// 
    /// </summary>
    public partial class UsercontrolButton : UserControl, Usercontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolButton()
        {
            // ヌル・アクセス防止のため
            this.customcontrolButton1 = new CustomcontrolButton();
            this.memoryBtn1 = new MemoryButtonImpl();

            InitializeComponent();



            // この背景の赤色は、ボタンに隠れて見えないはずです。
            this.BackColor = Color.Red;
        }

        //────────────────────────────────────────

        private void UctTextbox_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.customcontrolButton1);

            this.SizeFit();
        }

        //────────────────────────────────────────

        private void SizeFit()
        {
            // 「ボタン」
            //枠線の太さは1px。
            //　　　　　　　　2px
            //　　┌────┐
            //　　│　　　　│　　2px
            //　　│　　　　├─┐
            //　　│　　　　│影│
            //　　│　　　　│１│
            //　　└─┬──┤　│
            //　2px　 │影２│　│
            //　　　　└──┴─┘
            //　　　2px

            // 自分の内側に線を引ければよい。
            // 右と下に2pxの影を付ける。
            int nShadowPx = 2;

            this.customcontrolButton1.Width = this.Width;
            this.customcontrolButton1.Height = this.Height;


            this.memoryBtn1.Bounds = new Rectangle(
                0,
                0,
                this.Width - 1 - nShadowPx,
                this.Height - 1 - nShadowPx
                );

            // 影1
            this.memoryBtn1.BoundsShadow1OrNull = new Rectangle(
                    this.Width - nShadowPx,
                    3,
                    2,
                    this.Height - 1 - nShadowPx
                    );

            // 影2
            this.memoryBtn1.BoundsShadow2OrNull = new Rectangle(
                    3,
                    this.Height - nShadowPx,
                    this.Width - 1 - 2 * nShadowPx,
                    2
                    );

            //
            // 縦幅を固定して、サイズ変更時も大きさを伸ばさないようにしたい場合は
            // この記述を有効にしてください。
            //
            //ucButton.Height = this.ccButton.Height;

        }

        //────────────────────────────────────────

        public void Clear()
        {
            this.customcontrolButton1.Clear();
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Destruct(30)", log_Reports);
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
            ConfigurationtreeToExpression_Event sToE_Event,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "CreateFunctionlist",log_Reports);
            //
            //
            Functionlist fc_Result = null;

            //.WriteLine(this.GetType().Name + "#CreateEventActionList: ＜構築＞【開始】　イベントに対応ついたアクションリストを追加します。　（ボタン）");

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

                case NamesSe.S_BUTTON_PRESSED:
                    {
                        //  （NActionPerformEnum.O_EA）

                        if (null == this.functionlist_Event_Click)
                        {
                            fc_Result = new Functionlist_FormImpl(
                                //EnumEventhandler.O_Ea,
                                sToE_Event, owner_MemoryApplication);
                            this.functionlist_Event_Click = fc_Result;
                            ((Functionlist_FormImpl)this.functionlist_Event_Click).InitializeBeforeUse();

                            this.UsercontroleventhandlerClick += new System.EventHandler(this.functionlist_Event_Click.Execute4_OnOEa);
                            //ccButton.Click += new System.EventHandler(this.e_ActionList_Click.Perform_OEa);

                            // ★DEBUG
                            //essageBox.Show(Info_Forms.LibraryName + ":" + this.GetType().Name + "#Perform_OEa: FC[" + this.ControlCommon.NFcName.GetString(EnumHitcount.Unconstraint, log_Reports) + "]で、EV[" + rEvent.Name + "]のアクションが登録されました。");

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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.GetType().Name, log_Reports);//クラス名
                tmpl.SetParameter(2, sToE_Event.Name, log_Reports);//イベント名
                tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Configurationtree(sToE_Event.Configurationtree_Event), log_Reports);//位置パンくずリスト

                owner_MemoryApplication.CreateErrorReport("Er:532;", tmpl, log_Reports);
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
                fo_Record.TryGetString(out sText, NamesFld.S_TEXT, false, "", this.ControlCommon.Owner_MemoryApplication, log_Reports);
                this.UsercontrolText = sText;

                bool bEnabled;
                fo_Record.TryGetBool(out bEnabled, NamesFld.S_ENABLED, this.ControlCommon.Owner_MemoryApplication, log_Reports);
                this.UsercontrolEnabled = bEnabled;

                bool bVisible;
                fo_Record.TryGetBool(out bVisible, NamesFld.S_VISIBLE, this.ControlCommon.Owner_MemoryApplication, log_Reports);
                this.UsercontrolVisible = bVisible;

                // フォントの設定
                {
                    // フォント・サイズの設定
                    float fontSizePt = Utility_Usercontrol.ParseFontSize(fo_Record, this.ControlCommon.Owner_MemoryApplication, log_Reports);
                    this.Font = new System.Drawing.Font("MS UI Gothic", fontSizePt, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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

            // 背景色の設定
            string sBackColor;
            fo_Record.TryGetString(out sBackColor, NamesFld.S_BACK_COLOR, false, "", this.ControlCommon.Owner_MemoryApplication, log_Reports);
            this.UsercontrolBackcolor = sBackColor;

            // コントロールは不可視にする。
            this.customcontrolButton1.Visible = false;

            this.ControlCommon.BAutomaticinputting = false;
            // 自動入力ここまで


            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
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

            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "AppendChild",log_Reports);
            //
            //

            //#このルートはエラー
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー454！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("ボタンに、子コントロールを追加しようとしないでください。");
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "AddValidator",log_Reports);
            //
            //

            customcontrolButton1.AddValidator(
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
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "RefreshData",log_Reports);
            //
            //

            customcontrolButton1.RefreshData(log_Reports);
            if (!this.customcontrolButton1.Visible)
            {
                // コントロールが表示されていない時。
                // 描画に任せる。見た目をPaintで描いていることがある。
                this.Refresh();
            }

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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UpdateData",log_Reports);
            //
            //

            customcontrolButton1.UsercontrolToMemory(
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

        private void UsercontrolButton_SizeChanged(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        //────────────────────────────────────────

        private void UsercontrolButton_MouseDown(object sender, MouseEventArgs e)
        {
            bool bRefresh = false;

            // 「ボタン」
            if (this.memoryBtn1.Bounds.Contains(e.Location))
            {
                this.memoryBtn1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryBtn1.BackBrush = new SolidBrush(Color.DarkSeaGreen);

                // フォーカスは合わさない。

                // アクション。
                {
                    // 不可視の場合、一旦、可視化する。
                    bool bVisible = this.customcontrolButton1.Visible;
                    if (!bVisible)
                    {
                        this.customcontrolButton1.Visible = true;
                    }
                    this.customcontrolButton1.PerformClick();
                    if (bVisible != this.customcontrolButton1.Visible)
                    {
                        this.customcontrolButton1.Visible = bVisible;
                    }
                }

                // ボタンを絵で描く。
                bRefresh = true;

                //ystem.Console.WriteLine("ボタンにマウスダウンした。e.Location=（" + e.Location.X + "、" + e.Location.Y + "）　this.moBtn.Bounds＝（" + this.moBtn.Bounds.X + "、" + this.moBtn.Bounds.Y + "、" + this.moBtn.Bounds.Width + "、" + this.moBtn.Bounds.Height + "）");
            }
            //else
            //{
            //    //ystem.Console.WriteLine("ボタンをクリックしていない。e.Location=（" + e.Location.X + "、" + e.Location.Y + "）　this.moBtn.Bounds＝（" + this.moBtn.Bounds.X + "、" + this.moBtn.Bounds.Y + "、" + this.moBtn.Bounds.Width + "、" + this.moBtn.Bounds.Height + "）");
            //}

            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolButton_MouseEnter(object sender, EventArgs e)
        {
            // マウスが領域に入ってきたら、
            // テキストボックスを可視化。
            UsercontrolButton ucBtn = (UsercontrolButton)sender;

            Point p1 = this.PointToClient(System.Windows.Forms.Cursor.Position);
            bool bRefresh = false;



            // ボタンをまだマウスカーソルで指していない時。
            if (this.memoryBtn1.Bounds.Contains(p1) && !this.memoryBtn1.BMousePointed)
            {
                //ystem.Console.WriteLine("UcNumにマウスエンター e.GetType().Name=[" + e.GetType().Name + "] マウス位置=[" + System.Windows.Forms.Cursor.Position.X + "," + System.Windows.Forms.Cursor.Position.Y + "] this.upbtnBounds=[" + this.moUpbtn.Bounds.X + "," + this.moUpbtn.Bounds.Y + "," + this.moUpbtn.Bounds.Width + "," + this.moUpbtn.Bounds.Height + "] p1=[" + p1.X + "," + p1.Y + "]　●含む");
                this.memoryBtn1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryBtn1.BackBrush = new SolidBrush(Color.YellowGreen);

                // ボタンを絵で描く。
                bRefresh = true;
            }
            //else
            //{
            //    ystem.Console.WriteLine("ボタンを今マウスカーソルで指している時は、描画スキップ。this.moBtn.Bounds.Contains(p1)＝（" + this.moBtn.Bounds.Contains(p1) + "）　!this.moBtn.MousePointed＝（" + !this.moBtn.MousePointed + "）");
            //}
            //ボタンを今マウスカーソルで指している時は、描画スキップ。


            if (bRefresh)
            {
                this.Refresh();
            }

        }

        //────────────────────────────────────────

        private void UsercontrolButton_MouseLeave(object sender, EventArgs e)
        {
            bool bRefresh = false;

            if (this.memoryBtn1.BMousePointed)
            {
                // ボタンを平常表示にする。
                this.memoryBtn1.ForeBrush = new SolidBrush(SystemColors.ControlText);
                this.memoryBtn1.BackBrush = new SolidBrush(SystemColors.Control);
                // ボタンを絵で描く。
                bRefresh = true;

                this.memoryBtn1.BMousePointed = false;
            }

            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolButton_MouseMove(object sender, MouseEventArgs e)
        {
            Point p1 = this.PointToClient(System.Windows.Forms.Cursor.Position);


            bool bRefresh = false;

            //「ボタン」
            {
                bool bNewPointed = this.memoryBtn1.Bounds.Contains(p1);
                if (this.memoryBtn1.BMousePointed != bNewPointed)
                {
                    if (bNewPointed)
                    {
                        // マウスカーソルで指した。

                        //「ボタン」
                        // マウスエンター。
                        this.memoryBtn1.ForeBrush = new SolidBrush(Color.Green);
                        this.memoryBtn1.BackBrush = new SolidBrush(Color.YellowGreen);

                        // ボタンを絵で描く。
                        bRefresh = true;
                    }
                    else
                    {
                        // マウスカーソルを外した。

                        // 「ボタン」を平常表示にする。
                        this.memoryBtn1.ForeBrush = new SolidBrush(SystemColors.ControlText);
                        this.memoryBtn1.BackBrush = new SolidBrush(SystemColors.Control);
                        // ボタンを絵で描く。
                        bRefresh = true;
                    }
                }
                this.memoryBtn1.BMousePointed = bNewPointed;
            }


            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolButton_Paint(object sender, PaintEventArgs e)
        {
            UsercontrolButton ucBtn = (UsercontrolButton)sender;

            //
            //　　┌────┐
            //　　│　　　　│
            //　　│　　　　├─┐
            //　　│　　　　│影│
            //　　│　　　　│１│
            //　　└─┬──┤　│
            //　　　　│影２│　│
            //　　　　└──┴─┘
            //
            // 自分の内側に線を引く。右と下に影を付ける。
            //


            // 背景色、前景色。
            Pen shapePen1;
            Brush shapeBursh1;
            Brush fontBrush1;
            if (!ucBtn.customcontrolButton1.Enabled)
            {
                // 編集不可能。

                e.Graphics.FillRectangle(Brushes.LightGray, this.memoryBtn1.Bounds);

                // 前景色。
                shapePen1 = Pens.Gray;
                shapeBursh1 = Brushes.Gray;
                fontBrush1 = Brushes.Gray;
            }
            else
            {
                // 編集可能。

                // 背景色。
                e.Graphics.FillRectangle(ucBtn.memoryBtn1.BackBrush, this.memoryBtn1.Bounds);

                // 前景色。
                shapePen1 = Pens.Black;
                shapeBursh1 = Brushes.Black;
                fontBrush1 = new SolidBrush(this.customcontrolButton1.ForeColor);
            }

            // 枠線
            e.Graphics.DrawRectangle(shapePen1, this.memoryBtn1.Bounds);

            // 影1
            e.Graphics.FillRectangle(shapeBursh1, this.memoryBtn1.BoundsShadow1OrNull);

            // 影2
            e.Graphics.FillRectangle(shapeBursh1, this.memoryBtn1.BoundsShadow2OrNull);

            // テキスト表示領域は、四角の線から1ドット離すように小さくします。
            e.Graphics.DrawString(
                this.customcontrolButton1.Text,
                this.customcontrolButton1.Font,
                fontBrush1,
                new Rectangle(
                    this.memoryBtn1.Bounds.X + 2 - 1,
                    this.memoryBtn1.Bounds.Y + 2 + 1,
                    this.memoryBtn1.Bounds.Width - 2,
                    this.memoryBtn1.Bounds.Height - 2
                    )
                );
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        public void JudgeValidity(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "JudgeValidity",log_Reports);
            //
            //

            customcontrolButton1.JudgeValidity(
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
                return this.CustomcontrolButton1.Font.Size;
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
                this.CustomcontrolButton1.TabIndex = value;
            }
            get
            {
                return this.CustomcontrolButton1.TabIndex;
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

        [
        Category("追加 イベントハンドラ"),
        Description("ボタンがクリックされたときに発生します。")
        ]
        public event EventHandler UsercontroleventhandlerClick
        {
            add
            {
                //this.ccButton.Count_EventHandler_Click++;
                this.customcontrolButton1.Click += value;
            }
            remove
            {
                //this.ccButton.Count_EventHandler_Click--;
                this.customcontrolButton1.Click -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加 イベントハンドラ"),
        Description("テキストが変更されたときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerTextChanged
        {
            add
            {
                customcontrolButton1.TextChanged += value;
            }
            remove
            {
                customcontrolButton1.TextChanged -= value;
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
                customcontrolButton1.Enter += value;
            }
            remove
            {
                customcontrolButton1.Enter -= value;
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
                customcontrolButton1.Leave += value;
            }
            remove
            {
                customcontrolButton1.Leave -= value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ボタンの位置・サイズ。
        /// </summary>
        private MemoryButtonImpl memoryBtn1;

        //────────────────────────────────────────

        /// <summary>
        /// イベントに対応づくアクションの実行順リスト。無ければヌル。
        /// </summary>
        private Functionlist functionlist_Event_Click;

        //────────────────────────────────────────

        /// <summary>
        /// テキストボックスを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        private CustomcontrolButton customcontrolButton1;

        /// <summary>
        /// テキストボックスを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        public CustomcontrolButton CustomcontrolButton1
        {
            get
            {
                return customcontrolButton1;
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
                ccAll.Add(this.CustomcontrolButton1);
                return ccAll;
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
                customcontrolButton1.Text = value;
            }
            get
            {
                return customcontrolButton1.Text;
            }
        }

        //────────────────────────────────────────

        public ControlCommon ControlCommon
        {
            get
            {
                return customcontrolButton1.ControlCommon;
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
                    Configurationtree_Node s_Node = new Configurationtree_NodeImpl(Info_Controls.Name_Library + ":" + this.GetType().Name + "#<init>:" + this.Name, null);
                    customcontrolButton1.ControlCommon.Expression_Name_Control = new Expression_Node_StringImpl(null, s_Node);
                    customcontrolButton1.Name = this.Name;
                }
                else
                {
                    customcontrolButton1.ControlCommon.Expression_Name_Control = value;
                    string sName_Usercontrol = value.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);
                    customcontrolButton1.Name = sName_Usercontrol;
                }

                //
                //
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);
            }
            get
            {
                return customcontrolButton1.ControlCommon.Expression_Name_Control;
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
                customcontrolButton1.AllowDrop = value;
            }
            get
            {
                return customcontrolButton1.AllowDrop;
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
                customcontrolButton1.Enabled = value;
            }
            get
            {
                return customcontrolButton1.Enabled;
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
        Description("このコントロールにドラッグされたアイテムがドロップされたときのイベントハンドラです。")
        ]
        public event DragEventHandler UsercontroleventhandlerDragDrop
        {
            add
            {
                customcontrolButton1.DragDrop += value;
            }
            remove
            {
                customcontrolButton1.DragDrop -= value;
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
                customcontrolButton1.DragEnter += value;
            }
            remove
            {
                customcontrolButton1.DragEnter -= value;
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
                customcontrolButton1.DragLeave += value;
            }
            remove
            {
                customcontrolButton1.DragLeave -= value;
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
                customcontrolButton1.DragOver += value;
            }
            remove
            {
                customcontrolButton1.DragOver -= value;
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
                customcontrolButton1.GiveFeedback += value;
            }
            remove
            {
                customcontrolButton1.GiveFeedback -= value;
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
                customcontrolButton1.QueryContinueDrag += value;
            }
            remove
            {
                customcontrolButton1.QueryContinueDrag -= value;
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
                customcontrolButton1.MouseDown += value;
            }
            remove
            {
                customcontrolButton1.MouseDown -= value;
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
                customcontrolButton1.MouseEnter += value;
            }
            remove
            {
                customcontrolButton1.MouseEnter -= value;
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
                customcontrolButton1.MouseHover += value;
            }
            remove
            {
                customcontrolButton1.MouseHover -= value;
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
                customcontrolButton1.MouseLeave += value;
            }
            remove
            {
                customcontrolButton1.MouseLeave -= value;
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
                customcontrolButton1.MouseMove += value;
            }
            remove
            {
                customcontrolButton1.MouseMove -= value;
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
                customcontrolButton1.MouseUp += value;
            }
            remove
            {
                customcontrolButton1.MouseUp -= value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
