using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;//Pens

namespace Xenon.NumPut
{
    /// <summary>
    /// CSVファイルで保存。
    /// </summary>
    public class Subaction001
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Subaction001()
        {
            this.in_sFpatha = "";
            this.out_errorMsg = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Perform(Memory3Contents moContents)
        {
            this.out_errorMsg = "";
            StringBuilder e_sCsv = new StringBuilder();


            e_sCsv.Append("NO,DISPLAY,LAYER,X,Y,FONT_SIZE,COLOR_BG,END");
            e_sCsv.Append(Environment.NewLine);
            e_sCsv.Append("int,string,int,int,int,int,string,END");
            e_sCsv.Append(Environment.NewLine);
            e_sCsv.Append("連番,表示文字列,レイヤー,中心X,中心Y,フォントサイズ10/20,Blue/Green,END");
            e_sCsv.Append(Environment.NewLine);

            int no = 0;
            foreach (List<MemoryNum> mNumList in moContents.LayerDic.Values)
            {
                foreach (MemoryNumImpl numSp in mNumList)
                {
                    e_sCsv.Append(no);
                    e_sCsv.Append(",");
                    e_sCsv.Append(numSp.GetText(moContents, false));
                    e_sCsv.Append(",");
                    e_sCsv.Append(numSp.NLayer);
                    e_sCsv.Append(",");
                    e_sCsv.Append((int)numSp.LocationOnBgActual.X);//拡大時の小数点以下切捨て
                    e_sCsv.Append(",");
                    e_sCsv.Append((int)numSp.LocationOnBgActual.Y);//拡大時の小数点以下切捨て
                    e_sCsv.Append(",");
                    e_sCsv.Append((int)numSp.NumSpFont.Size);
                    e_sCsv.Append(",");

                    if (
                        Brushes.Green == numSp.BrushBg
                        )
                    {
                        e_sCsv.Append("Green");
                    }
                    else
                    {
                        e_sCsv.Append("Blue");
                    }
                    e_sCsv.Append(",END");
                    e_sCsv.Append(Environment.NewLine);

                    no++;
                }
            }

            e_sCsv.Append("EOF,,,,,,,");
            e_sCsv.Append(Environment.NewLine);

            try
            {
                System.IO.File.WriteAllText(this.In_SFpatha, e_sCsv.ToString(), Encoding.Default);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                this.out_errorMsg = e.Message;
            }
        }

        //────────────────────────────────────────
        #endregion


        
        #region プロパティー
        //────────────────────────────────────────

        protected string in_sFpatha;

        /// <summary>
        /// 絶対ファイルパス
        /// </summary>
        public string In_SFpatha
        {
            get
            {
                return in_sFpatha;
            }
            set
            {
                in_sFpatha = value;
            }
        }

        //────────────────────────────────────────

        protected string out_errorMsg;

        /// <summary>
        /// エラーメッセージ。無ければ空文字列。
        /// </summary>
        public string Out_errorMsg
        {
            get
            {
                return out_errorMsg;
            }
            set
            {
                out_errorMsg = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
