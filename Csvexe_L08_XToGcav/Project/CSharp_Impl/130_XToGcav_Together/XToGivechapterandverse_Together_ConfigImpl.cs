using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;//XmlNode
using Xenon.Syntax;
using Xenon.Middle;


namespace Xenon.XToGcav
{
    /// <summary>
    /// (Stg) 設定ファイル
    /// 
    /// X→S。
    /// 
    /// ※コントロールの内容を最新表示するモデルです。
    /// </summary>
    public class XToConfigurationtree_Together_ConfigImpl : XToConfigurationtree_Together
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public XToConfigurationtree_Together_ConfigImpl()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// Rfrファイル読取。
        /// 
        /// 呼び出し元で、memoryApplicationに Stg をセットする。
        /// </summary>
        public Configurationtree_Node XToConfigurationtree(
            string sFpatha,//絶対ファイルパス
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToS",log_Reports);
            //
            //

            // リローディング設定。
            Configurationtree_Node sTg_Cnf = new Configurationtree_NodeImpl(NamesNode.S_CODEFILE_TOGETHERS, new Configurationtree_NodeImpl(sFpatha, null));

            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();

            XmlElement err_XTop;
            Exception err_Excp;
            try
            {
                xDoc.Load(sFpatha);


                // ルート要素を取得
                System.Xml.XmlElement xRoot = xDoc.DocumentElement;

                // スクリプトファイルのバージョンチェック。（関数登録ファイル）
                ValuesAttr.Test_Codefileversion(
                    xRoot.GetAttribute(PmNames.S_CODEFILE_VERSION.Name_Attribute),
                    log_Reports,
                    new Configurationtree_NodeImpl(sFpatha, null),
                    NamesNode.S_CODEFILE_TOGETHERS
                    );

                if (log_Reports.Successful)
                {
                    XmlNodeList xTopNL = xRoot.ChildNodes;

                    foreach (XmlNode xTopNode in xTopNL)
                    {
                        if (XmlNodeType.Element == xTopNode.NodeType)
                        {
                            XmlElement xTop = (XmlElement)xTopNode;

                            if (NamesNode.S_TOGETHER == xTop.Name)
                            {
                                XToConfigurationtree_C15_Elm to = XToConfigurationtree_Collection.GetTranslatorByNodeName(NamesNode.S_TOGETHER, log_Reports);
                                to.XToConfigurationtree(
                                    xTop,
                                    sTg_Cnf,
                                    memoryApplication,
                                    log_Reports
                                    );

                            }
                            else
                            {
                                err_XTop = xTop;
                                goto gt_Error_NotSupportedChild;
                            }
                        }
                    }
                }
            }
            catch (System.IO.IOException ex)
            {
                err_Excp = ex;
                goto gt_Error_IOException;
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
        gt_Error_NotSupportedChild:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー387！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("トゥゲザー登録ファイルに、<" + NamesNode.S_TOGETHER + ">要素以外の要素[");
                t.Append(err_XTop.Name);
                t.Append("]が含まれていました。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configurationtree(sTg_Cnf));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_IOException:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー388！", log_Method);

                StringBuilder t = new StringBuilder();

                t.Append("ファイルが見つかりません。");
                t.Append(Environment.NewLine);
                t.Append("absoluteFilePath=[");
                t.Append(sFpatha);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configurationtree(sTg_Cnf));
                t.Append(r.Message_SException(err_Excp));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー344！", log_Method);

                StringBuilder t = new StringBuilder();

                t.Append("読み込むファイルを間違えているかも？");
                t.Append(Environment.NewLine);
                t.Append("トゥゲザー登録ファイル（絶対パス）=[" + sFpatha + "]");
                t.Append(Environment.NewLine);
                t.Append("ex.Message=[" + err_Excp.Message + "]");
                t.Append(Environment.NewLine);
                t.Append("ex.GetType().Name=[" + err_Excp.GetType().Name + "]");

                // ヒント
                t.Append(r.Message_Configurationtree(sTg_Cnf));
                t.Append(r.Message_SException(err_Excp));

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
            return sTg_Cnf;
        }

        //────────────────────────────────────────
        #endregion



    }

}
