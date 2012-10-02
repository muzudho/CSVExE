using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;


namespace Xenon.Middle
{



    #region デリゲータ

    /// <summary>
    /// プロジェクトを選択したとき。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="projectValid">エディター設定ファイルを読み込めていれば真</param>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate void DELEGATE_OnEditorSelected(
        object sender,
        MemoryAatoolxml_Editor selectedEditorElm,
        bool bProjectValid,
        Log_Reports log_Reports
        );

    #endregion



    /// <summary>
    /// ツール・ウィンドウ。
    /// 
    /// 旧名：Form_ToolConfig
    /// </summary>
    public interface Form_Toolwindow
    {

        

        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        event DELEGATE_OnEditorSelected OnEditorSelected;

        //────────────────────────────────────────
        #endregion
        


        #region 生成と破棄
        //────────────────────────────────────────

        void InitializeBeforeUse(
            MemoryApplication owner_MemoryApplication
            );

        /// <summary>
        /// クリアー
        /// </summary>
        void Clear();

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        UserControl UctlstNameProject
        {
            get;
        }

        UserControl PctxtFpathProjectcnf
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
