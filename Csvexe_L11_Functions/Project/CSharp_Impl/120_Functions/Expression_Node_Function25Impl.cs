using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;//DataRowView
using System.Windows.Forms;//Application
using Xenon.Controls;
using Xenon.Syntax;
using Xenon.Middle;//MoOpyopyo,FormObjectProperties,Usercontrol
using Xenon.Table;//DefaultTable
using Xenon.Expr;

namespace Xenon.Functions
{



    /// <summary>
    /// 指定した変数に、フィールド値を格納します。
    /// </summary>
    public class Expression_Node_Function25Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string S_ACTION_NAME = "Sf:変数設定_選択行の列指定;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// フィールド名。
        /// 
        /// 元は名無し。
        /// </summary>
        public static readonly string S_PM_NAME_FIELD = PmNames.S_NAME_FIELD.SName_Pm;

        /// <summary>
        /// 値格納先変数名。
        /// </summary>
        public static readonly string S_PM_NAME_VAR_DESTINATION = PmNames.S_NAME_VAR_DESTINATION.SName_Pm;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function25Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
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

            Expression_Node_Function f0 = new Expression_Node_Function25Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期化
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function25Impl.S_PM_NAME_FIELD, new Expression_Leaf_StringImpl("", null, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function25Impl.S_PM_NAME_VAR_DESTINATION, new Expression_Leaf_StringImpl("", null, cur_Gcav), pg_Logging);

            //
            pg_Method.EndMethod(pg_Logging);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)// EventArgs e
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);

            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName0 + "]実行";
                pg_Method.Log_Stopwatch.Begin();
            }

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string sName_Usercontrol = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint,
                        pg_Logging
                        );

                    pg_Logging.SComment_EventCreationMe = "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe = "／追記：[" + sFncName0 + "]アクションを実行。";
                }


                ListBox pcLst = (ListBox)this.ExpressionfncPrmset.Sender;
                this.Perform2(
                    pcLst,
                    pg_Logging
                    );
            }

            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcLst"></param>
        /// <param name="pg_Logging"></param>
        protected void Perform2(
            ListBox pcLst,
            Log_Reports pg_Logging
            )
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform2",pg_Logging);


            //
            //このイベントが起こったリストボックスの名前。
            //
            string sName_Control;
            if (pcLst is CustomcontrolListbox)
            {
                CustomcontrolListbox cclst = (CustomcontrolListbox)pcLst;
                sName_Control = cclst.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);
                pg_Method.WriteDebug_ToConsole(sName_Control);
            }
            else
            {
                sName_Control = "";
            }


            //
            //
            //
            //現在、選択している項目。
            //
            //
            //
            DataRowView selectedDataRow = (DataRowView)pcLst.SelectedItem;
            if (null == selectedDataRow)
            {
                // 選択している行がなければ。

                // エラー。
                goto gt_Error_NoSelectedField;
            }


            //
            //
            //
            // 現在選択しているレコードの 指定フィールドの値を取得します。
            //
            //
            //
            {
                //指定されているフィールド名。
                string sName_Field;
                this.TrySelectAttr(out sName_Field, Expression_Node_Function25Impl.S_PM_NAME_FIELD, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                //そのフィールドの値。
                XenonValue_IntImpl cellData = (XenonValue_IntImpl)selectedDataRow[sName_Field];
                string sValue_Field = cellData.SHumaninput.Trim();
                //.WriteLine(this.GetType().Name + "#Perform_OEa: ◆　fieldValue=[" + fieldValue + "]");

                //変数名。
                Expression_Node_String ec_Name_ArgDestinationVariable;
                this.TrySelectAttr(out ec_Name_ArgDestinationVariable, Expression_Node_Function25Impl.S_PM_NAME_VAR_DESTINATION, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                //指定した変数に、フィールド値を格納します。
                this.Owner_MemoryApplication.MemoryVariables.SetStringValue(
                    new XenonNameImpl(
                        ec_Name_ArgDestinationVariable.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging),
                        ec_Name_ArgDestinationVariable.Cur_Givechapterandverse
                        ),
                    sValue_Field,
                    true,
                    pg_Logging
                    );
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NoSelectedField:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー198！", pg_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("未実装、リストボックス[" );
                sb.Append(sName_Control);
                sb.Append("]で選択している行がなかった。");


                sb.Append(Environment.NewLine);
                sb.Append("リストボックスの、選択している項目インデックス番号は、[");
                sb.Append(pcLst.SelectedIndex);
                sb.Append("]です。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                r.SMessage = sb.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion



    }
}
