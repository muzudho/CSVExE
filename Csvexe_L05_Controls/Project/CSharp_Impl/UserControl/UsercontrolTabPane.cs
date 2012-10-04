using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
    /// 「tbp」。タブ_ペーン。
    /// </summary>
    public partial class UsercontrolTabPane : UserControl, Usercontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolTabPane()
        {
            // ヌル・アクセス防止のため
            this.customcontrolTabControl1 = new CustomcontrolTabcontrol();

            InitializeComponent();
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
        /// コントロール用共通メソッド。
        /// </summary>
        public void Clear()
        {
            // タブ・ペーンなので、何もしません。
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

            //.WriteLine(this.GetType().Name + "#CreateEventActionList: ＜構築＞【開始】　イベントに対応ついたアクションリストを追加します。　（タブペーン）");

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

                case NamesSe.S_TAB_CHANGED:
                    {
                        if (null == this.functionlist_Event_SelectedIndexChanged)
                        {
                            Functionlist_FormTbpImpl fw = new Functionlist_FormTbpImpl(
                                //EnumEventhandler.O_Ea,
                                sToE_Event, owner_MemoryApplication);
                            fw.InitializeBeforeUse();
                            fw_Result = fw;

                            this.functionlist_Event_SelectedIndexChanged = fw;


                            this.customcontrolTabControl1.SelectedIndexChanged += new System.EventHandler(this.functionlist_Event_SelectedIndexChanged.Execute_OnOEa);
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
                tmpl.SetParameter(3, Log_RecordReportsImpl.ToMessage_Configurationtree(sToE_Event.Configurationtree_Event), log_Reports);//設定位置パンくずリスト

                this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:523;", tmpl, log_Reports);
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "AppendChild",log_Reports);
            //
            //

            if (log_Reports.Successful)
            {

                foreach (Customcontrol cct in uct.List_Customcontrol)
                {
                    //
                    // タブ ペーンに追加できるのは、タブ ページだけです。
                    //

                    //
                    // タブ ペーン"tbp" 直下にあるタブ ページ"tbg" だけが、タブ ペーンに追加できます。
                    //

                    if (cct is CustomcontrolTabPage)
                    {
                        CustomcontrolTabPage ccTabPage = (CustomcontrolTabPage)cct;

                        //
                        // このユーザーコントロールは タブペーンではなく、
                        // タブペーンを持っているユーザーコントロールなので、
                        // 持っているタブペーン（カスタム コントロール）に、子要素を追加します。
                        //
                        //
                        // ユーザーコントロール（UC）はタブページではないので追加できないので、
                        // タブページをextendsしているカスタムコントロール（CC）を追加します。
                        //
                        this.customcontrolTabControl1.TabPages.Add(ccTabPage);

                    }
                    else
                    {
                        goto gt_Error_AnotherChildType;
                    }

                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_AnotherChildType:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//タブペーン・コントロール名
                tmpl.SetParameter(2, uct.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//追加しようとしたコントロール名

                this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:524;", tmpl, log_Reports);
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

            customcontrolTabControl1.RefreshData(
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UpdateData",log_Reports);
            //
            //

            customcontrolTabControl1.UsercontrolToMemory(
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
            Expressionv_Validator_Old ev_validator,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UpdateData",log_Reports);
            //
            //

            customcontrolTabControl1.AddValidator(
                ev_validator,
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

        private void UsercontrolTabPane_SizeChanged(object sender, EventArgs e)
        {
            UsercontrolTabPane ucTabPane = (UsercontrolTabPane)sender;

            this.customcontrolTabControl1.Width = ucTabPane.Width;
            this.customcontrolTabControl1.Height = ucTabPane.Height;

            // サイズを変更しても、
            // ラベルの設定によってはサイズが変わらないことがあります。
            //
            // ラベルのサイズをフィードバックします。
            ucTabPane.Width = this.customcontrolTabControl1.Width;
            ucTabPane.Height = this.customcontrolTabControl1.Height;
        }

        //────────────────────────────────────────

        private void UsercontrolTabPane_Load(object sender, EventArgs e)
        {
            this.customcontrolTabControl1.Width = this.Width;
            this.customcontrolTabControl1.Height = this.Height;


            this.Controls.Add(this.customcontrolTabControl1);
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

            customcontrolTabControl1.JudgeValidity(
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
                return this.CustomcontrolTabControl1.Font.Size;
            }
        }

        public int UsercontrolTabindex
        {
            set
            {
                this.CustomcontrolTabControl1.TabIndex = value;
            }
            get
            {
                return this.CustomcontrolTabControl1.TabIndex;
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
        /// イベントに対応づくアクションの実行順リスト。無ければヌル。
        /// </summary>
        private Functionlist functionlist_Event_SelectedIndexChanged;

        //────────────────────────────────────────

        private CustomcontrolTabcontrol customcontrolTabControl1;

        /// <summary>
        /// TabControlを改造した、ＣＳＶＥｘＥ用カスタム・コントロール。
        /// </summary>
        public CustomcontrolTabcontrol CustomcontrolTabControl1
        {
            get
            {
                return customcontrolTabControl1;
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
                List<Customcontrol> list_Customcontrol = new List<Customcontrol>();
                list_Customcontrol.Add(this.CustomcontrolTabControl1);
                return list_Customcontrol;
            }
        }


        //────────────────────────────────────────

        public ControlCommon ControlCommon
        {
            get
            {
                return customcontrolTabControl1.ControlCommon;
            }
        }

        //────────────────────────────────────────

        [Browsable(true), Description("表示文字列です。")]
        public string UsercontrolText
        {
            set
            {
                customcontrolTabControl1.Text = value;
            }
            get
            {
                return customcontrolTabControl1.Text;
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
                    customcontrolTabControl1.ControlCommon.Expression_Name_Control = new Expression_Node_StringImpl(null, cf_Node);
                    customcontrolTabControl1.Name = this.Name;
                }
                else
                {
                    customcontrolTabControl1.ControlCommon.Expression_Name_Control = value;
                    string sName_Usercontrol = value.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);
                    customcontrolTabControl1.Name = sName_Usercontrol;
                }

                //
                //
                pg_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(pg_Method);
            }
            get
            {
                return customcontrolTabControl1.ControlCommon.Expression_Name_Control;
            }
        }


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
                customcontrolTabControl1.Enter += value;
            }
            remove
            {
                customcontrolTabControl1.Enter -= value;
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
                customcontrolTabControl1.Leave += value;
            }
            remove
            {
                customcontrolTabControl1.Leave -= value;
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
                customcontrolTabControl1.TextChanged += value;
            }
            remove
            {
                customcontrolTabControl1.TextChanged -= value;
            }
        }

        //────────────────────────────────────────

        public override bool AllowDrop
        {
            set
            {
                customcontrolTabControl1.AllowDrop = value;
            }
            get
            {
                return customcontrolTabControl1.AllowDrop;
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
                customcontrolTabControl1.Enabled = value;
            }
            get
            {
                return customcontrolTabControl1.Enabled;
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

        public event DragEventHandler UsercontroleventhandlerDragDrop
        {
            add
            {
                customcontrolTabControl1.DragDrop += value;
            }
            remove
            {
                customcontrolTabControl1.DragDrop -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragEnter
        {
            add
            {
                customcontrolTabControl1.DragEnter += value;
            }
            remove
            {
                customcontrolTabControl1.DragEnter -= value;
            }
        }

        //────────────────────────────────────────

        public event EventHandler UsercontroleventhandlerDragLeave
        {
            add
            {
                customcontrolTabControl1.DragLeave += value;
            }
            remove
            {
                customcontrolTabControl1.DragLeave -= value;
            }
        }

        //────────────────────────────────────────

        public event DragEventHandler UsercontroleventhandlerDragOver
        {
            add
            {
                customcontrolTabControl1.DragOver += value;
            }
            remove
            {
                customcontrolTabControl1.DragOver -= value;
            }
        }

        //────────────────────────────────────────

        public event GiveFeedbackEventHandler UsercontroleventhandlerGiveFeedback
        {
            add
            {
                customcontrolTabControl1.GiveFeedback += value;
            }
            remove
            {
                customcontrolTabControl1.GiveFeedback -= value;
            }
        }

        //────────────────────────────────────────

        public event QueryContinueDragEventHandler UsercontroleventhandlerQueryContinueDrag
        {
            add
            {
                customcontrolTabControl1.QueryContinueDrag += value;
            }
            remove
            {
                customcontrolTabControl1.QueryContinueDrag -= value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
