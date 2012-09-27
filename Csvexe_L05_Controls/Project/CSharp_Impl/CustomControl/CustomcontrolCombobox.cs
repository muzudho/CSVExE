﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Middle;//HValidator

namespace Xenon.Controls
{
    /// <summary>
    /// コンボボックスのカスタム・コントロール。
    /// </summary>
    public partial class CustomcontrolCombobox : ComboBox, Customcontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public CustomcontrolCombobox()
        {
            this.controlCommon__ = new ControlCommonImpl();

            this.nIndex_PreselectedItem = -1;

            // テキスト変更時のイベント・ハンドラーをセット。
            //this.TextChanged += new System.EventHandler(this.this_TextChanged);
        }

        //────────────────────────────────────────

        public void Clear()
        {
            this.Items.Clear();
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
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "Destruct(10)",log_Reports);
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
            List<Expression_Node_String> ecList_Data = this.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_DATA, false, Request_SelectingImpl.Unconstraint, log_Reports);
            List<Expression_Node_String> ecList_DataSource = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.SName_Pm, ValuesAttr.S_FROM, false, Request_SelectingImpl.First_Exist, log_Reports);
            if (!log_Reports.BSuccessful)
            {
                goto gt_EndMethod;
            }
            Expression_Node_String ec_DataSource = ecList_DataSource[0];


            if (null == ec_DataSource)
            {
                // データソースが未設定のとき

                this.Items.Clear();
            }
            else
            {
                // データソースが設定されているとき。

                // 未実装 TODO 実装すること。
            }

            goto gt_EndMethod;
        //
        //
        //
        //
        gt_EndMethod:
            ;
        }

        //────────────────────────────────────────

        public void UsercontrolToMemory(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
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

                //#未実装 TODO: 実装すること。
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー477！", pg_Method);

                    StringBuilder t = new StringBuilder();

                    t.Append("コントロール=[");
                    t.Append(this.Name);
                    t.Append("]のUpdateDataをしようとしましたが、"+pg_Method.SHead+" は　未実装でした。");
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
                    r.SetTitle("▲エラー476！", pg_Method);

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

        private int nIndex_PreselectedItem;

        /// <summary>
        /// コンボボックスで、前回選択されていた項目インデックス。
        /// 
        /// 自動化されていませんので、前回選択されていた項目は、使う側のソースでセットしてください。
        /// 
        /// コンボボックスのselectedIndex値の初期値は 0 なので、このプロパティの初期値は -1 にしておきます。
        /// TODO コンボボックスの SelectedIndexChanged の誤発動をなくしたい。
        /// </summary>
        public int NIndex_PreselectedItem
        {
            set
            {
                nIndex_PreselectedItem = value;
            }
            get
            {
                return nIndex_PreselectedItem;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}