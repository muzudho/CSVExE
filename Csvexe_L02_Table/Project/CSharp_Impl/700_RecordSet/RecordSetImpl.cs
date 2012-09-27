using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Table
{
    public class RecordSetImpl : RecordSet
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public RecordSetImpl(XenonTable xenonTable)
        {
            this.xenonTable = xenonTable;

            this.list_Field = new List<Dictionary<string, XenonValue>>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// DataRow → Dictionary
        /// </summary>
        /// <param name="row"></param>
        /// <param name="log_Reports"></param>
        public void Add(DataRow row, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.SName_Library, this, "Add",log_Reports);

            Dictionary<string, XenonValue> record = new Dictionary<string, XenonValue>();

            int nFieldCount = row.ItemArray.Length;
            for (int nFieldIndex = 0; nFieldIndex < nFieldCount; nFieldIndex++)
            {
                // フィールド名
                string sFieldName = xenonTable.List_Fielddefinition[nFieldIndex].SName_Trimupper;

                // 値
                XenonValue oValue;
                if (row[nFieldIndex] is DBNull)
                {
                    //// デバッグ
                    //if (true)
                    //{
                    //Log_TextIndented txt = new Log_TextIndentedImpl();

                    //    txt.Append(InfxenonTable.LibraryName + ":" + this.GetType().Name + "#Add:【ヌル】");
                    //    txt.Append("　field＝[" + sFieldName + "]");

                    //    ystem.Console.WriteLine(txt.ToString());
                    //}

                    Type type = xenonTable.List_Fielddefinition[nFieldIndex].Type;

                    String sConfigStack = xenonTable.Expression_Filepath_ConfigStack.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint, log_Reports);
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    if (type == typeof(XenonValue_StringImpl))
                    {
                        oValue = new XenonValue_StringImpl(sConfigStack);
                    }
                    else if (type == typeof(XenonValue_IntImpl))
                    {
                        oValue = new XenonValue_IntImpl(sConfigStack);
                    }
                    else if (type == typeof(XenonValue_BoolImpl))
                    {
                        oValue = new XenonValue_BoolImpl(sConfigStack);
                    }
                    else
                    {
                        //
                        // エラー。
                        goto gt_Error_UndefinedType;
                    }
                }
                else
                {
                    oValue = (XenonValue)row[nFieldIndex];

                    //// デバッグ
                    //if (true)
                    //{
                    //Log_TextIndented txt = new Log_TextIndentedImpl();

                    //    txt.Append(InfxenonTable.LibraryName + ":" + this.GetType().Name + "#Add:【○】");
                    //    txt.Append("　値＝[" + oValue.HumanInputString + "]");

                    //    ystem.Console.WriteLine(txt.ToString());
                    //}
                }

                record.Add(sFieldName, oValue);
            }

            this.List_Field.Add(record);

            // 正常
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedType:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー293！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("　未定義の型です。プログラムのミスの可能性があります。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

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
            return;
        }

        //────────────────────────────────────────

        /// <summary>
        /// List＜DataRow＞ → Dictionary
        /// </summary>
        /// <param name="row"></param>
        /// <param name="log_Reports"></param>
        public void AddList(List<DataRow> list_Row, Log_Reports log_Reports)
        {
            foreach (DataRow row in list_Row)
            {
                this.Add(row, log_Reports);
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

            }

            // 正常
            goto gt_EndMethod;

            //
        //
        //
        //
        gt_EndMethod:
            return;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<Dictionary<string, XenonValue>> list_Field;

        public List<Dictionary<string, XenonValue>> List_Field
        {
            get
            {
                return list_Field;
            }
            set
            {
                list_Field = value;
            }
        }

        //────────────────────────────────────────

        private XenonTable xenonTable;

        public XenonTable XenonTable
        {
            get
            {
                return xenonTable;
            }
            set
            {
                xenonTable = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
