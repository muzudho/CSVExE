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
        public Expressionv_5FAllFieldsIsEmptyImpl(Expression_Node_String parent_Expression_Node, Configurationtree_Node parent_Configurationtree_Node, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression_Node, parent_Configurationtree_Node, owner_MemoryApplication)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ユーザー定義プログラムの実行。
        /// </summary>
        /// <param name="hits"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public override string Execute4_OnExpressionString(
            EnumHitcount hits,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnExpressionString",log_Reports);
            //
            //

            Expression_Node_String err_Ev11;
            bool bAllFldsIsEmpty = true;

            Expression_Node_String ec_RecordSetLoadFrom;//ソース情報利用
            bool bHit = this.TrySelectAttribute(out ec_RecordSetLoadFrom, NamesNode.S_RECORD_SET_LOAD_FROM, EnumHitcount.One, log_Reports);

            //
            // 一時記憶に記憶されているレコードセットのコピー内容。
            RecordSet recordSet;
            if (log_Reports.Successful)
            {
                string sRecordSetLoadFrom = ec_RecordSetLoadFrom.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                // #デバッグ中
                System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#E_Execute: ★★ record-set-load-ｆｒｏｍ＝[" + sRecordSetLoadFrom + "]");

                recordSet = this.Owner_MemoryApplication.MemoryRecordset.RecordsetStorage.Get(ec_RecordSetLoadFrom,
                    this.Owner_MemoryApplication,
                    log_Reports);
            }
            else
            {
                recordSet = null;
            }

            Value_Humaninput err_OValue;
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
                        EnumHitcount.Unconstraint,
                        log_Reports
                        );

                    foreach (Expression_Node_String ec_11 in ecList_Child)
                    {
                        if (ec_11 is Expressionv_Elem99)
                        {
                            Expressionv_Elem99 ev_elem = (Expressionv_Elem99)ec_11;
                            ev_elem.SetDataRow(this.DataRow);
                            sb_Csv.Append(ev_elem.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                        }
                        else if (ec_11 is Expression_Node_StringImpl)
                        {
                            sb_Csv.Append(ec_11.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
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
                    Value_Humaninput oValue;
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
                    System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#E_Execute: oValue.Text＝[" + oValue.Text + "]");


                    if (oValue is Int_HumaninputImpl)
                    {
                        Int_HumaninputImpl oInt = (Int_HumaninputImpl)oValue;

                        if ("" != oInt.Text)
                        {
                            bAllFldsIsEmpty = false;
                        }
                    }
                    else if (oValue is String_HumaninputImpl)
                    {
                        String_HumaninputImpl oString = (String_HumaninputImpl)oValue;

                        if ("" != oString.Text)
                        {
                            bAllFldsIsEmpty = false;
                        }
                    }
                    else if (oValue is Bool_HumaninputImpl)
                    {
                        Bool_HumaninputImpl oBool = (Bool_HumaninputImpl)oValue;

                        if ("" != oBool.Text)
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_OValue.GetType().Name, log_Reports);//値の型名
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6032;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedElementClass:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_Ev11.GetType().Name, log_Reports);//クラス名
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6033;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedFld:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_SFldName.ToUpper(), log_Reports);//フィールド名大文字化
                tmpl.SetParameter(2, err_SCsv, log_Reports);//指定されたフィールド名の文字列

                StringBuilder s1 = new StringBuilder();
                foreach (string str in err_SList)
                {
                    s1.Append("[");
                    s1.Append(str);
                    s1.Append("]");
                    s1.Append(Environment.NewLine);
                }
                tmpl.SetParameter(3, s1.ToString(), log_Reports);//指定されたフィールド名の文字列

                StringBuilder s2 = new StringBuilder();
                // あるフィールド名の一覧
                foreach (DataColumn dataColumn in this.DataRow.Table.Columns)
                {
                    s2.Append("[");
                    s2.Append(dataColumn.ColumnName);
                    s2.Append("]");
                    s2.Append(Environment.NewLine);
                }
                tmpl.SetParameter(4, s1.ToString(), log_Reports);//指定されたフィールド名の文字列

                tmpl.SetParameter(5, Log_RecordReportsImpl.ToText_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト
                tmpl.SetParameter(6, Log_RecordReportsImpl.ToText_Exception(err_Excp), log_Reports);//例外メッセージ

                this.Owner_MemoryApplication.CreateErrorReport("Er:6034;", tmpl, log_Reports);
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
