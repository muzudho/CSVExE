using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.FrameMemo
{
    /// <summary>
    /// 全フレームの画像を保存。
    /// </summary>
    class Function5Save2Impl
    {



        #region アクション
        //────────────────────────────────────────

        public void Save(
            Usercontrolview_Infodisplay infodisplay,
            CheckBox pcchkInfo,
            Usercontrol_FrameMemo uc_FrameMemo
            )
        {
            if (null != infodisplay.MemorySprite.Bitmap)
            {

                // 列数と行数。
                int nCols = (int)infodisplay.MemorySprite.CountcolumnResult;
                int nRows = (int)infodisplay.MemorySprite.CountrowResult;

                // ファイル名の頭。
                StringBuilder s1 = new StringBuilder();
                {
                    s1.Append(Application.StartupPath);
                    s1.Append("\\ScreenShot\\");

                    DateTime now = System.DateTime.Now;
                    s1.Append(now.Year);
                    s1.Append("_");
                    s1.Append(now.Month);
                    s1.Append("_");
                    s1.Append(now.Day);
                    s1.Append("_");
                    s1.Append(now.Hour);
                    s1.Append("_");
                    s1.Append(now.Minute);
                    s1.Append("_");
                    s1.Append(now.Second);
                    s1.Append("_");
                    s1.Append(now.Millisecond);
                }


                for (int nRow = 1; nRow <= nRows; nRow++)
                {
                    for (int nCol = 1; nCol <= nCols; nCol++)
                    {
                        int nCell = (nRow - 1) * nCols + nCol;
                        System.Console.WriteLine("r" + nRow + " c" + nCol + " nCell" + nCell + "  nRows" + nRows + " nCols" + nCols);


                        uc_FrameMemo.Usercontrol_FrameParam.PctxtCropForce.Text = nCell.ToString();

                        Bitmap bm = new Function4Save1bImpl().CreateSaveImage(
                            infodisplay,
                            pcchkInfo,
                            uc_FrameMemo
                            );



                        // ファイル名を適当に作成。
                        StringBuilder s = new StringBuilder();
                        {
                            s.Append(s1.ToString());
                            s.Append("_c");
                            s.Append(nCell.ToString());
                            s.Append(".png");
                        }

                        // .exeの入っているフォルダーに ScreenShot フォルダーを置くこと。
                        bm.Save(s.ToString(), System.Drawing.Imaging.ImageFormat.Png);

                    }
                }

            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
