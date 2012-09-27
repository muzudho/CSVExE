using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{
    /// <summary>
    /// Controlの各種実体（Buttton等）を継承して作った自作コントロールに付けるインターフェース。
    /// 
    /// 各コントロールのクラス名に付ける接頭辞に限り、略称は「Cct」とする。
    /// </summary>
    public interface Customcontrol
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// イベントハンドラーを全て除去します。
        /// </summary>
        void ClearAllEventhandlers(Log_Reports log_Reports);

        /// <summary>
        /// このコントロールを破棄する前の、後始末処理です。
        /// </summary>
        /// <param name="log_Reports"></param>
        void Destruct(
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// データソースから、最新の値を取得し、コントロールに取り込みます。
        /// 
        /// データソースが設定されていない場合は、フォームのクリアーになります。
        /// </summary>
        void RefreshData(
            Log_Reports log_Reports
            );

        /// <summary>
        /// フォームの値を、データターゲットへセットします。
        /// </summary>
        void UsercontrolToMemory(
            Log_Reports log_Reports
            );

        ///// <summary>
        ///// 妥当性判定項目のリスト。
        ///// </summary>
        //List<Nv_TextValidator_old> ValidatorList
        //{
        //    get;
        //}

        void AddValidator(
            Expressionv_Validator_Old ecv_Validator,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 妥当性を判定します。
        /// </summary>
        void JudgeValidity(
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// コントロールの共通プロパティー、およびロジックが含まれているクラスです。
        /// </summary>
        ControlCommon ControlCommon
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }


}
