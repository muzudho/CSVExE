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
        public void Add(
            Expression_Node_String ec_Name, RecordSet recordSet,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Add",log_Reports);
            //
            //

            string sName = ec_Name.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim();

            try
            {
                this.dictionary_Recordset.Add(sName, recordSet);

                //// debug: 追加したレコードセットの内容。
                //{
                //    ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#Add: 追加したレコードセットの内容"+
                //        "　fld＝["+oRecordSet.NField.E_Execute(EnumHitcount.Unconstraint, log_Reports)+"]" +
                //        "　ｌｏｏｋｕｐ－ｖａｌｕｅ＝["+oRecordSet.NLookupValue.E_Execute(EnumHitcount.Unconstraint, log_Reports)+"]" +
                //        "　required＝[" + oRecordSet.NRequired.E_Execute(EnumHitcount.Unconstraint, log_Reports) + "]" +
                //        "　ｆｒｏｍ＝[" + oRecordSet.NFrom.E_Execute(EnumHitcount.Unconstraint, log_Reports) + "]" +
                //        "　ｄescription＝[" + oRecordSet.NDescription.E_Execute(EnumHitcount.Unconstraint, log_Reports) + "]" +
                //        "　Ｓｔｏｒａｇｅ＝[" + oRecordSet.NStorage.E_Execute(EnumHitcount.Unconstraint, log_Reports) + "]"
                //        );

                //}
            }
            catch (ArgumentException ex)
            {
                //return;

                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, sName, log_Reports);//名前
                    tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(ec_Name.Cur_Configuration), log_Reports);//設定位置パンくずリスト
                    tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Exception(ex), log_Reports);//例外メッセージ

                    memoryApplication.CreateErrorReport("Er:6042;", tmpl, log_Reports);
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
        public RecordSet Get(Expression_Node_String ec_Name,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Get",log_Reports);
            //
            //

            string sName = ec_Name.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim();


            RecordSet nResult;

            try
            {
                //ystem.Console.WriteLine(Info_N.LibraryName + ":" + this.GetType().Name + "#Remove: 【レコードセット削除】sName＝[" + sName + "]");
                nResult = this.dictionary_Recordset[sName];
            }
            catch (KeyNotFoundException ex)
            {
                nResult = null;

                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, sName, log_Reports);//名前
                    tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(ec_Name.Cur_Configuration), log_Reports);//設定位置パンくずリスト
                    tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Exception(ex), log_Reports);//例外メッセージ

                    memoryApplication.CreateErrorReport("Er:6043;", tmpl, log_Reports);
                }
            }
            catch (Exception ex)
            {
                nResult = null;

                {
                    Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                    tmpl.SetParameter(1, sName, log_Reports);//名前
                    tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(ec_Name.Cur_Configuration), log_Reports);//設定位置パンくずリスト
                    tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Exception(ex), log_Reports);//例外メッセージ

                    memoryApplication.CreateErrorReport("Er:6044;", tmpl, log_Reports);
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
        public void Remove(Expression_Node_String ec_Storage,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Remove",log_Reports);
            //
            //

            string sStorage = ec_Storage.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim();

            Exception err_Excp;
            try
            {
                this.dictionary_Recordset.Remove(sStorage);

                // #デバッグ中
                System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#Remove: 【レコードセット削除】sName＝[" + sStorage + "]");

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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sStorage, log_Reports);//名前
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configuration(ec_Storage.Cur_Configuration), log_Reports);//設定位置パンくずリスト
                tmpl.SetParameter(3, Log_RecordReportsImpl.ToText_Exception(err_Excp), log_Reports);//例外メッセージ

                memoryApplication.CreateErrorReport("Er:6045;", tmpl, log_Reports);
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
            string sName = ec_Name.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

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
