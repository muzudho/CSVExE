using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Xenon.Syntax
{

    /// <summary>
    /// 
    /// </summary>
    public class Expression_Leaf_StringImpl : Expression_Leaf_String
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Expression_Leaf_StringImpl(Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav)
            : this("", parent_Expression, cur_Gcav)
        {
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Expression_Leaf_StringImpl(string sHumanInput, Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav)
        {
            this.sHumanInput = sHumanInput;
            this.parent_Expression = parent_Expression;
            this.cur_Givechapterandverse = cur_Gcav;

            this.request_Selecting = Request_SelectingImpl.Unconstraint;
            this.ecDic_Attr = new DicExpression_Node_StringImpl(this.Cur_Givechapterandverse);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 新しいインスタンスを作ります。
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public Expression_Leaf_String NewInstance(
            Givechapterandverse_Node parent_Expression,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "NewInstance",log_Reports);

            //
            //
            //
            //

            Expression_Leaf_StringImpl result = new Expression_Leaf_StringImpl(null, parent_Expression);

            result.SetString(
                this.sHumanInput,
                log_Reports
                );

            //
            //
            log_Method.EndMethod(log_Reports);
            return result;
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
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "ToText_Snapshot",log_Reports_ForSnapshot);

            log_Reports_ForSnapshot.BeginCreateReport(EnumReport.Dammy);
            s.Increment();

            s.AppendI(0,"葉「E■[");
            s.Append(this.Cur_Givechapterandverse.SName);
            s.Append("]　");
            s.Append(this.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_ForSnapshot));
            s.Append("」");
            s.NewLine();


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
        /// 子要素を追加します。
        /// </summary>
        /// <param name="nItems"></param>
        /// <param name="request"></param>
        /// <param name="log_Reports"></param>
        public void Expression_AddChild(
            Expression_Node_String child_Expression,
            Log_Reports log_Reports
            )
        {
            //
            // エラー。

            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "Expression_AddChild",log_Reports);

            //
            //
            //
            //

            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("このメソッド " + this.GetType().Name + "#AddChildN は使わないでください。");

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }

            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// @Deprecated
        /// </summary>
        /// <param name="request"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public List<Expression_Node_String> Expression_GetChildList(
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            //
            // エラー。

            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "Expression_GetChildList",log_Reports);

            //
            //

            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー101！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("このメソッド " + this.GetType().Name + "#GetChildNList は使わないんでください。");

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.SMessage = t.ToString();

                log_Reports.EndCreateReport();
            }

            //
            //
            log_Method.EndMethod(log_Reports);

            return null;
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
        public bool TrySelectAttr(
            out Expression_Node_String ec_Result_Out,
            string sName,
            bool bRequired,
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            // 使いません。
            ec_Result_Out = new Expression_Node_StringImpl(this, null);
            return false;
        }

        public bool TrySelectAttr(
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
            throw new Exception(Info_Syntax.SName_Library + ":" + this.GetType().Name + "#AppendTextElement:このクラスでは、このメソッドを使わないでください。");
        }

        //────────────────────────────────────────

        public virtual string Expression_ExecuteMain(
            Log_Reports log_Reports
            )
        {
            return this.sHumanInput;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 内容を文字列型で返します。
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public virtual string Execute_OnExpressionString(
            Request_Selecting req_Items,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "Execute_OnEString",log_Reports);
            //
            //

            // もとに戻す
            this.request_Selecting = Request_SelectingImpl.Unconstraint;

            string sResult = this.Expression_ExecuteMain(log_Reports);// this.sHumanInput;

            //
            //
            log_Method.EndMethod(log_Reports);
            return sResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// このデータは、ファイルパス型だ、と想定して、ファイルパスを取得します。
        /// </summary>
        /// <returns></returns>
        public virtual Expression_Node_Filepath Execute_OnExpressionString_AsFilePath(
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            return Expression_Node_StringImpl.Execute_OnEString_AsFilePath_Impl(this, request, log_Reports);
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
            string sName_ExpectedNode,
            bool bRemove,
            Request_Selecting request,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "GetDirectChildByNodeName",log_Reports);

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

                r.SMessage = sb.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
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

        /// <summary>
        /// 子＜●●＞要素リスト。
        /// 使わない。
        /// </summary>
        public ListExpression_Node_String ListExpression_Child
        {
            get
            {
                return null;
            }
        }

        //────────────────────────────────────────

        private DicExpression_Node_String ecDic_Attr;

        /// <summary>
        /// 属性="" マップ。
        /// </summary>
        public DicExpression_Node_String DicExpression_Attr
        {
            get
            {
                return ecDic_Attr;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 値。
        /// </summary>
        private string sHumanInput;

        /// <summary>
        /// 内容を文字列型でセットします。
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public void SetString(
            string sHumanInput,
            Log_Reports log_Reports
            )
        {
            this.sHumanInput = sHumanInput;
        }

        //────────────────────────────────────────

        /// <summary>
        /// どういう結果が欲しいかの指定。
        /// </summary>
        private Request_Selecting request_Selecting;

        protected Request_Selecting Request_Selecting
        {
            get
            {
                return this.request_Selecting;
            }
        }

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
            request_Selecting = request;
        }

        //────────────────────────────────────────
        #endregion



    }
}
