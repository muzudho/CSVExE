using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;

namespace Xenon.Functions
{


    /// <summary>
    /// 『ＣＳＶエディター』を起動します。
    /// </summary>
    public class Expression_Node_Function_BootCsvEditorImpl : Expression_Node_FunctionAbstract
    {



        #region 用意
        //────────────────────────────────────────
        //
        // 関数名
        //

        /// <summary>
        /// 関数名。
        /// </summary>
        public const string S_ACTION_NAME = "Sf:Frame02;";

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Expression_Node_Function_BootCsvEditorImpl(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            : base(enumEventhandler, listS_ArgName, functiontranslatoritem)
        {
        }

        public override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "NewInstance",log_Reports);
            //

            Expression_Node_Function f0 = new Expression_Node_Function_BootCsvEditorImpl(this.EnumEventhandler, this.List_NameArgument, this.Functiontranslatoritem);
            f0.Parent_Expression = parent_Expression;
            f0.Cur_Configurationtree = cur_Gcav;
            ((Expression_Node_FunctionAbstract)f0).Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            //関数名初期値
            f0.Dictionary_Expression_Attribute.Set(PmNames.S_NAME.Name_Pm, new Expression_Leaf_StringImpl(S_ACTION_NAME, null, cur_Gcav), log_Reports);

            //「プロジェクト選択時」のイベントハンドラーを上書き要求。
            {
                Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                        Expression_Node_Function_OnEditorSelected_Impl.S_ACTION_NAME,
                        f0,
                        cur_Gcav,
                        owner_MemoryApplication,
                        log_Reports
                        );
                ((Expression_Node_Function_BootCsvEditorImpl)f0).Functionitem_OnProjectSelected = expr_Func;
            }

            //
            log_Method.EndMethod(log_Reports);
            return f0;
        }

        //────────────────────────────────────────
        #endregion

        

        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Expression_ExecuteMain(Log_Reports log_Reports)
        {
            //（１）メソッド開始
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Expression_ExecuteMain",log_Reports);

            if (this.EnumEventhandler == EnumEventhandler.O_Ea)
            {
                string sConfigStack_ThisMethod = "＜" + Info_Functions.Name_Library + ":" + this.GetType().Name + "#Perform_OEa:＞";
                Configurationtree_Node cf_ThisMethod = new Configurationtree_NodeImpl(sConfigStack_ThisMethod, null);


                //
                //
                //
                //（２）独自実装のモデルをセットアップするタイミング。
                //
                //
                //
                this.On_P2_NewModelSetup(log_Reports);


                //
                //
                //
                //（３）.exeのファイルパス
                //
                //
                //
                string sFpath_Startup = Application.StartupPath;


                //
                //
                //
                //（４）[F8]キーを押すと、「ツール設定ダイアログ」が開くようにします。
                //
                //
                //
                {
                    Expression_Node_Function expr_Func = Collection_Function.NewFunction2(
                            Expression_Node_Function21Impl.S_ACTION_NAME,
                            this,
                            this.Cur_Configurationtree,
                            this.Owner_MemoryApplication,
                            log_Reports
                            );

                    this.Owner_MemoryApplication.MemoryForms.Mainwnd_FormWrapping.Form.KeyDown += new System.Windows.Forms.KeyEventHandler(((Expression_Node_FunctionImpl)expr_Func).Execute_OnKey);
                }


                //
                //
                //
                //（５）『ツール設定ファイル』読取。
                //
                //
                //
                {
                    this.Owner_MemoryApplication.MemoryAatoolxml.P101_LoadAatoolxml( cf_ThisMethod, log_Reports);
                }


                //
                //
                //
                //（６）『ツール設定ダイアログ』の初期設定。
                //
                //
                //
                if (log_Reports.Successful)
                {
                    this.Owner_MemoryApplication.MemoryForms.Form_Toolwindow.Clear();

                    this.Owner_MemoryApplication.MemoryForms.Form_Toolwindow.InitializeBeforeUse(
                        this.Owner_MemoryApplication
                        );


                    // 「プロジェクト選択時」のイベントハンドラとして登録。
                    Expression_Node_Function expr_Func = this.Functionitem_OnProjectSelected.NewInstance(
                        this.Parent_Expression,
                        this.Cur_Configurationtree,
                        //EnumEventhandler.Unknown,
                        this.Owner_MemoryApplication,
                        log_Reports
                        );
                    //expr_Func.InitializeBeforeUse(this.Owner_MemoryApplication);
                    this.Owner_MemoryApplication.MemoryForms.Form_Toolwindow.OnEditorSelected += expr_Func.Execute_OnEditorSelected;
                }


                //
                //
                //
                //（７）「プロジェクト選択時」のイベントハンドラーを実行。（アプリケーション起動１回目）
                //
                //
                //
                if (log_Reports.Successful)
                {
                    this.Functionitem_OnProjectSelected.Execute_OnEditorSelected(
                        this.Functionparameterset.Sender, null, false, log_Reports);
                }



                //
                //
                //
                //（８）タイトル
                //
                //
                //
                if (log_Reports.Successful)
                {
                    // タイトルは、外部ファイルで記述します。

                    // mainWnd は、UcWindow ではなく UcPanel です。UsercontrolTextに設定しても、ウィンドウのタイトルは変わりません。
                    // mainWnd は特殊な方法で取得します。
                    Mainwnd_FormWrapping mainwnd_FormWrapping = this.Owner_MemoryApplication.MemoryForms.Mainwnd_FormWrapping;
                    mainwnd_FormWrapping.ControlCommon.BAutomaticinputting = true;

                    StringBuilder sb;
                    {
                        sb = new StringBuilder();

                        // エディター設定ファイルに記載されているエディターの表示タイトル。
                        sb.Append(this.Owner_MemoryApplication.MemoryVariables.GetStringByVariablename(
                            new Expression_Leaf_StringImpl(NamesVar.S_SS_TITLE_EDITOR,null,new Configurationtree_NodeImpl(log_Method.Fullname,null)),
                            false,log_Reports));

                        // レイアウト・テーブルに記載されているエディター名。
                        sb.Append(mainwnd_FormWrapping.UsercontrolText);

                        // 自動で付加。
                        sb.Append(" [CSVE×E " + ValuesAttr.S_VERSION_CSVEXE + "（code " + ValuesAttr.S_VERSION_CODEFILE + "）] - Xenontools （※[F8]キーでツール窓）");

                        mainwnd_FormWrapping.UsercontrolText = sb.ToString();
                    }

                    mainwnd_FormWrapping.ControlCommon.BAutomaticinputting = false;
                }
            }


            //
            //
            //
            //（１０）メソッド終了
            //
            //
            //
            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// 独自実装のモデルをセットアップするタイミング。
        /// </summary>
        protected virtual void On_P2_NewModelSetup(Log_Reports log_Reports)
        {
        }

        //────────────────────────────────────────
        #endregion


        
        #region プロパティー
        //────────────────────────────────────────

        private Expression_Node_Function functionitem_OnProjectSelected;

        /// <summary>
        /// 「プロジェクト選択時」に実行されるイベントハンドラ。
        /// </summary>
        public Expression_Node_Function Functionitem_OnProjectSelected
        {
            get
            {
                return this.functionitem_OnProjectSelected;
            }
            set
            {
                this.functionitem_OnProjectSelected = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
