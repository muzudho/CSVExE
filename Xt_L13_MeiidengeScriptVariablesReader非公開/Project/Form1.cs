using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using Xenon.Controls;
using Xenon.Functions;
using Xenon.Functions_89ma;
using Xenon.Layout;
using Xenon.Middle;
using Xenon.MiddleImpl;
using Xenon.Syntax;
using Xenon.Table;
using Xenon.Toolwindow;

namespace Xenon.Meiidenge
{
    public partial class Form1 : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Form1()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        private void Form1_Load(object sender, EventArgs e)
        {
            //デバッグ
            {
                List<string> listToken = new List<string>();

                string text = "a, b, c, d, e";

                //
                // 第一引数
                //
                {
                    Regex regex = new Regex(@"^(\w,?)");
                    MatchCollection mc = regex.Matches(text);

                    System.Console.WriteLine("mc.Count =[" + mc.Count + "]");

                    int i = 0;
                    foreach (Match m in mc)
                    {
                        System.Console.WriteLine("(" + i + ") m.Groups.Count=[" + m.Groups.Count + "]");

                        for (int j = 1; j < m.Groups.Count; j++)
                        {
                            string token = m.Groups[j].Value;
                            int lengthLeft = text.Length - 1 - token.Length;//「残りの長さ」の意味。左じゃないよ。
                            if (0 < lengthLeft)
                            {
                                text = text.Substring(token.Length, lengthLeft);
                            }
                            else
                            {
                                text = "";
                            }
                            System.Console.WriteLine("(" + i + ":" + j + ") =[" + token + "]　残りtext=[" + text + "]");

                            //トークンを得ます。
                            Match m2 = Regex.Match(token, @"^\s*(.*?),?$");//欲張らないマッチで、最後のカンマを除外します。
                            if(m2.Success)
                            {
                                listToken.Add(m2.Groups[1].Value);
                            }
                            else
                            {
                                //エラー
                            }
                        }
                    }

                }

                //
                // 第二引数以降
                //
                while (0<text.Length)
                {
                    Regex regex = new Regex(@"^(\s*\w,?)");
                    MatchCollection mc = regex.Matches(text);

                    System.Console.WriteLine("mc.Count =[" + mc.Count + "]");
                    if (0==mc.Count)
                    {
                        break;
                    }

                    int i = 0;
                    foreach (Match m in mc)
                    {
                        System.Console.WriteLine("(" + i + ") m.Groups.Count=[" + m.Groups.Count + "]");

                        for (int j = 1; j < m.Groups.Count; j++)
                        {
                            string token = m.Groups[j].Value;
                            int lengthLeft = text.Length - 1 - token.Length;//「残りの長さ」の意味。左じゃないよ。
                            if (0 < lengthLeft)
                            {
                                text = text.Substring(token.Length, lengthLeft);
                            }
                            else
                            {
                                text = "";
                            }
                            System.Console.WriteLine("(" + i + ":" + j + ") =[" + token + "]　残りtext=[" + text + "]");

                            //トークンを得ます。
                            Match m2 = Regex.Match(token, @"^\s*(.*?),?$");//欲張らないマッチで、最後のカンマを除外します。
                            if (m2.Success)
                            {
                                listToken.Add(m2.Groups[1].Value);
                            }
                            else
                            {
                                //エラー
                            }
                        }
                    }
                }

                //
                // 取得結果
                //
                int num = 0;
                foreach(string token in listToken)
                {
                    System.Console.WriteLine(num+":[" + token + "]");
                    num++;
                }
            }


            //（１）デバッグモード　※Log_MethodImpl#BeginMethod(...)をする前に必要。
            Log_ReportsImpl.BDebugmode_Static = true;
            Log_Reports log_Logging_ThisMethod;

            //（２）メソッド開始
            Log_Method log_Method = new Log_MethodImpl(0);
            // デバッグモード静的設定の後で。
            log_Method.BeginMethod(Info_MeiidengeSVR.Name_Library, this, "Form1_Load", out log_Logging_ThisMethod);
            //
            Expression_Node_String parent_Expression_Null = null;
            Configurationtree_Node cur_Conf = new Configurationtree_NodeImpl(log_Method.Fullname, null);

            //（３）ＣＳＶエディター・モデル（必要に応じて拡張）用意
            this.moCsvEditor = new MemoryApplicationImpl();
            this.MoCsvEditor.InitializeBeforeUse(
                new Mainwnd_FormWrappingImpl(this),
                new ConfigurationtreeToFunction_ListImpl(parent_Expression_Null, cur_Conf, this.MoCsvEditor, log_Logging_ThisMethod),
                new Form_ToolwindowImpl(),
                new MemoryAatoolxmlDialogImpl(this.MoCsvEditor),
                new UsercontrolStyleSetterImpl(),
                new UsercontrolCreator1Impl(),
                new XToMemory_FormImpl()
                );

            //（３ｂ）独自実装ライブラリーの関数を登録。
            Collection_Function89ma.RegisterFunctions(log_Logging_ThisMethod);

            //（４）アプリケーション・モデル作成後に E_Sf_BootCsvEditorImpl（必要に応じて拡張）実行。
            if (log_Logging_ThisMethod.Successful)
            {
                Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                        Expression_Node_Function_BootCsvEditorImpl.NAME_FUNCTION,
                        null,
                        cur_Conf,
                        this.MoCsvEditor,
                        log_Logging_ThisMethod
                        );

                // 実行
                expr_Func.Execute4_OnOEa(sender, e);
            }

            //（５）メソッド終了
            log_Method.EndMethod(log_Logging_ThisMethod);

            //
            //
            //
            //（６）エラーログ出力
            //
            //
            //
            if (!log_Logging_ThisMethod.Successful)
            {
                // エラーログ出力。
                this.MoCsvEditor.MemoryLogwriter.WriteErrorLog(
                    this.MoCsvEditor,
                    log_Logging_ThisMethod,
                    Info_MeiidengeSVR.Name_Library + ":" + this.GetType().Name + "#Form1_Load");
            }

            //（７）ロギング終了
            log_Logging_ThisMethod.EndLogging(log_Method);
        }



        #region プロパティー
        //────────────────────────────────────────

        protected MemoryApplication moCsvEditor;

        /// <summary>
        /// ＣＳＶエディター。
        /// 
        /// どのようなエディターにも変形する土台ソフトです。
        /// </summary>
        public MemoryApplication MoCsvEditor
        {
            set
            {
                moCsvEditor = value;
            }
            get
            {
                return moCsvEditor;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
