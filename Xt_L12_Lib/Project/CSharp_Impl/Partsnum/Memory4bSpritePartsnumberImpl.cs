using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Xenon.Lib
{
    /// <summary>
    /// 番号スプライトのデータセット。
    /// </summary>
    public class Memory4bSpritePartsnumberImpl : Memory4bSpritePartsnumber
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Memory4bSpritePartsnumberImpl()
        {
            this.text = "";
            this.name_Symbol = "";
            this.valuenumber_Symbol = "";
            this.comment = "";
            this.locationOnBackgroundActual = new Point();

            this.font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.penForeground = Pens.White;
            this.brushBackground = Brushes.Blue;
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Memory4bSpritePartsnumberImpl(string text)
        {
            this.Text = text;
            this.name_Symbol = "";
            this.valuenumber_Symbol = "";
            this.comment = "";
            this.locationOnBackgroundActual = new Point();

            this.font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.penForeground = Pens.White;
            this.brushBackground = Brushes.Blue;
            this.boundsCircleScaledOnBackground = new Rectangle();
            this.boundsTextScaledOnBackground = new Rectangle();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        private void ParseValue(out string out_Value)
        {
            string sValue = this.text.Trim();

            if (this.IsDefinitionExpression)
            {
                int nBegin = sValue.IndexOf('=');
                if (nBegin == -1)
                {
                    out_Value = "";
                    goto process_end;
                }

                if (sValue.Length <= nBegin + 1)
                {
                    out_Value = "";
                    goto process_end;
                }

                nBegin++;
                int nLast = sValue.IndexOf(':');
                if (-1 == nLast)
                {
                    out_Value = sValue.Substring(nBegin).Trim();
                }
                else
                {
                    if (nLast < nBegin)
                    {
                        //「:=」な形。
                        out_Value = sValue.Substring(nBegin).Trim();
                    }
                    else
                    {
                        out_Value = sValue.Substring(nBegin, nLast - nBegin).Trim();
                    }
                }
            }
            else
            {
                int nBegin = 0;
                int nLast = sValue.IndexOf(':');
                if (-1 == nLast)
                {
                    out_Value = sValue;
                }
                else
                {
                    out_Value = sValue.Substring(nBegin, nLast - nBegin).Trim();
                }
            }

            // 値は、「1000」か、「b+1000」といった形になっている。

            goto process_end;
        //
        //
        //
        //
        process_end:
            ;
            //this.value_Partsnumber = sResult;
        }

        //────────────────────────────────────────

        public void Parse_CalculateExpression(Memory1Application_Partsnumput memoryApplication_Partsnumput)
        {
            // 値は、「5000」「b+100」「b+0~3」といった形になっている。

            string result;
            string sValue = this.Valuenumber_Symbol.Trim();

            int nPlus = sValue.IndexOf('+');
            if (-1 == nPlus)
            {
                // 「+」が無ければ。

                int nValue;
                if (int.TryParse(sValue, out nValue))
                {
                    result = nValue.ToString();
                    if (!memoryApplication_Partsnumput.NameValueDic.ContainsKey(this.Name_Symbol.Trim()))
                    {
                        // 非既存なら。
                        memoryApplication_Partsnumput.NameValueDic.Add(this.Name_Symbol.Trim(), nValue);
                    }
                }
                else
                {
                    result = sValue;
                }
            }
            else
            {
                // 「+」が有れば。

                string sLeft = sValue.Substring(0, nPlus - 0).Trim();
                int nLeft;
                if (memoryApplication_Partsnumput.NameValueDic.ContainsKey(sLeft))
                {
                    nLeft = memoryApplication_Partsnumput.NameValueDic[sLeft];
                }
                else
                {
                    result = "エラー（" + sLeft + "=?）";
                    // #デバッグ
                    {
                        System.Console.WriteLine("↓");
                        foreach (KeyValuePair<string, int> kvP in memoryApplication_Partsnumput.NameValueDic)
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

                    result = (nLeft + nRight).ToString();

                    //ystem.Console.WriteLine("Name「"+this.SName+"」　 左「" + sLeft + "」（" + nLeft + "）＋右「" + sRight + "」（" + nRight + "）　→　「" + sResult + "」");

                    if (this.IsDefinitionExpression && !memoryApplication_Partsnumput.NameValueDic.ContainsKey(this.Name_Symbol))
                    {
                        // 名前定義で、非既存なら。
                        memoryApplication_Partsnumput.NameValueDic.Add(this.Name_Symbol, nLeft + nRight);
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
                        result = nTildeLeft.ToString() + "~";
                    }
                    else
                    {
                        // 「数字~数字」の場合。
                        int nBegin = nTilde + 1;
                        string sTildeRight = sRight.Substring(nBegin).Trim();
                        int nTildeRight;
                        int.TryParse(sTildeRight, out nTildeRight);

                        result = (nLeft + nTildeLeft).ToString() + "~" + (nLeft + nTildeRight).ToString();
                    }
                }
            }

            goto process_end;
        //
        process_end:
            this.sValueExecute = result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「b+1000」といった形を数値に変換します。
        /// </summary>
        /// <param name="moNumputImpl"></param>
        /// <returns></returns>
        public string Execute_CalculateExpression()
        {
            return this.sValueExecute;
        }

        //────────────────────────────────────────

        public string GetText( bool isHidden_Comment, Memory1Application_Partsnumput memoryApplication_Partsnumput)
        {
            StringBuilder s = new StringBuilder();

            if (memoryApplication_Partsnumput.IsDisplayExecute)
            {
                if (this.IsDefinitionExpression)
                {
                    // 名前定義
                    s.Append(this.Name_Symbol);
                    s.Append("=");
                    s.Append(this.Execute_CalculateExpression());
                }
                else
                {
                    // 番号
                    s.Append(this.Execute_CalculateExpression());
                }
            }
            else
            {
                // そのまま表示

                if (isHidden_Comment)
                {
                    // コメントは隠す場合。

                    if (this.IsDefinitionExpression)
                    {
                        // 名前定義
                        s.Append(this.Name_Symbol);
                        s.Append("=");
                        s.Append(this.Valuenumber_Symbol);
                    }
                    else
                    {
                        // 番号

                        // 値は「b+3~4」といった形。
                        s.Append(this.Valuenumber_Symbol);
                    }
                }
                else
                {
                    s.Append(this.text);
                }

            }

            return s.ToString();
        }

        //────────────────────────────────────────

        private void ParseComment(out string out_Comment)
        {
            string sValue = this.text.Trim();

            if (this.IsDefinitionExpression)
            {
                int nBegin = sValue.IndexOf(':');
                if (nBegin == -1)
                {
                    out_Comment = "";
                    goto process_end;
                }

                if (sValue.Length <= nBegin + 1)
                {
                    out_Comment = "";
                    goto process_end;
                }

                nBegin++;
                out_Comment = sValue.Substring(nBegin).Trim();
            }
            else
            {
                int nBegin = sValue.IndexOf(':');
                if (-1 == nBegin)
                {
                    out_Comment = "";
                    goto process_end;
                }

                if (sValue.Length <= nBegin + 1)
                {
                    out_Comment = "";
                    goto process_end;
                }

                nBegin++;
                out_Comment = sValue.Substring(nBegin).Trim();
            }

            goto process_end;
        //
        process_end:
            ;
        }

        //────────────────────────────────────────

        public bool Contains(Point mouse, Memory1Application_Partsnumput memoryApplication_Partsnumput )
        {
            return this.BoundsCircleScaledOnBackground.Contains(
                mouse.X - (int)memoryApplication_Partsnumput.BgLocationScaled.X,
                mouse.Y - (int)memoryApplication_Partsnumput.BgLocationScaled.Y
                );
        }

        //────────────────────────────────────────

        /// <summary>
        /// リストボックスの項目表示として利用。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.text;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private DELEGATE_OnChangeSprite_Partsnumber delegate_OnChangeSprite_Partsnumber;

        public DELEGATE_OnChangeSprite_Partsnumber Delegate_OnChangeSprite_Partsnumber
        {
            get
            {
                return this.delegate_OnChangeSprite_Partsnumber;
            }
            set
            {
                this.delegate_OnChangeSprite_Partsnumber = value;
            }
        }

        //────────────────────────────────────────

        private float scale;

        /// <summary>
        /// RefreshDataをしたときの縮尺。
        /// </summary>
        public float Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
            }
        }

        //────────────────────────────────────────

        private bool isMouseTarget;

        /// <summary>
        /// マウスに指されていれば真。
        /// </summary>
        public bool IsMouseTarget
        {
            get
            {
                return this.isMouseTarget;
            }
            set
            {
                this.isMouseTarget = value;
            }
        }

        //────────────────────────────────────────

        protected string name_Symbol;

        /// <summary>
        /// 「a=1000」といった文字列が入っている場合、「a」。
        /// 「a+0」といった文字列が入っている場合、「a」。
        /// 該当しなければ空文字列。
        /// </summary>
        public string Name_Symbol
        {
            get
            {
                return this.name_Symbol;
            }
        }

        private void ParseSymbol(out string out_Symbol)
        {
            string sValue = this.text.Trim();

            if (this.IsDefinitionExpression)
            {
                int nBegin = 0;
                int nLast = sValue.IndexOf('=');
                if (nLast == -1)
                {
                    out_Symbol = "";
                    goto process_end;
                }

                out_Symbol = sValue.Substring(nBegin, nLast - nBegin).Trim();
                //ystem.Console.WriteLine("(A) sValue=[" + sValue + "] nIx=["+nIx+"] sResult=[" + sResult + "]");
            }
            else
            {
                int nBegin = 0;
                int nLast = sValue.IndexOf('+');
                if (nLast == -1)
                {
                    out_Symbol = "";
                    goto process_end;
                }

                out_Symbol = sValue.Substring(nBegin, nLast - nBegin).Trim();
                //ystem.Console.WriteLine("(B) sValue=[" + sValue + "] nIx=[" + nIx + "] sResult=[" + sResult + "]");
            }

            goto process_end;
        //
        process_end:
            ;
        }

        //────────────────────────────────────────

        private string valuenumber_Symbol;

        /// <summary>
        /// 「a=1000:ステータス画面」といった文字列が入っている場合、「1000」。
        /// 「b+0:名前」といった文字列が入っている場合、「b+0」。
        /// 該当しなければ空文字列。
        /// </summary>
        public string Valuenumber_Symbol
        {
            get
            {
                return this.valuenumber_Symbol;
            }
        }

        //────────────────────────────────────────

        private string sValueExecute;

        //────────────────────────────────────────

        private string text;

        /// <summary>
        /// 記述されている文字列。
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                string sOld = text;

                text = value;

                if (sOld != this.text)
                {
                    // 変更したら

                    // 名前
                    {
                        string result;
                        this.ParseSymbol(out result);
                        this.name_Symbol = result;
                    }

                    // 値をパースします。
                    {
                        string result;
                        this.ParseValue(out result);
                        this.valuenumber_Symbol = result;
                    }

                    // コメント
                    {
                        string result;
                        this.ParseComment(out result);
                        this.comment = result;
                    }

                    this.IsDirty = true;
                }
            }
        }

        //────────────────────────────────────────

        private string comment;

        /// <summary>
        /// 「a=1000:ステータス画面」といった文字列が入っている場合、「ステータス画面」。
        /// 「b+0:名前」といった文字列が入っている場合、「名前」。
        /// 該当しなければ空文字列。
        /// </summary>
        public string Comment
        {
            get
            {
                return this.comment;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「a=1000」といった文字列が入っている場合、真。
        /// </summary>
        public bool IsDefinitionExpression
        {
            get
            {
                bool bResult;

                int nIx = this.text.IndexOf('=');
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

        protected PointF locationOnBackgroundActual;

        /// <summary>
        /// 背景画像上（on the background image）でのスプライトの点XY。等倍。
        /// </summary>
        public PointF LocationOnBackgroundActual
        {
            get
            {
                return locationOnBackgroundActual;
            }
            set
            {
                locationOnBackgroundActual = value;

                this.IsDirty = true;
            }
        }

        //────────────────────────────────────────

        protected Font font;

        /// <summary>
        /// 番号スプライトのフォント。
        /// </summary>
        public Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }

        //────────────────────────────────────────

        protected Brush brushBackground;

        /// <summary>
        /// 背面の色。
        /// </summary>
        public Brush BrushBackground
        {
            get
            {
                return brushBackground;
            }
            set
            {
                brushBackground = value;
            }
        }

        //────────────────────────────────────────

        protected Pen penForeground;

        /// <summary>
        /// 前景の色。
        /// </summary>
        public Pen PenForeground
        {
            get
            {
                return penForeground;
            }
            set
            {
                penForeground = value;
            }
        }

        //────────────────────────────────────────

        private bool isDirty;

        /// <summary>
        /// 次の描画時にデータを更新します。
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return isDirty;
            }
            set
            {
                isDirty = value;
            }
        }

        //────────────────────────────────────────

        private int number_Layer;

        /// <summary>
        /// レイヤー。
        /// </summary>
        public int Number_Layer
        {
            get
            {
                return number_Layer;
            }
            set
            {
                number_Layer = value;
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
            set
            {
                this.boundsCircleScaledOnBackground = value;
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
            set
            {
                this.boundsTextScaledOnBackground = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
