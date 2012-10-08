using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xenon.XyMemo
{
    public partial class Form1 : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            MemorySpritememoImpl moSprite = new MemorySpritememoImpl();
            this.xyMemoUc1.InitializeBeforeUse(moSprite);
            moSprite.VoSpriteList.Add(this.xyMemoUc1);
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.xyMemoUc1.Size = this.ClientSize;
            this.Refresh();
        }

        //────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            // タイトル
            {
                StringBuilder s = new StringBuilder();

                s.Append("XyMemo v");
                s.Append(Application.ProductVersion);
                s.Append(" - Xenon Tools");

                this.Text = s.ToString();
            }


            this.xyMemoUc1.Focus();

            this.xyMemoUc1.Size = this.ClientSize;
            this.Refresh();
        }

        //────────────────────────────────────────

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            // bug:リストボックスで　カーソルを動かしているときも、利いてしまう。

            if (e.Control)
            {
                this.xyMemoUc1.BCtrlKey = true;

                switch (e.KeyCode)
                {
                    case Keys.S:
                        {
                            // [Ctrl]+[S]
                            this.xyMemoUc1.Save();
                        }
                        break;
                }
            }
            else if (e.Shift)
            {
                this.xyMemoUc1.BShiftKey = true;
            }



            {
                int dx;
                int dy;
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            // [↑]
                            dx = (int)(0 * this.xyMemoUc1.MoSpriteCanvas.ScaleImg);
                            dy = (int)(-1 * this.xyMemoUc1.MoSpriteCanvas.ScaleImg);

                            if (this.xyMemoUc1.BCtrlKey)
                            {
                                // 画像全体を動かす。
                                this.xyMemoUc1.MoveBg(dx, dy);
                            }
                            else if (this.xyMemoUc1.BShiftKey)
                            {
                                // スプライトだけ動かす。
                                this.xyMemoUc1.MoveSpByGesture(dx, dy);
                            }
                            else
                            {
                                this.xyMemoUc1.MoveActiveSprite(dx, dy);
                            }

                        }
                        break;
                    case Keys.Right:
                        {
                            // [→]
                            dx = (int)(1 * this.xyMemoUc1.MoSpriteCanvas.ScaleImg);
                            dy = (int)(0 * this.xyMemoUc1.MoSpriteCanvas.ScaleImg);

                            if (this.xyMemoUc1.BCtrlKey)
                            {
                                // 画像全体を動かす。
                                this.xyMemoUc1.MoveBg(dx, dy);
                            }
                            else if (this.xyMemoUc1.BShiftKey)
                            {
                                // スプライトだけ動かす。
                                this.xyMemoUc1.MoveSpByGesture(dx, dy);
                            }
                            else
                            {
                                this.xyMemoUc1.MoveActiveSprite(dx, dy);
                            }

                        }
                        break;
                    case Keys.Down:
                        {
                            // [↓]
                            dx = (int)(0 * this.xyMemoUc1.MoSpriteCanvas.ScaleImg);
                            dy = (int)(1 * this.xyMemoUc1.MoSpriteCanvas.ScaleImg);

                            if (this.xyMemoUc1.BCtrlKey)
                            {
                                // 画像全体を動かす。
                                this.xyMemoUc1.MoveBg(dx, dy);
                            }
                            else if (this.xyMemoUc1.BShiftKey)
                            {
                                // スプライトだけ動かす。
                                this.xyMemoUc1.MoveSpByGesture(dx, dy);
                            }
                            else
                            {
                                this.xyMemoUc1.MoveActiveSprite(dx, dy);
                            }

                        }
                        break;
                    case Keys.Left:
                        {
                            // [←]
                            dx = (int)(-1 * this.xyMemoUc1.MoSpriteCanvas.ScaleImg);
                            dy = (int)(0 * this.xyMemoUc1.MoSpriteCanvas.ScaleImg);

                            if (this.xyMemoUc1.BCtrlKey)
                            {
                                // 画像全体を動かす。
                                this.xyMemoUc1.MoveBg(dx, dy);
                            }
                            else if (this.xyMemoUc1.BShiftKey)
                            {
                                // スプライトだけ動かす。
                                this.xyMemoUc1.MoveSpByGesture(dx, dy);
                            }
                            else
                            {
                                this.xyMemoUc1.MoveActiveSprite(dx, dy);
                            }

                        }
                        break;

                    case Keys.B:
                        {
                            // [B](back)背景画像の移動モードへ。
                            this.xyMemoUc1.ToBgMoveMode();
                        }
                        break;

                    case Keys.F:
                        {
                            // [F](front)スプライト画像の移動モードへ。
                            this.xyMemoUc1.ToSpMoveMode();
                        }
                        break;

                    case Keys.X:
                        {
                            // [X]ズームダウン
                            this.xyMemoUc1.ZoomDown();
                        }
                        break;

                    case Keys.Z:
                        {
                            // [Z]ズームアップ
                            this.xyMemoUc1.ZoomUp();
                        }
                        break;
                }
            }

        }

        //────────────────────────────────────────

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.xyMemoUc1.BCtrlKey = false;
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                this.xyMemoUc1.BShiftKey = false;
            }
        }

        //────────────────────────────────────────
        #endregion
        


    }
}
