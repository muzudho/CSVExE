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
        public static readonly string NAME_FUNCTION = "Sf:CSV保存;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// テーブル名。カンマ区切りで複数指定できる。
        /// </summary>
        public static readonly string PM_NAME_TABLE = PmNames.S_NAME_TABLE.Name_Pm;

        /// <summary>
        /// 保存を行ったという警告ダイアログを出さない場合は「block」と指定。無指定では出る。
        /// </summary>
        public static readonly string PM_POPUP = PmNames.S_POPUP.Name_Pm;

        /// <summary>
        /// 処理スキップ。何か文字が指定されている（空文字列でない）と、この処理は行われない。
        /// </summary>
        public static readonly string PM_FLOWSKIP = PmNames.S_FLOWSKIP.Name_Pm;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function04Impl(
            EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem
            )
            : base(enumEventhandler, listS_ArgName,functiontranslatoritem)
        {

        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function04Impl(this.EnumEventhandler, this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Gcav), log_Reports);

            f0.SetAttribute(Expression_Node_Function04Impl.PM_NAME_TABLE, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.SetAttribute(Expression_Node_Function04Impl.PM_POPUP, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.SetAttribute(Expression_Node_Function04Impl.PM_FLOWSKIP, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

            //
            log_Method.EndMethod(log_Reports);
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
        /// <param name="log_Reports"></param>
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain", log_Reports);

            string sFncName0;
            this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

            if (log_Reports.CanStopwatch)
            {
                log_Method.Log_Stopwatch.Message = "「E■[" + sFncName0 + "]アクション」実行(A)";
                log_Method.Log_Stopwatch.Begin();
            }


            if (this.Functionparameterset.Sender is Customcontrol)
            {
                Customcontrol ccFc = (Customcontrol)this.Functionparameterset.Sender;

                string sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                log_Reports.Comment_EventCreationMe = "／追記：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
            }
            else
            {
                log_Reports.Comment_EventCreationMe = "／追記：[" + sFncName0 + "]アクションを実行。";
            }

            //
            //
            //
            //

            if (this.EnumEventhandler == EnumEventhandler.O_Wr)
            {
                this.Functionparameterset.Node_EventOrigin += "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_WrRhn:＞";

                this.Perform2(log_Reports);

                ((EventMonitor)this.Functionparameterset.EventMonitor).BNowactionworking = false;
            }
            else if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                this.Perform2(log_Reports);
            }
            else
            {
            }

            //
            // デバッグ
            //

            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────

        private void Perform2(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Perform2",log_Reports);


            string sFlowSkip;
            this.TrySelectAttribute(out sFlowSkip, Expression_Node_Function04Impl.PM_FLOWSKIP, EnumHitcount.One_Or_Zero, log_Reports);
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
                this.TrySelectAttribute(out sTableNames, Expression_Node_Function04Impl.PM_NAME_TABLE, EnumHitcount.One_Or_Zero, log_Reports);

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
                if (log_Reports.Successful)
                {
                    Expression_Node_String ec_ArgTableName;
                    this.TrySelectAttribute(out ec_ArgTableName, Expression_Node_Function04Impl.PM_NAME_TABLE, EnumHitcount.One_Or_Zero, log_Reports);

                    Expression_Node_StringImpl ec_TableName = new Expression_Node_StringImpl(this, ec_ArgTableName.Cur_Configurationtree);
                    ec_TableName.AppendTextNode(
                        sTableName,
                        this.Cur_Configurationtree,
                        log_Reports
                        );

                    // テーブル
                    o_Table = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_TableName,
                        true,
                        log_Reports
                        );
                }
                else
                {
                    o_Table = null;
                }

                string sCsvText;
                if (log_Reports.Successful)
                {
                    ToCsv_TableCsvImpl textizer = new ToCsv_TableCsvImpl();
                    sCsvText = textizer.ToCsvText(o_Table, log_Reports);
                    if (!log_Reports.Successful)
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
                if (log_Reports.Successful)
                {
                    // 正常時

                    //essageBox.Show("テーブルのtext=[" + csvText + "]", "デバッグ");

                    // TODO ファイルパスの妥当性判定も欲しい
                    sFpatha = o_Table.Expression_Filepath_ConfigStack.Execute_OnExpressionString(
                        EnumHitcount.Unconstraint, log_Reports);
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sFpatha = "";
                }

                if (log_Reports.Successful)
                {
                    bool bPopup;
                    string sPopup;
                    this.TrySelectAttribute(out sPopup, Expression_Node_Function04Impl.PM_POPUP, EnumHitcount.One_Or_Zero, log_Reports);

                    if ("block" == sPopup.Trim())
                    {
                        log_Method.WriteInfo_ToConsole("sPopup=[" + sPopup + "] ポップアップしません。");
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
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
