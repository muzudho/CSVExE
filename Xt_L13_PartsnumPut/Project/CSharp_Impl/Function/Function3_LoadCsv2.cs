using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using Xenon.Lib;

namespace Xenon.PartsnumPut
{


    /// <summary>
    /// [仕様変更]
    /// 列名を変更。CSVExEの「フォーム設定ファイル」に合わせる。
    /// 
    /// DISPLAY → TEXT
    /// X → X_LT
    /// Y → Y_LT
    /// FONT_SIZE → FONT_SIZE_PT
    /// COLOR_BG → BACK_COLOR
    /// 
    /// </summary>
    public class Function3_LoadCsv2
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Function3_LoadCsv2()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Perform()
        {

            this.In_UsercontrolCanvas.ClearNumSps(true);


            //
            // テーブル読取
            //
            Dictionary<string, int> dictionary_NameField = new Dictionary<string, int>();

            int row = 0;
            // 「NO」、「DISPLAY」、「LAYER」「X」「Y」「FONT_SIZE」「COLOR_BG」（「END」）の8フィールドがある。
            int indexColumn_Display = -1;
            int indexColumn_Text = -1;
            int indexColumn_Layer = -1;
            int indexColumn_X = -1;
            int indexColumn_XLt = -1;
            int indexColumn_Y = -1;
            int indexColumn_YLt = -1;
            int indexColumn_FontSize = -1;
            int indexColumn_FontSizePt = -1;
            int indexColumn_ColorBg = -1;
            int indexColumn_BackColor = -1;
            foreach (string[] record in this.in_ListArraystring_Table)
            {
                //欲しい列が何番目にあるかを調べます。
                if (row == 0)
                {
                    // 上１行は「列名」。
                    int cur_IndexColumn = 0;
                    foreach (string sName in record)
                    {
                        string sNameUpper = sName.Trim().ToUpper();
                        if (!dictionary_NameField.ContainsKey(sNameUpper))
                        {
                            dictionary_NameField.Add(sNameUpper, cur_IndexColumn);
                            //ystem.Console.WriteLine(sNameUpper + "=" + nColIx);
                        }
                        else
                        {
                            // TODO:エラー
                        }

                        cur_IndexColumn++;
                    }

                    if (!dictionary_NameField.TryGetValue("DISPLAY", out indexColumn_Display))
                    {
                        indexColumn_Display = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("TEXT", out indexColumn_Text))
                    {
                        indexColumn_Text = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("LAYER", out indexColumn_Layer))
                    {
                        indexColumn_Layer = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("X", out indexColumn_X))
                    {
                        indexColumn_X = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("X_LT", out indexColumn_XLt))
                    {
                        indexColumn_XLt = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("Y", out indexColumn_Y))
                    {
                        indexColumn_Y = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("Y_LT", out indexColumn_YLt))
                    {
                        indexColumn_YLt = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("FONT_SIZE", out indexColumn_FontSize))
                    {
                        indexColumn_FontSize = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("FONT_SIZE_PT", out indexColumn_FontSizePt))
                    {
                        indexColumn_FontSizePt = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("COLOR_BG", out indexColumn_ColorBg))
                    {
                        indexColumn_ColorBg = -1;
                    }

                    if (!dictionary_NameField.TryGetValue("BACK_COLOR", out indexColumn_BackColor))
                    {
                        indexColumn_BackColor = -1;
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

                Memory4bSpritePartsnumberImpl memSpriteNum = new Memory4bSpritePartsnumberImpl();
                memSpriteNum.Delegate_OnChangeSprite_Partsnumber = this.In_UsercontrolCanvas.UsercontrolCanvas_OnChangeSpritePartsnumber;

                //表示テキスト
                {
                    if (0 <= indexColumn_Text)
                    {
                        memSpriteNum.Text = record[indexColumn_Text];
                    }
                    else if (0 <= indexColumn_Display)
                    {
                        //旧仕様
                        memSpriteNum.Text = record[indexColumn_Display];
                    }
                }

                //レイヤー
                if (0 <= indexColumn_Layer)
                {
                    int nLayer = 0;
                    int.TryParse(record[indexColumn_Layer], out nLayer);
                    memSpriteNum.Number_Layer = nLayer;
                }

                //座標
                {
                    //左辺x
                    int x = 0;
                    {
                        if (0 <= indexColumn_XLt)
                        {
                            int.TryParse(record[indexColumn_XLt], out x);
                        }
                        else if (0 <= indexColumn_X)
                        {
                            int.TryParse(record[indexColumn_X], out x);
                        }
                    }

                    //上辺y
                    int y = 0;
                    {
                        if (0 <= indexColumn_YLt)
                        {
                            int.TryParse(record[indexColumn_YLt], out y);
                        }
                        else if (0 <= indexColumn_Y)
                        {
                            int.TryParse(record[indexColumn_Y], out y);
                        }
                    }

                    memSpriteNum.LocationOnBackgroundActual = new PointF(x, y);
                }


                //フォントサイズ（1以上の数字なら有効）
                {
                    int fontsize = -1;
                    if (0 <= indexColumn_FontSizePt)
                    {
                        if (int.TryParse(record[indexColumn_FontSizePt], out fontsize))
                        {
                            fontsize = -1;
                        }
                    }
                    else if (0 <= indexColumn_FontSize)
                    {
                        //旧仕様
                        if (int.TryParse(record[indexColumn_FontSize], out fontsize))
                        {
                            fontsize = -1;
                        }
                    }

                    if (1 <= fontsize)
                    {
                        memSpriteNum.Font = new System.Drawing.Font("ＭＳ ゴシック", (float)fontsize);
                    }
                }

                //背景色
                {
                    string name_Color = "";
                    if (0 <= indexColumn_BackColor)
                    {
                        name_Color = record[indexColumn_BackColor];
                    }
                    else if (0 <= indexColumn_ColorBg)
                    {
                        //旧仕様
                        name_Color = record[indexColumn_ColorBg];
                    }

                    switch (name_Color)
                    {
                        case "Green":
                            memSpriteNum.BrushBackground = Brushes.Green;
                            break;

                        default:
                            memSpriteNum.BrushBackground = Brushes.Blue;
                            break;
                    }
                }

                this.In_UsercontrolCanvas.AddNumSp(memSpriteNum, true);

                //
            //
            loop_last://continueを使わない。

                row++;
            }

            this.In_UsercontrolCanvas.After_AddSpriteList();

            // フォームを再描画。
            this.In_UsercontrolCanvas.Refresh();

            goto gt_EndMethod;
        //
        gt_EndMethod:
            ;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected UsercontrolCanvas in_UsercontrolCanvas;

        /// <summary>
        /// 番号スプライトのリスト。
        /// </summary>
        public UsercontrolCanvas In_UsercontrolCanvas
        {
            get
            {
                return in_UsercontrolCanvas;
            }
            set
            {
                in_UsercontrolCanvas = value;
            }
        }

        //────────────────────────────────────────

        protected List<string[]> in_ListArraystring_Table;

        public List<string[]> In_ListArraystring_Table
        {
            set
            {
                this.in_ListArraystring_Table = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
