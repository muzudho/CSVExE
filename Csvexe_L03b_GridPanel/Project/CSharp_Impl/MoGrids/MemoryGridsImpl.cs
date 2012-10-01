using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.GridPanel
{
    /// <summary>
    /// グリッド エリアのコレクション。
    /// 
    /// (Model Of Grids Impl)
    /// </summary>
    public class MemoryGridsImpl : MemoryGrids
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// 空の状態に設定します。
        /// </summary>
        public void Clear()
        {
            this.Dictionary_Item.Clear();
        }

        //────────────────────────────────────────

        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// グリッド領域を追加します。（エラー対応処理付き）
        /// </summary>
        /// <param name="gridAreaName"></param>
        /// <param name="gridArea"></param>
        /// <param name="log_Reports"></param>
        public void Add(
            string sName_Gridarea,
            Grid gridArea,
            Log_Reports log_Reports,
            string sLogStack
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_GridPanel.Name_Library, this, "Add",log_Reports);

            Exception err_Excp;
            try
            {
                this.Dictionary_Item.Add(sName_Gridarea, gridArea);
            }
            catch (Exception e)
            {
                // エラー
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
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー50404！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("グリッドパネルの利用");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(sName_Gridarea);
                t.Append("]要素の追加時に失敗しました。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("エラー：");
                t.Append(err_Excp.Message);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("実行経路ヒント：");
                t.Append(sLogStack);

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, Grid> dictionary_Item;

        /// <summary>
        /// グリッド領域。
        /// </summary>
        public Dictionary<string, Grid> Dictionary_Item
        {
            set
            {
                dictionary_Item = value;
            }
            get
            {
                if (null == dictionary_Item)
                {
                    dictionary_Item = new Dictionary<string, Grid>();
                }
                return dictionary_Item;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
