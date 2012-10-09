using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;//Application
using System.Xml;

namespace Xenon.RepoNum
{
    public class StampImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public StampImpl()
        {
            this.sUser = "";
            this.sVer = "";
            this.sTarget = "";
            this.sStatus = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ユーザー設定ファイルパス
        /// </summary>
        /// <returns></returns>
        public string GetUserCnf()
        {
            StringBuilder s = new StringBuilder();

            s.Append(Application.StartupPath);
            s.Append("\\Save\\user.xml");

            return s.ToString();
        }

        public void LoadUserCnf(out string sErrorMsg)
        {
            // 絶対ファイルパス
            string sFpatha = this.GetUserCnf();

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
            System.Xml.XmlElement root = doc.DocumentElement;


            // userノード
            System.Xml.XmlNodeList userNL = root.GetElementsByTagName("user");
            for (int i = 0; i < userNL.Count; i++)
            {
                XmlNode nd = userNL.Item(i);

                if (XmlNodeType.Element == nd.NodeType)
                {
                    //
                    // ＜user＞
                    //
                    XmlElement elm = (XmlElement)nd;

                    this.SUser = elm.Attributes.GetNamedItem("value").Value;

                    // 最初の１個で終了。
                    break;
                }
            }

            // versionノード
            System.Xml.XmlNodeList versionNL = root.GetElementsByTagName("version");
            for (int i = 0; i < versionNL.Count; i++)
            {
                XmlNode nd = versionNL.Item(i);

                if (XmlNodeType.Element == nd.NodeType)
                {
                    //
                    // ＜version＞
                    //
                    XmlElement elm = (XmlElement)nd;

                    this.SVer = elm.Attributes.GetNamedItem("value").Value;

                    // 最初の１個で終了。
                    break;
                }
            }

            // numberノード
            System.Xml.XmlNodeList numberNL = root.GetElementsByTagName("number");
            for (int i = 0; i < numberNL.Count; i++)
            {
                XmlNode nd = numberNL.Item(i);

                if (XmlNodeType.Element == nd.NodeType)
                {
                    //
                    // ＜version＞
                    //
                    XmlElement elm = (XmlElement)nd;

                    int next = 0;
                    int.TryParse(elm.Attributes.GetNamedItem("value").Value, out next);
                    this.Num = next;

                    // 最初の１個で終了。
                    break;
                }
            }

            sErrorMsg = "";

            goto process_end;


            //
        //
        error_filePath:
            {
                StringBuilder t = new StringBuilder();
                t.Append("エラー：ユーザー設定ファイルパス＝[");
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
                t.Append("エラー：ユーザー設定ファイルパス読取失敗＝［");
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

        public void SaveUserCnf(out string sErrorMsg)
        {
            XmlDocument doc = new XmlDocument();

            // ルート
            XmlElement root = doc.CreateElement("repo-num");
            doc.AppendChild(root);

            // コメント
            {
                XmlComment cmt = doc.CreateComment("このファイルは、ツールによって上書きされます。");
                root.AppendChild(cmt);
            }

            // 報告者名
            {
                XmlElement elm = doc.CreateElement("user");
                elm.SetAttribute("value", this.SUser);
                root.AppendChild(elm);
            }

            // バージョン名
            {
                XmlElement elm = doc.CreateElement("version");
                elm.SetAttribute("value", this.SVer);
                root.AppendChild(elm);
            }

            // 報告番号
            {
                XmlElement elm = doc.CreateElement("number");
                elm.SetAttribute("value", this.Num.ToString());
                root.AppendChild(elm);
            }

            try
            {
                // XMLの保存方法を設定します。
                System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(this.GetUserCnf(), Encoding.UTF8);
                writer.Formatting = System.Xml.Formatting.Indented;
                writer.Indentation = 4;

                try
                {
                    doc.Save(writer);
                }
                catch (Exception ex)
                {
                    // エラー処理
                    sErrorMsg = "エラー：書込失敗＝［" + ex.Message + "］";
                    goto error_some;
                }
                finally
                {
                    writer.Close();
                }
            }
            catch (System.Xml.XmlException ex)
            {
                // エラー処理
                sErrorMsg = "エラー：XML読取失敗＝［" + ex.Message + "］";
                goto error_some;
            }
            catch (System.IO.IOException ex)
            {
                // エラー処理
                sErrorMsg = "エラー：ファイル入出力失敗＝［" + ex.Message + "］";
                goto error_some;
            }
            catch (System.Exception ex)
            {
                // エラー処理
                sErrorMsg = "エラー：予想しない失敗＝［" + ex.Message + "］";
                goto error_some;
            }

            sErrorMsg = "";
            goto process_end;

            //
        // エラー
        error_some:
            {
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

        /// <summary>
        /// 添付PNG画像ファイルの適当なサンプル
        /// </summary>
        /// <returns></returns>
        public string ToPngName()
        {
            StringBuilder s = new StringBuilder();

            s.Append(this.SUser);
            s.Append("_RNo");
            s.Append(this.Num);
            s.Append(".png");

            return s.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// スタンプ文字列。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            if (this.STarget != "" || this.SStatus != "")
            {
                s.Append("【");
            }

            if (this.STarget != "")
            {
                s.Append(this.STarget);
            }

            if (this.STarget != "" && this.SStatus != "")
            {
                s.Append("／");
            }

            if (this.SStatus != "")
            {
                s.Append(this.SStatus);
            }

            if (this.STarget != "" || this.SStatus != "")
            {
                s.Append("】");
            }

            s.Append("(");
            s.Append(this.SUser);
            s.Append("/RNo.");
            s.Append(this.Num);
            s.Append("/");
            s.Append(System.DateTime.Now.Year);
            s.Append("-");
            s.Append(System.DateTime.Now.Month);
            s.Append("-");
            s.Append(System.DateTime.Now.Day);
            s.Append("/");
            s.Append(this.SVer);
            s.Append(")");

            return s.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected string sUser;

        /// <summary>
        /// 報告者名
        /// </summary>
        public string SUser
        {
            get
            {
                return sUser;
            }
            set
            {
                sUser = value;
            }
        }

        //────────────────────────────────────────

        protected string sVer;

        /// <summary>
        /// バージョン番号
        /// </summary>
        public string SVer
        {
            get
            {
                return sVer;
            }
            set
            {
                sVer = value;
            }
        }

        //────────────────────────────────────────

        protected int num;

        /// <summary>
        /// 報告番号
        /// </summary>
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }

        //────────────────────────────────────────

        protected string sTarget;

        /// <summary>
        /// 宛先タグ
        /// </summary>
        public String STarget
        {
            get
            {
                return sTarget;
            }
            set
            {
                sTarget = value;
            }
        }

        //────────────────────────────────────────

        protected string sStatus;

        /// <summary>
        /// ステータス_タグ
        /// </summary>
        public String SStatus
        {
            get
            {
                return sStatus;
            }
            set
            {
                sStatus = value;
            }
        }

        //────────────────────────────────────────
        //────────────────────────────────────────
        //────────────────────────────────────────
        //────────────────────────────────────────
        //────────────────────────────────────────
        #endregion



    }
}
