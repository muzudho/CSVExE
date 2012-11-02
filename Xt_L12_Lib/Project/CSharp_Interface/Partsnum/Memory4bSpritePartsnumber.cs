using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Xenon.Lib
{



    #region 用意
    //────────────────────────────────────────

    /// <summary>
    /// 部品番号スプライトが変化したとき。
    /// </summary>
    /// <param name="scale2"></param>
    /// <param name="ucCanvas"></param>
    public delegate void DELEGATE_OnChangeSprite_Partsnumber(Memory4bSpritePartsnumber mNum, float scale2);

    //────────────────────────────────────────
    #endregion



    /// <summary>
    /// 部品番号スプライトです。
    /// </summary>
    public interface Memory4bSpritePartsnumber
    {



        #region アクション
        //────────────────────────────────────────

        string GetText( bool bHiddenComment, Memory1Application_Partsnumput memoryApplication_Partsnumput);

        /// <summary>
        /// 「b+1000」といった形を数値に変換します。
        /// </summary>
        /// <param name="moNumputImpl"></param>
        /// <returns></returns>
        string Execute_CalculateExpression();

        void Parse_CalculateExpression(Memory1Application_Partsnumput memoryApplication_Partsnumput);

        bool Contains(Point mouse, Memory1Application_Partsnumput memoryApplication_Partsnumput);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        DELEGATE_OnChangeSprite_Partsnumber Delegate_OnChangeSprite_Partsnumber
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 番号スプライトのフォント。
        /// </summary>
        Font Font
        {
            get;
            set;
        }

        /// <summary>
        /// 前景の色。
        /// </summary>
        Pen PenForeground
        {
            get;
            set;
        }

        /// <summary>
        /// 背面の色。
        /// </summary>
        Brush BrushBackground
        {
            get;
            set;
        }

        /// <summary>
        /// レイヤー
        /// </summary>
        int Number_Layer
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 背景画像上（on the background image）でのスプライトの点XY。等倍。
        /// </summary>
        PointF LocationOnBackgroundActual
        {
            get;
            set;
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウスに指されていれば真。
        /// </summary>
        bool IsMouseTarget
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
            set;
        }

        /// <summary>
        /// 次の描画時にデータを更新します。
        /// </summary>
        bool IsDirty
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
            set;
        }

        /// <summary>
        /// 記述されている文字列。
        /// </summary>
        string Text
        {
            get;
            set;
        }

        /// <summary>
        /// 「a=1000」といった文字列が入っている場合、「a」。
        /// 該当しなければ空文字列。
        /// </summary>
        string Name_Symbol
        {
            get;
        }

        /// <summary>
        /// 「a=1000:ステータス画面」といった文字列が入っている場合、「1000」。
        /// 「b+0:名前」といった文字列が入っている場合、「b+0」。
        /// 該当しなければ空文字列。
        /// </summary>
        string Valuenumber_Symbol
        {
            get;
        }

        /// <summary>
        /// 「a=1000:ステータス画面」といった文字列が入っている場合、「ステータス画面」。
        /// 「b+0:名前」といった文字列が入っている場合、「名前」。
        /// 該当しなければ空文字列。
        /// </summary>
        string Comment
        {
            get;
        }

        /// <summary>
        /// 「a=1000」といった文字列が入っている場合、真。
        /// </summary>
        bool IsDefinitionExpression
        {
            get;
        }

        float Scale
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
