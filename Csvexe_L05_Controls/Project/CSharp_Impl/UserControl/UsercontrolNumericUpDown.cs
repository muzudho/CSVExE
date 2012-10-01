using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//S_WrittenPlaceImpl
using Xenon.Middle;//FormObjectProperties,HValidator
using Xenon.Operating;//BuilderColor


namespace Xenon.Controls
{

    /// <summary>
    /// 「num」。数値ボックス。
    /// </summary>
    public partial class UsercontrolNumericUpDown : UserControl, Usercontrol
    {



        #region 用意
        //────────────────────────────────────────

        private readonly int N_UPDOWN_BTN_WIDTH = 13;
        private readonly int N_UPDOWN_BTN_HEIGHT = 10;
        private readonly int N_DOWN_BTN_Y = 9;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolNumericUpDown()
        {
            //「▲ボタン」。
            this.memoryUpbutton1 = new MemoryButtonImpl();
            //「▼ボタン」。
            this.memoryDownbutton1 = new MemoryButtonImpl();

            // ヌル・アクセス防止のため
            this.customcontrolTextbox1 = new CustomcontrolTextbox();

            InitializeComponent();
        }

        //────────────────────────────────────────

        private void UsercontrolNumericUpDown_Load(object sender, EventArgs e)
        {
            //
            //
            // テキストボックス
            //
            this.customcontrolTextbox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomcontrolTextbox1_KeyDown);

            this.Controls.Add(this.customcontrolTextbox1);

            this.SizeFit();
        }

        //────────────────────────────────────────

        private void SizeFit()
        {
            // 数値ボックス
            this.customcontrolTextbox1.Width = this.Width - N_UPDOWN_BTN_WIDTH;
            this.customcontrolTextbox1.Height = this.Height;

            // 「▲ボタン」。
            this.memoryUpbutton1.Bounds = new Rectangle(
                this.customcontrolTextbox1.Width,
                0,
                N_UPDOWN_BTN_WIDTH,
                N_UPDOWN_BTN_HEIGHT
                );

            // 「▼ボタン」。
            this.memoryDownbutton1.Bounds = new Rectangle(
                this.customcontrolTextbox1.Width,
                N_DOWN_BTN_Y,
                N_UPDOWN_BTN_WIDTH,
                N_UPDOWN_BTN_HEIGHT
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
            this.customcontrolTextbox1.Visible = false;

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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Destruct(30)",log_Reports);
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
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "CreateFunctionlist",log_Reports);
            //
            //
            Functionlist fw_Result = null;

            //.WriteLine(this.GetType().Name + "#CreateEventActionList: ＜構築＞【開始】　イベントに対応ついたアクションリストを追加します。　（数値上下ボタン）");

            //.WriteLine(this.GetType().Name + "#CreateEventActionList: ■■■■■■■■■■未実装です。無視されます。rEvent.Name=[" + rEvent.Name + "]■■■■■■■■■■");

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
                            fw_Result = new Functionlist_FormImpl(
                                //EnumEventhandler.O_Ea,
                                sToE_Event, owner_MemoryApplication);
                            this.functionlist_Event_ValueChanged = fw_Result;
                            ((Functionlist_FormImpl)this.functionlist_Event_ValueChanged).InitializeBeforeUse();


                            this.customcontrolTextbox1.TextChanged += new System.EventHandler(this.functionlist_Event_ValueChanged.Execute_OnOEa);


                            // ★DEBUG
                            //essageBox.Show(Info_Forms.LibraryName + ":" + this.GetType().Name + "#Perform_OEa: FC[" + this.ControlCommon.NFcName.GetString(Request_SelectingImpl.Unconstraint, log_Reports) + "]で、EV[" + rEvent.Name + "]のアクションが登録されました。");

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
                r.SetTitle("▲エラー457！", pg_Method);

                StringBuilder t = new StringBuilder();

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

            //#このルートはエラー。
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー458！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("数値上下ボックスに、子コントロールを追加しようとしないでください。");
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
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

        private void UsercontrolNumericUpDown_SizeChanged(object sender, EventArgs e)
        {
            this.SizeFit();
        }

        //────────────────────────────────────────

        private void UsercontrolNumericUpDown_Paint(object sender, PaintEventArgs e)
        {
            UsercontrolNumericUpDown ucNum = (UsercontrolNumericUpDown)sender;

            //
            // テキストボックス
            //
            if (!ucNum.customcontrolTextbox1.Visible)
            {
                // 不可視のときに描画。

                // 自分の内側に線を引ければよい。
                Rectangle rect = new Rectangle(
                    0,
                    0,
                    ucNum.CustomcontrolTextbox1.Width - 1,
                    ucNum.CustomcontrolTextbox1.Height - 1
                    );

                // 背景色
                if (ucNum.customcontrolTextbox1.ReadOnly)
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

                // テキスト表示領域は、四角の線の上下から1ドット離すように小さくします。
                rect.Inflate(-2, -2);
                rect.Offset(-1, 1);
                e.Graphics.DrawString(this.customcontrolTextbox1.Text, this.customcontrolTextbox1.Font, Brushes.Black, rect);
            }

            //
            // 「▲ボタン」
            //
            {
                // 自分の内側に線を引ければよい。
                Rectangle rect = new Rectangle(
                    this.memoryUpbutton1.Bounds.X,
                    this.memoryUpbutton1.Bounds.Y,
                    this.memoryUpbutton1.Bounds.Width - 1,
                    this.memoryUpbutton1.Bounds.Height - 1
                    );
                if (ucNum.customcontrolTextbox1.ReadOnly)
                {
                    // 編集不可能。
                    e.Graphics.FillRectangle(Brushes.LightGray, rect);
                }
                else
                {
                    // 編集可能。
                    e.Graphics.FillRectangle(this.memoryUpbutton1.BackBrush, rect);
                }
                // 枠線
                e.Graphics.DrawRectangle(Pens.Black, rect);

                // 視認で位置調整。
                rect.Offset(2, 1);
                e.Graphics.DrawString("▲", this.memoryUpbutton1.Font, this.memoryUpbutton1.ForeBrush, rect);
            }

            //
            // 「▼ボタン」
            //
            {
                // 自分の内側に線を引ければよい。
                Rectangle rect = new Rectangle(
                    this.memoryDownbutton1.Bounds.X,
                    this.memoryDownbutton1.Bounds.Y,
                    this.memoryDownbutton1.Bounds.Width - 1,
                    this.memoryDownbutton1.Bounds.Height - 1
                    );
                if (ucNum.customcontrolTextbox1.ReadOnly)
                {
                    // 編集不可能。
                    e.Graphics.FillRectangle(Brushes.LightGray, rect);
                }
                else
                {
                    // 編集可能。
                    e.Graphics.FillRectangle(this.memoryDownbutton1.BackBrush, rect);
                }
                // 枠線
                e.Graphics.DrawRectangle(Pens.Black, rect);

                // 視認で位置調整。
                rect.Offset(2, 1);
                e.Graphics.DrawString("▼", this.memoryDownbutton1.Font, this.memoryDownbutton1.ForeBrush, rect);
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// テキストボックスにフォーカスを置いて、↑キー、↓キーを押したとき。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        private void CustomcontrolTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // ↑キーを押したとき

                this.IncreaseValue();
            }
            else if (e.KeyCode == Keys.Down)
            {
                // ↓キーを押したとき

                this.DecreaseValue();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolNumericUpDown_Leave(object sender, EventArgs e)
        {
            // テキストボックスがフォーカスを失ったら、
            // テキストボックスを不可視化。
            UsercontrolNumericUpDown ucNum = (UsercontrolNumericUpDown)sender;
            ucNum.customcontrolTextbox1.Visible = false;
        }

        //────────────────────────────────────────

        private void UsercontrolNumericUpDown_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            bool bRefresh = false;

            //ystem.Console.WriteLine("UctNumericUpDown_Click e.GetType().Name=[" + e.GetType().Name + "] me.Location=[" + me.Location.X + "," + me.Location.Y + "] this.upbtnBounds=[" + this.moUpbtn.Bounds.X + "," + this.moUpbtn.Bounds.Y + "," + this.moUpbtn.Bounds.Width + "," + this.moUpbtn.Bounds.Height + "]");
            // 「▲ボタン」クリック時。
            if (this.memoryUpbutton1.Bounds.Contains(me.Location))
            {
                //ystem.Console.WriteLine("UctNumericUpDown_Click e.GetType().Name=[" + e.GetType().Name + "] me.Location=[" + me.Location.X + "," + me.Location.Y + "] this.upbtnBounds=[" + this.moUpbtn.Bounds.X + "," + this.moUpbtn.Bounds.Y + "," + this.moUpbtn.Bounds.Width + "," + this.moUpbtn.Bounds.Height + "]　「▲ボタン」クリック時。");

                if (!customcontrolTextbox1.Visible)
                {
                    // テキストボックスが表示されていない時。
                    // 描画に任せる。コントロールを絵で描いていることがある。
                    bRefresh = true;
                }
            }

            // 「▼ボタン」クリック時。
            if (this.memoryDownbutton1.Bounds.Contains(me.Location))
            {
                if (!customcontrolTextbox1.Visible)
                {
                    // テキストボックスが表示されていない時。
                    // 描画に任せる。コントロールを絵で描いていることがある。
                    bRefresh = true;
                }
            }

            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolNumericUpDown_MouseUp(object sender, MouseEventArgs e)
        {
            //ystem.Console.WriteLine("UcNumにマウスアップ e.GetType().Name=[" + e.GetType().Name + "] マウス位置=[" + System.Windows.Forms.Cursor.Position.X + "," + System.Windows.Forms.Cursor.Position.Y + "]");
            bool bRefresh = false;

            //「▲ボタン」
            if (this.memoryUpbutton1.Bounds.Contains(e.Location))
            {
                this.memoryUpbutton1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryUpbutton1.BackBrush = new SolidBrush(Color.YellowGreen);

                // ボタンを絵で描く。
                bRefresh = true;
            }

            //「▼ボタン」
            if (this.memoryDownbutton1.Bounds.Contains(e.Location))
            {
                this.memoryDownbutton1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryDownbutton1.BackBrush = new SolidBrush(Color.YellowGreen);

                // ボタンを絵で描く。
                bRefresh = true;
            }

            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolNumericUpDown_MouseDown(object sender, MouseEventArgs e)
        {
            // マウスダウン。
            //ystem.Console.WriteLine("UcNumにマウスダウン e.GetType().Name=[" + e.GetType().Name + "] マウス位置=[" + System.Windows.Forms.Cursor.Position.X + "," + System.Windows.Forms.Cursor.Position.Y + "]");

            bool bRefresh = false;

            // 「▲ボタン」
            if (this.memoryUpbutton1.Bounds.Contains(e.Location))
            {
                this.memoryUpbutton1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryUpbutton1.BackBrush = new SolidBrush(Color.DarkSeaGreen);

                // フォーカスをテキストボックスに持たせます。
                this.customcontrolTextbox1.Focus();

                this.IncreaseValue();

                // ボタンを絵で描く。
                bRefresh = true;
            }

            // 「▼ボタン」
            if (this.memoryDownbutton1.Bounds.Contains(e.Location))
            {
                this.memoryDownbutton1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryDownbutton1.BackBrush = new SolidBrush(Color.DarkSeaGreen);

                // フォーカスをテキストボックスに持たせます。
                this.customcontrolTextbox1.Focus();

                this.DecreaseValue();

                // ボタンを絵で描く。
                bRefresh = true;
            }

            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolNumericUpDown_MouseEnter(object sender, EventArgs e)
        {
            // マウスが領域に入ってきたら、
            // テキストボックスを可視化。
            UsercontrolNumericUpDown ucNum = (UsercontrolNumericUpDown)sender;
            if (!ucNum.customcontrolTextbox1.ReadOnly)
            {
                // 読取専門でなければ可視化。
                ucNum.customcontrolTextbox1.Visible = true;
            }

            Point p1 = this.PointToClient(System.Windows.Forms.Cursor.Position);
            bool bRefresh = false;



            //「▲ボタン」をまだマウスカーソルで指していない時。
            if (this.memoryUpbutton1.Bounds.Contains(p1) && !this.memoryUpbutton1.BMousePointed)
            {
                //ystem.Console.WriteLine("UcNumにマウスエンター e.GetType().Name=[" + e.GetType().Name + "] マウス位置=[" + System.Windows.Forms.Cursor.Position.X + "," + System.Windows.Forms.Cursor.Position.Y + "] this.upbtnBounds=[" + this.moUpbtn.Bounds.X + "," + this.moUpbtn.Bounds.Y + "," + this.moUpbtn.Bounds.Width + "," + this.moUpbtn.Bounds.Height + "] p1=[" + p1.X + "," + p1.Y + "]　●含む");
                this.memoryUpbutton1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryUpbutton1.BackBrush = new SolidBrush(Color.YellowGreen);

                // ボタンを絵で描く。
                bRefresh = true;
            }

            //「▼ボタン」をまだマウスカーソルで指していない時。
            if (this.memoryDownbutton1.Bounds.Contains(p1) && !this.memoryDownbutton1.BMousePointed)
            {
                this.memoryDownbutton1.ForeBrush = new SolidBrush(Color.Green);
                this.memoryDownbutton1.BackBrush = new SolidBrush(Color.YellowGreen);

                // ボタンを絵で描く。
                bRefresh = true;
            }

            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolNumericUpDown_MouseLeave(object sender, EventArgs e)
        {
            // 数値ボックスから外に出たら。

            bool bRefresh = false;

            if (this.memoryUpbutton1.BMousePointed)
            {
                // 「▲ボタン」を平常表示にする。
                this.memoryUpbutton1.ForeBrush = new SolidBrush(SystemColors.ControlText);
                this.memoryUpbutton1.BackBrush = new SolidBrush(SystemColors.Control);
                // ボタンを絵で描く。
                bRefresh = true;

                this.memoryUpbutton1.BMousePointed = false;
            }
            //    ystem.Console.WriteLine("UcNumにマウスリーブ e.GetType().Name=[" + e.GetType().Name + "] マウス位置=[" + System.Windows.Forms.Cursor.Position.X + "," + System.Windows.Forms.Cursor.Position.Y + "] this.upbtnBounds=[" + this.upbtnBounds.X + "," + this.upbtnBounds.Y + "," + this.upbtnBounds.Width + "," + this.upbtnBounds.Height + "] p1=[" + p1.X + "," + p1.Y + "]　●含む");

            //「▼ボタン」
            //マウスリーブ。
            if (this.memoryDownbutton1.BMousePointed)
            {
                // 「▼ボタン」を平常表示にする。
                this.memoryDownbutton1.ForeBrush = new SolidBrush(SystemColors.ControlText);
                this.memoryDownbutton1.BackBrush = new SolidBrush(SystemColors.Control);
                // ボタンを絵で描く。
                bRefresh = true;

                this.memoryDownbutton1.BMousePointed = false;
            }

            if (bRefresh)
            {
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void UsercontrolNumericUpDown_MouseMove(object sender, MouseEventArgs e)
        {
            Point p1 = this.PointToClient(System.Windows.Forms.Cursor.Position);

            // テキストボックス。
            if (this.customcontrolTextbox1.Bounds.Contains(p1))
            {
                // 可視化。
                this.customcontrolTextbox1.Visible = true;
            }

            bool bRefresh = false;

            //「▲ボタン」
            {
                bool bNewPointed = this.memoryUpbutton1.Bounds.Contains(p1);
                if (this.memoryUpbutton1.BMousePointed != bNewPointed)
                {
                    if (bNewPointed)
                    {
                        // マウスカーソルで指した。

                        //「▲ボタン」
                        // マウスエンター。
                        this.memoryUpbutton1.ForeBrush = new SolidBrush(Color.Green);
                        this.memoryUpbutton1.BackBrush = new SolidBrush(Color.YellowGreen);

                        // ボタンを絵で描く。
                        bRefresh = true;
                    }
                    else
                    {
                        // マウスカーソルを外した。

                        // 「▲ボタン」を平常表示にする。
                        this.memoryUpbutton1.ForeBrush = new SolidBrush(SystemColors.ControlText);
                        this.memoryUpbutton1.BackBrush = new SolidBrush(SystemColors.Control);
                        // ボタンを絵で描く。
                        bRefresh = true;
                    }
                }
                this.memoryUpbutton1.BMousePointed = bNewPointed;
            }

            //「▼ボタン」
            {
                bool bNewPointed = this.memoryDownbutton1.Bounds.Contains(p1);
                if (this.memoryDownbutton1.BMousePointed != bNewPointed)
                {
                    if (bNewPointed)
                    {
                        // マウスカーソルで指した。

                        // マウスエンター。
                        this.memoryDownbutton1.ForeBrush = new SolidBrush(Color.Green);
                        this.memoryDownbutton1.BackBrush = new SolidBrush(Color.YellowGreen);

                        // ボタンを絵で描く。
                        bRefresh = true;
                    }
                    else
                    {
                        // マウスカーソルを外した。

                        // ボタンを平常表示にする。
                        this.memoryDownbutton1.ForeBrush = new SolidBrush(SystemColors.ControlText);
                        this.memoryDownbutton1.BackBrush = new SolidBrush(SystemColors.Control);
                        // ボタンを絵で描く。
                        bRefresh = true;
                    }
                }
                this.memoryDownbutton1.BMousePointed = bNewPointed;
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

        /// <summary>
        /// 妥当性を判定します。
        /// </summary>
        public void JudgeValidity(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
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

        public ScrollBars UsercontrolScrollbars
        {
            get
            {
                return this.CustomcontrolTextbox1.ScrollBars;
            }
            set
            {
                this.CustomcontrolTextbox1.ScrollBars = value;
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

        /// <summary>
        /// NumericUpDownフォームは、空白・エラー入力値・上限下限値の取り扱いが意図する動きにとって無駄なので
        /// テキストボックスを使用した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
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
        /// 数値を増やすボタンの位置・サイズ。
        /// </summary>
        private MemoryButtonImpl memoryUpbutton1;

        //────────────────────────────────────────

        /// <summary>
        /// 数値を減らすボタンの位置・サイズ。
        /// </summary>
        private MemoryButtonImpl memoryDownbutton1;

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
                ccAll.Add(this.customcontrolTextbox1);
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
                customcontrolTextbox1.Text = value;
            }
            get
            {
                return customcontrolTextbox1.Text;
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
                    Configurationtree_Node cf_Node = new Configurationtree_NodeImpl(Info_Controls.Name_Library + ":" + this.GetType().Name + "#<init>:" + this.Name, null);
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
        Description("エディット コントロールの中の文字列を変更できるかどうかを設定します。")
        ]
        public bool ReadOnly
        {
            set
            {
                customcontrolTextbox1.ReadOnly = value;
            }
            get
            {
                return customcontrolTextbox1.ReadOnly;
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

        /// <summary>
        /// テキストボックスの内容がint値なら、+1 します。
        /// 空白なら 0 を入れます。
        /// それ以外なら無視します。
        /// </summary>
        private void IncreaseValue()
        {
            if (this.customcontrolTextbox1.Text == "")
            {
                this.customcontrolTextbox1.Text = "0";
            }
            else
            {
                int nNumber;
                if (!int.TryParse(this.customcontrolTextbox1.Text, out nNumber))
                {
                    // エラー
                    // 操作を無視します。
                }
                else
                {
                    nNumber++;
                    this.customcontrolTextbox1.Text = nNumber.ToString();
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// テキストボックスの内容が数値なら、-1 します。
        /// 空白なら 0 を入れます。
        /// それ以外なら無視します。
        /// </summary>
        private void DecreaseValue()
        {
            if (this.customcontrolTextbox1.Text == "")
            {
                this.customcontrolTextbox1.Text = "0";
            }
            else
            {
                int nNumber;
                if (!int.TryParse(this.customcontrolTextbox1.Text, out nNumber))
                {
                    // エラー

                    // 操作を無視します。
                }
                else
                {
                    nNumber--;
                    this.customcontrolTextbox1.Text = nNumber.ToString();
                }
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
        #endregion



    }
}
