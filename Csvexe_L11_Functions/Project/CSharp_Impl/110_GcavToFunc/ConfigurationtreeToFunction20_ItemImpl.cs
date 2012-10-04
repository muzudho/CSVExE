using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Functions
{


    public class ConfigurationtreeToFunction20_ItemImpl : ConfigurationtreeToFunction00_ItemImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public ConfigurationtreeToFunction20_ItemImpl()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override void Translate_Step2(
            ConfigurationtreeToFunction_Item parentProcesser,
            Configurationtree_Node action_Gcav,
            Expression_Node_Function parent_Expr_Func,//todo:何これ？
            MemoryApplication owner_MemoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Expression_Node_String ec_ArgListboxName;
            parent_Expr_Func.TrySelectAttribute(out ec_ArgListboxName, Expression_Node_Function20Impl.PM_NAME_CONTROL_LISTBOX, EnumHitcount.One_Or_Zero, log_Reports);

            if ("" == ec_ArgListboxName.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports))
            {
                // 引数 listboxFcName が指定されていない場合は、その記述が書かれているコントロールの名前を入れる。

                Configurationtree_Node cf_Event = action_Gcav.GetParentByNodename(NamesNode.S_EVENT, true, log_Reports);
                if (log_Reports.Successful)
                {
                    Configurationtree_Node parent_Configurationtree_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, log_Reports);

                    string sName_Usercontrol;
                    parent_Configurationtree_Control.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Usercontrol, true, log_Reports);
                    ec_ArgListboxName.AppendTextNode(sName_Usercontrol, action_Gcav, log_Reports);
                }
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
