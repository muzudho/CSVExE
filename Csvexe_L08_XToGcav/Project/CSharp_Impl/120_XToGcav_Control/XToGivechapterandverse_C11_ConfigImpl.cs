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
    public class XToConfigurationtree_C11_ConfigImpl : XToConfigurationtree_C11_Config
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
        public void XToConfigurationtree(
            string sName_Control,
            string sFpathH_F,
            string sFpatha_F,
            Configurationtree_Node cf_ControlConfig,
            Expression_Node_Filepath ec_Fopath_Forms,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "XToCf",log_Reports);
            //
            //

            System.Xml.XmlDocument xDoc = null;
            Exception err_Excp = null;
            if (log_Reports.Successful)
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
            if (log_Reports.Successful)
            {
                // 正常時

                XToConfigurationtree_C12_ControlImpl_ to = new XToConfigurationtree_C12_ControlImpl_();

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
                        xRoot.GetAttribute(PmNames.S_CODEFILE_VERSION.Name_Attribute),
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
                                to.XToConfigurationtree(
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
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, NamesNode.S_CODEFILE_CONTROLS, log_Reports);//期待したルート要素名
                tmpl.SetParameter(2, err_XElm.Name, log_Reports);//実際のルート要素名
                tmpl.SetParameter(3, sFpatha_F, log_Reports);//コントロール設定絶対ファイルパス
                tmpl.SetParameter(4, Log_RecordReportsImpl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                owner_MemoryApplication.CreateErrorReport("Er:8010;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotFoundFile:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sName_Control, log_Reports);//コントロール名
                tmpl.SetParameter(2, ec_Fopath_Forms.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//Formsフォルダーパス
                tmpl.SetParameter(3, sFpathH_F, log_Reports);//コントロール設定ファイル（入力ママ）
                tmpl.SetParameter(4, sFpatha_F, log_Reports);//コントロール設定ファイル絶対パス（Formsフォルダーと結合後）
                tmpl.SetParameter(5, Log_RecordReportsImpl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                owner_MemoryApplication.CreateErrorReport("Er:8011;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_IoException:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sName_Control, log_Reports);//コントロール名
                tmpl.SetParameter(2, ec_Fopath_Forms.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports), log_Reports);//Formsフォルダーパス
                tmpl.SetParameter(3, sFpathH_F, log_Reports);//コントロール設定ファイル（入力ママ）
                tmpl.SetParameter(4, sFpatha_F, log_Reports);//コントロール設定ファイル絶対パス（Formsフォルダーと結合後）
                tmpl.SetParameter(5, Log_RecordReportsImpl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                owner_MemoryApplication.CreateErrorReport("Er:8012;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_XmlException:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sFpatha_F, log_Reports);//コントロール設定ファイル絶対パス（Formsフォルダーと結合後）
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                owner_MemoryApplication.CreateErrorReport("Er:8013;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception01:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                owner_MemoryApplication.CreateErrorReport("Er:8014;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception02:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                owner_MemoryApplication.CreateErrorReport("Er:8015;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedChildElement:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, NamesNode.S_CONTROL1, log_Reports);//期待するノード名
                tmpl.SetParameter(2, err_XElm.Name, log_Reports);//実際のノード名

                owner_MemoryApplication.CreateErrorReport("Er:8016;", tmpl, log_Reports);
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
