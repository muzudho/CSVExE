using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Middle;//HValidator

namespace Xenon.Controls
{
    /// <summary>
    /// ラベルのカスタム・コントロール。
    /// </summary>
    public partial class CustomcontrolLabel : Label, Customcontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public CustomcontrolLabel()
        {
            this.controlCommon__ = new ControlCommonImpl();

            this.Padding = new Padding(0);
            this.Margin = new Padding(0);
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロール用共通メソッド。
        /// </summary>
        public void Clear()
        {
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

            List<Expression_Node_String> listExpr_Data = this.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, EnumHitcount.Unconstraint, log_Reports);
            List<Expression_Node_String> listExpr_DataSource = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(listExpr_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_FROM, false, EnumHitcount.First_Exist, log_Reports);
            if (!log_Reports.Successful)
            {
                goto gt_EndMethod;
            }
            Expression_Node_String ec_DataSource = listExpr_DataSource[0];

            if (null == ec_DataSource)
            {
                // データソースが設定されていないとき
                //.WriteLine(this.GetType().Name + "#RefreshData: データソースが設定されていません。");

                this.Clear();
            }
            else
            {
                if (log_Reports.Successful)
                {

                    this.ControlCommon.BAutomaticinputting = true;

                    //
                    // 最初の１件。なければ空文字列。
                    //
                    Expression_Node_String ec_Str = ec_DataSource;
                    this.Text = ec_Str.Execute_OnExpressionString(EnumHitcount.First_Exist_Or_Zero, log_Reports);

                    this.ControlCommon.BAutomaticinputting = false;
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
                goto gt_Error_Datatarget;
            }
            else
            {
                //
                // データターゲットが設定されているとき
                //

                //
                // 未実装 TODO: 実装すること。
                //
                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, this.Name, log_Reports);//コントロール名

                    this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:537;", tmpl, log_Reports);
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Datatarget:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.Name, log_Reports);//コントロール名

                this.ControlCommon.Owner_MemoryApplication.CreateErrorReport("Er:504;", tmpl, log_Reports);
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

        public void AddValidator(
            Expressionv_Validator_Old ecv_Validator,
            Log_Reports log_Reports
            )
        {
            // 未実装 TODO 実装すること。
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
            // 未実装 TODO 実装すること。
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

        // TODO: バリデーターリスト

        //────────────────────────────────────────
        #endregion



    }
}
