using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;//PointF

namespace Xenon.FrameMemo
{
    /// <summary>
    /// 全体図の描画。
    /// </summary>
    public class Subaction001
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bOnWindow"></param>
        /// <param name="moSp"></param>
        /// <param name="bX">ベースX</param>
        /// <param name="bY">ベースY</param>
        /// <param name="scale"></param>
        /// <param name="imgOpaque"></param>
        /// <param name="bImgGrid"></param>
        /// <param name="bInfoDisplayVisible"></param>
        /// <param name="infoDisplay"></param>
        public void Perform(
            Graphics g,
            bool bOnWindow,
            MemorySpriteImpl moSp,
            float bX,
            float bY,
            float scale,
            float imgOpaque,
            bool bImgGrid,
            bool bInfoDisplayVisible,
            ViewFrame_InfoDisplay infoDisplay
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
            float x = 0;
            float y = 0;
            if (bOnWindow)
            {
                x += moSp.Lt.X;
                y += moSp.Lt.Y;
            }

            //
            // 表示画像の長方形（Image rectangle）
            RectangleF dstIrScaled = new RectangleF(
                x + bX,
                y + bY,
                scale * (float)moSp.Bitmap.Width,
                scale * (float)moSp.Bitmap.Height
                );
            // グリッド枠の長方形（Grid frame rectangle）
            RectangleF dstGrScaled;
            {
                float col = moSp.NColCountResult;
                float row = moSp.NRowCountResult;
                if (col < 1)
                {
                    col = 1;
                }

                if (row < 1)
                {
                    row = 1;
                }

                float cw = moSp.NCellWidthResult;
                float ch = moSp.NCellHeightResult;

                //グリッドのベース
                dstGrScaled = new RectangleF(
                                scale * moSp.GridLt.X + x + bX,
                                scale * moSp.GridLt.Y + y + bY,
                                scale * col * cw,
                                scale * row * ch
                                );
            }

            // 太さ2pxの枠が収まるサイズ
            float borderWidth = 2.0f;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;//ドット絵のまま拡縮するように。しかし、この指定だと半ピクセル左上にずれるバグ。
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;//半ピクセル左上にずれるバグに対応。

            //
            // 画像描画
            g.DrawImage(
                moSp.Bitmap,
                new Rectangle((int)dstIrScaled.X, (int)dstIrScaled.Y, (int)dstIrScaled.Width, (int)dstIrScaled.Height),
                0,
                0,
                moSp.Bitmap.Width,
                moSp.Bitmap.Height,
                GraphicsUnit.Pixel,
                ia
                );

            // 枠線
            if (bImgGrid)
            {

                //
                // 枠線：影
                //
                // オフセット 0、0　だと、上辺、左辺の緑線、黒線が保存画像から見切れます。
                // オフセット 1、1　だと、上辺、左辺の緑線が保存画像から見切れます。
                // オフセット 2、2　だと、上辺、左辺の緑線、黒線が保存画像に入ります。
                //
                // X,Yを、2ドット右下にずらします。
                dstGrScaled.Offset(2, 2);
                // X,Yの起点をずらした分だけ、縦幅、横幅を小さくします。
                dstGrScaled.Width -= 2;
                dstGrScaled.Height -= 2;
                g.DrawRectangle(Pens.Black, dstGrScaled.X, dstGrScaled.Y, dstGrScaled.Width, dstGrScaled.Height);
                //
                //
                dstGrScaled.Offset(-1, -1);// 元の位置に戻します。
                dstGrScaled.Width += 2;// 元のサイズに戻します。
                dstGrScaled.Height += 2;


                // 格子：横線
                {
                    float h2 = infoDisplay.MoSprite.NCellHeightResult * scale;

                    for (int i = 1; i < infoDisplay.MoSprite.NRowCountResult; i++)
                    {
                        g.DrawLine(infoDisplay.GridPen,//Pens.Black,
                            dstGrScaled.X + borderWidth,
                            (float)i * h2 + dstGrScaled.Y,
                            dstGrScaled.Width + dstGrScaled.X - borderWidth - 1,
                            (float)i * h2 + dstGrScaled.Y
                            );
                    }
                }

                // 格子：影:縦線
                {
                    float w2 = infoDisplay.MoSprite.NCellWidthResult * scale;

                    for (int i = 1; i < infoDisplay.MoSprite.NColCountResult; i++)
                    {
                        g.DrawLine(infoDisplay.GridPen,//Pens.Black,
                            (float)i * w2 + dstGrScaled.X,
                            dstGrScaled.Y + borderWidth - 1,//上辺の枠と隙間を空けないように-1で調整。
                            (float)i * w2 + dstGrScaled.X,
                            dstGrScaled.Height + dstGrScaled.Y - borderWidth - 1
                            );
                    }
                }



                //
                // 枠線：緑
                //
                // 上辺、左辺の 0、0　と、
                // 右辺、下辺の -2、 -2 に線を引きます。
                //
                // 右辺、下辺が 0、0　だと画像外、
                // 右辺、下辺が -1、-1　だと影線の位置になります。
                dstGrScaled.Width -= 2;
                dstGrScaled.Height -= 2;
                g.DrawRectangle(Pens.Green, dstGrScaled.X, dstGrScaled.Y, dstGrScaled.Width, dstGrScaled.Height);
            }

            // 情報欄の描画
            if (bInfoDisplayVisible)
            {
                int dy;
                if (bOnWindow)
                {
                    dy = 100;
                }
                else
                {
                    dy = 4;// 16;
                }
                infoDisplay.Paint(g, bOnWindow, dy, scale);
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
