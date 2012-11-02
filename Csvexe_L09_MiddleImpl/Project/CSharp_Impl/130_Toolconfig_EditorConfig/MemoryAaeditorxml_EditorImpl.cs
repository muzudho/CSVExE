using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.MiddleImpl
{

    /// <summary>
    /// Aa_Editor.xml/＜ルート＞要素。
    /// </summary>
    public class MemoryAaeditorxml_EditorImpl : MemorySetverContainerImpl, MemoryAaeditorxml_Editor
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="parent_Cf">親ソース。</param>
        public MemoryAaeditorxml_EditorImpl(Configuration_Node parent_Cf)
            : base(parent_Cf)
        {
            this.name_Editor = "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアー。
        /// </summary>
        public override void Clear()
        {
            this.parent = null;

            this.name_Editor = "";
            this.dictionary_Fsetvar_Configurationtree = new Dictionary_Fsetvar_ConfigurationtreeImpl();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string name_Editor;

        /// <summary>
        /// エディター名
        /// </summary>
        public string Name_Editor
        {
            get
            {
                return name_Editor;
            }
            set
            {
                name_Editor = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }


}
