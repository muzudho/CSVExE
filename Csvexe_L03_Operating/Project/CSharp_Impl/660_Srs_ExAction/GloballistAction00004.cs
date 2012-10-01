using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;

namespace Xenon.Operating
{
    /// <summary>
    /// XML セーブ。
    /// </summary>
    public class GloballistAction00004
    {

        /// <summary>
        /// XML形式で書出し。
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        /// <param name="doc"></param>
        /// <param name="log_Reports"></param>
        public bool Perform(
            string sFpath,
            Encoding encoding,
            XmlDocument doc,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Operating.Name_Library, this, "Perform",log_Reports);

            bool bResult;

            try
            {

                // ルート要素を取得
                System.Xml.XmlElement root = doc.DocumentElement;

                // sample要素を列挙
                System.Xml.XmlNodeList nodeList = root.GetElementsByTagName("sample");

                // XMLの保存方法を設定します。
                System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(sFpath, encoding);
                writer.Formatting = System.Xml.Formatting.Indented;
                writer.Indentation = 4;

                try
                {
                    doc.Save(writer);

                    bResult = true;
                    goto gt_EndMethod;
                }
                catch (Exception ex)
                {
                    // エラー処理
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー0801087！", pg_Method);
                        r.Message = "[" + ex.GetType().Name + "]：" + ex.Message;
                        log_Reports.EndCreateReport();
                    }
                }
                finally
                {
                    writer.Close();
                }
            }
            catch (System.Xml.XmlException ex)
            {
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー1086！", pg_Method);
                    r.Message = ex.Message;
                    log_Reports.EndCreateReport();
                }
            }
            catch (System.IO.IOException ex)
            {
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー1085！", pg_Method);
                    r.Message = ex.Message;
                    log_Reports.EndCreateReport();
                }
            }
            catch (System.Exception ex)
            {
                if (log_Reports.CanCreateReport)
                {
                    Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー0801084！", pg_Method);
                    r.Message = "["+ex.GetType().Name+"]："+ex.Message;
                    log_Reports.EndCreateReport();
                }
            }

            bResult = false;
            goto gt_EndMethod;

        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return bResult;
        }
    }
}
