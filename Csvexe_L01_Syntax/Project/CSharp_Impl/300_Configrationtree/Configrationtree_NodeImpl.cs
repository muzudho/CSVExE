using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{

    /// <summary>
    /// 設定ファイル等から読み込んだデータを保持するオブジェクトは、これを継承することになる。
    /// </summary>
    public class Configurationtree_NodeImpl : Configurationtree_Node
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="parent_Gcav_OrNull"></param>
        public Configurationtree_NodeImpl(string sName, Configurationtree_Node parent_Gcav_OrNull)
        {
            this.name = sName;
            this.parent = parent_Gcav_OrNull;
            this.list_Child = new List_Configurationtree_NodeImpl(this);

            this.dictionary_Attribute = new Dictionary_Configurationtree_StringImpl(this);
        }

        //────────────────────────────────────────

        /// <summary>
        /// new された直後の内容に戻します。
        /// </summary>
        public void Clear( string sName, Configurationtree_Node parent_Gcav_OrNull, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "Clear", log_Reports);

            //
            //
            //
            // 親
            //
            //
            //
            this.Parent = parent_Gcav_OrNull;


            //
            //
            //
            // 自
            //
            //
            //
            this.Name = sName;


            //
            //
            //
            // 属性
            //
            //
            //
            this.Dictionary_Attribute.Clear( this, log_Reports);


            //
            //
            //
            // 子
            //
            //
            //
            this.list_Child.Clear(log_Reports);


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
        public virtual void ToText_Locationbreadcrumbs(Log_TextIndented s)
        {
            s.Increment();

            // 親のノード名を追加。
            if (null != this.Parent)
            {
                this.Parent.ToText_Locationbreadcrumbs(s);
                s.Append("/");
            }
            else
            {
                // このクラスがトップ・ノードだった場合。
                s.Append("ソース：");
            }

            // 自分のノード名を追加。
            s.Append(this.Name);

            s.Decrement();
        }

        public virtual void ToText_Content(Log_TextIndented s)
        {
            s.Increment();

            // ノード名
            s.AppendI(0, "<[");
            s.Append(this.Name);
            s.Append("]　");

            // クラス
            s.Append("[");
            s.Append(this.GetType().Name);
            s.Append("]クラス");

            s.Append(">");
            s.Newline();


            //
            // string 属性
            //
            s.AppendI(1, "string属性");
            s.Newline();
            this.Dictionary_Attribute.ForEach(delegate(string sKey, string sValue, ref bool bBreak)
            {
                s.AppendI(1, "[");
                s.Append(sKey);
                s.Append("]=[");
                s.Append(sValue);
                s.Append("]");
                s.Newline();
            });


            //
            // 子要素
            //
            this.list_Child.ToText_Content(s);


            s.AppendI(0, "</");
            s.Append(this.GetType().Name);
            s.Append("クラス>");
            s.Newline();


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
        public virtual Configurationtree_Node GetParentByNodename(string sName, bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "GetParentByNodename",log_Reports);
            //
            //
            Configurationtree_Node result;

            Configurationtree_Node err_Parent_Gcav;
            if (log_Reports.Successful)
            {
                if (null != this.Parent)
                {
                    // 親要素があるとき

                    if (sName == this.Parent.Name)
                    {
                        // ノード名が一致
                        result = this.Parent;
                    }
                    else
                    {
                        // ノード名が一致しないとき
                        result = this.Parent.GetParentByNodename(sName, bRequired, log_Reports);
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
                    s.Newline();


                    s.Append("指定ノード名[");
                    s.Append(sName);
                    s.Append("]");
                    s.Newline();

                    s.Append("親要素はヌルです。");
                    s.Newline();

                    if (null != err_Parent_Gcav)
                    {
                        s.Append("親要素ノード名[");
                        s.Append(err_Parent_Gcav.Name);
                        s.Append("]");
                        s.Newline();
                    }

                    // ヒント
                    s.Append(r.Message_Configurationtree(this));

                    r.Message = s.ToString();
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
        public List<Configurationtree_Node> GetChildrenByNodename(string sName, bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "GetChildrenByNodename", log_Reports);
            //
            //
            List<Configurationtree_Node> result = new List<Configurationtree_Node>();

            if (log_Reports.Successful)
            {
                this.list_Child.ForEach(delegate(Configurationtree_Node child_Gcav, ref bool bBreak)
                {
                    if (sName == child_Gcav.Name)
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
                s.Newline();


                s.Append("指定ノード名[");
                s.Append(sName);
                s.Append("]");
                s.Newline();

                // ヒント
                s.Append(r.Message_Configurationtree(this));

                r.Message = s.ToString();
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

        private Configurationtree_Node parent;

        /// <summary>
        /// 親要素。なければヌル。
        /// </summary>
        public Configurationtree_Node Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        //────────────────────────────────────────

        private string name;

        /// <summary>
        /// ノード（要素、属性）の名前。fncや arg など。
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //────────────────────────────────────────

        private List_Configurationtree_Node list_Child;

        /// <summary>
        /// 子要素のリスト。（格納順序を保つこと）
        /// </summary>
        public List_Configurationtree_Node List_Child
        {
            get
            {
                return list_Child;
            }
        }

        //────────────────────────────────────────

        private Dictionary_Configurationtree_String dictionary_Attribute;

        public Dictionary_Configurationtree_String Dictionary_Attribute
        {
            get
            {
                return this.dictionary_Attribute;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
