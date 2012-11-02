using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace Xenon.Lib
{



    public class Memory1Application_PartsnumputImpl : Memory1Application_Partsnumput
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Memory1Application_PartsnumputImpl()
        {
            this.controldialogOpenfileBg = new System.Windows.Forms.OpenFileDialog();
            this.ScaleImg = 1;
            this.nameValueDic = new Dictionary<string, int>();
            this.BgLocationScaled = new Point();

            this.MemoryOperationmode = new Memory2Operationmode_NormalImpl();//this

            this.mouseDragModeEnum = EnumMousedragmode.None;
            this.layerDic = new Dictionary<int, List<Memory4bSpritePartsnumber>>();
            this.list_NameGroup = new List<string>();
            this.dictionary_MemoryPartsnumbergroupImpl = new Dictionary<string, Memory4aPartsnumbersymbolspritesImpl>();
            this.sGroupNameArray = new string[0];
            this.sFpath_Csv = "";
            this.sFpath_BgPng = "";
            this.BgOpaque = 0.5F;
            this.PreScale = 1;
            this.Count_Creates = 1;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void ChooseFile_PngCsv( Form form )
        {
            OpenFileDialog openFileDialog = this.ControldialogOpenfileBg;

            openFileDialog.InitialDirectory = Application.StartupPath;
            DialogResult result = openFileDialog.ShowDialog(form);

            if (result == DialogResult.OK)
            {
                //絶対ファイルパス
                string filepathabsolute = openFileDialog.FileName;

                //拡張子
                string extension = System.IO.Path.GetExtension(filepathabsolute);
                if (".png" == extension)
                {
                    //PNGのファイルパス
                    this.Delegate_OnPngOpened(filepathabsolute, form );
                }
                else if (".csv" == extension)
                {
                    //CSVのファイルパス
                    this.Delegate_OnCsvOpened(filepathabsolute, form );
                }
            }
            else if (result == DialogResult.Cancel)
            {
                //変更なし
            }
            else
            {
                //ファイルチューザーのエラー？
                this.Delegate_OnErrorFilechooser( form );
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// PNGと、CSVを保存します。
        /// 
        /// 絵を作成するためにキャンバスを利用します。
        /// 
        /// </summary>
        /// <param name="form1"></param>
        public void Save()
        {
            if (null != this.Bitmap_Bg)
            {
                // ファイル名を適当に作成。
                string name_File;
                {
                    StringBuilder s = new StringBuilder();
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
                    //拡張子は付けない。
                    name_File = s.ToString();
                }

                // 原画PNG
                {
                    Bitmap bmSrc = new Bitmap(this.Bitmap_Bg.Width, this.Bitmap_Bg.Height);

                    Graphics g = Graphics.FromImage(bmSrc);

                    float nOldOpaque = this.BgOpaque;
                    this.BgOpaque = 1.0F;
                    //ucCanvas1.PaintBackground(g, false, 1.0F);//等倍
                    this.Delegate_OnRequestPaintBackground(g, false, 1.0F);//等倍
                    this.BgOpaque = nOldOpaque;

                    g.Dispose();

                    // 原画PNGファイル名
                    StringBuilder sPngSrc = new StringBuilder();
                    {
                        sPngSrc.Append(Application.StartupPath);
                        // .exeの入っているフォルダーに Save フォルダーを置くこと。
                        sPngSrc.Append("\\Save\\");

                        sPngSrc.Append(name_File);
                        sPngSrc.Append(".png");
                    }

                    // 画像の保存
                    try
                    {
                        bmSrc.Save(sPngSrc.ToString(), System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "エラー");
                    }
                }

                // 結合PNG
                {
                    // TODO 拡大のし過ぎに注意。
                    float scale2 = this.ScaleImg;
                    if (2.0 < scale2)
                    {
                        scale2 = 2.0f;
                    }

                    Bitmap bmDst = new Bitmap(
                        this.Bitmap_Bg.Width * (int)scale2,
                        this.Bitmap_Bg.Height * (int)scale2
                        );

                    //imgのGraphicsオブジェクトを取得
                    Graphics g = Graphics.FromImage(bmDst);

                    this.Delegate_OnRequestPaintBackground(g, false, scale2);

                    this.Delegate_OnRequestPaintListsprite(g, false, scale2);

                    g.Dispose();


                    // 結合PNGファイル名
                    StringBuilder sPngDst = new StringBuilder();
                    {
                        sPngDst.Append(Application.StartupPath);
                        // .exeの入っているフォルダーに Save フォルダーを置くこと。
                        sPngDst.Append("\\Save\\");

                        sPngDst.Append(name_File);
                        sPngDst.Append("#Graph.png");
                    }

                    // 画像の保存
                    try
                    {
                        bmDst.Save(sPngDst.ToString(), System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "エラー");
                    }
                }

                // CSV
                {
                    // CSVファイル名
                    StringBuilder filepathabsolute_Csv = new StringBuilder();
                    {
                        filepathabsolute_Csv.Append(Application.StartupPath);
                        // .exeの入っているフォルダーに Save フォルダーを置くこと。
                        filepathabsolute_Csv.Append("\\Save\\");

                        filepathabsolute_Csv.Append(name_File);
                        filepathabsolute_Csv.Append(".csv");
                    }

                    // CSVの保存
                    bool bDisplayExecute_old = this.IsDisplayExecute;
                    this.IsDisplayExecute = false;
                    string out_ErrorMessage;
                    this.Delegate_OnRequestWriteCsv(out out_ErrorMessage, filepathabsolute_Csv.ToString());
                    this.IsDisplayExecute = bDisplayExecute_old;

                    if ("" != out_ErrorMessage)
                    {
                        MessageBox.Show(out_ErrorMessage, "エラー");
                    }
                    else
                    {
                        this.IsChangedContents = false;
                    }
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 番号を追加します。
        /// </summary>
        /// <param name="mNum"></param>
        public void AddPartsnumbersprite(Memory4bSpritePartsnumber mNum, bool bLoadingNow, Memory1Application_Partsnumput memoryApplication_Partsnumput)
        {
            if (!this.DictionaryLayer.ContainsKey(mNum.Number_Layer))
            {
                List<Memory4bSpritePartsnumber> mNumList = new List<Memory4bSpritePartsnumber>();
                mNumList.Add(mNum);
                this.DictionaryLayer.Add(mNum.Number_Layer, mNumList);
            }
            else
            {
                this.DictionaryLayer[mNum.Number_Layer].Add(mNum);
            }


            if (!bLoadingNow)
            {
                memoryApplication_Partsnumput.IsChangedContents = true;
            }
        }

        public void ClearNumbers(bool bLoadingNow, Memory1Application_Partsnumput memoryApplication_Partsnumput)
        {
            this.layerDic.Clear();
            if (!bLoadingNow)
            {
                memoryApplication_Partsnumput.IsChangedContents = true;
            }
        }

        public int Count_Partsnumbersprite
        {
            get
            {
                int nTotal = 0;
                foreach (List<Memory4bSpritePartsnumber> mList in this.layerDic.Values)
                {
                    nTotal += mList.Count;
                }
                return nTotal;
            }
        }

        //────────────────────────────────────────

        public void RemovePartsnumberspriteAt(int selectedIndex, Memory1Application_Partsnumput memoryApplication_Partsnumput)
        {
            this.List_VisiblePartsnumbersprite.RemoveAt(selectedIndex);
            memoryApplication_Partsnumput.IsChangedContents = true;
        }

        //────────────────────────────────────────

        public void SetText_SpritePartsnumber(Memory4bSpritePartsnumber mNum, string sText, Memory1Application_Partsnumput memoryApplication_Partsnumput)
        {
            if (mNum.Text != sText)
            {
                mNum.Text = sText;
                memoryApplication_Partsnumput.IsChangedContents = true;
            }
        }

        //────────────────────────────────────────

        public void MovePartsnumbersprite(Memory4bSpritePartsnumber mNum, float dx, float dy, float nScale, Memory1Application_Partsnumput memoryApplication_Partsnumput)
        {
            // 背景画像上のスプライト位置
            mNum.LocationOnBackgroundActual = new PointF(
                mNum.LocationOnBackgroundActual.X + dx / nScale,
                mNum.LocationOnBackgroundActual.Y + dy / nScale
                );
            //ystem.Console.WriteLine("移動前("+old.X+","+old.Y+")　移動後("+mNum.LocationOnBackgroundActual.X+","+mNum.LocationOnBackgroundActual.Y+")");

            mNum.Delegate_OnChangeSprite_Partsnumber(mNum, nScale);//, ucCanvas
            memoryApplication_Partsnumput.IsChangedContents = true;
        }

        //────────────────────────────────────────

        public void AddNewLayer(out int nNewLayer)
        {
            List<int> numbers = new List<int>();

            foreach (int nLayer in this.DictionaryLayer.Keys)
            {
                numbers.Add(nLayer);
            }

            int[] array = numbers.ToArray();
            Array.Sort(array);

            nNewLayer = 0;
            foreach (int nL in array)
            {
                if (nL < 0)
                {
                    // 無視
                }
                else if (nNewLayer == nL)
                {
                    nNewLayer++;
                }
            }

            this.DictionaryLayer.Add(nNewLayer, new List<Memory4bSpritePartsnumber>());
        }

        //────────────────────────────────────────

        /// <summary>
        /// グルーピング
        /// </summary>
        public void Grouping(Memory1Application_Partsnumput memoryApplication_Partsnumput)
        {

            this.list_NameGroup.Clear();

            this.dictionary_MemoryPartsnumbergroupImpl.Clear();

            foreach (Memory4bSpritePartsnumber memSpritePartnumVisible in this.List_VisiblePartsnumbersprite)
            {
                // 書式からグループ分け。
                if (memSpritePartnumVisible.IsDefinitionExpression)
                {
                    if (dictionary_MemoryPartsnumbergroupImpl.ContainsKey(memSpritePartnumVisible.Name_Symbol))
                    {
                        // 「a=1000」など定義文が、既に登録されていた場合。
                        Memory4aPartsnumbersymbolspritesImpl memSymboldefinition = dictionary_MemoryPartsnumbergroupImpl[memSpritePartnumVisible.Name_Symbol];
                        memSymboldefinition.MemoryPartsnumbersprite_Symboldefinition = memSpritePartnumVisible;
                    }
                    else
                    {
                        // 「a=1000」など、未登録の定義文の場合。
                        Memory4aPartsnumbersymbolspritesImpl memSymboldefinition = new Memory4aPartsnumbersymbolspritesImpl();
                        memSymboldefinition.MemoryPartsnumbersprite_Symboldefinition = memSpritePartnumVisible;
                        dictionary_MemoryPartsnumbergroupImpl.Add(memSpritePartnumVisible.Name_Symbol, memSymboldefinition);
                        list_NameGroup.Add(memSpritePartnumVisible.Name_Symbol);
                    }
                }
                else
                {
                    // 「b+1」など。
                    Memory4aPartsnumbersymbolspritesImpl memSpriteExpression;
                    if (dictionary_MemoryPartsnumbergroupImpl.ContainsKey(memSpritePartnumVisible.Name_Symbol))
                    {
                        memSpriteExpression = dictionary_MemoryPartsnumbergroupImpl[memSpritePartnumVisible.Name_Symbol];
                    }
                    else
                    {
                        memSpriteExpression = new Memory4aPartsnumbersymbolspritesImpl();
                        dictionary_MemoryPartsnumbergroupImpl.Add(memSpritePartnumVisible.Name_Symbol, memSpriteExpression);
                        list_NameGroup.Add(memSpritePartnumVisible.Name_Symbol);
                    }

                    memSpriteExpression.List_MemoryPartsnumbersprite_Expression.Add(memSpritePartnumVisible);
                }
            }

            this.sGroupNameArray = this.List_NameGroup.ToArray();
            Array.Sort(sGroupNameArray);

            // 数値計算
            foreach (string sGroupName in this.Array_NameGroup)
            {
                Memory4aPartsnumbersymbolspritesImpl moGroup = this.Dictionary_MemoryPartsnumbergroupImpl[sGroupName];

                // 名前定義
                if (memoryApplication_Partsnumput.IsDisplayExecute)
                {
                    moGroup.MemoryPartsnumbersprite_Symboldefinition.Parse_CalculateExpression(memoryApplication_Partsnumput);
                }

                // Num要素
                foreach (Memory4bSpritePartsnumber mNum in moGroup.List_MemoryPartsnumbersprite_Expression)
                {
                    if (memoryApplication_Partsnumput.IsDisplayExecute)
                    {
                        mNum.Parse_CalculateExpression(memoryApplication_Partsnumput);
                    }
                }

            }

        }

        //────────────────────────────────────────

        public void PaintSprite(
            Graphics g, Memory4bSpritePartsnumber memSprNum, bool isOnWindow, float scale2)
        {

            if (this.IsDisplayExecute && memSprNum.IsDefinitionExpression)
            {
                // 数値表示モードでは、名前定義は表示しません。
                goto process_end;
            }

            if (memSprNum.IsDirty || memSprNum.Scale != scale2)
            {
                memSprNum.Delegate_OnChangeSprite_Partsnumber(memSprNum, scale2);//, numPutUc
            }

            Rectangle boundsCircle;
            if (isOnWindow)
            {
                boundsCircle = new Rectangle(
                        memSprNum.BoundsCircleScaledOnBackground.X + (int)this.BgLocationScaled.X,
                        memSprNum.BoundsCircleScaledOnBackground.Y + (int)this.BgLocationScaled.Y,
                        memSprNum.BoundsCircleScaledOnBackground.Width,
                        memSprNum.BoundsCircleScaledOnBackground.Height
                        );
            }
            else
            {
                boundsCircle = memSprNum.BoundsCircleScaledOnBackground;
            }

            Rectangle boundsText;
            if (isOnWindow)
            {
                boundsText = new Rectangle(
                        memSprNum.BoundsTextScaledOnBackground.X + (int)this.BgLocationScaled.X,
                        memSprNum.BoundsTextScaledOnBackground.Y + (int)this.BgLocationScaled.Y,
                        memSprNum.BoundsTextScaledOnBackground.Width,
                        memSprNum.BoundsTextScaledOnBackground.Height
                    );
            }
            else
            {
                boundsText = new Rectangle(
                    memSprNum.BoundsTextScaledOnBackground.X,
                    memSprNum.BoundsTextScaledOnBackground.Y,
                    memSprNum.BoundsTextScaledOnBackground.Width,
                    memSprNum.BoundsTextScaledOnBackground.Height
                    );
            }


            //// 番号スプライトのサイズ
            string sText = memSprNum.GetText(true, this);

            // 後ろに、少し大きめの丸を塗ります。
            Brush backBrush;
            if (memSprNum.IsMouseTarget)
            {
                backBrush = Brushes.YellowGreen;
            }
            else
            {
                backBrush = memSprNum.BrushBackground;
            }
            g.FillEllipse(backBrush, boundsCircle.X, boundsCircle.Y, boundsCircle.Width, boundsCircle.Height);
            g.DrawEllipse(memSprNum.PenForeground, boundsCircle.X, boundsCircle.Y, boundsCircle.Width, boundsCircle.Height);


            // 影
            g.DrawString(
                sText,
                memSprNum.Font,
                Brushes.Black,
                boundsText.Location
                );
            boundsText.Offset(-1, -1);
            // 文字
            g.DrawString(
                sText,
                memSprNum.Font,
                Brushes.White,
                boundsText.Location
                );

            goto process_end;
        //
        //
        //
        //
        process_end:
            ;
        }

        //────────────────────────────────────────

        /// <summary>
        /// [乗せる画像]の描画
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bOnWindow"></param>
        /// <param name="scale2"></param>
        public void PaintListsprite(Graphics g, bool bOnWindow, float scale2)
        {
            foreach (Memory4bSpritePartsnumber mNum in this.List_VisiblePartsnumbersprite)
            {
                this.PaintSprite(g, mNum, bOnWindow, scale2);
            }
        }

        //────────────────────────────────────────

        public void DirtyAllNums()
        {
            foreach (Memory4bSpritePartsnumber mNum in this.List_VisiblePartsnumbersprite)
            {
                mNum.IsDirty = true;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public DELEGATE_OnRequestPaintBackground delegate_OnRequestPaintBackground;

        public DELEGATE_OnRequestPaintBackground Delegate_OnRequestPaintBackground
        {
            get
            {
                return this.delegate_OnRequestPaintBackground;
            }
            set
            {
                this.delegate_OnRequestPaintBackground = value;
            }
        }

        //────────────────────────────────────────

        public DELEGATE_OnRequestPaintListsprite delegate_OnRequestPaintListsprite;

        public DELEGATE_OnRequestPaintListsprite Delegate_OnRequestPaintListsprite
        {
            get
            {
                return this.delegate_OnRequestPaintListsprite;
            }
            set
            {
                this.delegate_OnRequestPaintListsprite = value;
            }
        }

        //────────────────────────────────────────

        public DELEGATE_OnRequestWriteCsv delegate_OnRequestWriteCsv;

        public DELEGATE_OnRequestWriteCsv Delegate_OnRequestWriteCsv
        {
            get
            {
                return this.delegate_OnRequestWriteCsv;
            }
            set
            {
                this.delegate_OnRequestWriteCsv = value;
            }
        }

        //────────────────────────────────────────

        public DELEGATE_OnChanged_SomeContents delegate_OnChanged_SomeContents;

        public DELEGATE_OnChanged_SomeContents Delegate_OnChanged_SomeContents
        {
            get
            {
                return this.delegate_OnChanged_SomeContents;
            }
            set
            {
                this.delegate_OnChanged_SomeContents = value;
            }
        }

        //────────────────────────────────────────

        public DELEGATE_OnOpened_SomeFiles delegate_OnOpened_SomeFiles;

        public DELEGATE_OnOpened_SomeFiles Delegate_OnOpened_SomeFiles
        {
            get
            {
                return this.delegate_OnOpened_SomeFiles;
            }
            set
            {
                this.delegate_OnOpened_SomeFiles = value;
            }
        }

        //────────────────────────────────────────
        //
        // コントロール
        //

        private System.Windows.Forms.OpenFileDialog controldialogOpenfileBg;

        /// <summary>
        /// ファイルオープン・ダイアログ。
        /// </summary>
        public OpenFileDialog ControldialogOpenfileBg
        {
            get
            {
                return this.controldialogOpenfileBg;
            }
        }

        //────────────────────────────────────────

        private Form form;

        public Form Form
        {
            get
            {
                return this.form;
            }
            set
            {
                this.form = value;
            }
        }

        //────────────────────────────────────────
        //
        // デリゲーター
        //

        public DELEGATE_OnPngOpened delegate_OnPngOpened;

        public DELEGATE_OnPngOpened Delegate_OnPngOpened
        {
            get
            {
                return this.delegate_OnPngOpened;
            }
            set
            {
                this.delegate_OnPngOpened = value;
            }
        }

        //────────────────────────────────────────

        public DELEGATE_OnCsvOpened delegate_OnCsvOpened;

        public DELEGATE_OnCsvOpened Delegate_OnCsvOpened
        {
            get
            {
                return this.delegate_OnCsvOpened;
            }
            set
            {
                this.delegate_OnCsvOpened = value;
            }
        }

        //────────────────────────────────────────

        public DELEGATE_OnErrorFilechooser delegate_OnErrorFilechooser;

        public DELEGATE_OnErrorFilechooser Delegate_OnErrorFilechooser
        {
            get
            {
                return this.delegate_OnErrorFilechooser;
            }
            set
            {
                this.delegate_OnErrorFilechooser = value;
            }
        }

        //────────────────────────────────────────

        public DELEGATE_OnSave delegate_OnSave;

        public DELEGATE_OnSave Delegate_OnSave
        {
            get
            {
                return this.delegate_OnSave;
            }
            set
            {
                this.delegate_OnSave = value;
            }
        }

        //────────────────────────────────────────

        public DELEGATE_OnPopupExplain delegate_OnPopupExplain;

        public DELEGATE_OnPopupExplain Delegate_OnPopupExplain
        {
            get
            {
                return this.delegate_OnPopupExplain;
            }
            set
            {
                this.delegate_OnPopupExplain = value;
            }
        }

        //────────────────────────────────────────

        protected Bitmap bitmap_Bg;

        /// <summary>
        /// 背景画像。
        /// </summary>
        public Bitmap Bitmap_Bg
        {
            get
            {
                return this.bitmap_Bg;
            }
            set
            {
                bitmap_Bg = value;
            }
        }

        //────────────────────────────────────────

        private bool bChangedContents;

        /// <summary>
        /// 内容を変更したら真。セーブしたら偽。
        /// </summary>
        public bool IsChangedContents
        {
            get
            {
                return this.bChangedContents;
            }
            set
            {
                this.bChangedContents = value;
            }
        }

        //────────────────────────────────────────

        private bool isDisplayExecute;

        /// <summary>
        /// 偽…そのまま表示
        /// 真…加算表示
        /// </summary>
        public bool IsDisplayExecute
        {
            get
            {
                return this.isDisplayExecute;
            }
            set
            {
                this.isDisplayExecute = value;
            }
        }

        //────────────────────────────────────────

        protected float scaleImg;

        /// <summary>
        /// 拡大率。
        /// </summary>
        public float ScaleImg
        {
            get
            {
                return scaleImg;
            }
            set
            {
                this.scaleImg = value;
            }
        }

        //────────────────────────────────────────

        protected PointF bgLocationScaled;

        /// <summary>
        /// 背景画像の点XY。
        /// </summary>
        public PointF BgLocationScaled
        {
            get
            {
                return bgLocationScaled;
            }
            set
            {
                bgLocationScaled = value;
            }
        }

        //────────────────────────────────────────

        private Dictionary<string, int> nameValueDic;

        public Dictionary<string, int> NameValueDic
        {
            get
            {
                return this.nameValueDic;
            }
        }

        //────────────────────────────────────────

        private Memory2Operationmode memoryOperationmode;

        /// <summary>
        /// 操作モード。
        /// </summary>
        public Memory2Operationmode MemoryOperationmode
        {
            get
            {
                return this.memoryOperationmode;
            }
            set
            {
                this.memoryOperationmode = value;
            }
        }

        //────────────────────────────────────────

        protected EnumMousedragmode mouseDragModeEnum;

        public EnumMousedragmode EnumMousedragmode
        {
            get
            {
                return this.mouseDragModeEnum;
            }
        }

        //────────────────────────────────────────

        protected bool mouseDraggingNone;

        /// <summary>
        /// マウスのドラッグをこれから始める最初なら真。
        /// </summary>
        public bool MouseDraggingNone
        {
            get
            {
                return this.mouseDraggingNone;
            }
            set
            {
                this.mouseDraggingNone = value;
            }
        }

        //────────────────────────────────────────

        protected bool mouseDragging;

        /// <summary>
        /// マウスをドラッグ中なら真。
        /// </summary>
        public bool MouseDragging
        {
            get
            {
                return this.mouseDragging;
            }
            set
            {
                this.mouseDragging = value;
            }
        }

        //────────────────────────────────────────

        protected PointF mouseDownLocation;

        /// <summary>
        /// マウス押下点XY。
        /// </summary>
        public PointF MouseDownLocation
        {
            get
            {
                return this.mouseDownLocation;
            }
            set
            {
                this.mouseDownLocation = value;
            }
        }

        //────────────────────────────────────────

        #region マウス操作

        protected PointF preDragLocation;

        /// <summary>
        /// 1つ前のドラッグ点XY。
        /// </summary>
        public PointF PreDragLocation
        {
            get
            {
                return this.preDragLocation;
            }
            set
            {
                this.preDragLocation = value;
            }
        }

        #endregion

        //────────────────────────────────────────

        protected bool bShiftKey;

        /// <summary>
        /// [Shift]キーが押されていれば真。
        /// </summary>
        public bool IsShiftkey
        {
            get
            {
                return bShiftKey;
            }
            set
            {
                bShiftKey = value;
            }
        }

        //────────────────────────────────────────

        protected bool bCtrlKey;

        /// <summary>
        /// [Ctrl]キーが押されていれば真。
        /// </summary>
        public bool IsControlkey
        {
            get
            {
                return bCtrlKey;
            }
            set
            {
                bCtrlKey = value;
            }
        }

        //────────────────────────────────────────

        protected int createsCount;

        /// <summary>
        /// 連番
        /// </summary>
        public int Count_Creates
        {
            get
            {
                return createsCount;
            }
            set
            {
                createsCount = value;
            }
        }

        //────────────────────────────────────────

        protected float preScale;

        /// <summary>
        /// 変更前の拡大率。
        /// </summary>
        public float PreScale
        {
            get
            {
                return this.preScale;
            }
            set
            {
                this.preScale = value;
            }
        }

        //────────────────────────────────────────

        protected Memory4bSpritePartsnumberImpl selectedMoSprite;

        /// <summary>
        /// 現在選択中のスプライト。未選択ならヌル。
        /// </summary>
        public Memory4bSpritePartsnumberImpl SelectedMemoryPartsnumbersprite
        {
            get
            {
                return selectedMoSprite;
            }
            set
            {
                selectedMoSprite = value;
            }
        }

        //────────────────────────────────────────

        private string sFpath_Csv;

        public string Filepath_Csv
        {
            get
            {
                return this.sFpath_Csv;
            }
            set
            {
                this.sFpath_Csv = value;
            }
        }

        //────────────────────────────────────────

        private string sFpath_BgPng;

        public string Filepath_BgPng
        {
            get
            {
                return this.sFpath_BgPng;
            }
            set
            {
                this.sFpath_BgPng = value;
            }
        }

        //────────────────────────────────────────

        private Memory4bSpritePartsnumber mouseTargetNum;

        /// <summary>
        /// マウスが指している番号。なければヌル。
        /// </summary>
        public Memory4bSpritePartsnumber MouseTargetNum
        {
            get
            {
                return this.mouseTargetNum;
            }
            set
            {
                this.mouseTargetNum = value;
            }
        }

        //────────────────────────────────────────

        private int nSelectedLayer;

        public int SelectedLayer
        {
            get
            {
                return this.nSelectedLayer;
            }
            set
            {
                this.nSelectedLayer = value;
            }
        }

        //────────────────────────────────────────

        protected Dictionary<int, List<Memory4bSpritePartsnumber>> layerDic;

        /// <summary>
        /// 番号スプライトのレイヤー別リスト。
        /// </summary>
        public Dictionary<int, List<Memory4bSpritePartsnumber>> DictionaryLayer
        {
            get
            {
                return layerDic;
            }
            set
            {
                layerDic = value;
            }
        }

        //────────────────────────────────────────

        public List<Memory4bSpritePartsnumber> List_VisiblePartsnumbersprite
        {
            get
            {
                List<Memory4bSpritePartsnumber> moNumList;
                if (this.DictionaryLayer.ContainsKey(this.SelectedLayer))
                {
                    moNumList = this.DictionaryLayer[this.SelectedLayer];
                }
                else
                {
                    moNumList = new List<Memory4bSpritePartsnumber>();
                    this.DictionaryLayer.Add(this.SelectedLayer, moNumList);
                }

                return moNumList;
            }
        }

        //────────────────────────────────────────

        private List<string> list_NameGroup;

        public List<string> List_NameGroup
        {
            get
            {
                return this.list_NameGroup;
            }
        }

        //────────────────────────────────────────

        private Dictionary<string, Memory4aPartsnumbersymbolspritesImpl> dictionary_MemoryPartsnumbergroupImpl;

        public Dictionary<string, Memory4aPartsnumbersymbolspritesImpl> Dictionary_MemoryPartsnumbergroupImpl
        {
            get
            {
                return this.dictionary_MemoryPartsnumbergroupImpl;
            }
        }

        //────────────────────────────────────────

        private string[] sGroupNameArray;

        public string[] Array_NameGroup
        {
            get
            {
                return this.sGroupNameArray;
            }
        }

        //────────────────────────────────────────

        protected float bgOpaque;

        /// <summary>
        /// 背景画像の不透明度。0.0F～1.0F。
        /// </summary>
        public float BgOpaque
        {
            get
            {
                return this.bgOpaque;
            }
            set
            {
                this.bgOpaque = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
