using System;
using System.Collections.Generic;
using System.Drawing;//Color
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Middle;//HValidator

namespace Xenon.Controls
{
    /// <summary>
    /// テキストボックスのカスタム・コントロールです。
    /// 
    /// 手による直接入力と、自動設定による入力を区別するテキストボックスです。
    /// </summary>
    public class CustomcontrolNumericUpDown : NumericUpDown, Customcontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public CustomcontrolNumericUpDown()
        {
            this.controlCommon__ = new ControlCommonImpl();

            // テキスト変更時のイベント・ハンドラーをセット。
            this.TextChanged += new System.EventHandler(this.this_TextChanged);

            this.list_Expressionv_Validator = new List<Expressionv_Validator_Old>();
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロール用共通メソッド。
        /// </summary>
        public void Clear()
        {
            // 空クリアー
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "RefreshData",log_Reports);
            //
            //


            List<Expression_Node_String> ecList_Data = this.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, EnumHitcount.Unconstraint, log_Reports);
            List<Expression_Node_String> ecList_DataSource = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_FROM, false, EnumHitcount.First_Exist, log_Reports);
            if (!log_Reports.Successful)
            {
                goto gt_EndMethod;
            }
            Expression_Node_String ec_DataSource = ecList_DataSource[0];


            if (null == ec_DataSource)
            {
                // データソースが設定されていないとき

                this.Clear();
            }
            else
            {
                if (log_Reports.Successful)
                {
                    //EnumHitcount requestItems = new EnumHitcount();
                    //requestItems = EnumHitcount.First_Exist_Or_Zero;

                    if (0 < ec_DataSource.List_Expression_Child.Count)
                    {
                        ec_DataSource.List_Expression_Child.ForEach(delegate(Expression_Node_String e_str, ref bool bRemove, ref bool bBreak)
                        {
                            this.ControlCommon.BAutomaticinputting = true;

                            //
                            // 最初の１件。無ければ空文字列。
                            //
                            string sValue = e_str.Execute_OnExpressionString(EnumHitcount.First_Exist_Or_Zero, log_Reports);

                            if (sValue == "")
                            {
                                //
                                // 空文字列の場合。
                                //
                                this.Text = "";
                            }
                            else
                            {
                                decimal decimalValue;
                                bool bSuccessful = decimal.TryParse(sValue, out decimalValue);

                                if (bSuccessful)
                                {
                                    this.Value = decimalValue;// decimal.Parse(valueString);
                                    this.Text = sValue;
                                }
                                else
                                {
                                    //
                                    // パース_エラー
                                    //
                                    this.Value = new Decimal();
                                    this.Text = "";
                                }
                            }

                            this.ControlCommon.BAutomaticinputting = false;

                            // 最初の１件のみ。
                            bBreak = true;
                        });
                    }
                    else
                    {
                        // 件数が無ければ。
                        this.ControlCommon.BAutomaticinputting = true;
                        this.Text = "";// 空にする。
                        //hNumericUpDown.Enabled = true;
                        this.ControlCommon.BAutomaticinputting = false;
                    }
                }
                else
                {

                }
            }

            goto gt_EndMethod;
        //
        //
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

        /// <summary>
        /// データ・ターゲットへの出力を行います。
        /// 
        /// イベント・ハンドラー以外でも、直接、データターゲットへの出力を行うことができます。
        /// </summary>
        public void UsercontrolToMemory(
            Log_Reports log_Reports
            )
        {

            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UsercontrolToMemory",log_Reports);
            //
            //

            if (null == this.ControlCommon.Expression_Control)
            {
                // このコントロールに対応づくテーブル等の設定がなく、ただの空箱の場合。
                // Visual Studio のビジュアルエディターで直接置いただけの時は、ここに来ます。

                // 何もせず終了。
                goto gt_EndMethod;
            }


            List<Expression_Node_String> ecList_Data = this.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, EnumHitcount.Unconstraint, log_Reports);
            List<Expression_Node_String> ecList_DataTarget = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_TO, false, EnumHitcount.First_Exist, log_Reports);
            if (!log_Reports.Successful)
            {
                goto gt_EndMethod;
            }
            Expression_Node_String ec_DataTarget = ecList_DataTarget[0];


            if (null == ec_DataTarget)
            {
                // エラー：     データターゲットが未設定のとき
                goto gt_Error_Nulltarget;
            }
            else
            {
                // データターゲットが設定されているとき

                CustomcontrolNumericUpDown ccNumericUpDown = this;//イベントハンドラーのsender引数と一致すること。

                // TODO 数値型テキストボックスで空白を出力しようとしたときにエラーになるのはバグなので修正したい。

                // 特にトリムは行いません。

                string sValueText = ccNumericUpDown.Text;
                decimal valueDecimal = ccNumericUpDown.Value;

                ToMemory_Performer nDataTargetUpdater = new ExpressionDataTargetUpdaterImpl();

                nDataTargetUpdater.ToMemory(
                    sValueText,
                    this.ControlCommon.Expression_Control,
                    this.ControlCommon.Owner_MemoryApplication,
                    log_Reports
                    );

                if (log_Reports.Successful)
                {
                    // 成功時
                    ccNumericUpDown.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    // 設定失敗時。
                    ccNumericUpDown.BackColor = Color.Yellow;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Nulltarget:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.Name, log_Reports);//コントロール名

                this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:508;", tmpl, log_Reports);
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
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// テキストが変更されたというイベント・ハンドラー。
        /// 
        /// このイベント・ハンドラーは、このカスタム コントロールに必ず登録されます。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        private void this_TextChanged(object sender, EventArgs e)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "this_TextChanged",log_Reports_ThisMethod);
            //
            //

            string sName_Usercontrol = this.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);

            log_Reports_ThisMethod.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロール（数値上下ボックス）のテキストが変更されました。";

            CustomcontrolNumericUpDown ccNumericUpDown = (CustomcontrolNumericUpDown)sender;

            if (this.ControlCommon.BAutomaticinputting)
            {
                // コンピューターにより自動入力されたとき。
                //essageBox.Show("コンピュータによって自動入力されました。 コントロールID=[" + this.FormObjectId + "]", "デバッグ");
            }
            else
            {
                // 手入力による更新。

                MessageBox.Show(
                    "ユーザーによって直接入力されました。this.ControlCommon.Name=[" + sName_Usercontrol + "]",
                    "▲デバッグ（" + Info_Controls.Name_Library + "）" + this.GetType().Name + "#this_TextChanged:");

                this.UsercontrolToMemory(
                    log_Reports_ThisMethod
                    );
            }


            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(pg_Method);
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
            foreach (Expressionv_TextValidator_Old ecv_Validator_Old in this.list_Expressionv_Validator)
            {
                EnumValidation_Old enumValidation = ecv_Validator_Old.JudgeValidity(this.Text);

                switch (enumValidation)
                {
                    case EnumValidation_Old.Ok:
                        // OK
                        if (this.ReadOnly || !this.Enabled)
                        {
                            this.BackColor = SystemColors.Control;
                        }
                        else
                        {
                            this.BackColor = SystemColors.Window;
                        }
                        return;// 関数から抜けます。

                    case EnumValidation_Old.Ng:
                        // NG
                        this.BackColor = Color.Yellow;
                        return;// 関数から抜けます。

                    default:
                        // 続行
                        break;
                }
            }

            // OK
            if (this.ReadOnly || !this.Enabled)
            {
                this.BackColor = SystemColors.Control;
            }
            else
            {
                this.BackColor = SystemColors.Window;
            }
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
        #endregion



    }
}
