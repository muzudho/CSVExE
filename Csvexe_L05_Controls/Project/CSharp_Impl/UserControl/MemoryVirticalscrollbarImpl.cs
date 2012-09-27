using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Xenon.Controls
{
    /// <summary>
    /// 縦スクロールバー。
    /// </summary>
    class MemoryVirticalscrollbarImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryVirticalscrollbarImpl()
        {
            this.memoryUpbutton = new MemoryButtonImpl();
            this.memoryUpbutton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128))); ;

            this.memoryDownbutton = new MemoryButtonImpl();
            this.memoryDownbutton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128))); ;

            this.bounds = new Rectangle();
            this.foreBrush = new SolidBrush(SystemColors.ControlText);
            this.backBrush = new SolidBrush(SystemColors.Control);
            this.font = new System.Drawing.Font("MS UI Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bMousePointed = false;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryButtonImpl memoryUpbutton;

        /// <summary>
        /// 「▲ボタン」の位置・サイズ。
        /// </summary>
        public MemoryButtonImpl MemoryUpbutton
        {
            get
            {
                return this.memoryUpbutton;
            }
            set
            {
                this.memoryUpbutton = value;
            }
        }

        //────────────────────────────────────────

        private MemoryButtonImpl memoryDownbutton;

        /// <summary>
        /// 「▼」ボタンの位置・サイズ。
        /// </summary>
        public MemoryButtonImpl MemoryDownbutton
        {
            get
            {
                return this.memoryDownbutton;
            }
            set
            {
                this.memoryDownbutton = value;
            }
        }

        //────────────────────────────────────────

        private Rectangle bounds;

        /// <summary>
        /// 位置とサイズ。
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return this.bounds;
            }
            set
            {
                this.bounds = value;
            }
        }

        //────────────────────────────────────────

        private Brush foreBrush;

        /// <summary>
        /// 描画色。
        /// </summary>
        public Brush ForeBrush
        {
            get
            {
                return this.foreBrush;
            }
            set
            {
                this.foreBrush = value;
            }
        }

        //────────────────────────────────────────

        private Brush backBrush;

        /// <summary>
        /// 背景色。
        /// </summary>
        public Brush BackBrush
        {
            get
            {
                return this.backBrush;
            }
            set
            {
                this.backBrush = value;
            }
        }

        //────────────────────────────────────────

        private Font font;

        /// <summary>
        /// 「▲」や「▼」のフォント。
        /// </summary>
        public Font Font
        {
            get
            {
                return this.font;
            }
            set
            {
                this.font = value;
            }
        }

        //────────────────────────────────────────

        private bool bMousePointed;

        /// <summary>
        /// 「▲ボタン」の上にマウスカーソルが乗っていればtrue。
        /// </summary>
        public bool BMousePointed
        {
            get
            {
                return this.bMousePointed;
            }
            set
            {
                this.bMousePointed = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
