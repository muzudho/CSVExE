using System;
using System.Collections.Generic;
using System.Drawing;//Bitmap,Point
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Syntax;

///
/// ドラッグ＆ドロップ・ライブラリー
///
namespace Xenon.Operating
{

    /// <summary>
    /// テキストが入ったリストボックス（Txtlstと略号）から、画像を取り出す（ドラッグ＆ドロップ）機能をまとめたクラス
    /// </summary>
    public class DragsTextlistboxToImgImpl
    {



        #region 用意
        //────────────────────────────────────────

        public delegate string DLGT_SourceListbox_GetFilepathFromItem(object itemValue, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public DragsTextlistboxToImgImpl()
        {
            this.MouseDownLocation = Point.Empty;

            this.CursorDraggingMove = Cursor.Current;
            this.CursorDraggingCopy = Cursor.Current;
            this.CursorDraggingLink = Cursor.Current;
            this.CursorDraggingNone = Cursor.Current;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// マウス・カーソルのアイコン画像を変更します。
        /// 
        /// 記述する箇所は、例えばリストボックスのlistBox1_GiveFeedbackです。
        /// </summary>
        /// <param name="e"></param>
        public void OnSourceListbox_GiveFeedback(
            object sender,
            GiveFeedbackEventArgs e,
            Log_Reports log_Reports
            )
        {
            // 既定のカーソルを使わないようにします。
            e.UseDefaultCursors = false;

            // ドロップの効果に合わせて、カーソルを指定します。
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // 移動
                Cursor.Current = this.CursorDraggingMove;
            }
            else if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                // コピー
                Cursor.Current = this.CursorDraggingCopy;
            }
            else if ((e.Effect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // ショートカット
                Cursor.Current = this.CursorDraggingLink;
            }
            else
            {
                // 禁止
                Cursor.Current = this.CursorDraggingNone;
            }
        }

        //────────────────────────────────────────        

        /// <summary>
        /// ドラッグ＆ドロップ中に発生します。
        /// ドラッグをキャンセルするのに使います。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSourceListbox_QueryContinueDrag(
            object sender,
            QueryContinueDragEventArgs e,
            Log_Reports log_Reports
            )
        {
            // ドラッグ中にマウスの右ボタンが押されていれば、ドラッグをキャンセルします。

            // "2"は、マウスの右ボタンを表します。何故か定数はないようです。
            if ((e.KeyState & 2) == 2)
            {
                e.Action = DragAction.Cancel;
            }
        }

        //────────────────────────────────────────        

        /// <summary>
        /// リストボックスの上で、マウス・ボタンが押下されたとき。
        /// 
        /// マウス・カーソルの座標位置を記憶します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSourceListbox_MouseDown(
            object sender,
            MouseEventArgs e,
            Log_Reports log_Reports
            )
        {
            // マウスの左ボタンが押下されている時、ドラッグを実行中にします。

            // マウスの左ボタンが押されている時。
            if (e.Button == MouseButtons.Left)
            {
                // このリストボックス
                ListBox listbox = (ListBox)sender;
                // ドラッグするアイテムのインデックスを取得します。
                int itemIndex = listbox.IndexFromPoint(e.X, e.Y);
                if (0 <= itemIndex)
                {
                    // 選択時。
                    this.mouseDownLocation = new Point(e.X, e.Y);

                    // ここでは　ドラッグ＆ドロップしません。
                }
                else
                {
                    // 未選択時。
                    return;
                }
            }
            // マウスの左ボタン以外が押されたとき。
            else
            {
                this.mouseDownLocation = Point.Empty;
            }
        }

        //────────────────────────────────────────        

        /// <summary>
        /// リストボックスの上で、マウス・ボタンが放されたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSourceListbox_MouseUp(
            object sender,
            MouseEventArgs e,
            Log_Reports log_Reports
            )
        {
            this.MouseDownLocation = Point.Empty;
        }

        //────────────────────────────────────────        

        /// <summary>
        /// リストボックスの上で、マウス・カーソルが移動したとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSourceListbox_MouseMove(
            object sender,
            MouseEventArgs e,
            Log_Reports log_Reports
            )
        {
            // マウス・カーソルの座標位置が記憶されている場合。
            if (this.mouseDownLocation != Point.Empty)
            {
                // ドラッグと判定しないマウス・カーソルの移動範囲を取得する
                Rectangle noDragBounds = new Rectangle(
                    this.mouseDownLocation.X - SystemInformation.DragSize.Width / 2,
                    this.mouseDownLocation.Y - SystemInformation.DragSize.Height / 2,
                    SystemInformation.DragSize.Width,
                    SystemInformation.DragSize.Height);

                // ドラッグと判定しない移動範囲を超えたかどうか判定します。
                if (!noDragBounds.Contains(e.X, e.Y))
                {
                    // このリスト・ボックス
                    ListBox listbox = (ListBox)sender;

                    // 選択しているアイテムを取得します。
                    ListBox.SelectedObjectCollection selectedItems = listbox.SelectedItems;

                    // 選択されているアイテムが無ければ中断します。
                    if (selectedItems.Count < 1)
                    {
                        return;
                    }

                    // ファイル・パスの配列を作ります。
                    string[] filePaths = new string[selectedItems.Count];
                    // インデックスの配列を作ります。項目削除時に使います。
                    int[] itemIndeces = new int[selectedItems.Count];

                    int nArrayIndex = 0;
                    for (int nIndex = 0; nIndex < selectedItems.Count; nIndex++)
                    {
                        // リストボックスの項目の型が何かは分かりません。
                        object itemObject = selectedItems[nIndex];

                        string sFpath = this.Dlgt_SourceListbox_GetFilepathFromItem(itemObject, log_Reports);

                        filePaths[nArrayIndex] = sFpath;
                        itemIndeces[nArrayIndex] = nIndex;
                        nArrayIndex++;
                    }

                    // ファイル・パスの配列を、ドラッグ＆ドロップで運ばれるデータとします。

                    // DataObjectの第一引数を DataFormats.FileDrop とし、
                    // 第二引数には パスの配列を指定します。
                    IDataObject dataObject = new DataObject(DataFormats.FileDrop, filePaths);

                    // ドラッグ＆ドロップの実行中になります。
                    DragDropEffects effects =
                        listbox.DoDragDrop(dataObject,
                            DragDropEffects.All | DragDropEffects.Link);

                    // ドロップしたときの効果がMoveになる場合は、もとのアイテムを削除します。
                    if (effects == DragDropEffects.Move)
                    {
                        foreach (int itemIndex in itemIndeces)
                        {
                            listbox.Items.RemoveAt(itemIndex);
                        }
                    }

                    this.mouseDownLocation = Point.Empty;
                }
            }

        }

        //────────────────────────────────────────        
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Cursor cursorDraggingMove;

        /// <summary>
        /// ドラッグ時のカーソルの画像。移動時。
        /// </summary>
        public Cursor CursorDraggingMove
        {
            get
            {
                return cursorDraggingMove;
            }
            set
            {
                cursorDraggingMove = value;
            }
        }

        //────────────────────────────────────────

        private Cursor cursorDraggingCopy;

        /// <summary>
        /// ドラッグ時のカーソルの画像。コピー時。
        /// </summary>
        public Cursor CursorDraggingCopy
        {
            get
            {
                return cursorDraggingCopy;
            }
            set
            {
                cursorDraggingCopy = value;
            }
        }

        //────────────────────────────────────────

        private Cursor cursorDraggingLink;

        /// <summary>
        /// ドラッグ時のカーソルの画像。ショートカット作成時。
        /// </summary>
        public Cursor CursorDraggingLink
        {
            get
            {
                return cursorDraggingLink;
            }
            set
            {
                cursorDraggingLink = value;
            }
        }

        //────────────────────────────────────────

        private Cursor cursorDraggingNone;

        /// <summary>
        /// ドラッグ時のカーソルの画像。禁止時。
        /// </summary>
        public Cursor CursorDraggingNone
        {
            get
            {
                return cursorDraggingNone;
            }
            set
            {
                cursorDraggingNone = value;
            }
        }

        //────────────────────────────────────────

        private Point mouseDownLocation;

        /// <summary>
        /// マウス・ボタンが押された時の座標位置
        /// </summary>
        public Point MouseDownLocation
        {
            get
            {
                return mouseDownLocation;
            }
            set
            {
                mouseDownLocation = value;
            }
        }

        //────────────────────────────────────────

        private DragsTextlistboxToImgImpl.DLGT_SourceListbox_GetFilepathFromItem dlgt_SourceListbox_GetFilepathFromItem;

        /// <summary>
        /// リストボックスの項目を解析し、ファイル名にして返します。
        /// 
        /// ドラッグ元のリストボックスの設定。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public DragsTextlistboxToImgImpl.DLGT_SourceListbox_GetFilepathFromItem Dlgt_SourceListbox_GetFilepathFromItem
        {
            get
            {
                return dlgt_SourceListbox_GetFilepathFromItem;
            }
            set
            {
                dlgt_SourceListbox_GetFilepathFromItem = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
