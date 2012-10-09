using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

using System.Drawing;//Graphics
using System.Windows.Forms;

namespace Xenon.NumPut
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

            this.MoApplication = new Memory1ApplicationImpl();

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

        private void DirtyAllNums()
        {
            if (null != this.MoApplication)//null != this.MoProject.MoContents
            {
                foreach (MemoryNum mNum in this.MoApplication.MoProject.MoContents.VisibleNumList)
                {
                    mNum.BDirty = true;
                }
            }
        }

        /// <summary>
        /// カーソルキーで1px動かしたいときなどに。
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void MoveActiveSprite(float dx, float dy)
        {
            if (this.MoApplication.MoProject.MoContents.MouseDragModeEnum == EnumMousedragmode.SpriteMove)
            {
                //
                // 乗せる画像移動
                //
                this.MoveSp(dx, dy);
            }
            else if (this.MoApplication.MoProject.MoContents.MouseDragModeEnum == EnumMousedragmode.BgMove)
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
                MemoryNum mNum = (MemoryNum)this.pclstNums.Items[this.pclstNums.SelectedIndex];

                // 移動前再描画
                this.Invalidate(
                    new Rectangle(
                        mNum.BoundsCircleScaledOnBackground.X + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.X,
                        mNum.BoundsCircleScaledOnBackground.Y + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.Y,
                        mNum.BoundsCircleScaledOnBackground.Width,
                        mNum.BoundsCircleScaledOnBackground.Height
                        ),
                    false);

                PointF old = mNum.LocationOnBgActual;

                // 移動
                this.MoApplication.MoProject.MoContents.MoveNum(mNum, dx, dy, this.MoApplication.MoProject.MoContents.ScaleImg, this);
                ((Form1)this.ParentForm).OnContentsChanged();

                // 移動後再描画
                this.Invalidate(
                    new Rectangle(
                        mNum.BoundsCircleScaledOnBackground.X + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.X,
                        mNum.BoundsCircleScaledOnBackground.Y + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.Y,
                        mNum.BoundsCircleScaledOnBackground.Width,
                        mNum.BoundsCircleScaledOnBackground.Height
                        ),
                    false);
            }
        }

        private void MoveBg(float dx, float dy)
        {
            // 背景画像移動
            this.MoApplication.MoProject.MoContents.BgLocationScaled = new PointF(
                this.MoApplication.MoProject.MoContents.BgLocationScaled.X + dx,
                this.MoApplication.MoProject.MoContents.BgLocationScaled.Y + dy
                );

            this.DirtyAllNums();

            // 再描画
            this.Refresh();
        }

        public void PaintBg(Graphics g, bool bOnWindow, float scale2)
        {
            if (null != this.MoApplication.MoProject.MoContents.Bitmap_Bg)
            {
                // ビットマップ画像の不透明度を指定します。
                System.Drawing.Imaging.ImageAttributes ia;
                {
                    System.Drawing.Imaging.ColorMatrix cm =
                        new System.Drawing.Imaging.ColorMatrix();
                    cm.Matrix00 = 1;
                    cm.Matrix11 = 1;
                    cm.Matrix22 = 1;
                    cm.Matrix33 = this.MoApplication.MoProject.MoContents.BgOpaque;//α値。0～1か？
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
                    x += this.MoApplication.MoProject.MoContents.BgLocationScaled.X;
                    y += this.MoApplication.MoProject.MoContents.BgLocationScaled.Y;
                }
                float width = this.MoApplication.MoProject.MoContents.Bitmap_Bg.Width;
                float height = this.MoApplication.MoProject.MoContents.Bitmap_Bg.Height;
                Rectangle dstRect = new Rectangle((int)x, (int)y, (int)(scale2 * width), (int)(scale2 * height));

                if (!bOnWindow && this.MoApplication.MoProject.MoContents.BgOpaque < 1.0f)
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
                    this.MoApplication.MoProject.MoContents.Bitmap_Bg,
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

        /// <summary>
        /// [乗せる画像]の描画
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bOnWindow"></param>
        /// <param name="scale2"></param>
        public void PaintSpList(Graphics g, bool bOnWindow, float scale2)
        {
            foreach (MemoryNumImpl mNum in this.MoApplication.MoProject.MoContents.VisibleNumList)
            {
                this.PaintSp(g, mNum, bOnWindow, scale2, this);
            }
        }

        public void PaintSp(Graphics g, MemoryNum mNum, bool bOnWindow, float scale2, UsercontrolCanvas numPutUc)
        {
            if (this.MoApplication.MoProject.MoContents.BDisplayExecute && mNum.BNameDefine)
            {
                // 数値表示モードでは、名前定義は表示しません。
                goto process_end;
            }

            if (mNum.BDirty || mNum.Scale != scale2)
            {
                mNum.RefreshData(scale2, numPutUc);
            }

            Rectangle boundsCircle;
            if (bOnWindow)
            {
                boundsCircle = new Rectangle(
                        mNum.BoundsCircleScaledOnBackground.X + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.X,
                        mNum.BoundsCircleScaledOnBackground.Y + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.Y,
                        mNum.BoundsCircleScaledOnBackground.Width,
                        mNum.BoundsCircleScaledOnBackground.Height
                        );
            }
            else
            {
                boundsCircle = mNum.BoundsCircleScaledOnBackground;
            }

            Rectangle boundsText;
            if (bOnWindow)
            {
                boundsText = new Rectangle(
                        mNum.BoundsTextScaledOnBackground.X + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.X,
                        mNum.BoundsTextScaledOnBackground.Y + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.Y,
                        mNum.BoundsTextScaledOnBackground.Width,
                        mNum.BoundsTextScaledOnBackground.Height
                    );
            }
            else
            {
                boundsText = new Rectangle(
                    mNum.BoundsTextScaledOnBackground.X,
                    mNum.BoundsTextScaledOnBackground.Y,
                    mNum.BoundsTextScaledOnBackground.Width,
                    mNum.BoundsTextScaledOnBackground.Height
                    );
            }


            //// 番号スプライトのサイズ
            string sText = mNum.GetText(this.MoApplication.MoProject.MoContents, true);

            // 後ろに、少し大きめの丸を塗ります。
            Brush backBrush;
            if (mNum.BMouseTarget)
            {
                backBrush = Brushes.YellowGreen;
            }
            else
            {
                backBrush = mNum.BrushBg;
            }
            g.FillEllipse(backBrush, boundsCircle.X, boundsCircle.Y, boundsCircle.Width, boundsCircle.Height);
            g.DrawEllipse(mNum.PenFg, boundsCircle.X, boundsCircle.Y, boundsCircle.Width, boundsCircle.Height);


            // 影
            g.DrawString(
                sText,
                mNum.NumSpFont,
                Brushes.Black,
                boundsText.Location
                );
            boundsText.Offset(-1, -1);
            // 文字
            g.DrawString(
                sText,
                mNum.NumSpFont,
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

        private void _CalSelectedSpriteGui(MemoryNum selectedNum)
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
                this.pctxtEdits.Text = selectedNum.SText;//.GetText(this.MoContents,false);

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

                switch ((int)selectedNum.NumSpFont.Size)
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

                if (Brushes.Green == selectedNum.BrushBg)
                {
                    this.pcrdiBgcolorGreen.Checked = true;
                }
                else if (Brushes.Blue == selectedNum.BrushBg)
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
            if (0 < this.MoApplication.MoProject.MoContents.CountNum)
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

        public void AddNumSp(MemoryNum mNum, bool bLoadingNow)
        {

            //
            //
            this.MoApplication.MoProject.MoContents.AddNum(mNum, bLoadingNow);

            //
            //
            ListBox pclst = this.pclstNums;
            this.PclstNums_autoInput = true;//自動入力開始
            pclst.Items.Add(mNum);
            pclst.SelectedIndex = pclst.Items.Count - 1;
            this.PclstNums_autoInput = false;//自動入力終了

            //
            //
            ((Form1)this.ParentForm).OnContentsChanged();
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
                this.MoApplication.MoProject.MoContents.SelectedMoSprite = (MemoryNumImpl)pclstNum.Items[pclstNum.SelectedIndex];
                this._CalSelectedSpriteGui(this.MoApplication.MoProject.MoContents.SelectedMoSprite);

            }
            else
            {
                //
                // ◇項目を選択していない場合
                //
                this.MoApplication.MoProject.MoContents.SelectedMoSprite = null;
                this._CalSelectedSpriteGui(this.MoApplication.MoProject.MoContents.SelectedMoSprite);

            }
        }

        //────────────────────────────────────────

        public void OpenCsv()
        {
            if (System.IO.File.Exists(this.MoApplication.MoProject.MoContents.SFpath_Csv))
            {

                // CSVファイルが開かれた。
                Subaction002 a2 = new Subaction002();
                a2.In_SFpatha = this.MoApplication.MoProject.MoContents.SFpath_Csv;
                a2.In_UcCanvas = this;
                a2.In_MNumList = this.MoApplication.MoProject.MoContents.VisibleNumList;
                a2.Perfrom();

                if ("" != a2.Out_errorMsg)
                {
                    MessageBox.Show(a2.Out_errorMsg, "エラー");
                    goto process_end;
                }

                this.pclstLayer.Items.Clear();
                foreach (int nKey in this.MoApplication.MoProject.MoContents.LayerDic.Keys)
                {
                    this.pclstLayer.Items.Add(nKey);
                }

                if (0 < this.pclstLayer.Items.Count)
                {
                    this.pclstLayer.SelectedIndex = 0;
                }
            }

            goto process_end;
        //
        //
        //
        //
        process_end:
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

            this.MoApplication.MoProject.MoContents.ClearNums(bLoadingNow);
            this.pclstLayer.Items.Clear();
        }

        //────────────────────────────────────────

        public void OpenBg()
        {
            UsercontrolCanvas ucCanvas = this;
            Form1 form1 = (Form1)this.ParentForm;

            if (System.IO.File.Exists(ucCanvas.MoApplication.MoProject.MoContents.SFpath_BgPng))
            {

                // 画像ファイルが開かれたものとして、ビットマップにする。
                try
                {
                    ucCanvas.MoApplication.MoProject.MoContents.Bitmap_Bg = new Bitmap(ucCanvas.MoApplication.MoProject.MoContents.SFpath_BgPng);
                    form1.ToolStripMenuItem_BgOpen.Enabled = true;
                    ucCanvas.PclblBgOpaque.Enabled = true;
                    ucCanvas.PcddlBgOpaque.Enabled = true;
                    ucCanvas.PclblAlScale.Enabled = true;
                    ucCanvas.PcddlAlScale.Enabled = true;
                }
                catch (ArgumentException)
                {
                    // 指定したファイルが画像じゃなかった。
                    ucCanvas.MoApplication.MoProject.MoContents.Bitmap_Bg = null;
                    ucCanvas.PclblBgOpaque.Enabled = false;
                    ucCanvas.PcddlBgOpaque.Enabled = false;
                }

                ucCanvas.MoApplication.MoProject.MoContents.BgLocationScaled = new PointF(150.0f, 60.0f);
            }
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
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("x  1" == sSelectedValue)
                {
                    this.MoApplication.MoProject.MoContents.PreScale = this.MoApplication.MoProject.MoContents.ScaleImg;
                    this.MoApplication.MoProject.MoContents.ScaleImg = 1;
                }
                else if ("x  2" == sSelectedValue)
                {
                    this.MoApplication.MoProject.MoContents.PreScale = this.MoApplication.MoProject.MoContents.ScaleImg;
                    this.MoApplication.MoProject.MoContents.ScaleImg = 2;
                }
                else if ("x  4" == sSelectedValue)
                {
                    this.MoApplication.MoProject.MoContents.PreScale = this.MoApplication.MoProject.MoContents.ScaleImg;
                    this.MoApplication.MoProject.MoContents.ScaleImg = 4;
                }
                else if ("x  8" == sSelectedValue)
                {
                    this.MoApplication.MoProject.MoContents.PreScale = this.MoApplication.MoProject.MoContents.ScaleImg;
                    this.MoApplication.MoProject.MoContents.ScaleImg = 8;
                }
                else if ("x 16" == sSelectedValue)
                {
                    this.MoApplication.MoProject.MoContents.PreScale = this.MoApplication.MoProject.MoContents.ScaleImg;
                    this.MoApplication.MoProject.MoContents.ScaleImg = 16;
                }
                else
                {
                    this.MoApplication.MoProject.MoContents.PreScale = this.MoApplication.MoProject.MoContents.ScaleImg;
                    this.MoApplication.MoProject.MoContents.ScaleImg = 1;
                }
            }
            else
            {
                // 未選択

                this.MoApplication.MoProject.MoContents.PreScale = this.MoApplication.MoProject.MoContents.ScaleImg;
                this.MoApplication.MoProject.MoContents.ScaleImg = 1;
            }


            // 現在見えている画面上の中心を固定するようにズーム。
            if (null != this.MoApplication.MoProject.MoContents.Bitmap_Bg)
            {

                //
                // 位置調整 

                float multiple = this.MoApplication.MoProject.MoContents.ScaleImg / this.MoApplication.MoProject.MoContents.PreScale; //何倍になったか。

                // 画面の中心に位置する、ズームされた画像上の位置（固定点）
                float imgFixX = (this.Width / 2.0f) - this.MoApplication.MoProject.MoContents.BgLocationScaled.X;
                float imgFixY = (this.Height / 2.0f) - this.MoApplication.MoProject.MoContents.BgLocationScaled.Y;

                // 背景位置
                this.MoApplication.MoProject.MoContents.BgLocationScaled = new PointF(
                    this.MoApplication.MoProject.MoContents.BgLocationScaled.X - (imgFixX * multiple - imgFixX),
                    this.MoApplication.MoProject.MoContents.BgLocationScaled.Y - (imgFixY * multiple - imgFixY)
                    );
            }

            this.DirtyAllNums();

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        private void pcbtnSp_Click(object sender, EventArgs e)
        {
        }

        //────────────────────────────────────────
        //
        // マウス
        //

        private void UcCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            //this.MoApplication.MoProject.MoOperationMode
            this.MoApplication.MoProject.MoContents.MouseDraggingNone = true;
            this.MoApplication.MoProject.MoContents.MouseDragging = true;
            this.MoApplication.MoProject.MoContents.MouseDownLocation = e.Location;
            this.MoApplication.MoProject.MoContents.PreDragLocation = e.Location;

            // フォーカスをコントロールから外すことで、フォーカスをフォームに戻します。
            this.ActiveControl = null;


            // スプライトと重なるか判定
            foreach (MemoryNum mNum in this.MoApplication.MoProject.MoContents.VisibleNumList)
            {
                bool bHit = mNum.Contains(e.Location, this);
                if (bHit)
                {
                    this.pclstNums.SelectedItem = mNum;
                }
            }
        }

        private void UcCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            int flag;
            if (this.MoApplication.MoProject.MoContents.BCtrlKey)
            {
                // 背景画像の移動
                flag = 2;
            }
            else if (this.MoApplication.MoProject.MoContents.BShiftKey)
            {
                // 乗せる画像の移動
                flag = 1;
            }
            else if (this.MoApplication.MoProject.MoContents.MouseDragModeEnum == EnumMousedragmode.SpriteMove)
            {
                // 乗せる画像の移動
                flag = 1;
            }
            else if (this.MoApplication.MoProject.MoContents.MouseDragModeEnum == EnumMousedragmode.BgMove)
            {
                // 背景画像の移動
                flag = 2;
            }
            else
            {
                // 移動しない
                flag = 0;
            }

            if (null != this.MoApplication.MoProject.MoContents.MouseTargetNum)
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

                if (this.MoApplication.MoProject.MoContents.MouseDragging)
                {
                    // 前回ドラッグした位置との差分
                    float dx;
                    float dy;
                    if (this.MoApplication.MoProject.MoContents.MouseDraggingNone)
                    {
                        dx = 0;
                        dy = 0;
                        this.MoApplication.MoProject.MoContents.MouseDraggingNone = false;
                    }
                    else
                    {
                        dx = e.Location.X - this.MoApplication.MoProject.MoContents.PreDragLocation.X;
                        dy = e.Location.Y - this.MoApplication.MoProject.MoContents.PreDragLocation.Y;
                    }

                    this.MoveSp(dx, dy);

                    // ドラッグした位置
                    this.MoApplication.MoProject.MoContents.PreDragLocation = e.Location;
                }
            }
            else if (2 == flag)
            {
                //
                // 背景画像移動
                //

                if (this.MoApplication.MoProject.MoContents.MouseDragging)
                {
                    // 前回ドラッグした位置との差分
                    float dx;
                    float dy;
                    if (this.MoApplication.MoProject.MoContents.MouseDraggingNone)
                    {
                        dx = 0;
                        dy = 0;
                        this.MoApplication.MoProject.MoContents.MouseDraggingNone = false;
                    }
                    else
                    {
                        dx = e.Location.X - this.MoApplication.MoProject.MoContents.PreDragLocation.X;
                        dy = e.Location.Y - this.MoApplication.MoProject.MoContents.PreDragLocation.Y;
                    }

                    this.MoveBg(dx, dy);

                    // ドラッグした位置
                    this.MoApplication.MoProject.MoContents.PreDragLocation = e.Location;
                }
            }


            // スプライトと重なるか判定
            this.MoApplication.MoProject.MoContents.MouseTargetNum = null;
            foreach (MemoryNum mNum in this.MoApplication.MoProject.MoContents.VisibleNumList)
            {
                bool bOld = mNum.BMouseTarget;
                mNum.BMouseTarget = mNum.Contains(e.Location, this);
                if (mNum.BMouseTarget)
                {
                    this.MoApplication.MoProject.MoContents.MouseTargetNum = mNum;
                }

                if (bOld != mNum.BMouseTarget)
                {
                    this.Invalidate(
                        new Rectangle(
                            mNum.BoundsCircleScaledOnBackground.X + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.X,
                            mNum.BoundsCircleScaledOnBackground.Y + (int)this.MoApplication.MoProject.MoContents.BgLocationScaled.Y,
                            mNum.BoundsCircleScaledOnBackground.Width,
                            mNum.BoundsCircleScaledOnBackground.Height
                            ),
                        false);
                }
            }
        }

        private void UcCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            this.MoApplication.MoProject.MoContents.MouseDragging = false;
        }

        //────────────────────────────────────────

        private void UcCanvas_Paint(object sender, PaintEventArgs e)
        {

            // 背景画像
            this.PaintBg(e.Graphics, true, this.MoApplication.MoProject.MoContents.ScaleImg);

            // 番号画像
            this.PaintSpList(e.Graphics, true, this.MoApplication.MoProject.MoContents.ScaleImg);
        }

        //────────────────────────────────────────

        private void pcddlOpaqueBg_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("100" == sSelectedValue)
                {
                    this.MoApplication.MoProject.MoContents.BgOpaque = 1.0F;
                }
                else if (" 75" == sSelectedValue)
                {
                    this.MoApplication.MoProject.MoContents.BgOpaque = 0.75F;
                }
                else if (" 50" == sSelectedValue)
                {
                    this.MoApplication.MoProject.MoContents.BgOpaque = 0.50F;
                }
                else if (" 25" == sSelectedValue)
                {
                    this.MoApplication.MoProject.MoContents.BgOpaque = 0.25F;
                }
                else
                {
                    this.MoApplication.MoProject.MoContents.BgOpaque = 1.0F;
                }
            }
            else
            {
                // 未選択

                this.MoApplication.MoProject.MoContents.BgOpaque = 1.0F;
            }

            // 再描画
            this.Refresh();
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

            MemoryNum mNum = new MemoryNumImpl(this.MoApplication.MoProject.MoContents.CreatesCount.ToString());
            this.MoApplication.MoProject.MoContents.CreatesCount++;

            mNum.LocationOnBgActual = new PointF(
                this.Width / 2 - this.MoApplication.MoProject.MoContents.BgLocationScaled.X,
                this.Height / 2 - this.MoApplication.MoProject.MoContents.BgLocationScaled.Y
                );
            mNum.NLayer = this.MoApplication.MoProject.MoContents.NSelectedLayer;

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
                this.MoApplication.MoProject.MoContents.RemoveNumAt(selectedIndex);
                ((Form1)this.ParentForm).OnContentsChanged();
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
                goto process_end;
            }

            // 選択項目を編集ボックスに表示
            this.proc001();

            goto process_end;

            //
        //
        //
        //

        process_end:
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

                    MemoryNumImpl numSp = (MemoryNumImpl)pclst.Items[selectedIndex];
                    this.MoApplication.MoProject.MoContents.SetNumText(numSp, pctxt.Text);
                    ((Form1)this.ParentForm).OnContentsChanged();

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
            if (null != this.MoApplication.MoProject.MoContents.SelectedMoSprite)
            {
                this.MoApplication.MoProject.MoContents.SelectedMoSprite.NumSpFont = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            }

            // 再描画
            this.Refresh();
        }

        private void pcrdiFontMiddle_CheckedChanged(object sender, EventArgs e)
        {
            if (null != this.MoApplication.MoProject.MoContents.SelectedMoSprite)
            {
                this.MoApplication.MoProject.MoContents.SelectedMoSprite.NumSpFont = new System.Drawing.Font("ＭＳ ゴシック", 20F);
            }

            // 再描画
            this.Refresh();
        }

        private void pcrdiBgcolorBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (null != this.MoApplication.MoProject.MoContents.SelectedMoSprite)
            {
                this.MoApplication.MoProject.MoContents.SelectedMoSprite.BrushBg = Brushes.Blue;
            }

            // 再描画
            this.Refresh();
        }

        private void pcrdiBgcolorGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (null != this.MoApplication.MoProject.MoContents.SelectedMoSprite)
            {
                this.MoApplication.MoProject.MoContents.SelectedMoSprite.BrushBg = Brushes.Green;
            }

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        private void pcrdiFontLarge_CheckedChanged(object sender, EventArgs e)
        {
            if (null != this.MoApplication.MoProject.MoContents.SelectedMoSprite)
            {
                this.MoApplication.MoProject.MoContents.SelectedMoSprite.NumSpFont = new System.Drawing.Font("ＭＳ ゴシック", 40F);
            }

            // 再描画
            this.Refresh();
        }

        private void pctxtEdits_Leave(object sender, EventArgs e)
        {
            // グルーピング
            this.MoApplication.MoProject.MoContents.Grouping();

            // HTMLをリロード。
            Form1 form1 = (Form1)this.ParentForm;
            form1.UcDetailWindow.UcDetailOut.ReloadHtml(this.MoApplication.MoProject.MoContents);
        }

        private void pcrdiDisplay1_CheckedChanged(object sender, EventArgs e)
        {
            this.MoApplication.MoProject.MoContents.BDisplayExecute = false;

            // グルーピング
            this.MoApplication.MoProject.MoContents.Grouping();

            // 画面図を更新。
            this.Refresh();

            // HTMLをリロード。
            Form1 form1 = (Form1)this.ParentForm;
            form1.UcDetailWindow.UcDetailOut.ReloadHtml(this.MoApplication.MoProject.MoContents);
        }

        private void pcrdiDisplay2_CheckedChanged(object sender, EventArgs e)
        {
            this.MoApplication.MoProject.MoContents.BDisplayExecute = true;

            // グルーピング、画面図を更新。
            this.MoApplication.MoProject.MoContents.Grouping();
            this.Refresh();

            // HTMLをリロード。
            Form1 form1 = (Form1)this.ParentForm;
            form1.UcDetailWindow.UcDetailOut.ReloadHtml(this.MoApplication.MoProject.MoContents);
        }

        //────────────────────────────────────────

        private void pcbtnLayerAdd_Click(object sender, EventArgs e)
        {
            int nNewLayer;
            this.MoApplication.MoProject.MoContents.AddNewLayer(out nNewLayer);
            this.pclstLayer.Items.Add(nNewLayer);
        }

        private void pclstLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox pclstLayer = (ListBox)sender;
            if (null == pclstLayer.SelectedItem)
            {
                this.MoApplication.MoProject.MoContents.NSelectedLayer = -1;
            }
            else
            {
                this.MoApplication.MoProject.MoContents.NSelectedLayer = (int)pclstLayer.SelectedItem;
            }

            //
            //
            ListBox pclstNum = this.pclstNums;
            this.PclstNums_autoInput = true;//自動入力開始
            pclstNum.Items.Clear();
            foreach (MemoryNum mNum in this.MoApplication.MoProject.MoContents.VisibleNumList)
            {
                pclstNum.Items.Add(mNum);
            }

            if (0 < pclstNum.Items.Count)
            {
                pclstNum.SelectedIndex = 0;
            }
            this.PclstNums_autoInput = false;//自動入力終了


            this.MoApplication.MoProject.MoContents.Grouping();
            this.Refresh();

            // HTMLをリロード。
            Form1 form1 = (Form1)this.ParentForm;
            form1.UcDetailWindow.UcDetailOut.ReloadHtml(this.MoApplication.MoProject.MoContents);
        }

        private void UcCanvas_Load(object sender, EventArgs e)
        {
            this.MoApplication.Form1 = (Form1)this.ParentForm;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected Memory1Application moApplication;

        /// <summary>
        /// 番号スプライトのリスト。
        /// </summary>
        public Memory1Application MoApplication
        {
            get
            {
                return moApplication;
            }
            set
            {
                moApplication = value;
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

        public OpenFileDialog PcdlgOpenBg
        {
            get
            {
                return this.pcdlgOpenBg;
            }
        }

        //────────────────────────────────────────

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
