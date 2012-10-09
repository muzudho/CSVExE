using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;//Application
using System.Xml;

namespace Xenon.RepoNum
{
    public class EngineImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public EngineImpl()
        {
            this.targetTagList = new List<TagElmImpl>();
            this.statusTagList = new List<TagElmImpl>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// エンジン設定ファイルパス
        /// </summary>
        /// <returns></returns>
        public string GetEngineCnf()
        {
            StringBuilder s = new StringBuilder();

            s.Append(Application.StartupPath);
            s.Append("\\Save\\engine.xml");

            return s.ToString();
        }

        public void LoadEngineCnf(out string sErrorMsg)
        {
            // 絶対ファイルパス
            string sFpatha = this.GetEngineCnf();

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();


            Exception error_excp;
            try
            {
                // ファイルの読込み
                doc.Load(sFpatha);
            }
            catch (System.ArgumentException ex)
            {
                // エラー
                goto error_filePath;
            }
            catch (System.Exception ex)
            {
                // エラー
                error_excp = ex;
                goto error_read;
            }

            // ルート要素
            XmlElement root = doc.DocumentElement;


            // target-tagノード
            {
                XmlNodeList nl10 = root.GetElementsByTagName("target-tag");
                for (int i = 0; i < nl10.Count; i++)
                {
                    XmlNode nd10 = nl10.Item(i);

                    if (XmlNodeType.Element == nd10.NodeType)
                    {
                        //
                        // ＜target-tag＞
                        //
                        XmlElement elm10 = (XmlElement)nd10;

                        // tag
                        XmlNodeList nl11 = elm10.GetElementsByTagName("tag");
                        for (int j = 0; j < nl11.Count; j++)
                        {
                            XmlNode nd11 = nl11.Item(j);

                            if (XmlNodeType.Element == nd11.NodeType)
                            {
                                //
                                // ＜tag＞
                                //
                                XmlElement elm11 = (XmlElement)nd11;

                                TagElmImpl tag = new TagElmImpl();
                                tag.SValue = elm11.GetAttribute("value");
                                tag.SDisplay = elm11.GetAttribute("display");
                                tag.SDescription = elm11.GetAttribute("description");
                                this.TargetTagList.Add(tag);
                            }
                        }

                        // 最初の１個で終了。
                        break;
                    }
                }
            }

            // status-tagノード
            {
                XmlNodeList nl10 = root.GetElementsByTagName("status-tag");
                for (int i = 0; i < nl10.Count; i++)
                {
                    XmlNode nd10 = nl10.Item(i);

                    if (XmlNodeType.Element == nd10.NodeType)
                    {
                        //
                        // ＜target-tag＞
                        //
                        XmlElement elm10 = (XmlElement)nd10;

                        // tag
                        XmlNodeList nl11 = elm10.GetElementsByTagName("tag");
                        for (int j = 0; j < nl11.Count; j++)
                        {
                            XmlNode nd11 = nl11.Item(j);

                            if (XmlNodeType.Element == nd11.NodeType)
                            {
                                //
                                // ＜tag＞
                                //
                                XmlElement elm11 = (XmlElement)nd11;

                                TagElmImpl tag = new TagElmImpl();
                                tag.SValue = elm11.GetAttribute("value");
                                tag.SDisplay = elm11.GetAttribute("display");
                                tag.SDescription = elm11.GetAttribute("description");
                                this.StatusTagList.Add(tag);
                            }
                        }

                        // 最初の１個で終了。
                        break;
                    }
                }
            }

            sErrorMsg = "";

            goto process_end;


            //
        //
        error_filePath:
            {
                StringBuilder t = new StringBuilder();
                t.Append("エラー：エンジン設定ファイルパス＝[");
                t.Append(sFpatha);
                t.Append("］");

                sErrorMsg = t.ToString();
            }
            goto process_end;

            //
        //
        error_read:
            {
                StringBuilder t = new StringBuilder();
                t.Append("エラー：エンジン設定ファイルパス読取失敗＝［");
                t.Append(error_excp.Message);
                t.Append("］");

                sErrorMsg = t.ToString();
            }
            goto process_end;

            //
        //
        //
        //
        process_end:
            return;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected List<TagElmImpl> targetTagList;

        /// <summary>
        /// 宛先タグのリスト。
        /// </summary>
        public List<TagElmImpl> TargetTagList
        {
            get
            {
                return targetTagList;
            }
        }

        //────────────────────────────────────────

        protected List<TagElmImpl> statusTagList;

        /// <summary>
        /// ステータス_タグのリスト。
        /// </summary>
        public List<TagElmImpl> StatusTagList
        {
            get
            {
                return statusTagList;
            }
        }

        //────────────────────────────────────────
        #endregion

    }
}
