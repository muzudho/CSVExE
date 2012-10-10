using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Table
{

    /// <summary>
    /// セル値。型付き。
    /// (Value)
    /// </summary>
    public interface ValueHumaninput : Configurationtree_Node
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 文字列データを int型や bool型などに変換済みなら真、
        /// できていないなら偽。
        /// 空白は真。
        /// </summary>
        bool IsValidated
        {
            get;
        }

        /// <summary>
        /// 入力データそのままの形。
        /// (human input text)
        /// </summary>
        string Humaninput
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
