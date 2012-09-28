using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{
    class XToGivechapterandverse_V_5FAllFieldsIsEmptyImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected override Givechapterandverse_Node CreateMyself(
            XmlElement cur_X, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            Givechapterandverse_Node cur_Cf;
            cur_Cf = new Givechapterandverse_NodeImpl(NamesNode.S_FNC, parent_Cf);

            return cur_Cf;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        protected override void Parse_SAttribute(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "Parse_SAttr",log_Reports);
            //
            //

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        protected override void LinkToParent(
            Givechapterandverse_Node cur_Cf, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
        }

        //────────────────────────────────────────
        #endregion



    }
}
