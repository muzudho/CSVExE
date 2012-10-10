using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Table
{
    abstract public class AbstractValue_HumaninputImpl : Configurationtree_NodeImpl, ValueHumaninput
    {



        #region 生成と破棄
        //────────────────────────────────────────        

        public AbstractValue_HumaninputImpl(string sConfigStack)
            : base("ノード名未指定", new Configurationtree_NodeImpl(sConfigStack, null))
        {
            this.bSpaced = true;
            this.humaninput = "";
        }

        //────────────────────────────────────────        
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// デバッグ用情報。
        /// </summary>
        abstract public override void ToText_Content(Log_TextIndented txt);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 入力データそのままの形。
        /// ・派生クラスでセット使用。
        /// </summary>
        protected string humaninput;

        /// <summary>
        /// 入力データそのままの形。
        /// </summary>
        public virtual string Humaninput
        {
            get
            {
                return humaninput;
            }
            set
            {
                if ("" == value.Trim())
                {
                    bSpaced = true;
                }
                else
                {
                    bSpaced = false;
                }

                isValidated = true;
                this.humaninput = value;
            }
        }

        //────────────────────────────────────────        

        /// <summary>
        /// 文字列データを int型や bool型などに変換済みなら真、
        /// できていないなら偽。
        /// 空白は真。
        /// ・派生クラスでセット使用。
        /// </summary>
        protected bool isValidated;

        /// <summary>
        /// 文字列データを int型や bool型などに変換済みなら真、
        /// できていないなら偽。
        /// </summary>
        /// <returns></returns>
        public bool IsValidated
        {
            get
            {
                return isValidated;
            }
        }

        //────────────────────────────────────────        

        /// <summary>
        /// 空欄なら真。
        /// 
        /// 空白のみの場合、真。
        /// 空白以外の文字が含まれていれば偽。
        /// ・派生クラスでセット使用。
        /// </summary>
        protected bool bSpaced;

        /// <summary>
        /// 空白のみの場合、真。
        /// 空白以外の文字が含まれていれば偽。
        /// </summary>
        /// <returns></returns>
        public bool IsSpaces()
        {
            return bSpaced;
        }

        //────────────────────────────────────────        
        #endregion



    }
}
