using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Xenon.NumPut
{
    public interface MemoryNum
    {



        #region アクション
        //────────────────────────────────────────

        void RefreshData(float scale2, UsercontrolCanvas ucCanvas);

        string GetText(Memory3Contents moContents, bool bHiddenComment);

        /// <summary>
        /// 「b+1000」といった形を数値に変換します。
        /// </summary>
        /// <param name="moNumputImpl"></param>
        /// <returns></returns>
        string SValueExecute();

        void ParseValueExecute(Memory3ContentsImpl moNumputImpl);

        bool Contains(Point mouse, UsercontrolCanvas ucCanvas);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 番号スプライトのフォント。
        /// </summary>
        Font NumSpFont
        {
            get;
            set;
        }

        /// <summary>
        /// 前景の色。
        /// </summary>
        Pen PenFg
        {
            get;
            set;
        }

        /// <summary>
        /// 背面の色。
        /// </summary>
        Brush BrushBg
        {
            get;
            set;
        }

        /// <summary>
        /// レイヤー
        /// </summary>
        int NLayer
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 背景画像上（on the background image）でのスプライトの点XY。等倍。
        /// </summary>
        PointF LocationOnBgActual
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウスに指されていれば真。
        /// </summary>
        bool BMouseTarget
        {
            get;
            set;
        }

        /// <summary>
        /// 拡大縮小されている背景画像上での円の位置・サイズ。
        /// </summary>
        Rectangle BoundsCircleScaledOnBackground
        {
            get;
        }

        /// <summary>
        /// 次の描画時にデータを更新します。
        /// </summary>
        bool BDirty
        {
            get;
            set;
        }

        /// <summary>
        /// 拡大縮小されている背景画像上でのテキストの位置・サイズ。
        /// </summary>
        Rectangle BoundsTextScaledOnBackground
        {
            get;
        }

        /// <summary>
        /// 記述されている文字列。
        /// </summary>
        string SText
        {
            get;
            set;
        }

        /// <summary>
        /// 「a=1000」といった文字列が入っている場合、「a」。
        /// 該当しなければ空文字列。
        /// </summary>
        string SName
        {
            get;
        }

        /// <summary>
        /// 「a=1000:ステータス画面」といった文字列が入っている場合、「1000」。
        /// 「b+0:名前」といった文字列が入っている場合、「b+0」。
        /// 該当しなければ空文字列。
        /// </summary>
        string SValue
        {
            get;
        }

        /// <summary>
        /// 「a=1000:ステータス画面」といった文字列が入っている場合、「ステータス画面」。
        /// 「b+0:名前」といった文字列が入っている場合、「名前」。
        /// 該当しなければ空文字列。
        /// </summary>
        string SComment
        {
            get;
        }

        /// <summary>
        /// 「a=1000」といった文字列が入っている場合、真。
        /// </summary>
        bool BNameDefine
        {
            get;
        }

        float Scale
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
