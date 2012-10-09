using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.FrameMemo
{
    /// <summary>
    /// (View Of Frame)
    /// </summary>
    public interface ViewFrame
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 計算結果の列数。未指定またはエラーなら 0。
        /// </summary>
        void OnColumnCountResultChanged(float nValue);

        /// <summary>
        /// 計算結果の行数。未指定またはエラーなら 0。
        /// </summary>
        void OnRowCountResultChanged(float nValue);

        /// <summary>
        /// 計算結果のセルの横幅。等倍。
        /// </summary>
        void OnCellWidthResultChanged(float nValue);

        /// <summary>
        /// 計算結果のセルの縦幅。等倍。
        /// </summary>
        void OnCellHeightResultChanged(float nValue);

        /// <summary>
        /// 指定した[切り抜くフレーム／１～]
        /// </summary>
        void OnCropForceChanged(int nValue);

        /// <summary>
        /// 計算結果の[切り抜くフレーム終値／１～]
        /// </summary>
        void OnCropLastResultChanged(int nValue);

        void Refresh();

        //────────────────────────────────────────
        #endregion



    }

}
