using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{



    /// <summary>
    /// 検索結果がどうだったらセーフ、結果がどうだったらエラーか、の判定条件です。
    /// 
    /// 検索の引数として指定するのに使います。
    /// </summary>
    public interface Request_Selecting
    {


        
        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 期待する検索ヒット数の区分。
        /// </summary>
        EnumHitcount EnumHitcount
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
