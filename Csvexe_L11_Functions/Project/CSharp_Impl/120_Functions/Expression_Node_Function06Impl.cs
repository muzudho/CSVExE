using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Diagnostics;//外部プログラムの起動,Process
using Xenon.Syntax;
using Xenon.Table;
using Xenon.Middle;

namespace Xenon.Functions
{
    public class Expression_Node_Function06Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        public static readonly string NAME_FUNCTION = "Sf:外部アプリケーション起動_CSV渡す;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 元となるテーブル名。//カンマ区切りで複数指定できる。
        /// </summary>
        public static readonly string PM_NAME_TABLE_SOURCE = PmNames.S_NAME_TABLE_SRC.Name_Pm;

        /// <summary>
        /// 外部アプリケーションを実行するなら、そのファイルパス。なければ空文字列。
        /// </summary>
        public static string PM_FILEPATH_EXTERNALAPPLICATION = PmNames.S_FILEPATH_EXTERNALAPPLICATION.Name_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function06Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            :base(enumEventhandler, listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "E_Sa06Impl",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function06Impl(this.EnumEventhandler,this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Gcav), log_Reports);

            f0.SetAttribute(Expression_Node_Function06Impl.PM_NAME_TABLE_SOURCE, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);
            f0.SetAttribute(Expression_Node_Function06Impl.PM_FILEPATH_EXTERNALAPPLICATION, new Expression_Node_StringImpl(this, cur_Gcav), log_Reports);

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
        public override string Execute5_Main(Log_Reports log_Reports)// EventArgs e
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                string sFncName;
                this.TrySelectAttribute(out sFncName, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);

                if (log_Reports.CanStopwatch)
                {
                    log_Method.Log_Stopwatch.Message = "Nアクション[" + sFncName + "]実行";
                    log_Method.Log_Stopwatch.Begin();
                }


                if (this.Functionparameterset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.Functionparameterset.Sender;

                    string fcNameStr = fcCc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                    log_Reports.Comment_EventCreationMe = "[" + fcNameStr + "]コントロールが、[" + sFncName + "]アクションを実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe = "[" + sFncName + "]アクションを実行。";
                }



                // テーブル
                XenonTable o_Table_Src;
                {
                    Expression_Node_String ec_ArgTableName;
                    this.TrySelectAttribute(out ec_ArgTableName, Expression_Node_Function06Impl.PM_NAME_TABLE_SOURCE, EnumHitcount.One_Or_Zero, log_Reports);

                    o_Table_Src = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_ArgTableName,
                        true,
                        log_Reports
                        );
                }


                Expression_Node_Filepath ec_Fpath_Csv;
                if (log_Reports.Successful)
                {
                    ec_Fpath_Csv = o_Table_Src.Expression_Filepath_ConfigStack;
                }
                else
                {
                    ec_Fpath_Csv = null;
                }


                // CSVファイルパス
                string sFpatha_csv;//絶対ファイルパス
                if (log_Reports.Successful)
                {
                    // 正常時

                    // TODO ファイルパスの妥当性判定も欲しい
                    sFpatha_csv = ec_Fpath_Csv.Execute4_OnExpressionString(
                        EnumHitcount.Unconstraint, log_Reports);
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sFpatha_csv = "";
                }

                //
                // 外部アプリケーションの起動。
                //
                Expression_Node_String ec_Fpath_ArgExternalApplication;
                this.TrySelectAttribute(out ec_Fpath_ArgExternalApplication, Expression_Node_Function06Impl.PM_FILEPATH_EXTERNALAPPLICATION, EnumHitcount.One_Or_Zero, log_Reports);

                string sEaFilePath = ec_Fpath_ArgExternalApplication.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                if ("" != sEaFilePath)
                {
                    Expression_Node_Filepath ec_Fpath_App;
                    if (log_Reports.Successful)
                    {
                        // 正常時

                        Expression_Node_String ecValue = new Expression_Node_StringImpl(this, this.Cur_Configurationtree);
                        ecValue.AppendTextNode(
                            sEaFilePath,
                            this.Cur_Configurationtree,
                            log_Reports
                            );

                        ec_Fpath_App = ecValue.Execute4_OnExpressionString_AsFilepath(
                            EnumHitcount.Unconstraint,
                            log_Reports
                            );
                    }
                    else
                    {
                        ec_Fpath_App = null;
                    }


                    string sFpatha_ExternalApplication;//絶対ファイルパス
                    if (log_Reports.Successful)
                    {
                        // 正常時


                        // 外部プログラムの起動
                        sFpatha_ExternalApplication = ec_Fpath_App.Execute4_OnExpressionString(
                            EnumHitcount.Unconstraint, log_Reports);
                        if (!log_Reports.Successful)
                        {
                            // 既エラー。
                            goto gt_EndMethod;
                        }
                    }
                    else
                    {
                        sFpatha_ExternalApplication = "";
                    }

                    if (log_Reports.Successful)
                    {
                        // 正常時

                        string program = sFpatha_ExternalApplication;
                        string argument = sFpatha_csv;

                        Process extProcess = new Process();
                        extProcess.StartInfo.FileName = program;	//起動するファイル名
                        extProcess.StartInfo.Arguments = argument;	//起動時の引数

                        extProcess.Start();

                    }
                }
            }
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
