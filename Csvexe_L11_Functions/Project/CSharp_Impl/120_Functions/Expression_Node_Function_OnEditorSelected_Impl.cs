using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;//Application
using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;
using Xenon.MiddleImpl;



namespace Xenon.Functions
{


    /// <summary>
    /// 「プロジェクト選択時」のイベントハンドラとして登録されます。
    /// 
    /// （１）～
    /// （１８）新規ウィンドウを開く
    /// 
    /// 旧名：E_Sf_Frame_Sub3Impl
    /// </summary>
    public class Expression_Node_Function_OnEditorSelected_Impl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        /// <summary>
        /// 関数名。
        /// </summary>
        public static readonly string NAME_FUNCTION = "Sa:Frame01;";

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function_OnEditorSelected_Impl(
            EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem
            )
            : base(enumEventhandler, listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Conf,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_FunctionAbstract f0 = new Expression_Node_Function_OnEditorSelected_Impl(this.EnumEventhandler, this.List_NameArgument,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Conf;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.SetAttribute(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(NAME_FUNCTION, null, cur_Conf), log_Reports);
            ((Expression_Node_Function_OnEditorSelected_Impl)f0).in_Subroutine_Function30_1_OrNull = null;
            ((Expression_Node_Function_OnEditorSelected_Impl)f0).in_Subroutine_Function30_2_OrNull = null;

            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// プロジェクト読取り時の定形アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="st_PrevProjectElm_OrNull"></param>
        /// <param name="bProjectValid"></param>
        /// <param name="log_Reports"></param>
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            //（）メソッド開始
            Log_Method log_Method = new Log_MethodImpl(1);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main",log_Reports);


            //
            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("「プロジェクト選択時」用のイベントハンドラーを実行します。");
            }


            //（）タスク_デスクリプション
            {
                string sFncName0;
                this.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                if (this.Functionparameterset.Sender is Customcontrol)
                {
                    Customcontrol ccFc = (Customcontrol)this.Functionparameterset.Sender;
                    string sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                    log_Reports.Comment_EventCreationMe += "／追加：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    log_Reports.Comment_EventCreationMe += "／追加：[" + sFncName0 + "]アクションを実行。";
                }
            }



            string sConfigStack_EventOrigin = "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#:プロジェクト選択時＞";
            Configurationtree_Node cf_ThisMethod = new Configurationtree_NodeImpl(sConfigStack_EventOrigin, null);
            //
            //（）ダミー・イベントモニターの作成。
            EventMonitor eventMonitor_Dammy = new EventMonitorImpl(null, cf_ThisMethod);




            if (this.EnumEventhandler == EnumEventhandler.Editor_B_Lr)
            {
                //（４）独自モデルの取得
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（４）独自モデルの取得");
                }
                //
                this.On_P04_ReadNewModel(log_Reports);


                //（５）エディター名。ツール設定ファイルに記載されている方。
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（５）エディター名。ツール設定ファイルに記載されている方。");
                }

                // 表示用の名称。
                string sName_SelectingEditor;
                if (this.Functionparameterset.SelectedProjectElement_Configurationtree == null)
                {
                    //
                    // 切り替えるプロジェクトが判明していない場合は、空文字列。
                    //
                    sName_SelectingEditor = "";
                }
                else
                {
                    //
                    // todo: エディター設定ファイルの方のエディター名を入れても意味ないのでは？
                    //
                    sName_SelectingEditor = ((MemoryAatoolxml_Editor)this.Functionparameterset.SelectedProjectElement_Configurationtree).Name;
                }



                //（６）まず、きれいさっぱり　プロジェクトをクリアーします。（切替用）
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（６）まず、きれいさっぱり　プロジェクトをクリアーします。（切替用）");
                }
                // todo:イベントハンドラーを外してから、フォームを外すこと。リストボックスが誤挙動を起こしている。
                this.On_P06_ClearProject(this.Functionparameterset.Sender, eventMonitor_Dammy, log_Reports);



                //（７）「Aa_Editor.xml」読取。
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（７）「Aa_Editor.xml」読取。");
                }
                //
                if (!this.Functionparameterset.IsProjectValid || this.Functionparameterset.SelectedProjectElement_Configurationtree == null)
                {
                    MemoryAatoolxml_Editor moAatoolxml_PrevEditorElm_OrNull = null;


                    //
                    //
                    //
                    // デフォルト・プロジェクト名が指定されていない場合、
                    // ツール設定ファイルの最初に記述されているプロジェクトを選択します。
                    //
                    //
                    //
                    if (log_Reports.Successful)
                    {
                        if ("" == sName_SelectingEditor)
                        {
                            //
                            // デフォルト・エディター名が未指定の場合。
                            //
                            MemoryAatoolxml_Editor moAatoolxml_DefaultEditor = this.Owner_MemoryApplication.MemoryAatoolxml.GetDefaultEditor(true, log_Reports);
                            if (!log_Reports.Successful)
                            {
                                // 既エラー。
                                goto gt_EndMethod;
                            }

                            // ↓これ要る？
                            sName_SelectingEditor = moAatoolxml_DefaultEditor.Name;
                        }
                    }


                    this.On_P07_SelectDefaultProject(ref sName_SelectingEditor, ref moAatoolxml_PrevEditorElm_OrNull, this.Functionparameterset.IsProjectValid, log_Reports);


                    this.Functionparameterset.SelectedProjectElement_Configurationtree = moAatoolxml_PrevEditorElm_OrNull;

                    //
                    //
                    //
                    //「プロジェクトを開いた時の初期化」イベントハンドラーで使うために、ここで設定します。
                    //
                    //
                    //
                    this.Functionparameterset.SelectedProjectElement_Configurationtree = this.Owner_MemoryApplication.MemoryAatoolxml.GetEditorByName(sName_SelectingEditor, true, log_Reports);
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }


                // ↓追加
                if (null == this.Functionparameterset.SelectedProjectElement_Configurationtree)
                {
                    {
                        Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                        tmpl.SetParameter(1, sName_SelectingEditor, log_Reports);//エディター名

                        this.Owner_MemoryApplication.CreateErrorReport("Er:110003;", tmpl, log_Reports);
                    }
                }
                // ↑追加



                //（１３ａ）エディター・フォルダー。
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１３ａ）エディター・フォルダーパス類推。");
                }
                //
                //
                //
                Expression_Node_Filepath ec_Fopath_Editor;
                if (log_Reports.Successful)
                {
                    MemoryAatoolxml_Editor moAatoolxml_SelectedEditor = (MemoryAatoolxml_Editor)this.Functionparameterset.SelectedProjectElement_Configurationtree;
                    ec_Fopath_Editor = moAatoolxml_SelectedEditor.GetFilepathByFsetvarname(
                        NamesVar.S_SP_EDITOR,
                        this.Owner_MemoryApplication.MemoryVariables,
                        true,
                        log_Reports
                        );
                }
                else
                {
                    ec_Fopath_Editor = null;
                }


                //（１３ｂ）「Aa_Editor.xml」読取。
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１３ｂ）「Aa_Editor.xml」ファイルパス類推。");
                }
                //
                Expression_Node_Filepath ec_Fpath_AaEditorXml;
                if (log_Reports.Successful)
                {

                    //
                    // ツール設定ファイルで指定された値から、自動類推で設定されているはず。
                    //
                    Configurationtree_NodeFilepath cf_Fpath_EditorXml = new Configurationtree_NodeFilepathImpl(
                        "ツール設定ファイル[" + Application.StartupPath + System.IO.Path.DirectorySeparatorChar + ValuesAttr.S_FPATHR_AATOOLXML + "]の中の[" + sName_SelectingEditor + "]エディターへの指定から自動類推",
                        null);

                    // フォルダーパス ＋ \Aa_Editor.xml
                    string sFpatha_Aaeditorxml = ec_Fopath_Editor.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_EDITOR_XML;

                    // プロジェクト起動時に。
                    cf_Fpath_EditorXml.InitPath(
                        sFpatha_Aaeditorxml,
                        log_Reports
                        );
                    ec_Fpath_AaEditorXml = new Expression_Node_FilepathImpl(cf_Fpath_EditorXml);
                }
                else
                {
                    ec_Fpath_AaEditorXml = null;
                }


                //（８）「エディター設定ファイル」に記述されている＜ｆ－ｓｅｔ－ｖａｒ＞要素を、「エディター設定ファイル・モデル」に格納。Cf→M
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（８）「エディター設定ファイル」に記述されている＜ｆ－ｓｅｔ－ｖａｒ＞要素を、「エディター設定ファイル・モデル」に格納。Cf→M。この時点で「Sp:Engine;」といったシステム変数は自動類推が終わっている必要があります。");
                }
                //
                MemoryAaeditorxml_Editor moAaeditorxml_Editor = null;
                if (log_Reports.Successful)
                {
                    this.On_P08_SpToVar_(
                        out moAaeditorxml_Editor,
                        ec_Fpath_AaEditorXml,
                        ec_Fopath_Editor,
                        (MemoryAatoolxml_Editor)this.Functionparameterset.SelectedProjectElement_Configurationtree,
                        log_Reports
                        );
                }



                
                //
                //
                //
                // ここで「Aa_Files.csv」を読み込みたい。
                //
                //
                //




                if (log_Reports.Successful)
                {
                    //（９）変数ファイル読取
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole("（９）変数ファイル読取");
                    }
                    //
                    this.Owner_MemoryApplication.MemoryVariables.LoadVariables(
                        Application.StartupPath,
                        log_Reports
                        );
                }




                if (log_Reports.Successful)
                {
                    //（１０）プログラマー用・デバッグモードのON/OFF。
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole("（１０）プログラマー用・デバッグモードのON/OFF。");
                    }
                    //
                    //mainWndの作成より先に設定する必要がある。ステータスバーを出す、出さないについて。
                    {
                        Expression_Leaf_StringImpl ec_Varname = new Expression_Leaf_StringImpl(this, this.Cur_Configurationtree.Parent);
                        ec_Varname.SetString(NamesVar.S_SS_DEBUGMODE_PROGRAMMER, log_Reports);
                        string sValue = this.Owner_MemoryApplication.MemoryVariables.GetStringByVariablename(ec_Varname, false, log_Reports);
                        if (ValuesAttr.S_ON == sValue)
                        {
                            Log_ReportsImpl.BDebugmode_Static = true;
                        }
                        else if (ValuesAttr.S_OFF == sValue)
                        {
                            Log_ReportsImpl.BDebugmode_Static = false;
                        }
                        else if (ValuesAttr.S_EMPTY == sValue)
                        {
                            // 無視
                        }
                        else
                        {
                            // TODO:エラー
                        }
                    }
                }




                if (log_Reports.Successful)
                {
                    //（１１）画面レイアウト・デバッグモードのON/OFF。
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole("（１１）フォーム・デバッグモードのON/OFF。");
                    }
                    //
                    Expression_Leaf_StringImpl ec_Varname = new Expression_Leaf_StringImpl(this, this.Cur_Configurationtree.Parent);
                    ec_Varname.SetString(NamesVar.S_SS_DEBUGMODE_FORM, log_Reports);
                    string sValue = this.Owner_MemoryApplication.MemoryVariables.GetStringByVariablename(ec_Varname, false, log_Reports);
                    if (ValuesAttr.S_ON == sValue)
                    {
                        Log_ReportsImpl.BDebugmode_Form = true;
                    }
                    else if (ValuesAttr.S_OFF == sValue)
                    {
                        Log_ReportsImpl.BDebugmode_Form = false;
                    }
                    else if (ValuesAttr.S_EMPTY == sValue)
                    {
                        // 無視
                    }
                    else
                    {
                        // TODO:エラー
                    }
                }





                //（１４）「Aa_Files.csv」読取。
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１４）「Aa_Files.csv」読取。");
                }
                //
                List<Expression_Node_Filepath> ecList_Fpath_BackupRequest;
                {
                    if (log_Reports.Successful)
                    {
                        // 正常時

                        Expression_Node_Function function_Expr = Collection_Function.NewFunction2(
                                Expression_Node_Function22Impl.NAME_FUNCTION, this, this.Cur_Configurationtree,
                                this.Owner_MemoryApplication, log_Reports);

                        // 実行
                        function_Expr.Execute4_OnLr(this.Functionparameterset.Sender, eventMonitor_Dammy, sConfigStack_EventOrigin, log_Reports);

                        // 実行後
                        ecList_Fpath_BackupRequest = ((Expression_Node_Function22Impl)function_Expr).List_Expression_Filepath_BackupRequest_Out;
                    }
                    else
                    {
                        //
                        // エラー
                        //

                        ecList_Fpath_BackupRequest = null;
                    }
                }



                //（１４ｂ）ユーザー定義関数設定ファイル読取【2012-03-30追加】
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１４ｂ）ユーザー定義関数設定ファイル読取【2012-03-30追加】");
                }
                //
                if (log_Reports.Successful)
                {
                    // タイプデータ値。
                    Expression_Leaf_StringImpl ec_NameVariable = new Expression_Leaf_StringImpl(this, new Configurationtree_NodeImpl("!ハードコーディング",null));
                    ec_NameVariable.SetString(ValuesTypeData.S_CODE_FUNCTIONS, log_Reports);

                    List<MemoryCodefileinfo> listInfo = null;
                    if (log_Reports.Successful)
                    {
                        listInfo = this.Owner_MemoryApplication.MemoryCodefiles.GetCodefileinfoByTypedata(ec_NameVariable, true, log_Reports);
                    }

                    if (log_Reports.Successful)
                    {
                        foreach (MemoryCodefileinfo scriptfile in listInfo)
                        {
                            if (log_Reports.Successful)
                            {
                                this.Owner_MemoryApplication.MemoryFunctions.LoadFile(
                                    scriptfile.Expression_Filepath,
                                    log_Reports);

                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }





                //（１６）『スタイルシート設定ファイル』読取
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１６）『スタイルシート設定ファイル』読取");
                }
                //
                if (log_Reports.Successful)
                {
                    Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                        Expression_Node_Function19Impl.NAME_FUNCTION, this, this.Cur_Configurationtree,
                        this.Owner_MemoryApplication, log_Reports);

                    Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(this, cf_ThisMethod);
                    ec_Str.AppendTextNode(NamesVar.S_ST_STYLESHEET, this.Cur_Configurationtree, log_Reports);

                    expr_Func.SetAttribute(Expression_Node_Function19Impl.PM_NAME_TABLE_STYLESHEET, ec_Str, log_Reports);


                    expr_Func.Execute4_OnLr(
                        this.Functionparameterset.Sender,
                        eventMonitor_Dammy,
                        sConfigStack_EventOrigin,
                        log_Reports
                        );
                }



                //（１７ａ）「バックアップを取る」前にしておく独自実装をするタイミング。
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１７ａ）「バックアップを取る」前にしておく独自実装をするタイミング。");
                }
                //
                this.On_P17a_PreviousBackup(
                    this.Functionparameterset.Sender,
                    moAaeditorxml_Editor,
                    ec_Fpath_AaEditorXml,
                    ec_Fopath_Editor,
                    (MemoryAatoolxml_Editor)this.Functionparameterset.SelectedProjectElement_Configurationtree,
                    eventMonitor_Dammy,
                    sConfigStack_EventOrigin,
                    log_Reports);

                //（１７ｂ）今日の分のバックアップを取ります。
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１７ｂ）今日の分のバックアップを取ります。");
                }
                //
                this.On_P17b_DateBackup(ecList_Fpath_BackupRequest, this.Functionparameterset.Sender, eventMonitor_Dammy, sConfigStack_EventOrigin, log_Reports);


                //（１７ｃ）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１７ｃ）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。");
                }
                //
                this.On_P17c_PreviousOpenWindow(
                    this.Functionparameterset.Sender,
                    moAaeditorxml_Editor,
                    ec_Fpath_AaEditorXml,
                    ec_Fopath_Editor,
                    (MemoryAatoolxml_Editor)this.Functionparameterset.SelectedProjectElement_Configurationtree,
                    eventMonitor_Dammy,
                    sConfigStack_EventOrigin,
                    log_Reports);


                //（１８）関数３０「新規ウィンドウを開く」実行。引数には関数を２つ指定できる。
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１８）関数３０「新規ウィンドウを開く」実行。引数には関数を２つ指定できる。");
                }
                //
                {

                    Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                            Expression_Node_Function30Impl.NAME_FUNCTION, this, this.Cur_Configurationtree,
                            this.Owner_MemoryApplication, log_Reports);

                    {
                        //Expression_Node_Function30Impl f1 = 

                        {
                            Expression_Node_StringImpl ec_FormStart;
                            {
                                Expression_FvarImpl ec_Fvar = new Expression_FvarImpl(this, this.Cur_Configurationtree, this.Owner_MemoryApplication);
                                ec_Fvar.AppendTextNode(NamesVar.S_SS_FORM_START, this.Cur_Configurationtree, log_Reports);

                                ec_FormStart = new Expression_Node_StringImpl(this, this.Cur_Configurationtree);
                                ec_FormStart.List_Expression_Child.Add(ec_Fvar, log_Reports);
                            }
                            ((Expression_Node_Function30Impl)expr_Func).SetAttribute(Expression_Node_Function30Impl.PM_NAME_FORM, ec_FormStart, log_Reports);
                        }

                        ((Expression_Node_Function30Impl)expr_Func).In_Subroutine_Function30_1 = this.In_Subroutine_Function30_1_OrNull;
                        ((Expression_Node_Function30Impl)expr_Func).In_Subroutine_Function30_2 = this.In_Subroutine_Function30_2_OrNull;
                        ((Expression_Node_Function30Impl)expr_Func).SetAttribute(
                            Expression_Node_Function30Impl.PM_NAME_TOGETHER,
                            new Expression_Leaf_StringImpl(NamesStg.S_STG_BEGIN_APPLICATION, null, cf_ThisMethod), log_Reports);
                    }


                    expr_Func.Execute4_OnLr(
                        this.Functionparameterset.Sender,
                        eventMonitor_Dammy,
                        sConfigStack_EventOrigin,
                        log_Reports
                        );
                }


                //（１９）最後に
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１９）最後に");
                }
                //
                this.On_P19_AtLast(
                    this.Functionparameterset.Sender,
                    (MemoryAatoolxml_Editor)this.Functionparameterset.SelectedProjectElement_Configurationtree,
                    this.Functionparameterset.IsProjectValid,
                    sConfigStack_EventOrigin,
                    log_Reports);




                //
                // 「S」と「E」を出力したい。
                if (false)
                {
                    // 「S」全てのコントロールと、ユーザー定義関数について。

                    log_Method.WriteInfo_ToConsole("┌──────────┐「S」全てのコントロールについて。");
                    this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol fcUc, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.Newline();
                        fcUc.ControlCommon.Expression_Control.Cur_Configurationtree.ToText_Content(s);
                        log_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    log_Method.WriteInfo_ToConsole("└──────────┘");

                    log_Method.WriteInfo_ToConsole("┌──────────┐「S」全てのユーザー定義関数について。");
                    this.Owner_MemoryApplication.MemoryFunctions.ForEach_Children(delegate(string sKey, Expression_Node_Function ec_CommonFunction, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.Newline();
                        ec_CommonFunction.Cur_Configurationtree.ToText_Content(s);
                        log_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    log_Method.WriteInfo_ToConsole("└──────────┘");




                    // 「E」全てのコントロールと、ユーザー定義関数について。

                    log_Method.WriteInfo_ToConsole("┌──────────┐「E」全てのコントロールについて。");
                    this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol fcUc, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.Newline();
                        fcUc.ControlCommon.Expression_Control.ToText_Snapshot(s);
                        log_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    log_Method.WriteInfo_ToConsole("└──────────┘");

                    log_Method.WriteInfo_ToConsole("┌──────────┐「E」全てのユーザー定義関数について。");
                    this.Owner_MemoryApplication.MemoryFunctions.ForEach_Children(delegate(string sKey, Expression_Node_Function ec_CommonFunction, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.Newline();
                        ec_CommonFunction.ToText_Snapshot(s);
                        log_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    log_Method.WriteInfo_ToConsole("└──────────┘");

                }
                log_Method.WriteInfo_ToConsole("◆起動終了");





                goto gt_EndMethod;
            //
            gt_EndMethod:
                log_Method.EndMethod(log_Reports);
            }

            return "";
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// 独自のデータモデルを取得したい場合はオーバーライドしてください。
        /// </summary>
        protected virtual void On_P04_ReadNewModel(Log_Reports log_Reports)
        {
        }

        /// <summary>
        /// プロジェクトのクリアーを独自に実装したい場合はオーバーライドしてください。
        /// 
        /// // todo:イベントハンドラーを外してから、フォームを外すこと。リストボックスが誤挙動を起こしている。
        /// </summary>
        protected virtual void On_P06_ClearProject(
            object sender,
            EventMonitor eventMonitor,
            Log_Reports log_Reports)
        {
            //
            //
            //
            //（６）まず、きれいさっぱり　プロジェクトをクリアーします。（プロジェクト切替用）
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Owner_MemoryApplication.ClearProject(
                    this.Owner_MemoryApplication.MemoryForms.Mainwnd_FormWrapping.Form.Controls,
                    log_Reports
                    );
            }
        }

        protected virtual void On_P07_SelectDefaultProject(
            ref string sName_InitialProject,
            ref MemoryAatoolxml_Editor moAatoolxml_PrevEditor_OrNull,
            bool bProjectValid,
            Log_Reports log_Reports
            )
        {

            goto gt_EndMethod;

            //
        //
        //
        //
        gt_EndMethod:
            ;
        }

        /// <summary>
        /// （８）「エディター設定ファイル」に記述されている＜ｆ－ｓｅｔ－ｖａｒ＞要素を、「エディター設定ファイル・モデル」に格納。Cf→M
        /// </summary>
        /// <param name="st_PrevProject_OrNull"></param>
        /// <param name="log_Reports"></param>
        private void On_P08_SpToVar_(
            out MemoryAaeditorxml_Editor out_moAaeditorxml_Editor,
            Expression_Node_Filepath ec_Fpath_AaEditorXml,
            Expression_Node_Filepath ec_Fopath_Editor,
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "On_P08_SpToVar_",log_Reports);


            //
            //
            //
            //（１３ｃ）『Aa_Editor.xml』ロード
            //
            //
            //
            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("（１３ｃ）『Aa_Editor.xml』ロード");
            }


            MemoryAaeditorxml moAaeditorxml = new MemoryAaeditorxmlImpl(this.Owner_MemoryApplication);
            //moAaeditorxml.Clear1(log_Reports);

            if (log_Reports.Successful)
            {
                moAaeditorxml.Load_AutoSystemVariable(
                    ec_Fopath_Editor,
                    log_Reports
                    );
            }

            //
            out_moAaeditorxml_Editor = new MemoryAaeditorxml_EditorImpl(ec_Fpath_AaEditorXml.Cur_Configurationtree);
            if (log_Reports.Successful)
            {
                out_moAaeditorxml_Editor.LoadFile_Aaxml(
                    ec_Fpath_AaEditorXml,
                    this.Owner_MemoryApplication.MemoryVariables,
                    log_Reports
                    );
            }


            if (log_Reports.Successful)
            {
                moAaeditorxml.LoadFile(
                    ec_Fopath_Editor,
                    log_Reports
                    );
            }


            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }


        /// <summary>
        /// （１７ｂ）今日の分のバックアップを取ります。
        /// </summary>
        /// <param name="e_FpathList_BackupRequest"></param>
        /// <param name="sender"></param>
        /// <param name="eventMonitor_Dammy"></param>
        /// <param name="sConfigStack_EventOrigin"></param>
        /// <param name="log_Reports"></param>
        protected virtual void On_P17b_DateBackup(
            List<Expression_Node_Filepath> listExpression_Filepath_BackupRequest,
            object sender,
            EventMonitor eventMonitor_Dammy,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports)
        {
            if (log_Reports.Successful)
            {
                Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                        Expression_Node_Function44Impl.NAME_FUNCTION, this, this.Cur_Configurationtree,
                        this.Owner_MemoryApplication, log_Reports);

                {
                    ((Expression_Node_Function44Impl)expr_Func).Expression_FilepathList_Backup = listExpression_Filepath_BackupRequest;
                }

                expr_Func.Execute4_OnLr(
                    sender,
                    eventMonitor_Dammy,
                    sConfigStack_EventOrigin,
                    log_Reports
                    );
            }
        }


        /// <summary>
        /// （１７）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor_Dammy"></param>
        /// <param name="sConfigStack_EventOrigin"></param>
        /// <param name="log_Reports"></param>
        protected virtual void On_P17a_PreviousBackup(
            object sender,
            MemoryAaeditorxml_Editor moAaeditorxml_Editor,
            Expression_Node_Filepath ec_Fpath_AaEditorXml,
            Expression_Node_Filepath ec_Fopath_Editor,
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor,
            EventMonitor eventMonitor_Dammy,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports)
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "On_P17a_PreviousOpenWindow_Backup",log_Reports);


            //
            //
            //
            //（６）バックアップ・フォルダーのオーナー名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Owner_MemoryApplication.MemoryBackup.Configurationtree_Name_SubFolder = moAaeditorxml_Editor.Dictionary_Fsetvar_Configurationtree.GetFsetvar(
                    NamesVar.S_SS_BACKUP_NAME_MY_FOLDER, false, log_Reports);
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }


            //
            //
            //
            //（７）取り置きするバックアップ・フォルダーの数。1日1回バックアップを取っているのなら、10 に設定すれば、10日分のバックアップが取り置きされることになります。
            //
            //
            //
            if (log_Reports.Successful)
            {
                this.Owner_MemoryApplication.MemoryBackup.Configurationtree_BackupKeptbackups = moAaeditorxml_Editor.Dictionary_Fsetvar_Configurationtree.GetFsetvar(
                    NamesVar.S_SI_BACKUP_KEPT_BACKUPS, false, log_Reports);
                if (!log_Reports.Successful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            //
            //
            //
            // バックアップ・フォルダー ファイルパス有無チェック。
            //
            //
            //
            if (log_Reports.Successful)
            {
                XenonNameImpl o_Name_Variable = new XenonNameImpl(NamesVar.S_SP_BACKUP_FOLDER, new Configurationtree_NodeImpl("!ハードコーディング_ExAction00022#", null));

                // 変数名。
                Expression_Leaf_StringImpl ec_Atom = new Expression_Leaf_StringImpl(null, o_Name_Variable.Cur_Configurationtree);
                ec_Atom.SetString(
                    o_Name_Variable.SValue,
                    log_Reports
                );

                // ファイルパス。
                log_Reports.Log_Callstack.Push(log_Method, "①");
                Expression_Node_Filepath ec_Fpath_Exports = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                    ec_Atom,
                    true,
                    log_Reports
                    );
                log_Reports.Log_Callstack.Pop(log_Method, "①");

                this.TestExists_EmptyFilePath(
                    "BackupBaseDirectory",
                    ec_Fpath_Exports,
                    ec_Fpath_AaEditorXml.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports),
                    log_Reports
                );
            }

            //
            //
            //
            // バックアップ数 文字列有無チェック。
            //
            //
            //
            if (log_Reports.Successful)
            {
                Configurationtree_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Configurationtree_BackupKeptbackups;

                string sValue;
                cf_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                this.TestExists_String(
                    "DateBackupKeptbackups",
                    sValue,
                    ec_Fpath_AaEditorXml.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports),
                    log_Reports
                );
            }


            //
            //
            //
            // バックアップ・フォルダー名 文字列有無チェック。
            //
            //
            //
            if (log_Reports.Successful)
            {
                Configurationtree_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Configurationtree_Name_SubFolder;

                string sValue;
                cf_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                this.TestExists_String(
                    "DateBackupFolderOwnerName",
                    sValue,
                    ec_Fpath_AaEditorXml.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports),
                    log_Reports
                );
            }

            // 保管するバックアップ数（日毎）
            if (log_Reports.Successful)
            {
                int nBackups;
                {
                    Configurationtree_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Configurationtree_BackupKeptbackups;

                    string sValue;
                    cf_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                    if (!int.TryParse(sValue, out nBackups))
                    {
                        // エラー。
                        this.Owner_MemoryApplication.MemoryBackup.BackupKeptbackups = 0;
                    }
                    else
                    {
                        this.Owner_MemoryApplication.MemoryBackup.BackupKeptbackups = nBackups;
                    }
                }

                // バックアップ・フォルダーのサブ名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
                {
                    Configurationtree_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Configurationtree_Name_SubFolder;

                    string sValue;
                    cf_Fsetvar.Dictionary_Attribute.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                    this.Owner_MemoryApplication.MemoryBackup.Name_SubFolder = sValue;
                }
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        /// <summary>
        /// （１７）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor_Dammy"></param>
        /// <param name="sConfigStack_EventOrigin"></param>
        /// <param name="log_Reports"></param>
        protected virtual void On_P17c_PreviousOpenWindow(
            object sender,
            MemoryAaeditorxml_Editor moAaeditorxml_Editor,
            Expression_Node_Filepath ec_Fpath_AaEditorXml,
            Expression_Node_Filepath ec_Fopath_Editor,
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor,
            EventMonitor eventMonitor_Dammy,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports)
        {
        }

        protected virtual void On_P19_AtLast(
            object sender,
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor,
            bool bProjectValid,
            string sConfigStack_EventOrigin,
            Log_Reports log_Reports
            )
        {
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        protected void TestExists_String(
            string sArgName_Display,
            string sValue,
            string sFpath_SelectedProject,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "TestExists_String",log_Reports);

            if ("" == sValue)
            {
                goto gt_Error_NoData;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NoData:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sFpath_SelectedProject, log_Reports);//選択したエディター・フォルダーのファイルパス
                tmpl.SetParameter(2, sArgName_Display, log_Reports);//表示名

                this.Owner_MemoryApplication.CreateErrorReport("Er:110004;", tmpl, log_Reports);
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

        protected void TestExists_EmptyFilePath(
            string sArgName,
            Expression_Node_Filepath ec_Fpath,
            string sFpath_SelectedProject,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "TestExists_EmptyFilePath",log_Reports);
            //
            //

            if (null == ec_Fpath)
            {
                goto gt_Error_NullFpath;
            }
            else if ("" == ec_Fpath.Humaninput)
            {
                goto gt_Error_NoData;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullFpath:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sFpath_SelectedProject, log_Reports);//選択したエディター・フォルダーのファイルパス
                tmpl.SetParameter(2, sArgName, log_Reports);//引数名

                this.Owner_MemoryApplication.CreateErrorReport("Er:110005;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NoData:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sArgName, log_Reports);//引数名
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToText_Configurationtree(ec_Fpath.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:110006;", tmpl, log_Reports);
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
        #endregion



        #region プロパティー

        // ──────────────────────────────

        /// <summary>
        /// 派生クラスのコンストラクターで上書きしてください。上書きしなければヌル。
        /// </summary>
        private Subroutine_Function30_1 in_Subroutine_Function30_1_OrNull;

        /// <summary>
        /// サブ処理。
        /// </summary>
        public Subroutine_Function30_1 In_Subroutine_Function30_1_OrNull
        {
            get
            {
                return this.in_Subroutine_Function30_1_OrNull;
            }
            set
            {
                this.in_Subroutine_Function30_1_OrNull = value;
            }
        }

        // ──────────────────────────────

        /// <summary>
        /// 派生クラスのコンストラクターで上書きしてください。上書きしなければヌル。
        /// </summary>
        private Subroutine_Function30_2 in_Subroutine_Function30_2_OrNull;

        /// <summary>
        /// サブ処理。
        /// </summary>
        public Subroutine_Function30_2 In_Subroutine_Function30_2_OrNull
        {
            get
            {
                return this.in_Subroutine_Function30_2_OrNull;
            }
            set
            {
                this.in_Subroutine_Function30_2_OrNull = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
