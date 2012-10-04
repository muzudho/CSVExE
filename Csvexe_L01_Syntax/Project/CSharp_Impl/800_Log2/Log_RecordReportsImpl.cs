﻿//
// Cushion
//
// アプリケーションを作るうえで、よく使うことになるもの。
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Xenon.Syntax
{
    /// <summary>
    /// 警告メッセージ。
    /// </summary>
    public class Log_RecordReportsImpl : Log_RecordReports
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Log_RecordReportsImpl(Log_Reports parent_Log_Logging)
        {
            this.Owner = parent_Log_Logging;
            this.sTitle = "";
            this.p1pText = new Builder_TexttemplateP1pImpl();
            this.sConfigStack = "";
            this.sGroupTag = "";

            this.enumReport = EnumReport.Error;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 警告タイトル。
        /// </summary>
        public void SetTitle(string sErrorNumber, Log_Method log_Method)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("【");
            sb.Append(sErrorNumber);
            sb.Append("】（");
            sb.Append(log_Method.Fullname);
            sb.Append("）");
            this.Title = sb.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public static string ToMessage_Configurationtree(
            Configurationtree_Node parent_Gcav
            )
        {
            Log_TextIndented s = new Log_TextIndentedImpl();

            if (null == parent_Gcav)
            {
                s.Append("　　親要素が指定されていません。");
            }
            else
            {
                s.Append("　　問題箇所ヒント：");
                s.Newline();
                s.Newline();
                parent_Gcav.ToText_Locationbreadcrumbs(s);
                s.Newline();
                s.Newline();

                s.Append(Log_RecordReportsImpl.ToMessage_Separator());

                s.Append("　　問題内部ヒント：");
                s.Newline();
                parent_Gcav.ToText_Content(s);
                s.Newline();
                s.Newline();

                s.Append(Log_RecordReportsImpl.ToMessage_Separator());

                s.Append("　　問題を報告したオブジェクトの型: ");
                s.Append(parent_Gcav.GetType());
                s.Append("　（これはラッパークラスということもあるかも知れません）");
                s.Newline();
                s.Newline();
            }


            return s.ToString();
        }

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public string Message_Configurationtree(
            Configurationtree_Node parent_Cnf
            )
        {
            return Log_RecordReportsImpl.ToMessage_Configurationtree(parent_Cnf);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public void WriteCallstack(Log_Callstack log_CallStack)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Message_SSeparator());

            sb.Append("　　実行経路ヒント：");
            sb.Append(Environment.NewLine);
            sb.Append("　　　");

            sb.Append(log_CallStack.ToString());
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);

            this.text_Callstack = sb.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public static string ToMessage_Exception(
            Exception ex
            )
        {
            StringBuilder sb = new StringBuilder();

            if (null == ex)
            {
                sb.Append("　　発生したExceptionメッセージ：Exceptionがヌルでした。");
            }
            else
            {
                sb.Append("　　発生したExceptionメッセージ：");
                sb.Append(Environment.NewLine);
                sb.Append("　　　");
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                sb.Append("　　Exceptionクラスの型：");
                sb.Append(Environment.NewLine);
                sb.Append("　　　");
                sb.Append(ex.GetType().FullName);
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public string Message_SException(
            Exception ex
            )
        {
            return Log_RecordReportsImpl.ToMessage_Exception(ex);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public static string ToMessage_Separator()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("　　--------- --------- --------- ---------");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);


            return sb.ToString();
        }

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public string Message_SSeparator()
        {
            return Log_RecordReportsImpl.ToMessage_Separator();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「%1%」形式で文章中で使える文字列。
        /// </summary>
        /// <param name="number">「%1%」で使う数字。1から始まる連番。</param>
        /// <param name="sMessage">「%1%」に対応する文字列。</param>
        public void SetParameter_P1p(int nNumber, object sMessage, Log_Reports log_Reports)
        {
            this.p1pText.SetParameter(nNumber, sMessage.ToString(), log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// レポート作成時の、コールスタック文字列。
        /// </summary>
        private string text_Callstack;

        //────────────────────────────────────────

        private Log_Reports owner;

        /// <summary>
        /// 親要素。
        /// </summary>
        public Log_Reports Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        //────────────────────────────────────────

        private EnumReport enumReport;

        /// <summary>
        /// プログラムを停止させるか、続行させるかの区別。
        /// </summary>
        public EnumReport EnumReport
        {
            get
            {
                return enumReport;
            }
            set
            {
                enumReport = value;
            }
        }

        //────────────────────────────────────────

        private Builder_TexttemplateP1p p1pText;

        /// <summary>
        /// 本文。
        /// </summary>
        public string Message
        {
            set
            {
                // テンプレート
                this.p1pText.Text = value;
            }
        }

        public string GetMessage(Log_Reports log_Reports)
        {
            Expression_Node_String expr_Str = this.p1pText.Compile(log_Reports);

            StringBuilder sb = new StringBuilder();
            sb.Append(expr_Str.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
            sb.Append(System.Environment.NewLine);

            // コールスタックを付けます。
            sb.Append(this.text_Callstack);

            return sb.ToString();
        }

        //────────────────────────────────────────

        private string sTitle;

        /// <summary>
        /// 警告タイトル。
        /// </summary>
        public string Title
        {
            set
            {
                sTitle = value;
            }
            get
            {
                return sTitle;
            }
        }

        //────────────────────────────────────────

        private string sConfigStack;

        /// <summary>
        /// 人間オペレーターは、ここを修正しろ、といった情報。
        /// 例：「xxxファイルのxx行目のxxx」
        /// </summary>
        public string Logstack
        {
            set
            {
                sConfigStack = value;
            }
            get
            {
                return sConfigStack;
            }
        }

        //────────────────────────────────────────

        private string sGroupTag;

        /// <summary>
        /// グループ・タグ。情報を見たい人が、表示する情報を絞り込むために使われます。
        /// </summary>
        public string Tag_Group
        {
            set
            {
                sGroupTag = value;
            }
            get
            {
                return sGroupTag;
            }
        }

        //────────────────────────────────────────
        #endregion


        
    }

}