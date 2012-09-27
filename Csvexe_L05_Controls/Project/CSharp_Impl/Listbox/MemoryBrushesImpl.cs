using System;
using System.Collections.Generic;
using System.Drawing;//Brush
using System.Linq;
using System.Text;

using Xenon.Middle;//BrushesStorage
using Xenon.Operating;//NStyle

namespace Xenon.Controls
{
    public class MemoryBrushesImpl : MemoryBrushes
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryBrushesImpl()
        {
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 使わなくなったら呼び出してください。
        /// </summary>
        public void Dispose()
        {
            if (null != this.dictionary_Brush)
            {
                foreach (Brush brush in this.dictionary_Brush.Values)
                {
                    brush.Dispose();
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// ブラシの再利用。
        /// </summary>
        /// <param name="nStyle"></param>
        /// <returns></returns>
        public Brush GetByStyle(XenonStyle xenonStyle)
        {
            if (null == this.dictionary_Brush)
            {
                this.dictionary_Brush = new Dictionary<string, Brush>();
            }

            if (this.dictionary_Brush.ContainsKey(xenonStyle.ForeXenonColor.SName_Color))
            {
                return this.dictionary_Brush[xenonStyle.ForeXenonColor.SName_Color];
            }

            //
            // 指定の色のブラシを作成。
            Brush brush = new SolidBrush(xenonStyle.ForeXenonColor.Color);
            this.dictionary_Brush[xenonStyle.ForeXenonColor.SName_Color] = brush;
            return brush;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ブラシの再利用。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Brush GetByName(string sName)
        {
            if (null == this.dictionary_Brush)
            {
                this.dictionary_Brush = new Dictionary<string, Brush>();
            }

            if (this.dictionary_Brush.ContainsKey(sName))
            {
                return this.dictionary_Brush[sName];
            }

            if ("BRUSH_listItem_emptyRecord" == sName)
            {
                Brush brush = new SolidBrush(Color.LightGray);
                this.dictionary_Brush["BRUSH_listItem_emptyRecord"] = brush;
                return brush;
            }
            else if ("BRUSH_listItem_existsData" == sName)
            {
                Brush brush = new SolidBrush(Color.Black);
                this.dictionary_Brush["BRUSH_listItem_existsData"] = brush;
                return brush;
            }
            else if ("BRUSH_listItem_error" == sName)
            {
                Brush brush = new SolidBrush(Color.Red);
                this.dictionary_Brush["BRUSH_listItem_error"] = brush;
                return brush;
            }
            else
            {
                return null;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<string, Brush> dictionary_Brush;

        //────────────────────────────────────────
        #endregion



    }
}
