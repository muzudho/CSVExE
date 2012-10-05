using System;
using System.Collections.Generic;
using System.Diagnostics;//Stopwatch
using System.Drawing;//SystemColors,Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//GiveFeedbackEventArgs

using Xenon.Syntax;//Log_TextIndented
using Xenon.Middle;//FormObjectProperties,CustomLabel

namespace Xenon.Controls
{
    /// <summary>
    /// 実行可能な＜event＞要素。フォームに登録されるもの。
    /// 
    /// 「コントロール設定ファイル」に記述されているイベント（アクションのリスト）を実行します。
    /// 正確には、OCnf_Control オブジェクトを読み取って、アクションを作成し、実行していきます。
    /// 
    /// 「フォーム」用？
    /// </summary>
    public class Functionlist_FormImpl : FunctionexecutableAbstract, Functionlist
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。これは使わない。
        /// </summary>
        /// <param nFcName="nActionPerformEnum"></param>
        /// <param nFcName="oWrittenPlace"></param>
        public Functionlist_FormImpl()
            : base( null/*parent_Expression*/, null/*cur_Conf*/)
        {
            throw new Exception(Info_Controls.Name_Library + ":" + this.GetType().Name + "#<init>:このコンストラクターは使わないでください。");
        }

        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param nFcName="nActionPerformEnum"></param>
        /// <param nFcName="oWrittenPlace"></param>
        public Functionlist_FormImpl(
            ConfigurationtreeToExpression_Event sToE_Event,
            MemoryApplication owner_MemoryApplication
            )
            : base(null/*parent_Expression*/, null/*cur_Conf*/)
        {
            this.ConfigurationtreeToExpression_Event = sToE_Event;

            this.list_Item = new List<Expression_Node_Function>();
            this.sType = "!ハードコーディング_" + this.GetType().Name + "#<init>";
        }

        //────────────────────────────────────────

        /// <summary>
        /// このオブジェクトのインスタンスを作成したときに、セットしてください。
        /// </summary>
        public virtual void InitializeBeforeUse()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ドラッグ＆ドロップ　アクション実行。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        public override void Execute4_OnDnD(
            object sender,
            GiveFeedbackEventArgs e
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute4_OnDnD", log_Reports_ThisMethod);

            //
            //
            //
            //
            Customcontrol cct = null;

            //
            // コントロール名。
            //
            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);

                log_Reports_ThisMethod.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールでドラッグ＆ドロップされました。";

                // ステータスバーに、コントロール名を表示。
                //cct.ControlCommon.MoControlMediator.AddStatus_ActionFcName(sName_Usercontrol, d_Logging_Dammy);
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports_ThisMethod.Comment_EventCreationMe = "ドラッグ＆ドロップされました。";
            }

            //
            // ストップウォッチ。
            //
            if (log_Reports_ThisMethod.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    this.ConfigurationtreeToExpression_Event.Name
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            // 登録アクション作成・実行ループ。
            //

            // 未作成時「作成」
            if (!this.ConfigurationtreeToExpression_Event.IsTranslated_ConfigurationtreeToExpression)
            {
                this.ConfigurationtreeToExpression_Event.Translate(cct.ControlCommon.Owner_MemoryApplication, log_Reports_ThisMethod);

            }

            // 実行。
            //EnumEventhandler err_Eh;
            if (log_Reports_ThisMethod.Successful)
            {
                foreach (Expression_Node_Function expr_Func in this.List_Item)
                {
                    expr_Func.Execute4_OnDnD(sender, e);
                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(pg_Method);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 画像ドロップ　アクション実行。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        /// <param nFcName="parentLocation"></param>
        /// <param nFcName="debugMessage1"></param>
        /// <param nFcName="debugStatusResultMessage"></param>
        /// <param nFcName="log_Reports"></param>
        public override void Execute4_OnImgDrop(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            string debugMessage1,
            string debugStatusResultMessage,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute4_OnImgDrop", log_Reports);

            //
            //

            Customcontrol cct = null;

            //
            // コントロール名。
            //
            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                log_Reports.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールで画像がドロップされました。";

                // ステータスバーに、コントロール名を表示。
                //cct.ControlCommon.MoControlMediator.AddStatus_ActionFcName(sName_Usercontrol, log_Reports);
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports.Comment_EventCreationMe = "画像がドロップされました。";
            }

            //
            // ストップウォッチ。
            //
            if (log_Reports.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    this.ConfigurationtreeToExpression_Event.Name
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            // 登録アクション作成・実行ループ。
            //

            // 未作成時「作成」
            if (!this.ConfigurationtreeToExpression_Event.IsTranslated_ConfigurationtreeToExpression)
            {
                this.ConfigurationtreeToExpression_Event.Translate(cct.ControlCommon.Owner_MemoryApplication, log_Reports);
            }

            //EnumEventhandler err_Eh;
            if (log_Reports.Successful)
            {
                foreach (Expression_Node_Function expr_Func in this.List_Item)
                {
                    expr_Func.Execute4_OnImgDrop(
                        sender,
                        e,
                        parentLocation,
                        debugMessage1,
                        debugStatusResultMessage,
                        log_Reports
                        );
                }
            }



            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 画像ドロップ　アクション実行。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        /// <param nFcName="fileName"></param>
        /// <param nFcName="droppedBitmap"></param>
        public override void Execute4_OnImgDropB(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            string sFpatha_Image,
            Bitmap droppedBitmap,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute4_OnImgDropB", log_Reports);

            //
            //

            Customcontrol cct = null;

            //
            // コントロール名。
            //
            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                log_Reports.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールで画像がドロップされました。";

                // ステータスバーに、コントロール名を表示。
                //cct.ControlCommon.MoControlMediator.AddStatus_ActionFcName(sName_Usercontrol, log_Reports);
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports.Comment_EventCreationMe = "画像がドロップされました。";
            }

            //
            // ストップウォッチ。
            //
            if (log_Reports.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    this.ConfigurationtreeToExpression_Event.Name
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            // 「登録アクション設定」を元に、「アクション」を作成し、実行順に実行。
            //
            if (!this.ConfigurationtreeToExpression_Event.IsTranslated_ConfigurationtreeToExpression)
            {
                this.ConfigurationtreeToExpression_Event.Translate(cct.ControlCommon.Owner_MemoryApplication, log_Reports);
            }

            //EnumEventhandler err_Eh;
            if (log_Reports.Successful)
            {
                foreach (Expression_Node_Function expr_Func in this.List_Item)
                {
                    expr_Func.Execute4_OnImgDropB(
                        sender,
                        e,
                        parentLocation,
                        sFpatha_Image,
                        droppedBitmap,
                        log_Reports
                        );
                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// リストボックス用アクション実行。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        public override string Execute4_OnLstBox(
            object sender,
            object itemValue,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute4_OnLstBox", log_Reports);

            //
            //

            Customcontrol cct = null;

            //
            // コントロール名。
            //
            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                log_Reports.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールでリストボックス用アクションが実行されました。";

                // ステータスバーに、コントロール名を表示。
                //cct.ControlCommon.MoControlMediator.AddStatus_ActionFcName(sName_Usercontrol, log_Reports);
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports.Comment_EventCreationMe = "リストボックス用アクションが実行されました。";
            }

            //
            // ストップウォッチ。
            //
            if (log_Reports.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    this.ConfigurationtreeToExpression_Event.Name
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            // 登録アクション作成・実行ループ。
            //

            //
            // 最後のアクションの返却値が残ります。
            //
            string sReturnValue = "";

            //
            // 「登録アクション設定」を元に、「アクション」を作成し、実行順に実行。
            //
            if (!this.ConfigurationtreeToExpression_Event.IsTranslated_ConfigurationtreeToExpression)
            {
                this.ConfigurationtreeToExpression_Event.Translate(cct.ControlCommon.Owner_MemoryApplication, log_Reports);

            }

            //EnumEventhandler err_Eh;
            if (log_Reports.Successful)
            {
                foreach (Expression_Node_Function expr_Func in this.List_Item)
                {
                    sReturnValue = expr_Func.Execute4_OnLstBox(sender, itemValue, log_Reports);
                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
            return sReturnValue;
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウス　アクション実行。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        public override void Execute4_OnMouse(
            object sender, MouseEventArgs e
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute4_OnMouse", log_Reports_ThisMethod);
            //
            //

            Customcontrol cct = null;

            //
            // コントロール名。
            //
            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);

                log_Reports_ThisMethod.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールでマウス_アクションが実行されました。";

                // ステータスバーに、コントロール名を表示。
                //cct.ControlCommon.MoControlMediator.AddStatus_ActionFcName(sName_Usercontrol, d_Logging_Dammy);
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports_ThisMethod.Comment_EventCreationMe = "マウス_アクションが実行されました。";
            }

            //
            // ストップウォッチ。
            //
            if (log_Reports_ThisMethod.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    this.ConfigurationtreeToExpression_Event.Name
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            // 「登録アクション設定」を元に、「アクション」を作成し、実行順に実行。
            //
            if (!this.ConfigurationtreeToExpression_Event.IsTranslated_ConfigurationtreeToExpression)
            {
                this.ConfigurationtreeToExpression_Event.Translate(cct.ControlCommon.Owner_MemoryApplication, log_Reports_ThisMethod);
            }

            //EnumEventhandler err_Eh;
            if (log_Reports_ThisMethod.Successful)
            {
                foreach (Expression_Node_Function expr_Func in this.List_Item)
                {
                    //
                    // 登録アクション作成・実行ループ。
                    //
                    expr_Func.Execute4_OnMouse(sender, e);
                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(pg_Method);
        }

        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// 
        /// 引数が object と EventArgs の場合。
        /// 
        /// ListBox の「項目選択時」は、これではなく、
        /// NEventPerformer_ListboxImpl#Perform_OEa
        /// を使ってください。
        /// 
        /// 数値ボックスの "Se:値変更時;" は、ここにくる。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        public override void Execute4_OnOEa(
            object sender, EventArgs e
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute4_OnOEa", log_Reports_ThisMethod);
            //
            //

            Customcontrol cct = null;

            //
            // コントロール名。
            //
            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);

                log_Reports_ThisMethod.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールでOEaアクションが実行されました。";

                // ステータスバーに、コントロール名を表示。
                //cct.ControlCommon.MoControlMediator.AddStatus_ActionFcName(sName_Usercontrol, d_Logging_Dammy);
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports_ThisMethod.Comment_EventCreationMe = "OEaアクションが実行されました。";
            }

            //
            // ストップウォッチ
            //
            if (log_Reports_ThisMethod.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    this.ConfigurationtreeToExpression_Event.Name
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            //
            //
            //
            //ystem.Console.WriteLine(Info_Forms.LibraryName + ":" + this.GetType().Name + "#Perform_OEa: 何回呼び出される？(A)");


            //
            // 登録アクション作成・実行ループ。
            //

            //
            // 「登録アクション設定」を元に、「アクション」を作成し、実行順に実行。
            //
            if (!this.ConfigurationtreeToExpression_Event.IsTranslated_ConfigurationtreeToExpression)
            {
                // まだアクションが作成されていなければ、作成。
                this.ConfigurationtreeToExpression_Event.Translate(cct.ControlCommon.Owner_MemoryApplication, log_Reports_ThisMethod);
            }

            //EnumEventhandler err_Eh;
            if (log_Reports_ThisMethod.Successful)
            {
                // 登録されているアクションを実行。
                foreach (Expression_Node_Function expr_Func in this.List_Item)
                {
                    expr_Func.Execute4_OnOEa(sender, e);
                }
            }


            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(pg_Method);
        }

        //────────────────────────────────────────

        /// <summary>
        /// todo:
        /// プロジェクトの読取アクション実行。
        /// </summary>
        /// <param nFcName="selectedProject"></param>
        /// <param nFcName="projectValid">プロジェクトの読み込みに成功していれば真。</param>
        /// <param nFcName="log_Reports"></param>
        public override void Execute4_OnEditorSelected(
            object sender,
            object st_SelectedEditorElm,
            bool projectValid,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute4_OnEditorSelected", log_Reports);

            //
            //

            Customcontrol cct = null;

            //
            // コントロール名。
            //
            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                log_Reports.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールでプロジェクト選択アクションが実行されました。";

                // ステータスバーに、コントロール名を表示。
                //cct.ControlCommon.MoControlMediator.AddStatus_ActionFcName(sName_Usercontrol, log_Reports);
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports.Comment_EventCreationMe = "プロジェクト選択アクションが実行されました。";
            }

            //
            // ストップウォッチ。
            //
            if (log_Reports.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    this.ConfigurationtreeToExpression_Event.Name
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            // 「登録アクション設定」を元に、「アクション」を作成し、実行順に実行。
            //
            if (!this.ConfigurationtreeToExpression_Event.IsTranslated_ConfigurationtreeToExpression)
            {
                this.ConfigurationtreeToExpression_Event.Translate(cct.ControlCommon.Owner_MemoryApplication, log_Reports);
            }

            //EnumEventhandler err_Eh;
            if (log_Reports.Successful)
            {
                foreach (Expression_Node_Function expr_Func in this.List_Item)
                {
                    //
                    // 登録アクション作成・実行ループ。
                    //
                    expr_Func.Execute4_OnEditorSelected(
                        sender,
                        st_SelectedEditorElm,
                        projectValid,
                        log_Reports
                        );
                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// ドラッグ＆ドロップ用アクション実行。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        public override void Execute4_OnQueryContinueDragEventArgs(
            object sender,
            QueryContinueDragEventArgs e
            )
        {
            this.Execute4_OnQueryContinueDragEventArgs(
                sender,
                e
            );

            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute4_OnQueryContinueDragEventArgs", log_Reports_ThisMethod);
            //
            //
            Customcontrol cct = null;

            //
            // コントロール名。
            //
            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports_ThisMethod);

                log_Reports_ThisMethod.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールでQueryContinueDragEventArgsアクションが実行されました。";

                // ステータスバーに、コントロール名を表示。
                //cct.ControlCommon.MoControlMediator.AddStatus_ActionFcName(sName_Usercontrol, d_Logging_Dammy);
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports_ThisMethod.Comment_EventCreationMe = "QueryContinueDragEventArgsアクションが実行されました。";
            }

            //
            // ストップウォッチ。
            //
            if (log_Reports_ThisMethod.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    this.ConfigurationtreeToExpression_Event.Name
                    );
                pg_Method.Log_Stopwatch.Begin();
            }


            //
            // 「登録アクション設定」を元に、「アクション」を作成し、実行順に実行。
            //
            if (!this.ConfigurationtreeToExpression_Event.IsTranslated_ConfigurationtreeToExpression)
            {
                this.ConfigurationtreeToExpression_Event.Translate(cct.ControlCommon.Owner_MemoryApplication, log_Reports_ThisMethod);
            }

            //EnumEventhandler err_Eh;
            if (log_Reports_ThisMethod.Successful)
            {
                foreach (Expression_Node_Function expr_Func in this.List_Item)
                {
                    //
                    // 登録アクション作成・実行ループ。
                    //
                    expr_Func.Execute4_OnQueryContinueDragEventArgs(sender, e);
                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(pg_Method);

        }

        //────────────────────────────────────────

        /// <summary>
        /// todo:
        /// </summary>
        /// <param nFcName="log_Reports"></param>
        public override void Execute4_OnLr(
            object sender,
            object eventMonitor,//EventMonitor
            string sWrittenPlace_EventOrigin,
            Log_Reports log_Reports
        )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Execute4_OnLr", log_Reports);
            //
            //

            Customcontrol cct = null;

            //
            // コントロール名。
            //
            string sName_Usercontrol;
            if (sender is Customcontrol)
            {
                cct = (Customcontrol)sender;

                sName_Usercontrol = cct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                log_Reports.Comment_EventCreationMe = "[" + sName_Usercontrol + "]コントロールでWrRhnアクションが実行されました。";

                // ステータスバーに、コントロール名を表示。
                //cct.ControlCommon.MoControlMediator.AddStatus_ActionFcName(sName_Usercontrol, log_Reports);
            }
            else
            {
                sName_Usercontrol = "";
                log_Reports.Comment_EventCreationMe = "WrRhnアクションが実行されました。";
            }

            //
            // ストップウォッチ。
            //
            if (log_Reports.CanStopwatch)
            {
                pg_Method.Log_Stopwatch.Message = Utility_Format.Format(
                    sName_Usercontrol,
                    this.ConfigurationtreeToExpression_Event.Name
                    );
                pg_Method.Log_Stopwatch.Begin();
            }

            //
            // 「登録アクション設定」を元に、「アクション」を作成し、実行順に実行。
            //
            if (!this.ConfigurationtreeToExpression_Event.IsTranslated_ConfigurationtreeToExpression)
            {
                this.ConfigurationtreeToExpression_Event.Translate(cct.ControlCommon.Owner_MemoryApplication, log_Reports);
            }

            //EnumEventhandler err_Eh;
            if (log_Reports.Successful)
            {
                foreach (Expression_Node_Function expr_Func in this.List_Item)
                {
                    //
                    // 登録アクション作成・実行ループ。
                    //
                    expr_Func.Execute4_OnLr(
                        sender,
                        eventMonitor,
                        sWrittenPlace_EventOrigin,
                        log_Reports
                        );
                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
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
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary_Expression_Node_String dictionary_Expression_Parameter;

        /// <summary>
        /// Expression_Node_Stringを関数として使うときの『ユーザー定義引数』のディクショナリー。
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

        protected string sType;

        /// <summary>
        /// このアクションの型の名前。派生クラスからセットが使われる。
        /// </summary>
        public string SType
        {
            get
            {
                return sType;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// このアクションの一覧が記述されている、対応するイベント。
        /// </summary>
        private ConfigurationtreeToExpression_Event ConfigurationtreeToExpression_Event;

        //────────────────────────────────────────

        private List<Expression_Node_Function> list_Item;

        /// <summary>
        /// todo:どういうふうに使う？
        /// </summary>
        public List<Expression_Node_Function> List_Item
        {
            get
            {
                return this.list_Item;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
