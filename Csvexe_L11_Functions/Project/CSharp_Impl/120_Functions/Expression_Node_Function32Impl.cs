using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;//DataRowView
using System.Windows.Forms;//Application
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol
using Xenon.Table;//DefaultTable


namespace Xenon.Functions
{
    public class Expression_Node_Function32Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:コントロール値設定_選択行の列指定;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// テーブル名。
        /// </summary>
        public static readonly string PM_NAME_TABLE = PmNames.S_NAME_TABLE.Name_Pm;

        /// <summary>
        /// フィールド名。
        /// 
        /// 元は名無し。
        /// </summary>
        public static string PM_NAME_FIELD = PmNames.S_NAME_FIELD.Name_Pm;

        /// <summary>
        /// 値格納先コントロール名。
        /// </summary>
        public static readonly string PM_NAME_CONTROL_DESTINATION = PmNames.S_NAME_CONTROL_DESTINATION.Name_Pm;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function32Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
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

            Expression_Node_Function f0 = new Expression_Node_Function32Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);

            f0.SetAttribute(Expression_Node_Function32Impl.PM_NAME_TABLE, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function32Impl.PM_NAME_FIELD, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);
            f0.SetAttribute(Expression_Node_Function32Impl.PM_NAME_CONTROL_DESTINATION, new Expression_Node_StringImpl(this, cur_Conf), log_Reports);

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
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                if (this.Functionparameterset.Sender is Customcontrol)
                {
                    Customcontrol ccFc = (Customcontrol)this.Functionparameterset.Sender;

                    string sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                    log_Reports.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe = "[" + sFncName0 + "]アクションを実行。";
                }


                ListBox pcLst = (ListBox)this.Functionparameterset.Sender;



                this.Execute6_Sub(pcLst, log_Reports);
            }

            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Execute6_Sub(
            ListBox pcLst,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute6_Sub", log_Reports);

            if (log_Reports.CanStopwatch)
            {
                string sFncName0;
                this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName0 + "]実行";

                log_Method.Log_Stopwatch.Begin();
            }


            DataRowView selectedDataRow = (DataRowView)pcLst.SelectedItem;

            if (null == selectedDataRow)
            {
                // 選択している行がなければ。
                goto gt_Error_NotFoundSelectedRow;
            }


            Expression_Node_String ec_ArgTableName;
            this.TrySelectAttribute(out ec_ArgTableName, Expression_Node_Function32Impl.PM_NAME_TABLE, EnumHitcount.One_Or_Zero, log_Reports);

            XenonTable o_Table = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                ec_ArgTableName,
                true,
                log_Reports
                );

            if (null == o_Table)
            {
                // エラー中断。
                goto gt_EndMethod;
            }
            DataTable dataTable = o_Table.DataTable;

            //.WriteLine(this.GetType().Name + "#: ◆　テーブルはあった。");


            // 現在選択しているレコードの NOフィールドの値を取得します。
            {
                string sArgFieldName;
                this.TrySelectAttribute(out sArgFieldName, Expression_Node_Function32Impl.PM_NAME_FIELD, EnumHitcount.One_Or_Zero, log_Reports);

                XenonValue_IntImpl cellData = (XenonValue_IntImpl)selectedDataRow[sArgFieldName];

                string sFieldValue = cellData.Humaninput.Trim();
                //.WriteLine(this.GetType().Name + "#: ◆　fieldValue=[" + fieldValue + "]");


                Expression_Node_String ec_ArgDestinationFcName;
                this.TrySelectAttribute(out ec_ArgDestinationFcName, Expression_Node_Function32Impl.PM_NAME_CONTROL_DESTINATION, EnumHitcount.One_Or_Zero, log_Reports);

                // コントロールに格納します。
                List<Usercontrol> list_FcUc;
                {
                    list_FcUc = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                        ec_ArgDestinationFcName,
                        true,
                        log_Reports
                        );
                }

                if (log_Reports.Successful)
                {
                    Usercontrol fcUc = list_FcUc[0];

                    fcUc.UsercontrolText = sFieldValue;
                }

            }


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundSelectedRow:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, pcLst.SelectedIndex.ToString(), log_Reports);//リストボックスで選択している項目のindex

                this.Owner_MemoryApplication.CreateErrorReport("Er:110016;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
