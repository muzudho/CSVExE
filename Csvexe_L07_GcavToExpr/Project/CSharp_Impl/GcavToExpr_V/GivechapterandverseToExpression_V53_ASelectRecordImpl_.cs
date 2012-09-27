using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.GcavToExpr
{
    /// <summary>
    /// ＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ａ－ｒｅｃｏｒｄ－ｓｅｔ－ｓａｖｅ－ｔｏ；＞要素
    /// </summary>
    class GivechapterandverseToExpression_V53_ASelectRecordImpl_ : GivechapterandverseToExpression_AbstractImpl
    {



        #region アクション
        //────────────────────────────────────────

        public void Translate(
            Givechapterandverse_Node cur_Cf,//＜ａ－ｓｅｌｅｃｔ－ｒｅｃｏｒｄ＞
            Expressionv_3FListboxValidationImpl parent_Exprv,
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.SName_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(36)" + cur_Cf.SName);
            }

            //
            //
            //
            //


            //
            //
            //
            // 自
            //
            //
            //
            Expressionv_4ASelectRecordImpl cur_Exprv = new Expressionv_4ASelectRecordImpl(parent_Exprv, cur_Cf, memoryApplication);


            //
            //
            //
            // 属性
            //
            //
            //
            {
                {
                    PmName pmName = PmNames.S_FIELD_KEY;
                    if (cur_Cf.Dictionary_SAttribute_Givechapterandverse.ContainsKey(pmName.SName_Pm))
                    {
                        string sValue;
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(pmName, out sValue, true, log_Reports);

                        Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(parent_Exprv, cur_Cf);
                        ec_Str.AppendTextNode(
                            sValue,
                            cur_Cf,
                            log_Reports
                            );
                        cur_Exprv.Expression_Field = ec_Str;
                    }
                }

                {
                    PmName pmName = PmNames.S_VALUE_KEY;
                    if (cur_Cf.Dictionary_SAttribute_Givechapterandverse.ContainsKey(pmName.SName_Pm))
                    {
                        string sValue;
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(pmName, out sValue, true, log_Reports);

                        Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(parent_Exprv, cur_Cf);
                        ec_Str.AppendTextNode(
                            sValue,
                            cur_Cf,
                            log_Reports
                            );
                        cur_Exprv.Expression_LookupVal = ec_Str;
                    }
                }

                {
                    PmName pmName = PmNames.S_REQUIRED;
                    if (cur_Cf.Dictionary_SAttribute_Givechapterandverse.ContainsKey(pmName.SName_Pm))
                    {
                        string sValue;
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(pmName, out sValue, true, log_Reports);

                        Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(parent_Exprv, cur_Cf);
                        ec_Str.AppendTextNode(
                            sValue,
                            cur_Cf,
                            log_Reports
                            );
                        cur_Exprv.Expression_Required = ec_Str;
                    }
                }

                {
                    PmName pmName = PmNames.S_FROM;
                    if (cur_Cf.Dictionary_SAttribute_Givechapterandverse.ContainsKey(pmName.SName_Pm))
                    {
                        string sValue;
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(pmName, out sValue, true, log_Reports);

                        Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(parent_Exprv, cur_Cf);
                        ec_Str.AppendTextNode(
                            sValue,
                            cur_Cf,
                            log_Reports
                            );
                        cur_Exprv.Expression_From = ec_Str;
                    }
                }

                {
                    PmName pmName = PmNames.S_STORAGE;
                    if (cur_Cf.Dictionary_SAttribute_Givechapterandverse.ContainsKey(pmName.SName_Pm))
                    {
                        string sValue;
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(pmName, out sValue, true, log_Reports);

                        Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(parent_Exprv, cur_Cf);
                        ec_Str.AppendTextNode(
                            sValue,
                            cur_Cf,
                            log_Reports
                            );
                        cur_Exprv.Expression_Storage = ec_Str;
                    }
                }

                {
                    PmName pmName = PmNames.S_DESCRIPTION;
                    if (cur_Cf.Dictionary_SAttribute_Givechapterandverse.ContainsKey(pmName.SName_Pm))
                    {
                        string sValue;
                        cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(pmName, out sValue, true, log_Reports);

                        Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(parent_Exprv, cur_Cf);
                        ec_Str.AppendTextNode(
                            sValue,
                            cur_Cf,
                            log_Reports
                            );
                        cur_Exprv.Expression_Description = ec_Str;
                    }
                }

            }//属性


            //
            //
            //
            // 親へ連結
            //
            //
            //
            parent_Exprv.List_Expressionv_ASelectRecord.Add(cur_Exprv);//.Add(nA66, Request_SelectingImpl.Unconstraint, log_Reports);


            //
            //
            //
            // 子
            //
            //
            //
            {
                // ＜ｆ－ｃｅｌｌ＞要素のリスト
                this.ParseChild_InGivechapterandverseToExpression(
                    cur_Cf,
                    cur_Exprv,
                    memoryApplication,
                    pg_ParsingLog,
                    log_Reports
                    );
            }

            goto gt_EndMethod;
        //
        //
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
