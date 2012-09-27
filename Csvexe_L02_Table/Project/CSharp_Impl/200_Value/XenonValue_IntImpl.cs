﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//WarningReports


namespace Xenon.Table
{
    public class XenonValue_IntImpl : XenonValue_AbstractImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────        

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="sourceHintName"></param>
        public XenonValue_IntImpl(String sConfigStack)
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

        public bool TryGet(out int nResult)
        {
            bool bSuccess;

            if (this.BValidated)
            {
                nResult = this.nValue_Int;
                bSuccess = true;
            }
            else
            {
                if (int.TryParse(this.SHumaninput, out this.nValue_Int))
                {
                    nResult = this.nValue_Int;
                    bSuccess = true;
                }
                else
                {
                    nResult = 0;
                    bSuccess = false;
                }
            }

            return bSuccess;
        }

        //────────────────────────────────────────        

        static public string ParseString(object data)
        {
            if (data is XenonValue_IntImpl)
            {
                return ((XenonValue_IntImpl)data).SHumaninput;
            }

            //
            // 以下、エラー対応。
            //
            // DBNull でここをよく通る。
            //
            //
            //if (false)
            //{
            //    Log_TextIndented t = new Log_TextIndentedImpl();

            //    if (data is DBNull)
            //    {
            //        t.Append("int型の値が必要なところでしたが、値が存在しませんでした。（DBNull）");
            //        t.Append(Environment.NewLine);
            //    }
            //    else
            //    {
            //        t.Append("指定の引数の値[");
            //        t.Append(((O_Value)data).SHumanInput);
            //        t.Append("]は、int型ではありませんでした。");
            //        t.Append(Environment.NewLine);
            //    }

            //    //.WriteLine("OValue_IntImpl.GetString: エラーメッセージ＝" + dt.ToString());
            //    throw new System.ArgumentException(t.ToString());
            //}

            //
            //
            //
            //

            return "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="outInt"></param>
        /// <returns>正常終了なら真、異常終了なら偽。</returns>
        static public bool TryParse(
            object data,
            out int nValue_Out,
            EnumOperationIfErrorvalue enumCellDataErrorSupport,
            object altValue,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.SName_Library, "OValue_IntImpl", "TryParse",log_Reports);

            bool bResult;

            XenonValue_IntImpl err_IntCellData;
            if (data is XenonValue_IntImpl)
            {
                XenonValue_IntImpl intCellData = (XenonValue_IntImpl)data;

                if (intCellData.IsSpaces())
                {
                    //
                    // 空白の場合
                    //

                    if (EnumOperationIfErrorvalue.Spaces_To_Alt_Value == enumCellDataErrorSupport)
                    {
                        if (altValue is int)
                        {
                            nValue_Out = (int)altValue;

                            bResult = true;
                        }
                        else
                        {
                            // エラー
                            nValue_Out = 0;//ゴミ値
                            bResult = false;
                            err_IntCellData = intCellData;
                            goto gt_Error_AnotherType2;
                        }
                    }
                    else
                    {
                        // エラー
                        nValue_Out = 0;//ゴミ値
                        bResult = false;
                        err_IntCellData = intCellData;
                        goto gt_Error_EmptyString;
                    }
                }
                else if (!intCellData.bValidated)
                {
                    // エラー（変換に失敗した場合）
                    nValue_Out = 0;//ゴミ値
                    bResult = false;
                    err_IntCellData = intCellData;
                    goto gt_Error_Invalid;
                }
                else
                {
                    // 正常処理
                    nValue_Out = intCellData.nValue_Int;

                    bResult = true;
                }

            }
            else if (null == data)
            {
                // エラー
                nValue_Out = 0;//ゴミ値
                bResult = false;
                goto gt_Error_Null;
            }
            else if (!(data is XenonValue))
            {
                // エラー
                nValue_Out = 0;//ゴミ値
                bResult = false;
                goto gt_Error_AnotherType;
            }
            else
            {
                // エラー
                nValue_Out = 0;//ゴミ値
                bResult = false;
                goto gt_Error_Class;
            }

            // 正常
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_AnotherType2:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー201！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　altValue引数には、int型の値を指定してください。");
                s.Append(Environment.NewLine);
                s.Append("　　intセル値=[");
                s.Append(err_IntCellData.SHumaninput);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　　問題箇所ヒント：");
                s.Append(Environment.NewLine);
                s.Append("　　　");
                err_IntCellData.ToText_Path(s);
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_EmptyString:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー201！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("▲エラー202！(" + Info_Table.SName_Library + ")");
                s.NewLine();
                s.Append("　セルに、int型の値を入れてください。空欄にしないでください。");
                s.Append(Environment.NewLine);
                s.Append("　　intセル値=[");
                s.Append(err_IntCellData.SHumaninput);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　　問題箇所ヒント：");
                s.Append(Environment.NewLine);
                s.Append("　　　");
                err_IntCellData.ToText_Path(s);
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Invalid:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー111！！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　int型に変換できませんでした。[");
                s.Append(err_IntCellData.SHumaninput);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　　問題箇所ヒント：");
                s.Append(Environment.NewLine);
                s.Append("　　　");
                err_IntCellData.ToText_Path(s);
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Null:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー110！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　指定の引数dataに、IntCellData型の値を指定してください。空っぽでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_AnotherType:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー111！", log_Method);

                Log_TextIndentedImpl s = new Log_TextIndentedImpl();
                s.Append("　指定の引数dataに、CellData型の値を指定してください。");
                s.Append(Environment.NewLine);
                s.Append("　別の型[" + data.GetType().Name + "でした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Class:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー112！", log_Method);

                Log_TextIndentedImpl s = new Log_TextIndentedImpl();
                s.Append("　指定の引数の値[");
                s.Append(((XenonValue)data).SHumaninput);
                s.Append("]は、IntCellData型ではありませんでした。");
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

            //
            // 型が同じ時。
            //
            XenonValue_IntImpl intCellData = obj as XenonValue_IntImpl;
            if (null != intCellData)
            {
                // 空欄同士なら真です。
                if (this.IsSpaces() && intCellData.IsSpaces())
                {
                    return true;
                }

                if (this.BValidated && intCellData.BValidated)
                {
                    // お互いが数値なら、数値で判定

                    return this.nValue_Int == intCellData.nValue_Int;
                }
                else
                {
                    // どちらか片方でも非数値なら、文字列で判定

                    return this.SHumaninput == intCellData.SHumaninput;
                }
            }

            if (obj is int)
            {
                int nIntValue = (int)obj;

                // このオブジェクトが空欄なら偽。
                if (this.IsSpaces())
                {
                    return false;
                }

                // このオブジェクトが非int値なら偽。
                if (!this.BValidated)
                {
                    return false;
                }

                // 数値で比較
                return this.nValue_Int == nIntValue;
            }

            return false;
        }

        //────────────────────────────────────────        

        static public bool IsSpaces(object data)
        {
            if (data is XenonValue_IntImpl)
            {
                return ((XenonValue_IntImpl)data).bSpaced;
            }

            throw new System.ArgumentException("指定の引数の値[" + ((XenonValue)data).SHumaninput + "]は、int型ではありませんでした。");
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// int型のデータ。
        /// </summary>
        private int nValue_Int;

        /// <summary>
        /// int型値をセットします。
        /// </summary>
        /// <param name="nValue"></param>
        public void SetInt(int nValue)
        {
            nValue_Int = nValue;
            bSpaced = false;
            bValidated = true;
            this.SHumaninput = nValue_Int.ToString();
        }

        //────────────────────────────────────────        

        /// <summary>
        /// 入力データそのままの形。
        /// </summary>
        public override string SHumaninput
        {
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

                    if (!int.TryParse(value, out nValue_Int))
                    {
                        // エラー
                        bValidated = false;
                    }
                    else
                    {
                        bValidated = true;
                    }
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
