using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Middle;//CellUpdater
using Xenon.Table;//DefaultTable

namespace Xenon.Controls
{

    /// <summary>
    /// </summary>
    public class ToMemory_CellImpl : ToMemory_Cell
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 選択されているセルに、指定の値を上書きします。
        /// </summary>
        /// <param nFcName="outputValueStr"></param>
        /// <param nFcName="row"></param>
        /// <param nFcName="selFldDefinition">選択フィールド</param>
        /// <param nFcName="log_Reports"></param>
        public void ToMemory_ToSelectedField(
            string sValue_Output,
            Expression_Node_String ec_Fcell,
            DataRow row,
            Fielddefinition selFldDefinition,//選択したフィールド定義
            Log_Reports log_Reports
            )
        {
            //essageBox.Show("アップデートデータ【開始】 outputValueStr=[" + outputValueStr + "]\n", "(FormsImpl)" + this.GetType().NFcName );

            //.WriteLine(this.GetType().NFcName + "#: 【開始】データのアップデートを始める。");

            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "ToM_ToSelectedField",log_Reports);
            //
            //

            string sName_SelectedFld;
            {
                bool bHit = ec_Fcell.TrySelectAttribute(
                    out sName_SelectedFld,
                    PmNames.S_SELECT.Name_Pm,
                    EnumHitcount.One,
                    log_Reports
                    );
            }

            string sConfigStack_StringOfCell = sName_SelectedFld;

            switch (selFldDefinition.Type_Field)
            {
                case EnumTypeFielddefinition.String:
                    {
                        // 空欄も自動処理
                        String_HumaninputImpl cellData = new String_HumaninputImpl(sConfigStack_StringOfCell);
                        cellData.Text = sValue_Output;

                        row[sName_SelectedFld] = cellData;
                    }
                    break;
                case EnumTypeFielddefinition.Int:
                    {
                        // 空欄も自動処理
                        Int_HumaninputImpl cellData = new Int_HumaninputImpl(sConfigStack_StringOfCell);
                        cellData.Text = sValue_Output;
                        row[sName_SelectedFld] = cellData;
                    }
                    break;
                case EnumTypeFielddefinition.Bool:
                    {
                        // 空欄も自動処理
                        Bool_HumaninputImpl cellData = new Bool_HumaninputImpl(sConfigStack_StringOfCell);
                        cellData.Text = sValue_Output;
                        row[sName_SelectedFld] = cellData;
                    }
                    break;
                default:
                    {
                        if (log_Reports.CanCreateReport)
                        {
                            Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                            r.SetTitle("▲エラー398！", pg_Method);

                            StringBuilder t = new StringBuilder();

                            t.Append("予期しない、フィールドの型です。");
                            t.Append(Environment.NewLine);
                            t.Append("selFldDefinition.Type=[");
                            t.Append(selFldDefinition.ToString_Type());
                            t.Append("]");
                            t.Append(Environment.NewLine);
                            t.Append(Environment.NewLine);

                            // ヒント
                            t.Append(r.Message_Configuration(
                                ec_Fcell.Cur_Configuration));

                            r.Message = t.ToString();
                            log_Reports.EndCreateReport();
                        }
                    }
                    break;
            }

            //
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
