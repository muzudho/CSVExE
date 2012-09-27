using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{

    public delegate void DLGT_Givechapterandverse_Children( Givechapterandverse_Node child_Gcav, ref bool bBreak);

    /// <summary>
    /// コンフィグ場所情報。設定ファイルの記述ミスの場所をたどれる仕組み。
    /// 
    /// 読み取り専用。
    /// </summary>
    public interface Givechapterandverse_Node
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// new された直後の内容に戻します。
        /// </summary>
        void Clear(string sName, Givechapterandverse_Node parent_OrNull, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 問題が起こったときに、設定ファイル等の修正箇所を示す説明などに利用。
        /// 
        /// 無限ループを防ぐために、このメソッドの中で参照できるのは、
        /// 親元のオブジェクトのみです。
        /// </summary>
        void ToText_Path(Log_TextIndented s);

        /// <summary>
        /// 問題が起こったときに、設定ファイル等で、どのような内容だったのかを示す説明などに利用。
        /// 
        /// 無限ループを防ぐために、このメソッドの中では、
        /// 親を参照してはいけません。
        /// 
        /// 同じインスタンスの、ToText_Content の中で使うことができます。
        /// </summary>
        void ToText_Content(Log_TextIndented s);

        /// <summary>
        /// ノード名を指定して、直近の親ノードを取得します。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="bRequired"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        Givechapterandverse_Node GetParentByNodename(string sName, bool bRequired, Log_Reports log_Reports);

        /// <summary>
        /// ノード名を指定して、直近の子ノードを取得します。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="bRequired">偽を指定した時は、要素数0のリストを返す。</param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        List<Givechapterandverse_Node> GetChildrenByNodename(string sName, bool bRequired, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 関数なら「Sf:Cell;」といった関数名。
        /// </summary>
        string SName
        {
            get;
        }

        /// <summary>
        /// 親。なければヌル。
        /// </summary>
        Givechapterandverse_Node Parent_Givechapterandverse
        {
            get;
        }

        /// <summary>
        /// 属性＝””。
        /// </summary>
        DictionaryGivechapterandverse_String DictionaryGivechapterandverse_SAttr
        {
            get;
        }

        /// <summary>
        /// 子要素のリスト。
        /// </summary>
        ListGivechapterandverse_Node ListGivechapterandverse_Child
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
