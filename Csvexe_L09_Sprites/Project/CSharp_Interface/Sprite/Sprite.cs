using System;
using System.Collections.Generic;
using System.Drawing;//Bitmap
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

using Xenon.Syntax;

namespace Xenon.Sprites
{
    /// <summary>
    /// スプライトの配置位置が妥当か不妥当かを判定します。
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="parentLocation"></param>
    /// <param name="sMsg">エラーがあれば原因が設定されます。無ければ無視します。</param>
    /// <returns></returns>
    public delegate bool DLGT_CheckLocationValid(
        Sprite sprite,
        Point parentLocation,
        ref string sMsg
    );

    public interface Sprite
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        /// <param name="modelOfSprDic"></param>
        /// <param name="pg_Logging"></param>
        void Paint(
            Graphics g,
            Point parentLocation,
            MemorySpriteDictionary moSpriteDic,
            Log_Reports pg_Logging
            );

        /// <summary>
        /// 左上隅座標
        /// (Lt)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void SetLefttopLocation(int nX, int nY);

        /// <summary>
        /// 左上隅座標に加算
        /// (LT)
        /// </summary>
        /// <param name="nDx"></param>
        /// <param name="nDy"></param>
        void OffsetLefttopLocation(int nDx, int nDy);

        /// <summary>
        /// サイズ
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void SetSize(int nWidth, int nHeight);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 番号の振りなおしを行うときに、一時的に新しいスプライト・インデックスを入れておくためのものです。
        /// </summary>
        int NIndexForRenumbering
        {
            get;
            set;
        }

        /// <summary>
        /// スプライトを、配列やコレクション・クラスで管理するときに使うための、0から始まる数値です。
        /// </summary>
        int NIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 画像
        /// </summary>
        Bitmap Bmp
        {
            get;
            set;
        }

        /// <summary>
        /// マウスの操作対象が変更されたとき。
        /// </summary>
        DLGT_CheckLocationValid Dlgt_CheckLocationValid
        {
            set;
        }

        /// <summary>
        /// スプライト画像の位置とサイズです。倍角を掛け算した後の値です。
        /// 
        /// スプライトは、画像の左上隅位置(Left top)を、パネル上の座標（ピクセル）を持っています。
        /// (Lt)
        /// </summary>
        Rectangle BoundsLefttopScaled
        {
            get;
        }

        /// <summary>
        /// スプライト画像の位置とサイズです。倍角を掛け算する前の値です。
        /// 
        /// スプライトは、画像の左上隅位置(Left top)を、パネル上の座標（ピクセル）を持っています。
        /// (Lt)
        /// </summary>
        Rectangle BoundsLefttopOriginal
        {
            get;
            set;
        }

        /// <summary>
        /// 表示倍角
        /// </summary>
        float NScale
        {
            get;
            set;
        }

        /// <summary>
        /// サイズ
        /// </summary>
        Size SizeOriginal
        {
            get;
            set;
        }

        /// <summary>
        /// サイズ
        /// </summary>
        Size SizeScaled
        {
            get;
        }

        /// <summary>
        /// マウスカーソルが被さっているか
        /// </summary>
        bool BMouseOvered
        {
            get;
            set;
        }

        /// <summary>
        /// マウスカーソルが指していれば真。常に１つ。
        /// </summary>
        bool BMouseTarget
        {
            get;
            set;
        }

        /// <summary>
        /// ドラッグ中か
        /// </summary>
        bool BDragging
        {
            get;
            set;
        }

        /// <summary>
        /// スプライト画像を選択していれば真です。0～複数件。
        /// </summary>
        bool BSelected
        {
            get;
            set;
        }

        /// <summary>
        /// スプライト画像の選択を切り替えようとすれば真です。
        /// </summary>
        bool BSelectToggled
        {
            get;
            set;
        }

        /// <summary>
        /// Zインデックス
        /// </summary>
        int NZOrder
        {
            get;
            set;
        }

        /// <summary>
        /// デバッグ用情報。このスプライトが作られたソースを人間が修正するために使われます。
        /// </summary>
        string SLogStack
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
