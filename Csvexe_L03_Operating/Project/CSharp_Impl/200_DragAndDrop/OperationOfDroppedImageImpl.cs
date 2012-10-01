using System;
using System.Collections.Generic;
using System.Drawing;//Bitmap
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
    /// ドラッグしている画像のドロップを受け付けるパネルの機能
    /// </summary>
    public class OperationOfDroppedImageImpl
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// ターゲットコントロールに画像をドロップしたとき。処理開始前。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DLGT_Clear_OnDropInit(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ターゲットコントロールに画像をドロップしたとき。画像１つにつき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DLGT_Catch_OnItemDropped(
            object sender,
            DragEventArgs e,
            Point parentLocation, 
            string sName_File,
            Bitmap droppedBitmap,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ターゲットコントロールに画像をドロップしたとき。全ての画像終了時。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DLGT_Report_OnDropFinished(
            object sender,
            DragEventArgs e,
            Point parentLocation, 
            string sMessage1_Debug,
            string sMessage_DebugStatusResult,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理開始前。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DLGT_Clear_OnDragEnterInit(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理終了時。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void DLGT_Report_OnDragEnterFinished(
            object sender,
            DragEventArgs e,
            Point parentLocation, 
            string sText_DebugFormats,
            string sText_DebugStatusEnters,
            string sText_DebugStatusReceives,
            Log_Reports log_Reports
            );

        /// <summary>
        /// ターゲットコントロールに画像をドロップしたとき。処理開始前。
        /// </summary>
        protected OperationOfDroppedImageImpl.DLGT_Clear_OnDropInit dlgt_Clear_OnDropInit;

        /// <summary>
        /// ターゲットコントロールに画像をドロップした時のメソッド。
        /// </summary>
        protected OperationOfDroppedImageImpl.DLGT_Catch_OnItemDropped dlgt_Catch_OnItemDropped;

        /// <summary>
        /// ターゲットコントロールに画像をドロップしたとき。全ての画像終了時。
        /// </summary>
        protected OperationOfDroppedImageImpl.DLGT_Report_OnDropFinished dlgt_Report_OnDropFinished;

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理開始前。
        /// </summary>
        protected OperationOfDroppedImageImpl.DLGT_Clear_OnDragEnterInit dlgt_Clear_OnDragEnterInit;

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理終了時。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected OperationOfDroppedImageImpl.DLGT_Report_OnDragEnterFinished dlgt_Report_OnDragEnterFinished;

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// データが、ターゲットコントロールの上にドロップされたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDragDrop(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            )
        {
            // 外部の処理を挟み込めます。
            if (null!=this.dlgt_Clear_OnDropInit)
            {
                this.dlgt_Clear_OnDropInit(
                    sender,
                    e,
                    parentLocation,
                    log_Reports
                    );
            }

            if (log_Reports.Successful)
            {
                // 正常時

                //ドロップされたデータの形式を調べます。

                // ファイルドロップ
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // ファイルであれば。
                    string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                    StringBuilder sb_DebugMessage = new StringBuilder();
                    sb_DebugMessage.Append("ドロップされたファイル数=[");
                    sb_DebugMessage.Append(fileNames.Length);
                    sb_DebugMessage.Append("]\r\n");

                    foreach (string sFileName in fileNames)
                    {
                        try
                        {
                            Bitmap droppedBitmap = new Bitmap(sFileName);

                            // 画像ファイルであった場合
                            if (null != this.dlgt_Catch_OnItemDropped)
                            {
                                this.dlgt_Catch_OnItemDropped(
                                    sender,
                                    e,
                                    parentLocation,
                                    sFileName,
                                    droppedBitmap,
                                    log_Reports
                                    );
                            }
                        }
                        catch (Exception)
                        {
                            // 画像ではなかった場合。

                            // 無視します。
                        }

                        sb_DebugMessage.Append(sFileName);
                        sb_DebugMessage.Append("\r\n");
                    }

                    if (null != this.dlgt_Report_OnDropFinished)
                    {
                        this.dlgt_Report_OnDropFinished(
                            sender,
                            e,
                            parentLocation,
                            sb_DebugMessage.ToString(),
                            "ファイル・パスのようなものがパネルの上に落とされました。",
                            log_Reports
                            );
                    }
                }
                else
                {
                    if (null != this.dlgt_Report_OnDropFinished)
                    {
                        this.dlgt_Report_OnDropFinished(
                            sender,
                            e,
                            parentLocation,
                            "",
                            "何かパネルの上に落とされましたが、文字列としても画像としても読み取れませんでした。",
                            log_Reports
                            );
                    }
                }
                // 文字列または画像のどちらにも読み取れないデータは無視します。
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// データが、ターゲットコントロールの上にエンターされたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDragEnter(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            )
        {
            // 外部の処理を挟み込めます。
            if (null!=this.dlgt_Clear_OnDragEnterInit)
            {
                this.dlgt_Clear_OnDragEnterInit(
                    sender,
                    e,
                    parentLocation,
                    log_Reports
                    );
            }

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
                string sDebugFormatsText = sb.ToString();
                //essageBox.Show("debugFormatsText=[" + debugFormatsText + "]", "△デバッグ83！");


                string sDebugStatusEntersText;
                string sDebugStatusReceivesTxt;
                // ドラッグされてきたデータの形式を調べます。

                // ファイルドロップ
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    sDebugStatusEntersText = "ファイルのようなものがパネルの上にドラッグされてきました。";

                    object droppedObj = e.Data.GetData(DataFormats.FileDrop, false);

                    if (droppedObj is string[])
                    {
                        // ファイル名であれば。
                        string[] fileNames = (string[])droppedObj;

                        // 画像ファイルが含まれているかどうか。
                        bool bImageContained = false;

                        foreach (string sFileName in fileNames)
                        {
                            // まず、画像ファイルの有無を確認します。
                            if (System.IO.File.Exists(sFileName))
                            {
                                // 存在するファイルへのパスなら

                                try
                                {
                                    // 画像ファイルとして読み込めるか、
                                    // そうでなければ例外を投げます。
                                    // ヌルになることはないかと思います。
                                    Bitmap droppedBitmap = new Bitmap(sFileName);

                                    // 画像ファイルが含まれていた場合。
                                    bImageContained = true;
                                }
                                catch (Exception)
                                {
                                    // 画像ファイルでなければ無視して続行。

                                    // TODO エラーがあったという情報を、なんとか人間オペレーターに与えたい。
                                    //.WriteLine(this.GetType().Name + "#OnTargetPanel_DragEnter: エラー。画像ファイルではなかった。fileName=[" + fileName + "]：" + e1.Message);
                                    //essageBox.Show("ドラッグ・エンター：画像ファイルではなかった。fileName=[" + fileName + "]", "△デバッグ85！");
                                }
                            }
                            else
                            {
                                // 存在しないファイルへのパスなら

                                // TODO エラーがあったという情報を、なんとか人間オペレーターに与えたい。
                                //.WriteLine(this.GetType().Name + "#OnTargetPanel_DragEnter: エラー。存在しないファイルへのパスでした。fileName=[" + fileName + "]：");
                            }

                        }

                        if (bImageContained)
                        {
                            // ドロップした時の効果を Copy として見えるようにします。
                            e.Effect = DragDropEffects.Copy;
                            sDebugStatusReceivesTxt = "コピーの受け入れ態勢をとります。画像として読み取れるファイルがありました。";
                        }
                        else
                        {
                            // ドロップできないように見えるようにします。
                            e.Effect = DragDropEffects.None;
                            sDebugStatusReceivesTxt = "受け入れない態勢をとります。画像として読み取れるファイルがありませんでした。";
                        }
                    }
                    else
                    {
                        sDebugStatusReceivesTxt = "";
                    }
                }
                else
                {
                    sDebugStatusEntersText = "何かパネルの上にドラッグされてきました。";

                    // ファイル・ドロップでなければ、ドロップできないように見えるようにします。
                    e.Effect = DragDropEffects.None;
                    sDebugStatusReceivesTxt = "受け入れない態勢をとります。ファイルとして読み取れません。";
                }

                // 外部の処理を挟み込めます。
                if (null != this.dlgt_Report_OnDragEnterFinished)
                {
                    this.dlgt_Report_OnDragEnterFinished(
                        sender,
                        e,
                        parentLocation,
                        sDebugFormatsText,
                        sDebugStatusEntersText,
                        sDebugStatusReceivesTxt,
                        log_Reports
                        );
                }
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// ターゲットコントロールにマウスカーソルが入ってきたとき。受け取り態勢を整えます。処理開始前。
        /// </summary>
        public OperationOfDroppedImageImpl.DLGT_Clear_OnDragEnterInit Dlgt_Clear_OnDragEnterInit
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
        public OperationOfDroppedImageImpl.DLGT_Report_OnDragEnterFinished Dlgt_Report_OnDragEnterFinished
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
        /// ターゲットコントロールに画像をドロップしたとき。処理開始前。
        /// </summary>
        public OperationOfDroppedImageImpl.DLGT_Clear_OnDropInit Dlgt_Clear_OnDropInit
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
        /// ターゲットコントロールに画像をドロップした時のメソッド。
        /// </summary>
        public OperationOfDroppedImageImpl.DLGT_Catch_OnItemDropped Dlgt_Catch_OnItemDropped
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
        /// ターゲットコントロールに画像をドロップしたとき。全ての画像終了時。
        /// </summary>
        public OperationOfDroppedImageImpl.DLGT_Report_OnDropFinished Dlgt_Report_OnDropFinished
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
