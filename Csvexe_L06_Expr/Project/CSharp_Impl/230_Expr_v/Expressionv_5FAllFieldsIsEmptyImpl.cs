using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Table;


namespace Xenon.Expr
{
    public class Expressionv_5FAllFieldsIsEmptyImpl : Expressionv_Elem99Impl, Expressionv_5FAllFieldsIsEmpty
    {


        
        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="s_ParentNode"></param>
        /// <param name="moOpyopyo"></param>
        public Expressionv_5FAllFieldsIsEmptyImpl(Expression_Node_String parent_Expression_Node, Givechapterandverse_Node parent_Givechapterandverse_Node, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression_Node, parent_Givechapterandverse_Node, owner_MemoryApplication)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ユーザー定義プログラムの実行。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public override string Execute_OnExpressionString(
            Request_Selecting request,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnExpressionString",log_Reports);
            //
            //

            Expression_Node_String err_Ev11;
            bool bAllFldsIsEmpty = true;

            Expression_Node_String ec_RecordSetLoadFrom;//ソース情報利用
            bool bHit = this.Dictionary_Expression_Attribute.TrySelect(out ec_RecordSetLoadFrom, NamesNode.S_RECORD_SET_LOAD_FROM, true, Request_SelectingImpl.Unconstraint, log_Reports);

            //
            // 一時記憶に記憶されているレコードセットのコピー内容。
            RecordSet recordSet;
            if (log_Reports.Successful)
            {
                string sRecordSetLoadFrom = ec_RecordSetLoadFrom.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                // #デバッグ中
                System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#E_Execute: ★★ record-set-load-ｆｒｏｍ＝[" + sRecordSetLoadFrom + "]");

                recordSet = this.Owner_MemoryApplication.MemoryRecordset.RecordsetStorage.Get(ec_RecordSetLoadFrom, log_Reports);
            }
            else
            {
                recordSet = null;
            }

            XenonValue err_OValue;
            string err_SFldName;
            Exception err_Excp;
            string err_SCsv;
            List<string> err_SList;
            if (log_Reports.Successful)
            {
                //
                // 子＜f-●●＞要素を実行し、文字列連結。
                // 「SK10,LV10,OP10,COND10,COND10x,COND10y,COND10z,PRI10,RATE10,PER10」といった文字列が取得できることを期待。
                StringBuilder sb_Csv = new StringBuilder();
                {
                    List<Expression_Node_String> ecList_Child = this.List_Expression_Child.SelectList(
                        Request_SelectingImpl.Unconstraint,
                        log_Reports
                        );

                    foreach (Expression_Node_String ec_11 in ecList_Child)
                    {
                        if (ec_11 is Expressionv_Elem99)
                        {
                            Expressionv_Elem99 ev_elem = (Expressionv_Elem99)ec_11;
                            ev_elem.SetDataRow(this.DataRow);
                            sb_Csv.Append(ev_elem.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                        }
                        else if (ec_11 is Expression_Node_StringImpl)
                        {
                            sb_Csv.Append(ec_11.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                        }
                        else
                        {
                            err_Ev11 = ec_11;
                            bAllFldsIsEmpty = false;
                            goto gt_Error_UndefinedElementClass;
                        }
                    }
                }

                //
                // コンマ区切り文字列を、リスト化。
                List<string> sList;
                {
                    CsvTo_ListImpl csvTo = new CsvTo_ListImpl();
                    sList = csvTo.Read(sb_Csv.ToString());
                }


                //
                // 全部真なら真、１つでも偽なら偽。
                foreach (string sFldName in sList)
                {
                    // bug: argumentException
                    XenonValue oValue;
                    try
                    {
                        // レコードセットの１件目だけをとりあえず確認。TODO:
                        oValue = recordSet.List_Field[0][sFldName.ToUpper()];
                        //oValue = (OValue)dataRow[fldName];
                    }
                    catch (KeyNotFoundException ex)
                    {
                        err_Excp = ex;
                        err_SFldName = sFldName;
                        err_SCsv = sb_Csv.ToString();
                        err_SList = sList;
                        goto gt_Error_UndefinedFld;
                    }


                    // #デバッグ中
                    System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#E_Execute: oValue.Humaninput＝[" + oValue.Humaninput + "]");


                    if (oValue is XenonValue_IntImpl)
                    {
                        XenonValue_IntImpl oInt = (XenonValue_IntImpl)oValue;

                        if ("" != oInt.Humaninput)
                        {
                            bAllFldsIsEmpty = false;
                        }
                    }
                    else if (oValue is XenonValue_StringImpl)
                    {
                        XenonValue_StringImpl oString = (XenonValue_StringImpl)oValue;

                        if ("" != oString.Humaninput)
                        {
                            bAllFldsIsEmpty = false;
                        }
                    }
                    else if (oValue is XenonValue_BoolImpl)
                    {
                        XenonValue_BoolImpl oBool = (XenonValue_BoolImpl)oValue;

                        if ("" != oBool.Humaninput)
                        {
                            bAllFldsIsEmpty = false;
                        }

                        //
                        // TODO: false/trueタイプ、0/1タイプにも対応したい。
                        //
                    }
                    else
                    {
                        //
                        // エラー。
                        err_OValue = oValue;
                        goto gt_Error_UndefinedType;
                    }
                }
            }


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedType:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー115！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("未定義のタイプです。プログラミングのミス？");
                t.Append(Environment.NewLine);
                t.Append("oValueの型名＝[");
                t.Append(err_OValue.GetType().Name);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedElementClass:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー116！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("未定義のタイプです。プログラミングのミス？");
                t.Append(Environment.NewLine);
                t.Append("err_Ev11の型名＝[");
                t.Append(err_Ev11.GetType().Name);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedFld:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー117！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("無いフィールドを指定しました。設定、もしくはプログラミングのミス？");
                t.Append(Environment.NewLine);
                t.Append("無いフィールド名＝[");
                t.Append(err_SFldName.ToUpper());
                t.Append("]（大文字化されます）");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
            

                t.Append(Environment.NewLine);
                t.Append("指定されたフィールド名の文字列＝[");
                t.Append(err_SCsv);
                t.Append("]");
                t.Append(Environment.NewLine);

                t.Append("指定されたフィールド名の一覧");
                t.Append(Environment.NewLine);
                foreach (string str in err_SList)
                {
                    t.Append("[");
                    t.Append(str);
                    t.Append("]");
                    t.Append(Environment.NewLine);
                }
                t.Append("以上");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);


                // あるフィールド名の一覧
                t.Append("フィールド名の一覧");
                t.Append(Environment.NewLine);
                foreach (DataColumn dataColumn in this.DataRow.Table.Columns)
                {
                    t.Append("[");
                    t.Append(dataColumn.ColumnName);
                    t.Append("]");
                    t.Append(Environment.NewLine);
                }
                t.Append("以上");
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(this.Cur_Givechapterandverse));
                t.Append(r.Message_SException(err_Excp));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return bAllFldsIsEmpty.ToString();
        }

        //────────────────────────────────────────
        #endregion

    }
}
