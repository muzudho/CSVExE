using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Xenon.Syntax
{

    /// <summary>
    /// スレッド１つにつき、これを１つ宛てがうように使う。
    /// 
    /// プログラムの中でエラーがあれば、これに報告する。
    /// </summary>
    public class Log_ReportsImpl : Log_Reports
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Log_ReportsImpl(Log_Method log_Method_CreationMe)
        {
            this.bDebugEnable = true;

            this.bNotInfiniteLoop = true;
            this.list_Record = new List<Log_RecordReport>();

            this.log_Callstack = new Log_CallstackImpl();

            this.bSuccessful = true;
            this.log_Method_CreationMe = log_Method_CreationMe;
            this.sComment_EventCreationMe = "";
        }

        public Log_RecordReport CreateDammyReport()
        {
            return new Log_Report01Impl(this);
        }

        //────────────────────────────────────────

        /// <summary>
        /// エラーメッセージ、警告メッセージを全て消去します。
        /// </summary>
        public void Clear()
        {
            if (0 < this.list_Record.Count)
            {
                // メッセージがあったのなら。
                this.list_Record.Clear();
                this.bSuccessful = true;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 警告メッセージを追加します。
        /// </summary>
        /// <param name="warningReport"></param>
        private void Add(Log_RecordReport log_RecordReport)
        {
            this.list_Record.Add(log_RecordReport);

            if (log_RecordReport.EnumReport == EnumReport.Error)
            {
                this.bSuccessful = false;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 指定したログの全てのメッセージを、追加します。
        /// </summary>
        /// <param name="log_Reports"></param>
        public void AddRange(Log_Reports log_Reports)
        {
            this.list_Record.AddRange(log_Reports.List_Record);
            this.bSuccessful = (0 == this.list_Record.Count);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 警告が出ていれば、そのテキスト。
        /// </summary>
        /// <returns></returns>
        public string ToMessage(string sGroupTag)
        {
            StringBuilder sb = new StringBuilder();

            if (null != this.log_Method_CreationMe)
            {
                sb.Append("ロガー生成場所：");
                sb.Append(this.Log_Method_CreationMe.SHead);
                sb.Append(System.Environment.NewLine);
            }
            else
            {
                sb.Append("ロガー生成場所：ヌル");
                sb.Append(System.Environment.NewLine);
            }

            sb.Append("ロガーの作成に関するコメント：");
            sb.Append(this.SComment_EventCreationMe);
            sb.Append(System.Environment.NewLine);


            sb.Append("デバッグログ出力：");
            sb.Append(System.Environment.NewLine);

            int nErrorCount = 0;
            foreach (Log_RecordReport log_RecordReport in this.list_Record)
            {
                // グループ・タグが指定されていれば、
                // グループ・タグが一致するメッセージだけを出力します。

                if (log_RecordReport.EnumReport == EnumReport.Error)
                {
                    if ("" == sGroupTag || sGroupTag == log_RecordReport.SGroupTag)
                    {
                        sb.Append("(No.");
                        sb.Append(nErrorCount);
                        sb.Append(") ");

                        // タイトル
                        sb.Append(log_RecordReport.STitle);

                        if ("" != log_RecordReport.SGroupTag)
                        {
                            // グループ・タグ
                            sb.Append(log_RecordReport.SGroupTag);
                        }

                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);

                        if ("" != log_RecordReport.SConfigStack)
                        {
                            sb.Append("エラー発生元データの推測ヒント：");
                            sb.Append(log_RecordReport.SConfigStack);
                            sb.Append(Environment.NewLine);
                            sb.Append(Environment.NewLine);
                        }

                        sb.Append(log_RecordReport.SMsg(this));
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);

                        if ("" != log_RecordReport.SConfigStack)
                        {
                            sb.Append("プログラム実行経路推測ヒント：");
                            sb.Append(this.Log_Callstack.ToString());
                            sb.Append(Environment.NewLine);
                            sb.Append(Environment.NewLine);
                        }

                        sb.Append(Environment.NewLine);

                    }


                    // カウンターは、読み飛ばしたエラーもきちんとカウント。
                    nErrorCount++;
                }
            }

            if (!Log_ReportsImpl.BDebugmode_Static)
            {
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append("このデバッグ情報は、DebugModeフラグが立っていない状態でのものです。");
                sb.Append(Environment.NewLine);
                sb.Append("DDebuggerImpl.DebugModeフラグを立てると、今より詳細な情報が出力されるかもしれません。");
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 警告が出ていれば、そのテキスト。
        /// </summary>
        /// <returns></returns>
        public string ToMessage()//WarningMessage
        {
            // タグ指定なし。
            return this.ToMessage("");
        }

        //────────────────────────────────────────
        #endregion



        #region 開始と終了
        //────────────────────────────────────────

        /// <summary>
        /// デバッグの開始。
        /// </summary>
        public void BeginDebug()
        {
            this.bDebugEnable = false;
        }

        /// <summary>
        /// デバッグの終了。
        /// </summary>
        public void EndDebug()
        {
            this.bDebugEnable = true;
        }

        /// <summary>
        /// このオブジェクトの生存の終了時。
        /// </summary>
        public void EndLogging(Log_Method log_Method)
        {
            if (!this.BSuccessful)
            {
                // エラー
                goto gt_Error_NotSuccessful;
            }
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSuccessful:
            //必ず実行。
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("▲エラー！（");
                sb.Append(log_Method.SHead);
                sb.Append("）（※EntThread）");

                MessageBox.Show(this.ToMessage(), sb.ToString());
            }
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            ;
        }

        //────────────────────────────────────────

        /// <summary>
        /// デバッグ報告開始。
        /// </summary>
        /// <param name="d_EnumReport"></param>
        /// <returns>新しいレポート。</returns>
        public Log_RecordReport BeginCreateReport(EnumReport enumReport)
        {
            this.bNotInfiniteLoop = false;

            Log_Report01Impl r;
            r = new Log_Report01Impl(this);

            r.EnumReport = enumReport;

            // ダミーレポートでない場合、レポートを記録します。
            if (EnumReport.Dammy != enumReport)
            {
                r.WriteCallstack(this.Log_Callstack);
                this.Add(r);
            }

            return r;
        }

        /// <summary>
        /// デバッグ報告終了。
        /// </summary>
        public void EndCreateReport()
        {
            this.bNotInfiniteLoop = true;
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// デバッグ処理中にデバッグ処理を行うと、無限ループになることがある。
        /// そこでデバッグ処理はこのフラグで囲い、デバッグ処理に入ったら偽にしておくことで、
        /// 子プログラムでデバッグ処理を行わないようにする。これで無限ループを防止する。
        /// </summary>
        public bool CanCreateReport
        {
            get
            {
                return this.bNotInfiniteLoop;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// デバッグして良い場合なら真。
        /// </summary>
        public bool CanDebug
        {
            get
            {
                return bDebugEnable;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Log_Method log_Method_CreationMe;

        /// <summary>
        /// このロガーが new されているメソッドを特定する情報。
        /// </summary>
        public Log_Method Log_Method_CreationMe
        {
            get
            {
                return this.log_Method_CreationMe;
            }
        }

        //────────────────────────────────────────

        private string sComment_EventCreationMe;
        /// <summary>
        /// このロガーを new したイベントの説明。
        /// </summary>
        public string SComment_EventCreationMe
        {
            get
            {
                return this.sComment_EventCreationMe;
            }
            set
            {
                this.sComment_EventCreationMe = value;
            }
        }

        //────────────────────────────────────────

        private Log_Callstack log_Callstack;

        /// <summary>
        /// @Deprecated
        /// コールスタック。
        /// </summary>
        public Log_Callstack Log_Callstack
        {
            get
            {
                return log_Callstack;
            }
            set
            {
                log_Callstack = value;
            }
        }

        //────────────────────────────────────────

        private bool bNotInfiniteLoop;

        //────────────────────────────────────────

        private List<Log_RecordReport> list_Record;

        /// <summary>
        /// 警告メッセージの一覧。
        /// </summary>
        public List<Log_RecordReport> List_Record
        {
            get
            {
                return this.list_Record;
            }
        }

        //────────────────────────────────────────

        private bool bSuccessful;

        /// <summary>
        /// プログラムを停止させるべき問題が発生していなければ真。（エラーメッセージが 0 件なら真）
        /// </summary>
        public bool BSuccessful
        {
            get
            {
                return bSuccessful;
            }
        }

        //────────────────────────────────────────

        private static bool bDebugmode_Static;

        /// <summary>
        ///
        /// </summary>
        public static bool BDebugmode_Static
        {
            get
            {
                return bDebugmode_Static;
            }
            set
            {
                bDebugmode_Static = value;
            }
        }

        //────────────────────────────────────────

        private bool bDebugEnable;

        // ──────────────────────────────

        private static bool bDebugmode_Form;

        /// <summary>
        /// デバッグモードのON/OFF。画面レイアウト用。
        /// </summary>
        public static bool BDebugmode_Form
        {
            get
            {
                return bDebugmode_Form;
            }
            set
            {
                bDebugmode_Form = value;
            }
        }

        // ──────────────────────────────

        static private bool bDebugmode_Stopwatch_Static;

        public bool CanStopwatch
        {
            get
            {
                return Log_ReportsImpl.BDebugmode_Static && bDebugmode_Stopwatch_Static;
            }
        }

        /// <summary>
        /// デバッグモード（実行時間計測）なら真。
        /// </summary>
        public bool BDebugmode_Stopwatch
        {
            set
            {
                bDebugmode_Stopwatch_Static = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 警告の件数を返します。
        /// </summary>
        public int NCount
        {
            get
            {
                return this.list_Record.Count;
            }
        }

        //────────────────────────────────────────
        #endregion


        
    }
}
