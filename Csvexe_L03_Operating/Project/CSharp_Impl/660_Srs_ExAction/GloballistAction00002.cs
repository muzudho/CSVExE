using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;//XmlNode

using Xenon.Syntax;//N_FilePath
using Xenon.Table;//IntCellData

namespace Xenon.Operating
{

    /// <summary>
    /// XML ロード。『SRSグローバルリスト設定ファイル』
    /// </summary>
    public class GloballistAction00002
    {
        public MemoryGloballistconfig Perform(
            string sFpath_Glcnf,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Operating.Name_Library, this, "Perform",log_Reports);

            // グローバルリスト・コンフィグ設定ファイルの内容。
            MemoryGloballistconfig moGlcnf = new MemoryGloballistconfigImpl();

            Configurationtree_Node parent_Configurationtree_Node = new Configurationtree_NodeImpl("グローバルリスト設定",null);

            Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L03_2", parent_Configurationtree_Node);
            cf_Fpath.InitPath(sFpath_Glcnf, log_Reports);
            if (!log_Reports.Successful)
            {
                // 既エラー。
                goto gt_EndMethod;
            }

            Expression_Node_Filepath ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);
            string sFpatha_Xml = ec_Fpath.Execute_OnExpressionString(
                Request_SelectingImpl.Unconstraint, log_Reports);
            if (!log_Reports.Successful)
            {
                // 既エラー。
                goto gt_EndMethod;
            }

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();


            if (log_Reports.Successful)
            {
                // 正常時

                try
                {
                    // ファイルの読込み
                    doc.Load(sFpatha_Xml);
                }
                catch (System.ArgumentException ex)
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー0800206！", pg_Method);

                        StringBuilder t = new StringBuilder();
                        t.Append("『SRSグローバルリスト』設定ファイルを読込もうとしたら、エラーが発生しました。");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("ファイル=[");
                        t.Append(sFpath_Glcnf);
                        t.Append("]");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("もしかすると：");
                        t.Append(Environment.NewLine);
                        t.Append("　・ファイルパスが間違っているか、未入力なのかも知れません。ファイルパスを指定してください。");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("例外メッセージ：[");
                        t.Append(ex.GetType().Name);
                        t.Append("]：");
                        t.Append(ex.Message);

                        r.Message = t.ToString();
                        log_Reports.EndCreateReport();
                    }
                }
                catch (System.Exception ex)
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー0800205！", pg_Method);

                        StringBuilder t = new StringBuilder();
                        t.Append("『SRSグローバルリスト』設定ファイルの読込中にエラーが発生しました。");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("ファイル=[");
                        t.Append(sFpath_Glcnf);
                        t.Append("]");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("もしかすると：");
                        t.Append(Environment.NewLine);
                        t.Append("　・読込む設定ファイルを間違えている？ それは『SRSグローバルリスト 設定ファイル』で合っていますか？");
                        t.Append(Environment.NewLine);
                        t.Append("　・読込んだ設定ファイルの内容に間違いがある？");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("例外メッセージ：[");
                        t.Append(ex.GetType().Name);
                        t.Append("]：");
                        t.Append(ex.Message);

                        r.Message = t.ToString();
                        log_Reports.EndCreateReport();
                    }
                }
            }

            if (log_Reports.Successful)
            {
                // 正常時
                try
                {
                    // ルート要素を取得
                    System.Xml.XmlElement root = doc.DocumentElement;


                    // type要素を列挙
                    System.Xml.XmlNodeList typeNL = root.GetElementsByTagName("type");

                    for (int nTypeIndex = 0; nTypeIndex < typeNL.Count; nTypeIndex++)
                    {
                        XmlNode x_TypeNode = typeNL.Item(nTypeIndex);

                        if (log_Reports.Successful)
                        {
                            // 正常時

                            if (XmlNodeType.Element == x_TypeNode.NodeType)
                            {
                                //
                                // type要素
                                //
                                XmlElement x_TypeElm = (XmlElement)x_TypeNode;

                                string sType = x_TypeElm.Attributes.GetNamedItem(SrsAttrName.S_NAME).Value;

                                GloballistconfigTypesectionImpl typeSection = new GloballistconfigTypesectionImpl();
                                typeSection.Name_Type = sType;

                                moGlcnf.TypesectionList.List_Item.Add(typeSection);
                            }
                        }
                    }





                    // human要素を列挙
                    System.Xml.XmlNodeList x_HumanNL = root.GetElementsByTagName("human");

                    for (int nHumanIndex = 0; nHumanIndex < x_HumanNL.Count; nHumanIndex++)
                    {
                        XmlNode x_HumanNode = x_HumanNL.Item(nHumanIndex);

                        if (log_Reports.Successful)
                        {
                            // 正常時

                            if (XmlNodeType.Element == x_HumanNode.NodeType)
                            {
                                //
                                // human要素
                                //
                                XmlElement x_HumanElm = (XmlElement)x_HumanNode;

                                GloballistconfigHuman human = new GloballistconfigHumanImpl();
                                human.Name = x_HumanElm.Attributes.GetNamedItem(SrsAttrName.S_NAME).Value;

                                moGlcnf.Dictionary_Human.Add(human.Name, human);

                                // variable要素を列挙
                                System.Xml.XmlNodeList x_VariableNL = x_HumanElm.GetElementsByTagName("variable");

                                for (int n_VariableIndex = 0; n_VariableIndex < x_VariableNL.Count; n_VariableIndex++)
                                {
                                    XmlNode x_VariableNode = x_VariableNL.Item(n_VariableIndex);

                                    if (XmlNodeType.Element == x_VariableNode.NodeType)
                                    {
                                        //
                                        // variable要素
                                        //
                                        XmlElement x_VariableElm = (XmlElement)x_VariableNode;

                                        GloballistconfigVariable variable = new GloballistconfigVariableImpl();
                                        variable.Name_Type = x_VariableElm.Attributes.GetNamedItem("type").Value;

                                        // 変数の連想配列に、項目を追加
                                        if (human.Dictionary_Variable.ContainsKey(variable.Name_Type))
                                        {
                                            // エラー
                                            if (log_Reports.CanCreateReport)
                                            {
                                                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                                                r.SetTitle("▲エラー1002！", pg_Method);
                                                r.Message = "指定された変数の型["+variable.Name_Type+"]が、重複されて記述されています。";
                                                log_Reports.EndCreateReport();
                                            }
                                        }
                                        else
                                        {
                                            human.Dictionary_Variable.Add(variable.Name_Type, variable);


                                            // number要素を列挙
                                            System.Xml.XmlNodeList numberNL = x_VariableElm.GetElementsByTagName("number");

                                            for (int numberIndex = 0; numberIndex < numberNL.Count; numberIndex++)
                                            {
                                                XmlNode numberNode = numberNL.Item(numberIndex);

                                                if (XmlNodeType.Element == numberNode.NodeType)
                                                {
                                                    //
                                                    // number要素
                                                    //
                                                    XmlElement numberElm = (XmlElement)numberNode;

                                                    GloballistconfigNumber numberObj = new GloballistconfigNumberImpl();
                                                    numberObj.Text_Range = numberElm.Attributes.GetNamedItem("range").Value;

                                                    XenonValue_IntImpl oPriority = new XenonValue_IntImpl("!ハードコーディング_LoaderOfGlobalListConfigXml");
                                                    oPriority.Humaninput = numberElm.Attributes.GetNamedItem("priority").Value;
                                                    numberObj.Priority = oPriority;

                                                    // 変数の連想配列に、変数番号オブジェクトを追加
                                                    variable.Dictionary_Number.Add(numberObj.Text_Range, numberObj);
                                                }
                                            }
                                        }



                                    }
                                }


                            }
                        }
                    }


                }
                catch (System.IO.IOException ex)
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー080103！", pg_Method);
                        r.Message = "『SRSグローバルリスト』設定ファイルが見つかりません。：" + ex.Message;
                        log_Reports.EndCreateReport();
                    }
                }
                catch (System.Exception ex)
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー0800204！", pg_Method);

                        StringBuilder t = new StringBuilder();
                        t.Append("『SRSグローバルリスト』設定ファイルの読込中にエラーが発生しました。");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("ファイル=[");
                        t.Append(sFpath_Glcnf);
                        t.Append("]");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("もしかすると：");
                        t.Append(Environment.NewLine);
                        t.Append("　・読込む設定ファイルを間違えている？ それは『SRSグローバルリスト 設定ファイル』で合っていますか？");
                        t.Append(Environment.NewLine);
                        t.Append("　・読込んだ設定ファイルの内容に間違いがある？");
                        t.Append(Environment.NewLine);
                        t.Append(Environment.NewLine);
                        t.Append("例外メッセージ：[");
                        t.Append(ex.GetType().Name);
                        t.Append("]：");
                        t.Append(ex.Message);

                        r.Message = t.ToString();
                        log_Reports.EndCreateReport();
                    }
                }
            }

            //
            //
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return moGlcnf;
        }
    }
}
