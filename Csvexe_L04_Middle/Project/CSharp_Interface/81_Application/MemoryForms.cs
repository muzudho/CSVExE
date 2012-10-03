using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Middle
{


    /// <summary>
    /// 旧名：DLGT_FcUc_ChildNodes
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="uct_Child"></param>
    /// <param name="bRemove"></param>
    /// <param name="bBreak"></param>
    public delegate void DELEGATE_Usercontrol_Children(
        string sKey, Usercontrol uct_Child, ref bool bRemove, ref bool bBreak);

    public interface MemoryForms
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// コントロール集のディクショナリー。
        /// </summary>
        void ForEach_Children(DELEGATE_Usercontrol_Children dlgt1);

        //────────────────────────────────────────
        #endregion




        #region 生成と破棄
        //────────────────────────────────────────

        void InitializeBeforeUse(
            Mainwnd_FormWrapping mainwnd_FormWrapping,
            ConfigurationtreeToFunction gcavToFunc,
            Form_Toolwindow form_Toolwindow,
            MemoryAatoolxmlDialog moToolConfigDlg,
            UsercontrolStyleSetter uctStyleSetter,
            UsercontrolCreator1 uctCreator1,
            XToMemory_Form xToM_FormImpl
            );

        /// <summary>
        /// new した直後の内容に戻します。
        /// </summary>
        void Clear(MemoryApplication owner_MemoryApplication);

        /// <summary>
        /// フォーム上の、コントロールをクリアーしていきます。
        /// </summary>
        /// <param name="formControls"></param>
        /// <param name="log_Reports"></param>
        void ClearForms(
            Control.ControlCollection formControls,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『コントロール設定ファイル』を読み取ります。
        /// </summary>
        void LoadFile(
            RecordUserformconfig fo_Record,
            Expression_Node_Filepath ec_Fopath_Forms,
            Log_Reports log_Reports
            );

        /// <summary>
        /// コントロールに、データソース、データターゲットを設定していきます。
        ///
        /// 『レイアウト設定ファイル』に記述されている、
        /// FILE列 で示された『ユーザーコントロール設定ファイル』を読み取っていきます。
        /// </summary>
        void SetupUsercontrolconfigs(
            TableUserformconfig sl_Config,
            Expression_Node_Filepath ec_Fopath_Forms,
            Log_Reports log_Reports
            );

        /// <summary>
        /// レイアウトを設定します。
        /// 
        /// ファイルパスの入っている変数の名前を指定します。
        /// </summary>
        /// <param name="listO_Table_Form">レイアウト設定ファイルの、ファイルパスが入っている変数名。</param>
        /// <param name="oFolderPath_forms">formsフォルダーの、ファイルパスが入っている変数名。</param>
        /// <param name="startupPath"></param>
        /// <param name="form"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        void SetupFormAndLoadUsercontrolconfigs(
            List<XenonTable> listO_Table_Form,
            Expression_Node_Filepath ec_Fopath_Forms,
            Form form,
            Log_Reports log_Reports
            );

        void P1_XToMemory_Userformconfig(
            TableUserformconfig fo_Config,
            XenonTable xenonTable_Form,
            Log_Reports log_Reports
            );

        void P2_CreateForm(
            TableUserformconfig sl_Config,
            Form form,
            Log_Reports log_Reports
            );

        void P3_ApplyStyleToUsercontrol(
            TableUserformconfig sl_Config,
            Log_Reports log_Reports
            );

        /// <summary>
        /// コントロール集のディクショナリー。
        /// 
        /// コントロールの名前の先頭文字を指定し、その名前で始まるコントロールのみ返す。
        /// </summary>
        Dictionary<string, Usercontrol> ItemsStartsWith(
            string sStarts,
            Log_Reports log_Reports
            );

        /// <summary>
        /// コントロール名を指定すると、コントロールを返します。
        /// カンマ区切りの文字列で、複数個のコントロール名を指定できること。
        /// </summary>
        /// <param name="e_FcName"></param>
        /// <param name="bRequired">該当しなかった場合に処理失敗扱いにするなら真。</param>
        /// <param name="log_Reports"></param>
        /// <returns>該当しなかった場合は空リストを返します。</returns>
        List<Usercontrol> GetUsercontrolsByName(
            Expression_Node_String ec_NameFc,
            bool bRequired,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ユーザー・コントロールを削除します。
        /// </summary>
        /// <param name="nFcName"></param>
        /// <returns></returns>
        bool RemoveUsercontrol(
            Expression_Node_String ec_NameFc,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ユーザー・コントロールを追加します。
        /// </summary>
        /// <param name="e_FcName">ユーザー・コントロール名。</param>
        /// <param name="fcUc"></param>
        /// <param name="log_Reports"></param>
        void PutUsercontrol(
            Expression_Node_String ec_NameFc,
            Usercontrol fcUc,
            Log_Reports log_Reports
            );

        /// <summary>
        /// デバッグ出力。
        /// </summary>
        void WriteDebug_ToConsole();

        /// <summary>
        /// コントロールに、最新のデータを表示します。
        /// </summary>
        /// <param name="together_Gcav">トゥゲザーの名前です。</param>
        /// <param name="togetherConfig_Gcav">トゥゲザー設定です。</param>
        /// <param name="log_Reports"></param>
        void RefreshDataByTogether(
            Configurationtree_Node together_Gcav,
            Configurationtree_Node togetherConfig_Gcav,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────

        /// <summary>
        /// 「　●」といった文字列。ステータスバーに表示される、アクションを起こしたコントロール名を連ねる前に置く。
        /// </summary>
        /// <param name="sFcName"></param>
        /// <param name="log_Reports"></param>
        void AddStatus_ActionUsercontrolNameBegin(Log_Reports log_Reports);

        /// <summary>
        /// ステータスバーに、アクションを起こしたコントロール名を追加します。
        /// </summary>
        /// <param name="sFcName"></param>
        /// <param name="log_Reports"></param>
        void AddStatus_ActionUsercontrolName(string sName_Fc, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// コントロールの存在の有無を返します。
        /// </summary>
        /// <param name="nFcName"></param>
        /// <returns>コントロールの存在の有無</returns>
        bool ContainsUsercontrolByName(
            Expression_Node_String ec_NameFc,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// メインウィンドウ_ラッパー。設定されていなければヌル。
        /// </summary>
        Mainwnd_FormWrapping Mainwnd_FormWrapping
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ツール・ウィンドウ。
        /// </summary>
        Form_Toolwindow Form_Toolwindow
        {
            get;
            //set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ユーザー・コントロールを生成するオブジェクト。
        /// </summary>
        UsercontrolCreator1 UsercontrolCreator1
        {
            get;
            set;
        }

        //────────────────────────────────────────

        UsercontrolStyleSetter UsercontrolStyleSetter
        {
            get;
        }

        /// <summary>
        /// このツール・コンフィグ・ダイアログボックスのモデルです。
        /// </summary>
        MemoryAatoolxmlDialog MemoryAatoolxmlDialog
        {
            get;
        }

        /// <summary>
        /// Functionexecuterを作るオブジェクト。使う前に設定してください。
        /// </summary>
        ConfigurationtreeToFunction ConfigurationtreeToFunction
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
