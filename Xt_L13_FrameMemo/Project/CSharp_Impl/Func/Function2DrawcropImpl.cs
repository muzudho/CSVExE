using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;//PointF

namespace Xenon.FrameMemo
{
    /// <summary>
    /// 切抜きフレームの描画。
    /// </summary>
    public class Function2DrawcropImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="isOnWindow"></param>
        /// <param name="memorySprite"></param>
        /// <param name="xBase">ベースX</param>
        /// <param name="yBase">ベースY</param>
        /// <param name="scale"></param>
        /// <param name="imgOpaque"></param>
        /// <param name="isImageGrid"></param>
        /// <param name="isInfodisplayVisible"></param>
        /// <param name="infodisplay"></param>
        public void Perform(
            Graphics g,
            bool isOnWindow,
            MemorySpriteImpl memorySprite,
            float xBase,
            float yBase,
            float scale,
            float imgOpaque,
            bool isImageGrid,
            bool isInfodisplayVisible,
            Usercontrolview_Infodisplay infodisplay
            )
        {
            // ビットマップ画像の不透明度を指定します。
            System.Drawing.Imaging.ImageAttributes ia;
            {
                System.Drawing.Imaging.ColorMatrix cm =
                    new System.Drawing.Imaging.ColorMatrix();
                cm.Matrix00 = 1;
                cm.Matrix11 = 1;
                cm.Matrix22 = 1;
                cm.Matrix33 = imgOpaque;//α値。0～1か？
                cm.Matrix44 = 1;

                //ImageAttributesオブジェクトの作成
                ia = new System.Drawing.Imaging.ImageAttributes();
                //ColorMatrixを設定する
                ia.SetColorMatrix(cm);
            }
            float dstX = 0;
            float dstY = 0;
            if (isOnWindow)
            {
                dstX += memorySprite.Lefttop.X;
                dstY += memorySprite.Lefttop.Y;
            }


            // 表示する画像の横幅、縦幅。
            float viWidth = (float)memorySprite.Bitmap.Width / memorySprite.CountcolumnResult;
            float viHeight = (float)memorySprite.Bitmap.Height / memorySprite.CountrowResult;

            // 横幅、縦幅の上限。
            if (memorySprite.WidthcellResult < viWidth)
            {
                viWidth = memorySprite.WidthcellResult;
            }

            if (memorySprite.HeightcellResult < viHeight)
            {
                viHeight = memorySprite.HeightcellResult;
            }



            // 枠を考慮しない画像サイズ
            Rectangle dstR = new Rectangle(
                (int)(dstX + xBase),
                (int)(dstY + yBase),
                (int)viWidth,
                (int)viHeight
                );
            Rectangle dstRScaled = new Rectangle(
                (int)(dstX + xBase),
                (int)(dstY + yBase),
                (int)(scale * viWidth),
                (int)(scale * viHeight)
                );

            // 太さ2pxの枠が収まるサイズ（Border Rectangle）
            int borderWidth = 2;
            Rectangle dstBr = new Rectangle(
                (int)dstX + borderWidth,
                (int)dstY + borderWidth,
                (int)viWidth - 2 * borderWidth,
                (int)viHeight - 2 * borderWidth);
            Rectangle dstBrScaled = new Rectangle(
                (int)dstX + borderWidth,
                (int)dstY + borderWidth,
                (int)(scale * viWidth) - 2 * borderWidth,
                (int)(scale * viHeight) - 2 * borderWidth);

            // 切り抜く位置。
            PointF srcL = memorySprite.GetCropXy();

            float gridX = memorySprite.GridLefttop.X;
            float gridY = memorySprite.GridLefttop.Y;



            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;//ドット絵のまま拡縮するように。しかし、この指定だと半ピクセル左上にずれるバグ。
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;//半ピクセル左上にずれるバグに対応。
            g.DrawImage(
                memorySprite.Bitmap,
                dstRScaled,
                srcL.X,
                srcL.Y,
                viWidth,
                viHeight,
                GraphicsUnit.Pixel,
                ia
                );

            // 枠線
            if (isImageGrid)
            {
                //
                // 枠線：影
                //
                // X,Yを、1ドット右下にずらします。
                dstRScaled.Offset(1, 1);
                // 最初の状態だと、右辺、下辺が外に1px出ています。
                // X,Yをずらした分と合わせて、縦幅、横幅を2ドット狭くします。
                dstRScaled.Width -= 2;
                dstRScaled.Height -= 2;
                g.DrawRectangle(Pens.Black, dstRScaled);
                //
                //
                dstRScaled.Offset(-1, -1);// 元の位置に戻します。
                dstRScaled.Width += 2;// 元のサイズに戻します。
                dstRScaled.Height += 2;

                //
                // 格子線は引かない。
                //

                // 枠線：緑
                // 最初から1ドット出ている分と、X,Yをずらした分と合わせて、
                // 縦幅、横幅を2ドット狭くします。
                dstRScaled.Width -= 2;
                dstRScaled.Height -= 2;
                g.DrawRectangle(Pens.Green, dstRScaled);
            }

            // 情報欄の描画
            if (isInfodisplayVisible)
            {
                int dy;
                if (isOnWindow)
                {
                    dy = 100;
                }
                else
                {
                    dy = 4;// 16;
                }
                infodisplay.Paint(g, isOnWindow, dy, scale);
            }
        }

        //────────────────────────────────────────
        #endregion


    }
}
