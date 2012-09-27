using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{
    /// <summary>
    /// 呼び出されたイベントハンドラーの種類。
    /// 実行メソッドPerformの引数の形です。
    /// </summary>
    public enum EnumEventhandler
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// 未知です。
        /// </summary>
        Unknown,

        /// <summary>
        /// 画像ドロップ用
        /// 
        /// object, DragEventArgs, Point, string, Bitmap, WarningReports
        /// </summary>
        O_Dea_P_S_B_Wr,

        /// <summary>
        /// 画像ドロップ用
        /// 
        /// object, DragEventArgs, Point, string, string, WarningReports
        /// </summary>
        O_Dea_P_S_S_Wr,

        /// <summary>
        /// よく使うアクション object, EventArgs
        /// </summary>
        O_Ea,

        /// <summary>
        /// ドラッグ＆ドロップ用
        /// 
        /// object, GiveFeedbackEventArgs
        /// </summary>
        O_Gfea,

        /// <summary>
        /// キー操作用
        /// 
        /// object, KeyEventArgs
        /// </summary>
        O_Kea,
        
        /// <summary>
        /// マウス用
        /// 
        /// object, MouseEventArgs
        /// </summary>
        O_Mea,

        /// <summary>
        /// ドラッグ＆ドロップ用
        /// 
        /// object, QueryContinueDragEventArgs
        /// </summary>
        O_Qcdea,

        /// <summary>
        /// リストボックス用
        /// 
        /// object, WarningReports
        /// </summary>
        O_Wr,
        
        /// <summary>
        /// プロジェクト読取用
        /// 
        /// TcProject, bool, WarningReports
        /// </summary>
        Tp_B_Wr_Rhn,

        /// <summary>
        /// WarningReports
        /// </summary>
        Wr_Rhn,

        //────────────────────────────────────────
        #endregion



    }
}
