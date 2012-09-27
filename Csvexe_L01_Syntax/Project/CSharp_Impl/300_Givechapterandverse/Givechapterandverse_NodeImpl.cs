using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{

    /// <summary>
    /// 設定ファイル等から読み込んだデータを保持するオブジェクトは、これを継承することになる。
    /// </summary>
    public class Givechapterandverse_NodeImpl : Givechapterandverse_Node
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="parent_Gcav_OrNull"></param>
        public Givechapterandverse_NodeImpl(string sName, Givechapterandverse_Node parent_Gcav_OrNull)
        {
            this.sName = sName;
            this.parent_Givechapterandverse = parent_Gcav_OrNull;
            this.listGivechapterandverse_Child = new ListGivechapterandverse_NodeImpl(this);

            this.dictionaryGivechapterandverse_SAttr = new DictionaryGivechapterandverse_StringImpl(this);
        }

        //────────────────────────────────────────

        /// <summary>
        /// new された直後の内容に戻します。
        /// </summary>
        public void Clear( string sName, Givechapterandverse_Node parent_Gcav_OrNull, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "Clear", log_Reports);

            //
            //
            //
            // 親
            //
            //
            //
            this.Parent_Givechapterandverse = parent_Gcav_OrNull;


            //
            //
            //
            // 自
            //
            //
            //
            this.SName = sName;


            //
            //
            //
            // 属性
            //
            //
            //
            this.Dictionary_SAttribute_Givechapterandverse.Clear( this, log_Reports);


            //
            //
            //
            // 子
            //
            //
            //
            this.List_ChildGivechapterandverse.Clear(log_Reports);


            //
            //
            //
            // 親への連結は維持。
            //
            //
            //

            //
            //
            log_Method.EndMethod(log_Reports);
        }
        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 問題箇所ヒント。
        /// 
        /// 問題が起こったときに、設定ファイル等の修正箇所を示す説明などに利用。
        /// </summary>
        public virtual void ToText_Path(Log_TextIndented s)
        {
            s.Increment();

            // 親のノード名を追加。
            if (null != this.Parent_Givechapterandverse)
            {
                this.Parent_Givechapterandverse.ToText_Path(s);
                s.Append("/");
            }
            else
            {
                // このクラスがトップ・ノードだった場合。
                s.Append("ソース：");
            }

            // 自分のノード名を追加。
            s.Append(this.SName);

            s.Decrement();
        }

        public virtual void ToText_Content(Log_TextIndented s)
        {
            s.Increment();

            // ノード名
            s.AppendI(0, "<[");
            s.Append(this.SName);
            s.Append("]　");

            // クラス
            s.Append("[");
            s.Append(this.GetType().Name);
            s.Append("]クラス");

            s.Append(">");
            s.NewLine();


            //
            // string 属性
            //
            s.AppendI(1, "string属性");
            s.NewLine();
            this.Dictionary_SAttribute_Givechapterandverse.ForEach(delegate(string sKey, string sValue, ref bool bBreak)
            {
                s.AppendI(1, "[");
                s.Append(sKey);
                s.Append("]=[");
                s.Append(sValue);
                s.Append("]");
                s.NewLine();
            });


            //
            // 子要素
            //
            this.List_ChildGivechapterandverse.ToText_Content(s);


            s.AppendI(0, "</");
            s.Append(this.GetType().Name);
            s.Append("クラス>");
            s.NewLine();


            s.Decrement();
        }

        //────────────────────────────────────────

        /// <summary>
        /// ノード名を指定して、直近の親ノードを取得したい。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="bRequired">偽を指定した時は、不一致の時ヌルを返す。</param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public virtual Givechapterandverse_Node GetParentByNodename(string sName, bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "GetParentByNodename",log_Reports);
            //
            //
            Givechapterandverse_Node result;

            Givechapterandverse_Node err_Parent_Gcav;
            if (log_Reports.BSuccessful)
            {
                if (null != this.Parent_Givechapterandverse)
                {
                    // 親要素があるとき

                    if (sName == this.Parent_Givechapterandverse.SName)
                    {
                        // ノード名が一致
                        result = this.Parent_Givechapterandverse;
                    }
                    else
                    {
                        // ノード名が一致しないとき
                        result = this.Parent_Givechapterandverse.GetParentByNodename(sName, bRequired, log_Reports);
                    }
                }
                else
                {
                    // 親要素がないとき

                    result = null;
                    err_Parent_Gcav = null;
                    goto gt_Error_NotFoundParent;
                }
            }
            else
            {
                // 既にエラーが出ているとき

                result = null;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundParent:
            if (log_Reports.CanCreateReport)
            {
                if (bRequired)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー501！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();
                    s.Append("親要素の取得に失敗しました。");
                    s.NewLine();


                    s.Append("指定ノード名[");
                    s.Append(sName);
                    s.Append("]");
                    s.NewLine();

                    s.Append("親要素はヌルです。");
                    s.NewLine();

                    if (null != err_Parent_Gcav)
                    {
                        s.Append("親要素ノード名[");
                        s.Append(err_Parent_Gcav.SName);
                        s.Append("]");
                        s.NewLine();
                    }

                    // ヒント
                    s.Append(r.Message_Givechapterandverse(this));

                    r.SMessage = s.ToString();
                    log_Reports.EndCreateReport();
                }
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ノード名を指定して、直近の子ノードを取得したい。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="bRequired">偽を指定した時は、要素数0のリストを返す。</param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public List<Givechapterandverse_Node> GetChildrenByNodename(string sName, bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "GetChildrenByNodename", log_Reports);
            //
            //
            List<Givechapterandverse_Node> result = new List<Givechapterandverse_Node>();

            if (log_Reports.BSuccessful)
            {
                this.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node child_Gcav, ref bool bBreak)
                {
                    if (sName == child_Gcav.SName)
                    {
                        // ノード名が一致
                        result.Add(child_Gcav);
                    }
                    else
                    {
                        // ノード名が一致しないとき

                    }
                });
            }
            else
            {
                // 既にエラーが出ているとき
                goto gt_EndMethod;
            }

            if (result.Count < 1 && bRequired)
            {
                if (bRequired)
                {
                    goto gt_Error_EmptyHitChild;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
            //────────────────────────────────────────
        gt_Error_EmptyHitChild:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー502！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("該当した子要素がありませんでした。");
                s.NewLine();


                s.Append("指定ノード名[");
                s.Append(sName);
                s.Append("]");
                s.NewLine();

                // ヒント
                s.Append(r.Message_Givechapterandverse(this));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
            //────────────────────────────────────────
            #endregion
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Givechapterandverse_Node parent_Givechapterandverse;

        /// <summary>
        /// 親要素。なければヌル。
        /// </summary>
        public Givechapterandverse_Node Parent_Givechapterandverse
        {
            get
            {
                return parent_Givechapterandverse;
            }
            set
            {
                parent_Givechapterandverse = value;
            }
        }

        //────────────────────────────────────────

        private string sName;

        /// <summary>
        /// ノード（要素、属性）の名前。fncや arg など。
        /// </summary>
        public string SName
        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
            }
        }

        //────────────────────────────────────────

        private ListGivechapterandverse_Node listGivechapterandverse_Child;

        /// <summary>
        /// 子要素のリスト。（格納順序を保つこと）
        /// </summary>
        public ListGivechapterandverse_Node List_ChildGivechapterandverse
        {
            get
            {
                return listGivechapterandverse_Child;
            }
        }

        //────────────────────────────────────────

        private DictionaryGivechapterandverse_String dictionaryGivechapterandverse_SAttr;

        public DictionaryGivechapterandverse_String Dictionary_SAttribute_Givechapterandverse
        {
            get
            {
                return this.dictionaryGivechapterandverse_SAttr;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
