using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode
using System.Windows.Forms;

using Xenon.Syntax;//N_FilePath
using Xenon.Middle;


namespace Xenon.XToGcav
{

    /// <summary>
    /// </summary>
    public class XToGivechapterandverse_C11_ConfigImpl : XToGivechapterandverse_C11_Config
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// コントロール名と、設定ファイルパスが指定されるので、
        /// 検索して、設定。
        /// </summary>
        /// <param name="sFcName"></param>
        /// <param name="sFpathH_F">絶対ファイルパス（F）手入力</param>
        /// <param name="sFpatha_F">絶対ファイルパス（F）</param>
        /// <param name="s_FcConfig"></param>
        /// <param name="oFormsFolderPath"></param>
        /// <param name="owner_MemoryApplication"></param>
        /// <param name="log_Reports"></param>
        public void XToGivechapterandverse(
            string sName_Control,
            string sFpathH_F,
            string sFpatha_F,
            Givechapterandverse_Node cf_ControlConfig,
            Expression_Node_Filepath ec_Fopath_Forms,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.SName_Library, this, "XToCf",log_Reports);
            //
            //

            System.Xml.XmlDocument xDoc = null;
            Exception err_Excp = null;
            if (log_Reports.BSuccessful)
            {
                // 正常時

                xDoc = new System.Xml.XmlDocument();

                if (System.IO.File.Exists(sFpatha_F))
                {
                    try
                    {
                        xDoc.Load(sFpatha_F);
                    }
                    catch (System.IO.IOException ex)
                    {
                        //
                        // エラー。
                        err_Excp = ex;
                        goto gt_Error_IoException;
                    }
                    catch (System.Xml.XmlException ex)
                    {
                        //
                        // エラー。
                        err_Excp = ex;
                        goto gt_Error_XmlException;
                    }
                    catch (Exception ex)
                    {
                        //
                        // エラー。
                        err_Excp = ex;
                        goto gt_Error_Exception01;
                    }
                }
                else
                {
                    // エラー。
                    goto gt_Error_NotFoundFile;
                }

            }


            //
            // コントロール自体は、Aa_Forms.csvを読み取って
            // 既に追加済みです。


            XmlElement err_XElm = null;
            if (log_Reports.BSuccessful)
            {
                // 正常時

                XToGivechapterandverse_C12_ControlImpl_ to = new XToGivechapterandverse_C12_ControlImpl_();

                try
                {
                    // ルート要素を取得
                    System.Xml.XmlElement xRoot = xDoc.DocumentElement;

                    // ＜ｓｃｒｉｐｔｆｉｌｅ－ｃｏｎｔｒｏｌｓ　ｓｃｒｉｐｔｆｉｌｅ－ｖｅｒｓｉｏｎ＝”１．０”＞　を期待。
                    if (NamesNode.S_CODEFILE_CONTROLS != xRoot.Name)
                    {
                        //エラー
                        err_XElm = xRoot;
                        goto gt_Error_Root;
                    }

                    // スクリプトファイルのバージョンチェック。（コントロール設定ファイル）
                    ValuesAttr.Test_Codefileversion(
                        xRoot.GetAttribute(PmNames.S_CODEFILE_VERSION.SName_Attr),
                        log_Reports,
                        cf_ControlConfig,
                        NamesNode.S_CODEFILE_CONTROLS
                        );


                    //　ルート要素の下の子＜ｃｏｎｔｒｏｌ＞要素

                    XmlNodeList xNl_Top = xRoot.ChildNodes;

                    foreach (XmlNode xTopNode in xNl_Top)
                    {
                        if (XmlNodeType.Element == xTopNode.NodeType)
                        {
                            XmlElement xTop = (XmlElement)xTopNode;

                            if (NamesNode.S_CONTROL1 == xTop.Name)
                            {
                                to.XToGivechapterandverse(
                                    sName_Control,
                                    cf_ControlConfig,
                                    xTop,
                                    owner_MemoryApplication,
                                    log_Reports
                                    );

                            }
                            else
                            {
                                //
                                // エラー。
                                err_XElm = xTop;
                                goto gt_Error_UndefinedChildElement;
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    //
                    // エラー。
                    err_Excp = ex;
                    goto gt_Error_Exception02;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Root:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー502！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("コントロール設定ファイルのルート要素が、期待しないものでした。");
                s.NewLine();
                s.NewLine();
                s.Append("期待したルート要素：<");
                s.Append(NamesNode.S_CODEFILE_CONTROLS);
                s.Append(">");
                s.NewLine();
                s.NewLine();
                s.Append("実際のルート要素：<");
                s.Append(err_XElm.Name);
                s.Append(">");
                s.NewLine();
                s.NewLine();



                s.Append("コントロール設定ファイル：");
                s.Append(sFpatha_F);
                s.NewLine();
                s.NewLine();


                // ヒント
                s.Append(r.Message_SException(err_Excp));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotFoundFile:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー501！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("指定のフォーム[");
                s.Append(sName_Control);
                s.Append("]の設定ファイルが見つかりません。");
                s.NewLine();
                s.NewLine();

                s.Append("ファイル パスか、フォルダー パスを確認してください。");
                s.NewLine();

                s.Append("フォームズ_フォルダー：");
                s.NewLine();
                s.Append("　　");
                s.Append(ec_Fopath_Forms.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                s.NewLine();
                s.NewLine();

                s.Append("コントロール設定ファイル（入力ママ）：");
                s.NewLine();
                s.Append("　　");
                s.Append(sFpathH_F);
                s.NewLine();
                s.NewLine();


                s.Append("コントロール設定ファイル（フォームズ_フォルダーと結合後）：");
                s.NewLine();
                s.Append("　　");
                s.Append(sFpatha_F);
                s.NewLine();
                s.NewLine();


                s.NewLine();

                s.Append("コントロール設定ファイル(Fcnf)を読み込もうとしたとき。");
                s.NewLine();
                s.NewLine();

                // ヒント
                s.Append(r.Message_SException(err_Excp));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_IoException:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー392！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();

                t.Append("レイアウト設定ファイルの[");
                t.Append(sName_Control);
                t.Append("]レコードを元に、");
                t.NewLine();
                t.Append("コントロールの設定ファイルを読み込もうとしたとき。");
                t.NewLine();
                t.NewLine();

                t.Append("ファイル パスか、フォルダー パスを確認してください。");
                t.NewLine();
                t.Append("ファイルが見つかりませんでした。");
                t.NewLine();

                t.Append("フォームズ_フォルダー：");
                t.NewLine();
                t.Append("　　");
                t.Append(ec_Fopath_Forms.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                t.NewLine();
                t.NewLine();

                t.Append("コントロール設定ファイル（入力ママ）：");
                t.NewLine();
                t.Append("　　");
                t.Append(sFpathH_F);
                t.NewLine();
                t.NewLine();


                t.Append("コントロール設定ファイル（フォームズ_フォルダーと結合後）：");
                t.NewLine();
                t.Append("　　");
                t.Append(sFpatha_F);
                t.NewLine();
                t.NewLine();


                t.NewLine();

                t.Append("コントロール設定ファイル(Fcnf)を読み込もうとしたとき。");
                t.NewLine();
                t.NewLine();

                // ヒント
                t.Append(r.Message_SException(err_Excp));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_XmlException:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー393！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("エラー。XMLの書き方にミスがあるかも？");
                s.NewLine();
                s.NewLine();

                s.Append("コントロール設定ファイル：");
                s.Append(sFpatha_F);
                s.NewLine();
                s.NewLine();

                // ヒント
                s.Append(r.Message_SException(err_Excp));

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception01:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー394！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("想定外のエラー。");
                t.NewLine();
                t.NewLine();

                // ヒント
                t.Append(r.Message_SException(err_Excp));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception02:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー395！", log_Method);

                Log_TextIndented t = new Log_TextIndentedImpl();
                t.Append("想定外のエラー。");
                t.NewLine();
                t.NewLine();

                // ヒント
                t.Append(r.Message_SException(err_Excp));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedChildElement:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle( "▲エラー1494！", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("コントロール設定ファイルに、<");
                sb.Append(NamesNode.S_CONTROL1);
                sb.Append(">要素以外の要素[");
                sb.Append(err_XElm.Name);
                sb.Append("]が含まれていました。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // ヒント

                r.SMessage = sb.ToString();
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
