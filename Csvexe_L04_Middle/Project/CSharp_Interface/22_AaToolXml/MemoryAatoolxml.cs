using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{
    /// <summary>
    /// ツール設定ファイル・モデル。
    /// （Aa_Tool.xml）
    /// </summary>
    public interface MemoryAatoolxml
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// クリアー
        /// </summary>
        void Clear();

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 定型処理。
        /// </summary>
        void P101_LoadAatoolxml(
            MemoryApplication memoryApplication,
            Givechapterandverse_Node parent_Gcav,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ファイル読み込み。
        /// </summary>
        /// <param name="e_Fpath_Config_Tool"></param>
        /// <param name="log_Reports"></param>
        void LoadFile(
            Expression_Node_Filepath ec_Fpath_Config_Tool,
            Log_Reports log_Reports
            );

        /// <summary>
        /// プロジェクトを返します。該当がなければヌルを返します。
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="bRequired">該当がない場合にエラー扱いにするなら真</param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        MemoryAatoolxml_Editor GetEditorByName(string sName_Editor, bool bRequired, Log_Reports log_Reports);

        /// <summary>
        /// 『ツール設定ファイル』に最初に記述されているプロジェクトを返します。
        /// 該当がなければヌルを返します。
        /// </summary>
        /// <param name="bRequired">該当がない場合にエラー扱いにするなら真</param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        MemoryAatoolxml_Editor GetFirstEditor(bool bRequired, Log_Reports log_Reports);

        /// <summary>
        /// 
        /// デフォルト・プロジェクト名が指定されていれば、デフォルト・プロジェクトを返す。
        ///
        /// デフォルト・プロジェクト名が指定されていない場合、
        /// ツール設定ファイルの最初に記述されているプロジェクトを返す。
        /// 
        /// 該当がなければヌルを返します。
        /// 
        /// 
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        MemoryAatoolxml_Editor GetDefaultEditor(bool bRequired, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 利用者に、修正箇所を伝える情報。
        /// </summary>
        Givechapterandverse_Node Cur_Givechapterandverse
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// デフォルトで選択されているエディターの名前
        /// </summary>
        string SDefaultEditor
        {
            get;
            set;
        }

        /// <summary>
        /// ＜ｅｄｉｔｏｒ＞要素の名前つきリスト
        /// </summary>
        Dictionary_AatoolxmlEditor Dictionary_Editor
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
