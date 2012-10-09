using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.FrameMemo
{
    /// <summary>
    /// 画像を保存。
    /// </summary>
    class SubactionSave001
    {



        #region アクション
        //────────────────────────────────────────

        public void Save(
            ViewFrame_InfoDisplay infoDisplay,
            CheckBox pcchkInfo,
            Usercontrol_FrameMemo uc_FrameMemo
            )
        {
            if (null != infoDisplay.MoSprite.Bitmap)
            {

                Bitmap bm = new SubactionSave001Sub001().CreateSaveImage(
                    infoDisplay,
                    pcchkInfo,
                    uc_FrameMemo
                    );



                // ファイル名を適当に作成。
                StringBuilder s = new StringBuilder();
                {
                    s.Append(Application.StartupPath);
                    s.Append("\\ScreenShot\\");

                    DateTime now = System.DateTime.Now;
                    s.Append(now.Year);
                    s.Append("_");
                    s.Append(now.Month);
                    s.Append("_");
                    s.Append(now.Day);
                    s.Append("_");
                    s.Append(now.Hour);
                    s.Append("_");
                    s.Append(now.Minute);
                    s.Append("_");
                    s.Append(now.Second);
                    s.Append("_");
                    s.Append(now.Millisecond);
                    s.Append(".png");
                }

                // .exeの入っているフォルダーに ScreenShot フォルダーを置くこと。
                bm.Save(s.ToString(), System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
