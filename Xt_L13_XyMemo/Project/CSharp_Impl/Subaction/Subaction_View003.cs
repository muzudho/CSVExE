using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Xenon.XyMemo
{



    public class Subaction_View003
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 情報表示。
        /// </summary>
        /// <param name="g"></param>
        /// <param name="isOnWindow"></param>
        /// <param name="scale2"></param>
        public void Paint(
            Graphics g,
            bool isOnWindow,
            MemorySpritememoImpl memorySpritememo,
            float scale2,
            Spritememo_InfoDisplay infoDisplay
            )
        {
            int ox;
            int oy;

            if (isOnWindow)
            {
                ox = 0;
                oy = 100;
            }
            else
            {
                ox = 0;
                oy = 0;
            }

            int row = 1;
            string sText;

            //
            // ベースx,y
            //
            sText = infoDisplay.E_sSpBaseLocationOnBg.ToString();
            if ("" != sText)
            {
                // 影
                g.DrawString(
                    sText,
                    infoDisplay.CoordinateFont,
                    Brushes.Black,
                    infoDisplay.TextLocationAA[row][2].X + ox,
                    infoDisplay.TextLocationAA[row][2].Y + oy
                    );
                // 白抜き文字
                g.DrawString(
                    sText,
                    infoDisplay.CoordinateFont,
                    Brushes.White,
                    infoDisplay.TextLocationAA[row][1].X + ox,
                    infoDisplay.TextLocationAA[row][1].Y + oy
                    );

                row++;
            }

            //
            // 左上x,y
            //
            {
                string s = infoDisplay.E_sSpLtOnBg.ToString();

                // 影
                g.DrawString(
                    s,
                    infoDisplay.CoordinateFont,
                    Brushes.Black,
                    infoDisplay.TextLocationAA[row][2].X + ox,
                    infoDisplay.TextLocationAA[row][2].Y + oy
                    );
                // 白抜き文字
                g.DrawString(
                    s,
                    infoDisplay.CoordinateFont,
                    Brushes.White,
                    infoDisplay.TextLocationAA[row][1].X + ox,
                    infoDisplay.TextLocationAA[row][1].Y + oy
                    );

                row++;
            }

            //
            // 中心x,y
            //
            {
                string s = infoDisplay.E_sSpCtOnBg.ToString();
                // 影
                g.DrawString(
                    s,
                    infoDisplay.CoordinateFont,
                    Brushes.Black,
                    infoDisplay.TextLocationAA[row][2].X + ox,
                    infoDisplay.TextLocationAA[row][2].Y + oy
                    );
                // 白抜き文字
                g.DrawString(
                    s,
                    infoDisplay.CoordinateFont,
                    Brushes.White,
                    infoDisplay.TextLocationAA[row][1].X + ox,
                    infoDisplay.TextLocationAA[row][1].Y + oy
                    );

                row++;
            }

            //
            // 横幅、縦幅
            //
            if (
                (0 != memorySpritememo.DstSizeResult.Width || 0 != memorySpritememo.SrcSize.Width) &&
                (0 != memorySpritememo.DstSizeResult.Height || 0 != memorySpritememo.SrcSize.Height)
                )
            {
                string s = infoDisplay.E_sWH.ToString();
                // 影
                g.DrawString(
                    s,
                    infoDisplay.CoordinateFont,
                    Brushes.Black,
                    infoDisplay.TextLocationAA[row][2].X + ox,
                    infoDisplay.TextLocationAA[row][2].Y + oy
                    );
                // 白抜き文字
                g.DrawString(
                    s,
                    infoDisplay.CoordinateFont,
                    Brushes.White,
                    infoDisplay.TextLocationAA[row][1].X + ox,
                    infoDisplay.TextLocationAA[row][1].Y + oy
                    );

                row++;
            }

        }

        //────────────────────────────────────────
        #endregion



    }



}
