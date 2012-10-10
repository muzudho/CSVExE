using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Table
{


    /// <summary>
    /// フィールド定義。
    /// </summary>
    public interface Fielddefinition
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// string,int,boolを返します。未該当の時は空文字列を返します。
        /// </summary>
        /// <returns></returns>
        string GetTypeString();

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// フィールドの名前。入力したままの文字列。
        /// </summary>
        string Name_Humaninput
        {
            get;
            set;
        }

        /// <summary>
        /// フィールドの名前。トリムして英字大文字に加工（アッパー）した文字列。読み取り専用。
        /// </summary>
        string Name_Trimupper
        {
            get;
        }

        /// <summary>
        /// フィールドの型。
        /// </summary>
        Type Type
        {
            get;
            set;
        }

        /// <summary>
        /// フィールドについてのコメント。
        /// </summary>
        string Comment
        {
            set;
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
