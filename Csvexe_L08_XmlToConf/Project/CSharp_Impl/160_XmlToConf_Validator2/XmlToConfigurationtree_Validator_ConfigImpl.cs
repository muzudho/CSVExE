using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;

namespace Xenon.XmlToConf
{

    /// <summary>
    /// varidation設定ファイル X → S。
    /// </summary>
    public class XmlToConfigurationtree_Validator_ConfigImpl : XmlToConfigurationtree_V51_Config
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// X → S。
        /// </summary>
        /// <param name="sFpatha">絶対ファイルパス</param>
        /// <param name="memoryApplication"></param>
        /// <param name="log_Reports"></param>
        public void XmlToConfigurationtree(
            string sFpatha,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_XmlToConf.Name_Library, this, "XmlToConfigurationtree", log_Reports);
            //
            //

            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            Exception err_Excp = null;

            if (System.IO.File.Exists(sFpatha))
            {
                try
                {
                    xDoc.Load(sFpatha);
                }
                catch (System.IO.IOException ex)
                {
                    //
                    // エラー。
                    err_Excp = ex;
                    goto gt_Error_IoException01;
                }
                catch (ArgumentException ex)
                {
                    //
                    // エラー。
                    err_Excp = ex;
                    goto gt_Error_ArgException01;
                }
                catch (Exception ex)
                {
                    //
                    // エラー。
                    err_Excp = ex;
                    goto gt_Error_Exception91;
                }
            }
            else
            {
                // エラー。
                goto gt_Error_NotFoundFile;
            }






            XmlNode err_XTopNode = null;

            if (log_Reports.Successful)
            {
                // new した直後の内容に戻します。
                memoryApplication.MemoryValidators.Configurationtree_Validatorsconfig.Clear( NamesNode.S_CODEFILE_VALIDATORS, new Configurationtree_NodeImpl(sFpatha, null), log_Reports);


                // ルート要素を取得
                System.Xml.XmlElement xRoot = xDoc.DocumentElement;

                // スクリプトファイルのバージョンチェック。（バリデーター登録ファイル）
                ValuesAttr.Test_Codefileversion(
                    xRoot.GetAttribute(PmNames.S_CODEFILE_VERSION.Name_Attribute),
                    log_Reports,
                    new Configurationtree_NodeImpl(sFpatha, null),
                    NamesNode.S_CODEFILE_VALIDATORS
                    );

                //
                //＜ｃｏｎｔｒｏｌ＞要素を列挙
                //
                XmlNodeList xNl_Top = xRoot.ChildNodes;

                foreach(XmlNode xTopNode in xNl_Top)
                {
                    err_XTopNode = xTopNode;

                    if(XmlNodeType.Element == xTopNode.NodeType)
                    {
                        if (NamesNode.S_CONTROL1 == xTopNode.Name)
                        {
                            XmlElement xTop = (XmlElement)xTopNode;

                            //
                            //
                            //
                            //＜ｃｏｎｔｒｏｌ＞要素
                            //
                            //
                            //

                            XmlToConfigurationtree_C15_Elm to = XmlToConfigurationtree_Collection.GetTranslatorByNodeName(xTopNode.Name, log_Reports);
                            to.XmlToConfigurationtree(
                                xTop,
                                memoryApplication.MemoryValidators.Configurationtree_Validatorsconfig,
                                memoryApplication,
                                log_Reports
                                );
                        }
                        else
                        {
                            //
                            // エラー。
                            goto gt_Error_UndefinedChild04;
                        }
                    }
                }


            }
            else
            {
                // new した直後の内容に戻します。
                memoryApplication.MemoryValidators.Configurationtree_Validatorsconfig.Clear(NamesNode.S_CODEFILE_VALIDATORS, new Configurationtree_NodeImpl("!ハードコーディング_"+log_Method.Fullname, null), log_Reports);
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundFile:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー31！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("バリデーション設定ファイル読取時。");
                s.Append(Environment.NewLine);
                s.Append("ファイルが見つかりません。");
                s.Append(Environment.NewLine);
                s.Append("[");
                s.Append(sFpatha);
                s.Append("]");

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_IoException01:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー34！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("バリデーション設定ファイル読取時。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("ファイルが見つかりません：" + err_Excp.Message);
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_ArgException01:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー397！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("バリデーション設定ファイル読取時。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("読み込むファイルを間違えているかも？：" + err_Excp.Message);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("absoluteFilePath=[");
                t.Append(sFpatha);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedChild04:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー398！", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("バリデーション設定ファイル(Xv)に、<" + NamesNode.S_CONTROL1 + ">要素以外の要素[");
                sb.Append(err_XTopNode.Name);
                sb.Append("]が含まれていました。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // ヒント

                r.Message = sb.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception91:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー399！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("何らかのエラー。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
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
        }

        //────────────────────────────────────────
        #endregion



    }
}
