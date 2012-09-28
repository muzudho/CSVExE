using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;//Point
using System.Windows.Forms;//Graphics,MouseEventArgs

using Xenon.GridPanel;//GridArea……マウスの移動に影響を与える。

namespace Xenon.Sprites
{

    /// <summary>
    /// スプライトをマウスで操作するロジック。
    /// </summary>
    public class ControllerOfSpriteMouseImpl : ControllerOfSpriteMouse
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public ControllerOfSpriteMouseImpl()
        {
            this.mouseLocation = new Point();
            this.mouseLefttopOnGrid = new Point();
            this.grabbedLefttopInImg = new Point();
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// マウスに重なっている画像をドラッグできる状態にします。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="modelOfSpriteDic"></param>
        public void OnMouseDowned(
            MouseEventArgs e,
            Point o_OLt,
            MemorySpriteDictionary moSpDic
            )
        {

            // リストの後ろから判定します。
            int nSpriteCount = moSpDic.List_SpriteZOrder.Count;
            for (int nSpriteIndex = nSpriteCount - 1; nSpriteIndex >= 0; nSpriteIndex--)
            {
                Sprite sprite = moSpDic.List_SpriteZOrder[nSpriteIndex].Value;

                if (sprite.BoundsLefttopScaled.Contains(
                    e.Location.X - o_OLt.X,
                    e.Location.Y - o_OLt.Y
                    ))
                {
                    // ドラッグ開始
                    sprite.BDragging = true;// どこでfalseにしてる？

                    // クリックした画像内の座標と、画像の左上隅座標との差を求めます。
                    this.grabbedLefttopInImg = new Point(
                        e.X - sprite.BoundsLefttopScaled.X - o_OLt.X,
                        e.Y - sprite.BoundsLefttopScaled.Y - o_OLt.Y
                        );

                    // 最初の1件を見つけた時点で終了します。
                    break;
                }
            }

            // マウスに重なっている画像の選択／非選択を切り替える可能性が発生します。マウス・ムーブを挟むと、切り替えの意思を解除。
            moSpDic.CheckSelectToggledAll(
                e.Location,
                o_OLt
                );
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウスムーブ
        /// </summary>
        /// <param name="e"></param>
        /// <param name="modelOfSpriteDic"></param>
        public void OnMouseMoved(
            MouseEventArgs e,//コントロールの中でのマウス座標
            Point o_GridViewLt,//基本、(0,0)？
            MemorySpriteDictionary moSpDic
            )
        {

            // マウスカーソルの座標を取得します。
            this.mouseLocation.X = e.X; //スクリーン上での位置。
            this.mouseLocation.Y = e.Y;

            //
            // マウスをドラッグしても、スナップ吸着していると スプライトが移動しないこともあります。
            // スプライトが移動したら、真です。
            //
            //bool moved = false;

            Point zure = Point.Empty;//ずれ。

            if (this.BGridSnapped)
            {
                // グリッド・スナップが有効です。

                // 全てのグリッド領域について、当たり判定を調査。
                // TODO 先に有効なものがあれば、それを優先します。





                //マウスカーソルの位置は、スプライト画像の適当な場所を掴んでいる。

                int nSpWidth = 0;
                int nSpHeight = 0;

                // ドラッグ中になっているスプライトの内、マウスターゲットを１つ取得。
                foreach (Sprite draggingSp in moSpDic.DraggingSprites().Values)
                {
                    if (draggingSp.BMouseTarget)
                    {
                        nSpWidth = draggingSp.Bmp.Width;
                        nSpHeight = draggingSp.Bmp.Height;
                        break;
                    }
                }


                // 掴んでいるスプライトの左上隅の座標は、
                // 現在のマウス位置から、「スプライトの中の掴んでいる座標」を引いたものになります。
                Point spLt = new Point();// スプライトの左上座標
                spLt.X = this.mouseLocation.X - this.GrabbedLefttopInImg.X;
                spLt.Y = this.mouseLocation.Y - this.GrabbedLefttopInImg.Y;

                Point spCt = new Point();// スプライトの中心座標
                spCt.X = spLt.X + (int)((double)nSpWidth / 2.0d);
                spCt.Y = spLt.Y + (int)((double)nSpHeight / 2.0d);


                // 「スプライトの中心」の近くにある、グリッドの十字の交差点を取得
                Point nearCt = Point.Empty;
                foreach (Grid grid in this.Dictionary_Grid.Values)
                {
                    //
                    // グリッドビュー全体が、同じグリッド線上の形に収まるなら正しく動きます。
                    //

                    //if (grid.Contains(spCt))//中心座標で、陣形の中にいるかを判定。
                    //{
                    nearCt = grid.NearCrosspoint(spCt);
                    //}
                }

                if (Point.Empty == nearCt)
                {
                    // 近くに、吸着するような　交差点がなければ。
                    nearCt = new Point(spCt.X, spCt.Y);
                }

                // 左上座標に変換。
                Point nearLt = new Point(
                    nearCt.X - (int)((double)nSpWidth / 2.0d),
                    nearCt.Y - (int)((double)nSpHeight / 2.0d)
                    );

                // マウスで掴んでいるズレを足す？
                this.mouseLefttopOnGrid.X = nearLt.X + this.grabbedLefttopInImg.X;
                this.mouseLefttopOnGrid.Y = nearLt.Y + this.grabbedLefttopInImg.Y;

                //
                //　指している位置が、「グリッド交差点とスプライト左上隅点とのズレ」分、ずれます。
                //

                //
                // ズレを求めます。
                //
                zure.X = this.MouseLefttopOnGrid.X - this.MouseLocation.X;
                zure.Y = this.MouseLefttopOnGrid.Y - this.MouseLocation.Y;
            }
            else
            {
                // グリッド・スナップが無効です。
                //moved = true;

                this.mouseLefttopOnGrid.X = this.MouseLocation.X;// e.X;
                this.mouseLefttopOnGrid.Y = this.MouseLocation.Y;// e.Y;
            }

            // 画像の選択のキャンセルを解除。
            moSpDic.CancelSelectToggleAll();

            // 画像をドラッグしているか否かで処理を分けます。
            if (moSpDic.IsDraggingAnything())
            {

                // 現在、画像をドラッグしています。
                this.OnSpriteDragging(o_GridViewLt, moSpDic, zure);
            }
            else
            {
                // 現在、画像をドラッグしていません。

                // スプライトの上に、マウスカーソルが重なっているか判定します。
                moSpDic.CheckMouseOveredAll(e.Location, o_GridViewLt);
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// スプライト ドラッグ中
        /// </summary>
        private void OnSpriteDragging(
            Point o_OLt,
            MemorySpriteDictionary moSpDic,
            Point zure
            )
        {


            //.Console.WriteLine(this.GetType().Name + "#OnSpriteDragging: pointedLocation=(" + this.pointedLocation.X + ", " + this.pointedLocation.Y + ")　ずれ（"+zure.X+", "+zure.Y+"）");
            //　　スプライト左上座標=(" + spriteLeftTopLocation.X + ", " + spriteLeftTopLocation.Y + ")


            // マウス ターゲットがどれほど移動するか、移動距離を算出します。
            // スプライトの移動量は、「ずらしたスプライト」で計算します。
            // （※マウスで今抑えているスプライトと、それ以外の選択スプライトでは計算方法が変わります。）
            int nDx = 0;
            int nDy = 0;
            // 選択されている画像がドラッグされているのなら、他の選択されている画像も一緒に動きます。
            // 選択されていない画像がドラッグされているのなら、他の画像は動きません。
            bool bSelectedOfDraggingImage = false;
            {
                foreach (Sprite sprite in moSpDic.Dictionary_Sprite.Values)
                {
                    if (sprite.BDragging)
                    {
                        if (sprite.BMouseTarget)
                        {
                            // ドラッグしており、かつマウス ターゲットになっているスプライトがあれば（１つだけ存在する？）

                            //
                            // グリッドのクロスポイントからはズレていることがある。
                            int nXInAreaZure = this.mouseLefttopOnGrid.X - o_OLt.X;
                            int nYInAreaZure = this.mouseLefttopOnGrid.Y - o_OLt.Y;

                            //
                            // X
                            //

                            // 画像の左上隅の位置を動かすので、マウスカーソルの位置から、画像内座標を引いて、左上隅の座標を算出します。
                            nDx = nXInAreaZure - this.grabbedLefttopInImg.X - sprite.BoundsLefttopScaled.X;

                            // マウスカーソルにぴったりと　くっついてくる計算式。
                            //                            nDx = nXInArea - this.grabbedLocationInImage.X - sprite.BoundsLtScaled.X - zure.X;

                            // マウスカーソルに、左上隅が　ぴったりと　くっついてくる計算式。
                            //                            nDx = nXInArea - sprite.BoundsLtScaled.X - zure.X;

                            //.Console.WriteLine(this.GetType().Name + "#OnSpriteDragging: translateX[" + translateX + "]　＝　xInArea[" + xInArea + "]　－　this.grabbedLocationInImage.X[" + this.grabbedLocationInImage.X + "]　－　sprite.BoundsLtScaled.X[" + sprite.BoundsLtScaled.X + "]");

                            //
                            // Y
                            //

                            nDy = nYInAreaZure - this.grabbedLefttopInImg.Y - sprite.BoundsLefttopScaled.Y; // -8 ほどずれてる。

                            // マウスカーソルにぴったりと　くっついてくる計算式。
                            //                            nDy = nYInArea - this.grabbedLocationInImage.Y - sprite.BoundsLtScaled.Y - zure.Y;

                            // マウスカーソルに、左上隅が　ぴったりと　くっついてくる計算式。
                            //nDy = nYInArea - sprite.BoundsLtScaled.Y - zure.Y;

                            //.Console.WriteLine(this.GetType().Name + "#OnSpriteDragging: translateY[" + translateY + "]　＝　yInArea[" + yInArea + "]　－　this.grabbedLocationInImage.Y[" + this.grabbedLocationInImage.Y + "]　－　sprite.BoundsLtScaled.Y[" + sprite.BoundsLtScaled.Y + "]");
                        }

                        if (sprite.BSelected)
                        {
                            // ドラッグしており、かつ選択しているスプライトがあれば
                            bSelectedOfDraggingImage = true;
                        }
                    }
                }
            }


            foreach (Sprite sprite in moSpDic.Dictionary_Sprite.Values)
            {
                // ドラッグ中か、ドラッグ中の画像として選択されていて、選択中のスプライトなら。
                // その画像の位置を動かします。
                if (sprite.BDragging || (bSelectedOfDraggingImage && sprite.BSelected))
                {
                    // 移動前、移動後の移動量チェック
                    //int nPreX = sprite.BoundsLtOriginal.X;
                    //int nPreY = sprite.BoundsLtOriginal.Y;
                    //.Console.WriteLine(this.GetType().Name + "#OffsetLocationOfSelectedSprite: ▲ドラッグで移動　スプライト インデックス＝[" + sprite.Index + "]　移動量＝[" + translateX + ", " + translateY + "]　スプライト左上[" + sprite.BoundsLtOriginal.X + ", " + sprite.BoundsLtOriginal.Y + "]　ドラッグしてないときに動いてないか？");
                    //sprite.Dragging[" + sprite.Dragging + "]
                    //selectedOfDraggingImage[" + selectedOfDraggingImage + "]
                    //sprite.Selected[" + sprite.Selected + "]
                    //

                    // 画像の左上隅の位置を動かすので、マウスカーソルの位置から、画像内座標を引いて、左上隅の座標を算出します。
                    //
                    // TODO スナップに吸着しているとき動かなくしたい。
                    sprite.OffsetLefttopLocation(
                        nDx,
                        nDy
                        );

                    //int nMovedX = sprite.BoundsLtOriginal.X - nPreX;
                    //int nMovedY = sprite.BoundsLtOriginal.Y - nPreY;
                    //.Console.WriteLine(this.GetType().Name + "#OffsetLocationOfSelectedSprite: △ドラッグで移動後　スプライト インデックス＝[" + sprite.Index + "]　移動した量[" + movedX + ", " + movedY + "]");
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウスアップ
        /// </summary>
        /// <param name="e"></param>
        /// <param name="modelOfSpriteDic"></param>
        public void OnMouseUpped(
            MouseEventArgs e,
            Point parentLocation,
            MemorySpriteDictionary spriteDictionaryModel
            )
        {

            // ドラッグしている画像を離します。
            foreach (Sprite sprite in spriteDictionaryModel.Dictionary_Sprite.Values)
            {
                sprite.BDragging = false;
            }


            // 選択解除の要求が利いていれば、画像選択を切り替えます。
            foreach (Sprite sprite in spriteDictionaryModel.Dictionary_Sprite.Values)
            {
                if (sprite.BSelectToggled)
                {
                    sprite.BSelected = !sprite.BSelected;

                    //
                    // ■スプライトの選択状態変化
                    //
                    spriteDictionaryModel.Dlgt_OnSpriteSelectionChangedPerform(
                        sprite,
                        parentLocation
                        );
                }
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Point mouseLocation;

        /// <summary>
        /// マウスカーソルの座標(Location)です。
        /// </summary>
        public Point MouseLocation
        {
            get
            {
                return mouseLocation;
            }
        }

        //────────────────────────────────────────

        private Point mouseLefttopOnGrid;

        /// <summary>
        /// グリッド吸着を考慮した後の、マウスカーソルが指している座標(Location)です。
        /// </summary>
        public Point MouseLefttopOnGrid
        {
            get
            {
                return mouseLefttopOnGrid;
            }
        }

        //────────────────────────────────────────

        private Point grabbedLefttopInImg;

        /// <summary>
        /// スプライトの上でマウスボタンを押下したときの、そのスプライト画像(Image)内でのマウスカーソルの位置(Location)。
        /// </summary>
        public Point GrabbedLefttopInImg
        {
            get
            {
                return grabbedLefttopInImg;
            }
        }

        //────────────────────────────────────────

        private bool bGridSnapped;

        /// <summary>
        /// グリッド吸着を有効にするなら真です。
        /// 
        /// ■グリップ・スナップを有効にするには、
        /// スプライト・マウス・コントローラーに、グリッド領域の登録もしておいてください。
        /// </summary>
        public bool BGridSnapped
        {
            get
            {
                return bGridSnapped;
            }
            set
            {
                bGridSnapped = value;
            }
        }

        //────────────────────────────────────────

        private Dictionary<string, Grid> dictionary_Grid;

        /// <summary>
        /// このシステムに影響を及ぼすグリッド領域です。
        /// </summary>
        public Dictionary<string, Grid> Dictionary_Grid
        {
            get
            {
                if (null == dictionary_Grid)
                {
                    dictionary_Grid = new Dictionary<string, Grid>();
                }
                return dictionary_Grid;
            }
            set
            {
                dictionary_Grid = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
