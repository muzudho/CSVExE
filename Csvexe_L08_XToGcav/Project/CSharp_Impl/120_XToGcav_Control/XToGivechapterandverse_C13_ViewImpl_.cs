using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using Xenon.Syntax;//Log_TextIndented
using Xenon.Controls;
using Xenon.Middle;

namespace Xenon.XToGcav
{


    /// <summary>
    /// (Sf) ＜ｖｉｅｗ＞
    /// </summary>
    class XToGivechapterandverse_C13_ViewImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ＜ｖｉｅｗ＞要素を読取り、s_Dataを作成。
        /// </summary>
        /// <param name="x_View"></param>
        /// <param name="s_Parent"></param>
        /// <param name="log_Reports"></param>
        public override void XToGivechapterandverse(
            XmlElement cur_X,
            Givechapterandverse_Node parent_Cf,//＜ｃｏｎｔｒｏｌ＞
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToS",log_Reports);
            //
            //



            //
            //
            //
            // 自
            //
            //
            //
            Givechapterandverse_Node cur_Sf = this.CreateMyself(cur_X, parent_Cf, memoryApplication, log_Reports);



            //
            //
            //
            // 属性
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Parse_SAttribute(cur_X, cur_Sf, memoryApplication, log_Reports);
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
                this.Parse_ChildNodes(cur_X, cur_Sf, memoryApplication, log_Reports);
            }



            //
            //
            //
            // 親へ連結
            //
            //
            //
            if (log_Reports.Successful)
            {
                parent_Cf.List_ChildGivechapterandverse.Add(cur_Sf, log_Reports);
            }



            //
            //
            //
            //

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return;
        }

        //────────────────────────────────────────

        protected override void Parse_ChildNodes(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            XToGivechapterandverse_C14_Hub to = new XToGivechapterandverse_C14_HubImpl();
            to.XToGivechapterandverse(
                cur_X,
                cur_Cf,
                memoryApplication,
                log_Reports
                );
        }

        //────────────────────────────────────────
        #endregion



    }
}
