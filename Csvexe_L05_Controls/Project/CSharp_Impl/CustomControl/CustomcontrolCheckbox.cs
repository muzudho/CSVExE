using System;
using System.Collections.Generic;
using System.Drawing;//Color
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//Log_TextIndentedImpl
using Xenon.Middle;//HValidator

namespace Xenon.Controls
{
    /// <summary>
    /// テキストボックスのカスタム・コントロールです。
    /// 
    /// 手による直接入力と、自動設定による入力を区別するチェックボックスです。
    /// 
    /// 【▲！】Text プロパティーは、チェックボックスに指定するのではなく、ラベルを使ってください。
    /// 
    /// (Human Check Box)
    /// </summary>
    public class CustomcontrolCheckbox : CheckBox, Customcontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public CustomcontrolCheckbox()
        {
            this.controlCommon__ = new ControlCommonImpl();

            // チェック変更時のイベント・ハンドラーをセット。
            this.CheckedChanged += new System.EventHandler(this.this_CheckChanged);

            // false,true値がデフォルト。
            this.enumCheckboxValuetype = EnumCheckboxValuetype.Bool;

            this.list_Expressionv_Validator = new List<Expressionv_Validator_Old>();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 値をクリアーします。
        /// </summary>
        public void Clear()
        {
            this.Checked = false;
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


            List<Expression_Node_String> list_Expr_Data = this.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, EnumHitcount.Unconstraint, log_Reports);
            List<Expression_Node_String> list_Expr_Datasource = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(list_Expr_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_FROM, false, EnumHitcount.First_Exist, log_Reports);
            if (!log_Reports.Successful)
            {
                goto gt_EndMethod;
            }
            Expression_Node_String expr_Datasource = list_Expr_Datasource[0];


            if (null == expr_Datasource)
            {
                // データソースが設定されていないとき

                this.Clear();
            }
            else
            {
                if (log_Reports.Successful)
                {

                    if (0 < expr_Datasource.List_Expression_Child.Count)
                    {
                        expr_Datasource.List_Expression_Child.ForEach(delegate(Expression_Node_String expr_First, ref bool bRemove, ref bool bBreak)
                        {
                            if (log_Reports.Successful)
                            {
                                //
                                // 最初の１件。なければ空文字列。
                                //

                                string sValue;
                                if (null == expr_First)
                                {
                                    sValue = "";
                                }
                                else
                                {
                                    Expression_Node_String e_str = (Expression_Node_String)expr_First;
                                    sValue = e_str.Execute4_OnExpressionString(EnumHitcount.First_Exist_Or_Zero, log_Reports);
                                }


                                switch (this.EnumCheckboxValuetype)
                                {
                                    case EnumCheckboxValuetype.Bool:
                                        //
                                        //
                                        //
                                        // bool型のチェックボックス
                                        //
                                        //
                                        //
                                        {
                                            if ("" == sValue.Trim())
                                            {
                                                //
                                                // 暫定：　空白は、falseとして扱います。
                                                //
                                                sValue = "false";
                                            }


                                            this.ControlCommon.BAutomaticinputting = true;
                                            bool bChecked;
                                            bool bResult = bool.TryParse(sValue, out bChecked);
                                            this.Checked = bChecked;

                                            if (!bResult)
                                            {
                                                // エラー
                                                this.Checked = false;
                                                this.BackColor = Color.Red;

                                                //#内部メソッド内のエラー
                                                {
                                                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                                                    tmpl.SetParameter(1, sValue, log_Reports);//値

                                                    // データソース要素のソースを調べますが、「どのテーブルから取ってきたか」ではなく、
                                                    // 「設定ファイルに何と書かれていたか」を取ってきます。
                                                    //tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configurationtree(expr_Datasource.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト
                                                    tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configurationtree(expr_First.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                                                    this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:539;", tmpl, log_Reports);
                                                }
                                            }

                                            this.ControlCommon.BAutomaticinputting = false;
                                        }
                                        break;

                                    case EnumCheckboxValuetype.Zero_One:
                                        //
                                        //
                                        //
                                        // 0,1型のチェックボックス
                                        //
                                        //
                                        //
                                        {
                                            if ("" == sValue.Trim())
                                            {
                                                //
                                                // 暫定：　空白は、0（偽）として扱います。
                                                //
                                                sValue = "0";
                                            }


                                            this.ControlCommon.BAutomaticinputting = true;
                                            int nCheckedInt;
                                            bool bResult = int.TryParse(sValue, out nCheckedInt);


                                            if (bResult)
                                            {
                                                if (0 == nCheckedInt)
                                                {
                                                    this.Checked = false;
                                                }
                                                else if (1 == nCheckedInt)
                                                {
                                                    this.Checked = true;
                                                }
                                                else
                                                {
                                                    //
                                                    // 警告
                                                    //
                                                    this.Checked = false;
                                                    this.BackColor = Color.Red;

                                                    //#内部メソッド内のエラー
                                                    {
                                                        Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                                                        tmpl.SetParameter(1, nCheckedInt.ToString(), log_Reports);//値
                                                        tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configurationtree(expr_First.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                                                        this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:540;", tmpl, log_Reports);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //
                                                // エラー
                                                //
                                                this.Checked = false;
                                                this.BackColor = Color.Red;

                                                //#内部メソッド内のエラー
                                                {
                                                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                                                    tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(expr_First.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                                                    this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:541;", tmpl, log_Reports);
                                                }
                                            }

                                            goto automatic_input_end;

                                            //
                                        //
                                        //
                                        //
                                        automatic_input_end:
                                            this.ControlCommon.BAutomaticinputting = false;
                                        }
                                        break;

                                    default:
                                        {
                                            //
                                            // エラー
                                            //
                                            this.Checked = false;
                                            this.BackColor = Color.Red;

                                            //#内部メソッド内のエラー
                                            {
                                                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                                                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(expr_First.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                                                this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:542;", tmpl, log_Reports);
                                            }
                                        }
                                        break;
                                }

                            }

                            //
                            // 最初の１件のみ。
                            bBreak = true;
                        });
                    }
                    else
                    {
                        // 件数が無ければ。
                        this.ControlCommon.BAutomaticinputting = true;
                        this.Checked = false;// 空にする。
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
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
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
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "UsercontrolToMemory(10)",log_Reports);
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
                goto gt_Error_NullDatatarget;
            }
            else
            {
                // データターゲットが設定されているとき

                CustomcontrolCheckbox ccCheckBox = this;//イベントハンドラーのsender引数と一致すること。

                // TODO 数値型テキストボックスで空白を出力しようとしたときにエラーになるのはバグなので修正したい。

                // 特にトリムは行いません。

                switch (this.enumCheckboxValuetype)
                {
                    case EnumCheckboxValuetype.Bool:
                        {
                            ToMemory_Performer nDataTargetUpdater = new ExpressionDataTargetUpdaterImpl();

                            nDataTargetUpdater.ToMemory(
                                ccCheckBox.Checked.ToString(),
                                this.ControlCommon.Expression_Control,
                                this.ControlCommon.Owner_MemoryApplication,
                                log_Reports
                                );
                        }
                        break;

                    case EnumCheckboxValuetype.Zero_One:
                        {
                            int nCheckedInt;
                            if (ccCheckBox.Checked)
                            {
                                nCheckedInt = 1;
                            }
                            else
                            {
                                nCheckedInt = 0;
                            }

                            ToMemory_Performer nDataTargetUpdater = new ExpressionDataTargetUpdaterImpl();

                            nDataTargetUpdater.ToMemory(
                                nCheckedInt.ToString(),
                                this.ControlCommon.Expression_Control,
                                this.ControlCommon.Owner_MemoryApplication,
                                log_Reports
                                );
                        }
                        break;

                    default:
                        {
                            Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                            tmpl.SetParameter(1, this.enumCheckboxValuetype.ToString(),log_Reports);//未定義のEnum値。

                            this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:506;", tmpl, log_Reports);
                        }
                        break;
                }


                if (log_Reports.Successful)
                {
                    // 成功時
                    ccCheckBox.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    // 設定失敗時。
                    ccCheckBox.BackColor = Color.Yellow;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullDatatarget:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.Name, log_Reports);//コントロール名

                this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:502;", tmpl, log_Reports);
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



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// チェックが変更されたというイベント・ハンドラー。
        /// 
        /// このイベント・ハンドラーは、HCheckBoxに必ず登録されます。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        private void this_CheckChanged(object sender, EventArgs e)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "this_CheckChanged",log_Reports_ThisMethod);
            //
            //

            //bug:Expression_Name_Controlがnull→コンストラクタでダミーを入れた
            string sName_Usercontrol = this.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);

            log_Reports_ThisMethod.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロール（チェックボックス）のチェックが変更されました。";



            CustomcontrolCheckbox ccCheckBox = (CustomcontrolCheckbox)sender;

            if (this.ControlCommon.BAutomaticinputting)
            {
                // コンピューターにより自動入力されたとき。
                //essageBox.Show("コンピュータによって自動入力されました。 コントロールID=[" + this.FormObjectId + "]", "▲デバッグ");
            }
            else
            {
                // 手入力による更新。
                //essageBox.Show(
                //"ユーザーによって直接入力されました。hNumericUpDown=[" + hNumericUpDown + "] コントロールID=["+this.FormObjectId+"]",
                //"▲デバッグ（" + Info_Forms .LibraryName+ "）"+this.GetType().NFcName+"#this_CheckChanged:");

                this.UsercontrolToMemory(
                    log_Reports_ThisMethod
                    );
            }



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
            foreach (Expressionv_TextValidator_Old ecv_Validator in this.list_Expressionv_Validator)
            {
                // true/false
                EnumValidation_Old enumValidation = ecv_Validator.JudgeValidity(this.Checked.ToString());

                switch (enumValidation)
                {
                    case EnumValidation_Old.Ok:
                        // OK
                        if (!this.Enabled)
                        {
                            this.BackColor = SystemColors.Control;
                        }
                        else
                        {
                            this.BackColor = SystemColors.Window;
                        }
                        goto gt_EndMethod;// 関数から抜けます。

                    case EnumValidation_Old.Ng:
                        // NG
                        this.BackColor = Color.Yellow;
                        goto gt_EndMethod;// 関数から抜けます。

                    default:
                        // 続行
                        break;
                }
            }

            if (0 < this.list_Expressionv_Validator.Count)
            {
                // 妥当性判定を行った後の場合のみ。行ってない場合は無視。

                // OK
                if (!this.Enabled)
                {
                    this.BackColor = SystemColors.Control;
                }
                else
                {
                    this.BackColor = SystemColors.Window;
                }
            }

            //
        //
        //
        //
        gt_EndMethod:
            return;
        }

        //────────────────────────────────────────
        #endregion
        


        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// チェックボックスの値の型。
        /// </summary>
        private EnumCheckboxValuetype enumCheckboxValuetype;

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

        /// <summary>
        /// チェックボックスの値の型。
        /// </summary>
        public EnumCheckboxValuetype EnumCheckboxValuetype
        {
            get
            {
                return enumCheckboxValuetype;
            }
            set
            {
                enumCheckboxValuetype = value;
            }
        }

        //────────────────────────────────────────
        #endregion

        
        
    }
}
