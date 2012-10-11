using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Drawing;
using Xenon.Syntax;
using Xenon.Table;
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
            Log_Method log_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_PartsnumPut.Name_Library, this, "Perform", log_Reports_ThisMethod);

            this.In_UsercontrolCanvas.ClearNumSps(true);
            log_Method.WriteDebug_ToConsole("Performを実行しました。");


            //
            // テーブル読取
            //
            //Dictionary<string, int> dictionary_NameField = new Dictionary<string, int>();

            //欲しい列が何番目にあるかを調べます。
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
            //this.in_Table_Humaninput.RecordFielddefinition.ForEach(delegate(Fielddefinition fielddefinition, ref bool isBreak2, Log_Reports log_Reports2)
            //{
            //},log_Reports_ThisMethod);

            // 列のindex。該当がなければ-1。
            indexColumn_Display = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("DISPLAY");
            indexColumn_Text = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("TEXT");
            indexColumn_Layer = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("LAYER");
            indexColumn_X = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("X");
            indexColumn_XLt = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("X_LT");
            indexColumn_Y = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("Y");
            indexColumn_YLt = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("Y_LT");
            indexColumn_FontSize = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("FONT_SIZE");
            indexColumn_FontSizePt = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("FONT_SIZE_PT");
            indexColumn_ColorBg = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("COLOR_BG");
            indexColumn_BackColor = this.in_Table_Humaninput.RecordFielddefinition.ColumnIndexOf_Trimupper("BACK_COLOR");

            this.in_Table_Humaninput.ForEach_Datapart(delegate(Record_Humaninput recordH, ref bool isBreak1, Log_Reports log_Reports1)
            {
                //log_Method.WriteDebug_ToConsole("row=[" + row + "] recordH.ToString_DebugDump()=[" + recordH.ToString_DebugDump() + "]");

                //if (row == 0)
                //{
                //    // 上１行は「列名」。

                //    //log_Method.WriteDebug_ToConsole("indexColumn_BackColor=[" + indexColumn_BackColor + "] recordH.ToString_DebugDump()=[" + recordH.ToString_DebugDump()+ "]");

                //    goto gt_LastLoop;
                //}
                //else if (row < 3)
                //{
                //    // 上３行(row=0,1,2)は「列名」「型」「解説」として無視。
                //    goto gt_LastLoop;
                //}

                // 左端に EOF が入っていれば終了。
                if ("EOF" == recordH.ValueAt(0).Text.Trim())
                {
                    isBreak1 = true;
                    goto gt_LastLoop;
                }

                Memory4bSpritePartsnumberImpl memSpriteNum = new Memory4bSpritePartsnumberImpl();
                memSpriteNum.Delegate_OnChangeSprite_Partsnumber = this.In_UsercontrolCanvas.UsercontrolCanvas_OnChangeSpritePartsnumber;

                //表示テキスト
                {
                    if (0 <= indexColumn_Text)
                    {
                        memSpriteNum.Text = recordH.ValueAt(indexColumn_Text).Text;
                    }
                    else if (0 <= indexColumn_Display)
                    {
                        //旧仕様
                        memSpriteNum.Text = recordH.ValueAt(indexColumn_Display).Text;
                    }
                }

                //レイヤー
                if (0 <= indexColumn_Layer)
                {
                    int nLayer = 0;
                    int.TryParse(recordH.ValueAt(indexColumn_Layer).Text, out nLayer);
                    memSpriteNum.Number_Layer = nLayer;
                }

                //座標
                {
                    //左辺x
                    int x = 0;
                    {
                        if (0 <= indexColumn_XLt)
                        {
                            int.TryParse(recordH.ValueAt(indexColumn_XLt).Text, out x);
                        }
                        else if (0 <= indexColumn_X)
                        {
                            int.TryParse(recordH.ValueAt(indexColumn_X).Text, out x);
                        }
                    }

                    //上辺y
                    int y = 0;
                    {
                        if (0 <= indexColumn_YLt)
                        {
                            int.TryParse(recordH.ValueAt(indexColumn_YLt).Text, out y);
                        }
                        else if (0 <= indexColumn_Y)
                        {
                            int.TryParse(recordH.ValueAt(indexColumn_Y).Text, out y);
                        }
                    }

                    memSpriteNum.LocationOnBackgroundActual = new PointF(x, y);
                }


                //フォントサイズ（1以上の数字なら有効）
                {
                    int fontsize = -1;
                    if (0 <= indexColumn_FontSizePt)
                    {
                        if (int.TryParse(recordH.ValueAt(indexColumn_FontSizePt).Text, out fontsize))
                        {
                            fontsize = -1;
                        }
                    }
                    else if (0 <= indexColumn_FontSize)
                    {
                        //旧仕様
                        if (int.TryParse(recordH.ValueAt(indexColumn_FontSize).Text, out fontsize))
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
                        name_Color = recordH.ValueAt(indexColumn_BackColor).Text;
                    }
                    else if (0 <= indexColumn_ColorBg)
                    {
                        //旧仕様
                        name_Color = recordH.ValueAt(indexColumn_ColorBg).Text;
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
            gt_LastLoop://continueを使わない。

                row++;
            }, log_Reports_ThisMethod);

            this.In_UsercontrolCanvas.After_AddSpriteList();

            // フォームを再描画。
            this.In_UsercontrolCanvas.Refresh();

            //
            goto gt_EndMethod;
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports_ThisMethod);
            return;
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

        protected Table_Humaninput in_Table_Humaninput;

        public Table_Humaninput In_Table_Humaninput
        {
            set
            {
                this.in_Table_Humaninput = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
