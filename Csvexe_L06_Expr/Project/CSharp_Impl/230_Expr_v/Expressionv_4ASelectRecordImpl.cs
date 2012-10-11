using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Table;//NFldName

namespace Xenon.Expr
{

    /// <summary>
    /// ＜ｓｔａｒｔｕｐ－ｓｐｅｃｉａｌ－ｒｕｌｅ＞の中で使う子要素。
    /// </summary>
    public class Expressionv_4ASelectRecordImpl : Expression_NodeImpl, Expressionv_4ASelectRecord
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Expressionv_4ASelectRecordImpl(Expression_Node_String parent_Expression_Node, Configurationtree_Node parent_Configurationtree_Node, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression_Node, parent_Configurationtree_Node, owner_MemoryApplication)//
        {
            this.expression_Field = new Expression_Node_StringImpl(parent_Expression_Node, parent_Configurationtree_Node);
            this.expression_LookupVal = new Expression_Node_StringImpl(parent_Expression_Node, parent_Configurationtree_Node);
            this.expression_Required = new Expression_Node_StringImpl(parent_Expression_Node, parent_Configurationtree_Node);
            this.expression_From = new Expression_Node_StringImpl(parent_Expression_Node, parent_Configurationtree_Node);
            this.expression_Storage = new Expression_Node_StringImpl(parent_Expression_Node, parent_Configurationtree_Node);
            this.expression_Description = new Expression_Node_StringImpl(parent_Expression_Node, parent_Configurationtree_Node);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// レコードセットを、名前を付けて一時記憶します。
        /// </summary>
        public void Execute_SaveRecordset(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_SaveRecordset", log_Reports);
            //
            //

            //
            // 既に、一時記憶に同名のレコードセットがないか検索。

            string sStorage = this.Expression_Storage.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
            if (!this.Owner_MemoryApplication.MemoryRecordset.RecordsetStorage.Contains(this.Expression_Storage, log_Reports))
            {
                RecordSet dst_Rs_ToSave;
                Selectstatement selectSt_ToSave;
                {
                    if ("" == this.Expression_From.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim())
                    {
                        //
                        // エラー。
                        goto gt_Error_EmptyTableName;
                    }

                    Table_Humaninput oTable = this.Owner_MemoryApplication.MemoryTables.GetTable_HumaninputByName(
                        this.Expression_From,//これが空文字列の場合がある？？
                        true,
                        log_Reports
                        );
                    dst_Rs_ToSave = new RecordSetImpl(oTable);

                    //
                    // 要求の作成。
                    {
                        // ＜ｓｔａｒｔｕｐ－ｓｐｅｃｉａｌ－ｒｕｌｅ＞の中で使う子要素。
                        selectSt_ToSave = new SelectstatementImpl(this, this.Cur_Configurationtree);
                        {
                            Recordcondition recCond1;// = new RecordconditionImpl(s_ParentNode);

                            // TODO: logic要素がある版も要るはず。
                            bool bSuccessful = RecordconditionImpl.TryBuild(out recCond1, EnumLogic.None, this.Expression_Field.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), this.Cur_Configurationtree.Parent, log_Reports);
                            recCond1.Value = this.Expression_LookupVal.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                            selectSt_ToSave.List_Recordcondition.Add(recCond1);
                        }
                        selectSt_ToSave.Required = this.Expression_Required.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                        selectSt_ToSave.Expression_From = this.Expression_From;
                        selectSt_ToSave.Storage = this.Expression_Storage.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                    }
                }

                //
                // レコードの検索。
                {
                    Configurationtree_Node parent_Cf_Query = this.Cur_Configurationtree.Parent;

                    // テーブル名。
                    if ("" == selectSt_ToSave.Expression_From.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim())
                    {
                        //
                        // エラー。
                        goto gt_Error_EmptyTableName;
                    }

                    Table_Humaninput o_Table = this.Owner_MemoryApplication.MemoryTables.GetTable_HumaninputByName(selectSt_ToSave.Expression_From, true, log_Reports);

                    if (null == o_Table)
                    {
                        goto gt_Error_NullTable;
                    }



                    bool bExpectedValueRequired;
                    {
                        bool parseSuccessful = bool.TryParse(selectSt_ToSave.Required, out bExpectedValueRequired);
                    }


                    //
                    //
                    //
                    // 条件
                    //
                    //
                    //
                    string name_KeyField;
                    Fielddefinition fielddefinition_Key;
                    string value_Expected;
                    P2_ReccondImpl sel2 = new P2_ReccondImpl();
                    sel2.GetFirstAwhrReccond(
                        out name_KeyField,
                        out fielddefinition_Key,
                        out value_Expected,
                        selectSt_ToSave.List_Recordcondition,
                        o_Table,
                        log_Reports
                        );
                    List<DataRow> dst_Row = new List<DataRow>();

                    SelectPerformerImpl sp = new SelectPerformerImpl();
                    sp.Select(
                        out dst_Row,
                        name_KeyField,
                        value_Expected,
                        bExpectedValueRequired,
                        fielddefinition_Key,
                        o_Table.DataTable,
                        parent_Cf_Query,
                        log_Reports
                        );



                    dst_Rs_ToSave.AddList(dst_Row, log_Reports);
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }


                    //P2_SelectCellImpl sel2 = new P2_SelectCellImpl(this.MoOpyopyo);
                    //sel2.P2_Select(
                    //    ref dst_Rs_ToSave,
                    //    selectSt_ToSave,
                    //    this.Parent,
                    //    log_Reports
                    //    );
                }


                // debug:
                //if (false)
                //{
                //    StringBuilder txt = new StringBuilder();

                //    txt.Append(Info_E.LibraryName + ":" + this.GetType().Name + "#SaveRecordSet: 【検索してきたレコードセット】ここで内容消えてない？（２）？");
                //    txt.Append("　fld＝[" + recordSet_toSave.Selectstatement.E_Field.E_Execute(log_Reports) + "]");
                //    txt.Append("　ｌｏｏｋｕｐ－ｖａｌｕｅ＝[" + recordSet_toSave.Selectstatement.E_Value.E_Execute( log_Reports) + "]");
                //    txt.Append("　ｄescription＝[" + recordSet_toSave.Selectstatement.Expression_Description.E_Execute( log_Reports) + "]");
                //    txt.Append("　ｆｒｏｍ＝[" + recordSet_toSave.Selectstatement.Expression_From.E_Execute( log_Reports) + "]");
                //    txt.Append("　required＝[" + recordSet_toSave.Selectstatement.E_Required.E_Execute( log_Reports) + "]");
                //    txt.Append("　Ｓｔｏｒａｇｅ＝[" + recordSet_toSave.Selectstatement.Expression_Storage.E_Execute( log_Reports) + "]");

                //    //txt.Append("　this.NFld＝[" + RecordSet_toSave.NField.E_Execute(EnumHitcount.Unconstraint, log_Reports) + "]");
                //    //txt.Append("　this.NLookupValue＝[" + RecordSet_toSave.NLookupValue.E_Execute(EnumHitcount.Unconstraint, log_Reports) + "]");
                //    //txt.Append("　this.NRequired＝[" + RecordSet_toSave.NRequired.E_Execute(EnumHitcount.Unconstraint, log_Reports) + "]");
                //    //txt.Append("　this.NFrom＝[" + RecordSet_toSave.NFrom.E_Execute(EnumHitcount.Unconstraint, log_Reports) + "]");

                //    //txt.Append("　ヒット件数＝[" + RecordSet_toSave.O_Items.Count + "]");
                //    txt.Append("　ヒット件数＝[" + recordSet.Count + "]");

                //    // レコードの内容
                //    //foreach (Dictionary<string, OValue> oRecord in RecordSet_toSave.O_Items)
                //    //{
                //    //    txt.Append("　フィールド数＝[" + oRecord.Count + "]");
                //    //    foreach (string sKey in oRecord.Keys)
                //    //    {
                //    //        OValue oValue = oRecord[sKey];
                //    //        txt.Append("　要素＝[" + sKey + ":" + oValue.HumanInputString + "]");
                //    //    }
                //    //}
                //    foreach (DataRow record in recordSet)
                //    {
                //        txt.Append("　フィールド数＝[" + record.Table.Columns.Count + "]");
                //        foreach (DataColumn column in record.Table.Columns)
                //        {

                //            Value_Humaninput oValue = (Value_Humaninput)record[column.ColumnName];

                //            txt.Append("　★" + column.ColumnName + "＝[" + oValue.Humaninput + "]");
                //        }
                //    }

                //    //ystem.Console.WriteLine(txt.ToString());
                //}

                // debug:
                //if (false)
                //{
                //    StringBuilder txt = new StringBuilder();

                //    txt.Append(Info_E.LibraryName + ":" + this.GetType().Name + "#SaveRecordSet: 　【検索してきたレコードセット】内容入っていますか（３）？");


                //    txt.Append("　ヒット件数＝[" + recordSet_toSave.O_Items.Count + "]←検索後");

                //    // レコードの内容
                //    foreach (Dictionary<string, Value_Humaninput> oRecord in recordSet_toSave.O_Items)
                //    {
                //        txt.Append("　フィールド数＝[" + oRecord.Count + "]");
                //        foreach (string sKey in oRecord.Keys)
                //        {
                //            Value_Humaninput oValue = oRecord[sKey];
                //            txt.Append("　■" + sKey + "＝[" + oValue.Humaninput + "]");
                //        }
                //    }


                //    //ystem.Console.WriteLine(txt.ToString());
                //}


                //
                // レコードの一時保存。
                P4_RecordSetSaverImpl sel4 = new P4_RecordSetSaverImpl(this.Owner_MemoryApplication);
                sel4.P4_Save(
                    dst_Rs_ToSave,
                    this,
                    log_Reports
                    );
            }
            else
            {
                //ystem.Console.WriteLine(this.GetType().Name + "#SaveRecordSet: レコードセットは既に登録済みです。");
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_EmptyTableName:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(this.Cur_Configurationtree.Parent), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6030;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullTable:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configurationtree(this.Cur_Configurationtree.Parent), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6031;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// レコードセットの一時記憶を、削除します。
        /// </summary>
        public void RemoveRecordset(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "RemoveRecordset", log_Reports);
            //
            //

            if (null != this.Expression_Storage)
            {
                string sStorage = this.Expression_Storage.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim();

                if ("" != sStorage)
                {
                    //
                    // レコードセットを削除。
                    this.Owner_MemoryApplication.MemoryRecordset.RecordsetStorage.Remove(
                        this.Expression_Storage,
                        this.Owner_MemoryApplication,
                        log_Reports);
                }
            }

            //
            //
            //
            //

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ｆｉｅｌｄ＝”” 属性。
        /// </summary>
        private Expression_Node_String expression_Field;

        public Expression_Node_String Expression_Field
        {
            get
            {
                return expression_Field;
            }
            set
            {
                expression_Field = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ｌｏｏｋｕｐ－ｖａｌｕｅ="" 属性。
        /// </summary>
        private Expression_Node_String expression_LookupVal;

        public Expression_Node_String Expression_LookupVal
        {
            get
            {
                return expression_LookupVal;
            }
            set
            {
                expression_LookupVal = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// required="" 属性。
        /// </summary>
        private Expression_Node_String expression_Required;

        public Expression_Node_String Expression_Required
        {
            get
            {
                return expression_Required;
            }
            set
            {
                expression_Required = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ｆｒｏｍ="" 属性。
        /// </summary>
        private Expression_Node_String expression_From;

        public Expression_Node_String Expression_From
        {
            get
            {
                return expression_From;
            }
            set
            {
                expression_From = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// Ｓｔｏｒａｇｅ="" 属性。
        /// </summary>
        private Expression_Node_String expression_Storage;

        public Expression_Node_String Expression_Storage
        {
            get
            {
                return expression_Storage;
            }
            set
            {
                expression_Storage = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 属性。
        /// </summary>
        private Expression_Node_String expression_Description;

        public Expression_Node_String Expression_Description
        {
            get
            {
                return expression_Description;
            }
            set
            {
                expression_Description = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
