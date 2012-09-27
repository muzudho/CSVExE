using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Table
{
    abstract public class XenonValue_AbstractImpl : Givechapterandverse_NodeImpl, XenonValue
    {



        #region 生成と破棄
        //────────────────────────────────────────        

        public XenonValue_AbstractImpl(string sConfigStack)
            : base("ノード名未指定", new Givechapterandverse_NodeImpl(sConfigStack, null))
        {
            this.bSpaced = true;
            this.sHumaninput = "";
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
        protected string sHumaninput;

        /// <summary>
        /// 入力データそのままの形。
        /// </summary>
        public virtual string SHumaninput
        {
            get
            {
                return sHumaninput;
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

                bValidated = true;
                this.sHumaninput = value;
            }
        }

        //────────────────────────────────────────        

        /// <summary>
        /// 文字列データを int型や bool型などに変換済みなら真、
        /// できていないなら偽。
        /// 空白は真。
        /// ・派生クラスでセット使用。
        /// </summary>
        protected bool bValidated;

        /// <summary>
        /// 文字列データを int型や bool型などに変換済みなら真、
        /// できていないなら偽。
        /// </summary>
        /// <returns></returns>
        public bool BValidated
        {
            get
            {
                return bValidated;
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
