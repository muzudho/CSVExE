using System;
using System.Collections.Generic;
using System.Drawing;//Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//DragEventArgs

using Xenon.Syntax;

///
/// ドラッグ＆ドロップ・ライブラリー
///
namespace Xenon.Operating
{

    /// <summary>
    /// ドラッグしているファイルのドロップを受け付けるテキストボックスの機能
    /// </summary>
    public class OperationOfDroppedFileImpl : OperationOfDroppedFile
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// ターゲットコントロールにアイテムをドロップしたとき。処理開始前。
        /// 
        /// 主に、クリアーや準備を行う機会として利用することを想定しています。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DELEGATE_Clear_OnDropInit(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ターゲットコントロールにアイテムをドロップしたとき。アイテム１つにつき。
        /// 
        /// 主に、ドロップされたアイテムを１つずつ利用することを想定しています。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DELEGATE_Catch_OnItemDropped(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            string sName_File,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ターゲットコントロールにアイテムをドロップしたとき。全ての画像終了時。
        /// 
        /// 主に、デバッグ用のメッセージを出力する機会として利用することを想定しています。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DELEGATE_Report_OnDropFinished(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            string sMessage1_Debug,
            string sMessage_DebugStatusResult,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理開始前。
        /// 
        /// 主に、クリアーや準備を行う機会として利用することを想定しています。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DELEGATE_Clear_OnDragEnterInit(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理終了時。
        /// 
        /// 主に、デバッグ用のメッセージを出力する機会として利用することを想定しています。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DELEGATE_Report_OnDragEnterFinished(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            string sText_DebugFormats,
            string sText_DebugStatusEnters,
            string sText_DebugStatusReceives,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理開始前。
        /// </summary>
        protected OperationOfDroppedFileImpl.DELEGATE_Clear_OnDragEnterInit dlgt_Clear_OnDragEnterInit;

        /// <summary>
        /// ターゲットコントロールに画像をドロップしたとき。処理開始前。
        /// </summary>
        protected OperationOfDroppedFileImpl.DELEGATE_Clear_OnDropInit dlgt_Clear_OnDropInit;

        /// <summary>
        /// ターゲットコントロールに画像をドロップした時のメソッド。
        /// </summary>
        protected OperationOfDroppedFileImpl.DELEGATE_Catch_OnItemDropped dlgt_Catch_OnItemDropped;

        /// <summary>
        /// ターゲットコントロールに画像をドロップしたとき。全ての画像終了時。
        /// </summary>
        protected OperationOfDroppedFileImpl.DELEGATE_Report_OnDropFinished dlgt_Report_OnDropFinished;

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理終了時。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected OperationOfDroppedFileImpl.DELEGATE_Report_OnDragEnterFinished dlgt_Report_OnDragEnterFinished;

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// データが、ターゲットコントロールの上にドロップされたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="log_Reports"></param>
        public void OnDragDrop(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            )
        {
            // 外部の処理を挟み込めます。
            this.dlgt_Clear_OnDropInit(
                sender,
                e,
                parentLocation,
                log_Reports);

            if (log_Reports.Successful)
            {
                // 正常時

                //ドロップされたデータの形式を調べます。

                // ファイルドロップ
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // ファイルであれば。
                    string[] sFileNameArray = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                    StringBuilder sb_DebugMessage = new StringBuilder();
                    sb_DebugMessage.Append("ドロップされたファイル数=[");
                    sb_DebugMessage.Append(sFileNameArray.Length);
                    sb_DebugMessage.Append("]\r\n");

                    foreach (string sFileName in sFileNameArray)
                    {
                        // ファイルであった場合
                        this.dlgt_Catch_OnItemDropped(
                            sender,
                            e,
                            parentLocation,
                            sFileName,
                            log_Reports
                            );

                        sb_DebugMessage.Append(sFileName);
                        sb_DebugMessage.Append("\r\n");
                    }

                    this.dlgt_Report_OnDropFinished(
                        sender,
                        e,
                        parentLocation,
                        sb_DebugMessage.ToString(),
                        "ファイル・パスのようなものがパネルの上に落とされました。",
                        log_Reports
                        );
                }
                else
                {
                    // ファイルと認識できないデータは無視します。

                    this.dlgt_Report_OnDropFinished(
                        sender,
                        e,
                        parentLocation,
                        "",
                        "何かパネルの上に落とされましたが、ファイルとは認識されませんでした。",
                        log_Reports
                        );
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// データが、ターゲットコントロールの上にエンターされたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="log_Reports"></param>
        public void OnDragEnter(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            )
        {

            // 外部の処理を挟み込めます。
            this.dlgt_Clear_OnDragEnterInit(
                sender, e, parentLocation, log_Reports);

            if (log_Reports.Successful)
            {
                // 正常時

                // ドラッグされてきたデータの形式を一覧します。
                StringBuilder sb = new StringBuilder();
                sb.Append("ドラッグされてきたデータの形式の個数=[");
                sb.Append(e.Data.GetFormats().Length);
                sb.Append("]\r\n");
                foreach (string sFormat in e.Data.GetFormats())
                {
                    sb.Append(sFormat);
                    sb.Append("\r\n");
                }
                string sDebugFormats = sb.ToString();


                string sDebugStatusEnters;
                string sDebugStatusReceives;
                // ドラッグされてきたデータの形式を調べます。

                // ファイルドロップ
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    sDebugStatusEnters = "ファイルのようなものがパネルの上にドラッグされてきました。";

                    object droppedObj = e.Data.GetData(DataFormats.FileDrop, false);

                    if (droppedObj is string[])
                    {
                        // ファイル名の配列であれば。

                        // ドロップできるかどうかの見え方。
                        //
                        // ◆Ｃｏｐｙ
                        //
                        e.Effect = DragDropEffects.Copy;
                        sDebugStatusReceives = "コピーの受け入れ態勢をとります。画像として読み取れるファイルがありました。";
                    }
                    else
                    {
                        sDebugStatusReceives = "";
                    }
                }
                else
                {
                    // ファイル・ドロップでなければ。
                    sDebugStatusEnters = "何かパネルの上にドラッグされてきました。";

                    // ドロップできるかどうかの見え方。
                    //
                    // ◆Ｎｏｎｅ
                    //
                    e.Effect = DragDropEffects.None;
                    sDebugStatusReceives = "受け入れない態勢をとります。ファイルとして読み取れません。";
                }

                // 外部の処理を挟み込めます。
                this.dlgt_Report_OnDragEnterFinished(
                    sender,
                    e,
                    parentLocation,
                    sDebugFormats,
                    sDebugStatusEnters,
                    sDebugStatusReceives,
                    log_Reports
                    );
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理開始前。
        /// </summary>
        public OperationOfDroppedFileImpl.DELEGATE_Clear_OnDragEnterInit Dlgt_Clear_OnDragEnterInit
        {
            get
            {
                return dlgt_Clear_OnDragEnterInit;
            }
            set
            {
                dlgt_Clear_OnDragEnterInit = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理終了時。
        /// </summary>
        public OperationOfDroppedFileImpl.DELEGATE_Report_OnDragEnterFinished Dlgt_Report_OnDragEnterFinished
        {
            get
            {
                return dlgt_Report_OnDragEnterFinished;
            }
            set
            {
                dlgt_Report_OnDragEnterFinished = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ターゲットコントロールにアイテムをドロップしたとき。処理開始前。
        /// </summary>
        public OperationOfDroppedFileImpl.DELEGATE_Clear_OnDropInit Dlgt_Clear_OnDropInit
        {
            get
            {
                return dlgt_Clear_OnDropInit;
            }
            set
            {
                dlgt_Clear_OnDropInit = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ターゲットコントロールにアイテムをドロップした時のメソッド。
        /// </summary>
        public OperationOfDroppedFileImpl.DELEGATE_Catch_OnItemDropped Dlgt_Catch_OnItemDropped
        {
            get
            {
                return dlgt_Catch_OnItemDropped;
            }
            set
            {
                dlgt_Catch_OnItemDropped = value;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ターゲットコントロールにアイテムをドロップしたとき。全ての画像終了時。
        /// </summary>
        public OperationOfDroppedFileImpl.DELEGATE_Report_OnDropFinished Dlgt_Report_OnDropFinished
        {
            get
            {
                return dlgt_Report_OnDropFinished;
            }
            set
            {
                dlgt_Report_OnDropFinished = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
