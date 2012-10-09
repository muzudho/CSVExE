using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.FrameMemo
{
    /// <summary>
    /// 保存する画像の作成。
    /// </summary>
    class Function4Save1bImpl
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 保存する画像の作成。
        /// </summary>
        public Bitmap CreateSaveImage(
            Usercontrolview_Infodisplay infodisplay,
            CheckBox pcchkInfo,
            Usercontrol_FrameMemo uc_FrameMemo
            )
        {
            Bitmap bm;

            if (null != infodisplay.MemorySprite.Bitmap)
            {

                // 情報領域
                int infoHeight;
                {
                    int infoRows = infodisplay.InfoRows;
                    int nHeightMargin = 8 + 4;
                    int nFontSize = 16;
                    infoHeight = infoRows * nFontSize + nHeightMargin;
                }


                {
                    // 情報欄のサイズ
                    SizeF infoSizeF;
                    if (pcchkInfo.Checked)
                    {
                        //
                        // 情報表示時
                        //

                        bm = new Bitmap(1, 1);
                        //ダミーのGraphicsオブジェクトを取得
                        Graphics dammy_g = Graphics.FromImage(bm);

                        infoSizeF = dammy_g.MeasureString(infodisplay.ToString_FileName(), infodisplay.Font);
                        // すぐ、Graphicsを廃棄。
                        dammy_g.Dispose();
                        // 横幅を 4px 大きく取る。
                        infoSizeF.Width += 4;
                    }
                    else
                    {
                        infoSizeF = new SizeF();
                    }



                    // 新規画像サイズ。
                    int w;
                    int h;
                    if (infodisplay.MemorySprite.IsCrop)
                    {
                        w = (int)infodisplay.MemorySprite.WidthcellResult;
                        h = (int)infodisplay.MemorySprite.HeightcellResult;
                    }
                    else
                    {
                        w = infodisplay.MemorySprite.Bitmap.Width;
                        h = infodisplay.MemorySprite.Bitmap.Height;
                    }

                    if (pcchkInfo.Checked)
                    {
                        // 横幅の最低値
                        int minW = (int)infoSizeF.Width;
                        if (w < minW)
                        {
                            w = minW;
                        }
                    }

                    // 横幅の上限（画像の横幅、または画像の横幅が300未満の場合、300）
                    {
                        int maxW;
                        if (300 <= infodisplay.MemorySprite.Bitmap.Width)
                        {
                            maxW = infodisplay.MemorySprite.Bitmap.Width;
                        }
                        else
                        {
                            maxW = 300;
                        }

                        if (maxW < w)
                        {
                            w = maxW;
                        }
                    }

                    // 縦幅
                    if (pcchkInfo.Checked)
                    {
                        h += infoHeight;
                    }

                    bm = new Bitmap(w, h);
                }

                //imgのGraphicsオブジェクトを取得
                Graphics g = Graphics.FromImage(bm);

                try
                {
                    // 背景色（自動の場合は、塗りつぶさない）
                    if (uc_FrameMemo.BackColor != SystemColors.Control)
                    {
                        g.FillRectangle(new SolidBrush(uc_FrameMemo.BackColor), 0, 0, bm.Width, bm.Height);
                    }

                    float baseX = 0;
                    float baseY = 0;
                    if (pcchkInfo.Checked)
                    {
                        baseY += infoHeight;
                    }

                    uc_FrameMemo.PaintSprite(
                        g,
                        false,
                        baseX,
                        baseY,
                        1.0F
                        );//等倍
                }
                finally
                {
                    g.Dispose();
                }
            }
            else
            {
                bm = null;
            }


            return bm;
        }

        //────────────────────────────────────────
        #endregion



    }
}
