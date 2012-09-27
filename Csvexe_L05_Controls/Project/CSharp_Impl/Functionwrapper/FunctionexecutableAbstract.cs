﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Controls
{
    public abstract class FunctionexecutableAbstract : Expression_Node_StringImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public FunctionexecutableAbstract(Expression_Node_String parent_Expression, Givechapterandverse_Node cur_Gcav)
            : base(parent_Expression,cur_Gcav)
        {
        }

        //────────────────────────────────────────

        public void InitializeBeforeUse(object/*MemoryApplication*/ owner_MemoryApplication)
        {
            this.owner_MemoryApplication = (MemoryApplication)owner_MemoryApplication;
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
        public abstract void Execute_OnDnD(
            object prm_Sender,
            GiveFeedbackEventArgs prm_E
            );

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
        /// 
        public abstract void Execute_OnImgDrop(
            object prm_Sender,
            DragEventArgs prm_E,
            Point prm_ParentLocation,
            string prm_DebugMessage1,
            string prm_DebugStatusResultMessage,
            Log_Reports prm_D_LoggingBuffer
            );

        //────────────────────────────────────────

        /// <summary>
        /// 画像ドロップ　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="fileName"></param>
        /// <param name="droppedBitmap"></param>
        public abstract void Execute_OnImgDropB(
            object prm_Sender,
            DragEventArgs prm_E,
            Point prm_ParentLocation,
            string prm_Fpatha_Image,
            Bitmap prm_DroppedBitmap,
            Log_Reports prm_D_LoggingBuffer
            );

        //────────────────────────────────────────

        /// <summary>
        /// リストボックス用アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract string Execute_OnLstBox(
            object prm_Sender,
            object prm_ItemValue,
            Log_Reports prm_D_LoggingBuffer
            );

        //────────────────────────────────────────

        /// <summary>
        /// マウス　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void Execute_OnMouse(
            object prm_Sender,
            MouseEventArgs prm_E
            );

        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void Execute_OnOEa(
            object prm_Sender,
            EventArgs prm_E
            );

        //────────────────────────────────────────

        /// <summary>
        /// todo:
        /// プロジェクトの読取アクション実行。
        /// </summary>
        /// <param name="selectedProject"></param>
        /// <param name="projectValid">プロジェクトの読み込みに成功していれば真。</param>
        /// <param name="log_Reports"></param>
        public abstract void Execute_OnEditorSelected(
            object prm_Sender,
            object prm_St_selectedEditorElm,//St_ProjectElm
            bool prm_EditorValid,
            Log_Reports prm_D_LoggingBuffer
            );

        //────────────────────────────────────────

        /// <summary>
        /// ドラッグ＆ドロップ用アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void Execute_OnQueryContinueDragEventArgs(
            object prm_Sender,
            QueryContinueDragEventArgs prm_E
            );

        //────────────────────────────────────────

        /// <summary>
        /// todo:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventMonitor"></param>
        /// <param name="log_Reports"></param>
        public abstract void Execute_OnWrRhn(
            object prm_Sender,
            object prm_EventMonitor,//EventMonitor
            string prm_SNode_EventOrigin,
            Log_Reports prm_D_LoggingBuffer
        );

        //────────────────────────────────────────

        /// <summary>
        /// キー　アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void Execute_OnKey(
            object prm_Sender,
            KeyEventArgs prm_E
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return this.owner_MemoryApplication;
            }
            set
            {
                this.owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}