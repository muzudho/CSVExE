using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;//SystemColors,Point
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//S_WrittenPlaceImpl
using Xenon.Middle;//FormObjectProperties,CustomLabel
using Xenon.Operating;//BuilderColor
using Xenon.Table;//CellData


namespace Xenon.Controls
{

    /// <summary>
    /// 「lst」。リストボックス。
    /// </summary>
    public partial class UsercontrolListbox : UserControl, Usercontrol
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// 縦スクロールバーの横幅。
        /// </summary>
        private static readonly int N_VSCRBAR_WIDTH = 19;

        /// <summary>
        /// 縦スクロールバーの上下ボタンの縦幅。 
        /// </summary>
        private static readonly int N_VSCRBAR_UPDOWNBTN_HEIGHT = 20;

        /// <summary>
        /// 無指定時の項目の縦幅。
        /// </summary>
        private static readonly int N_DEFAULT_ITEM_HEIGHT_PX = 16;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolListbox()
        {
            // ヌル・アクセス防止のため
            this.CustomcontrolListbox1 = new CustomcontrolListbox();
            this.memoryVirticalscrollbar1 = new MemoryVirticalscrollbarImpl();

            this.listBoxItemDrawer = new ListboxItemDrawer_01Impl(null);

            InitializeComponent();

        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        private void UsercontrolListbox_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();


            this.CustomcontrolListbox1.Width = this.Width;
            this.CustomcontrolListbox1.Height = this.Height;

            this.Controls.Add(this.CustomcontrolListbox1);

            // 
            // CcListbox
            // 
            this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.UsercontrolListbox_DrawItem);
            //this.Refresh

            this.ResumeLayout(false);

            // この時点では、this.Width値が想定外の値なので、
            // 縦スクロールバーの位置設定は、Resize時に行う。
        }

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

            // 【特殊】
            string sScrollbars;
            fo_Record.TryGetString(out sScrollbars, NamesFld.S_SCROLL_BARS, false, "", this.ControlCommon.Owner_MemoryApplication, log_Reports);
            switch (sScrollbars.ToUpper())
            {
                case ValuesAttr.S_BOTH:
                    this.HorizontalScrollbar = true;
                    this.UsercontrolScrollbars = ScrollBars.Both;
                    break;
                case ValuesAttr.S_HORIZONTAL:
                    this.HorizontalScrollbar = true;
                    this.UsercontrolScrollbars = ScrollBars.Horizontal;
                    break;
                case ValuesAttr.S_VERTICAL:
                    this.HorizontalScrollbar = false;
                    this.UsercontrolScrollbars = ScrollBars.Vertical;
                    break;
                default: //case "NONE":
                    this.HorizontalScrollbar = false;
                    this.UsercontrolScrollbars = ScrollBars.None;
                    break;
            }


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

            // 【特殊】リストボックスの場合
            int nItemHeightPx;
            fo_Record.TryGetInt(out nItemHeightPx, NamesFld.S_ITEM_HEIGHT_PX, false, UsercontrolListbox.N_DEFAULT_ITEM_HEIGHT_PX, this.ControlCommon.Owner_MemoryApplication, log_Reports);
            if (0 < nItemHeightPx && nItemHeightPx < 256)
            {
                this.ItemHeight = nItemHeightPx;
            }

            // 【特殊】リストボックスの場合
            string sItemDisplayFormat;
            fo_Record.TryGetString(out sItemDisplayFormat, NamesFld.S_ITEM_DISPLAY_FORMAT, false, "", this.ControlCommon.Owner_MemoryApplication, log_Reports);
            this.CustomcontrolListbox1.SItemDisplayFormat = sItemDisplayFormat;

            // 【特殊】リストボックスの場合
            string sListValueField;
            fo_Record.TryGetString(out sListValueField, NamesFld.S_LIST_VALUE_FIELD, false, "", this.ControlCommon.Owner_MemoryApplication, log_Reports);
            this.CustomcontrolListbox1.SListValueField = sListValueField;


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

            // コントロールを不可視化。
            this.customcontrolListbox1.Visible = false;

            this.ControlCommon.BAutomaticinputting = false;
            // 自動入力ここまで

            goto gt_EndMethod;
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
            ConfigurationtreeToExpression_Event sToE_Event,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "CreateFunctionlist",log_Reports);
            //
            //
            Functionlist fw_Result = null;

            //.WriteLine(this.GetType().Name + "#CreateEventActionList: ＜構築＞【開始】　イベントに対応ついたアクションリストを追加します。　（リストボックス）");

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

                case NamesSe.S_ITEM_SELECTED:
                    {
                        //
                        //  （NActionPerformEnum.O_EA）
                        //

                        if (null == this.functionlist_Event_SelectedValueChanged)
                        {
                            Functionlist_FormLstImpl fw = new Functionlist_FormLstImpl(
                                //EnumEventhandler.O_Ea,
                                sToE_Event, owner_MemoryApplication);
                            fw.InitializeBeforeUse();
                            fw_Result = fw;

                            this.functionlist_Event_SelectedValueChanged = fw;


                            this.CustomcontrolListbox1.SelectedValueChanged += new System.EventHandler(this.functionlist_Event_SelectedValueChanged.Execute_OnOEa);

                            // ★DEBUG
                            //essageBox.Show(Info_Forms.LibraryName + ":" + this.GetType().Name + "#Perform_OEa: FC[" + this.ControlCommon.NFcName.GetString(EnumHitcount.Unconstraint, log_Reports) + "]で、EV[" + rEvent.Name + "]のアクションが登録されました。");

                        }
                    }
                    break;

                case NamesSe.S_ITEM_DOUBLE_CLICKED:
                    {
                        //
                        //  （NActionPerformEnum.O_EA）
                        //

                        if (null == this.functionlist_Event_ItemDoubleClicked)
                        {
                            fw_Result = new Functionlist_FormImpl(
                                //EnumEventhandler.O_Ea,
                                sToE_Event, owner_MemoryApplication);
                            this.functionlist_Event_ItemDoubleClicked = fw_Result;
                            ((Functionlist_FormImpl)this.functionlist_Event_ItemDoubleClicked).InitializeBeforeUse();


                            this.CustomcontrolListbox1.DoubleClick += new System.EventHandler(this.functionlist_Event_ItemDoubleClicked.Execute_OnOEa);

                            // ★DEBUG
                            //essageBox.Show(Info_Forms.LibraryName + ":" + this.GetType().Name + "#Perform_OEa: FC[" + this.ControlCommon.NFcName.GetString(EnumHitcount.Unconstraint, log_Reports) + "]で、EV[" + rEvent.Name + "]のアクションが登録されました。");

                        }
                    }
                    break;

                default:
                    // エラー
                    goto gt_Error_NotSupportedEvent;
            }


            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSupportedEvent:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.GetType().Name, log_Reports);//クラス名
                tmpl.SetParameter(2, sToE_Event.Name, log_Reports);//イベント名

                this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:518;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return fw_Result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアー
        /// 
        /// リストボックスの内容を空っぽにします。
        /// </summary>
        public void Clear()
        {
            // 【特殊】リストボックス.DataSourceをヌルにします。
            this.DataSource = null;

            this.CustomcontrolListbox1.SelectedIndex = -1;//【2012-09-06】追加
            this.CustomcontrolListbox1.Items.Clear();
        }

        /// <summary>
        /// イベントハンドラーを全て除去します。
        /// </summary>
        public void ClearAllEventhandlers(Log_Reports log_Reports)
        {
            // 【特殊】リストボックス.DataSourceをヌルにします。
            //this.DataSource = null;

            Remover_AllEventhandlers remover = new Remover_AllEventhandlersImpl(
                this.CustomcontrolListbox1,
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
                cct.Destruct(log_Reports);
            }
        }

        //────────────────────────────────────────

        public void Destruct(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Destruct(10)",log_Reports);
            //
            //

            // 【特殊】リストボックス.DataSourceをヌルにします。
//            this.DataSource = null;

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
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "AppendChild",log_Reports);
            //
            //

            //#このルートはエラー。
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー369！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("リストボックスに、子コントロールを追加しようとしないでください。");
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

            this.CustomcontrolListbox1.AddValidator(
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
        /// 妥当性判定ロジックを追加します。
        /// </summary>
        /// <param nFcName="nValidator"></param>
        public void AddValidator_FListboxForItems(
            Expressionv_3FListboxValidation ecv_Validator,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "AddValidator_FListboxForItems",log_Reports);
            //
            //

            this.CustomcontrolListbox1.AddValidator_FListboxForItems(
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
            this.customcontrolListbox1.Dirty(log_Reports);

            // リストボックスは空っぽになり、再描画時に最新値を取得するようになるが、
            // 「リストボックスの絵」の方が反映できてない。

            if (null == this.customcontrolListbox1.DataSource)
            {
                // データソースがセットされていない場合は、無視します。
            }
            else
            {
                // 全ての項目を予め作成させます。※初回空欄防止。
                int nLastIx = this.customcontrolListbox1.Items.Count;
                for (int nLoop = 0; nLoop < nLastIx; nLoop++)
                {
                    this.listBoxItemDrawer.P1_GetItemString(nLoop, this.customcontrolListbox1, log_Reports);
                    this.listBoxItemDrawer.P2_GetForeBrush(nLoop, this.customcontrolListbox1, log_Reports);
                }
            }

            // TODO: 対応したい。
            // リストボックスにデータベースをセットする前に
            // Dirtyをしてしまい、
            // エラーメッセージが表示されることがある。

            // 2012-02-03追加
            // リアルタイム更新に必要。
            // 例：「モンスター名を変更したら、モンスター名リストでもすぐに更新」のように。
            this.Refresh();
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

            this.CustomcontrolListbox1.RefreshData(log_Reports);

            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);

            //ystem.Console.WriteLine(this.GetType().Name + "#RefreshData: ★★デバッグ中。「" + this.ControlCommon.NFcName.GetString(EnumHitcount.Unconstraint, log_Reports) + "」更新。");
            //if (this.ControlCommon.NFcName.GetString(EnumHitcount.Unconstraint, log_Reports) == "FC_main_recordsLst")
            //{
            //    ystem.Console.WriteLine(this.GetType().Name + "#RefreshData: ★★デバッグ中。「FC_main_recordsLst」更新。");
            //}
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param nFcName="log_Reports"></param>
        public void UsercontrolToMemory(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UsercontrolToMemory",log_Reports);
            //
            //

            this.CustomcontrolListbox1.UsercontrolToMemory(log_Reports);

            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void SelectItem(
            Expression_Node_String ec_KeyColumnName,
            Expression_Node_String ec_ExpectedValue,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "SelectItem",log_Reports);
            //
            //

            this.CustomcontrolListbox1.SelectItem(
                ec_KeyColumnName,
                ec_ExpectedValue,
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

        private void UsercontrolListbox_SizeChanged(object sender, EventArgs e)
        {
            UsercontrolListbox uctLst = (UsercontrolListbox)sender;

            this.CustomcontrolListbox1.Width = uctLst.Width;
            this.CustomcontrolListbox1.Height = uctLst.Height;

            // サイズを変更しても、
            // 設定によってはサイズが変わらないことがあります。
            //
            // サイズをフィードバックします。
            uctLst.Width = this.CustomcontrolListbox1.Width;
            uctLst.Height = this.CustomcontrolListbox1.Height;
        }

        //────────────────────────────────────────

        /// <summary>
        /// リストボックスの項目の表示機能。
        /// 
        /// ・初回は、「リストボックスの最上段から、１つ１つ項目表示」する際の、表示できる項目回数。
        /// ・他に、「項目を選択し、前の選択肢を非選択表示に、新しい選択肢を選択表示に」する際の２回。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsercontrolListbox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UcListbox_DrawItem",log_Reports_ThisMethod);

            //
            //
            //
            //

            CustomcontrolListbox cctListbox = (CustomcontrolListbox)sender;


            //
            // 必ず最初に、検索したレコードセットを一時記憶に入れる指定であれば、
            // 検索したレコードセットを一時記憶に入れます。
            {
                //
                // ＜validator＞要素数だけ。通常、0 or 1。
                List<Expressionv_3FListboxValidation> ecvList_Validators = cctListbox.List_Expressionv_FListboxValidation;
                foreach (Expressionv_3FListboxValidation ev33 in ecvList_Validators)
                {
                    //
                    // ＜a-select-record＞要素を元に、レコードセットを一時記憶。
                    foreach (Expressionv_4ASelectRecord ecv_44 in ev33.List_Expressionv_ASelectRecord)
                    {

                        // デバッグ
                        if (true)
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.Append(Info_Controls.Name_Library + ":" + this.GetType().Name + "#OnCreated:【一時記憶セット】");
                            sb.Append("　FC＝[" + this.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod) + "]");

                            // #デバッグ出力
                            System.Console.WriteLine(sb.ToString());
                        }


                        ecv_44.Execute_SaveRecordset(log_Reports_ThisMethod);

                    }
                }
            }


            //
            // （２）描画
            this.ListboxItemDrawer.Perform(
                sender,
                e,
                log_Reports_ThisMethod
                );

            //
            //
            //
            //

            if (!log_Reports_ThisMethod.Successful)
            {
                //
                // エラーログ出力。

                // bug: リストボックスでエラーが出た時、項目の回数だけ表示されてしまう。
                this.ControlCommon.Owner_MemoryApplication.MemoryLogwriter.WriteErrorLog(
                    this.ControlCommon.Owner_MemoryApplication,
                    log_Reports_ThisMethod,
                    pg_Method.Fullname
                    );
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports_ThisMethod);
        }

        //────────────────────────────────────────

        private void UsercontrolListbox_MouseEnter(object sender, EventArgs e)
        {
            // マウスが領域に入ってきたら、
            // リストボックスを可視化。
            UsercontrolListbox uctLst = (UsercontrolListbox)sender;
            if (!uctLst.customcontrolListbox1.Visible)
            {
                uctLst.customcontrolListbox1.Visible = true;
            }
        }

        //────────────────────────────────────────

        private void UsercontrolListbox_Paint(object sender, PaintEventArgs e)
        {
            Log_Method pg_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_Dammy = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UcListbox_Paint",log_Reports_Dammy);


            UsercontrolListbox ucLst = (UsercontrolListbox)sender;

            if (!this.customcontrolListbox1.Visible)
            {
                // コントロールが不可視の場合、絵を描く。

                bool bEnabled = ucLst.customcontrolListbox1.Enabled;

                // 自分の内側に線を引ければよい。
                Rectangle rect = new Rectangle(
                    0,
                    0,
                    ucLst.Width - 1,
                    ucLst.Height - 1
                    );
                if (!bEnabled)
                {
                    // 編集不可能。
                    e.Graphics.FillRectangle(Brushes.LightGray, rect);
                }
                else
                {
                    // 編集可能。
                    e.Graphics.FillRectangle(Brushes.White, rect);
                }
                e.Graphics.DrawRectangle(
                    Pens.Black, rect
                    );


                // 縦スクロールバーの描画。
                bool bVisibleVscrbar = false;
                if (bVisibleVscrbar)
                {
                    Rectangle rect2 = new Rectangle(
                        this.memoryVirticalscrollbar1.Bounds.X,
                        this.memoryVirticalscrollbar1.Bounds.Y,
                        this.memoryVirticalscrollbar1.Bounds.Width - 1,
                        this.memoryVirticalscrollbar1.Bounds.Height - 1
                        );
                    if (!bEnabled)
                    {
                        // 編集不可能。
                        e.Graphics.FillRectangle(Brushes.LightGray, rect2);
                    }
                    else
                    {
                        // 編集可能。
                        e.Graphics.FillRectangle(this.memoryVirticalscrollbar1.BackBrush, rect2);
                    }

                    // 枠線
                    e.Graphics.DrawRectangle(Pens.Black, rect2);

                    // 「▲」ボタン。
                    {
                        MemoryButtonImpl moBtn = this.memoryVirticalscrollbar1.MemoryUpbutton;

                        // 自分の内側に線を引ければよい。
                        Rectangle rect3 = new Rectangle(
                            moBtn.Bounds.X,
                            moBtn.Bounds.Y,
                            moBtn.Bounds.Width - 1,
                           moBtn.Bounds.Height - 1
                            );
                        if (!bEnabled)
                        {
                            // 編集不可能。
                            e.Graphics.FillRectangle(Brushes.LightGray, rect3);
                        }
                        else
                        {
                            // 編集可能。
                            e.Graphics.FillRectangle(moBtn.BackBrush, rect3);
                        }
                        // 枠線
                        e.Graphics.DrawRectangle(Pens.Black, rect3);

                        // 視認で位置調整。
                        rect3.Offset(2, 1);
                        e.Graphics.DrawString("▲", moBtn.Font, moBtn.ForeBrush, rect3);
                    }

                    // 「▼」ボタン。
                    {
                        MemoryButtonImpl moBtn = this.memoryVirticalscrollbar1.MemoryDownbutton;

                        // 自分の内側に線を引ければよい。
                        Rectangle rect3 = new Rectangle(
                            moBtn.Bounds.X,
                            moBtn.Bounds.Y,
                            moBtn.Bounds.Width - 1,
                            moBtn.Bounds.Height - 1
                            );
                        if (!bEnabled)
                        {
                            // 編集不可能。
                            e.Graphics.FillRectangle(Brushes.LightGray, rect3);
                        }
                        else
                        {
                            // 編集可能。
                            e.Graphics.FillRectangle(moBtn.BackBrush, rect3);
                        }
                        // 枠線
                        e.Graphics.DrawRectangle(Pens.Black, rect3);

                        // 視認で位置調整。
                        rect3.Offset(2, 1);
                        e.Graphics.DrawString("▼", moBtn.Font, moBtn.ForeBrush, rect3);
                    }

                }


                // リストのテキストを表示します。
                {
                    // リストボックスの縦幅。
                    int nBoxH = rect.Height;
                    // 行の縦幅。
                    int nLineH = this.customcontrolListbox1.ItemHeight;

                    // テキスト表示領域は、四角の線から1ドット離すように小さくします。
                    Rectangle rect2;
                    if (bVisibleVscrbar)
                    {
                        // 縦スクロールバーを表示する場合。
                        rect2 = new Rectangle(
                            rect.X + 2,
                            rect.Y + 2,
                            rect.Width - N_VSCRBAR_WIDTH - 1,
                            nLineH - 2
                            );
                    }
                    else
                    {
                        rect2 = new Rectangle(
                            rect.X + 2,
                            rect.Y + 2,
                            rect.Width - 2,
                            nLineH - 2
                            );
                    }
                    //rect2=rect;
                    //rect.Inflate(-2, -2);

                    // 表示できる行数。
                    int nVrows = nBoxH / nLineH;

                    // 先頭項目のインデックス
                    int nVFirstIx = this.customcontrolListbox1.IndexFromPoint(1, 1);
                    if (nVFirstIx == -1)
                    {
                        pg_Method.WriteError_ToConsole(
                            "▲L05エラー①！ "+
                            pg_Method.Fullname + ":根本的なエラー？"
                            );
                        //essageBox.Show(
                        //    );
                    }
                    else
                    {
                        int nVLastIx = nVFirstIx + nVrows;
                        if (this.customcontrolListbox1.List_SText_Display.Count <= nVLastIx)
                        {
                            nVLastIx = this.customcontrolListbox1.List_SText_Display.Count - 1;
                        }

                        // 選択項目のインデックス
                        int nSelectedIx = this.customcontrolListbox1.SelectedIndex;

                        for (int nLoop = nVFirstIx; nLoop <= nVLastIx; nLoop++)
                        {
                            string sDisplayText = this.customcontrolListbox1.List_SText_Display[nLoop];

                            if (nSelectedIx != nLoop)
                            {
                                // 非選択表示
                                Brush brush = null;

                                if (nLoop < this.customcontrolListbox1.List_ForeBrush.Count)
                                {
                                    brush = this.customcontrolListbox1.List_ForeBrush[nLoop];
                                }

                                if (null == brush)
                                {
                                    brush = Brushes.Black;
                                }

                                e.Graphics.DrawString(sDisplayText, this.customcontrolListbox1.Font, brush, rect2);
                            }
                            else
                            {
                                // 選択表示
                                e.Graphics.FillRectangle(Brushes.Blue, rect2);
                                e.Graphics.DrawString(sDisplayText, this.customcontrolListbox1.Font, Brushes.White, rect2);

                            }
                            rect2.Y += nLineH;
                            //rect2.Offset(0, nLineH);
                        }
                    }

                }


            }

            pg_Method.EndMethod(log_Reports_Dammy);
            log_Reports_Dammy.EndLogging(pg_Method);
        }

        //────────────────────────────────────────

        private void UsercontrolListbox_Leave(object sender, EventArgs e)
        {
            // コントロールがフォーカスを失ったら、
            // コントロールを不可視化。
            UsercontrolListbox ucLst = (UsercontrolListbox)sender;
            ucLst.customcontrolListbox1.Visible = false;
        }

        //────────────────────────────────────────

        private void UsercontrolListbox_Resize(object sender, EventArgs e)
        {
            // 縦スクロールバー。
            this.memoryVirticalscrollbar1.Bounds = new Rectangle(
                this.Width - N_VSCRBAR_WIDTH,
                0,
                N_VSCRBAR_WIDTH,
                this.Height
                );

            // 「▲」ボタン。
            this.memoryVirticalscrollbar1.MemoryUpbutton.Bounds = new Rectangle(
                this.Width - N_VSCRBAR_WIDTH,
                0,
                N_VSCRBAR_WIDTH,
                N_VSCRBAR_UPDOWNBTN_HEIGHT
                );

            // 「▼」ボタン。
            this.memoryVirticalscrollbar1.MemoryDownbutton.Bounds = new Rectangle(
                this.Width - N_VSCRBAR_WIDTH,
                this.Height - N_VSCRBAR_UPDOWNBTN_HEIGHT,
                N_VSCRBAR_WIDTH,
                N_VSCRBAR_UPDOWNBTN_HEIGHT
                );
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

            this.CustomcontrolListbox1.JudgeValidity(log_Reports);

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
                return this.CustomcontrolListbox1.ItemHeight;
            }
        }

        public string UsercontrolItemdisplayformat
        {
            get
            {
                return this.CustomcontrolListbox1.SItemDisplayFormat;
            }
        }

        public string UsercontrolListvaluefield
        {
            get
            {
                return this.CustomcontrolListbox1.SListValueField;
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
                return this.CustomcontrolListbox1.Font.Size;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int UsercontrolTabindex
        {
            set
            {
                this.CustomcontrolListbox1.TabIndex = value;
            }
            get
            {
                return this.CustomcontrolListbox1.TabIndex;
            }
        }

        private ScrollBars usercontrolScrollbars;

        public ScrollBars UsercontrolScrollbars
        {
            get
            {
                return this.usercontrolScrollbars;
            }
            set
            {
                this.usercontrolScrollbars = value;
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
                this.CustomcontrolListbox1.Enter += value;
            }
            remove
            {
                this.CustomcontrolListbox1.Enter -= value;
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
                this.CustomcontrolListbox1.Leave += value;
            }
            remove
            {
                this.CustomcontrolListbox1.Leave -= value;
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
                this.CustomcontrolListbox1.TextChanged += value;
            }
            remove
            {
                this.CustomcontrolListbox1.TextChanged -= value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public event DrawItemEventHandler DrawItem
        {
            add
            {
                this.CustomcontrolListbox1.DrawItem += value;
            }
            remove
            {
                this.CustomcontrolListbox1.DrawItem -= value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// イベント【Se:項目選択時;】に対応するアクションリスト。
        /// 
        /// 「モンスターレギオンエディター」が使っているので public にしている。
        /// </summary>
        public event EventHandler SelectedValueChanged
        {
            add
            {
                this.CustomcontrolListbox1.SelectedValueChanged += value;
            }
            remove
            {
                this.CustomcontrolListbox1.SelectedValueChanged -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler SelectedIndexChanged
        {
            add
            {
                this.CustomcontrolListbox1.SelectedIndexChanged += value;
            }
            remove
            {
                this.CustomcontrolListbox1.SelectedIndexChanged -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragDrop
        {
            add
            {
                this.CustomcontrolListbox1.DragDrop += value;
            }
            remove
            {
                this.CustomcontrolListbox1.DragDrop -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragEnter
        {
            add
            {
                this.CustomcontrolListbox1.DragEnter += value;
            }
            remove
            {
                this.CustomcontrolListbox1.DragEnter -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerDragLeave
        {
            add
            {
                this.CustomcontrolListbox1.DragLeave += value;
            }
            remove
            {
                this.CustomcontrolListbox1.DragLeave -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragOver
        {
            add
            {
                this.CustomcontrolListbox1.DragOver += value;
            }
            remove
            {
                this.CustomcontrolListbox1.DragOver -= value;
            }
        }

        //────────────────────────────────────────

        public event GiveFeedbackEventHandler UsercontroleventhandlerGiveFeedback
        {
            add
            {
                this.CustomcontrolListbox1.GiveFeedback += value;
            }
            remove
            {
                this.CustomcontrolListbox1.GiveFeedback -= value;
            }
        }

        //────────────────────────────────────────

        public event QueryContinueDragEventHandler UsercontroleventhandlerQueryContinueDrag
        {
            add
            {
                this.CustomcontrolListbox1.QueryContinueDrag += value;
            }
            remove
            {
                this.CustomcontrolListbox1.QueryContinueDrag -= value;
            }
        }

        //────────────────────────────────────────

        public event MouseEventHandler UsercontroleventhandlerMouseDown
        {
            add
            {
                this.CustomcontrolListbox1.MouseDown += value;
            }
            remove
            {
                this.CustomcontrolListbox1.MouseDown -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerMouseEnter
        {
            add
            {
                this.CustomcontrolListbox1.MouseEnter += value;
            }
            remove
            {
                this.CustomcontrolListbox1.MouseEnter -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerMouseHover
        {
            add
            {
                this.CustomcontrolListbox1.MouseHover += value;
            }
            remove
            {
                this.CustomcontrolListbox1.MouseHover -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerMouseLeave
        {
            add
            {
                this.CustomcontrolListbox1.MouseLeave += value;
            }
            remove
            {
                this.CustomcontrolListbox1.MouseLeave -= value;
            }
        }

        //────────────────────────────────────────

        public event MouseEventHandler UsercontroleventhandlerMouseMove
        {
            add
            {
                this.CustomcontrolListbox1.MouseMove += value;
            }
            remove
            {
                this.CustomcontrolListbox1.MouseMove -= value;
            }
        }

        //────────────────────────────────────────

        public event MouseEventHandler UsercontroleventhandlerMouseUp
        {
            add
            {
                this.CustomcontrolListbox1.MouseUp += value;
            }
            remove
            {
                this.CustomcontrolListbox1.MouseUp -= value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 縦スクロールバーの位置・サイズ。
        /// </summary>
        private MemoryVirticalscrollbarImpl memoryVirticalscrollbar1;

        //────────────────────────────────────────

        /// <summary>
        /// イベントに対応づくアクションの実行順リスト。無ければヌル。
        /// </summary>
        private Functionlist functionlist_Event_SelectedValueChanged;

        //────────────────────────────────────────

        /// <summary>
        /// イベントに対応づくアクションの実行順リスト。無ければヌル。
        /// </summary>
        private Functionlist functionlist_Event_ItemDoubleClicked;

        //────────────────────────────────────────

        /// <summary>
        /// リストボックスの項目の表示機能。
        /// </summary>
        private ListboxItemDrawer listBoxItemDrawer;

        /// <summary>
        /// リストボックスの項目の表示機能。
        /// </summary>
        public ListboxItemDrawer ListboxItemDrawer
        {
            get
            {
                return listBoxItemDrawer;
            }
            set
            {
                listBoxItemDrawer = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// リストボックスを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        private CustomcontrolListbox customcontrolListbox1;

        /// <summary>
        /// リストボックスを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        public CustomcontrolListbox CustomcontrolListbox1
        {
            get
            {
                return customcontrolListbox1;
            }
            set
            {
                customcontrolListbox1 = value;
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
                ccAll.Add(this.CustomcontrolListbox1);
                return ccAll;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public ControlCommon ControlCommon
        {
            get
            {
                return this.CustomcontrolListbox1.ControlCommon;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
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
                this.CustomcontrolListbox1.Text = value;
            }
            get
            {
                Log_Method pg_Method = new Log_MethodImpl(0);
                Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
                pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UsercontrolText get",log_Reports_ThisMethod);
                //
                //

                //
                // ListBox.Text を返しても実用性がない？
                //
                // リストボックスの値は、何とする？
                //
                string sResult;
                Exception err_Excp;

                string sListValueFld;
                if (0 <= this.CustomcontrolListbox1.SelectedIndex && this.CustomcontrolListbox1.SelectedIndex < this.CustomcontrolListbox1.Items.Count)
                {
                    //行データがある
                    DataRowView row = (DataRowView)this.CustomcontrolListbox1.Items[this.CustomcontrolListbox1.SelectedIndex];//決め打ち

                    if (null==this.CustomcontrolListbox1.SListValueField || "" == this.CustomcontrolListbox1.SListValueField)
                    {
                        sListValueFld = "NO";//デフォルト
                    }
                    else
                    {
                        sListValueFld = this.CustomcontrolListbox1.SListValueField;
                    }

                    XenonValue_IntImpl oValue;
                    try
                    {
                        oValue = (XenonValue_IntImpl)row.Row[sListValueFld];//決め打ち
                    }
                    catch (Exception ex)
                    {
                        //
                        // エラー。
                        sResult = "＜エラー＞";
                        oValue = null;
                        err_Excp = ex;
                        goto gt_Error_NameField;
                    }

                    if (log_Reports_ThisMethod.Successful)
                    {
                        int nInt;
                        if (XenonValue_IntImpl.TryParse(
                            oValue,
                            out nInt,
                            EnumOperationIfErrorvalue.Spaces_To_Alt_Value,
                            -1,
                            log_Reports_ThisMethod
                            ))
                        {
                            sResult = nInt.ToString();
                        }
                        else
                        {
                            // エラー
                            sResult = "＜エラー＞";
                        }

                        if (!log_Reports_ThisMethod.Successful)
                        {
                            // エラー
                            sResult = "＜エラー＞";
                            goto gt_EndMethod;
                        }
                    }
                    else
                    {
                        sResult = "＜エラー＞";
                    }
                }
                else
                {
                    //正常：データはない
                    sResult = "＜正常：データはない＞";
                }

                goto gt_EndMethod;
            //
            //
                #region 異常系
            //────────────────────────────────────────
            gt_Error_NameField:
                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, sListValueFld, log_Reports_ThisMethod);//リストボックスのフィールド名
                    tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Exception(err_Excp), log_Reports_ThisMethod);//例外メッセージ

                    this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:517;", tmpl, log_Reports_ThisMethod);
                }
                goto gt_EndMethod;
            //────────────────────────────────────────
                #endregion
            //
            //
            gt_EndMethod:
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);

                return sResult;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public int NIndex_PreselectedItem
        {
            set
            {
                this.CustomcontrolListbox1.NIndex_PreselectedItem = value;
            }
            get
            {
                return this.CustomcontrolListbox1.NIndex_PreselectedItem;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public object DataSource
        {
            set
            {
                this.CustomcontrolListbox1.DataSource = value;
            }
            get
            {
                return this.CustomcontrolListbox1.DataSource;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 要素のコレクション。読み取り専用。
        /// </summary>
        public ListBox.ObjectCollection Items
        {
            get
            {
                return this.CustomcontrolListbox1.Items;
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
                    Configurationtree_Node cf_Node = new Configurationtree_NodeImpl(Info_Controls.Name_Library + ":" + this.GetType().Name + "#<init>:" + this.Name, null);
                    this.CustomcontrolListbox1.ControlCommon.Expression_Name_Control = new Expression_Node_StringImpl(null, cf_Node);
                    this.CustomcontrolListbox1.Name = this.Name;
                }
                else
                {
                    this.CustomcontrolListbox1.ControlCommon.Expression_Name_Control = value;
                    string sName_Usercontrol = value.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);
                    this.CustomcontrolListbox1.Name = sName_Usercontrol;
                }

                //
                //
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);
            }
            get
            {
                return this.CustomcontrolListbox1.ControlCommon.Expression_Name_Control;
            }
        }

        //────────────────────────────────────────

        public override bool AllowDrop
        {
            set
            {
                this.CustomcontrolListbox1.AllowDrop = value;
            }
            get
            {
                return this.CustomcontrolListbox1.AllowDrop;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public DrawMode DrawMode
        {
            set
            {
                this.CustomcontrolListbox1.DrawMode = value;
            }
            get
            {
                return this.CustomcontrolListbox1.DrawMode;
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
                this.CustomcontrolListbox1.Enabled = value;
            }
            get
            {
                return this.CustomcontrolListbox1.Enabled;
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
        /// 
        /// </summary>
        public int ItemHeight
        {
            set
            {
                this.CustomcontrolListbox1.ItemHeight = value;
            }
            get
            {
                return this.CustomcontrolListbox1.ItemHeight;
            }
        }

        //────────────────────────────────────────

        public SelectionMode SelectionMode
        {
            set
            {
                this.CustomcontrolListbox1.SelectionMode = value;
            }
            get
            {
                return this.CustomcontrolListbox1.SelectionMode;
            }
        }

        //────────────────────────────────────────

        public override string Text
        {
            set
            {
                this.CustomcontrolListbox1.Text = value;
            }
            get
            {
                return this.CustomcontrolListbox1.Text;
            }
        }

        //────────────────────────────────────────

        //[Browsable(true)]
        public object SelectedValue
        {
            set
            {
                this.CustomcontrolListbox1.SelectedValue = value;
            }
            get
            {
                return this.CustomcontrolListbox1.SelectedValue;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 選択されている要素のコレクション。読み取り専用。
        /// </summary>
        public ListBox.SelectedObjectCollection SelectedItems
        {
            get
            {
                return this.CustomcontrolListbox1.SelectedItems;
            }
        }

        //────────────────────────────────────────

        public int SelectedIndex
        {
            set
            {
                this.CustomcontrolListbox1.SelectedIndex = value;
            }
            get
            {
                return this.CustomcontrolListbox1.SelectedIndex;
            }
        }

        //────────────────────────────────────────

        public ListBox.SelectedIndexCollection SelectedIndices
        {
            get
            {
                return this.CustomcontrolListbox1.SelectedIndices;
            }
        }

        //────────────────────────────────────────

        public void ClearSelected()
        {
            this.CustomcontrolListbox1.ClearSelected();
        }

        //────────────────────────────────────────

        public object SelectedItem
        {
            set
            {
                this.CustomcontrolListbox1.SelectedItem = value;
            }
            get
            {
                return this.CustomcontrolListbox1.SelectedItem;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("水平スクロールバーがスクロールする横幅")
        ]
        public int HorizontalExtent
        {
            set
            {
                this.CustomcontrolListbox1.HorizontalExtent = value;
            }
            get
            {
                return this.CustomcontrolListbox1.HorizontalExtent;
            }
        }

        //────────────────────────────────────────

        [
        Category("追加"),
        Description("水平スクロールバーの有無")
        ]
        public bool HorizontalScrollbar
        {
            set
            {
                this.CustomcontrolListbox1.HorizontalScrollbar = value;
            }
            get
            {
                return this.CustomcontrolListbox1.HorizontalScrollbar;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
