using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{
    public delegate void DLGT_SAllAttrs(string sKey, string sValue, ref bool bBreak);


    public class DictionaryGivechapterandverse_StringImpl : DictionaryGivechapterandverse_String
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public DictionaryGivechapterandverse_StringImpl(Givechapterandverse_Node owner_Gcav)
        {
            this.owner_Givechapterandverse = owner_Gcav;
            this.dictionaryS = new Dictionary<string, string>();
        }

        //────────────────────────────────────────

        /// <summary>
        /// new された直後の内容に戻します。
        /// </summary>
        public void Clear(Givechapterandverse_Node owner_Gcav, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "Clear", log_Reports);

            //
            //

            this.owner_Givechapterandverse = null;
            this.dictionaryS.Clear();

            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// attr系要素の追加。
        /// 
        /// 既に追加されている要素は、追加できない。
        /// </summary>
        public void Add(
            string sKey,
            string sValue,
            Givechapterandverse_Node gcav_Value,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "Add",log_Reports);

            //
            //

            if (!this.dictionaryS.ContainsKey(sKey))
            {
                this.dictionaryS.Add(sKey, sValue);
            }
            else
            {
                if (bRequired)
                {
                    // エラー
                    goto gt_Error_Duplicate;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Duplicate:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー345！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("要素<");
                s.Append(this.owner_Givechapterandverse.SName);
                s.Append(">に、同じ名前の属性が重複していました。");
                s.NewLine();

                s.Append("入れようとした要素の名前=[");
                s.Append(sKey);
                s.Append("]");
                s.NewLine();

                // ヒント
                s.Append(r.Message_Givechapterandverse(gcav_Value));

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
        /// attr系要素の追加。
        /// </summary>
        public void Set(
            string sKey,
            string sValue,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "Set",log_Reports);

            //
            //
            //
            //

            this.dictionaryS[sKey] = sValue;

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 空白は、無いのと同じに扱う。
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="sResult"></param>
        /// <param name="bRequired"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public bool TryGetValue(
            PmName pmName,//Pmオブジェクトにしたい。
            out string sResult,
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "TryGetValue",log_Reports);
            //


            bool bHit = this.dictionaryS.TryGetValue(pmName.SName_Pm, out sResult);
            if (!bHit || "" == sResult)
            {
                if (bRequired)
                {
                    goto gt_Error_NoHit;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NoHit:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("Er:004;", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();


                s.Append("name=\"");
                s.Append(pmName.SName_Attr);
                s.Append("\" 属性か、または <arg name=\"");
                s.Append(pmName.SName_Pm);
                s.Append("\" ～> 要素のどちらかが必要でしたが、違う方を書いたか、記述されていないか、空文字列でした。");
                s.NewLine();
                s.NewLine();

                if (null != this.owner_Givechapterandverse)
                {
                    //ヒント
                    s.Append(r.Message_Givechapterandverse(this.owner_Givechapterandverse));
                }
                else
                {
                    s.Append("どの要素かは不明。");
                    s.NewLine();
                }

                // ヒント

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
            return bHit;
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        public bool ContainsKey(string sKey)
        {
            return this.dictionaryS.ContainsKey(sKey);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// このオブジェクトを所有しているオブジェクト。
        /// </summary>
        private Givechapterandverse_Node owner_Givechapterandverse;

        //────────────────────────────────────────

        private Dictionary<string, string> dictionaryS;

        /// <summary>
        /// 属性＝””
        /// </summary>
        public Dictionary<string, string> Dictionary_SAttribute
        {
            get
            {
                return dictionaryS;
            }
            set
            {
                dictionaryS = value;
            }
        }

        public void ForEach(DLGT_SAllAttrs dlgt1)
        {
            bool bBreak = false;
            foreach (KeyValuePair<string, string> kvp in this.Dictionary_SAttribute)
            {
                dlgt1(kvp.Key, kvp.Value, ref bBreak);

                if (bBreak)
                {
                    break;
                }
            }
        }

        //────────────────────────────────────────

        public int NCount
        {
            get
            {
                return this.dictionaryS.Count;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
