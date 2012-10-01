using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.MiddleImpl
{
    /// <summary>
    /// ＜input＞要素の名前つきリスト。
    /// </summary>
    public class Dictionary_Fsetvar_GivechapterandverseImpl : Dictionary_Fsetvar_Givechapterandverse
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Dictionary_Fsetvar_GivechapterandverseImpl()
        {
            Givechapterandverse_Node parent_Cf_Null = null;//TODO:this
            this.list_ChildGivechapterandverse = new ListGivechapterandverse_NodeImpl(parent_Cf_Null);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// input要素を、name属性を検索キーにして検索し、取得します。
        /// 該当がなければヌルを返します。
        /// </summary>
        /// <param name="inputName">name属性</param>
        /// <param name="bRequired">該当するデータがない場合、エラー</param>
        /// <returns></returns>
        public Givechapterandverse_Node GetFsetvar(
            string sNameVar,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetFsetvar",log_Reports);

            //
            //

            Givechapterandverse_Node cf_Result = null;

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("子＜ｆ－ｓｅｔ－ｖａｒ＞要素数=[" + this.List_ChildGivechapterandverse.Count + "]");
            }

            this.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node cf_Child, ref bool bBreak)
            {
                string sNamevar1;
                cf_Child.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME_VAR, out sNamevar1, true, log_Reports);

                if (sNamevar1 == sNameVar)
                {
                    // input要素のname-var属性を検索し、該当するinput要素があれば。
                    cf_Result = cf_Child;
                }
            });

            if (null == cf_Result)
            {
                if (bRequired)
                {
                    // エラーとして扱います。
                    goto gt_Error_Null;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Null:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー261！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("指定されたinput要素＝[" + sNameVar + "]は存在しませんでした。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("もしかして？");
                s.Append(Environment.NewLine);
                s.Append("　・名前のスペルは合っていますか？");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);


                s.Append("input要素名=[");
                s.Append(sNameVar);
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
            return cf_Result;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private ListGivechapterandverse_Node list_ChildGivechapterandverse;

        /// <summary>
        /// input要素の名前つきリスト。
        /// </summary>
        public ListGivechapterandverse_Node List_ChildGivechapterandverse
        {
            get
            {
                return list_ChildGivechapterandverse;
            }
        }

        //────────────────────────────────────────
        #endregion



    }



}
