using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Table;//DefaultTable

namespace Xenon.TablePermutation
{
    /// <summary>
    /// ■使用方法
    /// 
    /// TablePermutationForm tablePermutationForm = new TablePermutationForm();
    /// 
    /// DefaultTable regionTable = this.MonsterRegionEditorModel.OpyopyoModel.GetTableById("RegionTable",true);
    /// tablePermutationForm.SetDataSource(regionTable, pg_Logging);
    ///
    /// // モーダル・ダイアログボックスとしてフォームを開きます。
    /// tablePermutationForm.ShowDialog(this);
    /// </summary>
    public partial class TablePermutationForm : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public TablePermutationForm()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void SetDataSource(XenonTable o_Table, Log_Reports pg_Logging)
        {
            string sErrorMsg;
            this.xenonTable = o_Table;

            Utility_TableviewImpl u_tblView = new Utility_TableviewImpl();
            u_tblView.BVisibled_Fieldtype = true;

            u_tblView.SetDataSourceToListView(
                o_Table, this.listView1, out sErrorMsg);
            if ("" != sErrorMsg)
            {
                // 既エラー。
                if (pg_Logging.CanCreateReport)
                {
                    Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                    r.Message = sErrorMsg;
                    pg_Logging.EndCreateReport();
                }
                goto gt_EndMethod;
            }

            u_tblView.CopyTo(this.listView1, this.listView2, out sErrorMsg);
            if ("" != sErrorMsg)
            {
                // 既エラー。
                if (pg_Logging.CanCreateReport)
                {
                    Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                    r.Message = sErrorMsg;
                    pg_Logging.EndCreateReport();
                }
                goto gt_EndMethod;
            }

            //
        //
        //
        //
        gt_EndMethod:
            return;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// [終了]ボタン。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitsButton_Click(object sender, EventArgs e)
        {
            // 自フォームを閉じます。
            this.Close();

            // 自分を破棄します。（モーダル・ダイアログボックスとして開かれた場合を想定）
            this.Dispose();
        }

        //────────────────────────────────────────

        /// <summary>
        /// [移動を実行]ボタン。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recordMovesButton_Click(object sender, EventArgs e)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports d_Logging_Event = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_TablePermutation.SName_Library, this, "recordMovesButton_Click",d_Logging_Event);
            //
            //

            if (null == this.xenonTable)
            {
                goto gt_Error_NullTable;
            }

            bool b_OldEnabled_1;
            bool b_OldEnabled_2;
            if (d_Logging_Event.Successful)
            {
                // 正常時

                b_OldEnabled_1 = this.listView1.Enabled;
                this.listView1.Enabled = false;

                b_OldEnabled_2 = this.listView2.Enabled;
                this.listView2.Enabled = false;


                int[] sourceIndices = new int[this.listView1.SelectedIndices.Count];
                this.listView1.SelectedIndices.CopyTo(sourceIndices, 0);


                int nDestinationIndex = -1;
                foreach (int nSelectedIndex in this.listView2.SelectedIndices)
                {
                    nDestinationIndex = nSelectedIndex;

                    break;
                }


                this.xenonTable.MoveItemsBefore(sourceIndices, nDestinationIndex);


                // データ・テーブルをもとに、リストビューを準備します。
                this.SetDataSource(this.xenonTable, d_Logging_Event);
            }
            else
            {
                // エラー終了処理

                b_OldEnabled_1 = false;
                b_OldEnabled_2 = false;
            }

            if (d_Logging_Event.Successful)
            {
                // 正常時

                // リストビューを更新。
                this.listView1.Refresh();
                this.listView2.Refresh();

                this.listView1.Enabled = b_OldEnabled_1;
                this.listView2.Enabled = b_OldEnabled_2;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullTable:
            if (d_Logging_Event.CanCreateReport)
            {
                Log_RecordReport r = d_Logging_Event.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー204！", pg_Method);
                r.Message = "データソースとなるテーブルが未設定（ヌル）です。";
                d_Logging_Event.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(d_Logging_Event);
            d_Logging_Event.EndLogging(pg_Method);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// データソースとなるテーブル。
        /// </summary>
        private XenonTable xenonTable;

        //────────────────────────────────────────
        #endregion



    }
}
