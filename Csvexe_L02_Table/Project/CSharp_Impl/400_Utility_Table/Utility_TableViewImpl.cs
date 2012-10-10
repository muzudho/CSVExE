using System;
using System.Collections.Generic;
using System.Data;//DataTable
using System.Linq;
using System.Text;
using System.Windows.Forms;//ListView

using Xenon.Syntax;//WarningReports

namespace Xenon.Table
{
    /// <summary>
    /// テーブル・ビュー・ユーティリティー。
    /// </summary>
    public class Utility_TableviewImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// リスト・ビュー1の内容を、リスト・ビュー2へ、コピーします。
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="listView"></param>
        public void CopyTo(ListView listView1, ListView listView2, out string sMessage_Error)
        {
            // リスト・ビュー2を空にします。
            listView2.Clear();

            // 編集テーブルを、並び順変更先テーブルにコピーします。
            foreach (ColumnHeader columnHeader in listView1.Columns)
            {
                listView2.Columns.Add(columnHeader.Text);
            }

            foreach (ListViewItem listViewItem in listView1.Items)
            {
                // [0]列目を初期値として設定します。
                ListViewItem newItem = new ListViewItem(listViewItem.Text);

                // 最初の[0]列目は既に追加済みなので、[1]列目以降から追加します。
                for (int nIndex = 1; nIndex < listViewItem.SubItems.Count; nIndex++)
                {
                    newItem.SubItems.Add(listViewItem.SubItems[nIndex]);
                }
                listView2.Items.Add(newItem);
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            sMessage_Error = "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// リスト・ビューに、テーブルをセットします。
        /// </summary>
        public void SetDataSourceToListView(TableHumaninput xenonTable, ListView listView, out string sMessage_Error)
        {
            DataTable dataTable = xenonTable.DataTable;

            listView.Clear();

            // リスト・ビューにフィールドを追加します。
            foreach (FielddefinitionImpl fieldDefinition in xenonTable.List_Fielddefinition)
            {
                // 列を追加します。見出しと幅も設定します。
                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append(fieldDefinition.Name_Humaninput);

                if (this.BVisibled_Fieldtype)
                {
                    // デバッグ用に、フィールドの型もヘッダーに表示する場合。
                    t.Append(":");
                    t.Append(fieldDefinition.Type.Name);
                }

                listView.Columns.Add(t.ToString(), 90);
            }


            for (int nIndex_Row = 0; nIndex_Row < dataTable.Rows.Count; nIndex_Row++)
            {
                DataRow row = dataTable.Rows[nIndex_Row];

                ListViewItem item = null;

                object[] recordFields = row.ItemArray;//ItemArrayは1回の呼び出しが重い。
                for (int nColumnIndex = 0; nColumnIndex < recordFields.Length; nColumnIndex++)
                {
                    object columnObject = recordFields[nColumnIndex];

                    if (columnObject is ValueHumaninput)
                    {
                        ValueHumaninput cellData = (ValueHumaninput)columnObject;

                        string sFieldValue = cellData.Humaninput;

                        // レコードを作成します。
                        if (0 == nColumnIndex)
                        {
                            // 最初の列の場合は、行追加になります。

                            // 文字列を追加。
                            item = new ListViewItem(sFieldValue);
                            listView.Items.Add(item);
                        }
                        else
                        {
                            // 最初の列より後ろは、列追加になります。

                            // 文字列を追加。
                            item.SubItems.Add(sFieldValue);
                        }
                    }
                    else if (columnObject is DBNull)
                    {
                        // 空欄、または列データを未設定。
                        goto gt_Error_DBNull;
                    }
                    else
                    {
                        //エラー
                        goto gt_Error_UnknownType;
                    }


                }
            }

            sMessage_Error = "";
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_DBNull:
            {
                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("▲エラー201！(" + Info_Table.Name_Library + ")");
                t.Newline();
                t.Append("列が未設定（DBNull）。テーブル名=[" + xenonTable.Name + "]");
                sMessage_Error = t.ToString();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UnknownType:
            {
                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("▲エラー291！(" + Info_Table.Name_Library + ")");
                t.Newline();
                t.Append("未定義の型の列。テーブル名=[" + xenonTable.Name + "]");
                sMessage_Error = t.ToString();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            return;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private bool bVisibled_Fieldtype;

        /// <summary>
        /// デバッグ用に、フィールドの型もヘッダーに表示するなら真。
        /// </summary>
        public bool BVisibled_Fieldtype
        {
            set
            {
                bVisibled_Fieldtype = value;
            }
            get
            {
                return bVisibled_Fieldtype;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
