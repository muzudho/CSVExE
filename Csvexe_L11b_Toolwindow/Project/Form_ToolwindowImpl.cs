using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Functions;
using Xenon.Middle;
using Xenon.MiddleImpl;
using Xenon.Expr;

namespace Xenon.Toolwindow
{

    /// <summary>
    /// ツール・ウィンドウ。
    /// 
    /// ※サブ・ウィンドウです。
    ///   単独でフォーム起動しても、足らないプロパティーがあると思います。
    /// 
    /// ※使用時は、モデルにアプリケーション名を設定してください。
    /// </summary>
    public partial class Form_ToolwindowImpl : Form, Form_Toolwindow
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Form_ToolwindowImpl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 使う前に設定してください。
        /// このフォーム単独起動時は、呼び出されないプログラムが書かれていることがあります。
        /// </summary>
        /// <param name="ownerProp_MemoryApplication"></param>
        public void InitializeBeforeUse(
            MemoryApplication owner_MemoryApplication
            )
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
        }

        //────────────────────────────────────────

        /// <summary>
        /// クリアー
        /// </summary>
        public void Clear()
        {
            // リストボックス
            {
                UsercontrolListbox uctLst = (UsercontrolListbox)this.UctlstNameProject;
                uctLst.ControlCommon.BAutomaticinputting = true;
                uctLst.Clear();
                uctLst.ControlCommon.BAutomaticinputting = false;
            }

            UsercontrolTextbox uctTxt = (UsercontrolTextbox)this.PctxtFpathProjectcnf;
            uctTxt.ControlCommon.BAutomaticinputting = true;
            uctTxt.Clear();
            uctTxt.ControlCommon.BAutomaticinputting = false;

            this.pctxtInformation.Text = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// エディター設定ファイルの絶対パス
        /// </summary>
        /// <returns></returns>
        private string GetFilepathabsolute_Editor(
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditorElm,
            Log_Reports pg_Logging
            )
        {
            string sFpath_EditorXml = "";

            moAatoolxml_SelectedEditorElm.Dictionary_Fsetvar_Configurationtree.List_Child.ForEach(delegate(Configurationtree_Node s_Fsetvar, ref bool bBreak)
            {
                string sNamevar1;
                s_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_NAME_VAR, out sNamevar1, true, pg_Logging);

                if (sNamevar1 == NamesVar.S_SP_EDITOR)
                {
                    string sValue;
                    s_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, pg_Logging);

                    sFpath_EditorXml = sValue + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_EDITOR_XML;
                }

            });

            // エディター設定ファイル パスの有効/無効を調べます。
            string sFpatha;
            Expression_Node_Filepath e_Fpath_prj;
            {
                Configurationtree_Node parent_Configurationtree_Node = new Configurationtree_NodeImpl("!ハードコーディング_" + this.GetType().Name + "#GetProjectAbsFilePath", null);

                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L09TcDlg_2", parent_Configurationtree_Node);
                cf_Fpath.InitPath(
                    sFpath_EditorXml,
                    pg_Logging
                    );
                if (!pg_Logging.Successful)
                {
                    // 既エラー。
                    sFpatha = "";
                    goto gt_EndMethod;
                }

                e_Fpath_prj = new Expression_Node_FilepathImpl(cf_Fpath);
            }

            sFpatha = e_Fpath_prj.Execute4_OnExpressionString(
                EnumHitcount.Unconstraint, pg_Logging);
            if (!pg_Logging.Successful)
            {
                // 既エラー。
                sFpatha = "";
                goto gt_EndMethod;
            }

            //.WriteLine(this.GetType().Name + "#GetProjectAbsFilePath: absFilePath=[" + absFilePath + "]");

            //
        //
        //
        //
        gt_EndMethod:
            return sFpatha;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports d_Logging_Load = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Toolwindow.Name_Library, this, "Form1_Load",d_Logging_Load);
            //
            //

            this.Load_Form2_(d_Logging_Load);


            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(d_Logging_Load);
            d_Logging_Load.EndLogging(pg_Method);
        }

        //────────────────────────────────────────

        private void Load_Form2_(Log_Reports pg_Logging)
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Toolwindow.Name_Library, this, "Form1_Load",pg_Logging);



            StringBuilder sb = new StringBuilder();

            MemoryAatoolxmlDialog moAatoolxmlDialog;
            if (null != this.Owner_MemoryApplication)
            {
                moAatoolxmlDialog = this.Owner_MemoryApplication.MemoryForms.MemoryAatoolxmlDialog;
            }
            else
            {
                // ダミーを作成。
                pg_Method.WriteInfo_ToConsole("ダミー・MemoryAatoolxmlDialogを作成。");
                moAatoolxmlDialog = new MemoryAatoolxmlDialogImpl(this.Owner_MemoryApplication);
            }

            moAatoolxmlDialog.MemoryAatoolxml = new MemoryAatoolxmlImpl(this.Owner_MemoryApplication);


            Configurationtree_Node parent_Gcav = new Configurationtree_NodeImpl("!ハードコーディング_" + this.GetType().Name + "#Form1_Load", null);


            // ツール設定ファイルへのパスは固定とします。
            Expression_Node_Filepath ec_Fpath_toolcnf;
            {
                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L09TcDlg_3", parent_Gcav);
                cf_Fpath.InitPath(
                    ValuesAttr.S_FPATHR_AATOOLXML,
                    pg_Logging);
                if (!pg_Logging.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                ec_Fpath_toolcnf = new Expression_Node_FilepathImpl(cf_Fpath);
            }


            //
            //
            //
            //「ツール設定ファイル」読取り
            //
            //
            //
            moAatoolxmlDialog.MemoryAatoolxml.LoadFile(ec_Fpath_toolcnf, pg_Logging);
            if (!pg_Logging.Successful)
            {
                // 既エラー。
                goto gt_EndMethod;
            }

            {
                UsercontrolListbox uctLst = (UsercontrolListbox)this.UctlstNameProject;
                uctLst.Clear();
                foreach (string sName_Project in moAatoolxmlDialog.MemoryAatoolxml.Dictionary_Editor.Dictionary_Item.Keys)
                {
                    uctLst.Items.Add(sName_Project);
                }

                if ("" == moAatoolxmlDialog.Name_SelectedEditor)
                {
                    // 選択プロジェクト名が指定されていなければ。

                    if (0 < uctLst.Items.Count)
                    {
                        // 先頭の要素を選択します。
                        uctLst.ControlCommon.BAutomaticinputting = true;
                        uctLst.SelectedIndex = 0;
                        uctLst.ControlCommon.BAutomaticinputting = false;
                    }
                    else
                    {
                        // 非選択にします。
                        uctLst.ControlCommon.BAutomaticinputting = true;
                        uctLst.SelectedIndex = -1;
                        uctLst.ControlCommon.BAutomaticinputting = false;
                    }
                }
                else
                {
                    // 選択プロジェクト名が指定されていれば。

                    int selectedIndex = uctLst.Items.IndexOf(moAatoolxmlDialog.Name_SelectedEditor);

                    uctLst.ControlCommon.BAutomaticinputting = true;
                    uctLst.SelectedIndex = selectedIndex;
                    uctLst.ControlCommon.BAutomaticinputting = false;
                }
            }

            sb.Append("[◆コマンドライン引数]");
            sb.Append(Environment.NewLine);

            // コマンドライン引数を取得します。
            string[] args = System.Environment.GetCommandLineArgs();

            //コマンドライン引数の表示
            int n = 1;
            foreach (string sArg in args)
            {
                sb.Append("【");
                sb.Append(n);
                sb.Append("】");
                sb.Append(sArg);
                sb.Append(Environment.NewLine);
            }

            this.pctxtInformation.Text = sb.ToString();

            Expression_Node_String parent_Expression_Null = null;

            //  ■
            //■  ■ 「変数書出ボタン」のイベント設定
            //  ■
            {
                Expression_Node_Function expr_Func = Collection_Function.NewFunction2( Expression_Node_Function45Impl.NAME_FUNCTION, 
                    parent_Expression_Null, parent_Gcav, this.Owner_MemoryApplication, pg_Logging);
                expr_Func.SetAttribute(Expression_Node_Function28Impl.PM_MESSAGE, new Expression_Leaf_StringImpl("変数出力試し", null, parent_Gcav), pg_Logging);
            }

            //  ■
            //■  ■ 「フォームCSV書出ボタン」のイベント設定
            //  ■
            {
                Expression_Node_Function expr_Func = Collection_Function.NewFunction2(Expression_Node_Function46Impl.NAME_FUNCTION,
                        parent_Expression_Null, parent_Gcav, this.Owner_MemoryApplication, pg_Logging);
                expr_Func.SetAttribute(Expression_Node_Function28Impl.PM_MESSAGE, new Expression_Leaf_StringImpl("フォームCSV出力試し", null, parent_Gcav), pg_Logging);

                this.uctButton2.UsercontroleventhandlerClick += new EventHandler(expr_Func.Execute4_OnOEa);
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// [選択]ボタンを押したとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_ChangingBtn_FoClick(object sender, EventArgs e)
        {
            //
            //
            //
            //()メソッド開始
            //
            //
            //
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports d_Logging_Click = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Toolwindow.Name_Library, this, "On_ChangingBtn_FoClick",d_Logging_Click);


            //
            //
            //
            //
            //
            //
            //

            // 選択プロジェクトXml要素。
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor;
            //プロジェクトへのファイルパス。
            string sFpatha_Project;
            {
                //選択したプロジェクトの名前。
                string sName_SelectedProject = (string)((UsercontrolListbox)this.UctlstNameProject).SelectedItem;

                if (this.Owner_MemoryApplication.MemoryForms.MemoryAatoolxmlDialog.MemoryAatoolxml.Dictionary_Editor.Dictionary_Item.ContainsKey(sName_SelectedProject))
                {
                    // 指定のプロジェクト要素が存在した場合
                    moAatoolxml_SelectedEditor = this.Owner_MemoryApplication.MemoryForms.MemoryAatoolxmlDialog.MemoryAatoolxml.Dictionary_Editor.Dictionary_Item[sName_SelectedProject];
                    sFpatha_Project = this.GetFilepathabsolute_Editor(
                        moAatoolxml_SelectedEditor,
                        d_Logging_Click
                        );
                }
                else
                {
                    // 指定のプロジェクト要素が存在しなかった場合

                    moAatoolxml_SelectedEditor = null;
                    sFpatha_Project = "";
                }
            }


            // エディター設定ファイルの読み込みの成功判定
            bool bLoaded_ProjectConfig;

            if ("" == sFpatha_Project)
            {
                // エディター設定ファイルへのパスが読み込めなかった場合
                bLoaded_ProjectConfig = false;
            }
            else
            {
                if (d_Logging_Click.Successful)
                {
                    // 正常時

                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

                    try
                    {

                        doc.Load(sFpatha_Project);

                        // 読み込むだけで終わり。
                        bLoaded_ProjectConfig = true;
                    }
                    catch (System.IO.IOException ex)
                    {
                        // 読み込みに失敗した場合。
                        bLoaded_ProjectConfig = false;

                        //#エラー扱いとはしません。
                        StringBuilder sb = new StringBuilder();

                        sb.Append("プロジェクト ファイルとして指定されたファイルは、利用できませんでした。");
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);

                        sb.Append("指定されたプロジェクト ファイル=[");
                        sb.Append(sFpatha_Project);
                        sb.Append("]");
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);

                        sb.Append("エラーメッセージ=[");
                        sb.Append(ex.Message);
                        sb.Append("]");
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);

                        this.pctxtInformation.Text = sb.ToString();
                    }
                }
                else
                {
                    bLoaded_ProjectConfig = false;
                }
            }

            //
            // プロジェクト ファイルの読み込みの有無に関わらず、
            // 外部の処理を挟み込めます。
            //
            this.onEditorSelected(
                sender,
                moAatoolxml_SelectedEditor,
                bLoaded_ProjectConfig,
                d_Logging_Click
                );

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(d_Logging_Click);
            d_Logging_Click.EndLogging(pg_Method);
        }

        //────────────────────────────────────────

        /// <summary>
        /// @Deprecated 使ってない？
        /// 
        /// リストボックスで、プロジェクト名を変更したとき。
        /// 旧名：projectNameDdl_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_ProjectNameDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports d_Logging_Click = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Toolwindow.Name_Library, this, "projectNameDdl_SelectedIndexChanged",d_Logging_Click);
            //
            //

            // 選択プロジェクト名：取得
            string sSelectedProjectName = (string)((UsercontrolListbox)this.UctlstNameProject).SelectedItem;

            // 選択プロジェクト名：セット
            this.Owner_MemoryApplication.MemoryForms.MemoryAatoolxmlDialog.Name_SelectedEditor = sSelectedProjectName;

            // エディター設定ファイルへのパス
            this.PctxtFpathProjectcnf.Text = "";



            // 内容をデバッグ出力
            //this.MemoryAatoolxmlDialog.MoToolConfig.Projects.DebugWrite();


            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor;

            if (this.Owner_MemoryApplication.MemoryForms.MemoryAatoolxmlDialog.MemoryAatoolxml.Dictionary_Editor.Dictionary_Item.ContainsKey(sSelectedProjectName))
            {
                moAatoolxml_SelectedEditor = this.Owner_MemoryApplication.MemoryForms.MemoryAatoolxmlDialog.MemoryAatoolxml.Dictionary_Editor.GetEditorByName(
                    sSelectedProjectName,true,d_Logging_Click);
                if (!d_Logging_Click.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                if (d_Logging_Click.Successful)
                {
                    // 正常時

                    moAatoolxml_SelectedEditor.Dictionary_Fsetvar_Configurationtree.List_Child.ForEach(delegate(Configurationtree_Node s_Fsetvar, ref bool bBreak)
                    {
                        string sNamevar;
                        s_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_NAME_VAR, out sNamevar, true, d_Logging_Click);

                        string sValue;
                        s_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, d_Logging_Click);

                        if (sNamevar == NamesVar.S_SP_EDITOR)
                        {
                            UsercontrolTextbox uctTxt = (UsercontrolTextbox)this.PctxtFpathProjectcnf;
                            uctTxt.ControlCommon.BAutomaticinputting = true;
                            uctTxt.Text = sValue + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_EDITOR_XML;
                            uctTxt.ControlCommon.BAutomaticinputting = false;
                        }
                    });
                }

            }
            else
            {
                // 異常時
                goto gt_Error_NotFoundProjectname;
            }
            //.WriteLine(this.GetType().Name + "#projectNameComboBoxUc_SelectedIndexChanged: selectedProjectName=[" + selectedProjectName + "] this.ProjectConfigFilePathTextBoxUc.Text=[" + this.ProjectConfigFilePathTxt.Text + "]");



            //// 更新を確定します。
            //bool commit = true;



            //// 内容をデバッグ出力
            //.WriteLine(this.GetType().Name + "#projectConfigFilePathTxt_FoTextChanged:　（１）");
            //this.MemoryAatoolxmlDialog.MoToolConfig.Projects.DebugWrite();




            //
            // 『ｐｒｏｊｅｃｔ－ｃｏｎｆｉｇ』ファイルの存在の有無を確認したい。
            //


            //// 内容をデバッグ出力
            //.WriteLine(this.GetType().Name + "#projectConfigFilePathTxt_FoTextChanged:　（２）");
            //this.MemoryAatoolxmlDialog.MoToolConfig.Projects.DebugWrite();




            //if (pg_Logging.Successful)
            //{
            //    // 正常時

            //    if (commit)
            //    {
            //        // 『ｐｒｏｊｅｃｔ－ｃｏｎｆｉｇ.xml』ファイルの存在の有無を確認したい。
            //        Flow0010 flow0010 = new Flow0010();
            //        string projectConfigXmlAbsFilePath = flow0010.GetFileAbsPath(
            //            this.ProjectConfigFilePathTxt.Text,
            //            false,//取得できなくてもエラーとしない。
            //            pg_Logging,
            //            "*projectConfigFilePathTextBoxUc_FoTextChanged(3)"
            //            );

            //        if ("" == projectConfigXmlAbsFilePath)
            //        {
            //            // 『ｐｒｏｊｅｃｔ－ｃｏｎｆｉｇ』の絶対ファイルパスを取得できなかったとき。

            //            WarningReport dReport = new WarningReportImpl();
            //            dReport.Title = "▲エラー21！(Toolwindow)";

            //            StringBuilder txt = new StringBuilder();
            //            txt.Append("(1)『ｐｒｏｊｅｃｔ－ｃｏｎｆｉｇ』ファイルへのパスがテキストボックスに入力されていませんでした。");
            //            txt.Append(Environment.NewLine);
            //            txt.Append("　　ツール設定ファイルの プロジェクト要素の内容を確かめてみてください。");
            //            txt.Append(Environment.NewLine);
            //            txt.Append(Environment.NewLine);
            //            txt.Append(this.GetType().Name);
            //            txt.Append("#projectConfigFilePathTextBoxUc_FoTextChanged:");
            //            txt.Append(Environment.NewLine);
            //            txt.Append(" テキストボックス値=[" + this.ProjectConfigFilePathTxt.Text + "]");
            //            dReport.Message = txt.ToString();

            //            pg_Logging.Add(dReport);
            //            //.WriteLine( txt.ToString() );

            //        }
            //        else
            //        {
            //            // 『ｐｒｏｊｅｃｔ－ｃｏｎｆｉｇ』の絶対ファイルパスを取得できたとき。


            //            // ツール設定ファイルの存在の有無を確認したい。
            //            string toolConfigXmlAbsFilePath = flow0010.GetFileAbsPath(
            //                ModelOfToolConfigImpl.TOOL_CONFIG_REL_FILE_PATH,
            //                false,//取得できなくてもエラーとしない。
            //                pg_Logging,
            //                "*projectConfigFilePathTextBoxUc_FoTextChanged(4)"
            //                );

            //            if ("" == toolConfigXmlAbsFilePath)
            //            {
            //                // ツール設定ファイルの絶対ファイルパスを取得できなかったとき。

            //                //.WriteLine(this.GetType().Name + "#projectConfigFilePathTextBoxUc_FoTextChanged: (2)ツール設定ファイルへのパスが取得できなかったので、変更をツール設定ファイルに保存しません。");
            //            }
            //            else
            //            {
            //                // ツール設定ファイルの絶対ファイルパスを取得できたとき。

            //                // TODO ツール設定ファイルに、『ｐｒｏｊｅｃｔ－ｃｏｎｆｉｇ.xml』の絶対パスを保存したい。

            //                //
            //                // 外部ファイルに変更を保存します。
            //                //
            //                //if (!this.ProjectConfigFilePathTxt.ControlCommon.BAutomaticinputting)
            //                //{
            //                //    // 自動入力でない場合。

            //                //    if (pg_Logging.Successful)
            //                //    {
            //                //        // 正常時

            //                //        // 『SRSグローバルリスト マージツール設定』の保存
            //                //        WriterOfToolConfig writer1 = new WriterOfToolConfig();
            //                //        writer1.Write(
            //                //            toolConfigXmlAbsFilePath,//ここは『ツール設定ファイル』が正しい。
            //                //            this.MemoryAatoolxmlDialog.ApplicationName,
            //                //            this.MemoryAatoolxmlDialog.MoToolConfig.Projects,
            //                //            pg_Logging,
            //                //            "*projectConfigFilePathTextBoxUc_FoTextChanged(5)"
            //                //            );

            //                //        // 現在のフォーム入力値は保存データと一致します。
            //                //        //TODO modelOfFormOfTcd.InvalidInput = false;
            //                //    }
            //                //}
            //            }

            //        }


            //    }
            //    else
            //    {
            //        // 現在のフォーム入力値は保存データと一致しない可能性があります。
            //        //this.MemoryAatoolxmlDialog.InvalidInput = true;
            //    }
            //}


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundProjectname:
            if (d_Logging_Click.CanCreateReport)
            {
                Log_RecordReports r = d_Logging_Click.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー902！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("プロジェクト名[" + sSelectedProjectName + "]を選択しましたが、");
                t.Append(Environment.NewLine);
                t.Append("そのプロジェクト名は　登録されていないものでした。");
                r.Message = t.ToString();
                d_Logging_Click.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(d_Logging_Click);
            d_Logging_Click.EndLogging(pg_Method);
        }

        //────────────────────────────────────────

        private void pcbtnChanging_Load(object sender, EventArgs e)
        {

        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private DELEGATE_OnEditorSelected dlgt_OnEditorSelected;

        //────────────────────────────────────────

        private event DELEGATE_OnEditorSelected onEditorSelected;

        /// <summary>
        ///『Xn_L11_Function:Expression_Node_Function_BootCsvEditorImpl#Ex_ExecuteMain』で、
        ///『this.FwFnc_OnProjectSelected』がセットされる。
        ///
        /// </summary>
        public event DELEGATE_OnEditorSelected OnEditorSelected
        {
            add
            {
                onEditorSelected += value;
            }
            remove
            {
                onEditorSelected -= value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ハードコーディングされたコントロール。
        /// </summary>
        public UserControl UctlstNameProject
        {
            get
            {
                return uclstNameProject;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ハードコーディングされたコントロール。
        /// </summary>
        public UserControl PctxtFpathProjectcnf
        {
            get
            {
                return pctxtFpathProjectcnf;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// このダイアログを呼び出しているアプリケーションの名前
        /// </summary>
        public string SName_Application
        {
            get
            {
                return this.Owner_MemoryApplication.MemoryForms.MemoryAatoolxmlDialog.Name_Application;
            }
            set
            {
                this.Owner_MemoryApplication.MemoryForms.MemoryAatoolxmlDialog.Name_Application = value;
            }
        }

        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return this.owner_MemoryApplication;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
