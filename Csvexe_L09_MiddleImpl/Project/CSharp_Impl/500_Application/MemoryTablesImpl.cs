using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Table; //DefaultTable
using Xenon.Middle;

namespace Xenon.MiddleImpl
{

    /// <summary>
    /// テーブルズ モデル
    /// 
    /// (Model Of Tables)
    /// </summary>
    public class MemoryTablesImpl : MemoryTables
    {



        #region 生成と破棄
        //────────────────────────────────────────
        
        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryTablesImpl()
        {
            this.dictionary_XenonTable = new Dictionary<string, XenonTable>();
        }

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear()
        {
            this.dictionary_XenonTable.Clear();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// テーブル名を指定することで、テーブルを返します。
        /// </summary>
        /// <param select="nTableName"></param>
        /// <param select="bRequired">該当しなかった場合に警告表示を行うなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        public XenonTable GetXenonTableByName(
            Expression_Node_String ec_TableName,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "GetXenonTableByName",log_Reports);

            //
            //
            //
            //

            XenonTable o_Table;
            string sTableName = ec_TableName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports); ;
            if (this.dictionary_XenonTable.ContainsKey(sTableName))
            {
                o_Table = this.dictionary_XenonTable[sTableName];
            }
            else
            {
                o_Table = null;


                if (bRequired)
                {
                    //
                    // エラー
                    goto gt_Error_NotFoundTable;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundTable:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー928！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("[");

                s.Append(sTableName);

                s.Append("]という名前のテーブルは存在しませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Givechapterandverse(ec_TableName.Cur_Givechapterandverse.Parent_Givechapterandverse));

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
            return o_Table;
        }

        /// <summary>
        /// テーブルを返します。レイアウト_グループ名を指定してください。
        /// </summary>
        /// <param select="nTableName"></param>
        /// <param select="bRequired">該当しなかった場合にエラー扱いなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        public List<XenonTable> GetXenonTableByFormgroup(
            Expression_Node_String ecTableUnit,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "GetXenonTableByFormgroup",log_Reports);
            //
            //

            List<XenonTable> oList_ResltTable = new List<XenonTable>();

            if (null==ecTableUnit)
            {
                goto gt_EndMethod;
            }

            try
            {
                string sTableUnit = ecTableUnit.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                foreach (XenonTable oTable in this.dictionary_XenonTable.Values)
                {
                    if (null!=oTable.STableunit &&
                        sTableUnit == oTable.STableunit)
                    {
                        oList_ResltTable.Add(oTable);
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                if (bRequired)// && null != log_Reports
                {
                    //
                    // エラー
                    goto gt_Error_NotFound;
                }
            }
            
            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFound:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー929！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("指定したレイアウト_グループ名[");

                t.Append(ecTableUnit.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));

                t.Append("]は、存在しませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(ecTableUnit.Cur_Givechapterandverse.Parent_Givechapterandverse));

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
            return oList_ResltTable;
        }

        //────────────────────────────────────────

        /// <summary>
        /// テーブルを、コレクションに追加します。
        /// </summary>
        /// <param select="oTable"></param>
        public void AddXenonTable(
            XenonTable o_Table,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "AddXenonTable", log_Reports);

            string sTableName_Trimed = o_Table.SName.Trim();

            if(""==sTableName_Trimed)
            {
                // エラー
                goto gt_Error_NoName;
            }

            if (log_Reports.BSuccessful)
            {
                if (!this.Dictionary_XenonTable.ContainsKey(sTableName_Trimed))
                {
                    this.dictionary_XenonTable[sTableName_Trimed] = o_Table;
                }
                else
                {
                    // エラー
                    goto gt_Error_OverlappedTableName;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NoName:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー930！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("テーブル名を指定してください。無名です。[");
                t.Append(o_Table.SName);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("テーブルを登録するには、テーブル名が必要です。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_OverlappedTableName:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー931！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("登録しようとしたテーブルの名前は、既に登録されていました。[");
                t.Append(o_Table.SName);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("同じ名前のテーブルは、２度登録できません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(o_Table));

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



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, XenonTable> dictionary_XenonTable;

        /// <summary>
        /// ユーザー定義テーブルの、名前付き一覧。
        /// </summary>
        public Dictionary<string, XenonTable> Dictionary_XenonTable
        {
            get
            {
                return this.dictionary_XenonTable;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
