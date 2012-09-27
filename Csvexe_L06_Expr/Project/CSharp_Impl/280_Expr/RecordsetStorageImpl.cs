using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Expr
{


    public class RecordsetStorageImpl : RecordsetStorage
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public RecordsetStorageImpl()
        {
            this.dictionary_Recordset = new Dictionary<string, RecordSet>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// レコードセットの追加。
        /// </summary>
        /// <param name="eName"></param>
        /// <param name="recordSet"></param>
        /// <param name="log_Reports"></param>
        public void Add(Expression_Node_String ec_Name, RecordSet recordSet, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.SName_Library, this, "Add",log_Reports);
            //
            //

            string sName = ec_Name.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports).Trim();

            try
            {
                this.dictionary_Recordset.Add(sName, recordSet);

                //// debug: 追加したレコードセットの内容。
                //{
                //    ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#Add: 追加したレコードセットの内容"+
                //        "　fld＝["+oRecordSet.NField.E_Execute(Request_SelectingImpl.Unconstraint, log_Reports)+"]" +
                //        "　ｌｏｏｋｕｐ－ｖａｌｕｅ＝["+oRecordSet.NLookupValue.E_Execute(Request_SelectingImpl.Unconstraint, log_Reports)+"]" +
                //        "　required＝[" + oRecordSet.NRequired.E_Execute(Request_SelectingImpl.Unconstraint, log_Reports) + "]" +
                //        "　ｆｒｏｍ＝[" + oRecordSet.NFrom.E_Execute(Request_SelectingImpl.Unconstraint, log_Reports) + "]" +
                //        "　ｄescription＝[" + oRecordSet.NDescription.E_Execute(Request_SelectingImpl.Unconstraint, log_Reports) + "]" +
                //        "　Ｓｔｏｒａｇｅ＝[" + oRecordSet.NStorage.E_Execute(Request_SelectingImpl.Unconstraint, log_Reports) + "]"
                //        );

                //}
            }
            catch (ArgumentException ex)
            {
                //return;

                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー129！", log_Method);

                    StringBuilder t = new StringBuilder();
                    t.Append("もしかして、既に追加されている要素を、また追加しましたか？");
                    t.Append(Environment.NewLine);
                    t.Append("record-set-save-to 名前＝[");
                    t.Append(sName);
                    t.Append("]");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);
                    t.Append("record-set-save-to属性を使って、一時記憶したレコードセットは、使い終わった時に、");
                    t.Append(Environment.NewLine);
                    t.Append("record-set-clear属性を使って、削除する必要があります。");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);


                    // oSourceが無限ループ？？

                    // ヒント
                    t.Append(r.Message_Givechapterandverse(ec_Name.Cur_Givechapterandverse));
                    t.Append(r.Message_SException(ex));

                    r.SMessage = t.ToString();
                    log_Reports.EndCreateReport();
                }
            }

            //
            //
            //
            //

            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// レコードセットの取得。
        /// </summary>
        /// <param name="eName"></param>
        /// <param name="log_Reports"></param>
        /// <returns>該当がなければヌル。</returns>
        public RecordSet Get(Expression_Node_String ec_Name, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.SName_Library, this, "Get",log_Reports);
            //
            //

            string sName = ec_Name.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports).Trim();


            RecordSet nResult;

            try
            {
                //ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#Remove: 【レコードセット削除】sName＝[" + sName + "]");
                nResult = this.dictionary_Recordset[sName];
            }
            catch (KeyNotFoundException ex)
            {
                nResult = null;

                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー130！", log_Method);

                    StringBuilder t = new StringBuilder();
                    t.Append("指定の名前で一時記憶されているレコードセットはありませんでした。");
                    t.Append(Environment.NewLine);
                    t.Append("record-set-load-ｆｒｏｍ 名前＝[");
                    t.Append(sName);
                    t.Append("]");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);


                    // oSourceが無限ループ？？

                    // ヒント
                    t.Append(r.Message_Givechapterandverse(ec_Name.Cur_Givechapterandverse));
                    t.Append(r.Message_SException(ex));

                    r.SMessage = t.ToString();
                    log_Reports.EndCreateReport();
                }
            }
            catch (Exception ex)
            {
                nResult = null;

                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー131！", log_Method);

                    StringBuilder t = new StringBuilder();
                    t.Append("原因不明。");
                    t.Append(Environment.NewLine);
                    t.Append("record-set-load-ｆｒｏｍ 名前＝[");
                    t.Append(sName);
                    t.Append("]");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);


                    // oSourceが無限ループ？？

                    //
                    // ヒント
                    t.Append(r.Message_Givechapterandverse(ec_Name.Cur_Givechapterandverse));
                    t.Append(r.Message_SException(ex));

                    r.SMessage = t.ToString();
                    log_Reports.EndCreateReport();
                }
            }

            //
            //
            //
            //

            log_Method.EndMethod(log_Reports);
            return nResult;
        }

        /// <summary>
        /// レコードセットの削除。
        /// </summary>
        /// <param name="eStorage"></param>
        /// <param name="log_Reports"></param>
        public void Remove(Expression_Node_String ec_Storage, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.SName_Library, this, "Remove",log_Reports);
            //
            //

            string sStorage = ec_Storage.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports).Trim();

            Exception err_Excp;
            try
            {
                this.dictionary_Recordset.Remove(sStorage);

                // #デバッグ中
                System.Console.WriteLine(Info_Expr.SName_Library + ":" + this.GetType().Name + "#Remove: 【レコードセット削除】sName＝[" + sStorage + "]");

            }
            catch (Exception ex)
            {
                err_Excp = ex;
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
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー132！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("原因不明。");
                t.Append(Environment.NewLine);
                t.Append("＜a-record-set-to-save＞Ｓｔｏｒａｇｅ 名前＝[");
                t.Append(sStorage);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);


                // oSourceが無限ループ？？

                // ヒント
                t.Append(r.Message_Givechapterandverse(ec_Storage.Cur_Givechapterandverse));
                t.Append(r.Message_SException(err_Excp));

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
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 有無。
        /// </summary>
        /// <param name="nName"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public bool Contains(Expression_Node_String ec_Name, Log_Reports log_Reports)
        {
            string sName = ec_Name.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

            return this.dictionary_Recordset.ContainsKey(sName);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, RecordSet> dictionary_Recordset;

        //────────────────────────────────────────
        #endregion



    }

}
