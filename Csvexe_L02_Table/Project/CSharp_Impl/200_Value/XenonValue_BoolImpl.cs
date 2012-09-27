using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports


namespace Xenon.Table
{
    public class XenonValue_BoolImpl : XenonValue_AbstractImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="sourceHintName"></param>
        public XenonValue_BoolImpl(String sConfigStack)
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
            txt.Append(this.SHumaninput);
            txt.Append("]");

            txt.AppendI(0, ">");
            txt.NewLine();


            txt.Decrement();
        }

        //────────────────────────────────────────        

        public bool TryGet(out bool bResult)
        {
            bool bSuccess;

            if (this.BValidated)
            {
                bResult = this.bValue_Bool;
                bSuccess = true;
            }
            else
            {
                if (bool.TryParse(this.SHumaninput, out this.bValue_Bool))
                {
                    bResult = this.bValue_Bool;
                    bSuccess = true;
                }
                else
                {
                    bResult = false;
                    bSuccess = false;
                }
            }

            return bSuccess;
        }

        //────────────────────────────────────────

        static public bool TryParse(
            object data,
            out bool bValue_Out,
            EnumOperationIfErrorvalue enumCellDataErrorSupport,
            object altValue,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.SName_Library, "XenonValue_BoolImpl", "TryParse", log_Reports);

            bool bResult;

            XenonValue_BoolImpl err_BoolCellData;
            if (data is Boolean)
            {
                bValue_Out = (bool)data;

                bResult = true;
            }
            else if (data is XenonValue_BoolImpl)
            {
                XenonValue_BoolImpl boolCellData = (XenonValue_BoolImpl)data;

                if (boolCellData.IsSpaces())
                {
                    // 空白の場合

                    if (EnumOperationIfErrorvalue.Spaces_To_Alt_Value == enumCellDataErrorSupport)
                    {
                        if (altValue is bool)
                        {
                            bValue_Out = (bool)altValue;

                            bResult = true;
                        }
                        else
                        {
                            // エラー
                            bValue_Out = false;//ゴミ値
                            bResult = false;
                            err_BoolCellData = boolCellData;
                            goto gt_Error_AnotherType;
                        }
                    }
                    else
                    {
                        // エラー
                        bValue_Out = false;//ゴミ値
                        bResult = false;
                        err_BoolCellData = boolCellData;
                        goto gt_Error_EmptyString;
                    }

                }
                else if (!boolCellData.bValidated)
                {
                    // エラー（変換に失敗した場合）
                    bValue_Out = false;//ゴミ値
                    bResult = false;
                    err_BoolCellData = boolCellData;
                    goto gt_Error_Invalid;
                }
                else
                {
                    bValue_Out = boolCellData.GetBool();

                    bResult = true;
                }
            }
            else if (null == data)
            {
                // エラー
                bValue_Out = false;//ゴミ値
                bResult = false;
                goto gt_Error_Null;
            }
            else if (!(data is XenonValue))
            {
                // エラー
                bValue_Out = false;//ゴミ値
                bResult = false;
                goto gt_Error_AnotherTypeData;
            }
            else
            {
                // エラー
                bValue_Out = false;//ゴミ値
                bResult = false;
                goto gt_Error_Class;
            }

            // 正常
            goto gt_EndMethod;
            //
            //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_AnotherType:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー543！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　altValue引数には、bool型の値を指定してください。");
                s.Append(Environment.NewLine);
                s.Append("　　boolセル値=[");
                s.Append(err_BoolCellData.SHumaninput);
                s.Append("]");

                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("　　問題箇所ヒント：");
                err_BoolCellData.ToText_Path(s);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_EmptyString:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー531！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　セルに、bool型の値を入れてください。空欄にしないでください。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("　　boolセル値=[");
                s.Append(err_BoolCellData.SHumaninput);
                s.Append("]");

                //
                // ヒント
                err_BoolCellData.ToText_Path(s);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Invalid:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー112！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　bool型に変換できませんでした。[");
                s.Append(err_BoolCellData.SHumaninput);
                s.Append("]");

                //
                // ヒント
                err_BoolCellData.ToText_Path(s);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Null:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー231！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　指定の引数dataに、BoolCellData型の値を指定してください。空っぽでした。");

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_AnotherTypeData:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー332！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　bool型のデータを入れるところで、");
                s.Append(Environment.NewLine);
                s.Append("　別の型[" + data.GetType().Name + "]でした。");

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Class:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー233！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定の引数の値[");
                s.Append(((XenonValue)data).SHumaninput);
                s.Append("]は、BoolCellData型ではありませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　型＝[");
                s.Append(data.GetType().Name);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;

        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return bResult;
        }

        static public bool IsSpaces(object data)
        {
            if (data is XenonValue_BoolImpl)
            {
                return ((XenonValue_BoolImpl)data).bSpaced;
            }

            throw new System.ArgumentException("指定の引数の値[" + ((XenonValue)data).SHumaninput + "]は、bool型ではありませんでした。");
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
            XenonValue_BoolImpl obj2 = obj as XenonValue_BoolImpl;
            if (null != obj2)
            {
                // 空欄同士なら真です。
                if (this.IsSpaces() && obj2.IsSpaces())
                {
                    return true;
                }

                if (this.BValidated && obj2.BValidated)
                {
                    // お互いがブール値なら

                    return this.bValue_Bool == obj2.bValue_Bool;
                }
                else
                {
                    // どちらか片方でも非ブール値なら

                    return this.SHumaninput == obj2.SHumaninput;
                }
            }

            if (obj is bool)
            {
                bool bValue = (bool)obj;

                // このオブジェクトが空欄なら偽。
                if (this.IsSpaces())
                {
                    return false;
                }

                // このオブジェクトが非bool値なら偽。
                if (!this.BValidated)
                {
                    return false;
                }

                // bool値で比較
                return this.bValue_Bool == bValue;
            }

            return false;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// bool型のデータ。
        /// </summary>
        private bool bValue_Bool;

        public bool GetBool()
        {
            if (!bValidated)
            {
                bool bSuccessful = this.BValidated;
                if (!bSuccessful)
                {
                    // 変換に失敗した場合。
                    throw new System.InvalidOperationException("bool型に変換できませんでした。[" + this.SHumaninput + "]");
                }
            }
            return bValue_Bool;
        }

        public void SetBool(bool bValue)
        {
            this.bValue_Bool = bValue;
            this.SHumaninput = bValue.ToString();
        }

        //────────────────────────────────────────

        static public string ParseString(object data)
        {
            string sResult;

            if (data is XenonValue_BoolImpl)
            {
                sResult = ((XenonValue_BoolImpl)data).SHumaninput;
                goto gt_EndMethod;
            }

            //
            // エラー
            //
            Log_TextIndented t = new Log_TextIndentedImpl();
            t.Append("指定の引数の値[");
            t.Append(((XenonValue)data).SHumaninput);
            t.Append("]は、bool型ではありませんでした。");
            t.Append(Environment.NewLine);

            throw new System.ArgumentException(t.ToString());

            //
        //
        //
        //
        gt_EndMethod:
            return sResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 入力データそのままの形。
        /// </summary>
        public override string SHumaninput
        {
            get
            {
                return this.sHumaninput;
            }
            set
            {
                if ("" == value.Trim())
                {
                    bSpaced = true;
                    bValidated = true;
                }
                else
                {
                    bSpaced = false;

                    bValidated = bool.TryParse(value, out bValue_Bool);
                }

                this.sHumaninput = value;
            }
        }

        //────────────────────────────────────────

        public override int GetHashCode()
        {
            return this.SHumaninput.GetHashCode();
        }

        //────────────────────────────────────────
        #endregion



    }
}
