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
            Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav, List<string> listS_ArgName)
            : base(parent_Expression, cur_Gcav)
        {
            this.dictionary_Expression_Parameter = new DicExpression_Node_StringImpl(cur_Gcav);
            this.expressionfncPrmset = new ExpressionfncPrmsetImpl();

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
            Givechapterandverse_Node cur_Gcav,
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
        public override void Execute_OnDnD(
            object prm_Sender,
            GiveFeedbackEventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnDnD",log_Reports_Master);
            //
            //


            // イベントハンドラー引数の設定
            this.Set_OnDnD(
                this,
                prm_Sender, prm_E);



            this.Expression_ExecuteMain(log_Reports_Master);

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
                expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
                expr_Func.ExpressionfncPrmset.GiveFeedbackEventArgs = prm_E;
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
        public override void Execute_OnImgDrop(
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
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnImgDrop",log_Reports);
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


            this.Expression_ExecuteMain(log_Reports);

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
                expr_Func.EnumEventhandler = EnumEventhandler.O_Dea_P_S_S_Wr;
                expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
                expr_Func.ExpressionfncPrmset.DragEventArgs = prm_E;
                expr_Func.ExpressionfncPrmset.ParentLocation = prm_ParentLocation;
                expr_Func.ExpressionfncPrmset.Message_Debug1 = prm_DebugMessage1;
                expr_Func.ExpressionfncPrmset.Message_DebugStatusResult = prm_DebugStatusResultMessage;
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
        public override void Execute_OnImgDropB(
            object prm_Sender,
            DragEventArgs prm_E,
            Point prm_ParentLocation,
            string prm_Fpatha_Image,
            Bitmap prm_DroppedBitmap,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnImgDropB",log_Reports);
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


            this.Expression_ExecuteMain(log_Reports);

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
                expr_Func.EnumEventhandler = EnumEventhandler.O_Dea_P_S_B_Wr;
                expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
                expr_Func.ExpressionfncPrmset.DragEventArgs = prm_E;
                expr_Func.ExpressionfncPrmset.ParentLocation = prm_ParentLocation;
                expr_Func.ExpressionfncPrmset.Filepathabsolute_Image = prm_Fpatha_Image;
                expr_Func.ExpressionfncPrmset.DroppedBitmap = prm_DroppedBitmap;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// リストボックス用アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Execute_OnLstBox(
            object prm_Sender,
            object prm_ItemValue,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnLstBox",log_Reports);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnLstBox(
                this,
                prm_Sender,
                prm_ItemValue,
                log_Reports
            );

            string sResult = this.Expression_ExecuteMain(log_Reports);
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
                expr_Func.EnumEventhandler = EnumEventhandler.O_Wr;
                expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
                expr_Func.ExpressionfncPrmset.ItemValue = prm_ItemValue;
            }

            return "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウス　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Execute_OnMouse(
            object prm_Sender,
            MouseEventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnMouse",log_Reports_Master);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnMouse(
                this,
                prm_Sender,
                prm_E
            );



            this.Expression_ExecuteMain(log_Reports_Master);

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
                expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
                expr_Func.ExpressionfncPrmset.MouseEventArgs = prm_E;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Execute_OnOEa(
            object prm_Sender,
            EventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnOEa",log_Reports_Master);

            // イベントハンドラー引数の設定
            this.Set_OnOEa(
                this,
                prm_Sender,
                prm_E
            );

            this.Expression_ExecuteMain(log_Reports_Master);

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
                expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
                expr_Func.ExpressionfncPrmset.EventArgs = prm_E;
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
        public override void Execute_OnEditorSelected(
            object prm_Sender,
            object prm_St_selectedEditorElm,
            bool prm_ProjectValid,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnPrjSelected",log_Reports);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnPrjSelected(
                this,
                prm_Sender,
                prm_St_selectedEditorElm,
                prm_ProjectValid,
                log_Reports
            );


            this.Expression_ExecuteMain(log_Reports);

            log_Method.EndMethod(log_Reports);
        }

        protected void Set_OnPrjSelected(
            Expression_Node_Function expr_Func,
            object prm_Sender,
            object prm_St_selectedProjectElm,//St_ProjectElm
            bool prm_ProjectValid,
            Log_Reports prm_D_LoggingBuffer
            )
        {
            expr_Func.EnumEventhandler = EnumEventhandler.Tp_B_Wr_Rhn;
            expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
            expr_Func.ExpressionfncPrmset.SelectedProjectElement_Givechapterandverse = prm_St_selectedProjectElm;
            expr_Func.ExpressionfncPrmset.ProjectValid = prm_ProjectValid;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ドラッグ＆ドロップ用アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Execute_OnQueryContinueDragEventArgs(
            object prm_Sender,
            QueryContinueDragEventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnQueryContinueDragEventArgs",log_Reports_Master);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnQueryContinueDragEventArgs(
                this,
                prm_Sender,
                prm_E
            );


            this.Expression_ExecuteMain(log_Reports_Master);

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
                expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
                expr_Func.ExpressionfncPrmset.QueryContinueDragEventArgs = prm_E;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// todo:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor"></param>
        /// <param name="log_Reports"></param>
        public override void Execute_OnWrRhn(
            object prm_Sender,
            object prm_EventMonitor,//EventMonitor
            string prm_SNode_EventOrigin,
            Log_Reports log_Reports
        )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnWrRhn",log_Reports);
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


            this.Expression_ExecuteMain(log_Reports);

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
            expr_Func.EnumEventhandler = EnumEventhandler.O_Wr;
            expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
            expr_Func.ExpressionfncPrmset.EventMonitor = prm_EventMonitor;
            expr_Func.ExpressionfncPrmset.Node_EventOrigin = prm_SNode_EventOrigin;
        }

        //────────────────────────────────────────

        /// <summary>
        /// キー　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Execute_OnKey(
            object prm_Sender,
            KeyEventArgs prm_E
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            Log_Reports log_Reports_Master = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_OnKey",log_Reports_Master);
            //
            //

            // イベントハンドラー引数の設定
            this.Set_OnKey(
                this,
                prm_Sender,
                prm_E
            );


            this.Expression_ExecuteMain(log_Reports_Master);

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
                expr_Func.ExpressionfncPrmset.Sender = prm_Sender;
                expr_Func.ExpressionfncPrmset.KeyEventArgs = prm_E;
            }
        }

        //────────────────────────────────────────

        protected virtual string E_Execute_NoUse(
            Expression_Node_Function ec_CommonFunction,
            string sLibraryName,
            string sClassName,
            string sMethodName,
            EnumEventhandler enumEH,
            Givechapterandverse_Node cf_Node,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "E_Execute_NoUse",log_Reports);
            //
            //

            string sResult = "";

            //#このルートはエラー
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.CreateDammyReport();
                r.SetTitle("▲プログラミング_ミス599！", log_Method);

                StringBuilder s = new StringBuilder();
                s.Append(sLibraryName);
                s.Append(":");
                s.Append(sClassName);
                s.Append("#");
                s.Append(sMethodName);
                s.Append(":　イベントハンドラーtype=[");
                s.Append(enumEH);
                s.Append("] は使わないでください。");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);


                string sFncName0;
                ec_CommonFunction.TrySelectAttribute(out sFncName0, PmNames.S_NAME.Name_Pm, false, Request_SelectingImpl.Unconstraint, log_Reports);

                s.Append("　関数type=[");
                s.Append(sFncName0);
                s.Append("]");
                s.Append(Environment.NewLine);
                s.Append(Environment.NewLine);

                //
                // 問題箇所ヒント
                s.Append(r.Message_Givechapterandverse(cf_Node));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
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
        //public virtual string Expression_ExecuteMain(Log_Reports log_Reports)
        //{
        //    Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
        //    log_Method.SetPath(Info_Functions.Name_Library, this, "Expression_ExecuteMain");
        //    log_Method.BeginMethod(log_Reports);
        //    //
        //    //

        //    string sResult;

        //    sResult = this.Function.Expression_ExecuteMain(log_Reports);
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

        //    //this.E_SystemAction.EnumEventhandler == EnumEventhandler.O_Wr
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

        //    //EnumEventhandler.O_Wr
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

        private DicExpression_Node_String dictionary_Expression_Parameter;

        /// <summary>
        /// Expression_Node_Stringを関数として使うときの『ユーザー定義引数』のディクショナリー。
        /// TODO:使ってる？
        /// </summary>
        public DicExpression_Node_String Dictionary_Expression_Parameter
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

        private ExpressionfncPrmset expressionfncPrmset;

        public ExpressionfncPrmset ExpressionfncPrmset
        {
            get
            {
                return this.expressionfncPrmset;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
