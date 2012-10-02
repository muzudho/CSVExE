using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Operating;

namespace Xenon.Middle
{

    /// <summary>
    /// アプリケーションの内容の全て。
    /// </summary>
    public interface MemoryApplication
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// 使う前に、実装インスタンスを設定してください。
        /// </summary>
        /// <param name="mainwnd_FormWrapping"></param>
        /// <param name="collection_EventHandler"></param>
        void InitializeBeforeUse(
            Mainwnd_FormWrapping mainwnd_FormWrapping,
            ConfigurationtreeToFunction conftreeToFunction,
            Form_Toolwindow form_Toolwindow,
            MemoryAatoolxmlDialog moAatoolxmlDialog,
            UsercontrolStyleSetter ucontrolStyleSetter,
            UsercontrolCreator1 ucontrolCreator1,
            XToMemory_Form xToM_FormImpl
            );

        /// <summary>
        /// 使わなくなったら呼び出してください。
        /// </summary>
        void Dispose();

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorSymbol">「Er:301;」といった文字列。ソースコード内を文字列検索しやすいように、数字ではなく文字列として指定します。</param>
        /// <param name="texttemplateBuilder_ParameterSetted"></param>
        /// <param name="log_Reports"></param>
        void CreateErrorReport(
            string errorSymbol,
            Builder_TexttemplateP1p texttemplateBuilder_ParameterSetted,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────

        /// <summary>
        /// エディター設定ファイルによって設定された「アプリケーション・モデル」を空っぽにします。
        /// </summary>
        void ClearProject(
            Control.ControlCollection formControls,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 日付別バックアップ設定。
        /// </summary>
        MemoryBackup MemoryBackup
        {
            get;
        }

        /// <summary>
        /// コントロール集モデル。
        /// </summary>
        MemoryForms MemoryForms
        {
            get;
        }

        /// <summary>
        /// 変数モデル。（Model Of Variables）
        /// </summary>
        MemoryVariables MemoryVariables
        {
            get;
        }

        /// <summary>
        /// ユーザー定義関数を格納したもの。
        /// </summary>
        MemoryFunctions MemoryFunctions
        {
            get;
        }

        /// <summary>
        /// テーブル一覧。
        /// </summary>
        MemoryTables MemoryTables
        {
            get;
        }

        /// <summary>
        /// コード・ファイル情報を格納したもの。
        /// </summary>
        MemoryCodefiles MemoryCodefiles
        {
            get;
        }


        /// <summary>
        /// トゥゲザー設定。（グローバル）
        /// </summary>
        MemoryTogethers MemoryTogethers
        {
            get;
        }

        /// <summary>
        /// バリデーター設定。（グローバル）
        /// </summary>
        MemoryValidators MemoryValidators
        {
            get;
        }

        /// <summary>
        /// スタイルシート設定ファイルで記述された内容。
        /// </summary>
        MemoryStyles MemoryStyles
        {
            get;
        }

        MemoryLogwriter MemoryLogwriter
        {
            get;
        }

        /// <summary>
        /// 各種ブラシ。
        /// </summary>
        MemoryBrushes MemoryBrushes
        {
            get;
        }

        MemoryRecordset MemoryRecordset
        {
            get;
        }

        /// <summary>
        /// ツール設定ファイルの内容。
        /// </summary>
        MemoryAatoolxml MemoryAatoolxml
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
