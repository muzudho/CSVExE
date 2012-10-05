using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.ConfToExpr
{
    /// <summary>
    /// 「S■ａｒｇ」→「E■ａｒｇ」
    /// </summary>
    public class ConfigurationtreeToExpression_F14_FArgImpl : ConfigurationtreeToExpression_F14n16_AbstractImpl_
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ＜ａｒｇ１＞
        /// </summary>
        /// <param name="oFStrNode"></param>
        /// <param name="nFAelem"></param>
        /// <param name="moOpyopyo"></param>
        /// <param name="log_Reports"></param>
        public override void Translate(
            Configurationtree_Node cur_Cf,//「S■ａｒｇ１」
            Expression_Node_String parent_Ec,//親「E■ｆｎｃ」
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "SToE",log_Reports);

            //
            // デバッグオープンの前に。
            //
            // 「S■ａｒｇ１　ｎａｍｅ＝”★”」属性
            //
            string sName_MyFnc;
            cur_Cf.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_MyFnc, false, log_Reports);

            if (log_Method.CanDebug(1))
            {
                Dictionary<string, string> s_Dic = new Dictionary<string, string>();
                s_Dic.Add(PmNames.S_NAME.Name_Pm, sName_MyFnc);
                pg_ParsingLog.Increment("(6.ａｒｇ１・３要素)" + cur_Cf.Name, s_Dic);
            }

            //
            //

            if (log_Method.CanDebug(2))
            {
                log_Method.WriteDebug_ToConsole( "「S■ａｒｇ１・３」要素　解析開始┌────────────────┐　自ａｒｇ１・３は、e_Parent=[" + parent_Ec.Cur_Configurationtree.Name + "]の”" + sName_MyFnc + "”属性になる。");
            }


            string parent_SName_Fnc;
            {
                // ヒット必須にするとエラーになる？
                parent_Ec.TrySelectAttribute(out parent_SName_Fnc, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                if (!log_Reports.Successful)
                {
                    goto gt_EndMethod;
                }

                //if (0 < d_InMethod.NDebugLevel)
                //{
                //    if (NamesNode.S_FNC != e_Parent.Cur_Configurationtree.Name)
                //    {
                //        d_InMethod.WriteDebug_ToConsole(1, "ｆｎｃ以外の親要素「E■[" + e_Parent.Cur_Configurationtree.Name + "]」");
                //    }
                //}
            }

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
            // 属性
            //
            //
            //
            if (log_Reports.Successful)
            {
                // 元からあった。
                this.ParseAttr_InConfigurationtreeToExpression(
                    cur_Cf,
                    cur_Ec,
                    true,//ｎａｍｅ属性は必須。
                    true,//ｖａｌｕｅ属性は、子＜ｆ－ｓｔｒ＞にする。
                    log_Reports
                    );
            }


            //
            //
            //
            // 子
            //
            //
            //
            if (log_Reports.Successful)
            {
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
            // 親へ連結　※属性連結。
            //
            //
            //
            if (log_Reports.Successful)
            {
                parent_Ec.SetAttribute(sName_MyFnc, cur_Ec, log_Reports);
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Cf.Name);
            }

            if (log_Method.CanDebug(2))
            {
                log_Method.WriteDebug_ToConsole( "「S■ａｒｇ１・３」要素　解析終了└────────────────┘");
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
