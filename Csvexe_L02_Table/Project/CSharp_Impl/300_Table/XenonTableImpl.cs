using System;
using System.Data;//DataTable,DataRow
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//ManualFilePath,WarningReports


namespace Xenon.Table
{
    /// <summary>
    /// フィールドの型定義と、0～複数件レコードを持ったテーブルです。
    /// 
    /// 他のテーブル・クラスと名称の被りを防ぐために前置詞が付いています。
    /// </summary>
    public class XenonTableImpl : Configurationtree_NodeImpl, XenonTable
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="e_Fpath_ConfigStack"></param>
        public XenonTableImpl(string name_Table, Expression_Node_Filepath ec_Fpath_ConfigStack)
            : base("ノード名未指定", ec_Fpath_ConfigStack.Cur_Configurationtree)
        {
            this.expression_Filepath_ConfigStack = ec_Fpath_ConfigStack;

            this.dataTable = new DataTable();
            this.name_Table = name_Table;
            this.xenonTableFormat = new XenonTableformatImpl();
            this.listO_FieldDefinition = new List<XenonFielddefinition>();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 設定された型リストで、テーブルの構造を作成します。
        /// </summary>
        public void CreateTable(List<XenonFielddefinition> oList_NewFldDef, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.Name_Library, this, "CreateTable",log_Reports);

            //
            //
            //
            //

            this.dataTable.Clear();
            this.listO_FieldDefinition = oList_NewFldDef;

            Exception err_E;
            foreach (XenonFielddefinitionImpl o_FldDef in oList_NewFldDef)
            {
                // 列の型を決めます。
                try
                {
                    this.dataTable.Columns.Add(o_FldDef.Name_Trimupper, o_FldDef.Type);
                }
                catch (DuplicateNameException e)
                {
                    err_E = e;
                    goto gt_Error_Duplicated;
                }
            }


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Duplicated:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー111！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("列の名前が重複しています。");
                s.Append(err_E.Message);
                s.Append(Environment.NewLine);
                s.Append("テーブル名＝[");
                s.Append(this.dataTable.TableName);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public override void ToText_Content(Log_TextIndented s)
        {
            s.Increment();


            s.AppendI(0, "<OTableImplクラス>");
            s.Append(Environment.NewLine);

            this.Expression_Filepath_ConfigStack.Cur_Configurationtree.ToText_Content(s);

            s.AppendI(0, "</OTableImplクラス>");
            s.Append(Environment.NewLine);


            s.Decrement();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 行を追加します。
        /// </summary>
        /// <param name="record"></param>
        public void AddRecord(DataRow dataRow)
        {
            this.DataTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// 空行を作成します。
        /// </summary>
        /// <returns></returns>
        public DataRow CreateNewRecord(out string sErrorMsg)
        {

            // 新しいレコードを1つ作ります。
            DataRow newDataRow = this.DataTable.NewRow();
            // 全ての列は現在、DBNullになっています。

            // ひとまず、全ての列に有効なインスタンスを設定します。

            int nColumnIndex = 0;
            sErrorMsg = "";
            foreach (XenonFielddefinitionImpl o_FldDef in this.List_Fielddefinition)
            {
                // 列の型を調べます。

                //
                //
                // セルのソースヒント名
                //
                string sSourceHintNameOfCell;
                if ("" == o_FldDef.Name_Trimupper)
                {
                    // 名無しフィールド

                    // フィールド名がないので、インデックスで指定します。
                    Log_TextIndented t = new Log_TextIndentedImpl();
                    t.Append("(");
                    t.Append(nColumnIndex);
                    t.Append(")番フィールド");
                    sSourceHintNameOfCell = t.ToString();
                }
                else
                {
                    sSourceHintNameOfCell = o_FldDef.Name_Humaninput;
                }

                if (o_FldDef.Type == typeof(XenonValue_StringImpl))
                {

                    XenonValue_StringImpl stringCellData = new XenonValue_StringImpl(sSourceHintNameOfCell);
                    stringCellData.Humaninput = "";

                    if ("" == o_FldDef.Name_Trimupper)
                    {
                        // 名無しフィールド
                        // フィールド名がないので、インデックスで指定します。
                        newDataRow[nColumnIndex] = stringCellData;
                    }
                    else
                    {
                        newDataRow[o_FldDef.Name_Trimupper] = stringCellData;
                    }
                }
                else if (o_FldDef.Type == typeof(XenonValue_IntImpl))
                {
                    XenonValue_IntImpl intCellData = new XenonValue_IntImpl(sSourceHintNameOfCell);
                    intCellData.Humaninput = "";

                    if ("" == o_FldDef.Name_Trimupper)
                    {
                        // 名無しフィールド
                        // フィールド名がないので、インデックスで指定します。
                        newDataRow[nColumnIndex] = intCellData;
                    }
                    else
                    {
                        newDataRow[o_FldDef.Name_Trimupper] = intCellData;
                    }
                }
                else if (o_FldDef.Type == typeof(XenonValue_BoolImpl))
                {
                    XenonValue_BoolImpl boolCellData = new XenonValue_BoolImpl(sSourceHintNameOfCell);
                    boolCellData.Humaninput = "";

                    if ("" == o_FldDef.Name_Trimupper)
                    {
                        // 名無しフィールド
                        // フィールド名がないので、インデックスで指定します。
                        newDataRow[nColumnIndex] = boolCellData;
                    }
                    else
                    {
                        newDataRow[o_FldDef.Name_Trimupper] = boolCellData;
                    }
                }
                else
                {
                    Log_TextIndented t = new Log_TextIndentedImpl();
                    t.Append("▲エラー431！(" + Info_Table.Name_Library + ")");
                    t.Newline();
                    t.Append("この列は、未定義の型です。[" + o_FldDef.Type.Name + "]");
                    sErrorMsg = t.ToString();

                    // 文字列型を入れる。
                    XenonValue_StringImpl stringCellData = new XenonValue_StringImpl(sSourceHintNameOfCell);
                    stringCellData.Humaninput = "";

                    if ("" == o_FldDef.Name_Trimupper)
                    {
                        // 名無しフィールド
                        // フィールド名がないので、インデックスで指定します。
                        newDataRow[nColumnIndex] = stringCellData;
                    }
                    else
                    {
                        newDataRow[o_FldDef.Name_Trimupper] = stringCellData;
                    }
                }

                nColumnIndex++;
            }

            goto gt_EndMethod;

            //
        //
        //
        //
        gt_EndMethod:
            return newDataRow;
        }

        /// <summary>
        /// データを渡すことで、テーブルを作成します。
        /// テーブルの型定義と、データを渡します。
        /// 
        /// TODO:データテーブルによって新行を作成するので、データテーブルの列定義と、列定義リストは合わせて置かなければならない。
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="fldDefList">列定義は絞りこまれている場合もあります。</param>
        /// <param name="d_Logging_OrNull"></param>
        public void AddRecordList(
            List<List<string>> rows, List<XenonFielddefinition> oList_fldDef, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.Name_Library, this, "AddRecordList",log_Reports);

            //
            //
            //
            //

            string err_SColumnName_TrimUpper;
            Exception err_Excep;
            DataRow err_DataRow;
            List<string> err_SList_Column;
            int err_NCIx;

            // テーブルデータを作成します。
            // rowIndex
            for (int nRIx = 0; nRIx < rows.Count; nRIx++)
            {
                List<string> sList_Column = rows[nRIx];

                // 行オブジェクトを作成。
                DataRow dataRow = this.dataTable.NewRow();

                // TODO:これで合ってる？　入力テーブルの行数と、列定義の列数、小さい方に合わせます。（2012-02-11/仕様変更）
                int nEndover;
                if (sList_Column.Count < oList_fldDef.Count)
                {
                    nEndover = sList_Column.Count;
                }
                else
                {
                    nEndover = oList_fldDef.Count;
                }

                // 行の列数ではなく、列定義の列数でループを回します。
                // 絞りこまれていることがあるからです。
                //
                // columnIndex
                for (int nCIx = 0; nCIx < nEndover; nCIx++)
                //for (int nCIx = 0; nCIx < o_fldDefList.Count; nCIx++)
                //for (int nCIx = 0; nCIx < sRow.Count; nCIx++)
                {
                    // 引き渡されたデータを、行オブジェクトにセット
                    string sColumnName_TrimUpper = oList_fldDef[nCIx].Name_Trimupper;
                    if ("" == sColumnName_TrimUpper)
                    {
                        // 列定義になく、データ領域に溢れていたので追加された列か、
                        // 列名なしの列。

                        if (oList_fldDef.Count <= nCIx)
                        {
                            // フィールドを追加。
                            // 列名：　空文字列
                            // 値の型：OValue_StringImpl
                            this.dataTable.Columns.Add("", typeof(XenonValue_StringImpl));
                        }


                        //
                        //
                        // セルのソースヒント名
                        //
                        string sSourceHintNameOfCell;
                        {
                            // フィールド名がないので、インデックスで指定します。
                            Log_TextIndented t = new Log_TextIndentedImpl();
                            t.Append("(");
                            t.Append(nCIx);
                            t.Append(")番フィールド");
                            sSourceHintNameOfCell = t.ToString();
                        }

                        // 列名がないので、列インデックスで指定して、データを追加。
                        // 値の型：OValue_StringImpl
                        XenonValue_StringImpl o_StringCellData = new XenonValue_StringImpl(sSourceHintNameOfCell);
                        o_StringCellData.Humaninput = sList_Column[nCIx];
                        dataRow[nCIx] = o_StringCellData;
                    }
                    else
                    {
                        if (sList_Column.Count <= nCIx)
                        {
                            // エラー
                            err_DataRow = dataRow;
                            err_SList_Column = sList_Column;
                            err_NCIx = nCIx;
                            goto gt_Error_ColumnIndexOver;
                        }
                        // 値を格納。
                        XenonValue o_Value = Utility_Row.ConfigurationTo_Field(//TODO:
                            nCIx,
                            sList_Column[nCIx],
                            oList_fldDef,
                            log_Reports
                            );

                        try
                        {
                            dataRow[sColumnName_TrimUpper] = o_Value;
                        }
                        catch (ArgumentException e)
                        {
                            err_DataRow = dataRow;
                            err_SColumnName_TrimUpper = sColumnName_TrimUpper;
                            err_Excep = e;
                            goto gt_Error_Field;
                        }
                    }
                }

                // テーブルに行オブジェクトをセット
                this.dataTable.Rows.Add(dataRow);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_ColumnIndexOver:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー463！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("列定義の個数より　フィールド数の少ない入力テーブルが指定されました。");
                s.Newline();

                s.Append("実データのこの行の列数[");
                s.Append(err_SList_Column.Count);
                s.Append("] 指定した列インデックス=[");
                s.Append(err_NCIx);
                s.Append("] フィールド定義の個数=[");
                s.Append(oList_fldDef.Count);
                s.Append("]");
                s.Newline();

                s.Append("──────────────────────────────テーブルに存在する列名");
                s.Newline();
                foreach (DataColumn col in err_DataRow.Table.Columns)
                {
                    s.Append("実列名＝[" + col.ColumnName + "]");
                    s.Newline();
                }
                s.Append("──────────────────────────────");
                s.Newline();

                s.Append("──────────────────────────────定義に存在する列名");
                s.Newline();
                foreach (XenonFielddefinitionImpl o_FldDef in oList_fldDef)
                {
                    s.Append("定義列名＝[" + o_FldDef.Name_Humaninput + "]");
                    s.Newline();
                }
                s.Append("──────────────────────────────");
                s.Newline();

                //s.Append("──────────────────────────────実データ");
                //s.Newline();
                //foreach (List<string> fields in rows)
                //{
                //    foreach (string sCell in fields)
                //    {
                //        s.Append("この行の最初の１個[");
                //        s.Append(sCell);
                //        s.Append("]");
                //        break;
                //    }
                //    s.Newline();
                //}
                //s.Append("──────────────────────────────");
                //s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Field:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー462！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("フィールド名[" + err_SColumnName_TrimUpper + "]が指定されましたが、ありません。");
                s.Newline();

                s.Append("──────────────────────────────テーブルに存在する列名");
                s.Newline();
                foreach (DataColumn col in err_DataRow.Table.Columns)
                {
                    s.Append("実列名＝[" + col.ColumnName + "]");
                    s.Newline();
                }
                s.Append("──────────────────────────────");
                s.Newline();

                s.Append("──────────────────────────────定義に存在する列名");
                s.Newline();
                foreach (XenonFielddefinitionImpl o_FldDef in oList_fldDef)
                {
                    s.Append("定義列名＝[" + o_FldDef.Name_Humaninput + "]");
                    s.Newline();
                }
                s.Append("──────────────────────────────");
                s.Newline();

                // ヒント
                s.Append(r.Message_SException(err_Excep));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
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
        /// NOフィールドを 0からの連番に振りなおします。
        /// 
        /// NOフィールド値は、プログラム中で主キーとして使うことがあるので、
        /// 変更するのであれば、ファイルを読み込んだ直後にするものとします。
        /// </summary>
        public void RenumberingNoField()
        {
            // NOフィールド値。
            int nNoValue = 0;
            {
                foreach (DataRow dataRow in this.DataTable.Rows)
                {
                    if (this.DataTable.Columns.Contains("NO"))
                    {
                        // NOフィールドがあれば。

                        XenonValue_IntImpl intCellData = (XenonValue_IntImpl)dataRow["NO"];

                        // NOフィールド値をセット
                        intCellData.SetInt(nNoValue);

                        nNoValue++;
                    }
                }
            }
        }

        /// <summary>
        /// 行の削除。
        /// </summary>
        /// <param name="record"></param>
        public void Remove(DataRow dataRow)
        {
            this.DataTable.Rows.Remove(dataRow);
        }

        /// <summary>
        /// 指定したレコードの並び順を１つ上に上げます。
        /// </summary>
        /// <param name="ttbwIndex"></param>
        public void MoveRecordToUpByIndex(int nRowIndex)
        {
            if (0 < nRowIndex)
            {
                // 新規空行を作成
                DataRow newRow = this.DataTable.NewRow();

                // 移動させたい行の内容を、新規空行にコピー。
                newRow.ItemArray = this.DataTable.Rows[nRowIndex].ItemArray;

                // 移動させたい行を、テーブルから除外。（重複挿入防止機能を回避するため）
                this.DataTable.Rows.RemoveAt(nRowIndex);

                // 移動させたい行のコピー内容を持つ新規行を挿入。
                this.DataTable.Rows.InsertAt(newRow, nRowIndex - 1);
            }
        }

        /// <summary>
        /// 指定したレコードの並び順を１つ下に下げます。
        /// </summary>
        /// <param name="ttbwIndex"></param>
        public void MoveRecordToDownByIndex(int nRowIndex)
        {
            if (nRowIndex < this.DataTable.Rows.Count - 1)
            {
                // 新規空行を作成
                DataRow newRow = this.DataTable.NewRow();

                // 移動させたい行の内容を、新規空行にコピー。
                newRow.ItemArray = this.DataTable.Rows[nRowIndex].ItemArray;

                // 移動させたい行を、テーブルから除外。（重複挿入防止機能を回避するため）
                this.DataTable.Rows.RemoveAt(nRowIndex);

                // 移動させたい行のコピー内容を持つ新規行を挿入。
                this.DataTable.Rows.InsertAt(newRow, nRowIndex + 1);
            }
        }

        /// <summary>
        /// 指定項目A（1～複数件）を、指定項目Bの下に移動させます。
        /// </summary>
        /// <param name="sourceIndices">移動待ち要素のリスト。インデックスの昇順に並んでいる必要があります。</param>
        /// <param name="destinationIndex"></param>
        public void MoveItemsBefore(int[] nSourceIndices, int nDestinationIndex)
        {
            if (nDestinationIndex < 0 && this.DataTable.Rows.Count <= nDestinationIndex)
            {
                // 無視。
                // テーブルの行数と同数の数字を指定しても、現実装では無視。

                return;
            }

            // ビューの不活性化(Enabled=false)は、このメソッドの外側で行ってください。

            // 位置調整に使うカウンター。
            int nOffset = 0;

            for (int nSourceArrayIndex = 0; nSourceArrayIndex < nSourceIndices.Length; nSourceArrayIndex++)
            {
                int nSourceIndex = nSourceIndices[nSourceArrayIndex];

                // 要素が動いた後の、移動待ちの全要素のインデックスを見直します。
                if (nDestinationIndex == nSourceIndex)
                {
                    // 移動元要素が動かなかったら

                    // 無視します。
                }
                else if (nDestinationIndex < nSourceIndex)
                {
                    // 移動元要素が、上に移動したのなら

                    // 移動元要素が移動後に　その後ろに来る要素で、
                    // もともと移動元要素より上にあった要素は、
                    // 位置が 1つ繰り下がり（+1）ます。
                    for (int arrayIndex2 = nSourceArrayIndex + 1; arrayIndex2 < nSourceIndices.Length; arrayIndex2++)
                    {
                        if (nDestinationIndex <= nSourceIndices[arrayIndex2] && nSourceIndices[arrayIndex2] < nSourceIndex)
                        {
                            nSourceIndices[arrayIndex2]++;
                        }
                    }

                    // TODO ・テーブルには、そのテーブルに入っている行を、また同じテーブルに挿入するということができない？
                    // TODO ・テーブルから行を抜いてしまうと、その行はもう使えなくなってしまうので、削除は避けたい。

                    // TODO ・データソースとなるテーブルの並び順を替えたなら、そのテーブルのセルをデータソースにしているコントロールは全て作り直しにする？

                    // 移動元要素を、リストから一旦抜いた後で、移動先の要素の上に挿入します。
                    DataRow newSourceItem = this.DataTable.NewRow();
                    //                    this.DataTable.Rows.
                    DataRow sourceItem = this.DataTable.Rows[nSourceIndex];
                    newSourceItem.ItemArray = sourceItem.ItemArray;//コピー
                    this.DataTable.Rows.RemoveAt(nSourceIndex);

                    // Insertメソッドは、0から始まる数字を指定します。
                    // 指定したインデックスの上に挿入されます。
                    //
                    // 2つ目以降の要素が追加されるときは、
                    // 「先に追加した要素と同じインデックスにInsertする＝どんどん上に追加される」
                    // ことになるので、逆順になります。
                    // それを防ぐために offset で調整します。
                    this.DataTable.Rows.InsertAt(newSourceItem, nDestinationIndex + nOffset);
                    nOffset++;
                }
                else
                {
                    // 移動元要素が、下に移動したのなら

                    // 移動元要素より下にあった要素で、
                    // 移動元要素が移動後に、その前に来る要素は、
                    // 位置が 1つ繰り上がり（-1）ます。
                    for (int nArrayIndex2 = nSourceArrayIndex + 1; nArrayIndex2 < nSourceIndices.Length; nArrayIndex2++)
                    {
                        if (nSourceIndices[nArrayIndex2] <= nDestinationIndex && nSourceIndex < nSourceIndices[nArrayIndex2])
                        {
                            nSourceIndices[nArrayIndex2]--;
                        }
                    }

                    // TODO テーブルから行を抜いてしまうと、その行はもう使えなくなってしまうので、削除は避けたい。

                    // 移動元要素を、一旦リストから抜いて、移動先の要素の上に挿入します。
                    DataRow newSourceItem = this.DataTable.NewRow();
                    DataRow sourceItem = this.DataTable.Rows[nSourceIndex];
                    newSourceItem.ItemArray = sourceItem.ItemArray;//コピー
                    this.DataTable.Rows.RemoveAt(nSourceIndex);

                    // Insertメソッドは、0から始まる数字を指定します。
                    // 指定したインデックスの上に挿入されます。

                    // 移動元の要素が抜かれているので、移動先は1つ繰り下がって(+1)ずれこんでいます。
                    // -1 して、ずれこみを解消します。
                    this.DataTable.Rows.InsertAt(newSourceItem, nDestinationIndex - 1);
                    // 2つ目以降の要素も　同じインデックスに追加されますが、
                    // 自分が削除されている瞬間に　移動先の要素は上に移動しているので、
                    // その空いたスペースに　自分が入ることになります。
                    // これで、正順に並ぶことになります。
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// フィールドの定義を取得します。
        /// 
        /// フィールド名の英字大文字、小文字は無視します。
        /// </summary>
        /// <param name="expectedFieldName"></param>
        /// <param name="bRequired">該当なしの時に例外を投げるなら真。</param>
        /// <returns>該当なし、エラーの場合偽。</returns>
        public bool TryGetFieldDefinitionByName(
            out List<XenonFielddefinition> oList_FieldDefinition,
            List<string> sList_ExpectedFieldName,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.Name_Library, this, "TryGetFieldDefinitionByName",log_Reports);

            bool bResult = true;
            oList_FieldDefinition = new List<XenonFielddefinition>();

            if (sList_ExpectedFieldName.Count < 1)
            {
                // エラー。
                goto gt_Error_ParamNothingField;
            }


            string err_SExpectedFieldName;
            int nCount = 0;
            foreach (string sExpectedFieldName in sList_ExpectedFieldName)
            {
                //
                // TODO:現状、「ID,NAME」などのカンマ区切りに対応できていない？
                //

                string sExpectedFieldNameUpper = sExpectedFieldName.ToUpper();

                foreach (XenonFielddefinitionImpl fieldDefinition in this.List_Fielddefinition)
                {
                    if (fieldDefinition.Name_Trimupper == sExpectedFieldNameUpper)
                    {
                        oList_FieldDefinition.Add(fieldDefinition);
                        nCount++;
                        goto gt_NextField;
                    }
                }


                // 一致するものが無かった場合。
                oList_FieldDefinition.Add(null);
                bResult = false;

                if (bRequired)
                {
                    //
                    // エラー。
                    err_SExpectedFieldName = sExpectedFieldName;
                    goto gt_Error_NothingField;
                }

                // 正常
                goto gt_EndMethod;

            gt_NextField:
                ;
            }
            // 正常

            if (nCount < 1)
            {
                bResult = false;

                if (bRequired)
                {
                    // エラー。
                    StringBuilder s = new StringBuilder();
                    foreach (string sFld in sList_ExpectedFieldName)
                    {
                        s.Append("[");
                        s.Append(sFld);
                        s.Append("]");
                    }
                    err_SExpectedFieldName = s.ToString();
                    goto gt_Error_NothingField;
                }

            }

            // 正常
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_ParamNothingField:
            {
                bResult = false;

                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー121！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();
                    s.Append("[");
                    s.Append(this.Name);
                    s.Append("]テーブルの列定義を調べようとしましたが、列名が指定されていません。sExpectedFieldNameList.Count＝[");
                    s.Append(sList_ExpectedFieldName.Count);
                    s.Append("]");

                    // ヒント

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NothingField:
            {
                bResult = false;

                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー122！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();
                    s.Append("[");
                    s.Append(this.Name);
                    s.Append("]テーブルに、[");

                    s.Append(err_SExpectedFieldName);
                    s.Append("]フィールドは存在しませんでした。");

                    // ヒント

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return bResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// NOフィールドの値で指定したレコードを返します。なければヌルです。
        /// </summary>
        /// <param name="exceptedNo"></param>
        /// <returns></returns>
        public DataRow SelectByNo(
            XenonValue_IntImpl intCellDataParam,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.Name_Library, this, "SelectByNo",log_Reports);

            //
            //
            //
            //


            DataRow result;

            if (intCellDataParam.IsSpaces())
            {
                // 空白なら中断。
                result = null;
                goto gt_Error_Spaces;
            }
            else if (!intCellDataParam.IsValidated)
            {
                // エラーデータなら中断。
                result = null;
                goto gt_Error_Invalid;
            }

            int nExpectedNo;
            bool bParsed = XenonValue_IntImpl.TryParse(
                intCellDataParam,
                out nExpectedNo,
                EnumOperationIfErrorvalue.Error,
                null,
                log_Reports
                );
            if (!log_Reports.Successful)
            {
                // 既エラー
                result = null;
                goto gt_EndMethod;
            }

            if (bParsed)
            {

                foreach (DataRow dataRow in this.DataTable.Rows)
                {
                    if (dataRow.Table.Columns.Contains("NO"))
                    {
                        // NO列があれば

                        XenonValue cellData = (XenonValue)dataRow["NO"];

                        if (cellData is XenonValue_IntImpl)
                        {
                            XenonValue_IntImpl intCellData = (XenonValue_IntImpl)cellData;

                            if (intCellData.IsSpaces())
                            {
                                // 空白なら無視
                            }
                            else if (!intCellData.IsValidated)
                            {
                                // エラーデータなら無視
                            }
                            else
                            {
                                int nNoInt;

                                bool bParsed2 = XenonValue_IntImpl.TryParse(
                                    intCellData,
                                    out nNoInt,
                                    EnumOperationIfErrorvalue.Error,
                                    null,
                                    log_Reports
                                    );
                                if (!log_Reports.Successful)
                                {
                                    // 既エラー
                                    result = null;
                                    goto gt_EndMethod;
                                }

                                if (bParsed2)
                                {
                                    if (nExpectedNo == nNoInt)
                                    {
                                        // 一致すれば。
                                        result = dataRow;
                                        goto gt_EndMethod;
                                    }
                                }
                            }
                        }
                    }
                }

            }

            result = null;
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Spaces:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー641！", log_Method);
                r.Message = "（空白なので中断）";
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Invalid:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー642！", log_Method);
                r.Message = "（エラーデータなので中断）";
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 指定のInt型フィールドの値で指定したレコードを返します。なければヌルです。
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="expectedInt"></param>
        /// <returns>一致しなければヌル。</returns>
        public DataRow SelectByInt(
            string sFieldName,
            XenonValue_IntImpl expectedIntParam,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.Name_Library, this, "SelectByInt",log_Reports);

            //
            //
            //
            //

            DataRow result;

            if (expectedIntParam.IsSpaces())
            {
                // 空白なら中断。
                result = null;
                goto gt_Error_Spaces;
            }
            else if (!expectedIntParam.IsValidated)
            {
                // エラーデータなら中断。
                result = null;
                goto gt_Error_Invalid;
            }

            int nExpectedInt;

            bool bParsed = XenonValue_IntImpl.TryParse(
                expectedIntParam,
                out nExpectedInt,
                EnumOperationIfErrorvalue.Error,
                null,
                log_Reports
                );
            if (!log_Reports.Successful || !bParsed)
            {
                // 既エラー
                result = null;
                goto gt_EndMethod;
            }


            Exception err_Excp;
            try
            {
                foreach (DataRow dataRow in this.DataTable.Rows)
                {

                    XenonValue cellData = (XenonValue)dataRow[sFieldName];

                    if (cellData is XenonValue_IntImpl)
                    {
                        XenonValue_IntImpl intCellData = (XenonValue_IntImpl)cellData;

                        if (intCellData.IsSpaces())
                        {
                            // 空白なら無視
                        }
                        else if (!intCellData.IsValidated)
                        {
                            // エラーデータなら無視
                        }
                        else
                        {
                            int nExistsInt;

                            bool bParsed2 = XenonValue_IntImpl.TryParse(
                                intCellData,
                                out nExistsInt,
                                EnumOperationIfErrorvalue.Error,
                                null,
                                log_Reports
                                );
                            if (!log_Reports.Successful)
                            {
                                // 既エラー
                                result = null;
                                goto gt_EndMethod;
                            }

                            if (bParsed2)
                            {
                                if (nExpectedInt == nExistsInt)
                                {
                                    // 一致すれば。
                                    result = dataRow;
                                    // 正常
                                    goto gt_EndMethod;
                                }
                            }
                        }
                    }
                    //}
                }
            }
            catch (Exception e)
            {
                // ArgumentException: 指定した名前の列がなかった場合など。
                err_Excp = e;
                result = null;
                goto gt_Error_Exception;
            }


            result = null;
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Spaces:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー651！", log_Method);
                r.Message = "＜空白で中断＞";
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Invalid:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー652！", log_Method);
                r.Message = "＜エラーデータで中断＞";
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー653！", log_Method);
                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append(r.Message_SException(err_Excp));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 指定のstring型フィールドの値で指定したレコードを返します。なければヌルです。
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="expectedInt"></param>
        /// <returns>一致しなければヌル。</returns>
        public List<DataRow> SelectByString(
            string sFieldName,
            XenonValue_StringImpl expectedStringParam,
            EnumHitcount hits,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.Name_Library, this, "SelectByString", log_Reports);

            //
            //
            //
            //

            List<DataRow> list_Result = new List<DataRow>();

            //if (!expectedStringParam.BValidated)
            //{
            //    // エラーデータなら中断。
            //    result = null;
            //    if (log_Reports.CanCreateReport)
            //    {
            //        Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
            //        r.SetTitle("▲エラー652！", this.GetType().Name, InfxenonTable.LibraryName);
            //        r.Message = "＜エラーデータで中断 BValidated=false＞";
            //        log_Reports.EndCreateReport();
            //    }
            //    goto gt_EndMethod;
            //}

            string sExpected;

            bool bParsed = XenonValue_StringImpl.TryParse(
                expectedStringParam,
                out sExpected,
                "",
                "",
                log_Method,
                log_Reports
                );
            if (!log_Reports.Successful || !bParsed)
            {
                // 既エラー
                goto gt_EndMethod;
            }


            Exception err_Excp;
            try
            {
                foreach (DataRow dataRow in this.DataTable.Rows)
                {

                    XenonValue cellData = (XenonValue)dataRow[sFieldName];

                    if (cellData is XenonValue_StringImpl)
                    {
                        XenonValue_StringImpl stringCellData = (XenonValue_StringImpl)cellData;

                        if (!stringCellData.IsValidated)
                        {
                            // エラーデータなら無視
                        }
                        else
                        {
                            string sExists;

                            bool bParsed2 = XenonValue_StringImpl.TryParse(
                                stringCellData,
                                out sExists,
                                "",
                                "",
                                log_Method,
                                log_Reports
                                );
                            if (!log_Reports.Successful)
                            {
                                // 既エラー
                                goto gt_EndMethod;
                            }

                            if (bParsed2)
                            {
                                if (sExpected == sExists)
                                {
                                    // 一致すれば。
                                    list_Result.Add(dataRow);

                                    if (hits == EnumHitcount.First_Exist)
                                    {
                                        // 正常
                                        goto gt_EndMethod;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // ArgumentException: 指定した名前の列がなかった場合など。
                err_Excp = e;
                goto gt_Error_Exception;
            }

            goto gt_EndMethod;
            //
            //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー653！", log_Method);
                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append(r.Message_SException(err_Excp));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
            //
            //
        gt_EndMethod:
            if (hits == EnumHitcount.First_Exist && list_Result.Count != 1)
            {
                // 必ず存在する最初の１件を返さなければなりませんが、そうではありませんでした。
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー654！", log_Method);

                    Log_TextIndented s = new Log_TextIndentedImpl();
                    s.Append("必ず存在する最初の１件を返さなければなりませんが、そうではありませんでした。");
                    s.Newline();
                    s.Append("count=[");
                    s.Append(list_Result.Count);
                    s.Append("]");

                    r.Message = s.ToString();
                    log_Reports.EndCreateReport();
                }
            }
            log_Method.EndMethod(log_Reports);
            return list_Result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// フィールドの型のデバッグ情報です。
        /// </summary>
        /// <returns></returns>
        public string DebugFields()
        {
            Log_TextIndented t = new Log_TextIndentedImpl();

            foreach (XenonFielddefinitionImpl fieldDefinition in listO_FieldDefinition)
            {
                t.Append("[");
                t.Append(fieldDefinition.Name_Humaninput);
                t.Append(":");
                t.Append(fieldDefinition.Type);
                t.Append("]");
            }

            return t.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 【2012-08-25 追加】
        /// </summary>
        /// <param name="sName_Field"></param>
        /// <param name="bRequired"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public bool ContainsField(string sName_Field, bool bRequired, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.Name_Library, this, "ContainsField",log_Reports);

            bool bResult;

            if (this.DataTable.Columns.Contains(sName_Field))
            {
                bResult = true;
            }
            else
            {
                bResult = false;

                if (bRequired)
                {
                    // エラー
                    goto gt_Error_NotFoundField;
                }
            }


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundField:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー902！", log_Method);

                StringBuilder sb = new StringBuilder();

                sb.Append("[" + sName_Field + "]フィールドは、[" + this.Name + "]には存在しませんでした。");
                sb.Append(Environment.NewLine);
                sb.Append("テーブル名＝[" + this.Name + "]");
                sb.Append(Environment.NewLine);
                sb.Append("データ・タイプ＝[" + this.Typedata + "]");

                r.Message = sb.ToString();
                log_Reports.EndCreateReport();
            }
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return bResult;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<XenonFielddefinition> listO_FieldDefinition;

        /// <summary>
        /// フィールドの型定義。
        /// </summary>
        public List<XenonFielddefinition> List_Fielddefinition
        {
            get
            {
                return listO_FieldDefinition;
            }
        }

        //────────────────────────────────────────

        private XenonTableformat xenonTableFormat;

        /// <summary>
        /// テーブルの内容保存方法などの設定。
        /// </summary>
        public XenonTableformat XenonTableformat
        {
            get
            {
                return xenonTableFormat;
            }
            set
            {
                xenonTableFormat = value;
            }
        }

        //────────────────────────────────────────

        private DataTable dataTable;

        /// <summary>
        /// テーブルのデータ部。
        /// </summary>
        public DataTable DataTable
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
            }
        }

        //────────────────────────────────────────

        private string name_Table;

        /// <summary>
        /// このテーブルの名前。なければ空文字列。
        /// </summary>
        public string Name_Table
        {
            get
            {
                return name_Table;
            }
            set
            {
                name_Table = value;

                // データテーブルに、テーブル名を上書きします。
                this.DataTable.TableName = name_Table;
            }
        }

        //────────────────────────────────────────

        private string sTableUnit;

        /// <summary>
        /// このテーブルの「テーブル_ユニット名」。なければ空文字列。
        /// </summary>
        public string Tableunit
        {
            get
            {
                return sTableUnit;
            }
            set
            {
                sTableUnit = value;
            }
        }

        //────────────────────────────────────────

        private string sTypeData;

        /// <summary>
        /// 「TYPE_DATA」フィールド値。
        /// 「T:～;」
        /// </summary>
        public string Typedata
        {
            get
            {
                return sTypeData;
            }
            set
            {
                sTypeData = value;
            }
        }

        //────────────────────────────────────────

        private bool bDateBackup;

        /// <summary>
        /// 「日別バックアップ」を行うなら真。
        /// </summary>
        public bool IsDatebackupActivated
        {
            get
            {
                return bDateBackup;
            }
            set
            {
                bDateBackup = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// あれば、テーブルのファイル・パスなど。
        /// なければヌル可？
        /// </summary>
        private Expression_Node_Filepath expression_Filepath_ConfigStack;

        public Expression_Node_Filepath Expression_Filepath_ConfigStack
        {
            get
            {
                return expression_Filepath_ConfigStack;
            }
        }

        //────────────────────────────────────────
        #endregion



    }



}
