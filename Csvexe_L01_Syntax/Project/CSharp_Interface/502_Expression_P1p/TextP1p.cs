using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Xenon.Syntax
{


    /// <summary>
    /// 「%1%」や、「%2%」といったシンボルを含むテキストです。
    /// </summary>
    public interface TextP1p
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// Expression系オブジェクトを作成します。
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        Expression_Node_String Compile(
            Log_Reports log_Reports
            );

        /// <summary>
        /// 実行します。
        /// </summary>
        /// <returns></returns>
        String Perform();

        /// <summary>
        /// 「%1%」、「%2%」といった記号を探し、リストに「1」、「2」といった数字に置き換えて返します。
        /// </summary>
        /// <returns></returns>
        List<int> GetP1pNumbers(
            DicExpression_Node_String dic_Expr_Attr,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 「%1%:%2%」といった文字列（テキスト_テンプレートと呼ぶ）。
        /// </summary>
        string Text
        {
            get;
            set;
        }

        /// <summary>
        /// [1]=101
        /// [2]=赤
        /// といったディクショナリー。
        /// 
        /// キーは %1%や、%2%といった名前の中の数字。[1]から始める。
        /// Xn_L05_E:E_FtextTemplate#E_ExecuteでAddされます。
        /// </summary>
        Dictionary<int, string> Dictionary_NumberAndValue_Parameter
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
