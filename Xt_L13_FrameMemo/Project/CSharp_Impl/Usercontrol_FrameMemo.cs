using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Lib;

namespace Xenon.FrameMemo
{
    public partial class Usercontrol_FrameMemo : UserControl, ViewFrame
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Usercontrol_FrameMemo()
        {
            InitializeComponent();

            this.infoDisplay = new ViewFrame_InfoDisplay();

            MemorySpriteImpl moSprite = new MemorySpriteImpl();
            moSprite.VoFrameList.Add(this.infoDisplay);
            moSprite.VoFrameList.Add(this.ucFrameParam);
            moSprite.VoFrameList.Add(this);
            this.ucFrameParam.MoSprite = moSprite;
            this.infoDisplay.MoSprite = moSprite;


            this.mouseDragModeEnum = EnumMousedragmode.NONE;

            this.pclstMouseDrag.Items.Add("なし");
            this.pclstMouseDrag.Items.Add("画像移動");
            this.pclstMouseDrag.SelectedIndex = 0;

            this.pcddlAlScale.Items.Add("x0.25");
            this.pcddlAlScale.Items.Add("x0.5");
            this.pcddlAlScale.Items.Add("x  1");//初期選択
            this.pcddlAlScale.Items.Add("x  2");
            this.pcddlAlScale.Items.Add("x  4");
            this.pcddlAlScale.Items.Add("x  8");
            this.pcddlAlScale.Items.Add("x 16");
            this.pcddlAlScale.SelectedIndex = 2;

            this.pcddlBgclr.Items.Add("自動");//初期選択
            this.pcddlBgclr.Items.Add("白");
            this.pcddlBgclr.Items.Add("灰色");
            this.pcddlBgclr.Items.Add("黒");
            this.pcddlBgclr.Items.Add("赤");
            this.pcddlBgclr.Items.Add("黄");
            this.pcddlBgclr.Items.Add("緑");
            this.pcddlBgclr.Items.Add("青");
            this.pcddlBgclr.SelectedIndex = 0;

            this.pcddlOpaque.Items.Add("100");//初期選択
            this.pcddlOpaque.Items.Add(" 75");
            this.pcddlOpaque.Items.Add(" 50");
            this.pcddlOpaque.Items.Add(" 25");
            this.pcddlOpaque.SelectedIndex = 0;
            this.imgOpaque = 1.0F;

            this.pcchkImgBorder.Checked = true;

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

            this.scale = 1;
            this.preScale = 1;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void OnColumnCountResultChanged(float nValue)
        {
        }

        //────────────────────────────────────────

        public void OnRowCountResultChanged(float nValue)
        {
        }

        //────────────────────────────────────────

        public void OnCellWidthResultChanged(float nValue)
        {
        }

        //────────────────────────────────────────

        public void OnCellHeightResultChanged(float nVlaue)
        {
        }

        //────────────────────────────────────────

        public void OnCropForceChanged(int nValue)
        {
        }

        //────────────────────────────────────────

        public void OnCropLastResultChanged(int nValue)
        {
        }

        //────────────────────────────────────────

        /// <summary>
        /// カーソルキーで1px動かしたいときなどに。
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void MoveActiveSprite(float dx, float dy)
        {
            if (this.mouseDragModeEnum == EnumMousedragmode.IMG_MOVE)
            {
                //
                // 画像移動
                //
                this.MoveImg(dx, dy);
            }

        }

        //────────────────────────────────────────

        private void MoveImg(float dx, float dy)
        {
            // 背景画像移動
            this.infoDisplay.MoSprite.Lt = new PointF(
                this.infoDisplay.MoSprite.Lt.X + dx,
                this.infoDisplay.MoSprite.Lt.Y + dy
                );

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bOnWindow"></param>
        /// <param name="baseX"></param>
        /// <param name="baseY"></param>
        /// <param name="scale2"></param>
        public void PaintSprite(
            Graphics g,
            bool bOnWindow,
            float baseX,
            float baseY,
            float scale2
            )
        {
            if (null != this.infoDisplay.MoSprite.Bitmap)
            {
                if (this.infoDisplay.MoSprite.BCrop)
                {
                    // 切抜き

                    Subaction002 act2 = new Subaction002();
                    act2.Perform(
                        g,
                        bOnWindow,
                        this.infoDisplay.MoSprite,
                        baseX,
                        baseY,
                        scale2,
                        this.imgOpaque,
                        this.bImgGrid,
                        this.pcchkInfo.Checked,
                        this.infoDisplay
                        );
                }
                else
                {
                    // 全体図

                    Subaction001 act1 = new Subaction001();
                    act1.Perform(
                        g,
                        bOnWindow,
                        this.infoDisplay.MoSprite,
                        baseX,
                        baseY,
                        scale2,
                        this.imgOpaque,
                        this.bImgGrid,
                        this.pcchkInfo.Checked,
                        this.infoDisplay
                        );
                }
            }
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

        //────────────────────────────────────────

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
                    this.pcbtnSaveImg.Enabled = true;
                    this.pcbtnSaveImgFrames.Enabled = true;
                    this.pclblOpaque.Enabled = true;
                    this.pcddlOpaque.Enabled = true;
                    this.pclblBgclr.Enabled = true;
                    this.pcddlBgclr.Enabled = true;
                    this.pclblAlScale.Enabled = true;
                    this.pcddlAlScale.Enabled = true;
                    this.pclblMouseDrag.Enabled = true;
                    this.pclstMouseDrag.Enabled = true;
                    this.pclstMouseDrag.SelectedIndex = 1;//「画像移動」を選択
                    this.pclblImgBorder.Enabled = true;
                    this.pcchkImgBorder.Enabled = true;

                    this.pclblInfo.Enabled = true;
                    this.pcchkInfo.Enabled = true;



                    this.infoDisplay.SFilePath = sFpatha;

                    this.ucFrameParam.OnImageOpened();

                    this.infoDisplay.MoSprite.BAutoInputting = true;//自動入力開始
                    // 画像設定
                    this.infoDisplay.MoSprite.Bitmap = new Bitmap(sFpatha);

                    this.infoDisplay.MoSprite.Lt = new Point(//.Lt
                        this.Width / 2 - this.infoDisplay.MoSprite.Bitmap.Width / 2,
                        this.Height / 2 - this.infoDisplay.MoSprite.Bitmap.Height / 2
                        );

                    // フォームを再描画。
                    this.Refresh();
                    this.infoDisplay.MoSprite.BAutoInputting = false;//自動入力終了
                }
                catch (ArgumentException)
                {
                    // 指定したファイルが画像じゃなかった。

                    this.pcbtnSaveImg.Enabled = false;
                    this.pcbtnSaveImgFrames.Enabled = false;
                    this.pclblOpaque.Enabled = false;
                    this.pcddlOpaque.Enabled = false;
                    this.pclblBgclr.Enabled = false;
                    this.pcddlBgclr.Enabled = false;
                    this.pclblAlScale.Enabled = false;
                    this.pcddlAlScale.Enabled = false;
                    this.pclblMouseDrag.Enabled = false;
                    this.pclstMouseDrag.Enabled = false;
                    this.pclstMouseDrag.SelectedIndex = 0;//「なし」を選択
                    this.pclblImgBorder.Enabled = false;
                    this.pcchkImgBorder.Enabled = false;

                    this.ucFrameParam.OnImageClosed();

                    this.infoDisplay.MoSprite.BAutoInputting = true;//自動入力開始
                    this.infoDisplay.MoSprite.Bitmap = null;

                    // フォームを再描画。
                    this.Refresh();
                    this.infoDisplay.MoSprite.BAutoInputting = false;//自動入力終了
                }

            }
            else if (result == DialogResult.Cancel)
            {
                //変更なし
            }
            else
            {
                // ？
                this.pcbtnSaveImg.Enabled = false;
                this.pcbtnSaveImgFrames.Enabled = false;
            }
        }

        private void pcddlScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("x0.25" == sSelectedValue)
                {
                    this.preScale = this.scale;
                    this.scale = 0.25f;
                }
                else if ("x0.5" == sSelectedValue)
                {
                    this.preScale = this.scale;
                    this.scale = 0.5f;
                }
                else if ("x  1" == sSelectedValue)
                {
                    this.preScale = this.scale;
                    this.scale = 1;
                }
                else if ("x  2" == sSelectedValue)
                {
                    this.preScale = this.scale;
                    this.scale = 2;
                }
                else if ("x  4" == sSelectedValue)
                {
                    this.preScale = this.scale;
                    this.scale = 4;
                }
                else if ("x  8" == sSelectedValue)
                {
                    this.preScale = this.scale;
                    this.scale = 8;
                }
                else if ("x 16" == sSelectedValue)
                {
                    this.preScale = this.scale;
                    this.scale = 16;
                }
                else
                {
                    this.preScale = this.scale;
                    this.scale = 1;
                }
            }
            else
            {
                // 未選択

                this.preScale = this.scale;
                this.scale = 1;
            }


            // 現在見えている画面上の中心を固定するようにズーム。
            if (null != this.infoDisplay.MoSprite.Bitmap)
            {

                //
                // 位置調整 

                float multiple = this.scale / this.preScale; //何倍になったか。

                // 画面の中心に位置する、ズームされた画像上の位置（固定点）
                float imgFixX = (this.Width / 2.0f) - this.infoDisplay.MoSprite.Lt.X;
                float imgFixY = (this.Height / 2.0f) - this.infoDisplay.MoSprite.Lt.Y;

                // 背景位置
                this.infoDisplay.MoSprite.Lt = new PointF(//.Lt
                    this.infoDisplay.MoSprite.Lt.X - (imgFixX * multiple - imgFixX),
                    this.infoDisplay.MoSprite.Lt.Y - (imgFixY * multiple - imgFixY)
                    );
            }


            // 再描画
            this.Refresh();
        }

        private void FrameMemoUc_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDraggingNone = true;
            this.mouseDragging = true;
            this.mouseDownLocation = e.Location;

            this.preDragLocation = e.Location;

            // フォーカスをコントロールから外すことで、フォーカスをフォームに戻します。
            this.ActiveControl = null;
        }

        //────────────────────────────────────────

        private void FrameMemoUc_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDragModeEnum == EnumMousedragmode.IMG_MOVE)
            {
                //
                // 画像移動
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

                    this.MoveImg(dx, dy);

                    // ドラッグした位置
                    this.preDragLocation = e.Location;
                }
            }
        }

        private void FrameMemoUc_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDragging = false;
        }

        private void FrameMemoUc_Paint(object sender, PaintEventArgs e)
        {

            // 画像
            this.PaintSprite(
                e.Graphics,
                true,
                0,
                0,
                this.scale
                );
        }

        private void pcddlOpaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("自動" == sSelectedValue)
                {
                    this.BackColor = SystemColors.Control;
                }
                else
                {
                    this.BackColor = new ColorFromName().FromName(sSelectedValue);
                }
            }
            else
            {
                // 未選択

                this.BackColor = SystemColors.Control;
            }

            // 再描画
            this.Refresh();
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
                    this.imgOpaque = 1.0F;
                }
                else if (" 75" == sSelectedValue)
                {
                    this.imgOpaque = 0.75F;
                }
                else if (" 50" == sSelectedValue)
                {
                    this.imgOpaque = 0.50F;
                }
                else if (" 25" == sSelectedValue)
                {
                    this.imgOpaque = 0.25F;
                }
                else
                {
                    this.imgOpaque = 1.0F;
                }
            }
            else
            {
                // 未選択

                this.imgOpaque = 1.0F;
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

                if ("画像移動" == sSelectedValue)
                {
                    this.mouseDragModeEnum = EnumMousedragmode.IMG_MOVE;
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

        private void pcchkInfo_CheckedChanged(object sender, EventArgs e)
        {
            // 再描画。
            this.Refresh();
        }

        //────────────────────────────────────────

        private void pcddlBorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string sSelectedValue = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("なし" == sSelectedValue)
                {
                    this.bImgGrid = false;
                }
                else if ("あり" == sSelectedValue)
                {
                    this.bImgGrid = true;
                }
                else
                {
                    this.bImgGrid = false;
                }
            }
            else
            {
                // 未選択

                this.bImgGrid = false;
            }

            // 再描画
            this.Refresh();
        }

        private void pcchkImgBorder_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox pcchk = (CheckBox)sender;

            this.bImgGrid = pcchk.Checked;

            // 再描画
            this.Refresh();
        }

        private void pcddlGridcolor_SelectedIndexChanged(object sender, EventArgs e)
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

        /// <summary>
        /// 画像を保存。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcbtnSaveImg_Click(object sender, EventArgs e)
        {
            new SubactionSave001().Save(
                this.InfoDisplay,
                this.PcchkInfo,
                this
                );
        }

        /// <summary>
        /// 全フレーム画像保存。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ccButtonEx1_Click(object sender, EventArgs e)
        {
            new SubactionSave002().Save(
                this.InfoDisplay,
                this.PcchkInfo,
                this
                );
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
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
        /// 拡大率。
        /// </summary>
        protected float scale;

        //────────────────────────────────────────

        /// <summary>
        /// 変更前の拡大率。
        /// </summary>
        protected float preScale;

        //────────────────────────────────────────

        /// <summary>
        /// 画像の不透明度。0.0F～1.0F。
        /// </summary>
        protected float imgOpaque;

        //────────────────────────────────────────

        /// <summary>
        /// 画像のグリッド線の有無。
        /// </summary>
        protected bool bImgGrid;

        //────────────────────────────────────────

        protected ViewFrame_InfoDisplay infoDisplay;

        /// <summary>
        /// width,height,ファイル名等表示。
        /// </summary>
        public ViewFrame_InfoDisplay InfoDisplay
        {
            get
            {
                return infoDisplay;
            }
        }

        //────────────────────────────────────────

        public CheckBox PcchkInfo
        {
            get
            {
                return pcchkInfo;
            }
        }

        //────────────────────────────────────────

        public Usercontrol_FrameParam Uc_FrameParam
        {
            get
            {
                return ucFrameParam;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
