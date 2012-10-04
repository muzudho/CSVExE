using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Table;//DefaultTable,TextTemplateImpl

namespace Xenon.Expr
{

    /// <summary>
    /// ＜ｆ－ｔｅｘｔ－ｔｅｍｐｌａｔｅ＞要素。
    /// 
    /// 
    /// </summary>
    public class Expression_SftextTemplate : Expression_NodeImpl
    {



        #region 用意
        //────────────────────────────────────────

        public const string S_TRUE = "true";

        public const string S_FIELD_ID = "ID";

        public const string S_FIELD_TEXT = "TEXT";

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="s_ParentNode"></param>
        /// <param name="moOpyopyo"></param>
        private Expression_SftextTemplate(
            Expression_Node_String parent_Expression, Configurationtree_Node parent_Configurationtree, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression, parent_Configurationtree, owner_MemoryApplication)
        {
        }

        public static Expression_Node_String Create(
            Expression_Node_String parent_Expression, Configurationtree_Node parent_Configurationtree, MemoryApplication owner_MemoryApplication)
        {
            return new Expression_SftextTemplate(parent_Expression, parent_Configurationtree, owner_MemoryApplication);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ユーザー定義プログラムの実行。
        /// </summary>
        /// <returns></returns>
        public override string Expression_ExecuteMain(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //

            Configurationtree_Node parent_Configurationtree_Node_Query = this.Cur_Configurationtree;

            StringBuilder sb_Result = new StringBuilder();

            //
            // 外観
            //
            // ＜ｆ－ｔｅｘｔ－ｔｅｍｐｌａｔｅ ｔａｂｌｅ="Ut:条件テーブル" ｌｏｏｋｕｐ－ｉｄ="100"＞
            //
            // ・ｌｏｏｋｕｐ－ｉｄ は、ｌｏｏｋｕｐ－ｖａｌｕｅ という名前の方が良かった。
            //

            //
            // 指定のテーブルの ID列を指定して、TEXT列の内容を取得。
            Builder_TexttemplateP1pImpl p1pText = new Builder_TexttemplateP1pImpl();
            {
                // ＜ｆ－ｔｅｘｔ－ｔｅｍｐｌａｔｅ＞要素。
                Selectstatement selectSt = new SelectstatementImpl(this, this.Cur_Configurationtree);

                // TODO: logic属性がある版も要るはず。
                Recordcondition recCond1;
                bool bSuccessful = RecordconditionImpl.TryBuild(out recCond1, EnumLogic.None, Expression_SftextTemplate.S_FIELD_ID, parent_Configurationtree_Node_Query, log_Reports);
                selectSt.List_Recordcondition.Add(recCond1);

                ////
                //// （１）キー_フィールド名
                //{
                //    recCond1.Name_Field = "ID";
                //}

                //
                // （２）探したいキー値
                {
                    //
                    // thisは、＜ｆ－ｔｅｘｔ－ｔｅｍｐｌａｔｅ＞。
                    //

                    string sLookupId;
                    bool bHit = this.TrySelectAttribute(out sLookupId, PmNames.S_LOOKUP_ID.Name_Pm, EnumHitcount.One, log_Reports);
                    if (bHit)
                    {
                        recCond1.Value = sLookupId;
                    }

                    string sLookupValue;
                    if (log_Reports.Successful)
                    {
                        sLookupValue = recCond1.Value;
                    }
                    else
                    {
                        // エラー
                        goto gt_Error_NotFoundVariable;
                    }

                    // bug:
                    if ("" == sLookupValue.Trim())
                    {
                        //
                        // 検索キーが空欄の場合。
                        sb_Result.Length = 0; //空文字列にする。
                        goto gt_EndMethod;
                    }
                }

                //
                // （３）検索ヒットの必須の有無
                {
                    // 必須指定。
                    selectSt.Required = Expression_SftextTemplate.S_TRUE;
                }

                //
                // （４）テーブル名
                {
                    Expression_Node_String ec_Result;//ソース情報利用
                    bool bHit = this.TrySelectAttribute(out ec_Result, PmNames.S_TABLE.Name_Pm, EnumHitcount.One, log_Reports);
                    selectSt.Expression_From = ec_Result;
                }

                //
                // （５）欲しいデータのあるフィールド名
                selectSt.List_SName_SelectField.Add(Expression_SftextTemplate.S_FIELD_TEXT);







                //
                // （１）レコードセットの絞り込み。
                RecordSet dst_Rs;
                {
                    XenonTable o_Tbl = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                        selectSt.Expression_From,//これが空文字列の場合がある？？
                        true,
                        log_Reports
                        );
                    dst_Rs = new RecordSetImpl(o_Tbl);
                }
                //dst_Rs.Selectstatement = selectSt;//★


                {

                    // テーブル名。
                    if ("" == selectSt.Expression_From.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim())
                    {
                        //
                        // エラー。
                        goto gt_Error_EmptyTableName;
                    }

                    XenonTable o_Table = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(selectSt.Expression_From, true, log_Reports);

                    if (null == o_Table)
                    {
                        goto gt_Error_NullTable;
                    }



                    bool bExpectedValueRequired;
                    {
                        bool parseSuccessful = bool.TryParse(selectSt.Required, out bExpectedValueRequired);
                    }


                    //
                    //
                    //
                    // 条件
                    //
                    //
                    //
                    string sKeyFieldName;
                    XenonFielddefinition o_KeyFldDef;
                    string sExpectedValue;
                    P2_ReccondImpl sel2 = new P2_ReccondImpl();
                    sel2.GetFirstAwhrReccond(
                        out sKeyFieldName,
                        out o_KeyFldDef,
                        out sExpectedValue,
                        selectSt.List_Recordcondition,
                        o_Table,
                        log_Reports
                        );
                    List<DataRow> dst_Row = new List<DataRow>();

                    SelectPerformerImpl sp = new SelectPerformerImpl();
                    sp.Select(
                        out dst_Row,
                        sKeyFieldName,
                        sExpectedValue,
                        bExpectedValueRequired,
                        o_KeyFldDef,
                        o_Table.DataTable,
                        parent_Configurationtree_Node_Query,
                        log_Reports
                        );



                    dst_Rs.AddList(dst_Row, log_Reports);
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }


                if (!log_Reports.Successful)
                {
                    //
                    // エラーが出ていたら、さっさと抜ける。
                    //sResult = "";
                    goto gt_EndMethod;
                }

                //
                // フィールド値の取得。
                P5_CellsSelecterImpl sel5 = new P5_CellsSelecterImpl(this.Owner_MemoryApplication);
                List<List<string>> sListList_reslt = sel5.P5_Select_CellType(
                    dst_Rs,
                    selectSt,
                    null,//nｗｈｅｒｅ_recordSetSaveTo,
                    this.Cur_Configurationtree,
                    log_Reports
                    );



                if (0 < sListList_reslt.Count)
                {
                    // 先頭行の、
                    List<string> sList_Fld = sListList_reslt[0];
                    // 先頭フィールドの値。
                    string sString = sList_Fld[0];

                    //e_string.SetValidation(...);
                    p1pText.Text = sString;
                }
                else
                {
                    // エラー

                    Log_TextIndented txt = new Log_TextIndentedImpl();
                    txt.Append(this.GetType().Name);
                    txt.Append("#GetString:(" + Info_Expr.Name_Library + ") エラー。該当なし。");

                    txt.Append(" 選択フィールド=[");

                    txt.Append(selectSt.ToSelectFieldNameListCsv());

                    txt.Append("]");

                    txt.Append(" テーブル=[");

                    txt.Append(selectSt.Expression_From.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                    txt.Append("]");

                    // キーフィールド
                    txt.Append(" [");

                    txt.Append(recCond1.Name_Field);

                    txt.Append("]が");

                    // 探す値。
                    txt.Append("[");
                    txt.Append(recCond1.Value);
                    txt.Append("]のとき");



                    p1pText.Text = txt.ToString();
                }

            }



            List<int> nList_P1p = p1pText.ExistsP1pNumbers(
                this.Dictionary_Expression_Attribute,
                log_Reports
                );

            foreach (int n_P1p in nList_P1p)
            {
                string p1pValue;
                {
                    bool bHit = this.TrySelectAttribute(
                        out p1pValue,
                        "p" + n_P1p+"p",
                        EnumHitcount.One,
                        log_Reports
                        );

                    if (log_Reports.Successful)
                    {
                    }
                    else
                    {
                        p1pValue = null;
                    }

                    p1pText.Dictionary_NumberAndValue_Parameter.Add(n_P1p, p1pValue);
                }
            }


            Expression_Node_String ec_TextTemplate = p1pText.Compile(
                log_Reports
                );

            sb_Result.Append(ec_TextTemplate.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));

            
            //
            //
            //
            // TODO: 制約の判定
            //
            //
            //

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundVariable:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(parent_Configurationtree_Node_Query), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6009;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_EmptyTableName:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(parent_Configurationtree_Node_Query), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6010;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullTable:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(parent_Configurationtree_Node_Query), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6011;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sb_Result.ToString();
        }

        //────────────────────────────────────────
        #endregion



    }
}
