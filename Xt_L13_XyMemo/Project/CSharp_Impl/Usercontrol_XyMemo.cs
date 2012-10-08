using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing;//Graphics

using Xenon.Lib;

namespace Xenon.XyMemo
{
    public partial class Usercontrol_XyMemo : UserControl, Spritememo
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Usercontrol_XyMemo()
        {
            InitializeComponent();

            this.mouseDragModeEnum = EnumMousedragmode.NONE;
            this.infoDisplay = new Spritememo_InfoDisplay();

            this.pclstMouseDrag.Items.Add("なし");
            this.pclstMouseDrag.Items.Add("背景画像移動");
            this.pclstMouseDrag.Items.Add("乗せる画像移動");
            this.pclstMouseDrag.SelectedIndex = 0;

            this.pcddlAlScale.Items.Add("x0.25");
            this.pcddlAlScale.Items.Add("x0.5");
            this.pcddlAlScale.Items.Add("x  1");//初期選択
            this.pcddlAlScale.Items.Add("x  2");
            this.pcddlAlScale.Items.Add("x  4");
            this.pcddlAlScale.Items.Add("x  8");
            this.pcddlAlScale.Items.Add("x 16");
            this.pcddlAlScale.SelectedIndex = 2;

            this.pcddlBgOpaque.Items.Add("100");
            this.pcddlBgOpaque.Items.Add(" 75");
            this.pcddlBgOpaque.Items.Add(" 50");//初期選択
            this.pcddlBgOpaque.Items.Add(" 25");
            this.pcddlBgOpaque.SelectedIndex = 2;
            this.bgOpaque = 0.5F;

            // 格子枠の色
            this.pcddlGridcolor.Items.Add("自動");
            this.pcddlGridcolor.Items.Add("白");
            this.pcddlGridcolor.Items.Add("灰色");
            this.pcddlGridcolor.Items.Add("黒");
            this.pcddlGridcolor.Items.Add("赤");
            this.pcddlGridcolor.Items.Add("黄");
            this.pcddlGridcolor.Items.Add("緑");//初期選択
            this.pcddlGridcolor.Items.Add("青");
            this.pcddlGridcolor.SelectedIndex = 6;

            this.bgLocation = new Point();
        }

        public void InitializeBeforeUse(MemorySpritememoImpl moSprite)
        {
            this.MoSprite = moSprite;

            MemorySpritecanvasImpl moSpriteCanvasImpl = new MemorySpritecanvasImpl();
            this.MoSpriteCanvas = moSpriteCanvasImpl;
            this.ucSpriteParam.MoSpriteCanvas = moSpriteCanvas;

            this.InfoDisplay.MoSprite = moSprite;
            this.ucSpriteParam.MoSprite = moSprite;
            moSprite.VoSpriteList.Add(this.InfoDisplay);
            moSprite.VoSpriteList.Add(this.ucSpriteParam);

            this.pcddlSpOpaque.Items.Add("100");
            this.pcddlSpOpaque.Items.Add(" 75");
            this.pcddlSpOpaque.Items.Add(" 50");//初期選択
            this.pcddlSpOpaque.Items.Add(" 25");
            this.pcddlSpOpaque.SelectedIndex = 2;
            this.MoSprite.NOpaque = 0.5F;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void OnSpriteLocationChanged()
        {
            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// サイズが変わったとき。
        /// </summary>
        public void OnSpriteSizeChanged()
        {
            if (null == this.MoSprite.Bitmap && 0 != this.MoSprite.DstSizeResult.Width && 0 != this.MoSprite.DstSizeResult.Height)
            {
                // まだ画像が作られていないとき

                // 中心座標の初期値をセット。
                this.MoSprite.MyCtOnBg = new PointF(
                    this.MoSprite.LtXOnBgOsz + this.MoSprite.DstSizeResult.Width / 2,
                    this.MoSprite.LtYOnBgOsz + this.MoSprite.DstSizeResult.Height / 2
                    );


                if (false == this.pclstMouseDrag.Enabled)
                {
                    // 使用不可の解除
                    this.pclstMouseDrag.Enabled = true;
                    this.pclstMouseDrag.SelectedIndex = 2;//「乗せる画像移動」を選択
                }

                this.pclblSpOpaque.Enabled = true;
                this.pcddlSpOpaque.Enabled = true;

                //
                // 枠線
                this.pclblSpBorder.Enabled = true;
                this.pcchkSpBorder.Enabled = true;

                //
                // 十字線
                this.pclblSpCross.Enabled = true;
                this.pcchkSpCross.Enabled = true;
            }

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「乗せる画像」を削除。
        /// </summary>
        private void EjectSp(bool bLocationSizeKeep)
        {
            this.MoSprite.Bitmap = null;
            this.pclblSpOpaque.Enabled = false;
            this.pcddlSpOpaque.Enabled = false;
            this.pcbtnSpClr.Enabled = false;

            // 枠線
            this.pclblSpBorder.Enabled = false;
            this.pcchkSpBorder.Checked = false;
            this.pcchkSpBorder.Enabled = false;

            // 十字線
            this.pclblSpCross.Enabled = false;
            this.MoSprite.BCross = false;
            this.pcchkSpCross.Checked = false;
            this.pcchkSpCross.Enabled = false;


            // 初期位置
            if (bLocationSizeKeep)
            {
                //this.MoSprite.SrcSize = new Size(0, 0);
                // 中央座標と、左上座標が等しくなる。
                this.MoSprite.MyCtOnBg = new PointF(
                    this.MoSprite.MyLtOnBgOsz.X,
                    this.MoSprite.MyLtOnBgOsz.Y
                    );
            }
            else
            {
                this.MoSprite.SrcSize = new Size(0, 0);
                this.MoSprite.DstSizeResult = new Size(0, 0);
                this.MoSprite.MyLtOnBgOsz = new PointF(0, 0);
                this.MoSprite.MyCtOnBg = new PointF(0, 0);

                this.ucSpriteParam.PctxtDstWidthForced.Text = "";
                this.ucSpriteParam.PctxtDstHeightForced.Text = "";
                this.ucSpriteParam.PclblDstWidthResult.Text = "-";
                this.ucSpriteParam.PclblDstHeightResult.Text = "-";
            }

            this.ucSpriteParam.PclblLtXResult.Text = "-";
            this.ucSpriteParam.PclblLtYResult.Text = "-";
            this.ucSpriteParam.PclblCtXResult.Text = "-";
            this.ucSpriteParam.PclblCtYResult.Text = "-";

            // フォームを再描画。
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// カーソルキーで1px動かしたいときなどに。
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void MoveActiveSprite(float dx, float dy)
        {
            if (this.mouseDragModeEnum == EnumMousedragmode.SPRITE_MOVE)
            {
                //
                // 乗せる画像移動
                //
                this.MoveSpByGesture(dx, dy);
            }
            else if (this.mouseDragModeEnum == EnumMousedragmode.BG_MOVE)
            {
                //
                // 背景画像移動
                //
                this.MoveBg(dx, dy);
            }

        }

        /// <summary>
        /// キーボードのカーソル、またはマウスでのスプライト移動。
        /// フォームからの数値入力ではない。
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void MoveSpByGesture(float dx, float dy)
        {
            //
            // 指定欄を空欄にして、左上座標優先にします。
            //
            this.MoSprite.PrimaryLtCtForce = EnumLefttopCenter.Lt;
            this.ucSpriteParam.PctxtLtXForce.Text = "";
            this.ucSpriteParam.PctxtLtYForce.Text = "";
            this.ucSpriteParam.PctxtCtXForce.Text = "";
            this.ucSpriteParam.PctxtCtYForce.Text = "";

            //
            // 背景画像上のスプライト位置
            //
            {
                float scaledX = this.MoSprite.MyLtOnBgOsz.X * this.MoSpriteCanvas.ScaleImg + dx;
                float scaledY = this.MoSprite.MyLtOnBgOsz.Y * this.MoSpriteCanvas.ScaleImg + dy;

                // デジタルにします。
                scaledX -= scaledX % this.MoSpriteCanvas.ScaleImg;
                scaledY -= scaledY % this.MoSpriteCanvas.ScaleImg;

                this.MoSprite.MyLtOnBgOsz = new PointF(
                    scaledX / this.MoSpriteCanvas.ScaleImg,
                    scaledY / this.MoSpriteCanvas.ScaleImg
                );
            }
            {
                float scaledX = this.MoSprite.MyCtOnBg.X * this.MoSpriteCanvas.ScaleImg + dx;
                float scaledY = this.MoSprite.MyCtOnBg.Y * this.MoSpriteCanvas.ScaleImg + dy;

                // デジタルにします。
                scaledX -= scaledX % this.MoSpriteCanvas.ScaleImg;
                scaledY -= scaledY % this.MoSpriteCanvas.ScaleImg;

                this.MoSprite.MyCtOnBg = new PointF(
                    scaledX / this.MoSpriteCanvas.ScaleImg,
                    scaledY / this.MoSpriteCanvas.ScaleImg
                );
            }

        }

        public void MoveBg(float dx, float dy)
        {
            // 画像全体を移動
            this.bgLocation.X += dx;
            this.bgLocation.Y += dy;

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        private void PaintBg(Graphics g, bool bOnWindow, float scale2)
        {
            if (null != this.bitmap_bg)
            {
                // ビットマップ画像の不透明度を指定します。
                System.Drawing.Imaging.ImageAttributes ia;
                {
                    System.Drawing.Imaging.ColorMatrix cm =
                        new System.Drawing.Imaging.ColorMatrix();
                    cm.Matrix00 = 1;
                    cm.Matrix11 = 1;
                    cm.Matrix22 = 1;
                    cm.Matrix33 = this.bgOpaque;//α値。0～1か？
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
                    x += this.bgLocation.X;
                    y += this.bgLocation.Y;
                }
                float width = this.bitmap_bg.Width;
                float height = this.bitmap_bg.Height;
                Rectangle dstRect = new Rectangle((int)x, (int)y, (int)(scale2 * width), (int)(scale2 * height));

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;//ドット絵のまま拡縮するように。しかし、この指定だと半ピクセル左上にずれるバグ。
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;//半ピクセル左上にずれるバグに対応。
                g.DrawImage(
                    this.bitmap_bg,
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

        //────────────────────────────────────────

        /// <summary>
        /// 背景画像の移動モードへ
        /// </summary>
        public void ToBgMoveMode()
        {
            ListBox listBox = this.pclstMouseDrag;

            listBox.SelectedIndex = 1;
        }

        /// <summary>
        /// スプライト画像の移動モードへ
        /// </summary>
        public void ToSpMoveMode()
        {
            ListBox listBox = this.pclstMouseDrag;

            listBox.SelectedIndex = 2;
        }

        //────────────────────────────────────────

        /// <summary>
        /// １段階、拡大します。
        /// </summary>
        public void ZoomUp()
        {
            ComboBox listBox = this.pcddlAlScale;

            if (listBox.SelectedIndex + 1 < listBox.Items.Count)
            {
                listBox.SelectedIndex++;
                this.Refresh();
            }
        }

        /// <summary>
        /// １段階、縮小します。
        /// </summary>
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

        /// <summary>
        /// [乗せる画像]の描画
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bOnWindow"></param>
        /// <param name="scale2"></param>
        public void PaintSprite(Graphics g, bool bOnWindow, float scale2, PointF bgLocation, Spritememo_InfoDisplay infoDisplay)
        {
            if (null == this.MoSprite)
            {
                goto gt_ProcessEnd;
            }

            //
            // 表示する画像の、左上隅座標
            //
            float x = scale2 * this.MoSprite.LtXOnBgOsz;
            float y = scale2 * this.MoSprite.LtYOnBgOsz;

            if (bOnWindow)
            {
                x += bgLocation.X;
                y += bgLocation.Y;
            }

            //
            // 表示する横幅、縦幅
            //
            float width = this.MoSprite.DstSizeResult.Width;
            float height = this.MoSprite.DstSizeResult.Height;

            // 表示する位置と、横幅、縦幅
            Rectangle dstRectScaled = new Rectangle((int)x, (int)y, (int)(scale2 * width), (int)(scale2 * height));

            // 枠の太さ（影+本体= 2px）
            int borderWidth = 2;


            if (null == this.MoSprite.Bitmap)
            {
                //
                // ビットマップが指定されていなければ、緑色の四角を表示する。
                //
                g.FillRectangle(
                    this.MoSprite.AltBrush,
                    dstRectScaled
                    );
            }
            else
            {
                // ビットマップ画像の不透明度を指定します。
                System.Drawing.Imaging.ImageAttributes ia;
                {
                    System.Drawing.Imaging.ColorMatrix cm =
                        new System.Drawing.Imaging.ColorMatrix();
                    cm.Matrix00 = 1;
                    cm.Matrix11 = 1;
                    cm.Matrix22 = 1;
                    cm.Matrix33 = this.MoSprite.NOpaque;//α値。0～1か？
                    cm.Matrix44 = 1;

                    //ImageAttributesオブジェクトの作成
                    ia = new System.Drawing.Imaging.ImageAttributes();
                    //ColorMatrixを設定する
                    ia.SetColorMatrix(cm);
                }

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;//ドット絵のまま拡縮するように。しかし、この指定だと半ピクセル左上にずれるバグ。
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;//半ピクセル左上にずれるバグに対応。
                g.DrawImage(
                    this.MoSprite.Bitmap,
                    dstRectScaled,
                    0,
                    0,
                    this.MoSprite.Bitmap.Width,
                    this.MoSprite.Bitmap.Height,
                    GraphicsUnit.Pixel,
                    ia
                    );
            }

            // 十字線
            if (this.MoSprite.BCross)
            {
                // 縦線
                g.DrawLine(
                    this.infoDisplay.GridPen,//Pens.Green,
                    (int)(dstRectScaled.X + (double)dstRectScaled.Width / 2.0d),
                    dstRectScaled.Y,
                    (int)(dstRectScaled.X + (double)dstRectScaled.Width / 2.0d),
                    dstRectScaled.Y + dstRectScaled.Height - 1
                    );

                // 横線
                g.DrawLine(
                    this.infoDisplay.GridPen,//Pens.Green,
                    dstRectScaled.X,
                    (int)(dstRectScaled.Y + (double)dstRectScaled.Height / 2.0d),
                    dstRectScaled.X + dstRectScaled.Width - 1,
                    (int)(dstRectScaled.Y + (double)dstRectScaled.Height / 2.0d)
                    );
            }

            // 枠線
            if (this.MoSprite.BBorder)
            {
                //
                // 枠線：影
                //
                // X,Yを、1ドット右下にずらします。
                dstRectScaled.Offset(1, 1);
                // 最初の状態だと、右辺、下辺が外に1px出ています。
                // X,Yをずらした分と合わせて、縦幅、横幅を2ドット狭くします。
                dstRectScaled.Width -= 2;
                dstRectScaled.Height -= 2;
                g.DrawRectangle(Pens.Black, dstRectScaled);
                //
                //
                dstRectScaled.Offset(-1, -1);// 元の位置に戻します。
                dstRectScaled.Width += 2;// 元のサイズに戻します。
                dstRectScaled.Height += 2;

                //
                // 枠線：
                //
                // 最初から1ドット出ている分と、X,Yをずらした分と合わせて、
                // 縦幅、横幅を2ドット狭くします。
                dstRectScaled.Width -= 2;
                dstRectScaled.Height -= 2;
                g.DrawRectangle(
                    infoDisplay.GridPen,// Pens.Green,
                    dstRectScaled);

                // 元に戻す。
                dstRectScaled.Width += 2;
                dstRectScaled.Height += 2;
            }

            //
        //
        //
        //
        gt_ProcessEnd:
            return;
        }

        public void Save()
        {
            if (this.pcbtnSaveImg.Enabled && null != this.bitmap_bg)
            {
                Bitmap bm = new Bitmap(this.bitmap_bg.Width, this.bitmap_bg.Height);

                //imgのGraphicsオブジェクトを取得
                Graphics g = Graphics.FromImage(bm);

                bool bOnWindow = false;//ウィンドウの中ではない。
                float scale2 = 1.0F;//等倍
                this.PaintBg(g, bOnWindow, scale2);

                this.PaintSprite(g, bOnWindow, scale2, this.bgLocation, this.infoDisplay);

                // 情報表示
                new Subaction_View003().Paint(
                    g, bOnWindow, this.MoSprite, scale2, this.InfoDisplay);

                g.Dispose();

                // ファイル名を適当に作成。
                StringBuilder s = new StringBuilder();
                {
                    s.Append(Application.StartupPath);
                    s.Append("\\ScreenShot\\");

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
                    s.Append(".png");
                }

                // .exeの入っているフォルダーに ScreenShot フォルダーを置くこと。
                bm.Save(s.ToString(), System.Drawing.Imaging.ImageFormat.Png);


            }
        }

        //────────────────────────────────────────
        #endregion


        
        #region イベントハンドラー
        //────────────────────────────────────────

        private void pcbtnBg_Click(object sender, EventArgs e)
        {
            this.pcdlgOpenBgFile.InitialDirectory = Application.StartupPath;
            DialogResult result = this.pcdlgOpenBgFile.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                // 絶対ファイルパス
                string sFpatha = this.pcdlgOpenBgFile.FileName;

                // 画像ファイルが開かれたものとして、ビットマップにする。
                try
                {
                    this.bitmap_bg = new Bitmap(sFpatha);
                    this.pcbtnSp.Enabled = true;
                    this.pcbtnSaveImg.Enabled = true;
                    this.pclblBgOpaque.Enabled = true;
                    this.pcddlBgOpaque.Enabled = true;
                    this.pclblAlScale.Enabled = true;
                    this.pcddlAlScale.Enabled = true;
                    this.pclblMouseDrag.Enabled = true;
                    this.pclstMouseDrag.Enabled = true;
                    this.pclstMouseDrag.SelectedIndex = 1;//「背景画像移動」を選択
                }
                catch (ArgumentException)
                {
                    // 指定したファイルが画像じゃなかった。
                    this.bitmap_bg = null;
                    this.pclblBgOpaque.Enabled = false;
                    this.pcddlBgOpaque.Enabled = false;
                }

                this.bgLocation.X = 50.0f;
                this.bgLocation.Y = 50.0f;

            }
            else if (result == DialogResult.Cancel)
            {
                //変更なし
            }
            else
            {
                this.pcbtnSaveImg.Enabled = false;
            }

            // フォームを再描画。
            this.Refresh();
        }

        private void pcddlScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == this.MoSpriteCanvas)
            {
                goto gt_ProcessEnd;
            }

            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("x0.25" == sSelectedValue)
                {
                    this.MoSpriteCanvas.PreScale = this.MoSpriteCanvas.ScaleImg;
                    this.MoSpriteCanvas.ScaleImg = 0.25f;
                }
                else if ("x0.5" == sSelectedValue)
                {
                    this.MoSpriteCanvas.PreScale = this.MoSpriteCanvas.ScaleImg;
                    this.MoSpriteCanvas.ScaleImg = 0.5f;
                }
                else if ("x  1" == sSelectedValue)
                {
                    this.MoSpriteCanvas.PreScale = this.MoSpriteCanvas.ScaleImg;
                    this.MoSpriteCanvas.ScaleImg = 1;
                }
                else if ("x  2" == sSelectedValue)
                {
                    this.MoSpriteCanvas.PreScale = this.MoSpriteCanvas.ScaleImg;
                    this.MoSpriteCanvas.ScaleImg = 2;
                }
                else if ("x  4" == sSelectedValue)
                {
                    this.MoSpriteCanvas.PreScale = this.MoSpriteCanvas.ScaleImg;
                    this.MoSpriteCanvas.ScaleImg = 4;
                }
                else if ("x  8" == sSelectedValue)
                {
                    this.MoSpriteCanvas.PreScale = this.MoSpriteCanvas.ScaleImg;
                    this.MoSpriteCanvas.ScaleImg = 8;
                }
                else if ("x 16" == sSelectedValue)
                {
                    this.MoSpriteCanvas.PreScale = this.MoSpriteCanvas.ScaleImg;
                    this.MoSpriteCanvas.ScaleImg = 16;
                }
                else
                {
                    this.MoSpriteCanvas.PreScale = this.MoSpriteCanvas.ScaleImg;
                    this.MoSpriteCanvas.ScaleImg = 1;
                }
            }
            else
            {
                // 未選択

                this.MoSpriteCanvas.PreScale = this.MoSpriteCanvas.ScaleImg;
                this.MoSpriteCanvas.ScaleImg = 1;
            }


            // 現在見えている画面上の中心を固定するようにズーム。
            if (null != this.bitmap_bg)
            {

                //
                // 位置調整 

                float multiple = this.MoSpriteCanvas.ScaleImg / this.MoSpriteCanvas.PreScale; //何倍になったか。

                // 画面の中心に位置する、ズームされた画像上の位置（固定点）
                float imgFixX = (this.Width / 2.0f) - this.bgLocation.X;
                float imgFixY = (this.Height / 2.0f) - this.bgLocation.Y;

                // 背景位置
                this.bgLocation.X -= imgFixX * multiple - imgFixX;
                this.bgLocation.Y -= imgFixY * multiple - imgFixY;
            }


            // 再描画
            this.Refresh();

            //
        //
        //
        //
        gt_ProcessEnd:
            return;
        }

        private void pcbtnSp_Click(object sender, EventArgs e)
        {
            this.pcdlgOpenSpriteFile.InitialDirectory = Application.StartupPath;
            DialogResult result = this.pcdlgOpenSpriteFile.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                // 絶対ファイルパス
                string sFpatha = this.pcdlgOpenSpriteFile.FileName;

                // スプライトについて
                {
                    // 画像ファイルが開かれたものとして、ビットマップにする。
                    try
                    {
                        if (null == this.MoSprite.Bitmap)
                        {
                            //
                            // まだ１回も画像が開かれていないとき。
                            //

                            // 枠線
                            this.pclblSpBorder.Enabled = true;
                            this.pcchkSpBorder.Checked = true;//初期値
                            this.pcchkSpBorder.Enabled = true;

                            // 十字線
                            this.MoSprite.BCross = true;
                            this.pclblSpCross.Enabled = true;
                            this.pcchkSpCross.Checked = true;//初期値
                            this.pcchkSpCross.Enabled = true;
                        }

                        this.MoSprite.Bitmap = new Bitmap(sFpatha);
                        this.pclblSpOpaque.Enabled = true;
                        this.pcddlSpOpaque.Enabled = true;
                        this.pclblAlScale.Enabled = true;
                        this.pcddlAlScale.Enabled = true;
                        this.pclblMouseDrag.Enabled = true;
                        this.pclstMouseDrag.Enabled = true;
                        this.pclstMouseDrag.SelectedIndex = 2;//「乗せる画像移動」を選択
                        this.pcbtnSpClr.Enabled = true;

                        this.ucSpriteParam.Enabled = true;

                        // 初期サイズ
                        this.MoSprite.SrcSize = new Size(this.MoSprite.Bitmap.Width, this.MoSprite.Bitmap.Height);

                        // 初期Dstサイズを、フォーム入力値と同じにします。
                        int nWidth;
                        if (int.TryParse(this.ucSpriteParam.PctxtDstWidthForced.Text, out nWidth))
                        {
                            this.MoSprite.DstSizeResult = new Size(
                                nWidth,
                                this.MoSprite.DstSizeResult.Height
                                );
                        }
                        else
                        {
                            this.MoSprite.DstSizeResult = new Size(
                                this.MoSprite.SrcSize.Width,//入力値が無ければソースサイズ。
                                this.MoSprite.DstSizeResult.Height
                                );
                        }
                        //
                        int nHeight;
                        if (int.TryParse(this.ucSpriteParam.PctxtDstHeightForced.Text, out nHeight))
                        {
                            this.MoSprite.DstSizeResult = new Size(
                                this.MoSprite.DstSizeResult.Width,
                                nHeight
                                );
                        }
                        else
                        {
                            this.MoSprite.DstSizeResult = new Size(
                                this.MoSprite.DstSizeResult.Width,
                                this.MoSprite.SrcSize.Height//入力値が無ければソースサイズ。
                                );
                        }
                        //System.Console.WriteLine("デバッグ　横幅＝[" + this.MoSprite.DstSizeResult.Width + "] 縦幅＝[" + this.MoSprite.DstSizeResult.Height + "]");

                        // 初期位置
                        this.MoSprite.MyCtOnBg = new PointF(
                            this.MoSprite.MyLtOnBgOsz.X + (float)this.MoSprite.Bitmap.Width / 2.0f,
                            this.MoSprite.MyLtOnBgOsz.Y + (float)this.MoSprite.Bitmap.Height / 2.0f
                            );

                        // フォームを再描画。
                        this.ucSpriteParam.RefreshSpriteSizeDisplay();
                        this.Refresh();
                    }
                    catch (ArgumentException)
                    {
                        // 座標位置はキープ。
                        this.EjectSp(true);
                    }
                }
            }
        }

        //────────────────────────────────────────

        private void XyMemoUc_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDraggingNone = true;
            this.mouseDragging = true;
            this.mouseDownLocation = e.Location;

            this.preDragLocation = e.Location;

            // フォーカスをコントロールから外すことで、フォーカスをフォームに戻します。
            this.ActiveControl = null;
        }

        //────────────────────────────────────────

        private void XyMemoUc_MouseMove(object sender, MouseEventArgs e)
        {
            int flag;
            if (this.BCtrlKey)
            {
                // 背景画像の移動
                flag = 2;
            }
            else if (this.BShiftKey)
            {
                // 乗せる画像の移動
                flag = 1;
            }
            else if (this.mouseDragModeEnum == EnumMousedragmode.SPRITE_MOVE)
            {
                // 乗せる画像の移動
                flag = 1;
            }
            else if (this.mouseDragModeEnum == EnumMousedragmode.BG_MOVE)
            {
                // 背景画像の移動
                flag = 2;
            }
            else
            {
                // 移動しない
                flag = 0;
            }

            if (1 == flag)
            {
                //
                // 乗せる画像移動
                //

                if (this.mouseDragging)
                {
                    // 前回ドラッグした位置との差分
                    float dx;
                    float dy;
                    if (this.mouseDraggingNone)
                    {
                        dx = 0;
                        dy = 0;
                        this.mouseDraggingNone = false;
                    }
                    else
                    {
                        dx = e.Location.X - this.preDragLocation.X;
                        dy = e.Location.Y - this.preDragLocation.Y;
                    }

                    this.MoveSpByGesture(dx, dy);

                    // ドラッグした位置
                    this.preDragLocation = e.Location;
                }
            }
            else if (2 == flag)
            {
                //
                // 背景画像移動
                //

                if (this.mouseDragging)
                {
                    // 前回ドラッグした位置との差分
                    float dx;
                    float dy;
                    if (this.mouseDraggingNone)
                    {
                        dx = 0;
                        dy = 0;
                        this.mouseDraggingNone = false;
                    }
                    else
                    {
                        dx = e.Location.X - this.preDragLocation.X;
                        dy = e.Location.Y - this.preDragLocation.Y;
                    }

                    this.MoveBg(dx, dy);

                    // ドラッグした位置
                    this.preDragLocation = e.Location;
                }
            }
        }

        private void XyMemoUc_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDragging = false;
        }

        private void XyMemoUc_Paint(object sender, PaintEventArgs e)
        {
            if (null == this.MoSpriteCanvas)
            {
                goto gt_ProcessEnd;
            }

            bool bOnWindow = true;

            // 背景画像
            this.PaintBg(e.Graphics, bOnWindow, this.MoSpriteCanvas.ScaleImg);

            // スプライト画像
            this.PaintSprite(e.Graphics, bOnWindow, this.MoSpriteCanvas.ScaleImg, this.bgLocation, this.infoDisplay);

            // 画面の中心を示す十字線
            //this.PaintCross(e.Graphics);

            // 情報表示
            new Subaction_View003().Paint(
                e.Graphics, bOnWindow,
                this.MoSprite, this.MoSpriteCanvas.ScaleImg, this.InfoDisplay);

            //
        //
        //
        //
        gt_ProcessEnd:
            return;
        }

        //────────────────────────────────────────

        private void pcddlOpaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == this.MoSprite)
            {
                goto gt_ProcessEnd;
            }

            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("100" == sSelectedValue)
                {
                    this.MoSprite.NOpaque = 1.0F;
                }
                else if (" 75" == sSelectedValue)
                {
                    this.MoSprite.NOpaque = 0.75F;
                }
                else if (" 50" == sSelectedValue)
                {
                    this.MoSprite.NOpaque = 0.50F;
                }
                else if (" 25" == sSelectedValue)
                {
                    this.MoSprite.NOpaque = 0.25F;
                }
                else
                {
                    this.MoSprite.NOpaque = 1.0F;
                }
            }
            else
            {
                // 未選択

                this.MoSprite.NOpaque = 1.0F;
            }

            //
        //
        //
        //
        gt_ProcessEnd:

            // 再描画
            this.Refresh();
        }

        /// <summary>
        /// 画像を保存。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbtnSaveImg_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void pcddlOpaqueBg_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("100" == sSelectedValue)
                {
                    this.bgOpaque = 1.0F;
                }
                else if (" 75" == sSelectedValue)
                {
                    this.bgOpaque = 0.75F;
                }
                else if (" 50" == sSelectedValue)
                {
                    this.bgOpaque = 0.50F;
                }
                else if (" 25" == sSelectedValue)
                {
                    this.bgOpaque = 0.25F;
                }
                else
                {
                    this.bgOpaque = 1.0F;
                }
            }
            else
            {
                // 未選択

                this.bgOpaque = 1.0F;
            }

            // 再描画
            this.Refresh();
        }

        private void pclstMouseDrag_SelectedIndexChanged(object sender, EventArgs e)
        {
            // リストボックス
            ListBox pclst = (ListBox)sender;

            if (0 <= pclst.SelectedIndex)
            {
                string sSelectedValue = (string)pclst.Items[pclst.SelectedIndex];

                if ("乗せる画像移動" == sSelectedValue)
                {
                    this.mouseDragModeEnum = EnumMousedragmode.SPRITE_MOVE;
                }
                else if ("背景画像移動" == sSelectedValue)
                {
                    this.mouseDragModeEnum = EnumMousedragmode.BG_MOVE;
                }
                else
                {
                    this.mouseDragModeEnum = EnumMousedragmode.NONE;
                }
            }
            else
            {
                // 未選択

                this.mouseDragModeEnum = EnumMousedragmode.NONE;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「乗せる画像」の[クリア]ボタン。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbtnSpClr_Click(object sender, EventArgs e)
        {
            // 「乗せる画像」を削除。

            // 座標位置もクリアー。
            this.EjectSp(false);
        }

        private void pcchkCross_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox pcchk = (CheckBox)sender;

            this.MoSprite.BCross = pcchk.Checked;

            this.Refresh();
        }

        private void pcchkSpBorder_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox pcchk = (CheckBox)sender;

            this.MoSprite.BBorder = pcchk.Checked;

            // 再描画
            this.Refresh();
        }

        private void pcddlBordercolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            Color clr;
            if (0 <= pcddl.SelectedIndex)
            {
                string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("自動" == sSelectedValue)
                {
                    clr = SystemColors.Control;
                }
                else
                {
                    clr = new ColorFromName().FromName(sSelectedValue);
                }
            }
            else
            {
                // 未選択

                clr = SystemColors.Control;
            }

            this.infoDisplay.GridPen = new Pen(clr);

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected MemorySpritecanvasImpl moSpriteCanvas;

        public MemorySpritecanvasImpl MoSpriteCanvas
        {
            get
            {
                return moSpriteCanvas;
            }
            set
            {
                moSpriteCanvas = value;
            }
        }

        //────────────────────────────────────────

        protected MemorySpritememoImpl moSprite;

        /// <summary>
        /// スプライト
        /// </summary>
        public MemorySpritememoImpl MoSprite
        {
            get
            {
                return moSprite;
            }
            set
            {
                moSprite = value;
            }
        }

        //────────────────────────────────────────

        protected Spritememo_InfoDisplay infoDisplay;

        public Spritememo_InfoDisplay InfoDisplay
        {
            get
            {
                return infoDisplay;
            }
        }

        //────────────────────────────────────────

        protected Bitmap bitmap_bg;

        //────────────────────────────────────────

        protected EnumMousedragmode mouseDragModeEnum;

        //────────────────────────────────────────

        /// <summary>
        /// マウスのドラッグをこれから始める最初なら真。
        /// </summary>
        protected bool mouseDraggingNone;

        //────────────────────────────────────────

        /// <summary>
        /// マウスをドラッグ中なら真。
        /// </summary>
        protected bool mouseDragging;

        //────────────────────────────────────────

        /// <summary>
        /// マウス押下点XY。
        /// </summary>
        protected PointF mouseDownLocation;

        //────────────────────────────────────────

        /// <summary>
        /// 1つ前のドラッグ点XY。
        /// </summary>
        protected PointF preDragLocation;

        //────────────────────────────────────────

        /// <summary>
        /// 背景画像の点XY。
        /// </summary>
        protected PointF bgLocation;

        //────────────────────────────────────────

        /// <summary>
        /// 背景画像の不透明度。0.0F～1.0F。
        /// </summary>
        protected float bgOpaque;

        //────────────────────────────────────────

        protected bool bShiftKey;

        /// <summary>
        /// [Shift]キーが押されていれば真。
        /// </summary>
        public bool BShiftKey
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
        public bool BCtrlKey
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
        #endregion



    }
}
