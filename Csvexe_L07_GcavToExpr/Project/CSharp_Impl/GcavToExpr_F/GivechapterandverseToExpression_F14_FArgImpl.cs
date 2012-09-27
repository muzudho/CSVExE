using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    /// <summary>
    /// 「S■ａｒｇ」→「E■ａｒｇ」
    /// </summary>
    public class GivechapterandverseToExpression_F14_FArgImpl : GivechapterandverseToExpression_F14n16_AbstractImpl_
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
            Givechapterandverse_Node cur_Cf,//「S■ａｒｇ１」
            Expression_Node_String parent_Ec,//親「E■ｆｎｃ」
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.SName_Library, this, "SToE",log_Reports);

            //
            // デバッグオープンの前に。
            //
            // 「S■ａｒｇ１　ｎａｍｅ＝”★”」属性
            //
            string sName_MyFnc;
            cur_Cf.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_MyFnc, false, log_Reports);

            if (log_Method.CanDebug(1))
            {
                Dictionary<string, string> s_Dic = new Dictionary<string, string>();
                s_Dic.Add(PmNames.S_NAME.SName_Pm, sName_MyFnc);
                pg_ParsingLog.Increment("(6.ａｒｇ１・３要素)" + cur_Cf.SName, s_Dic);
            }

            //
            //

            if (log_Method.CanDebug(2))
            {
                log_Method.WriteDebug_ToConsole( "「S■ａｒｇ１・３」要素　解析開始┌────────────────┐　自ａｒｇ１・３は、e_Parent=[" + parent_Ec.Cur_Givechapterandverse.SName + "]の”" + sName_MyFnc + "”属性になる。");
            }


            string parent_SName_Fnc;
            {
                bool bRequired;
                //todo: bRequired = true;//エラー。
                bRequired = false;
                parent_Ec.TrySelectAttr(out parent_SName_Fnc, PmNames.S_NAME.SName_Pm, bRequired, Request_SelectingImpl.Unconstraint, log_Reports);
                if (!log_Reports.BSuccessful)
                {
                    goto gt_EndMethod;
                }

                //if (0 < d_InMethod.NDebugLevel)
                //{
                //    if (NamesNode.S_FNC != e_Parent.Cur_Givechapterandverse.SName)
                //    {
                //        d_InMethod.WriteDebug_ToConsole(1, "ｆｎｃ以外の親要素「E■[" + e_Parent.Cur_Givechapterandverse.SName + "]」");
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
            if (log_Reports.BSuccessful)
            {
                // 元からあった。
                this.ParseAttr_InGivechapterandverseToExpression(
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
            if (log_Reports.BSuccessful)
            {
                this.ParseChild_InGivechapterandverseToExpression(
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
            if (log_Reports.BSuccessful)
            {
                parent_Ec.DicExpression_Attr.Set(sName_MyFnc, cur_Ec, log_Reports);
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                pg_ParsingLog.Decrement(cur_Cf.SName);
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
