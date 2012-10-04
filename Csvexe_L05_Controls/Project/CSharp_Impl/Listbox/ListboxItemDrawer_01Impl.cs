using System;
using System.Collections.Generic;
using System.Data;//DataRowView
using System.Drawing;//Point,Brush
using System.Linq;
using System.Text;
using System.Windows.Forms;//DrawItemEventArgs

using Xenon.Syntax;//Log_TextIndentedImpl
using Xenon.Middle;
using Xenon.Operating;//TextAlign,StyleAttrItem
using Xenon.Table; //OTable

namespace Xenon.Controls
{
    /// <summary>
    /// リストボックスの項目の描画。
    /// 
    /// 「%1%:%2%|ID|NAME」形式で設定する場合。
    /// </summary>
    public class ListboxItemDrawer_01Impl : ListboxItemDrawer
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="owner_MemoryApplication"></param>
        public ListboxItemDrawer_01Impl(MemoryApplication owner_MemoryApplication)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────


        /// <summary>
        /// 初回、リストボックスの項目１つずつに１回呼び出されます。
        /// 
        /// その後は、再描画が必要な項目だけ呼び出されます。
        /// </summary>
        /// <param nFcName="sender"></param>
        /// <param nFcName="e"></param>
        public void Perform(
            object sender,
            DrawItemEventArgs e,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Perform",log_Reports);
            //
            //

            // 項目がなければ、中断。
            if (e.Index < 0)
            {
                return;
            }


            // リストボックスの項目１つ分の背景を描画します。
            e.DrawBackground();

            // ＣＳＶＥｘＥ用に改造されたコントロールが使用されているものとします。
            CustomcontrolListbox ccLst = (CustomcontrolListbox)sender;

            //
            // 描画する文字列を作成します。
            string sItemDisplayText = this.P1_GetItemString(e.Index, ccLst, log_Reports);

            if (!log_Reports.Successful)
            {
                // 失敗していれば中断。
                goto gt_EndMethod;
            }

            //
            // 描画色のブラシ。指定しない場合はヌル。
            Brush foreBrushOrNull = this.P2_GetForeBrush(e.Index, ccLst, log_Reports);

            //
            // 妥当性判定
            Expressionv_4ADisplay err_Expressionv_ADisplay = null;
            {
                //
                // ＜validator＞要素数だけ。通常、0 or 1。
                List<Expressionv_3FListboxValidation> ecvList_Validators = ccLst.List_Expressionv_FListboxValidation;
                foreach (Expressionv_3FListboxValidation ecv_ListboxV in ecvList_Validators)
                {

                    //
                    // ＜display＞系の数だけ。通常、1。
                    List<Expressionv_4ADisplay> ecvList_ADisplay = ecv_ListboxV.List_Expressionv_ADisplay;
                    foreach (Expressionv_4ADisplay ecv_ADisplay in ecvList_ADisplay)
                    {
                        err_Expressionv_ADisplay = ecv_ADisplay;

                        string sType;
                        if (ecv_ADisplay.Dictionary_SAttribute.ContainsKey(PmNames.S_TYPE.Name_Pm))
                        {
                            sType = ecv_ADisplay.Dictionary_SAttribute[PmNames.S_TYPE.Name_Pm];
                        }
                        else
                        {
                            sType = "＜エラー＞";
                        }

                        if ("DSP_空レコード" == sType.Trim())
                        {
                            //
                            // 子要素が true を返してきたら、
                            // グレー表示。


                            // ★★★★★★★★★★★この中で時間食ってる。
                            DataRowView dataRowView = (DataRowView)ccLst.Items[e.Index];
                            ecv_ADisplay.SetDataRow(dataRowView.Row);
                            string sResult = ecv_ADisplay.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                            // ★★★★★★★★★★★この中で時間食ってる。




                            bool bResult;
                            if (Boolean.TryParse(sResult, out bResult))
                            {
                                //
                                // 変換成功

                                if (bResult)
                                {
                                    //
                                    // 空レコードなら
                                    foreBrushOrNull = this.Owner_MemoryApplication.MemoryBrushes.GetByName("BRUSH_listItem_emptyRecord");
                                }
                                else
                                {
                                    //
                                    // 空レコードではないなら
                                    foreBrushOrNull = this.Owner_MemoryApplication.MemoryBrushes.GetByName("BRUSH_listItem_existsData");
                                }
                            }
                            else
                            {
                                //
                                // 変換失敗

                                foreBrushOrNull = this.Owner_MemoryApplication.MemoryBrushes.GetByName("BRUSH_listItem_error");

                                // ループから脱出
                                goto gt_EndLoop_Validation;
                            }
                        }
                        else
                        {
                            //
                            // エラー。
                            goto gt_Error_UndefinedType;
                        }
                    }
                }
            }
        gt_EndLoop_Validation:
            //
            //

            //
            // 項目のテキストを描画。
            //
            this.P4_DrawString(sender, e, sItemDisplayText, foreBrushOrNull, ccLst, log_Reports);

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedType:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                //コントロールの型名
                if (err_Expressionv_ADisplay.Dictionary_SAttribute.ContainsKey(PmNames.S_TYPE.Name_Pm))
                {
                    tmpl.SetParameter(1, err_Expressionv_ADisplay.Dictionary_SAttribute[PmNames.S_TYPE.Name_Pm], log_Reports);
                }
                else
                {
                    tmpl.SetParameter(1, "ヌル", log_Reports);
                }

                this.Owner_MemoryApplication.CreateErrorReport("Er:534;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の文字列。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cctLst"></param>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        public virtual string P1_GetItemString(
            int nCurIx,
            CustomcontrolListbox cctLst,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "P1_GetItemLabel",log_Reports);
            //
            //
            string sDisplayText;


            // ↓2012-02-02 追加
            if (nCurIx < cctLst.List_SText_Display.Count)
            {
                sDisplayText = cctLst.List_SText_Display[nCurIx];
                if (null != sDisplayText)
                {
                    goto gt_EndMethod;
                }
            }

            //
            // 項目の数だけ呼び出される。
            // 処理はできるだけ軽く。


            //
            // リストボックスには、テーブルをセットしています。
            // 取り出されるものは「行」になります。
            //
            // DataRowをセットしましたが、取り出されるのは DataRowViewになるようです。
            DataRowView dataRowView = (DataRowView)cctLst.Items[nCurIx];
            XenonTable o_Table = cctLst.XenonTable_Datasource;

            if (null == o_Table)
            {
                // データソースがセットされていない場合。
                goto gt_Error_10;
            }
            else if (!log_Reports.Successful)
            {
                goto gt_Error_20;
            }


            //
            // 使われ方として、
            // リストボックスの oValue は、データテーブルであることが多い。
            //
            // その場合、HTMLのような、リストボックスからvalue値を取ると数字が返ってくる、ということがない。
            //

            PipeSeparatedString sPipes = new PipeSeparatedStringImpl();

            sDisplayText = sPipes.Perform(
                cctLst.SItemDisplayFormat,
                dataRowView,
                o_Table,
                log_Reports
                );

            if (!log_Reports.Successful)
            {
                sDisplayText = "(エラー発生中)";
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_10:
            {
                sDisplayText = null;// "(Err10)早すぎロード";//"[" + ccLst .ControlCommon.Expression_Name_Control.E_Execute(null)+ "]リストボックスにデータソース・テーブルが指定されていませんでした)");

                // 項目数だけエラーダイアログボックスが出てくるので、省略。
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_20:
            {
                sDisplayText = "(リストボックスにDataSourceTableが指定されていません)";

                // 項目数だけエラーダイアログボックスが出てくるので、省略。
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            // ↓2012-02-02 追加
            while (cctLst.List_SText_Display.Count <= nCurIx)
            {
                cctLst.List_SText_Display.Add(null);
            }
            cctLst.List_SText_Display[nCurIx] = sDisplayText;

            pg_Method.EndMethod(log_Reports);
            return sDisplayText;
        }

        //────────────────────────────────────────

        public virtual string P2b_GetStyleName(
            int nCurIx, CustomcontrolListbox ccListbox, Log_Reports log_Reports)
        {
            return "";
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curIx"></param>
        /// <param name="ccLst"></param>
        /// <param name="log_Reports"></param>
        /// <returns>指定しない場合はヌル。</returns>
        public Brush P2_GetForeBrush(//virtual
            int nCurIx,
            CustomcontrolListbox ccLst,
            Log_Reports log_Reports
            )
        {
            //
            // "banana|apple"など、スタイルの名称を予定。
            string sStyleAttrNames = this.P2b_GetStyleName(nCurIx, ccLst, log_Reports);//ok


            Brush brush;


            // ↓2012-02-03 追加
            if (nCurIx < ccLst.List_ForeBrush.Count)
            {
                brush = ccLst.List_ForeBrush[nCurIx];
                if (null != brush)
                {
                    goto gt_EndMethod;
                }
            }


            // スタイルを読み取りたい。
            if (this.Owner_MemoryApplication.MemoryStyles.Dictionary_RecordStyle.ContainsKey(sStyleAttrNames))
            {
                RecordXenonStyle sStyleRec = this.Owner_MemoryApplication.MemoryStyles.Dictionary_RecordStyle[sStyleAttrNames];

                XenonStyle o_Style = new XToMemory_Style().Parse(
                    sStyleRec.Style,
                    log_Reports
                    );

                if (null != o_Style.ForeXenonColor)
                {
                    // 前景色の指定があれば。

                    //
                    // 指定の色のブラシを作成。
                    brush = this.Owner_MemoryApplication.MemoryBrushes.GetByStyle(o_Style);
                }
                else
                {
                    // 前景色の指定がなければ。

                    //
                    // ブラシ変更なし。
                    brush = null;
                }
            }
            else
            {
                // 前景色で。

                //
                // ブラシ変更なし。
                brush = null;
            }

            //
        //
        //
        //
        gt_EndMethod:

            // ↓2012-02-03 追加
            while (ccLst.List_ForeBrush.Count <= nCurIx)
            {
                ccLst.List_ForeBrush.Add(null);
            }
            ccLst.List_ForeBrush[nCurIx] = brush;


            return brush;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="displayText"></param>
        /// <param name="foreBrushOrNull">指定しない場合はヌル。</param>
        /// <param name="cctLst"></param>
        /// <param name="log_Reports"></param>
        public virtual void P4_DrawString(
            object sender,
            DrawItemEventArgs e,
            string sDisplayText,
            Brush foreBrushOrNull,
            CustomcontrolListbox cctLst,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "P4_Main",log_Reports);
            //
            //

            ListBox pclst = (ListBox)sender;

            bool bForeBrushCreated = false;
            Brush foreBrush;
            Exception err_Excp;

            if (log_Reports.Successful)
            {
                // 正常時

                //
                // 文字列の描画
                try
                {
                    if (null == foreBrushOrNull)
                    {
                        // スタイルシートで設定しないとき

                        if (e.State == DrawItemState.Selected)
                        {
                            // 選択項目

                            // 背景色が濃い色と想定。
                            foreBrush = Brushes.White;
                        }
                        else if (e.State == DrawItemState.None)
                        {
                            // 非選択項目

                            // 無視
                            foreBrush = new SolidBrush(e.ForeColor);
                            bForeBrushCreated = true;
                        }
                        else
                        {
                            //無視
                            foreBrush = new SolidBrush(e.ForeColor);
                            bForeBrushCreated = true;
                        }
                    }
                    else
                    {
                        // スタイルシートで設定するとき

                        if (e.State == DrawItemState.Selected)
                        {
                            // 選択項目

                            // 背景色が濃い色と想定。
                            foreBrush = Brushes.White;
                        }
                        else if (e.State == DrawItemState.None)
                        {
                            // 非選択項目

                            foreBrush = foreBrushOrNull;
                        }
                        else
                        {
                            // 無視
                            foreBrush = new SolidBrush(e.ForeColor);
                            bForeBrushCreated = true;
                        }
                    }

                    e.Graphics.DrawString(sDisplayText, e.Font, foreBrush, e.Bounds);
                }
                catch (ArgumentException ex)
                {
                    foreBrush = null;
                    err_Excp = ex;
                    goto gt_Error_ArgumentException;
                }

                //
                // 後始末
                if (bForeBrushCreated)
                {
                    foreBrush.Dispose();
                }

                // フォーカスを示す四角形を描画
                e.DrawFocusRectangle();
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_ArgumentException:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sDisplayText, log_Reports);//表示テキスト
                tmpl.SetParameter(2, e.Font.ToString(), log_Reports);//フォント名
                tmpl.SetParameter(3, foreBrush.ToString(), log_Reports);//前景ブラシ名
                tmpl.SetParameter(4, e.Bounds.ToString(), log_Reports);//矩形位置とサイズ
                tmpl.SetParameter(5, Log_RecordReportsImpl.ToMessage_Exception(err_Excp), log_Reports);//例外メッセージ

                this.Owner_MemoryApplication.CreateErrorReport("Er:535;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// アプリケーション・モデル。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            set
            {
                owner_MemoryApplication = value;
            }
            get
            {
                return owner_MemoryApplication;
            }
        }

        //────────────────────────────────────────
        #endregion

        

    }


}
