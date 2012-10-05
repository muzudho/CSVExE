using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.ConfToExpr
{
    class ConfigurationtreeToExpression_V52_FListboxValidationImpl_ : ConfigurationtreeToExpression_AbstractImpl
    {



        #region アクション
        //────────────────────────────────────────

        public void Translate(
            Configurationtree_Node cur_Conf,//Sv_3FListboxValidation
            UsercontrolListbox uctLst,
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(34)" + cur_Conf.Name);
            }

            //
            //

            // バリデーター設定要素
            Configurationtree_Node cf_ValidatorConfig;
            {
                List<Configurationtree_Node> cfList_ValidatorConfig = uctLst.ControlCommon.Configurationtree_Control.GetChildrenByNodename(NamesNode.S_CODEFILE_VALIDATORS, false, log_Reports);

                if (1 < cfList_ValidatorConfig.Count)
                {
                    throw new Exception("バリデーター設定要素が２つ以上ありました。");
                }
                else if (0 < cfList_ValidatorConfig.Count)
                {
                    cf_ValidatorConfig = cfList_ValidatorConfig[0];
                }
                else
                {
                    cf_ValidatorConfig = null;
                }
            }



            //
            //
            //
            // 自
            //
            //
            //
            Expressionv_3FListboxValidationImpl cur_Exprv = new Expressionv_3FListboxValidationImpl(null, cf_ValidatorConfig, memoryApplication);

            //
            //
            //
            // 子
            //
            //
            //
            List<Configurationtree_Node> cfList_Fnc = cur_Conf.GetChildrenByNodename(NamesNode.S_FNC, false, log_Reports);

            // #デバッグ中
            //d_InMethod.WriteDebug_ToConsole(1, " ＜ａ－ｄｉｓｐｌａｙ＞数＝[" + sv_Cur.Sv_ADisplayList.Count + "]");
            //d_InMethod.WriteDebug_ToConsole(1, " ＜ｆｎｃ　ｎａｍｅ＝”ａ－ｒｅｃｏｒｄ－ｓｅｔ－ｓａｖｅ－ｔｏ”＞数＝[" + sv_Cur.Sv_ASelectRecordList.Count + "]");

            foreach (Configurationtree_Node child_Cf in cfList_Fnc)
            {
                string sName_Fnc;
                child_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Fnc, true, log_Reports);

                if (NamesFnc.S_VLD_SELECT_RECORD == sName_Fnc)
                {
                    ConfigurationtreeToExpression_V53_ASelectRecordImpl_ to = new ConfigurationtreeToExpression_V53_ASelectRecordImpl_();
                    to.Translate(
                        child_Cf,
                        cur_Exprv,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }
                else if (NamesFnc.S_VLD_DISPLAY == sName_Fnc)
                {
                    // ＜ａ－ｄｉｓｐｌａｙ＞要素
                    ConfigurationtreeToExpression_V53_ADisplayImpl_ to = new ConfigurationtreeToExpression_V53_ADisplayImpl_();
                    to.Translate(
                        child_Cf,
                        cur_Exprv,
                        uctLst,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );
                }
                else
                {
                    log_Method.WriteError_ToConsole("未実装です。");
                    throw new Exception("未実装です。");
                }
            }


            goto gt_EndMethod;


            //
        //
        //
        //
        gt_EndMethod:

            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Conf.Name);
            }
            log_Method.EndMethod(log_Reports);

        }

        //────────────────────────────────────────
        #endregion



    }
}
