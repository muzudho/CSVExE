using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;//TabControl

using Xenon.Syntax;
using Xenon.Middle;//HValidator

namespace Xenon.Controls
{
    public partial class CustomcontrolTabcontrol : TabControl, Customcontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public CustomcontrolTabcontrol()
        {
            this.controlCommon__ = new ControlCommonImpl();

            this.list_Expressionv_Validator = new List<Expressionv_Validator_Old>();
            InitializeComponent();
        }

        public CustomcontrolTabcontrol(IContainer container)
        {
            this.controlCommon__ = new ControlCommonImpl();

            container.Add(this);

            InitializeComponent();
        }

        //────────────────────────────────────────

        /// <summary>
        /// ＣＳＶＥｘＥ用の初期化です。
        /// </summary>
        private void InitializeComponentXenon()
        {
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.Controls.Add(this.tabPage1);
            this.Controls.Add(this.tabPage2);
            this.Location = new System.Drawing.Point(40, 64);
            this.Name = "tabControl1";
            this.SelectedIndex = 0;
            this.Size = new System.Drawing.Size(200, 100);
            this.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 75);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 75);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;

            // 
            //
            // 
            this.ResumeLayout(false);
        }

        //────────────────────────────────────────

        public void Clear()
        {
            // タブ_コントロールなので、何もしません。
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
        }

        //────────────────────────────────────────

        public void Destruct(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "Destruct(20)",log_Reports);
            //
            //

            this.ClearAllEventhandlers(log_Reports);

            //
            // 破棄フラグを立てます。
            //
            this.ControlCommon.BDestructed = true;

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
        /// データソースから値を取得し、コントロールに取り込みます。
        /// 
        /// データソースが設定されていない場合は、フォームのクリアーになります。
        /// </summary>
        public void RefreshData(
            Log_Reports log_Reports
            )
        {
            //
            // タブなので何もしません。
            //
        }

        //────────────────────────────────────────

        /// <summary>
        /// データ・ターゲットへの出力を行います。
        /// 
        /// イベント・ハンドラー以外でも、直接、データターゲットへの出力を行うことができます。
        /// 
        /// 旧名：PerformDataTargetOut
        /// </summary>
        public void UsercontrolToMemory(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "UsercontrolToMemory",log_Reports);
            //
            //

            if (null == this.ControlCommon.Expression_Control)
            {
                // このコントロールに対応づくテーブル等の設定がなく、ただの空箱の場合。
                // Visual Studio のビジュアルエディターで直接置いただけの時は、ここに来ます。

                // 何もせず終了。
                goto gt_EndMethod;
            }


            List<Expression_Node_String> ecList_Data = this.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, Request_SelectingImpl.Unconstraint, log_Reports);
            List<Expression_Node_String> ecList_DataTarget = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.SName_Pm, ValuesAttr.S_TO, false, Request_SelectingImpl.First_Exist, log_Reports);
            if (!log_Reports.BSuccessful)
            {
                goto gt_EndMethod;
            }
            Expression_Node_String ec_DataTarget = ecList_DataTarget[0];


            if (null == ec_DataTarget)
            {
                // エラー：     データターゲットが未設定のとき
                goto gt_Error_NullDatatarget;
            }
            else
            {
                //
                // データターゲットが設定されているとき
                //

                //
                // 未実装 TODO: 実装すること。
                //
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー472！", pg_Method);

                    StringBuilder t = new StringBuilder();

                    t.Append("コントロール=[");
                    t.Append(this.Name);
                    t.Append("]のUpdateDataをしようとしましたが、CcTabControl#UpdateDataは　未実装でした。");
                    t.Append(Environment.NewLine);
                    t.Append("プログラミングのミスの可能性があります。");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);

                    // ヒント

                    r.SMessage = t.ToString();
                    log_Reports.EndCreateReport();
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullDatatarget:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー466！", pg_Method);

                StringBuilder t = new StringBuilder();

                t.Append("コントロール=[");
                t.Append(this.Name);
                t.Append("]には、NDataTarget が設定されていませんでした。");
                t.Append(Environment.NewLine);
                t.Append("プログラミングのミスの可能性があります。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

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
        /// 妥当性判定ロジックを追加します。
        /// </summary>
        /// <param nFcName="nValidator"></param>
        public void AddValidator(
            Expressionv_Validator_Old ecv_Validator,
            Log_Reports log_Reports
            )
        {
            if (ecv_Validator is Expressionv_TextValidator_Old)
            {
                this.list_Expressionv_Validator.Add((Expressionv_TextValidator_Old)ecv_Validator);
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
            //
            // 無視
            //
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private ControlCommon controlCommon__;

        /// <summary>
        /// コントロールの共通プロパティー、およびロジックが含まれているクラスです。
        /// 
        /// C#では多重継承ができないので、共通のプロパティー、ロジックがあれば、ここに含めます。
        /// </summary>
        public ControlCommon ControlCommon
        {
            get
            {
                return controlCommon__;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 妥当性判定項目のリスト。
        /// </summary>
        private List<Expressionv_Validator_Old> list_Expressionv_Validator;

        /// <summary>
        /// 妥当性判定項目のリスト。
        /// </summary>
        public List<Expressionv_Validator_Old> List_Expressionv_Validator
        {
            get
            {
                return list_Expressionv_Validator;
            }
        }

        //────────────────────────────────────────

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;

        //────────────────────────────────────────
        #endregion



    }
}
