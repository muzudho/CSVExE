using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{
    public class Log_MethodImpl : Log_Method
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Log_MethodImpl()
        {
            this.debugLevel_Method = 0;
            this.debugMode_Master = false;
            this.sName_Library = "";
            this.sName_Class = "";
            this.sName_Method = "";
            this.log_Stopwatch = new Log_StopwatchImpl(this);
        }

        public Log_MethodImpl(int nDebugLevel_Method)
        {
            this.debugLevel_Method = nDebugLevel_Method;
            this.debugMode_Master = true;
            this.sName_Library = "";
            this.sName_Class = "";
            this.sName_Method = "";
            this.log_Stopwatch = new Log_StopwatchImpl(this);
        }

        public Log_MethodImpl(int nLevel_MethodDebug, bool bDebugMode_Master)
        {
            this.debugLevel_Method = nLevel_MethodDebug;
            this.debugMode_Master = bDebugMode_Master;
            this.sName_Library = "";
            this.sName_Class = "";
            this.sName_Method = "";
            this.log_Stopwatch = new Log_StopwatchImpl(this);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        [Obsolete("ライブラリ名、クラス名、メソッド名も同時にセットするBeginMethodを使うこと。")]
        public void SetPath(string sName_Library, object thisClass, string sName_Method)
        {
            this.sName_Library = sName_Library;
            this.sName_Class = thisClass.GetType().Name;
            this.bStatic = false;
            this.sName_Method = sName_Method;
        }

        [Obsolete("ライブラリ名、クラス名、メソッド名も同時にセットするBeginMethodを使うこと。")]
        public void SetPath(string sName_Library, string sName_StaticClass, string sName_Method)
        {
            this.sName_Library = sName_Library;
            this.sName_Class = sName_StaticClass;
            this.bStatic = true;
            this.sName_Method = sName_Method;
        }

        //────────────────────────────────────────

        public void WriteDebug_ToConsole(string sMessage)
        {
            // #出力
            System.Console.WriteLine(this.Fullname + ":　" + sMessage);
        }

        public void WriteError_ToConsole(string sMessage)
        {
            // #出力
            System.Console.WriteLine(this.Fullname + ":エラー　" + sMessage);
        }

        public void WriteWarning_ToConsole(string sMessage)
        {
            // #出力
            System.Console.WriteLine(this.Fullname + ":警告　" + sMessage);
        }

        public void WriteInfo_ToConsole(string sMessage)
        {
            // #出力
            System.Console.WriteLine(this.Fullname + ":情報　" + sMessage);
        }

        //────────────────────────────────────────
        #endregion



        #region 開始と終了
        //────────────────────────────────────────

        [Obsolete("ライブラリ名、クラス名、メソッド名も同時にセットするBeginMethodを使うこと。")]
        public void BeginMethod(Log_Reports log_Reports)
        {
            // デバッグを行うなら、コールスタックにこのメソッドパスを追加。
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                log_Reports.Log_Callstack.Push(this);
            }
        }

        public void BeginMethod(string sName_Library, object thisClass, string sName_Method, Log_Reports log_Reports)
        {
            this.sName_Library = sName_Library;
            this.sName_Class = thisClass.GetType().Name;
            this.bStatic = false;
            this.sName_Method = sName_Method;

            // デバッグを行うなら、コールスタックにこのメソッドパスを追加。
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                log_Reports.Log_Callstack.Push(this);
            }
        }

        public void BeginMethod(string sName_Library, string sName_StaticClass, string sName_Method, Log_Reports log_Reports)
        {
            this.sName_Library = sName_Library;
            this.sName_Class = sName_StaticClass;
            this.bStatic = true;
            this.sName_Method = sName_Method;

            // デバッグを行うなら、コールスタックにこのメソッドパスを追加。
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                log_Reports.Log_Callstack.Push(this);
            }
        }

        [Obsolete("ライブラリ名、クラス名、メソッド名も同時にセットするBeginMethodを使うこと。")]
        public void BeginMethod(out Log_Reports log_Reports)
        {
            log_Reports = new Log_ReportsImpl(this);

            // デバッグを行うなら、コールスタックにこのメソッドパスを追加。
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                log_Reports.Log_Callstack.Push(this);
            }
        }

        public void BeginMethod(string sName_Library, object thisClass, string sName_Method, out Log_Reports log_Reports)
        {
            this.sName_Library = sName_Library;
            this.sName_Class = thisClass.GetType().Name;
            this.bStatic = false;
            this.sName_Method = sName_Method;

            log_Reports = new Log_ReportsImpl(this);

            // デバッグを行うなら、コールスタックにこのメソッドパスを追加。
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                log_Reports.Log_Callstack.Push(this);
            }
        }

        public void BeginMethod(string sName_Library, string sName_StaticClass, string sName_Method, out Log_Reports log_Reports)
        {
            this.sName_Library = sName_Library;
            this.sName_Class = sName_StaticClass;
            this.bStatic = true;
            this.sName_Method = sName_Method;

            log_Reports = new Log_ReportsImpl(this);

            // デバッグを行うなら、コールスタックにこのメソッドパスを追加。
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                log_Reports.Log_Callstack.Push(this);
            }
        }

        public void EndMethod(Log_Reports log_Reports)
        {
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                if (this.Log_Stopwatch.IsRunning && log_Reports.CanStopwatch)
                {
                    this.Log_Stopwatch.End();
                }

                log_Reports.Log_Callstack.Pop(this);
            }
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        public bool Equals(Log_Method log_Method)
        {
            bool bEquals;

            if(
                log_Method.Name_Library == this.Name_Library &&
                log_Method.Name_Class == this.Name_Class &&
                log_Method.Static == this.Static &&
                log_Method.Name_Method == this.Name_Method
                )
            {
                bEquals = true;
            }
            else
            {
                bEquals = false;
            }

            return bEquals;
        }

        //────────────────────────────────────────

        public bool CanError()
        {
            bool bErrorMode = true;

            return bErrorMode;
        }

        public bool CanWarning()
        {
            bool bWarningMode = true;

            return bWarningMode;
        }

        public bool CanDebug(int nDebugLevel_Codeblock)
        {
            bool bDebugMode;

            if (this.debugMode_Master && nDebugLevel_Codeblock <= this.debugLevel_Method)
            {
                bDebugMode = true;
            }
            else
            {
                bDebugMode = false;
            }

            return bDebugMode;
        }

        public bool CanInfo()
        {
            bool bInfoMode;

            if (this.debugMode_Master)
            {
                bInfoMode = true;
            }
            else
            {
                bInfoMode = false;
            }

            return bInfoMode;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public string Fullname
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(this.Name_Library);
                sb.Append(":");
                sb.Append(this.Name_Class);
                if (this.Static)
                {
                    sb.Append(".");
                }
                else
                {
                    sb.Append("#");
                }
                sb.Append(this.Name_Method);

                return sb.ToString();
            }
        }

        //────────────────────────────────────────

        private int debugLevel_Method;
        private bool debugMode_Master;

        //────────────────────────────────────────

        private Log_Stopwatch log_Stopwatch;

        /// <summary>
        /// ストップウォッチ。
        /// </summary>
        public Log_Stopwatch Log_Stopwatch
        {
            get
            {
                return log_Stopwatch;
            }
            set
            {
                log_Stopwatch = value;
            }
        }

        //────────────────────────────────────────
        
        private string sName_Library;

        public string Name_Library
        {
            get
            {
                return sName_Library;
            }
        }

        //────────────────────────────────────────

        private string sName_Class;

        public string Name_Class
        {
            get
            {
                return sName_Class;
            }
        }

        //────────────────────────────────────────

        private bool bStatic;

        public bool Static
        {
            get
            {
                return bStatic;
            }
        }

        //────────────────────────────────────────

        private string sName_Method;

        public string Name_Method
        {
            get
            {
                return sName_Method;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
