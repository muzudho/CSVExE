﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.MiddleImpl
{
    public class MemoryCodefilesImpl : MemoryCodefiles
    {



        #region 生成と破棄
        //────────────────────────────────────────
        
        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryCodefilesImpl()
        {
            this.dictionary_Table = new Dictionary<string, MemoryCodefileinfo>();
        }

        /// <summary>
        /// クリアーします。
        /// </summary>
        public void Clear()
        {
            this.dictionary_Table.Clear();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Add(
            MemoryCodefileinfo moCodefileInfo,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "Add",log_Reports);

            string sName_Trimed = moCodefileInfo.SName.Trim();

            if ("" == sName_Trimed)
            {
                // エラー
                goto gt_Error_NoName;
            }

            if (log_Reports.BSuccessful)
            {
                if (!this.Dictionary_Table.ContainsKey(sName_Trimed))
                {
                    this.Dictionary_Table[sName_Trimed] = moCodefileInfo;
                }
                else
                {
                    // エラー
                    goto gt_Error_OverlappedName;
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
                r.SetTitle("▲エラー323！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("スクリプトファイル呼出名を指定してください。無名です。[");
                s.Append(moCodefileInfo.SName);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_OverlappedName:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー322！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("登録しようとしたスクリプトファイル呼出名は、既に登録されていました。[");
                s.Append(moCodefileInfo.SName);
                s.Append("]");
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
        }

        //────────────────────────────────────────

        /// <summary>
        /// スクリプトファイル情報を返します。TYPE_DATA値を指定してください。
        /// </summary>
        /// <param select="nTableName"></param>
        /// <param select="bRequired">該当しなかった場合にエラー扱いなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        public List<MemoryCodefileinfo> GetCodefileinfoByTypedata(
            Expression_Node_String ec_Typedata,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.SName_Library, this, "GetCodefileinfoByTypedata",log_Reports);
            //
            //

            List<MemoryCodefileinfo> result = new List<MemoryCodefileinfo>();

            if (null == ec_Typedata)
            {
                goto gt_EndMethod;
            }

            try
            {
                string sExpectedTypedata = ec_Typedata.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                foreach (MemoryCodefileinfo codefile in this.Dictionary_Table.Values)
                {
                    if (sExpectedTypedata == codefile.STypedata)
                    {
                        result.Add(codefile);
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
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー927！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定したタイプデータ名[");

                s.Append(ec_Typedata.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));

                s.Append("]は、存在しませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Givechapterandverse(ec_Typedata.Cur_Givechapterandverse.Parent_Givechapterandverse));

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
            return result;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, MemoryCodefileinfo> dictionary_Table;

        /// <summary>
        /// スクリプトファイルの行データの連想配列。
        /// </summary>
        public Dictionary<string, MemoryCodefileinfo> Dictionary_Table
        {
            get
            {
                return this.dictionary_Table;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}