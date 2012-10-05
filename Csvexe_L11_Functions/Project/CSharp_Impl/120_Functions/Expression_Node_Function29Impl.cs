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

        public static readonly string NAME_FUNCTION = "Sf:入力値の確定;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// コントロールの名前。
        /// </summary>
        public static readonly string PM_NAME_CONTROL = PmNames.S_NAME_CONTROL.Name_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function29Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Conf,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function29Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function29Impl.PM_NAME_CONTROL, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
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
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {
                this.Functionparameterset.Node_EventOrigin += "＜" + log_Method.Fullname + "＞";


                if (this.Functionparameterset.Sender is Customcontrol)
                {
                    Customcontrol cct = (Customcontrol)this.Functionparameterset.Sender;

                    string sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                    log_Reports.Comment_EventCreationMe += "／追加：[" + sName_Usercontrol + "]コントロールが、NAction29を実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe += "／追加：NAction29を実行。";
                }


                this.Execute6_Sub(log_Reports);

                //
                //

                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.Functionparameterset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                if (this.Functionparameterset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.Functionparameterset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                    log_Reports.Comment_EventCreationMe += "／追加：[" + sName_Usercontrol + "]コントロールが、NAction29を実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe += "／追加：NAction29を実行。";
                }

                this.Execute6_Sub(log_Reports);
            }

            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Execute6_Sub(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute6_Sub", log_Reports);

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName0 + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }


            //
            // 指定された引数から、または、
            // このNAction29要素を含んでいる ｃｏｎｔｒｏｌ要素から、コントロールの名前を取得。
            List<Usercontrol> list_Usercontrol;
            if (log_Reports.Successful)
            {
                // 正常時


                Expression_Node_String ec_Name_Control;

                //
                // コントロール名が指定されていれば、そのコントロール名。
                //
                this.TrySelectAttribute(out ec_Name_Control, Expression_Node_Function29Impl.PM_NAME_CONTROL, EnumHitcount.One_Or_Zero, log_Reports);

                string sName_Control = ec_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);


                if ("" == sName_Control.Trim())
                {
                    //コントロール名が指定されていない場合。
                    //
                    //  ・このシステム関数を含んでいるイベント要素→コントロール要素と辿り、コントロール名を取得。
                    Configurationtree_Node cf_Event = this.Cur_Configurationtree.GetParentByNodename(NamesNode.S_EVENT, false, log_Reports);

                    if (null != cf_Event)
                    {
                        Configurationtree_Node owner_Configurationtree_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, log_Reports);

                        if (null != owner_Configurationtree_Control)
                        {
                            bool bHit = owner_Configurationtree_Control.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Control, false, log_Reports);

                            if (bHit)
                            {
                                ec_Name_Control = new Expression_Node_StringImpl(this, this.Cur_Configurationtree);
                                ec_Name_Control.AppendTextNode(
                                    sName_Control,
                                    this.Cur_Configurationtree,
                                    log_Reports
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
                    log_Reports
                    );
            }
            else
            {
                list_Usercontrol = new List<Usercontrol>();
            }



            //
            // 妥当性判定を行います。
            //
            if (log_Reports.Successful)
            {
                if (0 < list_Usercontrol.Count)
                {
                    Usercontrol uct = list_Usercontrol[0];
                    uct.JudgeValidity(log_Reports);
                }

                //.WriteLine(this.GetType().Name + "#: ◆　妥当性判定を行った。");
            }




            if (log_Reports.Successful)
            {
                //
                // 指定のコントロールの内容を、データ・ソースから読取り直して最新表示します。
                //

                if (0 < list_Usercontrol.Count)
                {
                    Usercontrol uct = list_Usercontrol[0];

                    //.WriteLine(this.GetType().Name + "#: ◆　指定のコントロールに、データのアップデートを指示。");

                    if (uct.ControlCommon.BAutomaticinputting)
                    {
                        // コンピューターにより自動入力されたとき。
                        //essageBox.Show("コンピュータによって自動入力されました。 コントロールID=[" + this.FormObjectId + "]", "デバッグ");
                    }
                    else
                    {
                        // 手入力による更新。

                        uct.UsercontrolToMemory(log_Reports);
                    }
                }


                //.WriteLine(this.GetType().Name + "#: ◆　指示終了。");

            }


            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
