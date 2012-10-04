using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;//Application,Control
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol

namespace Xenon.Functions
{
    public class Expression_Node_Function11Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:Action11;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        // なし

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function11Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Expression_Node_Function f0 = new Expression_Node_Function11Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Gcav), log_Reports);

            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 「ツール設定ウィンドウ」を開きます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor"></param>
        /// <param name="log_Reports"></param>
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);

            if (this.EnumEventhandler == EnumEventhandler.O_Lr)
            {
                if (log_Reports.CanStopwatch)
                {
                    string sFncName;
                    this.TrySelectAttribute(out sFncName, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                    log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName + "]実行";
                    log_Method.Log_Stopwatch.Begin();
                }

                //
                //
                //
                //
                this.Functionparameterset.Node_EventOrigin += "＜" + log_Method.Fullname + ":＞";


                // ツール設定モデルを共有します。
                this.Owner_MemoryApplication.MemoryForms.MemoryAatoolxmlDialog.MemoryAatoolxml = this.Owner_MemoryApplication.MemoryAatoolxml;

                // 「SelectedIndexイベント」を必ず動かすために、リストボックスを空にします。
                this.Owner_MemoryApplication.MemoryForms.Form_Toolwindow.Clear();

                // ダイアログボックスを出します。
                ((Form)this.Owner_MemoryApplication.MemoryForms.Form_Toolwindow).ShowDialog(this.Owner_MemoryApplication.MemoryForms.Mainwnd_FormWrapping.Form);


                //
                //
                //
                // 必ずフラグをオフにします。
                //
                //
                //
                ((EventMonitor)this.Functionparameterset.EventMonitor).BNowactionworking = false;
            }

            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
