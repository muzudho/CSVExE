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
        public static readonly string S_ACTION_NAME = "Sa:Frame01;";

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function_OnEditorSelected_Impl(
            EnumEventhandler enumEventhandler, List<string> listS_ArgName, GivechapterandverseToFunction_Item functiontranslatoritem
            )
            : base(enumEventhandler, listS_ArgName,functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_FunctionAbstract f0 = new Expression_Node_Function_OnEditorSelected_Impl(this.EnumEventhandler, this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);
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
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method log_Method = new Log_MethodImpl(1);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",log_Reports);


            //
            //
            //
            //
            //
            //
            //
            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole("「プロジェクト選択時」用のイベントハンドラーを実行します。");
            }


            //
            //
            //
            //（）タスク_デスクリプション
            //
            //
            //
            {
                string sFncName0;
                this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol ccFc = (Customcontrol)this.ExpressionfncPrmset.Sender;
                    string sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);
                    log_Reports.SComment_EventCreationMe += "／追加：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    log_Reports.SComment_EventCreationMe += "／追加：[" + sFncName0 + "]アクションを実行。";
                }
            }



            string sConfigStack_EventOrigin = "＜" + Info_Functions.SName_Library + ":" + this.GetType().Name + "#Perform_PrjSelected:プロジェクト選択時＞";
            Givechapterandverse_Node cf_ThisMethod = new Givechapterandverse_NodeImpl(sConfigStack_EventOrigin, null);
            //
            //
            //
            //（）ダミー・イベントモニターの作成。
            //
            //
            //
            EventMonitor eventMonitor_Dammy = new EventMonitorImpl(null, cf_ThisMethod);




            if (this.EnumEventhandler == EnumEventhandler.Tp_B_Wr_Rhn)
            {


                //
                //
                //
                //（４）独自モデルの取得
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（４）独自モデルの取得");
                }
                //
                this.On_P04_ReadNewModel(log_Reports);




                //
                //
                //
                //（５）エディター名。ツール設定ファイルに記載されている方。
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（５）エディター名。ツール設定ファイルに記載されている方。");
                }

                // 表示用の名称。
                string sName_SelectingEditor;
                if (this.ExpressionfncPrmset.St_SelectedProjectElm == null)
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
                    sName_SelectingEditor = ((MemoryAatoolxml_Editor)this.ExpressionfncPrmset.St_SelectedProjectElm).SName;
                }




                //
                //
                //
                //（６）まず、きれいさっぱり　プロジェクトをクリアーします。（切替用）
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（６）まず、きれいさっぱり　プロジェクトをクリアーします。（切替用）");
                }
                // todo:イベントハンドラーを外してから、フォームを外すこと。リストボックスが誤挙動を起こしている。
                this.On_P06_ClearProject(this.ExpressionfncPrmset.Sender, eventMonitor_Dammy, log_Reports);




                //
                //
                //
                //（７）「Aa_Editor.xml」読取。
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（７）「Aa_Editor.xml」読取。");
                }
                //
                if (!this.ExpressionfncPrmset.BProjectValid || this.ExpressionfncPrmset.St_SelectedProjectElm == null)
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
                    if (log_Reports.BSuccessful)
                    {
                        if ("" == sName_SelectingEditor)
                        {
                            //
                            // デフォルト・エディター名が未指定の場合。
                            //
                            MemoryAatoolxml_Editor moAatoolxml_DefaultEditor = this.Owner_MemoryApplication.MemoryAatoolxml.GetDefaultEditor(true, log_Reports);
                            if (!log_Reports.BSuccessful)
                            {
                                // 既エラー。
                                goto gt_EndMethod;
                            }

                            // ↓これ要る？
                            sName_SelectingEditor = moAatoolxml_DefaultEditor.SName;
                        }
                    }


                    this.On_P07_SelectDefaultProject(ref sName_SelectingEditor, ref moAatoolxml_PrevEditorElm_OrNull, this.ExpressionfncPrmset.BProjectValid, log_Reports);


                    this.ExpressionfncPrmset.St_SelectedProjectElm = moAatoolxml_PrevEditorElm_OrNull;

                    //
                    //
                    //
                    //「プロジェクトを開いた時の初期化」イベントハンドラーで使うために、ここで設定します。
                    //
                    //
                    //
                    this.ExpressionfncPrmset.St_SelectedProjectElm = this.Owner_MemoryApplication.MemoryAatoolxml.GetEditorByName(sName_SelectingEditor, true, log_Reports);
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }


                // ↓追加
                if (null == this.ExpressionfncPrmset.St_SelectedProjectElm)
                {
                    if (log_Reports.CanCreateReport)
                    {
                        Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー1029！", log_Method);

                        StringBuilder s = new StringBuilder();
                        s.Append("ツール設定ファイルから、デフォルトプロジェクトを選べませんでした。");
                        s.Append(Environment.NewLine);
                        s.Append("エディター名＝[");
                        s.Append(sName_SelectingEditor);
                        s.Append("]");
                        r.SMessage = s.ToString();
                        log_Reports.EndCreateReport();
                    }
                }
                // ↑追加




                //
                //
                //
                //（１３ａ）エディター・フォルダー。
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１３ａ）エディター・フォルダーパス類推。");
                }
                //
                //
                //
                Expression_Node_Filepath ec_Fopath_Editor;
                if (log_Reports.BSuccessful)
                {
                    MemoryAatoolxml_Editor moAatoolxml_SelectedEditor = (MemoryAatoolxml_Editor)this.ExpressionfncPrmset.St_SelectedProjectElm;
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


                //
                //
                //
                //（１３ｂ）「Aa_Editor.xml」読取。
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１３ｂ）「Aa_Editor.xml」ファイルパス類推。");
                }
                //
                Expression_Node_Filepath ec_Fpath_AaEditorXml;
                if (log_Reports.BSuccessful)
                {

                    //
                    // ツール設定ファイルで指定された値から、自動類推で設定されているはず。
                    //
                    Givechapterandverse_Filepath cf_Fpath_EditorXml = new Givechapterandverse_FilepathImpl(
                        "ツール設定ファイル[" + Application.StartupPath + System.IO.Path.DirectorySeparatorChar + ValuesAttr.S_FPATHR_AATOOLXML + "]の中の[" + sName_SelectingEditor + "]エディターへの指定から自動類推",
                        null);

                    // フォルダーパス ＋ \Aa_Editor.xml
                    string sFpatha_Aaeditorxml = ec_Fopath_Editor.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports) + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_EDITOR_XML;

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


                //
                //
                //
                //（８）「エディター設定ファイル」に記述されている＜ｆ－ｓｅｔ－ｖａｒ＞要素を、「エディター設定ファイル・モデル」に格納。Cf→M
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（８）「エディター設定ファイル」に記述されている＜ｆ－ｓｅｔ－ｖａｒ＞要素を、「エディター設定ファイル・モデル」に格納。Cf→M。この時点で「Sp:Engine;」といったシステム変数は自動類推が終わっている必要があります。");
                }
                //
                MemoryAaeditorxml_Editor moAaeditorxml_Editor = null;
                if (log_Reports.BSuccessful)
                {
                    this.On_P08_SpToVar_(
                        out moAaeditorxml_Editor,
                        ec_Fpath_AaEditorXml,
                        ec_Fopath_Editor,
                        (MemoryAatoolxml_Editor)this.ExpressionfncPrmset.St_SelectedProjectElm,
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




                if (log_Reports.BSuccessful)
                {
                    //
                    //
                    //
                    //（９）変数ファイル読取
                    //
                    //
                    //
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole("（９）変数ファイル読取");
                    }
                    //
                    this.Owner_MemoryApplication.MemoryVariables.LoadVariables(
                        Application.StartupPath,
                        this.Owner_MemoryApplication,
                        log_Reports
                        );
                }




                if (log_Reports.BSuccessful)
                {
                    //
                    //
                    //
                    //（１０）プログラマー用・デバッグモードのON/OFF。
                    //
                    //
                    //
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole("（１０）プログラマー用・デバッグモードのON/OFF。");
                    }
                    //
                    //mainWndの作成より先に設定する必要がある。ステータスバーを出す、出さないについて。
                    {
                        Expression_Leaf_StringImpl ec_Varname = new Expression_Leaf_StringImpl(this, this.Cur_Givechapterandverse.Parent_Givechapterandverse);
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




                if (log_Reports.BSuccessful)
                {
                    //
                    //
                    //
                    //（１１）画面レイアウト・デバッグモードのON/OFF。
                    //
                    //
                    //
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole("（１１）フォーム・デバッグモードのON/OFF。");
                    }
                    //
                    Expression_Leaf_StringImpl ec_Varname = new Expression_Leaf_StringImpl(this, this.Cur_Givechapterandverse.Parent_Givechapterandverse);
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





                //
                //
                //
                //（１４）「Aa_Files.csv」読取。
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１４）「Aa_Files.csv」読取。");
                }
                //
                List<Expression_Node_Filepath> ecList_Fpath_BackupRequest;
                {
                    if (log_Reports.BSuccessful)
                    {
                        // 正常時

                        Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                                Expression_Node_Function22Impl.S_ACTION_NAME, this, this.Cur_Givechapterandverse,
                                this.Owner_MemoryApplication, log_Reports);

                        // 実行
                        expr_Func.Execute_OnWrRhn(this.ExpressionfncPrmset.Sender, eventMonitor_Dammy, sConfigStack_EventOrigin, log_Reports);

                        // 実行後
                        ecList_Fpath_BackupRequest = ((Expression_Node_Function22Impl)expr_Func).List_Expression_Filepath_BackupRequest_Out;
                    }
                    else
                    {
                        //
                        // エラー
                        //

                        ecList_Fpath_BackupRequest = null;
                    }
                }



                //
                //
                //
                //（１４ｂ）ユーザー定義関数設定ファイル読取【2012-03-30追加】
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１４ｂ）ユーザー定義関数設定ファイル読取【2012-03-30追加】");
                }
                //
                if (log_Reports.BSuccessful)
                {
                    // タイプデータ値。
                    Expression_Leaf_StringImpl ec_NameVariable = new Expression_Leaf_StringImpl(this, new Givechapterandverse_NodeImpl("!ハードコーディング",null));
                    ec_NameVariable.SetString(ValuesTypeData.S_CODE_FUNCTIONS, log_Reports);

                    List<MemoryCodefileinfo> listInfo = null;
                    if (log_Reports.BSuccessful)
                    {
                        listInfo = this.Owner_MemoryApplication.MemoryCodefiles.GetCodefileinfoByTypedata(ec_NameVariable, true, log_Reports);
                    }

                    if (log_Reports.BSuccessful)
                    {
                        foreach (MemoryCodefileinfo scriptfile in listInfo)
                        {
                            if (log_Reports.BSuccessful)
                            {
                                this.Owner_MemoryApplication.MemoryFunctions.LoadFile(
                                    scriptfile.Expression_Filepath,
                                    this.Owner_MemoryApplication,
                                    log_Reports);

                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }





                //
                //
                //
                //（１６）『スタイルシート設定ファイル』読取
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１６）『スタイルシート設定ファイル』読取");
                }
                //
                if (log_Reports.BSuccessful)
                {
                    Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                        Expression_Node_Function19Impl.S_ACTION_NAME, this, this.Cur_Givechapterandverse,
                        this.Owner_MemoryApplication, log_Reports);

                    Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(this, cf_ThisMethod);
                    ec_Str.AppendTextNode(NamesVar.S_ST_STYLESHEET, this.Cur_Givechapterandverse, log_Reports);

                    expr_Func.DicExpression_Attr.Set(Expression_Node_Function19Impl.S_PM_NAME_TABLE_STYLE_SHEET, ec_Str, log_Reports);


                    expr_Func.Execute_OnWrRhn(
                        this.ExpressionfncPrmset.Sender,
                        eventMonitor_Dammy,
                        sConfigStack_EventOrigin,
                        log_Reports
                        );
                }



                //
                //
                //
                //（１７ａ）「バックアップを取る」前にしておく独自実装をするタイミング。
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１７ａ）「バックアップを取る」前にしておく独自実装をするタイミング。");
                }
                //
                this.On_P17a_PreviousBackup(
                    this.ExpressionfncPrmset.Sender,
                    moAaeditorxml_Editor,
                    ec_Fpath_AaEditorXml,
                    ec_Fopath_Editor,
                    (MemoryAatoolxml_Editor)this.ExpressionfncPrmset.St_SelectedProjectElm,
                    eventMonitor_Dammy,
                    sConfigStack_EventOrigin,
                    log_Reports);

                //
                //
                //
                //（１７ｂ）今日の分のバックアップを取ります。
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１７ｂ）今日の分のバックアップを取ります。");
                }
                //
                this.On_P17b_DateBackup(ecList_Fpath_BackupRequest, this.ExpressionfncPrmset.Sender, eventMonitor_Dammy, sConfigStack_EventOrigin, log_Reports);


                //
                //
                //
                //（１７ｃ）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１７ｃ）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。");
                }
                //
                this.On_P17c_PreviousOpenWindow(
                    this.ExpressionfncPrmset.Sender,
                    moAaeditorxml_Editor,
                    ec_Fpath_AaEditorXml,
                    ec_Fopath_Editor,
                    (MemoryAatoolxml_Editor)this.ExpressionfncPrmset.St_SelectedProjectElm,
                    eventMonitor_Dammy,
                    sConfigStack_EventOrigin,
                    log_Reports);


                //
                //
                //
                //（１８）関数３０「新規ウィンドウを開く」実行。引数には関数を２つ指定できる。
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１８）関数３０「新規ウィンドウを開く」実行。引数には関数を２つ指定できる。");
                }
                //
                {

                    Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                            Expression_Node_Function30Impl.S_ACTION_NAME, this, this.Cur_Givechapterandverse,
                            this.Owner_MemoryApplication, log_Reports);

                    {
                        //Expression_Node_Function30Impl f1 = 

                        {
                            Expression_Node_StringImpl ec_FormStart;
                            {
                                Expression_FvarImpl ec_Fvar = new Expression_FvarImpl(this, this.Cur_Givechapterandverse, this.Owner_MemoryApplication);
                                ec_Fvar.AppendTextNode(NamesVar.S_SS_FORM_START, this.Cur_Givechapterandverse, log_Reports);

                                ec_FormStart = new Expression_Node_StringImpl(this, this.Cur_Givechapterandverse);
                                ec_FormStart.ListExpression_Child.Add(ec_Fvar, log_Reports);
                            }
                            ((Expression_Node_Function30Impl)expr_Func).DicExpression_Attr.Set(Expression_Node_Function30Impl.S_PM_NAME_FORM, ec_FormStart, log_Reports);
                        }

                        ((Expression_Node_Function30Impl)expr_Func).In_Subroutine_Function30_1 = this.In_Subroutine_Function30_1_OrNull;
                        ((Expression_Node_Function30Impl)expr_Func).In_Subroutine_Function30_2 = this.In_Subroutine_Function30_2_OrNull;
                        ((Expression_Node_Function30Impl)expr_Func).DicExpression_Attr.Set(
                            Expression_Node_Function30Impl.S_PM_NAME_TOGETHER,
                            new Expression_Leaf_StringImpl(NamesStg.S_STG_BEGIN_APPLICATION, null, cf_ThisMethod), log_Reports);
                    }


                    expr_Func.Execute_OnWrRhn(
                        this.ExpressionfncPrmset.Sender,
                        eventMonitor_Dammy,
                        sConfigStack_EventOrigin,
                        log_Reports
                        );
                }


                //
                //
                //
                //（１９）最後に
                //
                //
                //
                if (log_Method.CanDebug(1))
                {
                    log_Method.WriteDebug_ToConsole("（１９）最後に");
                }
                //
                this.On_P19_AtLast(
                    this.ExpressionfncPrmset.Sender,
                    (MemoryAatoolxml_Editor)this.ExpressionfncPrmset.St_SelectedProjectElm,
                    this.ExpressionfncPrmset.BProjectValid,
                    sConfigStack_EventOrigin,
                    log_Reports);




                //
                //
                //
                // 「S」と「E」を出力したい。
                //
                //
                //
                if (false)
                {
                    //List<string> list_sNodeName = new List<string>();
                    //List<string> list_eNodeName = new List<string>();

                    // 「S」全てのコントロールと、ユーザー定義関数について。

                    log_Method.WriteInfo_ToConsole("┌──────────┐「S」全てのコントロールについて。");
                    this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol fcUc, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.NewLine();
                        fcUc.ControlCommon.Expression_Control.Cur_Givechapterandverse.ToText_Content(s);
                        log_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    log_Method.WriteInfo_ToConsole("└──────────┘");

                    log_Method.WriteInfo_ToConsole("┌──────────┐「S」全てのユーザー定義関数について。");
                    this.Owner_MemoryApplication.MemoryFunctions.ForEach_Children(delegate(string sKey, Expression_Node_Function ec_CommonFunction, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.NewLine();
                        ec_CommonFunction.Cur_Givechapterandverse.ToText_Content(s);
                        log_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    log_Method.WriteInfo_ToConsole("└──────────┘");




                    // 「E」全てのコントロールと、ユーザー定義関数について。

                    log_Method.WriteInfo_ToConsole("┌──────────┐「E」全てのコントロールについて。");
                    this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol fcUc, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.NewLine();
                        fcUc.ControlCommon.Expression_Control.ToText_Snapshot(s);
                        log_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    log_Method.WriteInfo_ToConsole("└──────────┘");

                    log_Method.WriteInfo_ToConsole("┌──────────┐「E」全てのユーザー定義関数について。");
                    this.Owner_MemoryApplication.MemoryFunctions.ForEach_Children(delegate(string sKey, Expression_Node_Function ec_CommonFunction, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.NewLine();
                        ec_CommonFunction.ToText_Snapshot(s);
                        log_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    log_Method.WriteInfo_ToConsole("└──────────┘");

                }
                log_Method.WriteInfo_ToConsole("◆起動終了");





                goto gt_EndMethod;
            //
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
            if (log_Reports.BSuccessful)
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
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "On_P08_SpToVar_",log_Reports);


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


            MemoryAaeditorxml moAaeditorxml = new MemoryAaeditorxmlImpl();
            //moAaeditorxml.Clear1(log_Reports);

            if (log_Reports.BSuccessful)
            {
                moAaeditorxml.Load_AutoSystemVariable(
                    ec_Fopath_Editor,
                    this.Owner_MemoryApplication,
                    log_Reports
                    );
            }

            //
            out_moAaeditorxml_Editor = new MemoryAaeditorxml_EditorImpl(ec_Fpath_AaEditorXml.Cur_Givechapterandverse);
            if (log_Reports.BSuccessful)
            {
                out_moAaeditorxml_Editor.LoadFile_Aaxml(
                    ec_Fpath_AaEditorXml,
                    this.Owner_MemoryApplication.MemoryVariables,
                    log_Reports
                    );
            }


            if (log_Reports.BSuccessful)
            {
                moAaeditorxml.LoadFile(
                    ec_Fopath_Editor,
                    this.Owner_MemoryApplication,
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
            if (log_Reports.BSuccessful)
            {
                Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                        Expression_Node_Function44Impl.S_ACTION_NAME, this, this.Cur_Givechapterandverse,
                        this.Owner_MemoryApplication, log_Reports);

                {
                    ((Expression_Node_Function44Impl)expr_Func).Expression_FilepathList_Backup = listExpression_Filepath_BackupRequest;
                }

                expr_Func.Execute_OnWrRhn(
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
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "On_P17a_PreviousOpenWindow_Backup",log_Reports);


            //
            //
            //
            //（６）バックアップ・フォルダーのオーナー名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
            //
            //
            //
            if (log_Reports.BSuccessful)
            {
                this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_SName_SubFolder = moAaeditorxml_Editor.Dictionary_Fsetvar_Givechapterandverse.GetFsetvar(
                    NamesVar.S_SS_BACKUP_NAME_MY_FOLDER, false, log_Reports);
                if (!log_Reports.BSuccessful)
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
            if (log_Reports.BSuccessful)
            {
                this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_BackupKeptbackups = moAaeditorxml_Editor.Dictionary_Fsetvar_Givechapterandverse.GetFsetvar(
                    NamesVar.S_SI_BACKUP_KEPT_BACKUPS, false, log_Reports);
                if (!log_Reports.BSuccessful)
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
            if (log_Reports.BSuccessful)
            {
                XenonNameImpl o_Name_Variable = new XenonNameImpl(NamesVar.S_SP_BACKUP_FOLDER, new Givechapterandverse_NodeImpl("!ハードコーディング_ExAction00022#Perform_WrRhn", null));

                // 変数名。
                Expression_Leaf_StringImpl ec_Atom = new Expression_Leaf_StringImpl(null, o_Name_Variable.Cur_Givechapterandverse);
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
                    ec_Fpath_AaEditorXml.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports),
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
            if (log_Reports.BSuccessful)
            {
                Givechapterandverse_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_BackupKeptbackups;

                string sValue;
                cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                this.TestExists_String(
                    "DateBackupKeptbackups",
                    sValue,
                    ec_Fpath_AaEditorXml.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports),
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
            if (log_Reports.BSuccessful)
            {
                Givechapterandverse_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_SName_SubFolder;

                string sValue;
                cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                this.TestExists_String(
                    "DateBackupFolderOwnerName",
                    sValue,
                    ec_Fpath_AaEditorXml.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports),
                    log_Reports
                );
            }

            // 保管するバックアップ数（日毎）
            if (log_Reports.BSuccessful)
            {
                int nBackups;
                {
                    Givechapterandverse_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_BackupKeptbackups;

                    string sValue;
                    cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                    if (!int.TryParse(sValue, out nBackups))
                    {
                        // エラー。
                        this.Owner_MemoryApplication.MemoryBackup.NBackupKeptbackups = 0;
                    }
                    else
                    {
                        this.Owner_MemoryApplication.MemoryBackup.NBackupKeptbackups = nBackups;
                    }
                }

                // バックアップ・フォルダーのサブ名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
                {
                    Givechapterandverse_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_SName_SubFolder;

                    string sValue;
                    cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, log_Reports);

                    this.Owner_MemoryApplication.MemoryBackup.SName_SubFolder = sValue;
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
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "TestExists_String",log_Reports);

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
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1202！", log_Method);

                StringBuilder sB = new StringBuilder();
                sB.Append("『");
                sB.Append(sFpath_SelectedProject);
                sB.Append("』ファイルの『");
                sB.Append(sArgName_Display);
                sB.Append("』が未設定です。");
                sB.Append(Environment.NewLine);
                r.SMessage = sB.ToString();
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

        protected void TestExists_EmptyFilePath(
            string sArgName,
            Expression_Node_Filepath ec_Fpath,
            string sFpath_SelectedProject,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.SName_Library, this, "TestExists_EmptyFilePath",log_Reports);
            //
            //

            if (null == ec_Fpath)
            {
                goto gt_Error_NullFpath;
            }
            else if ("" == ec_Fpath.SHumaninput)
            {
                goto gt_Error_NoData;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullFpath:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー502！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("『");
                s.Append(sFpath_SelectedProject);
                s.Append("』エディター設定ファイルに、『");
                s.Append(sArgName);
                s.Append("』設定が　ありませんでした。");
                s.Append(Environment.NewLine);
                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NoData:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー501！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append("『");
                s.Append(sArgName);
                s.Append("』が未設定です。");
                s.Append(Environment.NewLine);

                s.Append(r.Message_Givechapterandverse(ec_Fpath.Cur_Givechapterandverse));

                r.SMessage = s.ToString();
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
