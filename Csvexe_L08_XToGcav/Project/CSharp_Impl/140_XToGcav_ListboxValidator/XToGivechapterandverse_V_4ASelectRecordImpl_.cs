using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{
    class XToGivechapterandverse_V_4ASelectRecordImpl_ : XToGivechapterandverse_C_Parser15Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected override Givechapterandverse_Node CreateMyself(
            XmlElement cur_X,
            Givechapterandverse_Node parent_Cf,
            MemoryApplication memoryApplication, 
            Log_Reports log_Reports
            )
        {
            Givechapterandverse_Node cf_Cur;
            cf_Cur = new Givechapterandverse_NodeImpl(NamesNode.S_FNC, parent_Cf);

            return cf_Cur;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        protected override void Parse_ChildNodes(
            XmlElement cur_X,
            Givechapterandverse_Node cf_Cur,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────

        protected override void LinkToParent(
            Givechapterandverse_Node cur_Cf, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf,log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
