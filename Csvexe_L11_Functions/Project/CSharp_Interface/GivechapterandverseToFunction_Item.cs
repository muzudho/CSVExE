using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Functions
{
    public interface ConfigurationtreeToFunction_Item
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// s_Actionをもとに、Fc_EventHandler を作成します。
        /// 
        /// E_ActionCollectionImpl#ApplyArg で使用。
        /// </summary>
        /// <param name="oAction"></param>
        /// <returns></returns>
        Expression_Node_Function Translate(
            string sName_Action,
            Configurationtree_Node cur_Cf_Action,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
        );

        //────────────────────────────────────────

        void Translate_Step1(
            ConfigurationtreeToFunction_Item parentProcesser,
            Configurationtree_Node action_Gcav,
            Expression_Node_Function parent_Ec_Sf,//todo:何これ？
            MemoryApplication owner_MemoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        void Translate_Step2(
            ConfigurationtreeToFunction_Item parentProcesser,
            Configurationtree_Node action_Gcav,
            Expression_Node_Function parent_Ec_Sf,//todo:何これ？
            MemoryApplication owner_MemoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
