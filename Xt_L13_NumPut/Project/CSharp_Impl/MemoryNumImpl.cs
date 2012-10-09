using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;//Graphics

namespace Xenon.NumPut
{
    /// <summary>
    /// 番号スプライト
    /// </summary>
    public class MemoryNumImpl : MemoryNum
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryNumImpl()
        {
            this.sText = "";
            this.sName = "";
            this.sValue = "";
            this.sComment = "";
            this.locationOnBgActual = new Point();

            this.numSpFont = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.penFg = Pens.White;
            this.brushBg = Brushes.Blue;
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryNumImpl(string sText)
        {
            this.SText = sText;
            this.sName = "";
            this.sValue = "";
            this.sComment = "";
            this.locationOnBgActual = new Point();

            this.numSpFont = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.penFg = Pens.White;
            this.brushBg = Brushes.Blue;
            this.boundsCircleScaledOnBackground = new Rectangle();
            this.boundsTextScaledOnBackground = new Rectangle();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        private void ParseValue()
        {
            string sResult;
            string sValue = this.sText.Trim();

            if (this.BNameDefine)
            {
                int nBegin = sValue.IndexOf('=');
                if (nBegin == -1)
                {
                    sResult = "";
                    goto process_end;
                }

                if (sValue.Length <= nBegin + 1)
                {
                    sResult = "";
                    goto process_end;
                }

                nBegin++;
                int nLast = sValue.IndexOf(':');
                if (-1 == nLast)
                {
                    sResult = sValue.Substring(nBegin).Trim();
                }
                else
                {
                    if (nLast < nBegin)
                    {
                        //「:=」な形。
                        sResult = sValue.Substring(nBegin).Trim();
                    }
                    else
                    {
                        sResult = sValue.Substring(nBegin, nLast - nBegin).Trim();
                    }
                }
            }
            else
            {
                int nBegin = 0;
                int nLast = sValue.IndexOf(':');
                if (-1 == nLast)
                {
                    sResult = sValue;
                }
                else
                {
                    sResult = sValue.Substring(nBegin, nLast - nBegin).Trim();
                }
            }

            // 値は、「1000」か、「b+1000」といった形になっている。

            goto process_end;
        //
        //
        //
        //
        process_end:
            this.sValue = sResult;
        }

        //────────────────────────────────────────

        public void ParseValueExecute(Memory3ContentsImpl moNumputImpl)
        {
            string sResult = "";

            // 値は、「5000」「b+100」「b+0~3」といった形になっている。

            string sValue = this.SValue.Trim();

            int nPlus = sValue.IndexOf('+');
            if (-1 == nPlus)
            {
                // 「+」が無ければ。

                int nValue;
                if (int.TryParse(sValue, out nValue))
                {
                    sResult = nValue.ToString();
                    if (!moNumputImpl.NameValueDic.ContainsKey(this.SName.Trim()))
                    {
                        // 非既存なら。
                        moNumputImpl.NameValueDic.Add(this.SName.Trim(), nValue);
                    }
                }
                else
                {
                    sResult = sValue;
                }
            }
            else
            {
                // 「+」が有れば。

                string sLeft = sValue.Substring(0, nPlus - 0).Trim();
                int nLeft;
                if (moNumputImpl.NameValueDic.ContainsKey(sLeft))
                {
                    nLeft = moNumputImpl.NameValueDic[sLeft];
                }
                else
                {
                    sResult = "エラー（" + sLeft + "=?）";
                    // #デバッグ
                    {
                        System.Console.WriteLine("↓");
                        foreach (KeyValuePair<string, int> kvP in moNumputImpl.NameValueDic)
                        {
                            System.Console.WriteLine(kvP.Key + "＝" + kvP.Value);
                        }
                        System.Console.WriteLine("↑");
                    }
                    goto process_end;
                }


                string sRight;
                if (sValue.Length <= nPlus + 1)
                {
                    sRight = "";
                }
                else
                {
                    int nRightBegin = nPlus + 1;
                    int nLast = sValue.IndexOf(':');

                    if (-1 == nLast || sValue.Length <= nLast + 1)
                    {
                        // 「：」が無いか、空コメントがある場合。
                        sRight = sValue.Substring(nRightBegin).Trim();
                    }
                    else
                    {
                        sRight = sValue.Substring(nRightBegin, nLast - nRightBegin).Trim();
                    }
                }


                int nTilde = sRight.IndexOf('~');
                if (-1 == nTilde)
                {
                    // 「~」が無ければ。
                    int nRight;
                    int.TryParse(sRight, out nRight);

                    sResult = (nLeft + nRight).ToString();

                    //ystem.Console.WriteLine("Name「"+this.SName+"」　 左「" + sLeft + "」（" + nLeft + "）＋右「" + sRight + "」（" + nRight + "）　→　「" + sResult + "」");

                    if (this.BNameDefine && !moNumputImpl.NameValueDic.ContainsKey(this.SName))
                    {
                        // 名前定義で、非既存なら。
                        moNumputImpl.NameValueDic.Add(this.SName, nLeft + nRight);
                    }
                }
                else
                {
                    // 「~」が有れば。

                    string sTildeLeft = sRight.Substring(0, nTilde).Trim();
                    int nTildeLeft;
                    int.TryParse(sTildeLeft, out nTildeLeft);

                    if (sRight.Length <= nTilde + 1)
                    {
                        // 「~」が末尾にある場合。
                        sResult = nTildeLeft.ToString() + "~";
                    }
                    else
                    {
                        // 「数字~数字」の場合。
                        int nBegin = nTilde + 1;
                        string sTildeRight = sRight.Substring(nBegin).Trim();
                        int nTildeRight;
                        int.TryParse(sTildeRight, out nTildeRight);

                        sResult = (nLeft + nTildeLeft).ToString() + "~" + (nLeft + nTildeRight).ToString();
                    }
                }
            }

            goto process_end;
        //
        process_end:
            this.sValueExecute = sResult;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「b+1000」といった形を数値に変換します。
        /// </summary>
        /// <param name="moNumputImpl"></param>
        /// <returns></returns>
        public string SValueExecute()
        {
            return this.sValueExecute;
        }

        //────────────────────────────────────────

        public string GetText(Memory3Contents moContents, bool bHiddenComment)
        {
            StringBuilder s = new StringBuilder();

            if (moContents.BDisplayExecute)
            {
                if (this.BNameDefine)
                {
                    // 名前定義
                    s.Append(this.SName);
                    s.Append("=");
                    s.Append(this.SValueExecute());
                }
                else
                {
                    // 番号
                    s.Append(this.SValueExecute());
                }
            }
            else
            {
                // そのまま表示

                if (bHiddenComment)
                {
                    // コメントは隠す場合。

                    if (this.BNameDefine)
                    {
                        // 名前定義
                        s.Append(this.SName);
                        s.Append("=");
                        s.Append(this.SValue);
                    }
                    else
                    {
                        // 番号

                        // 値は「b+3~4」といった形。
                        s.Append(this.SValue);
                    }
                }
                else
                {
                    s.Append(this.sText);
                }

            }

            return s.ToString();
        }

        //────────────────────────────────────────

        private void ParseComment()
        {
            string sResult;
            string sValue = this.sText.Trim();

            if (this.BNameDefine)
            {
                int nBegin = sValue.IndexOf(':');
                if (nBegin == -1)
                {
                    sResult = "";
                    goto process_end;
                }

                if (sValue.Length <= nBegin + 1)
                {
                    sResult = "";
                    goto process_end;
                }

                nBegin++;
                sResult = sValue.Substring(nBegin).Trim();
            }
            else
            {
                int nBegin = sValue.IndexOf(':');
                if (-1 == nBegin)
                {
                    sResult = "";
                    goto process_end;
                }

                if (sValue.Length <= nBegin + 1)
                {
                    sResult = "";
                    goto process_end;
                }

                nBegin++;
                sResult = sValue.Substring(nBegin).Trim();
            }

            goto process_end;
        //
        //
        //
        //
        process_end:
            this.sComment = sResult;
        }

        //────────────────────────────────────────

        public void RefreshData(float scale2, UsercontrolCanvas ucCanvas)
        {
            if (ucCanvas.MoApplication.MoProject.MoContents.BDisplayExecute && this.BNameDefine)
            {
                // 数値表示モードでは、名前定義は表示しません。
                this.scale = 1.0f;
                this.boundsCircleScaledOnBackground = new Rectangle();
                this.boundsTextScaledOnBackground = new Rectangle();
                goto process_end;
            }

            this.scale = scale2;
            float x = scale2 * this.LocationOnBgActual.X;
            float y = scale2 * this.LocationOnBgActual.Y;

            // ドット絵の1ドットを最小単位にして動くよう調整。スケールは 1、または 2の倍数の整数。
            x = (float)((int)(x / scale2) * (int)scale2);
            y = (float)((int)(y / scale2) * (int)scale2);


            // 番号スプライトのサイズ
            string sText = this.GetText(ucCanvas.MoApplication.MoProject.MoContents, true);
            Graphics g = ucCanvas.CreateGraphics();
            SizeF sizeF = g.MeasureString(sText, this.NumSpFont);
            g.Dispose();


            // センタリング
            x -= sizeF.Width / 2;
            y -= sizeF.Height / 2;

            // 後ろに、少し大きめの丸を塗ります。
            this.boundsCircleScaledOnBackground = new Rectangle(
                (int)x - 4,
                (int)y - 4,
                (int)sizeF.Width + 8,
                (int)sizeF.Height + 2
                );
            this.boundsTextScaledOnBackground = new Rectangle(
                (int)x,
                (int)y,
                (int)(scale2 * sizeF.Width),
                (int)(scale2 * sizeF.Height)
                );

            goto process_end;
        //
        //
        //
        //
        process_end:
            this.BDirty = false;
        }

        //────────────────────────────────────────

        public bool Contains(Point mouse, UsercontrolCanvas ucCanvas)
        {
            return this.BoundsCircleScaledOnBackground.Contains(
                mouse.X - (int)ucCanvas.MoApplication.MoProject.MoContents.BgLocationScaled.X,
                mouse.Y - (int)ucCanvas.MoApplication.MoProject.MoContents.BgLocationScaled.Y
                );

            //return this.BoundsCircleScaledOnWindow.Contains(mouse);
        }

        //────────────────────────────────────────

        /// <summary>
        /// リストボックスの項目表示として利用。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.sText;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private float scale;

        /// <summary>
        /// RefreshDataをしたときの縮尺。
        /// </summary>
        public float Scale
        {
            get
            {
                return scale;
            }
        }

        //────────────────────────────────────────

        private bool bMouseTarget;

        /// <summary>
        /// マウスに指されていれば真。
        /// </summary>
        public bool BMouseTarget
        {
            get
            {
                return this.bMouseTarget;
            }
            set
            {
                this.bMouseTarget = value;
            }
        }

        //────────────────────────────────────────

        protected string sName;

        /// <summary>
        /// 「a=1000」といった文字列が入っている場合、「a」。
        /// 「a+0」といった文字列が入っている場合、「a」。
        /// 該当しなければ空文字列。
        /// </summary>
        public string SName
        {
            get
            {
                return this.sName;
            }
        }

        private void ParseName()
        {
            string sResult;
            string sValue = this.sText.Trim();

            if (this.BNameDefine)
            {
                int nBegin = 0;
                int nLast = sValue.IndexOf('=');
                if (nLast == -1)
                {
                    sResult = "";
                    goto process_end;
                }

                sResult = sValue.Substring(nBegin, nLast - nBegin).Trim();
                //ystem.Console.WriteLine("(A) sValue=[" + sValue + "] nIx=["+nIx+"] sResult=[" + sResult + "]");
            }
            else
            {
                int nBegin = 0;
                int nLast = sValue.IndexOf('+');
                if (nLast == -1)
                {
                    sResult = "";
                    goto process_end;
                }

                sResult = sValue.Substring(nBegin, nLast - nBegin).Trim();
                //ystem.Console.WriteLine("(B) sValue=[" + sValue + "] nIx=[" + nIx + "] sResult=[" + sResult + "]");
            }

            goto process_end;
        //
        //
        //
        //
        process_end:
            this.sName = sResult;
        }

        //────────────────────────────────────────

        private string sValue;

        //────────────────────────────────────────

        /// <summary>
        /// 「a=1000:ステータス画面」といった文字列が入っている場合、「1000」。
        /// 「b+0:名前」といった文字列が入っている場合、「b+0」。
        /// 該当しなければ空文字列。
        /// </summary>
        public string SValue
        {
            get
            {
                return this.sValue;
            }
        }

        //────────────────────────────────────────

        private string sValueExecute;

        //────────────────────────────────────────

        private string sText;

        /// <summary>
        /// 記述されている文字列。
        /// </summary>
        public string SText
        {
            get
            {
                return this.sText;
            }
            set
            {
                string sOld = sText;

                sText = value;

                if (sOld != this.sText)
                {
                    // 変更したら

                    // 名前
                    this.ParseName();
                    // 値
                    this.ParseValue();
                    // コメント
                    this.ParseComment();

                    this.BDirty = true;
                }
            }
        }

        //────────────────────────────────────────

        private string sComment;

        /// <summary>
        /// 「a=1000:ステータス画面」といった文字列が入っている場合、「ステータス画面」。
        /// 「b+0:名前」といった文字列が入っている場合、「名前」。
        /// 該当しなければ空文字列。
        /// </summary>
        public string SComment
        {
            get
            {
                return this.sComment;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「a=1000」といった文字列が入っている場合、真。
        /// </summary>
        public bool BNameDefine
        {
            get
            {
                bool bResult;

                int nIx = this.sText.IndexOf('=');
                if (nIx == -1)
                {
                    bResult = false;
                    goto process_end;
                }

                bResult = true;

                goto process_end;
            //
            //
            //
            //
            process_end:
                return bResult;
            }
        }

        //────────────────────────────────────────

        protected PointF locationOnBgActual;

        /// <summary>
        /// 背景画像上（on the background image）でのスプライトの点XY。等倍。
        /// </summary>
        public PointF LocationOnBgActual
        {
            get
            {
                return locationOnBgActual;
            }
            set
            {
                locationOnBgActual = value;

                this.BDirty = true;
            }
        }

        //────────────────────────────────────────

        protected Font numSpFont;

        /// <summary>
        /// 番号スプライトのフォント。
        /// </summary>
        public Font NumSpFont
        {
            get
            {
                return numSpFont;
            }
            set
            {
                numSpFont = value;
            }
        }

        //────────────────────────────────────────

        protected Brush brushBg;

        /// <summary>
        /// 背面の色。
        /// </summary>
        public Brush BrushBg
        {
            get
            {
                return brushBg;
            }
            set
            {
                brushBg = value;
            }
        }

        //────────────────────────────────────────

        protected Pen penFg;

        /// <summary>
        /// 前景の色。
        /// </summary>
        public Pen PenFg
        {
            get
            {
                return penFg;
            }
            set
            {
                penFg = value;
            }
        }

        //────────────────────────────────────────

        private bool bDirty;

        /// <summary>
        /// 次の描画時にデータを更新します。
        /// </summary>
        public bool BDirty
        {
            get
            {
                return bDirty;
            }
            set
            {
                bDirty = value;
            }
        }

        //────────────────────────────────────────

        private int nLayer;

        /// <summary>
        /// レイヤー。
        /// </summary>
        public int NLayer
        {
            get
            {
                return nLayer;
            }
            set
            {
                nLayer = value;
            }
        }

        //────────────────────────────────────────

        private Rectangle boundsCircleScaledOnBackground;

        public Rectangle BoundsCircleScaledOnBackground
        {
            get
            {
                return this.boundsCircleScaledOnBackground;
            }
        }

        //────────────────────────────────────────

        private Rectangle boundsTextScaledOnBackground;

        public Rectangle BoundsTextScaledOnBackground
        {
            get
            {
                return this.boundsTextScaledOnBackground;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
