using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;

namespace Xenon.ConfToExpr
{

    public class ConfigurationtreeToExpression_V51_ConfigImpl : ConfigurationtreeToExpression_AbstractImpl, ConfigurationtreeToExpression_V51_Config
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// S → E。
        /// </summary>
        public void Translate(
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(41)バリデーションファイル");
            }

            //
            //
            //
            //

            if (log_Reports.Successful)
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

                        List<Configurationtree_Node> cfList_ValidatorConfig = uctLst.ControlCommon.Configurationtree_Control.GetChildrenByNodename(NamesNode.S_CODEFILE_VALIDATORS, false, log_Reports);
                        if (1 < cfList_ValidatorConfig.Count)
                        {
                            throw new Exception("バリデーター設定要素が２つ以上ありました。");
                        }
                        else if (0 < cfList_ValidatorConfig.Count)
                        {
                            Configurationtree_Node cf_ValidatorConfig = cfList_ValidatorConfig[0];

                            // (Sv)コントロールのSv
                            {
                                ConfigurationtreeToExpression_V52_FListboxValidationImpl_ to = new ConfigurationtreeToExpression_V52_FListboxValidationImpl_();

                                List<Configurationtree_Node> cfList_Validation = cf_ValidatorConfig.GetChildrenByNodename(NamesNode.S_F_LISTBOX_VALIDATION, false, log_Reports);

                                foreach (Configurationtree_Node child_Cf in cfList_Validation)
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
                                ConfigurationtreeToUsercontrol_V52_ValidatorImpl_ to = new ConfigurationtreeToUsercontrol_V52_ValidatorImpl_();

                                List<Configurationtree_Node> cfList_Validator = cf_ValidatorConfig.GetChildrenByNodename(NamesNode.S_VALIDATOR, false, log_Reports);
                                foreach (Configurationtree_Node cf in cfList_Validator)
                                {
                                    to.ConfigurationtreeToUsercontrol(
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
