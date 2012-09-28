using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data;
using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Table;

namespace Xenon.Functions
{
    public class Expression_Node_Function04Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        /// <summary>
        /// 関数名。
        /// </summary>
        public static readonly string S_ACTION_NAME = "Sf:CSV保存;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// テーブル名。カンマ区切りで複数指定できる。
        /// </summary>
        public static readonly string S_PM_NAME_TABLE = PmNames.S_NAME_TABLE.SName_Pm;

        /// <summary>
        /// 保存を行ったという警告ダイアログを出さない場合は「block」と指定。無指定では出る。
        /// </summary>
        public static readonly string S_PM2_POPUP = PmNames.S_POPUP.SName_Pm;

        /// <summary>
        /// 処理スキップ。何か文字が指定されている（空文字列でない）と、この処理は行われない。
        /// </summary>
        public static readonly string S_PM2_FLOW_SKIP = PmNames.S_FLOWSKIP.SName_Pm;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function04Impl(
            EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem
            )
            : base(enumEventhandler, listS_ArgName,functiontranslatoritem)
        {

        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function04Impl(this.EnumEventhandler, this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function04Impl.S_PM_NAME_TABLE, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function04Impl.S_PM2_POPUP, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function04Impl.S_PM2_FLOW_SKIP, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

            //
            pg_Method.EndMethod(pg_Logging);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor"></param>
        /// <param name="pg_Logging"></param>
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain", pg_Logging);

            string sFncName0;
            this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

            if (pg_Logging.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.SMessage = "「E■[" + sFncName0 + "]アクション」実行(A)";
                pg_Method.Log_Stopwatch.Begin();
            }


            if (this.ExpressionfncPrmset.Sender is Customcontrol)
            {
                Customcontrol ccFc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                string sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                pg_Logging.SComment_EventCreationMe = "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
            }
            else
            {
                pg_Logging.SComment_EventCreationMe = "／追記：[" + sFncName0 + "]アクションを実行。";
            }

            //
            //
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.ExpressionfncPrmset.SNode_EventOrigin += "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";

                this.Perform2(pg_Logging);

                ((EventMonitor)this.ExpressionfncPrmset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(pg_Logging);
            }
            else
            {
            }

            //
            // デバッグ
            //

            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────

        private void Perform2(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Perform2",pg_Logging);


            string sFlowSkip;
            this.TrySelectAttr(out sFlowSkip, Expression_Node_Function04Impl.S_PM2_FLOW_SKIP, false, Request_SelectingImpl.Unconstraint, pg_Logging);
            if ("" != sFlowSkip.Trim())
            {
                // 処理をスキップします。
                goto gt_EndMethod;
            }


            //
            //
            //
            // テーブル名
            //
            //
            //
            List<string> sList_TableName = new List<string>();
            {
                string sTableNames;
                this.TrySelectAttr(out sTableNames, Expression_Node_Function04Impl.S_PM_NAME_TABLE, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                CsvTo_DataTableImpl reader = new CsvTo_DataTableImpl();
                DataTable tblNamesTable = reader.Read(
                    sTableNames
                    );

                foreach (DataRow row in tblNamesTable.Rows)
                {
                    foreach (string column in row.ItemArray)
                    {
                        sList_TableName.Add(column);
                    }
                }
            }

            foreach (string sTableName in sList_TableName)
            {
                XenonTable o_Table;
                if (pg_Logging.BSuccessful)
                {
                    Expression_Node_String ec_ArgTableName;
                    this.TrySelectAttr(out ec_ArgTableName, Expression_Node_Function04Impl.S_PM_NAME_TABLE, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                    Expression_Node_StringImpl ec_TableName = new Expression_Node_StringImpl(this, ec_ArgTableName.Cur_Givechapterandverse);
                    ec_TableName.AppendTextNode(
                        sTableName,
                        this.Cur_Givechapterandverse,
                        pg_Logging
                        );

                    // テーブル
                    o_Table = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_TableName,
                        true,
                        pg_Logging
                        );
                }
                else
                {
                    o_Table = null;
                }

                string sCsvText;
                if (pg_Logging.BSuccessful)
                {
                    ToCsv_TableCsvImpl textizer = new ToCsv_TableCsvImpl();
                    sCsvText = textizer.ToCsvText(o_Table, pg_Logging);
                    if (!pg_Logging.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sCsvText = null;
                }

                string sFpatha;//絶対ファイルパス
                if (pg_Logging.BSuccessful)
                {
                    // 正常時

                    //essageBox.Show("テーブルのtext=[" + csvText + "]", "デバッグ");

                    // TODO ファイルパスの妥当性判定も欲しい
                    sFpatha = o_Table.Expression_Filepath_ConfigStack.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint, pg_Logging);
                    if (!pg_Logging.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sFpatha = "";
                }

                if (pg_Logging.BSuccessful)
                {
                    bool bPopup;
                    string sPopup;
                    this.TrySelectAttr(out sPopup, Expression_Node_Function04Impl.S_PM2_POPUP, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                    if ("block" == sPopup.Trim())
                    {
                        pg_Method.WriteInfo_ToConsole("sPopup=[" + sPopup + "] ポップアップしません。");
                        bPopup = false;
                    }
                    else
                    {
                        bPopup = true;
                    }

                    CsvWriterImpl writer = new CsvWriterImpl();
                    writer.Write(
                        sCsvText, sFpatha, bPopup);
                }
            }

        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion



    }
}
