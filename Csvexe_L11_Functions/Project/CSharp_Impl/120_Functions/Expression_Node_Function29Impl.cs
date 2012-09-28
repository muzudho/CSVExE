using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol


namespace Xenon.Functions
{
    public class Expression_Node_Function29Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:入力値の確定;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// コントロールの名前。
        /// </summary>
        public static readonly string S_PM_NAME_CONTROL = PmNames.S_NAME_CONTROL.SName_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function29Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function29Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function29Impl.S_PM_NAME_CONTROL, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

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
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + pg_Method.SHead + "＞";


                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol cct = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                    pg_Logging.SComment_EventCreationMe += "／追加：[" + sName_Usercontrol + "]コントロールが、NAction29を実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe += "／追加：NAction29を実行。";
                }


                this.Perform2(pg_Logging);

                //
                //

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
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                    pg_Logging.SComment_EventCreationMe += "／追加：[" + sName_Usercontrol + "]コントロールが、NAction29を実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe += "／追加：NAction29を実行。";
                }

                this.Perform2(pg_Logging);
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

            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName0 + "]実行";
                pg_Method.Log_Stopwatch.Begin();
            }


            //
            // 指定された引数から、または、
            // このNAction29要素を含んでいる ｃｏｎｔｒｏｌ要素から、コントロールの名前を取得。
            List<Usercontrol> list_Usercontrol;
            if (pg_Logging.BSuccessful)
            {
                // 正常時


                Expression_Node_String ec_Name_Control;

                //
                // コントロール名が指定されていれば、そのコントロール名。
                //
                this.TrySelectAttr(out ec_Name_Control, Expression_Node_Function29Impl.S_PM_NAME_CONTROL, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                string sName_Control = ec_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);


                if ("" == sName_Control.Trim())
                {
                    //コントロール名が指定されていない場合。
                    //
                    //  ・このシステム関数を含んでいるイベント要素→コントロール要素と辿り、コントロール名を取得。
                    Givechapterandverse_Node cf_Event = this.Cur_Givechapterandverse.GetParentByNodename(NamesNode.S_EVENT, false, pg_Logging);

                    if (null != cf_Event)
                    {
                        Givechapterandverse_Node owner_Givechapterandverse_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, pg_Logging);

                        if (null != owner_Givechapterandverse_Control)
                        {
                            bool bHit = owner_Givechapterandverse_Control.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_Control, false, pg_Logging);

                            if (bHit)
                            {
                                ec_Name_Control = new Expression_Node_StringImpl(this, this.Cur_Givechapterandverse);
                                ec_Name_Control.AppendTextNode(
                                    sName_Control,
                                    this.Cur_Givechapterandverse,
                                    pg_Logging
                                    );
                            }
                        }
                        else
                        {
                            //nFcName_prm = null;
                        }

                    }
                    else
                    {
                        //nFcName_prm = null;
                    }
                }

                //
                // 指定のコントロール
                //
                list_Usercontrol = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                    ec_Name_Control,
                    true,
                    pg_Logging
                    );
            }
            else
            {
                list_Usercontrol = new List<Usercontrol>();
            }



            //
            // 妥当性判定を行います。
            //
            if (pg_Logging.BSuccessful)
            {
                if (0 < list_Usercontrol.Count)
                {
                    Usercontrol uct = list_Usercontrol[0];
                    uct.JudgeValidity(pg_Logging);
                }

                //.WriteLine(this.GetType().Name + "#Perform_WrRhn: ◆　妥当性判定を行った。");
            }




            if (pg_Logging.BSuccessful)
            {
                //
                // 指定のコントロールの内容を、データ・ソースから読取り直して最新表示します。
                //

                if (0 < list_Usercontrol.Count)
                {
                    Usercontrol uct = list_Usercontrol[0];

                    //.WriteLine(this.GetType().Name + "#Perform_WrRhn: ◆　指定のコントロールに、データのアップデートを指示。");

                    if (uct.ControlCommon.BAutomaticinputting)
                    {
                        // コンピューターにより自動入力されたとき。
                        //essageBox.Show("コンピュータによって自動入力されました。 コントロールID=[" + this.FormObjectId + "]", "デバッグ");
                    }
                    else
                    {
                        // 手入力による更新。

                        uct.UsercontrolToMemory(pg_Logging);
                    }
                }


                //.WriteLine(this.GetType().Name + "#Perform_WrRhn: ◆　指示終了。");

            }


            //
            //
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion



    }
}
