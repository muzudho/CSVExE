using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{

    /// <summary>
    /// 主に、子要素を入れるのに使う。
    /// </summary>
    public class ListGivechapterandverse_NodeImpl : ListGivechapterandverse_Node
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public ListGivechapterandverse_NodeImpl(Givechapterandverse_Node owner_Gcav)
        {
            this.owner_Givechapterandverse = owner_Gcav;
            this.list_Givechapterandverse = new List<Givechapterandverse_Node>();
        }

        //────────────────────────────────────────

        /// <summary>
        /// リストを空にする。
        /// </summary>
        /// <param name="log_Reports"></param>
        public void Clear(
            Log_Reports log_Reports
            )
        {
            this.list_Givechapterandverse.Clear();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public virtual void ToText_Content(Log_TextIndented s)
        {
            s.Increment();


            //
            // 子要素
            foreach (Givechapterandverse_Node cur_Gcav in this.list_Givechapterandverse)
            {
                cur_Gcav.ToText_Content(s);
            }

            // 子要素しかありません。

            s.Decrement();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 追加。
        /// </summary>
        public void Add(
            Givechapterandverse_Node cur_Gcav,
            Log_Reports log_Reports
            )
        {
            this.list_Givechapterandverse.Add(cur_Gcav);
        }

        //────────────────────────────────────────

        /// <summary>
        /// @Deprecated
        /// 一覧。
        /// </summary>
        public List<Givechapterandverse_Node> SelectList(
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            return list_Givechapterandverse;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ノードを、リストのindexで指定して、取得します。
        /// 該当がなければヌルを返します。
        /// </summary>
        /// <param select="index">リストのインデックス</param>
        /// <param select="bRequired">該当するデータがない場合、エラー</param>
        /// <param select="log_Reports">警告メッセージ</param>
        /// <returns></returns>
        public Givechapterandverse_Node GetNodeByIndex(
            int nIndex,
            bool bRequired,
            Log_Reports log_Reports
            )
        {

            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "GetNodeByIndex",log_Reports);
            //
            //
            //
            //

            Givechapterandverse_Node gcav_FoundItem;

            if (0 <= nIndex && nIndex < this.list_Givechapterandverse.Count)
            {
                gcav_FoundItem = this.list_Givechapterandverse[nIndex];
            }
            else
            {
                gcav_FoundItem = null;

                if (bRequired)
                {
                    // エラーとして扱います。
                    goto gt_Error_BadIndex;
                }
            }

            goto gt_EndMethod;
        //
        //
        #region 異常系
        //────────────────────────────────────────
        gt_Error_BadIndex:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー097！!", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("指定されたノードは存在しませんでした。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append("リストのインデックス=[");
                sb.Append(nIndex);
                sb.Append("]");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // ヒント

                r.SMessage = sb.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        #endregion
        //
        //
    gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return gcav_FoundItem;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Givechapterandverse_Node owner_Givechapterandverse;

        public Givechapterandverse_Node Owner_Givechapterandverse
        {
            get
            {
                return owner_Givechapterandverse;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ＜f-●●＞要素のリスト。
        /// </summary>
        private List<Givechapterandverse_Node> list_Givechapterandverse;

        //────────────────────────────────────────

        public void ForEach(DLGT_Givechapterandverse_Children dlgt1)
        {
            bool bBreak = false;
            foreach (Givechapterandverse_Node cur_Gcav in this.list_Givechapterandverse)
            {
                dlgt1(cur_Gcav, ref bBreak);

                if (bBreak)
                {
                    break;
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 個数。
        /// </summary>
        public int NCount
        {
            get
            {
                return list_Givechapterandverse.Count;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
