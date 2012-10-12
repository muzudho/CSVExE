using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports


namespace Xenon.Table
{
    public class String_HumaninputImpl : AbstractValue_HumaninputImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="sourceHintName"></param>
        public String_HumaninputImpl(String nodeConfigtree)
            : base(nodeConfigtree)
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
            txt.Append(this.Text);
            txt.Append("]");

            txt.AppendI(0, ">");
            txt.Newline();


            txt.Decrement();
        }

        //────────────────────────────────────────

        public bool TryGet(out string result)
        {
            result = this.Text;
            return true;
        }

        public string GetString()
        {
            return this.Text;
        }

        public void SetString(string value)
        {
            this.Text = value;
            bSpaced = ("" == this.Text.Trim());
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

            if (data is String_HumaninputImpl)
            {
                s_Out = ((String_HumaninputImpl)data).GetString();
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
            else if (!(data is Value_Humaninput))
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
                s.Append(((Value_Humaninput)data).Text);
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
            String_HumaninputImpl stringH = obj as String_HumaninputImpl;
            if (null != stringH)
            {
                // 文字列の比較。
                return this.Text == stringH.Text;
            }

            string str = obj as string;
            if (null != str)
            {
                // 文字列の比較。
                return this.Text == str;
            }

            return false;
        }

        //────────────────────────────────────────

        static public bool IsSpaces(object data)
        {
            if (data is String_HumaninputImpl)
            {
                return ((String_HumaninputImpl)data).bSpaced;
            }

            throw new System.ArgumentException("指定の引数の値[" + ((Value_Humaninput)data).Text + "]は、string型ではありませんでした。");
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 入力データそのままの形。
        /// </summary>
        public override string Text
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

                this.text = value;
            }
        }

        //────────────────────────────────────────

        public override int GetHashCode()
        {
            return this.Text.GetHashCode();
        }

        //────────────────────────────────────────
        #endregion



    }
}
