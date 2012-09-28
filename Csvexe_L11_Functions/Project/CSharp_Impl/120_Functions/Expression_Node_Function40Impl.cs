using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol

namespace Xenon.Functions
{
    public class Expression_Node_Function40Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:可視化;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// コントロール名。
        /// </summary>
        public static readonly string S_PM_NAME_FC = PmNames.S_NAME_CONTROL.SName_Pm;

        /// <summary>
        /// 可視。コントロールの可視／不可視を切り替えます。true または false を指定してください。
        /// </summary>
        public static string S_PM_VALUE_VISIBLED = PmNames.S_VALUE_VISIBLED.SName_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function40Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "E_Sa40Impl",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function40Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function40Impl.S_PM_NAME_FC, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function40Impl.S_PM_VALUE_VISIBLED, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

            //
            pg_Method.EndMethod(pg_Logging);
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
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);

            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                this.Perform2(
                    pg_Logging
                    );

                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.ExpressionfncPrmset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(
                    pg_Logging
                    );

            }

            //
            //
            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────

        protected void Perform2(
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform2",pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                string sFncName;
                this.TrySelectAttr(out sFncName, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);
                pg_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName + "]実行";
                pg_Method.Log_Stopwatch.Begin();
            }


            {
                Expression_Node_String ec_ArgFcName;
                this.TrySelectAttr(out ec_ArgFcName, Expression_Node_Function40Impl.S_PM_NAME_FC, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                // コントロールを1つ検索。
                List<Usercontrol> list_FcUc = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                    ec_ArgFcName, true, pg_Logging);

                if (pg_Logging.BSuccessful)
                {
                    Usercontrol fcUc = list_FcUc[0];

                    string sValue;
                    this.TrySelectAttr(out sValue, Expression_Node_Function40Impl.S_PM_VALUE_VISIBLED, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                    bool bValue;
                    if (Boolean.TryParse(sValue, out bValue))
                    {
                        fcUc.ControlCommon.BAutomaticinputting = true;//自動入力。
                        //fcUc.UsercontrolEnabled = bValue; // todo:可視／不可視にしたい。
                        fcUc.UsercontrolVisible = bValue;
                        fcUc.ControlCommon.BAutomaticinputting = false;//自動入力解除。

                        // なぜか、Enabledを変更しても、背景色が　更新されない。
                        // 値は変更されてないからか。
                        // 背景色を更新するために、JudgeValidity を呼んでやる。
                        //
                        // トゥゲザーでやるべきか？
                        fcUc.JudgeValidity(pg_Logging);
                    }
                }
            }

            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion



    }
}
