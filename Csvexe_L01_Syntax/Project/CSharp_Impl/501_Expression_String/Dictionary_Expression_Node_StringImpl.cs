using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{

    /// <summary>
    /// 
    /// </summary>
    public class Dictionary_Expression_Node_StringImpl : Dictionary_Expression_Node_String
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Dictionary_Expression_Node_StringImpl(Configurationtree_Node owner_Gcav)
        {
            this.Owner_Gcav = owner_Gcav;

            this.dicExpression_Item = new Dictionary<string, Expression_Node_String>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public void ToText_Snapshot(Log_TextIndented s)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ForSnapshot = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "ToText_Snapshot", log_Reports_ForSnapshot);

            log_Reports_ForSnapshot.BeginCreateReport(EnumReport.Dammy);
            //


            if (this.dicExpression_Item.Count < 1)
            {
                s.AppendI(0, "属性なし");
                s.Newline();
            }
            else
            {
                s.AppendI(0, "┌────────┐属性数＝[");
                s.Append(this.dicExpression_Item.Count);
                s.Append("]");
                s.Newline();


                foreach (Expression_Node_String ec_Item in this.dicExpression_Item.Values)
                {
                    ec_Item.ToText_Snapshot(s);
                }

                s.AppendI(0, "└────────┘");
                s.Newline();
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Reports_ForSnapshot.EndCreateReport();
            log_Method.EndMethod(log_Reports_ForSnapshot);
        }

        //────────────────────────────────────────

        public bool TrySelect(
            out string sResult,
            string sName,
            EnumHitcount request,//todo:正しい使い方を。
            Log_Reports log_Reports
            )
        {
            bool bResult;
            Expression_Node_String ec_String;

            bool bSuccessful = this.TrySelect(out ec_String, sName, request, log_Reports);
            if (bSuccessful)
            {
                sResult = ec_String.Execute_OnExpressionString(request, log_Reports);
                bResult = true;
            }
            else
            {
                sResult = "";
                bResult = false;
            }

            return bResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 子要素を追加します。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="nItem"></param>
        /// <param name="request"></param>
        /// <param name="log_Reports"></param>
        public void Set(
            string sName,
            Expression_Node_String ec_Item,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "Set", log_Reports);


            if (!this.dicExpression_Item.ContainsKey(sName))
            {
                // 新規項目なら

                // そのまま追加。
                this.dicExpression_Item.Add(sName, ec_Item);
            }
            else
            {
                // 既存項目なら

                // 上書きします。
                this.dicExpression_Item.Remove(sName);
                this.dicExpression_Item.Add(sName, ec_Item);


                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole(" 既に追加されていた項目を削除して、上書きしました。[" + sName + "]");
                }
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// デバッグするのに使う内容を取得します。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="log_Reports"></param>
        public void ToText_Debug(Log_TextIndented s, Log_Reports log_Reports)
        {
            s.Append(this.GetType().Name + "#DebugWrite:項目数＝[" + this.dicExpression_Item.Count + "]");
            s.Newline();
            s.Append(this.GetType().Name + "#DebugWrite:──────────ここから");
            s.Newline();
            foreach (KeyValuePair<string, Expression_Node_String> kvp in this.dicExpression_Item)
            {
                s.Append("key=[" + kvp.Key + "]　value=[" + kvp.Value.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]");
                s.Newline();
            }
            s.Append(this.GetType().Name + "#DebugWrite:──────────ここまで");
            s.Newline();
        }

        //────────────────────────────────────────

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("StrDic ");
            foreach (KeyValuePair<string, Expression_Node_String> kvP in this.dicExpression_Item)
            {
                sb.Append(kvP.Key);
                sb.Append("=値 ");
            }

            return sb.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e_Result">検索結果。</param>
        /// <param name="sName"></param>
        /// <param name="bRequired"></param>
        /// <param name="hits"></param>
        /// <param name="log_Reports"></param>
        /// <returns>検索結果が1件以上あれば真。</returns>
        public bool TrySelect(
            out Expression_Node_String ec_Result_Out,
            string sName,
            EnumHitcount hits,
            Log_Reports log_Reports//bug:ヌルのことがある？
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "TrySelect", log_Reports);

            //
            //
            //
            //
            bool bHit;

            if (this.dicExpression_Item.ContainsKey(sName))
            {
                // ヒット。
                ec_Result_Out = this.dicExpression_Item[sName];
                bHit = true;
            }
            else
            {
                // 一致なし。

                if (Utility_Hitcount.IsRequired(hits,log_Reports))
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー141！", log_Method);

                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("指定された名前[");
                        s.Append(sName);
                        s.Append("]は、“EDic(連想配列)”の中にありませんでした。");
                        s.Newline();

                        s.Append("┌────────┐キー一覧（個数＝[");
                        s.Append(this.dicExpression_Item.Count);
                        s.Append("]）");
                        s.Newline();
                        foreach (string sKey in this.dicExpression_Item.Keys)
                        {
                            s.Append("[");
                            s.Append(sKey);
                            s.Append("]");
                            s.Newline();
                        }
                        s.Append("└────────┘");
                        s.Newline();

                        // ヒント

                        if (null != this.Owner_Gcav)
                        {
                            s.Append("◆オーナー情報1");
                            s.Newline();
                            this.Owner_Gcav.ToText_Content(s);
                        }

                        if (0 < this.dicExpression_Item.Count)
                        {
                            foreach (Expression_Node_String e_Item in this.dicExpression_Item.Values)
                            {
                                // 最初の１個。
                                s.Append("◆最初の要素の親の情報。");
                                s.Newline();
                                Expression_Node_String e_Parent = e_Item.Parent_Expression;
                                e_Parent.ToText_Snapshot(s);
                                break;
                            }
                        }

                        //
                        // オーナーの情報。
                        s.Newline();
                        s.Newline();
                        s.Append("◆オーナー情報2。");
                        s.Newline();
                        this.owner_Gcav.ToText_Locationbreadcrumbs(s);


                        r.Message = s.ToString();
                        log_Reports.EndCreateReport();
                    }

                    ec_Result_Out = null;
                    bHit = false;
                }
                else
                {
                    // 該当しないキーを指定され、値を取得できなかったが、エラー報告しない。
                    Configurationtree_Node parent_Gcav = new Configurationtree_NodeImpl("!ハードコーディング_NStringDictionaryImpl#Get", null);
                    ec_Result_Out = new Expression_Leaf_StringImpl(null, parent_Gcav);
                    bHit = false;
                }
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return bHit;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 子＜●●＞要素のリスト。
        /// </summary>
        private Dictionary<string, Expression_Node_String> dicExpression_Item;

        public bool ContainsKey(string sName)
        {
            return this.dicExpression_Item.ContainsKey(sName);
        }

        //────────────────────────────────────────

        public Dictionary<string, Expression_Node_String>.KeyCollection Keys(
            Log_Reports log_Reports
            )
        {
            return this.dicExpression_Item.Keys;
        }

        //────────────────────────────────────────

        public Dictionary<string, Expression_Node_String>.ValueCollection Values(
            Log_Reports log_Reports
            )
        {
            return this.dicExpression_Item.Values;
        }

        //────────────────────────────────────────

        public int Count
        {
            get
            {
                return this.dicExpression_Item.Count;
            }
        }

        //────────────────────────────────────────

        private Configurationtree_Node owner_Gcav;

        /// <summary>
        /// このオブジェクトを持つ、オブジェクト。
        /// </summary>
        public Configurationtree_Node Owner_Gcav
        {
            get
            {
                return owner_Gcav;
            }
            set
            {
                owner_Gcav = value;
            }
        }

        //────────────────────────────────────────

        public void ForEach(DELEGATE_Expression_Attributes dlgt1)
        {
            bool bBreak = false;
            foreach (KeyValuePair<string, Expression_Node_String> kvp in this.dicExpression_Item)
            {
                dlgt1(kvp.Key, kvp.Value, ref bBreak);

                if (bBreak)
                {
                    break;
                }
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
