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
    public class Utility_XToGivechapterandverse_Usercontrolconfig
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
            Givechapterandverse_Node cf_FcConfig,
            Expression_Node_Filepath ec_Fopath_Forms,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_XToGcav.Name_Library, this, "GetControlNameList",log_Reports);
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
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー407！", log_Method);

                StringBuilder t = new StringBuilder();

                t.Append("レイアウト設定ファイルの中に書かれている、[");
                t.Append(sName_Control);
                t.Append("]のレコードを元に、");
                t.Append(Environment.NewLine);
                t.Append("そのコントロールの設定ファイルを読み込もうとしましたが、");
                t.Append(Environment.NewLine);
                t.Append("そんなファイル、見つかりませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("ファイル パスか、フォルダー パスを確認してください。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("フォームズ_フォルダー：");
                t.Append(Environment.NewLine);
                t.Append("　　");
                t.Append(ec_Fopath_Forms.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("コントロール設定ファイル（入力ママ）：");
                t.Append(Environment.NewLine);
                t.Append("　　");
                t.Append(sHiFpath_ControlFile);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);


                t.Append("コントロール設定ファイル（フォームズ_フォルダーと結合後）：");
                t.Append(Environment.NewLine);
                t.Append("　　");
                t.Append(sFpatha_Fcnf);
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);


                t.Append(Environment.NewLine);

                t.Append("コントロール設定ファイル(Fcnf)を読み込もうとしたとき。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_SException(err_Excp));


                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_XmlException01:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー408！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("エラー。XMLの書き方にミスがあるかも？");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("コントロール設定ファイルを読み込もうとしたとき。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_SException(err_Excp));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedChildElement:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle( "▲エラー499！", log_Method);

                StringBuilder sb = new StringBuilder();
                sb.Append("コントロール設定ファイルに、<");
                sb.Append(NamesNode.S_CONTROL1);
                sb.Append(">要素以外の要素[");
                sb.Append(xError.Name);
                sb.Append("]が含まれていました。");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                // ヒント

                r.Message = sb.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_XmlException02:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー409！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("想定外のエラー。");
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

                Givechapterandverse_Node parent_Cf = new Givechapterandverse_NodeImpl("formsフォルダーパス＋コンポーネント設定ファイルパス", null);

                Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L08_1", parent_Cf);
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
