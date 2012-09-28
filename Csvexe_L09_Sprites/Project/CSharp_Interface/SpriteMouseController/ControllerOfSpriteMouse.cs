using System;
using System.Collections.Generic;
using System.Drawing;//Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics,MouseEventArgs

using Xenon.GridPanel;//GridArea……マウスの移動に影響を与える。

namespace Xenon.Sprites
{
    public interface ControllerOfSpriteMouse
    {



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// マウスに重なっている画像をドラッグできる状態にします。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="o_OLt">原点</param>
        /// <param name="moSpDic"></param>
        void OnMouseDowned(
            MouseEventArgs e,
            Point o_OLt,
            MemorySpriteDictionary moSpDic
            );

        /// <summary>
        /// マウスムーブ
        /// </summary>
        /// <param name="e"></param>
        /// <param name="o_OLt">原点</param>
        /// <param name="moSpDic"></param>
        void OnMouseMoved(MouseEventArgs e, Point o_OLt, MemorySpriteDictionary moSpDic);

        /// <summary>
        /// マウスアップ
        /// </summary>
        /// <param name="e"></param>
        /// <param name="o_OLt">原点</param>
        /// <param name="moSpDic"></param>
        void OnMouseUpped(MouseEventArgs e, Point o_OLt, MemorySpriteDictionary moSpDic);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// マウスカーソルの座標です。
        /// </summary>
        Point MouseLocation
        {
            get;
        }

        /// <summary>
        /// グリッド吸着を考慮した後の、マウスカーソルが指している座標(Left Top location)です。
        /// (Lt)
        /// </summary>
        Point MouseLefttopOnGrid
        {
            get;
        }

        /// <summary>
        /// スプライトの上でマウスボタンを押下したときの、そのスプライト画像(Image)内でのマウスカーソルの位置(Left Top location)。
        /// (Lt)
        /// </summary>
        Point GrabbedLefttopInImg
        {
            get;
        }

        /// <summary>
        /// グリッド吸着を有効にするなら真です。
        /// 
        /// ■グリップ・スナップを有効にするには、
        /// スプライト・マウス・コントローラーに、グリッド領域の登録もしておいてください。
        /// </summary>
        bool BGridSnapped
        {
            get;
            set;
        }

        /// <summary>
        /// このシステムに影響を及ぼすグリッド領域です。
        /// </summary>
        Dictionary<string, Grid> Dictionary_Grid
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
