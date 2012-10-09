using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;//PointF

namespace Xenon.NumPut
{
    /// <summary>
    /// CSVファイルの読取
    /// </summary>
    public class Subaction002
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Subaction002()
        {
            this.in_sFpatha = "";
            this.in_MNumList = new List<MemoryNum>();

            this.out_errorMsg = "";
        }

        //────────────────────────────────────────
        #endregion

        

        #region アクション
        //────────────────────────────────────────

        public void Perfrom()
        {
            this.out_errorMsg = "";
            this.out_table = new List<string[]>();

            this.In_UcCanvas.ClearNumSps(true);

            // CSV読取
            string sCsv;
            try
            {
                sCsv = System.IO.File.ReadAllText(this.In_SFpatha, Encoding.Default);
            }
            catch (Exception e)
            {
                // エラー
                this.out_errorMsg = e.Message;
                goto process_end;
            }


            //
            // テーブル作成
            //

            System.IO.StringReader reader = new System.IO.StringReader(sCsv);

            // CSVを解析して、テーブル形式で格納。
            {
                int rowIndex = 0;
                while (-1 < reader.Peek())
                {
                    string line = reader.ReadLine();

                    //
                    // 配列の返却値を、ダイレクトに渡します。
                    //
                    this.Out_table.Add(line.Split(','));

                    rowIndex++;
                }
            }

            // ストリームを閉じます。
            reader.Close();


            //
            // テーブル読取
            //
            Dictionary<string, int> nFieldNameDic = new Dictionary<string, int>();

            int row = 0;
            // 「NO」、「DISPLAY」、「LAYER」「X」「Y」「FONT_SIZE」「COLOR_BG」（「END」）の8フィールドがある。
            int nIx_Display = -1;
            int nIx_Layer = -1;
            int nIx_X = -1;
            int nIx_Y = -1;
            int nIx_FontSize = -1;
            int nIx_ColorBg = -1;
            foreach (string[] record in this.Out_table)
            {
                if (row == 0)
                {
                    // 上１行は「列名」。
                    int nColIx = 0;
                    foreach (string sName in record)
                    {
                        string sNameUpper = sName.Trim().ToUpper();
                        if (!nFieldNameDic.ContainsKey(sNameUpper))
                        {
                            nFieldNameDic.Add(sNameUpper, nColIx);
                            //ystem.Console.WriteLine(sNameUpper + "=" + nColIx);
                        }
                        else
                        {
                            // TODO:エラー
                        }

                        nColIx++;
                    }

                    if (!nFieldNameDic.TryGetValue("DISPLAY", out nIx_Display))
                    {
                        nIx_Display = -1;
                    }

                    if (!nFieldNameDic.TryGetValue("LAYER", out nIx_Layer))
                    {
                        nIx_Layer = -1;
                    }

                    if (!nFieldNameDic.TryGetValue("X", out nIx_X))
                    {
                        nIx_X = -1;
                    }

                    if (!nFieldNameDic.TryGetValue("Y", out nIx_Y))
                    {
                        nIx_Y = -1;
                    }

                    if (!nFieldNameDic.TryGetValue("FONT_SIZE", out nIx_FontSize))
                    {
                        nIx_FontSize = -1;
                    }

                    if (!nFieldNameDic.TryGetValue("COLOR_BG", out nIx_ColorBg))
                    {
                        nIx_ColorBg = -1;
                    }

                    goto loop_last;
                }
                else if (row < 3)
                {
                    // 上３行(row=0,1,2)は「列名」「型」「解説」として無視。
                    goto loop_last;
                }

                // 左端に EOF が入っていれば終了。
                if ("EOF" == record[0].Trim())
                {
                    break;
                }

                MemoryNumImpl mNum = new MemoryNumImpl();

                if (0 <= nIx_Display)
                {
                    mNum.SText = record[nIx_Display];
                }

                if (0 <= nIx_Layer)
                {
                    int nLayer = 0;
                    int.TryParse(record[nIx_Layer], out nLayer);
                    mNum.NLayer = nLayer;
                }

                int x = 0;
                if (0 <= nIx_X)
                {
                    int.TryParse(record[nIx_X], out x);
                }

                int y = 0;
                if (0 <= nIx_Y)
                {
                    int.TryParse(record[nIx_Y], out y);
                }

                mNum.LocationOnBgActual = new PointF(x, y);

                if (0 <= nIx_FontSize)
                {
                    int nFontSize;
                    if (int.TryParse(record[nIx_FontSize], out nFontSize))
                    {
                        mNum.NumSpFont = new System.Drawing.Font("ＭＳ ゴシック", (float)nFontSize);
                    }
                }

                if (0 <= nIx_ColorBg)
                {
                    switch (record[nIx_ColorBg])
                    {
                        case "Green":
                            mNum.BrushBg = Brushes.Green;
                            break;

                        default:
                            mNum.BrushBg = Brushes.Blue;
                            break;
                    }
                }

                this.In_UcCanvas.AddNumSp(mNum, true);

                //
            //
            loop_last://continueを使わない。

                row++;
            }

            this.In_UcCanvas.After_AddSpriteList();

            // フォームを再描画。
            this.In_UcCanvas.Refresh();

            //
        //
        //
        //
        process_end:
            return;
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

        protected List<MemoryNum> in_MNumList;

        /// <summary>
        /// 番号スプライトのリスト。
        /// </summary>
        public List<MemoryNum> In_MNumList
        {
            get
            {
                return in_MNumList;
            }
            set
            {
                in_MNumList = value;
            }
        }

        //────────────────────────────────────────

        protected UsercontrolCanvas in_UcCanvas;

        /// <summary>
        /// 番号スプライトのリスト。
        /// </summary>
        public UsercontrolCanvas In_UcCanvas
        {
            get
            {
                return in_UcCanvas;
            }
            set
            {
                in_UcCanvas = value;
            }
        }

        //────────────────────────────────────────

        protected List<string[]> out_table;

        public List<string[]> Out_table
        {
            get
            {
                return out_table;
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
        }

        //────────────────────────────────────────
        #endregion



    }



}
