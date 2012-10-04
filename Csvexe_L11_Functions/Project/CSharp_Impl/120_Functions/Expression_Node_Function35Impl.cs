using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;//Application,Form
using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//Usercontrol
using Xenon.MiddleImpl;

namespace Xenon.Functions
{
    public class Expression_Node_Function35Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:ビュー関連付け;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        // なし

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function35Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Expression_Node_Function f0 = new Expression_Node_Function35Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Gcav), log_Reports);

            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain",log_Reports);

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName0 + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }

            //
            //

            Expression_Node_String err_Ec_FcName1;
            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {

                if (this.Functionparameterset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.Functionparameterset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                        EnumHitcount.Unconstraint,
                        log_Reports
                        );

                    log_Reports.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe = "[" + sFncName0 + "]アクションを実行。";
                }

                //
                //
                //
                //
                this.Functionparameterset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";


                //
                // このNAction29を含んでいるｃｏｎｔｒｏｌ要素から
                // コントロールの名前を取得。
                Expression_Node_String ec_FcName1;

                //
                // このNAction29要素を含んでいる ｃｏｎｔｒｏｌ要素から、コントロールの名前を取得。
                List<Usercontrol> list_FcUc;
                if (log_Reports.Successful)
                {
                    // 正常時

                    Configurationtree_Node cf_Event = this.Cur_Configurationtree.GetParentByNodename(NamesNode.S_EVENT, false, log_Reports);

                    if (null != cf_Event)
                    {
                        Configurationtree_Node owner_Configurationtree_Control = cf_Event.GetParentByNodename(NamesNode.S_CONTROL1, true, log_Reports);

                        if (null != owner_Configurationtree_Control)
                        {
                            string sName_Usercontrol;
                            owner_Configurationtree_Control.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Usercontrol, true, log_Reports);


                            Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(this, this.Cur_Configurationtree);
                            ec_Str.AppendTextNode(
                                sName_Usercontrol,
                                this.Cur_Configurationtree,
                                log_Reports
                                );

                            ec_FcName1 = ec_Str;
                        }
                        else
                        {
                            ec_FcName1 = null;
                        }

                    }
                    else
                    {
                        ec_FcName1 = null;
                    }

                    //
                    // 指定のコントロール
                    //
                    list_FcUc = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                        ec_FcName1,
                        true,
                        log_Reports
                        );
                }
                else
                {
                    //
                    // エラー。
                    ec_FcName1 = null;
                    list_FcUc = null;
                    err_Ec_FcName1 = ec_FcName1;
                    goto gt_Error_NullFcUc;
                }
                // ここで、fcUc は必ずある。
                Usercontrol fct = list_FcUc[0];

                //
                //
                //
                // View
                //
                //
                //

                // 最初の１個のみ有効。必ずあるとする。
                List<Expression_Node_String> ecList_View = fct.ControlCommon.Expression_Control.SelectDirectchildByNodename(NamesNode.S_VIEW, false, EnumHitcount.One, log_Reports);
                if (!log_Reports.Successful)
                {
                    goto gt_EndMethod;
                }
                Expression_Node_StringImpl ec_View = (Expression_Node_StringImpl)ecList_View[0];

                //
                // O → N は、Fcnfをロードした時点で実行済み。
                if (ec_View.List_Expression_Child.Count < 1)
                {
                    //
                    // エラー。
                    //
                    // このアクションを使うからには、
                    // 必ず＜ｖｉｅｗ＞の中に子要素がないといけない。
                    err_Ec_FcName1 = ec_FcName1;
                    goto gt_Error_EmptyView;
                }


                object errorRule = null;
                Expression_Node_String err_Ec_DataTarget = null;
                if (log_Reports.Successful)
                {
                    // 正常時

                    ec_View.List_Expression_Child.ForEach(delegate(Expression_Node_String ec_Child, ref bool bRemove, ref bool bBreak)
                    {
                        string sFncName;
                        ec_Child.TrySelectAttribute(out sFncName, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

                        if (
                            NamesNode.S_FNC == ec_Child.Cur_Configurationtree.Name &&
                            NamesFnc.S_LISTBOX_LABELS == sFncName
                            )
                        {
                            // ＜ｆ－ｌｉｓｔ－ｂｏｘ－ｌａｂｅｌｓ＞


                            //
                            // fcUc は、必ずリストボックス。
                            if (!(fct is UsercontrolListbox))
                            {
                                //
                                // エラー。
                                goto gt_Error_NotListbox;
                            }

                            UsercontrolListbox uctLst = (UsercontrolListbox)fct;

                            //
                            // リストボックスの表示を自作します。項目の高さが固定の場合。
                            uctLst.DrawMode = DrawMode.OwnerDrawFixed;



                            //
                            // N → Uc

                            //
                            // 描画プログラムの作成。
                            ListboxItemDrawer_02Impl drawer = new ListboxItemDrawer_02Impl(
                                this.Owner_MemoryApplication);

                            //
                            // ｉｔｅｍ－ｖａｌｕｒ－ｔｏ－ｖａｒｉａｂｌｅ="" 属性
                            //
                            //if (null == nF11.E_ItemValueToVariable)
                            {
                                // ＜データ ａｃｃｅｓｓ="ｔｏ"＞から取りたい。
                                Expression_Node_String ec_ItemValueToVariable = null;//ソース情報利用


                                List<Expression_Node_String> ecList_DataTarget;
                                {
                                    List<Expression_Node_String> ecList_Data = uctLst.ControlCommon.Expression_Control.SelectDirectchildByNodename( NamesNode.S_DATA, false, EnumHitcount.Unconstraint, log_Reports);
                                    ecList_DataTarget = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Data, PmNames.S_ACCESS.Name_Pm, ValuesAttr.S_TO, false, EnumHitcount.First_Exist, log_Reports);
                                }

                                if (!log_Reports.Successful)
                                {
                                    goto gt_EndMethod2;
                                }
                                Expression_Node_String ec_DataTarget = ecList_DataTarget[0];
                                err_Ec_DataTarget = ec_DataTarget;


                                if (null != ec_DataTarget)
                                {
                                    bool bHit = ec_DataTarget.TrySelectAttribute(
                                        out ec_ItemValueToVariable, PmNames.S_NAME_VAR.Name_Pm, EnumHitcount.One, log_Reports);
                                    if (bHit)
                                    {
                                        drawer.Expression_ValueVariableName = ec_ItemValueToVariable;
                                    }
                                    else
                                    {
                                        // エラー。
                                        goto gt_Error_NullItemValueToVariable;
                                    }
                                }
                                else
                                {
                                    // エラー。
                                    goto gt_Error_NotFoundDataTarget;
                                }
                            }
                            //else
                            //{
                            //    //
                            //    // 変数名設定。
                            //    drawer.Ec_ValueVariableName = nF11.E_ItemValueToVariable;
                            //}

                            //
                            // ＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｉｔｅｍ－ｌａｂｅｌ；”＞
                            List<Expression_Node_String> ecList_Fnc = ec_Child.SelectDirectchildByNodename(NamesNode.S_FNC, false, EnumHitcount.Unconstraint, log_Reports);
                            ecList_Fnc = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(ecList_Fnc, PmNames.S_NAME.Name_Pm, NamesFnc.S_ITEM_LABEL2, false, EnumHitcount.First_Exist, log_Reports);
                            if (!log_Reports.Successful)
                            {
                                // エラー。
                                goto gt_EndMethod2;
                            }

                            drawer.Expression_ItemLabel = ecList_Fnc[0];

                            if (log_Reports.Successful)
                            {
                                //
                                // 描画プログラムの変更。
                                uctLst.ListboxItemDrawer = drawer;
                            }

                        }
                        else
                        {
                            errorRule = ec_Child;

                            //
                            // エラー。未定義の＜view＞。
                            goto gt_Error_UndefinedView;
                        }

                        goto gt_EndMethod2;

                        //
                        //
                        //
                        //

            //
                    // エラー。
                    gt_Error_NotListbox:
                        {
                            Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                            tmpl.SetParameter(1, ec_FcName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//コントロール名
                            tmpl.SetParameter(2, fct.GetType().Name, log_Reports);//コントロールのクラス名

                            this.Owner_MemoryApplication.CreateErrorReport("Er:110019;", tmpl, log_Reports);
                        }
                        goto gt_EndMethod2;

                    //
                    // エラー。
                    gt_Error_NotFoundDataTarget:
                        {
                            Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                            tmpl.SetParameter(1, ec_FcName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//コントロール名

                            this.Owner_MemoryApplication.CreateErrorReport("Er:110020;", tmpl, log_Reports);
                        }
                        goto gt_EndMethod2;

                    //
                    // エラー。
                    gt_Error_NullItemValueToVariable:
                        {
                            Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                            tmpl.SetParameter(1, PmNames.S_NAME_VAR.Name_Pm, log_Reports);//引数名NameVar
                            tmpl.SetParameter(2, ec_FcName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//コントロール名

                            //
                            //　「ａｃｃｅｓｓ="ｔｏ"」要素を取得しているような。
                            //
                            Log_TextIndented s1 = new Log_TextIndentedImpl();
                            err_Ec_DataTarget.ToText_Snapshot(s1);
                            tmpl.SetParameter(3, s1.ToString(), log_Reports);//データターゲットの変数の中身

                            Log_TextIndented s2 = new Log_TextIndentedImpl();
                            err_Ec_DataTarget.Cur_Configurationtree.ToText_Content(s2);
                            tmpl.SetParameter(4, s2.ToString(), log_Reports);//データターゲットの設定の中身

                            this.Owner_MemoryApplication.CreateErrorReport("Er:110021;", tmpl, log_Reports);
                        }
                        goto gt_EndMethod2;

            //
                    // エラー。
                    gt_Error_UndefinedView:
                        {
                            Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                            tmpl.SetParameter(1, errorRule.GetType().Name, log_Reports);//要素のクラス名
                            tmpl.SetParameter(2, ec_Child.Cur_Configurationtree.Name, log_Reports);//設定の子要素のノード名
                            tmpl.SetParameter(3, sFncName, log_Reports);//設定の子要素の関数名

                            this.Owner_MemoryApplication.CreateErrorReport("Er:110022;", tmpl, log_Reports);
                        }
                        goto gt_EndMethod2;

                    gt_EndMethod2:
                        ;
                    });




                    //
                    // 「表示プログラム」を作成、
                    // リストボックスにその「リスト作成プログラム」を渡す。
                    // リストボックスは再表示されるたびに、
                    // その「リスト作成プログラム」を実行。

                    // 以下、その「表示プログラム」の内容。

                    //
                    // ループカウンタの回数だけ、リストに項目を追加。

                    //
                    // その内容は、値が＜ａ－ｉｔｅｍ－ｖａｌｕｅ＞から取得。

                    //
                    // その内容は、表示ラベルが＜ａ－ｉｔｅｍ－ｌａｂｅｌ＞から取得。

                    //
                    // その表示ラベルは、次の条件に一致した時、グレー色にする。
                    //
                    // ＜ａ－ｉｔｅｍ－ｇｒａｙ－ｏｕｔ＞
                    // ＜ｆ－ａｌｌ－ｔｒｕｅ＞
                    // ＜ａ－ｅｍｐｔｙ－ｆｉｅｌｄ＞
                }
                goto gt_EndMethod;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullFcUc:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_Ec_FcName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//コントロール名

                this.Owner_MemoryApplication.CreateErrorReport("Er:110023;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_EmptyView:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_Ec_FcName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//検索ヒット数

                this.Owner_MemoryApplication.CreateErrorReport("Er:110024;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            // 必ずフラグをオフにします。
            ((EventMonitor)this.Functionparameterset.EventMonitor).BNowactionworking = false;
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
