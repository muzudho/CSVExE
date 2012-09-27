using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// GlobalList.txtのモデル。
    /// 
    /// (Model Of Global List Impl)
    /// </summary>
    public class MemoryGloballistImpl : MemoryGloballist
    {






        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryGloballistImpl()
        {
            this.dictionary_Typesection = new Dictionary<string, Dictionary<int, MemoryGloballistLine>>();
        }

        //────────────────────────────────────────
        #endregion


        
        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear()
        {
            this.dictionary_Typesection.Clear();
        }

        //────────────────────────────────────────

        /// <summary>
        /// GlobalList.txtの一行分のデータを追加します。
        /// </summary>
        /// <param name="glLine"></param>
        public void AddLine(MemoryGloballistLine glLine)
        {
            Dictionary<int, MemoryGloballistLine> glLineList;

            if (this.dictionary_Typesection.ContainsKey(glLine.SType))
            {
                glLineList = this.dictionary_Typesection[glLine.SType];
            }
            else
            {
                glLineList = new Dictionary<int, MemoryGloballistLine>();
                this.dictionary_Typesection.Add(glLine.SType, glLineList);
            }

            glLineList.Add(glLine.NNumber, glLine);
        }

        //────────────────────────────────────────
        #endregion

        

        #region プロパティー
        //────────────────────────────────────────

        protected Dictionary<string, Dictionary<int, MemoryGloballistLine>> dictionary_Typesection;

        /// <summary>
        /// 変数の型毎に区切られた、変数のリスト。
        /// 
        /// [変数の型名,[変数の番号,GlLine]]
        /// </summary>
        public Dictionary<string, Dictionary<int, MemoryGloballistLine>> Dictionary_Typesection
        {
            set
            {
                dictionary_Typesection = value;
            }
            get
            {
                return dictionary_Typesection;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
