using System;
using System.Collections.Generic;
using System.Drawing;//Bitmap,Point
using System.Linq;
using System.Text;
using System.Windows.Forms;//Graphics

using Xenon.Syntax;

namespace Xenon.Sprites
{

    /// <summary>
    /// マウスの操作対象が変更されたとき。
    /// </summary>
    /// <returns></returns>
    public delegate void DLGT_OnMouseTargettingChanged(Sprite sprite, Point parentLocation);

    /// <summary>
    /// スプライトの選択が変更されたとき。
    /// </summary>
    /// <returns></returns>
    public delegate void DLGT_OnSpriteSelectionChanged(Sprite sprite, Point parentLocation);

    /// <summary>
    /// (Model Of Sprites Dictionary)
    /// </summary>
    public interface MemorySpriteDictionary
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// 登録されているスプライトと、それに関連する内部データを全てクリアーします。
        /// </summary>
        void Clear();

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 最初のデフォルト設定にします。
        /// 
        /// ゴミデータを除去するには、クリアーも併用してください。
        /// </summary>
        void PutDefault();

        /// <summary>
        /// 画像の選択のキャンセルを解除。
        /// </summary>
        void CancelSelectToggleAll();

        /// <summary>
        /// 選択中のスプライトを全て取得。
        /// </summary>
        Dictionary<int, Sprite> SelectedSprites();

        /// <summary>
        /// ドラッグ中のスプライトを全て取得。
        /// </summary>
        Dictionary<int, Sprite> DraggingSprites();

        /// <summary>
        /// マウスターゲットになっているスプライトを全て取得。
        /// </summary>
        Dictionary<int, Sprite> TargetSprites();

        /// <summary>
        /// 指定のスプライトを、名前で削除します。
        /// 
        /// 同名のスプライトがないという前提です。
        /// </summary>
        void Remove(int nSpriteIndex);

        /// <summary>
        /// 指定のスプライトを、名前で削除します。
        /// 
        /// 同名のスプライトがないという前提です。
        /// </summary>
        void RemoveAll(Dictionary<int, Sprite>.KeyCollection spriteNameList);

        /// <summary>
        /// 1つでもドラッグ中のスプライトがあれば真です。
        /// </summary>
        /// <returns></returns>
        bool IsDraggingAnything();

        /// <summary>
        /// 選択されている画像の位置を動かします。
        /// </summary>
        void OffsetLocationOfSelectedSprite(
            int nTranslateX,
            int nTranslateY,
            bool bSelectedOfDraggingImage
            );

        /// <summary>
        /// スプライトの上に、マウスカーソルが重なっているか判定します。
        /// </summary>
        void CheckMouseOveredAll(
            Point mouseLocation,
            Point parentLocation
            );

        /// <summary>
        /// マウスに重なっている画像の選択／非選択を切り替える可能性が発生します。マウス・ムーブを挟むと、切り替えの意思を解除。
        /// </summary>
        void CheckSelectToggledAll(Point mouseLocation, Point parentLocation);

        /// <summary>
        /// スプライトを追加します。
        /// 
        /// 事前に CanAddSprite を使って、スプライトを追加できることを確認してから使用してください。
        /// </summary>
        void AddSprite(
            Sprite sprite,
            Log_Reports pg_Logging
            );

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// デフォルト・デリゲート
        /// </summary>
        void OnMouseTargettingChanged(Sprite sprite, Point parentLocation);

        /// <summary>
        /// デフォルト・デリゲート
        /// </summary>
        void OnSpriteSelectionChanged(Sprite sprite, Point parentLocation);

        /// <summary>
        /// デフォルト・デリゲートの処理を実行します。
        /// </summary>
        void Dlgt_OnSpriteSelectionChangedPerform(Sprite sprite, Point parentLocation);

        /// <summary>
        /// 描画を行います。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="parentLocation"></param>
        /// <param name="pg_Logging"></param>
        void Paint(
            Graphics g,
            Point parentLocation,
            Log_Reports pg_Logging
            );

        Sprite CreateSprite(
            int nSpriteIndex,
            string sFpath_Image,
            int nInitX,
            int nInitY,
            string sConfigStack_OfSprite
            );

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// スプライトを、コレクションに追加可能かどうか。
        /// </summary>
        /// <returns></returns>
        bool CanAddSprite(
            Sprite sprite,
            Log_Reports pg_Logging
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// マウスの操作対象が変更されたとき。
        /// </summary>
        DLGT_OnMouseTargettingChanged Dlgt_OnMouseTargettingChanged
        {
            set;
        }

        /// <summary>
        /// スプライトの選択が変更されたとき。
        /// </summary>
        DLGT_OnSpriteSelectionChanged Dlgt_OnSpriteSelectionChanged
        {
            set;
        }

        Dictionary<int, Sprite> Dictionary_Sprite
        {
            get;
            set;
        }

        List<KeyValuePair<int, Sprite>> List_SpriteZOrder
        {
            get;
            set;
        }

        int NCount
        {
            get;
        }

        /// <summary>
        /// 警告のために表示される赤枠を描くペン。赤色で太い。
        /// 
        /// 画像が読み込まれていなかったり、配置位置が不妥当だった場合など。
        /// </summary>
        Pen BorderPen4OnInvalid
        {
            get;
            set;
        }

        /// <summary>
        /// 赤色の枠や×印を描くためのペン。桃色で細い。
        /// 
        /// 画像が読み込まれていなかったり、配置位置が不妥当だった場合など警告用。
        /// </summary>
        Pen BorderPen2OnInvalid
        {
            get;
            set;
        }

        Pen BorderPen2OnOver
        {
            get;
            set;
        }

        /// <summary>
        /// 警告文字用ブラシ。
        /// </summary>
        Brush BorderBrushOnInvalid
        {
            get;
            set;
        }

        Pen BorderPen4OnOver
        {
            get;
            set;
        }

        Brush BorderBrushOnSelected
        {
            get;
            set;
        }

        Pen BorderPen4OnSelected
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion


        
    }
}
