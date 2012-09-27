﻿using System;
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
            Givechapterandverse_Node parent_Cf_Query,//this
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.SName_Library, this, "P5_Select",log_Reports);
            //
            //

            List<List<string>> reslt_sFieldListList = new List<List<string>>();



            //
            // （１）テーブル
            XenonTable o_Table;
            {
                o_Table = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(selectSt_ToSave.Expression_From, true, log_Reports);

                if (null == o_Table)
                {
                    // エラー。
                    goto gt_Error_NullTable;
                }
            }
            if (!log_Reports.BSuccessful)
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
            XenonFielddefinition keyFldDefinition = null;
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
                        sList_KeyFldName.Add(recCond.SField);
                    }

                    List<XenonFielddefinition> oList_keyFldDefinition;
                    bool bHit = o_Table.TryGetFieldDefinitionByName(
                         out oList_keyFldDefinition,
                        sList_KeyFldName,
                        false,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful || !bHit)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    keyFldDefinition = oList_keyFldDefinition[0];
                }



                //
                // （３）選択対象のフィールドの定義を調べます。
                List<XenonFielddefinition> list_SelectedFldDefinition;
                {
                    bool bHit = o_Table.TryGetFieldDefinitionByName(
                        out list_SelectedFldDefinition,
                        selectSt_ToSave.List_SName_SelectField,
                        true,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
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

                foreach (XenonFielddefinition selectedFldDef in list_SelectedFldDefinition)
                {
                    string sSelectField = selectedFldDef.SName_Trimupper;

                    //
                    // （５）
                    if (null == selectedFldDef)
                    {
                        // エラー。
                        goto gt_Error_NullSelectedFldDefinition;
                    }

                    //
                    // （６）欠番

                    //
                    // （７）
                    //if (null == p3_Selectstatement.RecordList || p3_Selectstatement.RecordList.Count < 1)
                    if (null == dst_Rs_toSave || dst_Rs_toSave.List_Field.Count < 1)
                    {
                        {
                            //// テーブル名。
                            //if ("" == selectSt.Expression_From.E_Execute(log_Reports).Trim())
                            //{
                            //    //
                            //    // エラー。
                            //    goto gt_Error_EmptyTableName;
                            //}

                            //XenonTable o_Table = this.MoOpyopyo.MemoryTables.GetXenonTableByName(selectSt.Expression_From, true, log_Reports);

                            //if (null == o_Table)
                            //{
                            //    goto gt_Error_NullTable;
                            //}



                            bool bExpectedValueRequired;
                            {
                                bool parseSuccessful = bool.TryParse(selectSt_ToSave.SRequired, out bExpectedValueRequired);
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
                                selectSt_ToSave.List_Recordcondition,
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
                                parent_Cf_Query,
                                log_Reports
                                );



                            dst_Rs_toSave.AddList(dst_Row, log_Reports);
                            if (!log_Reports.BSuccessful)
                            {
                                // 既エラー。
                                goto gt_EndMethod;
                            }
                        }


                        if (null == dst_Rs_toSave)
                        {
                            //
                            // （７－２） 

                            //if (null != log_Reports)//無限ループ防止
                            //{
                            //
                            // エラー。
                            goto gt_Error_UndefinedPrimitiveType;
                            //}

                            ////
                            //// 非エラー中断。
                            //goto gt_EndMethod;
                        }

                        //ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#P5_Select: ＜f-cell選択（３７１）＞　RecordSet_toSave .O_Items.Count＝[" + RecordSet_toSave.O_Items.Count + "]");

                        //P4_RecordSetSaverImpl sel4 = new P4_RecordSetSaverImpl(moOpyopyo);
                        //sel4.P4_Save(
                        //    RecordSet_toSave,
                        //    RecordSetSaveTo_or_null,
                        //    log_Reports
                        //    );

                    }
                    else
                    {
                        // レコードセットは、一時記憶から取得済み。
                        //ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#P5_Select: ＜f-cell選択（３７５）＞　【レコードセットは、一時記憶から取得済み】");
                    }


                    //
                    // （８）
                    if (log_Reports.BSuccessful)
                    {
                        //// debug:
                        //if (false)
                        //{
                        //    ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#P5_Select: ＜f-cell選択（３８０）＞　selectedFldNameStr＝[" + selectedFldNameStr + "]　RecordSet_toSave.O_Items.Count＝[" + RecordSet_toSave.O_Items.Count + "]");
                        //}

                        //
                        // キー_フィールドの型別に、処理。
                        //
                        if (keyFldDefinition.Type == typeof(XenonValue_StringImpl))
                        {
                            //
                            // （８－１）キーが string型フィールドなら

                            // この行の、選択対象のフィールドの値。

                            foreach (Dictionary<string, XenonValue> record in dst_Rs_toSave.List_Field)
                            {
                                //
                                // 値。

                                XenonValue selectedCellData;
                                try
                                {
                                    selectedCellData = (XenonValue)record[sSelectField];
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    selectedCellData = null;
                                    err_SSelectedFldName = sSelectField;
                                    err_Exception = ex;
                                    goto gt_Error_NotFoundFld;
                                }

                                Expression_Node_String ec_SelectedValue = this.GetSelectedFieldValue(
                                    selectedFldDef,
                                    selectedCellData,
                                    parent_Cf_Query,
                                    log_Reports
                                    );

                                //TODO:e_SelectedValue.SetValidation(...);
                                list_FldImpl3.Add(ec_SelectedValue.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                            }

                        }
                        else if (keyFldDefinition.Type == typeof(XenonValue_IntImpl))
                        {
                            //
                            // （８－２） キー・フィールドが int型の場合。

                            foreach (Dictionary<string, XenonValue> record in dst_Rs_toSave.List_Field)
                            {
                                // この行の、選択対象のフィールドの値。

                                if (null != log_Reports && !log_Reports.BSuccessful)//無限ループ防止
                                {
                                    //
                                    // エラー発生時は無視。
                                    //
                                }
                                else
                                {
                                    XenonValue selectedCellData;
                                    try
                                    {
                                        selectedCellData = record[sSelectField];
                                    }
                                    catch (KeyNotFoundException ex)
                                    {
                                        selectedCellData = null;
                                        err_SSelectedFldName = sSelectField;
                                        err_Exception = ex;
                                        goto gt_Error_NotFoundFld;
                                    }

                                    {
                                        //ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#P5_Select: ＜f-cell選択（８－２b）＞");

                                        // 値。
                                        Expression_Node_String ec_SelectedValue = this.GetSelectedFieldValue(
                                            selectedFldDef,
                                            selectedCellData,
                                            parent_Cf_Query,
                                            log_Reports
                                            );

                                        //TODO:e_SelectedValue.SetValidation(...);
                                        list_FldImpl3.Add(ec_SelectedValue.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                                    }
                                }
                            }

                        }
                        else if (keyFldDefinition.Type == typeof(XenonValue_BoolImpl))
                        {
                            //
                            // （８－３） キーが、bool型フィールド

                            //
                            // 値。
                            foreach (Dictionary<string, XenonValue> record in dst_Rs_toSave.List_Field)
                            {

                                // この行の、選択対象のフィールドの値。
                                XenonValue selectedCellData;
                                try
                                {
                                    selectedCellData = (XenonValue)record[sSelectField];
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    selectedCellData = null;
                                    err_SSelectedFldName = sSelectField;
                                    err_Exception = ex;
                                    goto gt_Error_NotFoundFld;
                                }

                                Expression_Node_String ec_SelectedValue = this.GetSelectedFieldValue(
                                    selectedFldDef,
                                    selectedCellData,
                                    parent_Cf_Query,
                                    log_Reports
                                    );

                                //TODO:e_SelectedValue.SetValidation(...);
                                list_FldImpl3.Add(ec_SelectedValue.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                                //                                fldListImpl3.Add(e_SelectedValue);
                            }


                        }
                        else
                        {
                            //
                            // （８－４） 

                            //
                            // 既にエラー対策済み。

                            if (null != log_Reports)//無限ループ防止
                            {
                                //
                                // エラー。
                                goto gt_Error_UndefinedPrimitiveType;
                            }

                            //
                            // 非エラー中断。
                            goto gt_EndMethod;
                        }

                    }

                }//select列１つ

                if (0 < list_FldImpl3.Count)
                {
                    // フィールドがあれば追加。
                    reslt_sFieldListList.Add(list_FldImpl3);
                }


            }



            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullTable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー301！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("ヌル＝oTable");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullKeyFldDefinition:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー133！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("ヌル＝keyFldDefinition");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(parent_Cf_Query));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullSelectedFldDefinition:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー134！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("ヌル＝selectedFldDefinition");
                t.Append(Environment.NewLine);

                t.Append("　refTable.Name=[");
                t.Append(o_Table.SName);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(parent_Cf_Query));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedPrimitiveType:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー135！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("プログラムに無い型です。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("　keyFldDefinition.Type=[");
                t.Append(keyFldDefinition.Type);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(parent_Cf_Query));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotFoundFld:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー136！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("指定されたフィールドは、テーブルにありませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("　err_SSelectedFldName=[");
                t.Append(err_SSelectedFldName);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(parent_Cf_Query));
                t.Append(r.Message_SException(err_Exception));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
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
            XenonFielddefinition selectedFldDefinition,
            XenonValue selectedOValue,
            Givechapterandverse_Node parent_Cf_Select,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.SName_Library, this, "GetSelectedFldValue",log_Reports);
            //
            //


            Expression_Node_String reslt_Expression_SelectedValue;
            if (selectedFldDefinition.Type == typeof(XenonValue_IntImpl))
            {
                StringBuilder s = new StringBuilder();
                s.Append("IntCellDataフィールド[");
                s.Append(selectedFldDefinition.SName_Humaninput);
                s.Append("]から取得");

                string sValue = XenonValue_IntImpl.ParseString(selectedOValue);
                Expression_Leaf_String ec_Field = new Expression_Leaf_StringImpl(null, parent_Cf_Select);
                ec_Field.SetString(sValue, log_Reports);
                reslt_Expression_SelectedValue = ec_Field;
            }
            else if (selectedFldDefinition.Type == typeof(XenonValue_StringImpl))
            {
                StringBuilder s = new StringBuilder();
                s.Append("StringCellDataフィールド[");
                s.Append(selectedFldDefinition.SName_Humaninput);
                s.Append("]から取得");

                string sValue = XenonValue_StringImpl.ParseString(selectedOValue);
                Expression_Leaf_String ec_Field = new Expression_Leaf_StringImpl(null, parent_Cf_Select);
                ec_Field.SetString(sValue, log_Reports);
                reslt_Expression_SelectedValue = ec_Field;
            }
            else if (selectedFldDefinition.Type == typeof(XenonValue_BoolImpl))
            {
                StringBuilder s = new StringBuilder();
                s.Append("XenonValue_Boolフィールド[");
                s.Append(selectedFldDefinition.SName_Humaninput);
                s.Append("]から取得");

                string sValue = XenonValue_BoolImpl.ParseString(selectedOValue);
                Expression_Leaf_String ec_Field = new Expression_Leaf_StringImpl(null, parent_Cf_Select);
                ec_Field.SetString(sValue, log_Reports);
                reslt_Expression_SelectedValue = ec_Field;
            }
            else
            {
                reslt_Expression_SelectedValue = null;
                goto gt_Error_NotSupportedType;
                //throw new System.ApplicationException();
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotSupportedType:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー598！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("▲エラー5098！ 予期しない型です。selectedFldDefinition.Type=[" );
                s.Append(selectedFldDefinition.Type);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
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