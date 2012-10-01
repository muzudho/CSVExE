using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{
    /// <summary>
    /// 名前。 GetElementByName(o_Name)のような引数として使う。
    /// 
    /// 例：バリデーターの引数、イベント名、トゥゲザーの名前、変数名。
    /// </summary>
    public interface XenonName
    {



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 名前の文字列。
        /// </summary>
        string SValue
        {
            get;
        }

        Configurationtree_Node Cur_Configurationtree
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
