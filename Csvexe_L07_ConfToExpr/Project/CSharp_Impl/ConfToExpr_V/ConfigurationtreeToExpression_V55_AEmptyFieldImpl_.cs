using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.ConfToExpr
{
    
    class ConfigurationtreeToExpression_V55_AEmptyFieldImpl_ : ConfigurationtreeToExpression_AbstractImpl
    {



        #region アクション
        //────────────────────────────────────────

        public void Translate(
            Configurationtree_Node cur_Cf,//＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞
            Expression_Node_String parent_Expr,//Expressionv_5FAllTrueImpl
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(39)" + cur_Cf.Name);
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
            Expressionv_6AEmptyFieldImpl ecv_AEmptyFld = new Expressionv_6AEmptyFieldImpl(parent_Expr, cur_Cf, memoryApplication);


            //
            //
            //
            // 属性
            //
            //
            //
            {
                {
                    PmName pmName = PmNames.S_TYPE;
                    string sValue;
                    bool bHit = cur_Cf.Dictionary_Attribute.TryGetValue(pmName, out sValue, false, log_Reports);
                    if (bHit)
                    {
                        Expression_Leaf_String ec_Leaf = new Expression_Leaf_StringImpl(sValue, parent_Expr, cur_Cf);
                        ecv_AEmptyFld.SetAttribute(pmName.Name_Pm, ec_Leaf, log_Reports);
                        //evAEmptyFld.Dictionary_SAttribute.Add(sAttrName, s_Cur.SAttrDic.Get(sAttrName, true, log_Reports));
                    }
                    else
                    {
                        // クリアー上書きしない。
                    }
                }

                {
                    PmName pmName = PmNames.S_DESCRIPTION;
                    string sValue;
                    bool bHit = cur_Cf.Dictionary_Attribute.TryGetValue(pmName, out sValue, false, log_Reports);
                    if (bHit)
                    {
                        Expression_Leaf_String ec_Leaf = new Expression_Leaf_StringImpl(sValue, parent_Expr, cur_Cf);
                        ecv_AEmptyFld.SetAttribute(pmName.Name_Pm, ec_Leaf, log_Reports);
                    }
                    else
                    {
                        // クリアー上書きしない。
                    }
                }
            }


            //
            //
            //
            // 親へ連結
            //
            //
            //
            {
                // TODO:?
                parent_Expr.List_Expression_Child.Add(ecv_AEmptyFld, log_Reports);
            }


            //
            //
            //
            // 子
            //
            //
            //
            {
                // ＜ｆ－ｃｅｌｌ＞要素のリスト
                this.ParseChild_InConfigurationtreeToExpression(
                    cur_Cf,
                    ecv_AEmptyFld,
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
                pg_ParsingLog.Decrement(cur_Cf.Name);
            }
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
