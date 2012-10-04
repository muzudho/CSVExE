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
            XenonFielddefinition selFldDefinition,//選択したフィールド定義
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

            // 紛らわしいですが、.GetType() と .Type は別物です。
            if (selFldDefinition.Type == typeof(XenonValue_StringImpl))
            {
                //row[this.SelectedFldName] = outputValueStr;



                // 空欄も自動処理
                XenonValue_StringImpl cellData = new XenonValue_StringImpl(sConfigStack_StringOfCell);
                cellData.Humaninput = sValue_Output;


                row[sName_SelectedFld] = cellData;
            }
            else if (selFldDefinition.Type == typeof(XenonValue_IntImpl))
            {
                // 空欄も自動処理
                XenonValue_IntImpl cellData = new XenonValue_IntImpl(sConfigStack_StringOfCell);
                cellData.Humaninput = sValue_Output;
                row[sName_SelectedFld] = cellData;
            }
            else if (selFldDefinition.Type == typeof(XenonValue_BoolImpl))
            {
                // 空欄も自動処理
                XenonValue_BoolImpl cellData = new XenonValue_BoolImpl(sConfigStack_StringOfCell);
                cellData.Humaninput = sValue_Output;
                row[sName_SelectedFld] = cellData;

                //if ("" == outputValueStr.Trim())
                //{
                //    // 空欄なら
                //    row[this.SelectedFldName] = CellDataTarget.ALT_EMPTY_INT;// TODO int型のフィールドに空欄を入れるには？
                //}
                //else
                //{
                //    try
                //    {
                //        row[this.SelectedFldName] = outputValueStr;
                //    }
                //    catch (ArgumentException)
                //    {
                //        // 数値型のフィールドに文字を入れようとしたときなど。

                //        // エラー中断。
                //        WarningReport dr = new WarningReport();
                //        dr.STitle = "▲エラー1213！（"+Info_Forms.LibraryName+"）";
                //        dr.Message = "数値型のフィールドに文字[" + outputValueStr + "]を入れようとしました。";
                //        log_Reports.Add(dr);
                //        return;
                //    }
                //}
            }
            else
            {
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー398！", pg_Method);

                    StringBuilder t = new StringBuilder();

                    t.Append("予期しない、フィールドの型です。");
                    t.Append(Environment.NewLine);
                    t.Append("selFldDefinition.Type=[");
                    t.Append(selFldDefinition.Type);
                    t.Append("]");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);

                    // ヒント
                    t.Append(r.Message_Configurationtree(ec_Fcell.Cur_Configurationtree));

                    r.Message = t.ToString();
                    log_Reports.EndCreateReport();
                }
            }


            //
            //
            //
            //
            pg_Method.EndMethod(log_Reports);

            //essageBox.Show("アップデートデータ【終了】 outputValueStr=[" + outputValueStr + "]", "(FormsImpl)" + this.GetType().NFcName + "#:");
            //.WriteLine(this.GetType().NFcName + "#: 【終了】アップデート完了。");
        }

        //────────────────────────────────────────
        #endregion



    }
}
