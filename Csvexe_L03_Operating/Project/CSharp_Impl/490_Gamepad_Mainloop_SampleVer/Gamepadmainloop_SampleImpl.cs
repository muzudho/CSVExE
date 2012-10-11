using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;//Application

using Xenon.Syntax;
using Xenon.Table;//Table_Humaninput

namespace Xenon.Operating
{
    /// <summary>
    /// メインループです。ループの中身を書きます。
    /// </summary>
    public class Gamepadmainloop_SampleImpl : Gamepadmainloop
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="form1"></param>
        public Gamepadmainloop_SampleImpl(Usercontrol_Form1 form1)
        {
            this.form1 = form1;

            this.input = new Gamepadmainloop_Input_SampleImpl();
        }

        /// <summary>
        /// フォームのコンストラクト時。
        /// </summary>
        public void Init()
        {
            this.receiptByViews = new Gamepadmainloop_Receipt_View[2];
            {
                Gamepadmainloop_Receipt_ViewTest input = new Gamepadmainloop_Receipt_ViewTest();
                input.Uc_Form1 = form1;
                this.receiptByViews[0] = input;
            }
            {
                Gamepadmainloop_Receipt_ViewConfig input = new Gamepadmainloop_Receipt_ViewConfig();
                input.Uc_Form1 = form1;
                this.receiptByViews[1] = input;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// フォームのロード時。
        /// </summary>
        public void Load()
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_Load = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Operating.Name_Library, this, "Load",log_Reports_Load);
            //
            //

            // タイトル
            {
                StringBuilder s = new StringBuilder();

                s.Append("GamePad v");
                s.Append(Application.ProductVersion);
                s.Append(" - Xenon Tools");

                this.Form1.Text = s.ToString();
            }

            // キー設定
            {
                KeyconfigImpl keycnf;

                // キーコンフィグ読取
                {
                    XTo_KeyconfigImpl xToO = new XTo_KeyconfigImpl();
                    xToO.XTo(
                        out keycnf,
                        log_Reports_Load
                        );

                    this.Input.Table_Humaninput_Keyconfig = keycnf.O_Table_Keycnf;
                }

                // キー設定(1P)
                if (keycnf.Dic_KeyCnf.ContainsKey(1))
                {
                    KeyconfigPadImpl keycnfPad = keycnf.Dic_KeyCnf[1];

                    {
                        string sErrorMsg;
                        this.Form1.UsercontrolPage2.Open(1, keycnfPad, out sErrorMsg);
                        if ("" != sErrorMsg)
                        {
                            // エラー
                            if (log_Reports_Load.CanCreateReport)
                            {
                                Log_RecordReports r = log_Reports_Load.BeginCreateReport(EnumReport.Error);
                                r.SetTitle("▲エラー111！", pg_Method);
                                r.Message = sErrorMsg;
                                log_Reports_Load.EndCreateReport();
                            }
                            goto gt_EndMethod;
                        }
                    }

                    {
                        string sErrorMsg;
                        this.Form1.UsercontrolPage3.Open(1, keycnfPad, out sErrorMsg);
                        if ("" != sErrorMsg)
                        {
                            // エラー
                            if (log_Reports_Load.CanCreateReport)
                            {
                                Log_RecordReports r = log_Reports_Load.BeginCreateReport(EnumReport.Error);
                                r.SetTitle("▲エラー112！", pg_Method);
                                r.Message = sErrorMsg;
                                log_Reports_Load.EndCreateReport();
                            }
                            goto gt_EndMethod;
                        }
                    }
                }

            }

            // タイマー開始。
            this.Form1.Pctmr1.Enabled = true;

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports_Load);
            log_Reports_Load.EndLogging(pg_Method);
        }

        //────────────────────────────────────────

        public void Step()
        {
            // コントローラーの監視。
            this.Input.ListenController(this);


            // 開いているページに応じて、キー入力の効果を変えます。
            int index = this.Form1.TabControl1.SelectedIndex;

            if(0<=index && index<this.ReceiptByViews.Length )
            {
                this.ReceiptByViews[index].Perform(this);
            }

            this.nTimer++;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Usercontrol_Form1 form1;

        /// <summary>
        /// フォーム1。
        /// </summary>
        public Usercontrol_Form1 Form1
        {
            get
            {
                return form1;
            }
        }

        //────────────────────────────────────────

        private Gamepadmainloop_Input input;

        /// <summary>
        /// メインループの中の、入力担当。
        /// </summary>
        public Gamepadmainloop_Input Input
        {
            get
            {
                return input;
            }
        }

        //────────────────────────────────────────

        private Gamepadmainloop_Receipt_View[] receiptByViews;

        /// <summary>
        /// 場面別の、入力の受け取り方。
        /// </summary>
        public Gamepadmainloop_Receipt_View[] ReceiptByViews
        {
            get
            {
                return this.receiptByViews;
            }
        }

        //────────────────────────────────────────

        private long nTimer;

        /// <summary>
        /// タイマー。
        /// </summary>
        public long NTimer
        {
            get
            {
                return nTimer;
            }
            set
            {
                nTimer = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
