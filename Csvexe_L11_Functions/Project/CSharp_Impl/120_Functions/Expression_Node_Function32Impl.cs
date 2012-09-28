﻿using System;
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

        public static readonly string S_ACTION_NAME = "Sf:コントロール値設定_選択行の列指定;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// テーブル名。
        /// </summary>
        public static readonly string S_PM_NAME_TABLE = PmNames.S_NAME_TABLE.SName_Pm;

        /// <summary>
        /// フィールド名。
        /// 
        /// 元は名無し。
        /// </summary>
        public static string S_PM_NAME_FIELD = PmNames.S_NAME_FIELD.SName_Pm;

        /// <summary>
        /// 値格納先コントロール名。
        /// </summary>
        public static readonly string S_PM_NAME_FC_DESTINATION = PmNames.S_NAME_CONTROL_DESTINATION.SName_Pm;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function32Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler,listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function32Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);

            f0.DicExpression_Attr.Set(Expression_Node_Function32Impl.S_PM_NAME_TABLE, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.DicExpression_Attr.Set(Expression_Node_Function32Impl.S_PM_NAME_FIELD, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.DicExpression_Attr.Set(Expression_Node_Function32Impl.S_PM_NAME_FC_DESTINATION, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

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
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",log_Reports);

            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol ccFc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                    log_Reports.SComment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    log_Reports.SComment_EventCreationMe = "[" + sFncName0 + "]アクションを実行。";
                }


                ListBox pcLst = (ListBox)this.ExpressionfncPrmset.Sender;



                this.Perform2(pcLst, log_Reports);
            }

            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        protected void Perform2(
            ListBox pcLst,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform2",log_Reports);

            if (log_Reports.CanStopwatch)
            {
                string sFncName0;
                this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);
                log_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName0 + "]実行";

                log_Method.Log_Stopwatch.Begin();
            }


            DataRowView selectedDataRow = (DataRowView)pcLst.SelectedItem;

            if (null == selectedDataRow)
            {
                // 選択している行がなければ。
                goto gt_Error_NotFoundSelectedRow;
            }

            //.WriteLine(this.GetType().Name + "#Perform_OEa: ◆　選択している行はあった。");


            Expression_Node_String ec_ArgTableName;
            this.TrySelectAttr(out ec_ArgTableName, Expression_Node_Function32Impl.S_PM_NAME_TABLE, false, Request_SelectingImpl.Unconstraint, log_Reports);

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

            //.WriteLine(this.GetType().Name + "#Perform_OEa: ◆　テーブルはあった。");


            // 現在選択しているレコードの NOフィールドの値を取得します。
            {
                string sArgFieldName;
                this.TrySelectAttr(out sArgFieldName, Expression_Node_Function32Impl.S_PM_NAME_FIELD, false, Request_SelectingImpl.Unconstraint, log_Reports);

                XenonValue_IntImpl cellData = (XenonValue_IntImpl)selectedDataRow[sArgFieldName];

                string sFieldValue = cellData.SHumaninput.Trim();
                //.WriteLine(this.GetType().Name + "#Perform_OEa: ◆　fieldValue=[" + fieldValue + "]");


                Expression_Node_String ec_ArgDestinationFcName;
                this.TrySelectAttr(out ec_ArgDestinationFcName, Expression_Node_Function32Impl.S_PM_NAME_FC_DESTINATION, false, Request_SelectingImpl.Unconstraint, log_Reports);

                // コントロールに格納します。
                List<Usercontrol> list_FcUc;
                {
                    list_FcUc = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                        ec_ArgDestinationFcName,
                        true,
                        log_Reports
                        );
                }

                if (log_Reports.BSuccessful)
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
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー198！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("未実装、リストボックスで選択している行がなかった。");
                s.Append(Environment.NewLine);
                s.Append("選択している項目インデックス番号は、[");
                s.Append(pcLst.SelectedIndex);
                s.Append("]です。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
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