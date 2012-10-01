using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;//Stopwatch


namespace Xenon.Syntax
{

    public class Log_StopwatchImpl : Log_Stopwatch
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Log_StopwatchImpl(Log_Method owner_Log_Method)
        {
            this.owner_Log_Method = owner_Log_Method;
            this.sMessage = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────


        public void Begin()
        {
            if (null == this.stopwatch)
            {
                this.stopwatch = new Stopwatch();
            }

            this.stopwatch.Start();
            this.NMilliSeconds_Start = this.stopwatch.ElapsedMilliseconds;
        }

        public void End()
        {
            if (this.IsRunning)
            {
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_Syntax.Name_Library, this, "End", log_Reports_ThisMethod);

                this.NMilliSeconds_End = stopwatch.ElapsedMilliseconds;


                StringBuilder sb = new StringBuilder();

                sb.Append(Info_Syntax.Name_Library);
                sb.Append(":");
                sb.Append(this.GetType().Name);
                sb.Append("#End: 計測 ");
                sb.Append(this.ToString());
                sb.Append(Environment.NewLine);

                log_Method.WriteInfo_ToConsole(sb.ToString());
                log_Method.EndMethod(log_Reports_ThisMethod);
                log_Reports_ThisMethod.EndLogging(log_Method);
            }
        }

        //────────────────────────────────────────

        public override string ToString()
        {
            long nMilliSeconds = this.NMilliSeconds_End - this.NMilliSeconds_Start;

            StringBuilder sb = new StringBuilder();

            if (this.IsRunning)
            {
                //
                // メソッド名
                //
                sb.Append("Stopwatch ");
                sb.Append(this.Owner_Log_Method.Fullname);
                sb.Append(":");

                sb.Append(this.sMessage);

                sb.Append(" 処理時間=[");
                sb.Append(nMilliSeconds);
                sb.Append("]ミリ秒。");
            }
            else
            {
                //
                // メソッド名
                //
                sb.Append("Stopwatch ");
                sb.Append(this.Owner_Log_Method.Fullname);
                sb.Append(":");

                sb.Append(this.sMessage);

                sb.Append(" 未起動。");
            }

            return sb.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        public bool IsRunning
        {
            get
            {
                bool bResult;
                if (null == this.stopwatch)
                {
                    bResult = false;
                }
                else
                {
                    bResult = this.stopwatch.IsRunning;
                }

                return bResult;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// C#で用意されているストップウォッチ。
        /// </summary>
        private Stopwatch stopwatch;

        //────────────────────────────────────────

        private Log_Method owner_Log_Method;

        private Log_Method Owner_Log_Method
        {
            get
            {
                return this.owner_Log_Method;
            }
            set
            {
                this.owner_Log_Method = value;
            }
        }

        //────────────────────────────────────────

        private string sMessage;

        public string Message
        {
            get
            {
                return sMessage;
            }
            set
            {
                sMessage = value;
            }
        }

        //────────────────────────────────────────

        private long nMilliSeconds_Start;

        public long NMilliSeconds_Start
        {
            get
            {
                return nMilliSeconds_Start;
            }
            set
            {
                nMilliSeconds_Start = value;
            }
        }

        //────────────────────────────────────────

        private long nMilliSeconds_End;

        public long NMilliSeconds_End
        {
            get
            {
                return nMilliSeconds_End;
            }
            set
            {
                nMilliSeconds_End = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }

}
