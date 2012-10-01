using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.MiddleImpl;

namespace Xenon.Toolwindow
{
    /// <summary>
    /// ツール設定ダイアログのモデル
    /// 
    /// (Model Of Tool Config Dialog Implementation)
    /// </summary>
    public class MemoryAatoolxmlDialogImpl : MemoryAatoolxmlDialog
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryAatoolxmlDialogImpl()
        {
            this.Name_SelectedEditor = "";
            this.Name_Application = "";
            this.memoryAatoolxml = new MemoryAatoolxmlImpl();
            this.dictionary_Editor = new Dictionary_Fsetvar_GivechapterandverseImpl();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryAatoolxml memoryAatoolxml;

        /// <summary>
        /// ツール設定ファイル モデル。（MemoryAatoolxmlDialog Of Tool Config）
        /// </summary>
        public MemoryAatoolxml MemoryAatoolxml
        {
            get
            {
                return memoryAatoolxml;
            }
            set
            {
                memoryAatoolxml = value;
            }
        }

        //────────────────────────────────────────

        private Dictionary_Fsetvar_Givechapterandverse dictionary_Editor;

        /// <summary>
        /// エディター設定ファイル モデル
        /// </summary>
        public Dictionary_Fsetvar_Givechapterandverse Dictionary_Editor
        {
            get
            {
                return dictionary_Editor;
            }
            set
            {
                dictionary_Editor = value;
            }
        }

        //────────────────────────────────────────

        private string name_SelectedEditor;

        /// <summary>
        /// 選択しているプロジェクト名
        /// </summary>
        public string Name_SelectedEditor
        {
            get
            {
                return name_SelectedEditor;
            }
            set
            {
                name_SelectedEditor = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// このファイアログを開いているアプリケーションの名前
        /// </summary>
        private string name_Application;

        /// <summary>
        /// このファイアログを開いているアプリケーションの名前
        /// </summary>
        public string Name_Application
        {
            get
            {
                return name_Application;
            }
            set
            {
                name_Application = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
