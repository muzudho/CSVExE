using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Lib
{


    /// <summary>
    /// 部品番号のシンボル１個分の、スプライトのリスト。
    /// </summary>
    public class Memory4aPartsnumbersymbolspritesImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Memory4aPartsnumbersymbolspritesImpl()
        {
            this.memoryPartsnumbersprite_Symboldefinition = new Memory4bSpritePartsnumberImpl();
            this.list_MemoryPartsnumbersprite_Expression = new List<Memory4bSpritePartsnumber>();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Memory4bSpritePartsnumber memoryPartsnumbersprite_Symboldefinition;

        /// <summary>
        /// 「a=100」や「b=a+0」といった、シンボルの数字定義を行っているスプライト。
        /// </summary>
        public Memory4bSpritePartsnumber MemoryPartsnumbersprite_Symboldefinition
        {
            get
            {
                return this.memoryPartsnumbersprite_Symboldefinition;
            }
            set
            {
                this.memoryPartsnumbersprite_Symboldefinition = value;
            }
        }

        //────────────────────────────────────────

        private List<Memory4bSpritePartsnumber> list_MemoryPartsnumbersprite_Expression;

        /// <summary>
        /// 「b+0」「b+1」といった、シンボルの数字定義「以外」の部品番号スプライト。
        /// </summary>
        public List<Memory4bSpritePartsnumber> List_MemoryPartsnumbersprite_Expression
        {
            get
            {
                return this.list_MemoryPartsnumbersprite_Expression;
            }
        }

        //────────────────────────────────────────
        #endregion



    }



}
