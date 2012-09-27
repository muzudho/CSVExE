using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;//Log_TextIndentedImpl
using Xenon.Middle;//NDataTargetUpdater
using Xenon.Table;//DefaultTable

namespace Xenon.Controls
{


    public class ExpressionDataTargetUpdaterImpl : ToMemory_Performer
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// このデータ・ターゲットに指定されている場所へ、値をセットします。
        /// </summary>
        /// <returns>成功すれば真。</returns>
        public void ToMemory(
            string sValue_Output,
            Expression_Node_String ec_Control,//「Expr■ｃｏｎｔｒｏｌ」相当。
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "ToM",log_Reports);

            //
            //

            List<Expression_Node_String> listExpr_Data = ec_Control.SelectDirectchildByNodename( NamesNode.S_DATA, false, Request_SelectingImpl.Unconstraint, log_Reports);
            List<Expression_Node_String> listExpr_DataTarget = Utility_Expression_NodeImpl.SelectItemsByPmAsCsv(listExpr_Data, PmNames.S_ACCESS.SName_Pm, ValuesAttr.S_TO, false, Request_SelectingImpl.First_Exist, log_Reports);
            if (!log_Reports.BSuccessful)
            {
                goto gt_EndMethod;
            }
            Expression_Node_String ec_DataTarget = listExpr_DataTarget[0];

            this.ToMemory_ParentFcells(
                sValue_Output,
                ec_DataTarget,
                moApplication,
                log_Reports
                );

            //essageBox.Show("アップデートデータ【終了】", "(FormsImpl)" + this.GetType().NFcName + "#:");
            //.WriteLine(this.GetType().NFcName + "#: 【終了】");

            //
            //
            //
            //
            goto gt_EndMethod;


        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);

            // 正常終了
            return;
        }

        //────────────────────────────────────────

        public void ToMemory_ParentFcells(
            string sValue_Output,
            Expression_Node_String parent_Expr_Fcells,//子「Ｓｆ：Ｃｅｌｌ；」関数を持った親要素。
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "ToM_ParentFcells",log_Reports);
            //
            //

            // ＜ｄａｔａ＞の子要素のリスト。
            parent_Expr_Fcells.ListExpression_Child.ForEach(delegate(Expression_Node_String child_Expr, ref bool bRemove, ref bool bBreak)
            {
                string sName_Fnc;
                child_Expr.TrySelectAttr(out sName_Fnc, PmNames.S_NAME.SName_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports);

                if (log_Reports.BSuccessful)
                {
                    if (NamesFnc.S_CELL == sName_Fnc)
                    {
                        // Ｓｆ：ｃｅｌｌ；

                        this.ToMemory_DataTargetFcell(
                            sValue_Output,
                            child_Expr,
                            moApplication,
                            log_Reports
                            );
                    }
                    //else if (NamesNode.S_ARG3 == e_Child.Cur_Givechapterandverse.SName_Node)
                    //{
                    //    // スルー
                    //    d_InMethod.WarningWrite("[" + e_Child.Cur_Givechapterandverse.SName_Node + "]ノードを無視しました。");
                    //}
                    else
                    {
                        if (log_Reports.CanCreateReport)
                        {
                            Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                            r.SetTitle("▲エラー377！", pg_Method);

                            Log_TextIndented t = new Log_TextIndentedImpl();

                            t.AppendI(0, "Ｓｆ：ｃｅｌｌ；　以外の要素が指定されていました。");
                            t.NewLine();
                            t.AppendI(0, "「データターゲット」または「ａｒｇ３　ｔｏ」には、Ｓｆ：ｃｅｌｌ；　要素１つしか指定してはいけません。");
                            t.NewLine();
                            t.NewLine();

                            t.AppendI(0, "もしかして？　「『Ｓｆ：ｃｅｌｌ；』の親」　を渡すべきところに、「『ａｒｇ３　ｔｏ』の親」を渡していませんか？");
                            t.NewLine();

                            // ヒント
                            t.AppendI(1, r.Message_Givechapterandverse(child_Expr.Cur_Givechapterandverse));

                            r.SMessage = t.ToString();
                            log_Reports.EndCreateReport();
                        }
                    }
                }
            });

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void ToMemory_DataTargetFcell(
            string sValue_Output,
            Expression_Node_String ec_SfCell,//Ｓｆ：ｃｅｌｌ；
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Controls.SName_Library, this, "ToM_DataTargetFcell",log_Reports);
            //
            //


            string sName_Fnc;
            ec_SfCell.TrySelectAttr(out sName_Fnc, PmNames.S_NAME.SName_Pm, true, Request_SelectingImpl.Unconstraint, log_Reports);
            if (NamesFnc.S_CELL != sName_Fnc)
            {
                // エラー。
                goto gt_Error_NotSfcell;
            }



            // ■ｆ－ｃｅｌｌの子要素
            Expression_Node_String ec_KeyExpected1 = null;
            int nKeyCount = 0;
            {
                //
                //「E■ｆ－ｃｅｌｌ」の子要素のリスト。
                ec_SfCell.ListExpression_Child.ForEach(delegate(Expression_Node_String e_Item, ref bool bRemove2, ref bool bBreak2)
                {
                    // キー値 が１つ入っています。
                    ec_KeyExpected1 = e_Item;
                    nKeyCount++;
                });
            }

            // それでも　＠ｋｅｙＶａｌｕｅを取得できなければ。
            if (null == ec_KeyExpected1)
            {
                //「E■ｒｅｃ－ｃｏｎｄ」を調べる。
                Expression_Node_String ec_Where;
                bool bHit2 = ec_SfCell.TrySelectAttr(out ec_Where, PmNames.S_WHERE.SName_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);
                if (bHit2)
                {
                    ec_Where.ListExpression_Child.ForEach(delegate(Expression_Node_String e_Item, ref bool bRemove2, ref bool bBreak2)
                    {
                        if (NamesNode.S_FNC == e_Item.Cur_Givechapterandverse.SName)
                        {
                            //ystem.Console.WriteLine(Info_Forms.LibraryName + ":" + this.GetType().Name + "#ToM: 「E■ｆ－ｃｅｌｌ」の「E■＠ｗｈｅｒｅ」属性の下の「E■fnc」を解析。その子要素がｖａｌｕｅ相当であるはず。");
                            ec_KeyExpected1 = e_Item;
                        }
                        else
                        {
                        }

                    });
                }
            }


            if (1 < nKeyCount)
            {
                ec_KeyExpected1 = null;

                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー311！", pg_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();

                    s.Append("「E■ｆ－ｃｅｌｌ」系要素の子要素が、「E■ｒｅｃ－ｃｏｎｄ」を除いて[" + nKeyCount + "]個ありました。");
                    s.NewLine();

                    s.Append("この子要素は　キー値になるもので、１個でなければいけません。");
                    s.NewLine();

                    // 一覧
                    s.Append("──────────子要素名一覧");
                    s.NewLine();

                    ec_SfCell.ListExpression_Child.ForEach(delegate(Expression_Node_String e_Str1, ref bool bRemove2, ref bool bBreak2)
                    {
                        if ("" == e_Str1.Cur_Givechapterandverse.SName)
                        {
                            s.Append("E■（要素名無し）");
                            s.NewLine();
                        }
                        else
                        {
                            s.Append("E■");
                            s.Append(e_Str1.Cur_Givechapterandverse.SName);
                            s.NewLine();
                        }
                    });
                    s.Append("──────────");
                    s.NewLine();

                    // ヒント
                    s.Append(r.Message_Givechapterandverse(ec_SfCell.Cur_Givechapterandverse));

                    r.SMessage = s.ToString();
                    log_Reports.EndCreateReport();
                }
            }
            else if (null == ec_KeyExpected1)
            {
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー312！", pg_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();

                    //s.Append("「E■ｆ－ｃｅｌｌ」系要素の子要素に、「E■ｆ－ｔｅｘｔ」や「E■ｆ－ｃｅｌｌ」が無いのか、有っても値がありませんでした。");
                    s.Append("「E■ｆ－ｃｅｌｌ」の「keyValue」相当の値が指定されていませんでした。");
                    s.NewLine();

                    // 一覧
                    s.Append("──────────子要素名一覧");
                    s.NewLine();
                    ec_SfCell.ListExpression_Child.ForEach(delegate(Expression_Node_String e_Str1, ref bool bRemove2, ref bool bBreak2)
                    {
                        if ("" == e_Str1.Cur_Givechapterandverse.SName)
                        {
                            s.Append("E■（要素名無し）");
                            s.NewLine();
                        }
                        else
                        {
                            s.Append("E■");
                            s.Append(e_Str1.Cur_Givechapterandverse.SName);
                            s.NewLine();
                        }
                    });
                    s.Append("──────────");
                    s.NewLine();

                    // ヒント
                    s.Append(r.Message_Givechapterandverse(ec_SfCell.Cur_Givechapterandverse));

                    r.SMessage = s.ToString();
                    log_Reports.EndCreateReport();
                }
            }

            if (log_Reports.BSuccessful)
            {

                //
                // ＜f-cell＞１つにつき。
                //
                ExpressionToMemory_FcellImpl to = new ExpressionToMemory_FcellImpl();
                to.Translate(
                    sValue_Output,
                    ec_KeyExpected1,
                    ec_SfCell,// ＜f-cell＞相当と想定。
                    moApplication,
                    log_Reports
                    );
            }

            goto gt_EndMethod;
        //
        //
        gt_Error_NotSfcell:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー909！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("Ｓｆ：ｃｅｌｌ；でないExpression_Node_Stringが指定されました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Givechapterandverse(ec_SfCell.Cur_Givechapterandverse));
                if (null != ec_SfCell)
                {
                    ec_SfCell.ToText_Snapshot(s);
                }

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
