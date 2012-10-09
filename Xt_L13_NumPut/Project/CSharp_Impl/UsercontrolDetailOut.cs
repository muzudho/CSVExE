using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.NumPut
{
    public partial class UsercontrolDetailOut : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolDetailOut()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void UcDetailOut_Load(object sender, EventArgs e)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void ReloadHtml(Memory3Contents moContents)
        {
            StringBuilder s = new StringBuilder();
            s.Append("<html>");
            s.Append("<body style=\"font-family:ＭＳ ゴシック;font-size:10.5pt;color:gray;\">");

            foreach (string sGroupName in moContents.SGroupNameArray)
            {
                MemoryGroupImpl moGroup = moContents.MoGroupImplDic[sGroupName];

                //
                // 名前定義
                s.Append(moGroup.MNameDefine.SName);
                s.Append("=");
                if (moContents.BDisplayExecute)
                {
                    s.Append(moGroup.MNameDefine.SValueExecute());
                }
                else
                {
                    s.Append(moGroup.MNameDefine.SValue);
                }
                // コメント
                if ("" != moGroup.MNameDefine.SComment)
                {
                    s.Append("／");
                    // 薄い青
                    s.Append("<span style=\"color:#3366ff;\">「");
                    s.Append(moGroup.MNameDefine.SComment);
                    s.Append("」</span>");
                }
                s.Append("<br/>");
                s.Append(Environment.NewLine);

                //
                // Num要素
                if (0 < moGroup.MNumList.Count)
                {
                    s.Append("<div style=\"margin-left:32px;\">");

                    int nColumn = 0;
                    foreach (MemoryNum mNum in moGroup.MNumList)
                    {
                        StringBuilder s2 = new StringBuilder();

                        if (1 <= nColumn)
                        {
                            // 2列目以降は、頭に全角空白を１つ追加。
                            s2.Append("　");
                        }

                        if (moContents.BDisplayExecute)
                        {
                            // 絶対番号
                            s2.Append(mNum.SValueExecute());
                        }
                        else
                        {
                            // 「a+0~2」形式
                            s2.Append(mNum.SValue);
                        }

                        if ("" != mNum.SComment)
                        {
                            // コメント
                            s2.Append("「");
                            s2.Append(mNum.SComment);
                            s2.Append("」");

                        }

                        string sTxt2 = s2.ToString();

                        s.Append(sTxt2);
                        nColumn++;
                    }

                    // 改行
                    s.Append("<br/>");
                    s.Append(Environment.NewLine);

                    s.Append("</div>");
                }

            }
            s.Append("</body>");
            s.Append("</html>");
            this.Html = s.ToString();

            goto process_end;
        //
        //
        //
        //
        process_end:
            ;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public string Html
        {
            set
            {
                this.webBrowser1.DocumentText = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
