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
        public MemoryTablesImpl(MemoryApplication owner_MemoryApplication)
        {
            this.Clear(owner_MemoryApplication);
        }

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear(MemoryApplication owner_MemoryApplication)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
            if (null == this.dictionary_Table_Humaninput)
            {
                this.dictionary_Table_Humaninput = new Dictionary<string, Table_Humaninput>();
            }
            else
            {
                this.dictionary_Table_Humaninput.Clear();
            }
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
        public Table_Humaninput GetTable_HumaninputByName(
            Expression_Node_String ec_TableName,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetTable_HumaninputByName",log_Reports);

            //
            //
            //
            //

            Table_Humaninput o_Table;
            string sTableName = ec_TableName.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports); ;
            if (this.dictionary_Table_Humaninput.ContainsKey(sTableName))
            {
                o_Table = this.dictionary_Table_Humaninput[sTableName];
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー928！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("[");

                s.Append(sTableName);

                s.Append("]という名前のテーブルは存在しませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Configuration(ec_TableName.Cur_Configuration.Parent));

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
            return o_Table;
        }

        /// <summary>
        /// テーブルを返します。NAME_FORM列値を指定してください。
        /// </summary>
        /// <param select="nTableName"></param>
        /// <param select="bRequired">該当しなかった場合にエラー扱いなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        public List<Table_Humaninput> GetTable_HumaninputByFormgroup(
            Expression_Node_String expr_KeyExpected,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetTable_HumaninputByFormgroup",log_Reports);
            //
            //

            List<Table_Humaninput> list_ResltTable = new List<Table_Humaninput>();

            if (null==expr_KeyExpected)
            {
                goto gt_EndMethod;
            }

            try
            {
                string str_KeyExpected = expr_KeyExpected.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                foreach (Table_Humaninput xenonTable in this.dictionary_Table_Humaninput.Values)
                {
                    if (null!=xenonTable.Tableunit &&
                        str_KeyExpected == xenonTable.Tableunit)
                    {
                        list_ResltTable.Add(xenonTable);
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                if (bRequired)
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー929！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("指定したレイアウト_グループ名[");

                t.Append(expr_KeyExpected.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));

                t.Append("]は、存在しませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configuration(expr_KeyExpected.Cur_Configuration.Parent));

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
            return list_ResltTable;
        }

        /// <summary>
        /// テーブルを返します。レイアウト_グループ名を指定してください。
        /// </summary>
        /// <param select="nTableName"></param>
        /// <param select="bRequired">該当しなかった場合にエラー扱いなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        public List<Table_Humaninput> GetTable_HumaninputByTypedata(
            Expression_Node_String expr_KeyExpected,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetTable_HumaninputByTypedata", log_Reports);
            //
            //

            List<Table_Humaninput> list_ResltTable = new List<Table_Humaninput>();
            string str_KeyExpected = "";

            if (null == expr_KeyExpected)
            {
                if (bRequired)
                {
                    goto gt_Error_NullExpected;
                }

                goto gt_EndMethod;
            }

            try
            {
                str_KeyExpected = expr_KeyExpected.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                foreach (Table_Humaninput xenonTable in this.dictionary_Table_Humaninput.Values)
                {
                    if (null != xenonTable.Typedata &&
                        str_KeyExpected == xenonTable.Typedata)
                    {
                        list_ResltTable.Add(xenonTable);
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                if (bRequired)
                {
                    // エラー
                    goto gt_Error_NotFound;
                }
            }

            if (list_ResltTable.Count<1)
            {
                // エラー
                goto gt_Error_NotFound;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullExpected:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー929！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("指定したキー比較値がヌルでした。[" + str_KeyExpected + "]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configuration(expr_KeyExpected.Cur_Configuration.Parent));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotFound:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー929！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("指定した"+NamesFld.S_TYPE_DATA+"[");

                t.Append(expr_KeyExpected.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));

                t.Append("]にヒットするテーブルは、存在しませんでした。\n\nもしかして？\n　・ツール設定ファイル、プロジェクトファイル、ファイル一覧ファイル、テーブルファイルをまだ読み込めていない？\n　・ファイル名が間違っている？");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configuration(expr_KeyExpected.Cur_Configuration.Parent));

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
            return list_ResltTable;
        }

        //────────────────────────────────────────

        /// <summary>
        /// テーブルを、コレクションに追加します。
        /// </summary>
        /// <param select="oTable"></param>
        public void AddTable_Humaninput(
            Table_Humaninput o_Table,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "AddTable_Humaninput", log_Reports);

            string sTableName_Trimed = o_Table.Name_Table.Trim();

            if(""==sTableName_Trimed)
            {
                // エラー
                goto gt_Error_NoName;
            }

            if (log_Reports.Successful)
            {
                if (!this.Dictionary_Table_Humaninput.ContainsKey(sTableName_Trimed))
                {
                    this.dictionary_Table_Humaninput[sTableName_Trimed] = o_Table;
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
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー930！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("テーブル名を指定してください。無名です。[");
                t.Append(o_Table.Name);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("テーブルを登録するには、テーブル名が必要です。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_OverlappedTableName:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー931！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("登録しようとしたテーブルの名前は、既に登録されていました。[");
                t.Append(o_Table.Name);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("同じ名前のテーブルは、２度登録できません。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configuration(o_Table));

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
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// このオブジェクトを所有するオブジェクト。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return owner_MemoryApplication;
            }
            set
            {
                owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────

        private Dictionary<string, Table_Humaninput> dictionary_Table_Humaninput;

        /// <summary>
        /// ユーザー定義テーブルの、名前付き一覧。
        /// </summary>
        public Dictionary<string, Table_Humaninput> Dictionary_Table_Humaninput
        {
            get
            {
                return this.dictionary_Table_Humaninput;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
