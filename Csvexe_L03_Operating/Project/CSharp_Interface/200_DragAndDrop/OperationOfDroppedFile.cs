using System;
using System.Collections.Generic;
using System.Drawing;//Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//DragEventArgs

using Xenon.Syntax;

namespace Xenon.Operating
{


    /// <summary>
    /// これは、ファイルのドロップです。
    /// </summary>
    public interface OperationOfDroppedFile
    {



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// データが、ターゲットコントロールの上にドロップされたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="log_Reports"></param>
        void OnDragDrop(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            );

        /// <summary>
        /// データが、ターゲットコントロールの上にエンターされたとき。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="log_Reports"></param>
        void OnDragEnter(
            object sender,
            DragEventArgs e,
            Point parentLocation,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



    }
}
