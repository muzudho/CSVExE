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
        public MemoryAaeditorxml_EditorImpl(Givechapterandverse_Node parent_Cf)
            : base(parent_Cf)
        {
            this.sName_Editor = "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアー。
        /// </summary>
        public override void Clear()
        {
            this.parent_Givechapterandverse = null;

            this.sName_Editor = "";
            this.dictionary_Fsetvar_Givechapterandverse = new Dictionary_Fsetvar_GivechapterandverseImpl();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sName_Editor;

        /// <summary>
        /// エディター名
        /// </summary>
        public string SName_Editor
        {
            get
            {
                return sName_Editor;
            }
            set
            {
                sName_Editor = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }


}
