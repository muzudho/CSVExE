using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;//DataRowView
using System.Drawing;//Brush
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Layout;
using Xenon.Functions;
using Xenon.Middle;
using Xenon.Table;
using Xenon.Toolwindow;
using Xenon.MiddleImpl;

namespace Xenon.Csvexe
{


    public partial class Form1 : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// 静的関数。
        /// 
        /// 関数を登録します。
        /// </summary>
        public static void RegisterFunctions(Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_CSVEditorImpl.Name_Library, "Form1", "static RegisterFunctions",pg_Logging);
            //

            ConfigurationtreeToFunction_Item transUnknown = new ConfigurationtreeToFunction00_ItemImpl();//暫定

            // 親クラスを上書きしないよう、関数名は変えておくこと。
            {
                List<string> sList = new List<string>();
                // arg 不明
                Collection_Function.SetFunction(Expression_Node_Function_BootCsvEditorExImpl.NAME_FUNCTION, new Expression_Node_Function_BootCsvEditorExImpl(EnumEventhandler.O_Ea, sList, transUnknown), pg_Logging);
            }
            pg_Method.WriteDebug_ToConsole("ＣＳＶエディター用のブート関数を登録。");

            //
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {

            //
            //
            //
            //（１）デバッグモード　※Log_MethodImpl#BeginMethod(...)をする前に必要。
            //
            //
            //
            Log_ReportsImpl.BDebugmode_Static = true;
            Log_Reports pg_Logging_ThisMethod;


            //
            //
            //
            //（２）メソッド開始
            //
            //
            //
            Log_Method pg_Method = new Log_MethodImpl(0);
            // デバッグモード静的設定の後で。
            pg_Method.BeginMethod(Info_CSVEditorImpl.Name_Library, this, "Form1_Load", out pg_Logging_ThisMethod);
            //

            Expression_Node_String parent_Expression_Null = null;
            Configurationtree_Node cur_Gcav = new Configurationtree_NodeImpl(pg_Method.Fullname, null);



            //
            //
            //
            //（３）ＣＳＶエディター・モデル（必要に応じて拡張）用意
            //
            //
            //
            this.memoryCsvEditor = new MemoryApplicationImpl();
            this.MemoryCsvEditor.InitializeBeforeUse(
                new Mainwnd_FormWrappingImpl(this),
                new ConfigurationtreeToFunction_ListImpl(parent_Expression_Null, cur_Gcav, this.MemoryCsvEditor, pg_Logging_ThisMethod),
                new Form_ToolwindowImpl(),
                new MemoryAatoolxmlDialogImpl(this.MemoryCsvEditor),
                new UsercontrolStyleSetterImpl(),
                new UsercontrolCreator1Impl(),
                new XToMemory_FormImpl()
                );

            Form1.RegisterFunctions(pg_Logging_ThisMethod);

            //
            //
            //
            //（４）アプリケーション・モデル作成後に E_Sf_BootCsvEditorImpl（必要に応じて拡張）実行。
            //
            //
            //
            if (pg_Logging_ThisMethod.Successful)
            {

                Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                        Expression_Node_Function_BootCsvEditorExImpl.NAME_FUNCTION,
                        null,
                        cur_Gcav,
                        this.MemoryCsvEditor,
                        pg_Logging_ThisMethod
                        );
                //expr_Func.InitializeBeforeUse(this.MoCsvEditor);

                // 実行
                expr_Func.Execute_OnOEa(sender, e);
            }


            //
            //
            //
            //（５）エラーログ出力
            //
            //
            //
            if (!pg_Logging_ThisMethod.Successful)
            {
                // 異常時

                this.MemoryCsvEditor.MemoryLogwriter.WriteErrorLog(
                    this.MemoryCsvEditor,
                    pg_Logging_ThisMethod,
                    pg_Method.Fullname
                    );
            }

            //
            //
            //
            //（６）メソッド、ロギング終了
            //
            //
            //
            pg_Method.EndMethod(pg_Logging_ThisMethod);
            pg_Logging_ThisMethod.EndLogging(pg_Method);
        }

        //────────────────────────────────────────

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (null != this.MemoryCsvEditor)
            {
                this.MemoryCsvEditor.Dispose();
            }
        }

        //────────────────────────────────────────

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    Log_Method pg_Method = new Log_MethodImpl(0);
        //    pg_Method.SetPath(Info_CSVEditorImpl.Name_Library, this, "Form1_Paint");
        //    Log_Reports pg_Logging_Master = new Log_ReportsImpl(pg_Method);
        //    pg_Method.BeginMethod(pg_Logging_Master);

        //    //テスト。
        //    pg_Method.WriteInfo_ToConsole("テスト中");

        //    this.MoCsvEditor.MemoryForms.GetUsercontrolsByName(new Ec_LeafImpl("Sc:Mainwnd;", null, null), true, pg_Logging_Master);

        //    e.Graphics.FillRectangle(Brushes.Red, 0, 0, 1200, 800);
        //    e.Graphics.FillRectangle(Brushes.Black, 100, 100, 200, 100);

        //    pg_Method.EndMethod(pg_Logging_Master);
        //    pg_Logging_Master.EndLogging(pg_Method);
        //}

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected MemoryApplication memoryCsvEditor;

        /// <summary>
        /// ＣＳＶエディター。
        /// 
        /// どのようなエディターにも変形する土台ソフトです。
        /// </summary>
        public MemoryApplication MemoryCsvEditor
        {
            set
            {
                memoryCsvEditor = value;
            }
            get
            {
                return memoryCsvEditor;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
