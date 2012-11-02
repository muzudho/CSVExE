using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{


    /// <summary>
    /// Aa_Tool.xml/＜editor＞ と、 Aa_Editor.xml/＜ルート＞ が該当。
    /// </summary>
    public  interface MemorySetvarContainer
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// クリアー。
        /// </summary>
        void Clear();

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// 『エディター設定ファイル』読取
        /// 
        /// 
        /// </summary>
        void LoadFile_Aaxml(
            Expression_Node_Filepath expr_Fpath_Config_Editor,
            MemoryVariables moVariables,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────

        /// <summary>
        /// ＜ｆ－ｓｅｔ－ｖａｒ＞要素の名前を指定して、値を取り出します。（ファイル・パスとします）
        /// 該当がなければヌルを返します。
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="bRequired">該当がない場合にエラー扱いにするなら真</param>
        /// <returns></returns>
        Expression_Node_Filepath GetFilepathByFsetvarname(
            string sName_Fsetvar,
            MemoryVariables moVariables,
            bool bRequired,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────

        /// <summary>
        /// 内容をデバッグ出力。
        /// </summary>
        void WriteDebug_ToConsole(Dictionary_Fsetvar_Configurationtree dic_Fsetvar, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ＜ｆ－ｓｅｔ－ｖａｒ＞要素の名前つきリスト
        /// </summary>
        Dictionary_Fsetvar_Configurationtree Dictionary_Fsetvar_Configurationtree
        {
            get;
            set;
        }

        /// <summary>
        /// メンテナンス要素。
        /// </summary>
        Configuration_Node Parent
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }



}
