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
    /// 『AaEditor.xml』は、主に
    /// C:\SRS_Project\プロジェクト名\meta\editor-config\プロジェクト記号\project-config.xml
    /// に配置される、プロジェクト別の、
    /// ツールの入力値を保存するファイルです。
    /// 
    /// 旧『tool-save.xml』ファイルです。
    /// WriterOfProjectConfig
    /// </summary>
    public class Writer_Aaeditorxml
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『AaEditor.xml』ファイルへ書き出します。
        /// </summary>
        /// <param name="sFpatha_Pcnf"></param>
        /// <param name="applicationName"></param>
        /// <param name="inputs"></param>
        public void Write(
            string sFpatha_Pcnf,
            string sName_Editor,
            Dictionary_Fsetvar_Configurationtree stDic_Fsetvar,
            Log_Reports log_Reports
        )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Write",log_Reports);

            XmlDocument xDoc = new XmlDocument();

            // UTF-8 エンコーディングで書くものとします。
            XmlProcessingInstruction xPi = xDoc.CreateProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
            xDoc.AppendChild(xPi);

            Exception err_Excp;
            try
            {
                // ルート要素を作成
                System.Xml.XmlElement xRoot = xDoc.CreateElement(NamesNode.S_EDITOR);

                //
                // これは書出しなので、スクリプトファイルのバージョンチェックを省略。
                //

                //xRoot.SetAttribute(PmNames.S_NAME_EDITOR.Name_Attribute, sName_Editor);

                xDoc.AppendChild(xRoot);

                // 説明文の記述
                {
                    StringBuilder sbText1 = new StringBuilder();
                    sbText1.Append("このファイルは、『");
                    sbText1.Append(sName_Editor);
                    sbText1.Append("』によって読書きされます");

                    xRoot.AppendChild(xDoc.CreateComment(sbText1.ToString()));
                }

                // ＜ｆ－ｓｅｔ－ｖａｒ＞要素：
                stDic_Fsetvar.List_Child.ForEach(delegate(Configurationtree_Node cf_Fsetvar, ref bool bBreak)
                {
                    XmlElement x_Fsetvar = xDoc.CreateElement(NamesNode.S_F_SET_VAR);

                    //ｎａｍｅ－ｖａｒ属性
                    string sNamevar;
                    cf_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_NAME_VAR, out sNamevar, true, log_Reports);

                    //ｆｏｌｄｅｒ属性
                    string sFolder;
                    cf_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_FOLDER, out sFolder, true, log_Reports);

                    //ｖａｌｕｅ属性
                    string sValue;
                    cf_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                    //ｄｅｓｃｒｉｐｔｉｏｎ属性
                    string sDescription;
                    cf_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_DESCRIPTION, out sDescription, true, log_Reports);

                    x_Fsetvar.SetAttribute(PmNames.S_NAME.Name_Attribute, sNamevar);
                    x_Fsetvar.SetAttribute(PmNames.S_FOLDER.Name_Attribute, sFolder);
                    x_Fsetvar.SetAttribute(PmNames.S_VALUE.Name_Attribute, sValue);
                    x_Fsetvar.SetAttribute(PmNames.S_DESCRIPTION.Name_Attribute, sDescription);
                    xRoot.AppendChild(x_Fsetvar);
                });

                // .xmlファイルの中身全文を保存。
                xDoc.Save(sFpatha_Pcnf);
            }
            catch (Exception ex)
            {
                // エラー
                err_Excp = ex;
                goto gt_Error_Exception;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Exception:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー341！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("エディター設定ファイルへの書き出しに失敗しました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                s.Append("エラーの種類：");
                s.Append(err_Excp.GetType().Name);
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);
                s.Append("エラーメッセージ：");
                s.Append(err_Excp.Message);
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                r.Message = r.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return;
        }

        //────────────────────────────────────────
        #endregion



    }
}
