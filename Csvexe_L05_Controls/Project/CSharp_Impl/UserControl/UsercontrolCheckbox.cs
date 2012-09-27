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
    /// 「chk」。チェックボックス。
    /// 
    /// 【▲！】Text プロパティーは、チェックボックスに指定するのではなく、ラベルを使ってください。
    /// </summary>
    public partial class UsercontrolCheckbox : UserControl, Usercontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolCheckbox()
        {
            // ヌル・アクセス防止のため
            this.customcontrolCheckbox1 = new CustomcontrolCheckbox();
            this.memoryButton1 = new MemoryButtonImpl();

            InitializeComponent();
        }

        //────────────────────────────────────────

        private void UsercontrolTextbox_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.customcontrolCheckbox1);

            this.SizeFit();
        }

        //────────────────────────────────────────

        private void SizeFit()
        {
            //枠線の太さは1px。
            //　　　　2px
            //　　　┌─┬────┐
            //　2px │　│　影２　│
            //　　　│　├────┤
            //　　　│影│　　　　│
            //　　　│１│　　　　│
            //　　　│　│　　　　│
            //　　　│　│　　　　│
            //　　　└─┴────┘
            //

            // 自分の内側に線と影を引く。
            int nLinePx = 1;
            int nShadowPx = 2;

            this.customcontrolCheckbox1.Width = this.Width;
            this.customcontrolCheckbox1.Height = this.Height;


            this.memoryButton1.Bounds = new Rectangle(
                0,
                0,
                this.Width - nLinePx,
                this.Height - nLinePx
                );

            // 影1
            this.memoryButton1.BoundsShadow1OrNull = new Rectangle(
                    nLinePx,
                    nLinePx,
                    nShadowPx,
                    this.Height - 2 * nLinePx
                    );

            // 影2
            this.memoryButton1.BoundsShadow2OrNull = new Rectangle(
                    nLinePx + nShadowPx,
                    nLinePx,
                    this.Width - 2 * nLinePx - nShadowPx,
                    2
                    );
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
            //

            // 自動入力ここから
            this.ControlCommon.BAutomaticinputting = true;

            // リストボックスの Text プロパティーは無視。

            bool bEnabled;
            fo_Record.TryGetBool(out bEnabled, NamesFld.S_ENABLED, log_Reports);
            this.UsercontrolEnabled = bEnabled;

            bool bVisible;
            fo_Record.TryGetBool(out bVisible, NamesFld.S_VISIBLE, log_Reports);
            this.UsercontrolVisible = bVisible;

            // 【特殊】チェックボックスの値の型
            string sChkValueType;
            {
                fo_Record.TryGetString(out sChkValueType, NamesFld.S_CHK_VALUE_TYPE, false, "", log_Reports);
                this.sUsercontrolChkvaluetype = sChkValueType.Trim();
                if (ValuesAttr.S_EMPTY == this.sUsercontrolChkvaluetype)
                {
                    this.EnumCheckboxValuetype = EnumCheckboxValuetype.Bool;
                }
                else if (ValuesAttr.S_ZERO_ONE == this.sUsercontrolChkvaluetype)
                {
                    this.EnumCheckboxValuetype = EnumCheckboxValuetype.Zero_One;
                }
                else if (ValuesAttr.S_BOOL == this.sUsercontrolChkvaluetype)
                {
                    this.EnumCheckboxValuetype = EnumCheckboxValuetype.Bool;
                }
                else
                {
                    //エラー
                    goto gt_Error_NotSupportedValue;
                }
            }


            // フォントの設定
            {
                // フォント・サイズの設定
                float nFontSizePt = Utility_Usercontrol.ParseFontSize(fo_Record, log_Reports);
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
            this.customcontrolCheckbox1.Visible = false;

            this.ControlCommon.BAutomaticinputting = false;
            // 自動入力ここまで

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSupportedValue:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー354！", pg_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("チェックボックス[");
                t.Append(this.ControlCommon.Expression_Name_Control);
                t.Append("]の");
                t.NewLine();

                t.Append("レイアウト設定のCHK_VALUE_TYPEフィールドに、");
                t.NewLine();

                t.Append("未対応の値[");
                t.Append(sChkValueType);
                t.Append("]が入っていました。");
                t.NewLine();

                // ヒント
                t.Append(r.Message_Givechapterandverse(fo_Record.Parent_TableUserformconfig.Givechapterandverse_Mynode));

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
            Functionlist fc_Result = null;

            //.WriteLine(this.GetType().Name + "#CreateEventActionList: ＜構築＞【開始】　イベントに対応ついたアクションリストを追加します。　（チェックボックス）");

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

                case NamesSe.S_ITEM_SELECTED:
                    {
                        //
                        // チェックした時／チェックを外した時
                        //

                        if (null == this.functionlist_Event_CheckedChanged)
                        {
                            Functionlist_FormChkImpl fw = new Functionlist_FormChkImpl(
                                //EnumEventhandler.O_Ea,
                                sToE_Event, owner_MemoryApplication);
                            fw.InitializeBeforeUse();
                            fc_Result = fw;

                            this.functionlist_Event_CheckedChanged = fw;


                            this.customcontrolCheckbox1.CheckedChanged += new System.EventHandler(this.functionlist_Event_CheckedChanged.Execute_OnOEa);
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
                r.SetTitle("▲エラー355！", pg_Method);

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

            //.WriteLine(this.GetType().NFcName + "#CreateEventActionList: ■■■■■■■■■■未実装です。無視されます。rEvent.NFcName=[" + rEvent.NFcName + "]■■■■■■■■■■");
            return fc_Result;
        }

        //────────────────────────────────────────

        public void Clear()
        {
            this.customcontrolCheckbox1.Clear();
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
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "Destruct(10)",log_Reports);
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

            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "AppendChild",log_Reports);
            //
            //

            //#このルートはエラー
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー356！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("チェックボックスに、子コントロールを追加しようとしないでください。");
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

                r.SMessage = t.ToString();
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
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "AddValidator",log_Reports);
            //
            //

            customcontrolCheckbox1.AddValidator(
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

            customcontrolCheckbox1.RefreshData(log_Reports);
            if (!this.customcontrolCheckbox1.Visible)
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
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "UpdateData",log_Reports);
            //
            //

            customcontrolCheckbox1.UsercontrolToMemory(
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

        private void UsercontrolCheckbox_SizeChanged(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        //────────────────────────────────────────

        private void UsercontrolCheckbox_Paint(object sender, PaintEventArgs e)
        {
            UsercontrolCheckbox ucChk = (UsercontrolCheckbox)sender;

            //枠線の太さは1px。
            //　　　　2px
            //　　　┌─┬────┐
            //　2px │　│　影２　│
            //　　　│　├────┤
            //　　　│影│　　　　│
            //　　　│１│　　　　│
            //　　　│　│　　　　│
            //　　　│　│　　　　│
            //　　　└─┴────┘
            //


            // 背景色、前景色。
            Pen shapePen1;
            Brush shapeBursh1;
            Brush fontBrush1;
            if (!ucChk.customcontrolCheckbox1.Enabled)
            {
                // 編集不可能。

                e.Graphics.FillRectangle(Brushes.LightGray, this.memoryButton1.Bounds);

                // 前景色。
                shapePen1 = Pens.Gray;
                shapeBursh1 = Brushes.Black;
                fontBrush1 = Brushes.Gray;
            }
            else
            {
                // 編集可能。

                // 背景色。
                e.Graphics.FillRectangle(ucChk.memoryButton1.BackBrush, this.memoryButton1.Bounds);
                //e.Graphics.FillRectangle(Brushes.White, this.moBtn.Bounds);

                // 前景色。
                shapePen1 = Pens.Black;
                shapeBursh1 = Brushes.Black;
                fontBrush1 = new SolidBrush(this.customcontrolCheckbox1.ForeColor);
            }

            // 枠線
            e.Graphics.DrawRectangle(shapePen1, this.memoryButton1.Bounds);

            // 影1
            e.Graphics.FillRectangle(shapeBursh1, this.memoryButton1.BoundsShadow1OrNull);

            // 影2
            e.Graphics.FillRectangle(shapeBursh1, this.memoryButton1.BoundsShadow2OrNull);

            string sDisplay;
            if (this.customcontrolCheckbox1.Checked)
            {
                sDisplay = "V";
            }
            else
            {
                sDisplay = "";
            }

            // テキスト表示領域は、四角の線から1ドット離すように小さくします。
            e.Graphics.DrawString(
                sDisplay,
                this.customcontrolCheckbox1.Font,
                fontBrush1,
                new Rectangle(
                    this.memoryButton1.Bounds.X + 2 + 1,
                    this.memoryButton1.Bounds.Y + 2 + 3,
                    this.memoryButton1.Bounds.Width - 2,
                    this.memoryButton1.Bounds.Height - 2
                    )
                );

        }

        //────────────────────────────────────────

        private void UsercontrolCheckbox_Click(object sender, EventArgs e)
        {

        }

        //────────────────────────────────────────

        private void UsercontrolCheckbox_MouseDown(object sender, MouseEventArgs e)
        {
            bool bRefresh = false;

            // 「ボタン」
            if (this.memoryButton1.Bounds.Contains(e.Location))
            {
                this.memoryButton1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryButton1.BackBrush = new SolidBrush(Color.DarkSeaGreen);

                // フォーカスは合わさない。

                // アクション。
                {
                    // 不可視の場合、一旦、可視化する。
                    bool bVisible = this.customcontrolCheckbox1.Visible;
                    if (!bVisible)
                    {
                        this.customcontrolCheckbox1.Visible = true;
                    }
                    this.customcontrolCheckbox1.Checked = !this.customcontrolCheckbox1.Checked;
                    if (bVisible != this.customcontrolCheckbox1.Visible)
                    {
                        this.customcontrolCheckbox1.Visible = bVisible;
                    }
                }

                // ボタンを絵で描く。
                bRefresh = true;
            }

            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolCheckbox_MouseEnter(object sender, EventArgs e)
        {
            // マウスが領域に入ってきたら、
            // コントロールを可視化。
            UsercontrolCheckbox ucChk = (UsercontrolCheckbox)sender;

            Point p1 = this.PointToClient(System.Windows.Forms.Cursor.Position);
            bool bRefresh = false;



            // コントロールをまだマウスカーソルで指していない時。
            if (this.memoryButton1.Bounds.Contains(p1) && !this.memoryButton1.BMousePointed)
            {
                this.memoryButton1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryButton1.BackBrush = new SolidBrush(Color.YellowGreen);

                // コントロールを絵で描く。
                bRefresh = true;
            }


            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolCheckbox_MouseLeave(object sender, EventArgs e)
        {
            bool bRefresh = false;

            if (this.memoryButton1.BMousePointed)
            {
                // コントロールを平常表示にする。
                this.memoryButton1.ForeBrush = new SolidBrush(SystemColors.ControlText);
                this.memoryButton1.BackBrush = new SolidBrush(SystemColors.Control);
                // コントロールを絵で描く。
                bRefresh = true;

                this.memoryButton1.BMousePointed = false;
            }

            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolCheckbox_MouseMove(object sender, MouseEventArgs e)
        {
            Point p1 = this.PointToClient(System.Windows.Forms.Cursor.Position);


            bool bRefresh = false;

            {
                bool bNewPointed = this.memoryButton1.Bounds.Contains(p1);
                if (this.memoryButton1.BMousePointed != bNewPointed)
                {
                    if (bNewPointed)
                    {
                        // マウスカーソルで指した。

                        // マウスエンター。
                        this.memoryButton1.ForeBrush = new SolidBrush(Color.Green);
                        this.memoryButton1.BackBrush = new SolidBrush(Color.YellowGreen);

                        // 絵で描く。
                        bRefresh = true;
                    }
                    else
                    {
                        // マウスカーソルを外した。

                        // 平常表示にする。
                        this.memoryButton1.ForeBrush = new SolidBrush(SystemColors.ControlText);
                        this.memoryButton1.BackBrush = new SolidBrush(SystemColors.Control);
                        // 絵で描く。
                        bRefresh = true;
                    }
                }
                this.memoryButton1.BMousePointed = bNewPointed;
            }


            if (bRefresh)
            {
                this.Refresh();
            }

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
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "JudgeValidity",log_Reports);
            //
            //

            customcontrolCheckbox1.JudgeValidity(
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

        private string sUsercontrolChkvaluetype;
        public string UsercontrolChkvaluetype
        {
            get
            {
                return sUsercontrolChkvaluetype;
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

                ColorResult colorResult = BuilderColor.Parse(this.sUsercontrolBackcolor, Color.White/*【特殊】*/, false);
                this.BackColor = colorResult.Color;

                this.memoryButton1.BackBrush = new SolidBrush(colorResult.Color);//【特殊】
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
                return this.CustomcontrolCheckbox1.Font.Size;
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
                this.CustomcontrolCheckbox1.TabIndex = value;
            }
            get
            {
                return this.CustomcontrolCheckbox1.TabIndex;
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
        Description("テキストが変更されたときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerTextChanged
        {
            add
            {
                customcontrolCheckbox1.TextChanged += value;
            }
            remove
            {
                customcontrolCheckbox1.TextChanged -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加 イベントハンドラ"),
        Description("チェック状態が変更されたときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerCheckedChanged
        {
            add
            {
                customcontrolCheckbox1.CheckedChanged += value;
            }
            remove
            {
                customcontrolCheckbox1.CheckedChanged -= value;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加 イベントハンドラ"),
        Description("チェック状態が変更されたときのイベントハンドラです。")
        ]
        public event EventHandler UsercontroleventhandlerCheckStateChanged
        {
            add
            {
                customcontrolCheckbox1.CheckStateChanged += value;
            }
            remove
            {
                customcontrolCheckbox1.CheckStateChanged -= value;
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
                customcontrolCheckbox1.Enter += value;
            }
            remove
            {
                customcontrolCheckbox1.Enter -= value;
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
                customcontrolCheckbox1.Leave += value;
            }
            remove
            {
                customcontrolCheckbox1.Leave -= value;
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
                customcontrolCheckbox1.DragDrop += value;
            }
            remove
            {
                customcontrolCheckbox1.DragDrop -= value;
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
                customcontrolCheckbox1.DragEnter += value;
            }
            remove
            {
                customcontrolCheckbox1.DragEnter -= value;
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
                customcontrolCheckbox1.DragLeave += value;
            }
            remove
            {
                customcontrolCheckbox1.DragLeave -= value;
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
                customcontrolCheckbox1.DragOver += value;
            }
            remove
            {
                customcontrolCheckbox1.DragOver -= value;
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
                customcontrolCheckbox1.GiveFeedback += value;
            }
            remove
            {
                customcontrolCheckbox1.GiveFeedback -= value;
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
                customcontrolCheckbox1.QueryContinueDrag += value;
            }
            remove
            {
                customcontrolCheckbox1.QueryContinueDrag -= value;
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
                customcontrolCheckbox1.MouseDown += value;
            }
            remove
            {
                customcontrolCheckbox1.MouseDown -= value;
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
                customcontrolCheckbox1.MouseEnter += value;
            }
            remove
            {
                customcontrolCheckbox1.MouseEnter -= value;
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
                customcontrolCheckbox1.MouseHover += value;
            }
            remove
            {
                customcontrolCheckbox1.MouseHover -= value;
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
                customcontrolCheckbox1.MouseLeave += value;
            }
            remove
            {
                customcontrolCheckbox1.MouseLeave -= value;
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
                customcontrolCheckbox1.MouseMove += value;
            }
            remove
            {
                customcontrolCheckbox1.MouseMove -= value;
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
                customcontrolCheckbox1.MouseUp += value;
            }
            remove
            {
                customcontrolCheckbox1.MouseUp -= value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ボタンの位置・サイズ。
        /// </summary>
        private MemoryButtonImpl memoryButton1;

        //────────────────────────────────────────

        /// <summary>
        /// イベントに対応づくアクションの実行順リスト。無ければヌル。
        /// </summary>
        private Functionlist functionlist_Event_CheckedChanged;

        //────────────────────────────────────────

        private CustomcontrolCheckbox customcontrolCheckbox1;

        /// <summary>
        /// テキストボックスを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        public CustomcontrolCheckbox CustomcontrolCheckbox1
        {
            get
            {
                return customcontrolCheckbox1;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// チェックボックスの値の型。
        /// </summary>
        public EnumCheckboxValuetype EnumCheckboxValuetype
        {
            get
            {
                return this.customcontrolCheckbox1.EnumCheckboxValuetype;
            }
            set
            {
                this.customcontrolCheckbox1.EnumCheckboxValuetype = value;
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
                ccAll.Add(this.customcontrolCheckbox1);
                return ccAll;
            }
        }

        //────────────────────────────────────────

        public ControlCommon ControlCommon
        {
            get
            {
                return customcontrolCheckbox1.ControlCommon;
            }
        }

        //────────────────────────────────────────

        [Browsable(true), Description("チェックボックスの表示文字列ではなく、値です。")]
        public string UsercontrolText
        {
            set
            {
                string sText = value;
                bool bResult;
                int nResult;
                if (bool.TryParse(sText, out bResult))
                {
                    // true/false
                    customcontrolCheckbox1.Checked = bResult;
                }
                else if (int.TryParse(sText, out nResult))
                {
                    // 0/1/...
                    if (0 == nResult)
                    {
                        customcontrolCheckbox1.Checked = false;
                    }
                    else
                    {
                        customcontrolCheckbox1.Checked = true;
                    }
                }
                else
                {
                    // エラー
                }

                customcontrolCheckbox1.Text = sText;
            }
            get
            {
                string sText = customcontrolCheckbox1.Text;

                if ("" == sText.Trim())
                {
                    if (customcontrolCheckbox1.Checked)
                    {
                        sText = "true";
                    }
                    else
                    {
                        sText = "false";
                    }
                }

                return sText;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("追加 ユーザーコントロールの中に配置されている主コントロールの名前です。")
        ]
        public Expression_Node_String Usercontrol_Name_Control
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
                    customcontrolCheckbox1.ControlCommon.Expression_Name_Control = new Expression_Node_StringImpl(null, cf_Node);
                    customcontrolCheckbox1.Name = this.Name;
                }
                else
                {
                    customcontrolCheckbox1.ControlCommon.Expression_Name_Control = value;
                    string sName_Usercontrol = value.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ThisMethod);
                    customcontrolCheckbox1.Name = sName_Usercontrol;
                }

                //
                //
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);
            }
            get
            {
                return customcontrolCheckbox1.ControlCommon.Expression_Name_Control;
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
                customcontrolCheckbox1.AllowDrop = value;
            }
            get
            {
                return customcontrolCheckbox1.AllowDrop;
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
                customcontrolCheckbox1.Enabled = value;
            }
            get
            {
                return customcontrolCheckbox1.Enabled;
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
        Category("その他"),
        Description("チェックボックスの選択状態です。"),
        Browsable(true)
        ]
        public bool Checked
        {
            set
            {
                customcontrolCheckbox1.Checked = value;
            }
            get
            {
                return customcontrolCheckbox1.Checked;
            }
        }

        //────────────────────────────────────────

        [
        Category("その他"),
        Description("チェックボックスの選択状態です。"),
        Browsable(true)
        ]
        public CheckState CheckState
        {
            set
            {
                customcontrolCheckbox1.CheckState = value;
            }
            get
            {
                return customcontrolCheckbox1.CheckState;
            }
        }

        //────────────────────────────────────────
        #endregion

        

    }
}
