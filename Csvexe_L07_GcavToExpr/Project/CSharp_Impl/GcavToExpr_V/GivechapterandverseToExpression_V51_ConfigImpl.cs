﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{

    public class GivechapterandverseToExpression_V51_ConfigImpl : GivechapterandverseToExpression_AbstractImpl, GivechapterandverseToExpression_V51_Config
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// S → E。
        /// </summary>
        public void Translate(
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.SName_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(41)バリデーションファイル");
            }

            //
            //
            //
            //

            if (log_Reports.BSuccessful)
            {

                //
                // コントロール順
                memoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol uct, ref bool bRemove, ref bool bBreak)
                {
                    if (uct is UsercontrolListbox)
                    {
                        //
                        // リストボックスなら。
                        UsercontrolListbox uctLst = (UsercontrolListbox)uct;

                        List<Givechapterandverse_Node> cfList_ValidatorConfig = uctLst.ControlCommon.Givechapterandverse_Control.GetChildrenByNodename(NamesNode.S_CODEFILE_VALIDATORS, false, log_Reports);
                        if (1 < cfList_ValidatorConfig.Count)
                        {
                            throw new Exception("バリデーター設定要素が２つ以上ありました。");
                        }
                        else if (0 < cfList_ValidatorConfig.Count)
                        {
                            Givechapterandverse_Node cf_ValidatorConfig = cfList_ValidatorConfig[0];

                            // (Sv)コントロールのSv
                            {
                                GivechapterandverseToExpression_V52_FListboxValidationImpl_ to = new GivechapterandverseToExpression_V52_FListboxValidationImpl_();

                                List<Givechapterandverse_Node> cfList_Validation = cf_ValidatorConfig.GetChildrenByNodename(NamesNode.S_F_LISTBOX_VALIDATION, false, log_Reports);

                                foreach (Givechapterandverse_Node child_Cf in cfList_Validation)
                                {

                                    //
                                    // ＜ｆ－ｌｉｓｔ－ｂｏｘ－ｖａｌｉｄａｔｉｏｎ＞
                                    to.Translate(
                                        child_Cf,
                                        uctLst,
                                        memoryApplication,
                                        pg_ParsingLog,
                                        log_Reports
                                        );

                                }//foreach
                            }

                            {
                                GivechapterandverseToUsercontrol_V52_ValidatorImpl_ to = new GivechapterandverseToUsercontrol_V52_ValidatorImpl_();

                                List<Givechapterandverse_Node> cfList_Validator = cf_ValidatorConfig.GetChildrenByNodename(NamesNode.S_VALIDATOR, false, log_Reports);
                                foreach (Givechapterandverse_Node cf in cfList_Validator)
                                {
                                    to.GivechapterandverseToUsercontrol(
                                        cf,
                                        uct,
                                        pg_ParsingLog,
                                        log_Reports
                                        );
                                }
                            }

                        }//Ov

                    }
                    else
                    {
                    }
                });
            }

            goto gt_EndMethod;


            //
        //
        //
        //
        gt_EndMethod:

            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement("(41)バリデーションファイル");
            }
            log_Method.EndMethod(log_Reports);

        }

        //────────────────────────────────────────
        #endregion



    }
}