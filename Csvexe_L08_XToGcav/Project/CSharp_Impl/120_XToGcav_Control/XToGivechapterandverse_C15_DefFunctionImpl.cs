using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using Xenon.Syntax;//Log_TextIndented
using Xenon.Middle;


namespace Xenon.XToGcav
{

    /// <summary>
    /// (Sf) ＜ｆ－ｐａｒａｍ＞
    /// 
    /// ステートレス設計で。
    /// </summary>
    public class XToGivechapterandverse_C15_DefFunctionImpl : XToGivechapterandverse_C_Parser15Impl
    {



        #region アクション
        //────────────────────────────────────────

        public override void XToGivechapterandverse(
            XmlElement cur_X,
            Givechapterandverse_Node parent_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "XToS",log_Reports);
            //
            //



            //
            //
            //
            // 自
            //
            //
            //
            log_Method.WriteWarning_ToConsole("①自 [" + log_Reports.BSuccessful + "]");
            Givechapterandverse_Node cur_Cf;
            if (log_Reports.BSuccessful)
            {
                cur_Cf = this.CreateMyself(cur_X, parent_Cf, memoryApplication, log_Reports);
            }
            else
            {
                cur_Cf = null;
            }



            //
            //
            //
            // 属性
            //
            //
            //
            log_Method.WriteWarning_ToConsole("②属性 [" + log_Reports.BSuccessful + "]");
            if (log_Reports.BSuccessful)
            {
                this.Parse_SAttribute(cur_X, cur_Cf, memoryApplication, log_Reports);
            }



            //
            //
            //
            // 属性テスト
            //
            //
            //
            log_Method.WriteWarning_ToConsole("③属性テスト [" + log_Reports.BSuccessful + "]");
            if (log_Reports.BSuccessful)
            {
                this.Test_Attributes(cur_X, cur_Cf, log_Reports);
            }



            //
            //
            //
            // 子
            //
            //
            //
            log_Method.WriteWarning_ToConsole("④子 [" + log_Reports.BSuccessful + "]");
            if (log_Reports.BSuccessful)
            {
                this.Parse_ChildNodes(cur_X, cur_Cf, memoryApplication, log_Reports);
            }



            //
            //
            //
            // 子テスト
            //
            //
            //
            log_Method.WriteWarning_ToConsole("⑤子テスト [" + log_Reports.BSuccessful + "]");
            if (log_Reports.BSuccessful)
            {
                this.Test_ChildNodes(cur_X, cur_Cf, log_Reports);
            }



            //
            //
            //
            // 親へ連結。
            //
            //
            //
            log_Method.WriteWarning_ToConsole("⑥親へ連結 [" + log_Reports.BSuccessful + "]");
            if (log_Reports.BSuccessful)
            {
                this.LinkToParent(cur_Cf, parent_Cf, memoryApplication, log_Reports);
            }



            goto gt_EndMethod;
        //
        //
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        protected override void LinkToParent(
            Givechapterandverse_Node cur_Cf, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "LinkToParent", log_Reports);
            log_Method.WriteWarning_ToConsole("親要素に、連結。");

            parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf, log_Reports);
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
