using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Xenon.Syntax;

namespace Xenon.Operating
{

    /// <summary>
    /// 内容 → XML Document 変換。
    /// </summary>
    public class GloballistAction00003
    {
        /// <summary>
        /// XML Documentに変換。
        /// </summary>
        /// <param name="xmlText"></param>
        /// <returns></returns>
        public XmlDocument Perform(
            MemoryGloballistconfig moGlcnf,
            Log_Reports log_Reports
            )
        {
            XmlDocument doc = new XmlDocument();

            XmlElement rootElm = doc.CreateElement("global-list-config");
            doc.AppendChild(rootElm);

            rootElm.AppendChild(doc.CreateComment(" 変数の型名を、グローバルリストに並んでいる順番に並べてください "));

            // 変数の型名の追加
            foreach (GloballistconfigTypesection typeSection in moGlcnf.TypesectionList.List_Item)
            {
                XmlElement typeElm = doc.CreateElement("type");
                typeElm.SetAttribute(SrsAttrName.S_NAME, typeSection.SType);
                rootElm.AppendChild(typeElm);
            }

            rootElm.AppendChild(doc.CreateComment(" 担当者の情報を記述してください。担当者名、変数の型名、変数番号のそれぞれ、順不同です。 "));
            // 担当者情報の追加
            foreach (GloballistconfigHuman human in moGlcnf.Dictionary_Human.Values)
            {
                XmlElement humanElm = doc.CreateElement("human");
                humanElm.SetAttribute(SrsAttrName.S_NAME, human.SName);
                rootElm.AppendChild(humanElm);

                // 担当変数の型の情報の追加
                foreach (GloballistconfigVariable var in human.Dictionary_Variable.Values)
                {
                    XmlElement varElm = doc.CreateElement("variable");
                    varElm.SetAttribute("type", var.SType);
                    humanElm.AppendChild(varElm);

                    // 担当変数の情報の追加
                    foreach (GloballistconfigNumber num in var.Dictionary_Number.Values)
                    {
                        XmlElement numElm = doc.CreateElement("number");
                        numElm.SetAttribute("range", num.SRange);
                        numElm.SetAttribute("priority", num.Priority.SHumaninput);
                        varElm.AppendChild(numElm);
                    }
                }
            }
            return doc;
        }
    }
}
