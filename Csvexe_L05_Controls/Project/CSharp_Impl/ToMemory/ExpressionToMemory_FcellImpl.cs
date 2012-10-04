using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Syntax;//Log_TextIndentedImpl
using Xenon.Middle;//NDataTargetUpdater,NFuncCell
using Xenon.Table;//DefaultTable

namespace Xenon.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class ExpressionToMemory_FcellImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ＜ｆ－ｃｅｌｌ＞→M
        /// </summary>
        /// <param name="outputValueStr"></param>
        /// <param name="nKeyExpected"></param>
        /// <param name="nFcell"></param>
        /// <param name="moApplication"></param>
        /// <param name="log_Reports"></param>
        public void Translate(
            string sOutputValue,
            Expression_Node_String ec_KeyExpected,
            Expression_Node_String ec_SfCell,//Ｓｆ：ｃｅｌｌ；相当と想定。
            MemoryApplication moApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "EToM2",log_Reports);
            //
            //

            string sName_Fnc;
            ec_SfCell.TrySelectAttribute(out sName_Fnc, PmNames.S_NAME.Name_Pm, EnumHitcount.One, log_Reports);
            if (NamesFnc.S_CELL != sName_Fnc)
            {
                // エラー。
                goto gt_Error_NotSfcell;
            }


            string sSelectedFldName;
            if (log_Reports.Successful)
            {
                bool bHit = ec_SfCell.TrySelectAttribute(
                    out sSelectedFldName,
                    PmNames.S_SELECT.Name_Pm,
                    EnumHitcount.One_Or_Zero,
                    log_Reports
                    );

                //if (!bHit)
                //{
                //    // 【追加 2012-07-10】
                //    // Sf:cell; の子要素arg1 には、name="ｓｅｌｅｃｔ" のものがある。本来これは属性連結しておいて欲しい。
                //    List<Expression_Node_String> list_Arg1 = e_SfCell.SelectDirectchildByNodename(NamesNode.S_ARG1, false, EnumHitcount.Unconstraint, log_Reports);

                //    d_InMethod.WriteDebug_ToConsole(1, "sSelectedFldNameが属性になかった。子要素ａｒｇ１（" + list_Arg1 .Count+ "個）から探す。");
                //    if (0<d_InMethod.NDebugLevel && list_Arg1.Count<=0)
                //    {
                //        Log_TextIndented s = new Log_TextIndentedImpl();
                //        e_SfCell.ToText_Snapshot(s);
                //        d_InMethod.WriteDebug_ToConsole(1, s.ToString());   
                //    }

                //    EUtil_NodeImpl.SelectItemsByAttrAsCsv(list_Arg1, PmNames.NAME.SAttrName, ValuesAttr.S_SELECT, false, EnumHitcount.First_Exist, log_Reports);

                //    if (log_Reports.Successful)
                //    {
                //        sSelectedFldName = list_Arg1[0].Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                //    }
                //}
            }
            else
            {
                sSelectedFldName = "";
            }


            Expression_Node_String ec_KeyFldName1 = null;
            if (log_Reports.Successful)
            {
                Expression_Node_String ec_Where = null;

                //
                //　「E■ｗｈｅｒｅ」は子要素。
                //

                // 再検索。
                ec_SfCell.List_Expression_Child.ForEach(delegate(Expression_Node_String ec_Child, ref bool bRemove, ref bool bBreak)
                {
                    string sValue;
                    ec_Child.TrySelectAttribute(out sValue, PmNames.S_NAME.Name_Pm, EnumHitcount.One, log_Reports);

                    if (NamesNode.S_FNC == ec_Child.Cur_Configurationtree.Name &&
                        NamesFnc.S_WHERE == sValue)
                    {
                        ec_Where = ec_Child;

                        if (pg_Method.CanDebug(2))
                        {
                            pg_Method.WriteDebug_ToConsole("子「E■[" + ec_Child.Cur_Configurationtree.Name + "]」。子要素数=[" + ec_Where.List_Expression_Child.Count + "]");
                        }

                        ec_Where.List_Expression_Child.ForEach(delegate(Expression_Node_String e_Item, ref bool bRemove2, ref bool bBreak2)
                        {
                            if (NamesNode.S_FNC == e_Item.Cur_Configurationtree.Name)
                            {
                                Expression_Node_String ec_Field;
                                bool bHit3 = e_Item.TrySelectAttribute(out ec_Field, PmNames.S_FIELD.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                                if (bHit3)
                                {
                                    //「E■ｆ－ｃｅｌｌ」／「E■＠ｗｈｅｒｅ」／「E■ｆｎｃ　ｆｉｅｌｄ＝”★”」。
                                    ec_KeyFldName1 = ec_Field;

                                    if (pg_Method.CanDebug(2))
                                    {
                                        pg_Method.WriteDebug_ToConsole( "「E■ｆ－ｃｅｌｌ」／「E■ａ－ｗｈｅｒｅ」／「E■ｆｎｃ　ｆｉｅｌｄ＝”[" + ec_KeyFldName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]”」。");
                                    }
                                }
                                else
                                {
                                    throw new Exception("ここは通らない？");
                                }
                            }
                            else
                            {
                                // #エラー
                                System.Console.WriteLine(Info_Controls.Name_Library + ":" + this.GetType().Name + "#EToM: 「E■ｆｎｃ」がありませんでした。");
                            }

                        });
                    }
                    else
                    {
                        if (pg_Method.CanDebug(2))
                        {
                            pg_Method.WriteDebug_ToConsole( "（無視）　 子「E■[" + ec_Child.Cur_Configurationtree.Name + "]」。");
                        }
                    }
                });

                if (null == ec_Where)
                {
                    // #エラー
                    System.Console.WriteLine(Info_Controls.Name_Library + ":" + this.GetType().Name + "#EToM: 「E■ｆ－ｃｅｌｌ」に、子「E■ｗｈｅｒｅ」が無かった？　そういう場合（無条件）もある。");
                }
            }
            else
            {
                ec_KeyFldName1 = null;
            }


            //
            // ｆｒｏｍ
            //
            Expression_Node_String ec_TableName1;//ソース情報利用
            if (log_Reports.Successful)
            {
                // Sf:cell; に ｆｒｏｍ が指定されていない？
                bool bHit = ec_SfCell.TrySelectAttribute(
                    out ec_TableName1,
                    PmNames.S_FROM.Name_Pm,
                    EnumHitcount.One,
                    log_Reports
                    );

                //if (null == e_TableName1)
                //{
                //    d_InMethod.WriteDebug_ToConsole(1, "e_TableName1が属性になかった。子要素ａｒｇ１から探す。");
                //    // 【追加 2012-07-10】
                //    // Sf:cell; の子要素arg1 には、name=”ｆｒｏｍ” のものがある。本来これは属性連結しておいて欲しい。
                //    List<Expression_Node_String> list_Arg1 = e_SfCell.SelectDirectchildByNodename(NamesNode.S_ARG1, false, EnumHitcount.Unconstraint, log_Reports);
                //    EUtil_NodeImpl.SelectItemsByAttrAsCsv(list_Arg1, PmNames.NAME.SAttrName, ValuesAttr.S_FROM, false, EnumHitcount.First_Exist, log_Reports);

                //    if (log_Reports.Successful)
                //    {
                //        e_TableName1 = list_Arg1[0];
                //    }
                //}
            }
            else
            {
                ec_TableName1 = null;
            }


            //
            // required
            //
            bool bExpectedValueRequired = false;
            if (log_Reports.Successful)
            {
                string sRequired1;
                bool bHit = ec_SfCell.TrySelectAttribute(out sRequired1, PmNames.S_REQUIRED.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                if (bHit)
                {
                    // 【旧仕様】
                    bool bParseSuccessful = bool.TryParse(sRequired1, out bExpectedValueRequired);
                }
                else
                {
                    // 【新仕様】

                    //
                    // 新仕様では、「E■ｆ－ｃｅｌｌ／＠E■ｗｈｅｒｅ／E■ｐｒｍ　ｎａｍｅ＝”ｒｅｑｕｉｒｅｄ”」。
                    //
                    {
                        Expression_Node_String ec_Where;
                        bool bHit1 = ec_SfCell.TrySelectAttribute(out ec_Where, PmNames.S_WHERE.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                        if (bHit1)
                        {
                            throw new Exception("こーこは通らない？");
                        }
                    }

                }
            }
            else
            {
            }


            // e_TableName を取得してから引数エラーチェック。
            if (null == ec_KeyExpected)
            {
                // エラー
                goto gt_Error_NullKeyExpected;
            }

            // ──────────

            XenonTable o_Table;
            if (log_Reports.Successful)
            {
                o_Table = moApplication.MemoryTables.GetXenonTableByName(ec_TableName1, true, log_Reports);
                // エラー時には、エラーメッセージを出させます。

                if (null == o_Table)
                {
                    //
                    // エラー中断。
                    goto gt_Error_NotFoundTable;
                }
                else
                {
                    //
                    // 正常時
                    //
                    //.WriteLine("(" + Info_Forms .LibraryName+ ")" + this.GetType().NFcName + "#...: （１）テーブル検索終了 refOTable=[" + refOTable.SourceFilePath + "]");
                }
            }
            else
            {
                o_Table = null;
            }


            string err_SKeyFldName;
            string err_SSelectedFldName;

            // field=""。
            XenonFielddefinition o_KeyFldDef;
            if (log_Reports.Successful)
            {
                //
                // 検索のキーとなるフィールドの定義を調べます。
                //

                List<string> sList_KeyFldName;
                {
                    sList_KeyFldName = new List<string>();

                    string sKeyFldName = ec_KeyFldName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                    if ("" == sKeyFldName.Trim())
                    {
                        // エラー
                        err_SKeyFldName = sKeyFldName;
                        goto gt_Error_EmptyKeyField;
                    }
                    sList_KeyFldName.Add(sKeyFldName);
                    if (sList_KeyFldName.Count < 1)
                    {
                        // エラー
                        err_SKeyFldName = sKeyFldName;
                        goto gt_Error_ZeroKeyField;
                    }
                }

                List<XenonFielddefinition> oList_KeyFldDef;
                bool bHit = o_Table.TryGetFieldDefinitionByName(
                    out oList_KeyFldDef,
                    sList_KeyFldName,
                    true,
                    log_Reports
                    );
                if (!log_Reports.Successful || !bHit)
                {
                    goto gt_EndMethod;
                }

                o_KeyFldDef = oList_KeyFldDef[0];
            }
            else
            {
                o_KeyFldDef = null;
            }


            List<XenonFielddefinition> oList_SelectedFldDef;
            if (log_Reports.Successful)
            {
                // 選択対象のフィールドの定義を調べます。

                List<string> sList_SelectedFldName;
                {
                    sList_SelectedFldName = new CsvTo_ListImpl().Read(sSelectedFldName);
                    foreach (string sName in sList_SelectedFldName)
                    {
                        if ("" == sName.Trim())
                        {
                            // エラー
                            err_SSelectedFldName = sSelectedFldName;
                            goto gt_Error_EmptySelectField;
                        }
                    }

                    if (sList_SelectedFldName.Count < 1)
                    {
                        // エラー
                        err_SSelectedFldName = sSelectedFldName;
                        goto gt_Error_ZeroSelectField;
                    }
                }

                bool bHit = o_Table.TryGetFieldDefinitionByName(
                    out oList_SelectedFldDef,
                    sList_SelectedFldName,
                    false,
                    log_Reports
                    );
                if (!log_Reports.Successful || !bHit)
                {
                    goto gt_EndMethod;
                }
            }
            else
            {
                oList_SelectedFldDef = null;
            }



            if (log_Reports.Successful)
            {
                if (null == o_KeyFldDef)
                {
                    //
                    // エラー中断。
                    goto gt_Error_NotFoundKeyFldDefinition;
                }
            }



            if (log_Reports.Successful)
            {
                if (oList_SelectedFldDef.Count < 1)
                {
                    //
                    // エラー中断。
                    goto gt_Error_NotFoundSelectFldDefinition;
                }
            }


            if (log_Reports.Successful)
            {

                List<DataRow> dst_Row = new List<DataRow>();


                string sKeyFieldName = ec_KeyFldName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                string sExpectedValue = ec_KeyExpected.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                Configurationtree_Node cf_WrittenPlace_Query = ec_SfCell.Cur_Configurationtree;

                SelectPerformerImpl sp = new SelectPerformerImpl();
                sp.Select(
                    out dst_Row,
                    sKeyFieldName,
                    sExpectedValue,
                    bExpectedValueRequired,
                    o_KeyFldDef,
                    o_Table.DataTable,
                    cf_WrittenPlace_Query,
                    log_Reports
                    );




                if (0 < dst_Row.Count)
                {
                    //.WriteLine("(" + Info_Forms .LibraryName+ ")" + this.GetType().NFcName + "#...: （６a）該当 recordSet.Count=[" + recordSet.Count + "]");

                    foreach (DataRow row in dst_Row)
                    {
                        ToMemory_CellImpl updater = new ToMemory_CellImpl();


                        foreach (XenonFielddefinition o_SelectedFldDef in oList_SelectedFldDef)
                        {
                            updater.ToMemory_ToSelectedField(
                                sOutputValue,
                                ec_SfCell,
                                row,
                                o_SelectedFldDef,
                                log_Reports
                                );
                        }
                    }

                }
                else
                {
                    //
                    // エラー。
                    goto gt_Error_NotFoundRecord;
                }
            }

            goto gt_EndMethod;
        //
        //
        gt_Error_NotSfcell:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー909！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("Ｓｆ：ｃｅｌｌ；でないExpression_Node_Stringが指定されました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));
                if (null != ec_SfCell)
                {
                    ec_SfCell.ToText_Snapshot(s);
                }

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //
        //
        gt_Error_NullKeyExpected:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー906！", pg_Method);

                StringBuilder s = new StringBuilder();

                s.Append("引数e_KeyExpectedにヌルが指定されました。 e_KeyExpected=[");
                s.Append(ec_KeyExpected);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　　this.TableName=[");
                s.Append(ec_TableName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;

        gt_Error_EmptyKeyField:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー903！", pg_Method);

                StringBuilder s = new StringBuilder();

                s.Append("fieldで指定されたキーフィールドの名前が空文字列でした。 err_SKeyFldName=[");
                s.Append(err_SKeyFldName);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　　this.TableName=[");
                s.Append(ec_TableName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;

        gt_Error_ZeroKeyField:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー902！", pg_Method);

                StringBuilder s = new StringBuilder();

                s.Append("fieldで指定されたキーフィールドの個数が０個でした。 err_SKeyFldName=[");
                s.Append(err_SKeyFldName);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　　this.TableName=[");
                s.Append(ec_TableName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;

        gt_Error_EmptySelectField:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー904！", pg_Method);

                StringBuilder s = new StringBuilder();

                s.Append("selectで指定されたフィールドの名前に空文字列がありました。 err_SSelectedFldName=[");
                s.Append(err_SSelectedFldName);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　　this.TableName=[");
                s.Append(ec_TableName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;

        gt_Error_ZeroSelectField:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー901！", pg_Method);

                StringBuilder s = new StringBuilder();

                s.Append("selectで指定されたフィールドの個数が０個でした。 err_SSelectedFldName=[");
                s.Append(err_SSelectedFldName);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　　this.TableName=[");
                s.Append(ec_TableName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;

            // エラー。
        gt_Error_NotFoundTable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1011！", pg_Method);

                StringBuilder s = new StringBuilder();

                s.Append("　ヌル＝refTable");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("　　this.TableName=[");
                s.Append(ec_TableName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;

        gt_Error_NotFoundKeyFldDefinition:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー478！", pg_Method);

                StringBuilder t = new StringBuilder();

                t.Append("　キーフィールドの定義を取得できませんでした。");
                t.Append(Environment.NewLine);

                t.Append("「E■[");
                t.Append(ec_KeyFldName1.Cur_Configurationtree.Name);
                t.Append("]」、キーフィールド名=[");
                t.Append(ec_KeyFldName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;

        gt_Error_NotFoundSelectFldDefinition:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー479！", pg_Method);

                StringBuilder t = new StringBuilder();

                t.Append("　取得データが入っているはずのフィールドの定義を取得できませんでした。");
                t.Append(Environment.NewLine);
                t.Append("　　指定されたフィールド名=[");
                t.Append(sSelectedFldName);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;

        gt_Error_NotFoundRecord:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー344！", pg_Method);

                string sDebugExceptedKey = ec_KeyExpected.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("【失敗】");
                s.Newline();
                s.Newline();

                s.Append("［");
                s.Append(o_Table.Name);
                s.Append("］（テーブル）には、");
                s.Append(Environment.NewLine);

                s.Append("［");
                s.Append(ec_KeyFldName1.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                s.Append("］フィールドに");

                s.Append("[");
                s.Append(sDebugExceptedKey);
                s.Append("]が入っているレコードは、見つかりませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("この入力したデータは、入力が確定されず、無視されています。");
                s.Append(Environment.NewLine);

                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("もしかして？");
                s.Append(Environment.NewLine);
                s.Append("　・ツールの不便さにより、手入力で");
                s.Append(Environment.NewLine);
                s.Append("　　指定のテーブルに　ID付きのレコードの空欄を");
                s.Append(Environment.NewLine);
                s.Append("　　予め　作っておかなければならなかった、といった決まりごとはありませんか？");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("　・それとも、それ以外の理由？");
                s.Append(Environment.NewLine);

                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("────────以下はプログラマー用の情報。");
                s.Append(Environment.NewLine);


                // ヒント
                s.Append(r.Message_Configurationtree(ec_SfCell.Cur_Configurationtree));

                r.Message = s.ToString();

                //essageBox.Show(r.SMsg(log_Reports), Info_Forms.LibraryName + ":" + this.GetType().Name );
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
