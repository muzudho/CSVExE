using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;//XmlDocument

using Xenon.Syntax;//N_FilePath
using Xenon.Middle;

namespace Xenon.XToGcav
{

    /// <summary>
    /// (Sf)
    /// 
    /// X→S。
    /// </summary>
    public class Utility_XToConfigurationtree_Usercontrolconfig
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 「.xml」(Fcnf)ファイルの、&lt;control&gt;要素の、oNodeName（コントロール名）のリスト。記述順。
        /// </summary>
        /// <returns></returns>
        public List<string> GetList_NameControl(
            string sName_Control,
            string sHiFpath_ControlFile,
            string sFpatha_Fcnf,
            Configurationtree_Node cf_FcConfig,
            Expression_Node_Filepath ec_Fopath_Forms,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "GetList_NameControl", log_Reports);
            //
            //

            XmlDocument xDoc = null;

            List<string> sList = new List<string>();
            Exception err_Excp = null;
            if (log_Reports.Successful)
            {
                // 正常時

                xDoc = new System.Xml.XmlDocument();

                try
                {
                    xDoc.Load(sFpatha_Fcnf);
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
                    goto gt_Error_XmlException01;
                }
            }


            XmlElement xError = null;
            if (log_Reports.Successful)
            {
                // 正常時

                try
                {
                    //
                    // コントロール自体は、Aa_Forms.csvを読み取って
                    // 既に追加済みです。
                    //

                    // ルート要素を取得
                    System.Xml.XmlElement xRoot = xDoc.DocumentElement;

                    //
                    // ＜ｃｏｎｔｒｏｌ＞要素を読取
                    //


                    if (NamesNode.S_CONTROL1 == xRoot.Name)
                    {
                        //　ルート要素が＜ｃｏｎｔｒｏｌ＞

                        // コントロール名をリストに追加。
                        sList.Add(sName_Control);
                    }
                    else
                    {
                        //
                        // ＜ｃｏｎｔｒｏｌ＞要素を列挙
                        //
                        XmlNodeList xTopNL = xRoot.ChildNodes;

                        foreach (XmlNode xTopNode in xTopNL)
                        {
                            if (XmlNodeType.Element == xTopNode.NodeType)
                            {
                                XmlElement xTop = (XmlElement)xTopNode;


                                if (NamesNode.S_CONTROL1 == xTop.Name)
                                {
                                    // コントロール名をリストに追加。
                                    sList.Add(sName_Control);

                                }
                                else
                                {
                                    //
                                    // エラー。
                                    xError = xTop;
                                    goto gt_Error_UndefinedChildElement;
                                }

                            }
                        }
                    }


                }
                catch (System.Xml.XmlException ex)
                {
                    //
                    // エラー。
                    err_Excp = ex;
                    goto gt_Error_XmlException02;
                }

            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_IoException:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sName_Control, log_Reports);//コントロール名
                tmpl.SetParameter(2, ec_Fopath_Forms.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports), log_Reports);//Formsフォルダーパス
                tmpl.SetParameter(3, sHiFpath_ControlFile, log_Reports);//コントロール設定ファイルパス（入力ママ）
                tmpl.SetParameter(4, sFpatha_Fcnf, log_Reports);//コントロール設定ファイルパス（Formsフォルダーと結合後）
                tmpl.SetParameter(5, Log_Report01Impl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                memoryApplication.CreateErrorReport("Er:8004;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_XmlException01:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_Report01Impl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                memoryApplication.CreateErrorReport("Er:8005;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedChildElement:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, NamesNode.S_CONTROL1, log_Reports);//期待するノード名
                tmpl.SetParameter(2, xError.Name, log_Reports);//含まれていたノード名

                memoryApplication.CreateErrorReport("Er:8006;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_XmlException02:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_Report01Impl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                memoryApplication.CreateErrorReport("Er:8007;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sList;
        }


        //────────────────────────────────────────


        public string GetSFilepath_UsercontrolconfigAbsolute(
            Expression_Node_Filepath ec_Fpath_Fcnf,
            Expression_Node_Filepath ec_Fopath_Forms,
            Log_Reports log_Reports
            )
        {
            string sFpatha_Fcnf;

            //
            // forms フォルダー
            //
            string sFopatha_Forms = ec_Fopath_Forms.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
            if (!log_Reports.Successful)
            {
                // 既エラー。
                sFpatha_Fcnf = "";
                goto gt_EndMethod;
            }


            //
            // Fcnf 絶対ファイルパス
            //
            if (log_Reports.Successful)
            {
                // 正常時

                Configurationtree_Node parent_Cf = new Configurationtree_NodeImpl("formsフォルダーパス＋コンポーネント設定ファイルパス", null);

                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L08_1", parent_Cf);
                cf_Fpath.InitPath(
                    sFopatha_Forms,
                    ec_Fpath_Fcnf.Humaninput,
                    log_Reports
                    );
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    sFpatha_Fcnf = "";
                    goto gt_EndMethod;
                }

                Expression_Node_Filepath ec_Fpatha_Fcnf = new Expression_Node_FilepathImpl(cf_Fpath);
                sFpatha_Fcnf = ec_Fpatha_Fcnf.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    sFpatha_Fcnf = "";
                    goto gt_EndMethod;
                }
            }
            else
            {
                // エラー
                sFpatha_Fcnf = "";
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            return sFpatha_Fcnf;
        }

        //────────────────────────────────────────
        #endregion



    }
}
