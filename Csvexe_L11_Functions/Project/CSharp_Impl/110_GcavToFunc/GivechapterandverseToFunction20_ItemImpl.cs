using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Functions
{


    public class GivechapterandverseToFunction20_ItemImpl : GivechapterandverseToFunction00_ItemImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public GivechapterandverseToFunction20_ItemImpl()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override void Translate_Step2(
            GivechapterandverseToFunction_Item parentProcesser,
            Givechapterandverse_Node action_Gcav,
            Expression_Node_Function parent_Expr_Func,//todo:何これ？
            MemoryApplication owner_MemoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports pg_Logging
            )
        {
            Expression_Node_String ec_ArgListboxName;
            parent_Expr_Func.TrySelectAttr(out ec_ArgListboxName, Expression_Node_Function20Impl.S_PM_NAME_FC_LST, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if ("" == ec_ArgListboxName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging))
            {
                // 引数 listboxFcName が指定されていない場合は、その記述が書かれているコントロールの名前を入れる。

                Givechapterandverse_Node cf_Event = action_Gcav.GetParentByNodename(NamesNode.S_EVENT, true, pg_Logging);
                if (pg_Logging.BSuccessful)
                {
                    Givechapterandverse_Node parent_Givechapterandverse_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, pg_Logging);

                    string sName_Usercontrol;
                    parent_Givechapterandverse_Control.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Usercontrol, true, pg_Logging);
                    ec_ArgListboxName.AppendTextNode(sName_Usercontrol, action_Gcav, pg_Logging);
                }
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
