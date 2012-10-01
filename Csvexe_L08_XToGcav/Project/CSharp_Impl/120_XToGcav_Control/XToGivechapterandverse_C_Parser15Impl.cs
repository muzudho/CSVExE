using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.XToGcav
{
    public class XToGivechapterandverse_C_Parser15Impl : XToGivechapterandverse_C15_Elm
    {



        #region 生成と破棄
        //────────────────────────────────────────

        protected virtual Givechapterandverse_Node CreateMyself(
            XmlElement cur_X, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            Givechapterandverse_Node cf_Cur = new Givechapterandverse_NodeImpl(cur_X.Name, parent_Cf);
            return cf_Cur;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public virtual void XToGivechapterandverse(
            XmlElement cur_X,
            Givechapterandverse_Node parent_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToS",log_Reports);
            //
            //



            //
            //
            //
            // 自
            //
            //
            //
            Givechapterandverse_Node cur_Cf;
            if (log_Reports.Successful)
            {
                cur_Cf = this.CreateMyself(cur_X, parent_Cf, memoryApplication, log_Reports);
            }
            else
            {
                cur_Cf = null;
            }



            //
            //
            //
            // 属性
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Parse_SAttribute(cur_X, cur_Cf, memoryApplication, log_Reports);
            }



            //
            //
            //
            // 属性テスト
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Test_Attributes(cur_X, cur_Cf, log_Reports);
            }



            //
            //
            //
            // 子
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Parse_ChildNodes(cur_X, cur_Cf, memoryApplication, log_Reports);
            }



            //
            //
            //
            // 子テスト
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Test_ChildNodes(cur_X, cur_Cf, log_Reports);
            }



            //
            //
            //
            // 親へ連結。
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.LinkToParent(cur_Cf, parent_Cf, memoryApplication, log_Reports);
            }



            goto gt_EndMethod;
            //
            //
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// ＜要素名　属性＝”☆”＞　の、属性部分を解析。
        /// </summary>
        /// <param name="x_Cur"></param>
        /// <param name="s_Cur"></param>
        /// <param name="memoryApplication"></param>
        /// <param name="log_Reports"></param>
        protected virtual void Parse_SAttribute(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "Parse_SAttr",log_Reports);


            //
            //
            //
            //（）全属性解析
            //
            //
            //
            XmlAttribute err_XAttr = null;
            foreach (XmlAttribute xAttr in cur_X.Attributes)
            {
                if (this.List_SName_Attribute.Contains(xAttr.Name))
                {
                    // ①
                    PmName pmName = PmNames.FromSAttribute(xAttr.Name);
                    if (null != pmName)
                    {
                        cur_Cf.Dictionary_Attribute_Givechapterandverse.Add(pmName.Name_Pm, xAttr.Value, cur_Cf, true, log_Reports);
                    }
                    else
                    {
                        // エラー
                        err_XAttr = xAttr;
                        goto gt_Error_UndefinedAttr;

                        //// 【廃止方針】
                        //if (log_Method.CanInfo())
                        //{
                        //    log_Method.WriteInfo_ToConsole("廃止方針のAdd([" + x_Attr.Name + "], [" + x_Attr.Value + "])");
                        //}

                        //throw new Exception("廃止方針のAdd([" + x_Attr.Name + "], [" + x_Attr.Value + "])");
                        //s_Cur.Dictionary_Attribute_Givechapterandverse.Add(x_Attr.Name, x_Attr.Value, s_Cur, true, log_Reports);
                    }
                }
                else
                {
                    err_XAttr = xAttr;
                    goto gt_Error_UndefinedAttr;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedAttr:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー336！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("[");
                s.Append(cur_X.Name);
                s.Append("]要素を探索中に、未対応の属性が記述されていました。");
                s.Newline();

                s.Append("xAttr.Name=[");
                s.Append(err_XAttr.Name);
                s.Append("]");
                s.Newline();
                s.Newline();

                // ヒント
                s.Append(r.Message_Givechapterandverse(cur_Cf));

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
        }

        //────────────────────────────────────────

        /// <summary>
        /// 必須属性の有無テスト。
        /// </summary>
        /// <param name="x_Cur"></param>
        /// <param name="s_Cur"></param>
        /// <param name="log_Reports"></param>
        protected virtual void Test_Attributes(XmlElement cur_X, Givechapterandverse_Node cur_Cf, Log_Reports log_Reports)
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "Test_Attributes",log_Reports);

            //
            // 必須属性の有無テスト
            //
            string err_SName_Attr;
            if (null != this.List_SName_RequiredPm)
            {
                foreach (string sName_Attr in this.List_SName_RequiredPm)
                {
                    if (!cur_Cf.Dictionary_Attribute_Givechapterandverse.ContainsKey(sName_Attr))
                    {
                        // エラー。
                        err_SName_Attr = sName_Attr;
                        goto gt_Error_NothingAttr;
                    }
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NothingAttr:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー325！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("　[" + cur_X.Name + "]要素には、[" + err_SName_Attr + "]属性を記入してください。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Givechapterandverse(cur_Cf));

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

        protected virtual void Parse_ChildNodes(
            XmlElement cur_X,
            Givechapterandverse_Node cur_Cf,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            XToGivechapterandverse_C14_Hub to = new XToGivechapterandverse_C14_HubImpl();
            to.XToGivechapterandverse(cur_X, cur_Cf, memoryApplication, log_Reports);
        }

        //────────────────────────────────────────

        protected virtual void Test_ChildNodes(XmlElement cur_X, Givechapterandverse_Node cur_Cf, Log_Reports log_Reports)
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// 親要素に、この要素を追加。
        /// </summary>
        protected virtual void LinkToParent(
            Givechapterandverse_Node cur_Cf, Givechapterandverse_Node parent_Cf, MemoryApplication memoryApplication, Log_Reports log_Reports)
        {
            parent_Cf.List_ChildGivechapterandverse.Add(cur_Cf, log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// string属性名一覧。
        /// </summary>
        private List<string> list_SName_Attribute;

        public virtual List<string> List_SName_Attribute
        {
            get
            {
                return this.list_SName_Attribute;
            }
            set
            {
                this.list_SName_Attribute = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 必須の属性名一覧。
        /// </summary>
        private List<string> list_SName_RequiredPm;

        public virtual List<string> List_SName_RequiredPm
        {
            get
            {
                return this.list_SName_RequiredPm;
            }
            set
            {
                this.list_SName_RequiredPm = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// pm属性名一覧。
        /// </summary>
        private List<PmNameItem> list_PmName;

        public virtual List<PmNameItem> List_PmName
        {
            get
            {
                return this.list_PmName;
            }
            set
            {
                this.list_PmName = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
