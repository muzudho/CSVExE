using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;//WarningReports,HumanInputFilePath
using Xenon.Middle;

namespace Xenon.MiddleImpl
{

    /// <summary>
    /// 『ツール設定ファイル』は、主に
    /// ツールのexeから相対パスで、特定の場所に配置される、ツールにつき１つだけある、
    /// ツールの入力値を保存するファイルです。
    /// </summary>
    public class Writer_Aatoolxml
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『ツール設定ファイル』へ書き出します。
        /// </summary>
        /// <param name="toolConfigXmlFileAbsPath"></param>
        /// <param name="applicationName"></param>
        /// <param name="inputs"></param>
        /// <param name="runningHintName"></param>
        public void Write(
            string sFpatha_Config_Tool,
            string sName_Application,
            Dictionary_AatoolxmlEditor dic_AatoolxmlEditor,
            Log_Reports log_Reports
        )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "Write",log_Reports);

            XmlDocument xDoc = new XmlDocument();

            // UTF-8 エンコーディングで書くものとします。
            XmlProcessingInstruction xPi = xDoc.CreateProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
            xDoc.AppendChild(xPi);

            // 説明文の記述
            {
                StringBuilder sbText1 = new StringBuilder();
                sbText1.Append("このファイルは、UTF-8(BOM無し) エンコーディングで記述してください。");

                xDoc.AppendChild(xDoc.CreateComment(sbText1.ToString()));
            }


            Exception err_Excp;
            try
            {
                // ルート要素を作成
                System.Xml.XmlElement xRoot = xDoc.CreateElement(NamesNode.S_CODEFILE_TOOL);

                //
                // これは書出しなので、スクリプトファイルのバージョンチェックを省略。
                //

                xRoot.SetAttribute("application", sName_Application);
                xDoc.AppendChild(xRoot);

                // 説明文の記述
                {
                    StringBuilder sb1 = new StringBuilder();
                    sb1.Append("このファイルは、恐らく『");
                    sb1.Append(sName_Application);
                    sb1.Append("』によって読書きされるかと思います。");

                    xRoot.AppendChild(xDoc.CreateComment(sb1.ToString()));
                }

                // エディター要素：
                foreach (MemoryAatoolxml_Editor aatool_Editor in dic_AatoolxmlEditor.Dictionary_Item.Values)
                {
                    XmlElement xEditor = xDoc.CreateElement(NamesNode.S_EDITOR);

                    // input要素：
                    aatool_Editor.Dictionary_Fsetvar_Givechapterandverse.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node s_Fsetvar, ref bool bBreak)
                    {
                        XmlElement x_Input = xDoc.CreateElement(NamesNode.S_F_SET_VAR);

                        //ｎａｍｅ－ｖａｒ属性
                        string sNamevar;
                        s_Fsetvar.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME_VAR, out sNamevar, true, log_Reports);

                        //ｆｏｌｄｅｒ属性
                        string sFolder;
                        s_Fsetvar.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_FOLDER, out sFolder, true, log_Reports);

                        //ｖａｌｕｅ属性
                        string sValue;
                        s_Fsetvar.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                        //ｄｅｓｃｒｉｐｔｉｏｎ属性
                        string sDescription;
                        s_Fsetvar.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_DESCRIPTION, out sDescription, true, log_Reports);

                        x_Input.SetAttribute(PmNames.S_NAME.Name_Attribute, sNamevar);
                        x_Input.SetAttribute(PmNames.S_FOLDER.Name_Attribute, sFolder);
                        x_Input.SetAttribute(PmNames.S_VALUE.Name_Attribute, sValue);
                        x_Input.SetAttribute(PmNames.S_DESCRIPTION.Name_Attribute, sDescription);

                        xEditor.AppendChild(x_Input);
                    });

                    xRoot.AppendChild(xEditor);
                }



                // .xmlファイルの中身全文を保存。
                xDoc.Save(sFpatha_Config_Tool);
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
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー351！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("『ツール設定ファイル』への書き出しに失敗しました。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                // ヒント
                s.Append(r.Message_SException(err_Excp));

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
