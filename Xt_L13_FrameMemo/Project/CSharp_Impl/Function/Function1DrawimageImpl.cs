using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Xenon.FrameMemo
{
    /// <summary>
    /// 全体図の描画。
    /// </summary>
    public class Function1DrawimageImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 全体図の描画。
        /// </summary>
        /// <param name="g"></param>
        /// <param name="isOnWindow"></param>
        /// <param name="memorySprite"></param>
        /// <param name="xBase">ベースX</param>
        /// <param name="yBase">ベースY</param>
        /// <param name="scale"></param>
        /// <param name="imgOpaque"></param>
        /// <param name="isImageGrid"></param>
        /// <param name="isVisible_Infodisplay"></param>
        /// <param name="infoDisplay"></param>
        public void Perform(
            Graphics g,
            bool isOnWindow,
            MemorySpriteImpl memorySprite,
            float xBase,
            float yBase,
            float scale,
            float imgOpaque,
            bool isImageGrid,
            bool isVisible_Infodisplay,
            PartnumberconfigImpl partnumberconf,
            Usercontrolview_Infodisplay infoDisplay
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
            float leftSprite = 0;
            float topSprite = 0;
            if (isOnWindow)
            {
                leftSprite += memorySprite.Lefttop.X;
                topSprite += memorySprite.Lefttop.Y;
            }

            //
            // 表示画像の長方形（Image rectangle）
            RectangleF dstIrScaled = new RectangleF(
                leftSprite + xBase,
                topSprite + yBase,
                scale * (float)memorySprite.Bitmap.Width,
                scale * (float)memorySprite.Bitmap.Height
                );
            // グリッド枠の長方形（Grid frame rectangle）
            RectangleF dstGrScaled;
            {
                float col = memorySprite.CountcolumnResult;
                float row = memorySprite.CountrowResult;
                if (col < 1)
                {
                    col = 1;
                }

                if (row < 1)
                {
                    row = 1;
                }

                float cw = memorySprite.WidthcellResult;
                float ch = memorySprite.HeightcellResult;

                //グリッドのベース
                dstGrScaled = new RectangleF(
                                scale * memorySprite.GridLefttop.X + leftSprite + xBase,
                                scale * memorySprite.GridLefttop.Y + topSprite + yBase,
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
                memorySprite.Bitmap,
                new Rectangle((int)dstIrScaled.X, (int)dstIrScaled.Y, (int)dstIrScaled.Width, (int)dstIrScaled.Height),
                0,
                0,
                memorySprite.Bitmap.Width,
                memorySprite.Bitmap.Height,
                GraphicsUnit.Pixel,
                ia
                );

            // 枠線
            if (isImageGrid)
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
                    float h2 = infoDisplay.MemorySprite.HeightcellResult * scale;

                    for (int row = 1; row < infoDisplay.MemorySprite.CountrowResult; row++)
                    {
                        g.DrawLine(infoDisplay.GridPen,//Pens.Black,
                            dstGrScaled.X + borderWidth,
                            (float)row * h2 + dstGrScaled.Y,
                            dstGrScaled.Width + dstGrScaled.X - borderWidth - 1,
                            (float)row * h2 + dstGrScaled.Y
                            );
                    }
                }

                // 格子：影:縦線
                {
                    float w2 = infoDisplay.MemorySprite.WidthcellResult * scale;

                    for (int column = 1; column < infoDisplay.MemorySprite.CountcolumnResult; column++)
                    {
                        g.DrawLine(infoDisplay.GridPen,//Pens.Black,
                            (float)column * w2 + dstGrScaled.X,
                            dstGrScaled.Y + borderWidth - 1,//上辺の枠と隙間を空けないように-1で調整。
                            (float)column * w2 + dstGrScaled.X,
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


            // 部品番号の描画
            if (partnumberconf.Visibled)
            {
                //
                // 数字は桁が多くなると横幅が伸びます。「0」「32」「105」
                // 特例で１桁は２桁扱いとして、「横幅÷桁数」が目安です。
                //


                // 最終部品番号
                int numberLast = (int)(infoDisplay.MemorySprite.CountrowResult * infoDisplay.MemorySprite.CountcolumnResult - 1) + partnumberconf.FirstIndex;
                // 最終部品番号の桁数
                int digit = numberLast.ToString().Length;
                if(1==digit)
                {
                    digit = 2;//特例で１桁は２桁扱いとします。
                }
                float fontPt = memorySprite.WidthcellResult / digit;

                //partnumberconf.Font = new Font("MS ゴシック", fontPt);
                partnumberconf.Font = new Font("メイリオ", fontPt);


                for (int row = 0; row < infoDisplay.MemorySprite.CountrowResult; row++)
                {
                    for (int column = 0; column < infoDisplay.MemorySprite.CountcolumnResult; column++)
                    {
                        int number = (int)(row * infoDisplay.MemorySprite.CountcolumnResult + column) + partnumberconf.FirstIndex;
                        string text = number.ToString();
                        SizeF stringSize = g.MeasureString(text, partnumberconf.Font);

                        g.DrawString(text, partnumberconf.Font, partnumberconf.Brush,
                            new PointF(
                                column * memorySprite.WidthcellResult + leftSprite + memorySprite.WidthcellResult / 2 - stringSize.Width/2 + xBase,
                                row * memorySprite.HeightcellResult + topSprite + memorySprite.HeightcellResult / 2 - stringSize.Height/2 + yBase
                                ));
                    }
                }
            }


            // 情報欄の描画
            if (isVisible_Infodisplay)
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
                infoDisplay.Paint(g, isOnWindow, dy, scale);
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
