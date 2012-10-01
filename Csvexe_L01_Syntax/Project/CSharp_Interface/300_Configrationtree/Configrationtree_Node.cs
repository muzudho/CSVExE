using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{

    public delegate void DELEGATE_Configurationtree_Nodes( Configurationtree_Node expr_Child, ref bool bBreak);

    /// <summary>
    /// ツリー構造状に記述されている設定の、記述ファイル、記述要素をたどれる仕組み。
    /// 
    /// 読み取り専用。
    /// </summary>
    public interface Configurationtree_Node
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// new された直後の内容に戻します。
        /// </summary>
        void Clear(string sName, Configurationtree_Node parent_OrNull, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 位置型のパンくずリスト。
        /// この設定の書かれているファイル名、要素等を示す文字列。
        /// 
        /// 無限ループを防ぐために、このメソッドの中で参照できるのは、
        /// 親元のオブジェクトのみです。
        /// </summary>
        void ToText_Locationbreadcrumbs(Log_TextIndented s);

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
        Configurationtree_Node GetParentByNodename(string sName, bool bRequired, Log_Reports log_Reports);

        /// <summary>
        /// ノード名を指定して、直近の子ノードを取得します。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="bRequired">偽を指定した時は、要素数0のリストを返す。</param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        List<Configurationtree_Node> GetChildrenByNodename(string sName, bool bRequired, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 関数なら「Sf:Cell;」といった関数名。
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// 親。なければヌル。
        /// </summary>
        Configurationtree_Node Parent
        {
            get;
        }

        /// <summary>
        /// 属性＝””。
        /// </summary>
        Dictionary_Configurationtree_String Dictionary_Attribute
        {
            get;
        }

        /// <summary>
        /// 子のリスト。
        /// </summary>
        List_Configurationtree_Node List_Child
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
