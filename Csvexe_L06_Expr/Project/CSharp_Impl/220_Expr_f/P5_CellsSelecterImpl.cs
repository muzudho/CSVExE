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
            Configurationtree_Node parent_Cf_Query,//this
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
            XenonTable o_Table;
            {
                o_Table = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(selectSt_ToSave.Expression_From, true, log_Reports);

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
                        sList_KeyFldName.Add(recCond.Name_Field);
                    }

                    List<XenonFielddefinition> oList_keyFldDefinition;
                    bool bHit = o_Table.TryGetFieldDefinitionByName(
                         out oList_keyFldDefinition,
                        sList_KeyFldName,
                        false,
                        log_Reports
                        );
                    if (!log_Reports.Successful || !bHit)
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

                foreach (XenonFielddefinition selectedFldDef in list_SelectedFldDefinition)
                {
                    string sSelectField = selectedFldDef.Name_Trimupper;

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
                                bool parseSuccessful = bool.TryParse(selectSt_ToSave.Required, out bExpectedValueRequired);
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
                            if (!log_Reports.Successful)
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
                    if (log_Reports.Successful)
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

                                if (null != log_Reports && !log_Reports.Successful)//無限ループ防止
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();

                this.Owner_MemoryApplication.CreateErrorReport("Er:6024;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullKeyFldDefinition:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_Report01Impl.ToMessage_Configurationtree(parent_Cf_Query), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6025;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullSelectedFldDefinition:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, o_Table.Name, log_Reports);//テーブル名
                tmpl.SetParameter(2, Log_Report01Impl.ToMessage_Configurationtree(parent_Cf_Query), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6026;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedPrimitiveType:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, keyFldDefinition.Type.ToString(), log_Reports);//キー・フィールド定義型名
                tmpl.SetParameter(2, Log_Report01Impl.ToMessage_Configurationtree(parent_Cf_Query), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6027;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotFoundFld:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_SSelectedFldName, log_Reports);//選択フィールド名
                tmpl.SetParameter(2, Log_Report01Impl.ToMessage_Configurationtree(parent_Cf_Query), log_Reports);//設定位置パンくずリスト
                tmpl.SetParameter(3, Log_Report01Impl.ToMessage_Exception(err_Exception), log_Reports);//例外メッセージ

                this.Owner_MemoryApplication.CreateErrorReport("Er:6028;", tmpl, log_Reports);
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
            Configurationtree_Node parent_Cf_Select,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "GetSelectedFldValue",log_Reports);
            //
            //


            Expression_Node_String reslt_Expression_SelectedValue;
            if (selectedFldDefinition.Type == typeof(XenonValue_IntImpl))
            {
                StringBuilder s = new StringBuilder();
                s.Append("IntCellDataフィールド[");
                s.Append(selectedFldDefinition.Name_Humaninput);
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
                s.Append(selectedFldDefinition.Name_Humaninput);
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
                s.Append(selectedFldDefinition.Name_Humaninput);
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, selectedFldDefinition.GetTypeString(), log_Reports);//選択したフィールド定義の型名

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
