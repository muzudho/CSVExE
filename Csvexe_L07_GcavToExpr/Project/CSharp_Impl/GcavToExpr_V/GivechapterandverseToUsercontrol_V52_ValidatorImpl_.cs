﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.GcavToExpr
{
    
    class GivechapterandverseToUsercontrol_V52_ValidatorImpl_ : GivechapterandverseToExpression_AbstractImpl
    {



        #region アクション
        //────────────────────────────────────────

        public void GivechapterandverseToUsercontrol(
            Givechapterandverse_Node cur_Cf,//Sv_3Validator ＜validator＞
            Usercontrol ucontrol,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.SName_Library, this, "SToFc",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(41)" + cur_Cf.SName);
            }

            //
            //
            //
            //

            string err_SParameterValue = null;
            Exception err_Excp = null;
            string err_SValue = null;
            string err_SName_Validator = null;



            EnumValidation_Old enumResult = EnumValidation_Old.Thru;

            if (cur_Cf.Dictionary_SAttribute_Givechapterandverse.ContainsKey(PmNames.S_VALUE_RESULT.SName_Pm))
            {
                string sValue_Parameter;
                cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE_RESULT, out sValue_Parameter, true, log_Reports);
                switch (sValue_Parameter)
                {
                    case "OK":
                        enumResult = EnumValidation_Old.Ok;
                        break;
                    case "NG":
                        enumResult = EnumValidation_Old.Ng;
                        break;
                    case "THRU":
                        enumResult = EnumValidation_Old.Thru;
                        break;
                    default:
                        //
                        // エラー。
                        goto gt_Error_UndefinedValidator02;
                }
            }



            string sName;
            string sName_ValidatorTrim;
            {
                PmName pmName = PmNames.S_NAME;
                if (cur_Cf.Dictionary_SAttribute_Givechapterandverse.ContainsKey(pmName.SName_Pm))
                {
                    cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(pmName, out sName, true, log_Reports);
                    sName_ValidatorTrim = sName.Trim();
                }
                else
                {
                    sName = "";
                    sName_ValidatorTrim = "";
                }
            }



            //
            // バリデーターの選択
            switch (sName_ValidatorTrim)
            {
                case NamesFnc.S_VLD_SPACES:
                    {
                        // SToE:
                        Expressionv_SpacesTextValidator_Old nValidator = new Expressionv_SpacesTextValidator_Old(enumResult);

                        ucontrol.AddValidator(
                            nValidator,
                            log_Reports
                            );
                    }
                    break;

                case NamesFnc.S_VLD_MATCH:
                    {
                        string sValue_Parameter;
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_EXPECTED, out sValue_Parameter, false, log_Reports);
                        err_SParameterValue = sValue_Parameter;

                        // SToE:
                        Expressionv_MatchTextValidator_Old ecv_Validator = new Expressionv_MatchTextValidator_Old(sValue_Parameter);

                        ucontrol.AddValidator(
                            ecv_Validator,
                            log_Reports
                            );
                    }
                    break;

                case NamesFnc.S_VLD_INT_RANGE:
                    {
                        bool bSuccessful = true;
                        int nBeginValue = 0;
                        if (bSuccessful)
                        {
                            string sBegin;
                            cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_BEGIN, out sBegin, false, log_Reports);

                            if (!int.TryParse(sBegin, out nBeginValue))
                            {
                                // エラー。
                                err_Excp = null;
                                err_SValue = sBegin;
                                goto gt_Error_InvalidatedBegin02;
                            }
                        }

                        int nEndValue = 0;
                        if (bSuccessful)
                        {
                            string sEnd;
                            cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_END, out sEnd, false, log_Reports);

                            if (!int.TryParse(sEnd, out nEndValue))
                            {
                                // エラー。
                                err_Excp = null;
                                err_SValue = sEnd;
                                goto gt_Error_InvalidatedEnd02;
                            }
                        }

                        if (bSuccessful)
                        {
                            // SToE:
                            Expressionv_IntRangeTextValidator_Old nValidator = new Expressionv_IntRangeTextValidator_Old(nBeginValue, nEndValue);

                            ucontrol.AddValidator(
                                nValidator,
                                log_Reports
                                );
                        }
                    }
                    break;

                case NamesFnc.S_VLD_ALL:
                    {
                        // SToE:
                        Expressionv_AllTextValidator_Old ecv_Validator = new Expressionv_AllTextValidator_Old(enumResult);

                        ucontrol.AddValidator(
                            ecv_Validator,
                            log_Reports
                            );
                    }
                    break;

                default:
                    //
                    // エラー。
                    err_SName_Validator = sName;
                    goto gt_Error_UndefinedValidator03;
            }//switch

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedValidator02:
            // TODO 未定義のバリデーターの場合。
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー806！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("バリデーション設定ファイル読取時。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("[" + PmNames.S_VALUE_RESULT.SName_Pm + "]引数に指定された[" + err_SParameterValue + "]というバリデーターは存在しません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_InvalidatedBegin02:
            // 設定エラー
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー807！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("バリデーション設定ファイル読取時。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("指定された[" + PmNames.S_BEGIN.SName_Pm + "]属性[" + err_SValue + "]は整数ではありません。：" + err_Excp.Message);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_InvalidatedEnd02:
            // 設定エラー
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー808！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("バリデーション設定ファイル読取時。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("指定された[" + PmNames.S_END.SName_Pm + "]属性[" + err_SValue + "]は整数ではありません。：" + err_Excp.Message);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedValidator03:
            // TODO 未定義のバリデーターの場合。
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー809！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("バリデーション設定ファイル読取時。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("指定された[" + err_SName_Validator + "]というバリデーターは存在しません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Cf.SName);
            }
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}