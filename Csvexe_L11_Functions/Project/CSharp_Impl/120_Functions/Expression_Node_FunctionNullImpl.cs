using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Functions
{
    public class Expression_Node_FunctionNullImpl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// </summary>
        public static readonly string NAME_FUNCTION = "Sf:ヌルアクション;";

        //────────────────────────────────────────
        #endregion



        #region 初期化
        //────────────────────────────────────────

        public Expression_Node_FunctionNullImpl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression,
            Configuration_Node cur_Conf, 
            object/*MemoryApplication*/ owner_MemoryApplication,
            Log_Reports log_Reports)
        {
            Expression_Node_Function f0 = new Expression_Node_FunctionNullImpl(this.EnumEventhandler,this.List_NameArgumentInitializer,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configuration = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            // 何もしません。

            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
