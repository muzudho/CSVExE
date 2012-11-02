using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Table;//DefaultTable,FldDefinition,NFldName

namespace Xenon.Expr
{

    /// <summary>
    /// データベースから、セル値を取得します。
    /// </summary>
    public class P5_CellsSelecterImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public P5_CellsSelecterImpl(MemoryApplication owner_MemoryApplication)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// フィールドから値を取得。
        /// 
        /// TODO:セルタイプ以外にも対応したい。
        /// </summary>
        /// <param name="RecordSet_toSave">ヌル不可</param>
        /// <param name="eSelectedFldName">選択フィールド</param>
        /// <param name="RecordSetSaveTo_or_null"></param>
        /// <param name="log_Reports"></param>
        /// <returns>行リスト＜列リスト＞</returns>
        public List<List<string>> P5_Select_CellType(
            RecordSet dst_Rs_toSave,
            Selectstatement selectSt_ToSave,
            Expressionv_4ASelectRecord ecv_selRec_OrNull,//ｗｈｅｒｅ
            Configuration_Node parent_Cf_Query,//this
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "P5_Select",log_Reports);
            //
            //

            List<List<string>> reslt_sFieldListList = new List<List<string>>();



            //
            // （１）テーブル
            Table_Humaninput o_Table;
            {
                o_Table = this.Owner_MemoryApplication.MemoryTables.GetTable_HumaninputByName(
                    selectSt_ToSave.Expression_From, true, log_Reports);

                if (null == o_Table)
                {
                    // エラー。
                    goto gt_Error_NullTable;
                }
            }
            if (!log_Reports.Successful)
            {
                //
                // エラーが出ていたら、さっさと抜ける。
                goto gt_EndMethod;
            }


            //
            //
            //
            //
            // 条件
            //
            //
            //
            //
            Fielddefinition keyFldDefinition = null;
            string err_SSelectedFldName = null;
            Exception err_Exception = null;
            Recordcondition err_Recordcondition = null;
            foreach (Recordcondition recCond in selectSt_ToSave.List_Recordcondition)
            {
                err_Recordcondition = recCond;

                //
                // （２）検索のキーフィールドの定義を調べます。

                // キーフィールド定義
                {

                    List<string> sList_KeyFldName;
                    {
                        // 要素数１個。
                        sList_KeyFldName = new List<string>();
                        sList_KeyFldName.Add(recCond.Name_Field);
                    }

                    RecordFielddefinition recordFielddefinition;
                    bool bHit = o_Table.TryGetFieldDefinitionByName(
                         out recordFielddefinition,
                        sList_KeyFldName,
                        false,
                        log_Reports
                        );
                    if (!log_Reports.Successful || !bHit)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    keyFldDefinition = recordFielddefinition.ValueAt(0);
                }



                //
                // （３）選択対象のフィールドの定義を調べます。
                RecordFielddefinition recordFieldDefinition_Selected;
                {
                    bool bHit = o_Table.TryGetFieldDefinitionByName(
                        out recordFieldDefinition_Selected,
                        selectSt_ToSave.List_SName_SelectField,
                        true,
                        log_Reports
                        );
                    if (!log_Reports.Successful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }



                //
                // （４）
                if (null == keyFldDefinition)
                {
                    // エラー。
                    goto gt_Error_NullKeyFldDefinition;
                }


                List<string> list_FldImpl3 = new List<string>();

                recordFieldDefinition_Selected.ForEach(delegate(Fielddefinition fielddefinition_Selected,ref bool isBreak2,Log_Reports log_Reports2)
                {
                    string sSelectField = fielddefinition_Selected.Name_Trimupper;

                    //
                    // （５）
                    if (null == fielddefinition_Selected)
                    {
                        // エラー。
                        isBreak2 = true;
                        goto gt_Error_NullSelectedFldDefinition;
                    }

                    //
                    // （６）欠番

                    //
                    // （７）
                    if (null == dst_Rs_toSave || dst_Rs_toSave.List_Field.Count < 1)
                    {
                        bool bExpectedValueRequired;
                        {
                            bool parseSuccessful = bool.TryParse(selectSt_ToSave.Required, out bExpectedValueRequired);
                        }

                        //
                        // 条件
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

                        dst_Rs_toSave.AddList(dst_Row, log_Reports);
                        if (!log_Reports.Successful)
                        {
                            // 既エラー。
                            isBreak2 = true;
                            goto gt_EndInnermethod;
                        }

                        if (null == dst_Rs_toSave)
                        {
                            // （７－２） 

                            isBreak2 = true;
                            goto gt_Error_UndefinedPrimitiveType;
                        }
                    }
                    else
                    {
                        // レコードセットは、一時記憶から取得済み。
                    }


                    // （８）
                    if (log_Reports.Successful)
                    {

                        // キー_フィールドの型別に、処理。
                        switch (keyFldDefinition.Type_Field)
                        {
                            case EnumTypeFielddefinition.String:
                                {
                                    // （８－１）キーが string型フィールドなら

                                    // この行の、選択対象のフィールドの値。

                                    foreach (Dictionary<string, Value_Humaninput> record in dst_Rs_toSave.List_Field)
                                    {
                                        // 値。

                                        Value_Humaninput selectedCellData;
                                        try
                                        {
                                            selectedCellData = (Value_Humaninput)record[sSelectField];
                                        }
                                        catch (KeyNotFoundException ex)
                                        {
                                            selectedCellData = null;
                                            err_SSelectedFldName = sSelectField;
                                            err_Exception = ex;
                                            isBreak2 = true;
                                            goto gt_Error_NotFoundFld;
                                        }

                                        Expression_Node_String ec_SelectedValue = this.GetSelectedFieldValue(
                                            fielddefinition_Selected,
                                            selectedCellData,
                                            parent_Cf_Query,
                                            log_Reports
                                            );

                                        list_FldImpl3.Add(ec_SelectedValue.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                                    }
                                }
                                break;
                            case EnumTypeFielddefinition.Int:
                                {
                                    //
                                    // （８－２） キー・フィールドが int型の場合。

                                    foreach (Dictionary<string, Value_Humaninput> record in dst_Rs_toSave.List_Field)
                                    {
                                        // この行の、選択対象のフィールドの値。

                                        if (null != log_Reports && !log_Reports.Successful)//無限ループ防止
                                        {
                                            // エラー発生時は無視。
                                        }
                                        else
                                        {
                                            Value_Humaninput selectedCellData;
                                            try
                                            {
                                                selectedCellData = record[sSelectField];
                                            }
                                            catch (KeyNotFoundException ex)
                                            {
                                                selectedCellData = null;
                                                err_SSelectedFldName = sSelectField;
                                                err_Exception = ex;
                                                isBreak2 = true;
                                                goto gt_Error_NotFoundFld;
                                            }

                                            {
                                                // 値。
                                                Expression_Node_String ec_SelectedValue = this.GetSelectedFieldValue(
                                                    fielddefinition_Selected,
                                                    selectedCellData,
                                                    parent_Cf_Query,
                                                    log_Reports
                                                    );

                                                list_FldImpl3.Add(ec_SelectedValue.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                                            }
                                        }
                                    }
                                }
                                break;
                            case EnumTypeFielddefinition.Bool:
                                {
                                    // （８－３） キーが、bool型フィールド

                                    // 値。
                                    foreach (Dictionary<string, Value_Humaninput> record in dst_Rs_toSave.List_Field)
                                    {
                                        // この行の、選択対象のフィールドの値。
                                        Value_Humaninput selectedCellData;
                                        try
                                        {
                                            selectedCellData = (Value_Humaninput)record[sSelectField];
                                        }
                                        catch (KeyNotFoundException ex)
                                        {
                                            selectedCellData = null;
                                            err_SSelectedFldName = sSelectField;
                                            err_Exception = ex;
                                            isBreak2 = true;
                                            goto gt_Error_NotFoundFld;
                                        }

                                        Expression_Node_String ec_SelectedValue = this.GetSelectedFieldValue(
                                            fielddefinition_Selected,
                                            selectedCellData,
                                            parent_Cf_Query,
                                            log_Reports
                                            );

                                        list_FldImpl3.Add(ec_SelectedValue.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                                    }
                                }
                                break;
                            default:
                                {
                                    //
                                    // （８－４） 

                                    //
                                    // 既にエラー対策済み。

                                    if (null != log_Reports)//無限ループ防止
                                    {
                                        //
                                        // エラー。
                                        isBreak2 = true;
                                        goto gt_Error_UndefinedPrimitiveType;
                                    }

                                    //
                                    // 非エラー中断。
                                    isBreak2 = true;
                                    goto gt_EndInnermethod;
                                }
                                break;
                        }

                    }

                    goto gt_EndInnermethod;
                //
                    #region 異常系
                //────────────────────────────────────────
                gt_Error_NullSelectedFldDefinition:
                    {
                        Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                        tmpl.SetParameter(1, o_Table.Name, log_Reports);//テーブル名
                        tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(parent_Cf_Query), log_Reports);//設定位置パンくずリスト

                        this.Owner_MemoryApplication.CreateErrorReport("Er:6026;", tmpl, log_Reports);
                    }
                goto gt_EndInnermethod;
                //────────────────────────────────────────
                gt_Error_UndefinedPrimitiveType:
                    {
                        Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                        tmpl.SetParameter(1, keyFldDefinition.ToString_Type(), log_Reports);//キー・フィールド定義型名
                        tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(parent_Cf_Query), log_Reports);//設定位置パンくずリスト

                        this.Owner_MemoryApplication.CreateErrorReport("Er:6027;", tmpl, log_Reports);
                    }
                goto gt_EndInnermethod;
                //────────────────────────────────────────
                gt_Error_NotFoundFld:
                    {
                        Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                        tmpl.SetParameter(1, err_SSelectedFldName, log_Reports);//選択フィールド名
                        tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(parent_Cf_Query), log_Reports);//設定位置パンくずリスト
                        tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Exception(err_Exception), log_Reports);//例外メッセージ

                        this.Owner_MemoryApplication.CreateErrorReport("Er:6028;", tmpl, log_Reports);
                    }
                goto gt_EndInnermethod;
                //────────────────────────────────────────
                    #endregion
                    //
                gt_EndInnermethod:
                    ;
                }, log_Reports);//select列１つ

                if (0 < list_FldImpl3.Count)
                {
                    // フィールドがあれば追加。
                    reslt_sFieldListList.Add(list_FldImpl3);
                }
            }

            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullTable:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();

                this.Owner_MemoryApplication.CreateErrorReport("Er:6024;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullKeyFldDefinition:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configuration(parent_Cf_Query), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6025;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return reslt_sFieldListList;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param oVariableName="selectedFldDefinition"></param>
        /// <param oVariableName="selectedOValue"></param>
        /// <returns></returns>
        private Expression_Node_String GetSelectedFieldValue(
            Fielddefinition selectedFldDefinition,
            Value_Humaninput valueH_Selected,
            Configuration_Node parent_Cf_Select,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "GetSelectedFldValue",log_Reports);
            //
            //


            Expression_Node_String reslt_Expression_SelectedValue;

            switch (selectedFldDefinition.Type_Field)
            {
                case EnumTypeFielddefinition.String:
                    {
                        StringBuilder s = new StringBuilder();
                        s.Append("StringCellDataフィールド[");
                        s.Append(selectedFldDefinition.Name_Humaninput);
                        s.Append("]から取得");

                        string sValue = ((Value_Humaninput)valueH_Selected).Text;
                        Expression_Leaf_String ec_Field = new Expression_Leaf_StringImpl(null, parent_Cf_Select);
                        ec_Field.SetString(sValue, log_Reports);
                        reslt_Expression_SelectedValue = ec_Field;
                    }
                    break;
                case EnumTypeFielddefinition.Int:
                    {
                        StringBuilder s = new StringBuilder();
                        s.Append("IntCellDataフィールド[");
                        s.Append(selectedFldDefinition.Name_Humaninput);
                        s.Append("]から取得");

                        string sValue = ((Value_Humaninput)valueH_Selected).Text;
                        Expression_Leaf_String ec_Field = new Expression_Leaf_StringImpl(null, parent_Cf_Select);
                        ec_Field.SetString(sValue, log_Reports);
                        reslt_Expression_SelectedValue = ec_Field;
                    }
                    break;
                case EnumTypeFielddefinition.Bool:
                    {
                        StringBuilder s = new StringBuilder();
                        s.Append("Value_Humaninput_Boolフィールド[");
                        s.Append(selectedFldDefinition.Name_Humaninput);
                        s.Append("]から取得");

                        string sValue = ((Value_Humaninput)valueH_Selected).Text;
                        Expression_Leaf_String ec_Field = new Expression_Leaf_StringImpl(null, parent_Cf_Select);
                        ec_Field.SetString(sValue, log_Reports);
                        reslt_Expression_SelectedValue = ec_Field;
                    }
                    break;
                default:
                    {
                        reslt_Expression_SelectedValue = null;
                        goto gt_Error_NotSupportedType;
                    }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSupportedType:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, selectedFldDefinition.ToString_Type(), log_Reports);//選択したフィールド定義の型名

                this.Owner_MemoryApplication.CreateErrorReport("Er:6029;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return reslt_Expression_SelectedValue;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// いろいろなエディターに変形するアプリケーションのモデルです。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            set
            {
                owner_MemoryApplication = value;
            }
            get
            {
                return owner_MemoryApplication;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
