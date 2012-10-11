using System;
using System.Collections.Generic;
using System.Data;//DataRowView
using System.Linq;
using System.Text;

using Xenon.Syntax;


namespace Xenon.Table
{
    ///// <summary>
    ///// 大文字・小文字を無視する文字列比較。
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //class IgnoreCaseComparer<T> : IEqualityComparer<T>
    //{
    //    public bool Equals(T x, T y)
    //    {
    //        if (x is string && y is string)
    //        {
    //            string xStr = x as string;
    //            string yStr = y as string;

    //            if(null!=xStr && null!=yStr)
    //            {
    //                return xStr.ToLower().Equals(yStr.ToLower());
    //            }
    //            else
    //            {
    //                return x.Equals(y);
    //            }

    //            //// 大文字・小文字を無視する文字列比較。
    //            //return xStr.Equals(yStr, StringComparison.OrdinalIgnoreCase);
    //        }
    //        else
    //        {
    //            return x.Equals(y);
    //        }
    //    }

    //    public int GetHashCode(T obj)
    //    {
    //        return obj.GetHashCode();
    //    }

    //}

    /// <summary>
    /// 行ユーティリティー
    /// </summary>
    public class Utility_Row
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// O_TableImpl#AddRecordListで使います。
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="sValue"></param>
        /// <param name="oTable"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public static Value_Humaninput ConfigurationTo_Field(
            int nIndex_Column,
            string sValue,
            RecordFielddefinition recordFielddefinition,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Table.Name_Library, "Utility_Row", "ConfigurationTo_Field", log_Reports);

            //
            //
            //
            //

            //
            // セルのソースヒント名
            string sConfigStack;
            try
            {
                sConfigStack = recordFielddefinition.ValueAt(nIndex_Column).Name_Humaninput;
            }
            catch (ArgumentOutOfRangeException)
            {
                // エラー
                goto gt_Error_Index;
            }

            Value_Humaninput result;

            // 型毎に処理を分けます。
            if (recordFielddefinition.ValueAt(nIndex_Column).Type == typeof(Int_HumaninputImpl))
            {
                // 空白データも自動処理
                Int_HumaninputImpl cellData = new Int_HumaninputImpl(sConfigStack);
                cellData.Text = sValue;
                result = cellData;
            }
            else if (recordFielddefinition.ValueAt(nIndex_Column).Type == typeof(Bool_HumaninputImpl))
            {
                // 空白データも自動処理
                Bool_HumaninputImpl cellData = new Bool_HumaninputImpl(sConfigStack);
                cellData.Text = sValue;
                result = cellData;
            }
            else
            {
                String_HumaninputImpl cellData = new String_HumaninputImpl(sConfigStack);
                cellData.Text = sValue;
                result = cellData;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Index:
            result = null;
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー461！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("列インデックス[" + nIndex_Column + "]（0スタート）が指定されましたが、");
                t.Newline();
                t.Append("列は[" + recordFielddefinition.Count + "]個しかありません。（列定義リストは、絞りこまれている場合もあります）");
                t.Newline();

                // ヒント

                r.Message = t.ToString();
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
        /// フィールドがなかった場合に、警告を作成してくれます。
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="c"></param>
        /// <param name="log_Reports"></param>
        /// <param name="dataSourceHintName"></param>
        /// <returns></returns>
        public static object GetFieldvalue(
            string sName_Field,
            DataRow row,
            bool bNoHitIsError,
            Log_Reports log_Reports,
            string sHintname_DataSource
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.Name_Library, "Utility_Row", "GetFieldvalue", log_Reports);

            object objResult;

            // ArgumentException予防
            if (!row.Table.Columns.Contains(sName_Field))
            {
                // 該当なしの場合

                objResult = null;


                if (bNoHitIsError)
                {
                    // 指定のフィールドが、該当なしの場合エラーになる設定なら
                    goto gt_Error_NotFoundField;
                }

                // 該当なしの場合エラーにならない設定なら、フィールドがなくても無視します。
                // 正常
                goto gt_EndMethod;
            }

            Exception err_Excp;
            try
            {
                // bug: 列名には、大文字・小文字の区別はないようです。
                objResult = row[sName_Field];
            }
            catch (Exception e)
            {
                objResult = null;
                err_Excp = e;
                goto gt_Error_Exception;
            }

            if (bNoHitIsError && null==objResult)
            {
                goto gt_Error_Null;
            }

            // 正常
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundField:
            // エラー。指定のフィールドが見つからなかった。
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー603！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定のフィールド[");
                s.Append(sName_Field);
                s.Append("]は、データソース[");
                s.Append(sHintname_DataSource);
                s.Append("]にはありませんでした。");
                s.Append(Environment.NewLine);

                s.Append("テーブル名＝[");
                s.Append(row.Table.TableName);
                s.Append("]");
                s.Append(Environment.NewLine);

                //sB.Append("エラー型：");
                //sB.Append(err_Excp.GetType().Name);
                //sB.Append(Environment.NewLine);
                //sB.Append("エラーメッセージ：");
                //sB.Append(err_Excp.Message);

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー601！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("指定のフィールド[");
                s.Append(sName_Field);
                s.Append("]の読取りに失敗しました。");
                s.Append(Environment.NewLine);

                s.Append("テーブル名＝[");
                s.Append(row.Table.TableName);
                s.Append("]");
                s.Append(Environment.NewLine);

                s.Append("データソースヒント名：");
                s.Append(sHintname_DataSource);
                s.Append(Environment.NewLine);

                s.Append("メッセージ：");
                s.Append(err_Excp.Message);

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Null:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー602！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("▲エラー4101！(" + Info_Table.Name_Library + ")");
                s.Newline();
                s.Append("指定のフィールド[");
                s.Append(sName_Field);
                s.Append("]は、ヌルでした。");
                s.Append(Environment.NewLine);
                s.Append("データソースヒント名：");
                s.Append(sHintname_DataSource);
                s.Append(Environment.NewLine);

                s.Append("テーブル名＝[");
                s.Append(row.Table.TableName);
                s.Append("]");
                s.Append(Environment.NewLine);

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
            return objResult;
        }

        //────────────────────────────────────────
        #endregion



    }
}
