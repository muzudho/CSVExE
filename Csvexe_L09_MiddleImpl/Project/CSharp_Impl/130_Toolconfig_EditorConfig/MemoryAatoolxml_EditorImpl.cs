using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.MiddleImpl
{

    /// <summary>
    /// Aa_Tool.xml/＜editor＞要素。
    /// </summary>
    public class MemoryAatoolxml_EditorImpl : MemorySetverContainerImpl ,MemoryAatoolxml_Editor
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="parent_Cf">親設定。</param>
        public MemoryAatoolxml_EditorImpl(Givechapterandverse_Node parent_Cf)
            : base(parent_Cf)
        {
            this.sName = "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアー。
        /// </summary>
        public override void Clear()
        {
            this.parent_Givechapterandverse = null;

            this.sName = "";
            this.dictionary_Fsetvar_Givechapterandverse = new Dictionary_Fsetvar_GivechapterandverseImpl();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sName;

        /// <summary>
        /// エディター名
        /// </summary>
        public string SName
        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }


}
