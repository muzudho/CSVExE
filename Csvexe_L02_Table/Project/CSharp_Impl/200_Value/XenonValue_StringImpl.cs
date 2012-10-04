using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports


namespace Xenon.Table
{
    public class XenonValue_StringImpl : XenonValue_AbstractImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="sourceHintName"></param>
        public XenonValue_StringImpl(String sConfigStack)
            : base(sConfigStack)
        {

        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override void ToText_Content(Log_TextIndented txt)
        {
            txt.Increment();


            txt.AppendI(0, "<");
            txt.Append(this.GetType().Name);
            txt.Append("クラス");

            txt.AppendI(1, "humanInputString=[");
            txt.Append(this.Humaninput);
            txt.Append("]");

            txt.AppendI(0, ">");
            txt.Newline();


            txt.Decrement();
        }

        //────────────────────────────────────────

        public bool TryGet(out string sResult)
        {
            sResult = this.Humaninput;
            return true;
        }

        public string GetString()
        {
            return this.Humaninput;
        }

        public void SetString(string sValue)
        {
            this.Humaninput = sValue;
            bSpaced = ("" == this.Humaninput.Trim());
        }

        //────────────────────────────────────────

        /// <summary>
        /// 文字列セルとして、データを読み取ります。
        /// 
        /// int型セル→文字列セルという融通は行います。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static public string ParseString(object data)
        {
            string sResult;

            if (null == data)
            {
                // エラー
                goto gt_Error_Null;
            }

            if (data is DBNull)
            {
                // 空欄。【追加 2011-04-11】
                sResult = "";
            }
            else if (data is XenonValue_StringImpl)
            {
                sResult = ((XenonValue_StringImpl)data).Humaninput;
            }
            else if (data is XenonValue_IntImpl)
            {
                sResult = ((XenonValue_IntImpl)data).Humaninput;
            }
            else
            {
                // エラー
                goto gt_Error_UndefinedData;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Null:
            {
                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("指定のセル値はヌルでした。文字列型として読み取ろうとしましたが、");
                t.Append(Environment.NewLine);
                t.Append("string型、またはint型のどちらでもありませんでした。");
                t.Append(Environment.NewLine);

                throw new System.ArgumentException(t.ToString());
            }
        //────────────────────────────────────────
        gt_Error_UndefinedData:
            {
                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("指定の引数の値[");
                t.Append(((XenonValue)data).Humaninput);
                t.Append("]を、文字列型として読み取ろうとしましたが、");
                t.Append(Environment.NewLine);
                t.Append("string型、またはint型のどちらでもありませんでした。");
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(data.GetType().Name);
                t.Append("]型でした。");
                throw new System.ArgumentException(t.ToString());
            }
            //goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            return sResult;
        }

        //────────────────────────────────────────

        static public bool TryParse(
            object data,
            out string s_Out,
            string sDebugConfigStack_Table,
            string sDebugConfigStack_Field,
            Log_Method log_Method,
            Log_Reports log_Reports)
        {
            bool bResult;

            if (data is XenonValue_StringImpl)
            {
                s_Out = ((XenonValue_StringImpl)data).GetString();
                bResult = true;
            }
            else if (data is DBNull)
            {
                //
                // 空欄は空文字列に。
                s_Out = "";
                bResult = true;
            }
            else if (null == data)
            {
                //
                // エラー
                goto gt_Error_Null;
            }
            else if (!(data is XenonValue))
            {
                //
                // エラー
                goto gt_Error_NotCellData;
            }
            else
            {
                //
                // エラー
                goto gt_Error_AnotherType;
            }

            // 正常
            goto gt_EndMethod;
            //
        // エラー。
        //────────────────────────────────────────
        gt_Error_Null:
            s_Out = "";//ゴミ値
            bResult = false;
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー241！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定の引数dataに、StringCellData型の値を指定してください。空っぽ(null)でした。");

                s.Append(Environment.NewLine);
                s.Append("debugHintName=[");
                s.Append(sDebugConfigStack_Table);
                s.Append(".");
                s.Append(sDebugConfigStack_Field);
                s.Append("]");

                s.Append(Environment.NewLine);
                s.Append("debugRunningHintName=[");
                s.Append(log_Method.Fullname);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotCellData:
            s_Out = "";//ゴミ値
            bResult = false;
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー243！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　指定の引数dataに、CellData型の値を指定してください。");
                s.Append(Environment.NewLine);
                s.Append("　別の型[" + data.GetType().Name + "でした。");
                s.Append(Environment.NewLine);

                s.Append(Environment.NewLine);
                s.Append("debugHintName=[");
                s.Append(sDebugConfigStack_Table);
                s.Append(".");
                s.Append(sDebugConfigStack_Field);
                s.Append("]");

                s.Append(Environment.NewLine);
                s.Append("debugRunningHintName=[");
                s.Append(log_Method.Fullname);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_AnotherType:
            s_Out = "";//ゴミ値
            bResult = false;
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー244！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定の引数の値[");
                s.Append(((XenonValue)data).Humaninput);
                s.Append("]は、StringCellData型ではありませんでした。");

                s.Append(Environment.NewLine);
                s.Append("debugHintName=[");
                s.Append(sDebugConfigStack_Table);
                s.Append(".");
                s.Append(sDebugConfigStack_Field);
                s.Append("]");

                s.Append(Environment.NewLine);
                s.Append("debugRunningHintName=[");
                s.Append(log_Method.Fullname);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        //
        //
        gt_EndMethod:
            return bResult;
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        public override bool Equals(System.Object obj)
        {
            // 引数がヌルの場合は、偽です。
            if (obj == null)
            {
                return false;
            }

            // 型が違えば偽です。
            XenonValue_StringImpl stringCellData = obj as XenonValue_StringImpl;
            if (null != stringCellData)
            {
                // 文字列の比較。
                return this.Humaninput == stringCellData.Humaninput;
            }

            string str = obj as string;
            if (null != str)
            {
                // 文字列の比較。
                return this.Humaninput == str;
            }

            return false;
        }

        //────────────────────────────────────────

        static public bool IsSpaces(object data)
        {
            if (data is XenonValue_StringImpl)
            {
                return ((XenonValue_StringImpl)data).bSpaced;
            }

            throw new System.ArgumentException("指定の引数の値[" + ((XenonValue)data).Humaninput + "]は、string型ではありませんでした。");
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 入力データそのままの形。
        /// </summary>
        public override string Humaninput
        {
            set
            {
                if ("" == value.Trim())
                {
                    bSpaced = true;
                }
                else
                {
                    bSpaced = false;
                }

                // 常に真。
                isValidated = true;

                this.humaninput = value;
            }
        }

        //────────────────────────────────────────

        public override int GetHashCode()
        {
            return this.Humaninput.GetHashCode();
        }

        //────────────────────────────────────────
        #endregion



    }
}
