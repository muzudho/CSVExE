using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

using System.Drawing;//Graphics
using System.Windows.Forms;
using Xenon.Lib;

namespace Xenon.PartsnumPut
{
    public partial class UsercontrolCanvas : UserControl
    {






        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public UsercontrolCanvas()
        {

            InitializeComponent();

            this.pcddlAlScale.Items.Add("x  1");
            this.pcddlAlScale.Items.Add("x  2");
            this.pcddlAlScale.Items.Add("x  4");
            this.pcddlAlScale.Items.Add("x  8");
            this.pcddlAlScale.Items.Add("x 16");
            this.pcddlAlScale.SelectedIndex = 0;

            this.pcddlBgOpaque.Items.Add("100");
            this.pcddlBgOpaque.Items.Add(" 75");
            this.pcddlBgOpaque.Items.Add(" 50");//初期選択
            this.pcddlBgOpaque.Items.Add(" 25");
            this.pcddlBgOpaque.SelectedIndex = 2;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void InitializeBeforeuse(Memory1Application_Partsnumput owner_MemoryApplication)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;

            this.Owner_MemoryApplication.Delegate_OnPngOpened = OnOpenBackgroundimage;
            this.Owner_MemoryApplication.Delegate_OnCsvOpened = OnCsvOpened;
            this.Owner_MemoryApplication.Delegate_OnErrorFilechooser = OnErrorFilechooser;
        }

        //────────────────────────────────────────

        /// <summary>
        /// カーソルキーで1px動かしたいときなどに。
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void MoveActiveSprite(float dx, float dy)
        {
            if (this.Owner_MemoryApplication.EnumMousedragmode == EnumMousedragmode.Move_Sprite)
            {
                //
                // 乗せる画像移動
                //
                this.MoveSp(dx, dy);
            }
            else if (this.Owner_MemoryApplication.EnumMousedragmode == EnumMousedragmode.Move_Background)
            {
                //
                // 背景画像移動
                //
                this.MoveBg(dx, dy);
            }

        }

        private void MoveSp(float dx, float dy)
        {
            if (0 <= this.pclstNums.SelectedIndex)
            {
                Memory4bSpritePartsnumber mNum = (Memory4bSpritePartsnumber)this.pclstNums.Items[this.pclstNums.SelectedIndex];

                // 移動前再描画
                this.Invalidate(
                    new Rectangle(
                        mNum.BoundsCircleScaledOnBackground.X + (int)this.Owner_MemoryApplication.BgLocationScaled.X,
                        mNum.BoundsCircleScaledOnBackground.Y + (int)this.Owner_MemoryApplication.BgLocationScaled.Y,
                        mNum.BoundsCircleScaledOnBackground.Width,
                        mNum.BoundsCircleScaledOnBackground.Height
                        ),
                    false);

                PointF old = mNum.LocationOnBackgroundActual;

                // 移動
                this.Owner_MemoryApplication.MovePartsnumbersprite(mNum, dx, dy, this.Owner_MemoryApplication.ScaleImg, this.Owner_MemoryApplication);
                this.Owner_MemoryApplication.Delegate_OnChanged_SomeContents();

                // 移動後再描画
                this.Invalidate(
                    new Rectangle(
                        mNum.BoundsCircleScaledOnBackground.X + (int)this.Owner_MemoryApplication.BgLocationScaled.X,
                        mNum.BoundsCircleScaledOnBackground.Y + (int)this.Owner_MemoryApplication.BgLocationScaled.Y,
                        mNum.BoundsCircleScaledOnBackground.Width,
                        mNum.BoundsCircleScaledOnBackground.Height
                        ),
                    false);
            }
        }

        private void MoveBg(float dx, float dy)
        {
            if (null != this.Owner_MemoryApplication)
            {
            }
            // 背景画像移動
            this.Owner_MemoryApplication.BgLocationScaled = new PointF(
                this.Owner_MemoryApplication.BgLocationScaled.X + dx,
                this.Owner_MemoryApplication.BgLocationScaled.Y + dy
                );

            this.Owner_MemoryApplication.DirtyAllNums();

            // 再描画
            this.Refresh();
        }

        public void PaintBackground(Graphics g, bool bOnWindow, float scale2)
        {
            if (null != this.Owner_MemoryApplication.Bitmap_Bg)
            {
                // ビットマップ画像の不透明度を指定します。
                System.Drawing.Imaging.ImageAttributes ia;
                {
                    System.Drawing.Imaging.ColorMatrix cm =
                        new System.Drawing.Imaging.ColorMatrix();
                    cm.Matrix00 = 1;
                    cm.Matrix11 = 1;
                    cm.Matrix22 = 1;
                    cm.Matrix33 = this.Owner_MemoryApplication.BgOpaque;//α値。0～1か？
                    cm.Matrix44 = 1;

                    //ImageAttributesオブジェクトの作成
                    ia = new System.Drawing.Imaging.ImageAttributes();
                    //ColorMatrixを設定する
                    ia.SetColorMatrix(cm);
                }
                float x = 0;
                float y = 0;
                if (bOnWindow)
                {
                    x += this.Owner_MemoryApplication.BgLocationScaled.X;
                    y += this.Owner_MemoryApplication.BgLocationScaled.Y;
                }
                float width = this.Owner_MemoryApplication.Bitmap_Bg.Width;
                float height = this.Owner_MemoryApplication.Bitmap_Bg.Height;
                Rectangle dstRect = new Rectangle((int)x, (int)y, (int)(scale2 * width), (int)(scale2 * height));

                if (!bOnWindow && this.Owner_MemoryApplication.BgOpaque < 1.0f)
                {
                    // ウィンドウの中に描画するのではない場合（書き出し時）に、
                    // 少しでも半透明になっているなら、背景色を白で塗りつぶします。

                    g.FillRectangle(
                        Brushes.White,
                        dstRect
                        );

                }

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;//ドット絵のまま拡縮するように。しかし、この指定だと半ピクセル左上にずれるバグ。
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;//半ピクセル左上にずれるバグに対応。
                g.DrawImage(
                    this.Owner_MemoryApplication.Bitmap_Bg,
                    dstRect,
                    0,
                    0,
                    width,
                    height,
                    GraphicsUnit.Pixel,
                    ia
                    );
            }
        }

        public void WriteCsv(out string out_ErrorMessage, string filepathabsolute_Csv)
        {
            out_ErrorMessage = "";
            StringBuilder sCsv = new StringBuilder();


            //sCsv.Append("NO,DISPLAY,LAYER,X,Y,FONT_SIZE,COLOR_BG,END");
            sCsv.Append("NO,TEXT,LAYER,X_LT,Y_LT,FONT_SIZE_PT,BACK_COLOR,END");
            sCsv.Append(Environment.NewLine);
            sCsv.Append("int,string,int,int,int,int,string,END");
            sCsv.Append(Environment.NewLine);
            sCsv.Append("連番,表示文字列,レイヤー,中心X,中心Y,フォントサイズ10/20,Blue/Green,END");
            sCsv.Append(Environment.NewLine);

            int no = 0;
            foreach (List<Memory4bSpritePartsnumber> list_MemPartsnumbersprite in this.Owner_MemoryApplication.DictionaryLayer.Values)
            {
                foreach (Memory4bSpritePartsnumberImpl numSp in list_MemPartsnumbersprite)
                {
                    sCsv.Append(no);
                    sCsv.Append(",");
                    sCsv.Append(numSp.GetText( false, this.Owner_MemoryApplication));
                    sCsv.Append(",");
                    sCsv.Append(numSp.Number_Layer);
                    sCsv.Append(",");
                    sCsv.Append((int)numSp.LocationOnBackgroundActual.X);//拡大時の小数点以下切捨て
                    sCsv.Append(",");
                    sCsv.Append((int)numSp.LocationOnBackgroundActual.Y);//拡大時の小数点以下切捨て
                    sCsv.Append(",");
                    sCsv.Append((int)numSp.Font.Size);
                    sCsv.Append(",");

                    if (
                        Brushes.Green == numSp.BrushBackground
                        )
                    {
                        sCsv.Append("Green");
                    }
                    else
                    {
                        sCsv.Append("Blue");
                    }
                    sCsv.Append(",END");
                    sCsv.Append(Environment.NewLine);

                    no++;
                }
            }

            sCsv.Append("EOF,,,,,,,");
            sCsv.Append(Environment.NewLine);

            try
            {
                System.IO.File.WriteAllText(filepathabsolute_Csv, sCsv.ToString(), Encoding.Default);
                //System.Console.WriteLine("ＣＳＶファイル保存：[" + filepathabsolute_Csv + "]");
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                out_ErrorMessage = e.Message;
            }
        }

        //────────────────────────────────────────

        public void ZoomUp()
        {
            ComboBox listBox = this.pcddlAlScale;

            if (listBox.SelectedIndex + 1 < listBox.Items.Count)
            {
                listBox.SelectedIndex++;
                this.Refresh();
            }
        }

        public void ZoomDown()
        {
            ComboBox listBox = this.pcddlAlScale;

            if (0 <= listBox.SelectedIndex - 1)
            {
                listBox.SelectedIndex--;
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void _CalSelectedSpriteGui(Memory4bSpritePartsnumber selectedNum)
        {

            if (null == selectedNum)
            {
                //
                // ◇選択スプライトが無い場合。
                //

                this.pctxtEdits.Text = "";
                this.pctxtEdits.Enabled = false;

                this.pclblFontSmall.Enabled = false;
                this.pcrdiFontSmall.Enabled = false;
                this.pclblFontMiddle.Enabled = false;
                this.pcrdiFontMiddle.Enabled = false;
                this.pclblFontLarge.Enabled = false;
                this.pcrdiFontLarge.Enabled = false;
                this.pclblBgcolorBlue.Enabled = false;
                this.pcrdiBgcolorBlue.Enabled = false;
                this.pclblBgcolorGreen.Enabled = false;
                this.pcrdiBgcolorGreen.Enabled = false;
            }
            else
            {
                //
                // ◇選択スプライトが有る場合。
                //
                this.pctxtEdits.Enabled = true;
                this.pctxtEdits.Text = selectedNum.Text;

                this.pclblFontSmall.Enabled = true;
                this.pcrdiFontSmall.Enabled = true;
                this.pclblFontMiddle.Enabled = true;
                this.pcrdiFontMiddle.Enabled = true;
                this.pclblFontLarge.Enabled = true;
                this.pcrdiFontLarge.Enabled = true;
                this.pclblBgcolorBlue.Enabled = true;
                this.pcrdiBgcolorBlue.Enabled = true;
                this.pclblBgcolorGreen.Enabled = true;
                this.pcrdiBgcolorGreen.Enabled = true;

                switch ((int)selectedNum.Font.Size)
                {
                    case 10:
                        this.pcrdiFontSmall.Checked = true;
                        break;
                    case 20:
                        this.pcrdiFontMiddle.Checked = true;
                        break;
                    case 40:
                        this.pcrdiFontLarge.Checked = true;
                        break;
                    default:
                        this.pcrdiFontSmall.Checked = false;
                        this.pcrdiFontMiddle.Checked = false;
                        this.pcrdiFontLarge.Checked = false;
                        break;
                }

                if (Brushes.Green == selectedNum.BrushBackground)
                {
                    this.pcrdiBgcolorGreen.Checked = true;
                }
                else if (Brushes.Blue == selectedNum.BrushBackground)
                {
                    this.pcrdiBgcolorBlue.Checked = true;
                }
                else
                {
                    this.pcrdiBgcolorGreen.Checked = false;
                    this.pcrdiBgcolorBlue.Checked = false;
                }
            }

        }

        public void After_AddSpriteList()
        {
            if (0 < this.Owner_MemoryApplication.Count_Partsnumbersprite)
            {
                this.pclblAlScale.Enabled = true;
                this.pcddlAlScale.Enabled = true;
                this.ccbtnRemoves.Enabled = true;
            }
            else
            {
                this.ccbtnRemoves.Enabled = false;
            }
        }

        public void AddNumSp(Memory4bSpritePartsnumber mNum, bool bLoadingNow)
        {

            //
            //
            this.Owner_MemoryApplication.AddPartsnumbersprite(mNum, bLoadingNow, this.Owner_MemoryApplication);

            //
            //
            ListBox pclst = this.pclstNums;
            this.PclstNums_autoInput = true;//自動入力開始
            pclst.Items.Add(mNum);
            pclst.SelectedIndex = pclst.Items.Count - 1;
            this.PclstNums_autoInput = false;//自動入力終了

            //
            //
            this.Owner_MemoryApplication.Delegate_OnChanged_SomeContents();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 選択項目を編集ボックスに表示
        /// </summary>
        private void proc001()
        {
            ListBox pclstNum = this.pclstNums;

            if (0 <= pclstNum.SelectedIndex)
            {
                //
                // ◇項目を選択している場合
                //
                this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite =
                    (Memory4bSpritePartsnumberImpl)pclstNum.Items[pclstNum.SelectedIndex];
                this._CalSelectedSpriteGui(this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite);

            }
            else
            {
                //
                // ◇項目を選択していない場合
                //
                this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite = null;
                this._CalSelectedSpriteGui(this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite);

            }
        }

        //────────────────────────────────────────

        public void OpenCsv()
        {
            if (System.IO.File.Exists(this.Owner_MemoryApplication.Filepath_Csv))
            {

                // CSVファイルが開かれた。

                List<string[]> listArraystring_Table;

                //関数2
                {
                    Function2_LoadCsv f2 = new Function2_LoadCsv();
                    f2.In_Filepathabsolute = this.Owner_MemoryApplication.Filepath_Csv;
                    //f2.In_ListMemorynumber = this.Owner_MemoryApplication.List_VisiblePartsnumbersprite;
                    f2.Perfrom();

                    if ("" != f2.Out_Errormessage)
                    {
                        MessageBox.Show(f2.Out_Errormessage, "エラー");
                        goto gt_EndMethod;
                    }

                    this.pclstLayer.Items.Clear();
                    foreach (int nKey in this.Owner_MemoryApplication.DictionaryLayer.Keys)
                    {
                        this.pclstLayer.Items.Add(nKey);
                    }

                    if (0 < this.pclstLayer.Items.Count)
                    {
                        this.pclstLayer.SelectedIndex = 0;
                    }

                    listArraystring_Table = f2.Out_ListArraystring_Table;
                }

                //関数3
                {
                    Function3_LoadCsv2 f3 = new Function3_LoadCsv2();
                    f3.In_UsercontrolCanvas = this;
                    f3.In_ListArraystring_Table = listArraystring_Table;
                    f3.Perform();

                }
            }

            goto gt_EndMethod;
        //
        gt_EndMethod:
            ;
        }

        public void ClearNumSps(bool bLoadingNow)
        {
            this.PctxtEdits_autoInput = true;//自動入力開始
            this.pctxtEdits.Text = "";
            this.PctxtEdits_autoInput = false;//自動入力終了

            this.PclstNums_autoInput = true;//自動入力開始
            this.pclstNums.Items.Clear();
            this.PclstNums_autoInput = false;//自動入力終了

            this.Owner_MemoryApplication.ClearNumbers(bLoadingNow, this.Owner_MemoryApplication);
            this.pclstLayer.Items.Clear();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 背景PNG画像を読み込まれたとき。
        /// </summary>
        private void OnOpenBackgroundimage(string filepathabsolute, Form form )
        {
            //PNGのファイルパス
            this.Owner_MemoryApplication.Filepath_BgPng = filepathabsolute;

            //
            //
            //
            //

            UsercontrolCanvas ucCanvas = this;
            Form1 form1 = (Form1)this.ParentForm;

            if (System.IO.File.Exists(this.Owner_MemoryApplication.Filepath_BgPng))
            {

                // 画像ファイルが開かれたものとして、ビットマップにする。
                try
                {
                    ucCanvas.Owner_MemoryApplication.Bitmap_Bg = new Bitmap(this.Owner_MemoryApplication.Filepath_BgPng);
                    form1.ToolStripMenuItem_BgOpen.Enabled = true;
                    ucCanvas.PclblBgOpaque.Enabled = true;
                    ucCanvas.PcddlBgOpaque.Enabled = true;
                    ucCanvas.PclblAlScale.Enabled = true;
                    ucCanvas.PcddlAlScale.Enabled = true;
                }
                catch (ArgumentException)
                {
                    // 指定したファイルが画像じゃなかった。
                    ucCanvas.Owner_MemoryApplication.Bitmap_Bg = null;
                    ucCanvas.PclblBgOpaque.Enabled = false;
                    ucCanvas.PcddlBgOpaque.Enabled = false;
                }

                this.Owner_MemoryApplication.BgLocationScaled = new PointF(150.0f, 60.0f);
            }

            //
            //
            //
            //

            // CSVファイルも予想。
            StringBuilder s = new StringBuilder();
            s.Append(System.IO.Path.GetDirectoryName(filepathabsolute));
            s.Append(System.IO.Path.DirectorySeparatorChar);
            s.Append(System.IO.Path.GetFileNameWithoutExtension(filepathabsolute));
            s.Append(".csv");
            this.Owner_MemoryApplication.Filepath_Csv = s.ToString();
            //ystem.Console.WriteLine("CSVファイル=" + sFpathCsv);

            this.OpenCsv();

            // ディレクトリー読込み
            form1.UcGraphList1.LoadDirectory(System.IO.Path.GetDirectoryName(filepathabsolute));
            form1.Memory1Application_Partsnumput.Delegate_OnOpened_SomeFiles();

        }

        private void OnCsvOpened(string filepathabsolute, Form form)
        {
            this.Owner_MemoryApplication.Filepath_Csv = filepathabsolute;
            this.OpenCsv();

            // PNGファイルも予想。
            StringBuilder s = new StringBuilder();
            s.Append(System.IO.Path.GetDirectoryName(filepathabsolute));
            s.Append(System.IO.Path.DirectorySeparatorChar);
            s.Append(System.IO.Path.GetFileNameWithoutExtension(filepathabsolute));
            s.Append(".png");
            this.Owner_MemoryApplication.Filepath_BgPng = s.ToString();
            //ystem.Console.WriteLine("PNGファイル=" + sFpathPng);

            ((Form1)form).Memory1Application_Partsnumput.Delegate_OnPngOpened(filepathabsolute, form);

            // ディレクトリー読込み
            ((Form1)form).UcGraphList1.LoadDirectory(System.IO.Path.GetDirectoryName(filepathabsolute));
            this.Owner_MemoryApplication.Delegate_OnOpened_SomeFiles();
        }

        private void OnErrorFilechooser( Form form )
        {
            ((Form1)form).ToolStripMenuItem_BgOpen.Enabled = false;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void pcbtnBg_Click(object sender, EventArgs e)
        {
        }

        private void pcddlScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != this.Owner_MemoryApplication)
            {

                // ドロップダウンリスト
                ComboBox pcddl = (ComboBox)sender;

                if (0 <= pcddl.SelectedIndex)
                {
                    string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                    if ("x  1" == sSelectedValue)
                    {
                        this.Owner_MemoryApplication.PreScale = this.Owner_MemoryApplication.ScaleImg;
                        this.Owner_MemoryApplication.ScaleImg = 1;
                    }
                    else if ("x  2" == sSelectedValue)
                    {
                        this.Owner_MemoryApplication.PreScale = this.Owner_MemoryApplication.ScaleImg;
                        this.Owner_MemoryApplication.ScaleImg = 2;
                    }
                    else if ("x  4" == sSelectedValue)
                    {
                        this.Owner_MemoryApplication.PreScale = this.Owner_MemoryApplication.ScaleImg;
                        this.Owner_MemoryApplication.ScaleImg = 4;
                    }
                    else if ("x  8" == sSelectedValue)
                    {
                        this.Owner_MemoryApplication.PreScale = this.Owner_MemoryApplication.ScaleImg;
                        this.Owner_MemoryApplication.ScaleImg = 8;
                    }
                    else if ("x 16" == sSelectedValue)
                    {
                        this.Owner_MemoryApplication.PreScale = this.Owner_MemoryApplication.ScaleImg;
                        this.Owner_MemoryApplication.ScaleImg = 16;
                    }
                    else
                    {
                        this.Owner_MemoryApplication.PreScale = this.Owner_MemoryApplication.ScaleImg;
                        this.Owner_MemoryApplication.ScaleImg = 1;
                    }
                }
                else
                {
                    // 未選択

                    this.Owner_MemoryApplication.PreScale = this.Owner_MemoryApplication.ScaleImg;
                    this.Owner_MemoryApplication.ScaleImg = 1;
                }


                // 現在見えている画面上の中心を固定するようにズーム。
                if (null != this.Owner_MemoryApplication.Bitmap_Bg)
                {

                    //
                    // 位置調整 

                    float multiple = this.Owner_MemoryApplication.ScaleImg / this.Owner_MemoryApplication.PreScale; //何倍になったか。

                    // 画面の中心に位置する、ズームされた画像上の位置（固定点）
                    float imgFixX = (this.Width / 2.0f) - this.Owner_MemoryApplication.BgLocationScaled.X;
                    float imgFixY = (this.Height / 2.0f) - this.Owner_MemoryApplication.BgLocationScaled.Y;

                    // 背景位置
                    this.Owner_MemoryApplication.BgLocationScaled = new PointF(
                        this.Owner_MemoryApplication.BgLocationScaled.X - (imgFixX * multiple - imgFixX),
                        this.Owner_MemoryApplication.BgLocationScaled.Y - (imgFixY * multiple - imgFixY)
                        );
                }

                this.Owner_MemoryApplication.DirtyAllNums();

                // 再描画
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        private void pcbtnSp_Click(object sender, EventArgs e)
        {
        }

        //────────────────────────────────────────
        //
        // マウス
        //

        private void UsercontrolCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.Owner_MemoryApplication.MouseDraggingNone = true;
            this.Owner_MemoryApplication.MouseDragging = true;
            this.Owner_MemoryApplication.MouseDownLocation = e.Location;
            this.Owner_MemoryApplication.PreDragLocation = e.Location;

            // フォーカスをコントロールから外すことで、フォーカスをフォームに戻します。
            this.ActiveControl = null;


            // スプライトと重なるか判定
            foreach (Memory4bSpritePartsnumber mNum in this.Owner_MemoryApplication.List_VisiblePartsnumbersprite)
            {
                bool bHit = mNum.Contains(e.Location, this.Owner_MemoryApplication);
                if (bHit)
                {
                    this.pclstNums.SelectedItem = mNum;
                }
            }
        }

        private void UsercontrolCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            int flag;
            if (this.Owner_MemoryApplication.IsControlkey)
            {
                // 背景画像の移動
                flag = 2;
            }
            else if (this.Owner_MemoryApplication.IsShiftkey)
            {
                // 乗せる画像の移動
                flag = 1;
            }
            else if (this.Owner_MemoryApplication.EnumMousedragmode == EnumMousedragmode.Move_Sprite)
            {
                // 乗せる画像の移動
                flag = 1;
            }
            else if (this.Owner_MemoryApplication.EnumMousedragmode == EnumMousedragmode.Move_Background)
            {
                // 背景画像の移動
                flag = 2;
            }
            else
            {
                // 移動しない
                flag = 0;
            }

            if (null != this.Owner_MemoryApplication.MouseTargetNum)
            {
                // 選択中の番号があれば。

                // 乗せる画像の移動
                flag = 1;
            }
            else
            {
                // 選択中の番号がなければ。

                // 背景画像の移動
                flag = 2;
            }

            if (1 == flag)
            {
                //
                // 乗せる画像移動
                //

                if (this.Owner_MemoryApplication.MouseDragging)
                {
                    // 前回ドラッグした位置との差分
                    float dx;
                    float dy;
                    if (this.Owner_MemoryApplication.MouseDraggingNone)
                    {
                        dx = 0;
                        dy = 0;
                        this.Owner_MemoryApplication.MouseDraggingNone = false;
                    }
                    else
                    {
                        dx = e.Location.X - this.Owner_MemoryApplication.PreDragLocation.X;
                        dy = e.Location.Y - this.Owner_MemoryApplication.PreDragLocation.Y;
                    }

                    this.MoveSp(dx, dy);

                    // ドラッグした位置
                    this.Owner_MemoryApplication.PreDragLocation = e.Location;
                }
            }
            else if (2 == flag)
            {
                //
                // 背景画像移動
                //

                if (this.Owner_MemoryApplication.MouseDragging)
                {
                    // 前回ドラッグした位置との差分
                    float dx;
                    float dy;
                    if (this.Owner_MemoryApplication.MouseDraggingNone)
                    {
                        dx = 0;
                        dy = 0;
                        this.Owner_MemoryApplication.MouseDraggingNone = false;
                    }
                    else
                    {
                        dx = e.Location.X - this.Owner_MemoryApplication.PreDragLocation.X;
                        dy = e.Location.Y - this.Owner_MemoryApplication.PreDragLocation.Y;
                    }

                    this.MoveBg(dx, dy);

                    // ドラッグした位置
                    this.Owner_MemoryApplication.PreDragLocation = e.Location;
                }
            }


            // スプライトと重なるか判定
            this.Owner_MemoryApplication.MouseTargetNum = null;
            foreach (Memory4bSpritePartsnumber mNum in this.Owner_MemoryApplication.List_VisiblePartsnumbersprite)
            {
                bool bOld = mNum.IsMouseTarget;
                mNum.IsMouseTarget = mNum.Contains(e.Location, this.Owner_MemoryApplication);
                if (mNum.IsMouseTarget)
                {
                    this.Owner_MemoryApplication.MouseTargetNum = mNum;
                }

                if (bOld != mNum.IsMouseTarget)
                {
                    this.Invalidate(
                        new Rectangle(
                            mNum.BoundsCircleScaledOnBackground.X + (int)this.Owner_MemoryApplication.BgLocationScaled.X,
                            mNum.BoundsCircleScaledOnBackground.Y + (int)this.Owner_MemoryApplication.BgLocationScaled.Y,
                            mNum.BoundsCircleScaledOnBackground.Width,
                            mNum.BoundsCircleScaledOnBackground.Height
                            ),
                        false);
                }
            }
        }

        private void UsercontrolCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            this.Owner_MemoryApplication.MouseDragging = false;
        }

        //────────────────────────────────────────

        private void UsercontrolCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (null != Owner_MemoryApplication)
            {

                // 背景画像
                this.PaintBackground(e.Graphics, true, this.Owner_MemoryApplication.ScaleImg);

                // 番号画像
                this.Owner_MemoryApplication.PaintListsprite(e.Graphics, true, this.Owner_MemoryApplication.ScaleImg);
            }
        }

        //────────────────────────────────────────

        private void pcddlOpaqueBg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null!=this.Owner_MemoryApplication)
            {
                // ドロップダウンリスト
                ComboBox pcddl = (ComboBox)sender;

                if (0 <= pcddl.SelectedIndex)
                {
                    string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                    if ("100" == sSelectedValue)
                    {
                        this.Owner_MemoryApplication.BgOpaque = 1.0F;
                    }
                    else if (" 75" == sSelectedValue)
                    {
                        this.Owner_MemoryApplication.BgOpaque = 0.75F;
                    }
                    else if (" 50" == sSelectedValue)
                    {
                        this.Owner_MemoryApplication.BgOpaque = 0.50F;
                    }
                    else if (" 25" == sSelectedValue)
                    {
                        this.Owner_MemoryApplication.BgOpaque = 0.25F;
                    }
                    else
                    {
                        this.Owner_MemoryApplication.BgOpaque = 1.0F;
                    }
                }
                else
                {
                    // 未選択

                    this.Owner_MemoryApplication.BgOpaque = 1.0F;
                }

                // 再描画
                this.Refresh();
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// [新規追加]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ccbtnAdds_Click(object sender, EventArgs e)
        {
            ListBox pclst = this.pclstNums;

            Memory4bSpritePartsnumber mNum = new Memory4bSpritePartsnumberImpl(this.Owner_MemoryApplication.Count_Creates.ToString());
            mNum.Delegate_OnChangeSprite_Partsnumber = UsercontrolCanvas_OnChangeSpritePartsnumber;

            this.Owner_MemoryApplication.Count_Creates++;

            mNum.LocationOnBackgroundActual = new PointF(
                this.Width / 2 - this.Owner_MemoryApplication.BgLocationScaled.X,
                this.Height / 2 - this.Owner_MemoryApplication.BgLocationScaled.Y
                );
            mNum.Number_Layer = this.Owner_MemoryApplication.SelectedLayer;

            this.AddNumSp(mNum, false);

            this.After_AddSpriteList();

            // 選択項目を編集ボックスに表示
            this.proc001();

            // フォームを再描画。
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// [選択項目削除]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ccbtnRemoves_Click(object sender, EventArgs e)
        {
            ListBox pclst = this.pclstNums;

            if (0 <= pclst.SelectedIndex)
            {
                int selectedIndex = pclst.SelectedIndex;//値を退避

                pclst.Items.RemoveAt(selectedIndex);
                this.Owner_MemoryApplication.RemovePartsnumberspriteAt(selectedIndex, this.Owner_MemoryApplication);
                this.Owner_MemoryApplication.Delegate_OnChanged_SomeContents();
            }

            if (pclst.Items.Count < 1)
            {
                this.ccbtnRemoves.Enabled = false;
            }

            // フォームを再描画。
            this.Refresh();
        }

        //────────────────────────────────────────

        private void pclstNums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.PclstNums_autoInput)
            {
                // 自動入力中なので、イベントを無視
                goto gt_EndMethod;
            }

            // 選択項目を編集ボックスに表示
            this.proc001();

            goto gt_EndMethod;

            //
        //
        //
        //

        gt_EndMethod:
            return;

        }

        private void pctxtEdits_TextChanged(object sender, EventArgs e)
        {
            if (!this.PctxtEdits_autoInput)
            {
                TextBox pctxt = (TextBox)sender;
                ListBox pclst = this.pclstNums;

                if (0 <= pclst.SelectedIndex)
                {
                    int selectedIndex = pclst.SelectedIndex;//値を退避

                    Memory4bSpritePartsnumberImpl numSp = (Memory4bSpritePartsnumberImpl)pclst.Items[selectedIndex];
                    this.Owner_MemoryApplication.SetText_SpritePartsnumber(numSp, pctxt.Text, this.Owner_MemoryApplication);
                    this.Owner_MemoryApplication.Delegate_OnChanged_SomeContents();

                    this.PclstNums_autoInput = true;//自動入力開始
                    pclst.Items.RemoveAt(selectedIndex);
                    pclst.Items.Insert(selectedIndex, numSp);
                    pclst.SelectedIndex = selectedIndex;
                    this.PclstNums_autoInput = false;//自動入力終了

                    this.Refresh();
                }
            }
        }

        //────────────────────────────────────────

        private void pcrdiFontSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (null != this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite)
            {
                this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            }

            // 再描画
            this.Refresh();
        }

        private void pcrdiFontMiddle_CheckedChanged(object sender, EventArgs e)
        {
            if (null != this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite)
            {
                this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite.Font = new System.Drawing.Font("ＭＳ ゴシック", 20F);
            }

            // 再描画
            this.Refresh();
        }

        private void pcrdiBgcolorBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (null != this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite)
            {
                this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite.BrushBackground = Brushes.Blue;
            }

            // 再描画
            this.Refresh();
        }

        private void pcrdiBgcolorGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (null != this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite)
            {
                this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite.BrushBackground = Brushes.Green;
            }

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        private void pcrdiFontLarge_CheckedChanged(object sender, EventArgs e)
        {
            if (null != this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite)
            {
                this.Owner_MemoryApplication.SelectedMemoryPartsnumbersprite.Font = new System.Drawing.Font("ＭＳ ゴシック", 40F);
            }

            // 再描画
            this.Refresh();
        }

        private void pctxtEdits_Leave(object sender, EventArgs e)
        {
            // グルーピング
            this.Owner_MemoryApplication.Grouping(this.Owner_MemoryApplication);

            // HTMLをリロード。
            Form1 form1 = (Form1)this.ParentForm;
            form1.UcDetailWindow.UsercontrolDetailbrowser1.ReloadHtml(this.Owner_MemoryApplication);
        }

        private void pcrdiDisplay1_CheckedChanged(object sender, EventArgs e)
        {
            this.Owner_MemoryApplication.IsDisplayExecute = false;

            // グルーピング
            this.Owner_MemoryApplication.Grouping(this.Owner_MemoryApplication);

            // 画面図を更新。
            this.Refresh();

            // HTMLをリロード。
            Form1 form1 = (Form1)this.ParentForm;
            form1.UcDetailWindow.UsercontrolDetailbrowser1.ReloadHtml(this.Owner_MemoryApplication);
        }

        private void pcrdiDisplay2_CheckedChanged(object sender, EventArgs e)
        {
            this.Owner_MemoryApplication.IsDisplayExecute = true;

            // グルーピング、画面図を更新。
            this.Owner_MemoryApplication.Grouping(this.Owner_MemoryApplication);
            this.Refresh();

            // HTMLをリロード。
            Form1 form1 = (Form1)this.ParentForm;
            form1.UcDetailWindow.UsercontrolDetailbrowser1.ReloadHtml(this.Owner_MemoryApplication);
        }

        //────────────────────────────────────────

        private void pcbtnLayerAdd_Click(object sender, EventArgs e)
        {
            int nNewLayer;
            this.Owner_MemoryApplication.AddNewLayer(out nNewLayer);
            this.pclstLayer.Items.Add(nNewLayer);
        }

        private void pclstLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox pclstLayer = (ListBox)sender;
            if (null == pclstLayer.SelectedItem)
            {
                this.Owner_MemoryApplication.SelectedLayer = -1;
            }
            else
            {
                this.Owner_MemoryApplication.SelectedLayer = (int)pclstLayer.SelectedItem;
            }

            //
            //
            ListBox pclstNum = this.pclstNums;
            this.PclstNums_autoInput = true;//自動入力開始
            pclstNum.Items.Clear();
            foreach (Memory4bSpritePartsnumber mNum in this.Owner_MemoryApplication.List_VisiblePartsnumbersprite)
            {
                pclstNum.Items.Add(mNum);
            }

            if (0 < pclstNum.Items.Count)
            {
                pclstNum.SelectedIndex = 0;
            }
            this.PclstNums_autoInput = false;//自動入力終了


            this.Owner_MemoryApplication.Grouping(this.Owner_MemoryApplication);
            this.Refresh();

            Form1 form1 = (Form1)this.ParentForm;
            if (null != form1.UcDetailWindow)
            {
                // HTMLをリロード。
                form1.UcDetailWindow.UsercontrolDetailbrowser1.ReloadHtml(this.Owner_MemoryApplication);
            }
        }

        private void UsercontrolCanvas_Load(object sender, EventArgs e)
        {
            //Form1 form1 = (Form1)this.ParentForm;
            //form1.Memory1Application_Partsnumput.Form = this.ParentForm;

            
        }

        //────────────────────────────────────────

        /// <summary>
        /// この関数は、Function2_LoadCsvに渡されます。
        /// </summary>
        /// <param name="mNum"></param>
        /// <param name="scale2"></param>
        public void UsercontrolCanvas_OnChangeSpritePartsnumber(Memory4bSpritePartsnumber mNum, float scale2)
        {
            if (this.Owner_MemoryApplication.IsDisplayExecute && mNum.IsDefinitionExpression)
            {
                // 数値表示モードでは、名前定義は表示しません。
                mNum.Scale = 1.0f;
                mNum.BoundsCircleScaledOnBackground = new Rectangle();
                mNum.BoundsTextScaledOnBackground = new Rectangle();
                goto gt_EndMethod;
            }

            mNum.Scale = scale2;
            float x = scale2 * mNum.LocationOnBackgroundActual.X;
            float y = scale2 * mNum.LocationOnBackgroundActual.Y;

            // ドット絵の1ドットを最小単位にして動くよう調整。スケールは 1、または 2の倍数の整数。
            x = (float)((int)(x / scale2) * (int)scale2);
            y = (float)((int)(y / scale2) * (int)scale2);


            // 番号スプライトのサイズ
            string sText = mNum.GetText( true, this.Owner_MemoryApplication);
            Graphics g = this.CreateGraphics();
            SizeF sizeF = g.MeasureString(sText, mNum.Font);
            g.Dispose();


            // センタリング
            x -= sizeF.Width / 2;
            y -= sizeF.Height / 2;

            // 後ろに、少し大きめの丸を塗ります。
            mNum.BoundsCircleScaledOnBackground = new Rectangle(
                (int)x - 4,
                (int)y - 4,
                (int)sizeF.Width + 8,
                (int)sizeF.Height + 2
                );
            mNum.BoundsTextScaledOnBackground = new Rectangle(
                (int)x,
                (int)y,
                (int)(scale2 * sizeF.Width),
                (int)(scale2 * sizeF.Height)
                );

            goto gt_EndMethod;
        //
        //
        //
        //
        gt_EndMethod:
            mNum.IsDirty = false;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Memory1Application_Partsnumput owner_MemoryApplication;

        public Memory1Application_Partsnumput Owner_MemoryApplication
        {
            get
            {
                return this.owner_MemoryApplication;
            }
            set
            {
                this.owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────

        protected bool pclstNums_autoInput;

        /// <summary>
        /// 「リストボックスの項目を追加削除するので、その間、イベントハンドラは処理をスルーして欲しいとき」なら真。
        /// </summary>
        public bool PclstNums_autoInput
        {
            get
            {
                return pclstNums_autoInput;
            }
            set
            {
                pclstNums_autoInput = value;
            }
        }

        //────────────────────────────────────────

        protected bool pctxtEdits_autoInput;

        /// <summary>
        /// 「テキストボックスの項目を追加削除するので、その間、イベントハンドラは処理をスルーして欲しいとき」なら真。
        /// </summary>
        public bool PctxtEdits_autoInput
        {
            get
            {
                return pctxtEdits_autoInput;
            }
            set
            {
                pctxtEdits_autoInput = value;
            }
        }

        //────────────────────────────────────────
        //
        // コントロール
        //

        public ListBox PclstLayer
        {
            get
            {
                return this.pclstLayer;
            }
        }

        //────────────────────────────────────────

        public Label PclblBgOpaque
        {
            get
            {
                return this.pclblBgOpaque;
            }
        }

        //────────────────────────────────────────

        public ComboBox PcddlBgOpaque
        {
            get
            {
                return this.pcddlBgOpaque;
            }
        }

        //────────────────────────────────────────

        public Label PclblAlScale
        {
            get
            {
                return this.pclblAlScale;
            }
        }

        //────────────────────────────────────────

        public ComboBox PcddlAlScale
        {
            get
            {
                return this.pcddlAlScale;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
