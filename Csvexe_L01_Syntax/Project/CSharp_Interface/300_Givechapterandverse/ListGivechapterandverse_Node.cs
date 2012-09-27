using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{

    /// <summary>
    /// ノードのリスト。
    /// </summary>
    public interface ListGivechapterandverse_Node
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// リストを空にする。
        /// </summary>
        /// <param name="log_Reports"></param>
        void Clear(
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

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
        /// 要素の追加。
        /// </summary>
        void Add(
            Givechapterandverse_Node cur,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ノードのリスト。
        /// </summary>
        List<Givechapterandverse_Node> SelectList(
            Request_Selecting request,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ノードを、リストのindexで指定して、取得します。
        /// 該当がなければヌルを返します。
        /// </summary>
        /// <param select="index">リストのインデックス</param>
        /// <param select="bRequired">該当するデータがない場合、エラー</param>
        /// <param select="log_Reports">警告メッセージ</param>
        /// <returns></returns>
        Givechapterandverse_Node GetNodeByIndex(
            int nIndex,
            bool bRequired,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// それぞれの要素。
        /// </summary>
        /// <param name="dlgt1"></param>
        void ForEach(DLGT_Givechapterandverse_Children dlgt1);

        /// <summary>
        /// 要素の個数。
        /// </summary>
        int NCount
        {
            get;
        }

        /// <summary>
        /// このリストの持ち主要素。
        /// </summary>
        Givechapterandverse_Node Owner_Givechapterandverse
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }


}
