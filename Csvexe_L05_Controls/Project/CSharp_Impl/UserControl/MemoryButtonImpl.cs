using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Xenon.Controls
{
    class MemoryButtonImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryButtonImpl()
        {
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

        private Rectangle boundsShadow1OrNull;

        /// <summary>
        /// 影１の位置とサイズ。無ければヌル。
        /// 
        ///枠線の太さは?px。
        ///　　　　　　　　?px
        ///　　┌────┐
        ///　　│　　　　│　　?px
        ///　　│　　　　├─┐
        ///　　│　　　　│影│
        ///　　│　　　　│１│
        ///　　└─┬──┤　│
        ///　?px　 │影２│　│
        ///　　　　└──┴─┘
        ///　　　?px
        /// </summary>
        public Rectangle BoundsShadow1OrNull
        {
            get
            {
                return this.boundsShadow1OrNull;
            }
            set
            {
                this.boundsShadow1OrNull = value;
            }
        }

        //────────────────────────────────────────

        private Rectangle boundsShadow2OrNull;

        /// <summary>
        /// 影２の位置とサイズ。無ければヌル。
        /// 
        ///枠線の太さは?px。
        ///　　　　　　　　?px
        ///　　┌────┐
        ///　　│　　　　│　　?px
        ///　　│　　　　├─┐
        ///　　│　　　　│影│
        ///　　│　　　　│１│
        ///　　└─┬──┤　│
        ///　?px　 │影２│　│
        ///　　　　└──┴─┘
        ///　　　?px
        /// </summary>
        public Rectangle BoundsShadow2OrNull
        {
            get
            {
                return this.boundsShadow2OrNull;
            }
            set
            {
                this.boundsShadow2OrNull = value;
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
        /// ボタンのラベルのフォント。
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
        /// ボタンの上にマウスカーソルが乗っていればtrue。
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
