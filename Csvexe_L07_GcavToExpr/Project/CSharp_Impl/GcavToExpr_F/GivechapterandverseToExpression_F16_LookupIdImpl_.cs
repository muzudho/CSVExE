using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//Log_TextIndented
using Xenon.Table;//NFldNameImpl
using Xenon.Middle;

namespace Xenon.GcavToExpr
{

    /// <summary>
    /// (Sf) ＜ｌｏｏｋｕｐ－ｉｄ＞要素　属性連結
    /// 
    /// S→E。
    /// </summary>
    class ConfigurationtreeToExpression_F16_LookupIdImpl_ : ConfigurationtreeToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        public override void Translate(
            Configurationtree_Node cur_Cf,//＜ｌｏｏｋｕｐ－ｉｄ＞
            Expression_Node_String parent_Ec,//＜　Ｓｆ：ｔｅｘｔ－ｔｅｍｐｌａｔｅ；＞
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            if (log_Method.CanDebug(1))
            {
                pg_ParsingLog.Increment("(9)" + cur_Cf.Name);
            }

            //
            //

            //
            //
            //
            // 自
            //
            //
            //
            Expression_Node_String cur_Ec = new Expression_Node_StringImpl(parent_Ec, cur_Cf);


            //
            //
            //
            // 親へ連結　（value属性）
            //
            //
            //
            {
                //
                // 自要素の value="" 属性を、親へ連結
                //
                PmName pmName = PmNames.S_VALUE;

                string sValue;
                bool bHit = cur_Cf.Dictionary_Attribute.TryGetValue(pmName, out sValue, false, log_Reports);
                if (bHit)
                {

                    cur_Ec.AppendTextNode(
                        sValue,
                        cur_Cf,
                        log_Reports
                        );

                    //
                    //
                    //
                    // 子
                    //
                    //
                    //
                    this.ParseChild_InConfigurationtreeToExpression(
                        cur_Cf,
                        cur_Ec,//自
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );

                    //
                    //
                    //
                    // 親へ連結　※属性連結
                    //
                    //
                    //
                    parent_Ec.Dictionary_Expression_Attribute.Set(PmNames.S_LOOKUP_ID.Name_Pm, cur_Ec, log_Reports);

                    goto gt_EndMethod;
                }
                else
                {
                }

            }


            //
            //
            //
            // 子
            //
            //
            //
            {
                //＜ａ－ｄｅｆａｕｌｔ＞の子要素を確認し、親＜ｆ－ｓｗｉｔｃｈ＞のdefault属性に追加します。

                this.ParseChild_InConfigurationtreeToExpression(
                    cur_Cf,
                    cur_Ec,
                    memoryApplication,
                    pg_ParsingLog,
                    log_Reports
                    );
            }


            //
            //
            //
            // 親へ連結
            //
            //
            //
            parent_Ec.Dictionary_Expression_Attribute.Set(PmNames.S_LOOKUP_ID.Name_Pm, cur_Ec, log_Reports);


            //
            //
            //
            // 親へ連結 debug
            //
            //
            //
            if (log_Method.CanDebug(1))
            {
                string parent_SName_Fnc;
                parent_Ec.Dictionary_Expression_Attribute.TrySelect(out parent_SName_Fnc, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);
                log_Method.WriteDebug_ToConsole( " ☆☆☆☆☆☆☆☆ 親＜[" + parent_Ec.Cur_Configurationtree.Name + "]　ｎａｍｅ＝”[" + parent_SName_Fnc + "]”　＞");

                string sName_MyFnc;
                cur_Ec.Dictionary_Expression_Attribute.TrySelect(out sName_MyFnc, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);
                log_Method.WriteDebug_ToConsole( " ☆☆☆☆☆☆☆☆ 自＜[" + cur_Ec.Cur_Configurationtree.Name + "]　ｎａｍｅ＝”[" + sName_MyFnc + "]”　＞");
            }


            goto gt_EndMethod;
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
