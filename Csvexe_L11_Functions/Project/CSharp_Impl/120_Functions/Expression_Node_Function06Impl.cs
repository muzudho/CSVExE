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

        public static readonly string S_ACTION_NAME = "Sf:外部アプリケーション起動_CSV渡す;";

        //────────────────────────────────────────
        //
        // 引数名
        //

        /// <summary>
        /// 元となるテーブル名。//カンマ区切りで複数指定できる。
        /// </summary>
        public static readonly string S_PM_NAME_TABLE_SRC = PmNames.S_NAME_TABLE_SRC.SName_Pm;

        /// <summary>
        /// 外部アプリケーションを実行するなら、そのファイルパス。なければ空文字列。
        /// </summary>
        public static string S_PM_FILEPATH_EXTERNALAPPLICATION = PmNames.S_FILEPATH_EXTERNALAPPLICATION.SName_Pm;

        //────────────────────────────────────────
        #endregion

        

        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function06Impl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem)
            :base(enumEventhandler, listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "E_Sa06Impl",pg_Logging);
            //

            Expression_Node_Function f0 = new Expression_Node_Function06Impl(this.EnumEventhandler,this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);

            f0.DicExpression_Attr.Set(Expression_Node_Function06Impl.S_PM_NAME_TABLE_SRC, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);
            f0.DicExpression_Attr.Set(Expression_Node_Function06Impl.S_PM_FILEPATH_EXTERNALAPPLICATION, new Expression_Node_StringImpl(this, cur_Gcav), pg_Logging);

            //
            pg_Method.EndMethod(pg_Logging);
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
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)// EventArgs e
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                string sFncName;
                this.TrySelectAttr(out sFncName, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                if (pg_Logging.CanStopwatch)
                {
                    pg_Method.Log_Stopwatch.SMessage = "Nアクション[" + sFncName + "]実行";
                    pg_Method.Log_Stopwatch.Begin();
                }


                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol fcCc = (Customcontrol)this.ExpressionfncPrmset.Sender;

                    string fcNameStr = fcCc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                    pg_Logging.SComment_EventCreationMe = "[" + fcNameStr + "]コントロールが、[" + sFncName + "]アクションを実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe = "[" + sFncName + "]アクションを実行。";
                }



                // テーブル
                XenonTable o_Table_Src;
                {
                    Expression_Node_String ec_ArgTableName;
                    this.TrySelectAttr(out ec_ArgTableName, Expression_Node_Function06Impl.S_PM_NAME_TABLE_SRC, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                    o_Table_Src = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        ec_ArgTableName,
                        true,
                        pg_Logging
                        );
                }


                Expression_Node_Filepath ec_Fpath_Csv;
                if (pg_Logging.BSuccessful)
                {
                    ec_Fpath_Csv = o_Table_Src.Expression_Filepath_ConfigStack;
                }
                else
                {
                    ec_Fpath_Csv = null;
                }


                // CSVファイルパス
                string sFpatha_csv;//絶対ファイルパス
                if (pg_Logging.BSuccessful)
                {
                    // 正常時

                    // TODO ファイルパスの妥当性判定も欲しい
                    sFpatha_csv = ec_Fpath_Csv.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint, pg_Logging);
                    if (!pg_Logging.BSuccessful)
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
                this.TrySelectAttr(out ec_Fpath_ArgExternalApplication, Expression_Node_Function06Impl.S_PM_FILEPATH_EXTERNALAPPLICATION, false, Request_SelectingImpl.Unconstraint, pg_Logging);

                string sEaFilePath = ec_Fpath_ArgExternalApplication.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                if ("" != sEaFilePath)
                {
                    Expression_Node_Filepath ec_Fpath_App;
                    if (pg_Logging.BSuccessful)
                    {
                        // 正常時

                        Expression_Node_String ecValue = new Expression_Node_StringImpl(this, this.Cur_Givechapterandverse);
                        ecValue.AppendTextNode(
                            sEaFilePath,
                            this.Cur_Givechapterandverse,
                            pg_Logging
                            );

                        ec_Fpath_App = ecValue.Execute_OnExpressionString_AsFilePath(
                            Request_SelectingImpl.Unconstraint,
                            pg_Logging
                            );
                    }
                    else
                    {
                        ec_Fpath_App = null;
                    }


                    string sFpatha_ExternalApplication;//絶対ファイルパス
                    if (pg_Logging.BSuccessful)
                    {
                        // 正常時


                        // 外部プログラムの起動
                        sFpatha_ExternalApplication = ec_Fpath_App.Execute_OnExpressionString(
                            Request_SelectingImpl.Unconstraint, pg_Logging);
                        if (!pg_Logging.BSuccessful)
                        {
                            // 既エラー。
                            goto gt_EndMethod;
                        }
                    }
                    else
                    {
                        sFpatha_ExternalApplication = "";
                    }

                    if (pg_Logging.BSuccessful)
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
            pg_Method.EndMethod(pg_Logging);
            return "";
        }

        //────────────────────────────────────────
        #endregion



    }
}
