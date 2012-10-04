using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Controls;

namespace Xenon.Expr
{
    /// <summary>
    /// コマンド。（システム関数相当）
    /// 
    /// ＜ｃｏｍｍｏｎ－ｆｕｎｃｔｉｏｎ＞要素。関数定義文。
    /// 
    /// todo: Expression_Node_FunctionAbstract と分けているのはなぜ？
    /// </summary>
    public class Expression_Node_FunctionImpl : FunctionexecutableAbstract, Expression_Node_Function
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="parent_Expression">生成時はヌルを入れておいて、#NewInstanceで後から設定することもできます。</param>
        /// <param name="cur_Gcav">生成時はヌルを入れておいて、#NewInstanceで後から設定することもできます。</param>
        public Expression_Node_FunctionImpl(
            Expression_Node_String parent_Expression, Configurationtree_Node cur_Gcav, List<string> listS_ArgName)
            : base(parent_Expression, cur_Gcav)
        {
            this.dictionary_Expression_Parameter = new Dictionary_Expression_Node_StringImpl(cur_Gcav);
            this.functionparameterset = new FunctionparametersetImpl();

            this.list_NameArgument = listS_ArgName;// new List<string>();
        }

        /// <summary>
        /// 込み入った処理が必要なこともあるので、コンストラクターとは分けています。
        /// </summary>
        /// <param name="parent_Expression"></param>
        /// <param name="cur_Gcav"></param>
        /// <param name="owner_MemoryApplication"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public virtual Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression,
            Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication,
            Log_Reports log_Reports)
        {
            Expression_Node_FunctionImpl expr_Func = new Expression_Node_FunctionImpl(parent_Expression, cur_Gcav, this.List_NameArgument);
            expr_Func.Owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
            return expr_Func;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ドラッグ＆ドロップ　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Execute4_OnDnD(
            object prm_Sender,
            GiveFeedbackEventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnDnD", log_Reports_Master);
            //
            //


            // イベントハンドラー引数の設定
            this.Set_OnDnD(
                this,
                prm_Sender, prm_E);



            this.Execute5_Main(log_Reports_Master);

            //if (!log_Reports_Master.Successful)
            //{
            //    // 異常時
            //    Info_Functions.WriteErrorLog(
            //        log_Method,//this.GetType().Name, log_Method.SMethodName,
            //        this.MemoryApplication, log_Reports_Master);
            //}

            //
            //
            log_Method.EndMethod(log_Reports_Master);
            log_Reports_Master.EndLogging(log_Method);
        }

        protected void Set_OnDnD(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            GiveFeedbackEventArgs prm_E
            )
        {
            if (null != expr_Func)//暫定
            {
                expr_Func.EnumEventhandler = EnumEventhandler.O_Gfea;
                expr_Func.Functionparameterset.Sender = prm_Sender;
                expr_Func.Functionparameterset.GiveFeedbackEventArgs = prm_E;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 画像ドロップ　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="parentLocation"></param>
        /// <param name="debugMessage1"></param>
        /// <param name="debugStatusResultMessage"></param>
        /// <param name="log_Reports"></param>
        public override void Execute4_OnImgDrop(
            object prm_Sender,
            DragEventArgs prm_E,
            Point prm_ParentLocation,
            string prm_DebugMessage1,
            string prm_DebugStatusResultMessage,
            Log_Reports log_Reports
            )
        {
            //
            //

            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnImgDrop", log_Reports);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnImgDrop(
                this,
                prm_Sender,
                prm_E,
                prm_ParentLocation,
                prm_DebugMessage1,
                prm_DebugStatusResultMessage,
                log_Reports
            );


            this.Execute5_Main(log_Reports);

            //
            //
            log_Method.EndMethod(log_Reports);
        }

        protected void Set_OnImgDrop(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            DragEventArgs prm_E,
            Point prm_ParentLocation,
            string prm_DebugMessage1,
            string prm_DebugStatusResultMessage,
            Log_Reports prm_D_LoggingBuffer
            )
        {
            if (null != expr_Func)//暫定
            {
                expr_Func.EnumEventhandler = EnumEventhandler.O_Dea_P_S_S_Lr;
                expr_Func.Functionparameterset.Sender = prm_Sender;
                expr_Func.Functionparameterset.DragEventArgs = prm_E;
                expr_Func.Functionparameterset.ParentLocation = prm_ParentLocation;
                expr_Func.Functionparameterset.Message_Debug1 = prm_DebugMessage1;
                expr_Func.Functionparameterset.Message_DebugStatusResult = prm_DebugStatusResultMessage;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 画像ドロップ　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="fileName"></param>
        /// <param name="droppedBitmap"></param>
        public override void Execute4_OnImgDropB(
            object prm_Sender,
            DragEventArgs prm_E,
            Point prm_ParentLocation,
            string prm_Fpatha_Image,
            Bitmap prm_DroppedBitmap,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnImgDropB", log_Reports);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnImgDropB(
                this,
                prm_Sender,
                prm_E,
                prm_ParentLocation,
                prm_Fpatha_Image,
                prm_DroppedBitmap,
                log_Reports
            );


            this.Execute5_Main(log_Reports);

            //
            //
            log_Method.EndMethod(log_Reports);
        }

        protected void Set_OnImgDropB(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            DragEventArgs prm_E,
            Point prm_ParentLocation,
            string prm_Fpatha_Image,
            Bitmap prm_DroppedBitmap,
            Log_Reports prm_D_LoggingBuffer
            )
        {
            if (null != expr_Func)//暫定
            {
                expr_Func.EnumEventhandler = EnumEventhandler.O_Dea_P_S_B_Lr;
                expr_Func.Functionparameterset.Sender = prm_Sender;
                expr_Func.Functionparameterset.DragEventArgs = prm_E;
                expr_Func.Functionparameterset.ParentLocation = prm_ParentLocation;
                expr_Func.Functionparameterset.Filepathabsolute_Image = prm_Fpatha_Image;
                expr_Func.Functionparameterset.DroppedBitmap = prm_DroppedBitmap;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// リストボックス用アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Execute4_OnLstBox(
            object prm_Sender,
            object prm_ItemValue,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnLstBox", log_Reports);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnLstBox(
                this,
                prm_Sender,
                prm_ItemValue,
                log_Reports
            );

            string sResult = this.Execute5_Main(log_Reports);
            log_Method.EndMethod(log_Reports);

            return sResult;
        }

        protected string Set_OnLstBox(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            object prm_ItemValue,
            Log_Reports prm_D_LoggingBuffer
            )
        {
            if (null != expr_Func)//暫定
            {
                expr_Func.EnumEventhandler = EnumEventhandler.O_Lr;
                expr_Func.Functionparameterset.Sender = prm_Sender;
                expr_Func.Functionparameterset.ItemValue = prm_ItemValue;
            }

            return "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウス　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Execute4_OnMouse(
            object prm_Sender,
            MouseEventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnMouse", log_Reports_Master);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnMouse(
                this,
                prm_Sender,
                prm_E
            );



            this.Execute5_Main(log_Reports_Master);

            //if (!log_Reports_Master.Successful)
            //{
            //    // 異常時
            //    Info_Functions.WriteErrorLog(
            //        log_Method,//this.GetType().Name, log_Method.SMethodName,
            //        this.MemoryApplication, log_Reports_Master);
            //}

            log_Method.EndMethod(log_Reports_Master);
        }

        protected void Set_OnMouse(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            MouseEventArgs prm_E
            )
        {
            if (null != expr_Func)//暫定
            {
                expr_Func.EnumEventhandler = EnumEventhandler.O_Mea;
                expr_Func.Functionparameterset.Sender = prm_Sender;
                expr_Func.Functionparameterset.MouseEventArgs = prm_E;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Execute4_OnOEa(
            object prm_Sender,
            EventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnOEa", log_Reports_Master);

            // イベントハンドラー引数の設定
            this.Set_OnOEa(
                this,
                prm_Sender,
                prm_E
            );

            this.Execute5_Main(log_Reports_Master);

            //if (!log_Reports_Master.Successful)
            //{
            //    // 異常時
            //    Info_Functions.WriteErrorLog(
            //        log_Method,//this.GetType().Name, log_Method.SMethodName,
            //        this.MemoryApplication, log_Reports_Master);
            //}

            log_Method.EndMethod(log_Reports_Master);
            log_Reports_Master.EndLogging(log_Method);
        }

        protected void Set_OnOEa(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            EventArgs prm_E
            )
        {
            if (null != expr_Func)//暫定
            {
                expr_Func.EnumEventhandler = EnumEventhandler.O_Ea;
                expr_Func.Functionparameterset.Sender = prm_Sender;
                expr_Func.Functionparameterset.EventArgs = prm_E;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// todo:
        /// プロジェクトの読取アクション実行。
        /// </summary>
        /// <param name="selectedProject"></param>
        /// <param name="projectValid">プロジェクトの読み込みに成功していれば真。</param>
        /// <param name="log_Reports"></param>
        public override void Execute4_OnEditorSelected(
            object prm_Sender,
            object prm_St_selectedEditorElm,
            bool prm_ProjectValid,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnEditorSelected", log_Reports);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnEditorSelected(
                this,
                prm_Sender,
                prm_St_selectedEditorElm,
                prm_ProjectValid,
                log_Reports
            );


            this.Execute5_Main(log_Reports);

            log_Method.EndMethod(log_Reports);
        }

        protected void Set_OnEditorSelected(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            object prm_St_selectedEditorElm,//St_ProjectElm
            bool prm_ProjectValid,
            Log_Reports prm_D_LoggingBuffer
            )
        {
            expr_Func.EnumEventhandler = EnumEventhandler.Editor_B_Lr;
            expr_Func.Functionparameterset.Sender = prm_Sender;
            expr_Func.Functionparameterset.SelectedProjectElement_Configurationtree = prm_St_selectedEditorElm;
            expr_Func.Functionparameterset.IsProjectValid = prm_ProjectValid;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ドラッグ＆ドロップ用アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Execute4_OnQueryContinueDragEventArgs(
            object prm_Sender,
            QueryContinueDragEventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnQueryContinueDragEventArgs", log_Reports_Master);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnQueryContinueDragEventArgs(
                this,
                prm_Sender,
                prm_E
            );


            this.Execute5_Main(log_Reports_Master);

            //if (!log_Reports_Master.Successful)
            //{
            //    // 異常時
            //    Info_Functions.WriteErrorLog(
            //        log_Method,//this.GetType().Name, sMethodNameWithSharp,
            //        this.MemoryApplication, log_Reports_Master);
            //}

            log_Method.EndMethod(log_Reports_Master);
        }

        protected void Set_OnQueryContinueDragEventArgs(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            QueryContinueDragEventArgs prm_E
            )
        {
            if (null != expr_Func)//暫定
            {
                expr_Func.EnumEventhandler = EnumEventhandler.O_Qcdea;
                expr_Func.Functionparameterset.Sender = prm_Sender;
                expr_Func.Functionparameterset.QueryContinueDragEventArgs = prm_E;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// todo:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor"></param>
        /// <param name="log_Reports"></param>
        public override void Execute4_OnLr(
            object prm_Sender,
            object prm_EventMonitor,//EventMonitor
            string prm_SNode_EventOrigin,
            Log_Reports log_Reports
        )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnLr", log_Reports);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnWrRhn(
                this,
                prm_Sender,
                prm_EventMonitor,//EventMonitor
                prm_SNode_EventOrigin,
                log_Reports
            );


            this.Execute5_Main(log_Reports);

            log_Method.EndMethod(log_Reports);
        }

        protected void Set_OnWrRhn(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            object prm_EventMonitor,//EventMonitor
            string prm_SNode_EventOrigin,
            Log_Reports prm_D_LoggingBuffer
        )
        {
            expr_Func.EnumEventhandler = EnumEventhandler.O_Lr;
            expr_Func.Functionparameterset.Sender = prm_Sender;
            expr_Func.Functionparameterset.EventMonitor = prm_EventMonitor;
            expr_Func.Functionparameterset.Node_EventOrigin = prm_SNode_EventOrigin;
        }

        //────────────────────────────────────────

        /// <summary>
        /// キー　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Execute4_OnKey(
            object prm_Sender,
            KeyEventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute4_OnKey", log_Reports_Master);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnKey(
                this,
                prm_Sender,
                prm_E
            );


            this.Execute5_Main(log_Reports_Master);

            //if (!log_Reports_Master.Successful)
            //{
            //    // エラー
            //    Info_Functions.WriteErrorLog(
            //        log_Method,//this.GetType().Name, sMethodNameWithSharp,
            //        this.MemoryApplication, log_Reports_Master);
            //}

            log_Method.EndMethod(log_Reports_Master);
        }

        protected void Set_OnKey(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            KeyEventArgs prm_E
            )
        {
            if (null != expr_Func)//暫定
            {
                expr_Func.EnumEventhandler = EnumEventhandler.O_Kea;
                expr_Func.Functionparameterset.Sender = prm_Sender;
                expr_Func.Functionparameterset.KeyEventArgs = prm_E;
            }
        }

        //────────────────────────────────────────

        protected virtual string E_Execute_NoUse(
            Expression_Node_Function ec_CommonFunction,
            string sLibraryName,
            string sClassName,
            string sMethodName,
            EnumEventhandler enumEH,
            Configurationtree_Node cf_Node,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "E_Execute_NoUse",log_Reports);
            //
            //

            string sResult = "";

            //#このルートはエラー
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, log_Method.Fullname, log_Reports);//問題の起こったメソッド
                tmpl.SetParameter(2, enumEH.ToString(), log_Reports);//イベントハンドラー

                string sFncName0;
                ec_CommonFunction.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                tmpl.SetParameter(3, sFncName0, log_Reports);//関数名
                tmpl.SetParameter(4, Log_RecordReportsImpl.ToText_Configurationtree(cf_Node), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6039;", tmpl, log_Reports);
            }

            //            ((E_SysFncAbstract)this.E_SystemAction).EventMonitor.BNowActionWorking = false;

            //
            //
            log_Method.EndMethod(log_Reports);
            return sResult;
        }

        //────────────────────────────────────────
        #endregion



        //#region アクション
        ////────────────────────────────────────────

        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual string Execute5_Main(Log_Reports log_Reports)
        //{
        //    Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
        //    log_Method.SetPath(Info_Functions.Name_Library, this, "Execute5_Main");
        //    log_Method.BeginMethod(log_Reports);
        //    //
        //    //

        //    string sResult;

        //    sResult = this.Function.Execute5_Main(log_Reports);
        //    // エラー

        //    //
        //    //
        //    //
        //    //

        //    //EnumEventhandler.O_GFEA
        //    //NActionAbstract#Perform_DnD
        //    // ドラッグ＆ドロップ　アクション実行。

        //    //EnumEventhandler.O_DEA_P_S_S_WR
        //    //NActionAbstract#Perform_ImgDrop
        //    // 画像ドロップ　アクション実行。

        //    //EnumEventhandler.O_DEA_P_S_B_WR
        //    // 画像ドロップ　アクション実行。
        //    //NActionAbstract#Perform_ImgDropB

        //    //this.E_SystemAction.EnumEventhandler == EnumEventhandler.O_Lr
        //    // リストボックス用アクション実行。
        //    //NActionAbstract#Perform_LstBox

        //    //this.E_SystemAction.EnumEventhandler == EnumEventhandler.O_KEA
        //    // キー　アクション実行。
        //    //NActionAbstract#Perform_Key

        //    //EnumEventhandler.O_MEA
        //    // マウス　アクション実行。
        //    //NActionAbstract#Perform_Mouse

        //    //EnumEventhandler.O_Ea
        //    // アクション実行。
        //    //NActionAbstract#Perform_OEa

        //    // EnumEventhandler.TP_B_WR_RHN
        //    // プロジェクトの読取アクション実行。
        //    // #Perform_PrjSelected

        //    // EnumEventhandler.O_QCDEA
        //    // ドラッグ＆ドロップ用アクション実行。
        //    //NActionAbstract#Perform_QueryContinueDragEventArgs

        //    //EnumEventhandler.O_Lr
        //    // エラー
        //    //NActionAbstract#Perform_WrRhn


        //    //
        //    //
        //    //
        //    //

        //    log_Method.EndMethod(log_Reports);
        //    return sResult;
        //}

        ////────────────────────────────────────────
        //#endregion


        #region プロパティー
        //────────────────────────────────────────

        private List<string> list_NameArgument;

        public List<string> List_NameArgument
        {
            get
            {
                return this.list_NameArgument;
            }
            set
            {
                this.list_NameArgument = value;
            }
        }

        ////────────────────────────────────────────

        private Dictionary_Expression_Node_String dictionary_Expression_Parameter;

        /// <summary>
        /// Expression_Node_Stringを関数として使うときの『ユーザー定義引数』のディクショナリー。
        /// TODO:使ってる？
        /// </summary>
        public Dictionary_Expression_Node_String Dictionary_Expression_Parameter
        {
            get
            {
                return this.dictionary_Expression_Parameter;
            }
            set
            {
                // 関数の引数を丸ごと渡す時に使う。
                this.dictionary_Expression_Parameter = value;
            }
        }

        //────────────────────────────────────────

        private EnumEventhandler enumEventhandler;

        /// <summary>
        /// 呼び出されたイベントハンドラーの種類。
        /// </summary>
        public EnumEventhandler EnumEventhandler
        {
            get
            {
                return enumEventhandler;
            }
            set
            {
                enumEventhandler = value;
            }
        }

        //────────────────────────────────────────

        private Functionparameterset functionparameterset;

        public Functionparameterset Functionparameterset
        {
            get
            {
                return this.functionparameterset;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
