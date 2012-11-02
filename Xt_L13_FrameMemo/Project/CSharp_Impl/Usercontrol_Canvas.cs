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
    public partial class Usercontrol_Canvas : UserControl, Usercontrolview
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Usercontrol_Canvas()
        {
            InitializeComponent();

            //部品番号
            {
                this.Partnumberconfig = new PartnumberconfigImpl();
                this.Partnumberconfig.FirstIndex = 0;

                this.Partnumberconfig.SetBrushByColor( Color.FromArgb(192, 0, 255, 0));//75%透明の緑。
            }

            //添付情報
            {
                this.infodisplay = new Usercontrolview_Infodisplay();
            }

            MemorySpriteImpl moSprite = new MemorySpriteImpl();
            moSprite.List_Usercontrolview.Add(this.infodisplay);
            moSprite.List_Usercontrolview.Add(this.ucFrameParam);
            moSprite.List_Usercontrolview.Add(this);
            this.ucFrameParam.MemorySprite = moSprite;
            this.infodisplay.MemorySprite = moSprite;


            this.enumMousedragmode = EnumMousedragmode.None;

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

            this.pcchkGridVisibled.Checked = true;

            // 格子枠の色
            this.pcddlGridColor.Items.Add("自動");
            this.pcddlGridColor.Items.Add("白");
            this.pcddlGridColor.Items.Add("灰色");
            this.pcddlGridColor.Items.Add("黒");
            this.pcddlGridColor.Items.Add("赤");
            this.pcddlGridColor.Items.Add("黄");
            this.pcddlGridColor.Items.Add("緑");//初期選択
            this.pcddlGridColor.Items.Add("青");
            this.pcddlGridColor.SelectedIndex = 6;

            this.scale = 1;
            this.preScale = 1;

            //部品番号の色
            this.pcddlPartnumberColor.Items.Add("自動");
            this.pcddlPartnumberColor.Items.Add("白");
            this.pcddlPartnumberColor.Items.Add("灰色");
            this.pcddlPartnumberColor.Items.Add("黒");
            this.pcddlPartnumberColor.Items.Add("赤");
            this.pcddlPartnumberColor.Items.Add("黄");
            this.pcddlPartnumberColor.Items.Add("緑");//初期選択
            this.pcddlPartnumberColor.Items.Add("青");
            this.pcddlPartnumberColor.SelectedIndex = 6;

            //部品番号の半透明度
            this.pcddlPartnumberOpaque.Items.Add("100");
            this.pcddlPartnumberOpaque.Items.Add(" 75");//初期選択
            this.pcddlPartnumberOpaque.Items.Add(" 50");
            this.pcddlPartnumberOpaque.Items.Add(" 25");
            this.pcddlPartnumberOpaque.SelectedIndex = 1;

            //部品番号の開始インデックス
            this.pctxtPartnumberFirst.Text = "0";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void OnChanged_CountcolumnResult(float nValue)
        {
        }

        //────────────────────────────────────────

        public void OnChanged_CountrowResult(float nValue)
        {
        }

        //────────────────────────────────────────

        public void OnChanged_WidthcellResult(float nValue)
        {
        }

        //────────────────────────────────────────

        public void OnChanged_HeightcellResult(float nVlaue)
        {
        }

        //────────────────────────────────────────

        public void OnChanged_CropForce(int nValue)
        {
        }

        //────────────────────────────────────────

        public void OnChanged_CropLastResult(int nValue)
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
            if (this.enumMousedragmode == EnumMousedragmode.Image_Move)
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
            this.infodisplay.MemorySprite.Lefttop = new PointF(
                this.infodisplay.MemorySprite.Lefttop.X + dx,
                this.infodisplay.MemorySprite.Lefttop.Y + dy
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
            if (null != this.infodisplay.MemorySprite.Bitmap)
            {
                if (this.infodisplay.MemorySprite.IsCrop)
                {
                    // 切抜き

                    Function2DrawcropImpl f2 = new Function2DrawcropImpl();
                    f2.Perform(
                        g,
                        bOnWindow,
                        this.infodisplay.MemorySprite,
                        baseX,
                        baseY,
                        scale2,
                        this.imgOpaque,
                        this.isImageGrid,
                        this.pcchkInfoVisibled.Checked,
                        this.infodisplay
                        );
                }
                else
                {
                    // 全体図

                    Function1DrawimageImpl f1 = new Function1DrawimageImpl();
                    f1.Perform(
                        g,
                        bOnWindow,
                        this.infodisplay.MemorySprite,
                        baseX,
                        baseY,
                        scale2,
                        this.imgOpaque,
                        this.isImageGrid,
                        this.pcchkInfoVisibled.Checked,
                        this.Partnumberconfig,
                        this.Infodisplay
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

                    //枠線
                    this.pclblGrid1.Enabled = true;
                    this.pcchkGridVisibled.Enabled = true;
                    this.pcddlGridColor.Enabled = true;

                    this.pclblInfo1.Enabled = true;
                    this.pcchkInfoVisibled.Enabled = true;

                    //部品番号
                    this.pclblPartnumber1.Enabled = true;
                    this.pcddlPartnumberOpaque.Enabled = true;
                    this.pclblPartnumber2.Enabled = true;
                    this.pcchkPartnumberVisible.Enabled = true;
                    this.pcddlPartnumberColor.Enabled = true;
                    this.pclblPartnumber3.Enabled = true;
                    this.pctxtPartnumberFirst.Enabled = true;


                    this.infodisplay.Filepath = sFpatha;

                    this.ucFrameParam.OnImageOpened();

                    this.infodisplay.MemorySprite.IsAutoinputting = true;//自動入力開始
                    // 画像設定
                    this.infodisplay.MemorySprite.Bitmap = new Bitmap(sFpatha);

                    this.infodisplay.MemorySprite.Lefttop = new Point(//.Lt
                        this.Width / 2 - this.infodisplay.MemorySprite.Bitmap.Width / 2,
                        this.Height / 2 - this.infodisplay.MemorySprite.Bitmap.Height / 2
                        );

                    // フォームを再描画。
                    this.Refresh();
                    this.infodisplay.MemorySprite.IsAutoinputting = false;//自動入力終了
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

                    //枠線
                    this.pclblGrid1.Enabled = false;
                    this.pcchkGridVisibled.Enabled = false;
                    this.pcddlGridColor.Enabled = false;

                    //部品番号
                    this.pclblPartnumber1.Enabled = false;
                    this.pcddlPartnumberOpaque.Enabled = false;
                    this.pclblPartnumber2.Enabled = false;
                    this.pcchkPartnumberVisible.Enabled = false;
                    this.pcddlPartnumberColor.Enabled = false;
                    this.pclblPartnumber3.Enabled = false;
                    this.pctxtPartnumberFirst.Enabled = false;

                    this.ucFrameParam.OnImageClosed();

                    this.infodisplay.MemorySprite.IsAutoinputting = true;//自動入力開始
                    this.infodisplay.MemorySprite.Bitmap = null;

                    // フォームを再描画。
                    this.Refresh();
                    this.infodisplay.MemorySprite.IsAutoinputting = false;//自動入力終了
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
            if (null != this.infodisplay.MemorySprite.Bitmap)
            {

                //
                // 位置調整 

                float multiple = this.scale / this.preScale; //何倍になったか。

                // 画面の中心に位置する、ズームされた画像上の位置（固定点）
                float imgFixX = (this.Width / 2.0f) - this.infodisplay.MemorySprite.Lefttop.X;
                float imgFixY = (this.Height / 2.0f) - this.infodisplay.MemorySprite.Lefttop.Y;

                // 背景位置
                this.infodisplay.MemorySprite.Lefttop = new PointF(//.Lt
                    this.infodisplay.MemorySprite.Lefttop.X - (imgFixX * multiple - imgFixX),
                    this.infodisplay.MemorySprite.Lefttop.Y - (imgFixY * multiple - imgFixY)
                    );
            }


            // 再描画
            this.Refresh();
        }

        private void Canvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDraggingNone = true;
            this.mouseDragging = true;
            this.mouseDownLocation = e.Location;

            this.preDragLocation = e.Location;

            // フォーカスをコントロールから外すことで、フォーカスをフォームに戻します。
            this.ActiveControl = null;
        }

        //────────────────────────────────────────

        private void Canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.enumMousedragmode == EnumMousedragmode.Image_Move)
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

        private void Canvas1_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDragging = false;
        }

        private void Canvas1_Paint(object sender, PaintEventArgs e)
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

        private void pclstMouseDrag_SelectedIndexChanged(object sender, EventArgs e)
        {
            // リストボックス
            ListBox pclst = (ListBox)sender;

            if (0 <= pclst.SelectedIndex)
            {
                string sSelectedValue = (string)pclst.Items[pclst.SelectedIndex];

                if ("画像移動" == sSelectedValue)
                {
                    this.enumMousedragmode = EnumMousedragmode.Image_Move;
                }
                else
                {
                    this.enumMousedragmode = EnumMousedragmode.None;
                }
            }
            else
            {
                // 未選択

                this.enumMousedragmode = EnumMousedragmode.None;
            }
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
                    this.isImageGrid = false;
                }
                else if ("あり" == sSelectedValue)
                {
                    this.isImageGrid = true;
                }
                else
                {
                    this.isImageGrid = false;
                }
            }
            else
            {
                // 未選択

                this.isImageGrid = false;
            }

            // 再描画
            this.Refresh();
        }

        private void pcchkImgBorder_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox pcchk = (CheckBox)sender;

            this.isImageGrid = pcchk.Checked;

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
            new Function3Save1Impl().Save(
                this.Infodisplay,
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
            new Function5Save2Impl().Save(
                this.Infodisplay,
                this.PcchkInfo,
                this
                );
        }

        //────────────────────────────────────────
        #endregion




        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// 枠線の色。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcddlGridcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            Color clr;
            if (0 <= pcddl.SelectedIndex)
            {
                string valueSelected = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("自動" == valueSelected)
                {
                    clr = SystemColors.Control;
                }
                else
                {
                    clr = new ColorFromName().FromName(valueSelected);
                }
            }
            else
            {
                // 未選択

                clr = SystemColors.Control;
            }

            this.infodisplay.GridPen = new Pen(clr);

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 部品番号の色。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcddlPartnumberColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            Color clr;
            if (0 <= pcddl.SelectedIndex)
            {
                string valueSelected = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("自動" == valueSelected)
                {
                    clr = SystemColors.Control;
                }
                else
                {
                    clr = new ColorFromName().FromName(valueSelected);
                }
            }
            else
            {
                // 未選択

                clr = SystemColors.Control;
            }

            this.Partnumberconfig.SetBrushByColor( clr);

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 画像の不透明度。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcddlOpaqueBg_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string valueSelected = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("100" == valueSelected)
                {
                    this.imgOpaque = 1.0F;
                }
                else if (" 75" == valueSelected)
                {
                    this.imgOpaque = 0.75F;
                }
                else if (" 50" == valueSelected)
                {
                    this.imgOpaque = 0.50F;
                }
                else if (" 25" == valueSelected)
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

        //────────────────────────────────────────

        /// <summary>
        /// 部品番号の不透明度。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcddlPartnumberOpaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ドロップダウンリスト
            ComboBox pcddl = (ComboBox)sender;

            if (0 <= pcddl.SelectedIndex)
            {
                string valueSelected = (string)pcddl.Items[pcddl.SelectedIndex];

                if ("100" == valueSelected)
                {
                    this.Partnumberconfig.SetBrushByAlpha( 255);
                }
                else if (" 75" == valueSelected)
                {
                    this.Partnumberconfig.SetBrushByAlpha( 192);
                }
                else if (" 50" == valueSelected)
                {
                    this.Partnumberconfig.SetBrushByAlpha( 128);
                }
                else if (" 25" == valueSelected)
                {
                    this.Partnumberconfig.SetBrushByAlpha( 64);
                }
                else
                {
                    this.Partnumberconfig.SetBrushByAlpha( 255);
                }
            }
            else
            {
                // 未選択

                this.Partnumberconfig.SetBrushByAlpha( 255);
            }

            // 再描画
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 添付情報表示チェックボックス。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcchkInfo_CheckedChanged(object sender, EventArgs e)
        {
            // 再描画。
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 部品番号表示チェックボックス。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcchkPartnumberVisible_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox pcchk = (CheckBox)sender;

            this.Partnumberconfig.Visibled = pcchk.Checked;

            // 再描画。
            this.Refresh();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 部品番号開始インデックス。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctxtPartnumberFirst_TextChanged(object sender, EventArgs e)
        {
            TextBox pctxt = (TextBox)sender;

            int number;
            if (int.TryParse(pctxt.Text, out number))
            {
                this.Partnumberconfig.FirstIndex = number;
            }
            else
            {
                //エラー
                this.Partnumberconfig.FirstIndex = 0;
            }

            // 再描画。
            this.Refresh();
        }

        //────────────────────────────────────────
        #endregion




        #region プロパティー
        //────────────────────────────────────────

        protected EnumMousedragmode enumMousedragmode;

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
        protected bool isImageGrid;

        //────────────────────────────────────────

        private PartnumberconfigImpl partnumberconfig;

        public PartnumberconfigImpl Partnumberconfig
        {
            get
            {
                return this.partnumberconfig;
            }
            set
            {
                this.partnumberconfig = value;
            }
        }

        //────────────────────────────────────────

        protected Usercontrolview_Infodisplay infodisplay;

        /// <summary>
        /// width,height,ファイル名等表示。
        /// </summary>
        public Usercontrolview_Infodisplay Infodisplay
        {
            get
            {
                return infodisplay;
            }
        }

        //────────────────────────────────────────

        public CheckBox PcchkInfo
        {
            get
            {
                return pcchkInfoVisibled;
            }
        }

        //────────────────────────────────────────

        public Usercontrol_FrameParam Usercontrol_FrameParam
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
