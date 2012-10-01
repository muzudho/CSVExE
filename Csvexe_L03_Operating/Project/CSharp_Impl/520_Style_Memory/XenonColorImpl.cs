using System;
using System.Collections.Generic;
using System.Drawing;//Color
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    public class XenonColorImpl : XenonColor
    {


        
        #region 生成と破棄
        //────────────────────────────────────────

        public XenonColorImpl()
        {
            color = Color.Gray;
            this.sName_Color = "";
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Color color;

        /// <summary>
        /// 色。
        /// </summary>
        public Color Color
        {
            set
            {
                color = value;
            }
            get
            {
                return color;
            }
        }

        //────────────────────────────────────────

        private string sName_Color;

        /// <summary>
        /// 色の名前。
        /// </summary>
        public string Name_Color
        {
            get
            {
                return sName_Color;
            }
            set
            {
                sName_Color = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
