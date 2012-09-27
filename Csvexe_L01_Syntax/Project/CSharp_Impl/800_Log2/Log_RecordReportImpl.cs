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
    public class Log_Report01Impl : Log_RecordReport
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Log_Report01Impl(Log_Reports parent_Log_Logging)
        {
            this.Parent_Log_Reports = parent_Log_Logging;
            this.sTitle = "";
            this.p1pText = new TextP1pImpl();
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
            sb.Append(log_Method.SHead);
            sb.Append("）");
            this.STitle = sb.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public string Message_Givechapterandverse(
            Givechapterandverse_Node parent_Gcav
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
                s.NewLine();
                s.NewLine();
                parent_Gcav.ToText_Path(s);
                s.NewLine();
                s.NewLine();

                s.Append(this.Message_SSeparator());

                s.Append("　　問題内部ヒント：");
                s.NewLine();
                parent_Gcav.ToText_Content(s);
                s.NewLine();
                s.NewLine();

                s.Append(this.Message_SSeparator());

                s.Append("　　問題を報告したオブジェクトの型: ");
                s.Append(parent_Gcav.GetType());
                s.Append("　（これはラッパークラスということもあるかも知れません）");
                s.NewLine();
                s.NewLine();
            }


            return s.ToString();
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

            this.sCallstack = sb.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public string Message_SException(
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

        //────────────────────────────────────────

        /// <summary>
        /// 警告メッセージの定型文を作ります。
        /// </summary>
        /// <returns></returns>
        public string Message_SSeparator()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("　　--------- --------- --------- ---------");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);


            return sb.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「%1%」形式で文章中で使える文字列。
        /// </summary>
        /// <param name="number">「%1%」で使う数字。1から始まる連番。</param>
        /// <param name="sMessage">「%1%」に対応する文字列。</param>
        public void AddP1p(int nNumber, object sMessage)
        {
            this.p1pText.DicS_P1p.Add(nNumber, sMessage.ToString());
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// レポート作成時の、コールスタック文字列。
        /// </summary>
        private string sCallstack;

        //────────────────────────────────────────

        private Log_Reports parent_Log_Reports;

        /// <summary>
        /// 親要素。
        /// </summary>
        public Log_Reports Parent_Log_Reports
        {
            get
            {
                return parent_Log_Reports;
            }
            set
            {
                parent_Log_Reports = value;
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

        private TextP1p p1pText;

        /// <summary>
        /// 本文。
        /// </summary>
        public string SMessage
        {
            set
            {
                // テンプレート
                this.p1pText.SText = value;
            }
        }

        public string SMsg(Log_Reports log_Reports)
        {
            Expression_Node_String ec_Str = this.p1pText.Compile(log_Reports);

            StringBuilder sb = new StringBuilder();
            sb.Append(ec_Str.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
            sb.Append(System.Environment.NewLine);

            // コールスタックを付けます。
            sb.Append(this.sCallstack);

            return sb.ToString();
        }

        //────────────────────────────────────────

        private string sTitle;

        /// <summary>
        /// 警告タイトル。
        /// </summary>
        public string STitle
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
        public string SConfigStack
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
        public string SGroupTag
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
