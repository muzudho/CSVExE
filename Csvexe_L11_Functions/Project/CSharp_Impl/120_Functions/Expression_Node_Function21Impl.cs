using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//Keys,Application

using Xenon.Syntax;
using Xenon.Middle;//FormObjectProperties,Usercontrol


namespace Xenon.Functions
{
    public class Expression_Node_Function21Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        /// <summary>
        /// 関数名。
        /// </summary>
        public static readonly string NAME_FUNCTION = "Sf:Action21;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        // なし

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function21Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Expression_Node_Function f0 = new Expression_Node_Function21Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
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

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);

            if (log_Reports.CanStopwatch)
            {
                string sFncName0;
                this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName0 + "]実行";
                log_Method.Log_Stopwatch.Begin();
            }
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Kea)
            {
                string sConfigStack_EventOrigin = "＜" + log_Method.Fullname + ":＞";
                Configurationtree_Node cf_WrittenPlace_ThisMethod = new Configurationtree_NodeImpl(sConfigStack_EventOrigin, null);

                Keys keys = this.Functionparameterset.KeyEventArgs.KeyCode;

                //
                // Form1のKeyPreview属性を true にしておく必要があります。
                //

                switch (keys)
                {
                    case Keys.F8:

                        //
                        // 「ツール設定ウィンドウ」を開きます。
                        //
                        //OWrittenPlace oWrittenPlace = new OWrittenPlaceImpl(this.OWrittenPlace.WrittenPlace + "!ハードコーディング_NAction21#(10)");

                        Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                                Expression_Node_Function11Impl.NAME_FUNCTION, this, this.Cur_Configurationtree,
                                this.Owner_MemoryApplication, log_Reports);

                        Configurationtree_Node cf_Event;
                        {
                            cf_Event = this.Cur_Configurationtree.GetParentByNodename(NamesNode.S_EVENT, false, log_Reports);
                        }


                        expr_Func.Execute4_OnLr(
                            this.Functionparameterset.Sender,
                            new EventMonitorImpl(cf_Event, cf_WrittenPlace_ThisMethod),//ダミー
                            sConfigStack_EventOrigin,
                            log_Reports
                            );

                        //essageBox.Show("[F8]キーを押しました。", "△情報103！");
                        break;
                }
            }


            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
