using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Lib;

namespace Xenon.PartsnumPut
{
    public partial class UsercontrolDetailbrowser : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsercontrolDetailbrowser()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void ReloadHtml( Memory1Application_Partsnumput memoryApplication_Partsnumput)
        {
            StringBuilder s = new StringBuilder();
            s.Append("<html>");
            s.Append("<body style=\"font-family:ＭＳ ゴシック;font-size:10.5pt;color:gray;\">");

            foreach (string sGroupName in memoryApplication_Partsnumput.Array_NameGroup)
            {
                Memory4aPartsnumbersymbolspritesImpl moGroup = memoryApplication_Partsnumput.Dictionary_MemoryPartsnumbergroupImpl[sGroupName];

                //
                // 名前定義
                s.Append(moGroup.MemoryPartsnumbersprite_Symboldefinition.Name_Symbol);
                s.Append("=");
                if (memoryApplication_Partsnumput.IsDisplayExecute)
                {
                    s.Append(moGroup.MemoryPartsnumbersprite_Symboldefinition.Execute_CalculateExpression());
                }
                else
                {
                    s.Append(moGroup.MemoryPartsnumbersprite_Symboldefinition.Valuenumber_Symbol);
                }
                // コメント
                if ("" != moGroup.MemoryPartsnumbersprite_Symboldefinition.Comment)
                {
                    s.Append("／");
                    // 薄い青
                    s.Append("<span style=\"color:#3366ff;\">「");
                    s.Append(moGroup.MemoryPartsnumbersprite_Symboldefinition.Comment);
                    s.Append("」</span>");
                }
                s.Append("<br/>");
                s.Append(Environment.NewLine);

                //
                // Num要素
                if (0 < moGroup.List_MemoryPartsnumbersprite_Expression.Count)
                {
                    s.Append("<div style=\"margin-left:32px;\">");

                    int nColumn = 0;
                    foreach (Memory4bSpritePartsnumber mNum in moGroup.List_MemoryPartsnumbersprite_Expression)
                    {
                        StringBuilder s2 = new StringBuilder();

                        if (1 <= nColumn)
                        {
                            // 2列目以降は、頭に全角空白を１つ追加。
                            s2.Append("　");
                        }

                        if (memoryApplication_Partsnumput.IsDisplayExecute)
                        {
                            // 絶対番号
                            s2.Append(mNum.Execute_CalculateExpression());
                        }
                        else
                        {
                            // 「a+0~2」形式
                            s2.Append(mNum.Valuenumber_Symbol);
                        }

                        if ("" != mNum.Comment)
                        {
                            // コメント
                            s2.Append("「");
                            s2.Append(mNum.Comment);
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

            goto gt_EndMethod;
        //
        //
        //
        //
        gt_EndMethod:
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
                try
                {
                    this.webBrowser1.DocumentText = value;
                }
                catch (ObjectDisposedException excp)
                {
                    //まだ「詳細ウィンドウ」を作っていないときなど。
                    System.Console.WriteLine("例外：（まだ「詳細ウィンドウ」を作っていないときなど）：" + excp.Message);
                }
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
