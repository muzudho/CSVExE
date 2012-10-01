﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Xenon.Syntax
{

    /// <summary>
    /// </summary>
    public class Expression_P1pImpl : Expression_Node_String
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Expression_P1pImpl(Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav)
        {
            this.parent_Expression = parent_Expression;
            this.cur_Givechapterandverse = cur_Gcav;

            this.requestItems = Request_SelectingImpl.Unconstraint;

            this.dicS_P1p = new Dictionary<int, string>();
            this.listExpression_Child = new ListExpression_Node_StringImpl(this);//使いません。
            this.dictionary_Expression_Attribute = new DicExpression_Node_StringImpl(this.Cur_Givechapterandverse);
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
            s.Increment();

            s.Append("「E■[");
            s.Append(this.Cur_Givechapterandverse.Name);
            s.Append("]　");
            s.Append(this.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ForSnapshot));
            s.Append("」");
            s.Newline();

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            s.Decrement();
            log_Reports_ForSnapshot.EndCreateReport();
            log_Method.EndMethod(log_Reports_ForSnapshot);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 属性。
        /// </summary>
        /// <param name="out_E_Result">検索結果。</param>
        /// <param name="sName"></param>
        /// <param name="bRequired"></param>
        /// <param name="request"></param>
        /// <param name="log_Reports"></param>
        /// <returns>検索結果が1件以上あれば真。</returns>
        public bool TrySelectAttribute(
            out Expression_Node_String ec_Result_Out,
            string sName,
            bool bRequired,
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            // 使いません。
            ec_Result_Out = new Expression_Node_StringImpl(this, this.Cur_Givechapterandverse);
            return false;
        }

        //────────────────────────────────────────

        public bool TrySelectAttribute(
            out string sResult_Out,
            string sName,
            bool bRequired,
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            // 使いません。
            sResult_Out = "";
            return false;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 文字列を、子要素として追加。
        /// </summary>
        /// <param name="sHumaninput"></param>
        /// <param name="parent_Gcav"></param>
        /// <param name="log_Reports"></param>
        public void AppendTextNode(
            string sHumaninput,
            Givechapterandverse_Node parent_Gcav,
            Log_Reports log_Reports
            )
        {
            Expression_Leaf_StringImpl ec_Atom = new Expression_Leaf_StringImpl(null, parent_Gcav);
            ec_Atom.SetString(
                sHumaninput,
                log_Reports
                );

            this.List_Expression_Child.Add(
                ec_Atom,
                log_Reports
                );
        }

        //────────────────────────────────────────

        public virtual string Expression_ExecuteMain(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "Expression_ExecuteMain",log_Reports);

            string sResult;
            Exception err_Excp;

            try
            {
                sResult = this.dicS_P1p[this.nP1p];
            }
            catch (KeyNotFoundException e)
            {
                // エラー
                err_Excp = e;
                goto gt_Error_KeyNotFound;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_KeyNotFound:
            {
                sResult = "";
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー211！", log_Method);

                    Log_TextIndented t = new Log_TextIndentedImpl();
                    t.Append("テキスト_テンプレートの引数 p");
                    t.Append(this.nP1p);
                    t.Append("p の取得に失敗しました。");
                    t.Newline();

                    // ヒント
                    t.Append(r.Message_SException(err_Excp));

                    r.Message = t.ToString();
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
            return sResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 内容を文字列型で返します。
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public string Execute_OnExpressionString(
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "Execute_OnEString",log_Reports);

            //
            //
            //
            //

            string sResult;

            // エラーが出ている時は飛ばしたいが、「エラー報告」として利用されることがある。

            //if (!log_Reports.Successful)
            //{
            //    //エラー
            //    sResult = "＜E_P1pImpl:エラー101＞";
            //    goto gt_EndMethod;
            //}

            sResult = this.Expression_ExecuteMain(log_Reports);

            // もとに戻す
            this.requestItems = Request_SelectingImpl.Unconstraint;

            goto gt_EndMethod;
        //
        //
        //
        //

        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// このデータは、ファイルパス型だ、と想定して、ファイルパスを取得します。
        /// </summary>
        /// <returns></returns>
        public Expression_Node_Filepath Execute_OnExpressionString_AsFilepath(
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            return Expression_Node_StringImpl.Execute_OnEString_AsFilePath_Impl(this, request, log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 子要素を追加します。
        /// </summary>
        /// <param name="items"></param>
        /// <param name="request"></param>
        /// <param name="log_Reports"></param>
        public void AddChildElement(
            Expression_Node_String ec_Child,
            Log_Reports log_Reports
            )
        {
            //
            // エラー。

            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "AddChildElement",log_Reports);

            //
            //
            //
            //

            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);

                r.SetTitle("▲エラー201！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("このメソッド " + this.GetType().Name + "#AddChildHDataElement は使わないでください。");

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.Message = t.ToString();

                log_Reports.EndCreateReport();
            }

            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public List<Expression_Node_String> GetChildElements(
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            //
            // エラー。

            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "GetChildElements",log_Reports);

            //
            //
            //
            //

            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);

                r.SetTitle("▲エラー101！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("このメソッド " + this.GetType().Name + "#GetChildElements は使わないでください。");

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.Message = t.ToString();

                log_Reports.EndCreateReport();
            }
            //
            //
            log_Method.EndMethod(log_Reports);
            return null;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 親E_Stringを遡って検索。一致するものがなければヌル。
        /// </summary>
        /// <param name="sName_Node"></param>
        /// <returns></returns>
        public Expression_Node_String GetParentExpressionOrNull(string sName_Node)
        {
            return Expression_Node_StringImpl.GetParentEOrNull_(this, sName_Node);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 使えません。
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="sExpectedValue"></param>
        /// <param name="request"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public List<Expression_Node_String> SelectDirectchildByNodename(
            string sExpectedNodeName, bool bRemove, Request_Selecting request, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.Name_Library, this, "GetDirectChildByNodeName",log_Reports);

            List<Expression_Node_String> result = new List<Expression_Node_String>();

            if (EnumHitcount.One == request.EnumHitcount)
            {
                // 必ず１件だけヒットする想定。

                if (result.Count != 1)
                {
                    goto gt_errorNotOne;
                }
            }
            else if (EnumHitcount.First_Exist_Or_Zero == request.EnumHitcount)
            {
                // ヒットすれば最初の１件だけ、ヒットしなければ０件の想定。

                if (1 < result.Count)
                {
                    result.RemoveRange(1, result.Count - 1);
                }
            }
            else
            {
            }


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_errorNotOne:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("必ず、１件のみ取得する指定でしたが、[");
                sb.Append(result.Count);
                sb.Append("]件取得しました。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // ヒント

                r.Message = sb.ToString();
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

        private Givechapterandverse_Node cur_Givechapterandverse;

        /// <summary>
        /// 設定場所のヒント。
        /// </summary>
        public Givechapterandverse_Node Cur_Givechapterandverse
        {
            get
            {
                return this.cur_Givechapterandverse;
            }
            set
            {
                this.cur_Givechapterandverse = value;
            }
        }

        //────────────────────────────────────────

        private Expression_Node_String parent_Expression;

        /// <summary>
        /// 設定場所のヒント。
        /// </summary>
        public Expression_Node_String Parent_Expression
        {
            get
            {
                return this.parent_Expression;
            }
            set
            {
                this.parent_Expression = value;
            }
        }

        //────────────────────────────────────────

        private int nP1p;

        /// <summary>
        /// 「p1p」、「p2p」といった引数名の中の数字。
        /// 
        /// 「p1p」は、「%1%」を名前にしたもの。
        /// </summary>
        public int NP1p
        {
            get
            {
                return nP1p;
            }
            set
            {
                this.nP1p = value;
            }
        }

        //────────────────────────────────────────

        private Dictionary<int, string> dicS_P1p;

        /// <summary>
        /// [1]=101
        /// [2]=赤
        /// といったディクショナリー。
        /// 
        /// 数字は %1%や、p1pの名前の中の数字。[1]から始める。
        /// </summary>
        public Dictionary<int, string> DicS_P1p
        {
            get
            {
                return dicS_P1p;
            }
            set
            {
                dicS_P1p = value;
            }
        }

        //────────────────────────────────────────

        private ListExpression_Node_String listExpression_Child;

        /// <summary>
        /// 子＜●●＞リスト。
        /// 使いません。
        /// </summary>
        public ListExpression_Node_String List_Expression_Child
        {
            get
            {
                return listExpression_Child;
            }
        }

        //────────────────────────────────────────

        private DicExpression_Node_String dictionary_Expression_Attribute;

        /// <summary>
        /// 属性="" マップ。
        /// </summary>
        public DicExpression_Node_String Dictionary_Expression_Attribute
        {
            get
            {
                return dictionary_Expression_Attribute;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// どういう結果が欲しいかの指定。
        /// </summary>
        private Request_Selecting requestItems;

        //────────────────────────────────────────

        /// <summary>
        /// どういう結果が欲しいかの指定。
        /// 
        /// 旧名：SetValidation
        /// </summary>
        /// <param name="request"></param>
        public void SetRequest_Selecting(
            Request_Selecting request
            )
        {
            requestItems = request;
        }

        //────────────────────────────────────────
        #endregion




    }
}