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
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "NewInstance",pg_Logging);
            //

            Expression_Node_FunctionAbstract f0 = new Expression_Node_Function_OnEditorSelected_Impl(this.EnumEventhandler, this.ListS_ArgName,this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Givechapterandverse = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.DicExpression_Attr.Set(PmNames.S_NAME.SName_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), pg_Logging);
            ((Expression_Node_Function_OnEditorSelected_Impl)f0).in_Subroutine_Function30_1_OrNull = null;
            ((Expression_Node_Function_OnEditorSelected_Impl)f0).in_Subroutine_Function30_2_OrNull = null;

            //
            pg_Method.EndMethod(pg_Logging);
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
        /// <param name="pg_Logging"></param>
        public override string Expression_ExecuteMain(Log_Reports pg_Logging)
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method pg_Method = new Log_MethodImpl(1);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "Expression_ExecuteMain",pg_Logging);


            //
            //
            //
            //
            //
            //
            //
            if (pg_Method.CanDebug(1))
            {
                pg_Method.WriteDebug_ToConsole("「プロジェクト選択時」用のイベントハンドラーを実行します。");
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
                this.TrySelectAttr(out sFncName0, PmNames.S_NAME.SName_Pm, false, Request_SelectingImpl.Unconstraint, pg_Logging);
                if (this.ExpressionfncPrmset.Sender is Customcontrol)
                {
                    Customcontrol ccFc = (Customcontrol)this.ExpressionfncPrmset.Sender;
                    string sName_Usercontrol = ccFc.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);
                    pg_Logging.SComment_EventCreationMe += "／追加：[" + sName_Usercontrol + "]コントロールが、[" + sFncName0 + "]アクションを実行。";
                }
                else
                {
                    pg_Logging.SComment_EventCreationMe += "／追加：[" + sFncName0 + "]アクションを実行。";
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
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（４）独自モデルの取得");
                }
                //
                this.On_P04_ReadNewModel(pg_Logging);




                //
                //
                //
                //（５）エディター名。ツール設定ファイルに記載されている方。
                //
                //
                //
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（５）エディター名。ツール設定ファイルに記載されている方。");
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
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（６）まず、きれいさっぱり　プロジェクトをクリアーします。（切替用）");
                }
                // todo:イベントハンドラーを外してから、フォームを外すこと。リストボックスが誤挙動を起こしている。
                this.On_P06_ClearProject(this.ExpressionfncPrmset.Sender, eventMonitor_Dammy, pg_Logging);




                //
                //
                //
                //（７）「Aa_Editor.xml」読取。
                //
                //
                //
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（７）「Aa_Editor.xml」読取。");
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
                    if (pg_Logging.BSuccessful)
                    {
                        if ("" == sName_SelectingEditor)
                        {
                            //
                            // デフォルト・エディター名が未指定の場合。
                            //
                            MemoryAatoolxml_Editor moAatoolxml_DefaultEditor = this.Owner_MemoryApplication.MemoryAatoolxml.GetDefaultEditor(true, pg_Logging);
                            if (!pg_Logging.BSuccessful)
                            {
                                // 既エラー。
                                goto gt_EndMethod;
                            }

                            // ↓これ要る？
                            sName_SelectingEditor = moAatoolxml_DefaultEditor.SName;
                        }
                    }


                    this.On_P07_SelectDefaultProject(ref sName_SelectingEditor, ref moAatoolxml_PrevEditorElm_OrNull, this.ExpressionfncPrmset.BProjectValid, pg_Logging);


                    this.ExpressionfncPrmset.St_SelectedProjectElm = moAatoolxml_PrevEditorElm_OrNull;

                    //
                    //
                    //
                    //「プロジェクトを開いた時の初期化」イベントハンドラーで使うために、ここで設定します。
                    //
                    //
                    //
                    this.ExpressionfncPrmset.St_SelectedProjectElm = this.Owner_MemoryApplication.MemoryAatoolxml.GetEditorByName(sName_SelectingEditor, true, pg_Logging);
                    if (!pg_Logging.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }


                // ↓追加
                if (null == this.ExpressionfncPrmset.St_SelectedProjectElm)
                {
                    if (pg_Logging.CanCreateReport)
                    {
                        Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                        r.SetTitle("▲エラー1029！", pg_Method);

                        StringBuilder s = new StringBuilder();
                        s.Append("ツール設定ファイルから、デフォルトプロジェクトを選べませんでした。");
                        s.Append(Environment.NewLine);
                        s.Append("エディター名＝[");
                        s.Append(sName_SelectingEditor);
                        s.Append("]");
                        r.SMessage = s.ToString();
                        pg_Logging.EndCreateReport();
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
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１３ａ）エディター・フォルダーパス類推。");
                }
                //
                //
                //
                Expression_Node_Filepath ec_Fopath_Editor;
                if (pg_Logging.BSuccessful)
                {
                    MemoryAatoolxml_Editor moAatoolxml_SelectedEditor = (MemoryAatoolxml_Editor)this.ExpressionfncPrmset.St_SelectedProjectElm;
                    ec_Fopath_Editor = moAatoolxml_SelectedEditor.GetFilepathByFsetvarname(
                        NamesVar.S_SP_EDITOR,
                        this.Owner_MemoryApplication.MemoryVariables,
                        true,
                        pg_Logging
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
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１３ｂ）「Aa_Editor.xml」ファイルパス類推。");
                }
                //
                Expression_Node_Filepath ec_Fpath_AaEditorXml;
                if (pg_Logging.BSuccessful)
                {

                    //
                    // ツール設定ファイルで指定された値から、自動類推で設定されているはず。
                    //
                    Givechapterandverse_Filepath cf_Fpath_EditorXml = new Givechapterandverse_FilepathImpl(
                        "ツール設定ファイル[" + Application.StartupPath + System.IO.Path.DirectorySeparatorChar + ValuesAttr.S_FPATHR_AATOOLXML + "]の中の[" + sName_SelectingEditor + "]エディターへの指定から自動類推",
                        null);

                    // フォルダーパス ＋ \Aa_Editor.xml
                    string sFpatha_Aaeditorxml = ec_Fopath_Editor.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging) + System.IO.Path.DirectorySeparatorChar + NamesFile.S_AA_EDITOR_XML;

                    // プロジェクト起動時に。
                    cf_Fpath_EditorXml.InitPath(
                        sFpatha_Aaeditorxml,
                        pg_Logging
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
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（８）「エディター設定ファイル」に記述されている＜ｆ－ｓｅｔ－ｖａｒ＞要素を、「エディター設定ファイル・モデル」に格納。Cf→M。この時点で「Sp:Engine;」といったシステム変数は自動類推が終わっている必要があります。");
                }
                //
                MemoryAaeditorxml_Editor moAaeditorxml_Editor = null;
                if (pg_Logging.BSuccessful)
                {
                    this.On_P08_SpToVar_(
                        out moAaeditorxml_Editor,
                        ec_Fpath_AaEditorXml,
                        ec_Fopath_Editor,
                        (MemoryAatoolxml_Editor)this.ExpressionfncPrmset.St_SelectedProjectElm,
                        pg_Logging
                        );
                }



                
                //
                //
                //
                // ここで「Aa_Files.csv」を読み込みたい。
                //
                //
                //




                if (pg_Logging.BSuccessful)
                {
                    //
                    //
                    //
                    //（９）変数ファイル読取
                    //
                    //
                    //
                    if (pg_Method.CanDebug(1))
                    {
                        pg_Method.WriteDebug_ToConsole("（９）変数ファイル読取");
                    }
                    //
                    this.Owner_MemoryApplication.MemoryVariables.LoadVariables(
                        Application.StartupPath,
                        this.Owner_MemoryApplication,
                        pg_Logging
                        );
                }




                if (pg_Logging.BSuccessful)
                {
                    //
                    //
                    //
                    //（１０）プログラマー用・デバッグモードのON/OFF。
                    //
                    //
                    //
                    if (pg_Method.CanDebug(1))
                    {
                        pg_Method.WriteDebug_ToConsole("（１０）プログラマー用・デバッグモードのON/OFF。");
                    }
                    //
                    //mainWndの作成より先に設定する必要がある。ステータスバーを出す、出さないについて。
                    {
                        Expression_Leaf_StringImpl ec_Varname = new Expression_Leaf_StringImpl(this, this.Cur_Givechapterandverse.Parent_Givechapterandverse);
                        ec_Varname.SetString(NamesVar.S_SS_DEBUGMODE_PROGRAMMER, pg_Logging);
                        string sValue = this.Owner_MemoryApplication.MemoryVariables.GetStringByVariablename(ec_Varname, false, pg_Logging);
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




                if (pg_Logging.BSuccessful)
                {
                    //
                    //
                    //
                    //（１１）画面レイアウト・デバッグモードのON/OFF。
                    //
                    //
                    //
                    if (pg_Method.CanDebug(1))
                    {
                        pg_Method.WriteDebug_ToConsole("（１１）フォーム・デバッグモードのON/OFF。");
                    }
                    //
                    Expression_Leaf_StringImpl ec_Varname = new Expression_Leaf_StringImpl(this, this.Cur_Givechapterandverse.Parent_Givechapterandverse);
                    ec_Varname.SetString(NamesVar.S_SS_DEBUGMODE_FORM, pg_Logging);
                    string sValue = this.Owner_MemoryApplication.MemoryVariables.GetStringByVariablename(ec_Varname, false, pg_Logging);
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
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１４）「Aa_Files.csv」読取。");
                }
                //
                List<Expression_Node_Filepath> ecList_Fpath_BackupRequest;
                {
                    if (pg_Logging.BSuccessful)
                    {
                        // 正常時

                        Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                                Expression_Node_Function22Impl.S_ACTION_NAME, this, this.Cur_Givechapterandverse,
                                this.Owner_MemoryApplication, pg_Logging);

                        // 実行
                        expr_Func.Execute_OnWrRhn(this.ExpressionfncPrmset.Sender, eventMonitor_Dammy, sConfigStack_EventOrigin, pg_Logging);

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
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１４ｂ）ユーザー定義関数設定ファイル読取【2012-03-30追加】");
                }
                //
                if (pg_Logging.BSuccessful)
                {
                    // タイプデータ値。
                    Expression_Leaf_StringImpl ec_NameVariable = new Expression_Leaf_StringImpl(this, new Givechapterandverse_NodeImpl("!ハードコーディング",null));
                    ec_NameVariable.SetString(ValuesTypeData.S_CODE_FUNCTIONS, pg_Logging);

                    List<MemoryCodefileinfo> listInfo = null;
                    if (pg_Logging.BSuccessful)
                    {
                        listInfo = this.Owner_MemoryApplication.MemoryCodefiles.GetCodefileinfoByTypedata(ec_NameVariable, true, pg_Logging);
                    }

                    if (pg_Logging.BSuccessful)
                    {
                        foreach (MemoryCodefileinfo scriptfile in listInfo)
                        {
                            if (pg_Logging.BSuccessful)
                            {
                                this.Owner_MemoryApplication.MemoryFunctions.LoadFile(
                                    scriptfile.Expression_Filepath,
                                    this.Owner_MemoryApplication,
                                    pg_Logging);

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
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１６）『スタイルシート設定ファイル』読取");
                }
                //
                if (pg_Logging.BSuccessful)
                {
                    Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                        Expression_Node_Function19Impl.S_ACTION_NAME, this, this.Cur_Givechapterandverse,
                        this.Owner_MemoryApplication, pg_Logging);

                    Expression_Node_StringImpl ec_Str = new Expression_Node_StringImpl(this, cf_ThisMethod);
                    ec_Str.AppendTextNode(NamesVar.S_ST_STYLESHEET, this.Cur_Givechapterandverse, pg_Logging);

                    expr_Func.DicExpression_Attr.Set(Expression_Node_Function19Impl.S_PM_NAME_TABLE_STYLE_SHEET, ec_Str, pg_Logging);


                    expr_Func.Execute_OnWrRhn(
                        this.ExpressionfncPrmset.Sender,
                        eventMonitor_Dammy,
                        sConfigStack_EventOrigin,
                        pg_Logging
                        );
                }



                //
                //
                //
                //（１７ａ）「バックアップを取る」前にしておく独自実装をするタイミング。
                //
                //
                //
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１７ａ）「バックアップを取る」前にしておく独自実装をするタイミング。");
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
                    pg_Logging);

                //
                //
                //
                //（１７ｂ）今日の分のバックアップを取ります。
                //
                //
                //
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１７ｂ）今日の分のバックアップを取ります。");
                }
                //
                this.On_P17b_DateBackup(ecList_Fpath_BackupRequest, this.ExpressionfncPrmset.Sender, eventMonitor_Dammy, sConfigStack_EventOrigin, pg_Logging);


                //
                //
                //
                //（１７ｃ）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。
                //
                //
                //
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１７ｃ）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。");
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
                    pg_Logging);


                //
                //
                //
                //（１８）関数３０「新規ウィンドウを開く」実行。引数には関数を２つ指定できる。
                //
                //
                //
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１８）関数３０「新規ウィンドウを開く」実行。引数には関数を２つ指定できる。");
                }
                //
                {

                    Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                            Expression_Node_Function30Impl.S_ACTION_NAME, this, this.Cur_Givechapterandverse,
                            this.Owner_MemoryApplication, pg_Logging);

                    {
                        //Expression_Node_Function30Impl f1 = 

                        {
                            Expression_Node_StringImpl ec_FormStart;
                            {
                                Expression_FvarImpl ec_Fvar = new Expression_FvarImpl(this, this.Cur_Givechapterandverse, this.Owner_MemoryApplication);
                                ec_Fvar.AppendTextNode(NamesVar.S_SS_FORM_START, this.Cur_Givechapterandverse, pg_Logging);

                                ec_FormStart = new Expression_Node_StringImpl(this, this.Cur_Givechapterandverse);
                                ec_FormStart.ListExpression_Child.Add(ec_Fvar, pg_Logging);
                            }
                            ((Expression_Node_Function30Impl)expr_Func).DicExpression_Attr.Set(Expression_Node_Function30Impl.S_PM_NAME_FORM, ec_FormStart, pg_Logging);
                        }

                        ((Expression_Node_Function30Impl)expr_Func).In_Subroutine_Function30_1 = this.In_Subroutine_Function30_1_OrNull;
                        ((Expression_Node_Function30Impl)expr_Func).In_Subroutine_Function30_2 = this.In_Subroutine_Function30_2_OrNull;
                        ((Expression_Node_Function30Impl)expr_Func).DicExpression_Attr.Set(
                            Expression_Node_Function30Impl.S_PM_NAME_TOGETHER,
                            new Expression_Leaf_StringImpl(NamesStg.S_STG_BEGIN_APPLICATION, null, cf_ThisMethod), pg_Logging);
                    }


                    expr_Func.Execute_OnWrRhn(
                        this.ExpressionfncPrmset.Sender,
                        eventMonitor_Dammy,
                        sConfigStack_EventOrigin,
                        pg_Logging
                        );
                }


                //
                //
                //
                //（１９）最後に
                //
                //
                //
                if (pg_Method.CanDebug(1))
                {
                    pg_Method.WriteDebug_ToConsole("（１９）最後に");
                }
                //
                this.On_P19_AtLast(
                    this.ExpressionfncPrmset.Sender,
                    (MemoryAatoolxml_Editor)this.ExpressionfncPrmset.St_SelectedProjectElm,
                    this.ExpressionfncPrmset.BProjectValid,
                    sConfigStack_EventOrigin,
                    pg_Logging);




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

                    pg_Method.WriteInfo_ToConsole("┌──────────┐「S」全てのコントロールについて。");
                    this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol fcUc, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.NewLine();
                        fcUc.ControlCommon.Expression_Control.Cur_Givechapterandverse.ToText_Content(s);
                        pg_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    pg_Method.WriteInfo_ToConsole("└──────────┘");

                    pg_Method.WriteInfo_ToConsole("┌──────────┐「S」全てのユーザー定義関数について。");
                    this.Owner_MemoryApplication.MemoryFunctions.ForEach_Children(delegate(string sKey, Expression_Node_Function ec_CommonFunction, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.NewLine();
                        ec_CommonFunction.Cur_Givechapterandverse.ToText_Content(s);
                        pg_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    pg_Method.WriteInfo_ToConsole("└──────────┘");




                    // 「E」全てのコントロールと、ユーザー定義関数について。

                    pg_Method.WriteInfo_ToConsole("┌──────────┐「E」全てのコントロールについて。");
                    this.Owner_MemoryApplication.MemoryForms.ForEach_Children(delegate(string sKey, Usercontrol fcUc, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.NewLine();
                        fcUc.ControlCommon.Expression_Control.ToText_Snapshot(s);
                        pg_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    pg_Method.WriteInfo_ToConsole("└──────────┘");

                    pg_Method.WriteInfo_ToConsole("┌──────────┐「E」全てのユーザー定義関数について。");
                    this.Owner_MemoryApplication.MemoryFunctions.ForEach_Children(delegate(string sKey, Expression_Node_Function ec_CommonFunction, ref bool bRemove, ref bool bBreak)
                    {
                        Log_TextIndented s = new Log_TextIndentedImpl();
                        s.Append("[" + sKey + "]");
                        s.NewLine();
                        ec_CommonFunction.ToText_Snapshot(s);
                        pg_Method.WriteInfo_ToConsole(s.ToString());
                    });
                    pg_Method.WriteInfo_ToConsole("└──────────┘");

                }
                pg_Method.WriteInfo_ToConsole("◆起動終了");





                goto gt_EndMethod;
            //
            //
            gt_EndMethod:
                pg_Method.EndMethod(pg_Logging);
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
        protected virtual void On_P04_ReadNewModel(Log_Reports pg_Logging)
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
            Log_Reports pg_Logging)
        {
            //
            //
            //
            //（６）まず、きれいさっぱり　プロジェクトをクリアーします。（プロジェクト切替用）
            //
            //
            //
            if (pg_Logging.BSuccessful)
            {
                this.Owner_MemoryApplication.ClearProject(
                    this.Owner_MemoryApplication.MemoryForms.Mainwnd_FormWrapping.Form.Controls,
                    pg_Logging
                    );
            }
        }

        protected virtual void On_P07_SelectDefaultProject(
            ref string sName_InitialProject,
            ref MemoryAatoolxml_Editor moAatoolxml_PrevEditor_OrNull,
            bool bProjectValid,
            Log_Reports pg_Logging
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
        /// <param name="pg_Logging"></param>
        private void On_P08_SpToVar_(
            out MemoryAaeditorxml_Editor out_moAaeditorxml_Editor,
            Expression_Node_Filepath ec_Fpath_AaEditorXml,
            Expression_Node_Filepath ec_Fopath_Editor,
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor,
            Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "On_P08_SpToVar_",pg_Logging);


            //
            //
            //
            //（１３ｃ）『Aa_Editor.xml』ロード
            //
            //
            //
            if (pg_Method.CanDebug(1))
            {
                pg_Method.WriteDebug_ToConsole("（１３ｃ）『Aa_Editor.xml』ロード");
            }


            MemoryAaeditorxml moAaeditorxml = new MemoryAaeditorxmlImpl();
            //moAaeditorxml.Clear1(pg_Logging);

            if (pg_Logging.BSuccessful)
            {
                moAaeditorxml.Load_AutoSystemVariable(
                    ec_Fopath_Editor,
                    this.Owner_MemoryApplication,
                    pg_Logging
                    );
            }

            //
            out_moAaeditorxml_Editor = new MemoryAaeditorxml_EditorImpl(ec_Fpath_AaEditorXml.Cur_Givechapterandverse);
            if (pg_Logging.BSuccessful)
            {
                out_moAaeditorxml_Editor.LoadFile_Aaxml(
                    ec_Fpath_AaEditorXml,
                    this.Owner_MemoryApplication.MemoryVariables,
                    pg_Logging
                    );
            }


            if (pg_Logging.BSuccessful)
            {
                moAaeditorxml.LoadFile(
                    ec_Fopath_Editor,
                    this.Owner_MemoryApplication,
                    pg_Logging
                    );
            }


            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }


        /// <summary>
        /// （１７ｂ）今日の分のバックアップを取ります。
        /// </summary>
        /// <param name="e_FpathList_BackupRequest"></param>
        /// <param name="sender"></param>
        /// <param name="eventMonitor_Dammy"></param>
        /// <param name="sConfigStack_EventOrigin"></param>
        /// <param name="pg_Logging"></param>
        protected virtual void On_P17b_DateBackup(
            List<Expression_Node_Filepath> listExpression_Filepath_BackupRequest,
            object sender,
            EventMonitor eventMonitor_Dammy,
            string sConfigStack_EventOrigin,
            Log_Reports pg_Logging)
        {
            if (pg_Logging.BSuccessful)
            {
                Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                        Expression_Node_Function44Impl.S_ACTION_NAME, this, this.Cur_Givechapterandverse,
                        this.Owner_MemoryApplication, pg_Logging);

                {
                    ((Expression_Node_Function44Impl)expr_Func).Expression_FilepathList_Backup = listExpression_Filepath_BackupRequest;
                }

                expr_Func.Execute_OnWrRhn(
                    sender,
                    eventMonitor_Dammy,
                    sConfigStack_EventOrigin,
                    pg_Logging
                    );
            }
        }


        /// <summary>
        /// （１７）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor_Dammy"></param>
        /// <param name="sConfigStack_EventOrigin"></param>
        /// <param name="pg_Logging"></param>
        protected virtual void On_P17a_PreviousBackup(
            object sender,
            MemoryAaeditorxml_Editor moAaeditorxml_Editor,
            Expression_Node_Filepath ec_Fpath_AaEditorXml,
            Expression_Node_Filepath ec_Fopath_Editor,
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor,
            EventMonitor eventMonitor_Dammy,
            string sConfigStack_EventOrigin,
            Log_Reports pg_Logging)
        {
            //
            //
            //
            //（）メソッド開始
            //
            //
            //
            Log_Method pg_Method = new Log_MethodImpl(1, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "On_P17a_PreviousOpenWindow_Backup",pg_Logging);


            //
            //
            //
            //（６）バックアップ・フォルダーのオーナー名。例えば aaa なら、2009年12月3日のフォルダー名は 20091203_aaa になります。
            //
            //
            //
            if (pg_Logging.BSuccessful)
            {
                this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_SName_SubFolder = moAaeditorxml_Editor.Dictionary_Fsetvar_Givechapterandverse.GetFsetvar(
                    NamesVar.S_SS_BACKUP_NAME_MY_FOLDER, false, pg_Logging);
                if (!pg_Logging.BSuccessful)
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
            if (pg_Logging.BSuccessful)
            {
                this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_BackupKeptbackups = moAaeditorxml_Editor.Dictionary_Fsetvar_Givechapterandverse.GetFsetvar(
                    NamesVar.S_SI_BACKUP_KEPT_BACKUPS, false, pg_Logging);
                if (!pg_Logging.BSuccessful)
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
            if (pg_Logging.BSuccessful)
            {
                XenonNameImpl o_Name_Variable = new XenonNameImpl(NamesVar.S_SP_BACKUP_FOLDER, new Givechapterandverse_NodeImpl("!ハードコーディング_ExAction00022#Perform_WrRhn", null));

                // 変数名。
                Expression_Leaf_StringImpl ec_Atom = new Expression_Leaf_StringImpl(null, o_Name_Variable.Cur_Givechapterandverse);
                ec_Atom.SetString(
                    o_Name_Variable.SValue,
                    pg_Logging
                );

                // ファイルパス。
                pg_Logging.Log_Callstack.Push(pg_Method, "①");
                Expression_Node_Filepath ec_Fpath_Exports = this.Owner_MemoryApplication.MemoryVariables.GetExpressionfilepathByVariablename(
                    ec_Atom,
                    true,
                    pg_Logging
                    );
                pg_Logging.Log_Callstack.Pop(pg_Method, "①");

                this.TestExists_EmptyFilePath(
                    "BackupBaseDirectory",
                    ec_Fpath_Exports,
                    ec_Fpath_AaEditorXml.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging),
                    pg_Logging
                );
            }

            //
            //
            //
            // バックアップ数 文字列有無チェック。
            //
            //
            //
            if (pg_Logging.BSuccessful)
            {
                Givechapterandverse_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_BackupKeptbackups;

                string sValue;
                cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, pg_Logging);

                this.TestExists_String(
                    "DateBackupKeptbackups",
                    sValue,
                    ec_Fpath_AaEditorXml.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging),
                    pg_Logging
                );
            }


            //
            //
            //
            // バックアップ・フォルダー名 文字列有無チェック。
            //
            //
            //
            if (pg_Logging.BSuccessful)
            {
                Givechapterandverse_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_SName_SubFolder;

                string sValue;
                cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, pg_Logging);

                this.TestExists_String(
                    "DateBackupFolderOwnerName",
                    sValue,
                    ec_Fpath_AaEditorXml.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging),
                    pg_Logging
                );
            }

            // 保管するバックアップ数（日毎）
            if (pg_Logging.BSuccessful)
            {
                int nBackups;
                {
                    Givechapterandverse_Node cf_Fsetvar = this.Owner_MemoryApplication.MemoryBackup.Givechapterandverse_BackupKeptbackups;

                    string sValue;
                    cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, pg_Logging);

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
                    cf_Fsetvar.Dictionary_SAttribute_Givechapterandverse.TryGetValue(PmNames.S_VALUE, out sValue, true, pg_Logging);

                    this.Owner_MemoryApplication.MemoryBackup.SName_SubFolder = sValue;
                }
            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        /// <summary>
        /// （１７）「新規ウィンドウを開く」前にしておく独自実装をするタイミング。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor_Dammy"></param>
        /// <param name="sConfigStack_EventOrigin"></param>
        /// <param name="pg_Logging"></param>
        protected virtual void On_P17c_PreviousOpenWindow(
            object sender,
            MemoryAaeditorxml_Editor moAaeditorxml_Editor,
            Expression_Node_Filepath ec_Fpath_AaEditorXml,
            Expression_Node_Filepath ec_Fopath_Editor,
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor,
            EventMonitor eventMonitor_Dammy,
            string sConfigStack_EventOrigin,
            Log_Reports pg_Logging)
        {
        }

        protected virtual void On_P19_AtLast(
            object sender,
            MemoryAatoolxml_Editor moAatoolxml_SelectedEditor,
            bool bProjectValid,
            string sConfigStack_EventOrigin,
            Log_Reports pg_Logging
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
            Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "TestExists_String",pg_Logging);

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
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー1202！", pg_Method);

                StringBuilder sB = new StringBuilder();
                sB.Append("『");
                sB.Append(sFpath_SelectedProject);
                sB.Append("』ファイルの『");
                sB.Append(sArgName_Display);
                sB.Append("』が未設定です。");
                sB.Append(Environment.NewLine);
                r.SMessage = sB.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        protected void TestExists_EmptyFilePath(
            string sArgName,
            Expression_Node_Filepath ec_Fpath,
            string sFpath_SelectedProject,
            Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, this, "TestExists_EmptyFilePath",pg_Logging);
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
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー502！", pg_Method);

                StringBuilder s = new StringBuilder();
                s.Append("『");
                s.Append(sFpath_SelectedProject);
                s.Append("』エディター設定ファイルに、『");
                s.Append(sArgName);
                s.Append("』設定が　ありませんでした。");
                s.Append(Environment.NewLine);
                r.SMessage = s.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NoData:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー501！", pg_Method);

                StringBuilder s = new StringBuilder();
                s.Append("『");
                s.Append(sArgName);
                s.Append("』が未設定です。");
                s.Append(Environment.NewLine);

                s.Append(r.Message_Givechapterandverse(ec_Fpath.Cur_Givechapterandverse));

                r.SMessage = s.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
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
