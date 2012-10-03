using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//Form

using Xenon.Syntax;//Log_TextIndentedImpl
using Xenon.Controls;
using Xenon.Table;//CsvTo_ListImpl
using Xenon.Middle;
using Xenon.XToGcav;
using Xenon.Expr;
using Xenon.GcavToExpr;

namespace Xenon.MiddleImpl
{
    public class MemoryFormsImpl : MemoryForms
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryFormsImpl(MemoryApplication owner_MemoryApplication)
        {
            this.Clear(owner_MemoryApplication);
        }

        /// <summary>
        /// クリアー
        /// </summary>
        public void Clear(MemoryApplication owner_MemoryApplication)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
            if (null == this.dictionary_Item)
            {
                this.dictionary_Item = new Dictionary<string, Usercontrol>();
            }
            else
            {
                this.dictionary_Item.Clear();
            }
        }

        public void InitializeBeforeUse(
            Mainwnd_FormWrapping mainwnd_FormWrapping,
            ConfigurationtreeToFunction gcavToFunc,
            Form_Toolwindow form_Toolwindow,
            MemoryAatoolxmlDialog moAatoolxmlDialog,
            UsercontrolStyleSetter ucontrolStyleSetter,
            UsercontrolCreator1 ucontrolCreator1,
            XToMemory_Form xToM_FormImpl
            )
        {
            this.Mainwnd_FormWrapping = mainwnd_FormWrapping;
            this.givechapterandverseToFunction = gcavToFunc;
            this.ucontrolCreator1 = ucontrolCreator1;
            this.xToMemory_Form = xToM_FormImpl;

            this.form_Toolwindow = form_Toolwindow;
            //this.form_Toolwindow.InitializeBeforeUse(owner_MemoryApplication);
            this.moAatoolxmlDialog = moAatoolxmlDialog;

            this.ucontrolStyleSetter = ucontrolStyleSetter;
        }

        /// <summary>
        /// フォーム上の、コントロールを除外していきます。
        /// メインウィンドウ自身は除外せず残します。
        /// 
        /// todo:イベントハンドラーを外してから、フォームを外すこと。リストボックスが誤挙動を起こしている。
        /// </summary>
        /// <param name="formControls"></param>
        /// <param name="log_Reports"></param>
        public void ClearForms(
            Control.ControlCollection formControls,
            Log_Reports log_Reports
            )
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "ClearForms",log_Reports);


            if (log_Reports.Successful)
            {
                Control mainwnd = this.Mainwnd_FormWrapping.Form;

                //
                //
                //
                //（１）フォームに登録されているコントロール全ての、イベントハンドラーを外す。
                //
                //
                //
                this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol uct, ref bool bRemove, ref bool bBreak)
                {
                    if (log_Reports.Successful)
                    {
                        if (mainwnd != uct)
                        {
                            uct.ClearAllEventhandlers(log_Reports);
                        }
                        else
                        {
                            log_Method.WriteDebug_ToConsole("（１）メインウィンドウを除く。");
                        }
                    }
                });

                //
                //
                //
                //（２）フォームに登録されているコントロール全てを、クリアーする。
                //
                //
                //
                this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol uct, ref bool bRemove, ref bool bBreak)
                {
                    if (log_Reports.Successful)
                    {
                        if (mainwnd != uct)
                        {
                            uct.Clear();
                        }
                        else
                        {
                            log_Method.WriteDebug_ToConsole("（２）メインウィンドウを除く。");
                        }
                    }
                });

                //
                //
                //
                //（３）フォームを構成しているカスタム・コントロール全てを、破棄する。
                //
                //
                //
                this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol uct, ref bool bRemove, ref bool bBreak)
                {
                    if (log_Reports.Successful)
                    {
                        if (mainwnd != uct)
                        {
                            uct.DestractAllCustomcontrols(log_Reports);
                        }
                        else
                        {
                            log_Method.WriteDebug_ToConsole("（３）メインウィンドウを除く。");
                        }
                    }
                });

                //
                //
                //
                //（４）フォームに登録されているコントロール全てを、除外する。
                //
                //
                //
                this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol uct, ref bool bRemove, ref bool bBreak)
                {
                    if (log_Reports.Successful)
                    {
                        if (mainwnd != uct)
                        {
                            formControls.Remove((Control)uct);
                        }
                        else
                        {
                            log_Method.WriteDebug_ToConsole("（４）メインウィンドウを除く。");
                        }
                    }
                });

                //
                // ＣＳＶＥｘＥに登録されているコントロールの一覧を空にします。
                //
                this.Clear(this.Owner_MemoryApplication);
                //this.dic_Item.Add(NamesSc.S_MAINWND, (Usercontrol)mainwnd);
            }

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }
        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『コントロール設定ファイル(F)』を読み取ります。
        /// 
        /// X→S、S→E、S→A。
        /// </summary>
        public void LoadFile(
            RecordUserformconfig fo_Record,
            Expression_Node_Filepath ec_Fopath_Forms,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "LoadFile",log_Reports);
            //
            //

            // 手入力の Fcnf ファイルパス
            Configurationtree_NodeFilepath cf_Fpath_Control;
            fo_Record.TryGetFilepath_Configurationtree(out cf_Fpath_Control, NamesFld.S_FILE, false, this.Owner_MemoryApplication, log_Reports);
            string sFpathH_F = cf_Fpath_Control.GetHumaninput();

            string sName_Control;
            fo_Record.TryGetString(out sName_Control, NamesFld.S_NAME, true, "", this.Owner_MemoryApplication, log_Reports);

            // FILE フィールド（ファイルパス）が未指定なら、処理せず。
            if (log_Reports.Successful)
            {
                if ("" == sFpathH_F)
                {
                    goto gt_EndMethod;
                }
            }

            // (F) 絶対ファイルパス
            string sFpatha_F;
            {
                Utility_XToConfigurationtree_Usercontrolconfig to = new Utility_XToConfigurationtree_Usercontrolconfig();

                Expression_Node_FilepathImpl ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath_Control);

                sFpatha_F = to.GetSFilepath_UsercontrolconfigAbsolute(
                    ec_Fpath,//sl_record.Cf_File,
                    ec_Fopath_Forms,
                    log_Reports
                    );
            }

            //
            // Fcnf ファイルパス
            Expression_Node_Filepath ec_Fpath_F;
            {
                Configurationtree_Node parent_Cf = new Configurationtree_NodeImpl(log_Method.Fullname + ".LoadFcnfFile record[" + cf_Fpath_Control.GetHumaninput() + "]", null);

                Configurationtree_NodeFilepath cf_Fpath = new Configurationtree_NodeFilepathImpl("ファイルパス出典未指定L09Mid_3", parent_Cf);
                cf_Fpath.InitPath(sFpathH_F, sFpatha_F, log_Reports);
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                ec_Fpath_F = new Expression_Node_FilepathImpl(cf_Fpath);
            }

            if ("" == sFpatha_F)
            {
                // コンポーネント設定ファイルへのパスが指定されていなければ、処理しません。
                goto gt_Error_Fpath;
            }


            Configurationtree_Node cf_ControlConfig = new Configurationtree_NodeImpl(NamesNode.S_CODEFILE_CONTROLS, ec_Fpath_F.Cur_Configurationtree);


            //
            // X → S
            if (log_Reports.Successful)
            {
                XToConfigurationtree_C11_Config to = new XToConfigurationtree_C11_ConfigImpl();
                to.XToConfigurationtree(
                    sName_Control,
                    sFpathH_F,
                    sFpatha_F,
                    cf_ControlConfig,
                    ec_Fopath_Forms,
                    owner_MemoryApplication,
                    log_Reports
                    );
            }


            //
            // (F) X → E
            this.XToEc_Usercontrolconfig(
                cf_ControlConfig,
                fo_Record,
                ec_Fopath_Forms,
                log_Reports
                );

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Fpath:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("△情報53！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("コンポーネント設定ファイルへのパスが指定されていないので、");
                s.Newline();
                s.Newline();
                s.Append("処理しません。");
                s.Newline();
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// コントロールに、データソース、データターゲットを設定していきます。
        ///
        /// 『レイアウト設定ファイル』に記述されている、
        /// FILE列 で示された『コンポーネント設定ファイル』を読み取っていきます。
        ///
        /// 
        /// 備考：「モンスター・レギオン・エディター」で使用中。
        /// </summary>
        public void SetupUsercontrolconfigs(
            TableUserformconfig fo_Config,
            Expression_Node_Filepath ec_Fopath_Forms,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "SetupFcnfs",log_Reports);
            //

            if (log_Reports.Successful)
            {
                // 正常時

                // 
                // コントロールのプロパティー設定ファイルに記述されている、
                // FILE列 で示されたコンポーネント設定ファイルをもとに、
                // コントロールにデータ・ソースと、データ・ターゲットを動的に追加します。
                // 

                foreach (RecordUserformconfig fo_Record in fo_Config.List_RecordUserformconfig)
                {
                    Configurationtree_NodeFilepath cf_Fpath_Control;
                    fo_Record.TryGetFilepath_Configurationtree(out cf_Fpath_Control, NamesFld.S_FILE, false, this.Owner_MemoryApplication, log_Reports);

                    Expression_Node_Filepath e_Fpath_Usercontrol = new Expression_Node_FilepathImpl(cf_Fpath_Control);

                    this.Owner_MemoryApplication.MemoryForms.LoadFile(
                        fo_Record,
                        ec_Fopath_Forms,
                        log_Reports
                    );
                }
            }


            //.WriteLine(this.GetType().Name + "#LoadFcnfs: 【終了】");

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// レイアウトを設定します。
        /// 
        /// ファイルパスの入っている変数の名前を指定します。
        /// </summary>
        /// <param name="listO_Table_Form">フォーム設定テーブル。</param>
        /// <param name="oFolderPath_forms">formsフォルダーの、ファイルパス。</param>
        /// <param name="startupPath"></param>
        /// <param name="form"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public void SetupFormAndLoadUsercontrolconfigs(
            List<XenonTable> listO_Table_Form,
            Expression_Node_Filepath ec_Fopath_Forms,
            Form form,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "SetupFormAndLoadUsercontrolconfigs", log_Reports);
            //
            //

            // テーブル名別_設定マップ
            Dictionary<string, TableUserformconfig> dicFo_ByTable = new Dictionary<string, TableUserformconfig>();
            // レイアウト_グループ別_設定マップ
            Dictionary<string, TableUserformconfig> dicFo_ByGroup = new Dictionary<string, TableUserformconfig>();



            //
            // （Ｆ１）テーブル毎にレイアウト設定
            foreach (XenonTable o_Table_Form in listO_Table_Form)
            {
                string sTableName = o_Table_Form.Name;


                TableUserformconfig fo_Config_ByTable;
                if (dicFo_ByTable.ContainsKey(sTableName))
                {
                    fo_Config_ByTable = dicFo_ByTable[sTableName];
                }
                else
                {
                    fo_Config_ByTable = new TableUserformconfigImpl(
                        o_Table_Form.Name,
                        new Configurationtree_NodeImpl(
                            NamesNode.S_FORM_CONFIG,
                            o_Table_Form.Expression_Filepath_ConfigStack.Cur_Configurationtree//Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports)
                        ));
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                    dicFo_ByTable.Add(sTableName, fo_Config_ByTable);
                }


                //
                // コントロールのスタイルを設定します。
                this.P1_XToMemory_Userformconfig(
                    fo_Config_ByTable,
                    o_Table_Form,
                    log_Reports
                    );
            }

            //
            // （Ｆ２）テーブルユニット毎にレイアウト設定。
            foreach (XenonTable o_Table_Form in listO_Table_Form)
            {
                string sTableUnit = o_Table_Form.Tableunit;


                TableUserformconfig fo_Config_ByGroup;
                if (dicFo_ByGroup.ContainsKey(sTableUnit))
                {
                    fo_Config_ByGroup = dicFo_ByGroup[sTableUnit];
                }
                else
                {
                    fo_Config_ByGroup = new TableUserformconfigImpl(
                        o_Table_Form.Name,
                        new Configurationtree_NodeImpl(NamesNode.S_FORM_CONFIG,
                        o_Table_Form.Expression_Filepath_ConfigStack.Cur_Configurationtree//Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports)
                        ));
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                    dicFo_ByGroup.Add(sTableUnit, fo_Config_ByGroup);
                }


                //
                // コントロールのスタイルを設定します。
                this.P1_XToMemory_Userformconfig(
                    fo_Config_ByGroup,
                    o_Table_Form,
                    log_Reports
                    );
            }


            //
            // （Ｆ３）グループ毎にレイアウト作成、スタイル適用。
            foreach (TableUserformconfig fo_Config_ByGroup in dicFo_ByGroup.Values)
            {
                this.P2_CreateForm(
                    fo_Config_ByGroup,
                    form,
                    log_Reports
                    );

                this.P3_ApplyStyleToUsercontrol(
                    fo_Config_ByGroup,
                    log_Reports
                    );

                //
                // （４）コントロール１つ１つに、データソース、データターゲットを設定していきます。
                if (log_Reports.Successful)
                {
                    //
                    // コントロールに、データソース、データターゲットを設定していきます。
                    //
                    //　　　　 『レイアウト設定ファイル』に記述されている、
                    //　　　　 FILE列 で示されたコンポーネント設定ファイルをもとに。
                    //
                    this.Owner_MemoryApplication.MemoryForms.SetupUsercontrolconfigs(
                        fo_Config_ByGroup,
                        ec_Fopath_Forms,
                        log_Reports
                        );
                }
            }

            //
        //
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// コントロールのスタイルを設定します。
        /// </summary>
        /// <param name="fo_Config"></param>
        /// <param name="oFolderPath_forms"></param>
        /// <param name="form"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public void P1_XToMemory_Userformconfig(
            TableUserformconfig fo_Config,
            XenonTable o_Table_Form,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "P1_XToMemory_Userformconfig", log_Reports);
            //
            //

            if (log_Reports.Successful)
            {
                // 正常時

                this.xToMemory_Form.LoadUserformconfigFile(
                    fo_Config,
                    o_Table_Form,
                    this.Owner_MemoryApplication,
                    log_Reports
                    );

            }
            else
            {
                //config_form = null;
            }

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// コントロールのスタイルを設定します。
        /// </summary>
        /// <param name="fo_Config"></param>
        /// <param name="oFolderPath_forms"></param>
        /// <param name="form"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public void P2_CreateForm(
            TableUserformconfig fo_Config,
            Form form,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "P2_CreateForm",log_Reports);
            //
            //

            //
            // コントロールを動的に追加。
            if (log_Reports.Successful)
            {
                // 正常時

                // （プロパティーの設定はまだ行いません。）
                this.CreateForm(
                    fo_Config,
                    form,
                    log_Reports
                    );
            }

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// コントロールのスタイルを設定します。
        /// </summary>
        /// <param name="fo_Config"></param>
        /// <param name="oFolderPath_forms"></param>
        /// <param name="form"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public void P3_ApplyStyleToUsercontrol(
            TableUserformconfig fo_Config,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "P3_ApplyStyleToFc",log_Reports);
            //
            //

            //
            // コントロールのスタイルを設定。
            if (log_Reports.Successful)
            {
                // 正常時

                // 　　　　コントロール連想配列作成後。
                // 　　　　（旧・データ・ソースと、データ・ターゲットを設定した後で）

                this.Owner_MemoryApplication.MemoryForms.UsercontrolStyleSetter.SetupStyle(
                    fo_Config,
                    this.Owner_MemoryApplication,
                    log_Reports
                    );
            }


            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }


        /// <summary>
        /// 『レイアウト設定ファイル』をもとに、コントロールを作成し、
        /// フォームと、アプリケーション・モデルにコントロールを動的に追加します。
        /// </summary>
        /// <param name="fo_Config"></param>
        /// <param name="form"></param>
        protected void CreateForm(
            TableUserformconfig fo_Config,
            Form form,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "CreateForm",log_Reports);
            //
            //

            //this.form_noren = form;

            // レイアウトするロジックを一時停止。（メインフォーム）
            form.SuspendLayout();

            // フォームにステータスバーを付けます。（デバッグモードでのみ） TODO:１回限りであること。
            if (null == statusStrip1 && Log_ReportsImpl.BDebugmode_Static)
            {
                statusStrip1 = new System.Windows.Forms.StatusStrip();

                // 
                // statusStrip1
                // 
                statusStrip1.Location = new System.Drawing.Point(0, 244);
                statusStrip1.Name = "statusStrip1";
                statusStrip1.Size = new System.Drawing.Size(292, 22);
                statusStrip1.TabIndex = 0;
                statusStrip1.Text = "statusStrip1";

                this.statusStripLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
                this.statusStripLabel2.Name = "toolStripStatusLabel1";
                this.statusStripLabel2.Size = new System.Drawing.Size(114, 17);
                this.statusStripLabel2.Text = "toolStripStatusLabel1";
                this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.statusStripLabel2});

                form.Controls.Add(statusStrip1);

                // #情報
                if (log_Method.CanInfo())
                {
                    log_Method.WriteInfo_ToConsole("ステータスバーをフォームに追加した。（デバッグモードでのみ）TODO:１回限りであること。");
                }
            }

            //// フォームに「マルチロール_テキストボックス」を付けます。 TODO:１回限りであること。
            //if (null == this.multiroleTextBox)
            //{
            //    this.multiroleTextBox = new System.Windows.Forms.TextBox();
            //    this.multiroleTextBox.Multiline = true;
            //    form.Controls.Add(this.multiroleTextBox);

            //    // #デバッグ
            //    ystem.Console.WriteLine(Info_NorenImpl.LibraryName + ":MoNorenImpl#CreateForm:マルチロール_テキストボックスをフォームに追加した。TODO:１回限りであること。");
            //}

            // 1つ前のコントロールが入っている仕組み。
            List<Usercontrol> list_StackFc = new List<Usercontrol>();
            List<int> nList_StackTree = new List<int>();

            //
            // レコードの並び順は、記述されている順番とします。
            //
            foreach (RecordUserformconfig fo_Record in fo_Config.List_RecordUserformconfig)
            {
                int nCurTree;
                fo_Record.TryGetInt(out nCurTree, NamesFld.S_TREE, true, -1, this.Owner_MemoryApplication, log_Reports);

                //
                //
                // ここで、コントロール（UserControl）を作成。
                // 作成できなかった、または作成しなかった場合はヌル。
                //
                //
                Usercontrol uct = ucontrolCreator1.Create(
                    fo_Record,
                    true,
                    this.Owner_MemoryApplication,
                    log_Reports
                    );



                //.WriteLine(this.GetType().Name + "#CreateForm: (10) この要素=[" + fcUc.ControlCommon.Name + "] curTree=[" + curTree + "]");

                if (log_Reports.Successful)
                {
                    if (null != uct)
                    {
                        string sName_Control;
                        fo_Record.TryGetString(out sName_Control, NamesFld.S_NAME, true, "", this.Owner_MemoryApplication, log_Reports);


                        Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(null, fo_Record.Parent_TableUserformconfig.Cur_Configurationtree);
                        ec_Str.AppendTextNode(
                            sName_Control,
                            fo_Record.Parent_TableUserformconfig.Cur_Configurationtree,
                            log_Reports
                            );

                        //
                        //
                        // コントロール名の登録。
                        //
                        //
                        this.Owner_MemoryApplication.MemoryForms.PutUsercontrol(
                            ec_Str,
                            uct,
                            log_Reports
                            );


                        if (uct is UsercontrolWindow)
                        {
                            //
                            // 「ウィンドウ」（別窓）を開けたい場合。
                            //
                            UsercontrolWindow uctWnd = (UsercontrolWindow)uct;

                            //ucWindow.SetupStatusStrip();
                            uctWnd.CustomcontrolWindow1.Show();


                            //.WriteLine(this.GetType().Name + "#CreateForm: (20) 【ウィンドウ追加】トップに、この要素=[" + fcUc.ControlCommon.Name + "]を追加。");
                        }
                        else
                        {

                            if (0 == nList_StackTree.Count)
                            {
                                //
                                // ★追加：   メインフォームのトップに、この要素を追加
                                //
                                form.Controls.Add((Control)uct);

                                // 普通、メインウィンドウもここになる。
                            }
                            else
                            {
                                int nPrevTree = nList_StackTree.Last();

                                if (nPrevTree == nCurTree)
                                {
                                    // 1つ前の要素と ツリー値が同じなら、

                                    // 1つ前の要素をスタックから削除し、
                                    list_StackFc.RemoveAt(list_StackFc.Count - 1);
                                    nList_StackTree.RemoveAt(nList_StackTree.Count - 1);

                                    if (0 != nList_StackTree.Count)
                                    {
                                        nPrevTree = nList_StackTree.Last();

                                        //
                                        // ★追加：   前の要素（スタックの最後の要素）に、この要素を追加。
                                        //
                                        Usercontrol prevUc = list_StackFc.Last();

                                        prevUc.AppendChild(
                                            uct,
                                            log_Reports
                                            );

                                        //.WriteLine(this.GetType().Name + "#CreateForm: (40) 【前の要素に、この要素を追加】 前の要素=[" + prevUc.ControlCommon.Name + "]に、この要素=[" + fcUc.ControlCommon.Name + "]を追加。");
                                    }
                                    else
                                    {
                                        nPrevTree = 0;

                                        //
                                        // ★追加：   メインフォームのトップに、この要素を追加
                                        //
                                        form.Controls.Add((Control)uct);

                                        //.WriteLine(this.GetType().Name + "#CreateForm: (50) 【メインフォームのトップ要素として追加2】 メインフォームのトップに、この要素=[" + fcUc.ControlCommon.Name + "]を追加。");
                                    }
                                }
                                else if (nPrevTree < nCurTree)
                                {
                                    // 1つ前の要素より、大きなtree値を持つなら、

                                    //
                                    // ★追加：　1つ前の要素に、この要素を追加。
                                    //
                                    Usercontrol prevUc = list_StackFc.Last();

                                    prevUc.AppendChild(
                                        uct,
                                        log_Reports
                                        );

                                    //.WriteLine(this.GetType().Name + "#CreateForm: (60) 【前の要素に、この要素を追加】 前の要素=[" + prevUc.ControlCommon.Name + "]に、この要素=[" + fcUc.ControlCommon.Name + "]を追加。");
                                }
                                else
                                {
                                    // 1つ前の要素より、小さなtree値を持つなら、

                                    //
                                    // ★削除：
                                    // 　　自分より小さなtree値を持つ要素が出てくるまで、
                                    // 　　前の要素を消す。
                                    //
                                    list_StackFc.RemoveAt(list_StackFc.Count - 1);
                                    nList_StackTree.RemoveAt(nList_StackTree.Count - 1);
                                    //.WriteLine(this.GetType().Name + "#CreateForm: (70) 【前要素削除】 この要素=[" + fcUc.ControlCommon.Name + "]");

                                    //
                                    // foreachループの中で、リストの要素数が変わると、
                                    // foreachループは失敗する。
                                    //
                                    // whileループを使うことにする。
                                    //
                                    while (0 < nList_StackTree.Count)
                                    {
                                        Usercontrol prevUc = list_StackFc.Last();
                                        nPrevTree = nList_StackTree.Last();

                                        if (nCurTree <= nPrevTree)
                                        {
                                            list_StackFc.RemoveAt(list_StackFc.Count - 1);
                                            nList_StackTree.RemoveAt(nList_StackTree.Count - 1);
                                            //.WriteLine(this.GetType().Name + "#CreateForm: (80) 【前要素削除】 この要素=[" + fcUc.ControlCommon.Name + "] 前の要素=[" + prevUc.ControlCommon.Name + "]");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }


                                    if (0 == nList_StackTree.Count)
                                    {
                                        // 空っぽになったらループを止める。
                                        // エラー？
                                        nPrevTree = -1;
                                    }
                                    else
                                    {
                                        nPrevTree = nList_StackTree.Last();
                                    }


                                    if (0 == nList_StackTree.Count)
                                    {
                                        //
                                        // ★追加：   メインフォームのトップに、この要素を追加
                                        //
                                        form.Controls.Add((Control)uct);

                                        //.WriteLine(this.GetType().Name + "#CreateForm: (90) 【メインフォームのトップ要素として追加3】 メインフォームのトップに、この要素=[" + fcUc.ControlCommon.Name + "]を追加。");
                                    }
                                    else
                                    {
                                        //
                                        // ★追加：　1つ前の要素に、この要素を追加。
                                        //
                                        Usercontrol prevUc = list_StackFc.Last();

                                        prevUc.AppendChild(
                                            uct,
                                            log_Reports
                                            );

                                        //.WriteLine(this.GetType().Name + "#CreateForm: (100) 【前の要素に、この要素を追加】 前の要素=[" + prevUc.ControlCommon.Name + "]に、この要素=[" + fcUc.ControlCommon.Name + "]を追加。");
                                    }


                                }
                            }
                        }

                    }
                }

                list_StackFc.Add(uct);
                nList_StackTree.Add(nCurTree);
            }

            // レイアウトの一時停止を解除。レイアウト実行の強制はしない。（メインフォーム）
            form.ResumeLayout(false);

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 『コントロール設定ファイル(Fcnf)』を読み取ります。
        /// 
        /// X→S、S→E、X→A。
        /// </summary>
        public void XToEc_Usercontrolconfig(
            Configurationtree_Node cf_FcConfig,
            RecordUserformconfig fo_Record,
            Expression_Node_Filepath ec_Fopath_Forms,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "XToEc_Usercontrolcnf",log_Reports);

            //
            //

            //
            // 手入力の (Fcnf) ファイルパス
            Configurationtree_NodeFilepath cf_Fpath_Control;
            fo_Record.TryGetFilepath_Configurationtree(out cf_Fpath_Control, NamesFld.S_FILE, false, this.Owner_MemoryApplication, log_Reports);
            string sFpath_f = cf_Fpath_Control.GetHumaninput();

            //
            // コントロール名。
            string sName_Control;
            fo_Record.TryGetString(out sName_Control, NamesFld.S_NAME, true, "", this.Owner_MemoryApplication, log_Reports);

            //
            // (Fcnf) 絶対ファイルパス
            string sFpatha_f;
            {
                Utility_XToConfigurationtree_Usercontrolconfig to = new Utility_XToConfigurationtree_Usercontrolconfig();

                Expression_Node_FilepathImpl e_Fpath = new Expression_Node_FilepathImpl(cf_Fpath_Control);

                sFpatha_f = to.GetSFilepath_UsercontrolconfigAbsolute(
                    e_Fpath,//sl_record.Cf_File,
                    ec_Fopath_Forms,
                    log_Reports
                    );
            }


            //
            // X → S　（データソース、データターゲットの変換）
            // S → E
            //
            if (log_Reports.Successful)
            {
                Utility_XToConfigurationtree_Usercontrolconfig to1 = new Utility_XToConfigurationtree_Usercontrolconfig();

                List<string> sList_ControlName = to1.GetList_NameControl(
                    sName_Control,
                    sFpath_f,
                    sFpatha_f,
                    cf_FcConfig,
                    ec_Fopath_Forms,
                    log_Reports
                    );


                Log_TextIndented_ConfigurationtreeToExpressionImpl pg_ParsingLog = new Log_TextIndented_ConfigurationtreeToExpressionImpl();
                pg_ParsingLog.BEnabled = false;
                ConfigurationtreeToExpression_F10_ControlList to2 = new ConfigurationtreeToExpression_F10_ControlListImpl();
                to2.Translate(
                    sList_ControlName,
                    cf_FcConfig,
                    this.Owner_MemoryApplication,
                    pg_ParsingLog,
                    log_Reports
                    );
                if (Log_ReportsImpl.BDebugmode_Static && pg_ParsingLog.BEnabled)
                {
                    log_Method.WriteInfo_ToConsole(" parsingLog=" + pg_ParsingLog.ToString());
                }
            }



            //
            // X → A　（イベント_アクション_リストを構築します）
            //
            if (log_Reports.Successful)
            {
                //
                // （１）コントロールの名前を指定。
                //
                List<Usercontrol> list_Usercontrol;
                {
                    Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(null, fo_Record.Parent_TableUserformconfig.Cur_Configurationtree);
                    ec_Str.AppendTextNode(
                        sName_Control,
                        fo_Record.Parent_TableUserformconfig.Cur_Configurationtree,
                        log_Reports
                        );

                    list_Usercontrol = this.Owner_MemoryApplication.MemoryForms.GetUsercontrolsByName(
                        ec_Str,
                        true,
                        log_Reports
                        );
                }

                if (0 < list_Usercontrol.Count)
                {
                    Usercontrol uct = list_Usercontrol[0];

                    if (null != uct.ControlCommon.Configurationtree_Control)
                    {
                        //
                        // 「コントロール設定ファイル」のあったコントロールの
                        // 場合に限る。
                        //

                        List<Configurationtree_Node> cfList_Event = uct.ControlCommon.Configurationtree_Control.GetChildrenByNodename(NamesNode.S_EVENT, false, log_Reports);

                        foreach (Configurationtree_Node cf_Event in cfList_Event)
                        {
                            ConfigurationtreeToExpression_Event sToE_Event = new ConfigurationtreeToExpression_EventImpl();
                            sToE_Event.Configurationtree_Event = cf_Event;
                            Functionlist felist = uct.CreateFunctionlist(
                                sToE_Event,
                                this.Owner_MemoryApplication,
                                log_Reports
                                );
                            sToE_Event.Owner_Functionlist = felist;
                        }

                        //
                        // TODO:「dt」「txa」コントロールの場合、
                        // 値が変わったイベントの時に、「値確定」アクションが必ず起動するように
                        // 自動設定したい。
                        //

                    }
                }

            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void ForEach_Children(DELEGATE_Usercontrol_Children dlgt1)
        {
            bool bBreak = false;
            bool bRemove = false;

            // 読取り順は予想できない。
            foreach (KeyValuePair<string, Usercontrol> kvP in this.dictionary_Item)
            {
                dlgt1(kvP.Key, kvP.Value, ref bRemove, ref bBreak);

                if (bRemove)
                {
                    this.dictionary_Item.Remove(kvP.Key);
                    bRemove = false;
                }

                if (bBreak)
                {
                    break;
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロール集のディクショナリー。
        /// 
        /// コントロールの名前の先頭文字を指定し、その名前で始まるコントロールのみ返す。
        /// </summary>
        public Dictionary<string, Usercontrol> ItemsStartsWith(
            string sStarts,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "ItemsStartsWith",log_Reports);
            //
            //

            Dictionary<string, Usercontrol> dic = new Dictionary<string, Usercontrol>();

            this.ForEach_Children(delegate(string sKey, Usercontrol fcUc, ref bool bRemove, ref bool bBreak)
            {
                string sFcName = fcUc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                if (log_Reports.Successful && sFcName.StartsWith(sStarts))
                {
                    dic.Add(sFcName, fcUc);
                }
            });

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
            return dic;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 名前を指定すると、コントロールを返します。
        /// 名前は、カンマ区切りでの複数件にも対応しています。
        /// </summary>
        /// <param select="nFcName">コントロール名。</param>
        /// <param select="bRequired">該当しなかった場合に処理失敗扱いとするなら真。</param>
        /// <returns>該当しなかった場合はヌルを返します。</returns>
        public List<Usercontrol> GetUsercontrolsByName(
            Expression_Node_String ec_FcName,//Parent_Nodeとしても使う。
            bool bRequired,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "GetUsercontrolsByName",log_Reports);

            //
            //
            //
            //

            string sFcNameCsv;
            string err_SFcName;
            List<Usercontrol> list_FcUc = new List<Usercontrol>();
            if (log_Reports.Successful)
            {
 
                if (null == ec_FcName)
                {
                    //
                    // 必ずエラー。
                    goto gt_Error_NullName;
                }

                // コントロール名。カンマ区切りかも知れない。
                sFcNameCsv = ec_FcName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                List<string> sList_FcName = new CsvTo_ListImpl().Read(sFcNameCsv);

                foreach (string sFcName_humanInput in sList_FcName)
                {
                    if (log_Reports.Successful)
                    {
                        // コントロール名の前後のスペースは切り落とします。
                        string sFcName = sFcName_humanInput.Trim();

                        //TODO:末尾に「*」（dirty再読込要求）が付いてたら外したい。
                        if (sFcName.EndsWith("*"))
                        {
                            sFcName = sFcName.Substring(0, sFcName.Length - 1);
                        }


                        Usercontrol ucFc;

                        if (!this.dictionary_Item.ContainsKey(sFcName))
                        {
                            // 該当なし＝無視orエラー

                            ucFc = null;

                            if (bRequired)
                            {
                                // エラー
                                err_SFcName = sFcName;
                                goto gt_Error_NotFoundFc;
                            }
                        }
                        else
                        {
                            ucFc = this.dictionary_Item[sFcName];

                            if (bRequired && null == ucFc)
                            {
                                // エラー
                                err_SFcName = sFcName;
                                goto gt_Error_NullFc;
                            }
                        }

                        list_FcUc.Add(ucFc);
                    }
                }

                if (bRequired && list_FcUc.Count < 1)
                {
                    // エラー
                    goto gt_Error_ZeroCount;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_ZeroCount:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー340！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("1件以上のコントロールが該当することが条件でしたが、0件しか該当しませんでした。指定コントロール名=[");
                s.Append(sFcNameCsv);
                s.Append("]");
                s.Newline();
                s.Newline();

                s.Append("もしかして？　：中身が空の変数を指定していませんか？");
                s.Newline();
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullName:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー341！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("コントロールの名前が指定されていません。");
                s.Newline();
                s.Newline();

                s.Append("もしかして？　：<action>要素に引数を指定していますか？");
                s.Newline();
                s.Newline();

                // ヒント

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NullFc:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー932！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("プログラム・エラー！");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);
                t.Append("[");
                t.Append(err_SFcName);
                t.Append("]という名前のコントロールは、名前は登録されていましたがヌルでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotFoundFc:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー372！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("[");
                t.Append(err_SFcName);
                t.Append("]という名前のコントロールは登録されていませんでした。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configurationtree(ec_FcName.Cur_Configurationtree));

                t.Append("一覧：");
                this.ForEach_Children(delegate(string sKey, Usercontrol fcUc, ref bool bRemove, ref bool bBreak)
                {
                    t.Append(sKey);
                    t.Append(Environment.NewLine);
                });
                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return list_FcUc;
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロールを削除します。
        /// </summary>
        /// <param select="nFcName">コントロール名。</param>
        /// <returns></returns>
        public bool RemoveUsercontrol(
            Expression_Node_String ec_FcName,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "RemoveUsercontrol",log_Reports);
            //
            //

            string sFcName = ec_FcName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
            bool bResult = this.dictionary_Item.Remove(sFcName);

            //
            //
            //
            //

            log_Method.EndMethod(log_Reports);
            return bResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロール（UserControl）を追加します。
        /// </summary>
        /// <param select="nFcName">コントロール名。</param>
        /// <param select="fcUc"></param>
        public void PutUsercontrol(
            Expression_Node_String ec_FcName,
            Usercontrol fcUc,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "PutUsercontrol",log_Reports);
            //
            //

            string sFcName = ec_FcName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);


            if (fcUc is Control)
            {
                this.dictionary_Item[sFcName] = fcUc;
            }
            else
            {
                MessageBox.Show(
                    "コントロール[" + sFcName + "]は Control ではありませんでした。",
                    "▲プログラム・エラー86！"
                    );
            }

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロールに、最新のデータを表示します。
        /// </summary>
        /// <param select="cfTg_Together">トゥゲザー要素です。</param>
        /// <param select="cfTg_Config_Hint">トゥゲザー登録ファイルです。ヒント用。</param>
        /// <param select="log_Reports"></param>
        public void RefreshDataByTogether(
            Configurationtree_Node cfTg_Together,
            Configurationtree_Node cfTg_Config_Hint,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "RefreshDataByTogether",log_Reports);
            //
            //

            // ＜ｒｅｆｒｅｓｈｅｒ＞が無いものもある。その場合は無視する。
            if (null == cfTg_Together)
            {
                goto gt_EndMethod;
            }

            if (log_Reports.Successful)
            {
                //
                //
                //
                // （１）ターゲット名（コントロール名）のリスト
                //
                //
                //
                List<Configurationtree_Node> cfList_RfrTarget = cfTg_Together.GetChildrenByNodename(NamesNode.S_TARGET, false, log_Reports);


                foreach (Configurationtree_Node cf_RfrTarget in cfList_RfrTarget)
                {
                    this.RefreshUsercontrol(
                        cf_RfrTarget,
                        cfTg_Together,
                        cfTg_Config_Hint,
                        log_Reports
                        );
                }

            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        private void RefreshUsercontrol(
            Configurationtree_Node cf_TgTarget,
            Configurationtree_Node cf_TgTogether,
            Configurationtree_Node cf_RfrConfig_Hint,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "RefreshUsercontrol",log_Reports);
            //
            //
            Expression_Node_String err_EFcName;

            //
            //
            // 1:ターゲットの再表示
            // 所要時間目安[?]ミリ秒ほど
            //
            //

            if (log_Reports.CanStopwatch)
            {
                // コメント作成
                {
                    StringBuilder sb = new StringBuilder();

                    string sName_Together;
                    {
                        bool bHit = cf_TgTogether.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_Together, false, log_Reports);
                    }

                    string sIn_Together;
                    {
                        bool bHit = cf_TgTogether.Dictionary_Attribute.TryGetValue(PmNames.S_IN, out sIn_Together, false, log_Reports);
                    }

                    string sTarget_Together;
                    {
                        bool bHit = cf_TgTogether.Dictionary_Attribute.TryGetValue(PmNames.S_TARGET1, out sTarget_Together, false, log_Reports);
                    }

                    sb.Append("　Together-");

                    if ("" != sName_Together)
                    {
                        sb.Append("name[");
                        sb.Append(sName_Together);
                        sb.Append("]");
                    }

                    if ("" != sIn_Together)
                    {
                        sb.Append("in[");
                        sb.Append(sIn_Together);
                        sb.Append("]");
                    }

                    sb.Append(".TRGT[");
                    sb.Append(sTarget_Together);
                    sb.Append("]");

                    log_Method.Log_Stopwatch.Message = sb.ToString();
                }

                log_Method.Log_Stopwatch.Begin();
            }


            string sName_TgTarget;
            bool bDirty = false;
            if (log_Reports.Successful)
            {
                // ｔａｒｇｅｔ.NNの文字列表現
                cf_TgTarget.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_TgTarget, true, log_Reports);

                //TODO:末尾に「*」（dirty再読込要求）が付いてたら外したい。
                if (sName_TgTarget.EndsWith("*"))
                {
                    sName_TgTarget = sName_TgTarget.Substring(0, sName_TgTarget.Length - 1);
                    // デバッグ
                    //ystem.Console.WriteLine(Info_OpyopyoImpl.LibraryName + ":MemoryFormsImpl#RefreshDataByRefreaher:　末尾の*を取り除いた。sTargetName=[" + sTargetName + "]");
                    bDirty = true;
                }
            }
            else
            {
                sName_TgTarget = "";
            }



            //
            //
            //
            // （３）対象コントロール
            //
            //
            //
            if (log_Reports.Successful)
            {
                List<Usercontrol> list_Usercontrol;
                // コントロール名。
                Expression_Node_StringImpl ec_Name = new Expression_Node_StringImpl(null, cf_TgTarget);
                ec_Name.AppendTextNode(
                    sName_TgTarget,
                    cf_TgTarget,
                    log_Reports
                    );

                list_Usercontrol = this.GetUsercontrolsByName(
                    ec_Name,
                    false,// エラー対応は後でやるので、このメソッドの中ではしません。
                    log_Reports
                    );

                if (0 < list_Usercontrol.Count)
                {
                    //
                    //
                    //
                    // （４）再表示
                    //
                    //
                    //
                    Usercontrol uct = list_Usercontrol[0];
                    if (null == uct)
                    {
                        // エラー
                        err_EFcName = ec_Name;
                        goto gt_Error_NullFirstFc;
                    }

                    // 必要なら再読込
                    if (bDirty)
                    {
                        uct.Dirty(log_Reports);
                    }

                    // 再表示
                    uct.RefreshData(
                        log_Reports
                        );
                }
                else
                {
                    goto gt_Error_NotFoundUsercontrol;
                }
            }
            else
            {
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullFirstFc:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー721！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("コントロールを取得できませんでした。");

                s.Append(Environment.NewLine);
                s.Append("コントロール名＝[");
                s.Append(err_EFcName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports));
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotFoundUsercontrol:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー933！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("　リフレッシュ設定の＜"+NamesNode.S_TOGETHER+"＞要素に、");
                t.Append(Environment.NewLine);
                t.Append("　存在しないユーザー・コントロールの名前[");
                t.Append(sName_TgTarget);
                t.Append("]が指定されています。");
                t.Append(Environment.NewLine);
                t.Append("　確認してください。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("　ユーザー・コントロール[" + sName_TgTarget + "]の値を更新しようとしたとき。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                // ヒント
                t.Append(r.Message_Configurationtree(cf_RfrConfig_Hint));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// デバッグ出力。
        /// </summary>
        public void WriteDebug_ToConsole()
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_Dammy = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "DebugWrite",log_Reports_Dammy);
            //
            //


            log_Reports_Dammy.BeginCreateReport(EnumReport.Dammy);

            log_Method.WriteInfo_ToConsole("コントロールの一覧を出力。総数=[" + this.dictionary_Item.Values.Count + "]");

            int nCount = 1;
            this.ForEach_Children(delegate(string sKey, Usercontrol fcUc, ref bool bRemove, ref bool bBreak)
            {

                if (null == fcUc)
                {
                    log_Method.WriteInfo_ToConsole("(" + nCount + ")ヌル");
                    goto end_fc;
                }

                log_Method.WriteInfo_ToConsole("(" + nCount + ")" + fcUc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports_Dammy));
            // fcUc.ControlCommon.Configurationtree_Control は、ヌルのことがある。


                //foreach (S_Event s_event in fcUc.ControlCommon.Configurationtree_Control.S_EventDictionary.Values)
            //{

                //    // デバッグ出力
            //    //ystem.Console.WriteLine(this.GetType().Name + "#DebugWrite: 　アクション数=[" + s_event.S_ActionList.Items.Count + "]");
            //    foreach (S_Action s_action in s_event.S_ActionList.Items)
            //    {
            //        //
            //        // アクション
            //        //

                //        // デバッグ出力
            //        //ystem.Console.WriteLine(this.GetType().Name + "#DebugWrite: 　　アクション=[" + s_action.SType + "] 引数数=[" + s_event.S_ActionList.Items.Count + "]");
            //        foreach (S_Arg s_param in s_action.S_Args.Items.Values)
            //        {
            //            //
            //            // 引数
            //            //

                //            if (s_param.S_ArgEnum == S_ArgEnum.PARAM_ACTION)
            //            {
            //                S_Action s_parentAction = (S_Action)s_param.Parent;

                //                // デバッグ出力
            //                //ystem.Console.WriteLine(this.GetType().Name + "#DebugWrite: 　　　param-action要素=[" + s_param.SNodeName + "] 子引数数=[" + s_parentAction.S_Args.Items.Count + "]");

                //                foreach (S_Arg s_param2 in s_parentAction.S_Args.Items.Values)
            //                {
            //                    // デバッグ出力
            //                    //ystem.Console.WriteLine(this.GetType().Name + "#DebugWrite: 　　　　param-actionの子引数=[" + s_param2.SNodeName + "]");
            //                    // 値=[" + oAction2.OValue + "]
            //                }

                //            }
            //            else
            //            {
            //                // デバッグ出力
            //                //ystem.Console.WriteLine(this.GetType().Name + "#DebugWrite: 　　　引数=[" + s_param.SNodeName + "] ");
            //                //値=[" + oArg.OValue + "]
            //            }

                //        }
            //    }
            //}

            end_fc:
                nCount++;
            });

            //
            //
            log_Reports_Dammy.EndCreateReport();
            log_Method.EndMethod(log_Reports_Dammy);
            if (!log_Reports_Dammy.Successful)
            {
                log_Method.WriteDebug_ToConsole(log_Reports_Dammy.ToMessage());
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「　●」といった文字列。ステータスバーに表示される、アクションを起こしたコントロール名を連ねる前に置く。
        /// 
        /// デバッグモードで機能します。
        /// </summary>
        /// <param name="sFcName"></param>
        /// <param name="log_Reports"></param>
        public void AddStatus_ActionUsercontrolNameBegin(Log_Reports log_Reports)
        {
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                // ステータスバーに表示する文字列。
                StringBuilder sb = new StringBuilder();
                sb.Append(this.StatusStripLabel2.Text);
                sb.Append("　●");

                int displayLength = 150;// 20;//300
                if (displayLength < sb.Length)
                {
                    sb.Remove(0, sb.Length - displayLength);
                }

                string sDisplay = sb.ToString();
                this.StatusStripLabel2.Text = sDisplay;
                this.StatusStrip1.Refresh();
                // デバッグ
                //ystem.Console.WriteLine(Info_NorenImpl.LibraryName + ":Xenon.Noren.MoNorenImpl#AddStatus_ActionFcNameBegin:ステータスバー内のラベル文字列＝[" + sDisplay + "]");
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「→FC名」。ステータスバーに、アクションを起こしたコントロール名を追加します。
        /// 
        /// デバッグモードで機能します。
        /// </summary>
        /// <param name="sFcName"></param>
        /// <param name="log_Reports"></param>
        public void AddStatus_ActionUsercontrolName(string sFcName, Log_Reports log_Reports)
        {
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                // ステータスバーに表示する文字列。
                StringBuilder s = new StringBuilder();
                s.Append(this.StatusStripLabel2.Text);
                s.Append("→");
                s.Append(sFcName);

                int displayLength = 150;// 20;//300
                if (displayLength < s.Length)
                {
                    s.Remove(0, s.Length - displayLength);
                }

                string sDisplay = s.ToString();
                //            this.StatusStripLabel_norenForm.Text = System.DateTime.Today.ToString();
                this.StatusStripLabel2.Text = sDisplay;
                this.StatusStrip1.Refresh();
                // デバッグ
                //ystem.Console.WriteLine(Info_NorenImpl.LibraryName + ":Xenon.Noren.MoNorenImpl#AddStatus_ActionFcName:追加＝sFcName["+sFcName+"]　ステータスバー内のラベル文字列＝[" + sDisplay + "]");
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// このオブジェクトを所有するオブジェクト。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return owner_MemoryApplication;
            }
            set
            {
                owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロール集のマップ。
        /// 
        /// コントロールは、コントロールとして
        /// ユーザーコントロール等に追加しつつ、
        /// 登録コントロールとしてこのマップに追加します。
        /// </summary>
        private Dictionary<string, Usercontrol> dictionary_Item;

        //────────────────────────────────────────

        private Mainwnd_FormWrapping mainwnd_FormWrapping;

        /// <summary>
        /// メインウィンドウ_ラッパー。設定されていなければヌル。
        /// </summary>
        public Mainwnd_FormWrapping Mainwnd_FormWrapping
        {
            get
            {
                return this.mainwnd_FormWrapping;
            }
            set
            {
                this.mainwnd_FormWrapping = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// コントロールの存在の有無を返します。
        /// </summary>
        /// <param select="nFcName">コントロール名。</param>
        /// <returns>コントロールの存在の有無</returns>
        public bool ContainsUsercontrolByName(
            Expression_Node_String ec_FcName,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_MiddleImpl.Name_Library, this, "ContainsUsercontrolByName",log_Reports);
            //
            //

            string sFcName = ec_FcName.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
            bool bResult = this.dictionary_Item.ContainsKey(sFcName);

            //
            //
            //
            //
            log_Method.EndMethod(log_Reports);
            return bResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// コンポーネントのローダー。
        /// </summary>
        private XToMemory_Form xToMemory_Form;

        //────────────────────────────────────────

        private StatusStrip statusStrip1;

        /// <summary>
        /// フォームに追加されているステータスバー。
        /// </summary>
        private StatusStrip StatusStrip1
        {
            get
            {
                return statusStrip1;
            }
            set
            {
                statusStrip1 = value;
            }
        }

        //────────────────────────────────────────

        private ToolStripStatusLabel statusStripLabel2;

        /// <summary>
        /// フォームに追加されているステータスバーに追加されているラベル。
        /// </summary>
        private ToolStripStatusLabel StatusStripLabel2
        {
            get
            {
                return statusStripLabel2;
            }
            set
            {
                statusStripLabel2 = value;
            }
        }

        //────────────────────────────────────────

        private Form_Toolwindow form_Toolwindow;

        /// <summary>
        /// ツール設定フォーム
        /// </summary>
        public Form_Toolwindow Form_Toolwindow
        {
            get
            {
                //if (null == form_ToolConfig)
                //{
                //    form_ToolConfig = new Form_ToolConfigImpl();
                //    // todo: InitializeBeforeUse() も必要。

                //}

                return form_Toolwindow;
            }
            set
            {
                this.form_Toolwindow = value;
            }
        }

        //────────────────────────────────────────

        private UsercontrolCreator1 ucontrolCreator1;

        /// <summary>
        /// コントロールを生成するオブジェクト。
        /// </summary>
        public UsercontrolCreator1 UsercontrolCreator1
        {
            get
            {
                return this.ucontrolCreator1;
            }
            set
            {
                this.ucontrolCreator1 = value;
            }
        }

        //────────────────────────────────────────

        private UsercontrolStyleSetter ucontrolStyleSetter;

        public UsercontrolStyleSetter UsercontrolStyleSetter
        {
            get
            {
                return this.ucontrolStyleSetter;
            }
            set
            {
                this.ucontrolStyleSetter = value;
            }
        }

        //────────────────────────────────────────

        private MemoryAatoolxmlDialog moAatoolxmlDialog;

        /// <summary>
        /// このフォームのモデルです。
        /// </summary>
        public MemoryAatoolxmlDialog MemoryAatoolxmlDialog
        {
            get
            {
                //if (null == moToolConfigDlg)
                //{
                //    // このフォーム単独起動時用の仮値。
                //    moToolConfigDlg = new MoToolConfigDlgImpl();
                //}

                return moAatoolxmlDialog;
            }
        }

        //────────────────────────────────────────

        private ConfigurationtreeToFunction givechapterandverseToFunction;

        /// <summary>
        /// NActionを作るオブジェクト。使う前に設定してください。
        /// </summary>
        public ConfigurationtreeToFunction ConfigurationtreeToFunction
        {
            get
            {
                return givechapterandverseToFunction;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
