using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{

    /// <summary>
    /// ＜ｆｎｃ＞の子要素を解析。
    /// </summary>
    public class XToGivechapterandverse_C14_HubImpl : XToGivechapterandverse_C14_Hub
    {



        #region アクション
        //────────────────────────────────────────

        public void XToGivechapterandverse(
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
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "XToS",log_Reports);


            //
            //
            //
            //（）子要素
            //
            //
            //
            XmlNodeList child_XNl = cur_X.ChildNodes;

            string err_SName_CurNode = "";
            XmlElement err_XElm = null;
            Exception err_Excp = null;

            foreach (XmlNode child_XNode in child_XNl)
            {
                if (XmlNodeType.Element == child_XNode.NodeType)
                {
                    XmlElement xChild = (XmlElement)child_XNode;

                    string sName_Node = xChild.Name;


                    XToGivechapterandverse_C15_Elm to;

                    bool bHit = this.Dictionary_XToGivechapterandverse_ElmP.ContainsKey(sName_Node);
                    if (!bHit)
                    {
                        // 未該当＝エラー
                        err_SName_CurNode = cur_X.Name;
                        err_XElm = xChild;
                        goto gt_Error_UndefinedElement;
                    }

                    to = this.Dictionary_XToGivechapterandverse_ElmP[sName_Node];

                    if (log_Reports.BSuccessful)
                    {
                        try
                        {
                            to.XToGivechapterandverse(xChild, cur_Cf, memoryApplication, log_Reports);
                        }
                        catch (Exception ex)
                        {
                            //
                            // エラー。
                            err_XElm = xChild;
                            err_Excp = ex;
                            goto gt_Error_Exception;
                        }
                    }

                }

            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedElement:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー495！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("＜");
                s.Append(err_XElm.Name);
                s.Append("＞という子要素が指定されていますが、対応できません。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("＜");
                s.Append(err_SName_CurNode);
                s.Append("＞要素が対応できる子要素は次のとおり。");
                s.Append(Environment.NewLine);
                foreach (string key in this.Dictionary_XToGivechapterandverse_ElmP.Keys)
                {
                    s.Append("　＜");
                    s.Append(key);
                    s.Append("＞");
                    s.Append(Environment.NewLine);
                }
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Givechapterandverse(cur_Cf));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー90496！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("＜");
                s.Append(err_XElm.Name);
                s.Append("＞という要素を読み取った時、予想できないエラーが発生しました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_Givechapterandverse(cur_Cf));
                s.Append(r.Message_SException(err_Excp));

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
        #endregion


        
        #region プロパティー
        //────────────────────────────────────────

        private static Dictionary<string, XToGivechapterandverse_C15_Elm> dictionary_XToGivechapterandverse_ElmP;

        private Dictionary<string, XToGivechapterandverse_C15_Elm> Dictionary_XToGivechapterandverse_ElmP
        {
            get
            {
                //
                //
                //
                //（）メソッド開始
                //
                //
                //
                Log_Method log_Method = new Log_MethodImpl(0);
                Log_Reports d_Logging_ThisMethod = new Log_ReportsImpl(log_Method);
                log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "XToS_ElmPMap set",d_Logging_ThisMethod);


                if (null == dictionary_XToGivechapterandverse_ElmP)
                {
                    dictionary_XToGivechapterandverse_ElmP = new Dictionary<string, XToGivechapterandverse_C15_Elm>();

                    //
                    // TODO: 間違った入れ子関係も　読み取りしてしまうので、そこらへんのチェックも入れたい。
                    //

                    //
                    //
                    //
                    //子要素パーサー一覧
                    //
                    //
                    //

                    //
                    //＜ｆ－ｓｔｒ＞
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_F_STR, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_ElmP.Add(NamesNode.S_F_STR, to);
                    }

                    //
                    //＜ｆ－ｖａｒ＞
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_F_VAR, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_ElmP.Add(NamesNode.S_F_VAR, to);
                    }

                    //
                    //＜ｆ－ｐａｒａｍ＞
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_F_PARAM, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_ElmP.Add(NamesNode.S_F_PARAM, to);
                    }

                    //
                    //＜ｆｎｃ＞
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_FNC, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_ElmP.Add(NamesNode.S_FNC, to);
                    }

                    //
                    //＜ｄｅｆ－ｐａｒａｍ＞
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_DEF_PARAM, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_ElmP.Add(NamesNode.S_DEF_PARAM, to);
                    }

                    //
                    //＜ａｒｇ＞　※＜ｆｎｃ＞＜ａｃｔｉｏｎ＞専用の子要素。
                    //
                    {
                        XToGivechapterandverse_C15_Elm to = XToGivechapterandverse_Collection.GetTranslatorByNodeName(NamesNode.S_ARG, d_Logging_ThisMethod);
                        dictionary_XToGivechapterandverse_ElmP.Add(NamesNode.S_ARG, to);
                    }
                }

                //
                //
                log_Method.EndMethod(d_Logging_ThisMethod);
                d_Logging_ThisMethod.EndLogging(log_Method);

                return dictionary_XToGivechapterandverse_ElmP;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
